Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Umum

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmDemoHub
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

        Private Shared Sub ConfigureDemoBtn(b As Guna.UI2.WinForms.Guna2Button, text As String, tabIndex As Integer)
            b.BackColor = System.Drawing.Color.Transparent
            b.BorderColor = System.Drawing.Color.FromArgb(44, 24, 16)
            b.BorderRadius = 10
            b.BorderThickness = 2
            b.Cursor = System.Windows.Forms.Cursors.Hand
            b.FillColor = System.Drawing.Color.FromArgb(255, 250, 240)
            b.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
            b.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            b.Margin = New System.Windows.Forms.Padding(0, 0, 6, 8)
            b.Size = New System.Drawing.Size(246, 38)
            b.TabIndex = tabIndex
            b.Text = "  " & text
            b.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            b.UseTransparentBackground = True
        End Sub

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.card = New Guna.UI2.WinForms.Guna2Panel()
            Me.body = New System.Windows.Forms.TableLayoutPanel()
            Me.col1 = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCol1 = New System.Windows.Forms.Label()
            Me.flpCol1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnDemoWelcome = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoMenu = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoDetail = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoKeranjang = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoBayar = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoStruk = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoIdle = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoRating = New Guna.UI2.WinForms.Guna2Button()
            Me.col2 = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCol2 = New System.Windows.Forms.Label()
            Me.flpCol2 = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnDemoLogin = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoKasir = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoDapur = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoAntrian = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoLog = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoPengguna = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoPengaturan = New Guna.UI2.WinForms.Guna2Button()
            Me.col3 = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCol3 = New System.Windows.Forms.Label()
            Me.flpCol3 = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnDemoDashboard = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoProduk = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoVoucher = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoLaporan = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDemoMember = New Guna.UI2.WinForms.Guna2Button()
            Me.hdr = New Guna.UI2.WinForms.Guna2Panel()
            Me.ic = New System.Windows.Forms.PictureBox()
            Me.lblH = New System.Windows.Forms.Label()
            Me.lblS = New System.Windows.Forms.Label()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.card.SuspendLayout()
            Me.body.SuspendLayout()
            Me.col1.SuspendLayout()
            Me.flpCol1.SuspendLayout()
            Me.col2.SuspendLayout()
            Me.flpCol2.SuspendLayout()
            Me.col3.SuspendLayout()
            Me.flpCol3.SuspendLayout()
            Me.hdr.SuspendLayout()
            CType(Me.ic, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'card
            '
            Me.card.BackColor = System.Drawing.Color.Transparent
            Me.card.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.card.BorderRadius = 16
            Me.card.BorderThickness = 1
            Me.card.Controls.Add(Me.body)
            Me.card.Controls.Add(Me.hdr)
            Me.card.Dock = System.Windows.Forms.DockStyle.Fill
            Me.card.FillColor = System.Drawing.Color.White
            Me.card.Location = New System.Drawing.Point(0, 0)
            Me.card.Name = "card"
            Me.card.Size = New System.Drawing.Size(940, 610)
            Me.card.TabIndex = 0
            Me.card.UseTransparentBackground = True
            '
            'hdr
            '
            Me.hdr.BackColor = System.Drawing.Color.Transparent
            Me.hdr.BorderRadius = 14
            Me.hdr.Controls.Add(Me.ic)
            Me.hdr.Controls.Add(Me.lblH)
            Me.hdr.Controls.Add(Me.lblS)
            Me.hdr.Controls.Add(Me.btnClose)
            Me.hdr.CustomizableEdges.BottomLeft = False
            Me.hdr.CustomizableEdges.BottomRight = False
            Me.hdr.Dock = System.Windows.Forms.DockStyle.Top
            Me.hdr.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.hdr.Location = New System.Drawing.Point(0, 0)
            Me.hdr.Name = "hdr"
            Me.hdr.BorderThickness = 0
            Me.hdr.Size = New System.Drawing.Size(940, 68)
            Me.hdr.TabIndex = 0
            Me.hdr.UseTransparentBackground = True
            '
            'ic
            '
            Me.ic.BackColor = System.Drawing.Color.Transparent
            Me.ic.Location = New System.Drawing.Point(20, 16)
            Me.ic.Name = "ic"
            Me.ic.Size = New System.Drawing.Size(36, 36)
            Me.ic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.ic.TabIndex = 0
            Me.ic.TabStop = False
            '
            'lblH
            '
            Me.lblH.BackColor = System.Drawing.Color.Transparent
            Me.lblH.Font = New System.Drawing.Font("Georgia", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblH.ForeColor = System.Drawing.Color.White
            Me.lblH.Location = New System.Drawing.Point(64, 12)
            Me.lblH.Name = "lblH"
            Me.lblH.Size = New System.Drawing.Size(640, 26)
            Me.lblH.TabIndex = 1
            Me.lblH.Text = "Quick Demo Navigator — 20 Layar (A1 - A5)"
            '
            'lblS
            '
            Me.lblS.BackColor = System.Drawing.Color.Transparent
            Me.lblS.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblS.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.lblS.Location = New System.Drawing.Point(64, 38)
            Me.lblS.Name = "lblS"
            Me.lblS.Size = New System.Drawing.Size(640, 20)
            Me.lblS.TabIndex = 2
            Me.lblS.Text = "Lompat ke layar atau skenario demo mana pun dengan 1 klik (Tekan F9 kapan saja)."
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BackColor = System.Drawing.Color.Transparent
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(88, 60, 46)
            Me.btnClose.BorderRadius = 10
            Me.btnClose.BorderThickness = 1
            Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(886, 16)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(38, 36)
            Me.btnClose.TabIndex = 3
            Me.btnClose.Text = "X"
            Me.btnClose.UseTransparentBackground = True
            '
            'body
            '
            Me.body.BackColor = System.Drawing.Color.Transparent
            Me.body.ColumnCount = 3
            Me.body.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3!))
            Me.body.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3!))
            Me.body.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4!))
            Me.body.Controls.Add(Me.col1, 0, 0)
            Me.body.Controls.Add(Me.col2, 1, 0)
            Me.body.Controls.Add(Me.col3, 2, 0)
            Me.body.Dock = System.Windows.Forms.DockStyle.Fill
            Me.body.Location = New System.Drawing.Point(0, 68)
            Me.body.Name = "body"
            Me.body.Padding = New System.Windows.Forms.Padding(18, 16, 18, 16)
            Me.body.RowCount = 1
            Me.body.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.body.Size = New System.Drawing.Size(940, 542)
            Me.body.TabIndex = 1
            '
            'col1
            '
            Me.col1.BackColor = System.Drawing.Color.Transparent
            Me.col1.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.col1.BorderRadius = 16
            Me.col1.BorderThickness = 1
            Me.col1.Controls.Add(Me.flpCol1)
            Me.col1.Controls.Add(Me.lblCol1)
            Me.col1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.col1.FillColor = System.Drawing.Color.White
            Me.col1.Location = New System.Drawing.Point(24, 22)
            Me.col1.Margin = New System.Windows.Forms.Padding(6)
            Me.col1.Name = "col1"
            Me.col1.Padding = New System.Windows.Forms.Padding(12)
            Me.col1.Size = New System.Drawing.Size(316, 508)
            Me.col1.TabIndex = 0
            Me.col1.UseTransparentBackground = True
            '
            'lblCol1
            '
            Me.lblCol1.BackColor = System.Drawing.Color.Transparent
            Me.lblCol1.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCol1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCol1.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblCol1.Location = New System.Drawing.Point(12, 12)
            Me.lblCol1.Name = "lblCol1"
            Me.lblCol1.Size = New System.Drawing.Size(292, 30)
            Me.lblCol1.TabIndex = 0
            Me.lblCol1.Text = "A2 / A3 — Kiosk Pelanggan"
            '
            'flpCol1
            '
            Me.flpCol1.AutoScroll = True
            Me.flpCol1.BackColor = System.Drawing.Color.Transparent
            Me.flpCol1.Controls.Add(Me.btnDemoWelcome)
            Me.flpCol1.Controls.Add(Me.btnDemoMenu)
            Me.flpCol1.Controls.Add(Me.btnDemoDetail)
            Me.flpCol1.Controls.Add(Me.btnDemoKeranjang)
            Me.flpCol1.Controls.Add(Me.btnDemoBayar)
            Me.flpCol1.Controls.Add(Me.btnDemoStruk)
            Me.flpCol1.Controls.Add(Me.btnDemoIdle)
            Me.flpCol1.Controls.Add(Me.btnDemoRating)
            Me.flpCol1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpCol1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.flpCol1.Location = New System.Drawing.Point(12, 42)
            Me.flpCol1.Name = "flpCol1"
            Me.flpCol1.Size = New System.Drawing.Size(292, 454)
            Me.flpCol1.TabIndex = 1
            Me.flpCol1.WrapContents = False
            '
            'col1 buttons
            '
            Me.btnDemoWelcome.Name = "btnDemoWelcome"
            ConfigureDemoBtn(Me.btnDemoWelcome, "Layar Awal (FrmWelcome)", 0)
            Me.btnDemoMenu.Name = "btnDemoMenu"
            ConfigureDemoBtn(Me.btnDemoMenu, "Katalog Menu (FrmMenu)", 1)
            Me.btnDemoDetail.Name = "btnDemoDetail"
            ConfigureDemoBtn(Me.btnDemoDetail, "Detail Produk (Kustomisasi)", 2)
            Me.btnDemoKeranjang.Name = "btnDemoKeranjang"
            ConfigureDemoBtn(Me.btnDemoKeranjang, "Isi Contoh + Keranjang", 3)
            Me.btnDemoBayar.Name = "btnDemoBayar"
            ConfigureDemoBtn(Me.btnDemoBayar, "Pembayaran (Tunai / QRIS)", 4)
            Me.btnDemoStruk.Name = "btnDemoStruk"
            ConfigureDemoBtn(Me.btnDemoStruk, "Contoh Struk + QR", 5)
            Me.btnDemoIdle.Name = "btnDemoIdle"
            ConfigureDemoBtn(Me.btnDemoIdle, "Simulasi Idle (10s)", 6)
            Me.btnDemoRating.Name = "btnDemoRating"
            ConfigureDemoBtn(Me.btnDemoRating, "Dialog Rating Pesanan", 7)
            '
            'col2
            '
            Me.col2.BackColor = System.Drawing.Color.Transparent
            Me.col2.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.col2.BorderRadius = 16
            Me.col2.BorderThickness = 1
            Me.col2.Controls.Add(Me.flpCol2)
            Me.col2.Controls.Add(Me.lblCol2)
            Me.col2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.col2.FillColor = System.Drawing.Color.White
            Me.col2.Location = New System.Drawing.Point(352, 22)
            Me.col2.Margin = New System.Windows.Forms.Padding(6)
            Me.col2.Name = "col2"
            Me.col2.Padding = New System.Windows.Forms.Padding(12)
            Me.col2.Size = New System.Drawing.Size(316, 508)
            Me.col2.TabIndex = 1
            Me.col2.UseTransparentBackground = True
            '
            'lblCol2
            '
            Me.lblCol2.BackColor = System.Drawing.Color.Transparent
            Me.lblCol2.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCol2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCol2.ForeColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.lblCol2.Location = New System.Drawing.Point(12, 12)
            Me.lblCol2.Name = "lblCol2"
            Me.lblCol2.Size = New System.Drawing.Size(292, 30)
            Me.lblCol2.TabIndex = 0
            Me.lblCol2.Text = "A1 / A4 — Kasir, Dapur, Antrian"
            '
            'flpCol2
            '
            Me.flpCol2.AutoScroll = True
            Me.flpCol2.BackColor = System.Drawing.Color.Transparent
            Me.flpCol2.Controls.Add(Me.btnDemoLogin)
            Me.flpCol2.Controls.Add(Me.btnDemoKasir)
            Me.flpCol2.Controls.Add(Me.btnDemoDapur)
            Me.flpCol2.Controls.Add(Me.btnDemoAntrian)
            Me.flpCol2.Controls.Add(Me.btnDemoLog)
            Me.flpCol2.Controls.Add(Me.btnDemoPengguna)
            Me.flpCol2.Controls.Add(Me.btnDemoPengaturan)
            Me.flpCol2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpCol2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.flpCol2.Location = New System.Drawing.Point(12, 42)
            Me.flpCol2.Name = "flpCol2"
            Me.flpCol2.Size = New System.Drawing.Size(292, 454)
            Me.flpCol2.TabIndex = 1
            Me.flpCol2.WrapContents = False
            '
            'col2 buttons
            '
            Me.btnDemoLogin.Name = "btnDemoLogin"
            ConfigureDemoBtn(Me.btnDemoLogin, "Form Login Staff", 0)
            Me.btnDemoKasir.Name = "btnDemoKasir"
            ConfigureDemoBtn(Me.btnDemoKasir, "Login Instan: KASIR -> FrmKasir", 1)
            Me.btnDemoDapur.Name = "btnDemoDapur"
            ConfigureDemoBtn(Me.btnDemoDapur, "Login Instan: KASIR -> FrmDapur", 2)
            Me.btnDemoAntrian.Name = "btnDemoAntrian"
            ConfigureDemoBtn(Me.btnDemoAntrian, "Layar Antrian (FrmAntrian)", 3)
            Me.btnDemoLog.Name = "btnDemoLog"
            ConfigureDemoBtn(Me.btnDemoLog, "Log Aktivitas (FrmLog)", 4)
            Me.btnDemoPengguna.Name = "btnDemoPengguna"
            ConfigureDemoBtn(Me.btnDemoPengguna, "Pengguna Staff (FrmPengguna)", 5)
            Me.btnDemoPengaturan.Name = "btnDemoPengaturan"
            ConfigureDemoBtn(Me.btnDemoPengaturan, "Pengaturan Sistem", 6)
            '
            'col3
            '
            Me.col3.BackColor = System.Drawing.Color.Transparent
            Me.col3.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.col3.BorderRadius = 16
            Me.col3.BorderThickness = 1
            Me.col3.Controls.Add(Me.flpCol3)
            Me.col3.Controls.Add(Me.lblCol3)
            Me.col3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.col3.FillColor = System.Drawing.Color.White
            Me.col3.Location = New System.Drawing.Point(680, 22)
            Me.col3.Margin = New System.Windows.Forms.Padding(6)
            Me.col3.Name = "col3"
            Me.col3.Padding = New System.Windows.Forms.Padding(12)
            Me.col3.Size = New System.Drawing.Size(316, 508)
            Me.col3.TabIndex = 2
            Me.col3.UseTransparentBackground = True
            '
            'lblCol3
            '
            Me.lblCol3.BackColor = System.Drawing.Color.Transparent
            Me.lblCol3.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCol3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCol3.ForeColor = System.Drawing.Color.FromArgb(139, 69, 19)
            Me.lblCol3.Location = New System.Drawing.Point(12, 12)
            Me.lblCol3.Name = "lblCol3"
            Me.lblCol3.Size = New System.Drawing.Size(292, 30)
            Me.lblCol3.TabIndex = 0
            Me.lblCol3.Text = "A5 — Admin + Analitik"
            '
            'flpCol3
            '
            Me.flpCol3.AutoScroll = True
            Me.flpCol3.BackColor = System.Drawing.Color.Transparent
            Me.flpCol3.Controls.Add(Me.btnDemoDashboard)
            Me.flpCol3.Controls.Add(Me.btnDemoProduk)
            Me.flpCol3.Controls.Add(Me.btnDemoVoucher)
            Me.flpCol3.Controls.Add(Me.btnDemoLaporan)
            Me.flpCol3.Controls.Add(Me.btnDemoMember)
            Me.flpCol3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpCol3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.flpCol3.Location = New System.Drawing.Point(12, 42)
            Me.flpCol3.Name = "flpCol3"
            Me.flpCol3.Size = New System.Drawing.Size(292, 454)
            Me.flpCol3.TabIndex = 1
            Me.flpCol3.WrapContents = False
            '
            'col3 buttons
            '
            Me.btnDemoDashboard.Name = "btnDemoDashboard"
            ConfigureDemoBtn(Me.btnDemoDashboard, "Admin -> Dashboard", 0)
            Me.btnDemoProduk.Name = "btnDemoProduk"
            ConfigureDemoBtn(Me.btnDemoProduk, "Manajemen Produk / Stok", 1)
            Me.btnDemoVoucher.Name = "btnDemoVoucher"
            ConfigureDemoBtn(Me.btnDemoVoucher, "Manajemen Voucher Promo", 2)
            Me.btnDemoLaporan.Name = "btnDemoLaporan"
            ConfigureDemoBtn(Me.btnDemoLaporan, "Laporan, Array 2D / CSV", 3)
            Me.btnDemoMember.Name = "btnDemoMember"
            ConfigureDemoBtn(Me.btnDemoMember, "Member / Poin Loyalitas", 4)
            '
            'FrmDemoHub
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1020, 620)
            Me.Controls.Add(Me.card)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmDemoHub"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Quick Demo Navigator"
            Me.card.ResumeLayout(False)
            Me.body.ResumeLayout(False)
            Me.col1.ResumeLayout(False)
            Me.flpCol1.ResumeLayout(False)
            Me.col2.ResumeLayout(False)
            Me.flpCol2.ResumeLayout(False)
            Me.col3.ResumeLayout(False)
            Me.flpCol3.ResumeLayout(False)
            Me.hdr.ResumeLayout(False)
            CType(Me.ic, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents card As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents hdr As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents ic As System.Windows.Forms.PictureBox
        Friend WithEvents lblH As System.Windows.Forms.Label
        Friend WithEvents lblS As System.Windows.Forms.Label
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents body As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents col1 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCol1 As System.Windows.Forms.Label
        Friend WithEvents flpCol1 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents btnDemoWelcome As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoMenu As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoDetail As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoKeranjang As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoBayar As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoStruk As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoIdle As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoRating As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents col2 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCol2 As System.Windows.Forms.Label
        Friend WithEvents flpCol2 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents btnDemoLogin As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoKasir As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoDapur As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoAntrian As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoLog As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoPengguna As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoPengaturan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents col3 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCol3 As System.Windows.Forms.Label
        Friend WithEvents flpCol3 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents btnDemoDashboard As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoProduk As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoVoucher As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoLaporan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDemoMember As Guna.UI2.WinForms.Guna2Button

    End Class
End Namespace
