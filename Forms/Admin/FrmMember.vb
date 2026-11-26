Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Admin

    Public Class FrmMember
        Private ReadOnly _bsMember As New BindingSource()
        Private _selectedMemberId As Integer = 0

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
            ModTema.GayaGunaCard(cardEd, 14)

            pnlRight.AutoScroll = True
            cardEd.Dock = DockStyle.Top
            cardEd.Height = 525

            txtCari.IconLeft = BistroIcons.GetIcon(IconChar.MagnifyingGlass, ModTema.WarnaTeksRedup, 14)
            ModTema.GayaGunaTextBox(txtCari, "Cari nama atau no. HP member...")
            AddHandler txtCari.TextChanged, Sub()
                                                Dim kw = txtCari.Text.Trim().Replace("'", "''")
                                                _bsMember.Filter = If(String.IsNullOrEmpty(kw), "", $"nama LIKE '%{kw}%' OR no_hp LIKE '%{kw}%'")
                                            End Sub

            ModTema.GayaDataGridView(dgvMember)
            AddHandler dgvMember.SelectionChanged, AddressOf OnSelectionChanged

            ModTema.GayaGunaTextBox(txtNoHp)
            AddHandler txtNoHp.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            ModTema.GayaGunaTextBox(txtNama)
            ModTema.GayaGunaTextBox(txtPoin)

            ModTema.GayaGunaButtonSekunder(btnTambah, 10)
            AddHandler btnTambah.Click, Sub()
                                            _selectedMemberId = 0
                                            txtNoHp.Text = "" : txtNama.Text = "" : txtPoin.Text = "0"
                                            errMember.Clear()
                                            txtNoHp.Focus()
                                        End Sub

            ModTema.GayaGunaButtonUtama(btnSimpan, 10)
            AddHandler btnSimpan.Click, AddressOf OnSimpanClick

            ModTema.GayaGunaTextBox(txtDeltaPoin, "Masukkan saldo poin baru...")
            AddHandler txtDeltaPoin.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            ModTema.GayaGunaTextBox(txtAlasanPoin, "Contoh: Kompensasi promo...")
            ModTema.GayaGunaButtonDark(btnAturPoin, 10)
            AddHandler btnAturPoin.Click, AddressOf OnAturPoinClick
        End Sub

        Public Sub SegarkanData()
            MuatData()
        End Sub

        Private Sub MuatData()
            _bsMember.DataSource = ModMember.AmbilSemua()
            dgvMember.DataSource = _bsMember
        End Sub

        Private Sub OnSelectionChanged(sender As Object, e As EventArgs)
            If dgvMember.CurrentRow Is Nothing Then Return
            Dim drv = TryCast(dgvMember.CurrentRow.DataBoundItem, DataRowView)
            If drv Is Nothing Then Return
            _selectedMemberId = CInt(drv("id_member"))
            txtNoHp.Text = CStr(drv("no_hp"))
            txtNama.Text = CStr(drv("nama"))
            txtPoin.Text = CInt(drv("poin")).ToString()
            errMember.Clear()
        End Sub

        Private Sub OnSimpanClick(sender As Object, e As EventArgs)
            Dim hp = txtNoHp.Text.Trim()
            If hp.Length < 10 OrElse hp.Length > 15 Then
                errMember.SetError(txtNoHp, "No. HP harus 10-15 digit angka.") : Return
            End If
            If Not ModValidasi.WajibIsi(txtNama, errMember, "Nama member wajib diisi.") Then Return
            errMember.Clear()

            Try
                If _selectedMemberId = 0 Then
                    If ModMember.Cari(hp) IsNot Nothing Then
                        errMember.SetError(txtNoHp, "No. HP sudah terdaftar.") : Return
                    End If
                    ModMember.Daftar(hp, txtNama.Text.Trim())
                Else
                    ModMember.Ubah(_selectedMemberId, hp, txtNama.Text.Trim())
                End If
                MuatData()
                MessageBox.Show("Data member disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub OnAturPoinClick(sender As Object, e As EventArgs)
            If _selectedMemberId = 0 Then Return
            Dim poinBaru As Decimal = 0D
            If Not ModValidasi.BacaAngka(txtDeltaPoin, errMember, poinBaru) OrElse poinBaru < 0D Then Return
            If Not ModValidasi.WajibIsi(txtAlasanPoin, errMember, "Alasan wajib diisi.") Then Return

            Try
                If ModMember.AturSaldoPoin(_selectedMemberId, CInt(poinBaru), txtAlasanPoin.Text.Trim()) Then
                    txtDeltaPoin.Text = ""
                    txtAlasanPoin.Text = ""
                    MuatData()
                    MessageBox.Show("Saldo poin member berhasil diperbarui.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace
