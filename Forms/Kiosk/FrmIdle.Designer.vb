Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmIdle
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
            Me.btnLanjut = New Guna.UI2.WinForms.Guna2Button()
            Me.pgbSisa = New Guna.UI2.WinForms.Guna2ProgressBar()
            Me.lblCountdown = New System.Windows.Forms.Label()
            Me.lblDesc = New System.Windows.Forms.Label()
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.picIcon = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.card.SuspendLayout()
            CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'card
            '
            Me.card.BackColor = System.Drawing.Color.Transparent
            Me.card.BorderColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.card.BorderRadius = 16
            Me.card.BorderThickness = 1
            Me.card.Controls.Add(Me.btnLanjut)
            Me.card.Controls.Add(Me.pgbSisa)
            Me.card.Controls.Add(Me.lblCountdown)
            Me.card.Controls.Add(Me.lblDesc)
            Me.card.Controls.Add(Me.lblJudul)
            Me.card.Controls.Add(Me.picIcon)
            Me.card.Dock = System.Windows.Forms.DockStyle.Fill
            Me.card.FillColor = System.Drawing.Color.White
            Me.card.Location = New System.Drawing.Point(0, 0)
            Me.card.Name = "card"
            Me.card.Size = New System.Drawing.Size(460, 320)
            Me.card.TabIndex = 0
            Me.card.UseTransparentBackground = True
            '
            'picIcon
            '
            Me.picIcon.BackColor = System.Drawing.Color.Transparent
            Me.picIcon.FillColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.picIcon.Location = New System.Drawing.Point(198, 24)
            Me.picIcon.Name = "picIcon"
            Me.picIcon.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.picIcon.Size = New System.Drawing.Size(64, 64)
            Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.picIcon.TabIndex = 0
            Me.picIcon.TabStop = False
            Me.picIcon.UseTransparentBackground = True
            '
            'lblJudul
            '
            Me.lblJudul.BackColor = System.Drawing.Color.Transparent
            Me.lblJudul.Font = New System.Drawing.Font("Georgia", 13.5!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblJudul.Location = New System.Drawing.Point(24, 98)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(412, 32)
            Me.lblJudul.TabIndex = 1
            Me.lblJudul.Text = "Apakah Anda masih memesan?"
            Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDesc
            '
            Me.lblDesc.BackColor = System.Drawing.Color.Transparent
            Me.lblDesc.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblDesc.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblDesc.Location = New System.Drawing.Point(30, 132)
            Me.lblDesc.Name = "lblDesc"
            Me.lblDesc.Size = New System.Drawing.Size(400, 40)
            Me.lblDesc.TabIndex = 2
            Me.lblDesc.Text = "Pesanan akan direset otomatis demi kenyamanan pelanggan berikutnya."
            Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCountdown
            '
            Me.lblCountdown.BackColor = System.Drawing.Color.Transparent
            Me.lblCountdown.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblCountdown.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblCountdown.Location = New System.Drawing.Point(24, 174)
            Me.lblCountdown.Name = "lblCountdown"
            Me.lblCountdown.Size = New System.Drawing.Size(412, 28)
            Me.lblCountdown.TabIndex = 3
            Me.lblCountdown.Text = "Reset dalam 10 detik"
            Me.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pgbSisa
            '
            Me.pgbSisa.BackColor = System.Drawing.Color.Transparent
            Me.pgbSisa.BorderRadius = 6
            Me.pgbSisa.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.pgbSisa.Location = New System.Drawing.Point(44, 208)
            Me.pgbSisa.Maximum = 10
            Me.pgbSisa.Name = "pgbSisa"
            Me.pgbSisa.ProgressColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.pgbSisa.ProgressColor2 = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.pgbSisa.Size = New System.Drawing.Size(372, 12)
            Me.pgbSisa.TabIndex = 4
            Me.pgbSisa.Value = 10
            '
            'btnLanjut
            '
            Me.btnLanjut.BackColor = System.Drawing.Color.Transparent
            Me.btnLanjut.BorderRadius = 12
            Me.btnLanjut.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLanjut.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnLanjut.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnLanjut.ForeColor = System.Drawing.Color.White
            Me.btnLanjut.ImageOffset = New System.Drawing.Point(-8, 0)
            Me.btnLanjut.Location = New System.Drawing.Point(44, 238)
            Me.btnLanjut.Name = "btnLanjut"
            Me.btnLanjut.BorderThickness = 0
            Me.btnLanjut.Size = New System.Drawing.Size(372, 52)
            Me.btnLanjut.TabIndex = 5
            Me.btnLanjut.Text = "Lanjutkan Pesanan Saya"
            Me.btnLanjut.UseTransparentBackground = True
            '
            'FrmIdle
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(460, 320)
            Me.Controls.Add(Me.card)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmIdle"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Konfirmasi Sesi Kiosk"
            Me.card.ResumeLayout(False)
            CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents card As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picIcon As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblDesc As System.Windows.Forms.Label
        Friend WithEvents lblCountdown As System.Windows.Forms.Label
        Friend WithEvents pgbSisa As Guna.UI2.WinForms.Guna2ProgressBar
        Friend WithEvents btnLanjut As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
