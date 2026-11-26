Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Umum

    Public Class FrmLogin
        Private ReadOnly _tmrKunci As New Timer()
        Private _gagalBerturut As Integer = 0
        Private _sisaKunciDetik As Integer = 0
        Private _sedangLogin As Boolean = False

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not DesignMode Then cp.ExStyle = cp.ExStyle Or &H2000000
                Return cp
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModAnimasi.SiapkanTransisiMasuk(Me, 16)
            ApplyRuntimePolish()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            ModTema.GayaGunaCard(rootCard, 14)
            pnlKiri.BackColor = Color.Transparent
            pnlKiri.UseTransparentBackground = True
            pnlKiri.FillColor = ModTema.WarnaCharcoal
            pnlKiri.BorderRadius = 12
            pnlKiri.CustomizableEdges.TopRight = False
            pnlKiri.CustomizableEdges.BottomRight = False
            picLogo.Image = ModProduk.AmbilLogoBistro()

            Dim dbAktif As Boolean = ModDatabase.DatabaseTerhubung()
            If dbAktif Then
                lblDbStatus.Text = "Database: Supabase Terhubung"
                lblDbStatus.ForeColor = ModTema.WarnaSukses
            Else
                lblDbStatus.Text = "Database: Mode Visual Dummy"
                lblDbStatus.ForeColor = ModTema.WarnaAksen
            End If

            ModTema.GayaGunaTextBox(txtUsername, "Masukkan username...")
            txtUsername.IconLeft = BistroIcons.GetIcon(IconChar.User, ModTema.WarnaTeksRedup, 16)

            ModTema.GayaGunaTextBox(txtPassword, "Masukkan password...")
            txtPassword.IconLeft = BistroIcons.GetIcon(IconChar.Lock, ModTema.WarnaTeksRedup, 16)
            AddHandler chkLihatPass.CheckedChanged, Sub()
                                                        txtPassword.PasswordChar = If(chkLihatPass.Checked, ControlChars.NullChar, "*"c)
                                                    End Sub

            ModTema.GayaGunaButtonSekunder(btnDemoAdmin, 8)
            btnDemoAdmin.Font = ModTema.FontKecil
            AddHandler btnDemoAdmin.Click, Sub()
                                               txtUsername.Text = "admin"
                                               txtPassword.Text = "admin123"
                                               errLogin.Clear()
                                           End Sub

            ModTema.GayaGunaButtonSekunder(btnDemoKasir, 8)
            btnDemoKasir.Font = ModTema.FontKecil
            AddHandler btnDemoKasir.Click, Sub()
                                               txtUsername.Text = "kasir1"
                                               txtPassword.Text = "kasir123"
                                               errLogin.Clear()
                                           End Sub

            ModTema.GayaGunaButtonSekunder(btnBatal, 10)
            AddHandler btnBatal.Click, Sub()
                                           DialogResult = DialogResult.Cancel
                                           Close()
                                       End Sub

            btnMasuk.Image = BistroIcons.GetIcon(IconChar.RightFromBracket, Color.White, 16)
            btnMasuk.ImageOffset = New Point(-6, 0)
            ModTema.GayaGunaButtonUtama(btnMasuk, 10)
            AddHandler btnMasuk.Click, AddressOf OnMasukClick
            AddHandler Shown, Sub() ModAnimasi.SlideUpFadeInModal(Me, 20, 230UL)

            AddHandler txtPassword.KeyDown, Sub(s, ev)
                                                If ev.KeyCode = Keys.Enter Then
                                                    ev.SuppressKeyPress = True
                                                    OnMasukClick(s, EventArgs.Empty)
                                                End If
                                            End Sub

            _tmrKunci.Interval = 1000
            AddHandler _tmrKunci.Tick, Sub()
                                           _sisaKunciDetik -= 1
                                           If _sisaKunciDetik <= 0 Then
                                               _tmrKunci.Stop()
                                               btnMasuk.Enabled = True
                                               lblPesan.Text = ""
                                               _gagalBerturut = 0
                                           Else
                                               lblPesan.Text = $"Terlalu banyak percobaan gagal. Coba lagi dalam {_sisaKunciDetik} detik."
                                           End If
                                       End Sub
            AddHandler FormClosing, Sub() _tmrKunci.Stop()
        End Sub

        Private Sub OnMasukClick(sender As Object, e As EventArgs)
            If _sedangLogin OrElse _sisaKunciDetik > 0 Then Return

            Dim okUser = ModValidasi.WajibIsi(txtUsername, errLogin, "Username wajib diisi.")
            Dim okPass = ModValidasi.WajibIsi(txtPassword, errLogin, "Password wajib diisi.")
            If Not (okUser AndAlso okPass) Then Return

            _sedangLogin = True
            btnMasuk.Enabled = False
            Try
                Dim uname As String = txtUsername.Text.Trim()
                Dim pass As String = txtPassword.Text
                Dim user As Pengguna = Nothing

                If ModDatabase.DatabaseTerhubung() Then
                    user = CariPenggunaSupabase(uname, pass)
                Else
                    user = CariPenggunaDummy(uname, pass)
                End If

                If user Is Nothing Then
                    TanganiGagalLogin(uname)
                    Return
                End If

                If Not user.Aktif Then
                    lblPesan.Text = "Akun pengguna tidak aktif."
                    Return
                End If

                _gagalBerturut = 0
                user.PasswordHash = ""
                ModSesi.Masuk(user)
                ModLog.Catat(KodeAksi.Login, $"Login sebagai {user.Peran}")
                DialogResult = DialogResult.OK
                Close()
            Catch ex As Exception
                lblPesan.Text = "Gagal memverifikasi akun: " & ModDatabase.PesanKesalahanAman(ex)
            Finally
                _sedangLogin = False
                If _sisaKunciDetik <= 0 Then btnMasuk.Enabled = True
            End Try
        End Sub

        Private Function CariPenggunaSupabase(uname As String, pass As String) As Pengguna
            Dim prm As New Dictionary(Of String, Object) From {{"username", uname}}
            Dim sql As String = "SELECT id_pengguna, username, password_hash, nama, role, aktif, terkunci, sisa_detik FROM public.fn_ambil_kredensial_login(@username)"
            Dim dt As DataTable = ModFunction.AmbilData(sql, prm)
            If dt.Rows.Count = 0 Then
                CatatGagalSupabase(uname)
                Return Nothing
            End If

            Dim row As DataRow = dt.Rows(0)
            Dim terkunci As Boolean = Not IsDBNull(row("terkunci")) AndAlso CBool(row("terkunci"))
            If terkunci Then
                Dim sisa As Integer = If(IsDBNull(row("sisa_detik")), 300, Math.Max(1, CInt(row("sisa_detik"))))
                _sisaKunciDetik = sisa
                btnMasuk.Enabled = False
                _tmrKunci.Start()
                lblPesan.Text = $"Akun terkunci sementara. Coba lagi dalam {sisa} detik."
                ModAnimasi.ShakeControl(txtPassword)
                Return Nothing
            End If

            If IsDBNull(row("id_pengguna")) Then
                CatatGagalSupabase(uname)
                Return Nothing
            End If

            Dim passwordHash As String = Convert.ToString(row("password_hash")).Trim()
            If Not BuatPassword.VerifikasiHash(pass, passwordHash) Then
                CatatGagalSupabase(uname)
                Return Nothing
            End If

            Try
                ModFunction.EksekusiData("SELECT public.fn_reset_login(@username)", prm)
            Catch
            End Try

            Return New Pengguna With {
                .IdPengguna = Convert.ToInt32(row("id_pengguna")),
                .Username = Convert.ToString(row("username")),
                .PasswordHash = "",
                .Nama = Convert.ToString(row("nama")),
                .Peran = Convert.ToString(row("role")),
                .Aktif = Convert.ToBoolean(row("aktif"))
            }
        End Function

        Private Sub CatatGagalSupabase(uname As String)
            Try
                ModFunction.EksekusiData("SELECT public.fn_catat_login_gagal(@username)", New Dictionary(Of String, Object) From {{"username", uname}})
            Catch
            End Try
        End Sub

        Private Function CariPenggunaDummy(uname As String, pass As String) As Pengguna
            ModDummyStore.PastikanInit()
            Dim candidate = ModDummyStore.PenggunaList.FirstOrDefault(Function(u) String.Equals(u.Username, uname, StringComparison.OrdinalIgnoreCase))
            If candidate Is Nothing Then Return Nothing
            If Not BuatPassword.VerifikasiHash(pass, candidate.PasswordHash) Then Return Nothing
            Return New Pengguna With {
                .IdPengguna = candidate.IdPengguna,
                .Username = candidate.Username,
                .PasswordHash = "",
                .Nama = candidate.Nama,
                .Peran = candidate.Peran,
                .Aktif = candidate.Aktif
            }
        End Function

        Private Sub TanganiGagalLogin(uname As String)
            If _sisaKunciDetik > 0 Then Return
            _gagalBerturut += 1
            ModLog.Catat(KodeAksi.LoginGagal, $"Login gagal untuk username '{uname}'")
            ModAnimasi.ShakeControl(txtPassword)
            If _gagalBerturut >= 5 Then
                _sisaKunciDetik = 30
                btnMasuk.Enabled = False
                _tmrKunci.Start()
                lblPesan.Text = "Terlalu banyak percobaan gagal. Tombol dikunci 30 detik."
            Else
                lblPesan.Text = $"Username atau password salah ({_gagalBerturut}/5)."
            End If
        End Sub

    End Class
End Namespace
