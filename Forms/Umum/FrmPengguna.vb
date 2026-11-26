Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Umum

    Public Class FrmPengguna
        Private ReadOnly _bsPengguna As New BindingSource()
        Private _selectedId As Integer = 0

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
            ApplyRuntimePolish()
            MuatData()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            ModTema.GayaGunaCard(cardGrid, 14)
            ModTema.GayaGunaCard(cardForm, 14)
            pnlRight.AutoScroll = True
            cardForm.Dock = DockStyle.Top
            cardForm.Height = 520

            txtCari.IconLeft = BistroIcons.GetIcon(IconChar.MagnifyingGlass, ModTema.WarnaTeksRedup, 15)
            ModTema.GayaGunaTextBox(txtCari, "Cari username atau nama...")
            AddHandler txtCari.TextChanged, Sub() TerapkanFilter()

            ModTema.GayaDataGridView(dgvPengguna)
            AddHandler dgvPengguna.SelectionChanged, AddressOf OnSelectionChanged

            ModTema.GayaGunaTextBox(txtUsername)
            ModTema.GayaGunaTextBox(txtNama)
            ModTema.GayaGunaTextBox(txtPassword)
            ModTema.GayaGunaComboBox(cboPeran)
            cboPeran.Items.Clear()
            cboPeran.Items.AddRange({Peran.Admin, Peran.Kasir})
            cboPeran.SelectedIndex = 1

            ModTema.GayaGunaButtonSekunder(btnTambah, 10)
            AddHandler btnTambah.Click, Sub() ResetForm()
            ModTema.GayaGunaButtonUtama(btnSimpan, 10)
            AddHandler btnSimpan.Click, AddressOf OnSimpanClick
            ModTema.GayaGunaButtonDark(btnResetPassword, 10)
            AddHandler btnResetPassword.Click, AddressOf OnResetPassClick
            ModTema.GayaGunaButtonBahaya(btnNonaktifkan, 10)
            AddHandler btnNonaktifkan.Click, AddressOf OnNonaktifkanClick
        End Sub

        Public Sub SegarkanData()
            MuatData()
        End Sub

        Private Sub MuatData()
            If ModDatabase.DatabaseTerhubung() Then
                Try
                    Dim sql As String = "SELECT id_pengguna, username, nama, role, aktif FROM pengguna ORDER BY id_pengguna"
                    Dim dtDb = ModFunction.AmbilData(sql)
                    _bsPengguna.DataSource = dtDb
                    dgvPengguna.DataSource = _bsPengguna
                    TerapkanFilter()
                    Return
                Catch
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim dt As New DataTable()
            dt.Columns.Add("id_pengguna", GetType(Integer))
            dt.Columns.Add("username", GetType(String))
            dt.Columns.Add("nama", GetType(String))
            dt.Columns.Add("role", GetType(String))
            dt.Columns.Add("aktif", GetType(Boolean))

            For Each u In ModDummyStore.PenggunaList.OrderBy(Function(x) x.IdPengguna)
                dt.Rows.Add(u.IdPengguna, u.Username, u.Nama, u.Peran, u.Aktif)
            Next
            _bsPengguna.DataSource = dt
            dgvPengguna.DataSource = _bsPengguna
            TerapkanFilter()
        End Sub

        Private Sub TerapkanFilter()
            Dim kw As String = txtCari.Text.Trim().Replace("'", "''")
            _bsPengguna.Filter = If(String.IsNullOrEmpty(kw), "", $"username LIKE '%{kw}%' OR nama LIKE '%{kw}%'")
        End Sub

        Private Sub OnSelectionChanged(sender As Object, e As EventArgs)
            If dgvPengguna.CurrentRow Is Nothing Then Return
            Dim drv = TryCast(dgvPengguna.CurrentRow.DataBoundItem, DataRowView)
            If drv Is Nothing Then Return
            _selectedId = CInt(drv("id_pengguna"))
            txtUsername.Text = CStr(drv("username"))
            txtNama.Text = CStr(drv("nama"))
            cboPeran.SelectedItem = CStr(drv("role"))
            chkAktif.Checked = CBool(drv("aktif"))
            txtPassword.Text = ""
            errPengguna.Clear()
        End Sub

        Private Sub ResetForm()
            _selectedId = 0
            txtUsername.Text = ""
            txtNama.Text = ""
            txtPassword.Text = ""
            cboPeran.SelectedItem = Peran.Kasir
            chkAktif.Checked = True
            errPengguna.Clear()
            txtUsername.Focus()
        End Sub

        Private Function UsernameSudahAda(uname As String, idSaatIni As Integer) As Boolean
            If ModDatabase.DatabaseTerhubung() Then
                Dim prm As New Dictionary(Of String, Object) From {{"username", uname}, {"id", idSaatIni}}
                Dim sql As String = "SELECT COUNT(*) FROM pengguna WHERE username = @username AND id_pengguna <> @id"
                Dim res = ModFunction.EksekusiScalar(sql, prm)
                If res IsNot Nothing AndAlso Not Convert.IsDBNull(res) Then
                    Return Convert.ToInt32(res) > 0
                End If
                Return False
            End If
            Return ModDummyStore.PenggunaList.Any(Function(u) u.IdPengguna <> idSaatIni AndAlso String.Equals(u.Username, uname, StringComparison.OrdinalIgnoreCase))
        End Function

        Private Sub OnSimpanClick(sender As Object, e As EventArgs)
            Dim okU = ModValidasi.WajibIsi(txtUsername, errPengguna, "Username wajib diisi.")
            Dim okN = ModValidasi.WajibIsi(txtNama, errPengguna, "Nama lengkap wajib diisi.")
            If Not (okU AndAlso okN) Then Return

            Dim uname = txtUsername.Text.Trim()
            Dim nama = txtNama.Text.Trim()
            Dim peranBaru = CStr(cboPeran.SelectedItem)

            If UsernameSudahAda(uname, _selectedId) Then
                errPengguna.SetError(txtUsername, "Username sudah digunakan.")
                Return
            End If

            If _selectedId = 0 AndAlso txtPassword.Text.Length < 6 Then
                errPengguna.SetError(txtPassword, "Password minimal 6 karakter.")
                Return
            End If

            If _selectedId > 0 AndAlso _selectedId = ModSesi.IdPengguna AndAlso (Not chkAktif.Checked OrElse peranBaru <> ModSesi.Peran) Then
                MessageBox.Show("Tidak boleh menonaktifkan atau menurunkan peran akun yang sedang login.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If ModDatabase.DatabaseTerhubung() Then
                Try
                    Dim prm As New Dictionary(Of String, Object) From {
                        {"username", uname},
                        {"nama", nama},
                        {"role", peranBaru},
                        {"aktif", chkAktif.Checked}
                    }
                    If _selectedId = 0 Then
                        prm("password_hash") = BuatPassword.BuatHash(txtPassword.Text)
                        ModFunction.EksekusiData("INSERT INTO pengguna (username, password_hash, nama, role, aktif) VALUES (@username, @password_hash, @nama, @role, @aktif)", prm)
                        ModLog.Catat(KodeAksi.PenggunaUbah, $"Tambah pengguna {uname} ({peranBaru})")
                    Else
                        prm("id") = _selectedId
                        ModFunction.EksekusiData("UPDATE pengguna SET username = @username, nama = @nama, role = @role, aktif = @aktif WHERE id_pengguna = @id", prm)
                        ModLog.Catat(KodeAksi.PenggunaUbah, $"Ubah pengguna {uname}")
                    End If
                    errPengguna.Clear()
                    MuatData()
                    ResetForm()
                    MessageBox.Show("Data pengguna berhasil disimpan ke Supabase.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                Catch ex As Exception
                    MessageBox.Show("Gagal menyimpan data pengguna: " & ex.Message, "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            If _selectedId = 0 Then
                Dim pBaru As New Pengguna With {
                    .IdPengguna = ModDummyStore.NextPenggunaId,
                    .Username = uname,
                    .Nama = nama,
                    .PasswordHash = BuatPassword.BuatHash(txtPassword.Text),
                    .Peran = peranBaru,
                    .Aktif = chkAktif.Checked
                }
                ModDummyStore.NextPenggunaId += 1
                ModDummyStore.PenggunaList.Add(pBaru)
                ModLog.Catat(KodeAksi.PenggunaUbah, $"Tambah pengguna {uname} ({peranBaru})")
            Else
                Dim existing = ModDummyStore.PenggunaList.FirstOrDefault(Function(u) u.IdPengguna = _selectedId)
                If existing Is Nothing Then Return
                existing.Username = uname
                existing.Nama = nama
                existing.Peran = peranBaru
                existing.Aktif = chkAktif.Checked
                ModLog.Catat(KodeAksi.PenggunaUbah, $"Ubah pengguna {uname}")
            End If

            errPengguna.Clear()
            MuatData()
            MessageBox.Show("Data pengguna berhasil disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OnResetPassClick(sender As Object, e As EventArgs)
            If _selectedId = 0 Then Return
            If txtPassword.Text.Length < 6 Then
                errPengguna.SetError(txtPassword, "Masukkan password baru minimal 6 karakter.")
                Return
            End If

            Dim hashBaru As String = BuatPassword.BuatHash(txtPassword.Text)
            If ModDatabase.DatabaseTerhubung() Then
                Try
                    Dim prm As New Dictionary(Of String, Object) From {{"password_hash", hashBaru}, {"id", _selectedId}}
                    ModFunction.EksekusiData("UPDATE pengguna SET password_hash = @password_hash WHERE id_pengguna = @id", prm)
                    ModLog.Catat(KodeAksi.PenggunaUbah, $"Reset password pengguna ID {_selectedId}")
                    txtPassword.Text = ""
                    errPengguna.Clear()
                    MessageBox.Show("Password berhasil direset dengan PBKDF2.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                Catch ex As Exception
                    MessageBox.Show("Gagal mereset password: " & ex.Message, "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            Dim existing = ModDummyStore.PenggunaList.FirstOrDefault(Function(u) u.IdPengguna = _selectedId)
            If existing Is Nothing Then Return
            existing.PasswordHash = hashBaru
            ModLog.Catat(KodeAksi.PenggunaUbah, $"Reset password untuk {existing.Username}")
            txtPassword.Text = ""
            errPengguna.Clear()
            MessageBox.Show("Password berhasil direset dengan PBKDF2.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OnNonaktifkanClick(sender As Object, e As EventArgs)
            If _selectedId = 0 Then Return
            If _selectedId = ModSesi.IdPengguna Then
                MessageBox.Show("Tidak boleh menonaktifkan akun yang sedang login.", "Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If MessageBox.Show("Yakin ingin menonaktifkan pengguna ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

            If ModDatabase.DatabaseTerhubung() Then
                Try
                    Dim prm As New Dictionary(Of String, Object) From {{"id", _selectedId}}
                    ModFunction.EksekusiData("UPDATE pengguna SET aktif = FALSE WHERE id_pengguna = @id", prm)
                    ModLog.Catat(KodeAksi.PenggunaUbah, $"Nonaktifkan pengguna ID {_selectedId}")
                    MuatData()
                    Return
                Catch ex As Exception
                    MessageBox.Show("Gagal menonaktifkan pengguna: " & ex.Message, "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            Dim existing = ModDummyStore.PenggunaList.FirstOrDefault(Function(u) u.IdPengguna = _selectedId)
            If existing Is Nothing Then Return
            existing.Aktif = False
            ModLog.Catat(KodeAksi.PenggunaUbah, $"Nonaktifkan akun {existing.Username}")
            MuatData()
        End Sub

    End Class
End Namespace
