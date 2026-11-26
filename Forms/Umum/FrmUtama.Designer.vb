Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Umum

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmUtama
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
            Me.menuStrip = New System.Windows.Forms.MenuStrip()
            Me.mTransaksi = New System.Windows.Forms.ToolStripMenuItem()
            Me.miKasir = New System.Windows.Forms.ToolStripMenuItem()
            Me.mDapur = New System.Windows.Forms.ToolStripMenuItem()
            Me.miDapur = New System.Windows.Forms.ToolStripMenuItem()
            Me.miAntrian = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMaster = New System.Windows.Forms.ToolStripMenuItem()
            Me.miProduk = New System.Windows.Forms.ToolStripMenuItem()
            Me.miVoucher = New System.Windows.Forms.ToolStripMenuItem()
            Me.miMember = New System.Windows.Forms.ToolStripMenuItem()
            Me.mLaporan = New System.Windows.Forms.ToolStripMenuItem()
            Me.miDashboard = New System.Windows.Forms.ToolStripMenuItem()
            Me.miLaporan = New System.Windows.Forms.ToolStripMenuItem()
            Me.mSistem = New System.Windows.Forms.ToolStripMenuItem()
            Me.miPengguna = New System.Windows.Forms.ToolStripMenuItem()
            Me.miPengaturan = New System.Windows.Forms.ToolStripMenuItem()
            Me.miLog = New System.Windows.Forms.ToolStripMenuItem()
            Me.miSep1 = New System.Windows.Forms.ToolStripSeparator()
            Me.miKembaliKiosk = New System.Windows.Forms.ToolStripMenuItem()
            Me.miKeluar = New System.Windows.Forms.ToolStripMenuItem()
            Me.mWindow = New System.Windows.Forms.ToolStripMenuItem()
            Me.miCascade = New System.Windows.Forms.ToolStripMenuItem()
            Me.miTileH = New System.Windows.Forms.ToolStripMenuItem()
            Me.miTileV = New System.Windows.Forms.ToolStripMenuItem()
            Me.miFullscreen = New System.Windows.Forms.ToolStripMenuItem()
            Me.miSep2 = New System.Windows.Forms.ToolStripSeparator()
            Me.miTutupSemua = New System.Windows.Forms.ToolStripMenuItem()
            Me.pnlSidebar = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnToggleNav = New Guna.UI2.WinForms.Guna2Button()
            Me.flpNav = New System.Windows.Forms.FlowLayoutPanel()

            Me.btnNavDashboard = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavKasir = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavDapur = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavAntrian = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavProduk = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavVoucher = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavMember = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavLaporan = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavPengguna = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavPengaturan = New Guna.UI2.WinForms.Guna2Button()

            Me.btnNavLog = New Guna.UI2.WinForms.Guna2Button()
            Me.btnKiosk = New Guna.UI2.WinForms.Guna2Button()
            Me.statusStrip = New System.Windows.Forms.StatusStrip()
            Me.lblUser = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblSepA = New System.Windows.Forms.ToolStripSeparator()
            Me.lblKoneksi = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblSepB = New System.Windows.Forms.ToolStripSeparator()
            Me.lblStokAlert = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblSpacer = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblDemoLink = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblSepC = New System.Windows.Forms.ToolStripSeparator()
            Me.lblJam = New System.Windows.Forms.ToolStripStatusLabel()
            Me.menuStrip.SuspendLayout()
            Me.pnlSidebar.SuspendLayout()

            Me.flpNav.SuspendLayout()
            Me.statusStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'menuStrip
            '
            Me.menuStrip.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.menuStrip.ForeColor = System.Drawing.Color.White
            Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mTransaksi, Me.mDapur, Me.mMaster, Me.mLaporan, Me.mSistem, Me.mWindow})
            Me.menuStrip.Location = New System.Drawing.Point(0, 0)
            Me.menuStrip.Name = "menuStrip"
            Me.menuStrip.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
            Me.menuStrip.Size = New System.Drawing.Size(1380, 28)
            Me.menuStrip.TabIndex = 0
            '
            'mTransaksi
            '
            Me.mTransaksi.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miKasir})
            Me.mTransaksi.ForeColor = System.Drawing.Color.White
            Me.mTransaksi.Name = "mTransaksi"
            Me.mTransaksi.Text = "Transaksi"
            '
            'miKasir
            '
            Me.miKasir.ForeColor = System.Drawing.Color.White
            Me.miKasir.Name = "miKasir"
            Me.miKasir.Tag = "FrmKasir"
            Me.miKasir.Text = "Kasir (Konfirmasi & Struk)"
            '
            'mDapur
            '
            Me.mDapur.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miDapur, Me.miAntrian})
            Me.mDapur.ForeColor = System.Drawing.Color.White
            Me.mDapur.Name = "mDapur"
            Me.mDapur.Text = "Dapur"
            '
            'miDapur
            '
            Me.miDapur.ForeColor = System.Drawing.Color.White
            Me.miDapur.Name = "miDapur"
            Me.miDapur.Tag = "FrmDapur"
            Me.miDapur.Text = "Kitchen Display (Dapur)"
            '
            'miAntrian
            '
            Me.miAntrian.ForeColor = System.Drawing.Color.White
            Me.miAntrian.Name = "miAntrian"
            Me.miAntrian.Tag = "FrmAntrian"
            Me.miAntrian.Text = "Layar Antrian Pelanggan"
            '
            'mMaster
            '
            Me.mMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miProduk, Me.miVoucher, Me.miMember})
            Me.mMaster.ForeColor = System.Drawing.Color.White
            Me.mMaster.Name = "mMaster"
            Me.mMaster.Text = "Master"
            '
            'miProduk
            '
            Me.miProduk.ForeColor = System.Drawing.Color.White
            Me.miProduk.Name = "miProduk"
            Me.miProduk.Tag = "FrmProduk"
            Me.miProduk.Text = "Produk, Kategori & Opsi"
            '
            'miVoucher
            '
            Me.miVoucher.ForeColor = System.Drawing.Color.White
            Me.miVoucher.Name = "miVoucher"
            Me.miVoucher.Tag = "FrmVoucher"
            Me.miVoucher.Text = "Voucher & Promo"
            '
            'miMember
            '
            Me.miMember.ForeColor = System.Drawing.Color.White
            Me.miMember.Name = "miMember"
            Me.miMember.Tag = "FrmMember"
            Me.miMember.Text = "Member & Poin"
            '
            'mLaporan
            '
            Me.mLaporan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miDashboard, Me.miLaporan})
            Me.mLaporan.ForeColor = System.Drawing.Color.White
            Me.mLaporan.Name = "mLaporan"
            Me.mLaporan.Text = "Laporan"
            '
            'miDashboard
            '
            Me.miDashboard.ForeColor = System.Drawing.Color.White
            Me.miDashboard.Name = "miDashboard"
            Me.miDashboard.Tag = "FrmDashboard"
            Me.miDashboard.Text = "Dashboard Ringkasan"
            '
            'miLaporan
            '
            Me.miLaporan.ForeColor = System.Drawing.Color.White
            Me.miLaporan.Name = "miLaporan"
            Me.miLaporan.Tag = "FrmLaporan"
            Me.miLaporan.Text = "Laporan Penjualan & CSV"
            '
            'mSistem
            '
            Me.mSistem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miPengguna, Me.miPengaturan, Me.miLog, Me.miSep1, Me.miKembaliKiosk, Me.miKeluar})
            Me.mSistem.ForeColor = System.Drawing.Color.White
            Me.mSistem.Name = "mSistem"
            Me.mSistem.Text = "Sistem"
            '
            'miPengguna
            '
            Me.miPengguna.ForeColor = System.Drawing.Color.White
            Me.miPengguna.Name = "miPengguna"
            Me.miPengguna.Tag = "FrmPengguna"
            Me.miPengguna.Text = "Pengguna Staff"
            '
            'miPengaturan
            '
            Me.miPengaturan.ForeColor = System.Drawing.Color.White
            Me.miPengaturan.Name = "miPengaturan"
            Me.miPengaturan.Tag = "FrmPengaturan"
            Me.miPengaturan.Text = "Pengaturan Aplikasi"
            '
            'miLog
            '
            Me.miLog.ForeColor = System.Drawing.Color.White
            Me.miLog.Name = "miLog"
            Me.miLog.Tag = "FrmLog"
            Me.miLog.Text = "Log Aktivitas"
            '
            'miSep1
            '
            Me.miSep1.Name = "miSep1"
            '
            'miKembaliKiosk
            '
            Me.miKembaliKiosk.ForeColor = System.Drawing.Color.White
            Me.miKembaliKiosk.Name = "miKembaliKiosk"
            Me.miKembaliKiosk.Text = "Kembali ke Kiosk"
            '
            'miKeluar
            '
            Me.miKeluar.ForeColor = System.Drawing.Color.White
            Me.miKeluar.Name = "miKeluar"
            Me.miKeluar.Text = "Keluar Aplikasi"
            '
            'mWindow
            '
            Me.mWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miCascade, Me.miTileH, Me.miTileV, Me.miFullscreen, Me.miSep2, Me.miTutupSemua})
            Me.mWindow.ForeColor = System.Drawing.Color.White
            Me.mWindow.Name = "mWindow"
            Me.mWindow.Text = "Window"
            '
            'miCascade
            '
            Me.miCascade.ForeColor = System.Drawing.Color.White
            Me.miCascade.Name = "miCascade"
            Me.miCascade.Text = "Cascade"
            '
            'miTileH
            '
            Me.miTileH.ForeColor = System.Drawing.Color.White
            Me.miTileH.Name = "miTileH"
            Me.miTileH.Text = "Tile Horizontal"
            '
            'miTileV
            '
            Me.miTileV.ForeColor = System.Drawing.Color.White
            Me.miTileV.Name = "miTileV"
            Me.miTileV.Text = "Tile Vertical"
            '
            'miFullscreen
            '
            Me.miFullscreen.ForeColor = System.Drawing.Color.White
            Me.miFullscreen.Name = "miFullscreen"
            Me.miFullscreen.Text = "Layar Penuh (F11)"
            '
            'miSep2
            '
            Me.miSep2.Name = "miSep2"
            '
            'miTutupSemua
            '
            Me.miTutupSemua.ForeColor = System.Drawing.Color.White
            Me.miTutupSemua.Name = "miTutupSemua"
            Me.miTutupSemua.Text = "Tutup Semua"
            '
            'pnlSidebar
            '
            Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlSidebar.Controls.Add(Me.btnToggleNav)
            Me.pnlSidebar.Controls.Add(Me.flpNav)
            Me.pnlSidebar.Controls.Add(Me.btnKiosk)
            Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlSidebar.Location = New System.Drawing.Point(0, 28)
            Me.pnlSidebar.Name = "pnlSidebar"
            Me.pnlSidebar.BorderRadius = 0
            Me.pnlSidebar.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlSidebar.Size = New System.Drawing.Size(228, 788)
            Me.pnlSidebar.TabIndex = 1
            '
            'btnToggleNav
            '
            Me.btnToggleNav.BackColor = System.Drawing.Color.Transparent
            Me.btnToggleNav.BorderRadius = 10
            Me.btnToggleNav.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnToggleNav.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.btnToggleNav.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnToggleNav.ForeColor = System.Drawing.Color.White
            Me.btnToggleNav.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnToggleNav.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnToggleNav.Location = New System.Drawing.Point(10, 10)
            Me.btnToggleNav.Name = "btnToggleNav"
            Me.btnToggleNav.Size = New System.Drawing.Size(208, 40)
            Me.btnToggleNav.TabIndex = 0
            Me.btnToggleNav.Text = "  Menu Operasional"
            Me.btnToggleNav.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnToggleNav.UseTransparentBackground = True
            '
            'flpNav
            '
            Me.flpNav.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.flpNav.AutoScroll = True
            Me.flpNav.BackColor = System.Drawing.Color.Transparent

            Me.flpNav.Controls.Add(Me.btnNavDashboard)

            Me.flpNav.Controls.Add(Me.btnNavKasir)

            Me.flpNav.Controls.Add(Me.btnNavDapur)

            Me.flpNav.Controls.Add(Me.btnNavAntrian)

            Me.flpNav.Controls.Add(Me.btnNavProduk)

            Me.flpNav.Controls.Add(Me.btnNavVoucher)

            Me.flpNav.Controls.Add(Me.btnNavMember)

            Me.flpNav.Controls.Add(Me.btnNavLaporan)

            Me.flpNav.Controls.Add(Me.btnNavPengguna)

            Me.flpNav.Controls.Add(Me.btnNavPengaturan)

            Me.flpNav.Controls.Add(Me.btnNavLog)
            Me.flpNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.flpNav.Location = New System.Drawing.Point(10, 58)
            Me.flpNav.Name = "flpNav"
            Me.flpNav.Size = New System.Drawing.Size(208, 668)
            Me.flpNav.TabIndex = 1
            Me.flpNav.WrapContents = False

            '
            'btnNavDashboard
            '
            Me.btnNavDashboard.Animated = True
            Me.btnNavDashboard.BackColor = System.Drawing.Color.Transparent
            Me.btnNavDashboard.BorderRadius = 10
            Me.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavDashboard.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnNavDashboard.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavDashboard.ForeColor = System.Drawing.Color.White
            Me.btnNavDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavDashboard.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavDashboard.Location = New System.Drawing.Point(0, 0)
            Me.btnNavDashboard.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavDashboard.Name = "btnNavDashboard"
            Me.btnNavDashboard.Size = New System.Drawing.Size(204, 40)
            Me.btnNavDashboard.TabIndex = 0
            Me.btnNavDashboard.Text = "  Dashboard"
            Me.btnNavDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavDashboard.UseTransparentBackground = True

            '
            'btnNavKasir
            '
            Me.btnNavKasir.Animated = True
            Me.btnNavKasir.BackColor = System.Drawing.Color.Transparent
            Me.btnNavKasir.BorderRadius = 10
            Me.btnNavKasir.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavKasir.FillColor = System.Drawing.Color.Transparent
            Me.btnNavKasir.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavKasir.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavKasir.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavKasir.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavKasir.Location = New System.Drawing.Point(0, 46)
            Me.btnNavKasir.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavKasir.Name = "btnNavKasir"
            Me.btnNavKasir.Size = New System.Drawing.Size(204, 40)
            Me.btnNavKasir.TabIndex = 1
            Me.btnNavKasir.Text = "  Kasir"
            Me.btnNavKasir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavKasir.UseTransparentBackground = True

            '
            'btnNavDapur
            '
            Me.btnNavDapur.Animated = True
            Me.btnNavDapur.BackColor = System.Drawing.Color.Transparent
            Me.btnNavDapur.BorderRadius = 10
            Me.btnNavDapur.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavDapur.FillColor = System.Drawing.Color.Transparent
            Me.btnNavDapur.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavDapur.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavDapur.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavDapur.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavDapur.Location = New System.Drawing.Point(0, 92)
            Me.btnNavDapur.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavDapur.Name = "btnNavDapur"
            Me.btnNavDapur.Size = New System.Drawing.Size(204, 40)
            Me.btnNavDapur.TabIndex = 2
            Me.btnNavDapur.Text = "  Dapur (KDS)"
            Me.btnNavDapur.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavDapur.UseTransparentBackground = True

            '
            'btnNavAntrian
            '
            Me.btnNavAntrian.Animated = True
            Me.btnNavAntrian.BackColor = System.Drawing.Color.Transparent
            Me.btnNavAntrian.BorderRadius = 10
            Me.btnNavAntrian.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavAntrian.FillColor = System.Drawing.Color.Transparent
            Me.btnNavAntrian.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavAntrian.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavAntrian.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavAntrian.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavAntrian.Location = New System.Drawing.Point(0, 138)
            Me.btnNavAntrian.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavAntrian.Name = "btnNavAntrian"
            Me.btnNavAntrian.Size = New System.Drawing.Size(204, 40)
            Me.btnNavAntrian.TabIndex = 3
            Me.btnNavAntrian.Text = "  Layar Antrian"
            Me.btnNavAntrian.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavAntrian.UseTransparentBackground = True

            '
            'btnNavProduk
            '
            Me.btnNavProduk.Animated = True
            Me.btnNavProduk.BackColor = System.Drawing.Color.Transparent
            Me.btnNavProduk.BorderRadius = 10
            Me.btnNavProduk.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavProduk.FillColor = System.Drawing.Color.Transparent
            Me.btnNavProduk.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavProduk.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavProduk.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavProduk.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavProduk.Location = New System.Drawing.Point(0, 184)
            Me.btnNavProduk.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavProduk.Name = "btnNavProduk"
            Me.btnNavProduk.Size = New System.Drawing.Size(204, 40)
            Me.btnNavProduk.TabIndex = 4
            Me.btnNavProduk.Text = "  Produk / Stok"
            Me.btnNavProduk.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavProduk.UseTransparentBackground = True

            '
            'btnNavVoucher
            '
            Me.btnNavVoucher.Animated = True
            Me.btnNavVoucher.BackColor = System.Drawing.Color.Transparent
            Me.btnNavVoucher.BorderRadius = 10
            Me.btnNavVoucher.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavVoucher.FillColor = System.Drawing.Color.Transparent
            Me.btnNavVoucher.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavVoucher.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavVoucher.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavVoucher.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavVoucher.Location = New System.Drawing.Point(0, 230)
            Me.btnNavVoucher.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavVoucher.Name = "btnNavVoucher"
            Me.btnNavVoucher.Size = New System.Drawing.Size(204, 40)
            Me.btnNavVoucher.TabIndex = 5
            Me.btnNavVoucher.Text = "  Voucher Promo"
            Me.btnNavVoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavVoucher.UseTransparentBackground = True

            '
            'btnNavMember
            '
            Me.btnNavMember.Animated = True
            Me.btnNavMember.BackColor = System.Drawing.Color.Transparent
            Me.btnNavMember.BorderRadius = 10
            Me.btnNavMember.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavMember.FillColor = System.Drawing.Color.Transparent
            Me.btnNavMember.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavMember.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavMember.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavMember.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavMember.Location = New System.Drawing.Point(0, 276)
            Me.btnNavMember.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavMember.Name = "btnNavMember"
            Me.btnNavMember.Size = New System.Drawing.Size(204, 40)
            Me.btnNavMember.TabIndex = 6
            Me.btnNavMember.Text = "  Member / Poin"
            Me.btnNavMember.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavMember.UseTransparentBackground = True

            '
            'btnNavLaporan
            '
            Me.btnNavLaporan.Animated = True
            Me.btnNavLaporan.BackColor = System.Drawing.Color.Transparent
            Me.btnNavLaporan.BorderRadius = 10
            Me.btnNavLaporan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavLaporan.FillColor = System.Drawing.Color.Transparent
            Me.btnNavLaporan.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavLaporan.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavLaporan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavLaporan.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavLaporan.Location = New System.Drawing.Point(0, 322)
            Me.btnNavLaporan.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavLaporan.Name = "btnNavLaporan"
            Me.btnNavLaporan.Size = New System.Drawing.Size(204, 40)
            Me.btnNavLaporan.TabIndex = 7
            Me.btnNavLaporan.Text = "  Laporan / CSV"
            Me.btnNavLaporan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavLaporan.UseTransparentBackground = True

            '
            'btnNavPengguna
            '
            Me.btnNavPengguna.Animated = True
            Me.btnNavPengguna.BackColor = System.Drawing.Color.Transparent
            Me.btnNavPengguna.BorderRadius = 10
            Me.btnNavPengguna.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavPengguna.FillColor = System.Drawing.Color.Transparent
            Me.btnNavPengguna.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavPengguna.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavPengguna.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavPengguna.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavPengguna.Location = New System.Drawing.Point(0, 368)
            Me.btnNavPengguna.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavPengguna.Name = "btnNavPengguna"
            Me.btnNavPengguna.Size = New System.Drawing.Size(204, 40)
            Me.btnNavPengguna.TabIndex = 8
            Me.btnNavPengguna.Text = "  Pengguna"
            Me.btnNavPengguna.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavPengguna.UseTransparentBackground = True

            '
            'btnNavPengaturan
            '
            Me.btnNavPengaturan.Animated = True
            Me.btnNavPengaturan.BackColor = System.Drawing.Color.Transparent
            Me.btnNavPengaturan.BorderRadius = 10
            Me.btnNavPengaturan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavPengaturan.FillColor = System.Drawing.Color.Transparent
            Me.btnNavPengaturan.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavPengaturan.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavPengaturan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavPengaturan.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavPengaturan.Location = New System.Drawing.Point(0, 414)
            Me.btnNavPengaturan.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavPengaturan.Name = "btnNavPengaturan"
            Me.btnNavPengaturan.Size = New System.Drawing.Size(204, 40)
            Me.btnNavPengaturan.TabIndex = 9
            Me.btnNavPengaturan.Text = "  Pengaturan"
            Me.btnNavPengaturan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavPengaturan.UseTransparentBackground = True

            '
            'btnNavLog
            '
            Me.btnNavLog.Animated = True
            Me.btnNavLog.BackColor = System.Drawing.Color.Transparent
            Me.btnNavLog.BorderRadius = 10
            Me.btnNavLog.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavLog.FillColor = System.Drawing.Color.Transparent
            Me.btnNavLog.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavLog.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNavLog.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavLog.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnNavLog.Location = New System.Drawing.Point(0, 460)
            Me.btnNavLog.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
            Me.btnNavLog.Name = "btnNavLog"
            Me.btnNavLog.Size = New System.Drawing.Size(204, 40)
            Me.btnNavLog.TabIndex = 10
            Me.btnNavLog.Text = "  Log Aktivitas"
            Me.btnNavLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnNavLog.UseTransparentBackground = True
            '
            'btnKiosk
            '
            Me.btnKiosk.BackColor = System.Drawing.Color.Transparent
            Me.btnKiosk.BorderColor = System.Drawing.Color.FromArgb(255, 250, 240)

            Me.btnKiosk.BorderRadius = 10

            Me.btnKiosk.BorderThickness = 2
            Me.btnKiosk.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKiosk.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.btnKiosk.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnKiosk.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnKiosk.ForeColor = System.Drawing.Color.White
            Me.btnKiosk.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnKiosk.ImageOffset = New System.Drawing.Point(10, 0)
            Me.btnKiosk.Location = New System.Drawing.Point(10, 736)
            Me.btnKiosk.Name = "btnKiosk"
            Me.btnKiosk.BorderRadius = 10
            Me.btnKiosk.Size = New System.Drawing.Size(208, 42)
            Me.btnKiosk.TabIndex = 2
            Me.btnKiosk.Text = "  Kembali ke Kiosk"
            Me.btnKiosk.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnKiosk.UseTransparentBackground = True
            '
            'statusStrip
            '
            Me.statusStrip.BackColor = System.Drawing.Color.White
            Me.statusStrip.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUser, Me.lblSepA, Me.lblKoneksi, Me.lblSepB, Me.lblStokAlert, Me.lblSpacer, Me.lblDemoLink, Me.lblSepC, Me.lblJam})
            Me.statusStrip.Location = New System.Drawing.Point(0, 816)
            Me.statusStrip.Name = "statusStrip"
            Me.statusStrip.Size = New System.Drawing.Size(1380, 24)
            Me.statusStrip.TabIndex = 2
            '
            'lblUser
            '
            Me.lblUser.Name = "lblUser"
            Me.lblUser.Text = "Staff: -"
            '
            'lblSepA
            '
            Me.lblSepA.Name = "lblSepA"
            '
            'lblKoneksi
            '
            Me.lblKoneksi.Name = "lblKoneksi"
            Me.lblKoneksi.Text = "Database: Memeriksa..."
            '
            'lblSepB
            '
            Me.lblSepB.Name = "lblSepB"
            '
            'lblStokAlert
            '
            Me.lblStokAlert.ForeColor = System.Drawing.Color.FromArgb(200, 116, 30)
            Me.lblStokAlert.Name = "lblStokAlert"
            Me.lblStokAlert.Text = "Stok Aman"
            '
            'lblSpacer
            '
            Me.lblSpacer.Name = "lblSpacer"
            Me.lblSpacer.Spring = True
            '
            'lblDemoLink
            '
            Me.lblDemoLink.IsLink = True
            Me.lblDemoLink.Name = "lblDemoLink"
            Me.lblDemoLink.Text = "Demo Hub (F9)"
            '
            'lblSepC
            '
            Me.lblSepC.Name = "lblSepC"
            '
            'lblJam
            '
            Me.lblJam.Name = "lblJam"
            Me.lblJam.Text = "00:00:00"
            '
            'FrmUtama
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1380, 840)
            Me.Controls.Add(Me.pnlSidebar)
            Me.Controls.Add(Me.menuStrip)
            Me.Controls.Add(Me.statusStrip)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.IsMdiContainer = True
            Me.MainMenuStrip = Me.menuStrip
            Me.MinimumSize = New System.Drawing.Size(1120, 700)
            Me.Name = "FrmUtama"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Bistro Staff Portal — Mode Operasional & Admin (MDI)"
            Me.menuStrip.ResumeLayout(False)
            Me.menuStrip.PerformLayout()
            Me.flpNav.ResumeLayout(False)

            Me.pnlSidebar.ResumeLayout(False)
            Me.statusStrip.ResumeLayout(False)
            Me.statusStrip.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
        Friend WithEvents mTransaksi As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miKasir As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mDapur As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miDapur As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miAntrian As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMaster As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miProduk As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miVoucher As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miMember As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mLaporan As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miDashboard As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miLaporan As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mSistem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miPengguna As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miPengaturan As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miLog As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miSep1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents miKembaliKiosk As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miKeluar As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miCascade As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miTileH As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miTileV As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miFullscreen As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents miSep2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents miTutupSemua As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents pnlSidebar As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents btnToggleNav As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents flpNav As System.Windows.Forms.FlowLayoutPanel

        Friend WithEvents btnNavDashboard As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavKasir As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavDapur As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavAntrian As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavProduk As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavVoucher As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavMember As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavLaporan As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavPengguna As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavPengaturan As Guna.UI2.WinForms.Guna2Button

        Friend WithEvents btnNavLog As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnKiosk As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
        Friend WithEvents lblUser As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblSepA As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents lblKoneksi As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblSepB As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents lblStokAlert As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblSpacer As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblDemoLink As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblSepC As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents lblJam As System.Windows.Forms.ToolStripStatusLabel

    End Class
End Namespace
