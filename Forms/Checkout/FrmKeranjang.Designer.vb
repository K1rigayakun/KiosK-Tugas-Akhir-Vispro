Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Checkout

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmKeranjang
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
            Me.pnlHead = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblHead = New System.Windows.Forms.Label()
            Me.icCart = New System.Windows.Forms.PictureBox()
            Me.pnlKanan = New System.Windows.Forms.Panel()
            Me.btnLanjutBayar = New Guna.UI2.WinForms.Guna2Button()
            Me.btnKembaliMenu = New Guna.UI2.WinForms.Guna2Button()
            Me.cardSummary = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblPoinDidapat = New System.Windows.Forms.Label()
            Me.lblTotal = New System.Windows.Forms.Label()
            Me.lblTotCap = New System.Windows.Forms.Label()
            Me.garisSummary = New System.Windows.Forms.Panel()
            Me.lblPajak = New System.Windows.Forms.Label()
            Me.lblCapPajak = New System.Windows.Forms.Label()
            Me.lblDiskonPoin = New System.Windows.Forms.Label()
            Me.lblCapDiskonPoin = New System.Windows.Forms.Label()
            Me.lblDiskonVoucher = New System.Windows.Forms.Label()
            Me.lblCapDiskonVoucher = New System.Windows.Forms.Label()
            Me.lblDiskonBertingkat = New System.Windows.Forms.Label()
            Me.lblCapDiskonBertingkat = New System.Windows.Forms.Label()
            Me.lblSubtotal = New System.Windows.Forms.Label()
            Me.lblCapSubtotal = New System.Windows.Forms.Label()
            Me.lblSumTitle = New System.Windows.Forms.Label()
            Me.cardVoucher = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblStatusVoucher = New System.Windows.Forms.Label()
            Me.btnPakaiVoucher = New Guna.UI2.WinForms.Guna2Button()
            Me.txtVoucher = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblVouchTitle = New System.Windows.Forms.Label()
            Me.cardMember = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnPakaiPoin = New Guna.UI2.WinForms.Guna2Button()
            Me.txtPakaiPoin = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblInfoMember = New System.Windows.Forms.Label()
            Me.btnCariMember = New Guna.UI2.WinForms.Guna2Button()
            Me.txtNoHpMember = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblMemTitle = New System.Windows.Forms.Label()
            Me.pnlKiri = New System.Windows.Forms.Panel()
            Me.cardGrid = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvKeranjang = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colMenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colOpsi = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlItemBar = New System.Windows.Forms.Panel()
            Me.btnHapus = New Guna.UI2.WinForms.Guna2Button()
            Me.btnTambah = New Guna.UI2.WinForms.Guna2Button()
            Me.btnKurang = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlSpacer = New System.Windows.Forms.Panel()
            Me.pnlUpsell = New Guna.UI2.WinForms.Guna2Panel()
            Me.flpUpsellItems = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnLewatiUpsell = New Guna.UI2.WinForms.Guna2Button()
            Me.lblUpsellHead = New System.Windows.Forms.Label()
            Me.pnlHead.SuspendLayout()
            CType(Me.icCart, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlKanan.SuspendLayout()
            Me.cardSummary.SuspendLayout()
            Me.cardVoucher.SuspendLayout()
            Me.cardMember.SuspendLayout()
            Me.pnlKiri.SuspendLayout()
            Me.cardGrid.SuspendLayout()
            CType(Me.dgvKeranjang, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlItemBar.SuspendLayout()
            Me.pnlUpsell.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHead
            '
            Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlHead.Controls.Add(Me.lblHead)
            Me.pnlHead.Controls.Add(Me.icCart)
            Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHead.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlHead.Location = New System.Drawing.Point(0, 0)
            Me.pnlHead.Name = "pnlHead"
            Me.pnlHead.BorderRadius = 0
            Me.pnlHead.Size = New System.Drawing.Size(1180, 68)
            Me.pnlHead.TabIndex = 0
            '
            'icCart
            '
            Me.icCart.BackColor = System.Drawing.Color.Transparent
            Me.icCart.Location = New System.Drawing.Point(22, 16)
            Me.icCart.Name = "icCart"
            Me.icCart.Size = New System.Drawing.Size(36, 36)
            Me.icCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icCart.TabIndex = 0
            Me.icCart.TabStop = False
            '
            'lblHead
            '
            Me.lblHead.BackColor = System.Drawing.Color.Transparent
            Me.lblHead.Font = New System.Drawing.Font("Georgia", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblHead.ForeColor = System.Drawing.Color.White
            Me.lblHead.Location = New System.Drawing.Point(66, 14)
            Me.lblHead.Name = "lblHead"
            Me.lblHead.Size = New System.Drawing.Size(560, 40)
            Me.lblHead.TabIndex = 1
            Me.lblHead.Text = "Keranjang Pesanan (Dine In)"
            Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlKanan
            '
            Me.pnlKanan.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlKanan.Controls.Add(Me.btnLanjutBayar)
            Me.pnlKanan.Controls.Add(Me.btnKembaliMenu)
            Me.pnlKanan.Controls.Add(Me.cardSummary)
            Me.pnlKanan.Controls.Add(Me.cardVoucher)
            Me.pnlKanan.Controls.Add(Me.cardMember)
            Me.pnlKanan.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlKanan.Location = New System.Drawing.Point(760, 68)
            Me.pnlKanan.Name = "pnlKanan"
            Me.pnlKanan.Padding = New System.Windows.Forms.Padding(10, 18, 22, 18)
            Me.pnlKanan.Size = New System.Drawing.Size(420, 692)
            Me.pnlKanan.TabIndex = 1
            '
            'cardMember
            '
            Me.cardMember.BackColor = System.Drawing.Color.Transparent
            Me.cardMember.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardMember.BorderRadius = 16
            Me.cardMember.BorderThickness = 1
            Me.cardMember.Controls.Add(Me.btnPakaiPoin)
            Me.cardMember.Controls.Add(Me.txtPakaiPoin)
            Me.cardMember.Controls.Add(Me.lblInfoMember)
            Me.cardMember.Controls.Add(Me.btnCariMember)
            Me.cardMember.Controls.Add(Me.txtNoHpMember)
            Me.cardMember.Controls.Add(Me.lblMemTitle)
            Me.cardMember.FillColor = System.Drawing.Color.White
            Me.cardMember.Location = New System.Drawing.Point(10, 18)
            Me.cardMember.Name = "cardMember"
            Me.cardMember.Size = New System.Drawing.Size(388, 152)
            Me.cardMember.TabIndex = 0
            Me.cardMember.UseTransparentBackground = True
            '
            'lblMemTitle
            '
            Me.lblMemTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblMemTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblMemTitle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblMemTitle.Location = New System.Drawing.Point(14, 10)
            Me.lblMemTitle.Name = "lblMemTitle"
            Me.lblMemTitle.Size = New System.Drawing.Size(360, 22)
            Me.lblMemTitle.TabIndex = 0
            Me.lblMemTitle.Text = "Member / Poin (Demo: 081234567890)"
            '
            'txtNoHpMember
            '
            Me.txtNoHpMember.BackColor = System.Drawing.Color.Transparent
            Me.txtNoHpMember.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNoHpMember.BorderRadius = 12
            Me.txtNoHpMember.FillColor = System.Drawing.Color.White
            Me.txtNoHpMember.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtNoHpMember.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtNoHpMember.Location = New System.Drawing.Point(14, 36)
            Me.txtNoHpMember.Name = "txtNoHpMember"
            Me.txtNoHpMember.PlaceholderText = "No. HP Member..."
            Me.txtNoHpMember.Size = New System.Drawing.Size(258, 36)
            Me.txtNoHpMember.TabIndex = 1
            Me.txtNoHpMember.BorderThickness = 1
            '
            'btnCariMember
            '
            Me.btnCariMember.BackColor = System.Drawing.Color.Transparent
            Me.btnCariMember.BorderRadius = 12
            Me.btnCariMember.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCariMember.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnCariMember.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnCariMember.ForeColor = System.Drawing.Color.White
            Me.btnCariMember.Location = New System.Drawing.Point(278, 36)
            Me.btnCariMember.Name = "btnCariMember"
            Me.btnCariMember.BorderThickness = 0
            Me.btnCariMember.Size = New System.Drawing.Size(96, 36)
            Me.btnCariMember.TabIndex = 2
            Me.btnCariMember.Text = "Cari"
            Me.btnCariMember.UseTransparentBackground = True
            '
            'lblInfoMember
            '
            Me.lblInfoMember.BackColor = System.Drawing.Color.Transparent
            Me.lblInfoMember.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblInfoMember.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblInfoMember.Location = New System.Drawing.Point(14, 76)
            Me.lblInfoMember.Name = "lblInfoMember"
            Me.lblInfoMember.Size = New System.Drawing.Size(360, 22)
            Me.lblInfoMember.TabIndex = 3
            Me.lblInfoMember.Text = "Belum ada member terpilih."
            '
            'txtPakaiPoin
            '
            Me.txtPakaiPoin.BackColor = System.Drawing.Color.Transparent
            Me.txtPakaiPoin.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtPakaiPoin.BorderRadius = 12
            Me.txtPakaiPoin.FillColor = System.Drawing.Color.White
            Me.txtPakaiPoin.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtPakaiPoin.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtPakaiPoin.Location = New System.Drawing.Point(14, 104)
            Me.txtPakaiPoin.Name = "txtPakaiPoin"
            Me.txtPakaiPoin.PlaceholderText = "Poin dipakai..."
            Me.txtPakaiPoin.Size = New System.Drawing.Size(220, 34)
            Me.txtPakaiPoin.TabIndex = 4
            Me.txtPakaiPoin.BorderThickness = 1
            '
            'btnPakaiPoin
            '
            Me.btnPakaiPoin.BackColor = System.Drawing.Color.Transparent
            Me.btnPakaiPoin.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnPakaiPoin.BorderRadius = 10
            Me.btnPakaiPoin.BorderThickness = 1
            Me.btnPakaiPoin.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPakaiPoin.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnPakaiPoin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnPakaiPoin.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnPakaiPoin.Location = New System.Drawing.Point(240, 104)
            Me.btnPakaiPoin.Name = "btnPakaiPoin"
            Me.btnPakaiPoin.Size = New System.Drawing.Size(134, 34)
            Me.btnPakaiPoin.TabIndex = 5
            Me.btnPakaiPoin.Text = "Pakai Poin"
            Me.btnPakaiPoin.UseTransparentBackground = True
            '
            'cardVoucher
            '
            Me.cardVoucher.BackColor = System.Drawing.Color.Transparent
            Me.cardVoucher.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardVoucher.BorderRadius = 16
            Me.cardVoucher.BorderThickness = 1
            Me.cardVoucher.Controls.Add(Me.lblStatusVoucher)
            Me.cardVoucher.Controls.Add(Me.btnPakaiVoucher)
            Me.cardVoucher.Controls.Add(Me.txtVoucher)
            Me.cardVoucher.Controls.Add(Me.lblVouchTitle)
            Me.cardVoucher.FillColor = System.Drawing.Color.White
            Me.cardVoucher.Location = New System.Drawing.Point(10, 180)
            Me.cardVoucher.Name = "cardVoucher"
            Me.cardVoucher.Size = New System.Drawing.Size(388, 108)
            Me.cardVoucher.TabIndex = 1
            Me.cardVoucher.UseTransparentBackground = True
            '
            'lblVouchTitle
            '
            Me.lblVouchTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblVouchTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblVouchTitle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblVouchTitle.Location = New System.Drawing.Point(14, 10)
            Me.lblVouchTitle.Name = "lblVouchTitle"
            Me.lblVouchTitle.Size = New System.Drawing.Size(360, 22)
            Me.lblVouchTitle.TabIndex = 0
            Me.lblVouchTitle.Text = "Kode Voucher (Coba: HEMAT10 / POTONG5K)"
            '
            'txtVoucher
            '
            Me.txtVoucher.BackColor = System.Drawing.Color.Transparent
            Me.txtVoucher.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtVoucher.BorderRadius = 12
            Me.txtVoucher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtVoucher.FillColor = System.Drawing.Color.White
            Me.txtVoucher.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtVoucher.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtVoucher.Location = New System.Drawing.Point(14, 36)
            Me.txtVoucher.Name = "txtVoucher"
            Me.txtVoucher.PlaceholderText = "Masukkan kode promo..."
            Me.txtVoucher.Size = New System.Drawing.Size(258, 36)
            Me.txtVoucher.TabIndex = 1
            Me.txtVoucher.BorderThickness = 1
            '
            'btnPakaiVoucher
            '
            Me.btnPakaiVoucher.BackColor = System.Drawing.Color.Transparent
            Me.btnPakaiVoucher.BorderRadius = 12
            Me.btnPakaiVoucher.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPakaiVoucher.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnPakaiVoucher.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnPakaiVoucher.ForeColor = System.Drawing.Color.White
            Me.btnPakaiVoucher.Location = New System.Drawing.Point(278, 36)
            Me.btnPakaiVoucher.Name = "btnPakaiVoucher"
            Me.btnPakaiVoucher.BorderThickness = 0
            Me.btnPakaiVoucher.Size = New System.Drawing.Size(96, 36)
            Me.btnPakaiVoucher.TabIndex = 2
            Me.btnPakaiVoucher.Text = "Pakai"
            Me.btnPakaiVoucher.UseTransparentBackground = True
            '
            'lblStatusVoucher
            '
            Me.lblStatusVoucher.BackColor = System.Drawing.Color.Transparent
            Me.lblStatusVoucher.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblStatusVoucher.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblStatusVoucher.Location = New System.Drawing.Point(14, 77)
            Me.lblStatusVoucher.Name = "lblStatusVoucher"
            Me.lblStatusVoucher.Size = New System.Drawing.Size(360, 22)
            Me.lblStatusVoucher.TabIndex = 3
            Me.lblStatusVoucher.Text = "Diskon bertingkat otomatis mulai belanja Rp100.000."
            '
            'cardSummary
            '
            Me.cardSummary.BackColor = System.Drawing.Color.Transparent
            Me.cardSummary.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardSummary.BorderRadius = 16
            Me.cardSummary.BorderThickness = 1
            Me.cardSummary.Controls.Add(Me.lblPoinDidapat)
            Me.cardSummary.Controls.Add(Me.lblTotal)
            Me.cardSummary.Controls.Add(Me.lblTotCap)
            Me.cardSummary.Controls.Add(Me.garisSummary)
            Me.cardSummary.Controls.Add(Me.lblPajak)
            Me.cardSummary.Controls.Add(Me.lblCapPajak)
            Me.cardSummary.Controls.Add(Me.lblDiskonPoin)
            Me.cardSummary.Controls.Add(Me.lblCapDiskonPoin)
            Me.cardSummary.Controls.Add(Me.lblDiskonVoucher)
            Me.cardSummary.Controls.Add(Me.lblCapDiskonVoucher)
            Me.cardSummary.Controls.Add(Me.lblDiskonBertingkat)
            Me.cardSummary.Controls.Add(Me.lblCapDiskonBertingkat)
            Me.cardSummary.Controls.Add(Me.lblSubtotal)
            Me.cardSummary.Controls.Add(Me.lblCapSubtotal)
            Me.cardSummary.Controls.Add(Me.lblSumTitle)
            Me.cardSummary.FillColor = System.Drawing.Color.White
            Me.cardSummary.Location = New System.Drawing.Point(10, 298)
            Me.cardSummary.Name = "cardSummary"
            Me.cardSummary.Size = New System.Drawing.Size(388, 250)
            Me.cardSummary.TabIndex = 2
            Me.cardSummary.UseTransparentBackground = True
            '
            'lblSumTitle
            '
            Me.lblSumTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblSumTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblSumTitle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblSumTitle.Location = New System.Drawing.Point(14, 12)
            Me.lblSumTitle.Name = "lblSumTitle"
            Me.lblSumTitle.Size = New System.Drawing.Size(360, 24)
            Me.lblSumTitle.TabIndex = 0
            Me.lblSumTitle.Text = "Rincian Pembayaran"
            '
            'lblCapSubtotal
            '
            Me.lblCapSubtotal.BackColor = System.Drawing.Color.Transparent
            Me.lblCapSubtotal.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblCapSubtotal.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblCapSubtotal.Location = New System.Drawing.Point(14, 44)
            Me.lblCapSubtotal.Name = "lblCapSubtotal"
            Me.lblCapSubtotal.Size = New System.Drawing.Size(180, 22)
            Me.lblCapSubtotal.TabIndex = 1
            Me.lblCapSubtotal.Text = "Subtotal"
            '
            'lblSubtotal
            '
            Me.lblSubtotal.BackColor = System.Drawing.Color.Transparent
            Me.lblSubtotal.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblSubtotal.Location = New System.Drawing.Point(194, 44)
            Me.lblSubtotal.Name = "lblSubtotal"
            Me.lblSubtotal.Size = New System.Drawing.Size(180, 22)
            Me.lblSubtotal.TabIndex = 2
            Me.lblSubtotal.Text = "Rp0"
            Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCapDiskonBertingkat
            '
            Me.lblCapDiskonBertingkat.BackColor = System.Drawing.Color.Transparent
            Me.lblCapDiskonBertingkat.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblCapDiskonBertingkat.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblCapDiskonBertingkat.Location = New System.Drawing.Point(14, 72)
            Me.lblCapDiskonBertingkat.Name = "lblCapDiskonBertingkat"
            Me.lblCapDiskonBertingkat.Size = New System.Drawing.Size(180, 22)
            Me.lblCapDiskonBertingkat.TabIndex = 3
            Me.lblCapDiskonBertingkat.Text = "Diskon Bertingkat"
            '
            'lblDiskonBertingkat
            '
            Me.lblDiskonBertingkat.BackColor = System.Drawing.Color.Transparent
            Me.lblDiskonBertingkat.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblDiskonBertingkat.ForeColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.lblDiskonBertingkat.Location = New System.Drawing.Point(194, 72)
            Me.lblDiskonBertingkat.Name = "lblDiskonBertingkat"
            Me.lblDiskonBertingkat.Size = New System.Drawing.Size(180, 22)
            Me.lblDiskonBertingkat.TabIndex = 4
            Me.lblDiskonBertingkat.Text = "Rp0"
            Me.lblDiskonBertingkat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCapDiskonVoucher
            '
            Me.lblCapDiskonVoucher.BackColor = System.Drawing.Color.Transparent
            Me.lblCapDiskonVoucher.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblCapDiskonVoucher.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblCapDiskonVoucher.Location = New System.Drawing.Point(14, 100)
            Me.lblCapDiskonVoucher.Name = "lblCapDiskonVoucher"
            Me.lblCapDiskonVoucher.Size = New System.Drawing.Size(180, 22)
            Me.lblCapDiskonVoucher.TabIndex = 5
            Me.lblCapDiskonVoucher.Text = "Diskon Voucher"
            '
            'lblDiskonVoucher
            '
            Me.lblDiskonVoucher.BackColor = System.Drawing.Color.Transparent
            Me.lblDiskonVoucher.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblDiskonVoucher.ForeColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.lblDiskonVoucher.Location = New System.Drawing.Point(194, 100)
            Me.lblDiskonVoucher.Name = "lblDiskonVoucher"
            Me.lblDiskonVoucher.Size = New System.Drawing.Size(180, 22)
            Me.lblDiskonVoucher.TabIndex = 6
            Me.lblDiskonVoucher.Text = "Rp0"
            Me.lblDiskonVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCapDiskonPoin
            '
            Me.lblCapDiskonPoin.BackColor = System.Drawing.Color.Transparent
            Me.lblCapDiskonPoin.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblCapDiskonPoin.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblCapDiskonPoin.Location = New System.Drawing.Point(14, 128)
            Me.lblCapDiskonPoin.Name = "lblCapDiskonPoin"
            Me.lblCapDiskonPoin.Size = New System.Drawing.Size(180, 22)
            Me.lblCapDiskonPoin.TabIndex = 7
            Me.lblCapDiskonPoin.Text = "Diskon Poin"
            '
            'lblDiskonPoin
            '
            Me.lblDiskonPoin.BackColor = System.Drawing.Color.Transparent
            Me.lblDiskonPoin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblDiskonPoin.ForeColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.lblDiskonPoin.Location = New System.Drawing.Point(194, 128)
            Me.lblDiskonPoin.Name = "lblDiskonPoin"
            Me.lblDiskonPoin.Size = New System.Drawing.Size(180, 22)
            Me.lblDiskonPoin.TabIndex = 8
            Me.lblDiskonPoin.Text = "Rp0"
            Me.lblDiskonPoin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCapPajak
            '
            Me.lblCapPajak.BackColor = System.Drawing.Color.Transparent
            Me.lblCapPajak.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblCapPajak.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblCapPajak.Location = New System.Drawing.Point(14, 156)
            Me.lblCapPajak.Name = "lblCapPajak"
            Me.lblCapPajak.Size = New System.Drawing.Size(180, 22)
            Me.lblCapPajak.TabIndex = 9
            Me.lblCapPajak.Text = "Pajak (PPN 11%)"
            '
            'lblPajak
            '
            Me.lblPajak.BackColor = System.Drawing.Color.Transparent
            Me.lblPajak.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblPajak.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblPajak.Location = New System.Drawing.Point(194, 156)
            Me.lblPajak.Name = "lblPajak"
            Me.lblPajak.Size = New System.Drawing.Size(180, 22)
            Me.lblPajak.TabIndex = 10
            Me.lblPajak.Text = "Rp0"
            Me.lblPajak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'garisSummary
            '
            Me.garisSummary.BackColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.garisSummary.Location = New System.Drawing.Point(14, 184)
            Me.garisSummary.Name = "garisSummary"
            Me.garisSummary.Size = New System.Drawing.Size(360, 1)
            Me.garisSummary.TabIndex = 11
            '
            'lblTotCap
            '
            Me.lblTotCap.BackColor = System.Drawing.Color.Transparent
            Me.lblTotCap.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblTotCap.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblTotCap.Location = New System.Drawing.Point(14, 192)
            Me.lblTotCap.Name = "lblTotCap"
            Me.lblTotCap.Size = New System.Drawing.Size(140, 32)
            Me.lblTotCap.TabIndex = 12
            Me.lblTotCap.Text = "TOTAL"
            '
            'lblTotal
            '
            Me.lblTotal.BackColor = System.Drawing.Color.Transparent
            Me.lblTotal.Font = New System.Drawing.Font("Georgia", 17.5!, System.Drawing.FontStyle.Bold)
            Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblTotal.Location = New System.Drawing.Point(150, 190)
            Me.lblTotal.Name = "lblTotal"
            Me.lblTotal.Size = New System.Drawing.Size(224, 34)
            Me.lblTotal.TabIndex = 13
            Me.lblTotal.Text = "Rp0"
            Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPoinDidapat
            '
            Me.lblPoinDidapat.BackColor = System.Drawing.Color.Transparent
            Me.lblPoinDidapat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblPoinDidapat.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblPoinDidapat.Location = New System.Drawing.Point(14, 224)
            Me.lblPoinDidapat.Name = "lblPoinDidapat"
            Me.lblPoinDidapat.Size = New System.Drawing.Size(360, 20)
            Me.lblPoinDidapat.TabIndex = 14
            Me.lblPoinDidapat.Text = "Daftar/cari member untuk kumpulkan poin"
            Me.lblPoinDidapat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnKembaliMenu
            '
            Me.btnKembaliMenu.BackColor = System.Drawing.Color.Transparent
            Me.btnKembaliMenu.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnKembaliMenu.BorderRadius = 12
            Me.btnKembaliMenu.BorderThickness = 1
            Me.btnKembaliMenu.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKembaliMenu.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnKembaliMenu.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnKembaliMenu.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnKembaliMenu.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnKembaliMenu.Location = New System.Drawing.Point(10, 560)
            Me.btnKembaliMenu.Name = "btnKembaliMenu"
            Me.btnKembaliMenu.Size = New System.Drawing.Size(148, 56)
            Me.btnKembaliMenu.TabIndex = 3
            Me.btnKembaliMenu.Text = "Kembali"
            Me.btnKembaliMenu.UseTransparentBackground = True
            '
            'btnLanjutBayar
            '
            Me.btnLanjutBayar.BackColor = System.Drawing.Color.Transparent
            Me.btnLanjutBayar.BorderRadius = 12
            Me.btnLanjutBayar.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLanjutBayar.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnLanjutBayar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnLanjutBayar.ForeColor = System.Drawing.Color.White
            Me.btnLanjutBayar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.btnLanjutBayar.ImageOffset = New System.Drawing.Point(6, 0)
            Me.btnLanjutBayar.Location = New System.Drawing.Point(168, 560)
            Me.btnLanjutBayar.Name = "btnLanjutBayar"
            Me.btnLanjutBayar.BorderThickness = 0
            Me.btnLanjutBayar.Size = New System.Drawing.Size(230, 56)
            Me.btnLanjutBayar.TabIndex = 4
            Me.btnLanjutBayar.Text = "Lanjut Bayar"
            Me.btnLanjutBayar.UseTransparentBackground = True
            '
            'pnlKiri
            '
            Me.pnlKiri.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlKiri.Controls.Add(Me.cardGrid)
            Me.pnlKiri.Controls.Add(Me.pnlSpacer)
            Me.pnlKiri.Controls.Add(Me.pnlUpsell)
            Me.pnlKiri.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKiri.Location = New System.Drawing.Point(0, 68)
            Me.pnlKiri.Name = "pnlKiri"
            Me.pnlKiri.Padding = New System.Windows.Forms.Padding(22, 18, 12, 18)
            Me.pnlKiri.Size = New System.Drawing.Size(760, 692)
            Me.pnlKiri.TabIndex = 2
            '
            'cardGrid
            '
            Me.cardGrid.BackColor = System.Drawing.Color.Transparent
            Me.cardGrid.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGrid.BorderRadius = 16
            Me.cardGrid.BorderThickness = 1
            Me.cardGrid.Controls.Add(Me.dgvKeranjang)
            Me.cardGrid.Controls.Add(Me.pnlItemBar)
            Me.cardGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGrid.FillColor = System.Drawing.Color.White
            Me.cardGrid.Location = New System.Drawing.Point(22, 18)
            Me.cardGrid.Name = "cardGrid"
            Me.cardGrid.Padding = New System.Windows.Forms.Padding(14)
            Me.cardGrid.Size = New System.Drawing.Size(726, 452)
            Me.cardGrid.TabIndex = 0
            Me.cardGrid.UseTransparentBackground = True
            '
            'dgvKeranjang
            '
            Me.dgvKeranjang.AllowUserToAddRows = False
            Me.dgvKeranjang.AllowUserToDeleteRows = False
            Me.dgvKeranjang.AutoGenerateColumns = False
            Me.dgvKeranjang.BackgroundColor = System.Drawing.Color.White
            Me.dgvKeranjang.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvKeranjang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvKeranjang.ColumnHeadersHeight = 40
            Me.dgvKeranjang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMenu, Me.colOpsi, Me.colHarga, Me.colQty, Me.colSubtotal})
            Me.dgvKeranjang.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvKeranjang.Location = New System.Drawing.Point(14, 14)
            Me.dgvKeranjang.MultiSelect = False
            Me.dgvKeranjang.Name = "dgvKeranjang"
            Me.dgvKeranjang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKeranjang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvKeranjang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKeranjang.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvKeranjang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvKeranjang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKeranjang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvKeranjang.ThemeStyle.RowsStyle.Height = 40
            Me.dgvKeranjang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKeranjang.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvKeranjang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvKeranjang.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvKeranjang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKeranjang.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvKeranjang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvKeranjang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvKeranjang.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvKeranjang.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvKeranjang.ReadOnly = True
            Me.dgvKeranjang.RowHeadersVisible = False
            Me.dgvKeranjang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvKeranjang.Size = New System.Drawing.Size(698, 368)
            Me.dgvKeranjang.TabIndex = 0
            Me.dgvKeranjang.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light
            '
            'colMenu
            '
            Me.colMenu.DataPropertyName = "NamaProduk"
            Me.colMenu.HeaderText = "Menu"
            Me.colMenu.Name = "colMenu"
            Me.colMenu.ReadOnly = True
            Me.colMenu.Width = 215
            '
            'colOpsi
            '
            Me.colOpsi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colOpsi.DataPropertyName = "OpsiDipilih"
            Me.colOpsi.HeaderText = "Opsi & Catatan"
            Me.colOpsi.Name = "colOpsi"
            Me.colOpsi.ReadOnly = True
            '
            'colHarga
            '
            Me.colHarga.DataPropertyName = "HargaSatuan"
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle1.Format = "C0"
            Me.colHarga.DefaultCellStyle = DataGridViewCellStyle1
            Me.colHarga.HeaderText = "Harga"
            Me.colHarga.Name = "colHarga"
            Me.colHarga.ReadOnly = True
            Me.colHarga.Width = 95
            '
            'colQty
            '
            Me.colQty.DataPropertyName = "Qty"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.colQty.DefaultCellStyle = DataGridViewCellStyle2
            Me.colQty.HeaderText = "Qty"
            Me.colQty.Name = "colQty"
            Me.colQty.ReadOnly = True
            Me.colQty.Width = 55
            '
            'colSubtotal
            '
            Me.colSubtotal.DataPropertyName = "SubtotalItem"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "C0"
            Me.colSubtotal.DefaultCellStyle = DataGridViewCellStyle3
            Me.colSubtotal.HeaderText = "Subtotal"
            Me.colSubtotal.Name = "colSubtotal"
            Me.colSubtotal.ReadOnly = True
            Me.colSubtotal.Width = 115
            '
            'pnlItemBar
            '
            Me.pnlItemBar.BackColor = System.Drawing.Color.White
            Me.pnlItemBar.Controls.Add(Me.btnHapus)
            Me.pnlItemBar.Controls.Add(Me.btnTambah)
            Me.pnlItemBar.Controls.Add(Me.btnKurang)
            Me.pnlItemBar.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlItemBar.Location = New System.Drawing.Point(14, 382)
            Me.pnlItemBar.Name = "pnlItemBar"
            Me.pnlItemBar.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
            Me.pnlItemBar.Size = New System.Drawing.Size(698, 56)
            Me.pnlItemBar.TabIndex = 1
            '
            'btnKurang
            '
            Me.btnKurang.BackColor = System.Drawing.Color.Transparent
            Me.btnKurang.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnKurang.BorderRadius = 10
            Me.btnKurang.BorderThickness = 1
            Me.btnKurang.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKurang.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnKurang.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnKurang.Location = New System.Drawing.Point(0, 10)
            Me.btnKurang.Name = "btnKurang"
            Me.btnKurang.Size = New System.Drawing.Size(48, 42)
            Me.btnKurang.TabIndex = 0
            Me.btnKurang.UseTransparentBackground = True
            '
            'btnTambah
            '
            Me.btnTambah.BackColor = System.Drawing.Color.Transparent
            Me.btnTambah.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnTambah.BorderRadius = 10
            Me.btnTambah.BorderThickness = 1
            Me.btnTambah.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTambah.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnTambah.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnTambah.Location = New System.Drawing.Point(56, 10)
            Me.btnTambah.Name = "btnTambah"
            Me.btnTambah.Size = New System.Drawing.Size(48, 42)
            Me.btnTambah.TabIndex = 1
            Me.btnTambah.UseTransparentBackground = True
            '
            'btnHapus
            '
            Me.btnHapus.BackColor = System.Drawing.Color.Transparent
            Me.btnHapus.BorderColor = System.Drawing.Color.FromArgb(234, 181, 176)
            Me.btnHapus.BorderRadius = 12
            Me.btnHapus.BorderThickness = 1
            Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnHapus.FillColor = System.Drawing.Color.FromArgb(253, 236, 236)
            Me.btnHapus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnHapus.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnHapus.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnHapus.Location = New System.Drawing.Point(114, 10)
            Me.btnHapus.Name = "btnHapus"
            Me.btnHapus.Size = New System.Drawing.Size(136, 42)
            Me.btnHapus.TabIndex = 2
            Me.btnHapus.Text = "Hapus Item"
            Me.btnHapus.UseTransparentBackground = True
            '
            'pnlSpacer
            '
            Me.pnlSpacer.BackColor = System.Drawing.Color.Transparent
            Me.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlSpacer.Location = New System.Drawing.Point(22, 470)
            Me.pnlSpacer.Name = "pnlSpacer"
            Me.pnlSpacer.Size = New System.Drawing.Size(726, 12)
            Me.pnlSpacer.TabIndex = 1
            '
            'pnlUpsell
            '
            Me.pnlUpsell.BackColor = System.Drawing.Color.Transparent
            Me.pnlUpsell.BorderColor = System.Drawing.Color.FromArgb(242, 196, 174)
            Me.pnlUpsell.BorderRadius = 16
            Me.pnlUpsell.BorderThickness = 1
            Me.pnlUpsell.Controls.Add(Me.flpUpsellItems)
            Me.pnlUpsell.Controls.Add(Me.btnLewatiUpsell)
            Me.pnlUpsell.Controls.Add(Me.lblUpsellHead)
            Me.pnlUpsell.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlUpsell.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.pnlUpsell.Location = New System.Drawing.Point(22, 482)
            Me.pnlUpsell.Name = "pnlUpsell"
            Me.pnlUpsell.Padding = New System.Windows.Forms.Padding(14)
            Me.pnlUpsell.Size = New System.Drawing.Size(726, 192)
            Me.pnlUpsell.TabIndex = 2
            Me.pnlUpsell.UseTransparentBackground = True
            Me.pnlUpsell.Visible = False
            '
            'lblUpsellHead
            '
            Me.lblUpsellHead.BackColor = System.Drawing.Color.Transparent
            Me.lblUpsellHead.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblUpsellHead.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblUpsellHead.Location = New System.Drawing.Point(14, 10)
            Me.lblUpsellHead.Name = "lblUpsellHead"
            Me.lblUpsellHead.Size = New System.Drawing.Size(520, 26)
            Me.lblUpsellHead.TabIndex = 0
            Me.lblUpsellHead.Text = "Lengkapi Pesanan Anda"
            '
            'btnLewatiUpsell
            '
            Me.btnLewatiUpsell.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnLewatiUpsell.BackColor = System.Drawing.Color.Transparent
            Me.btnLewatiUpsell.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnLewatiUpsell.BorderRadius = 10
            Me.btnLewatiUpsell.BorderThickness = 1
            Me.btnLewatiUpsell.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLewatiUpsell.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnLewatiUpsell.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnLewatiUpsell.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnLewatiUpsell.Location = New System.Drawing.Point(602, 8)
            Me.btnLewatiUpsell.Name = "btnLewatiUpsell"
            Me.btnLewatiUpsell.Size = New System.Drawing.Size(110, 30)
            Me.btnLewatiUpsell.TabIndex = 1
            Me.btnLewatiUpsell.Text = "Lewati"
            Me.btnLewatiUpsell.UseTransparentBackground = True
            '
            'flpUpsellItems
            '
            Me.flpUpsellItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.flpUpsellItems.BackColor = System.Drawing.Color.Transparent
            Me.flpUpsellItems.Location = New System.Drawing.Point(14, 44)
            Me.flpUpsellItems.Name = "flpUpsellItems"
            Me.flpUpsellItems.Size = New System.Drawing.Size(698, 134)
            Me.flpUpsellItems.TabIndex = 2
            Me.flpUpsellItems.WrapContents = False
            '
            'FrmKeranjang
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1180, 760)
            Me.Controls.Add(Me.pnlKiri)
            Me.Controls.Add(Me.pnlKanan)
            Me.Controls.Add(Me.pnlHead)
            Me.MinimumSize = New System.Drawing.Size(1020, 660)
            Me.Name = "FrmKeranjang"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Bistro Kiosk — Keranjang Pesanan"
            Me.pnlHead.ResumeLayout(False)
            CType(Me.icCart, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlKanan.ResumeLayout(False)
            Me.cardSummary.ResumeLayout(False)
            Me.cardVoucher.ResumeLayout(False)
            Me.cardMember.ResumeLayout(False)
            Me.pnlKiri.ResumeLayout(False)
            Me.cardGrid.ResumeLayout(False)
            CType(Me.dgvKeranjang, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlItemBar.ResumeLayout(False)
            Me.pnlUpsell.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlHead As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icCart As System.Windows.Forms.PictureBox
        Friend WithEvents lblHead As System.Windows.Forms.Label
        Friend WithEvents pnlKanan As System.Windows.Forms.Panel
        Friend WithEvents cardMember As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblMemTitle As System.Windows.Forms.Label
        Friend WithEvents txtNoHpMember As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnCariMember As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblInfoMember As System.Windows.Forms.Label
        Friend WithEvents txtPakaiPoin As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnPakaiPoin As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardVoucher As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblVouchTitle As System.Windows.Forms.Label
        Friend WithEvents txtVoucher As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnPakaiVoucher As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblStatusVoucher As System.Windows.Forms.Label
        Friend WithEvents cardSummary As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblSumTitle As System.Windows.Forms.Label
        Friend WithEvents lblCapSubtotal As System.Windows.Forms.Label
        Friend WithEvents lblSubtotal As System.Windows.Forms.Label
        Friend WithEvents lblCapDiskonBertingkat As System.Windows.Forms.Label
        Friend WithEvents lblDiskonBertingkat As System.Windows.Forms.Label
        Friend WithEvents lblCapDiskonVoucher As System.Windows.Forms.Label
        Friend WithEvents lblDiskonVoucher As System.Windows.Forms.Label
        Friend WithEvents lblCapDiskonPoin As System.Windows.Forms.Label
        Friend WithEvents lblDiskonPoin As System.Windows.Forms.Label
        Friend WithEvents lblCapPajak As System.Windows.Forms.Label
        Friend WithEvents lblPajak As System.Windows.Forms.Label
        Friend WithEvents garisSummary As System.Windows.Forms.Panel
        Friend WithEvents lblTotCap As System.Windows.Forms.Label
        Friend WithEvents lblTotal As System.Windows.Forms.Label
        Friend WithEvents lblPoinDidapat As System.Windows.Forms.Label
        Friend WithEvents btnKembaliMenu As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnLanjutBayar As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlKiri As System.Windows.Forms.Panel
        Friend WithEvents cardGrid As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvKeranjang As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colMenu As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colOpsi As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colHarga As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colSubtotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnlItemBar As System.Windows.Forms.Panel
        Friend WithEvents btnKurang As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnTambah As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnHapus As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlSpacer As System.Windows.Forms.Panel
        Friend WithEvents pnlUpsell As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblUpsellHead As System.Windows.Forms.Label
        Friend WithEvents btnLewatiUpsell As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents flpUpsellItems As System.Windows.Forms.FlowLayoutPanel
    End Class
End Namespace
