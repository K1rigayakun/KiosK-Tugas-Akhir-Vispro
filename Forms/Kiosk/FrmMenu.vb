Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Forms.Checkout
Imports VisproPrakProjectAkhir.Forms.Umum
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    Public Class FrmMenu
        Private _sidebarExpanded As Boolean = True
        Private ReadOnly _bsProduk As New BindingSource()
        Private _dtKategori As DataTable
        Private _dtProduk As DataTable
        Private _kategoriTerpilih As Integer = 0
        Private ReadOnly _katButtons As New List(Of Guna2Button)()
        Private _prevCartQty As Integer = -1

        Public Event KembaliKeWelcome()

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
            AddHandler ModKeranjang.KeranjangBerubah, AddressOf RefreshBarKeranjang
            AddHandler ModBahasa.BahasaBerubah, AddressOf TerapkanBahasa
            AddHandler ModNavigasi.ModeFullscreenBerubah, AddressOf OnModeFullscreenBerubah
            AddHandler Shown, Sub() ModAnimasi.FadeInForm(Me, 200UL)
            AddHandler FormClosing, AddressOf FrmMenu_FormClosing
            MuatDataAwal()
            RefreshBarKeranjang()
            PerbaruiTampilanFullscreen()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar
            ModTema.AktifkanDoubleBuffer(pnlSidebar)
            ModTema.AktifkanDoubleBuffer(flpKategori)
            ModTema.AktifkanDoubleBuffer(flpProduk)

            pnlTop.FillColor = ModTema.WarnaCharcoal
            btnToggleSidebar.BackColor = Color.Transparent
            btnToggleSidebar.UseTransparentBackground = True
            btnToggleSidebar.BorderRadius = 10
            btnToggleSidebar.Image = BistroIcons.GetIcon(IconChar.Bars, Color.White, 18)
            btnToggleSidebar.FillColor = ModTema.WarnaCharcoalLembut
            btnToggleSidebar.HoverState.FillColor = ModTema.WarnaUtama
            AddHandler btnToggleSidebar.Click, AddressOf ToggleSidebar

            picLogo.Image = ModProduk.AmbilLogoBistro()
            lblBrand.Font = ModTema.FontJudul
            lblBrand.Text = ModPengaturan.Ambil("nama_toko", "Bistro Kiosk Nusantara")

            lblTipeMakan.BackColor = Color.Transparent
            lblTipeMakan.UseTransparentBackground = True
            lblTipeMakan.BorderRadius = 8
            lblTipeMakan.FillColor = ModTema.WarnaUtama
            lblTipeMakan.DisabledState.FillColor = ModTema.WarnaUtama
            lblTipeMakan.DisabledState.ForeColor = Color.White
            lblTipeMakan.Text = ModKeranjang.TipeMakan.ToUpperInvariant()

            ModTema.GayaGunaTextBox(txtCari, ModBahasa.T("cari_placeholder"), 12)
            txtCari.BackColor = Color.Transparent
            txtCari.IconLeft = BistroIcons.GetIcon(IconChar.MagnifyingGlass, ModTema.WarnaTeksRedup, 16)
            AddHandler txtCari.TextChanged, Sub() TerapkanFilter()

            ModTema.GayaGunaButtonDark(btnFullscreen, 10)
            btnFullscreen.FillColor = ModTema.WarnaCharcoalLembut
            btnFullscreen.BorderColor = Color.FromArgb(88, 60, 46)
            btnFullscreen.BorderThickness = 1
            btnFullscreen.Text = ""
            btnFullscreen.ImageAlign = HorizontalAlignment.Center
            AddHandler btnFullscreen.Click, Sub() ModNavigasi.ToggleFullscreen(Me)

            ModTema.GayaGunaButtonDark(btnBahasa, 10)
            btnBahasa.FillColor = ModTema.WarnaCharcoalLembut
            btnBahasa.BorderColor = Color.FromArgb(88, 60, 46)
            btnBahasa.BorderThickness = 1
            btnBahasa.Text = ModBahasa.Bahasa
            btnBahasa.Image = BistroIcons.GetIcon(IconChar.Globe, ModTema.WarnaLatar, 16)
            btnBahasa.ImageOffset = New Point(-4, 0)
            AddHandler btnBahasa.Click, Sub() ModBahasa.Bahasa = If(ModBahasa.Bahasa = "ID", "EN", "ID")

            btnDemo.BackColor = Color.Transparent
            btnDemo.UseTransparentBackground = True
            btnDemo.Image = BistroIcons.GetIcon(IconChar.SlidersH, Color.White, 15)
            btnDemo.ImageOffset = New Point(-4, 0)
            btnDemo.FillColor = ModTema.WarnaUtama
            btnDemo.ForeColor = Color.White
            btnDemo.BorderRadius = 12
            btnDemo.BorderThickness = 0
            btnDemo.HoverState.FillColor = ModTema.WarnaUtamaHover
            btnDemo.Font = ModTema.FontTebal
            AddHandler btnDemo.Click, Sub() FrmDemoHub.ShowHub(Me)

            pnlBawah.FillColor = ModTema.WarnaCharcoal
            icCart.Image = BistroIcons.GetIcon(IconChar.ShoppingCart, ModTema.WarnaUtama, 26)
            lblRingkasCart.Font = ModTema.FontKecil
            lblRingkasCart.ForeColor = ModTema.WarnaSekunderLatar
            lblTotalCart.Font = New Font(ModTema.FontJudul.FontFamily, 15.0F, FontStyle.Bold)

            btnBatalPesanan.BackColor = Color.Transparent
            btnBatalPesanan.UseTransparentBackground = True
            btnBatalPesanan.Text = ModBahasa.T("batal_pesanan")
            btnBatalPesanan.FillColor = ModTema.WarnaCharcoalLembut
            btnBatalPesanan.ForeColor = ModTema.WarnaLatar
            btnBatalPesanan.BorderRadius = 12
            btnBatalPesanan.BorderThickness = 1
            btnBatalPesanan.BorderColor = Color.FromArgb(88, 60, 46)
            btnBatalPesanan.Font = ModTema.FontTebal
            AddHandler btnBatalPesanan.Click, AddressOf OnBatalPesananClick

            btnKeranjang.Text = ModBahasa.T("lihat_keranjang")
            btnKeranjang.Image = BistroIcons.GetIcon(IconChar.ArrowRight, Color.White, 18)
            ModTema.GayaGunaButtonUtama(btnKeranjang, 12)
            btnKeranjang.BorderThickness = 0
            AddHandler btnKeranjang.Click, AddressOf OnLihatKeranjangClick

            pnlSidebar.FillColor = ModTema.WarnaPermukaan
            pnlSidebar.BorderColor = ModTema.WarnaGaris
            flpProduk.BackColor = ModTema.WarnaLatar
            pnlKosong.Font = ModTema.FontJudul
            pnlKosong.ForeColor = ModTema.WarnaTeksRedup
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
            btnFullscreen.Image = BistroIcons.GetIcon(If(fs, IconChar.Compress, IconChar.Expand), ModTema.WarnaLatar, 15)
            btnFullscreen.FillColor = If(fs, ModTema.WarnaUtama, ModTema.WarnaCharcoalLembut)
        End Sub

        Public Sub ResetUntukPelangganBaru()
            _kategoriTerpilih = 0
            _prevCartQty = 0
            If Not String.IsNullOrEmpty(txtCari.Text) Then txtCari.Text = ""
            If Not _sidebarExpanded Then
                _sidebarExpanded = True
                ModAnimasi.StopActive(pnlSidebar)
                pnlSidebar.Width = 232
            End If
            MuatDataAwal()
            flpProduk.AutoScrollPosition = Point.Empty
            RefreshBarKeranjang()
        End Sub

        Public Sub MuatDataAwal()
            Try
                lblTipeMakan.Text = ModKeranjang.TipeMakan.ToUpperInvariant()
                _dtKategori = ModProduk.AmbilKategori()
                _dtProduk = ModProduk.AmbilProduk(0)
                _bsProduk.DataSource = _dtProduk

                BangunTombolKategori()
                TerapkanFilter()
            Catch ex As Exception
                MessageBox.Show("Gagal memuat katalog menu: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BangunTombolKategori()
            flpKategori.Controls.Clear()
            _katButtons.Clear()

            TambahTombolKategori(0, ModBahasa.T("semua_kategori"))
            If _dtKategori IsNot Nothing Then
                For Each row As DataRow In _dtKategori.Rows
                    TambahTombolKategori(CInt(row("id_kategori")), CStr(row("nama")))
                Next
            End If
            PerbaruiHighlightKategori()
        End Sub

        Private Sub TambahTombolKategori(idKat As Integer, nama As String)
            Dim btn As New Guna2Button() With {
                .Size = New Size(If(_sidebarExpanded, 206, 50), 48),
                .Margin = New Padding(0, 0, 0, 8),
                .Tag = New Tuple(Of Integer, String)(idKat, nama),
                .Text = If(_sidebarExpanded, "  " & nama, ""),
                .TextAlign = HorizontalAlignment.Left,
                .ImageAlign = HorizontalAlignment.Left,
                .ImageOffset = New Point(If(_sidebarExpanded, 10, 6), 0),
                .BorderRadius = 12,
                .Font = ModTema.FontTebal,
                .Cursor = Cursors.Hand,
                .Animated = True,
                .BackColor = Color.Transparent,
                .UseTransparentBackground = True
            }
            AddHandler btn.Click, Sub()
                                      _kategoriTerpilih = idKat
                                      PerbaruiHighlightKategori()
                                      TerapkanFilter()
                                  End Sub
            flpKategori.Controls.Add(btn)
            _katButtons.Add(btn)
        End Sub

        Private Sub PerbaruiHighlightKategori(Optional updateWidths As Boolean = True)
            flpKategori.SuspendLayout()
            For Each btn In _katButtons
                Dim info = DirectCast(btn.Tag, Tuple(Of Integer, String))
                Dim aktif As Boolean = (info.Item1 = _kategoriTerpilih)
                btn.FillColor = If(aktif, ModTema.WarnaUtama, ModTema.WarnaSekunderLatar)
                btn.ForeColor = If(aktif, Color.White, ModTema.WarnaTeks)
                btn.BorderThickness = If(aktif, 0, 1)
                btn.BorderColor = If(aktif, ModTema.WarnaUtama, Color.FromArgb(239, 228, 216))
                btn.HoverState.FillColor = If(aktif, ModTema.WarnaUtamaHover, ModTema.WarnaUtamaLembut)
                btn.Image = BistroIcons.GetCategoryIcon(info.Item2, If(aktif, Color.White, ModTema.WarnaUtama), 19)
                If updateWidths Then
                    btn.Width = If(_sidebarExpanded, 206, 50)
                    btn.Text = If(_sidebarExpanded, "  " & info.Item2, "")
                End If
            Next
            flpKategori.ResumeLayout(False)
        End Sub

        Private Sub ToggleSidebar(sender As Object, e As EventArgs)
            _sidebarExpanded = Not _sidebarExpanded
            Dim targetW As Integer = If(_sidebarExpanded, 232, 72)

            If Not _sidebarExpanded Then
                flpKategori.SuspendLayout()
                For Each b In _katButtons
                    b.Text = ""
                Next
                flpKategori.ResumeLayout(False)
            End If

            Dim startW As Single = CSng(pnlSidebar.Width)
            ModAnimasi.AnimateFloat(pnlSidebar, pnlSidebar, startW, CSng(targetW), 230UL,
                Sub(v)
                    Dim curW As Integer = CInt(Math.Round(v))
                    pnlSidebar.Width = curW
                    Dim btnW As Integer = Math.Max(48, curW - 24)
                    flpKategori.SuspendLayout()
                    For Each b In _katButtons
                        b.Width = btnW
                    Next
                    flpKategori.ResumeLayout(False)
                End Sub,
                Sub()
                    pnlSidebar.Width = targetW
                    PerbaruiHighlightKategori(True)
                End Sub,
                easing:=AddressOf WinFormAnimation.AnimationFunctions.QuinticEaseOut)
        End Sub

        Private Sub TerapkanFilter()
            If _dtProduk Is Nothing Then Return
            Dim bagian As New List(Of String)()
            If _kategoriTerpilih > 0 Then
                bagian.Add($"id_kategori = {_kategoriTerpilih}")
            End If
            Dim keyword As String = txtCari.Text.Trim().Replace("'", "''")
            If Not String.IsNullOrEmpty(keyword) Then
                bagian.Add($"(nama LIKE '%{keyword}%' OR deskripsi LIKE '%{keyword}%')")
            End If
            _bsProduk.Filter = String.Join(" AND ", bagian)
            BangunGridProduk()
        End Sub

        Private Sub BangunGridProduk()
            flpProduk.SuspendLayout()
            For Each oldCtrl As Control In flpProduk.Controls
                oldCtrl.Dispose()
            Next
            flpProduk.Controls.Clear()

            Dim ada As Boolean = False
            For Each itemObj As Object In _bsProduk.List
                Dim drv = TryCast(itemObj, DataRowView)
                If drv Is Nothing Then Continue For
                ada = True

                Dim stokVal As Integer? = If(IsDBNull(drv("stok")), Nothing, CType(CInt(drv("stok")), Integer?))
                Dim prod As New Produk With {
                    .IdProduk = CInt(drv("id_produk")),
                    .IdKategori = CInt(drv("id_kategori")),
                    .NamaKategori = CStr(drv("nama_kategori")),
                    .Nama = CStr(drv("nama")),
                    .Deskripsi = CStr(drv("deskripsi")),
                    .Harga = CDec(drv("harga")),
                    .Gambar = CStr(drv("gambar")),
                    .Tersedia = CBool(drv("tersedia")),
                    .BestSeller = CBool(drv("best_seller")),
                    .Stok = stokVal
                }

                Dim card As New ProdukCard() With {.Produk = prod}
                AddHandler card.Dipilih, AddressOf OnProdukDipilih
                flpProduk.Controls.Add(card)
            Next

            pnlKosong.Visible = Not ada
            flpProduk.Visible = ada
            flpProduk.ResumeLayout()
        End Sub

        Private Sub OnProdukDipilih(prod As Produk)
            Using frm As New FrmDetailProduk(prod.IdProduk)
                frm.ShowDialog(Me)
            End Using
        End Sub

        Private Sub RefreshBarKeranjang()
            If InvokeRequired Then
                BeginInvoke(New Action(AddressOf RefreshBarKeranjang))
                Return
            End If
            Dim jml As Integer = ModKeranjang.JumlahItem()
            Dim subTot As Decimal = ModKeranjang.Subtotal()
            If jml = 0 Then
                lblRingkasCart.Text = "Belum ada menu dipilih"
                lblTotalCart.Text = ModFormat.Rupiah(0D)
            Else
                lblRingkasCart.Text = $"{jml} {ModBahasa.T("item_dipilih")} ({ModKeranjang.TipeMakan})"
                lblTotalCart.Text = ModFormat.Rupiah(subTot)
            End If
            btnKeranjang.Enabled = (jml > 0)

            If _prevCartQty >= 0 AndAlso jml > _prevCartQty AndAlso Visible AndAlso Not ModAnimasi.NonaktifkanAnimasi Then
                ModAnimasi.AnimateColor(lblTotalCart, lblTotalCart, ModTema.WarnaUtama, Color.White,
                    Sub(c) lblTotalCart.ForeColor = c, 420UL)
            End If
            _prevCartQty = jml
        End Sub

        Private Sub TerapkanBahasa()
            If InvokeRequired Then
                BeginInvoke(New Action(AddressOf TerapkanBahasa))
                Return
            End If
            btnBahasa.Text = ModBahasa.Bahasa
            txtCari.PlaceholderText = ModBahasa.T("cari_placeholder")
            btnBatalPesanan.Text = ModBahasa.T("batal_pesanan")
            btnKeranjang.Text = ModBahasa.T("lihat_keranjang")
            If _katButtons.Count > 0 Then
                _katButtons(0).Tag = New Tuple(Of Integer, String)(0, ModBahasa.T("semua_kategori"))
                PerbaruiHighlightKategori()
            End If
            flpProduk.Invalidate(True)
            RefreshBarKeranjang()
        End Sub

        Private Sub OnBatalPesananClick(sender As Object, e As EventArgs)
            If ModKeranjang.JumlahItem() > 0 Then
                Dim res = MessageBox.Show("Batalkan pesanan dan kembali ke layar awal?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res <> DialogResult.Yes Then Return
            End If
            ModKeranjang.Kosongkan()
            RaiseEvent KembaliKeWelcome()
        End Sub

        Private Sub OnLihatKeranjangClick(sender As Object, e As EventArgs)
            Using frm As New FrmKeranjang()
                Dim res = ModNavigasi.BukaHalamanModal(Me, frm)
                If res = DialogResult.OK Then
                    RaiseEvent KembaliKeWelcome()
                Else
                    RefreshBarKeranjang()
                End If
            End Using
        End Sub

        Private Sub FrmMenu_FormClosing(sender As Object, e As FormClosingEventArgs)
            If e.CloseReason = CloseReason.UserClosing Then
                If ModKeranjang.JumlahItem() > 0 Then
                    Dim res = MessageBox.Show("Batalkan pesanan dan kembali ke layar awal?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If res <> DialogResult.Yes Then
                        e.Cancel = True
                        Return
                    End If
                End If
                e.Cancel = True
                ModKeranjang.Kosongkan()
                RaiseEvent KembaliKeWelcome()
                Return
            End If
            RemoveHandler ModKeranjang.KeranjangBerubah, AddressOf RefreshBarKeranjang
            RemoveHandler ModBahasa.BahasaBerubah, AddressOf TerapkanBahasa
            RemoveHandler ModNavigasi.ModeFullscreenBerubah, AddressOf OnModeFullscreenBerubah
        End Sub

    End Class
End Namespace
