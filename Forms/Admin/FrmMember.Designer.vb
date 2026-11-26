Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Admin

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmMember
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
            Me.components = New System.ComponentModel.Container()
            Me.errMember = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnlLeft = New System.Windows.Forms.Panel()
            Me.cardGrid = New Guna.UI2.WinForms.Guna2Panel()
            Me.txtCari = New Guna.UI2.WinForms.Guna2TextBox()
            Me.dgvMember = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colMemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colNoHp = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMemNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPoin = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlRight = New System.Windows.Forms.Panel()
            Me.cardEd = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblNoHp = New System.Windows.Forms.Label()
            Me.txtNoHp = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblNama = New System.Windows.Forms.Label()
            Me.txtNama = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblPoin = New System.Windows.Forms.Label()
            Me.txtPoin = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnTambah = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSimpan = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlSep = New System.Windows.Forms.Panel()
            Me.lblAdj = New System.Windows.Forms.Label()
            Me.lblDeltaPoin = New System.Windows.Forms.Label()
            Me.txtDeltaPoin = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblAlasanPoin = New System.Windows.Forms.Label()
            Me.txtAlasanPoin = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnAturPoin = New Guna.UI2.WinForms.Guna2Button()
            CType(Me.errMember, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlLeft.SuspendLayout()
            Me.cardGrid.SuspendLayout()
            CType(Me.dgvMember, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlRight.SuspendLayout()
            Me.cardEd.SuspendLayout()
            Me.SuspendLayout()
            '
            'errMember
            '
            Me.errMember.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            Me.errMember.ContainerControl = Me
            '
            'pnlLeft
            '
            Me.pnlLeft.Controls.Add(Me.cardGrid)
            Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
            Me.pnlLeft.Name = "pnlLeft"
            Me.pnlLeft.Padding = New System.Windows.Forms.Padding(18)
            Me.pnlLeft.Size = New System.Drawing.Size(670, 600)
            Me.pnlLeft.TabIndex = 0
            '
            'cardGrid
            '
            Me.cardGrid.BackColor = System.Drawing.Color.Transparent
            Me.cardGrid.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGrid.BorderRadius = 16
            Me.cardGrid.BorderThickness = 1
            Me.cardGrid.Controls.Add(Me.txtCari)
            Me.cardGrid.Controls.Add(Me.dgvMember)
            Me.cardGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGrid.FillColor = System.Drawing.Color.White
            Me.cardGrid.Location = New System.Drawing.Point(18, 18)
            Me.cardGrid.Name = "cardGrid"
            Me.cardGrid.Padding = New System.Windows.Forms.Padding(14)
            Me.cardGrid.Size = New System.Drawing.Size(634, 564)
            Me.cardGrid.TabIndex = 0
            Me.cardGrid.UseTransparentBackground = True
            '
            'txtCari
            '
            Me.txtCari.BackColor = System.Drawing.Color.Transparent
            Me.txtCari.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtCari.BorderRadius = 12
            Me.txtCari.DefaultText = ""
            Me.txtCari.FillColor = System.Drawing.Color.White
            Me.txtCari.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtCari.Location = New System.Drawing.Point(14, 14)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderText = "Cari nama atau no. HP member..."
            Me.txtCari.Size = New System.Drawing.Size(340, 38)
            Me.txtCari.TabIndex = 0
            Me.txtCari.BorderThickness = 1
            '
            'dgvMember
            '
            Me.dgvMember.AllowUserToAddRows = False
            Me.dgvMember.AllowUserToDeleteRows = False
            Me.dgvMember.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvMember.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvMember.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvMember.AutoGenerateColumns = False
            Me.dgvMember.BackgroundColor = System.Drawing.Color.White
            Me.dgvMember.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvMember.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvMember.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvMember.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvMember.ColumnHeadersHeight = 42
            Me.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvMember.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMemId, Me.colNoHp, Me.colMemNama, Me.colPoin})
            Me.dgvMember.EnableHeadersVisualStyles = False
            Me.dgvMember.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvMember.Location = New System.Drawing.Point(14, 62)
            Me.dgvMember.MultiSelect = False
            Me.dgvMember.Name = "dgvMember"
            Me.dgvMember.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvMember.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvMember.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvMember.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvMember.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvMember.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvMember.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvMember.ThemeStyle.RowsStyle.Height = 40
            Me.dgvMember.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvMember.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvMember.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvMember.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvMember.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvMember.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvMember.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvMember.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvMember.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvMember.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvMember.ReadOnly = True
            Me.dgvMember.RowHeadersVisible = False
            Me.dgvMember.RowTemplate.Height = 40
            Me.dgvMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvMember.Size = New System.Drawing.Size(606, 488)
            Me.dgvMember.TabIndex = 1
            '
            'colMemId
            '
            Me.colMemId.DataPropertyName = "id_member"
            Me.colMemId.HeaderText = "ID"
            Me.colMemId.Name = "colMemId"
            Me.colMemId.ReadOnly = True
            Me.colMemId.Width = 55
            '
            'colNoHp
            '
            Me.colNoHp.DataPropertyName = "no_hp"
            Me.colNoHp.HeaderText = "No. HP"
            Me.colNoHp.Name = "colNoHp"
            Me.colNoHp.ReadOnly = True
            Me.colNoHp.Width = 155
            '
            'colMemNama
            '
            Me.colMemNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colMemNama.DataPropertyName = "nama"
            Me.colMemNama.HeaderText = "Nama Member"
            Me.colMemNama.Name = "colMemNama"
            Me.colMemNama.ReadOnly = True
            '
            'colPoin
            '
            Me.colPoin.DataPropertyName = "poin"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.colPoin.DefaultCellStyle = DataGridViewCellStyle3
            Me.colPoin.HeaderText = "Poin"
            Me.colPoin.Name = "colPoin"
            Me.colPoin.ReadOnly = True
            Me.colPoin.Width = 85
            '
            'pnlRight
            '
            Me.pnlRight.Controls.Add(Me.cardEd)
            Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlRight.Location = New System.Drawing.Point(670, 0)
            Me.pnlRight.Name = "pnlRight"
            Me.pnlRight.Padding = New System.Windows.Forms.Padding(0, 18, 18, 18)
            Me.pnlRight.Size = New System.Drawing.Size(370, 600)
            Me.pnlRight.TabIndex = 1
            '
            'cardEd
            '
            Me.cardEd.BackColor = System.Drawing.Color.Transparent
            Me.cardEd.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardEd.BorderRadius = 16
            Me.cardEd.BorderThickness = 1
            Me.cardEd.Controls.Add(Me.lblNoHp)
            Me.cardEd.Controls.Add(Me.txtNoHp)
            Me.cardEd.Controls.Add(Me.lblNama)
            Me.cardEd.Controls.Add(Me.txtNama)
            Me.cardEd.Controls.Add(Me.lblPoin)
            Me.cardEd.Controls.Add(Me.txtPoin)
            Me.cardEd.Controls.Add(Me.btnTambah)
            Me.cardEd.Controls.Add(Me.btnSimpan)
            Me.cardEd.Controls.Add(Me.pnlSep)
            Me.cardEd.Controls.Add(Me.lblAdj)
            Me.cardEd.Controls.Add(Me.lblDeltaPoin)
            Me.cardEd.Controls.Add(Me.txtDeltaPoin)
            Me.cardEd.Controls.Add(Me.lblAlasanPoin)
            Me.cardEd.Controls.Add(Me.txtAlasanPoin)
            Me.cardEd.Controls.Add(Me.btnAturPoin)
            Me.cardEd.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardEd.FillColor = System.Drawing.Color.White
            Me.cardEd.Location = New System.Drawing.Point(0, 18)
            Me.cardEd.Name = "cardEd"
            Me.cardEd.Padding = New System.Windows.Forms.Padding(18)
            Me.cardEd.Size = New System.Drawing.Size(352, 564)
            Me.cardEd.TabIndex = 0
            Me.cardEd.UseTransparentBackground = True
            '
            'lblNoHp
            '
            Me.lblNoHp.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblNoHp.Location = New System.Drawing.Point(18, 18)
            Me.lblNoHp.Name = "lblNoHp"
            Me.lblNoHp.Size = New System.Drawing.Size(310, 20)
            Me.lblNoHp.TabIndex = 0
            Me.lblNoHp.Text = "No. HP (10-15 digit)"
            '
            'txtNoHp
            '
            Me.txtNoHp.BackColor = System.Drawing.Color.Transparent
            Me.txtNoHp.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNoHp.BorderRadius = 12
            Me.txtNoHp.DefaultText = ""
            Me.txtNoHp.FillColor = System.Drawing.Color.White
            Me.txtNoHp.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNoHp.Location = New System.Drawing.Point(18, 40)
            Me.txtNoHp.Name = "txtNoHp"
            Me.txtNoHp.Size = New System.Drawing.Size(316, 38)
            Me.txtNoHp.TabIndex = 1
            Me.txtNoHp.BorderThickness = 1
            '
            'lblNama
            '
            Me.lblNama.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblNama.Location = New System.Drawing.Point(18, 88)
            Me.lblNama.Name = "lblNama"
            Me.lblNama.Size = New System.Drawing.Size(310, 20)
            Me.lblNama.TabIndex = 2
            Me.lblNama.Text = "Nama Lengkap"
            '
            'txtNama
            '
            Me.txtNama.BackColor = System.Drawing.Color.Transparent
            Me.txtNama.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNama.BorderRadius = 12
            Me.txtNama.DefaultText = ""
            Me.txtNama.FillColor = System.Drawing.Color.White
            Me.txtNama.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNama.Location = New System.Drawing.Point(18, 110)
            Me.txtNama.Name = "txtNama"
            Me.txtNama.Size = New System.Drawing.Size(316, 38)
            Me.txtNama.TabIndex = 3
            Me.txtNama.BorderThickness = 1
            '
            'lblPoin
            '
            Me.lblPoin.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblPoin.Location = New System.Drawing.Point(18, 158)
            Me.lblPoin.Name = "lblPoin"
            Me.lblPoin.Size = New System.Drawing.Size(310, 20)
            Me.lblPoin.TabIndex = 4
            Me.lblPoin.Text = "Saldo Poin (Hanya Baca)"
            '
            'txtPoin
            '
            Me.txtPoin.BackColor = System.Drawing.Color.Transparent
            Me.txtPoin.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtPoin.BorderRadius = 12
            Me.txtPoin.DefaultText = ""
            Me.txtPoin.FillColor = System.Drawing.Color.White
            Me.txtPoin.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtPoin.Location = New System.Drawing.Point(18, 180)
            Me.txtPoin.Name = "txtPoin"
            Me.txtPoin.ReadOnly = True
            Me.txtPoin.Size = New System.Drawing.Size(316, 38)
            Me.txtPoin.TabIndex = 5
            Me.txtPoin.BorderThickness = 1
            '
            'btnTambah
            '
            Me.btnTambah.BackColor = System.Drawing.Color.Transparent
            Me.btnTambah.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnTambah.BorderRadius = 10
            Me.btnTambah.BorderThickness = 1
            Me.btnTambah.FillColor = System.Drawing.Color.White
            Me.btnTambah.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnTambah.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnTambah.Location = New System.Drawing.Point(18, 232)
            Me.btnTambah.Name = "btnTambah"
            Me.btnTambah.Size = New System.Drawing.Size(150, 40)
            Me.btnTambah.TabIndex = 6
            Me.btnTambah.Text = "Baru"
            Me.btnTambah.UseTransparentBackground = True
            '
            'btnSimpan
            '
            Me.btnSimpan.BackColor = System.Drawing.Color.Transparent
            Me.btnSimpan.BorderRadius = 12
            Me.btnSimpan.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSimpan.ForeColor = System.Drawing.Color.White
            Me.btnSimpan.Location = New System.Drawing.Point(184, 232)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.BorderThickness = 0
            Me.btnSimpan.Size = New System.Drawing.Size(150, 40)
            Me.btnSimpan.TabIndex = 7
            Me.btnSimpan.Text = "Simpan"
            Me.btnSimpan.UseTransparentBackground = True
            '
            'pnlSep
            '
            Me.pnlSep.BackColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.pnlSep.Location = New System.Drawing.Point(18, 290)
            Me.pnlSep.Name = "pnlSep"
            Me.pnlSep.Size = New System.Drawing.Size(316, 1)
            Me.pnlSep.TabIndex = 8
            '
            'lblAdj
            '
            Me.lblAdj.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblAdj.Location = New System.Drawing.Point(18, 302)
            Me.lblAdj.Name = "lblAdj"
            Me.lblAdj.Size = New System.Drawing.Size(316, 22)
            Me.lblAdj.TabIndex = 9
            Me.lblAdj.Text = "Penyesuaian Poin Manual"
            '
            'lblDeltaPoin
            '
            Me.lblDeltaPoin.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblDeltaPoin.Location = New System.Drawing.Point(18, 330)
            Me.lblDeltaPoin.Name = "lblDeltaPoin"
            Me.lblDeltaPoin.Size = New System.Drawing.Size(316, 18)
            Me.lblDeltaPoin.TabIndex = 10
            Me.lblDeltaPoin.Text = "Poin Baru (atau tambah/kurangi dengan nilai akhir)"
            '
            'txtDeltaPoin
            '
            Me.txtDeltaPoin.BackColor = System.Drawing.Color.Transparent
            Me.txtDeltaPoin.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtDeltaPoin.BorderRadius = 12
            Me.txtDeltaPoin.DefaultText = ""
            Me.txtDeltaPoin.FillColor = System.Drawing.Color.White
            Me.txtDeltaPoin.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtDeltaPoin.Location = New System.Drawing.Point(18, 350)
            Me.txtDeltaPoin.Name = "txtDeltaPoin"
            Me.txtDeltaPoin.PlaceholderText = "Masukkan saldo poin baru..."
            Me.txtDeltaPoin.Size = New System.Drawing.Size(316, 36)
            Me.txtDeltaPoin.TabIndex = 11
            Me.txtDeltaPoin.BorderThickness = 1
            '
            'lblAlasanPoin
            '
            Me.lblAlasanPoin.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblAlasanPoin.Location = New System.Drawing.Point(18, 394)
            Me.lblAlasanPoin.Name = "lblAlasanPoin"
            Me.lblAlasanPoin.Size = New System.Drawing.Size(316, 18)
            Me.lblAlasanPoin.TabIndex = 12
            Me.lblAlasanPoin.Text = "Alasan Penyesuaian (Wajib)"
            '
            'txtAlasanPoin
            '
            Me.txtAlasanPoin.BackColor = System.Drawing.Color.Transparent
            Me.txtAlasanPoin.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtAlasanPoin.BorderRadius = 12
            Me.txtAlasanPoin.DefaultText = ""
            Me.txtAlasanPoin.FillColor = System.Drawing.Color.White
            Me.txtAlasanPoin.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtAlasanPoin.Location = New System.Drawing.Point(18, 414)
            Me.txtAlasanPoin.Name = "txtAlasanPoin"
            Me.txtAlasanPoin.PlaceholderText = "Contoh: Kompensasi promo..."
            Me.txtAlasanPoin.Size = New System.Drawing.Size(316, 36)
            Me.txtAlasanPoin.TabIndex = 13
            Me.txtAlasanPoin.BorderThickness = 1
            '
            'btnAturPoin
            '
            Me.btnAturPoin.BackColor = System.Drawing.Color.Transparent
            Me.btnAturPoin.BorderRadius = 12
            Me.btnAturPoin.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnAturPoin.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnAturPoin.ForeColor = System.Drawing.Color.White
            Me.btnAturPoin.Location = New System.Drawing.Point(18, 462)
            Me.btnAturPoin.Name = "btnAturPoin"
            Me.btnAturPoin.BorderThickness = 0
            Me.btnAturPoin.Size = New System.Drawing.Size(316, 42)
            Me.btnAturPoin.TabIndex = 14
            Me.btnAturPoin.Text = "Atur Poin"
            Me.btnAturPoin.UseTransparentBackground = True
            '
            'FrmMember
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1040, 600)
            Me.Controls.Add(Me.pnlLeft)
            Me.Controls.Add(Me.pnlRight)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.Name = "FrmMember"
            Me.Text = "Manajemen Member & Poin Loyalitas"
            CType(Me.errMember, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlLeft.ResumeLayout(False)
            Me.cardGrid.ResumeLayout(False)
            CType(Me.dgvMember, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlRight.ResumeLayout(False)
            Me.cardEd.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents errMember As System.Windows.Forms.ErrorProvider
        Friend WithEvents pnlLeft As System.Windows.Forms.Panel
        Friend WithEvents cardGrid As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents txtCari As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents dgvMember As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colMemId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colNoHp As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMemNama As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPoin As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnlRight As System.Windows.Forms.Panel
        Friend WithEvents cardEd As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblNoHp As System.Windows.Forms.Label
        Friend WithEvents txtNoHp As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblNama As System.Windows.Forms.Label
        Friend WithEvents txtNama As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblPoin As System.Windows.Forms.Label
        Friend WithEvents txtPoin As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnTambah As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSimpan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlSep As System.Windows.Forms.Panel
        Friend WithEvents lblAdj As System.Windows.Forms.Label
        Friend WithEvents lblDeltaPoin As System.Windows.Forms.Label
        Friend WithEvents txtDeltaPoin As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblAlasanPoin As System.Windows.Forms.Label
        Friend WithEvents txtAlasanPoin As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnAturPoin As Guna.UI2.WinForms.Guna2Button

    End Class
End Namespace
