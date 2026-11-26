# Modul A2 — Kiosk Pelanggan (`FrmWelcome`, `FrmMenu`, `FrmDetailProduk`, `FrmIdle`, `FrmRating`)

## Alur Pelanggan
1. **FrmWelcome (`Forms\Kiosk\FrmWelcome.vb`)**
   - Memuat banner promosi aktif langsung dari tabel `public.banner_promo` melalui `ModProduk.AmbilBannerAktif()` dengan fallback gambar dari bucket Supabase Storage `kiosk-assets/banner/*`.
   - Menyediakan pilihan bahasa (`ID` / `EN`), toggle layar penuh (`F11`), akses Demo Hub (`F9`), dan akses Login Staff (`Ctrl+Alt+F12` atau klik logo 5x).
   - Pelanggan memilih **Dine In** atau **Take Away** yang mereset keranjang dan membuka `FrmMenu`.

2. **FrmMenu (`Forms\Kiosk\FrmMenu.vb`)**
   - Menampilkan kategori dari `public.kategori` (`ModProduk.AmbilKategori()`) dan grid kartu produk (`ProdukCard`) dari `public.produk` (`ModProduk.AmbilProduk()`).
   - Mendukung pencarian kata kunci, filter kategori, dan status stok (`stok = 0` / `tersedia = false`).
   - Memicu timer idle (`ModIdle`) yang membuka `FrmIdle` saat tidak ada aktivitas.

3. **FrmDetailProduk (`Forms\Kiosk\FrmDetailProduk.vb`)**
   - Memuat opsi produk dinamis dari `public.opsi_produk` (`ModProduk.AmbilOpsi(idProduk)`) yang dikelompokkan berdasarkan tipe (`Ukuran`, `Addon`, `Pedas`).
   - Menghitung harga satuan + tambahan opsi x kuantitas secara langsung sebelum ditambahkan ke `ModKeranjang`.

4. **Kontrak Pembayaran Tunai vs Non-Tunai & Poin Member**
   - **Non-Tunai (QRIS, Kartu, E-Wallet)**: status langsung `Lunas` + `Diproses` saat pesanan dibuat (`ModPesanan.SimpanPesanan`), stok dikurangi atomik dengan `pg_advisory_xact_lock` & `FOR UPDATE`, dan poin member langsung ditambahkan.
   - **Tunai (Bayar di Kasir)**: status awal `Belum` + `Menunggu Pembayaran`. Poin member **baru diberikan** setelah kasir mengonfirmasi pembayaran tunai pada `FrmKasir` (`ModAntrian.KonfirmasiTunai`).

5. **FrmRating (`Forms\Kiosk\FrmRating.vb`)**
   - Pelanggan dapat memberi rating 1–5 bintang dan komentar yang disimpan ke `public.rating_pesanan` (`ModPesanan.SimpanRating`).

