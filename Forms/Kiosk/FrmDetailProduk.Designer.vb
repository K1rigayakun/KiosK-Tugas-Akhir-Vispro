Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmDetailProduk
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
            Me.rootCard = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnTambah = New Guna.UI2.WinForms.Guna2Button()
            Me.btnBatal = New Guna.UI2.WinForms.Guna2Button()
            Me.lblHargaTotal = New System.Windows.Forms.Label()
            Me.lblTotCap = New System.Windows.Forms.Label()
            Me.btnTambahQty = New Guna.UI2.WinForms.Guna2Button()
            Me.txtQty = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnKurang = New Guna.UI2.WinForms.Guna2Button()
            Me.lblQtyTitle = New System.Windows.Forms.Label()
            Me.txtCatatan = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblCatatan = New System.Windows.Forms.Label()
            Me.pnlOpsiScroll = New System.Windows.Forms.Panel()
            Me.btnCloseX = New Guna.UI2.WinForms.Guna2Button()
            Me.lblHeadOpsi = New System.Windows.Forms.Label()
            Me.pnlKiri = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblHargaDasar = New System.Windows.Forms.Label()
            Me.lblDasarCaption = New System.Windows.Forms.Label()
            Me.lblDeskripsi = New System.Windows.Forms.Label()
            Me.lblNama = New System.Windows.Forms.Label()
            Me.lblKategori = New System.Windows.Forms.Label()
            Me.picProduk = New Guna.UI2.WinForms.Guna2PictureBox()
            Me.rootCard.SuspendLayout()
            Me.pnlKiri.SuspendLayout()
            CType(Me.picProduk, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'rootCard
            '
            Me.rootCard.BackColor = System.Drawing.Color.Transparent
            Me.rootCard.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.rootCard.BorderRadius = 16
            Me.rootCard.BorderThickness = 1
            Me.rootCard.Controls.Add(Me.btnTambah)
            Me.rootCard.Controls.Add(Me.btnBatal)
            Me.rootCard.Controls.Add(Me.lblHargaTotal)
            Me.rootCard.Controls.Add(Me.lblTotCap)
            Me.rootCard.Controls.Add(Me.btnTambahQty)
            Me.rootCard.Controls.Add(Me.txtQty)
            Me.rootCard.Controls.Add(Me.btnKurang)
            Me.rootCard.Controls.Add(Me.lblQtyTitle)
            Me.rootCard.Controls.Add(Me.txtCatatan)
            Me.rootCard.Controls.Add(Me.lblCatatan)
            Me.rootCard.Controls.Add(Me.pnlOpsiScroll)
            Me.rootCard.Controls.Add(Me.btnCloseX)
            Me.rootCard.Controls.Add(Me.lblHeadOpsi)
            Me.rootCard.Controls.Add(Me.pnlKiri)
            Me.rootCard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.rootCard.FillColor = System.Drawing.Color.White
            Me.rootCard.Location = New System.Drawing.Point(0, 0)
            Me.rootCard.Name = "rootCard"
            Me.rootCard.Size = New System.Drawing.Size(820, 620)
            Me.rootCard.TabIndex = 0
            Me.rootCard.UseTransparentBackground = True
            '
            'pnlKiri
            '
            Me.pnlKiri.BackColor = System.Drawing.Color.Transparent
            Me.pnlKiri.BorderRadius = 0
            Me.pnlKiri.Controls.Add(Me.lblHargaDasar)
            Me.pnlKiri.Controls.Add(Me.lblDasarCaption)
            Me.pnlKiri.Controls.Add(Me.lblDeskripsi)
            Me.pnlKiri.Controls.Add(Me.lblNama)
            Me.pnlKiri.Controls.Add(Me.lblKategori)
            Me.pnlKiri.Controls.Add(Me.picProduk)
            Me.pnlKiri.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.pnlKiri.Location = New System.Drawing.Point(18, 18)
            Me.pnlKiri.Name = "pnlKiri"
            Me.pnlKiri.Size = New System.Drawing.Size(310, 584)
            Me.pnlKiri.TabIndex = 0
            Me.pnlKiri.UseTransparentBackground = True
            '
            'picProduk
            '
            Me.picProduk.BackColor = System.Drawing.Color.Transparent
            Me.picProduk.BorderRadius = 12
            Me.picProduk.FillColor = System.Drawing.Color.White
            Me.picProduk.Location = New System.Drawing.Point(16, 16)
            Me.picProduk.Name = "picProduk"
            Me.picProduk.Size = New System.Drawing.Size(278, 230)
            Me.picProduk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picProduk.TabIndex = 0
            Me.picProduk.TabStop = False
            '
            'lblKategori
            '
            Me.lblKategori.BackColor = System.Drawing.Color.Transparent
            Me.lblKategori.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblKategori.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblKategori.Location = New System.Drawing.Point(18, 260)
            Me.lblKategori.Name = "lblKategori"
            Me.lblKategori.Size = New System.Drawing.Size(274, 22)
            Me.lblKategori.TabIndex = 1
            Me.lblKategori.Text = "KATEGORI"
            '
            'lblNama
            '
            Me.lblNama.BackColor = System.Drawing.Color.Transparent
            Me.lblNama.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblNama.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblNama.Location = New System.Drawing.Point(18, 284)
            Me.lblNama.Name = "lblNama"
            Me.lblNama.Size = New System.Drawing.Size(274, 58)
            Me.lblNama.TabIndex = 2
            Me.lblNama.Text = "Nama Menu Bistro"
            '
            'lblDeskripsi
            '
            Me.lblDeskripsi.BackColor = System.Drawing.Color.Transparent
            Me.lblDeskripsi.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblDeskripsi.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblDeskripsi.Location = New System.Drawing.Point(18, 348)
            Me.lblDeskripsi.Name = "lblDeskripsi"
            Me.lblDeskripsi.Size = New System.Drawing.Size(274, 96)
            Me.lblDeskripsi.TabIndex = 3
            Me.lblDeskripsi.Text = "Deskripsi lengkap hidangan bistro."
            '
            'lblDasarCaption
            '
            Me.lblDasarCaption.BackColor = System.Drawing.Color.Transparent
            Me.lblDasarCaption.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblDasarCaption.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblDasarCaption.Location = New System.Drawing.Point(18, 494)
            Me.lblDasarCaption.Name = "lblDasarCaption"
            Me.lblDasarCaption.Size = New System.Drawing.Size(274, 20)
            Me.lblDasarCaption.TabIndex = 4
            Me.lblDasarCaption.Text = "Harga Dasar"
            '
            'lblHargaDasar
            '
            Me.lblHargaDasar.BackColor = System.Drawing.Color.Transparent
            Me.lblHargaDasar.Font = New System.Drawing.Font("Georgia", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblHargaDasar.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblHargaDasar.Location = New System.Drawing.Point(18, 514)
            Me.lblHargaDasar.Name = "lblHargaDasar"
            Me.lblHargaDasar.Size = New System.Drawing.Size(274, 36)
            Me.lblHargaDasar.TabIndex = 5
            Me.lblHargaDasar.Text = "Rp0"
            '
            'lblHeadOpsi
            '
            Me.lblHeadOpsi.BackColor = System.Drawing.Color.Transparent
            Me.lblHeadOpsi.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblHeadOpsi.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblHeadOpsi.Location = New System.Drawing.Point(348, 20)
            Me.lblHeadOpsi.Name = "lblHeadOpsi"
            Me.lblHeadOpsi.Size = New System.Drawing.Size(400, 30)
            Me.lblHeadOpsi.TabIndex = 1
            Me.lblHeadOpsi.Text = "Kustomisasi Pesanan"
            '
            'btnCloseX
            '
            Me.btnCloseX.BackColor = System.Drawing.Color.Transparent
            Me.btnCloseX.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnCloseX.BorderRadius = 10
            Me.btnCloseX.BorderThickness = 1
            Me.btnCloseX.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCloseX.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnCloseX.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnCloseX.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnCloseX.Location = New System.Drawing.Point(764, 18)
            Me.btnCloseX.Name = "btnCloseX"
            Me.btnCloseX.Size = New System.Drawing.Size(38, 36)
            Me.btnCloseX.TabIndex = 2
            Me.btnCloseX.Text = "X"
            Me.btnCloseX.UseTransparentBackground = True
            '
            'pnlOpsiScroll
            '
            Me.pnlOpsiScroll.AutoScroll = True
            Me.pnlOpsiScroll.BackColor = System.Drawing.Color.White
            Me.pnlOpsiScroll.Location = New System.Drawing.Point(348, 58)
            Me.pnlOpsiScroll.Name = "pnlOpsiScroll"
            Me.pnlOpsiScroll.Size = New System.Drawing.Size(452, 340)
            Me.pnlOpsiScroll.TabIndex = 3
            '
            'lblCatatan
            '
            Me.lblCatatan.BackColor = System.Drawing.Color.Transparent
            Me.lblCatatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblCatatan.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblCatatan.Location = New System.Drawing.Point(348, 404)
            Me.lblCatatan.Name = "lblCatatan"
            Me.lblCatatan.Size = New System.Drawing.Size(450, 20)
            Me.lblCatatan.TabIndex = 4
            Me.lblCatatan.Text = "Catatan Tambahan (maks. 100 karakter)"
            '
            'txtCatatan
            '
            Me.txtCatatan.BackColor = System.Drawing.Color.Transparent
            Me.txtCatatan.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtCatatan.BorderRadius = 12
            Me.txtCatatan.FillColor = System.Drawing.Color.White
            Me.txtCatatan.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtCatatan.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtCatatan.Location = New System.Drawing.Point(348, 426)
            Me.txtCatatan.MaxLength = 100
            Me.txtCatatan.Name = "txtCatatan"
            Me.txtCatatan.PlaceholderText = "Contoh: saus dipisah, sedikit es..."
            Me.txtCatatan.Size = New System.Drawing.Size(452, 40)
            Me.txtCatatan.TabIndex = 5
            Me.txtCatatan.BorderThickness = 1
            '
            'lblQtyTitle
            '
            Me.lblQtyTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblQtyTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblQtyTitle.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblQtyTitle.Location = New System.Drawing.Point(348, 478)
            Me.lblQtyTitle.Name = "lblQtyTitle"
            Me.lblQtyTitle.Size = New System.Drawing.Size(140, 20)
            Me.lblQtyTitle.TabIndex = 6
            Me.lblQtyTitle.Text = "Jumlah (1-20)"
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
            Me.btnKurang.Location = New System.Drawing.Point(348, 500)
            Me.btnKurang.Name = "btnKurang"
            Me.btnKurang.Size = New System.Drawing.Size(44, 42)
            Me.btnKurang.TabIndex = 7
            Me.btnKurang.UseTransparentBackground = True
            '
            'txtQty
            '
            Me.txtQty.BackColor = System.Drawing.Color.Transparent
            Me.txtQty.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtQty.BorderRadius = 12
            Me.txtQty.FillColor = System.Drawing.Color.White
            Me.txtQty.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
            Me.txtQty.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtQty.Location = New System.Drawing.Point(398, 500)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(66, 42)
            Me.txtQty.TabIndex = 8
            Me.txtQty.BorderThickness = 1
            Me.txtQty.Text = "1"
            Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnTambahQty
            '
            Me.btnTambahQty.BackColor = System.Drawing.Color.Transparent
            Me.btnTambahQty.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnTambahQty.BorderRadius = 10
            Me.btnTambahQty.BorderThickness = 1
            Me.btnTambahQty.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTambahQty.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnTambahQty.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnTambahQty.Location = New System.Drawing.Point(470, 500)
            Me.btnTambahQty.Name = "btnTambahQty"
            Me.btnTambahQty.Size = New System.Drawing.Size(44, 42)
            Me.btnTambahQty.TabIndex = 9
            Me.btnTambahQty.UseTransparentBackground = True
            '
            'lblTotCap
            '
            Me.lblTotCap.BackColor = System.Drawing.Color.Transparent
            Me.lblTotCap.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblTotCap.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblTotCap.Location = New System.Drawing.Point(536, 478)
            Me.lblTotCap.Name = "lblTotCap"
            Me.lblTotCap.Size = New System.Drawing.Size(264, 20)
            Me.lblTotCap.TabIndex = 10
            Me.lblTotCap.Text = "Total Item"
            Me.lblTotCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblHargaTotal
            '
            Me.lblHargaTotal.BackColor = System.Drawing.Color.Transparent
            Me.lblHargaTotal.Font = New System.Drawing.Font("Georgia", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblHargaTotal.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblHargaTotal.Location = New System.Drawing.Point(536, 500)
            Me.lblHargaTotal.Name = "lblHargaTotal"
            Me.lblHargaTotal.Size = New System.Drawing.Size(264, 40)
            Me.lblHargaTotal.TabIndex = 11
            Me.lblHargaTotal.Text = "Rp0"
            Me.lblHargaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnBatal
            '
            Me.btnBatal.BackColor = System.Drawing.Color.Transparent
            Me.btnBatal.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnBatal.BorderRadius = 12
            Me.btnBatal.BorderThickness = 1
            Me.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBatal.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnBatal.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnBatal.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnBatal.Location = New System.Drawing.Point(348, 554)
            Me.btnBatal.Name = "btnBatal"
            Me.btnBatal.Size = New System.Drawing.Size(138, 48)
            Me.btnBatal.TabIndex = 12
            Me.btnBatal.Text = "Batal"
            Me.btnBatal.UseTransparentBackground = True
            '
            'btnTambah
            '
            Me.btnTambah.BackColor = System.Drawing.Color.Transparent
            Me.btnTambah.BorderRadius = 10
            Me.btnTambah.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTambah.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnTambah.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnTambah.ForeColor = System.Drawing.Color.White
            Me.btnTambah.ImageOffset = New System.Drawing.Point(-8, 0)
            Me.btnTambah.Location = New System.Drawing.Point(496, 554)
            Me.btnTambah.Name = "btnTambah"
            Me.btnTambah.BorderThickness = 0
            Me.btnTambah.Size = New System.Drawing.Size(304, 48)
            Me.btnTambah.TabIndex = 13
            Me.btnTambah.Text = "Tambah ke Keranjang"
            Me.btnTambah.UseTransparentBackground = True
            '
            'FrmDetailProduk
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(820, 620)
            Me.Controls.Add(Me.rootCard)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmDetailProduk"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Kustomisasi Pesanan"
            Me.rootCard.ResumeLayout(False)
            Me.pnlKiri.ResumeLayout(False)
            CType(Me.picProduk, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents rootCard As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents pnlKiri As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picProduk As Guna.UI2.WinForms.Guna2PictureBox
        Friend WithEvents lblKategori As System.Windows.Forms.Label
        Friend WithEvents lblNama As System.Windows.Forms.Label
        Friend WithEvents lblDeskripsi As System.Windows.Forms.Label
        Friend WithEvents lblDasarCaption As System.Windows.Forms.Label
        Friend WithEvents lblHargaDasar As System.Windows.Forms.Label
        Friend WithEvents lblHeadOpsi As System.Windows.Forms.Label
        Friend WithEvents btnCloseX As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlOpsiScroll As System.Windows.Forms.Panel
        Friend WithEvents lblCatatan As System.Windows.Forms.Label
        Friend WithEvents txtCatatan As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblQtyTitle As System.Windows.Forms.Label
        Friend WithEvents btnKurang As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents txtQty As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnTambahQty As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblTotCap As System.Windows.Forms.Label
        Friend WithEvents lblHargaTotal As System.Windows.Forms.Label
        Friend WithEvents btnBatal As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnTambah As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
