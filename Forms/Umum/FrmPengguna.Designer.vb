Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Umum

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmPengguna
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
            Me.components = New System.ComponentModel.Container()
            Me.errPengguna = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnlLeft = New System.Windows.Forms.Panel()
            Me.cardGrid = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.txtCari = New Guna.UI2.WinForms.Guna2TextBox()
            Me.dgvPengguna = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colUsername = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRole = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAktif = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.pnlRight = New System.Windows.Forms.Panel()
            Me.cardForm = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblEd = New System.Windows.Forms.Label()
            Me.lblUser = New System.Windows.Forms.Label()
            Me.txtUsername = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblNama = New System.Windows.Forms.Label()
            Me.txtNama = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblPass = New System.Windows.Forms.Label()
            Me.txtPassword = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblPeran = New System.Windows.Forms.Label()
            Me.cboPeran = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.chkAktif = New System.Windows.Forms.CheckBox()
            Me.btnTambah = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSimpan = New Guna.UI2.WinForms.Guna2Button()
            Me.btnResetPassword = New Guna.UI2.WinForms.Guna2Button()
            Me.btnNonaktifkan = New Guna.UI2.WinForms.Guna2Button()
            CType(Me.errPengguna, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlLeft.SuspendLayout()
            Me.cardGrid.SuspendLayout()
            CType(Me.dgvPengguna, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlRight.SuspendLayout()
            Me.cardForm.SuspendLayout()
            Me.SuspendLayout()
            '
            'errPengguna
            '
            Me.errPengguna.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            Me.errPengguna.ContainerControl = Me
            '
            'pnlLeft
            '
            Me.pnlLeft.Controls.Add(Me.cardGrid)
            Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
            Me.pnlLeft.Name = "pnlLeft"
            Me.pnlLeft.Padding = New System.Windows.Forms.Padding(18)
            Me.pnlLeft.Size = New System.Drawing.Size(680, 620)
            Me.pnlLeft.TabIndex = 0
            '
            'cardGrid
            '
            Me.cardGrid.BackColor = System.Drawing.Color.Transparent
            Me.cardGrid.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGrid.BorderRadius = 16
            Me.cardGrid.BorderThickness = 1
            Me.cardGrid.Controls.Add(Me.lblTitle)
            Me.cardGrid.Controls.Add(Me.txtCari)
            Me.cardGrid.Controls.Add(Me.dgvPengguna)
            Me.cardGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGrid.FillColor = System.Drawing.Color.White
            Me.cardGrid.Location = New System.Drawing.Point(18, 18)
            Me.cardGrid.Name = "cardGrid"
            Me.cardGrid.Padding = New System.Windows.Forms.Padding(16)
            Me.cardGrid.Size = New System.Drawing.Size(644, 584)
            Me.cardGrid.TabIndex = 0
            Me.cardGrid.UseTransparentBackground = True
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Georgia", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblTitle.Location = New System.Drawing.Point(16, 14)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(360, 28)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Daftar Pengguna (Admin & Kasir)"
            '
            'txtCari
            '
            Me.txtCari.BackColor = System.Drawing.Color.Transparent
            Me.txtCari.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtCari.BorderRadius = 12
            Me.txtCari.DefaultText = ""
            Me.txtCari.FillColor = System.Drawing.Color.White
            Me.txtCari.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtCari.Location = New System.Drawing.Point(16, 50)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderText = "Cari username atau nama..."
            Me.txtCari.Size = New System.Drawing.Size(340, 38)
            Me.txtCari.TabIndex = 1
            Me.txtCari.BorderThickness = 1
            '
            'dgvPengguna
            '
            Me.dgvPengguna.AllowUserToAddRows = False
            Me.dgvPengguna.AllowUserToDeleteRows = False
            Me.dgvPengguna.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvPengguna.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvPengguna.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvPengguna.AutoGenerateColumns = False
            Me.dgvPengguna.BackgroundColor = System.Drawing.Color.White
            Me.dgvPengguna.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvPengguna.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvPengguna.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvPengguna.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvPengguna.ColumnHeadersHeight = 42
            Me.dgvPengguna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvPengguna.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colUsername, Me.colNama, Me.colRole, Me.colAktif})
            Me.dgvPengguna.EnableHeadersVisualStyles = False
            Me.dgvPengguna.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvPengguna.Location = New System.Drawing.Point(16, 98)
            Me.dgvPengguna.MultiSelect = False
            Me.dgvPengguna.Name = "dgvPengguna"
            Me.dgvPengguna.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPengguna.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvPengguna.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPengguna.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvPengguna.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvPengguna.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPengguna.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvPengguna.ThemeStyle.RowsStyle.Height = 40
            Me.dgvPengguna.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPengguna.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvPengguna.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvPengguna.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvPengguna.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvPengguna.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvPengguna.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvPengguna.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvPengguna.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvPengguna.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvPengguna.ReadOnly = True
            Me.dgvPengguna.RowHeadersVisible = False
            Me.dgvPengguna.RowTemplate.Height = 40
            Me.dgvPengguna.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvPengguna.Size = New System.Drawing.Size(612, 470)
            Me.dgvPengguna.TabIndex = 2
            '
            'colId
            '
            Me.colId.DataPropertyName = "id_pengguna"
            Me.colId.HeaderText = "ID"
            Me.colId.Name = "colId"
            Me.colId.ReadOnly = True
            Me.colId.Width = 50
            '
            'colUsername
            '
            Me.colUsername.DataPropertyName = "username"
            Me.colUsername.HeaderText = "Username"
            Me.colUsername.Name = "colUsername"
            Me.colUsername.ReadOnly = True
            Me.colUsername.Width = 135
            '
            'colNama
            '
            Me.colNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colNama.DataPropertyName = "nama"
            Me.colNama.HeaderText = "Nama Lengkap"
            Me.colNama.Name = "colNama"
            Me.colNama.ReadOnly = True
            '
            'colRole
            '
            Me.colRole.DataPropertyName = "role"
            Me.colRole.HeaderText = "Peran"
            Me.colRole.Name = "colRole"
            Me.colRole.ReadOnly = True
            Me.colRole.Width = 90
            '
            'colAktif
            '
            Me.colAktif.DataPropertyName = "aktif"
            Me.colAktif.HeaderText = "Aktif"
            Me.colAktif.Name = "colAktif"
            Me.colAktif.ReadOnly = True
            Me.colAktif.Width = 65
            '
            'pnlRight
            '
            Me.pnlRight.Controls.Add(Me.cardForm)
            Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlRight.Location = New System.Drawing.Point(680, 0)
            Me.pnlRight.Name = "pnlRight"
            Me.pnlRight.Padding = New System.Windows.Forms.Padding(0, 18, 18, 18)
            Me.pnlRight.Size = New System.Drawing.Size(360, 620)
            Me.pnlRight.TabIndex = 1
            '
            'cardForm
            '
            Me.cardForm.BackColor = System.Drawing.Color.Transparent
            Me.cardForm.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardForm.BorderRadius = 16
            Me.cardForm.BorderThickness = 1
            Me.cardForm.Controls.Add(Me.lblEd)
            Me.cardForm.Controls.Add(Me.lblUser)
            Me.cardForm.Controls.Add(Me.txtUsername)
            Me.cardForm.Controls.Add(Me.lblNama)
            Me.cardForm.Controls.Add(Me.txtNama)
            Me.cardForm.Controls.Add(Me.lblPass)
            Me.cardForm.Controls.Add(Me.txtPassword)
            Me.cardForm.Controls.Add(Me.lblPeran)
            Me.cardForm.Controls.Add(Me.cboPeran)
            Me.cardForm.Controls.Add(Me.chkAktif)
            Me.cardForm.Controls.Add(Me.btnTambah)
            Me.cardForm.Controls.Add(Me.btnSimpan)
            Me.cardForm.Controls.Add(Me.btnResetPassword)
            Me.cardForm.Controls.Add(Me.btnNonaktifkan)
            Me.cardForm.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardForm.FillColor = System.Drawing.Color.White
            Me.cardForm.Location = New System.Drawing.Point(0, 18)
            Me.cardForm.Name = "cardForm"
            Me.cardForm.Padding = New System.Windows.Forms.Padding(18)
            Me.cardForm.Size = New System.Drawing.Size(342, 584)
            Me.cardForm.TabIndex = 0
            Me.cardForm.UseTransparentBackground = True
            '
            'lblEd
            '
            Me.lblEd.Font = New System.Drawing.Font("Georgia", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblEd.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblEd.Location = New System.Drawing.Point(18, 16)
            Me.lblEd.Name = "lblEd"
            Me.lblEd.Size = New System.Drawing.Size(300, 28)
            Me.lblEd.TabIndex = 0
            Me.lblEd.Text = "Detail Akun"
            '
            'lblUser
            '
            Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblUser.Location = New System.Drawing.Point(18, 56)
            Me.lblUser.Name = "lblUser"
            Me.lblUser.Size = New System.Drawing.Size(300, 20)
            Me.lblUser.TabIndex = 1
            Me.lblUser.Text = "Username"
            '
            'txtUsername
            '
            Me.txtUsername.BackColor = System.Drawing.Color.Transparent
            Me.txtUsername.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtUsername.BorderRadius = 12
            Me.txtUsername.DefaultText = ""
            Me.txtUsername.FillColor = System.Drawing.Color.White
            Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtUsername.Location = New System.Drawing.Point(18, 78)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(306, 38)
            Me.txtUsername.TabIndex = 2
            Me.txtUsername.BorderThickness = 1
            '
            'lblNama
            '
            Me.lblNama.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblNama.Location = New System.Drawing.Point(18, 126)
            Me.lblNama.Name = "lblNama"
            Me.lblNama.Size = New System.Drawing.Size(300, 20)
            Me.lblNama.TabIndex = 3
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
            Me.txtNama.Location = New System.Drawing.Point(18, 148)
            Me.txtNama.Name = "txtNama"
            Me.txtNama.Size = New System.Drawing.Size(306, 38)
            Me.txtNama.TabIndex = 4
            Me.txtNama.BorderThickness = 1
            '
            'lblPass
            '
            Me.lblPass.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblPass.Location = New System.Drawing.Point(18, 196)
            Me.lblPass.Name = "lblPass"
            Me.lblPass.Size = New System.Drawing.Size(306, 20)
            Me.lblPass.TabIndex = 5
            Me.lblPass.Text = "Password (min. 6 karakter untuk baru/reset)"
            '
            'txtPassword
            '
            Me.txtPassword.BackColor = System.Drawing.Color.Transparent
            Me.txtPassword.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtPassword.BorderRadius = 12
            Me.txtPassword.DefaultText = ""
            Me.txtPassword.FillColor = System.Drawing.Color.White
            Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtPassword.Location = New System.Drawing.Point(18, 218)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.Size = New System.Drawing.Size(306, 38)
            Me.txtPassword.TabIndex = 6
            Me.txtPassword.BorderThickness = 1
            '
            'lblPeran
            '
            Me.lblPeran.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblPeran.Location = New System.Drawing.Point(18, 266)
            Me.lblPeran.Name = "lblPeran"
            Me.lblPeran.Size = New System.Drawing.Size(300, 20)
            Me.lblPeran.TabIndex = 7
            Me.lblPeran.Text = "Peran"
            '
            'cboPeran
            '
            Me.cboPeran.BackColor = System.Drawing.Color.Transparent
            Me.cboPeran.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboPeran.BorderRadius = 12
            Me.cboPeran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPeran.FillColor = System.Drawing.Color.White
            Me.cboPeran.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboPeran.ItemHeight = 32
            Me.cboPeran.Location = New System.Drawing.Point(18, 288)
            Me.cboPeran.Name = "cboPeran"
            Me.cboPeran.Size = New System.Drawing.Size(306, 38)
            Me.cboPeran.TabIndex = 8
            Me.cboPeran.BorderThickness = 1
            '
            'chkAktif
            '
            Me.chkAktif.BackColor = System.Drawing.Color.Transparent
            Me.chkAktif.Checked = True
            Me.chkAktif.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkAktif.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.chkAktif.Location = New System.Drawing.Point(18, 338)
            Me.chkAktif.Name = "chkAktif"
            Me.chkAktif.Size = New System.Drawing.Size(150, 26)
            Me.chkAktif.TabIndex = 9
            Me.chkAktif.Text = "Akun Aktif"
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
            Me.btnTambah.Location = New System.Drawing.Point(18, 382)
            Me.btnTambah.Name = "btnTambah"
            Me.btnTambah.Size = New System.Drawing.Size(146, 42)
            Me.btnTambah.TabIndex = 10
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
            Me.btnSimpan.Location = New System.Drawing.Point(176, 382)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.BorderThickness = 0
            Me.btnSimpan.Size = New System.Drawing.Size(148, 42)
            Me.btnSimpan.TabIndex = 11
            Me.btnSimpan.Text = "Simpan"
            Me.btnSimpan.UseTransparentBackground = True
            '
            'btnResetPassword
            '
            Me.btnResetPassword.BackColor = System.Drawing.Color.Transparent
            Me.btnResetPassword.BorderRadius = 12
            Me.btnResetPassword.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnResetPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnResetPassword.ForeColor = System.Drawing.Color.White
            Me.btnResetPassword.Location = New System.Drawing.Point(18, 434)
            Me.btnResetPassword.Name = "btnResetPassword"
            Me.btnResetPassword.BorderThickness = 0
            Me.btnResetPassword.Size = New System.Drawing.Size(146, 42)
            Me.btnResetPassword.TabIndex = 12
            Me.btnResetPassword.Text = "Reset Pass"
            Me.btnResetPassword.UseTransparentBackground = True
            '
            'btnNonaktifkan
            '
            Me.btnNonaktifkan.BackColor = System.Drawing.Color.Transparent
            Me.btnNonaktifkan.BorderColor = System.Drawing.Color.FromArgb(234, 181, 176)
            Me.btnNonaktifkan.BorderRadius = 12
            Me.btnNonaktifkan.BorderThickness = 1
            Me.btnNonaktifkan.FillColor = System.Drawing.Color.FromArgb(253, 236, 236)
            Me.btnNonaktifkan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnNonaktifkan.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnNonaktifkan.Location = New System.Drawing.Point(176, 434)
            Me.btnNonaktifkan.Name = "btnNonaktifkan"
            Me.btnNonaktifkan.Size = New System.Drawing.Size(148, 42)
            Me.btnNonaktifkan.TabIndex = 13
            Me.btnNonaktifkan.Text = "Nonaktifkan"
            Me.btnNonaktifkan.UseTransparentBackground = True
            '
            'FrmPengguna
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1040, 620)
            Me.Controls.Add(Me.pnlLeft)
            Me.Controls.Add(Me.pnlRight)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.Name = "FrmPengguna"
            Me.Text = "Manajemen Pengguna Staff"
            CType(Me.errPengguna, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlLeft.ResumeLayout(False)
            Me.cardGrid.ResumeLayout(False)
            CType(Me.dgvPengguna, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlRight.ResumeLayout(False)
            Me.cardForm.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents errPengguna As System.Windows.Forms.ErrorProvider
        Friend WithEvents pnlLeft As System.Windows.Forms.Panel
        Friend WithEvents cardGrid As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents txtCari As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents dgvPengguna As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colUsername As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colNama As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRole As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAktif As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents pnlRight As System.Windows.Forms.Panel
        Friend WithEvents cardForm As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblEd As System.Windows.Forms.Label
        Friend WithEvents lblUser As System.Windows.Forms.Label
        Friend WithEvents txtUsername As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblNama As System.Windows.Forms.Label
        Friend WithEvents txtNama As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblPass As System.Windows.Forms.Label
        Friend WithEvents txtPassword As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblPeran As System.Windows.Forms.Label
        Friend WithEvents cboPeran As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents chkAktif As System.Windows.Forms.CheckBox
        Friend WithEvents btnTambah As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSimpan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnResetPassword As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnNonaktifkan As Guna.UI2.WinForms.Guna2Button

    End Class
End Namespace
