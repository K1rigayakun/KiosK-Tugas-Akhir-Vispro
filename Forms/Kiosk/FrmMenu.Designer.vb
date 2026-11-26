Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmMenu
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
            Me.btnBahasa = New Guna.UI2.WinForms.Guna2Button()
            Me.btnFullscreen = New Guna.UI2.WinForms.Guna2Button()
            Me.txtCari = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblTipeMakan = New Guna.UI2.WinForms.Guna2Button()
            Me.lblBrand = New System.Windows.Forms.Label()
            Me.picLogo = New System.Windows.Forms.PictureBox()
            Me.btnToggleSidebar = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlBawah = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnKeranjang = New Guna.UI2.WinForms.Guna2Button()
            Me.btnBatalPesanan = New Guna.UI2.WinForms.Guna2Button()
            Me.lblTotalCart = New System.Windows.Forms.Label()
            Me.lblRingkasCart = New System.Windows.Forms.Label()
            Me.icCart = New System.Windows.Forms.PictureBox()
            Me.pnlSidebar = New Guna.UI2.WinForms.Guna2Panel()
            Me.flpKategori = New System.Windows.Forms.FlowLayoutPanel()
            Me.flpProduk = New System.Windows.Forms.FlowLayoutPanel()
            Me.pnlKosong = New System.Windows.Forms.Label()
            Me.pnlTop.SuspendLayout()
            CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBawah.SuspendLayout()
            CType(Me.icCart, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlSidebar.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlTop.Controls.Add(Me.btnDemo)
            Me.pnlTop.Controls.Add(Me.btnBahasa)
            Me.pnlTop.Controls.Add(Me.btnFullscreen)
            Me.pnlTop.Controls.Add(Me.txtCari)
            Me.pnlTop.Controls.Add(Me.lblTipeMakan)
            Me.pnlTop.Controls.Add(Me.lblBrand)
            Me.pnlTop.Controls.Add(Me.picLogo)
            Me.pnlTop.Controls.Add(Me.btnToggleSidebar)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(16, 14, 16, 14)
            Me.pnlTop.Size = New System.Drawing.Size(1366, 76)
            Me.pnlTop.TabIndex = 0
            '
            'btnToggleSidebar
            '
            Me.btnToggleSidebar.BackColor = System.Drawing.Color.Transparent
            Me.btnToggleSidebar.BorderRadius = 8
            Me.btnToggleSidebar.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnToggleSidebar.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnToggleSidebar.Location = New System.Drawing.Point(16, 17)
            Me.btnToggleSidebar.Name = "btnToggleSidebar"
            Me.btnToggleSidebar.Size = New System.Drawing.Size(42, 42)
            Me.btnToggleSidebar.TabIndex = 0
            Me.btnToggleSidebar.UseTransparentBackground = True
            '
            'picLogo
            '
            Me.picLogo.BackColor = System.Drawing.Color.Transparent
            Me.picLogo.Location = New System.Drawing.Point(70, 16)
            Me.picLogo.Name = "picLogo"
            Me.picLogo.Size = New System.Drawing.Size(44, 44)
            Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picLogo.TabIndex = 1
            Me.picLogo.TabStop = False
            '
            'lblBrand
            '
            Me.lblBrand.BackColor = System.Drawing.Color.Transparent
            Me.lblBrand.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblBrand.ForeColor = System.Drawing.Color.White
            Me.lblBrand.Location = New System.Drawing.Point(122, 13)
            Me.lblBrand.Name = "lblBrand"
            Me.lblBrand.Size = New System.Drawing.Size(262, 26)
            Me.lblBrand.TabIndex = 2
            Me.lblBrand.Text = "Bistro Kiosk Nusantara"
            '
            'lblTipeMakan
            '
            Me.lblTipeMakan.BackColor = System.Drawing.Color.Transparent
            Me.lblTipeMakan.BorderRadius = 8
            Me.lblTipeMakan.DisabledState.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblTipeMakan.DisabledState.ForeColor = System.Drawing.Color.White
            Me.lblTipeMakan.Enabled = False
            Me.lblTipeMakan.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblTipeMakan.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
            Me.lblTipeMakan.ForeColor = System.Drawing.Color.White
            Me.lblTipeMakan.Location = New System.Drawing.Point(122, 41)
            Me.lblTipeMakan.Name = "lblTipeMakan"
            Me.lblTipeMakan.Size = New System.Drawing.Size(130, 22)
            Me.lblTipeMakan.TabIndex = 3
            Me.lblTipeMakan.Text = "DINE IN"
            Me.lblTipeMakan.UseTransparentBackground = True
            '
            'txtCari
            '
            Me.txtCari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtCari.BackColor = System.Drawing.Color.Transparent
            Me.txtCari.BorderColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtCari.BorderRadius = 10
            Me.txtCari.FillColor = System.Drawing.Color.White
            Me.txtCari.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtCari.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtCari.IconLeftSize = New System.Drawing.Size(16, 16)
            Me.txtCari.Location = New System.Drawing.Point(392, 17)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderText = "Cari menu favorit Anda..."
            Me.txtCari.Size = New System.Drawing.Size(660, 42)
            Me.txtCari.TabIndex = 4
            Me.txtCari.BorderThickness = 1
            '
            'btnFullscreen
            '
            Me.btnFullscreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnFullscreen.BackColor = System.Drawing.Color.Transparent
            Me.btnFullscreen.BorderColor = System.Drawing.Color.FromArgb(88, 60, 46)
            Me.btnFullscreen.BorderRadius = 10
            Me.btnFullscreen.BorderThickness = 1
            Me.btnFullscreen.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnFullscreen.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnFullscreen.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnFullscreen.ForeColor = System.Drawing.Color.White
            Me.btnFullscreen.Location = New System.Drawing.Point(1062, 17)
            Me.btnFullscreen.Name = "btnFullscreen"
            Me.btnFullscreen.Size = New System.Drawing.Size(48, 42)
            Me.btnFullscreen.TabIndex = 5
            Me.btnFullscreen.UseTransparentBackground = True
            '
            'btnBahasa
            '
            Me.btnBahasa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnBahasa.BackColor = System.Drawing.Color.Transparent
            Me.btnBahasa.BorderColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.btnBahasa.BorderRadius = 10
            Me.btnBahasa.BorderThickness = 1
            Me.btnBahasa.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBahasa.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnBahasa.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnBahasa.ForeColor = System.Drawing.Color.White
            Me.btnBahasa.Location = New System.Drawing.Point(1120, 17)
            Me.btnBahasa.Name = "btnBahasa"
            Me.btnBahasa.Size = New System.Drawing.Size(96, 42)
            Me.btnBahasa.TabIndex = 5
            Me.btnBahasa.Text = "ID"
            Me.btnBahasa.UseTransparentBackground = True
            '
            'btnDemo
            '
            Me.btnDemo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDemo.BackColor = System.Drawing.Color.Transparent
            Me.btnDemo.BorderRadius = 10
            Me.btnDemo.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDemo.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnDemo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnDemo.ForeColor = System.Drawing.Color.White
            Me.btnDemo.Location = New System.Drawing.Point(1224, 17)
            Me.btnDemo.Name = "btnDemo"
            Me.btnDemo.Size = New System.Drawing.Size(124, 42)
            Me.btnDemo.TabIndex = 6
            Me.btnDemo.BorderColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.btnDemo.BorderThickness = 2
            Me.btnDemo.Text = "Demo (F9)"
            Me.btnDemo.UseTransparentBackground = True
            '
            'pnlBawah
            '
            Me.pnlBawah.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlBawah.Controls.Add(Me.btnKeranjang)
            Me.pnlBawah.Controls.Add(Me.btnBatalPesanan)
            Me.pnlBawah.Controls.Add(Me.lblTotalCart)
            Me.pnlBawah.Controls.Add(Me.lblRingkasCart)
            Me.pnlBawah.Controls.Add(Me.icCart)
            Me.pnlBawah.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBawah.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlBawah.Location = New System.Drawing.Point(0, 738)
            Me.pnlBawah.Name = "pnlBawah"
            Me.pnlBawah.Padding = New System.Windows.Forms.Padding(24, 12, 24, 12)
            Me.pnlBawah.Size = New System.Drawing.Size(1366, 82)
            Me.pnlBawah.TabIndex = 1
            '
            'icCart
            '
            Me.icCart.BackColor = System.Drawing.Color.Transparent
            Me.icCart.Location = New System.Drawing.Point(26, 22)
            Me.icCart.Name = "icCart"
            Me.icCart.Size = New System.Drawing.Size(36, 36)
            Me.icCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icCart.TabIndex = 0
            Me.icCart.TabStop = False
            '
            'lblRingkasCart
            '
            Me.lblRingkasCart.BackColor = System.Drawing.Color.Transparent
            Me.lblRingkasCart.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblRingkasCart.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.lblRingkasCart.Location = New System.Drawing.Point(72, 16)
            Me.lblRingkasCart.Name = "lblRingkasCart"
            Me.lblRingkasCart.Size = New System.Drawing.Size(420, 22)
            Me.lblRingkasCart.TabIndex = 1
            Me.lblRingkasCart.Text = "Keranjang masih kosong"
            '
            'lblTotalCart
            '
            Me.lblTotalCart.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalCart.Font = New System.Drawing.Font("Georgia", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotalCart.ForeColor = System.Drawing.Color.White
            Me.lblTotalCart.Location = New System.Drawing.Point(72, 38)
            Me.lblTotalCart.Name = "lblTotalCart"
            Me.lblTotalCart.Size = New System.Drawing.Size(420, 30)
            Me.lblTotalCart.TabIndex = 2
            Me.lblTotalCart.Text = "Rp0"
            '
            'btnBatalPesanan
            '
            Me.btnBatalPesanan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnBatalPesanan.BackColor = System.Drawing.Color.Transparent
            Me.btnBatalPesanan.BorderColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.btnBatalPesanan.BorderRadius = 10
            Me.btnBatalPesanan.BorderThickness = 1
            Me.btnBatalPesanan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBatalPesanan.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnBatalPesanan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnBatalPesanan.ForeColor = System.Drawing.Color.White
            Me.btnBatalPesanan.Location = New System.Drawing.Point(910, 13)
            Me.btnBatalPesanan.Name = "btnBatalPesanan"
            Me.btnBatalPesanan.Size = New System.Drawing.Size(176, 56)
            Me.btnBatalPesanan.TabIndex = 3
            Me.btnBatalPesanan.Text = "Batalkan Pesanan"
            Me.btnBatalPesanan.UseTransparentBackground = True
            '
            'btnKeranjang
            '
            Me.btnKeranjang.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnKeranjang.BackColor = System.Drawing.Color.Transparent
            Me.btnKeranjang.BorderColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.btnKeranjang.BorderRadius = 10
            Me.btnKeranjang.BorderThickness = 2
            Me.btnKeranjang.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKeranjang.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnKeranjang.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnKeranjang.ForeColor = System.Drawing.Color.White
            Me.btnKeranjang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.btnKeranjang.ImageOffset = New System.Drawing.Point(8, 0)
            Me.btnKeranjang.Location = New System.Drawing.Point(1100, 13)
            Me.btnKeranjang.Name = "btnKeranjang"
            Me.btnKeranjang.Size = New System.Drawing.Size(242, 56)
            Me.btnKeranjang.TabIndex = 4
            Me.btnKeranjang.Text = "Lihat Keranjang"
            Me.btnKeranjang.UseTransparentBackground = True
            '
            'pnlSidebar
            '
            Me.pnlSidebar.BackColor = System.Drawing.Color.White
            Me.pnlSidebar.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.pnlSidebar.BorderThickness = 1
            Me.pnlSidebar.Controls.Add(Me.flpKategori)
            Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlSidebar.FillColor = System.Drawing.Color.White
            Me.pnlSidebar.Location = New System.Drawing.Point(0, 76)
            Me.pnlSidebar.Name = "pnlSidebar"
            Me.pnlSidebar.Padding = New System.Windows.Forms.Padding(10, 14, 10, 14)
            Me.pnlSidebar.Size = New System.Drawing.Size(232, 662)
            Me.pnlSidebar.TabIndex = 2
            '
            'flpKategori
            '
            Me.flpKategori.AutoScroll = True
            Me.flpKategori.BackColor = System.Drawing.Color.Transparent
            Me.flpKategori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpKategori.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.flpKategori.Location = New System.Drawing.Point(10, 14)
            Me.flpKategori.Name = "flpKategori"
            Me.flpKategori.Size = New System.Drawing.Size(212, 634)
            Me.flpKategori.TabIndex = 0
            Me.flpKategori.WrapContents = False
            '
            'flpProduk
            '
            Me.flpProduk.AutoScroll = True
            Me.flpProduk.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.flpProduk.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpProduk.Location = New System.Drawing.Point(232, 76)
            Me.flpProduk.Name = "flpProduk"
            Me.flpProduk.Padding = New System.Windows.Forms.Padding(18, 16, 18, 16)
            Me.flpProduk.Size = New System.Drawing.Size(1134, 662)
            Me.flpProduk.TabIndex = 3
            '
            'pnlKosong
            '
            Me.pnlKosong.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlKosong.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKosong.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold)
            Me.pnlKosong.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.pnlKosong.Location = New System.Drawing.Point(232, 76)
            Me.pnlKosong.Name = "pnlKosong"
            Me.pnlKosong.Size = New System.Drawing.Size(1134, 662)
            Me.pnlKosong.TabIndex = 4
            Me.pnlKosong.Text = "Tidak ada menu yang cocok dengan pencarian Anda."
            Me.pnlKosong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.pnlKosong.Visible = False
            '
            'FrmMenu
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1366, 820)
            Me.Controls.Add(Me.flpProduk)
            Me.Controls.Add(Me.pnlKosong)
            Me.Controls.Add(Me.pnlSidebar)
            Me.Controls.Add(Me.pnlBawah)
            Me.Controls.Add(Me.pnlTop)
            Me.MinimumSize = New System.Drawing.Size(1060, 680)
            Me.Name = "FrmMenu"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Bistro Kiosk - Menu Pemesanan"
            Me.pnlTop.ResumeLayout(False)
            CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBawah.ResumeLayout(False)
            CType(Me.icCart, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlSidebar.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlTop As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents btnToggleSidebar As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents picLogo As System.Windows.Forms.PictureBox
        Friend WithEvents lblBrand As System.Windows.Forms.Label
        Friend WithEvents lblTipeMakan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents txtCari As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnFullscreen As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnBahasa As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemo As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlBawah As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icCart As System.Windows.Forms.PictureBox
        Friend WithEvents lblRingkasCart As System.Windows.Forms.Label
        Friend WithEvents lblTotalCart As System.Windows.Forms.Label
        Friend WithEvents btnBatalPesanan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnKeranjang As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlSidebar As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents flpKategori As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents flpProduk As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents pnlKosong As System.Windows.Forms.Label
    End Class
End Namespace

