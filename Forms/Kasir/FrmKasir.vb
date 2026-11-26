Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Forms.Checkout
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kasir

    Public Class FrmKasir
        Private ReadOnly _errKasir As New ErrorProvider()
        Private ReadOnly _bsPesanan As New BindingSource()
        Private ReadOnly _tmrRefresh As New Timer()

        Private _selectedPesananId As Integer = 0
        Private _selectedTotal As Decimal = 0D
        Private _selectedStatus As String = ""
        Private _selectedMetode As String = ""

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
            _errKasir.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ApplyRuntimePolish()
            MuatPesanan()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar

            ModTema.GayaGunaComboBox(cboStatus)
            cboStatus.Items.AddRange({"Semua", StatusPesanan.MenungguPembayaran, StatusPesanan.Diproses, StatusPesanan.Siap, StatusPesanan.Selesai, StatusPesanan.Dibatalkan})
            cboStatus.SelectedItem = StatusPesanan.MenungguPembayaran
            AddHandler cboStatus.SelectedIndexChanged, Sub() TerapkanFilter()

            txtCariAntrian.IconLeft = BistroIcons.GetIcon(IconChar.MagnifyingGlass, ModTema.WarnaTeksRedup, 15)
            ModTema.GayaGunaTextBox(txtCariAntrian, "Cari no. antrian (contoh: 7)...")
            AddHandler txtCariAntrian.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            AddHandler txtCariAntrian.TextChanged, Sub() TerapkanFilter()

            btnRefresh.Image = BistroIcons.GetIcon(IconChar.ArrowsRotate, ModTema.WarnaTeks, 15)
            btnRefresh.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSekunder(btnRefresh, 10)
            AddHandler btnRefresh.Click, Sub() MuatPesanan()

            ModTema.GayaGunaCard(cardGrid, 14)
            cardGrid.ShadowDecoration.Enabled = False
            cardGrid.UseTransparentBackground = True
            ModTema.GayaGunaCard(cardDetail, 14)
            cardDetail.ShadowDecoration.Enabled = False
            cardDetail.UseTransparentBackground = True
            pnlRight.AutoScroll = True
            cardDetail.Dock = DockStyle.Top
            AddHandler cardDetail.Layout, Sub()
                                              Dim reqH As Integer = Math.Max(btnBatalkan.Bottom, btnCetakUlang.Bottom) + 18
                                              If cardDetail.Height <> reqH Then cardDetail.Height = reqH
                                          End Sub

            Dim idCulture = New CultureInfo("id-ID")
            ModTema.GayaDataGridView(dgvPesanan)
            dgvPesanan.ColumnHeadersDefaultCellStyle.Padding = New Padding(4, 0, 4, 0)
            dgvPesanan.DefaultCellStyle.Padding = New Padding(4, 4, 4, 4)
            colTotal.DefaultCellStyle.FormatProvider = idCulture
            AddHandler dgvPesanan.SelectionChanged, AddressOf OnSelectionChanged
            AddHandler dgvPesanan.CellFormatting, AddressOf OnPesananCellFormatting

            ModTema.GayaDataGridView(dgvDetail)
            dgvDetail.RowTemplate.Height = 32
            dgvDetail.ColumnHeadersHeight = 34
            colSubtotalDetail.DefaultCellStyle.FormatProvider = idCulture

            lblInfoPesanan.Font = New Font(ModTema.FontJudul.FontFamily, 11.5F, FontStyle.Bold)
            lblInfoPesanan.AutoEllipsis = True
            lblTotCap.Font = ModTema.FontSubJudul
            lblTotal.Font = New Font(ModTema.FontJudul.FontFamily, 15.0F, FontStyle.Bold)
            lblTotal.ForeColor = ModTema.WarnaUtama

            ModTema.GayaGunaTextBox(txtUangBayar, "Nominal uang tunai...")
            AddHandler txtUangBayar.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            AddHandler txtUangBayar.TextChanged, Sub() HitungKembalianLive()

            lstPecahan.Font = ModTema.FontStruk
            lstPecahan.BackColor = ModTema.WarnaLatar

            btnKonfirmasiTunai.Image = BistroIcons.GetIcon(IconChar.Check, Color.White, 16)
            btnKonfirmasiTunai.ImageOffset = New Point(-6, 0)
            ModTema.GayaGunaButtonSukses(btnKonfirmasiTunai, 10)
            AddHandler btnKonfirmasiTunai.Click, AddressOf OnKonfirmasiTunaiClick

            btnBatalkan.Image = BistroIcons.GetIcon(IconChar.TrashAlt, ModTema.WarnaBahaya, 14)
            btnBatalkan.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonBahaya(btnBatalkan, 10)
            AddHandler btnBatalkan.Click, AddressOf OnBatalkanClick

            btnCetakUlang.Image = BistroIcons.GetIcon(IconChar.Print, ModTema.WarnaTeks, 14)
            btnCetakUlang.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSekunder(btnCetakUlang, 10)
            AddHandler btnCetakUlang.Click, AddressOf OnCetakUlangClick

            _tmrRefresh.Interval = 5000
            AddHandler _tmrRefresh.Tick, Sub() MuatPesanan()
            AddHandler Shown, Sub() _tmrRefresh.Start()
            AddHandler FormClosing, Sub() _tmrRefresh.Stop()
        End Sub

        Public Sub SegarkanData()
            MuatPesanan()
        End Sub

        Public Sub MuatPesanan()
            Dim keepId As Integer = _selectedPesananId
            Dim dt = ModAntrian.AmbilPesanan("")
            dgvPesanan.SuspendLayout()
            _bsPesanan.DataSource = dt
            dgvPesanan.DataSource = _bsPesanan
            TerapkanFilter()

            If keepId > 0 Then
                For Each r As DataGridViewRow In dgvPesanan.Rows
                    Dim drv = TryCast(r.DataBoundItem, DataRowView)
                    If drv IsNot Nothing AndAlso CInt(drv("id_pesanan")) = keepId Then
                        r.Selected = True
                        dgvPesanan.CurrentCell = r.Cells("colAntrian")
                        Exit For
                    End If
                Next
            End If
            dgvPesanan.ResumeLayout()
        End Sub

        Private Sub TerapkanFilter()
            Dim bagian As New List(Of String)()
            Dim st As String = If(cboStatus.SelectedItem IsNot Nothing, CStr(cboStatus.SelectedItem), "Semua")
            If st <> "Semua" Then
                bagian.Add($"status_pesanan = '{st.Replace("'", "''")}'")
            End If
            Dim cari As String = txtCariAntrian.Text.Trim()
            Dim noInt As Integer
            If Not String.IsNullOrEmpty(cari) AndAlso Integer.TryParse(cari, noInt) Then
                bagian.Add($"no_antrian = {noInt}")
            End If
            _bsPesanan.Filter = String.Join(" AND ", bagian)
        End Sub

        Private Sub OnPesananCellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
            If e.RowIndex < 0 OrElse e.RowIndex >= dgvPesanan.Rows.Count Then Return
            Dim drv = TryCast(dgvPesanan.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If drv Is Nothing Then Return
            Dim st As String = CStr(drv("status_pesanan"))
            Select Case st
                Case StatusPesanan.MenungguPembayaran
                    e.CellStyle.BackColor = ModTema.WarnaPeringatanLembut
                Case StatusPesanan.Siap
                    e.CellStyle.BackColor = ModTema.WarnaSuksesLembut
                Case StatusPesanan.Dibatalkan
                    e.CellStyle.BackColor = ModTema.WarnaBahayaLembut
            End Select
        End Sub

        Private Sub OnSelectionChanged(sender As Object, e As EventArgs)
            If dgvPesanan.CurrentRow Is Nothing Then
                _selectedPesananId = 0
                Return
            End If
            Dim drv = TryCast(dgvPesanan.CurrentRow.DataBoundItem, DataRowView)
            If drv Is Nothing Then Return

            _selectedPesananId = CInt(drv("id_pesanan"))
            Dim noAntrian As Integer = CInt(drv("no_antrian"))
            _selectedTotal = CDec(drv("total"))
            _selectedStatus = CStr(drv("status_pesanan"))
            _selectedMetode = CStr(drv("metode_bayar"))

            lblInfoPesanan.Text = $"Antrian {ModFormat.NoAntrianStr(noAntrian)} — {_selectedStatus}"
            lblTotal.Text = ModFormat.Rupiah(_selectedTotal)
            dgvDetail.DataSource = ModAntrian.AmbilDetail(_selectedPesananId)

            Dim bolehTunai As Boolean = (_selectedStatus = StatusPesanan.MenungguPembayaran AndAlso _selectedMetode = MetodeBayar.Tunai)
            btnKonfirmasiTunai.Enabled = bolehTunai
            txtUangBayar.Enabled = bolehTunai
            If bolehTunai AndAlso Not txtUangBayar.Focused AndAlso String.IsNullOrWhiteSpace(txtUangBayar.Text) Then
                txtUangBayar.Text = CInt(Math.Ceiling(_selectedTotal)).ToString()
            End If
            btnBatalkan.Enabled = (_selectedStatus = StatusPesanan.MenungguPembayaran OrElse _selectedStatus = StatusPesanan.Diproses)
            btnCetakUlang.Enabled = True
            HitungKembalianLive()
        End Sub

        Private Sub HitungKembalianLive()
            lstPecahan.Items.Clear()
            If _selectedPesananId = 0 OrElse Not txtUangBayar.Enabled Then
                lblKembalian.Text = "Kembalian: -"
                _errKasir.SetError(txtUangBayar, "")
                Return
            End If
            Dim uang As Decimal = 0D
            If Not ModValidasi.BacaAngka(txtUangBayar, _errKasir, uang) Then
                lblKembalian.Text = "Kembalian: -"
                Return
            End If
            If uang < _selectedTotal Then
                _errKasir.SetError(txtUangBayar, $"Minimal {ModFormat.Rupiah(_selectedTotal)}.")
                lblKembalian.Text = "Uang belum mencukupi"
                lblKembalian.ForeColor = ModTema.WarnaBahaya
                Return
            End If
            _errKasir.SetError(txtUangBayar, "")
            Dim kemb = ModPesanan.HitungKembalian(_selectedTotal, uang)
            lblKembalian.Text = $"Kembalian: {ModFormat.Rupiah(kemb)}"
            lblKembalian.ForeColor = ModTema.WarnaSukses
            Dim pec = ModPesanan.PecahKembalian(kemb)
            If pec.Count = 0 Then
                lstPecahan.Items.Add("Uang pas — tidak ada kembalian.")
            Else
                For Each kvp In pec
                    lstPecahan.Items.Add($"{kvp.Value}x  {ModFormat.Rupiah(kvp.Key)}")
                Next
            End If
        End Sub

        Private Sub OnKonfirmasiTunaiClick(sender As Object, e As EventArgs)
            If _selectedPesananId = 0 Then Return
            Dim uang As Decimal = 0D
            If Not ModValidasi.BacaAngka(txtUangBayar, _errKasir, uang) Then Return
            If uang < _selectedTotal Then
                _errKasir.SetError(txtUangBayar, $"Uang bayar minimal {ModFormat.Rupiah(_selectedTotal)}.")
                Return
            End If
            If ModAntrian.KonfirmasiTunai(_selectedPesananId, uang) Then
                ModLog.Catat(KodeAksi.BayarTunai, $"Konfirmasi tunai pesanan ID {_selectedPesananId} sebesar {ModFormat.Rupiah(uang)}")
                MuatPesanan()
                Dim res = MessageBox.Show("Pembayaran tunai berhasil dikonfirmasi dan dikirim ke dapur. Cetak struk sekarang?", "Konfirmasi Berhasil", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If res = DialogResult.Yes Then
                    Using frm As New FrmStruk(_selectedPesananId, True)
                        frm.ShowDialog(Me)
                    End Using
                End If
            End If
        End Sub

        Private Sub OnBatalkanClick(sender As Object, e As EventArgs)
            If _selectedPesananId = 0 Then Return
            Dim res = MessageBox.Show("Yakin ingin membatalkan pesanan ini? Stok produk akan dikembalikan.", "Batalkan Pesanan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If res <> DialogResult.Yes Then Return
            If ModAntrian.UbahStatus(_selectedPesananId, StatusPesanan.Dibatalkan) Then
                ModLog.Catat(KodeAksi.PesananBatal, $"Membatalkan pesanan ID {_selectedPesananId}")
                MuatPesanan()
            Else
                MessageBox.Show("Pesanan dengan status saat ini tidak dapat dibatalkan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub OnCetakUlangClick(sender As Object, e As EventArgs)
            If _selectedPesananId = 0 Then Return
            Using frm As New FrmStruk(_selectedPesananId, True)
                frm.ShowDialog(Me)
            End Using
        End Sub

    End Class
End Namespace
