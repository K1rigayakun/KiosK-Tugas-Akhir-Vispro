Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Umum

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmLogin
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
            Me.components = New System.ComponentModel.Container()
            Me.errLogin = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.rootCard = New Guna.UI2.WinForms.Guna2Panel()
            Me.pnlKiri = New Guna.UI2.WinForms.Guna2Panel()
            Me.picLogo = New System.Windows.Forms.PictureBox()
            Me.lblBrand = New System.Windows.Forms.Label()
            Me.lblDesc = New System.Windows.Forms.Label()
            Me.lblDbStatus = New System.Windows.Forms.Label()
            Me.lblCreds = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblSub = New System.Windows.Forms.Label()
            Me.lblUser = New System.Windows.Forms.Label()
            Me.txtUsername = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblPass = New System.Windows.Forms.Label()
            Me.txtPassword = New Guna.UI2.WinForms.Guna2TextBox()
            Me.chkLihatPass = New System.Windows.Forms.CheckBox()
            Me.btnDemoAdmin = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoKasir = New Guna.UI2.WinForms.Guna2Button()
            Me.lblPesan = New System.Windows.Forms.Label()
            Me.btnBatal = New Guna.UI2.WinForms.Guna2Button()
            Me.btnMasuk = New Guna.UI2.WinForms.Guna2Button()
            CType(Me.errLogin, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.rootCard.SuspendLayout()
            Me.pnlKiri.SuspendLayout()
            CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'errLogin
            '
            Me.errLogin.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            Me.errLogin.ContainerControl = Me
            '
            'rootCard
            '
            Me.rootCard.BackColor = System.Drawing.Color.Transparent
            Me.rootCard.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.rootCard.BorderRadius = 16
            Me.rootCard.BorderThickness = 1
            Me.rootCard.Controls.Add(Me.pnlKiri)
            Me.rootCard.Controls.Add(Me.lblTitle)
            Me.rootCard.Controls.Add(Me.lblSub)
            Me.rootCard.Controls.Add(Me.lblUser)
            Me.rootCard.Controls.Add(Me.txtUsername)
            Me.rootCard.Controls.Add(Me.lblPass)
            Me.rootCard.Controls.Add(Me.txtPassword)
            Me.rootCard.Controls.Add(Me.chkLihatPass)
            Me.rootCard.Controls.Add(Me.btnDemoAdmin)
            Me.rootCard.Controls.Add(Me.btnDemoKasir)
            Me.rootCard.Controls.Add(Me.lblPesan)
            Me.rootCard.Controls.Add(Me.btnBatal)
            Me.rootCard.Controls.Add(Me.btnMasuk)
            Me.rootCard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.rootCard.FillColor = System.Drawing.Color.White
            Me.rootCard.Location = New System.Drawing.Point(0, 0)
            Me.rootCard.Name = "rootCard"
            Me.rootCard.Size = New System.Drawing.Size(780, 470)
            Me.rootCard.TabIndex = 0
            Me.rootCard.UseTransparentBackground = True
            '
            'pnlKiri
            '
            Me.pnlKiri.BackColor = System.Drawing.Color.Transparent
            Me.pnlKiri.BorderRadius = 12
            Me.pnlKiri.CustomizableEdges.BottomRight = False
            Me.pnlKiri.CustomizableEdges.TopRight = False
            Me.pnlKiri.Controls.Add(Me.picLogo)
            Me.pnlKiri.Controls.Add(Me.lblBrand)
            Me.pnlKiri.Controls.Add(Me.lblDesc)
            Me.pnlKiri.Controls.Add(Me.lblDbStatus)
            Me.pnlKiri.Controls.Add(Me.lblCreds)
            Me.pnlKiri.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlKiri.Location = New System.Drawing.Point(0, 0)
            Me.pnlKiri.Name = "pnlKiri"
            Me.pnlKiri.Size = New System.Drawing.Size(310, 470)
            Me.pnlKiri.TabIndex = 0
            Me.pnlKiri.UseTransparentBackground = True
            '
            'picLogo
            '
            Me.picLogo.BackColor = System.Drawing.Color.Transparent
            Me.picLogo.Location = New System.Drawing.Point(105, 44)
            Me.picLogo.Name = "picLogo"
            Me.picLogo.Size = New System.Drawing.Size(96, 96)
            Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picLogo.TabIndex = 0
            Me.picLogo.TabStop = False
            '
            'lblBrand
            '
            Me.lblBrand.BackColor = System.Drawing.Color.Transparent
            Me.lblBrand.Font = New System.Drawing.Font("Georgia", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblBrand.ForeColor = System.Drawing.Color.White
            Me.lblBrand.Location = New System.Drawing.Point(24, 154)
            Me.lblBrand.Name = "lblBrand"
            Me.lblBrand.Size = New System.Drawing.Size(262, 46)
            Me.lblBrand.TabIndex = 1
            Me.lblBrand.Text = "Bistro Staff Portal"
            Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDesc
            '
            Me.lblDesc.BackColor = System.Drawing.Color.Transparent
            Me.lblDesc.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblDesc.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.lblDesc.Location = New System.Drawing.Point(26, 206)
            Me.lblDesc.Name = "lblDesc"
            Me.lblDesc.Size = New System.Drawing.Size(258, 66)
            Me.lblDesc.TabIndex = 2
            Me.lblDesc.Text = "Akses operasional Kasir, Dapur, Layar Antrian, dan Administrasi Back Office."
            Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblDbStatus
            '
            Me.lblDbStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblDbStatus.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
            Me.lblDbStatus.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblDbStatus.Location = New System.Drawing.Point(24, 286)
            Me.lblDbStatus.Name = "lblDbStatus"
            Me.lblDbStatus.Size = New System.Drawing.Size(262, 24)
            Me.lblDbStatus.TabIndex = 3
            Me.lblDbStatus.Text = "Mode: Memeriksa Koneksi..."
            Me.lblDbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCreds
            '
            Me.lblCreds.BackColor = System.Drawing.Color.Transparent
            Me.lblCreds.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblCreds.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.lblCreds.Location = New System.Drawing.Point(24, 336)
            Me.lblCreds.Name = "lblCreds"
            Me.lblCreds.Size = New System.Drawing.Size(262, 92)
            Me.lblCreds.TabIndex = 4
            Me.lblCreds.Text = "Akun Simulasi Demo:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Admin: admin / admin123" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Kasir: kasir1 / kasir123"
            Me.lblCreds.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblTitle
            '
            Me.lblTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblTitle.Font = New System.Drawing.Font("Georgia", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblTitle.Location = New System.Drawing.Point(346, 36)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(390, 34)
            Me.lblTitle.TabIndex = 1
            Me.lblTitle.Text = "Masuk ke Mode Staff"
            '
            'lblSub
            '
            Me.lblSub.BackColor = System.Drawing.Color.Transparent
            Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSub.Location = New System.Drawing.Point(346, 72)
            Me.lblSub.Name = "lblSub"
            Me.lblSub.Size = New System.Drawing.Size(390, 24)
            Me.lblSub.TabIndex = 2
            Me.lblSub.Text = "Peran akun (Admin / Kasir) ditentukan otomatis."
            '
            'lblUser
            '
            Me.lblUser.BackColor = System.Drawing.Color.Transparent
            Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblUser.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblUser.Location = New System.Drawing.Point(346, 114)
            Me.lblUser.Name = "lblUser"
            Me.lblUser.Size = New System.Drawing.Size(380, 20)
            Me.lblUser.TabIndex = 3
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
            Me.txtUsername.Location = New System.Drawing.Point(346, 138)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.PlaceholderText = "Masukkan username..."
            Me.txtUsername.Size = New System.Drawing.Size(390, 42)
            Me.txtUsername.TabIndex = 4
            Me.txtUsername.BorderThickness = 1
            '
            'lblPass
            '
            Me.lblPass.BackColor = System.Drawing.Color.Transparent
            Me.lblPass.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblPass.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblPass.Location = New System.Drawing.Point(346, 194)
            Me.lblPass.Name = "lblPass"
            Me.lblPass.Size = New System.Drawing.Size(380, 20)
            Me.lblPass.TabIndex = 5
            Me.lblPass.Text = "Password"
            '
            'txtPassword
            '
            Me.txtPassword.BackColor = System.Drawing.Color.Transparent
            Me.txtPassword.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtPassword.BorderRadius = 12
            Me.txtPassword.DefaultText = ""
            Me.txtPassword.FillColor = System.Drawing.Color.White
            Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtPassword.Location = New System.Drawing.Point(346, 218)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.PlaceholderText = "Masukkan password..."
            Me.txtPassword.Size = New System.Drawing.Size(390, 42)
            Me.txtPassword.TabIndex = 6
            Me.txtPassword.BorderThickness = 1
            '
            'chkLihatPass
            '
            Me.chkLihatPass.BackColor = System.Drawing.Color.Transparent
            Me.chkLihatPass.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.chkLihatPass.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.chkLihatPass.Location = New System.Drawing.Point(346, 268)
            Me.chkLihatPass.Name = "chkLihatPass"
            Me.chkLihatPass.Size = New System.Drawing.Size(166, 24)
            Me.chkLihatPass.TabIndex = 7
            Me.chkLihatPass.Text = "Tampilkan password"
            '
            'btnDemoAdmin
            '
            Me.btnDemoAdmin.BackColor = System.Drawing.Color.Transparent
            Me.btnDemoAdmin.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnDemoAdmin.BorderRadius = 10
            Me.btnDemoAdmin.BorderThickness = 1
            Me.btnDemoAdmin.FillColor = System.Drawing.Color.White
            Me.btnDemoAdmin.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
            Me.btnDemoAdmin.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnDemoAdmin.Location = New System.Drawing.Point(524, 265)
            Me.btnDemoAdmin.Name = "btnDemoAdmin"
            Me.btnDemoAdmin.Size = New System.Drawing.Size(102, 28)
            Me.btnDemoAdmin.TabIndex = 8
            Me.btnDemoAdmin.Text = "Isi Admin"
            Me.btnDemoAdmin.UseTransparentBackground = True
            '
            'btnDemoKasir
            '
            Me.btnDemoKasir.BackColor = System.Drawing.Color.Transparent
            Me.btnDemoKasir.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnDemoKasir.BorderRadius = 10
            Me.btnDemoKasir.BorderThickness = 1
            Me.btnDemoKasir.FillColor = System.Drawing.Color.White
            Me.btnDemoKasir.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
            Me.btnDemoKasir.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnDemoKasir.Location = New System.Drawing.Point(634, 265)
            Me.btnDemoKasir.Name = "btnDemoKasir"
            Me.btnDemoKasir.Size = New System.Drawing.Size(102, 28)
            Me.btnDemoKasir.TabIndex = 9
            Me.btnDemoKasir.Text = "Isi Kasir"
            Me.btnDemoKasir.UseTransparentBackground = True
            '
            'lblPesan
            '
            Me.lblPesan.BackColor = System.Drawing.Color.Transparent
            Me.lblPesan.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblPesan.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.lblPesan.Location = New System.Drawing.Point(346, 302)
            Me.lblPesan.Name = "lblPesan"
            Me.lblPesan.Size = New System.Drawing.Size(390, 38)
            Me.lblPesan.TabIndex = 10
            '
            'btnBatal
            '
            Me.btnBatal.BackColor = System.Drawing.Color.Transparent
            Me.btnBatal.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnBatal.BorderRadius = 12
            Me.btnBatal.BorderThickness = 1
            Me.btnBatal.FillColor = System.Drawing.Color.White
            Me.btnBatal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnBatal.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnBatal.Location = New System.Drawing.Point(346, 354)
            Me.btnBatal.Name = "btnBatal"
            Me.btnBatal.Size = New System.Drawing.Size(134, 48)
            Me.btnBatal.TabIndex = 11
            Me.btnBatal.Text = "Batal"
            Me.btnBatal.UseTransparentBackground = True
            '
            'btnMasuk
            '
            Me.btnMasuk.BackColor = System.Drawing.Color.Transparent
            Me.btnMasuk.BorderRadius = 12
            Me.btnMasuk.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnMasuk.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnMasuk.ForeColor = System.Drawing.Color.White
            Me.btnMasuk.Location = New System.Drawing.Point(490, 354)
            Me.btnMasuk.Name = "btnMasuk"
            Me.btnMasuk.BorderThickness = 0
            Me.btnMasuk.Size = New System.Drawing.Size(246, 48)
            Me.btnMasuk.TabIndex = 12
            Me.btnMasuk.Text = "Masuk"
            Me.btnMasuk.UseTransparentBackground = True
            '
            'FrmLogin
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(780, 470)
            Me.Controls.Add(Me.rootCard)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmLogin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Masuk Mode Staff"
            CType(Me.errLogin, System.ComponentModel.ISupportInitialize).EndInit()
            Me.rootCard.ResumeLayout(False)
            Me.pnlKiri.ResumeLayout(False)
            CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents errLogin As System.Windows.Forms.ErrorProvider
        Friend WithEvents rootCard As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents pnlKiri As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picLogo As System.Windows.Forms.PictureBox
        Friend WithEvents lblBrand As System.Windows.Forms.Label
        Friend WithEvents lblDesc As System.Windows.Forms.Label
        Friend WithEvents lblDbStatus As System.Windows.Forms.Label
        Friend WithEvents lblCreds As System.Windows.Forms.Label
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSub As System.Windows.Forms.Label
        Friend WithEvents lblUser As System.Windows.Forms.Label
        Friend WithEvents txtUsername As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblPass As System.Windows.Forms.Label
        Friend WithEvents txtPassword As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents chkLihatPass As System.Windows.Forms.CheckBox
        Friend WithEvents btnDemoAdmin As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoKasir As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblPesan As System.Windows.Forms.Label
        Friend WithEvents btnBatal As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnMasuk As Guna.UI2.WinForms.Guna2Button

    End Class
End Namespace
