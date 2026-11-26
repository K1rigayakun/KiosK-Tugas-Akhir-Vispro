Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Forms.Checkout
Imports VisproPrakProjectAkhir.Forms.Kasir
Imports VisproPrakProjectAkhir.Forms.Kiosk
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Umum

    ''' <summary>
    ''' Quick Demo Navigator (tombol F9) untuk berpindah cepat antar seluruh 20 layar
    ''' saat memvisualisasikan aplikasi atau presentasi tugas.
    ''' </summary>
    Public Class FrmDemoHub
        Private ReadOnly _ownerForm As Form
        Private ReadOnly _welcomeForm As FrmWelcome
        Private _pendingAction As Action

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not DesignMode Then cp.ExStyle = cp.ExStyle Or &H2000000
                Return cp
            End Get
        End Property

        Public Shared Sub ShowHub(owner As Form, Optional welcome As FrmWelcome = Nothing)
            Dim pending As Action = Nothing
            Using hub As New FrmDemoHub(owner, welcome)
                hub.ShowDialog(owner)
                pending = hub._pendingAction
            End Using
            pending?.Invoke()
        End Sub

        Public Sub New()
            Me.New(Nothing, Nothing)
        End Sub

        Public Sub New(owner As Form, welcome As FrmWelcome)
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModAnimasi.SiapkanTransisiMasuk(Me, 16)
            _ownerForm = owner
            _welcomeForm = welcome
            ApplyRuntimePolish()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            ModTema.GayaGunaCard(card, 16)
            hdr.BackColor = Color.Transparent
            hdr.UseTransparentBackground = True
            hdr.FillColor = ModTema.WarnaCharcoal
            hdr.BorderRadius = 14
            hdr.CustomizableEdges.BottomLeft = False
            hdr.CustomizableEdges.BottomRight = False
            lblH.Font = New Font(ModTema.FontJudul.FontFamily, 15.0F, FontStyle.Bold)
            ic.Image = BistroIcons.GetIcon(IconChar.SlidersH, ModTema.WarnaUtama, 22)

            ModTema.GayaGunaButtonDark(btnClose, 10)
            btnClose.FillColor = ModTema.WarnaCharcoalLembut
            btnClose.BorderColor = Color.FromArgb(88, 60, 46)
            btnClose.BorderThickness = 1
            AddHandler btnClose.Click, Sub() Close()

            For Each c In {col1, col2, col3}
                ModTema.GayaGunaCard(c, 16)
            Next
            lblCol1.ForeColor = ModTema.WarnaUtama
            lblCol2.ForeColor = ModTema.WarnaSukses
            lblCol3.ForeColor = ModTema.WarnaSekunder

            ' Ikat seluruh aksi melalui _pendingAction agar Hub tertutup bersih sebelum berpindah form
            BindDemoButton(btnDemoWelcome, IconChar.Store, Sub() JadwalkanAksi(AddressOf BukaWelcome))
            BindDemoButton(btnDemoMenu, IconChar.Utensils, Sub() JadwalkanAksi(AddressOf BukaMenuDemo))
            BindDemoButton(btnDemoDetail, IconChar.Burger, Sub() JadwalkanAksi(Sub()
                                                                                  Using f As New FrmDetailProduk(9)
                                                                                      TampilkanDialog(_ownerForm, f)
                                                                                  End Using
                                                                              End Sub))
            BindDemoButton(btnDemoKeranjang, IconChar.ShoppingCart, Sub() JadwalkanAksi(Sub()
                                                                                            ModKeranjang.IsiContohDemo()
                                                                                            Using f As New FrmKeranjang()
                                                                                                ModNavigasi.BukaHalamanModal(_ownerForm, f)
                                                                                            End Using
                                                                                        End Sub))
            BindDemoButton(btnDemoBayar, IconChar.Qrcode, Sub() JadwalkanAksi(Sub()
                                                                                  If ModKeranjang.JumlahItem() = 0 Then ModKeranjang.IsiContohDemo()
                                                                                  Dim r = ModPromo.HitungRincian(ModKeranjang.Subtotal(), "HEMAT10", 0)
                                                                                  Using f As New FrmPembayaran(r)
                                                                                      ModNavigasi.BukaHalamanModal(_ownerForm, f)
                                                                                  End Using
                                                                              End Sub))
            BindDemoButton(btnDemoStruk, IconChar.Receipt, Sub() JadwalkanAksi(Sub()
                                                                                   Using f As New FrmStruk(3, True)
                                                                                       TampilkanDialog(_ownerForm, f)
                                                                                   End Using
                                                                               End Sub))
            BindDemoButton(btnDemoIdle, IconChar.Clock, Sub() JadwalkanAksi(Sub() ModIdle.SimulasikanIdle()))
            BindDemoButton(btnDemoRating, IconChar.Star, Sub() JadwalkanAksi(Sub()
                                                                                 Using f As New FrmRating(3)
                                                                                     TampilkanDialog(_ownerForm, f)
                                                                                 End Using
                                                                             End Sub))

            BindDemoButton(btnDemoLogin, IconChar.Lock, Sub() JadwalkanAksi(AddressOf BukaLoginDemo))
            BindDemoButton(btnDemoKasir, IconChar.MoneyBillWave, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Kasir, "FrmKasir")))
            BindDemoButton(btnDemoDapur, IconChar.Fire, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Kasir, "FrmDapur")))
            BindDemoButton(btnDemoAntrian, IconChar.Desktop, Sub() JadwalkanAksi(AddressOf BukaAntrianDemo))
            BindDemoButton(btnDemoLog, IconChar.History, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Admin, "FrmLog")))
            BindDemoButton(btnDemoPengguna, IconChar.User, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Admin, "FrmPengguna")))
            BindDemoButton(btnDemoPengaturan, IconChar.Cog, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Admin, "FrmPengaturan")))

            BindDemoButton(btnDemoDashboard, IconChar.ChartBar, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Admin, "FrmDashboard")))
            BindDemoButton(btnDemoProduk, IconChar.Box, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Admin, "FrmProduk")))
            BindDemoButton(btnDemoVoucher, IconChar.TicketAlt, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Admin, "FrmVoucher")))
            BindDemoButton(btnDemoLaporan, IconChar.Receipt, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Admin, "FrmLaporan")))
            BindDemoButton(btnDemoMember, IconChar.Users, Sub() JadwalkanAksi(Sub() BukaMdiSebagai(Peran.Admin, "FrmMember")))

            For Each flp In {flpCol1, flpCol2, flpCol3}
                AddHandler flp.SizeChanged, Sub(s, ev) SesuaikanLebarTombolKolom(DirectCast(s, FlowLayoutPanel))
                SesuaikanLebarTombolKolom(flp)
            Next

            AddHandler Shown, Sub()
                                  For Each flp In {flpCol1, flpCol2, flpCol3}
                                      SesuaikanLebarTombolKolom(flp)
                                  Next
                                  ModAnimasi.SlideUpFadeInModal(Me, 16, 220UL)
                              End Sub
        End Sub

        Private Shared Sub SesuaikanLebarTombolKolom(flp As FlowLayoutPanel)
            Dim targetW As Integer = Math.Max(180, flp.ClientSize.Width - 10)
            For Each c As Control In flp.Controls
                Dim btn = TryCast(c, Guna2Button)
                If btn IsNot Nothing AndAlso btn.Width <> targetW Then
                    btn.Width = targetW
                End If
            Next
        End Sub

        Private Sub JadwalkanAksi(aksi As Action)
            _pendingAction = aksi
            Close()
        End Sub

        Private Shared Sub TampilkanDialog(owner As Form, dialog As Form)
            If owner IsNot Nothing AndAlso Not owner.IsDisposed AndAlso owner.Visible Then
                dialog.ShowDialog(owner)
            Else
                dialog.ShowDialog()
            End If
        End Sub

        Private Shared Sub BindDemoButton(b As Guna2Button, icChar As IconChar, aksi As Action)
            ModTema.GayaGunaButtonSekunder(b, 10)
            b.Font = ModTema.FontKecil
            b.TextAlign = HorizontalAlignment.Left
            b.Image = BistroIcons.GetIcon(icChar, ModTema.WarnaUtama, 15)
            b.ImageAlign = HorizontalAlignment.Left
            b.ImageOffset = New Point(8, 0)
            AddHandler b.Click, Sub() aksi()
        End Sub

        Private Function CariWelcome() As FrmWelcome
            If _welcomeForm IsNot Nothing AndAlso Not _welcomeForm.IsDisposed Then Return _welcomeForm
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmWelcome Then Return DirectCast(f, FrmWelcome)
            Next
            Return Nothing
        End Function

        Private Function CariUtama() As FrmUtama
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmUtama Then Return DirectCast(f, FrmUtama)
            Next
            Return Nothing
        End Function

        Private Sub TutupKembaliJikaDiMdi()
            Dim mdi = CariUtama()
            If mdi IsNot Nothing AndAlso Not mdi.IsDisposed Then
                mdi.Close()
            End If
        End Sub

        Private Sub BukaWelcome()
            TutupKembaliJikaDiMdi()
            Dim w = CariWelcome()
            If w IsNot Nothing AndAlso Not w.IsDisposed Then
                For Each f In Application.OpenForms.Cast(Of Form)().ToList()
                    If TypeOf f Is FrmMenu Then
                        ModNavigasi.PindahHalaman(f, w)
                        Return
                    End If
                Next
                ModNavigasi.TerapkanModeJendela(w)
                w.Show()
                w.Activate()
            End If
        End Sub

        Private Sub BukaMenuDemo()
            TutupKembaliJikaDiMdi()
            Dim w = CariWelcome()
            If w IsNot Nothing AndAlso Not w.IsDisposed Then
                w.MulaiPesanan(TipeMakan.DineIn)
            End If
        End Sub

        Private Sub BukaLoginDemo()
            Dim w = CariWelcome()
            If w IsNot Nothing AndAlso Not w.IsDisposed AndAlso CariUtama() Is Nothing Then
                w.BukaLoginStaff()
            Else
                Using f As New FrmLogin()
                    TampilkanDialog(_ownerForm, f)
                End Using
            End If
        End Sub

        Private Sub BukaAntrianDemo()
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmAntrian Then
                    ModNavigasi.DaftarkanHalamanPenuh(f)
                    f.Show()
                    f.BringToFront()
                    f.Activate()
                    Return
                End If
            Next
            Dim ant As New FrmAntrian()
            ant.Show()
        End Sub

        Private Sub BukaMdiSebagai(peranTarget As String, namaForm As String)
            Dim user As Pengguna = Nothing
            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Dim dt = ModFunction.AmbilData(
                        "SELECT id_pengguna, username, nama, role, aktif FROM public.pengguna WHERE role = @r AND aktif = TRUE ORDER BY id_pengguna LIMIT 1",
                        New Dictionary(Of String, Object) From {{"r", peranTarget}})
                    If dt.Rows.Count > 0 Then
                        Dim r = dt.Rows(0)
                        user = New Pengguna With {
                            .IdPengguna = CInt(r("id_pengguna")),
                            .Username = CStr(r("username")),
                            .PasswordHash = "",
                            .Nama = CStr(r("nama")),
                            .Peran = CStr(r("role")),
                            .Aktif = CBool(r("aktif"))
                        }
                    End If
                Catch
                End Try
            End If
            If user Is Nothing Then
                ModDummyStore.PastikanInit()
                Dim d = ModDummyStore.PenggunaList.First(Function(u) u.Peran = peranTarget AndAlso u.Aktif)
                user = New Pengguna With {
                    .IdPengguna = d.IdPengguna,
                    .Username = d.Username,
                    .PasswordHash = "",
                    .Nama = d.Nama,
                    .Peran = d.Peran,
                    .Aktif = d.Aktif
                }
            End If
            ModSesi.Masuk(user)

            Dim mdi = CariUtama()
            If mdi IsNot Nothing AndAlso Not mdi.IsDisposed Then
                mdi.TerapkanHakAkses()
                mdi.BukaFormAnak(namaForm)
                mdi.Activate()
                Return
            End If

            Dim w = CariWelcome()
            If w IsNot Nothing AndAlso Not w.IsDisposed Then
                w.BukaModeStaffDenganForm(namaForm)
                Return
            End If

            Using mdiBaru As New FrmUtama()
                mdiBaru.FormAwal = namaForm
                mdiBaru.ShowDialog()
            End Using
        End Sub

    End Class
End Namespace
