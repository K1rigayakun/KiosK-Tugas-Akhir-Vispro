Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kasir

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmLog
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
            Me.pnlTop = New System.Windows.Forms.Panel()
            Me.btnTampil = New Guna.UI2.WinForms.Guna2Button()
            Me.txtCari = New Guna.UI2.WinForms.Guna2TextBox()
            Me.dtpSampai = New System.Windows.Forms.DateTimePicker()
            Me.lblSampai = New System.Windows.Forms.Label()
            Me.dtpDari = New System.Windows.Forms.DateTimePicker()
            Me.lblDari = New System.Windows.Forms.Label()
            Me.pnlWrap = New System.Windows.Forms.Panel()
            Me.card = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvLog = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colWaktu = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPengguna = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAksi = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colKet = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlWrap.SuspendLayout()
            Me.card.SuspendLayout()
            CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.White
            Me.pnlTop.Controls.Add(Me.btnTampil)
            Me.pnlTop.Controls.Add(Me.txtCari)
            Me.pnlTop.Controls.Add(Me.dtpSampai)
            Me.pnlTop.Controls.Add(Me.lblSampai)
            Me.pnlTop.Controls.Add(Me.dtpDari)
            Me.pnlTop.Controls.Add(Me.lblDari)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(18, 12, 18, 10)
            Me.pnlTop.Size = New System.Drawing.Size(1060, 64)
            Me.pnlTop.TabIndex = 0
            '
            'lblDari
            '
            Me.lblDari.BackColor = System.Drawing.Color.Transparent
            Me.lblDari.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblDari.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblDari.Location = New System.Drawing.Point(18, 20)
            Me.lblDari.Name = "lblDari"
            Me.lblDari.Size = New System.Drawing.Size(44, 24)
            Me.lblDari.TabIndex = 0
            Me.lblDari.Text = "Dari:"
            '
            'dtpDari
            '
            Me.dtpDari.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDari.Location = New System.Drawing.Point(64, 17)
            Me.dtpDari.Name = "dtpDari"
            Me.dtpDari.Size = New System.Drawing.Size(140, 23)
            Me.dtpDari.TabIndex = 1
            '
            'lblSampai
            '
            Me.lblSampai.BackColor = System.Drawing.Color.Transparent
            Me.lblSampai.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblSampai.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblSampai.Location = New System.Drawing.Point(216, 20)
            Me.lblSampai.Name = "lblSampai"
            Me.lblSampai.Size = New System.Drawing.Size(68, 24)
            Me.lblSampai.TabIndex = 2
            Me.lblSampai.Text = "Sampai:"
            '
            'dtpSampai
            '
            Me.dtpSampai.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpSampai.Location = New System.Drawing.Point(288, 17)
            Me.dtpSampai.Name = "dtpSampai"
            Me.dtpSampai.Size = New System.Drawing.Size(140, 23)
            Me.dtpSampai.TabIndex = 3
            '
            'txtCari
            '
            Me.txtCari.BackColor = System.Drawing.Color.Transparent
            Me.txtCari.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtCari.BorderRadius = 12
            Me.txtCari.FillColor = System.Drawing.Color.White
            Me.txtCari.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtCari.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtCari.Location = New System.Drawing.Point(444, 12)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderText = "Cari aksi atau keterangan..."
            Me.txtCari.Size = New System.Drawing.Size(280, 38)
            Me.txtCari.TabIndex = 4
            Me.txtCari.BorderThickness = 1
            '
            'btnTampil
            '
            Me.btnTampil.BackColor = System.Drawing.Color.Transparent
            Me.btnTampil.BorderRadius = 12
            Me.btnTampil.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTampil.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnTampil.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnTampil.ForeColor = System.Drawing.Color.White
            Me.btnTampil.Location = New System.Drawing.Point(738, 12)
            Me.btnTampil.Name = "btnTampil"
            Me.btnTampil.BorderThickness = 0
            Me.btnTampil.Size = New System.Drawing.Size(130, 38)
            Me.btnTampil.TabIndex = 5
            Me.btnTampil.Text = "Tampilkan"
            Me.btnTampil.UseTransparentBackground = True
            '
            'pnlWrap
            '
            Me.pnlWrap.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlWrap.Controls.Add(Me.card)
            Me.pnlWrap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlWrap.Location = New System.Drawing.Point(0, 64)
            Me.pnlWrap.Name = "pnlWrap"
            Me.pnlWrap.Padding = New System.Windows.Forms.Padding(18)
            Me.pnlWrap.Size = New System.Drawing.Size(1060, 556)
            Me.pnlWrap.TabIndex = 1
            '
            'card
            '
            Me.card.BackColor = System.Drawing.Color.Transparent
            Me.card.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.card.BorderRadius = 16
            Me.card.BorderThickness = 1
            Me.card.Controls.Add(Me.dgvLog)
            Me.card.Dock = System.Windows.Forms.DockStyle.Fill
            Me.card.FillColor = System.Drawing.Color.White
            Me.card.Location = New System.Drawing.Point(18, 18)
            Me.card.Name = "card"
            Me.card.Padding = New System.Windows.Forms.Padding(14)
            Me.card.Size = New System.Drawing.Size(1024, 520)
            Me.card.TabIndex = 0
            Me.card.UseTransparentBackground = True
            '
            'dgvLog
            '
            Me.dgvLog.AllowUserToAddRows = False
            Me.dgvLog.AllowUserToDeleteRows = False
            Me.dgvLog.AutoGenerateColumns = False
            Me.dgvLog.BackgroundColor = System.Drawing.Color.White
            Me.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvLog.ColumnHeadersHeight = 40
            Me.dgvLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colWaktu, Me.colPengguna, Me.colAksi, Me.colKet})
            Me.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvLog.Location = New System.Drawing.Point(14, 14)
            Me.dgvLog.MultiSelect = False
            Me.dgvLog.Name = "dgvLog"
            Me.dgvLog.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvLog.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvLog.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvLog.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvLog.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvLog.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvLog.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvLog.ThemeStyle.RowsStyle.Height = 40
            Me.dgvLog.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvLog.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvLog.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvLog.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvLog.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvLog.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvLog.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvLog.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvLog.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvLog.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvLog.ReadOnly = True
            Me.dgvLog.RowHeadersVisible = False
            Me.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvLog.Size = New System.Drawing.Size(996, 492)
            Me.dgvLog.TabIndex = 0
            Me.dgvLog.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light
            '
            'colWaktu
            '
            Me.colWaktu.DataPropertyName = "waktu"
            DataGridViewCellStyle1.Format = "dd MMM yyyy HH:mm:ss"
            Me.colWaktu.DefaultCellStyle = DataGridViewCellStyle1
            Me.colWaktu.HeaderText = "Waktu"
            Me.colWaktu.Name = "colWaktu"
            Me.colWaktu.ReadOnly = True
            Me.colWaktu.Width = 160
            '
            'colPengguna
            '
            Me.colPengguna.DataPropertyName = "pengguna"
            Me.colPengguna.HeaderText = "Pengguna"
            Me.colPengguna.Name = "colPengguna"
            Me.colPengguna.ReadOnly = True
            Me.colPengguna.Width = 165
            '
            'colAksi
            '
            Me.colAksi.DataPropertyName = "aksi"
            Me.colAksi.HeaderText = "Kode Aksi"
            Me.colAksi.Name = "colAksi"
            Me.colAksi.ReadOnly = True
            Me.colAksi.Width = 160
            '
            'colKet
            '
            Me.colKet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colKet.DataPropertyName = "keterangan"
            Me.colKet.HeaderText = "Keterangan"
            Me.colKet.Name = "colKet"
            Me.colKet.ReadOnly = True
            '
            'FrmLog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1060, 620)
            Me.Controls.Add(Me.pnlWrap)
            Me.Controls.Add(Me.pnlTop)
            Me.Name = "FrmLog"
            Me.Text = "Log Aktivitas Sistem (Audit Trail)"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlWrap.ResumeLayout(False)
            Me.card.ResumeLayout(False)
            CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents lblDari As System.Windows.Forms.Label
        Friend WithEvents dtpDari As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblSampai As System.Windows.Forms.Label
        Friend WithEvents dtpSampai As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtCari As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnTampil As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlWrap As System.Windows.Forms.Panel
        Friend WithEvents card As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvLog As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colWaktu As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPengguna As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAksi As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colKet As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
