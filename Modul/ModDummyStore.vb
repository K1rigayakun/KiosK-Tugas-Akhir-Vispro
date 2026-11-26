Option Strict On
Option Explicit On

Imports System.Security.Cryptography
Imports System.Text
Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    ''' <summary>
    ''' Penyimpanan data simulasi di memori agar seluruh alur A1-A5 bekerja penuh secara interaktif
    ''' sebelum disambungkan ke Supabase di Fase 2.
    ''' </summary>
    Public Module ModDummyStore

        Private _sudahInit As Boolean = False

        Public ReadOnly KategoriList As New List(Of Kategori)()
        Public ReadOnly ProdukList As New List(Of Produk)()
        Public ReadOnly OpsiList As New List(Of OpsiProduk)()
        Public ReadOnly PenggunaList As New List(Of Pengguna)()
        Public ReadOnly MemberList As New List(Of Member)()
        Public ReadOnly VoucherList As New List(Of Voucher)()
        Public ReadOnly PesananList As New List(Of PesananData)()
        Public ReadOnly DetailList As New List(Of DetailPesananData)()
        Public ReadOnly LogList As New List(Of LogAktivitasData)()
        Public ReadOnly RatingList As New List(Of RatingPesananData)()
        Public ReadOnly BannerList As New List(Of BannerPromo)()
        Public ReadOnly PengaturanDict As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

        Public NextKategoriId As Integer = 8
        Public NextProdukId As Integer = 25
        Public NextOpsiId As Integer = 100
        Public NextPenggunaId As Integer = 4
        Public NextMemberId As Integer = 21
        Public NextPesananId As Integer = 1
        Public NextDetailId As Integer = 1
        Public NextLogId As Long = 1

        Public Function HashPasswordPbkdf2(password As String) As String
            Dim salt(15) As Byte
            RandomNumberGenerator.Fill(salt)
            Dim iterasi As Integer = 100000
            Dim hash As Byte() = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iterasi, HashAlgorithmName.SHA256, 32)
            Return $"pbkdf2${iterasi}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}"
        End Function

        Public Function VerifikasiPassword(password As String, storedHash As String) As Boolean
            If String.IsNullOrWhiteSpace(storedHash) Then Return False
            If storedHash.StartsWith("pbkdf2$", StringComparison.Ordinal) Then
                Dim parts As String() = storedHash.Split("$"c)
                If parts.Length <> 4 Then Return False
                Dim iterasi As Integer
                If Not Integer.TryParse(parts(1), iterasi) Then Return False
                Dim salt As Byte() = Convert.FromBase64String(parts(2))
                Dim expected As Byte() = Convert.FromBase64String(parts(3))
                Dim actual As Byte() = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iterasi, HashAlgorithmName.SHA256, expected.Length)
                Return CryptographicOperations.FixedTimeEquals(actual, expected)
            Else
                ' Fallback SHA256 kompatibel versi minimal
                Dim bytes As Byte() = SHA256.HashData(Encoding.UTF8.GetBytes(password))
                Dim hex As String = Convert.ToHexString(bytes).ToLowerInvariant()
                Return CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(hex), Encoding.UTF8.GetBytes(storedHash.ToLowerInvariant()))
            End If
        End Function

        Public Sub PastikanInit()
            If _sudahInit Then Return
            _sudahInit = True

            ' 1. Pengaturan default (termasuk kunci dari KioskResto Orang 1)
            PengaturanDict("nama_toko") = "Bistro Kiosk Nusantara"
            PengaturanDict("alamat_toko") = "Jl. Kuliner Nusantara No. 18, Bandung"
            PengaturanDict("telepon_toko") = "022-8881234"
            PengaturanDict("footer_struk") = "Terima kasih telah berkunjung!"
            PengaturanDict("pajak_persen") = "11"
            PengaturanDict("service_persen") = "0"
            PengaturanDict("versi_aplikasi") = "1.0.0"
            PengaturanDict("idle_detik") = "60"
            PengaturanDict("ambang_stok") = "5"
            PengaturanDict("ambang_tunggu_menit") = "10"
            PengaturanDict("poin_per_rupiah") = "10000"
            PengaturanDict("nilai_poin") = "100"
            PengaturanDict("bahasa_default") = "ID"

            ' 2. Pengguna
            PenggunaList.Add(New Pengguna With {.IdPengguna = 1, .Username = "admin", .PasswordHash = HashPasswordPbkdf2("admin123"), .Nama = "Raka Pratama", .Peran = Model.Peran.Admin, .Aktif = True})
            PenggunaList.Add(New Pengguna With {.IdPengguna = 2, .Username = "kasir1", .PasswordHash = HashPasswordPbkdf2("kasir123"), .Nama = "Nadia Putri", .Peran = Model.Peran.Kasir, .Aktif = True})
            PenggunaList.Add(New Pengguna With {.IdPengguna = 3, .Username = "kasir2", .PasswordHash = HashPasswordPbkdf2("kasir123"), .Nama = "Bima Saputra", .Peran = Model.Peran.Kasir, .Aktif = True})

            ' 3. Kategori (7 kategori)
            KategoriList.AddRange({
                New Kategori With {.IdKategori = 1, .Nama = "Paket Hemat", .Urutan = 1},
                New Kategori With {.IdKategori = 2, .Nama = "Ayam", .Urutan = 2},
                New Kategori With {.IdKategori = 3, .Nama = "Burger", .Urutan = 3},
                New Kategori With {.IdKategori = 4, .Nama = "Nasi", .Urutan = 4},
                New Kategori With {.IdKategori = 5, .Nama = "Side Dish", .Urutan = 5},
                New Kategori With {.IdKategori = 6, .Nama = "Minuman", .Urutan = 6},
                New Kategori With {.IdKategori = 7, .Nama = "Dessert", .Urutan = 7}
            })

            ' 4. Produk (24 produk)
            TambahSeedProduk(1, 1, "Paket Hemat Bistro 1", "2 Ayam Crispy, Nasi Hangat, dan Es Lemon Tea", 42000D, "paket_combo.jpg", True, True, Nothing)
            TambahSeedProduk(2, 1, "Paket Duo Terakota", "2 Ayam, 2 Nasi, 2 Kentang, dan 2 Minuman", 78000D, "paket_combo.jpg", True, True, Nothing)
            TambahSeedProduk(3, 1, "Paket Burger Combo", "Double Smash Burger, Kentang, dan Caramel Coffee", 54000D, "burger_beef.jpg", True, False, Nothing)
            TambahSeedProduk(4, 1, "Paket Keluarga 4 Orang", "4 Ayam Crispy, 4 Nasi, 2 Kentang Large, 4 Teh", 145000D, "paket_combo.jpg", True, False, Nothing)

            TambahSeedProduk(5, 2, "Ayam Crispy Golden (2 Pcs)", "Ayam goreng renyah bumbu rempah hangat khas bistro", 34000D, "ayam_crispy.jpg", True, True, Nothing)
            TambahSeedProduk(6, 2, "Ayam Terakota Pedas (2 Pcs)", "Ayam crispy berbalut saus cabai terakota dan wijen", 37000D, "ayam_pedas.jpg", True, True, 18)
            TambahSeedProduk(7, 2, "Spicy Honey Wings (4 Pcs)", "Sayap ayam renyah saus madu pedas level pilihan", 32000D, "ayam_pedas.jpg", True, False, 3)
            TambahSeedProduk(8, 2, "Ayam Dada Spesial (1 Pc)", "Potongan dada ayam krispi juicy ukuran besar", 21000D, "ayam_crispy.jpg", True, False, Nothing)

            TambahSeedProduk(9, 3, "Double Smash Beef Burger", "Dua lapis daging sapi panggang, cheddar leleh, roti brioche", 46000D, "burger_beef.jpg", True, True, Nothing)
            TambahSeedProduk(10, 3, "Crispy Buttermilk Chicken", "Fillet ayam renyah dengan slaw segar dan saus chipotle", 36000D, "burger_chicken.jpg", True, False, 22)
            TambahSeedProduk(11, 3, "Truffle Cheese Burger", "Burger sapi keju ganda dengan saus krim jamur panggang", 49000D, "burger_beef.jpg", False, False, 0)

            TambahSeedProduk(12, 4, "Butter Rice Chicken Katsu", "Nasi mentega hangat dengan chicken katsu dan telur", 35000D, "nasi_bowl.jpg", True, True, Nothing)
            TambahSeedProduk(13, 4, "Nasi Ayam Sambal Terakota", "Nasi pulen hangat dengan suwiran ayam krispi pedas", 31000D, "nasi_bowl.jpg", True, False, 15)
            TambahSeedProduk(14, 4, "Nasi Putih Hangat", "Nasi pulen wangi porsi pas", 9000D, "nasi_bowl.jpg", True, False, Nothing)

            TambahSeedProduk(15, 5, "Kentang Goreng Keju", "Kentang renyah berbumbu paprika dengan cocolan keju", 20000D, "kentang_fries.jpg", True, True, Nothing)
            TambahSeedProduk(16, 5, "Crispy Chicken Bites", "Potongan ayam fillet renyah sekali gigit (8 pcs)", 23000D, "ayam_crispy.jpg", True, False, 2)
            TambahSeedProduk(17, 5, "Onion Rings Gurih", "Cincin bawang bombai tepung renyah keemasan", 19000D, "kentang_fries.jpg", True, False, Nothing)

            TambahSeedProduk(18, 6, "Es Teh Lemon Madu", "Teh seduh dingin segar dengan lemon & madu murni", 14000D, "minuman_es.jpg", True, True, Nothing)
            TambahSeedProduk(19, 6, "Iced Caramel Macchiato", "Espresso arabika dengan susu segar & karamel hangat", 24000D, "kopi_caramel.jpg", True, True, Nothing)
            TambahSeedProduk(20, 6, "Lychee Mint Breeze", "Minuman leci dingin menyegarkan dengan daun mint", 18000D, "minuman_es.jpg", True, False, Nothing)
            TambahSeedProduk(21, 6, "Air Mineral Dingin", "Air mineral murni kemasan 600ml", 8000D, "minuman_es.jpg", True, False, Nothing)

            TambahSeedProduk(22, 7, "Choco Fudge Sundae", "Es krim vanilla lembut dengan saus cokelat pekat & wafel", 17000D, "dessert_sundae.jpg", True, True, Nothing)
            TambahSeedProduk(23, 7, "Caramel Crunch Sundae", "Es krim lembut topping saus karamel & remah biskuit", 19000D, "dessert_sundae.jpg", True, False, Nothing)
            TambahSeedProduk(24, 7, "Matcha Cream Parfait", "Lapisan es krim vanilla & saus matcha manis lembut", 22000D, "dessert_sundae.jpg", True, False, 10)

            ' 5. Opsi Produk
            Dim nextOpsi As Integer = 1
            For Each p In ProdukList
                ' Ukuran untuk Minuman, Side Dish, Dessert, dan Paket
                If p.IdKategori = 6 OrElse p.IdKategori = 5 OrElse p.IdKategori = 7 OrElse p.IdKategori = 1 Then
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Regular", .Tipe = TipeOpsi.Ukuran, .TambahanHarga = 0D}) : nextOpsi += 1
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Large", .Tipe = TipeOpsi.Ukuran, .TambahanHarga = 5000D}) : nextOpsi += 1
                End If
                ' Pedas untuk Ayam & Nasi & Paket
                If p.IdKategori = 2 OrElse p.IdKategori = 4 OrElse p.IdKategori = 1 Then
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Tidak Pedas (0)", .Tipe = TipeOpsi.Pedas, .TambahanHarga = 0D}) : nextOpsi += 1
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Pedas Sedang (1)", .Tipe = TipeOpsi.Pedas, .TambahanHarga = 0D}) : nextOpsi += 1
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Pedas Mantap (2)", .Tipe = TipeOpsi.Pedas, .TambahanHarga = 0D}) : nextOpsi += 1
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Ekstra Terakota (3)", .Tipe = TipeOpsi.Pedas, .TambahanHarga = 0D}) : nextOpsi += 1
                End If
                ' Addon untuk Burger, Nasi, Ayam, Side Dish
                If p.IdKategori = 3 OrElse p.IdKategori = 4 OrElse p.IdKategori = 2 OrElse p.IdKategori = 5 Then
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Ekstra Keju Cheddar", .Tipe = TipeOpsi.Addon, .TambahanHarga = 3000D}) : nextOpsi += 1
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Saus Chipotle Bistro", .Tipe = TipeOpsi.Addon, .TambahanHarga = 2000D}) : nextOpsi += 1
                End If
                If p.IdKategori = 3 OrElse p.IdKategori = 4 Then
                    OpsiList.Add(New OpsiProduk With {.IdOpsi = nextOpsi, .IdProduk = p.IdProduk, .NamaOpsi = "Telur Mata Sapi", .Tipe = TipeOpsi.Addon, .TambahanHarga = 4000D}) : nextOpsi += 1
                End If
            Next
            NextOpsiId = nextOpsi

            ' 6. Banner Promo
            BannerList.AddRange({
                New BannerPromo With {.IdBanner = 1, .Judul = "Paket Hemat Bistro Mulai Rp42.000", .Subjudul = "Ayam renyah, nasi hangat & minuman segar lebih hemat 20%", .Gambar = "banner_hemat.jpg", .Urutan = 1, .Aktif = True},
                New BannerPromo With {.IdBanner = 2, .Judul = "Crispy Chicken Saus Terakota", .Subjudul = "Pilih level pedas favoritmu hingga level 3", .Gambar = "banner_crispy.jpg", .Urutan = 2, .Aktif = True},
                New BannerPromo With {.IdBanner = 3, .Judul = "Diskon Voucher HEMAT10 & Poin Member", .Subjudul = "Gunakan kode HEMAT10 di keranjang untuk potongan 10%", .Gambar = "banner_member.jpg", .Urutan = 3, .Aktif = True}
            })

            ' 7. Voucher
            Dim today As DateTime = DateTime.Today
            VoucherList.AddRange({
                New Voucher With {.Kode = "HEMAT10", .Jenis = JenisVoucher.Persen, .Nilai = 10D, .MinBelanja = 50000D, .TglMulai = today.AddDays(-7), .TglAkhir = today.AddDays(60), .Aktif = True},
                New Voucher With {.Kode = "POTONG5K", .Jenis = JenisVoucher.Nominal, .Nilai = 5000D, .MinBelanja = 30000D, .TglMulai = today.AddDays(-7), .TglAkhir = today.AddDays(60), .Aktif = True},
                New Voucher With {.Kode = "EXPIRED2025", .Jenis = JenisVoucher.Persen, .Nilai = 20D, .MinBelanja = 40000D, .TglMulai = New DateTime(2025, 1, 1), .TglAkhir = New DateTime(2025, 12, 31), .Aktif = True}
            })

            ' 8. Member
            MemberList.AddRange({
                New Member With {.IdMember = 1, .NoHp = "081234567890", .Nama = "Alya Maharani", .Poin = 250},
                New Member With {.IdMember = 2, .NoHp = "081298765432", .Nama = "Dimas Wijaya", .Poin = 120},
                New Member With {.IdMember = 3, .NoHp = "085611223344", .Nama = "Siti Rahma", .Poin = 480},
                New Member With {.IdMember = 4, .NoHp = "081234567891", .Nama = "Budi Santoso", .Poin = 450},
                New Member With {.IdMember = 5, .NoHp = "081234567892", .Nama = "Citra Dewi", .Poin = 820},
                New Member With {.IdMember = 6, .NoHp = "081234567893", .Nama = "Dian Purnomo", .Poin = 150},
                New Member With {.IdMember = 7, .NoHp = "081234567894", .Nama = "Eko Prasetyo", .Poin = 1200},
                New Member With {.IdMember = 8, .NoHp = "081234567895", .Nama = "Fitri Handayani", .Poin = 320},
                New Member With {.IdMember = 9, .NoHp = "081234567896", .Nama = "Galih Nugroho", .Poin = 680},
                New Member With {.IdMember = 10, .NoHp = "081234567897", .Nama = "Hana Lestari", .Poin = 90},
                New Member With {.IdMember = 11, .NoHp = "081234567898", .Nama = "Irwan Setiawan", .Poin = 1450},
                New Member With {.IdMember = 12, .NoHp = "081234567899", .Nama = "Julia Rahayu", .Poin = 275},
                New Member With {.IdMember = 13, .NoHp = "081234567900", .Nama = "Kevin Wijaya", .Poin = 540},
                New Member With {.IdMember = 14, .NoHp = "081234567901", .Nama = "Linda Kusuma", .Poin = 980},
                New Member With {.IdMember = 15, .NoHp = "081234567902", .Nama = "Muhammad Fauzi", .Poin = 120},
                New Member With {.IdMember = 16, .NoHp = "081234567903", .Nama = "Nita Anggraeni", .Poin = 760},
                New Member With {.IdMember = 17, .NoHp = "081234567904", .Nama = "Oscar Haryanto", .Poin = 430},
                New Member With {.IdMember = 18, .NoHp = "081234567905", .Nama = "Putri Maharani", .Poin = 1100},
                New Member With {.IdMember = 19, .NoHp = "081234567906", .Nama = "Rizky Dermawan", .Poin = 55},
                New Member With {.IdMember = 20, .NoHp = "081234567907", .Nama = "Sari Wulandari", .Poin = 890}
            })

            ' 9. Pesanan awal hari ini + histori 30 hari terakhir (agar Kasir, Dapur, Antrian, Dashboard, Laporan langsung hidup)
            SeedOrders()

            ' 10. Log aktivitas awal
            TambahLogInternal(DateTime.Now.AddMinutes(-95), 1, "Raka Pratama", KodeAksi.Login, "Admin masuk ke Mode Staff MDI")
            TambahLogInternal(DateTime.Now.AddMinutes(-60), 2, "Nadia Putri", KodeAksi.Login, "Kasir masuk bertugas shift pagi")
            TambahLogInternal(DateTime.Now.AddMinutes(-35), 2, "Nadia Putri", KodeAksi.BayarTunai, "Konfirmasi pembayaran tunai antrian #003 (Rp88.800)")
            TambahLogInternal(DateTime.Now.AddMinutes(-20), 2, "Nadia Putri", KodeAksi.StatusUbah, "Pesanan #003 ditandai Siap diambil")
            TambahLogInternal(DateTime.Now.AddMinutes(-15), 1, "Raka Pratama", KodeAksi.ProdukUbah, "Perbarui stok Spicy Honey Wings menjadi 3")
        End Sub

        Private Sub TambahSeedProduk(id As Integer, idKat As Integer, nama As String, desk As String, harga As Decimal, gambar As String, tersedia As Boolean, bestSeller As Boolean, stok As Integer?)
            Dim kat = KategoriList.FirstOrDefault(Function(k) k.IdKategori = idKat)
            ProdukList.Add(New Produk With {
                .IdProduk = id,
                .IdKategori = idKat,
                .NamaKategori = If(kat IsNot Nothing, kat.Nama, ""),
                .Nama = nama,
                .Deskripsi = desk,
                .Harga = harga,
                .Gambar = gambar,
                .Tersedia = tersedia,
                .BestSeller = bestSeller,
                .Stok = stok,
                .DibuatPada = DateTime.Now.AddDays(-10)
            })
        End Sub

        Private Sub SeedOrders()
            Dim now As DateTime = DateTime.Now

            ' Pesanan hari ini #1: Selesai (QRIS)
            TambahSeedOrder(1, Model.TipeMakan.DineIn, now.AddMinutes(-75), MetodeBayar.Qris, StatusBayar.Lunas, StatusPesanan.Selesai, 2, Nothing, Nothing,
                            now.AddMinutes(-74), now.AddMinutes(-67),
                            {(1, 2, "Large, Pedas Sedang (1)"), (18, 1, "Large")})

            ' Pesanan hari ini #2: Dibatalkan
            TambahSeedOrder(2, Model.TipeMakan.TakeAway, now.AddMinutes(-65), MetodeBayar.Tunai, StatusBayar.Belum, StatusPesanan.Dibatalkan, Nothing, Nothing, Nothing,
                            Nothing, Nothing,
                            {(10, 1, "Ekstra Keju Cheddar")})

            ' Pesanan hari ini #3: Siap (Lunas)
            TambahSeedOrder(3, Model.TipeMakan.DineIn, now.AddMinutes(-38), MetodeBayar.Tunai, StatusBayar.Lunas, StatusPesanan.Siap, 2, 100000D, 11200D,
                            now.AddMinutes(-35), now.AddMinutes(-20),
                            {(9, 1, "Ekstra Keju Cheddar"), (15, 1, "Large"), (19, 1, "Regular")})

            ' Pesanan hari ini #4: Siap (QRIS)
            TambahSeedOrder(4, Model.TipeMakan.TakeAway, now.AddMinutes(-28), MetodeBayar.Qris, StatusBayar.Lunas, StatusPesanan.Siap, Nothing, Nothing, Nothing,
                            now.AddMinutes(-28), now.AddMinutes(-12),
                            {(6, 2, "Pedas Mantap (2)"), (18, 2, "Regular")})

            ' Pesanan hari ini #5: Diproses (TERLAMBAT > 10 menit untuk demo sorotan merah Dapur!)
            TambahSeedOrder(5, Model.TipeMakan.DineIn, now.AddMinutes(-14), MetodeBayar.Kartu, StatusBayar.Lunas, StatusPesanan.Diproses, Nothing, Nothing, Nothing,
                            now.AddMinutes(-13), Nothing,
                            {(2, 1, "Pedas Mantap (2)"), (22, 2, "Regular")})

            ' Pesanan hari ini #6: Diproses (Baru masuk 3 menit)
            TambahSeedOrder(6, Model.TipeMakan.TakeAway, now.AddMinutes(-3), MetodeBayar.EWallet, StatusBayar.Lunas, StatusPesanan.Diproses, Nothing, Nothing, Nothing,
                            now.AddMinutes(-3), Nothing,
                            {(12, 1, "Telur Mata Sapi, Pedas Sedang (1)"), (19, 1, "Large")})

            ' Pesanan hari ini #7: Menunggu Pembayaran (Tunai)
            TambahSeedOrder(7, Model.TipeMakan.DineIn, now.AddMinutes(-2), MetodeBayar.Tunai, StatusBayar.Belum, StatusPesanan.MenungguPembayaran, Nothing, Nothing, Nothing,
                            Nothing, Nothing,
                            {(1, 1, "Regular, Pedas Sedang (1)"), (9, 1, "Ekstra Keju Cheddar"), (18, 1, "Large")})

            ' Pesanan hari ini #8: Menunggu Pembayaran (Tunai)
            TambahSeedOrder(8, Model.TipeMakan.TakeAway, now.AddMinutes(-1), MetodeBayar.Tunai, StatusBayar.Belum, StatusPesanan.MenungguPembayaran, Nothing, Nothing, Nothing,
                            Nothing, Nothing,
                            {(5, 2, "Tidak Pedas (0)"), (15, 1, "Regular")})

            ' Data historis 30 hari sebelumnya (untuk GrafikBatang & Laporan Array 2D agar tampak realistis)
            Dim seedItems As (Integer, Integer, String)()() = {
                New(Integer, Integer, String)() {(1, 2, "Regular"), (18, 2, "Large")},
                New(Integer, Integer, String)() {(9, 2, "Ekstra Keju Cheddar"), (15, 2, "Large")},
                New(Integer, Integer, String)() {(6, 3, "Pedas Mantap (2)"), (12, 1, "Telur Mata Sapi"), (19, 2, "Regular")},
                New(Integer, Integer, String)() {(2, 1, "Pedas Sedang (1)"), (22, 3, "Regular")},
                New(Integer, Integer, String)() {(4, 1, "Regular"), (19, 2, "Large"), (23, 2, "Regular")},
                New(Integer, Integer, String)() {(5, 3, "Regular"), (10, 2, "Saus Chipotle Bistro"), (18, 3, "Large")}
            }

            Dim metodeVariasi As String() = {MetodeBayar.Qris, MetodeBayar.Tunai, MetodeBayar.Kartu, MetodeBayar.EWallet}
            Dim komentarRating As String() = {
                "Makanannya enak banget, pelayanan ramah!",
                "Ayam gepreknya mantap, akan order lagi.",
                "Porsi besar, harga terjangkau.",
                "Recommended buat yang suka pedas.",
                "Burger-nya juara, kentang gurih.",
                "Top! Fast service."
            }

            For d As Integer = 30 To 1 Step -1
                Dim tglBase As DateTime = DateTime.Today.AddDays(-d)
                Dim jumlahOrder As Integer = 5 + (d Mod 4)
                For o As Integer = 1 To jumlahOrder
                    Dim jam As Integer = 10 + ((o * 2) Mod 11)
                    Dim tgl As DateTime = tglBase.AddHours(jam).AddMinutes((o * 7) Mod 55)
                    Dim idx As Integer = (d + o) Mod seedItems.Length
                    Dim metode As String = metodeVariasi((d + o) Mod metodeVariasi.Length)
                    Dim isBatal As Boolean = ((d + o) Mod 19 = 0)
                    Dim stBayar As String = If(isBatal, StatusBayar.Belum, StatusBayar.Lunas)
                    Dim stPesanan As String = If(isBatal, StatusPesanan.Dibatalkan, StatusPesanan.Selesai)

                    TambahSeedOrder(o, If(o Mod 2 = 0, Model.TipeMakan.TakeAway, Model.TipeMakan.DineIn), tgl,
                                    metode, stBayar, stPesanan, If(o Mod 2 = 0, 2, 3), Nothing, Nothing,
                                    If(isBatal, CType(Nothing, DateTime?), tgl.AddMinutes(1)),
                                    If(isBatal, CType(Nothing, DateTime?), tgl.AddMinutes(8 + (o Mod 6))),
                                    seedItems(idx))

                    If Not isBatal AndAlso ((d + o) Mod 3 <> 0) Then
                        Dim idBaru As Integer = NextPesananId - 1
                        Dim bintang As Integer = If((d + o) Mod 7 = 0, 4, 5)
                        RatingList.Add(New RatingPesananData With {
                            .IdPesanan = idBaru,
                            .Bintang = bintang,
                            .Komentar = komentarRating((d + o) Mod komentarRating.Length)
                        })
                    End If
                Next
            Next
        End Sub

        Private Sub TambahSeedOrder(noAntrian As Integer, tipe As String, tanggal As DateTime, metode As String,
                                    statusBayar As String, statusPesanan As String, idKasir As Integer?,
                                    uangBayar As Decimal?, kembalian As Decimal?,
                                    wDiproses As DateTime?, wSiap As DateTime?,
                                    items As (IdProduk As Integer, Qty As Integer, Opsi As String)())
            Dim idPes As Integer = NextPesananId
            NextPesananId += 1

            Dim subtotal As Decimal = 0D
            Dim details As New List(Of DetailPesananData)()
            For Each it In items
                Dim p = ProdukList.First(Function(x) x.IdProduk = it.IdProduk)
                Dim subItem As Decimal = p.Harga * it.Qty
                subtotal += subItem
                details.Add(New DetailPesananData With {
                    .IdDetail = NextDetailId,
                    .IdPesanan = idPes,
                    .IdProduk = p.IdProduk,
                    .NamaProduk = p.Nama,
                    .Qty = it.Qty,
                    .HargaSatuan = p.Harga,
                    .OpsiDipilih = it.Opsi,
                    .Catatan = "",
                    .Subtotal = subItem
                })
                NextDetailId += 1
            Next

            Dim diskon As Decimal = If(subtotal >= 100000D, Math.Round(subtotal * 0.05D, 0, MidpointRounding.AwayFromZero), 0D)
            Dim dasarPajak As Decimal = subtotal - diskon
            Dim pajak As Decimal = Math.Round(dasarPajak * 0.11D, 0, MidpointRounding.AwayFromZero)
            Dim total As Decimal = dasarPajak + pajak

            PesananList.Add(New PesananData With {
                .IdPesanan = idPes,
                .NoAntrian = noAntrian,
                .TipeMakan = tipe,
                .Tanggal = tanggal,
                .Subtotal = subtotal,
                .Diskon = diskon,
                .Pajak = pajak,
                .Total = total,
                .MetodeBayar = metode,
                .StatusBayar = statusBayar,
                .StatusPesanan = statusPesanan,
                .IdKasir = idKasir,
                .UangBayar = uangBayar,
                .Kembalian = kembalian,
                .WaktuDiproses = wDiproses,
                .WaktuSiap = wSiap
            })
            DetailList.AddRange(details)
        End Sub

        Public Sub TambahLogInternal(waktu As DateTime, idPengguna As Integer?, namaPengguna As String, aksi As String, keterangan As String)
            LogList.Add(New LogAktivitasData With {
                .IdLog = NextLogId,
                .Waktu = waktu,
                .IdPengguna = idPengguna,
                .NamaPengguna = If(String.IsNullOrWhiteSpace(namaPengguna), "Sistem / Kiosk", namaPengguna),
                .Aksi = aksi,
                .Keterangan = keterangan
            })
            NextLogId += 1
        End Sub

    End Module
End Namespace
