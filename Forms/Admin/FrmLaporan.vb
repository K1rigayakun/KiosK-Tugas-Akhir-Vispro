Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Admin

    Public Class FrmLaporan
        Private ReadOnly _bsRiwayat As New BindingSource()

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
            MuatLaporan()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            dtpDari.Value = DateTime.Today.AddDays(-6)
            dtpSampai.Value = DateTime.Today

            ModTema.GayaGunaComboBox(cboStatus)
            cboStatus.Items.Clear()
            cboStatus.Items.AddRange({"Semua", StatusPesanan.Selesai, StatusPesanan.Siap, StatusPesanan.Diproses, StatusPesanan.MenungguPembayaran, StatusPesanan.Dibatalkan})
            cboStatus.SelectedIndex = 0
            AddHandler cboStatus.SelectedIndexChanged, Sub() TerapkanFilterRiwayat()

            ModTema.GayaGunaButtonUtama(btnTampil, 10)
            AddHandler btnTampil.Click, Sub() MuatLaporan()

            btnEkspor.Image = BistroIcons.GetIcon(IconChar.FloppyDisk, Color.White, 15)
            btnEkspor.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonDark(btnEkspor, 10)
            AddHandler btnEkspor.Click, AddressOf OnEksporCsvClick

            tabLaporan.TabMenuBackColor = ModTema.WarnaLatar
            tabLaporan.TabButtonIdleState.FillColor = ModTema.WarnaLatar
            tabLaporan.TabButtonIdleState.ForeColor = ModTema.WarnaTeksRedup
            tabLaporan.TabButtonIdleState.Font = ModTema.FontTebal
            tabLaporan.TabButtonSelectedState.FillColor = ModTema.WarnaSekunderLatar
            tabLaporan.TabButtonSelectedState.ForeColor = ModTema.WarnaTeks
            tabLaporan.TabButtonSelectedState.InnerColor = ModTema.WarnaUtama
            tabLaporan.TabButtonSelectedState.Font = ModTema.FontTebal

            For Each c In {cardRiwayat, cardRekap, cardTerlaris}
                ModTema.GayaGunaCard(c, 14)
            Next

            ModTema.GayaDataGridView(dgvRiwayat)
            colTotal.DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
            AddHandler dgvRiwayat.CellDoubleClick, AddressOf OnRiwayatDoubleClick

            ModTema.GayaDataGridView(dgvRekap)

            ModTema.GayaDataGridView(dgvTerlaris)
            colTopOmzet.DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
        End Sub

        Public Sub MuatLaporan()
            If dtpSampai.Value.Date < dtpDari.Value.Date Then
                errLaporan.SetError(dtpSampai, "Tanggal sampai harus >= tanggal dari.") : Return
            End If
            If (dtpSampai.Value.Date - dtpDari.Value.Date).TotalDays > 366 Then
                errLaporan.SetError(dtpSampai, "Rentang maksimal 366 hari.") : Return
            End If
            errLaporan.Clear()

            Dim dari = dtpDari.Value.Date
            Dim sampai = dtpSampai.Value.Date

            ' 1. Riwayat
            _bsRiwayat.DataSource = ModLaporan.AmbilRiwayat(dari, sampai)
            dgvRiwayat.DataSource = _bsRiwayat
            TerapkanFilterRiwayat()

            ' 2. Rekap Kategori x Hari (Nested Loop Array 2D ke DGV unbound)
            Dim rekap = ModLaporan.AmbilRekapKategoriHari(dari, sampai)
            dgvRekap.Columns.Clear()
            dgvRekap.Rows.Clear()
            dgvRekap.Columns.Add("colKat", "Kategori")
            dgvRekap.Columns(0).Width = 145
            For Each tgl In rekap.Tanggal
                Dim colIdx = dgvRekap.Columns.Add($"d_{tgl:yyyyMMdd}", tgl.ToString("dd/MM"))
                dgvRekap.Columns(colIdx).Width = 100
                dgvRekap.Columns(colIdx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Next
            Dim colTotIdx = dgvRekap.Columns.Add("colTotal", "Total Kategori")
            dgvRekap.Columns(colTotIdx).Width = 135
            dgvRekap.Columns(colTotIdx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Dim colTotals(rekap.Tanggal.Length - 1) As Decimal
            Dim grandTotal As Decimal = 0D

            For r As Integer = 0 To rekap.Kategori.Length - 1
                Dim rowCells As New List(Of Object) From {rekap.Kategori(r)}
                Dim rowTotal As Decimal = 0D
                For c As Integer = 0 To rekap.Tanggal.Length - 1
                    Dim v As Decimal = rekap.Matriks(r, c)
                    rowTotal += v
                    colTotals(c) += v
                    rowCells.Add(ModFormat.Rupiah(v))
                Next
                grandTotal += rowTotal
                rowCells.Add(ModFormat.Rupiah(rowTotal))
                dgvRekap.Rows.Add(rowCells.ToArray())
            Next

            Dim footCells As New List(Of Object) From {"TOTAL HARIAN"}
            For c As Integer = 0 To colTotals.Length - 1
                footCells.Add(ModFormat.Rupiah(colTotals(c)))
            Next
            footCells.Add(ModFormat.Rupiah(grandTotal))
            Dim footIdx = dgvRekap.Rows.Add(footCells.ToArray())
            dgvRekap.Rows(footIdx).DefaultCellStyle.Font = ModTema.FontTebal
            dgvRekap.Rows(footIdx).DefaultCellStyle.BackColor = ModTema.WarnaSekunderLatar

            ' 3. Top 10 Menu Terlaris
            dgvTerlaris.DataSource = ModLaporan.AmbilMenuTerlaris(10, dari, sampai)
        End Sub

        Private Sub TerapkanFilterRiwayat()
            Dim st As String = If(cboStatus.SelectedItem IsNot Nothing, CStr(cboStatus.SelectedItem), "Semua")
            _bsRiwayat.Filter = If(st = "Semua", "", $"status_pesanan = '{st.Replace("'", "''")}'")

            Dim jml As Integer = 0
            Dim omzet As Decimal = 0D
            For Each obj As Object In _bsRiwayat.List
                Dim drv = TryCast(obj, DataRowView)
                If drv Is Nothing Then Continue For
                jml += 1
                If CStr(drv("status_bayar")) = StatusBayar.Lunas AndAlso CStr(drv("status_pesanan")) <> StatusPesanan.Dibatalkan Then
                    omzet += CDec(drv("total"))
                End If
            Next
            lblJumlah.Text = $"Jumlah Transaksi: {jml}"
            lblOmzet.Text = $"Total Omzet Sah: {ModFormat.Rupiah(omzet)}"
        End Sub

        Private Sub OnRiwayatDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 OrElse dgvRiwayat.Rows(e.RowIndex).DataBoundItem Is Nothing Then Return
            Dim drv = DirectCast(dgvRiwayat.Rows(e.RowIndex).DataBoundItem, DataRowView)
            Dim idPes As Integer = CInt(drv("id_pesanan"))
            Dim noAnt As Integer = CInt(drv("no_antrian"))
            Dim ringkasan = ModAntrian.RingkasanItemTeks(idPes)
            MessageBox.Show($"Detail Pesanan {ModFormat.NoAntrianStr(noAnt)}:{Environment.NewLine}{ringkasan}{Environment.NewLine}Total: {ModFormat.Rupiah(CDec(drv("total")))}", "Detail Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OnEksporCsvClick(sender As Object, e As EventArgs)
            Dim dgvAktif As DataGridView = dgvRiwayat
            If tabLaporan.SelectedIndex = 1 Then dgvAktif = dgvRekap
            If tabLaporan.SelectedIndex = 2 Then dgvAktif = dgvTerlaris

            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV File (*.csv)|*.csv"
                sfd.FileName = $"Laporan-Bistro-{DateTime.Now:yyyyMMdd}.csv"
                If sfd.ShowDialog(Me) <> DialogResult.OK Then Return

                Dim sw As StreamWriter = Nothing
                Try
                    sw = New StreamWriter(sfd.FileName, False, New UTF8Encoding(True))
                    Dim headers = dgvAktif.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible).Select(Function(c) EscapeCsv(c.HeaderText))
                    sw.WriteLine(String.Join(";", headers))

                    For Each r As DataGridViewRow In dgvAktif.Rows
                        If r.IsNewRow Then Continue For
                        Dim vals = dgvAktif.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible).Select(Function(c) EscapeCsv(If(r.Cells(c.Index).Value?.ToString(), "")))
                        sw.WriteLine(String.Join(";", vals))
                    Next
                    MessageBox.Show("Laporan CSV berhasil diekspor.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As IOException
                    MessageBox.Show("Gagal menulis CSV: " & ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If sw IsNot Nothing Then sw.Dispose()
                End Try
            End Using
        End Sub

        Private Shared Function EscapeCsv(val As String) As String
            If String.IsNullOrEmpty(val) Then Return ""
            ' Cegah CSV formula injection (Excel/Sheets mengeksekusi awalan =, +, -, @, Tab, CR)
            Dim safeVal As String = val
            If safeVal.Length > 0 AndAlso ("=+-@" & vbTab & vbCr).IndexOf(safeVal(0)) >= 0 Then
                safeVal = "'" & safeVal
            End If
            If safeVal.Contains(";"c) OrElse safeVal.Contains(""""c) OrElse safeVal.Contains(vbCr) OrElse safeVal.Contains(vbLf) Then
                Return """" & safeVal.Replace("""", """""") & """"
            End If
            Return safeVal
        End Function

    End Class
End Namespace
