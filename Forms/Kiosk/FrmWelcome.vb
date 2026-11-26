Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Forms.Umum
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    Public Class FrmWelcome
        Private Const HOTKEY_ID As Integer = 101

        Private ReadOnly _tmrBanner As New Timer()
        Private ReadOnly _bannerDots As New List(Of Guna2Panel)()
        Private Shared ReadOnly _fntBannerPill As New Font("Segoe UI", 8.5F, FontStyle.Bold)
        Private Shared ReadOnly _fntBannerTitle As New Font(ModTema.FontJudulBesar.FontFamily, 23.0F, FontStyle.Bold)
        Private Shared ReadOnly _fntBannerSub As New Font(ModTema.FontBiasa.FontFamily, 11.5F, FontStyle.Regular)

        Private _banners As List(Of BannerPromo)
        Private _bannerIdx As Integer = 0
        Private _prevBannerImg As Image = Nothing
        Private _bannerTransProgress As Single = 1.0F

        Private _frmMenu As FrmMenu
        Private _logoClickCount As Integer = 0
        Private _lastLogoClickTick As ULong = 0UL
        Private _firstShown As Boolean = True

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
            ModBahasa.Bahasa = ModPengaturan.Ambil("bahasa_default", "ID")
            ModAnimasi.SiapkanTransisiMasuk(Me, 0)
            ModNavigasi.DaftarkanHalamanPenuh(Me)
            ApplyRuntimePolish()
            AddHandler ModBahasa.BahasaBerubah, AddressOf TerapkanBahasa
            AddHandler ModIdle.Habis, AddressOf OnIdleHabis
            AddHandler ModNavigasi.ModeFullscreenBerubah, AddressOf OnModeFullscreenBerubah
            PerbaruiTampilanFullscreen()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar
            ModTema.AktifkanDoubleBuffer(pnlBannerCard)
            ModTema.AktifkanDoubleBuffer(picBanner)
            ModTema.AktifkanDoubleBuffer(pnlDots)

            pnlTop.FillColor = ModTema.WarnaCharcoal
            picLogo.Image = ModProduk.AmbilLogoBistro()
            AddHandler picLogo.Click, AddressOf OnLogoClick

            lblBrand.Font = New Font(ModTema.FontJudul.FontFamily, 15.5F, FontStyle.Bold)
            lblBrand.Text = ModPengaturan.Ambil("nama_toko", "Bistro Kiosk Nusantara")
            lblSubBrand.Font = ModTema.FontKecil
            lblSubBrand.ForeColor = ModTema.WarnaAksen

            ModTema.GayaGunaButtonDark(btnBahasa, 10)
            btnBahasa.FillColor = ModTema.WarnaCharcoalLembut
            btnBahasa.BorderColor = Color.FromArgb(88, 60, 46)
            btnBahasa.BorderThickness = 1
            btnBahasa.Text = ModBahasa.Bahasa
            btnBahasa.Image = BistroIcons.GetIcon(IconChar.Globe, ModTema.WarnaLatar, 15)
            btnBahasa.ImageOffset = New Point(-4, 0)
            AddHandler btnBahasa.Click, Sub() ModBahasa.Bahasa = If(ModBahasa.Bahasa = "ID", "EN", "ID")

            ModTema.GayaGunaButtonDark(btnFullscreen, 10)
            btnFullscreen.FillColor = ModTema.WarnaCharcoalLembut
            btnFullscreen.BorderColor = Color.FromArgb(88, 60, 46)
            btnFullscreen.BorderThickness = 1
            btnFullscreen.Image = BistroIcons.GetIcon(IconChar.Desktop, ModTema.WarnaLatar, 14)
            btnFullscreen.ImageOffset = New Point(-4, 0)
            AddHandler btnFullscreen.Click, AddressOf ToggleFullscreen

            ModTema.GayaGunaButtonDark(btnStaff, 10)
            btnStaff.FillColor = ModTema.WarnaCharcoalLembut
            btnStaff.BorderColor = Color.FromArgb(88, 60, 46)
            btnStaff.BorderThickness = 1
            btnStaff.Image = BistroIcons.GetIcon(IconChar.Lock, ModTema.WarnaLatar, 14)
            btnStaff.ImageOffset = New Point(-4, 0)
            AddHandler btnStaff.Click, Sub() BukaLoginStaff()

            btnDemo.BackColor = Color.Transparent
            btnDemo.UseTransparentBackground = True
            btnDemo.FillColor = ModTema.WarnaUtama
            btnDemo.ForeColor = Color.White
            btnDemo.Font = ModTema.FontTebal
            btnDemo.BorderRadius = 12
            btnDemo.BorderThickness = 0
            btnDemo.HoverState.FillColor = ModTema.WarnaUtamaHover
            btnDemo.Image = BistroIcons.GetIcon(IconChar.SlidersH, Color.White, 14)
            btnDemo.ImageOffset = New Point(-4, 0)
            AddHandler btnDemo.Click, Sub() FrmDemoHub.ShowHub(Me, Me)

            ModTema.GayaGunaCard(pnlBannerCard, 18)
            pnlBannerCard.FillColor = ModTema.WarnaCharcoal
            pnlBannerCard.BorderThickness = 0
            picBanner.BorderRadius = 18
            AddHandler picBanner.Paint, AddressOf OnBannerOverlayPaint
            pnlDots.BringToFront()

            lblTagline.Font = ModTema.FontJudulBesar
            lblTagline.ForeColor = ModTema.WarnaTeks
            lblTagline.Text = ModBahasa.T("welcome_tagline")

            lblPilih.Font = ModTema.FontSubJudul
            lblPilih.ForeColor = ModTema.WarnaTeksRedup
            lblPilih.Text = ModBahasa.T("welcome_sub")

            ModTema.GayaGunaButtonUtama(btnDineIn, 16)
            ModTema.PasangSoftShadow(btnDineIn, 0, 4, Color.FromArgb(46, 255, 107, 53))
            btnDineIn.Font = New Font(ModTema.FontJudul.FontFamily, 13.0F, FontStyle.Bold)
            btnDineIn.Text = ModBahasa.T("dine_in") & Environment.NewLine & ModBahasa.T("dine_in_sub")
            btnDineIn.Image = BistroIcons.GetIcon(IconChar.Utensils, Color.White, 38)
            AddHandler btnDineIn.Click, Sub() MulaiPesanan(TipeMakan.DineIn)

            ModTema.GayaGunaButtonSekunder(btnTakeAway, 16)
            ModTema.PasangSoftShadow(btnTakeAway, 0, 4)
            btnTakeAway.FillColor = ModTema.WarnaPermukaan
            btnTakeAway.BorderThickness = 1
            btnTakeAway.BorderColor = ModTema.WarnaGarisTegas
            btnTakeAway.HoverState.FillColor = ModTema.WarnaSekunderLatar
            btnTakeAway.HoverState.ForeColor = ModTema.WarnaTeks
            btnTakeAway.HoverState.BorderColor = ModTema.WarnaUtama
            btnTakeAway.Font = New Font(ModTema.FontJudul.FontFamily, 13.0F, FontStyle.Bold)
            btnTakeAway.Text = ModBahasa.T("take_away") & Environment.NewLine & ModBahasa.T("take_away_sub")
            btnTakeAway.Image = BistroIcons.GetIcon(IconChar.ShoppingBag, ModTema.WarnaUtama, 38)
            AddHandler btnTakeAway.Click, Sub() MulaiPesanan(TipeMakan.TakeAway)

            lblFooterHint.Font = ModTema.FontKecil
            lblFooterHint.ForeColor = ModTema.WarnaTeksRedup
            lblFooterHint.Text = "Akses Staff: tekan Ctrl+Alt+F12 atau klik logo 5x  |  Layar Penuh: F11  |  Demo Hub: F9"

            _tmrBanner.Interval = 4000
            AddHandler _tmrBanner.Tick, Sub()
                                            If _banners IsNot Nothing AndAlso _banners.Count > 1 Then
                                                _bannerIdx = (_bannerIdx + 1) Mod _banners.Count
                                                TampilkanBanner(True)
                                            End If
                                        End Sub

            AddHandler Resize, AddressOf OnFormResize
            AddHandler Load, AddressOf OnFormLoad
            AddHandler Shown, AddressOf OnFormShown
            AddHandler FormClosing, AddressOf FrmWelcome_FormClosing
            OnFormResize(Me, EventArgs.Empty)
        End Sub

        Private Sub OnFormResize(sender As Object, e As EventArgs)
            ModAnimasi.StopActive(btnDineIn)
            ModAnimasi.StopActive(btnTakeAway)

            Dim contentW As Integer = Math.Max(680, Math.Min(ClientSize.Width - 72, 1520))
            Dim leftX As Integer = (ClientSize.Width - contentW) \ 2
            Dim availH As Integer = Math.Max(480, ClientSize.Height - pnlTop.Height - 40)
            Dim compact As Boolean = (ClientSize.Height < 690)
            Dim topGap As Integer = If(compact, 12, 20)
            Dim bannerH As Integer = Math.Max(200, Math.Min(480, CInt(availH * 0.47)))

            pnlBannerCard.Location = New Point(leftX, pnlTop.Height + topGap)
            pnlBannerCard.Size = New Size(contentW, bannerH)
            pnlDots.Location = New Point(34, Math.Max(12, bannerH - 38))

            lblTagline.Location = New Point(leftX, pnlBannerCard.Bottom + If(compact, 10, 18))
            lblTagline.Size = New Size(contentW, If(compact, 36, 42))

            lblPilih.Location = New Point(leftX, lblTagline.Bottom + 2)
            lblPilih.Size = New Size(contentW, 24)

            Dim gap As Integer = 28
            Dim cardW As Integer = (contentW - gap) \ 2
            Dim cardH As Integer = Math.Max(104, Math.Min(178, CInt(availH * 0.22)))
            Dim cardsY As Integer = lblPilih.Bottom + If(compact, 10, 16)
            btnDineIn.Location = New Point(leftX, cardsY)
            btnDineIn.Size = New Size(cardW, cardH)
            btnTakeAway.Location = New Point(leftX + cardW + gap, cardsY)
            btnTakeAway.Size = New Size(contentW - cardW - gap, cardH)

            lblFooterHint.Location = New Point(leftX, Math.Max(btnDineIn.Bottom + 8, ClientSize.Height - 32))
            lblFooterHint.Size = New Size(contentW, 24)
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            MuatBanner()
            ModWindowsApi.DaftarHotkey(Handle, HOTKEY_ID, ModWindowsApi.MOD_CONTROL Or ModWindowsApi.MOD_ALT Or ModWindowsApi.MOD_NOREPEAT, Keys.F12)
            Dim batasIdle As Integer = ModPengaturan.AmbilInt("idle_detik", 60)
            ModIdle.Mulai(batasIdle)
        End Sub

        Private Sub OnFormShown(sender As Object, e As EventArgs)
            ModAnimasi.FadeInForm(Me, 220UL)
            If _firstShown Then
                _firstShown = False
                ModAnimasi.AnimateEntranceSlide(btnDineIn, 0, 14, 260UL, 40UL)
                ModAnimasi.AnimateEntranceSlide(btnTakeAway, 0, 14, 260UL, 100UL)
            End If
        End Sub

        Private Sub FrmWelcome_FormClosing(sender As Object, e As FormClosingEventArgs)
            _tmrBanner.Stop()
            ModIdle.Berhenti()
            ModWindowsApi.BatalHotkey(Handle, HOTKEY_ID)
            RemoveHandler ModBahasa.BahasaBerubah, AddressOf TerapkanBahasa
            RemoveHandler ModIdle.Habis, AddressOf OnIdleHabis
            RemoveHandler ModNavigasi.ModeFullscreenBerubah, AddressOf OnModeFullscreenBerubah
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            If m.Msg = ModWindowsApi.WM_HOTKEY AndAlso m.WParam.ToInt32() = HOTKEY_ID Then
                BukaLoginStaff()
                Return
            End If
            MyBase.WndProc(m)
        End Sub

        Private Sub OnLogoClick(sender As Object, e As EventArgs)
            Dim nowTick As ULong = ModWindowsApi.WaktuAktif()
            If nowTick - _lastLogoClickTick > 2500UL Then
                _logoClickCount = 0
            End If
            _lastLogoClickTick = nowTick
            _logoClickCount += 1
            If _logoClickCount >= 5 Then
                _logoClickCount = 0
                BukaLoginStaff()
            End If
        End Sub

        Private Sub ToggleFullscreen(sender As Object, e As EventArgs)
            ModNavigasi.ToggleFullscreen(Me)
        End Sub

        Private Sub OnModeFullscreenBerubah(aktif As Boolean)
            If IsDisposed Then Return
            If InvokeRequired Then
                BeginInvoke(New Action(Of Boolean)(AddressOf OnModeFullscreenBerubah), aktif)
                Return
            End If
            PerbaruiTampilanFullscreen()
        End Sub

        Private Sub PerbaruiTampilanFullscreen()
            Dim fs As Boolean = ModNavigasi.ModeFullscreen
            btnFullscreen.Text = If(fs, "Mode Jendela", "Layar Penuh")
            btnFullscreen.Image = BistroIcons.GetIcon(If(fs, IconChar.Compress, IconChar.Expand), ModTema.WarnaLatar, 14)
        End Sub

        Private Sub MuatBanner()
            _banners = ModProduk.AmbilBannerAktif()
            If _banners Is Nothing OrElse _banners.Count = 0 Then
                pnlBannerCard.Visible = False
                Return
            End If
            pnlBannerCard.Visible = True
            _bannerIdx = 0

            ' Bangun indikator dot sekali saja agar pergantian banner 60 FPS tanpa recreate handle
            pnlDots.Controls.Clear()
            _bannerDots.Clear()
            For i As Integer = 0 To _banners.Count - 1
                Dim idx As Integer = i
                Dim dot As New Guna2Panel() With {
                    .Size = New Size(If(i = 0, 32, 10), 10),
                    .Margin = New Padding(0, 4, 8, 4),
                    .BorderRadius = 5,
                    .BackColor = Color.Transparent,
                    .UseTransparentBackground = True,
                    .FillColor = If(i = 0, ModTema.WarnaUtama, Color.FromArgb(145, 255, 250, 240)),
                    .Cursor = Cursors.Hand
                }
                AddHandler dot.Click, Sub()
                                          If _bannerIdx = idx Then Return
                                          _bannerIdx = idx
                                          TampilkanBanner(True)
                                      End Sub
                pnlDots.Controls.Add(dot)
                _bannerDots.Add(dot)
            Next

            TampilkanBanner(False)
            _tmrBanner.Start()
        End Sub

        Private Sub TampilkanBanner(Optional animateTransition As Boolean = False)
            If _banners Is Nothing OrElse _banners.Count = 0 Then Return
            Dim b = _banners(_bannerIdx)
            Dim nextImg As Image = ModProduk.AmbilGambarBanner(b.Gambar)

            If animateTransition AndAlso picBanner.Image IsNot Nothing AndAlso Not ModAnimasi.NonaktifkanAnimasi AndAlso IsHandleCreated Then
                _prevBannerImg = picBanner.Image
                picBanner.Image = nextImg
                _bannerTransProgress = 0.0F
                ModAnimasi.AnimateFloat(picBanner, picBanner, 0.0F, 1.0F, 420UL,
                    Sub(v)
                        _bannerTransProgress = v
                        picBanner.Invalidate()
                    End Sub,
                    Sub()
                        _prevBannerImg = Nothing
                        _bannerTransProgress = 1.0F
                        picBanner.Invalidate()
                    End Sub,
                    easing:=AddressOf WinFormAnimation.AnimationFunctions.CubicEaseOut)
            Else
                _prevBannerImg = Nothing
                _bannerTransProgress = 1.0F
                picBanner.Image = nextImg
                picBanner.Invalidate()
            End If

            ' Perbarui lebar & warna dot secara halus tanpa Controls.Clear()
            For i As Integer = 0 To _bannerDots.Count - 1
                Dim dot = _bannerDots(i)
                Dim isActive As Boolean = (i = _bannerIdx)
                Dim targetW As Integer = If(isActive, 32, 10)
                Dim targetCol As Color = If(isActive, ModTema.WarnaUtama, Color.FromArgb(145, 255, 250, 240))
                If animateTransition AndAlso IsHandleCreated AndAlso Not ModAnimasi.NonaktifkanAnimasi Then
                    ModAnimasi.AnimateWidth(dot, targetW, 240UL)
                    ModAnimasi.AnimateColor(dot, New Tuple(Of String, Object)("dotCol", dot), dot.FillColor, targetCol,
                        Sub(c) dot.FillColor = c, 240UL)
                Else
                    ModAnimasi.StopActive(dot)
                    dot.Width = targetW
                    dot.FillColor = targetCol
                End If
            Next
        End Sub

        Private Sub OnBannerOverlayPaint(sender As Object, e As PaintEventArgs)
            If _banners Is Nothing OrElse _banners.Count = 0 Then Return
            Dim b = _banners(_bannerIdx)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            ' Crossfade gambar sebelumnya selama transisi
            If _bannerTransProgress < 1.0F AndAlso _prevBannerImg IsNot Nothing Then
                Dim fadeOutAlpha As Single = Math.Max(0.0F, 1.0F - _bannerTransProgress)
                Dim cm As New ColorMatrix() With {.Matrix33 = fadeOutAlpha}
                Using ia As New ImageAttributes()
                    ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)
                    g.DrawImage(_prevBannerImg, New Rectangle(0, 0, picBanner.Width, picBanner.Height), 0, 0, _prevBannerImg.Width, _prevBannerImg.Height, GraphicsUnit.Pixel, ia)
                End Using
            End If

            Dim ovRect As New Rectangle(0, 0, CInt(picBanner.Width * 0.62), picBanner.Height)
            Using lg As New LinearGradientBrush(ovRect, Color.FromArgb(232, 44, 24, 16), Color.FromArgb(0, 44, 24, 16), LinearGradientMode.Horizontal)
                g.FillRectangle(lg, ovRect)
            End Using

            Dim slideY As Integer = CInt(Math.Round((1.0F - _bannerTransProgress) * 10.0F))
            Dim pillRect As New Rectangle(34, 42 + slideY, 164, 30)
            Using pillPath = ModTema.BuatRoundedPath(pillRect, 12)
                Using brPill As New SolidBrush(ModTema.WarnaUtama)
                    g.FillPath(brPill, pillPath)
                End Using
            End Using
            Using sfC As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                Using brWhiteText As New SolidBrush(Color.White)
                    g.DrawString(ModBahasa.T("promo_badge"), _fntBannerPill, brWhiteText, pillRect, sfC)
                End Using
            End Using

            Using brWhite As New SolidBrush(ModTema.WarnaLatar)
                g.DrawString(b.Judul, _fntBannerTitle, brWhite, New RectangleF(34, 86 + slideY, 640, 108))
            End Using
            Using brSub As New SolidBrush(ModTema.WarnaSekunderLatar)
                g.DrawString(b.Subjudul, _fntBannerSub, brSub, New RectangleF(34, 198 + slideY, 560, 66))
            End Using
        End Sub

        Private Sub TerapkanBahasa()
            If InvokeRequired Then
                BeginInvoke(New Action(AddressOf TerapkanBahasa))
                Return
            End If
            btnBahasa.Text = ModBahasa.Bahasa
            lblTagline.Text = ModBahasa.T("welcome_tagline")
            lblPilih.Text = ModBahasa.T("welcome_sub")
            btnDineIn.Text = ModBahasa.T("dine_in") & Environment.NewLine & ModBahasa.T("dine_in_sub")
            btnTakeAway.Text = ModBahasa.T("take_away") & Environment.NewLine & ModBahasa.T("take_away_sub")
            picBanner.Invalidate()
        End Sub

        Public Sub MulaiPesanan(tipeMakan As String)
            ModKeranjang.Kosongkan()
            ModKeranjang.TipeMakan = tipeMakan
            If _frmMenu Is Nothing OrElse _frmMenu.IsDisposed Then
                _frmMenu = New FrmMenu()
                AddHandler _frmMenu.KembaliKeWelcome, Sub()
                                                          ModNavigasi.PindahHalaman(_frmMenu, Me)
                                                      End Sub
                AddHandler _frmMenu.FormClosed, Sub()
                                                    If Not IsDisposed Then
                                                        ModNavigasi.TerapkanModeJendela(Me)
                                                        Show()
                                                        Activate()
                                                    End If
                                                End Sub
            End If
            _frmMenu.ResetUntukPelangganBaru()
            ModNavigasi.PindahHalaman(Me, _frmMenu)
        End Sub

        Public Sub BukaLoginStaff()
            ModIdle.Berhenti()
            Using frm As New FrmLogin()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    BukaModeStaffSetelahLogin()
                Else
                    ModIdle.Mulai(ModPengaturan.AmbilInt("idle_detik", 60))
                End If
            End Using
        End Sub

        Public Sub BukaModeStaffSetelahLogin()
            BukaModeStaffDenganForm("")
        End Sub

        Public Sub BukaModeStaffDenganForm(Optional namaFormAwal As String = "")
            ModIdle.Berhenti()
            If _frmMenu IsNot Nothing AndAlso Not _frmMenu.IsDisposed AndAlso _frmMenu.Visible Then
                _frmMenu.Hide()
            End If
            Hide()
            Using mdi As New FrmUtama()
                mdi.FormAwal = namaFormAwal
                ModNavigasi.TerapkanModeJendela(mdi)
                mdi.ShowDialog()
            End Using
            If ModSesi.SudahLogin() Then ModSesi.Keluar()
            ModKeranjang.Kosongkan()
            ModNavigasi.TerapkanModeJendela(Me)
            Show()
            Activate()
            ModIdle.Mulai(ModPengaturan.AmbilInt("idle_detik", 60))
        End Sub

        Private Sub OnIdleHabis()
            If InvokeRequired Then
                BeginInvoke(New Action(AddressOf OnIdleHabis))
                Return
            End If
            Dim openCopy = Application.OpenForms.Cast(Of Form)().ToList()
            For Each f In openCopy
                If f IsNot Me AndAlso Not TypeOf f Is FrmUtama AndAlso Not TypeOf f Is Forms.Kasir.FrmAntrian Then
                    Try
                        If f Is _frmMenu Then
                            f.Hide()
                        Else
                            f.Close()
                        End If
                    Catch
                    End Try
                End If
            Next
            ModKeranjang.Kosongkan()
            ModNavigasi.TerapkanModeJendela(Me)
            Show()
            Activate()
        End Sub

    End Class
End Namespace
