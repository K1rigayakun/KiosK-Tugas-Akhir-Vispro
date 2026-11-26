Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Forms.Admin
Imports VisproPrakProjectAkhir.Forms.Kasir
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Umum

    ''' <summary>
    ''' Jendela induk MDI Mode Staff (Materi Wajib P12) dengan integrasi seluruh form A1-A5.
    ''' Tanpa WS_EX_COMPOSITED agar area MdiClient Win32 tidak berkedip hitam.
    ''' </summary>
    Public Class FrmUtama
        Private ReadOnly _tmrJam As New Timer()
        Private ReadOnly _navButtons As New List(Of Guna2Button)()
        Private _navExpanded As Boolean = True
        Private _formAktifName As String = ""
        Private _mdiClient As MdiClient

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property FormAwal As String = ""

        Public Sub New()
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModAnimasi.SiapkanTransisiMasuk(Me, 0)
            ModNavigasi.DaftarkanHalamanPenuh(Me)
            ApplyRuntimePolish()
            TerapkanHakAkses()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            ModTema.AktifkanDoubleBuffer(pnlSidebar)
            ModTema.AktifkanDoubleBuffer(flpNav)

            For Each ctrl As Control In Controls
                If TypeOf ctrl Is MdiClient Then
                    _mdiClient = DirectCast(ctrl, MdiClient)
                    _mdiClient.BackColor = ModTema.WarnaLatar
                    ModTema.AktifkanDoubleBuffer(_mdiClient)
                End If
            Next

            menuStrip.Renderer = New BistroMenuRenderer()
            menuStrip.Font = ModTema.FontBiasa

            AddHandler miKasir.Click, Sub() BukaFormAnak("FrmKasir")
            AddHandler miDapur.Click, Sub() BukaFormAnak("FrmDapur")
            AddHandler miAntrian.Click, Sub() BukaLayarAntrian()
            AddHandler miProduk.Click, Sub() BukaFormAnak("FrmProduk")
            AddHandler miVoucher.Click, Sub() BukaFormAnak("FrmVoucher")
            AddHandler miMember.Click, Sub() BukaFormAnak("FrmMember")
            AddHandler miDashboard.Click, Sub() BukaFormAnak("FrmDashboard")
            AddHandler miLaporan.Click, Sub() BukaFormAnak("FrmLaporan")
            AddHandler miPengguna.Click, Sub() BukaFormAnak("FrmPengguna")
            AddHandler miPengaturan.Click, Sub() BukaFormAnak("FrmPengaturan")
            AddHandler miLog.Click, Sub() BukaFormAnak("FrmLog")
            AddHandler miKembaliKiosk.Click, Sub() KembaliKeKiosk()
            AddHandler miKeluar.Click, Sub() Application.Exit()
            AddHandler miCascade.Click, Sub() LayoutMdi(MdiLayout.Cascade)
            AddHandler miTileH.Click, Sub() LayoutMdi(MdiLayout.TileHorizontal)
            AddHandler miTileV.Click, Sub() LayoutMdi(MdiLayout.TileVertical)
            AddHandler miFullscreen.Click, Sub() ModNavigasi.ToggleFullscreen(Me)
            AddHandler miTutupSemua.Click, Sub() TutupSemuaAnak()
            AddHandler ModNavigasi.ModeFullscreenBerubah, AddressOf OnModeFullscreenBerubah
            PerbaruiMenuFullscreen()

            btnToggleNav.Image = BistroIcons.GetIcon(IconChar.Bars, ModTema.WarnaUtama, 16)
            btnToggleNav.BorderRadius = 10
            pnlSidebar.FillColor = ModTema.WarnaCharcoal
            AddHandler btnToggleNav.Click, AddressOf ToggleSidebar

            ' Gunakan tombol sidebar yang sudah terpasang di Designer agar [Design] dan Runtime 1:1
            _navButtons.Clear()
            BindNavButton(btnNavDashboard, "Dashboard", "FrmDashboard", IconChar.ChartBar, Sub() BukaFormAnak("FrmDashboard"))
            BindNavButton(btnNavKasir, "Kasir", "FrmKasir", IconChar.MoneyBillWave, Sub() BukaFormAnak("FrmKasir"))
            BindNavButton(btnNavDapur, "Dapur (KDS)", "FrmDapur", IconChar.Fire, Sub() BukaFormAnak("FrmDapur"))
            BindNavButton(btnNavAntrian, "Layar Antrian", "FrmAntrian", IconChar.Desktop, Sub() BukaLayarAntrian())
            BindNavButton(btnNavProduk, "Produk / Stok", "FrmProduk", IconChar.Box, Sub() BukaFormAnak("FrmProduk"))
            BindNavButton(btnNavVoucher, "Voucher Promo", "FrmVoucher", IconChar.TicketAlt, Sub() BukaFormAnak("FrmVoucher"))
            BindNavButton(btnNavMember, "Member / Poin", "FrmMember", IconChar.Users, Sub() BukaFormAnak("FrmMember"))
            BindNavButton(btnNavLaporan, "Laporan / CSV", "FrmLaporan", IconChar.Receipt, Sub() BukaFormAnak("FrmLaporan"))
            BindNavButton(btnNavPengguna, "Pengguna", "FrmPengguna", IconChar.User, Sub() BukaFormAnak("FrmPengguna"))
            BindNavButton(btnNavPengaturan, "Pengaturan", "FrmPengaturan", IconChar.Cog, Sub() BukaFormAnak("FrmPengaturan"))
            BindNavButton(btnNavLog, "Log Aktivitas", "FrmLog", IconChar.History, Sub() BukaFormAnak("FrmLog"))

            btnKiosk.Image = BistroIcons.GetIcon(IconChar.Store, Color.White, 16)
            btnKiosk.FillColor = ModTema.WarnaUtama
            btnKiosk.ForeColor = Color.White
            btnKiosk.BorderRadius = 12
            btnKiosk.BorderThickness = 0
            btnKiosk.HoverState.FillColor = ModTema.WarnaUtamaHover
            AddHandler btnKiosk.Click, Sub() KembaliKeKiosk()

            statusStrip.BackColor = ModTema.WarnaLatar
            statusStrip.ForeColor = ModTema.WarnaTeks

            AddHandler lblDemoLink.Click, Sub() FrmDemoHub.ShowHub(Me)

            _tmrJam.Interval = 1000
            AddHandler _tmrJam.Tick, Sub() PerbaruiStatusBar()
            AddHandler Shown, AddressOf OnFormShown
            AddHandler FormClosing, AddressOf FrmUtama_FormClosing
        End Sub

        Private Sub OnModeFullscreenBerubah(aktif As Boolean)
            If IsDisposed Then Return
            If InvokeRequired Then
                BeginInvoke(New Action(Of Boolean)(AddressOf OnModeFullscreenBerubah), aktif)
                Return
            End If
            PerbaruiMenuFullscreen()
        End Sub

        Private Sub PerbaruiMenuFullscreen()
            miFullscreen.Checked = ModNavigasi.ModeFullscreen
            miFullscreen.Text = If(ModNavigasi.ModeFullscreen, "Keluar Layar Penuh (F11)", "Layar Penuh (F11)")
        End Sub

        Private Sub FrmUtama_FormClosing(sender As Object, e As FormClosingEventArgs)
            _tmrJam.Stop()
            RemoveHandler ModNavigasi.ModeFullscreenBerubah, AddressOf OnModeFullscreenBerubah
            If ModSesi.SudahLogin() Then
                ModSesi.Keluar()
            End If
        End Sub

        Private Sub BindNavButton(b As Guna2Button, teks As String, formName As String, ic As IconChar, onClick As Action)
            b.Text = "  " & teks
            b.Tag = New Tuple(Of String, String, IconChar)(formName, teks, ic)
            b.TextAlign = HorizontalAlignment.Left
            b.Image = BistroIcons.GetIcon(ic, ModTema.WarnaAksen, 16)
            b.ImageAlign = HorizontalAlignment.Left
            b.ImageOffset = New Point(10, 0)
            b.BorderRadius = 10
            b.BackColor = Color.Transparent
            b.UseTransparentBackground = True
            b.FillColor = Color.Transparent
            b.ForeColor = ModTema.WarnaSekunderLatar
            b.Font = ModTema.FontBiasa
            b.Cursor = Cursors.Hand
            b.Animated = True
            b.HoverState.FillColor = ModTema.WarnaCharcoalLembut
            AddHandler b.Click, Sub() onClick()
            _navButtons.Add(b)
        End Sub

        Private Sub ToggleSidebar(sender As Object, e As EventArgs)
            _navExpanded = Not _navExpanded
            Dim targetW As Integer = If(_navExpanded, 228, 66)

            If Not _navExpanded Then
                btnToggleNav.Text = ""
                btnKiosk.Text = ""
                flpNav.SuspendLayout()
                For Each b In _navButtons
                    b.Text = ""
                Next
                flpNav.ResumeLayout(False)
            End If

            Dim startW As Single = CSng(pnlSidebar.Width)
            ModAnimasi.AnimateFloat(pnlSidebar, pnlSidebar, startW, CSng(targetW), 230UL,
                Sub(v)
                    Dim curW As Integer = CInt(Math.Round(v))
                    pnlSidebar.Width = curW
                    btnToggleNav.Width = Math.Max(46, curW - 20)
                    Dim btnW As Integer = Math.Max(44, curW - 24)
                    flpNav.SuspendLayout()
                    For Each b In _navButtons
                        b.Width = btnW
                    Next
                    flpNav.ResumeLayout(False)
                End Sub,
                Sub()
                    pnlSidebar.Width = targetW
                    btnToggleNav.Width = targetW - 20
                    btnToggleNav.Text = If(_navExpanded, "  Menu Operasional", "")
                    btnKiosk.Text = If(_navExpanded, "  Kembali ke Kiosk", "")
                    PerbaruiHighlightSidebar(True)
                End Sub,
                easing:=AddressOf WinFormAnimation.AnimationFunctions.QuinticEaseOut)
        End Sub

        Private Sub PerbaruiHighlightSidebar(Optional updateWidths As Boolean = True)
            flpNav.SuspendLayout()
            For Each b In _navButtons
                Dim info = DirectCast(b.Tag, Tuple(Of String, String, IconChar))
                Dim aktif As Boolean = (info.Item1 = _formAktifName)
                If updateWidths Then
                    b.Width = If(_navExpanded, 204, 46)
                    b.Text = If(_navExpanded, "  " & info.Item2, "")
                End If
                b.FillColor = If(aktif, ModTema.WarnaUtama, Color.Transparent)
                b.ForeColor = If(aktif, Color.White, ModTema.WarnaSekunderLatar)
                b.Image = BistroIcons.GetIcon(info.Item3, If(aktif, Color.White, ModTema.WarnaAksen), 16)
            Next
            flpNav.ResumeLayout(False)
        End Sub

        Private Sub PerbaruiStatusBar()
            lblUser.Text = $"Staff: {ModSesi.NamaPengguna} ({ModSesi.Peran})"
            If ModDatabase.DatabaseTerhubung(False) Then
                lblKoneksi.Text = "Database: Terhubung (Supabase)"
                lblKoneksi.ForeColor = ModTema.WarnaSukses
            Else
                lblKoneksi.Text = "Database: Mode Visual Dummy"
                lblKoneksi.ForeColor = ModTema.WarnaTeksRedup
            End If
            Dim menipis As Integer = ModLaporan.JumlahStokMenipis()
            lblStokAlert.Text = If(menipis > 0, $"Perhatian: {menipis} menu stok menipis", "Stok Aman")
            lblStokAlert.ForeColor = If(menipis > 0, ModTema.WarnaBahaya, ModTema.WarnaSukses)
            lblJam.Text = DateTime.Now.ToString("dd MMM yyyy  HH:mm:ss")
        End Sub

        Public Sub TerapkanHakAkses()
            For Each topItem As ToolStripItem In menuStrip.Items
                Dim mi = TryCast(topItem, ToolStripMenuItem)
                If mi Is Nothing Then Continue For
                For Each subItem As ToolStripItem In mi.DropDownItems
                    Dim tagForm As String = TryCast(subItem.Tag, String)
                    If Not String.IsNullOrEmpty(tagForm) Then
                        subItem.Visible = ModSesi.BolehAkses(tagForm)
                    End If
                Next
            Next

            For Each b In _navButtons
                Dim info = DirectCast(b.Tag, Tuple(Of String, String, IconChar))
                b.Visible = ModSesi.BolehAkses(info.Item1)
            Next
            PerbaruiStatusBar()
        End Sub

        Private Sub OnFormShown(sender As Object, e As EventArgs)
            ModAnimasi.FadeInForm(Me, 210UL)
            _tmrJam.Start()
            PerbaruiStatusBar()
            Dim awal As String = FormAwal
            If Not String.IsNullOrWhiteSpace(awal) AndAlso ModSesi.BolehAkses(awal) Then
                BukaFormAnak(awal)
            ElseIf ModSesi.Peran = Peran.Admin Then
                BukaFormAnak("FrmDashboard")
            Else
                BukaFormAnak("FrmKasir")
            End If
        End Sub

        Public Sub BukaFormAnak(namaForm As String)
            If Not ModSesi.BolehAkses(namaForm) Then
                MessageBox.Show("Akun Anda tidak memiliki izin untuk membuka menu ini.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ModWindowsApi.SuspendDrawing(_mdiClient)
            Try
                For Each child As Form In MdiChildren
                    If String.Equals(child.GetType().Name, namaForm, StringComparison.OrdinalIgnoreCase) Then
                        child.WindowState = FormWindowState.Maximized
                        child.Activate()
                        SegarkanChild(child)
                        _formAktifName = namaForm
                        PerbaruiHighlightSidebar()
                        Return
                    End If
                Next

                Dim frmBaru As Form = BuatInstanceForm(namaForm)
                If frmBaru Is Nothing Then Return
                frmBaru.MdiParent = Me
                If _mdiClient IsNot Nothing Then
                    frmBaru.Bounds = New Rectangle(Point.Empty, _mdiClient.ClientSize)
                End If
                frmBaru.WindowState = FormWindowState.Maximized
                frmBaru.Show()
                _formAktifName = namaForm
                PerbaruiHighlightSidebar()
            Finally
                ModWindowsApi.ResumeDrawing(_mdiClient)
            End Try
        End Sub

        Private Shared Sub SegarkanChild(child As Form)
            If TypeOf child Is FrmDashboard Then
                DirectCast(child, FrmDashboard).MuatDashboard(False)
            ElseIf TypeOf child Is FrmKasir Then
                DirectCast(child, FrmKasir).SegarkanData()
            ElseIf TypeOf child Is FrmDapur Then
                DirectCast(child, FrmDapur).SegarkanData()
            ElseIf TypeOf child Is FrmProduk Then
                DirectCast(child, FrmProduk).SegarkanData()
            ElseIf TypeOf child Is FrmVoucher Then
                DirectCast(child, FrmVoucher).SegarkanData()
            ElseIf TypeOf child Is FrmMember Then
                DirectCast(child, FrmMember).SegarkanData()
            ElseIf TypeOf child Is FrmLaporan Then
                DirectCast(child, FrmLaporan).MuatLaporan()
            ElseIf TypeOf child Is FrmPengguna Then
                DirectCast(child, FrmPengguna).SegarkanData()
            ElseIf TypeOf child Is FrmLog Then
                DirectCast(child, FrmLog).SegarkanData()
            End If
        End Sub

        Private Shared Function BuatInstanceForm(namaForm As String) As Form
            Select Case namaForm
                Case "FrmDashboard" : Return New FrmDashboard()
                Case "FrmKasir" : Return New FrmKasir()
                Case "FrmDapur" : Return New FrmDapur()
                Case "FrmProduk" : Return New FrmProduk()
                Case "FrmVoucher" : Return New FrmVoucher()
                Case "FrmMember" : Return New FrmMember()
                Case "FrmLaporan" : Return New FrmLaporan()
                Case "FrmPengguna" : Return New FrmPengguna()
                Case "FrmPengaturan" : Return New FrmPengaturan()
                Case "FrmLog" : Return New FrmLog()
                Case Else : Return Nothing
            End Select
        End Function

        Public Sub BukaLayarAntrian()
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

        Private Sub TutupSemuaAnak()
            For Each child As Form In MdiChildren.ToArray()
                child.Close()
            Next
            _formAktifName = ""
            PerbaruiHighlightSidebar()
        End Sub

        Private Sub KembaliKeKiosk()
            TutupSemuaAnak()
            ModLog.Catat(KodeAksi.Logout, $"Staff {ModSesi.NamaPengguna} kembali ke Kiosk")
            ModSesi.Keluar()
            Close()
        End Sub

    End Class
End Namespace
