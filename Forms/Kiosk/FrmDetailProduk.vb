Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    Public Class FrmDetailProduk
        Private ReadOnly _idProduk As Integer
        Private _produk As Produk
        Private ReadOnly _errDetail As New ErrorProvider()

        Private ReadOnly _opsiUkuran As New List(Of RadioButton)()
        Private ReadOnly _opsiAddon As New List(Of CheckBox)()
        Private ReadOnly _opsiPedas As New List(Of RadioButton)()

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not DesignMode Then cp.ExStyle = cp.ExStyle Or &H2000000
                Return cp
            End Get
        End Property

        Public Sub New()
            Me.New(1)
        End Sub

        Public Sub New(idProduk As Integer)
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModAnimasi.SiapkanTransisiMasuk(Me, 16)
            _idProduk = idProduk
            _errDetail.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ApplyRuntimePolish()
            MuatData()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar

            ModTema.GayaGunaCard(rootCard, 16)

            pnlKiri.FillColor = ModTema.WarnaSekunderLatar
            pnlKiri.BorderRadius = 14
            pnlKiri.CustomizableEdges.TopRight = False
            pnlKiri.CustomizableEdges.BottomRight = False
            pnlKiri.BorderThickness = 1
            pnlKiri.BorderColor = ModTema.WarnaGaris
            pnlKiri.UseTransparentBackground = True
            picProduk.BorderRadius = 12
            picProduk.FillColor = ModTema.WarnaPermukaan

            lblKategori.Font = New Font(ModTema.FontKecil.FontFamily, 8.5F, FontStyle.Bold)
            lblKategori.ForeColor = ModTema.WarnaUtama
            lblNama.Font = ModTema.FontJudul
            lblDeskripsi.Font = ModTema.FontBiasa
            lblDeskripsi.ForeColor = ModTema.WarnaTeksRedup
            lblDasarCaption.Font = ModTema.FontKecil
            lblHargaDasar.Font = New Font(ModTema.FontJudul.FontFamily, 18.0F, FontStyle.Bold)
            lblHargaDasar.ForeColor = ModTema.WarnaUtama

            lblHeadOpsi.Font = ModTema.FontJudul
            ModTema.GayaGunaButtonSekunder(btnCloseX, 8)
            AddHandler btnCloseX.Click, Sub()
                                            DialogResult = DialogResult.Cancel
                                            Close()
                                        End Sub

            pnlOpsiScroll.BackColor = ModTema.WarnaPermukaan
            lblCatatan.Font = ModTema.FontKecil
            lblCatatan.Text = ModBahasa.T("catatan") & " (maks. 100 karakter)"
            ModTema.GayaGunaTextBox(txtCatatan, "Contoh: saus dipisah, sedikit es...")

            lblQtyTitle.Font = ModTema.FontKecil
            lblQtyTitle.Text = ModBahasa.T("jumlah") & " (1-20)"
            btnKurang.Image = BistroIcons.GetIcon(IconChar.Minus, ModTema.WarnaTeks, 16)
            ModTema.GayaGunaButtonSekunder(btnKurang, 8)
            AddHandler btnKurang.Click, Sub() UbahQtyStepper(-1)

            ModTema.GayaGunaTextBox(txtQty)
            txtQty.TextAlign = HorizontalAlignment.Center
            AddHandler txtQty.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            AddHandler txtQty.TextChanged, Sub() HitungTotalLive()

            btnTambahQty.Image = BistroIcons.GetIcon(IconChar.Plus, ModTema.WarnaTeks, 16)
            ModTema.GayaGunaButtonSekunder(btnTambahQty, 8)
            AddHandler btnTambahQty.Click, Sub() UbahQtyStepper(1)

            lblHargaTotal.Font = New Font(ModTema.FontJudul.FontFamily, 18.0F, FontStyle.Bold)
            lblHargaTotal.ForeColor = ModTema.WarnaUtama

            btnBatal.Text = ModBahasa.T("batal")
            ModTema.GayaGunaButtonSekunder(btnBatal, 10)
            AddHandler btnBatal.Click, Sub()
                                           DialogResult = DialogResult.Cancel
                                           Close()
                                       End Sub

            btnTambah.Text = ModBahasa.T("tambah_keranjang")
            btnTambah.Image = BistroIcons.GetIcon(IconChar.ShoppingCart, Color.White, 18)
            btnTambah.ImageOffset = New Point(-8, 0)
            ModTema.GayaGunaButtonUtama(btnTambah, 10)
            AddHandler btnTambah.Click, AddressOf OnTambahClick
            AddHandler Shown, Sub() ModAnimasi.SlideUpFadeInModal(Me, 20, 230UL)
        End Sub

        Private Sub MuatData()
            Try
                _produk = ModProduk.AmbilProdukObj(_idProduk)
                If _produk Is Nothing Then
                    MessageBox.Show("Produk tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Close()
                    Return
                End If

                picProduk.Image = ModProduk.AmbilGambar(_produk.Gambar)
                lblKategori.Text = _produk.NamaKategori.ToUpperInvariant()
                lblNama.Text = _produk.Nama
                lblDeskripsi.Text = _produk.Deskripsi
                lblHargaDasar.Text = ModFormat.Rupiah(_produk.Harga)

                Dim dtOpsi = ModProduk.AmbilOpsi(_idProduk)
                BangunOpsiDinamis(dtOpsi)
                HitungTotalLive()
            Catch ex As Exception
                MessageBox.Show("Gagal memuat detail produk: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Shared Function BuatSectionCard(judul As String, curY As Integer) As Guna2Panel
            Dim card As New Guna2Panel() With {
                .Location = New Point(2, curY),
                .Width = 424,
                .BorderRadius = 12,
                .BorderColor = ModTema.WarnaGaris,
                .BorderThickness = 1,
                .FillColor = ModTema.WarnaSekunderLatar,
                .BackColor = Color.Transparent,
                .UseTransparentBackground = True
            }
            Dim lblTitle As New Label() With {
                .Location = New Point(14, 10),
                .Size = New Size(396, 22),
                .Font = ModTema.FontTebal,
                .ForeColor = ModTema.WarnaTeks,
                .BackColor = Color.Transparent,
                .Text = judul
            }
            card.Controls.Add(lblTitle)
            Return card
        End Function

        Private Sub BangunOpsiDinamis(dtOpsi As DataTable)
            pnlOpsiScroll.Controls.Clear()
            _opsiUkuran.Clear()
            _opsiAddon.Clear()
            _opsiPedas.Clear()

            Dim curY As Integer = 4

            ' 1. Ukuran
            Dim ukuranRows = dtOpsi.Select($"tipe = '{TipeOpsi.Ukuran}'")
            If ukuranRows.Length > 0 Then
                Dim cardUk = BuatSectionCard(ModBahasa.T("ukuran"), curY)
                Dim ry As Integer = 36
                For idx As Integer = 0 To ukuranRows.Length - 1
                    Dim row = ukuranRows(idx)
                    Dim namaOpsi As String = CStr(row("nama_opsi"))
                    Dim tambahan As Decimal = CDec(row("tambahan_harga"))
                    Dim teks As String = If(tambahan > 0D, $"{namaOpsi} (+{ModFormat.Rupiah(tambahan)})", namaOpsi)
                    Dim rdo As New RadioButton() With {
                        .Text = teks,
                        .Tag = New Tuple(Of String, Decimal)(namaOpsi, tambahan),
                        .Location = New Point(16, ry),
                        .Size = New Size(392, 26),
                        .Font = ModTema.FontBiasa,
                        .BackColor = Color.Transparent,
                        .Checked = (idx = 0)
                    }
                    AddHandler rdo.CheckedChanged, Sub() HitungTotalLive()
                    cardUk.Controls.Add(rdo)
                    _opsiUkuran.Add(rdo)
                    ry += 28
                Next
                cardUk.Height = ry + 12
                pnlOpsiScroll.Controls.Add(cardUk)
                curY += cardUk.Height + 10
            End If

            ' 2. Addon
            Dim addonRows = dtOpsi.Select($"tipe = '{TipeOpsi.Addon}'")
            If addonRows.Length > 0 Then
                Dim cardAdd = BuatSectionCard(ModBahasa.T("addon"), curY)
                Dim cy As Integer = 36
                For Each row In addonRows
                    Dim namaOpsi As String = CStr(row("nama_opsi"))
                    Dim tambahan As Decimal = CDec(row("tambahan_harga"))
                    Dim chk As New CheckBox() With {
                        .Text = $"{namaOpsi} (+{ModFormat.Rupiah(tambahan)})",
                        .Tag = New Tuple(Of String, Decimal)(namaOpsi, tambahan),
                        .Location = New Point(16, cy),
                        .Size = New Size(392, 26),
                        .Font = ModTema.FontBiasa,
                        .BackColor = Color.Transparent
                    }
                    AddHandler chk.CheckedChanged, Sub() HitungTotalLive()
                    cardAdd.Controls.Add(chk)
                    _opsiAddon.Add(chk)
                    cy += 28
                Next
                cardAdd.Height = cy + 12
                pnlOpsiScroll.Controls.Add(cardAdd)
                curY += cardAdd.Height + 10
            End If

            ' 3. Pedas
            Dim pedasRows = dtOpsi.Select($"tipe = '{TipeOpsi.Pedas}'")
            If pedasRows.Length > 0 Then
                Dim cardPedas = BuatSectionCard(ModBahasa.T("pedas"), curY)
                Dim py As Integer = 36
                For idx As Integer = 0 To pedasRows.Length - 1
                    Dim row = pedasRows(idx)
                    Dim namaOpsi As String = CStr(row("nama_opsi"))
                    Dim tambahan As Decimal = CDec(row("tambahan_harga"))
                    Dim rdo As New RadioButton() With {
                        .Text = namaOpsi,
                        .Tag = New Tuple(Of String, Decimal)(namaOpsi, tambahan),
                        .Location = New Point(16, py),
                        .Size = New Size(392, 26),
                        .Font = ModTema.FontBiasa,
                        .BackColor = Color.Transparent,
                        .Checked = (idx = 0)
                    }
                    AddHandler rdo.CheckedChanged, Sub() HitungTotalLive()
                    cardPedas.Controls.Add(rdo)
                    _opsiPedas.Add(rdo)
                    py += 28
                Next
                cardPedas.Height = py + 12
                pnlOpsiScroll.Controls.Add(cardPedas)
                curY += cardPedas.Height + 10
            End If

            If dtOpsi.Rows.Count = 0 Then
                Dim lblNoOpsi As New Label() With {
                    .Location = New Point(8, 16),
                    .Size = New Size(410, 40),
                    .Font = ModTema.FontBiasa,
                    .ForeColor = ModTema.WarnaTeksRedup,
                    .Text = "Produk ini siap dipesan tanpa pilihan opsi tambahan."
                }
                pnlOpsiScroll.Controls.Add(lblNoOpsi)
            End If
        End Sub

        Private Sub UbahQtyStepper(delta As Integer)
            Dim qty As Integer = 1
            Integer.TryParse(txtQty.Text.Trim(), qty)
            qty = Math.Max(1, Math.Min(20, qty + delta))
            txtQty.Text = qty.ToString()
        End Sub

        Private Function HitungTambahanOpsi(ByRef ringkasanOpsi As String) As Decimal
            Dim totalTambahan As Decimal = 0D
            Dim bagian As New List(Of String)()

            For Each rdo In _opsiUkuran
                If rdo.Checked Then
                    Dim info = DirectCast(rdo.Tag, Tuple(Of String, Decimal))
                    totalTambahan += info.Item2
                    bagian.Add(info.Item1)
                End If
            Next
            For Each chk In _opsiAddon
                If chk.Checked Then
                    Dim info = DirectCast(chk.Tag, Tuple(Of String, Decimal))
                    totalTambahan += info.Item2
                    bagian.Add(info.Item1)
                End If
            Next
            For Each rdo In _opsiPedas
                If rdo.Checked Then
                    Dim info = DirectCast(rdo.Tag, Tuple(Of String, Decimal))
                    totalTambahan += info.Item2
                    bagian.Add(info.Item1)
                End If
            Next

            ringkasanOpsi = String.Join(", ", bagian)
            Return totalTambahan
        End Function

        Private Sub HitungTotalLive()
            If _produk Is Nothing Then Return
            Dim ringkas As String = ""
            Dim tambahan As Decimal = HitungTambahanOpsi(ringkas)
            Dim qty As Integer = 0
            If Not Integer.TryParse(txtQty.Text.Trim(), qty) OrElse qty < 1 OrElse qty > 20 Then
                _errDetail.SetError(txtQty, "Jumlah harus angka antara 1 sampai 20.")
                lblHargaTotal.Text = ModFormat.Rupiah(_produk.Harga + tambahan)
                Return
            End If
            _errDetail.SetError(txtQty, "")
            Dim total As Decimal = (_produk.Harga + tambahan) * qty
            lblHargaTotal.Text = ModFormat.Rupiah(total)
        End Sub

        Private Sub OnTambahClick(sender As Object, e As EventArgs)
            If _produk Is Nothing Then Return
            Dim qty As Integer = 0
            If Not Integer.TryParse(txtQty.Text.Trim(), qty) OrElse qty < 1 OrElse qty > 20 Then
                _errDetail.SetError(txtQty, "Jumlah harus angka antara 1 sampai 20.")
                ModAnimasi.ShakeControl(txtQty)
                txtQty.Focus()
                Return
            End If
            If _produk.Stok.HasValue AndAlso qty > _produk.Stok.Value Then
                _errDetail.SetError(txtQty, $"Stok tersisa hanya {_produk.Stok.Value}.")
                ModAnimasi.ShakeControl(txtQty)
                Return
            End If
            _errDetail.SetError(txtQty, "")

            Dim ringkas As String = ""
            Dim tambahan As Decimal = HitungTambahanOpsi(ringkas)
            Dim catatan As String = txtCatatan.Text.Trim()
            Dim kunci As String = $"{_produk.IdProduk}|{ringkas}|{catatan}"

            ModKeranjang.Tambah(New ItemKeranjang With {
                .Kunci = kunci,
                .IdProduk = _produk.IdProduk,
                .NamaProduk = _produk.Nama,
                .Gambar = _produk.Gambar,
                .HargaDasar = _produk.Harga,
                .TambahanOpsi = tambahan,
                .OpsiDipilih = ringkas,
                .Catatan = catatan,
                .Qty = qty
            })

            DialogResult = DialogResult.OK
            Close()
        End Sub

    End Class
End Namespace
