# Modul A5 — Manajemen Admin & Operasional (`FrmDashboard`, `FrmProduk`, `FrmVoucher`, `FrmMember`, `FrmLaporan`, `FrmKasir`, `FrmDapur`)

## Fitur Terintegrasi Supabase
1. **FrmDashboard (`Forms\Admin\FrmDashboard.vb`)**
   - Memuat 5 kartu KPI (Pendapatan Hari Ini, Jumlah Pesanan, Rata-Rata Order, Pesanan Dibatalkan, Stok Menipis), grafik omzet 7 hari (`GrafikBatang`), dan Top 5 Menu Terlaris secara paralel menggunakan `Task.WhenAll` (`ModLaporan`).
   - Ukuran ikon KPI (`34x34`) dan ukuran font angka menyesuaikan otomatis terhadap lebar kartu pada jendela sempit.

2. **FrmProduk (`Forms\Admin\FrmProduk.vb`)**
   - **Tab Produk**: CRUD lengkap ke `public.produk` (termasuk pencarian, filter kategori, peringatan stok menipis, konversi gambar ke JPEG standar `640x480` via `ModProduk.KonversiDanSimpanGambarProduk`, dan pencegahan hapus permanen jika sudah pernah dipesan dengan opsi nonaktifkan).
   - **Tab Kategori**: CRUD ke `public.kategori` dengan pengecekan FK (`23503`).
   - **Tab Opsi Produk**: Tambah & hapus variasi harga pada `public.opsi_produk` dengan proteksi indeks unik `ux_opsi_produk_unik`.

3. **FrmVoucher (`Forms\Admin\FrmVoucher.vb`)**
   - CRUD voucher promo (`Persen` / `Nominal`, `min_belanja`, `tgl_mulai`, `tgl_akhir`, `aktif`) langsung ke `public.voucher` serta pembersihan cache promo.

4. **FrmMember (`Forms\Admin\FrmMember.vb`)**
   - Pencarian, pendaftaran/pembaruan member (`ModMember.Daftar`, `ModMember.Ubah`), dan penyesuaian saldo poin manual dengan catatan audit wajib (`ModMember.AturSaldoPoin`).

5. **FrmLaporan (`Forms\Admin\FrmLaporan.vb`)**
   - Riwayat transaksi rentang tanggal, matriks Array 2D Kategori x Hari (`ModLaporan.AmbilRekapKategoriHari`), Top 10 Menu Terlaris, serta ekspor CSV UTF-8 dengan sanitasi **CSV Formula Injection** (`=`, `+`, `-`, `@`, `Tab`, `CR`).

6. **Keamanan & Akses**
   - Autentikasi `FrmLogin` memakai RPC server-side `fn_ambil_kredensial_login` (lockout 5x gagal -> kunci 300 detik) + PBKDF2 (`BuatPassword`).
   - RLS aktif pada seluruh tabel publik & Storage bucket `kiosk-assets`, serta dukungan enkripsi `ConnectionStrings:Default` AES-256-GCM melalui `ModKeamananConfig`.

