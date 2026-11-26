Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Kasir

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmAntrian
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
            Me.lblJam = New System.Windows.Forms.Label()
            Me.lblSub = New System.Windows.Forms.Label()
            Me.lblJudul = New System.Windows.Forms.Label()
            Me.picLogo = New System.Windows.Forms.PictureBox()
            Me.tlp = New System.Windows.Forms.TableLayoutPanel()
            Me.cardSiap = New Guna.UI2.WinForms.Guna2Panel()
            Me.flpSiap = New System.Windows.Forms.FlowLayoutPanel()
            Me.hdrSiap = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblHSiap = New System.Windows.Forms.Label()
            Me.cardDiproses = New Guna.UI2.WinForms.Guna2Panel()
            Me.flpDiproses = New System.Windows.Forms.FlowLayoutPanel()
            Me.hdrDiproses = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblHDip = New System.Windows.Forms.Label()
            Me.pnlTop.SuspendLayout()
            CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tlp.SuspendLayout()
            Me.cardSiap.SuspendLayout()
            Me.hdrSiap.SuspendLayout()
            Me.cardDiproses.SuspendLayout()
            Me.hdrDiproses.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlTop.Controls.Add(Me.lblJam)
            Me.pnlTop.Controls.Add(Me.lblSub)
            Me.pnlTop.Controls.Add(Me.lblJudul)
            Me.pnlTop.Controls.Add(Me.picLogo)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.BorderRadius = 0
            Me.pnlTop.Size = New System.Drawing.Size(1280, 82)
            Me.pnlTop.TabIndex = 0
            '
            'picLogo
            '
            Me.picLogo.BackColor = System.Drawing.Color.Transparent
            Me.picLogo.Location = New System.Drawing.Point(26, 16)
            Me.picLogo.Name = "picLogo"
            Me.picLogo.Size = New System.Drawing.Size(50, 50)
            Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picLogo.TabIndex = 0
            Me.picLogo.TabStop = False
            '
            'lblJudul
            '
            Me.lblJudul.BackColor = System.Drawing.Color.Transparent
            Me.lblJudul.Font = New System.Drawing.Font("Georgia", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblJudul.ForeColor = System.Drawing.Color.White
            Me.lblJudul.Location = New System.Drawing.Point(88, 16)
            Me.lblJudul.Name = "lblJudul"
            Me.lblJudul.Size = New System.Drawing.Size(540, 32)
            Me.lblJudul.TabIndex = 1
            Me.lblJudul.Text = "LAYAR ANTRIAN PESANAN"
            '
            'lblSub
            '
            Me.lblSub.BackColor = System.Drawing.Color.Transparent
            Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblSub.Location = New System.Drawing.Point(88, 48)
            Me.lblSub.Name = "lblSub"
            Me.lblSub.Size = New System.Drawing.Size(540, 20)
            Me.lblSub.TabIndex = 2
            Me.lblSub.Text = "Bistro Kiosk Nusantara  |  Tekan ESC untuk keluar"
            '
            'lblJam
            '
            Me.lblJam.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblJam.BackColor = System.Drawing.Color.Transparent
            Me.lblJam.Font = New System.Drawing.Font("Georgia", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblJam.ForeColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.lblJam.Location = New System.Drawing.Point(1020, 22)
            Me.lblJam.Name = "lblJam"
            Me.lblJam.Size = New System.Drawing.Size(230, 38)
            Me.lblJam.TabIndex = 3
            Me.lblJam.Text = "00:00:00"
            Me.lblJam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tlp
            '
            Me.tlp.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.tlp.ColumnCount = 2
            Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tlp.Controls.Add(Me.cardDiproses, 0, 0)
            Me.tlp.Controls.Add(Me.cardSiap, 1, 0)
            Me.tlp.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tlp.Location = New System.Drawing.Point(0, 82)
            Me.tlp.Name = "tlp"
            Me.tlp.Padding = New System.Windows.Forms.Padding(20, 8, 20, 20)
            Me.tlp.RowCount = 1
            Me.tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.tlp.Size = New System.Drawing.Size(1280, 678)
            Me.tlp.TabIndex = 1
            '
            'cardDiproses
            '
            Me.cardDiproses.BackColor = System.Drawing.Color.Transparent
            Me.cardDiproses.BorderRadius = 16
            Me.cardDiproses.Controls.Add(Me.flpDiproses)
            Me.cardDiproses.Controls.Add(Me.hdrDiproses)
            Me.cardDiproses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardDiproses.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.cardDiproses.Location = New System.Drawing.Point(20, 8)
            Me.cardDiproses.Margin = New System.Windows.Forms.Padding(0, 0, 10, 0)
            Me.cardDiproses.Name = "cardDiproses"
            Me.cardDiproses.BorderColor = System.Drawing.Color.FromArgb(88, 60, 46)
            Me.cardDiproses.BorderThickness = 1
            Me.cardDiproses.Size = New System.Drawing.Size(610, 650)
            Me.cardDiproses.TabIndex = 0
            Me.cardDiproses.UseTransparentBackground = True
            '
            'hdrDiproses
            '
            Me.hdrDiproses.BackColor = System.Drawing.Color.Transparent
            Me.hdrDiproses.BorderRadius = 14
            Me.hdrDiproses.Controls.Add(Me.lblHDip)
            Me.hdrDiproses.Dock = System.Windows.Forms.DockStyle.Top
            Me.hdrDiproses.FillColor = System.Drawing.Color.FromArgb(200, 116, 30)
            Me.hdrDiproses.Location = New System.Drawing.Point(0, 0)
            Me.hdrDiproses.Name = "hdrDiproses"
            Me.hdrDiproses.BorderThickness = 0
            Me.hdrDiproses.CustomizableEdges.BottomRight = False
            Me.hdrDiproses.CustomizableEdges.BottomLeft = False
            Me.hdrDiproses.Size = New System.Drawing.Size(610, 64)
            Me.hdrDiproses.TabIndex = 0
            Me.hdrDiproses.UseTransparentBackground = True
            '
            'lblHDip
            '
            Me.lblHDip.BackColor = System.Drawing.Color.Transparent
            Me.lblHDip.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblHDip.Font = New System.Drawing.Font("Georgia", 17.0!, System.Drawing.FontStyle.Bold)
            Me.lblHDip.ForeColor = System.Drawing.Color.White
            Me.lblHDip.Location = New System.Drawing.Point(0, 0)
            Me.lblHDip.Name = "lblHDip"
            Me.lblHDip.Size = New System.Drawing.Size(610, 64)
            Me.lblHDip.TabIndex = 0
            Me.lblHDip.Text = "SEDANG DISIAPKAN"
            Me.lblHDip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'flpDiproses
            '
            Me.flpDiproses.AutoScroll = True
            Me.flpDiproses.BackColor = System.Drawing.Color.Transparent
            Me.flpDiproses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpDiproses.Location = New System.Drawing.Point(0, 64)
            Me.flpDiproses.Name = "flpDiproses"
            Me.flpDiproses.Padding = New System.Windows.Forms.Padding(22)
            Me.flpDiproses.Size = New System.Drawing.Size(610, 586)
            Me.flpDiproses.TabIndex = 1
            '
            'cardSiap
            '
            Me.cardSiap.BackColor = System.Drawing.Color.Transparent
            Me.cardSiap.BorderRadius = 16
            Me.cardSiap.Controls.Add(Me.flpSiap)
            Me.cardSiap.Controls.Add(Me.hdrSiap)
            Me.cardSiap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardSiap.FillColor = System.Drawing.Color.FromArgb(63, 37, 26)
            Me.cardSiap.Location = New System.Drawing.Point(650, 8)
            Me.cardSiap.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
            Me.cardSiap.Name = "cardSiap"
            Me.cardSiap.BorderColor = System.Drawing.Color.FromArgb(88, 60, 46)
            Me.cardSiap.BorderThickness = 1
            Me.cardSiap.Size = New System.Drawing.Size(610, 650)
            Me.cardSiap.TabIndex = 1
            Me.cardSiap.UseTransparentBackground = True
            '
            'hdrSiap
            '
            Me.hdrSiap.BackColor = System.Drawing.Color.Transparent
            Me.hdrSiap.BorderRadius = 14
            Me.hdrSiap.Controls.Add(Me.lblHSiap)
            Me.hdrSiap.Dock = System.Windows.Forms.DockStyle.Top
            Me.hdrSiap.FillColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.hdrSiap.Location = New System.Drawing.Point(0, 0)
            Me.hdrSiap.Name = "hdrSiap"
            Me.hdrSiap.BorderThickness = 0
            Me.hdrSiap.CustomizableEdges.BottomRight = False
            Me.hdrSiap.CustomizableEdges.BottomLeft = False
            Me.hdrSiap.Size = New System.Drawing.Size(610, 64)
            Me.hdrSiap.TabIndex = 0
            Me.hdrSiap.UseTransparentBackground = True
            '
            'lblHSiap
            '
            Me.lblHSiap.BackColor = System.Drawing.Color.Transparent
            Me.lblHSiap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblHSiap.Font = New System.Drawing.Font("Georgia", 17.0!, System.Drawing.FontStyle.Bold)
            Me.lblHSiap.ForeColor = System.Drawing.Color.White
            Me.lblHSiap.Location = New System.Drawing.Point(0, 0)
            Me.lblHSiap.Name = "lblHSiap"
            Me.lblHSiap.Size = New System.Drawing.Size(610, 64)
            Me.lblHSiap.TabIndex = 0
            Me.lblHSiap.Text = "SIAP DIAMBIL"
            Me.lblHSiap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'flpSiap
            '
            Me.flpSiap.AutoScroll = True
            Me.flpSiap.BackColor = System.Drawing.Color.Transparent
            Me.flpSiap.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpSiap.Location = New System.Drawing.Point(0, 64)
            Me.flpSiap.Name = "flpSiap"
            Me.flpSiap.Padding = New System.Windows.Forms.Padding(22)
            Me.flpSiap.Size = New System.Drawing.Size(610, 586)
            Me.flpSiap.TabIndex = 1
            '
            'FrmAntrian
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.ClientSize = New System.Drawing.Size(1280, 760)
            Me.Controls.Add(Me.tlp)
            Me.Controls.Add(Me.pnlTop)
            Me.KeyPreview = True
            Me.Name = "FrmAntrian"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Layar Antrian Pesanan — Bistro Kiosk"
            Me.pnlTop.ResumeLayout(False)
            CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tlp.ResumeLayout(False)
            Me.cardSiap.ResumeLayout(False)
            Me.hdrSiap.ResumeLayout(False)
            Me.cardDiproses.ResumeLayout(False)
            Me.hdrDiproses.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlTop As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picLogo As System.Windows.Forms.PictureBox
        Friend WithEvents lblJudul As System.Windows.Forms.Label
        Friend WithEvents lblSub As System.Windows.Forms.Label
        Friend WithEvents lblJam As System.Windows.Forms.Label
        Friend WithEvents tlp As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents cardDiproses As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents hdrDiproses As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblHDip As System.Windows.Forms.Label
        Friend WithEvents flpDiproses As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents cardSiap As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents hdrSiap As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblHSiap As System.Windows.Forms.Label
        Friend WithEvents flpSiap As System.Windows.Forms.FlowLayoutPanel
    End Class
End Namespace
