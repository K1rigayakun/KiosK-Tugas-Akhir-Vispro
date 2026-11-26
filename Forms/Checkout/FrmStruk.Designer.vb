Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Checkout

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmStruk
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
            Me.lblStatusArahan = New System.Windows.Forms.Label()
            Me.lblAntrian = New System.Windows.Forms.Label()
            Me.lblCap = New System.Windows.Forms.Label()
            Me.pnlFoot = New System.Windows.Forms.Panel()
            Me.btnSelesai = New Guna.UI2.WinForms.Guna2Button()
            Me.btnCetak = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSimpan = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlBody = New System.Windows.Forms.Panel()
            Me.cardStruk = New Guna.UI2.WinForms.Guna2Panel()
            Me.txtStruk = New System.Windows.Forms.TextBox()
            Me.pnlQrBar = New System.Windows.Forms.Panel()
            Me.lblQrHint = New System.Windows.Forms.Label()
            Me.picQr = New System.Windows.Forms.PictureBox()
            Me.pnlTop.SuspendLayout()
            Me.pnlFoot.SuspendLayout()
            Me.pnlBody.SuspendLayout()
            Me.cardStruk.SuspendLayout()
            Me.pnlQrBar.SuspendLayout()
            CType(Me.picQr, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlTop.Controls.Add(Me.lblStatusArahan)
            Me.pnlTop.Controls.Add(Me.lblAntrian)
            Me.pnlTop.Controls.Add(Me.lblCap)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.BorderRadius = 0
            Me.pnlTop.Size = New System.Drawing.Size(560, 132)
            Me.pnlTop.TabIndex = 0
            '
            'lblCap
            '
            Me.lblCap.BackColor = System.Drawing.Color.Transparent
            Me.lblCap.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblCap.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblCap.Location = New System.Drawing.Point(20, 12)
            Me.lblCap.Name = "lblCap"
            Me.lblCap.Size = New System.Drawing.Size(520, 22)
            Me.lblCap.TabIndex = 0
            Me.lblCap.Text = "NOMOR ANTRIAN ANDA"
            Me.lblCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblAntrian
            '
            Me.lblAntrian.BackColor = System.Drawing.Color.Transparent
            Me.lblAntrian.Font = New System.Drawing.Font("Georgia", 32.0!, System.Drawing.FontStyle.Bold)
            Me.lblAntrian.ForeColor = System.Drawing.Color.White
            Me.lblAntrian.Location = New System.Drawing.Point(20, 34)
            Me.lblAntrian.Name = "lblAntrian"
            Me.lblAntrian.Size = New System.Drawing.Size(520, 56)
            Me.lblAntrian.TabIndex = 1
            Me.lblAntrian.Text = "001"
            Me.lblAntrian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblStatusArahan
            '
            Me.lblStatusArahan.BackColor = System.Drawing.Color.Transparent
            Me.lblStatusArahan.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblStatusArahan.ForeColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.lblStatusArahan.Location = New System.Drawing.Point(20, 92)
            Me.lblStatusArahan.Name = "lblStatusArahan"
            Me.lblStatusArahan.Size = New System.Drawing.Size(520, 26)
            Me.lblStatusArahan.TabIndex = 2
            Me.lblStatusArahan.Text = "Pesanan sedang disiapkan dapur."
            Me.lblStatusArahan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pnlFoot
            '
            Me.pnlFoot.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlFoot.Controls.Add(Me.btnSelesai)
            Me.pnlFoot.Controls.Add(Me.btnCetak)
            Me.pnlFoot.Controls.Add(Me.btnSimpan)
            Me.pnlFoot.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlFoot.Location = New System.Drawing.Point(0, 684)
            Me.pnlFoot.Name = "pnlFoot"
            Me.pnlFoot.Padding = New System.Windows.Forms.Padding(24, 10, 24, 16)
            Me.pnlFoot.Size = New System.Drawing.Size(560, 76)
            Me.pnlFoot.TabIndex = 1
            '
            'btnSimpan
            '
            Me.btnSimpan.BackColor = System.Drawing.Color.Transparent
            Me.btnSimpan.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnSimpan.BorderRadius = 12
            Me.btnSimpan.BorderThickness = 1
            Me.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSimpan.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSimpan.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnSimpan.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnSimpan.Location = New System.Drawing.Point(24, 10)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.Size = New System.Drawing.Size(154, 48)
            Me.btnSimpan.TabIndex = 0
            Me.btnSimpan.Text = "Simpan .txt"
            Me.btnSimpan.UseTransparentBackground = True
            '
            'btnCetak
            '
            Me.btnCetak.BackColor = System.Drawing.Color.Transparent
            Me.btnCetak.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnCetak.BorderRadius = 12
            Me.btnCetak.BorderThickness = 1
            Me.btnCetak.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCetak.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnCetak.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnCetak.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnCetak.ImageOffset = New System.Drawing.Point(-4, 0)
            Me.btnCetak.Location = New System.Drawing.Point(188, 10)
            Me.btnCetak.Name = "btnCetak"
            Me.btnCetak.Size = New System.Drawing.Size(154, 48)
            Me.btnCetak.TabIndex = 1
            Me.btnCetak.Text = "Cetak / Preview"
            Me.btnCetak.UseTransparentBackground = True
            '
            'btnSelesai
            '
            Me.btnSelesai.BackColor = System.Drawing.Color.Transparent
            Me.btnSelesai.BorderRadius = 12
            Me.btnSelesai.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSelesai.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnSelesai.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSelesai.ForeColor = System.Drawing.Color.White
            Me.btnSelesai.ImageOffset = New System.Drawing.Point(-6, 0)
            Me.btnSelesai.Location = New System.Drawing.Point(352, 10)
            Me.btnSelesai.Name = "btnSelesai"
            Me.btnSelesai.BorderThickness = 0
            Me.btnSelesai.Size = New System.Drawing.Size(184, 48)
            Me.btnSelesai.TabIndex = 2
            Me.btnSelesai.Text = "Selesai"
            Me.btnSelesai.UseTransparentBackground = True
            '
            'pnlBody
            '
            Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlBody.Controls.Add(Me.cardStruk)
            Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlBody.Location = New System.Drawing.Point(0, 132)
            Me.pnlBody.Name = "pnlBody"
            Me.pnlBody.Padding = New System.Windows.Forms.Padding(24, 14, 24, 14)
            Me.pnlBody.Size = New System.Drawing.Size(560, 552)
            Me.pnlBody.TabIndex = 2
            '
            'cardStruk
            '
            Me.cardStruk.BackColor = System.Drawing.Color.Transparent
            Me.cardStruk.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardStruk.BorderRadius = 16
            Me.cardStruk.BorderThickness = 1
            Me.cardStruk.Controls.Add(Me.txtStruk)
            Me.cardStruk.Controls.Add(Me.pnlQrBar)
            Me.cardStruk.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardStruk.FillColor = System.Drawing.Color.White
            Me.cardStruk.Location = New System.Drawing.Point(24, 14)
            Me.cardStruk.Name = "cardStruk"
            Me.cardStruk.Padding = New System.Windows.Forms.Padding(16)
            Me.cardStruk.Size = New System.Drawing.Size(512, 524)
            Me.cardStruk.TabIndex = 0
            Me.cardStruk.UseTransparentBackground = True
            '
            'txtStruk
            '
            Me.txtStruk.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.txtStruk.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtStruk.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtStruk.Font = New System.Drawing.Font("Consolas", 9.5!)
            Me.txtStruk.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtStruk.Location = New System.Drawing.Point(16, 16)
            Me.txtStruk.Multiline = True
            Me.txtStruk.Name = "txtStruk"
            Me.txtStruk.ReadOnly = True
            Me.txtStruk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtStruk.Size = New System.Drawing.Size(480, 376)
            Me.txtStruk.TabIndex = 0
            Me.txtStruk.TabStop = False
            '
            'pnlQrBar
            '
            Me.pnlQrBar.BackColor = System.Drawing.Color.White
            Me.pnlQrBar.Controls.Add(Me.lblQrHint)
            Me.pnlQrBar.Controls.Add(Me.picQr)
            Me.pnlQrBar.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlQrBar.Location = New System.Drawing.Point(16, 392)
            Me.pnlQrBar.Name = "pnlQrBar"
            Me.pnlQrBar.Size = New System.Drawing.Size(480, 116)
            Me.pnlQrBar.TabIndex = 1
            '
            'picQr
            '
            Me.picQr.BackColor = System.Drawing.Color.White
            Me.picQr.Location = New System.Drawing.Point(10, 8)
            Me.picQr.Name = "picQr"
            Me.picQr.Size = New System.Drawing.Size(100, 100)
            Me.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picQr.TabIndex = 0
            Me.picQr.TabStop = False
            '
            'lblQrHint
            '
            Me.lblQrHint.BackColor = System.Drawing.Color.Transparent
            Me.lblQrHint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblQrHint.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblQrHint.Location = New System.Drawing.Point(122, 22)
            Me.lblQrHint.Name = "lblQrHint"
            Me.lblQrHint.Size = New System.Drawing.Size(344, 68)
            Me.lblQrHint.TabIndex = 1
            Me.lblQrHint.Text = "Tunjukkan kode QR struk ini saat pengambilan pesanan di konter atau untuk konfirmasi pembayaran tunai."
            '
            'FrmStruk
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(560, 760)
            Me.Controls.Add(Me.pnlBody)
            Me.Controls.Add(Me.pnlFoot)
            Me.Controls.Add(Me.pnlTop)
            Me.Name = "FrmStruk"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Bistro Kiosk — Struk Pesanan"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlFoot.ResumeLayout(False)
            Me.pnlBody.ResumeLayout(False)
            Me.cardStruk.ResumeLayout(False)
            Me.cardStruk.PerformLayout()
            Me.pnlQrBar.ResumeLayout(False)
            CType(Me.picQr, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlTop As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCap As System.Windows.Forms.Label
        Friend WithEvents lblAntrian As System.Windows.Forms.Label
        Friend WithEvents lblStatusArahan As System.Windows.Forms.Label
        Friend WithEvents pnlFoot As System.Windows.Forms.Panel
        Friend WithEvents btnSimpan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnCetak As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSelesai As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlBody As System.Windows.Forms.Panel
        Friend WithEvents cardStruk As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents txtStruk As System.Windows.Forms.TextBox
        Friend WithEvents pnlQrBar As System.Windows.Forms.Panel
        Friend WithEvents picQr As System.Windows.Forms.PictureBox
        Friend WithEvents lblQrHint As System.Windows.Forms.Label
    End Class
End Namespace
