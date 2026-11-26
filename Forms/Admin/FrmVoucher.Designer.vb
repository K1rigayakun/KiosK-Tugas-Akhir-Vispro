Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Admin

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmVoucher
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
            Me.components = New System.ComponentModel.Container()
            Me.errVoucher = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnlLeft = New System.Windows.Forms.Panel()
            Me.cardGrid = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvVoucher = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colKode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colJenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colNilai = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMinBelanja = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTglAkhir = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAktif = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.lblH = New System.Windows.Forms.Label()
            Me.pnlRight = New System.Windows.Forms.Panel()
            Me.cardEd = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblKode = New System.Windows.Forms.Label()
            Me.txtKode = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblJenis = New System.Windows.Forms.Label()
            Me.cboJenis = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblNilai = New System.Windows.Forms.Label()
            Me.txtNilai = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblMinBelanja = New System.Windows.Forms.Label()
            Me.txtMinBelanja = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblMulai = New System.Windows.Forms.Label()
            Me.dtpMulai = New System.Windows.Forms.DateTimePicker()
            Me.lblAkhir = New System.Windows.Forms.Label()
            Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
            Me.chkAktif = New System.Windows.Forms.CheckBox()
            Me.btnBaru = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSimpan = New Guna.UI2.WinForms.Guna2Button()
            Me.btnHapus = New Guna.UI2.WinForms.Guna2Button()
            CType(Me.errVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlLeft.SuspendLayout()
            Me.cardGrid.SuspendLayout()
            CType(Me.dgvVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlRight.SuspendLayout()
            Me.cardEd.SuspendLayout()
            Me.SuspendLayout()
            '
            'errVoucher
            '
            Me.errVoucher.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            Me.errVoucher.ContainerControl = Me
            '
            'pnlLeft
            '
            Me.pnlLeft.Controls.Add(Me.cardGrid)
            Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
            Me.pnlLeft.Name = "pnlLeft"
            Me.pnlLeft.Padding = New System.Windows.Forms.Padding(18)
            Me.pnlLeft.Size = New System.Drawing.Size(680, 600)
            Me.pnlLeft.TabIndex = 0
            '
            'cardGrid
            '
            Me.cardGrid.BackColor = System.Drawing.Color.Transparent
            Me.cardGrid.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGrid.BorderRadius = 16
            Me.cardGrid.BorderThickness = 1
            Me.cardGrid.Controls.Add(Me.dgvVoucher)
            Me.cardGrid.Controls.Add(Me.lblH)
            Me.cardGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGrid.FillColor = System.Drawing.Color.White
            Me.cardGrid.Location = New System.Drawing.Point(18, 18)
            Me.cardGrid.Name = "cardGrid"
            Me.cardGrid.Padding = New System.Windows.Forms.Padding(14)
            Me.cardGrid.Size = New System.Drawing.Size(644, 564)
            Me.cardGrid.TabIndex = 0
            Me.cardGrid.UseTransparentBackground = True
            '
            'lblH
            '
            Me.lblH.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblH.Font = New System.Drawing.Font("Georgia", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblH.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblH.Location = New System.Drawing.Point(14, 14)
            Me.lblH.Name = "lblH"
            Me.lblH.Size = New System.Drawing.Size(616, 34)
            Me.lblH.TabIndex = 0
            Me.lblH.Text = "Daftar Kode Voucher Promo"
            '
            'dgvVoucher
            '
            Me.dgvVoucher.AllowUserToAddRows = False
            Me.dgvVoucher.AllowUserToDeleteRows = False
            Me.dgvVoucher.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvVoucher.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvVoucher.AutoGenerateColumns = False
            Me.dgvVoucher.BackgroundColor = System.Drawing.Color.White
            Me.dgvVoucher.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvVoucher.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvVoucher.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvVoucher.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvVoucher.ColumnHeadersHeight = 42
            Me.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvVoucher.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colKode, Me.colJenis, Me.colNilai, Me.colMinBelanja, Me.colTglAkhir, Me.colAktif})
            Me.dgvVoucher.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvVoucher.EnableHeadersVisualStyles = False
            Me.dgvVoucher.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvVoucher.Location = New System.Drawing.Point(14, 48)
            Me.dgvVoucher.MultiSelect = False
            Me.dgvVoucher.Name = "dgvVoucher"
            Me.dgvVoucher.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvVoucher.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvVoucher.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvVoucher.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvVoucher.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvVoucher.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvVoucher.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvVoucher.ThemeStyle.RowsStyle.Height = 40
            Me.dgvVoucher.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvVoucher.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvVoucher.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvVoucher.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvVoucher.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvVoucher.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvVoucher.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvVoucher.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvVoucher.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvVoucher.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvVoucher.ReadOnly = True
            Me.dgvVoucher.RowHeadersVisible = False
            Me.dgvVoucher.RowTemplate.Height = 40
            Me.dgvVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvVoucher.Size = New System.Drawing.Size(616, 502)
            Me.dgvVoucher.TabIndex = 1
            '
            'colKode
            '
            Me.colKode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colKode.DataPropertyName = "kode"
            Me.colKode.HeaderText = "Kode"
            Me.colKode.MinimumWidth = 115
            Me.colKode.Name = "colKode"
            Me.colKode.ReadOnly = True
            '
            'colJenis
            '
            Me.colJenis.DataPropertyName = "jenis"
            Me.colJenis.HeaderText = "Jenis"
            Me.colJenis.Name = "colJenis"
            Me.colJenis.ReadOnly = True
            Me.colJenis.Width = 85
            '
            'colNilai
            '
            Me.colNilai.DataPropertyName = "nilai"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.colNilai.DefaultCellStyle = DataGridViewCellStyle3
            Me.colNilai.HeaderText = "Nilai"
            Me.colNilai.Name = "colNilai"
            Me.colNilai.ReadOnly = True
            Me.colNilai.Width = 95
            '
            'colMinBelanja
            '
            Me.colMinBelanja.DataPropertyName = "min_belanja"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.Format = "C0"
            Me.colMinBelanja.DefaultCellStyle = DataGridViewCellStyle4
            Me.colMinBelanja.HeaderText = "Min. Belanja"
            Me.colMinBelanja.Name = "colMinBelanja"
            Me.colMinBelanja.ReadOnly = True
            Me.colMinBelanja.Width = 120
            '
            'colTglAkhir
            '
            Me.colTglAkhir.DataPropertyName = "tgl_akhir"
            DataGridViewCellStyle5.Format = "dd/MM/yyyy"
            Me.colTglAkhir.DefaultCellStyle = DataGridViewCellStyle5
            Me.colTglAkhir.HeaderText = "Berlaku s/d"
            Me.colTglAkhir.Name = "colTglAkhir"
            Me.colTglAkhir.ReadOnly = True
            Me.colTglAkhir.Width = 105
            '
            'colAktif
            '
            Me.colAktif.DataPropertyName = "aktif"
            Me.colAktif.HeaderText = "Aktif"
            Me.colAktif.Name = "colAktif"
            Me.colAktif.ReadOnly = True
            Me.colAktif.Width = 60
            '
            'pnlRight
            '
            Me.pnlRight.Controls.Add(Me.cardEd)
            Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlRight.Location = New System.Drawing.Point(680, 0)
            Me.pnlRight.Name = "pnlRight"
            Me.pnlRight.Padding = New System.Windows.Forms.Padding(0, 18, 18, 18)
            Me.pnlRight.Size = New System.Drawing.Size(360, 600)
            Me.pnlRight.TabIndex = 1
            '
            'cardEd
            '
            Me.cardEd.BackColor = System.Drawing.Color.Transparent
            Me.cardEd.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardEd.BorderRadius = 16
            Me.cardEd.BorderThickness = 1
            Me.cardEd.Controls.Add(Me.lblKode)
            Me.cardEd.Controls.Add(Me.txtKode)
            Me.cardEd.Controls.Add(Me.lblJenis)
            Me.cardEd.Controls.Add(Me.cboJenis)
            Me.cardEd.Controls.Add(Me.lblNilai)
            Me.cardEd.Controls.Add(Me.txtNilai)
            Me.cardEd.Controls.Add(Me.lblMinBelanja)
            Me.cardEd.Controls.Add(Me.txtMinBelanja)
            Me.cardEd.Controls.Add(Me.lblMulai)
            Me.cardEd.Controls.Add(Me.dtpMulai)
            Me.cardEd.Controls.Add(Me.lblAkhir)
            Me.cardEd.Controls.Add(Me.dtpAkhir)
            Me.cardEd.Controls.Add(Me.chkAktif)
            Me.cardEd.Controls.Add(Me.btnBaru)
            Me.cardEd.Controls.Add(Me.btnSimpan)
            Me.cardEd.Controls.Add(Me.btnHapus)
            Me.cardEd.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardEd.FillColor = System.Drawing.Color.White
            Me.cardEd.Location = New System.Drawing.Point(0, 18)
            Me.cardEd.Name = "cardEd"
            Me.cardEd.Padding = New System.Windows.Forms.Padding(18)
            Me.cardEd.Size = New System.Drawing.Size(342, 564)
            Me.cardEd.TabIndex = 0
            Me.cardEd.UseTransparentBackground = True
            '
            'lblKode
            '
            Me.lblKode.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblKode.Location = New System.Drawing.Point(18, 18)
            Me.lblKode.Name = "lblKode"
            Me.lblKode.Size = New System.Drawing.Size(300, 20)
            Me.lblKode.TabIndex = 0
            Me.lblKode.Text = "Kode Voucher (Unik)"
            '
            'txtKode
            '
            Me.txtKode.BackColor = System.Drawing.Color.Transparent
            Me.txtKode.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtKode.BorderRadius = 12
            Me.txtKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtKode.DefaultText = ""
            Me.txtKode.FillColor = System.Drawing.Color.White
            Me.txtKode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtKode.Location = New System.Drawing.Point(18, 40)
            Me.txtKode.Name = "txtKode"
            Me.txtKode.Size = New System.Drawing.Size(306, 38)
            Me.txtKode.TabIndex = 1
            Me.txtKode.BorderThickness = 1
            '
            'lblJenis
            '
            Me.lblJenis.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblJenis.Location = New System.Drawing.Point(18, 88)
            Me.lblJenis.Name = "lblJenis"
            Me.lblJenis.Size = New System.Drawing.Size(300, 20)
            Me.lblJenis.TabIndex = 2
            Me.lblJenis.Text = "Jenis Potongan"
            '
            'cboJenis
            '
            Me.cboJenis.BackColor = System.Drawing.Color.Transparent
            Me.cboJenis.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboJenis.BorderRadius = 12
            Me.cboJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboJenis.FillColor = System.Drawing.Color.White
            Me.cboJenis.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboJenis.ItemHeight = 32
            Me.cboJenis.Location = New System.Drawing.Point(18, 110)
            Me.cboJenis.Name = "cboJenis"
            Me.cboJenis.Size = New System.Drawing.Size(306, 38)
            Me.cboJenis.TabIndex = 3
            Me.cboJenis.BorderThickness = 1
            '
            'lblNilai
            '
            Me.lblNilai.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblNilai.Location = New System.Drawing.Point(18, 158)
            Me.lblNilai.Name = "lblNilai"
            Me.lblNilai.Size = New System.Drawing.Size(306, 20)
            Me.lblNilai.TabIndex = 4
            Me.lblNilai.Text = "Nilai (Persen <= 100 atau Nominal Rp)"
            '
            'txtNilai
            '
            Me.txtNilai.BackColor = System.Drawing.Color.Transparent
            Me.txtNilai.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNilai.BorderRadius = 12
            Me.txtNilai.DefaultText = ""
            Me.txtNilai.FillColor = System.Drawing.Color.White
            Me.txtNilai.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNilai.Location = New System.Drawing.Point(18, 180)
            Me.txtNilai.Name = "txtNilai"
            Me.txtNilai.Size = New System.Drawing.Size(306, 38)
            Me.txtNilai.TabIndex = 5
            Me.txtNilai.BorderThickness = 1
            '
            'lblMinBelanja
            '
            Me.lblMinBelanja.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblMinBelanja.Location = New System.Drawing.Point(18, 228)
            Me.lblMinBelanja.Name = "lblMinBelanja"
            Me.lblMinBelanja.Size = New System.Drawing.Size(300, 20)
            Me.lblMinBelanja.TabIndex = 6
            Me.lblMinBelanja.Text = "Minimal Belanja (Rp)"
            '
            'txtMinBelanja
            '
            Me.txtMinBelanja.BackColor = System.Drawing.Color.Transparent
            Me.txtMinBelanja.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtMinBelanja.BorderRadius = 12
            Me.txtMinBelanja.DefaultText = "0"
            Me.txtMinBelanja.FillColor = System.Drawing.Color.White
            Me.txtMinBelanja.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtMinBelanja.Location = New System.Drawing.Point(18, 250)
            Me.txtMinBelanja.Name = "txtMinBelanja"
            Me.txtMinBelanja.Size = New System.Drawing.Size(306, 38)
            Me.txtMinBelanja.TabIndex = 7
            Me.txtMinBelanja.BorderThickness = 1
            Me.txtMinBelanja.Text = "0"
            '
            'lblMulai
            '
            Me.lblMulai.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblMulai.Location = New System.Drawing.Point(18, 298)
            Me.lblMulai.Name = "lblMulai"
            Me.lblMulai.Size = New System.Drawing.Size(146, 20)
            Me.lblMulai.TabIndex = 8
            Me.lblMulai.Text = "Tanggal Mulai"
            '
            'dtpMulai
            '
            Me.dtpMulai.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpMulai.Location = New System.Drawing.Point(18, 320)
            Me.dtpMulai.Name = "dtpMulai"
            Me.dtpMulai.Size = New System.Drawing.Size(144, 28)
            Me.dtpMulai.TabIndex = 9
            '
            'lblAkhir
            '
            Me.lblAkhir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblAkhir.Location = New System.Drawing.Point(176, 298)
            Me.lblAkhir.Name = "lblAkhir"
            Me.lblAkhir.Size = New System.Drawing.Size(146, 20)
            Me.lblAkhir.TabIndex = 10
            Me.lblAkhir.Text = "Tanggal Akhir"
            '
            'dtpAkhir
            '
            Me.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpAkhir.Location = New System.Drawing.Point(176, 320)
            Me.dtpAkhir.Name = "dtpAkhir"
            Me.dtpAkhir.Size = New System.Drawing.Size(148, 28)
            Me.dtpAkhir.TabIndex = 11
            '
            'chkAktif
            '
            Me.chkAktif.BackColor = System.Drawing.Color.Transparent
            Me.chkAktif.Checked = True
            Me.chkAktif.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkAktif.Location = New System.Drawing.Point(18, 360)
            Me.chkAktif.Name = "chkAktif"
            Me.chkAktif.Size = New System.Drawing.Size(140, 24)
            Me.chkAktif.TabIndex = 12
            Me.chkAktif.Text = "Voucher Aktif"
            '
            'btnBaru
            '
            Me.btnBaru.BackColor = System.Drawing.Color.Transparent
            Me.btnBaru.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnBaru.BorderRadius = 12
            Me.btnBaru.BorderThickness = 1
            Me.btnBaru.FillColor = System.Drawing.Color.White
            Me.btnBaru.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnBaru.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnBaru.Location = New System.Drawing.Point(18, 404)
            Me.btnBaru.Name = "btnBaru"
            Me.btnBaru.Size = New System.Drawing.Size(94, 42)
            Me.btnBaru.TabIndex = 13
            Me.btnBaru.Text = "Baru"
            Me.btnBaru.UseTransparentBackground = True
            '
            'btnSimpan
            '
            Me.btnSimpan.BackColor = System.Drawing.Color.Transparent
            Me.btnSimpan.BorderRadius = 12
            Me.btnSimpan.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSimpan.ForeColor = System.Drawing.Color.White
            Me.btnSimpan.Location = New System.Drawing.Point(120, 404)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.BorderThickness = 0
            Me.btnSimpan.Size = New System.Drawing.Size(100, 42)
            Me.btnSimpan.TabIndex = 14
            Me.btnSimpan.Text = "Simpan"
            Me.btnSimpan.UseTransparentBackground = True
            '
            'btnHapus
            '
            Me.btnHapus.BackColor = System.Drawing.Color.Transparent
            Me.btnHapus.BorderColor = System.Drawing.Color.FromArgb(234, 181, 176)
            Me.btnHapus.BorderRadius = 12
            Me.btnHapus.BorderThickness = 1
            Me.btnHapus.FillColor = System.Drawing.Color.FromArgb(253, 236, 236)
            Me.btnHapus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnHapus.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnHapus.Location = New System.Drawing.Point(228, 404)
            Me.btnHapus.Name = "btnHapus"
            Me.btnHapus.Size = New System.Drawing.Size(96, 42)
            Me.btnHapus.TabIndex = 15
            Me.btnHapus.Text = "Hapus"
            Me.btnHapus.UseTransparentBackground = True
            '
            'FrmVoucher
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1040, 600)
            Me.Controls.Add(Me.pnlLeft)
            Me.Controls.Add(Me.pnlRight)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.Name = "FrmVoucher"
            Me.Text = "Manajemen Voucher & Promo"
            CType(Me.errVoucher, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlLeft.ResumeLayout(False)
            Me.cardGrid.ResumeLayout(False)
            CType(Me.dgvVoucher, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlRight.ResumeLayout(False)
            Me.cardEd.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents errVoucher As System.Windows.Forms.ErrorProvider
        Friend WithEvents pnlLeft As System.Windows.Forms.Panel
        Friend WithEvents cardGrid As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblH As System.Windows.Forms.Label
        Friend WithEvents dgvVoucher As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colKode As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colJenis As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colNilai As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMinBelanja As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTglAkhir As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAktif As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents pnlRight As System.Windows.Forms.Panel
        Friend WithEvents cardEd As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblKode As System.Windows.Forms.Label
        Friend WithEvents txtKode As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblJenis As System.Windows.Forms.Label
        Friend WithEvents cboJenis As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblNilai As System.Windows.Forms.Label
        Friend WithEvents txtNilai As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblMinBelanja As System.Windows.Forms.Label
        Friend WithEvents txtMinBelanja As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblMulai As System.Windows.Forms.Label
        Friend WithEvents dtpMulai As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblAkhir As System.Windows.Forms.Label
        Friend WithEvents dtpAkhir As System.Windows.Forms.DateTimePicker
        Friend WithEvents chkAktif As System.Windows.Forms.CheckBox
        Friend WithEvents btnBaru As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSimpan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnHapus As Guna.UI2.WinForms.Guna2Button

    End Class
End Namespace
