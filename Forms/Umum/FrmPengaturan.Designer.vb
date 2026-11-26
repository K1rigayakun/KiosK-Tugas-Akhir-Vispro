Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Umum

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmPengaturan
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
            Me.err = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnlWrap = New System.Windows.Forms.Panel()
            Me.card = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblNamaToko = New System.Windows.Forms.Label()
            Me.txtNamaToko = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblAlamat = New System.Windows.Forms.Label()
            Me.txtAlamat = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblTelepon = New System.Windows.Forms.Label()
            Me.txtTelepon = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblFooter = New System.Windows.Forms.Label()
            Me.txtFooter = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblVersi = New System.Windows.Forms.Label()
            Me.txtVersi = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblPajak = New System.Windows.Forms.Label()
            Me.txtPajak = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblService = New System.Windows.Forms.Label()
            Me.txtService = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblIdle = New System.Windows.Forms.Label()
            Me.txtIdle = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblAmbangStok = New System.Windows.Forms.Label()
            Me.txtAmbangStok = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblAmbangTunggu = New System.Windows.Forms.Label()
            Me.txtAmbangTunggu = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblPoinPerRupiah = New System.Windows.Forms.Label()
            Me.txtPoinPerRupiah = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblNilaiPoin = New System.Windows.Forms.Label()
            Me.txtNilaiPoin = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblBahasa = New System.Windows.Forms.Label()
            Me.cboBahasa = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.btnMuatUlang = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSimpan = New Guna.UI2.WinForms.Guna2Button()
            CType(Me.err, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlWrap.SuspendLayout()
            Me.card.SuspendLayout()
            Me.SuspendLayout()
            '
            'err
            '
            Me.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            Me.err.ContainerControl = Me
            '
            'pnlWrap
            '
            Me.pnlWrap.Controls.Add(Me.card)
            Me.pnlWrap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlWrap.Location = New System.Drawing.Point(0, 0)
            Me.pnlWrap.Name = "pnlWrap"
            Me.pnlWrap.Padding = New System.Windows.Forms.Padding(24)
            Me.pnlWrap.Size = New System.Drawing.Size(860, 620)
            Me.pnlWrap.TabIndex = 0
            '
            'card
            '
            Me.card.BackColor = System.Drawing.Color.Transparent
            Me.card.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.card.BorderRadius = 16
            Me.card.BorderThickness = 1
            Me.card.Controls.Add(Me.lblTitle)
            Me.card.Controls.Add(Me.lblNamaToko)
            Me.card.Controls.Add(Me.txtNamaToko)
            Me.card.Controls.Add(Me.lblAlamat)
            Me.card.Controls.Add(Me.txtAlamat)
            Me.card.Controls.Add(Me.lblTelepon)
            Me.card.Controls.Add(Me.txtTelepon)
            Me.card.Controls.Add(Me.lblFooter)
            Me.card.Controls.Add(Me.txtFooter)
            Me.card.Controls.Add(Me.lblVersi)
            Me.card.Controls.Add(Me.txtVersi)
            Me.card.Controls.Add(Me.lblPajak)
            Me.card.Controls.Add(Me.txtPajak)
            Me.card.Controls.Add(Me.lblService)
            Me.card.Controls.Add(Me.txtService)
            Me.card.Controls.Add(Me.lblIdle)
            Me.card.Controls.Add(Me.txtIdle)
            Me.card.Controls.Add(Me.lblAmbangStok)
            Me.card.Controls.Add(Me.txtAmbangStok)
            Me.card.Controls.Add(Me.lblAmbangTunggu)
            Me.card.Controls.Add(Me.txtAmbangTunggu)
            Me.card.Controls.Add(Me.lblPoinPerRupiah)
            Me.card.Controls.Add(Me.txtPoinPerRupiah)
            Me.card.Controls.Add(Me.lblNilaiPoin)
            Me.card.Controls.Add(Me.txtNilaiPoin)
            Me.card.Controls.Add(Me.lblBahasa)
            Me.card.Controls.Add(Me.cboBahasa)
            Me.card.Controls.Add(Me.btnMuatUlang)
            Me.card.Controls.Add(Me.btnSimpan)
            Me.card.Dock = System.Windows.Forms.DockStyle.Fill
            Me.card.FillColor = System.Drawing.Color.White
            Me.card.Location = New System.Drawing.Point(24, 24)
            Me.card.Name = "card"
            Me.card.Padding = New System.Windows.Forms.Padding(24)
            Me.card.Size = New System.Drawing.Size(812, 572)
            Me.card.TabIndex = 0
            Me.card.UseTransparentBackground = True
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Georgia", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblTitle.Location = New System.Drawing.Point(24, 16)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(560, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Konfigurasi Toko & Sistem Bistro Kiosk"
            '
            'lblNamaToko
            '
            Me.lblNamaToko.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblNamaToko.Location = New System.Drawing.Point(24, 58)
            Me.lblNamaToko.Name = "lblNamaToko"
            Me.lblNamaToko.Size = New System.Drawing.Size(360, 20)
            Me.lblNamaToko.TabIndex = 1
            Me.lblNamaToko.Text = "Nama Toko / Restoran"
            '
            'txtNamaToko
            '
            Me.txtNamaToko.BackColor = System.Drawing.Color.Transparent
            Me.txtNamaToko.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNamaToko.BorderRadius = 12
            Me.txtNamaToko.DefaultText = ""
            Me.txtNamaToko.FillColor = System.Drawing.Color.White
            Me.txtNamaToko.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNamaToko.Location = New System.Drawing.Point(24, 80)
            Me.txtNamaToko.Name = "txtNamaToko"
            Me.txtNamaToko.Size = New System.Drawing.Size(360, 38)
            Me.txtNamaToko.TabIndex = 2
            Me.txtNamaToko.BorderThickness = 1
            '
            'lblAlamat
            '
            Me.lblAlamat.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblAlamat.Location = New System.Drawing.Point(24, 128)
            Me.lblAlamat.Name = "lblAlamat"
            Me.lblAlamat.Size = New System.Drawing.Size(360, 20)
            Me.lblAlamat.TabIndex = 3
            Me.lblAlamat.Text = "Alamat Toko"
            '
            'txtAlamat
            '
            Me.txtAlamat.BackColor = System.Drawing.Color.Transparent
            Me.txtAlamat.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtAlamat.BorderRadius = 12
            Me.txtAlamat.DefaultText = ""
            Me.txtAlamat.FillColor = System.Drawing.Color.White
            Me.txtAlamat.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtAlamat.Location = New System.Drawing.Point(24, 150)
            Me.txtAlamat.Multiline = True
            Me.txtAlamat.Name = "txtAlamat"
            Me.txtAlamat.Size = New System.Drawing.Size(360, 56)
            Me.txtAlamat.TabIndex = 4
            Me.txtAlamat.BorderThickness = 1
            '
            'lblTelepon
            '
            Me.lblTelepon.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblTelepon.Location = New System.Drawing.Point(24, 216)
            Me.lblTelepon.Name = "lblTelepon"
            Me.lblTelepon.Size = New System.Drawing.Size(360, 20)
            Me.lblTelepon.TabIndex = 5
            Me.lblTelepon.Text = "No. Telepon Toko"
            '
            'txtTelepon
            '
            Me.txtTelepon.BackColor = System.Drawing.Color.Transparent
            Me.txtTelepon.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtTelepon.BorderRadius = 12
            Me.txtTelepon.DefaultText = ""
            Me.txtTelepon.FillColor = System.Drawing.Color.White
            Me.txtTelepon.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtTelepon.Location = New System.Drawing.Point(24, 238)
            Me.txtTelepon.Name = "txtTelepon"
            Me.txtTelepon.Size = New System.Drawing.Size(360, 38)
            Me.txtTelepon.TabIndex = 6
            Me.txtTelepon.BorderThickness = 1
            '
            'lblFooter
            '
            Me.lblFooter.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblFooter.Location = New System.Drawing.Point(24, 286)
            Me.lblFooter.Name = "lblFooter"
            Me.lblFooter.Size = New System.Drawing.Size(360, 20)
            Me.lblFooter.TabIndex = 7
            Me.lblFooter.Text = "Footer Struk Pelanggan"
            '
            'txtFooter
            '
            Me.txtFooter.BackColor = System.Drawing.Color.Transparent
            Me.txtFooter.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtFooter.BorderRadius = 12
            Me.txtFooter.DefaultText = ""
            Me.txtFooter.FillColor = System.Drawing.Color.White
            Me.txtFooter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtFooter.Location = New System.Drawing.Point(24, 308)
            Me.txtFooter.Multiline = True
            Me.txtFooter.Name = "txtFooter"
            Me.txtFooter.Size = New System.Drawing.Size(360, 56)
            Me.txtFooter.TabIndex = 8
            Me.txtFooter.BorderThickness = 1
            '
            'lblVersi
            '
            Me.lblVersi.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblVersi.Location = New System.Drawing.Point(24, 374)
            Me.lblVersi.Name = "lblVersi"
            Me.lblVersi.Size = New System.Drawing.Size(360, 20)
            Me.lblVersi.TabIndex = 9
            Me.lblVersi.Text = "Versi Aplikasi"
            '
            'txtVersi
            '
            Me.txtVersi.BackColor = System.Drawing.Color.Transparent
            Me.txtVersi.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtVersi.BorderRadius = 12
            Me.txtVersi.DefaultText = "1.0.0"
            Me.txtVersi.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.txtVersi.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtVersi.Location = New System.Drawing.Point(24, 396)
            Me.txtVersi.Name = "txtVersi"
            Me.txtVersi.ReadOnly = True
            Me.txtVersi.Size = New System.Drawing.Size(360, 38)
            Me.txtVersi.TabIndex = 10
            Me.txtVersi.BorderThickness = 1
            Me.txtVersi.Text = "1.0.0"
            '
            'lblPajak
            '
            Me.lblPajak.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblPajak.Location = New System.Drawing.Point(420, 58)
            Me.lblPajak.Name = "lblPajak"
            Me.lblPajak.Size = New System.Drawing.Size(172, 20)
            Me.lblPajak.TabIndex = 11
            Me.lblPajak.Text = "Pajak PPN (%)"
            '
            'txtPajak
            '
            Me.txtPajak.BackColor = System.Drawing.Color.Transparent
            Me.txtPajak.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtPajak.BorderRadius = 12
            Me.txtPajak.DefaultText = ""
            Me.txtPajak.FillColor = System.Drawing.Color.White
            Me.txtPajak.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtPajak.Location = New System.Drawing.Point(420, 80)
            Me.txtPajak.Name = "txtPajak"
            Me.txtPajak.Size = New System.Drawing.Size(172, 38)
            Me.txtPajak.TabIndex = 12
            Me.txtPajak.BorderThickness = 1
            Me.txtPajak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblService
            '
            Me.lblService.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblService.Location = New System.Drawing.Point(608, 58)
            Me.lblService.Name = "lblService"
            Me.lblService.Size = New System.Drawing.Size(176, 20)
            Me.lblService.TabIndex = 13
            Me.lblService.Text = "Service Charge (%)"
            '
            'txtService
            '
            Me.txtService.BackColor = System.Drawing.Color.Transparent
            Me.txtService.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtService.BorderRadius = 12
            Me.txtService.DefaultText = ""
            Me.txtService.FillColor = System.Drawing.Color.White
            Me.txtService.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtService.Location = New System.Drawing.Point(608, 80)
            Me.txtService.Name = "txtService"
            Me.txtService.Size = New System.Drawing.Size(176, 38)
            Me.txtService.TabIndex = 14
            Me.txtService.BorderThickness = 1
            Me.txtService.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblIdle
            '
            Me.lblIdle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblIdle.Location = New System.Drawing.Point(420, 128)
            Me.lblIdle.Name = "lblIdle"
            Me.lblIdle.Size = New System.Drawing.Size(364, 20)
            Me.lblIdle.TabIndex = 15
            Me.lblIdle.Text = "Batas Idle Kiosk (detik) [15 - 600]"
            '
            'txtIdle
            '
            Me.txtIdle.BackColor = System.Drawing.Color.Transparent
            Me.txtIdle.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtIdle.BorderRadius = 12
            Me.txtIdle.DefaultText = ""
            Me.txtIdle.FillColor = System.Drawing.Color.White
            Me.txtIdle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtIdle.Location = New System.Drawing.Point(420, 150)
            Me.txtIdle.Name = "txtIdle"
            Me.txtIdle.Size = New System.Drawing.Size(364, 38)
            Me.txtIdle.TabIndex = 16
            Me.txtIdle.BorderThickness = 1
            '
            'lblAmbangStok
            '
            Me.lblAmbangStok.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblAmbangStok.Location = New System.Drawing.Point(420, 198)
            Me.lblAmbangStok.Name = "lblAmbangStok"
            Me.lblAmbangStok.Size = New System.Drawing.Size(172, 20)
            Me.lblAmbangStok.TabIndex = 17
            Me.lblAmbangStok.Text = "Ambang Stok [1-100]"
            '
            'txtAmbangStok
            '
            Me.txtAmbangStok.BackColor = System.Drawing.Color.Transparent
            Me.txtAmbangStok.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtAmbangStok.BorderRadius = 12
            Me.txtAmbangStok.DefaultText = ""
            Me.txtAmbangStok.FillColor = System.Drawing.Color.White
            Me.txtAmbangStok.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtAmbangStok.Location = New System.Drawing.Point(420, 220)
            Me.txtAmbangStok.Name = "txtAmbangStok"
            Me.txtAmbangStok.Size = New System.Drawing.Size(172, 38)
            Me.txtAmbangStok.TabIndex = 18
            Me.txtAmbangStok.BorderThickness = 1
            '
            'lblAmbangTunggu
            '
            Me.lblAmbangTunggu.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblAmbangTunggu.Location = New System.Drawing.Point(608, 198)
            Me.lblAmbangTunggu.Name = "lblAmbangTunggu"
            Me.lblAmbangTunggu.Size = New System.Drawing.Size(176, 20)
            Me.lblAmbangTunggu.TabIndex = 19
            Me.lblAmbangTunggu.Text = "Telat Dapur (mnt)"
            '
            'txtAmbangTunggu
            '
            Me.txtAmbangTunggu.BackColor = System.Drawing.Color.Transparent
            Me.txtAmbangTunggu.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtAmbangTunggu.BorderRadius = 12
            Me.txtAmbangTunggu.DefaultText = ""
            Me.txtAmbangTunggu.FillColor = System.Drawing.Color.White
            Me.txtAmbangTunggu.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtAmbangTunggu.Location = New System.Drawing.Point(608, 220)
            Me.txtAmbangTunggu.Name = "txtAmbangTunggu"
            Me.txtAmbangTunggu.Size = New System.Drawing.Size(176, 38)
            Me.txtAmbangTunggu.TabIndex = 20
            Me.txtAmbangTunggu.BorderThickness = 1
            '
            'lblPoinPerRupiah
            '
            Me.lblPoinPerRupiah.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblPoinPerRupiah.Location = New System.Drawing.Point(420, 268)
            Me.lblPoinPerRupiah.Name = "lblPoinPerRupiah"
            Me.lblPoinPerRupiah.Size = New System.Drawing.Size(172, 20)
            Me.lblPoinPerRupiah.TabIndex = 21
            Me.lblPoinPerRupiah.Text = "Belanja / 1 Poin (Rp)"
            '
            'txtPoinPerRupiah
            '
            Me.txtPoinPerRupiah.BackColor = System.Drawing.Color.Transparent
            Me.txtPoinPerRupiah.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtPoinPerRupiah.BorderRadius = 12
            Me.txtPoinPerRupiah.DefaultText = ""
            Me.txtPoinPerRupiah.FillColor = System.Drawing.Color.White
            Me.txtPoinPerRupiah.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtPoinPerRupiah.Location = New System.Drawing.Point(420, 290)
            Me.txtPoinPerRupiah.Name = "txtPoinPerRupiah"
            Me.txtPoinPerRupiah.Size = New System.Drawing.Size(172, 38)
            Me.txtPoinPerRupiah.TabIndex = 22
            Me.txtPoinPerRupiah.BorderThickness = 1
            '
            'lblNilaiPoin
            '
            Me.lblNilaiPoin.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblNilaiPoin.Location = New System.Drawing.Point(608, 268)
            Me.lblNilaiPoin.Name = "lblNilaiPoin"
            Me.lblNilaiPoin.Size = New System.Drawing.Size(176, 20)
            Me.lblNilaiPoin.TabIndex = 23
            Me.lblNilaiPoin.Text = "Nilai 1 Poin (Rp)"
            '
            'txtNilaiPoin
            '
            Me.txtNilaiPoin.BackColor = System.Drawing.Color.Transparent
            Me.txtNilaiPoin.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNilaiPoin.BorderRadius = 12
            Me.txtNilaiPoin.DefaultText = ""
            Me.txtNilaiPoin.FillColor = System.Drawing.Color.White
            Me.txtNilaiPoin.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNilaiPoin.Location = New System.Drawing.Point(608, 290)
            Me.txtNilaiPoin.Name = "txtNilaiPoin"
            Me.txtNilaiPoin.Size = New System.Drawing.Size(176, 38)
            Me.txtNilaiPoin.TabIndex = 24
            Me.txtNilaiPoin.BorderThickness = 1
            '
            'lblBahasa
            '
            Me.lblBahasa.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblBahasa.Location = New System.Drawing.Point(420, 340)
            Me.lblBahasa.Name = "lblBahasa"
            Me.lblBahasa.Size = New System.Drawing.Size(364, 20)
            Me.lblBahasa.TabIndex = 25
            Me.lblBahasa.Text = "Bahasa Bawaan Kiosk"
            '
            'cboBahasa
            '
            Me.cboBahasa.BackColor = System.Drawing.Color.Transparent
            Me.cboBahasa.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboBahasa.BorderRadius = 12
            Me.cboBahasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboBahasa.FillColor = System.Drawing.Color.White
            Me.cboBahasa.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboBahasa.ItemHeight = 32
            Me.cboBahasa.Location = New System.Drawing.Point(420, 362)
            Me.cboBahasa.Name = "cboBahasa"
            Me.cboBahasa.Size = New System.Drawing.Size(364, 38)
            Me.cboBahasa.TabIndex = 26
            Me.cboBahasa.BorderThickness = 1
            '
            'btnMuatUlang
            '
            Me.btnMuatUlang.BackColor = System.Drawing.Color.Transparent
            Me.btnMuatUlang.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnMuatUlang.BorderRadius = 12
            Me.btnMuatUlang.BorderThickness = 1
            Me.btnMuatUlang.FillColor = System.Drawing.Color.White
            Me.btnMuatUlang.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnMuatUlang.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnMuatUlang.Location = New System.Drawing.Point(420, 480)
            Me.btnMuatUlang.Name = "btnMuatUlang"
            Me.btnMuatUlang.Size = New System.Drawing.Size(150, 48)
            Me.btnMuatUlang.TabIndex = 27
            Me.btnMuatUlang.Text = "Muat Ulang"
            Me.btnMuatUlang.UseTransparentBackground = True
            '
            'btnSimpan
            '
            Me.btnSimpan.BackColor = System.Drawing.Color.Transparent
            Me.btnSimpan.BorderRadius = 12
            Me.btnSimpan.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSimpan.ForeColor = System.Drawing.Color.White
            Me.btnSimpan.Location = New System.Drawing.Point(582, 480)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.BorderThickness = 0
            Me.btnSimpan.Size = New System.Drawing.Size(202, 48)
            Me.btnSimpan.TabIndex = 28
            Me.btnSimpan.Text = "Simpan Pengaturan"
            Me.btnSimpan.UseTransparentBackground = True
            '
            'FrmPengaturan
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(860, 620)
            Me.Controls.Add(Me.pnlWrap)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.Name = "FrmPengaturan"
            Me.Text = "Pengaturan Aplikasi"
            CType(Me.err, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlWrap.ResumeLayout(False)
            Me.card.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents err As System.Windows.Forms.ErrorProvider
        Friend WithEvents pnlWrap As System.Windows.Forms.Panel
        Friend WithEvents card As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblNamaToko As System.Windows.Forms.Label
        Friend WithEvents txtNamaToko As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblAlamat As System.Windows.Forms.Label
        Friend WithEvents txtAlamat As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblTelepon As System.Windows.Forms.Label
        Friend WithEvents txtTelepon As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblFooter As System.Windows.Forms.Label
        Friend WithEvents txtFooter As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblVersi As System.Windows.Forms.Label
        Friend WithEvents txtVersi As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblPajak As System.Windows.Forms.Label
        Friend WithEvents txtPajak As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblService As System.Windows.Forms.Label
        Friend WithEvents txtService As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblIdle As System.Windows.Forms.Label
        Friend WithEvents txtIdle As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblAmbangStok As System.Windows.Forms.Label
        Friend WithEvents txtAmbangStok As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblAmbangTunggu As System.Windows.Forms.Label
        Friend WithEvents txtAmbangTunggu As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblPoinPerRupiah As System.Windows.Forms.Label
        Friend WithEvents txtPoinPerRupiah As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblNilaiPoin As System.Windows.Forms.Label
        Friend WithEvents txtNilaiPoin As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblBahasa As System.Windows.Forms.Label
        Friend WithEvents cboBahasa As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnMuatUlang As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSimpan As Guna.UI2.WinForms.Guna2Button

    End Class
End Namespace
