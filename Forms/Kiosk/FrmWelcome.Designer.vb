Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmWelcome
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
            Me.pnlTop = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnDemo = New Guna.UI2.WinForms.Guna2Button()
            Me.btnStaff = New Guna.UI2.WinForms.Guna2Button()
            Me.btnFullscreen = New Guna.UI2.WinForms.Guna2Button()
            Me.btnBahasa = New Guna.UI2.WinForms.Guna2Button()
            Me.lblSubBrand = New System.Windows.Forms.Label()
            Me.lblBrand = New System.Windows.Forms.Label()
            Me.picLogo = New System.Windows.Forms.PictureBox()
            Me.pnlBannerCard = New Guna.UI2.WinForms.Guna2Panel()
            Me.pnlDots = New System.Windows.Forms.FlowLayoutPanel()
            Me.picBanner = New Guna.UI2.WinForms.Guna2PictureBox()
            Me.lblTagline = New System.Windows.Forms.Label()
            Me.lblPilih = New System.Windows.Forms.Label()
            Me.btnDineIn = New Guna.UI2.WinForms.Guna2Button()
            Me.btnTakeAway = New Guna.UI2.WinForms.Guna2Button()
            Me.lblFooterHint = New System.Windows.Forms.Label()
            Me.pnlTop.SuspendLayout()
            CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBannerCard.SuspendLayout()
            CType(Me.picBanner, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlTop.Controls.Add(Me.btnDemo)
            Me.pnlTop.Controls.Add(Me.btnStaff)
            Me.pnlTop.Controls.Add(Me.btnFullscreen)
            Me.pnlTop.Controls.Add(Me.btnBahasa)
            Me.pnlTop.Controls.Add(Me.lblSubBrand)
            Me.pnlTop.Controls.Add(Me.lblBrand)
            Me.pnlTop.Controls.Add(Me.picLogo)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.BorderRadius = 0
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(24, 14, 24, 14)
            Me.pnlTop.Size = New System.Drawing.Size(1366, 78)
            Me.pnlTop.TabIndex = 0
            '
            'picLogo
            '
            Me.picLogo.BackColor = System.Drawing.Color.Transparent
            Me.picLogo.Cursor = System.Windows.Forms.Cursors.Hand
            Me.picLogo.Location = New System.Drawing.Point(36, 14)
            Me.picLogo.Name = "picLogo"
            Me.picLogo.Size = New System.Drawing.Size(50, 50)
            Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picLogo.TabIndex = 0
            Me.picLogo.TabStop = False
            '
            'lblBrand
            '
            Me.lblBrand.BackColor = System.Drawing.Color.Transparent
            Me.lblBrand.Font = New System.Drawing.Font("Georgia", 15.5!, System.Drawing.FontStyle.Bold)
            Me.lblBrand.ForeColor = System.Drawing.Color.White
            Me.lblBrand.Location = New System.Drawing.Point(98, 16)
            Me.lblBrand.Name = "lblBrand"
            Me.lblBrand.Size = New System.Drawing.Size(380, 26)
            Me.lblBrand.TabIndex = 1
            Me.lblBrand.Text = "Bistro Kiosk Nusantara"
            '
            'lblSubBrand
            '
            Me.lblSubBrand.BackColor = System.Drawing.Color.Transparent
            Me.lblSubBrand.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblSubBrand.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblSubBrand.Location = New System.Drawing.Point(98, 43)
            Me.lblSubBrand.Name = "lblSubBrand"
            Me.lblSubBrand.Size = New System.Drawing.Size(380, 18)
            Me.lblSubBrand.TabIndex = 2
            Me.lblSubBrand.Text = "Warm Modern Bistro  |  Self-Service Terminal"
            '
            'btnBahasa
            '
            Me.btnBahasa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnBahasa.BackColor = System.Drawing.Color.Transparent
            Me.btnBahasa.BorderColor = System.Drawing.Color.FromArgb(88, 60, 46)
            Me.btnBahasa.BorderRadius = 12
            Me.btnBahasa.BorderThickness = 1
            Me.btnBahasa.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBahasa.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnBahasa.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnBahasa.ForeColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.btnBahasa.Location = New System.Drawing.Point(862, 18)
            Me.btnBahasa.Name = "btnBahasa"
            Me.btnBahasa.Size = New System.Drawing.Size(92, 42)
            Me.btnBahasa.TabIndex = 3
            Me.btnBahasa.Text = "ID"
            Me.btnBahasa.UseTransparentBackground = True
            '
            'btnFullscreen
            '
            Me.btnFullscreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnFullscreen.BackColor = System.Drawing.Color.Transparent
            Me.btnFullscreen.BorderColor = System.Drawing.Color.FromArgb(88, 60, 46)
            Me.btnFullscreen.BorderRadius = 12
            Me.btnFullscreen.BorderThickness = 1
            Me.btnFullscreen.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnFullscreen.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnFullscreen.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnFullscreen.ForeColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.btnFullscreen.Location = New System.Drawing.Point(964, 18)
            Me.btnFullscreen.Name = "btnFullscreen"
            Me.btnFullscreen.Size = New System.Drawing.Size(132, 42)
            Me.btnFullscreen.TabIndex = 4
            Me.btnFullscreen.Text = "Layar Penuh"
            Me.btnFullscreen.UseTransparentBackground = True
            '
            'btnStaff
            '
            Me.btnStaff.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnStaff.BackColor = System.Drawing.Color.Transparent
            Me.btnStaff.BorderColor = System.Drawing.Color.FromArgb(88, 60, 46)
            Me.btnStaff.BorderRadius = 12
            Me.btnStaff.BorderThickness = 1
            Me.btnStaff.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnStaff.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnStaff.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnStaff.ForeColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.btnStaff.Location = New System.Drawing.Point(1106, 18)
            Me.btnStaff.Name = "btnStaff"
            Me.btnStaff.Size = New System.Drawing.Size(92, 42)
            Me.btnStaff.TabIndex = 5
            Me.btnStaff.Text = "Staff"
            Me.btnStaff.UseTransparentBackground = True
            '
            'btnDemo
            '
            Me.btnDemo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDemo.BackColor = System.Drawing.Color.Transparent
            Me.btnDemo.BorderRadius = 12
            Me.btnDemo.BorderThickness = 0
            Me.btnDemo.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDemo.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnDemo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnDemo.ForeColor = System.Drawing.Color.White
            Me.btnDemo.Location = New System.Drawing.Point(1208, 18)
            Me.btnDemo.Name = "btnDemo"
            Me.btnDemo.Size = New System.Drawing.Size(122, 42)
            Me.btnDemo.TabIndex = 6
            Me.btnDemo.Text = "Demo (F9)"
            Me.btnDemo.UseTransparentBackground = True
            '
            'pnlBannerCard
            '
            Me.pnlBannerCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlBannerCard.BackColor = System.Drawing.Color.Transparent
            Me.pnlBannerCard.BorderRadius = 18
            Me.pnlBannerCard.BorderThickness = 0
            Me.pnlBannerCard.Controls.Add(Me.pnlDots)
            Me.pnlBannerCard.Controls.Add(Me.picBanner)
            Me.pnlBannerCard.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlBannerCard.Location = New System.Drawing.Point(36, 98)
            Me.pnlBannerCard.Name = "pnlBannerCard"
            Me.pnlBannerCard.Size = New System.Drawing.Size(1294, 356)
            Me.pnlBannerCard.TabIndex = 1
            Me.pnlBannerCard.UseTransparentBackground = True
            '
            'picBanner
            '
            Me.picBanner.BackColor = System.Drawing.Color.Transparent
            Me.picBanner.BorderRadius = 18
            Me.picBanner.Dock = System.Windows.Forms.DockStyle.Fill
            Me.picBanner.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.picBanner.Location = New System.Drawing.Point(0, 0)
            Me.picBanner.Name = "picBanner"
            Me.picBanner.Size = New System.Drawing.Size(1294, 356)
            Me.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.picBanner.TabIndex = 0
            Me.picBanner.TabStop = False
            Me.picBanner.UseTransparentBackground = True
            '
            'pnlDots
            '
            Me.pnlDots.BackColor = System.Drawing.Color.Transparent
            Me.pnlDots.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
            Me.pnlDots.Location = New System.Drawing.Point(34, 308)
            Me.pnlDots.Name = "pnlDots"
            Me.pnlDots.Size = New System.Drawing.Size(220, 26)
            Me.pnlDots.TabIndex = 1
            '
            'lblTagline
            '
            Me.lblTagline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTagline.BackColor = System.Drawing.Color.Transparent
            Me.lblTagline.Font = New System.Drawing.Font("Georgia", 21.0!, System.Drawing.FontStyle.Bold)
            Me.lblTagline.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblTagline.Location = New System.Drawing.Point(36, 472)
            Me.lblTagline.Name = "lblTagline"
            Me.lblTagline.Size = New System.Drawing.Size(1294, 42)
            Me.lblTagline.TabIndex = 2
            Me.lblTagline.Text = "Rasa Hangat, Pesan Cepat Tanpa Antre"
            Me.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPilih
            '
            Me.lblPilih.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPilih.BackColor = System.Drawing.Color.Transparent
            Me.lblPilih.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPilih.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblPilih.Location = New System.Drawing.Point(36, 514)
            Me.lblPilih.Name = "lblPilih"
            Me.lblPilih.Size = New System.Drawing.Size(1294, 26)
            Me.lblPilih.TabIndex = 3
            Me.lblPilih.Text = "Pilih cara bersantap Anda untuk mulai memesan"
            Me.lblPilih.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnDineIn
            '
            Me.btnDineIn.Animated = True
            Me.btnDineIn.BackColor = System.Drawing.Color.Transparent
            Me.btnDineIn.BorderRadius = 16
            Me.btnDineIn.BorderThickness = 0
            Me.btnDineIn.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDineIn.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnDineIn.Font = New System.Drawing.Font("Georgia", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnDineIn.ForeColor = System.Drawing.Color.White
            Me.btnDineIn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnDineIn.ImageOffset = New System.Drawing.Point(24, 0)
            Me.btnDineIn.ImageSize = New System.Drawing.Size(38, 38)
            Me.btnDineIn.Location = New System.Drawing.Point(36, 554)
            Me.btnDineIn.Name = "btnDineIn"
            Me.btnDineIn.Size = New System.Drawing.Size(633, 140)
            Me.btnDineIn.TabIndex = 4
            Me.btnDineIn.Text = "Makan di Tempat" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Disajikan hangat di meja"
            Me.btnDineIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnDineIn.TextOffset = New System.Drawing.Point(22, 0)
            Me.btnDineIn.UseTransparentBackground = True
            '
            'btnTakeAway
            '
            Me.btnTakeAway.Animated = True
            Me.btnTakeAway.BackColor = System.Drawing.Color.Transparent
            Me.btnTakeAway.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnTakeAway.BorderRadius = 16
            Me.btnTakeAway.BorderThickness = 1
            Me.btnTakeAway.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTakeAway.FillColor = System.Drawing.Color.White
            Me.btnTakeAway.Font = New System.Drawing.Font("Georgia", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnTakeAway.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnTakeAway.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnTakeAway.ImageOffset = New System.Drawing.Point(24, 0)
            Me.btnTakeAway.ImageSize = New System.Drawing.Size(38, 38)
            Me.btnTakeAway.Location = New System.Drawing.Point(697, 554)
            Me.btnTakeAway.Name = "btnTakeAway"
            Me.btnTakeAway.Size = New System.Drawing.Size(633, 140)
            Me.btnTakeAway.TabIndex = 5
            Me.btnTakeAway.Text = "Bawa Pulang" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Kemasan praktis siap bawa"
            Me.btnTakeAway.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnTakeAway.TextOffset = New System.Drawing.Point(22, 0)
            Me.btnTakeAway.UseTransparentBackground = True
            '
            'lblFooterHint
            '
            Me.lblFooterHint.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblFooterHint.BackColor = System.Drawing.Color.Transparent
            Me.lblFooterHint.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblFooterHint.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblFooterHint.Location = New System.Drawing.Point(36, 738)
            Me.lblFooterHint.Name = "lblFooterHint"
            Me.lblFooterHint.Size = New System.Drawing.Size(1294, 24)
            Me.lblFooterHint.TabIndex = 6
            Me.lblFooterHint.Text = "Akses Staff: tekan Ctrl+Alt+F12 atau klik logo 5x  |  Layar Penuh: F11  |  Demo Hub: F9"
            Me.lblFooterHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'FrmWelcome
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1366, 820)
            Me.Controls.Add(Me.lblFooterHint)
            Me.Controls.Add(Me.btnTakeAway)
            Me.Controls.Add(Me.btnDineIn)
            Me.Controls.Add(Me.lblPilih)
            Me.Controls.Add(Me.lblTagline)
            Me.Controls.Add(Me.pnlBannerCard)
            Me.Controls.Add(Me.pnlTop)
            Me.MinimumSize = New System.Drawing.Size(1060, 680)
            Me.Name = "FrmWelcome"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Bistro Kiosk Nusantara — Self-Ordering Kiosk"
            Me.pnlTop.ResumeLayout(False)
            CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBannerCard.ResumeLayout(False)
            CType(Me.picBanner, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlTop As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picLogo As System.Windows.Forms.PictureBox
        Friend WithEvents lblBrand As System.Windows.Forms.Label
        Friend WithEvents lblSubBrand As System.Windows.Forms.Label
        Friend WithEvents btnBahasa As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnFullscreen As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnStaff As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemo As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlBannerCard As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picBanner As Guna.UI2.WinForms.Guna2PictureBox
        Friend WithEvents pnlDots As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents lblTagline As System.Windows.Forms.Label
        Friend WithEvents lblPilih As System.Windows.Forms.Label
        Friend WithEvents btnDineIn As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnTakeAway As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblFooterHint As System.Windows.Forms.Label
    End Class
End Namespace
