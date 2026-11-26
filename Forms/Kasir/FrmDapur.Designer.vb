Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kasir

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmDapur
        Inherits System.Windows.Forms.Form

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.tabDapur = New Guna.UI2.WinForms.Guna2TabControl()
            Me.tpAntrian = New System.Windows.Forms.TabPage()
            Me.cardGrid = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvDapur = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAntrian = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTipe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRingkas = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTunggu = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlBar = New System.Windows.Forms.Panel()
            Me.btnSimulasiMasuk = New Guna.UI2.WinForms.Guna2Button()
            Me.btnMute = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSelesai = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSiap = New Guna.UI2.WinForms.Guna2Button()
            Me.cboTampil = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblF = New System.Windows.Forms.Label()
            Me.tpStat = New System.Windows.Forms.TabPage()
            Me.cardGrafik = New Guna.UI2.WinForms.Guna2Panel()
            Me.pnlGrafikHost = New System.Windows.Forms.Panel()
            Me.lblGrafTitle = New System.Windows.Forms.Label()
            Me.tlpKpiStat = New System.Windows.Forms.TableLayoutPanel()
            Me.cardKpiRata = New Guna.UI2.WinForms.Guna2Panel()
            Me.stripRata = New Guna.UI2.WinForms.Guna2Panel()
            Me.icoRata = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblJudulRata = New System.Windows.Forms.Label()
            Me.lblValRata = New System.Windows.Forms.Label()
            Me.lblSubRata = New System.Windows.Forms.Label()
            Me.cardKpiSelesai = New Guna.UI2.WinForms.Guna2Panel()
            Me.stripSelesai = New Guna.UI2.WinForms.Guna2Panel()
            Me.icoSelesai = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblJudulSelesai = New System.Windows.Forms.Label()
            Me.lblValSelesai = New System.Windows.Forms.Label()
            Me.lblSubSelesai = New System.Windows.Forms.Label()
            Me.cardKpiTerlama = New Guna.UI2.WinForms.Guna2Panel()
            Me.stripTerlama = New Guna.UI2.WinForms.Guna2Panel()
            Me.icoTerlama = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblJudulTerlama = New System.Windows.Forms.Label()
            Me.lblValTerlama = New System.Windows.Forms.Label()
            Me.lblSubTerlama = New System.Windows.Forms.Label()
            Me.pnlToast = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblToastMsg = New System.Windows.Forms.Label()
            Me.picBell = New System.Windows.Forms.PictureBox()
            Me.tabDapur.SuspendLayout()
            Me.tpAntrian.SuspendLayout()
            Me.cardGrid.SuspendLayout()
            CType(Me.dgvDapur, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBar.SuspendLayout()
            Me.tpStat.SuspendLayout()
            Me.cardGrafik.SuspendLayout()
            Me.tlpKpiStat.SuspendLayout()
            Me.cardKpiRata.SuspendLayout()
            CType(Me.icoRata, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardKpiSelesai.SuspendLayout()
            CType(Me.icoSelesai, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardKpiTerlama.SuspendLayout()
            CType(Me.icoTerlama, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlToast.SuspendLayout()
            CType(Me.picBell, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tabDapur
            '
            Me.tabDapur.Alignment = System.Windows.Forms.TabAlignment.Top
            Me.tabDapur.Controls.Add(Me.tpAntrian)
            Me.tabDapur.Controls.Add(Me.tpStat)
            Me.tabDapur.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabDapur.ItemSize = New System.Drawing.Size(200, 42)
            Me.tabDapur.Location = New System.Drawing.Point(0, 0)
            Me.tabDapur.Name = "tabDapur"
            Me.tabDapur.SelectedIndex = 0
            Me.tabDapur.Size = New System.Drawing.Size(1160, 680)
            Me.tabDapur.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
            Me.tabDapur.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tabDapur.TabButtonIdleState.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.tabDapur.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.tabDapur.TabButtonIdleState.InnerColor = System.Drawing.Color.White
            Me.tabDapur.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.tabDapur.TabButtonSelectedState.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.tabDapur.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.tabDapur.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.tabDapur.TabButtonSize = New System.Drawing.Size(200, 42)
            Me.tabDapur.TabIndex = 0
            Me.tabDapur.TabMenuBackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            '
            'tpAntrian
            '
            Me.tpAntrian.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tpAntrian.Controls.Add(Me.cardGrid)
            Me.tpAntrian.Controls.Add(Me.pnlBar)
            Me.tpAntrian.Location = New System.Drawing.Point(4, 46)
            Me.tpAntrian.Name = "tpAntrian"
            Me.tpAntrian.Padding = New System.Windows.Forms.Padding(16)
            Me.tpAntrian.Size = New System.Drawing.Size(1152, 630)
            Me.tpAntrian.TabIndex = 0
            Me.tpAntrian.Text = "Antrian Dapur"
            '
            'pnlBar
            '
            Me.pnlBar.BackColor = System.Drawing.Color.Transparent
            Me.pnlBar.Controls.Add(Me.btnSimulasiMasuk)
            Me.pnlBar.Controls.Add(Me.btnMute)
            Me.pnlBar.Controls.Add(Me.btnSelesai)
            Me.pnlBar.Controls.Add(Me.btnSiap)
            Me.pnlBar.Controls.Add(Me.cboTampil)
            Me.pnlBar.Controls.Add(Me.lblF)
            Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlBar.Location = New System.Drawing.Point(16, 16)
            Me.pnlBar.Name = "pnlBar"
            Me.pnlBar.Size = New System.Drawing.Size(1120, 58)
            Me.pnlBar.TabIndex = 0
            '
            'lblF
            '
            Me.lblF.BackColor = System.Drawing.Color.Transparent
            Me.lblF.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblF.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblF.Location = New System.Drawing.Point(4, 16)
            Me.lblF.Name = "lblF"
            Me.lblF.Size = New System.Drawing.Size(78, 24)
            Me.lblF.TabIndex = 0
            Me.lblF.Text = "Tampilkan:"
            '
            'cboTampil
            '
            Me.cboTampil.BackColor = System.Drawing.Color.Transparent
            Me.cboTampil.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboTampil.BorderRadius = 12
            Me.cboTampil.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cboTampil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTampil.FillColor = System.Drawing.Color.White
            Me.cboTampil.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cboTampil.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.cboTampil.ItemHeight = 30
            Me.cboTampil.Location = New System.Drawing.Point(86, 10)
            Me.cboTampil.Name = "cboTampil"
            Me.cboTampil.Size = New System.Drawing.Size(138, 36)
            Me.cboTampil.TabIndex = 1
            Me.cboTampil.BorderThickness = 1
            '
            'btnSiap
            '
            Me.btnSiap.BackColor = System.Drawing.Color.Transparent
            Me.btnSiap.BorderRadius = 12
            Me.btnSiap.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSiap.FillColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.btnSiap.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSiap.ForeColor = System.Drawing.Color.White
            Me.btnSiap.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnSiap.Location = New System.Drawing.Point(236, 8)
            Me.btnSiap.Name = "btnSiap"
            Me.btnSiap.BorderThickness = 0
            Me.btnSiap.Size = New System.Drawing.Size(138, 42)
            Me.btnSiap.TabIndex = 2
            Me.btnSiap.Text = "Tandai Siap"
            Me.btnSiap.UseTransparentBackground = True
            '
            'btnSelesai
            '
            Me.btnSelesai.BackColor = System.Drawing.Color.Transparent
            Me.btnSelesai.BorderRadius = 12
            Me.btnSelesai.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSelesai.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnSelesai.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSelesai.ForeColor = System.Drawing.Color.White
            Me.btnSelesai.Location = New System.Drawing.Point(384, 8)
            Me.btnSelesai.Name = "btnSelesai"
            Me.btnSelesai.BorderThickness = 0
            Me.btnSelesai.Size = New System.Drawing.Size(146, 42)
            Me.btnSelesai.TabIndex = 3
            Me.btnSelesai.Text = "Tandai Selesai"
            Me.btnSelesai.UseTransparentBackground = True
            '
            'btnMute
            '
            Me.btnMute.BackColor = System.Drawing.Color.Transparent
            Me.btnMute.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnMute.BorderRadius = 12
            Me.btnMute.BorderThickness = 1
            Me.btnMute.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMute.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnMute.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnMute.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnMute.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnMute.Location = New System.Drawing.Point(540, 8)
            Me.btnMute.Name = "btnMute"
            Me.btnMute.Size = New System.Drawing.Size(116, 42)
            Me.btnMute.TabIndex = 4
            Me.btnMute.Text = "Suara: ON"
            Me.btnMute.UseTransparentBackground = True
            '
            'btnSimulasiMasuk
            '
            Me.btnSimulasiMasuk.BackColor = System.Drawing.Color.Transparent
            Me.btnSimulasiMasuk.BorderRadius = 12
            Me.btnSimulasiMasuk.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSimulasiMasuk.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnSimulasiMasuk.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSimulasiMasuk.ForeColor = System.Drawing.Color.White
            Me.btnSimulasiMasuk.Location = New System.Drawing.Point(666, 8)
            Me.btnSimulasiMasuk.Name = "btnSimulasiMasuk"
            Me.btnSimulasiMasuk.BorderThickness = 0
            Me.btnSimulasiMasuk.Size = New System.Drawing.Size(236, 42)
            Me.btnSimulasiMasuk.TabIndex = 5
            Me.btnSimulasiMasuk.Text = "+ Simulasi Pesanan Baru"
            Me.btnSimulasiMasuk.UseTransparentBackground = True
            '
            'cardGrid
            '
            Me.cardGrid.BackColor = System.Drawing.Color.Transparent
            Me.cardGrid.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGrid.BorderRadius = 16
            Me.cardGrid.BorderThickness = 1
            Me.cardGrid.Controls.Add(Me.dgvDapur)
            Me.cardGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGrid.FillColor = System.Drawing.Color.White
            Me.cardGrid.Location = New System.Drawing.Point(16, 74)
            Me.cardGrid.Name = "cardGrid"
            Me.cardGrid.Padding = New System.Windows.Forms.Padding(12)
            Me.cardGrid.Size = New System.Drawing.Size(1120, 540)
            Me.cardGrid.TabIndex = 1
            Me.cardGrid.UseTransparentBackground = True
            '
            'dgvDapur
            '
            Me.dgvDapur.AllowUserToAddRows = False
            Me.dgvDapur.AllowUserToDeleteRows = False
            Me.dgvDapur.AutoGenerateColumns = False
            Me.dgvDapur.BackgroundColor = System.Drawing.Color.White
            Me.dgvDapur.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvDapur.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvDapur.ColumnHeadersHeight = 40
            Me.dgvDapur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colAntrian, Me.colTipe, Me.colRingkas, Me.colTunggu, Me.colStatus})
            Me.dgvDapur.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvDapur.Location = New System.Drawing.Point(12, 12)
            Me.dgvDapur.MultiSelect = False
            Me.dgvDapur.Name = "dgvDapur"
            Me.dgvDapur.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDapur.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvDapur.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDapur.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvDapur.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvDapur.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDapur.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvDapur.ThemeStyle.RowsStyle.Height = 40
            Me.dgvDapur.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDapur.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvDapur.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvDapur.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvDapur.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDapur.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvDapur.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvDapur.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvDapur.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvDapur.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvDapur.ReadOnly = True
            Me.dgvDapur.RowHeadersVisible = False
            Me.dgvDapur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDapur.Size = New System.Drawing.Size(1096, 516)
            Me.dgvDapur.TabIndex = 0
            Me.dgvDapur.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light
            '
            'colId
            '
            Me.colId.DataPropertyName = "id_pesanan"
            Me.colId.Name = "colId"
            Me.colId.ReadOnly = True
            Me.colId.Visible = False
            '
            'colAntrian
            '
            Me.colAntrian.DataPropertyName = "no_antrian"
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle1.Format = "000"
            Me.colAntrian.DefaultCellStyle = DataGridViewCellStyle1
            Me.colAntrian.HeaderText = "No Antrian"
            Me.colAntrian.Name = "colAntrian"
            Me.colAntrian.ReadOnly = True
            Me.colAntrian.Width = 96
            '
            'colTipe
            '
            Me.colTipe.DataPropertyName = "tipe_makan"
            Me.colTipe.HeaderText = "Tipe"
            Me.colTipe.Name = "colTipe"
            Me.colTipe.ReadOnly = True
            Me.colTipe.Width = 100
            '
            'colRingkas
            '
            Me.colRingkas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colRingkas.DataPropertyName = "ringkasan_item"
            Me.colRingkas.HeaderText = "Ringkasan Item"
            Me.colRingkas.Name = "colRingkas"
            Me.colRingkas.ReadOnly = True
            '
            'colTunggu
            '
            Me.colTunggu.DataPropertyName = "waktu_tunggu"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.colTunggu.DefaultCellStyle = DataGridViewCellStyle2
            Me.colTunggu.HeaderText = "Waktu Tunggu"
            Me.colTunggu.Name = "colTunggu"
            Me.colTunggu.ReadOnly = True
            Me.colTunggu.Width = 130
            '
            'colStatus
            '
            Me.colStatus.DataPropertyName = "status_pesanan"
            Me.colStatus.HeaderText = "Status"
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            Me.colStatus.Width = 130
            '
            'tpStat
            '
            Me.tpStat.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tpStat.Controls.Add(Me.cardGrafik)
            Me.tpStat.Controls.Add(Me.tlpKpiStat)
            Me.tpStat.Location = New System.Drawing.Point(4, 46)
            Me.tpStat.Name = "tpStat"
            Me.tpStat.Padding = New System.Windows.Forms.Padding(18)
            Me.tpStat.Size = New System.Drawing.Size(1152, 630)
            Me.tpStat.TabIndex = 1
            Me.tpStat.Text = "Statistik Dapur"
            '
            'tlpKpiStat
            '
            Me.tlpKpiStat.BackColor = System.Drawing.Color.Transparent
            Me.tlpKpiStat.ColumnCount = 3
            Me.tlpKpiStat.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.tlpKpiStat.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.tlpKpiStat.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
            Me.tlpKpiStat.Controls.Add(Me.cardKpiRata, 0, 0)
            Me.tlpKpiStat.Controls.Add(Me.cardKpiSelesai, 1, 0)
            Me.tlpKpiStat.Controls.Add(Me.cardKpiTerlama, 2, 0)
            Me.tlpKpiStat.Dock = System.Windows.Forms.DockStyle.Top
            Me.tlpKpiStat.Location = New System.Drawing.Point(18, 18)
            Me.tlpKpiStat.Name = "tlpKpiStat"
            Me.tlpKpiStat.RowCount = 1
            Me.tlpKpiStat.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.tlpKpiStat.Size = New System.Drawing.Size(1116, 128)
            Me.tlpKpiStat.TabIndex = 0
            '
            'cardKpiRata
            '
            Me.cardKpiRata.BackColor = System.Drawing.Color.Transparent
            Me.cardKpiRata.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardKpiRata.BorderRadius = 16
            Me.cardKpiRata.BorderThickness = 1
            Me.cardKpiRata.Controls.Add(Me.lblSubRata)
            Me.cardKpiRata.Controls.Add(Me.lblValRata)
            Me.cardKpiRata.Controls.Add(Me.lblJudulRata)
            Me.cardKpiRata.Controls.Add(Me.icoRata)
            Me.cardKpiRata.Controls.Add(Me.stripRata)
            Me.cardKpiRata.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardKpiRata.FillColor = System.Drawing.Color.White
            Me.cardKpiRata.Location = New System.Drawing.Point(0, 0)
            Me.cardKpiRata.Margin = New System.Windows.Forms.Padding(0, 0, 12, 12)
            Me.cardKpiRata.Name = "cardKpiRata"
            Me.cardKpiRata.Size = New System.Drawing.Size(360, 116)
            Me.cardKpiRata.TabIndex = 0
            Me.cardKpiRata.UseTransparentBackground = True
            '
            'stripRata
            '
            Me.stripRata.BackColor = System.Drawing.Color.Transparent
            Me.stripRata.BorderRadius = 3
            Me.stripRata.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.stripRata.Location = New System.Drawing.Point(16, 16)
            Me.stripRata.Name = "stripRata"
            Me.stripRata.Size = New System.Drawing.Size(4, 20)
            Me.stripRata.TabIndex = 0
            Me.stripRata.UseTransparentBackground = True
            '
            'icoRata
            '
            Me.icoRata.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.icoRata.BackColor = System.Drawing.Color.Transparent
            Me.icoRata.FillColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.icoRata.Location = New System.Drawing.Point(306, 14)
            Me.icoRata.Name = "icoRata"
            Me.icoRata.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.icoRata.Size = New System.Drawing.Size(38, 38)
            Me.icoRata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icoRata.TabIndex = 1
            Me.icoRata.TabStop = False
            Me.icoRata.UseTransparentBackground = True
            '
            'lblJudulRata
            '
            Me.lblJudulRata.BackColor = System.Drawing.Color.Transparent
            Me.lblJudulRata.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudulRata.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblJudulRata.Location = New System.Drawing.Point(26, 16)
            Me.lblJudulRata.Name = "lblJudulRata"
            Me.lblJudulRata.Size = New System.Drawing.Size(268, 22)
            Me.lblJudulRata.TabIndex = 2
            Me.lblJudulRata.Text = "Rata-Rata Persiapan"
            '
            'lblValRata
            '
            Me.lblValRata.BackColor = System.Drawing.Color.Transparent
            Me.lblValRata.Font = New System.Drawing.Font("Georgia", 20.0!, System.Drawing.FontStyle.Bold)
            Me.lblValRata.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblValRata.Location = New System.Drawing.Point(16, 44)
            Me.lblValRata.Name = "lblValRata"
            Me.lblValRata.Size = New System.Drawing.Size(328, 38)
            Me.lblValRata.TabIndex = 3
            Me.lblValRata.Text = "0.0 mnt"
            '
            'lblSubRata
            '
            Me.lblSubRata.BackColor = System.Drawing.Color.Transparent
            Me.lblSubRata.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblSubRata.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSubRata.Location = New System.Drawing.Point(16, 86)
            Me.lblSubRata.Name = "lblSubRata"
            Me.lblSubRata.Size = New System.Drawing.Size(328, 20)
            Me.lblSubRata.TabIndex = 4
            Me.lblSubRata.Text = "Dari pesanan Diproses hingga Siap"
            '
            'cardKpiSelesai
            '
            Me.cardKpiSelesai.BackColor = System.Drawing.Color.Transparent
            Me.cardKpiSelesai.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardKpiSelesai.BorderRadius = 16
            Me.cardKpiSelesai.BorderThickness = 1
            Me.cardKpiSelesai.Controls.Add(Me.lblSubSelesai)
            Me.cardKpiSelesai.Controls.Add(Me.lblValSelesai)
            Me.cardKpiSelesai.Controls.Add(Me.lblJudulSelesai)
            Me.cardKpiSelesai.Controls.Add(Me.icoSelesai)
            Me.cardKpiSelesai.Controls.Add(Me.stripSelesai)
            Me.cardKpiSelesai.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardKpiSelesai.FillColor = System.Drawing.Color.White
            Me.cardKpiSelesai.Location = New System.Drawing.Point(378, 0)
            Me.cardKpiSelesai.Margin = New System.Windows.Forms.Padding(6, 0, 6, 12)
            Me.cardKpiSelesai.Name = "cardKpiSelesai"
            Me.cardKpiSelesai.Size = New System.Drawing.Size(360, 116)
            Me.cardKpiSelesai.TabIndex = 1
            Me.cardKpiSelesai.UseTransparentBackground = True
            '
            'stripSelesai
            '
            Me.stripSelesai.BackColor = System.Drawing.Color.Transparent
            Me.stripSelesai.BorderRadius = 3
            Me.stripSelesai.FillColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.stripSelesai.Location = New System.Drawing.Point(16, 16)
            Me.stripSelesai.Name = "stripSelesai"
            Me.stripSelesai.Size = New System.Drawing.Size(4, 20)
            Me.stripSelesai.TabIndex = 0
            Me.stripSelesai.UseTransparentBackground = True
            '
            'icoSelesai
            '
            Me.icoSelesai.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.icoSelesai.BackColor = System.Drawing.Color.Transparent
            Me.icoSelesai.FillColor = System.Drawing.Color.FromArgb(234, 243, 236)
            Me.icoSelesai.Location = New System.Drawing.Point(306, 14)
            Me.icoSelesai.Name = "icoSelesai"
            Me.icoSelesai.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.icoSelesai.Size = New System.Drawing.Size(38, 38)
            Me.icoSelesai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icoSelesai.TabIndex = 1
            Me.icoSelesai.TabStop = False
            Me.icoSelesai.UseTransparentBackground = True
            '
            'lblJudulSelesai
            '
            Me.lblJudulSelesai.BackColor = System.Drawing.Color.Transparent
            Me.lblJudulSelesai.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudulSelesai.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblJudulSelesai.Location = New System.Drawing.Point(26, 16)
            Me.lblJudulSelesai.Name = "lblJudulSelesai"
            Me.lblJudulSelesai.Size = New System.Drawing.Size(268, 22)
            Me.lblJudulSelesai.TabIndex = 2
            Me.lblJudulSelesai.Text = "Pesanan Siap / Selesai"
            '
            'lblValSelesai
            '
            Me.lblValSelesai.BackColor = System.Drawing.Color.Transparent
            Me.lblValSelesai.Font = New System.Drawing.Font("Georgia", 20.0!, System.Drawing.FontStyle.Bold)
            Me.lblValSelesai.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblValSelesai.Location = New System.Drawing.Point(16, 44)
            Me.lblValSelesai.Name = "lblValSelesai"
            Me.lblValSelesai.Size = New System.Drawing.Size(328, 38)
            Me.lblValSelesai.TabIndex = 3
            Me.lblValSelesai.Text = "0"
            '
            'lblSubSelesai
            '
            Me.lblSubSelesai.BackColor = System.Drawing.Color.Transparent
            Me.lblSubSelesai.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblSubSelesai.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSubSelesai.Location = New System.Drawing.Point(16, 86)
            Me.lblSubSelesai.Name = "lblSubSelesai"
            Me.lblSubSelesai.Size = New System.Drawing.Size(328, 20)
            Me.lblSubSelesai.TabIndex = 4
            Me.lblSubSelesai.Text = "Pesanan selesai diproses hari ini"
            '
            'cardKpiTerlama
            '
            Me.cardKpiTerlama.BackColor = System.Drawing.Color.Transparent
            Me.cardKpiTerlama.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardKpiTerlama.BorderRadius = 16
            Me.cardKpiTerlama.BorderThickness = 1
            Me.cardKpiTerlama.Controls.Add(Me.lblSubTerlama)
            Me.cardKpiTerlama.Controls.Add(Me.lblValTerlama)
            Me.cardKpiTerlama.Controls.Add(Me.lblJudulTerlama)
            Me.cardKpiTerlama.Controls.Add(Me.icoTerlama)
            Me.cardKpiTerlama.Controls.Add(Me.stripTerlama)
            Me.cardKpiTerlama.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardKpiTerlama.FillColor = System.Drawing.Color.White
            Me.cardKpiTerlama.Location = New System.Drawing.Point(756, 0)
            Me.cardKpiTerlama.Margin = New System.Windows.Forms.Padding(12, 0, 0, 12)
            Me.cardKpiTerlama.Name = "cardKpiTerlama"
            Me.cardKpiTerlama.Size = New System.Drawing.Size(360, 116)
            Me.cardKpiTerlama.TabIndex = 2
            Me.cardKpiTerlama.UseTransparentBackground = True
            '
            'stripTerlama
            '
            Me.stripTerlama.BackColor = System.Drawing.Color.Transparent
            Me.stripTerlama.BorderRadius = 3
            Me.stripTerlama.FillColor = System.Drawing.Color.FromArgb(200, 116, 30)
            Me.stripTerlama.Location = New System.Drawing.Point(16, 16)
            Me.stripTerlama.Name = "stripTerlama"
            Me.stripTerlama.Size = New System.Drawing.Size(4, 20)
            Me.stripTerlama.TabIndex = 0
            Me.stripTerlama.UseTransparentBackground = True
            '
            'icoTerlama
            '
            Me.icoTerlama.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.icoTerlama.BackColor = System.Drawing.Color.Transparent
            Me.icoTerlama.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.icoTerlama.Location = New System.Drawing.Point(306, 14)
            Me.icoTerlama.Name = "icoTerlama"
            Me.icoTerlama.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.icoTerlama.Size = New System.Drawing.Size(38, 38)
            Me.icoTerlama.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icoTerlama.TabIndex = 1
            Me.icoTerlama.TabStop = False
            Me.icoTerlama.UseTransparentBackground = True
            '
            'lblJudulTerlama
            '
            Me.lblJudulTerlama.BackColor = System.Drawing.Color.Transparent
            Me.lblJudulTerlama.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudulTerlama.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblJudulTerlama.Location = New System.Drawing.Point(26, 16)
            Me.lblJudulTerlama.Name = "lblJudulTerlama"
            Me.lblJudulTerlama.Size = New System.Drawing.Size(268, 22)
            Me.lblJudulTerlama.TabIndex = 2
            Me.lblJudulTerlama.Text = "Antrian Terlama Aktif"
            '
            'lblValTerlama
            '
            Me.lblValTerlama.BackColor = System.Drawing.Color.Transparent
            Me.lblValTerlama.Font = New System.Drawing.Font("Georgia", 20.0!, System.Drawing.FontStyle.Bold)
            Me.lblValTerlama.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblValTerlama.Location = New System.Drawing.Point(16, 44)
            Me.lblValTerlama.Name = "lblValTerlama"
            Me.lblValTerlama.Size = New System.Drawing.Size(328, 38)
            Me.lblValTerlama.TabIndex = 3
            Me.lblValTerlama.Text = "0.0 mnt"
            '
            'lblSubTerlama
            '
            Me.lblSubTerlama.BackColor = System.Drawing.Color.Transparent
            Me.lblSubTerlama.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblSubTerlama.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSubTerlama.Location = New System.Drawing.Point(16, 86)
            Me.lblSubTerlama.Name = "lblSubTerlama"
            Me.lblSubTerlama.Size = New System.Drawing.Size(328, 20)
            Me.lblSubTerlama.TabIndex = 4
            Me.lblSubTerlama.Text = "Pesanan masih diproses saat ini"
            '
            'cardGrafik
            '
            Me.cardGrafik.BackColor = System.Drawing.Color.Transparent
            Me.cardGrafik.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGrafik.BorderRadius = 16
            Me.cardGrafik.BorderThickness = 1
            Me.cardGrafik.Controls.Add(Me.pnlGrafikHost)
            Me.cardGrafik.Controls.Add(Me.lblGrafTitle)
            Me.cardGrafik.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGrafik.FillColor = System.Drawing.Color.White
            Me.cardGrafik.Location = New System.Drawing.Point(18, 146)
            Me.cardGrafik.Name = "cardGrafik"
            Me.cardGrafik.Padding = New System.Windows.Forms.Padding(18)
            Me.cardGrafik.Size = New System.Drawing.Size(1116, 466)
            Me.cardGrafik.TabIndex = 1
            Me.cardGrafik.UseTransparentBackground = True
            '
            'lblGrafTitle
            '
            Me.lblGrafTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblGrafTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblGrafTitle.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblGrafTitle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblGrafTitle.Location = New System.Drawing.Point(18, 18)
            Me.lblGrafTitle.Name = "lblGrafTitle"
            Me.lblGrafTitle.Size = New System.Drawing.Size(1080, 32)
            Me.lblGrafTitle.TabIndex = 0
            Me.lblGrafTitle.Text = "Distribusi Pesanan Hari Ini per Jam (24 Slot)"
            '
            'pnlGrafikHost
            '
            Me.pnlGrafikHost.BackColor = System.Drawing.Color.White
            Me.pnlGrafikHost.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlGrafikHost.Location = New System.Drawing.Point(18, 50)
            Me.pnlGrafikHost.Name = "pnlGrafikHost"
            Me.pnlGrafikHost.Size = New System.Drawing.Size(1080, 398)
            Me.pnlGrafikHost.TabIndex = 1
            '
            'pnlToast
            '
            Me.pnlToast.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlToast.BackColor = System.Drawing.Color.Transparent
            Me.pnlToast.BorderColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.pnlToast.BorderRadius = 14
            Me.pnlToast.BorderThickness = 1
            Me.pnlToast.Controls.Add(Me.lblToastMsg)
            Me.pnlToast.Controls.Add(Me.picBell)
            Me.pnlToast.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlToast.Location = New System.Drawing.Point(816, 700)
            Me.pnlToast.Name = "pnlToast"
            Me.pnlToast.Size = New System.Drawing.Size(320, 68)
            Me.pnlToast.TabIndex = 1
            Me.pnlToast.UseTransparentBackground = True
            Me.pnlToast.Visible = False
            '
            'picBell
            '
            Me.picBell.BackColor = System.Drawing.Color.Transparent
            Me.picBell.Location = New System.Drawing.Point(16, 18)
            Me.picBell.Name = "picBell"
            Me.picBell.Size = New System.Drawing.Size(32, 32)
            Me.picBell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.picBell.TabIndex = 0
            Me.picBell.TabStop = False
            '
            'lblToastMsg
            '
            Me.lblToastMsg.BackColor = System.Drawing.Color.Transparent
            Me.lblToastMsg.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblToastMsg.ForeColor = System.Drawing.Color.White
            Me.lblToastMsg.Location = New System.Drawing.Point(56, 12)
            Me.lblToastMsg.Name = "lblToastMsg"
            Me.lblToastMsg.Size = New System.Drawing.Size(250, 44)
            Me.lblToastMsg.TabIndex = 1
            Me.lblToastMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'FrmDapur
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1160, 680)
            Me.Controls.Add(Me.pnlToast)
            Me.Controls.Add(Me.tabDapur)
            Me.Name = "FrmDapur"
            Me.Text = "Dapur (KDS) & Statistik Persiapan"
            Me.tabDapur.ResumeLayout(False)
            Me.tpAntrian.ResumeLayout(False)
            Me.cardGrid.ResumeLayout(False)
            CType(Me.dgvDapur, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBar.ResumeLayout(False)
            Me.tpStat.ResumeLayout(False)
            Me.cardGrafik.ResumeLayout(False)
            Me.tlpKpiStat.ResumeLayout(False)
            Me.cardKpiRata.ResumeLayout(False)
            CType(Me.icoRata, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardKpiSelesai.ResumeLayout(False)
            CType(Me.icoSelesai, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardKpiTerlama.ResumeLayout(False)
            CType(Me.icoTerlama, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlToast.ResumeLayout(False)
            CType(Me.picBell, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents tabDapur As Guna.UI2.WinForms.Guna2TabControl
        Friend WithEvents tpAntrian As System.Windows.Forms.TabPage
        Friend WithEvents pnlBar As System.Windows.Forms.Panel
        Friend WithEvents lblF As System.Windows.Forms.Label
        Friend WithEvents cboTampil As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnSiap As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSelesai As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnMute As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSimulasiMasuk As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardGrid As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvDapur As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAntrian As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTipe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRingkas As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTunggu As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tpStat As System.Windows.Forms.TabPage
        Friend WithEvents tlpKpiStat As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents cardKpiRata As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents stripRata As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icoRata As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudulRata As System.Windows.Forms.Label
        Friend WithEvents lblValRata As System.Windows.Forms.Label
        Friend WithEvents lblSubRata As System.Windows.Forms.Label
        Friend WithEvents cardKpiSelesai As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents stripSelesai As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icoSelesai As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudulSelesai As System.Windows.Forms.Label
        Friend WithEvents lblValSelesai As System.Windows.Forms.Label
        Friend WithEvents lblSubSelesai As System.Windows.Forms.Label
        Friend WithEvents cardKpiTerlama As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents stripTerlama As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icoTerlama As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudulTerlama As System.Windows.Forms.Label
        Friend WithEvents lblValTerlama As System.Windows.Forms.Label
        Friend WithEvents lblSubTerlama As System.Windows.Forms.Label
        Friend WithEvents cardGrafik As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblGrafTitle As System.Windows.Forms.Label
        Friend WithEvents pnlGrafikHost As System.Windows.Forms.Panel
        Friend WithEvents pnlToast As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picBell As System.Windows.Forms.PictureBox
        Friend WithEvents lblToastMsg As System.Windows.Forms.Label
    End Class
End Namespace
