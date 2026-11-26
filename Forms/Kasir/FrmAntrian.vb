Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kasir

    ''' <summary>
    ''' Layar Antrian Pelanggan Mandiri (2 Kolom: Sedang Disiapkan vs Siap Diambil).
    ''' </summary>
    Public Class FrmAntrian
        Private ReadOnly _tmrRefresh As New Timer()
        Private ReadOnly _tmrPulse As New Timer()

        Private ReadOnly _siapSebelumnya As New HashSet(Of Integer)()
        Private ReadOnly _siapBaruSet As New HashSet(Of Integer)()
        Private _lastDiprosesIds As New List(Of Integer)()
        Private _lastSiapIds As New List(Of Integer)()
        Private _pulseState As Boolean = False

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
            ModAnimasi.SiapkanTransisiMasuk(Me, 0)
            ModNavigasi.DaftarkanHalamanPenuh(Me)
            ApplyRuntimePolish()
            MuatAntrian(True)
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaCharcoal
            ModTema.AktifkanDoubleBuffer(flpDiproses)
            ModTema.AktifkanDoubleBuffer(flpSiap)

            pnlTop.FillColor = ModTema.WarnaCharcoal
            picLogo.Image = ModProduk.AmbilLogoBistro()
            lblJudul.Font = New Font(ModTema.FontJudulBesar.FontFamily, 18.0F, FontStyle.Bold)
            lblSub.Font = ModTema.FontKecil
            lblSub.ForeColor = ModTema.WarnaAksen
            lblSub.Text = ModPengaturan.Ambil("nama_toko", "Bistro Kiosk Nusantara") & "  |  Tekan ESC untuk keluar  |  F11: Layar Penuh"

            lblJam.Font = New Font(ModTema.FontJudulBesar.FontFamily, 18.0F, FontStyle.Bold)
            lblJam.ForeColor = ModTema.WarnaAksen
            lblJam.Text = DateTime.Now.ToString("HH:mm:ss")

            tlp.BackColor = ModTema.WarnaCharcoal
            For Each c In {cardDiproses, cardSiap}
                c.BackColor = Color.Transparent
                c.UseTransparentBackground = True
                c.BorderRadius = 16
                c.ShadowDecoration.Enabled = False
            Next
            For Each h In {hdrDiproses, hdrSiap}
                h.BackColor = Color.Transparent
                h.UseTransparentBackground = True
                h.BorderRadius = 14
                h.CustomizableEdges.BottomLeft = False
                h.CustomizableEdges.BottomRight = False
                h.ShadowDecoration.Enabled = False
            Next
            cardDiproses.FillColor = ModTema.WarnaCharcoalLembut
            cardDiproses.BorderThickness = 1
            cardDiproses.BorderColor = Color.FromArgb(88, 60, 46)
            hdrDiproses.FillColor = ModTema.WarnaUtama
            cardSiap.FillColor = ModTema.WarnaCharcoalLembut
            cardSiap.BorderThickness = 1
            cardSiap.BorderColor = Color.FromArgb(88, 60, 46)
            hdrSiap.FillColor = ModTema.WarnaSukses
            lblHDip.Font = New Font(ModTema.FontJudulBesar.FontFamily, 17.0F, FontStyle.Bold)
            lblHSiap.Font = New Font(ModTema.FontJudulBesar.FontFamily, 17.0F, FontStyle.Bold)

            AddHandler KeyDown, Sub(s, ev)
                                    If ev.KeyCode = Keys.Escape Then Close()
                                End Sub

            _tmrRefresh.Interval = 3000
            AddHandler _tmrRefresh.Tick, Sub() MuatAntrian(False)
            _tmrPulse.Interval = 650
            AddHandler _tmrPulse.Tick, AddressOf OnPulseTick

            AddHandler Shown, Sub()
                                  ModAnimasi.FadeInForm(Me, 200UL)
                                  _tmrRefresh.Start()
                                  _tmrPulse.Start()
                              End Sub
            AddHandler FormClosing, Sub()
                                        _tmrRefresh.Stop()
                                        _tmrPulse.Stop()
                                    End Sub
        End Sub

        Private Sub OnPulseTick(sender As Object, e As EventArgs)
            lblJam.Text = DateTime.Now.ToString("HH:mm:ss")
            _pulseState = Not _pulseState
            For Each c As Control In flpSiap.Controls
                Dim pnl = TryCast(c, Guna2Panel)
                If pnl IsNot Nothing AndAlso _siapBaruSet.Contains(CInt(pnl.Tag)) Then
                    Dim targetCol As Color = If(_pulseState, ModTema.WarnaAksen, ModTema.WarnaSukses)
                    ModAnimasi.AnimateColor(pnl, pnl, pnl.FillColor, targetCol, Sub(col) pnl.FillColor = col, 360UL)
                End If
            Next
        End Sub

        Private Sub MuatAntrian(initial As Boolean)
            Dim dtDip = ModAntrian.AmbilPesanan(StatusPesanan.Diproses)
            Dim dtSiap = ModAntrian.AmbilPesanan(StatusPesanan.Siap)

            Dim dipIds As New List(Of Integer)()
            For Each r As DataRow In dtDip.Rows
                dipIds.Add(CInt(r("no_antrian")))
            Next
            If initial OrElse Not dipIds.SequenceEqual(_lastDiprosesIds) Then
                _lastDiprosesIds = dipIds
                flpDiproses.SuspendLayout()
                flpDiproses.Controls.Clear()
                For Each noAnt In dipIds
                    flpDiproses.Controls.Add(BuatTileAntrian(noAnt, ModTema.WarnaCharcoal, ModTema.WarnaUtama, Color.FromArgb(88, 60, 46)))
                Next
                flpDiproses.ResumeLayout()
            End If

            Dim siapIds As New List(Of Integer)()
            For Each r As DataRow In dtSiap.Rows
                siapIds.Add(CInt(r("no_antrian")))
            Next
            If initial OrElse Not siapIds.SequenceEqual(_lastSiapIds) Then
                _lastSiapIds = siapIds
                Dim siapSaatIni As New HashSet(Of Integer)()
                flpSiap.SuspendLayout()
                flpSiap.Controls.Clear()
                For Each noAnt In siapIds
                    siapSaatIni.Add(noAnt)
                    If Not initial AndAlso Not _siapSebelumnya.Contains(noAnt) Then
                        _siapBaruSet.Add(noAnt)
                    End If
                    flpSiap.Controls.Add(BuatTileAntrian(noAnt, ModTema.WarnaSukses, Color.White, Color.FromArgb(148, 200, 164)))
                Next
                flpSiap.ResumeLayout()

                _siapSebelumnya.Clear()
                For Each n In siapSaatIni
                    _siapSebelumnya.Add(n)
                Next
            End If
        End Sub

        Private Function BuatTileAntrian(noAntrian As Integer, bg As Color, fg As Color, border As Color) As Guna2Panel
            Dim tile As New Guna2Panel() With {
                .Size = New Size(172, 108),
                .Margin = New Padding(10),
                .BackColor = Color.Transparent,
                .UseTransparentBackground = True,
                .FillColor = bg,
                .BorderColor = border,
                .BorderThickness = 1,
                .BorderRadius = 14,
                .Tag = noAntrian
            }
            Dim lbl As New Label() With {
                .Dock = DockStyle.Fill,
                .Font = New Font(ModTema.FontJudulBesar.FontFamily, 30.0F, FontStyle.Bold),
                .ForeColor = fg,
                .BackColor = Color.Transparent,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Text = ModFormat.NoAntrianStr(noAntrian)
            }
            tile.Controls.Add(lbl)
            Return tile
        End Function

    End Class
End Namespace
