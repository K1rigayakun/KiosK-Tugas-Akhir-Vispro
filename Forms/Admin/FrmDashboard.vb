Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Admin

    Public Class FrmDashboard
        Private ReadOnly _grafik7Hari As New GrafikBatang()
        Private ReadOnly _tmrRefresh As New Timer()
        Private _firstLoad As Boolean = True
        Private _isLoading As Boolean = False

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
            MuatDashboard()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            ModTema.AktifkanDoubleBuffer(tlpKpi)
            ModTema.AktifkanDoubleBuffer(tlpBottom)
            lblH.Font = New Font(ModTema.FontJudul.FontFamily, 15.0F, FontStyle.Bold)
            lblGraf.Font = ModTema.FontJudul
            lblTop.Font = ModTema.FontJudul

            btnRef.Image = BistroIcons.GetIcon(IconChar.ArrowsRotate, ModTema.WarnaTeks, 14)
            btnRef.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSekunder(btnRef, 12)
            AddHandler btnRef.Click, Sub() MuatDashboard()

            For Each c In {cardKpiPendapatan, cardKpiJumlah, cardKpiRata, cardKpiBatal, cardKpiStok, cardGrafik, cardTop5}
                ModTema.GayaGunaCard(c, 16)
            Next
            For Each s In {stripPendapatan, stripJumlah, stripRata, stripBatal, stripStok}
                s.BorderRadius = 3
            Next

            stripPendapatan.FillColor = ModTema.WarnaSukses
            stripJumlah.FillColor = ModTema.WarnaUtama
            stripRata.FillColor = ModTema.WarnaSekunder
            stripBatal.FillColor = ModTema.WarnaBahaya
            stripStok.FillColor = ModTema.WarnaPeringatan

            ' Ukuran ikon 34x34 di pojok kanan atas & geser lblVal ke Y=46 agar tidak bertabrakan saat layar sempit
            Dim kpiCards = {cardKpiPendapatan, cardKpiJumlah, cardKpiRata, cardKpiBatal, cardKpiStok}
            Dim kpiIcons = {icoPendapatan, icoJumlah, icoRata, icoBatal, icoStok}
            Dim kpiTitles = {lblJudulPendapatan, lblJudulJumlah, lblJudulRata, lblJudulBatal, lblJudulStok}
            Dim kpiVals = {lblValPendapatan, lblValJumlah, lblValRata, lblValBatal, lblValStok}
            Dim kpiSubs = {lblSubPendapatan, lblSubJumlah, lblSubRata, lblSubBatal, lblSubStok}

            For i As Integer = 0 To kpiCards.Length - 1
                kpiIcons(i).Size = New Size(34, 34)
                kpiIcons(i).Location = New Point(kpiCards(i).Width - 46, 10)
                kpiTitles(i).Location = New Point(22, 14)
                kpiTitles(i).Width = Math.Max(80, kpiCards(i).Width - 72)
                kpiVals(i).Location = New Point(22, 46)
                kpiVals(i).Size = New Size(Math.Max(100, kpiCards(i).Width - 34), 34)
                kpiVals(i).Font = New Font(ModTema.FontJudul.FontFamily, 16.5F, FontStyle.Bold)
                kpiVals(i).ForeColor = ModTema.WarnaTeks
                kpiSubs(i).Location = New Point(22, 84)
                kpiSubs(i).Width = Math.Max(100, kpiCards(i).Width - 34)
            Next

            icoPendapatan.FillColor = ModTema.WarnaSuksesLembut
            icoPendapatan.Image = BistroIcons.GetBadgeIcon(IconChar.MoneyBillWave, ModTema.WarnaSukses, ModTema.WarnaSuksesLembut, 34, 16)
            icoJumlah.FillColor = ModTema.WarnaUtamaLembut
            icoJumlah.Image = BistroIcons.GetBadgeIcon(IconChar.Receipt, ModTema.WarnaUtama, ModTema.WarnaUtamaLembut, 34, 16)
            icoRata.FillColor = ModTema.WarnaAksenLembut
            icoRata.Image = BistroIcons.GetBadgeIcon(IconChar.ChartBar, ModTema.WarnaSekunder, ModTema.WarnaAksenLembut, 34, 16)
            icoBatal.FillColor = ModTema.WarnaBahayaLembut
            icoBatal.Image = BistroIcons.GetBadgeIcon(IconChar.ExclamationTriangle, ModTema.WarnaBahaya, ModTema.WarnaBahayaLembut, 34, 16)
            icoStok.FillColor = ModTema.WarnaPeringatanLembut
            icoStok.Image = BistroIcons.GetBadgeIcon(IconChar.Box, ModTema.WarnaPeringatan, ModTema.WarnaPeringatanLembut, 34, 16)

            AddHandler tlpKpi.Resize, AddressOf OnKpiResize

            pnlGrafikHost.Controls.Clear()
            _grafik7Hari.Dock = DockStyle.Fill
            _grafik7Hari.FormatSebagaiRupiah = True
            pnlGrafikHost.Controls.Add(_grafik7Hari)

            ModTema.GayaDataGridView(dgvTop5)
            colOmzet.DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")

            _tmrRefresh.Interval = 30000
            AddHandler _tmrRefresh.Tick, Sub() MuatDashboard()
            AddHandler Shown, Sub()
                                  _tmrRefresh.Start()
                                  If _firstLoad Then
                                      _firstLoad = False
                                      MuatDashboard(True)
                                  End If
                              End Sub
            AddHandler FormClosing, Sub() _tmrRefresh.Stop()
        End Sub

        Private Sub OnKpiResize(sender As Object, e As EventArgs)
            If IsDisposed Then Return
            Dim cardW As Integer = cardKpiPendapatan.Width
            Dim targetSize As Single = If(cardW < 185, 13.0F, If(cardW < 215, 14.5F, 16.5F))
            For Each lv In {lblValPendapatan, lblValJumlah, lblValRata, lblValBatal, lblValStok}
                If Math.Abs(lv.Font.Size - targetSize) > 0.2F Then
                    lv.Font = New Font(ModTema.FontJudul.FontFamily, targetSize, FontStyle.Bold)
                End If
            Next
        End Sub

        Public Sub MuatDashboard(Optional animateKpi As Boolean = False)
            MuatDashboardAsync(animateKpi)
        End Sub

        Private Async Sub MuatDashboardAsync(animateKpi As Boolean)
            If _isLoading OrElse IsDisposed Then Return
            _isLoading = True
            Try
                Dim tRingkas = ModLaporan.AmbilRingkasanDashboardAsync()
                Dim tGrafik = ModLaporan.AmbilPenjualan7HariAsync()
                Dim tTop5 = ModLaporan.AmbilMenuTerlarisAsync(5)
                Await Task.WhenAll(tRingkas, tGrafik, tTop5)

                If IsDisposed Then Return

                Dim ringkas = tRingkas.Result
                If animateKpi AndAlso Visible AndAlso Not ModAnimasi.NonaktifkanAnimasi Then
                    ModAnimasi.AnimateNumber(lblValPendapatan, ringkas.PendapatanHariIni, Function(v) ModFormat.Rupiah(v), 520UL, 0UL)
                    ModAnimasi.AnimateNumber(lblValJumlah, ringkas.JumlahPesananHariIni, Function(v) CInt(Math.Round(v)).ToString(), 420UL, 50UL)
                    ModAnimasi.AnimateNumber(lblValRata, ringkas.RataRataOrder, Function(v) ModFormat.Rupiah(v), 520UL, 100UL)
                    ModAnimasi.AnimateNumber(lblValBatal, ringkas.PesananDibatalkan, Function(v) CInt(Math.Round(v)).ToString(), 380UL, 150UL)
                    ModAnimasi.AnimateNumber(lblValStok, ringkas.ProdukStokMenipis, Function(v) CInt(Math.Round(v)).ToString(), 380UL, 200UL)
                Else
                    lblValPendapatan.Text = ModFormat.Rupiah(ringkas.PendapatanHariIni)
                    lblValJumlah.Text = ringkas.JumlahPesananHariIni.ToString()
                    lblValRata.Text = ModFormat.Rupiah(ringkas.RataRataOrder)
                    lblValBatal.Text = ringkas.PesananDibatalkan.ToString()
                    lblValStok.Text = ringkas.ProdukStokMenipis.ToString()
                End If
                lblSubStok.Text = $"Produk di bawah {ModPengaturan.AmbilInt("ambang_stok", 5)} unit"

                _grafik7Hari.Data = tGrafik.Result
                dgvTop5.DataSource = tTop5.Result
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[FrmDashboard] MuatDashboardAsync gagal: " & ex.Message)
            Finally
                _isLoading = False
            End Try
        End Sub

    End Class
End Namespace
