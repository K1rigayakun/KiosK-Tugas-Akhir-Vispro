Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmRating
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
            Me.card = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnKirim = New Guna.UI2.WinForms.Guna2Button()
            Me.btnLewati = New Guna.UI2.WinForms.Guna2Button()
            Me.txtKomentar = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblSkor = New System.Windows.Forms.Label()
            Me.ratingStar = New Guna.UI2.WinForms.Guna2RatingStar()
            Me.lblSub = New System.Windows.Forms.Label()
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.picBadge = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.card.SuspendLayout()
            CType(Me.picBadge, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'card
            '
            Me.card.BackColor = System.Drawing.Color.Transparent
            Me.card.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.card.BorderRadius = 16
            Me.card.BorderThickness = 1
            Me.card.Controls.Add(Me.btnKirim)
            Me.card.Controls.Add(Me.btnLewati)
            Me.card.Controls.Add(Me.txtKomentar)
            Me.card.Controls.Add(Me.lblSkor)
            Me.card.Controls.Add(Me.ratingStar)
            Me.card.Controls.Add(Me.lblSub)
            Me.card.Controls.Add(Me.lblJudul)
            Me.card.Controls.Add(Me.picBadge)
            Me.card.Dock = System.Windows.Forms.DockStyle.Fill
            Me.card.FillColor = System.Drawing.Color.White
            Me.card.Location = New System.Drawing.Point(0, 0)
            Me.card.Name = "card"
            Me.card.Size = New System.Drawing.Size(500, 410)
            Me.card.TabIndex = 0
            Me.card.UseTransparentBackground = True
            '
            'picBadge
            '
            Me.picBadge.BackColor = System.Drawing.Color.Transparent
            Me.picBadge.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.picBadge.Location = New System.Drawing.Point(220, 22)
            Me.picBadge.Name = "picBadge"
            Me.picBadge.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.picBadge.Size = New System.Drawing.Size(60, 60)
            Me.picBadge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.picBadge.TabIndex = 0
            Me.picBadge.TabStop = False
            Me.picBadge.UseTransparentBackground = True
            '
            'lblJudul
            '
            Me.lblJudul.BackColor = System.Drawing.Color.Transparent
            Me.lblJudul.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblJudul.Location = New System.Drawing.Point(24, 90)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(452, 32)
            Me.lblJudul.TabIndex = 1
            Me.lblJudul.Text = "Bagaimana pengalaman memesan Anda?"
            Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblSub
            '
            Me.lblSub.BackColor = System.Drawing.Color.Transparent
            Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSub.Location = New System.Drawing.Point(24, 122)
            Me.lblSub.Name = "lblSub"
            Me.lblSub.Size = New System.Drawing.Size(452, 22)
            Me.lblSub.TabIndex = 2
            Me.lblSub.Text = "Masukan Anda membantu Bistro menjadi lebih baik."
            Me.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ratingStar
            '
            Me.ratingStar.BackColor = System.Drawing.Color.Transparent
            Me.ratingStar.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.ratingStar.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.ratingStar.Location = New System.Drawing.Point(120, 152)
            Me.ratingStar.Name = "ratingStar"
            Me.ratingStar.RatingColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.ratingStar.Size = New System.Drawing.Size(260, 46)
            Me.ratingStar.TabIndex = 3
            Me.ratingStar.Value = 5.0!
            '
            'lblSkor
            '
            Me.lblSkor.BackColor = System.Drawing.Color.Transparent
            Me.lblSkor.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblSkor.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblSkor.Location = New System.Drawing.Point(24, 202)
            Me.lblSkor.Name = "lblSkor"
            Me.lblSkor.Size = New System.Drawing.Size(452, 24)
            Me.lblSkor.TabIndex = 4
            Me.lblSkor.Text = "5 / 5 - Luar Biasa!"
            Me.lblSkor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtKomentar
            '
            Me.txtKomentar.BackColor = System.Drawing.Color.Transparent
            Me.txtKomentar.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtKomentar.BorderRadius = 12
            Me.txtKomentar.FillColor = System.Drawing.Color.White
            Me.txtKomentar.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtKomentar.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtKomentar.Location = New System.Drawing.Point(34, 236)
            Me.txtKomentar.MaxLength = 300
            Me.txtKomentar.Multiline = True
            Me.txtKomentar.Name = "txtKomentar"
            Me.txtKomentar.PlaceholderText = "Tulis komentar opsional (maks. 300 karakter)..."
            Me.txtKomentar.Size = New System.Drawing.Size(432, 78)
            Me.txtKomentar.TabIndex = 5
            Me.txtKomentar.BorderThickness = 1
            '
            'btnLewati
            '
            Me.btnLewati.BackColor = System.Drawing.Color.Transparent
            Me.btnLewati.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnLewati.BorderRadius = 12
            Me.btnLewati.BorderThickness = 1
            Me.btnLewati.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLewati.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.btnLewati.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnLewati.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnLewati.Location = New System.Drawing.Point(34, 334)
            Me.btnLewati.Name = "btnLewati"
            Me.btnLewati.Size = New System.Drawing.Size(150, 48)
            Me.btnLewati.TabIndex = 6
            Me.btnLewati.Text = "Lewati"
            Me.btnLewati.UseTransparentBackground = True
            '
            'btnKirim
            '
            Me.btnKirim.BackColor = System.Drawing.Color.Transparent
            Me.btnKirim.BorderRadius = 12
            Me.btnKirim.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnKirim.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnKirim.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnKirim.ForeColor = System.Drawing.Color.White
            Me.btnKirim.ImageOffset = New System.Drawing.Point(-8, 0)
            Me.btnKirim.Location = New System.Drawing.Point(196, 334)
            Me.btnKirim.Name = "btnKirim"
            Me.btnKirim.BorderThickness = 0
            Me.btnKirim.Size = New System.Drawing.Size(270, 48)
            Me.btnKirim.TabIndex = 7
            Me.btnKirim.Text = "Kirim Rating"
            Me.btnKirim.UseTransparentBackground = True
            '
            'FrmRating
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(500, 410)
            Me.Controls.Add(Me.card)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmRating"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Penilaian Layanan Bistro"
            Me.card.ResumeLayout(False)
            CType(Me.picBadge, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents card As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picBadge As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSub As System.Windows.Forms.Label
        Friend WithEvents ratingStar As Guna.UI2.WinForms.Guna2RatingStar
        Friend WithEvents lblSkor As System.Windows.Forms.Label
        Friend WithEvents txtKomentar As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnLewati As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnKirim As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
