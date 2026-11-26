Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kasir

    Public Class FrmDapur
        Private ReadOnly _tmrTampil As New Timer()
        Private ReadOnly _tmrToast As New Timer()
        Private ReadOnly _grafikJam As New GrafikBatang()

        Private ReadOnly _sudahTampilSet As New HashSet(Of Integer)()
        Private _muted As Boolean = False
        Private _lastPollTick As ULong = 0UL
        Private _dtDapur As DataTable
        Private _firstStatLoad As Boolean = True
        Private _lastDapurSig As String = ""
        Private _selectedPesananId As Integer = 0

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
            MuatDapur(True)
            MuatStatistik()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar

            tabDapur.Alignment = TabAlignment.Top
            tabDapur.TabButtonSize = New Size(200, 42)
            tabDapur.ItemSize = New Size(200, 42)
            tabDapur.TabMenuBackColor = ModTema.WarnaLatar
            tabDapur.TabButtonIdleState.FillColor = ModTema.WarnaLatar
            tabDapur.TabButtonIdleState.ForeColor = ModTema.WarnaTeksRedup
            tabDapur.TabButtonIdleState.Font = ModTema.FontTebal
            tabDapur.TabButtonSelectedState.FillColor = ModTema.WarnaSekunderLatar
            tabDapur.TabButtonSelectedState.ForeColor = ModTema.WarnaTeks
            tabDapur.TabButtonSelectedState.InnerColor = ModTema.WarnaUtama
            tabDapur.TabButtonSelectedState.Font = ModTema.FontTebal

            ModTema.GayaGunaComboBox(cboTampil)
            cboTampil.Items.AddRange({StatusPesanan.Diproses, StatusPesanan.Siap})
            cboTampil.SelectedIndex = 0
            AddHandler cboTampil.SelectedIndexChanged, Sub() MuatDapur(False)

            btnSiap.Image = BistroIcons.GetIcon(IconChar.Check, Color.White, 15)
            btnSiap.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSukses(btnSiap, 10)
            AddHandler btnSiap.Click, Sub() UbahStatusTerpilih(StatusPesanan.Siap)

            ModTema.GayaGunaButtonUtama(btnSelesai, 10)
            AddHandler btnSelesai.Click, Sub() UbahStatusTerpilih(StatusPesanan.Selesai)

            btnMute.Image = BistroIcons.GetIcon(IconChar.Bell, ModTema.WarnaTeks, 15)
            btnMute.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSekunder(btnMute, 10)
            AddHandler btnMute.Click, Sub()
                                          _muted = Not _muted
                                          btnMute.Text = If(_muted, "Suara: OFF", "Suara: ON")
                                      End Sub

            ModTema.GayaGunaButtonDark(btnSimulasiMasuk, 10)
            AddHandler btnSimulasiMasuk.Click, AddressOf OnSimulasiPesananMasuk

            For Each c In {cardGrid, cardGrafik, cardKpiRata, cardKpiSelesai, cardKpiTerlama}
                ModTema.GayaGunaCard(c, 16)
            Next
            For Each s In {stripRata, stripSelesai, stripTerlama}
                s.BorderRadius = 3
            Next

            ModTema.GayaDataGridView(dgvDapur)
            dgvDapur.RowTemplate.Height = 46
            colAntrian.DefaultCellStyle.Font = ModTema.FontSubJudul
            colTunggu.DefaultCellStyle.Font = ModTema.FontSubJudul
            AddHandler dgvDapur.CellFormatting, AddressOf OnDapurCellFormatting
            AddHandler dgvDapur.SelectionChanged, Sub()
                                                      If dgvDapur.CurrentRow Is Nothing Then Return
                                                      Dim drv = TryCast(dgvDapur.CurrentRow.DataBoundItem, DataRowView)
                                                      If drv IsNot Nothing Then _selectedPesananId = CInt(drv("id_pesanan"))
                                                  End Sub

            icoRata.FillColor = ModTema.WarnaUtamaLembut
            icoRata.Image = BistroIcons.GetBadgeIcon(IconChar.Clock, ModTema.WarnaUtama, ModTema.WarnaUtamaLembut, 40, 19)
            icoSelesai.FillColor = ModTema.WarnaSuksesLembut
            icoSelesai.Image = BistroIcons.GetBadgeIcon(IconChar.Check, ModTema.WarnaSukses, ModTema.WarnaSuksesLembut, 40, 19)
            icoTerlama.FillColor = ModTema.WarnaPeringatanLembut
            icoTerlama.Image = BistroIcons.GetBadgeIcon(IconChar.Fire, ModTema.WarnaPeringatan, ModTema.WarnaPeringatanLembut, 40, 19)

            pnlGrafikHost.Controls.Clear()
            _grafikJam.Dock = DockStyle.Fill
            _grafikJam.FormatSebagaiRupiah = False
            pnlGrafikHost.Controls.Add(_grafikJam)

            pnlToast.BorderRadius = 14
            pnlToast.BorderColor = ModTema.WarnaUtama
            pnlToast.BorderThickness = 1
            picBell.Image = BistroIcons.GetIcon(IconChar.Bell, ModTema.WarnaAksen, 22)
            pnlToast.BringToFront()

            _tmrToast.Interval = 4500
            AddHandler _tmrToast.Tick, Sub()
                                           _tmrToast.Stop()
                                           ModAnimasi.AnimateTop(pnlToast, ClientSize.Height + 20, 260UL, Sub() pnlToast.Visible = False)
                                       End Sub

            _tmrTampil.Interval = 1000
            AddHandler _tmrTampil.Tick, AddressOf OnTimerTick
            AddHandler Shown, Sub() _tmrTampil.Start()
            AddHandler FormClosing, Sub()
                                        _tmrTampil.Stop()
                                        _tmrToast.Stop()
                                    End Sub
        End Sub

        Private Sub OnTimerTick(sender As Object, e As EventArgs)
            PerbaruiKolomWaktuTunggu()
            Dim nowTick = ModWindowsApi.WaktuAktif()
            If nowTick - _lastPollTick >= 5000UL Then
                _lastPollTick = nowTick
                MuatDapur(False)
                MuatStatistik()
            End If
        End Sub

        Public Sub SegarkanData()
            MuatDapur(False)
            MuatStatistik()
        End Sub

        Private Sub MuatDapur(initial As Boolean)
            _lastPollTick = ModWindowsApi.WaktuAktif()
            Dim statusFilter As String = If(cboTampil.SelectedItem IsNot Nothing, CStr(cboTampil.SelectedItem), StatusPesanan.Diproses)
            Dim raw = ModAntrian.AmbilPesanan(statusFilter)

            Dim sigParts As New List(Of String)(raw.Rows.Count + 1) From {statusFilter}
            For Each r As DataRow In raw.Rows
                sigParts.Add($"{CInt(r("id_pesanan"))}:{CStr(r("status_pesanan"))}")
            Next
            Dim newSig As String = String.Join("|", sigParts)
            btnSiap.Enabled = (statusFilter = StatusPesanan.Diproses)
            btnSelesai.Enabled = (statusFilter = StatusPesanan.Siap)

            If Not initial AndAlso newSig = _lastDapurSig AndAlso _dtDapur IsNot Nothing Then
                PerbaruiKolomWaktuTunggu()
                Return
            End If
            _lastDapurSig = newSig

            Dim keepId As Integer = _selectedPesananId
            Dim dt As New DataTable()
            dt.Columns.Add("id_pesanan", GetType(Integer))
            dt.Columns.Add("no_antrian", GetType(Integer))
            dt.Columns.Add("tipe_makan", GetType(String))
            dt.Columns.Add("ringkasan_item", GetType(String))
            dt.Columns.Add("waktu_diproses", GetType(Object))
            dt.Columns.Add("waktu_tunggu", GetType(String))
            dt.Columns.Add("menit_tunggu", GetType(Double))
            dt.Columns.Add("status_pesanan", GetType(String))

            Dim adaBaru As Boolean = False
            Dim noAntrianBaru As Integer = 0

            For Each r As DataRow In raw.Rows
                Dim idPes As Integer = CInt(r("id_pesanan"))
                Dim noAnt As Integer = CInt(r("no_antrian"))
                Dim wDiproses As DateTime = If(IsDBNull(r("waktu_diproses")), CDate(r("tanggal")), CDate(r("waktu_diproses")))
                Dim dur As TimeSpan = DateTime.Now - wDiproses
                dt.Rows.Add(idPes, noAnt, CStr(r("tipe_makan")), ModAntrian.RingkasanItemTeks(idPes), wDiproses, ModFormat.Durasi(dur), dur.TotalMinutes, CStr(r("status_pesanan")))

                If Not _sudahTampilSet.Contains(idPes) Then
                    _sudahTampilSet.Add(idPes)
                    If Not initial AndAlso statusFilter = StatusPesanan.Diproses Then
                        adaBaru = True
                        noAntrianBaru = noAnt
                    End If
                End If
            Next

            _dtDapur = dt
            dgvDapur.DataSource = _dtDapur

            If keepId > 0 Then
                For Each row As DataGridViewRow In dgvDapur.Rows
                    Dim drv = TryCast(row.DataBoundItem, DataRowView)
                    If drv IsNot Nothing AndAlso CInt(drv("id_pesanan")) = keepId Then
                        row.Selected = True
                        dgvDapur.CurrentCell = row.Cells("colAntrian")
                        Exit For
                    End If
                Next
            End If

            If adaBaru Then
                TampilkanToast($"Pesanan baru masuk {ModFormat.NoAntrianStr(noAntrianBaru)}")
                If Not _muted Then ModWindowsApi.Bunyi()
            End If
        End Sub

        Private Sub PerbaruiKolomWaktuTunggu()
            If _dtDapur Is Nothing Then Return
            For Each r As DataRow In _dtDapur.Rows
                Dim wDiproses As DateTime = CDate(r("waktu_diproses"))
                Dim dur As TimeSpan = DateTime.Now - wDiproses
                r("waktu_tunggu") = ModFormat.Durasi(dur)
                r("menit_tunggu") = dur.TotalMinutes
            Next
        End Sub

        Private Sub OnDapurCellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
            If e.RowIndex < 0 OrElse _dtDapur Is Nothing OrElse e.RowIndex >= _dtDapur.Rows.Count Then Return
            Dim menit As Double = CDbl(_dtDapur.Rows(e.RowIndex)("menit_tunggu"))
            Dim ambang As Integer = ModPengaturan.AmbilInt("ambang_tunggu_menit", 10)
            Dim st As String = CStr(_dtDapur.Rows(e.RowIndex)("status_pesanan"))
            If st = StatusPesanan.Diproses AndAlso menit >= ambang Then
                e.CellStyle.BackColor = ModTema.WarnaBahayaLembut
                e.CellStyle.ForeColor = ModTema.WarnaBahaya
            End If
        End Sub

        Private Sub UbahStatusTerpilih(statusBaru As String)
            If dgvDapur.CurrentRow Is Nothing Then Return
            Dim drv = TryCast(dgvDapur.CurrentRow.DataBoundItem, DataRowView)
            If drv Is Nothing Then Return
            Dim idPes As Integer = CInt(drv("id_pesanan"))
            Dim noAnt As Integer = CInt(drv("no_antrian"))
            If ModAntrian.UbahStatus(idPes, statusBaru) Then
                ModLog.Catat(KodeAksi.StatusUbah, $"Pesanan {ModFormat.NoAntrianStr(noAnt)} diubah menjadi {statusBaru}")
                MuatDapur(True)
                MuatStatistik()
            Else
                MessageBox.Show("Transisi status tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub OnSimulasiPesananMasuk(sender As Object, e As EventArgs)
            ModAntrian.SimulasikanPesananMasukDapur()
            cboTampil.SelectedItem = StatusPesanan.Diproses
            MuatDapur(False)
            MuatStatistik()
        End Sub

        Public Sub TampilkanToast(pesan As String)
            lblToastMsg.Text = pesan
            pnlToast.Left = ClientSize.Width - pnlToast.Width - 24
            pnlToast.Top = ClientSize.Height + 10
            pnlToast.Visible = True
            pnlToast.BringToFront()
            ModAnimasi.AnimateTop(pnlToast, ClientSize.Height - pnlToast.Height - 24, 280UL)
            _tmrToast.Stop()
            _tmrToast.Start()
        End Sub

        Private Sub MuatStatistik()
            Dim st = ModAntrian.AmbilStatistikDapur()
            If _firstStatLoad AndAlso Visible AndAlso Not ModAnimasi.NonaktifkanAnimasi Then
                _firstStatLoad = False
                ModAnimasi.AnimateNumber(lblValRata, CDec(st.RataMenit), Function(v) $"{v:0.0} mnt", 450UL, 0UL)
                ModAnimasi.AnimateNumber(lblValSelesai, st.SelesaiHariIni, Function(v) CInt(Math.Round(v)).ToString(), 450UL, 60UL)
                ModAnimasi.AnimateNumber(lblValTerlama, CDec(st.TerlamaMenit), Function(v) $"{v:0.0} mnt", 450UL, 120UL)
            Else
                lblValRata.Text = $"{st.RataMenit:0.0} mnt"
                lblValSelesai.Text = st.SelesaiHariIni.ToString()
                lblValTerlama.Text = $"{st.TerlamaMenit:0.0} mnt"
            End If

            Dim pts As New List(Of GrafikTitik)()
            For h As Integer = 8 To 22
                pts.Add(New GrafikTitik With {.Label = $"{h:00}", .Nilai = st.PerJam(h), .Keterangan = $"Jam {h:00}:00 - {st.PerJam(h)} pesanan"})
            Next
            _grafikJam.Data = pts
        End Sub

    End Class
End Namespace
