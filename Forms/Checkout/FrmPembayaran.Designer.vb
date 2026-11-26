Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Checkout

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmPembayaran
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
            Me.pnlHead = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblHead = New System.Windows.Forms.Label()
            Me.pnlKiri = New System.Windows.Forms.Panel()
            Me.btnKembali = New Guna.UI2.WinForms.Guna2Button()
            Me.btnEWallet = New Guna.UI2.WinForms.Guna2Button()
            Me.btnKartu = New Guna.UI2.WinForms.Guna2Button()
            Me.btnTunai = New Guna.UI2.WinForms.Guna2Button()
            Me.btnQris = New Guna.UI2.WinForms.Guna2Button()
            Me.cardTotal = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblTotVal = New System.Windows.Forms.Label()
            Me.lblTotCap = New System.Windows.Forms.Label()
            Me.pnlKananWrap = New System.Windows.Forms.Panel()
            Me.cardDetail = New Guna.UI2.WinForms.Guna2Panel()
            Me.pnlQris = New System.Windows.Forms.Panel()
            Me.btnSudahBayar = New Guna.UI2.WinForms.Guna2Button()
            Me.lblCountdownQris = New System.Windows.Forms.Label()
            Me.picQris = New System.Windows.Forms.PictureBox()
            Me.lblQrisSub = New System.Windows.Forms.Label()
            Me.lblQrisJudul = New System.Windows.Forms.Label()
            Me.pnlTunai = New System.Windows.Forms.Panel()
            Me.btnBayarTunai = New Guna.UI2.WinForms.Guna2Button()
            Me.lstPecahan = New System.Windows.Forms.ListBox()
            Me.lblPecCap = New System.Windows.Forms.Label()
            Me.lblKembalian = New System.Windows.Forms.Label()
            Me.btnNom200 = New Guna.UI2.WinForms.Guna2Button()
            Me.btnNom100 = New Guna.UI2.WinForms.Guna2Button()
            Me.btnNom50 = New Guna.UI2.WinForms.Guna2Button()
            Me.btnNomPas = New Guna.UI2.WinForms.Guna2Button()
            Me.txtUangBayar = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblUangCap = New System.Windows.Forms.Label()
            Me.lblTunaiSub = New System.Windows.Forms.Label()
            Me.lblTunaiJudul = New System.Windows.Forms.Label()
            Me.pnlNonTunai = New System.Windows.Forms.Panel()
            Me.btnMulaiSimulasi = New Guna.UI2.WinForms.Guna2Button()
            Me.pgbSimulasi = New Guna.UI2.WinForms.Guna2ProgressBar()
            Me.picTerminal = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblNonTunaiSub = New System.Windows.Forms.Label()
            Me.lblNonTunaiJudul = New System.Windows.Forms.Label()
            Me.pnlHead.SuspendLayout()
            Me.pnlKiri.SuspendLayout()
            Me.cardTotal.SuspendLayout()
            Me.pnlKananWrap.SuspendLayout()
            Me.cardDetail.SuspendLayout()
            Me.pnlQris.SuspendLayout()
            CType(Me.picQris, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlTunai.SuspendLayout()
            Me.pnlNonTunai.SuspendLayout()
            CType(Me.picTerminal, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlHead
            '
            Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlHead.Controls.Add(Me.lblHead)
            Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHead.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlHead.Location = New System.Drawing.Point(0, 0)
            Me.pnlHead.Name = "pnlHead"
            Me.pnlHead.BorderRadius = 0
            Me.pnlHead.Size = New System.Drawing.Size(980, 66)
            Me.pnlHead.TabIndex = 0
            '
            'lblHead
            '
            Me.lblHead.BackColor = System.Drawing.Color.Transparent
            Me.lblHead.Font = New System.Drawing.Font("Georgia", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblHead.ForeColor = System.Drawing.Color.White
            Me.lblHead.Location = New System.Drawing.Point(24, 14)
            Me.lblHead.Name = "lblHead"
            Me.lblHead.Size = New System.Drawing.Size(600, 38)
            Me.lblHead.TabIndex = 0
            Me.lblHead.Text = "Pilih Metode Pembayaran"
            '
            'pnlKiri
            '
            Me.pnlKiri.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlKiri.Controls.Add(Me.btnKembali)
            Me.pnlKiri.Controls.Add(Me.btnEWallet)
            Me.pnlKiri.Controls.Add(Me.btnKartu)
            Me.pnlKiri.Controls.Add(Me.btnTunai)
            Me.pnlKiri.Controls.Add(Me.btnQris)
            Me.pnlKiri.Controls.Add(Me.cardTotal)
            Me.pnlKiri.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlKiri.Location = New System.Drawing.Point(0, 66)
            Me.pnlKiri.Name = "pnlKiri"
            Me.pnlKiri.Padding = New System.Windows.Forms.Padding(22, 18, 10, 18)
            Me.pnlKiri.Size = New System.Drawing.Size(340, 634)
            Me.pnlKiri.TabIndex = 1
            '
            'cardTotal
            '
            Me.cardTotal.BackColor = System.Drawing.Color.Transparent
            Me.cardTotal.BorderRadius = 16
            Me.cardTotal.Controls.Add(Me.lblTotVal)
            Me.cardTotal.Controls.Add(Me.lblTotCap)
            Me.cardTotal.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.cardTotal.Location = New System.Drawing.Point(22, 18)
            Me.cardTotal.Name = "cardTotal"
            Me.cardTotal.BorderThickness = 0
            Me.cardTotal.Size = New System.Drawing.Size(306, 108)
            Me.cardTotal.TabIndex = 0
            Me.cardTotal.UseTransparentBackground = True
            '
            'lblTotCap
            '
            Me.lblTotCap.BackColor = System.Drawing.Color.Transparent
            Me.lblTotCap.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblTotCap.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.lblTotCap.Location = New System.Drawing.Point(18, 16)
            Me.lblTotCap.Name = "lblTotCap"
            Me.lblTotCap.Size = New System.Drawing.Size(270, 22)
            Me.lblTotCap.TabIndex = 0
            Me.lblTotCap.Text = "Total Tagihan"
            '
            'lblTotVal
            '
            Me.lblTotVal.BackColor = System.Drawing.Color.Transparent
            Me.lblTotVal.Font = New System.Drawing.Font("Georgia", 22.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotVal.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblTotVal.Location = New System.Drawing.Point(18, 42)
            Me.lblTotVal.Name = "lblTotVal"
            Me.lblTotVal.Size = New System.Drawing.Size(270, 44)
            Me.lblTotVal.TabIndex = 1
            Me.lblTotVal.Text = "Rp0"
            '
            'btnQris
            '
            Me.btnQris.BackColor = System.Drawing.Color.Transparent
            Me.btnQris.BorderColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnQris.BorderRadius = 12
            Me.btnQris.BorderThickness = 2
            Me.btnQris.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQris.FillColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.btnQris.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.btnQris.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnQris.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnQris.ImageOffset = New System.Drawing.Point(16, 0)
            Me.btnQris.Location = New System.Drawing.Point(22, 140)
            Me.btnQris.Name = "btnQris"
            Me.btnQris.Size = New System.Drawing.Size(306, 58)
            Me.btnQris.TabIndex = 1
            Me.btnQris.Text = "   QRIS Instan"
            Me.btnQris.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnQris.UseTransparentBackground = True
            '
            'btnTunai
            '
            Me.btnTunai.BackColor = System.Drawing.Color.Transparent
            Me.btnTunai.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.btnTunai.BorderRadius = 12
            Me.btnTunai.BorderThickness = 1
            Me.btnTunai.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTunai.FillColor = System.Drawing.Color.White
            Me.btnTunai.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.btnTunai.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnTunai.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnTunai.ImageOffset = New System.Drawing.Point(16, 0)
            Me.btnTunai.Location = New System.Drawing.Point(22, 210)
            Me.btnTunai.Name = "btnTunai"
            Me.btnTunai.Size = New System.Drawing.Size(306, 58)
            Me.btnTunai.TabIndex = 2
            Me.btnTunai.Text = "   Tunai (Bayar di Kasir)"
            Me.btnTunai.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnTunai.UseTransparentBackground = True
            '
            'btnKartu
            '
            Me.btnKartu.BackColor = System.Drawing.Color.Transparent
            Me.btnKartu.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.btnKartu.BorderRadius = 12
            Me.btnKartu.BorderThickness = 1
            Me.btnKartu.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKartu.FillColor = System.Drawing.Color.White
            Me.btnKartu.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.btnKartu.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnKartu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnKartu.ImageOffset = New System.Drawing.Point(16, 0)
            Me.btnKartu.Location = New System.Drawing.Point(22, 280)
            Me.btnKartu.Name = "btnKartu"
            Me.btnKartu.Size = New System.Drawing.Size(306, 58)
            Me.btnKartu.TabIndex = 3
            Me.btnKartu.Text = "   Kartu Debit / Kredit"
            Me.btnKartu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnKartu.UseTransparentBackground = True
            '
            'btnEWallet
            '
            Me.btnEWallet.BackColor = System.Drawing.Color.Transparent
            Me.btnEWallet.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.btnEWallet.BorderRadius = 12
            Me.btnEWallet.BorderThickness = 1
            Me.btnEWallet.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnEWallet.FillColor = System.Drawing.Color.White
            Me.btnEWallet.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.btnEWallet.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnEWallet.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnEWallet.ImageOffset = New System.Drawing.Point(16, 0)
            Me.btnEWallet.Location = New System.Drawing.Point(22, 350)
            Me.btnEWallet.Name = "btnEWallet"
            Me.btnEWallet.Size = New System.Drawing.Size(306, 58)
            Me.btnEWallet.TabIndex = 4
            Me.btnEWallet.Text = "   E-Wallet (OVO / GoPay)"
            Me.btnEWallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnEWallet.UseTransparentBackground = True
            '
            'btnKembali
            '
            Me.btnKembali.BackColor = System.Drawing.Color.Transparent
            Me.btnKembali.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnKembali.BorderRadius = 12
            Me.btnKembali.BorderThickness = 1
            Me.btnKembali.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKembali.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnKembali.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnKembali.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnKembali.Location = New System.Drawing.Point(22, 428)
            Me.btnKembali.Name = "btnKembali"
            Me.btnKembali.Size = New System.Drawing.Size(306, 48)
            Me.btnKembali.TabIndex = 5
            Me.btnKembali.Text = "Kembali ke Keranjang"
            Me.btnKembali.UseTransparentBackground = True
            '
            'pnlKananWrap
            '
            Me.pnlKananWrap.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlKananWrap.Controls.Add(Me.cardDetail)
            Me.pnlKananWrap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKananWrap.Location = New System.Drawing.Point(340, 66)
            Me.pnlKananWrap.Name = "pnlKananWrap"
            Me.pnlKananWrap.Padding = New System.Windows.Forms.Padding(10, 18, 22, 18)
            Me.pnlKananWrap.Size = New System.Drawing.Size(640, 634)
            Me.pnlKananWrap.TabIndex = 2
            '
            'cardDetail
            '
            Me.cardDetail.BackColor = System.Drawing.Color.Transparent
            Me.cardDetail.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardDetail.BorderRadius = 16
            Me.cardDetail.BorderThickness = 1
            Me.cardDetail.Controls.Add(Me.pnlQris)
            Me.cardDetail.Controls.Add(Me.pnlTunai)
            Me.cardDetail.Controls.Add(Me.pnlNonTunai)
            Me.cardDetail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardDetail.FillColor = System.Drawing.Color.White
            Me.cardDetail.Location = New System.Drawing.Point(10, 18)
            Me.cardDetail.Name = "cardDetail"
            Me.cardDetail.Padding = New System.Windows.Forms.Padding(22)
            Me.cardDetail.Size = New System.Drawing.Size(608, 598)
            Me.cardDetail.TabIndex = 0
            Me.cardDetail.UseTransparentBackground = True
            '
            'pnlQris
            '
            Me.pnlQris.BackColor = System.Drawing.Color.Transparent
            Me.pnlQris.Controls.Add(Me.btnSudahBayar)
            Me.pnlQris.Controls.Add(Me.lblCountdownQris)
            Me.pnlQris.Controls.Add(Me.picQris)
            Me.pnlQris.Controls.Add(Me.lblQrisSub)
            Me.pnlQris.Controls.Add(Me.lblQrisJudul)
            Me.pnlQris.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlQris.Location = New System.Drawing.Point(22, 22)
            Me.pnlQris.Name = "pnlQris"
            Me.pnlQris.Size = New System.Drawing.Size(564, 554)
            Me.pnlQris.TabIndex = 0
            '
            'lblQrisJudul
            '
            Me.lblQrisJudul.BackColor = System.Drawing.Color.Transparent
            Me.lblQrisJudul.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblQrisJudul.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblQrisJudul.Location = New System.Drawing.Point(10, 8)
            Me.lblQrisJudul.Name = "lblQrisJudul"
            Me.lblQrisJudul.Size = New System.Drawing.Size(520, 32)
            Me.lblQrisJudul.TabIndex = 0
            Me.lblQrisJudul.Text = "Scan QRIS untuk Membayar (Simulasi)"
            '
            'lblQrisSub
            '
            Me.lblQrisSub.BackColor = System.Drawing.Color.Transparent
            Me.lblQrisSub.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblQrisSub.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblQrisSub.Location = New System.Drawing.Point(10, 42)
            Me.lblQrisSub.Name = "lblQrisSub"
            Me.lblQrisSub.Size = New System.Drawing.Size(520, 24)
            Me.lblQrisSub.TabIndex = 1
            Me.lblQrisSub.Text = "Pesanan otomatis masuk ke dapur setelah pembayaran dikonfirmasi."
            '
            'picQris
            '
            Me.picQris.BackColor = System.Drawing.Color.White
            Me.picQris.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.picQris.Location = New System.Drawing.Point(155, 84)
            Me.picQris.Name = "picQris"
            Me.picQris.Size = New System.Drawing.Size(230, 230)
            Me.picQris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picQris.TabIndex = 2
            Me.picQris.TabStop = False
            '
            'lblCountdownQris
            '
            Me.lblCountdownQris.BackColor = System.Drawing.Color.Transparent
            Me.lblCountdownQris.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblCountdownQris.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblCountdownQris.Location = New System.Drawing.Point(10, 328)
            Me.lblCountdownQris.Name = "lblCountdownQris"
            Me.lblCountdownQris.Size = New System.Drawing.Size(520, 30)
            Me.lblCountdownQris.TabIndex = 3
            Me.lblCountdownQris.Text = "Berlaku selama 02:00"
            Me.lblCountdownQris.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSudahBayar
            '
            Me.btnSudahBayar.BackColor = System.Drawing.Color.Transparent
            Me.btnSudahBayar.BorderRadius = 12
            Me.btnSudahBayar.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSudahBayar.FillColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.btnSudahBayar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSudahBayar.ForeColor = System.Drawing.Color.White
            Me.btnSudahBayar.ImageOffset = New System.Drawing.Point(-8, 0)
            Me.btnSudahBayar.Location = New System.Drawing.Point(80, 380)
            Me.btnSudahBayar.Name = "btnSudahBayar"
            Me.btnSudahBayar.BorderThickness = 0
            Me.btnSudahBayar.Size = New System.Drawing.Size(380, 56)
            Me.btnSudahBayar.TabIndex = 4
            Me.btnSudahBayar.Text = "Simulasi Sudah Bayar (Lunas)"
            Me.btnSudahBayar.UseTransparentBackground = True
            '
            'pnlTunai
            '
            Me.pnlTunai.BackColor = System.Drawing.Color.Transparent
            Me.pnlTunai.Controls.Add(Me.btnBayarTunai)
            Me.pnlTunai.Controls.Add(Me.lstPecahan)
            Me.pnlTunai.Controls.Add(Me.lblPecCap)
            Me.pnlTunai.Controls.Add(Me.lblKembalian)
            Me.pnlTunai.Controls.Add(Me.btnNom200)
            Me.pnlTunai.Controls.Add(Me.btnNom100)
            Me.pnlTunai.Controls.Add(Me.btnNom50)
            Me.pnlTunai.Controls.Add(Me.btnNomPas)
            Me.pnlTunai.Controls.Add(Me.txtUangBayar)
            Me.pnlTunai.Controls.Add(Me.lblUangCap)
            Me.pnlTunai.Controls.Add(Me.lblTunaiSub)
            Me.pnlTunai.Controls.Add(Me.lblTunaiJudul)
            Me.pnlTunai.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlTunai.Location = New System.Drawing.Point(22, 22)
            Me.pnlTunai.Name = "pnlTunai"
            Me.pnlTunai.Size = New System.Drawing.Size(564, 554)
            Me.pnlTunai.TabIndex = 1
            Me.pnlTunai.Visible = False
            '
            'lblTunaiJudul
            '
            Me.lblTunaiJudul.BackColor = System.Drawing.Color.Transparent
            Me.lblTunaiJudul.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblTunaiJudul.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblTunaiJudul.Location = New System.Drawing.Point(10, 8)
            Me.lblTunaiJudul.Name = "lblTunaiJudul"
            Me.lblTunaiJudul.Size = New System.Drawing.Size(520, 32)
            Me.lblTunaiJudul.TabIndex = 0
            Me.lblTunaiJudul.Text = "Pembayaran Tunai di Kasir"
            '
            'lblTunaiSub
            '
            Me.lblTunaiSub.BackColor = System.Drawing.Color.Transparent
            Me.lblTunaiSub.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblTunaiSub.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblTunaiSub.Location = New System.Drawing.Point(10, 42)
            Me.lblTunaiSub.Name = "lblTunaiSub"
            Me.lblTunaiSub.Size = New System.Drawing.Size(520, 40)
            Me.lblTunaiSub.TabIndex = 1
            Me.lblTunaiSub.Text = "Anda akan mendapatkan nomor antrian dan struk untuk dibayarkan ke kasir. Isi perkiraan uang tunai Anda di bawah (opsional):"
            '
            'lblUangCap
            '
            Me.lblUangCap.BackColor = System.Drawing.Color.Transparent
            Me.lblUangCap.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblUangCap.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblUangCap.Location = New System.Drawing.Point(10, 96)
            Me.lblUangCap.Name = "lblUangCap"
            Me.lblUangCap.Size = New System.Drawing.Size(240, 22)
            Me.lblUangCap.TabIndex = 2
            Me.lblUangCap.Text = "Estimasi Uang Dibayar"
            '
            'txtUangBayar
            '
            Me.txtUangBayar.BackColor = System.Drawing.Color.Transparent
            Me.txtUangBayar.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtUangBayar.BorderRadius = 12
            Me.txtUangBayar.FillColor = System.Drawing.Color.White
            Me.txtUangBayar.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtUangBayar.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtUangBayar.Location = New System.Drawing.Point(10, 122)
            Me.txtUangBayar.Name = "txtUangBayar"
            Me.txtUangBayar.PlaceholderText = "Nominal uang tunai..."
            Me.txtUangBayar.Size = New System.Drawing.Size(280, 42)
            Me.txtUangBayar.TabIndex = 3
            Me.txtUangBayar.BorderThickness = 1
            '
            'btnNomPas
            '
            Me.btnNomPas.BackColor = System.Drawing.Color.Transparent
            Me.btnNomPas.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnNomPas.BorderRadius = 10
            Me.btnNomPas.BorderThickness = 1
            Me.btnNomPas.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNomPas.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNomPas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnNomPas.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnNomPas.Location = New System.Drawing.Point(10, 174)
            Me.btnNomPas.Name = "btnNomPas"
            Me.btnNomPas.Size = New System.Drawing.Size(110, 34)
            Me.btnNomPas.TabIndex = 4
            Me.btnNomPas.Text = "Uang Pas"
            Me.btnNomPas.UseTransparentBackground = True
            '
            'btnNom50
            '
            Me.btnNom50.BackColor = System.Drawing.Color.Transparent
            Me.btnNom50.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnNom50.BorderRadius = 10
            Me.btnNom50.BorderThickness = 1
            Me.btnNom50.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNom50.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNom50.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnNom50.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnNom50.Location = New System.Drawing.Point(128, 174)
            Me.btnNom50.Name = "btnNom50"
            Me.btnNom50.Size = New System.Drawing.Size(110, 34)
            Me.btnNom50.TabIndex = 5
            Me.btnNom50.Text = "Rp50.000"
            Me.btnNom50.UseTransparentBackground = True
            '
            'btnNom100
            '
            Me.btnNom100.BackColor = System.Drawing.Color.Transparent
            Me.btnNom100.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnNom100.BorderRadius = 10
            Me.btnNom100.BorderThickness = 1
            Me.btnNom100.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNom100.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNom100.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnNom100.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnNom100.Location = New System.Drawing.Point(246, 174)
            Me.btnNom100.Name = "btnNom100"
            Me.btnNom100.Size = New System.Drawing.Size(110, 34)
            Me.btnNom100.TabIndex = 6
            Me.btnNom100.Text = "Rp100.000"
            Me.btnNom100.UseTransparentBackground = True
            '
            'btnNom200
            '
            Me.btnNom200.BackColor = System.Drawing.Color.Transparent
            Me.btnNom200.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnNom200.BorderRadius = 10
            Me.btnNom200.BorderThickness = 1
            Me.btnNom200.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNom200.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnNom200.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnNom200.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnNom200.Location = New System.Drawing.Point(364, 174)
            Me.btnNom200.Name = "btnNom200"
            Me.btnNom200.Size = New System.Drawing.Size(110, 34)
            Me.btnNom200.TabIndex = 7
            Me.btnNom200.Text = "Rp200.000"
            Me.btnNom200.UseTransparentBackground = True
            '
            'lblKembalian
            '
            Me.lblKembalian.BackColor = System.Drawing.Color.Transparent
            Me.lblKembalian.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblKembalian.ForeColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.lblKembalian.Location = New System.Drawing.Point(10, 222)
            Me.lblKembalian.Name = "lblKembalian"
            Me.lblKembalian.Size = New System.Drawing.Size(520, 32)
            Me.lblKembalian.TabIndex = 8
            Me.lblKembalian.Text = "Estimasi Kembalian: Rp0"
            '
            'lblPecCap
            '
            Me.lblPecCap.BackColor = System.Drawing.Color.Transparent
            Me.lblPecCap.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblPecCap.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblPecCap.Location = New System.Drawing.Point(10, 260)
            Me.lblPecCap.Name = "lblPecCap"
            Me.lblPecCap.Size = New System.Drawing.Size(300, 20)
            Me.lblPecCap.TabIndex = 9
            Me.lblPecCap.Text = "Estimasi Pecahan Kembalian:"
            '
            'lstPecahan
            '
            Me.lstPecahan.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.lstPecahan.Font = New System.Drawing.Font("Consolas", 9.5!)
            Me.lstPecahan.FormattingEnabled = True
            Me.lstPecahan.ItemHeight = 15
            Me.lstPecahan.Location = New System.Drawing.Point(10, 284)
            Me.lstPecahan.Name = "lstPecahan"
            Me.lstPecahan.Size = New System.Drawing.Size(520, 124)
            Me.lstPecahan.TabIndex = 10
            '
            'btnBayarTunai
            '
            Me.btnBayarTunai.BackColor = System.Drawing.Color.Transparent
            Me.btnBayarTunai.BorderRadius = 12
            Me.btnBayarTunai.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBayarTunai.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnBayarTunai.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnBayarTunai.ForeColor = System.Drawing.Color.White
            Me.btnBayarTunai.ImageOffset = New System.Drawing.Point(-8, 0)
            Me.btnBayarTunai.Location = New System.Drawing.Point(10, 424)
            Me.btnBayarTunai.Name = "btnBayarTunai"
            Me.btnBayarTunai.BorderThickness = 0
            Me.btnBayarTunai.Size = New System.Drawing.Size(520, 56)
            Me.btnBayarTunai.TabIndex = 11
            Me.btnBayarTunai.Text = "Buat Pesanan & Bayar di Kasir"
            Me.btnBayarTunai.UseTransparentBackground = True
            '
            'pnlNonTunai
            '
            Me.pnlNonTunai.BackColor = System.Drawing.Color.Transparent
            Me.pnlNonTunai.Controls.Add(Me.btnMulaiSimulasi)
            Me.pnlNonTunai.Controls.Add(Me.pgbSimulasi)
            Me.pnlNonTunai.Controls.Add(Me.picTerminal)
            Me.pnlNonTunai.Controls.Add(Me.lblNonTunaiSub)
            Me.pnlNonTunai.Controls.Add(Me.lblNonTunaiJudul)
            Me.pnlNonTunai.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlNonTunai.Location = New System.Drawing.Point(22, 22)
            Me.pnlNonTunai.Name = "pnlNonTunai"
            Me.pnlNonTunai.Size = New System.Drawing.Size(564, 554)
            Me.pnlNonTunai.TabIndex = 2
            Me.pnlNonTunai.Visible = False
            '
            'lblNonTunaiJudul
            '
            Me.lblNonTunaiJudul.BackColor = System.Drawing.Color.Transparent
            Me.lblNonTunaiJudul.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblNonTunaiJudul.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblNonTunaiJudul.Location = New System.Drawing.Point(10, 24)
            Me.lblNonTunaiJudul.Name = "lblNonTunaiJudul"
            Me.lblNonTunaiJudul.Size = New System.Drawing.Size(520, 36)
            Me.lblNonTunaiJudul.TabIndex = 0
            Me.lblNonTunaiJudul.Text = "Pembayaran Non-Tunai"
            Me.lblNonTunaiJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblNonTunaiSub
            '
            Me.lblNonTunaiSub.BackColor = System.Drawing.Color.Transparent
            Me.lblNonTunaiSub.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblNonTunaiSub.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblNonTunaiSub.Location = New System.Drawing.Point(40, 68)
            Me.lblNonTunaiSub.Name = "lblNonTunaiSub"
            Me.lblNonTunaiSub.Size = New System.Drawing.Size(460, 44)
            Me.lblNonTunaiSub.TabIndex = 1
            Me.lblNonTunaiSub.Text = "Tekan tombol di bawah untuk mensimulasikan pembacaan kartu / otorisasi E-Wallet selama 2 detik."
            Me.lblNonTunaiSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'picTerminal
            '
            Me.picTerminal.BackColor = System.Drawing.Color.Transparent
            Me.picTerminal.FillColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.picTerminal.Location = New System.Drawing.Point(210, 136)
            Me.picTerminal.Name = "picTerminal"
            Me.picTerminal.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.picTerminal.Size = New System.Drawing.Size(120, 120)
            Me.picTerminal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.picTerminal.TabIndex = 2
            Me.picTerminal.TabStop = False
            Me.picTerminal.UseTransparentBackground = True
            '
            'pgbSimulasi
            '
            Me.pgbSimulasi.BackColor = System.Drawing.Color.Transparent
            Me.pgbSimulasi.BorderRadius = 6
            Me.pgbSimulasi.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.pgbSimulasi.Location = New System.Drawing.Point(70, 286)
            Me.pgbSimulasi.Name = "pgbSimulasi"
            Me.pgbSimulasi.ProgressColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.pgbSimulasi.ProgressColor2 = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.pgbSimulasi.Size = New System.Drawing.Size(400, 16)
            Me.pgbSimulasi.TabIndex = 3
            '
            'btnMulaiSimulasi
            '
            Me.btnMulaiSimulasi.BackColor = System.Drawing.Color.Transparent
            Me.btnMulaiSimulasi.BorderRadius = 12
            Me.btnMulaiSimulasi.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMulaiSimulasi.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnMulaiSimulasi.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnMulaiSimulasi.ForeColor = System.Drawing.Color.White
            Me.btnMulaiSimulasi.Location = New System.Drawing.Point(80, 336)
            Me.btnMulaiSimulasi.Name = "btnMulaiSimulasi"
            Me.btnMulaiSimulasi.BorderThickness = 0
            Me.btnMulaiSimulasi.Size = New System.Drawing.Size(380, 56)
            Me.btnMulaiSimulasi.TabIndex = 4
            Me.btnMulaiSimulasi.Text = "Tempel Kartu / Konfirmasi"
            Me.btnMulaiSimulasi.UseTransparentBackground = True
            '
            'FrmPembayaran
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(980, 700)
            Me.Controls.Add(Me.pnlKananWrap)
            Me.Controls.Add(Me.pnlKiri)
            Me.Controls.Add(Me.pnlHead)
            Me.MinimumSize = New System.Drawing.Size(940, 640)
            Me.Name = "FrmPembayaran"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Bistro Kiosk — Pembayaran"
            Me.pnlHead.ResumeLayout(False)
            Me.pnlKiri.ResumeLayout(False)
            Me.cardTotal.ResumeLayout(False)
            Me.pnlKananWrap.ResumeLayout(False)
            Me.cardDetail.ResumeLayout(False)
            Me.pnlQris.ResumeLayout(False)
            CType(Me.picQris, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlTunai.ResumeLayout(False)
            Me.pnlNonTunai.ResumeLayout(False)
            CType(Me.picTerminal, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlHead As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblHead As System.Windows.Forms.Label
        Friend WithEvents pnlKiri As System.Windows.Forms.Panel
        Friend WithEvents cardTotal As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTotCap As System.Windows.Forms.Label
        Friend WithEvents lblTotVal As System.Windows.Forms.Label
        Friend WithEvents btnQris As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnTunai As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnKartu As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnEWallet As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnKembali As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlKananWrap As System.Windows.Forms.Panel
        Friend WithEvents cardDetail As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents pnlQris As System.Windows.Forms.Panel
        Friend WithEvents lblQrisJudul As System.Windows.Forms.Label
        Friend WithEvents lblQrisSub As System.Windows.Forms.Label
        Friend WithEvents picQris As System.Windows.Forms.PictureBox
        Friend WithEvents lblCountdownQris As System.Windows.Forms.Label
        Friend WithEvents btnSudahBayar As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlTunai As System.Windows.Forms.Panel
        Friend WithEvents lblTunaiJudul As System.Windows.Forms.Label
        Friend WithEvents lblTunaiSub As System.Windows.Forms.Label
        Friend WithEvents lblUangCap As System.Windows.Forms.Label
        Friend WithEvents txtUangBayar As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnNomPas As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnNom50 As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnNom100 As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnNom200 As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblKembalian As System.Windows.Forms.Label
        Friend WithEvents lblPecCap As System.Windows.Forms.Label
        Friend WithEvents lstPecahan As System.Windows.Forms.ListBox
        Friend WithEvents btnBayarTunai As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlNonTunai As System.Windows.Forms.Panel
        Friend WithEvents lblNonTunaiJudul As System.Windows.Forms.Label
        Friend WithEvents lblNonTunaiSub As System.Windows.Forms.Label
        Friend WithEvents picTerminal As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents pgbSimulasi As Guna.UI2.WinForms.Guna2ProgressBar
        Friend WithEvents btnMulaiSimulasi As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
