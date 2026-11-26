Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Checkout

    Public Class FrmKeranjang
        Private ReadOnly _errKeranjang As New ErrorProvider()
        Private ReadOnly _bsKeranjang As New BindingSource()
        Private _upsellSudahDitawarkan As Boolean = False
        Private ReadOnly _voucherDipakaiSet As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Private _rincianAktif As RincianHarga

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
            _errKeranjang.BlinkStyle = ErrorBlinkStyle.NeverBlink
            If Not String.IsNullOrEmpty(ModKeranjang.KodeVoucherAktif) Then
                _voucherDipakaiSet.Add(ModKeranjang.KodeVoucherAktif)
            End If
            ApplyRuntimePolish()
            MuatKeranjang()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            Text = "Bistro Kiosk — " & ModBahasa.T("keranjang_judul")
            BackColor = ModTema.WarnaLatar
            ModTema.AktifkanDoubleBuffer(flpUpsellItems)
            ModTema.AktifkanDoubleBuffer(cardGrid)
            ModTema.AktifkanDoubleBuffer(pnlKanan)

            pnlHead.FillColor = ModTema.WarnaCharcoal
            icCart.Image = BistroIcons.GetIcon(IconChar.ShoppingCart, ModTema.WarnaAksen, 24)
            lblHead.Font = New Font(ModTema.FontJudul.FontFamily, 16.0F, FontStyle.Bold)
            lblHead.Text = $"{ModBahasa.T("keranjang_judul")} ({ModKeranjang.TipeMakan})"

            For Each c In {cardGrid, cardMember, cardVoucher, cardSummary, pnlUpsell}
                ModTema.GayaGunaCard(c, 16)
            Next
            pnlUpsell.BorderColor = Color.FromArgb(242, 196, 174)
            pnlUpsell.BorderThickness = 1
            pnlUpsell.FillColor = ModTema.WarnaSekunderLatar

            ModTema.GayaDataGridView(dgvKeranjang)
            Dim idCulture = New CultureInfo("id-ID")
            colHarga.DefaultCellStyle.FormatProvider = idCulture
            colSubtotal.DefaultCellStyle.FormatProvider = idCulture

            btnKurang.Image = BistroIcons.GetIcon(IconChar.Minus, ModTema.WarnaTeks, 15)
            ModTema.GayaGunaButtonSekunder(btnKurang, 8)
            AddHandler btnKurang.Click, Sub() UbahQtyTerpilih(-1)

            btnTambah.Image = BistroIcons.GetIcon(IconChar.Plus, ModTema.WarnaTeks, 15)
            ModTema.GayaGunaButtonSekunder(btnTambah, 8)
            AddHandler btnTambah.Click, Sub() UbahQtyTerpilih(1)

            btnHapus.Image = BistroIcons.GetIcon(IconChar.TrashAlt, ModTema.WarnaBahaya, 15)
            btnHapus.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonBahaya(btnHapus, 10)
            AddHandler btnHapus.Click, AddressOf OnHapusItemClick

            lblUpsellHead.Font = ModTema.FontTebal
            lblUpsellHead.Text = ModBahasa.T("upsell_judul")
            btnLewatiUpsell.Text = ModBahasa.T("lewati")
            ModTema.GayaGunaButtonSekunder(btnLewatiUpsell, 8)
            AddHandler btnLewatiUpsell.Click, Sub()
                                                  pnlUpsell.Visible = False
                                                  BukaPembayaran()
                                              End Sub

            ModTema.GayaGunaTextBox(txtNoHpMember, "No. HP Member...")
            AddHandler txtNoHpMember.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            ModTema.GayaGunaButtonDark(btnCariMember, 8)
            AddHandler btnCariMember.Click, AddressOf OnCariMemberClick

            ModTema.GayaGunaTextBox(txtPakaiPoin, "Poin dipakai...")
            AddHandler txtPakaiPoin.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            ModTema.GayaGunaButtonSekunder(btnPakaiPoin, 8)
            AddHandler btnPakaiPoin.Click, AddressOf OnPakaiPoinClick

            ModTema.GayaGunaTextBox(txtVoucher, "Masukkan kode promo...")
            ModTema.GayaGunaButtonUtama(btnPakaiVoucher, 8)
            AddHandler btnPakaiVoucher.Click, AddressOf OnPakaiVoucherClick

            lblSumTitle.Font = ModTema.FontSubJudul
            lblCapPajak.Text = $"Pajak (PPN {ModPengaturan.Ambil("pajak_persen", "11")}%)"
            lblTotal.Font = New Font(ModTema.FontJudul.FontFamily, 17.5F, FontStyle.Bold)
            lblTotal.ForeColor = ModTema.WarnaUtama

            btnKembaliMenu.Image = BistroIcons.GetIcon(IconChar.ArrowLeft, ModTema.WarnaTeks, 16)
            btnKembaliMenu.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSekunder(btnKembaliMenu, 10)
            AddHandler btnKembaliMenu.Click, Sub()
                                                 DialogResult = DialogResult.Cancel
                                                 Close()
                                             End Sub

            btnLanjutBayar.Text = ModBahasa.T("lanjut_bayar")
            btnLanjutBayar.Image = BistroIcons.GetIcon(IconChar.ArrowRight, Color.White, 16)
            btnLanjutBayar.ImageOffset = New Point(6, 0)
            ModTema.GayaGunaButtonUtama(btnLanjutBayar, 10)
            AddHandler btnLanjutBayar.Click, AddressOf OnLanjutBayarClick

            ' Tata ulang pnlKanan agar responsif pada tinggi jendela kecil dan DPI tinggi
            pnlKanan.SuspendLayout()
            pnlKanan.Padding = New Padding(10, 14, 18, 14)
            Dim tlpAksiKanan As New TableLayoutPanel() With {
                .Dock = DockStyle.Bottom,
                .Height = 76,
                .ColumnCount = 2,
                .RowCount = 1,
                .BackColor = Color.Transparent,
                .Padding = New Padding(2, 10, 2, 10)
            }
            tlpAksiKanan.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 39.0F))
            tlpAksiKanan.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 61.0F))
            tlpAksiKanan.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))

            Dim pnlScrollKanan As New Panel() With {
                .Dock = DockStyle.Fill,
                .AutoScroll = True,
                .BackColor = Color.Transparent
            }
            pnlKanan.Controls.Remove(btnKembaliMenu)
            pnlKanan.Controls.Remove(btnLanjutBayar)
            pnlKanan.Controls.Remove(cardMember)
            pnlKanan.Controls.Remove(cardVoucher)
            pnlKanan.Controls.Remove(cardSummary)

            cardMember.Location = New Point(2, 4)
            cardVoucher.Location = New Point(2, cardMember.Bottom + 10)
            cardSummary.Location = New Point(2, cardVoucher.Bottom + 10)
            pnlScrollKanan.Controls.AddRange({cardMember, cardVoucher, cardSummary})

            btnKembaliMenu.Dock = DockStyle.Fill
            btnKembaliMenu.Margin = New Padding(0, 0, 6, 0)
            btnLanjutBayar.Dock = DockStyle.Fill
            btnLanjutBayar.Margin = New Padding(6, 0, 0, 0)
            tlpAksiKanan.Controls.Add(btnKembaliMenu, 0, 0)
            tlpAksiKanan.Controls.Add(btnLanjutBayar, 1, 0)

            pnlKanan.Controls.Add(pnlScrollKanan)
            pnlKanan.Controls.Add(tlpAksiKanan)
            pnlKanan.ResumeLayout()

            AddHandler Shown, Sub() ModAnimasi.FadeInForm(Me, 200UL)
        End Sub

        Private Sub MuatKeranjang()
            Dim items = ModKeranjang.Isi()
            _bsKeranjang.DataSource = items
            dgvKeranjang.DataSource = _bsKeranjang

            If ModKeranjang.MemberAktif IsNot Nothing Then
                txtNoHpMember.Text = ModKeranjang.MemberAktif.NoHp
                lblInfoMember.Text = $"{ModKeranjang.MemberAktif.Nama} — {ModKeranjang.MemberAktif.Poin} poin tersedia"
                lblInfoMember.ForeColor = ModTema.WarnaSukses
            End If
            If Not String.IsNullOrEmpty(ModKeranjang.KodeVoucherAktif) Then
                txtVoucher.Text = ModKeranjang.KodeVoucherAktif
            End If

            HitungDanTampilkanRingkasan()
        End Sub

        Private Sub HitungDanTampilkanRingkasan()
            Dim subtotal As Decimal = ModKeranjang.Subtotal()
            If subtotal <= 0D Then
                ModKeranjang.PoinDipakaiAktif = 0
                pnlUpsell.Visible = False
            End If

            ' Validasi ulang voucher aktif jika subtotal berkurang setelah hapus/ubah item
            If Not String.IsNullOrEmpty(ModKeranjang.KodeVoucherAktif) Then
                Dim hv = ModPromo.CekVoucher(ModKeranjang.KodeVoucherAktif, subtotal)
                If Not hv.Valid Then
                    ModKeranjang.KodeVoucherAktif = ""
                    _voucherDipakaiSet.Clear()
                    lblStatusVoucher.Text = "Voucher dilepas: " & hv.Pesan
                    lblStatusVoucher.ForeColor = ModTema.WarnaPeringatan
                End If
            End If

            _rincianAktif = ModPromo.HitungRincian(subtotal, ModKeranjang.KodeVoucherAktif, ModKeranjang.PoinDipakaiAktif)

            lblSubtotal.Text = ModFormat.Rupiah(_rincianAktif.Subtotal)
            lblDiskonBertingkat.Text = If(_rincianAktif.DiskonBertingkat > 0D, "-" & ModFormat.Rupiah(_rincianAktif.DiskonBertingkat), "Rp0")
            lblDiskonVoucher.Text = If(_rincianAktif.DiskonVoucher > 0D, "-" & ModFormat.Rupiah(_rincianAktif.DiskonVoucher), "Rp0")
            lblDiskonPoin.Text = If(_rincianAktif.DiskonPoin > 0D, "-" & ModFormat.Rupiah(_rincianAktif.DiskonPoin), "Rp0")
            lblPajak.Text = ModFormat.Rupiah(_rincianAktif.Pajak)
            lblTotal.Text = ModFormat.Rupiah(_rincianAktif.Total)

            If ModKeranjang.MemberAktif IsNot Nothing Then
                lblPoinDidapat.Text = $"Estimasi poin didapat: +{_rincianAktif.PoinDidapat} poin"
            Else
                lblPoinDidapat.Text = "Daftar/cari member untuk kumpulkan poin"
            End If

            btnLanjutBayar.Enabled = (ModKeranjang.JumlahItem() > 0)
        End Sub

        Private Function AmbilItemTerpilih() As ItemKeranjang
            If dgvKeranjang.CurrentRow Is Nothing Then Return Nothing
            Return TryCast(dgvKeranjang.CurrentRow.DataBoundItem, ItemKeranjang)
        End Function

        Private Sub UbahQtyTerpilih(delta As Integer)
            Dim item = AmbilItemTerpilih()
            If item Is Nothing Then Return
            Dim kunci As String = item.Kunci
            Dim qtyBaru As Integer = item.Qty + delta
            If qtyBaru <= 0 Then
                Dim res = MessageBox.Show($"Hapus '{item.NamaProduk}' dari keranjang?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res <> DialogResult.Yes Then Return
                ModKeranjang.Hapus(kunci)
            Else
                ModKeranjang.UbahQty(kunci, qtyBaru)
            End If
            MuatKeranjang()
            PilihBarisByKunci(kunci)
        End Sub

        Private Sub OnHapusItemClick(sender As Object, e As EventArgs)
            Dim item = AmbilItemTerpilih()
            If item Is Nothing Then Return
            Dim res = MessageBox.Show($"Hapus '{item.NamaProduk}' dari keranjang?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                ModKeranjang.Hapus(item.Kunci)
                MuatKeranjang()
            End If
        End Sub

        Private Sub PilihBarisByKunci(kunci As String)
            For Each row As DataGridViewRow In dgvKeranjang.Rows
                Dim it = TryCast(row.DataBoundItem, ItemKeranjang)
                If it IsNot Nothing AndAlso it.Kunci = kunci Then
                    row.Selected = True
                    dgvKeranjang.CurrentCell = row.Cells(0)
                    Exit For
                End If
            Next
        End Sub

        Private Sub OnCariMemberClick(sender As Object, e As EventArgs)
            If Not ModValidasi.WajibIsi(txtNoHpMember, _errKeranjang, "Masukkan No. HP member.") Then
                ModAnimasi.ShakeControl(txtNoHpMember)
                Return
            End If
            Dim m = ModMember.Cari(txtNoHpMember.Text.Trim())
            If m Is Nothing Then
                ModKeranjang.MemberAktif = Nothing
                ModKeranjang.PoinDipakaiAktif = 0
                lblInfoMember.Text = "Member tidak ditemukan."
                lblInfoMember.ForeColor = ModTema.WarnaBahaya
                ModAnimasi.ShakeControl(txtNoHpMember)
            Else
                ModKeranjang.MemberAktif = m
                lblInfoMember.Text = $"{m.Nama} — {m.Poin} poin tersedia"
                lblInfoMember.ForeColor = ModTema.WarnaSukses
            End If
            HitungDanTampilkanRingkasan()
        End Sub

        Private Sub OnPakaiPoinClick(sender As Object, e As EventArgs)
            If ModKeranjang.MemberAktif Is Nothing Then
                _errKeranjang.SetError(txtPakaiPoin, "Cari member terlebih dahulu.")
                Return
            End If
            Dim poin As Decimal = 0D
            If Not ModValidasi.BacaAngka(txtPakaiPoin, _errKeranjang, poin) Then Return
            Dim pInt As Integer = CInt(poin)
            If pInt < 0 OrElse pInt > ModKeranjang.MemberAktif.Poin Then
                _errKeranjang.SetError(txtPakaiPoin, $"Poin maksimal {ModKeranjang.MemberAktif.Poin}.")
                Return
            End If
            _errKeranjang.SetError(txtPakaiPoin, "")
            ModKeranjang.PoinDipakaiAktif = pInt
            HitungDanTampilkanRingkasan()
        End Sub

        Private Sub OnPakaiVoucherClick(sender As Object, e As EventArgs)
            Dim kode As String = txtVoucher.Text.Trim().ToUpperInvariant()
            If _voucherDipakaiSet.Contains(kode) AndAlso ModKeranjang.KodeVoucherAktif = kode Then
                lblStatusVoucher.Text = $"Voucher '{kode}' sudah diterapkan."
                lblStatusVoucher.ForeColor = ModTema.WarnaPeringatan
                Return
            End If

            Dim hv = ModPromo.CekVoucher(kode, ModKeranjang.Subtotal())
            If Not hv.Valid Then
                _errKeranjang.SetError(txtVoucher, hv.Pesan)
                lblStatusVoucher.Text = hv.Pesan
                lblStatusVoucher.ForeColor = ModTema.WarnaBahaya
                ModAnimasi.ShakeControl(txtVoucher)
                Return
            End If

            _errKeranjang.SetError(txtVoucher, "")
            _voucherDipakaiSet.Clear()
            _voucherDipakaiSet.Add(kode)
            ModKeranjang.KodeVoucherAktif = kode
            lblStatusVoucher.Text = hv.Pesan
            lblStatusVoucher.ForeColor = ModTema.WarnaSukses
            HitungDanTampilkanRingkasan()
        End Sub

        Private Sub OnLanjutBayarClick(sender As Object, e As EventArgs)
            If ModKeranjang.JumlahItem() = 0 Then Return

            If Not _upsellSudahDitawarkan Then
                Dim adaMinumanOrSide As Boolean = False
                Dim idsDiKeranjang As New HashSet(Of Integer)()
                For Each it In ModKeranjang.Isi()
                    idsDiKeranjang.Add(it.IdProduk)
                    Dim prod = ModProduk.AmbilProdukObj(it.IdProduk)
                    If prod IsNot Nothing AndAlso (String.Equals(prod.NamaKategori, "Side Dish", StringComparison.OrdinalIgnoreCase) OrElse
                                                   String.Equals(prod.NamaKategori, "Minuman", StringComparison.OrdinalIgnoreCase)) Then
                        adaMinumanOrSide = True
                    End If
                Next

                If Not adaMinumanOrSide Then
                    _upsellSudahDitawarkan = True
                    TampilkanUpsell(idsDiKeranjang)
                    Return
                End If
            End If

            BukaPembayaran()
        End Sub

        Private Sub TampilkanUpsell(idsDiKeranjang As HashSet(Of Integer))
            flpUpsellItems.Controls.Clear()
            Dim dtAll = ModProduk.AmbilProduk(0)
            Dim saran As New List(Of Produk)()
            For Each r As DataRow In dtAll.Rows
                Dim tersedia As Boolean = CBool(r("tersedia"))
                Dim idProd As Integer = CInt(r("id_produk"))
                Dim katNama As String = CStr(r("nama_kategori"))
                If tersedia AndAlso Not idsDiKeranjang.Contains(idProd) AndAlso
                   (String.Equals(katNama, "Side Dish", StringComparison.OrdinalIgnoreCase) OrElse
                    String.Equals(katNama, "Minuman", StringComparison.OrdinalIgnoreCase)) Then
                    saran.Add(New Produk With {
                        .IdProduk = idProd,
                        .IdKategori = CInt(r("id_kategori")),
                        .NamaKategori = katNama,
                        .Nama = CStr(r("nama")),
                        .Harga = CDec(r("harga")),
                        .Gambar = CStr(r("gambar")),
                        .Tersedia = tersedia
                    })
                    If saran.Count >= 3 Then Exit For
                End If
            Next

            If saran.Count = 0 Then
                BukaPembayaran()
                Return
            End If

            For Each prod In saran
                Dim pItem = prod
                Dim miniCard As New Guna2Panel() With {
                    .Size = New Size(214, 124),
                    .Margin = New Padding(0, 0, 10, 0)
                }
                ModTema.GayaGunaCard(miniCard, 14)
                miniCard.ShadowDecoration.Enabled = False
                miniCard.UseTransparentBackground = True

                Dim pic As New PictureBox() With {
                    .Location = New Point(10, 14),
                    .Size = New Size(58, 58),
                    .SizeMode = PictureBoxSizeMode.Zoom,
                    .Image = ModProduk.AmbilGambar(pItem.Gambar)
                }
                Dim lblN As New Label() With {
                    .Location = New Point(74, 10),
                    .Size = New Size(130, 36),
                    .Font = ModTema.FontKecil,
                    .ForeColor = ModTema.WarnaTeks,
                    .BackColor = Color.Transparent,
                    .Text = pItem.Nama
                }
                Dim lblP As New Label() With {
                    .Location = New Point(74, 48),
                    .Size = New Size(130, 22),
                    .Font = ModTema.FontTebal,
                    .ForeColor = ModTema.WarnaUtama,
                    .BackColor = Color.Transparent,
                    .Text = ModFormat.Rupiah(pItem.Harga)
                }
                Dim btnAdd As New Guna2Button() With {
                    .Location = New Point(10, 82),
                    .Size = New Size(194, 32),
                    .Text = "+ Tambah"
                }
                ModTema.GayaGunaButtonUtama(btnAdd, 10)
                AddHandler btnAdd.Click, Sub()
                                             ModKeranjang.Tambah(New ItemKeranjang With {
                                                 .Kunci = $"{pItem.IdProduk}||",
                                                 .IdProduk = pItem.IdProduk,
                                                 .NamaProduk = pItem.Nama,
                                                 .Gambar = pItem.Gambar,
                                                 .HargaDasar = pItem.Harga,
                                                 .Qty = 1
                                             })
                                             btnAdd.Text = "Ditambahkan"
                                             btnAdd.Enabled = False
                                             MuatKeranjang()
                                         End Sub

                miniCard.Controls.AddRange({pic, lblN, lblP, btnAdd})
                flpUpsellItems.Controls.Add(miniCard)
            Next
            Dim targetH As Integer = Math.Max(175, pnlUpsell.Height)
            If Visible AndAlso Not ModAnimasi.NonaktifkanAnimasi Then
                pnlUpsell.Height = 1
                pnlUpsell.Visible = True
                ModAnimasi.AnimateFloat(pnlUpsell, pnlUpsell, 1.0F, CSng(targetH), 260UL,
                    Sub(v) pnlUpsell.Height = CInt(Math.Round(v)),
                    Sub() pnlUpsell.Height = targetH,
                    easing:=AddressOf WinFormAnimation.AnimationFunctions.QuinticEaseOut)
            Else
                pnlUpsell.Height = targetH
                pnlUpsell.Visible = True
            End If
        End Sub

        Private Sub BukaPembayaran()
            HitungDanTampilkanRingkasan()
            Using frm As New FrmPembayaran(_rincianAktif)
                If ModNavigasi.BukaHalamanModal(Me, frm) = DialogResult.OK Then
                    DialogResult = DialogResult.OK
                    Close()
                End If
            End Using
        End Sub

    End Class
End Namespace
