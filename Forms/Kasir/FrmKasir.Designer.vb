Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kasir

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmKasir
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
            Me.pnlTop = New System.Windows.Forms.Panel()
            Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
            Me.txtCariAntrian = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cboStatus = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblSt = New System.Windows.Forms.Label()
            Me.pnlRight = New System.Windows.Forms.Panel()
            Me.cardDetail = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnCetakUlang = New Guna.UI2.WinForms.Guna2Button()
            Me.btnBatalkan = New Guna.UI2.WinForms.Guna2Button()
            Me.btnKonfirmasiTunai = New Guna.UI2.WinForms.Guna2Button()
            Me.lstPecahan = New System.Windows.Forms.ListBox()
            Me.lblKembalian = New System.Windows.Forms.Label()
            Me.txtUangBayar = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblBayarCap = New System.Windows.Forms.Label()
            Me.lblTotal = New System.Windows.Forms.Label()
            Me.lblTotCap = New System.Windows.Forms.Label()
            Me.dgvDetail = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colSubtotalDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblInfoPesanan = New System.Windows.Forms.Label()
            Me.pnlLeft = New System.Windows.Forms.Panel()
            Me.cardGrid = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvPesanan = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAntrian = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTipe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMetode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colBayar = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colWaktu = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlRight.SuspendLayout()
            Me.cardDetail.SuspendLayout()
            CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlLeft.SuspendLayout()
            Me.cardGrid.SuspendLayout()
            CType(Me.dgvPesanan, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.White
            Me.pnlTop.Controls.Add(Me.btnRefresh)
            Me.pnlTop.Controls.Add(Me.txtCariAntrian)
            Me.pnlTop.Controls.Add(Me.cboStatus)
            Me.pnlTop.Controls.Add(Me.lblSt)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(18, 12, 18, 10)
            Me.pnlTop.Size = New System.Drawing.Size(1160, 64)
            Me.pnlTop.TabIndex = 0
            '
            'lblSt
            '
            Me.lblSt.BackColor = System.Drawing.Color.Transparent
            Me.lblSt.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblSt.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblSt.Location = New System.Drawing.Point(18, 20)
            Me.lblSt.Name = "lblSt"
            Me.lblSt.Size = New System.Drawing.Size(60, 24)
            Me.lblSt.TabIndex = 0
            Me.lblSt.Text = "Status:"
            '
            'cboStatus
            '
            Me.cboStatus.BackColor = System.Drawing.Color.Transparent
            Me.cboStatus.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboStatus.BorderRadius = 12
            Me.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboStatus.FillColor = System.Drawing.Color.White
            Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cboStatus.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.cboStatus.ItemHeight = 30
            Me.cboStatus.Location = New System.Drawing.Point(82, 13)
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.Size = New System.Drawing.Size(220, 36)
            Me.cboStatus.TabIndex = 1
            Me.cboStatus.BorderThickness = 1
            '
            'txtCariAntrian
            '
            Me.txtCariAntrian.BackColor = System.Drawing.Color.Transparent
            Me.txtCariAntrian.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtCariAntrian.BorderRadius = 12
            Me.txtCariAntrian.FillColor = System.Drawing.Color.White
            Me.txtCariAntrian.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtCariAntrian.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtCariAntrian.Location = New System.Drawing.Point(316, 13)
            Me.txtCariAntrian.Name = "txtCariAntrian"
            Me.txtCariAntrian.PlaceholderText = "Cari no. antrian (contoh: 7)..."
            Me.txtCariAntrian.Size = New System.Drawing.Size(230, 38)
            Me.txtCariAntrian.TabIndex = 2
            Me.txtCariAntrian.BorderThickness = 1
            '
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
            Me.btnRefresh.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnRefresh.BorderRadius = 12
            Me.btnRefresh.BorderThickness = 1
            Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnRefresh.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnRefresh.Location = New System.Drawing.Point(560, 13)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(130, 38)
            Me.btnRefresh.TabIndex = 3
            Me.btnRefresh.Text = "Refresh"
            Me.btnRefresh.UseTransparentBackground = True
            '
            'pnlRight
            '
            Me.pnlRight.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlRight.Controls.Add(Me.cardDetail)
            Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlRight.Location = New System.Drawing.Point(740, 64)
            Me.pnlRight.Name = "pnlRight"
            Me.pnlRight.Padding = New System.Windows.Forms.Padding(6, 14, 18, 18)
            Me.pnlRight.Size = New System.Drawing.Size(420, 616)
            Me.pnlRight.TabIndex = 1
            '
            'cardDetail
            '
            Me.cardDetail.BackColor = System.Drawing.Color.Transparent
            Me.cardDetail.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardDetail.BorderRadius = 16
            Me.cardDetail.BorderThickness = 1
            Me.cardDetail.Controls.Add(Me.btnCetakUlang)
            Me.cardDetail.Controls.Add(Me.btnBatalkan)
            Me.cardDetail.Controls.Add(Me.btnKonfirmasiTunai)
            Me.cardDetail.Controls.Add(Me.lstPecahan)
            Me.cardDetail.Controls.Add(Me.lblKembalian)
            Me.cardDetail.Controls.Add(Me.txtUangBayar)
            Me.cardDetail.Controls.Add(Me.lblBayarCap)
            Me.cardDetail.Controls.Add(Me.lblTotal)
            Me.cardDetail.Controls.Add(Me.lblTotCap)
            Me.cardDetail.Controls.Add(Me.dgvDetail)
            Me.cardDetail.Controls.Add(Me.lblInfoPesanan)
            Me.cardDetail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardDetail.FillColor = System.Drawing.Color.White
            Me.cardDetail.Location = New System.Drawing.Point(6, 14)
            Me.cardDetail.Name = "cardDetail"
            Me.cardDetail.Padding = New System.Windows.Forms.Padding(16)
            Me.cardDetail.Size = New System.Drawing.Size(396, 584)
            Me.cardDetail.TabIndex = 0
            Me.cardDetail.UseTransparentBackground = True
            '
            'lblInfoPesanan
            '
            Me.lblInfoPesanan.BackColor = System.Drawing.Color.Transparent
            Me.lblInfoPesanan.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblInfoPesanan.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblInfoPesanan.Location = New System.Drawing.Point(16, 14)
            Me.lblInfoPesanan.Name = "lblInfoPesanan"
            Me.lblInfoPesanan.Size = New System.Drawing.Size(364, 28)
            Me.lblInfoPesanan.TabIndex = 0
            Me.lblInfoPesanan.Text = "Pilih pesanan di daftar"
            '
            'dgvDetail
            '
            Me.dgvDetail.AllowUserToAddRows = False
            Me.dgvDetail.AllowUserToDeleteRows = False
            Me.dgvDetail.AutoGenerateColumns = False
            Me.dgvDetail.BackgroundColor = System.Drawing.Color.White
            Me.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvDetail.ColumnHeadersHeight = 34
            Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colQty, Me.colItem, Me.colSubtotalDetail})
            Me.dgvDetail.Location = New System.Drawing.Point(16, 44)
            Me.dgvDetail.Name = "dgvDetail"
            Me.dgvDetail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDetail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvDetail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDetail.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvDetail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvDetail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDetail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvDetail.ThemeStyle.RowsStyle.Height = 40
            Me.dgvDetail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDetail.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvDetail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvDetail.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvDetail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvDetail.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvDetail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvDetail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvDetail.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvDetail.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvDetail.ReadOnly = True
            Me.dgvDetail.RowHeadersVisible = False
            Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDetail.Size = New System.Drawing.Size(364, 112)
            Me.dgvDetail.TabIndex = 1
            Me.dgvDetail.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light
            '
            'colQty
            '
            Me.colQty.DataPropertyName = "qty"
            Me.colQty.HeaderText = "Qty"
            Me.colQty.Name = "colQty"
            Me.colQty.ReadOnly = True
            Me.colQty.Width = 44
            '
            'colItem
            '
            Me.colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colItem.DataPropertyName = "nama_produk"
            Me.colItem.HeaderText = "Item"
            Me.colItem.Name = "colItem"
            Me.colItem.ReadOnly = True
            '
            'colSubtotalDetail
            '
            Me.colSubtotalDetail.DataPropertyName = "subtotal"
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle1.Format = "C0"
            Me.colSubtotalDetail.DefaultCellStyle = DataGridViewCellStyle1
            Me.colSubtotalDetail.HeaderText = "Subtotal"
            Me.colSubtotalDetail.Name = "colSubtotalDetail"
            Me.colSubtotalDetail.ReadOnly = True
            Me.colSubtotalDetail.Width = 104
            '
            'lblTotCap
            '
            Me.lblTotCap.BackColor = System.Drawing.Color.Transparent
            Me.lblTotCap.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblTotCap.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblTotCap.Location = New System.Drawing.Point(16, 162)
            Me.lblTotCap.Name = "lblTotCap"
            Me.lblTotCap.Size = New System.Drawing.Size(130, 26)
            Me.lblTotCap.TabIndex = 2
            Me.lblTotCap.Text = "Total Tagihan:"
            '
            'lblTotal
            '
            Me.lblTotal.BackColor = System.Drawing.Color.Transparent
            Me.lblTotal.Font = New System.Drawing.Font("Georgia", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblTotal.Location = New System.Drawing.Point(150, 158)
            Me.lblTotal.Name = "lblTotal"
            Me.lblTotal.Size = New System.Drawing.Size(230, 32)
            Me.lblTotal.TabIndex = 3
            Me.lblTotal.Text = "Rp0"
            Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBayarCap
            '
            Me.lblBayarCap.BackColor = System.Drawing.Color.Transparent
            Me.lblBayarCap.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblBayarCap.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblBayarCap.Location = New System.Drawing.Point(16, 196)
            Me.lblBayarCap.Name = "lblBayarCap"
            Me.lblBayarCap.Size = New System.Drawing.Size(200, 20)
            Me.lblBayarCap.TabIndex = 4
            Me.lblBayarCap.Text = "Uang Tunai Diterima:"
            '
            'txtUangBayar
            '
            Me.txtUangBayar.BackColor = System.Drawing.Color.Transparent
            Me.txtUangBayar.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtUangBayar.BorderRadius = 12
            Me.txtUangBayar.FillColor = System.Drawing.Color.White
            Me.txtUangBayar.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtUangBayar.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtUangBayar.Location = New System.Drawing.Point(16, 218)
            Me.txtUangBayar.Name = "txtUangBayar"
            Me.txtUangBayar.PlaceholderText = "Nominal uang tunai..."
            Me.txtUangBayar.Size = New System.Drawing.Size(364, 34)
            Me.txtUangBayar.TabIndex = 5
            Me.txtUangBayar.BorderThickness = 1
            '
            'lblKembalian
            '
            Me.lblKembalian.BackColor = System.Drawing.Color.Transparent
            Me.lblKembalian.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblKembalian.ForeColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.lblKembalian.Location = New System.Drawing.Point(16, 258)
            Me.lblKembalian.Name = "lblKembalian"
            Me.lblKembalian.Size = New System.Drawing.Size(364, 22)
            Me.lblKembalian.TabIndex = 6
            Me.lblKembalian.Text = "Kembalian: -"
            '
            'lstPecahan
            '
            Me.lstPecahan.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.lstPecahan.Font = New System.Drawing.Font("Consolas", 9.5!)
            Me.lstPecahan.FormattingEnabled = True
            Me.lstPecahan.ItemHeight = 15
            Me.lstPecahan.Location = New System.Drawing.Point(16, 282)
            Me.lstPecahan.Name = "lstPecahan"
            Me.lstPecahan.Size = New System.Drawing.Size(364, 54)
            Me.lstPecahan.TabIndex = 7
            '
            'btnKonfirmasiTunai
            '
            Me.btnKonfirmasiTunai.BackColor = System.Drawing.Color.Transparent
            Me.btnKonfirmasiTunai.BorderRadius = 12
            Me.btnKonfirmasiTunai.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKonfirmasiTunai.FillColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.btnKonfirmasiTunai.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnKonfirmasiTunai.ForeColor = System.Drawing.Color.White
            Me.btnKonfirmasiTunai.ImageOffset = New System.Drawing.Point(-6, 0)
            Me.btnKonfirmasiTunai.Location = New System.Drawing.Point(16, 344)
            Me.btnKonfirmasiTunai.Name = "btnKonfirmasiTunai"
            Me.btnKonfirmasiTunai.BorderThickness = 0
            Me.btnKonfirmasiTunai.Size = New System.Drawing.Size(364, 42)
            Me.btnKonfirmasiTunai.TabIndex = 8
            Me.btnKonfirmasiTunai.Text = "Konfirmasi Bayar Tunai"
            Me.btnKonfirmasiTunai.UseTransparentBackground = True
            '
            'btnBatalkan
            '
            Me.btnBatalkan.BackColor = System.Drawing.Color.Transparent
            Me.btnBatalkan.BorderColor = System.Drawing.Color.FromArgb(234, 181, 176)
            Me.btnBatalkan.BorderRadius = 12
            Me.btnBatalkan.BorderThickness = 1
            Me.btnBatalkan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBatalkan.FillColor = System.Drawing.Color.FromArgb(253, 236, 236)
            Me.btnBatalkan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnBatalkan.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnBatalkan.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnBatalkan.Location = New System.Drawing.Point(16, 394)
            Me.btnBatalkan.Name = "btnBatalkan"
            Me.btnBatalkan.Size = New System.Drawing.Size(176, 40)
            Me.btnBatalkan.TabIndex = 9
            Me.btnBatalkan.Text = "Batalkan"
            Me.btnBatalkan.UseTransparentBackground = True
            '
            'btnCetakUlang
            '
            Me.btnCetakUlang.BackColor = System.Drawing.Color.Transparent
            Me.btnCetakUlang.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnCetakUlang.BorderRadius = 12
            Me.btnCetakUlang.BorderThickness = 1
            Me.btnCetakUlang.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCetakUlang.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnCetakUlang.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnCetakUlang.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnCetakUlang.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnCetakUlang.Location = New System.Drawing.Point(204, 394)
            Me.btnCetakUlang.Name = "btnCetakUlang"
            Me.btnCetakUlang.Size = New System.Drawing.Size(176, 40)
            Me.btnCetakUlang.TabIndex = 10
            Me.btnCetakUlang.Text = "Cetak Ulang"
            Me.btnCetakUlang.UseTransparentBackground = True
            '
            'pnlLeft
            '
            Me.pnlLeft.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlLeft.Controls.Add(Me.cardGrid)
            Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlLeft.Location = New System.Drawing.Point(0, 64)
            Me.pnlLeft.Name = "pnlLeft"
            Me.pnlLeft.Padding = New System.Windows.Forms.Padding(18, 14, 10, 18)
            Me.pnlLeft.Size = New System.Drawing.Size(740, 616)
            Me.pnlLeft.TabIndex = 2
            '
            'cardGrid
            '
            Me.cardGrid.BackColor = System.Drawing.Color.Transparent
            Me.cardGrid.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGrid.BorderRadius = 16
            Me.cardGrid.BorderThickness = 1
            Me.cardGrid.Controls.Add(Me.dgvPesanan)
            Me.cardGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGrid.FillColor = System.Drawing.Color.White
            Me.cardGrid.Location = New System.Drawing.Point(18, 14)
            Me.cardGrid.Name = "cardGrid"
            Me.cardGrid.Padding = New System.Windows.Forms.Padding(12)
            Me.cardGrid.Size = New System.Drawing.Size(712, 584)
            Me.cardGrid.TabIndex = 0
            Me.cardGrid.UseTransparentBackground = True
            '
            'dgvPesanan
            '
            Me.dgvPesanan.AllowUserToAddRows = False
            Me.dgvPesanan.AllowUserToDeleteRows = False
            Me.dgvPesanan.AutoGenerateColumns = False
            Me.dgvPesanan.BackgroundColor = System.Drawing.Color.White
            Me.dgvPesanan.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvPesanan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvPesanan.ColumnHeadersHeight = 40
            Me.dgvPesanan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colAntrian, Me.colTipe, Me.colTotal, Me.colMetode, Me.colBayar, Me.colStatus, Me.colWaktu})
            Me.dgvPesanan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvPesanan.Location = New System.Drawing.Point(12, 12)
            Me.dgvPesanan.MultiSelect = False
            Me.dgvPesanan.Name = "dgvPesanan"
            Me.dgvPesanan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPesanan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvPesanan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPesanan.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvPesanan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvPesanan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPesanan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvPesanan.ThemeStyle.RowsStyle.Height = 40
            Me.dgvPesanan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPesanan.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvPesanan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvPesanan.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvPesanan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPesanan.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvPesanan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvPesanan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvPesanan.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvPesanan.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvPesanan.ReadOnly = True
            Me.dgvPesanan.RowHeadersVisible = False
            Me.dgvPesanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvPesanan.Size = New System.Drawing.Size(688, 560)
            Me.dgvPesanan.TabIndex = 0
            Me.dgvPesanan.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light
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
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.Format = "000"
            Me.colAntrian.DefaultCellStyle = DataGridViewCellStyle2
            Me.colAntrian.HeaderText = "Antrian"
            Me.colAntrian.Name = "colAntrian"
            Me.colAntrian.ReadOnly = True
            Me.colAntrian.Width = 76
            '
            'colTipe
            '
            Me.colTipe.DataPropertyName = "tipe_makan"
            Me.colTipe.HeaderText = "Tipe"
            Me.colTipe.Name = "colTipe"
            Me.colTipe.ReadOnly = True
            Me.colTipe.Width = 88
            '
            'colTotal
            '
            Me.colTotal.DataPropertyName = "total"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "C0"
            Me.colTotal.DefaultCellStyle = DataGridViewCellStyle3
            Me.colTotal.HeaderText = "Total"
            Me.colTotal.Name = "colTotal"
            Me.colTotal.ReadOnly = True
            Me.colTotal.Width = 100
            '
            'colMetode
            '
            Me.colMetode.DataPropertyName = "metode_bayar"
            Me.colMetode.HeaderText = "Metode"
            Me.colMetode.Name = "colMetode"
            Me.colMetode.ReadOnly = True
            Me.colMetode.Width = 78
            '
            'colBayar
            '
            Me.colBayar.DataPropertyName = "status_bayar"
            Me.colBayar.HeaderText = "Bayar"
            Me.colBayar.Name = "colBayar"
            Me.colBayar.ReadOnly = True
            Me.colBayar.Width = 68
            '
            'colStatus
            '
            Me.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colStatus.DataPropertyName = "status_pesanan"
            Me.colStatus.HeaderText = "Status"
            Me.colStatus.MinimumWidth = 120
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            '
            'colWaktu
            '
            Me.colWaktu.DataPropertyName = "tanggal"
            DataGridViewCellStyle4.Format = "HH:mm"
            Me.colWaktu.DefaultCellStyle = DataGridViewCellStyle4
            Me.colWaktu.HeaderText = "Waktu"
            Me.colWaktu.Name = "colWaktu"
            Me.colWaktu.ReadOnly = True
            Me.colWaktu.Width = 72
            '
            'FrmKasir
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1160, 680)
            Me.Controls.Add(Me.pnlLeft)
            Me.Controls.Add(Me.pnlRight)
            Me.Controls.Add(Me.pnlTop)
            Me.Name = "FrmKasir"
            Me.Text = "Kasir — Pembayaran & Konfirmasi Pesanan"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlRight.ResumeLayout(False)
            Me.cardDetail.ResumeLayout(False)
            CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlLeft.ResumeLayout(False)
            Me.cardGrid.ResumeLayout(False)
            CType(Me.dgvPesanan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents lblSt As System.Windows.Forms.Label
        Friend WithEvents cboStatus As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents txtCariAntrian As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlRight As System.Windows.Forms.Panel
        Friend WithEvents cardDetail As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblInfoPesanan As System.Windows.Forms.Label
        Friend WithEvents dgvDetail As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colItem As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colSubtotalDetail As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents lblTotCap As System.Windows.Forms.Label
        Friend WithEvents lblTotal As System.Windows.Forms.Label
        Friend WithEvents lblBayarCap As System.Windows.Forms.Label
        Friend WithEvents txtUangBayar As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblKembalian As System.Windows.Forms.Label
        Friend WithEvents lstPecahan As System.Windows.Forms.ListBox
        Friend WithEvents btnKonfirmasiTunai As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnBatalkan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnCetakUlang As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlLeft As System.Windows.Forms.Panel
        Friend WithEvents cardGrid As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvPesanan As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAntrian As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTipe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMetode As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colBayar As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colWaktu As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
