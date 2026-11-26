# Bistro Kiosk Nusantara — Kiosk & POS Restoran (VB.NET WinForms)

Aplikasi desktop self-service kiosk, kasir, dapur, layar antrian, dan administrasi restoran berbasis **VB.NET WinForms (.NET 10)** dengan dukungan dual-mode: **Supabase PostgreSQL (Live)** dan **ModDummyStore (Offline Fallback)**.

---

## Fitur Utama

- **Kiosk Pelanggan (`Forms\Kiosk\`)**: Layar selamat datang dengan banner promo (`FrmWelcome`), katalog menu & pencarian kategori (`FrmMenu`), kustomisasi opsi produk (`FrmDetailProduk`), layar idle promosi (`FrmIdle`), dan rating pesanan (`FrmRating`).
- **Checkout & Struk (`Forms\Checkout\`)**: Keranjang belanja dengan upsell dinamis berdasarkan nama kategori, penukaran poin member & validasi voucher promo (`FrmKeranjang`), pembayaran QRIS / Tunai / Kartu / E-Wallet dengan pemecah kembalian (`FrmPembayaran`), serta pratinjau/cetak struk & QR verifikasi (`FrmStruk`).
- **Operasional Kasir & Dapur (`Forms\Kasir\`)**: Konfirmasi pembayaran tunai & pembatalan atomik (`FrmKasir`), pemantauan antrian dapur dengan toast & statistik per jam (`FrmDapur`), layar antrian publik 2 kolom (`FrmAntrian`), dan riwayat log aktivitas (`FrmLog`).
- **Panel Admin (`Forms\Admin\` & `Forms\Umum\`)**: Dashboard KPI paralel & grafik omzet 7 hari (`FrmDashboard`), CRUD produk/kategori/opsi dengan standardisasi gambar JPEG (`FrmProduk`), manajemen voucher (`FrmVoucher`), manajemen member & saldo poin (`FrmMember`), laporan + ekspor CSV aman dari formula injection (`FrmLaporan`), manajemen akun pengguna (`FrmPengguna`), dan pengaturan toko (`FrmPengaturan`).
- **Keamanan**: Hash kata sandi PBKDF2 (`BuatPassword`), perlindungan lockout login lewat RPC Supabase, koneksi `SslMode.Require`, sanitasi pesan error database (`ModDatabase.PesanKesalahanAman`), RLS aktif di seluruh tabel publik, serta enkripsi connection string AES-256-GCM opsional (`ModKeamananConfig`).

---

## Prasyarat

- **.NET SDK 10.0** (`net10.0-windows`) pada Windows.
- NuGet packages (otomatis dipulihkan oleh `dotnet build`):
  - `FontAwesome.Sharp` `6.6.0`
  - `Guna.UI2.WinForms` `2.0.5.1`
  - `Microsoft.Extensions.Configuration.Json` `10.0.12`
  - `Npgsql` `10.0.3`
  - `QRCoder` `1.9.0`
  - `WinFormAnimation` `1.6.0.4`

---

## Konfigurasi Database (Supabase)

1. Salin `appsettings.example.json` menjadi `appsettings.json` (file `appsettings.json` sudah dikecualikan di `.gitignore`).
2. Isi `ConnectionStrings:Default` dengan kredensial PostgreSQL Supabase Anda (`SSL Mode=Require`).
3. Jalankan skrip SQL di folder `Database\`:
   - `Database\skema.sql` — skema tabel inti dan pengaktifan RLS.
   - `Database\seed.sql` — data awal produk, kategori, dan pengaturan (jika diperlukan).
   - `Database\02d_fix_duplicate_rls_policies.sql` — membatasi policy `pol_*_baca` ke role `anon` agar tidak terjadi policy `SELECT` duplikat untuk `authenticated`.
4. *(Opsional)* Enkripsi `ConnectionStrings:Default` menjadi format `ENCv1$...` menggunakan AES-256-GCM:
   ```powershell
   # Opsional: set kunci kustom melalui environment variable BISTRO_CONFIG_KEY
   dotnet run -- --encrypt-config appsettings.json
   ```

Jika `appsettings.json` belum diisi atau koneksi database tidak terjangkau, aplikasi otomatis berjalan dalam **Mode Dummy** menggunakan `ModDummyStore`.

---

## Menjalankan & Memverifikasi Proyek

```powershell
# Build proyek (Option Strict On)
dotnet build VisproPrakProjectAkhir.vbproj -c Debug

# Jalankan aplikasi GUI utama
dotnet run --project VisproPrakProjectAkhir.vbproj

# Jalankan self-test logika inti (Mode Dummy)
dotnet run --no-build -- --self-test testing\self_test_report.txt

# Cek detail koneksi Supabase
dotnet run --no-build -- --test-db

# Verifikasi integrasi end-to-end Supabase (memerlukan akses port 5432)
dotnet run --no-build -- --verify-supabase

# Generate 15 tangkapan layar form ke testing\screenshoot\
dotnet run --no-build -- --capture-tour testing\screenshoot
```

Atau jalankan skrip terpadu `testing\run_verification.ps1` untuk build, `--self-test`, dan `--capture-tour` sekaligus.

### Shortcut Keyboard saat Demo
- `F11`: Toggle mode layar penuh.
- `F9`: Buka `FrmDemoHub` (navigasi cepat antar layar).
- `Ctrl+Alt+F12`: Akses cepat form login staff dari layar Kiosk.

---

## Struktur Direktori & Dokumentasi

- `Forms\` — Antarmuka WinForms (`Kiosk`, `Checkout`, `Kasir`, `Admin`, `Umum`).
- `Modul\` — Logika bisnis, koneksi Supabase, keamanan konfigurasi, tema, animasi, dan cache.
- `Controls\` — Komponen kustom (`ProdukCard`, `GrafikBatang`, `BistroIcons`, `BistroWidgets`).
- `Model\` — `Models.vb` dan `Konstanta.vb`.
- `Database\` — Skema SQL, seed, dan migrasi.
- `Dokumentasi\` — Dokumentasi terperinci per modul:
  - [`A2-Kiosk.md`](Dokumentasi/A2-Kiosk.md)
  - [`A3-Checkout.md`](Dokumentasi/A3-Checkout.md)
  - [`A4-Kasir-Dapur.md`](Dokumentasi/A4-Kasir-Dapur.md)
  - [`A5-Admin.md`](Dokumentasi/A5-Admin.md)
  - [`A6-Antrian-Rating.md`](Dokumentasi/A6-Antrian-Rating.md)
- `testing\` — Skrip verifikasi, laporan self-test, dan hasil tangkapan layar.

