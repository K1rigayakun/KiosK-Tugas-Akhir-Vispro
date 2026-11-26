Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    Public Class FrmIdle
        Private ReadOnly _tmrHitung As New Timer()
        Private _sisaDetik As Integer = 10

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not DesignMode Then cp.ExStyle = cp.ExStyle Or &H2000000
                Return cp
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModAnimasi.SiapkanTransisiMasuk(Me, 16)
            ApplyRuntimePolish()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar

            ModTema.GayaGunaCard(card, 16)
            card.BorderColor = ModTema.WarnaUtama
            card.BorderThickness = 1
            card.ShadowDecoration.Enabled = False
            card.UseTransparentBackground = True

            picIcon.FillColor = ModTema.WarnaPeringatanLembut
            picIcon.Image = BistroIcons.GetBadgeIcon(IconChar.Clock, ModTema.WarnaPeringatan, ModTema.WarnaPeringatanLembut, 64, 28)

            lblJudul.Font = ModTema.FontJudul
            lblJudul.Text = ModBahasa.T("idle_judul")
            lblDesc.Font = ModTema.FontBiasa
            lblCountdown.Font = ModTema.FontTebal
            lblCountdown.ForeColor = ModTema.WarnaUtama

            pgbSisa.BorderRadius = 6
            pgbSisa.FillColor = ModTema.WarnaSekunderLatar
            pgbSisa.ProgressColor = ModTema.WarnaUtama
            pgbSisa.ProgressColor2 = ModTema.WarnaAksen

            btnLanjut.Text = ModBahasa.T("idle_lanjut")
            btnLanjut.Image = BistroIcons.GetIcon(IconChar.Check, Color.White, 18)
            btnLanjut.ImageOffset = New Point(-8, 0)
            ModTema.GayaGunaButtonUtama(btnLanjut, 10)
            AddHandler btnLanjut.Click, Sub()
                                            _tmrHitung.Stop()
                                            DialogResult = DialogResult.OK
                                            Close()
                                        End Sub

            _tmrHitung.Interval = 1000
            AddHandler _tmrHitung.Tick, AddressOf OnTick
            AddHandler Shown, Sub()
                                  _tmrHitung.Start()
                                  ModAnimasi.SlideUpFadeInModal(Me, 18, 220UL)
                              End Sub
            AddHandler FormClosing, Sub() _tmrHitung.Stop()
        End Sub

        Private Sub OnTick(sender As Object, e As EventArgs)
            _sisaDetik -= 1
            If _sisaDetik <= 0 Then
                _tmrHitung.Stop()
                DialogResult = DialogResult.Cancel
                Close()
                Return
            End If
            pgbSisa.Value = _sisaDetik
            lblCountdown.Text = $"Reset dalam {_sisaDetik} detik"
        End Sub

    End Class
End Namespace
