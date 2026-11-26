Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Admin

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmLaporan
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
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.components = New System.ComponentModel.Container()
            Me.errLaporan = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnlTop = New System.Windows.Forms.Panel()
            Me.lblDari = New System.Windows.Forms.Label()
            Me.dtpDari = New System.Windows.Forms.DateTimePicker()
            Me.lblSampai = New System.Windows.Forms.Label()
            Me.dtpSampai = New System.Windows.Forms.DateTimePicker()
            Me.cboStatus = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.btnTampil = New Guna.UI2.WinForms.Guna2Button()
            Me.btnEkspor = New Guna.UI2.WinForms.Guna2Button()
            Me.tabLaporan = New Guna.UI2.WinForms.Guna2TabControl()
            Me.tpRiwayat = New System.Windows.Forms.TabPage()
            Me.cardRiwayat = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvRiwayat = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colAntrian = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTipe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMetode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colBayar = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlSum = New System.Windows.Forms.Panel()
            Me.lblJumlah = New System.Windows.Forms.Label()
            Me.lblOmzet = New System.Windows.Forms.Label()
            Me.tpRekap = New System.Windows.Forms.TabPage()
            Me.cardRekap = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvRekap = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.tpTerlaris = New System.Windows.Forms.TabPage()
            Me.cardTerlaris = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvTerlaris = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colTopRank = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTopNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTopQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTopOmzet = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.errLaporan, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlTop.SuspendLayout()
            Me.tabLaporan.SuspendLayout()
            Me.tpRiwayat.SuspendLayout()
            Me.cardRiwayat.SuspendLayout()
            CType(Me.dgvRiwayat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlSum.SuspendLayout()
            Me.tpRekap.SuspendLayout()
            Me.cardRekap.SuspendLayout()
            CType(Me.dgvRekap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpTerlaris.SuspendLayout()
            Me.cardTerlaris.SuspendLayout()
            CType(Me.dgvTerlaris, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'errLaporan
            '
            Me.errLaporan.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            Me.errLaporan.ContainerControl = Me
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.White
            Me.pnlTop.Controls.Add(Me.lblDari)
            Me.pnlTop.Controls.Add(Me.dtpDari)
            Me.pnlTop.Controls.Add(Me.lblSampai)
            Me.pnlTop.Controls.Add(Me.dtpSampai)
            Me.pnlTop.Controls.Add(Me.cboStatus)
            Me.pnlTop.Controls.Add(Me.btnTampil)
            Me.pnlTop.Controls.Add(Me.btnEkspor)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(18, 12, 18, 10)
            Me.pnlTop.Size = New System.Drawing.Size(1160, 64)
            Me.pnlTop.TabIndex = 0
            '
            'lblDari
            '
            Me.lblDari.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblDari.Location = New System.Drawing.Point(18, 20)
            Me.lblDari.Name = "lblDari"
            Me.lblDari.Size = New System.Drawing.Size(52, 24)
            Me.lblDari.TabIndex = 0
            Me.lblDari.Text = "Dari:"
            '
            'dtpDari
            '
            Me.dtpDari.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDari.Location = New System.Drawing.Point(72, 17)
            Me.dtpDari.Name = "dtpDari"
            Me.dtpDari.Size = New System.Drawing.Size(136, 28)
            Me.dtpDari.TabIndex = 1
            '
            'lblSampai
            '
            Me.lblSampai.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblSampai.Location = New System.Drawing.Point(218, 20)
            Me.lblSampai.Name = "lblSampai"
            Me.lblSampai.Size = New System.Drawing.Size(76, 24)
            Me.lblSampai.TabIndex = 2
            Me.lblSampai.Text = "Sampai:"
            '
            'dtpSampai
            '
            Me.dtpSampai.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpSampai.Location = New System.Drawing.Point(298, 17)
            Me.dtpSampai.Name = "dtpSampai"
            Me.dtpSampai.Size = New System.Drawing.Size(136, 28)
            Me.dtpSampai.TabIndex = 3
            '
            'cboStatus
            '
            Me.cboStatus.BackColor = System.Drawing.Color.Transparent
            Me.cboStatus.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboStatus.BorderRadius = 12
            Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboStatus.FillColor = System.Drawing.Color.White
            Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboStatus.ItemHeight = 32
            Me.cboStatus.Location = New System.Drawing.Point(448, 12)
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.Size = New System.Drawing.Size(195, 38)
            Me.cboStatus.TabIndex = 4
            Me.cboStatus.BorderThickness = 1
            '
            'btnTampil
            '
            Me.btnTampil.BackColor = System.Drawing.Color.Transparent
            Me.btnTampil.BorderRadius = 12
            Me.btnTampil.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnTampil.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnTampil.ForeColor = System.Drawing.Color.White
            Me.btnTampil.Location = New System.Drawing.Point(656, 12)
            Me.btnTampil.Name = "btnTampil"
            Me.btnTampil.BorderThickness = 0
            Me.btnTampil.Size = New System.Drawing.Size(124, 38)
            Me.btnTampil.TabIndex = 5
            Me.btnTampil.Text = "Tampilkan"
            Me.btnTampil.UseTransparentBackground = True
            '
            'btnEkspor
            '
            Me.btnEkspor.BackColor = System.Drawing.Color.Transparent
            Me.btnEkspor.BorderRadius = 12
            Me.btnEkspor.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnEkspor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnEkspor.ForeColor = System.Drawing.Color.White
            Me.btnEkspor.Location = New System.Drawing.Point(792, 12)
            Me.btnEkspor.Name = "btnEkspor"
            Me.btnEkspor.BorderThickness = 0
            Me.btnEkspor.Size = New System.Drawing.Size(156, 38)
            Me.btnEkspor.TabIndex = 6
            Me.btnEkspor.Text = "Ekspor CSV"
            Me.btnEkspor.UseTransparentBackground = True
            '
            'tabLaporan
            '
            Me.tabLaporan.Alignment = System.Windows.Forms.TabAlignment.Top
            Me.tabLaporan.Controls.Add(Me.tpRiwayat)
            Me.tabLaporan.Controls.Add(Me.tpRekap)
            Me.tabLaporan.Controls.Add(Me.tpTerlaris)
            Me.tabLaporan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabLaporan.Location = New System.Drawing.Point(0, 64)
            Me.tabLaporan.Name = "tabLaporan"
            Me.tabLaporan.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.tabLaporan.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.tabLaporan.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.tabLaporan.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.tabLaporan.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tabLaporan.SelectedIndex = 0
            Me.tabLaporan.Size = New System.Drawing.Size(1160, 616)
            Me.tabLaporan.TabButtonSize = New System.Drawing.Size(268, 42)
            Me.tabLaporan.ItemSize = New System.Drawing.Size(268, 42)
            Me.tabLaporan.TabIndex = 1
            Me.tabLaporan.TabMenuBackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            '
            'tpRiwayat
            '
            Me.tpRiwayat.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tpRiwayat.Controls.Add(Me.cardRiwayat)
            Me.tpRiwayat.Location = New System.Drawing.Point(4, 46)
            Me.tpRiwayat.Name = "tpRiwayat"
            Me.tpRiwayat.Padding = New System.Windows.Forms.Padding(16)
            Me.tpRiwayat.Size = New System.Drawing.Size(1152, 566)
            Me.tpRiwayat.TabIndex = 0
            Me.tpRiwayat.Text = "Riwayat Transaksi"
            '
            'cardRiwayat
            '
            Me.cardRiwayat.BackColor = System.Drawing.Color.Transparent
            Me.cardRiwayat.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardRiwayat.BorderRadius = 16
            Me.cardRiwayat.BorderThickness = 1
            Me.cardRiwayat.Controls.Add(Me.dgvRiwayat)
            Me.cardRiwayat.Controls.Add(Me.pnlSum)
            Me.cardRiwayat.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardRiwayat.FillColor = System.Drawing.Color.White
            Me.cardRiwayat.Location = New System.Drawing.Point(16, 16)
            Me.cardRiwayat.Name = "cardRiwayat"
            Me.cardRiwayat.Padding = New System.Windows.Forms.Padding(12)
            Me.cardRiwayat.Size = New System.Drawing.Size(1120, 534)
            Me.cardRiwayat.TabIndex = 0
            Me.cardRiwayat.UseTransparentBackground = True
            '
            'dgvRiwayat
            '
            Me.dgvRiwayat.AllowUserToAddRows = False
            Me.dgvRiwayat.AllowUserToDeleteRows = False
            Me.dgvRiwayat.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvRiwayat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvRiwayat.AutoGenerateColumns = False
            Me.dgvRiwayat.BackgroundColor = System.Drawing.Color.White
            Me.dgvRiwayat.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvRiwayat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvRiwayat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvRiwayat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvRiwayat.ColumnHeadersHeight = 42
            Me.dgvRiwayat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvRiwayat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAntrian, Me.colTanggal, Me.colTipe, Me.colMetode, Me.colBayar, Me.colStatus, Me.colTotal})
            Me.dgvRiwayat.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvRiwayat.EnableHeadersVisualStyles = False
            Me.dgvRiwayat.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvRiwayat.Location = New System.Drawing.Point(12, 12)
            Me.dgvRiwayat.MultiSelect = False
            Me.dgvRiwayat.Name = "dgvRiwayat"
            Me.dgvRiwayat.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRiwayat.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvRiwayat.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRiwayat.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvRiwayat.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvRiwayat.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRiwayat.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvRiwayat.ThemeStyle.RowsStyle.Height = 40
            Me.dgvRiwayat.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRiwayat.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvRiwayat.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvRiwayat.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvRiwayat.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRiwayat.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvRiwayat.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvRiwayat.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvRiwayat.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvRiwayat.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvRiwayat.ReadOnly = True
            Me.dgvRiwayat.RowHeadersVisible = False
            Me.dgvRiwayat.RowTemplate.Height = 40
            Me.dgvRiwayat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvRiwayat.Size = New System.Drawing.Size(1096, 466)
            Me.dgvRiwayat.TabIndex = 0
            '
            'colAntrian
            '
            Me.colAntrian.DataPropertyName = "no_antrian"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle3.Format = "000"
            Me.colAntrian.DefaultCellStyle = DataGridViewCellStyle3
            Me.colAntrian.HeaderText = "Antrian"
            Me.colAntrian.Name = "colAntrian"
            Me.colAntrian.ReadOnly = True
            Me.colAntrian.Width = 88
            '
            'colTanggal
            '
            Me.colTanggal.DataPropertyName = "tanggal"
            DataGridViewCellStyle4.Format = "dd MMM yyyy HH:mm"
            Me.colTanggal.DefaultCellStyle = DataGridViewCellStyle4
            Me.colTanggal.HeaderText = "Tanggal"
            Me.colTanggal.Name = "colTanggal"
            Me.colTanggal.ReadOnly = True
            Me.colTanggal.Width = 158
            '
            'colTipe
            '
            Me.colTipe.DataPropertyName = "tipe_makan"
            Me.colTipe.HeaderText = "Tipe"
            Me.colTipe.Name = "colTipe"
            Me.colTipe.ReadOnly = True
            Me.colTipe.Width = 96
            '
            'colMetode
            '
            Me.colMetode.DataPropertyName = "metode_bayar"
            Me.colMetode.HeaderText = "Metode"
            Me.colMetode.Name = "colMetode"
            Me.colMetode.ReadOnly = True
            Me.colMetode.Width = 94
            '
            'colBayar
            '
            Me.colBayar.DataPropertyName = "status_bayar"
            Me.colBayar.HeaderText = "Bayar"
            Me.colBayar.Name = "colBayar"
            Me.colBayar.ReadOnly = True
            Me.colBayar.Width = 78
            '
            'colStatus
            '
            Me.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colStatus.DataPropertyName = "status_pesanan"
            Me.colStatus.HeaderText = "Status"
            Me.colStatus.MinimumWidth = 160
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            '
            'colTotal
            '
            Me.colTotal.DataPropertyName = "total"
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle5.Format = "C0"
            Me.colTotal.DefaultCellStyle = DataGridViewCellStyle5
            Me.colTotal.HeaderText = "Total"
            Me.colTotal.Name = "colTotal"
            Me.colTotal.ReadOnly = True
            Me.colTotal.Width = 128
            '
            'pnlSum
            '
            Me.pnlSum.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.pnlSum.Controls.Add(Me.lblJumlah)
            Me.pnlSum.Controls.Add(Me.lblOmzet)
            Me.pnlSum.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlSum.Location = New System.Drawing.Point(12, 478)
            Me.pnlSum.Name = "pnlSum"
            Me.pnlSum.Padding = New System.Windows.Forms.Padding(14, 10, 14, 10)
            Me.pnlSum.Size = New System.Drawing.Size(1096, 44)
            Me.pnlSum.TabIndex = 1
            '
            'lblJumlah
            '
            Me.lblJumlah.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblJumlah.Location = New System.Drawing.Point(14, 10)
            Me.lblJumlah.Name = "lblJumlah"
            Me.lblJumlah.Size = New System.Drawing.Size(300, 24)
            Me.lblJumlah.TabIndex = 0
            Me.lblJumlah.Text = "Jumlah Transaksi: 0"
            '
            'lblOmzet
            '
            Me.lblOmzet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblOmzet.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblOmzet.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblOmzet.Location = New System.Drawing.Point(658, 10)
            Me.lblOmzet.Name = "lblOmzet"
            Me.lblOmzet.Size = New System.Drawing.Size(420, 24)
            Me.lblOmzet.TabIndex = 1
            Me.lblOmzet.Text = "Total Omzet Sah: Rp0"
            Me.lblOmzet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tpRekap
            '
            Me.tpRekap.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tpRekap.Controls.Add(Me.cardRekap)
            Me.tpRekap.Location = New System.Drawing.Point(4, 46)
            Me.tpRekap.Name = "tpRekap"
            Me.tpRekap.Padding = New System.Windows.Forms.Padding(16)
            Me.tpRekap.Size = New System.Drawing.Size(1152, 566)
            Me.tpRekap.TabIndex = 1
            Me.tpRekap.Text = "Rekap Kategori x Hari (2D)"
            '
            'cardRekap
            '
            Me.cardRekap.BackColor = System.Drawing.Color.Transparent
            Me.cardRekap.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardRekap.BorderRadius = 16
            Me.cardRekap.BorderThickness = 1
            Me.cardRekap.Controls.Add(Me.dgvRekap)
            Me.cardRekap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardRekap.FillColor = System.Drawing.Color.White
            Me.cardRekap.Location = New System.Drawing.Point(16, 16)
            Me.cardRekap.Name = "cardRekap"
            Me.cardRekap.Padding = New System.Windows.Forms.Padding(12)
            Me.cardRekap.Size = New System.Drawing.Size(1120, 534)
            Me.cardRekap.TabIndex = 0
            Me.cardRekap.UseTransparentBackground = True
            '
            'dgvRekap
            '
            Me.dgvRekap.AllowUserToAddRows = False
            Me.dgvRekap.AllowUserToDeleteRows = False
            Me.dgvRekap.AllowUserToResizeRows = False
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvRekap.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
            Me.dgvRekap.BackgroundColor = System.Drawing.Color.White
            Me.dgvRekap.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvRekap.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvRekap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvRekap.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
            Me.dgvRekap.ColumnHeadersHeight = 42
            Me.dgvRekap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvRekap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvRekap.EnableHeadersVisualStyles = False
            Me.dgvRekap.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvRekap.Location = New System.Drawing.Point(12, 12)
            Me.dgvRekap.MultiSelect = False
            Me.dgvRekap.Name = "dgvRekap"
            Me.dgvRekap.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRekap.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvRekap.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRekap.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvRekap.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvRekap.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRekap.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvRekap.ThemeStyle.RowsStyle.Height = 40
            Me.dgvRekap.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRekap.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvRekap.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvRekap.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvRekap.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvRekap.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvRekap.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvRekap.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvRekap.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvRekap.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvRekap.ReadOnly = True
            Me.dgvRekap.RowHeadersVisible = False
            Me.dgvRekap.RowTemplate.Height = 40
            Me.dgvRekap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvRekap.Size = New System.Drawing.Size(1096, 510)
            Me.dgvRekap.TabIndex = 0
            '
            'tpTerlaris
            '
            Me.tpTerlaris.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tpTerlaris.Controls.Add(Me.cardTerlaris)
            Me.tpTerlaris.Location = New System.Drawing.Point(4, 46)
            Me.tpTerlaris.Name = "tpTerlaris"
            Me.tpTerlaris.Padding = New System.Windows.Forms.Padding(16)
            Me.tpTerlaris.Size = New System.Drawing.Size(1152, 566)
            Me.tpTerlaris.TabIndex = 2
            Me.tpTerlaris.Text = "Menu Terlaris (Top 10)"
            '
            'cardTerlaris
            '
            Me.cardTerlaris.BackColor = System.Drawing.Color.Transparent
            Me.cardTerlaris.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardTerlaris.BorderRadius = 16
            Me.cardTerlaris.BorderThickness = 1
            Me.cardTerlaris.Controls.Add(Me.dgvTerlaris)
            Me.cardTerlaris.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardTerlaris.FillColor = System.Drawing.Color.White
            Me.cardTerlaris.Location = New System.Drawing.Point(16, 16)
            Me.cardTerlaris.Name = "cardTerlaris"
            Me.cardTerlaris.Padding = New System.Windows.Forms.Padding(12)
            Me.cardTerlaris.Size = New System.Drawing.Size(1120, 534)
            Me.cardTerlaris.TabIndex = 0
            Me.cardTerlaris.UseTransparentBackground = True
            '
            'dgvTerlaris
            '
            Me.dgvTerlaris.AllowUserToAddRows = False
            Me.dgvTerlaris.AllowUserToDeleteRows = False
            Me.dgvTerlaris.AllowUserToResizeRows = False
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvTerlaris.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
            Me.dgvTerlaris.AutoGenerateColumns = False
            Me.dgvTerlaris.BackgroundColor = System.Drawing.Color.White
            Me.dgvTerlaris.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvTerlaris.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvTerlaris.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvTerlaris.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
            Me.dgvTerlaris.ColumnHeadersHeight = 42
            Me.dgvTerlaris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvTerlaris.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTopRank, Me.colTopNama, Me.colTopQty, Me.colTopOmzet})
            Me.dgvTerlaris.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvTerlaris.EnableHeadersVisualStyles = False
            Me.dgvTerlaris.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvTerlaris.Location = New System.Drawing.Point(12, 12)
            Me.dgvTerlaris.MultiSelect = False
            Me.dgvTerlaris.Name = "dgvTerlaris"
            Me.dgvTerlaris.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTerlaris.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvTerlaris.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTerlaris.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvTerlaris.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvTerlaris.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTerlaris.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvTerlaris.ThemeStyle.RowsStyle.Height = 40
            Me.dgvTerlaris.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTerlaris.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvTerlaris.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvTerlaris.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvTerlaris.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTerlaris.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvTerlaris.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvTerlaris.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvTerlaris.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvTerlaris.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvTerlaris.ReadOnly = True
            Me.dgvTerlaris.RowHeadersVisible = False
            Me.dgvTerlaris.RowTemplate.Height = 40
            Me.dgvTerlaris.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvTerlaris.Size = New System.Drawing.Size(1096, 510)
            Me.dgvTerlaris.TabIndex = 0
            '
            'colTopRank
            '
            Me.colTopRank.DataPropertyName = "peringkat"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.colTopRank.DefaultCellStyle = DataGridViewCellStyle10
            Me.colTopRank.HeaderText = "Peringkat"
            Me.colTopRank.Name = "colTopRank"
            Me.colTopRank.ReadOnly = True
            Me.colTopRank.Width = 90
            '
            'colTopNama
            '
            Me.colTopNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colTopNama.DataPropertyName = "nama_produk"
            Me.colTopNama.HeaderText = "Nama Menu"
            Me.colTopNama.Name = "colTopNama"
            Me.colTopNama.ReadOnly = True
            '
            'colTopQty
            '
            Me.colTopQty.DataPropertyName = "total_qty"
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.colTopQty.DefaultCellStyle = DataGridViewCellStyle11
            Me.colTopQty.HeaderText = "Total Terjual"
            Me.colTopQty.Name = "colTopQty"
            Me.colTopQty.ReadOnly = True
            Me.colTopQty.Width = 120
            '
            'colTopOmzet
            '
            Me.colTopOmzet.DataPropertyName = "total_omzet"
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle12.Format = "C0"
            Me.colTopOmzet.DefaultCellStyle = DataGridViewCellStyle12
            Me.colTopOmzet.HeaderText = "Total Omzet"
            Me.colTopOmzet.Name = "colTopOmzet"
            Me.colTopOmzet.ReadOnly = True
            Me.colTopOmzet.Width = 160
            '
            'FrmLaporan
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1160, 680)
            Me.Controls.Add(Me.tabLaporan)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.Name = "FrmLaporan"
            Me.Text = "Laporan Penjualan & Rekapitulasi"
            CType(Me.errLaporan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlTop.ResumeLayout(False)
            Me.tabLaporan.ResumeLayout(False)
            Me.tpRiwayat.ResumeLayout(False)
            Me.cardRiwayat.ResumeLayout(False)
            CType(Me.dgvRiwayat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlSum.ResumeLayout(False)
            Me.tpRekap.ResumeLayout(False)
            Me.cardRekap.ResumeLayout(False)
            CType(Me.dgvRekap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpTerlaris.ResumeLayout(False)
            Me.cardTerlaris.ResumeLayout(False)
            CType(Me.dgvTerlaris, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents errLaporan As System.Windows.Forms.ErrorProvider
        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents lblDari As System.Windows.Forms.Label
        Friend WithEvents dtpDari As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblSampai As System.Windows.Forms.Label
        Friend WithEvents dtpSampai As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboStatus As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnTampil As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnEkspor As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents tabLaporan As Guna.UI2.WinForms.Guna2TabControl
        Friend WithEvents tpRiwayat As System.Windows.Forms.TabPage
        Friend WithEvents cardRiwayat As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvRiwayat As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colAntrian As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTanggal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTipe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMetode As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colBayar As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnlSum As System.Windows.Forms.Panel
        Friend WithEvents lblJumlah As System.Windows.Forms.Label
        Friend WithEvents lblOmzet As System.Windows.Forms.Label
        Friend WithEvents tpRekap As System.Windows.Forms.TabPage
        Friend WithEvents cardRekap As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvRekap As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents tpTerlaris As System.Windows.Forms.TabPage
        Friend WithEvents cardTerlaris As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvTerlaris As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colTopRank As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTopNama As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTopQty As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTopOmzet As System.Windows.Forms.DataGridViewTextBoxColumn

    End Class
End Namespace
