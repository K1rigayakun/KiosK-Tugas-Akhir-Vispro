# Modul A6 — Layar Antrian Publik & Rating (`FrmAntrian`, `FrmRating`)

## 1. FrmAntrian (`Forms\Kasir\FrmAntrian.vb`)

### Tanggung Jawab
- Menampilkan papan antrian mandiri 2 kolom bagi pelanggan: **Sedang Disiapkan** (`flpDiproses`) dan **Siap Diambil** (`flpSiap`).
- Memuat pesanan hari ini dari `ModAntrian.AmbilPesanan(StatusPesanan.Diproses)` dan `ModAntrian.AmbilPesanan(StatusPesanan.Siap)`.
- Mendaftarkan form ke `ModNavigasi.DaftarkanHalamanPenuh(Me)` untuk dukungan mode layar penuh (`F11`) serta keluar dengan tombol `Escape`.
- Menampilkan logo restoran via `ModProduk.AmbilLogoBistro()`, nama toko dari `ModPengaturan.Ambil("nama_toko", "Bistro Kiosk Nusantara")`, dan jam digital real-time (`lblJam`).

### Pembaruan & Animasi Visual
- `_tmrRefresh` (`3000 ms`): memeriksa perubahan daftar nomor antrian memakai `SequenceEqual`; panel `FlowLayoutPanel` hanya dibangun ulang bila daftar berubah sehingga bebas flicker.
- `_tmrPulse` (`650 ms`): memperbarui jam digital dan menganimasikan warna tile yang baru masuk ke kolom **Siap** (`_siapBaruSet`) bergantian antara `ModTema.WarnaAksen` dan `ModTema.WarnaSukses` menggunakan `ModAnimasi.AnimateColor`.
- Setiap nomor antrian dirender sebagai `Guna2Panel` (`172 x 108` px, `BorderRadius = 14`, font `30pt Bold`).
- Kedua timer dihentikan pada event `FormClosing`.

---

## 2. FrmRating (`Forms\Kiosk\FrmRating.vb`)

### Tanggung Jawab
- Mengumpulkan penilaian bintang (`1`–`5`) dan komentar opsional (maksimal `300` karakter pada `txtKomentar`) untuk `idPesanan` tertentu setelah transaksi.
- Memakai kontrol `ratingStar` (`Guna2RatingStar`) yang memperbarui teks deskriptif pada `lblSkor`:
  - `1` -> `"1 / 5 - Perlu Perbaikan"`
  - `2` -> `"2 / 5 - Kurang Memuaskan"`
  - `3` -> `"3 / 5 - Cukup Baik"`
  - `4` -> `"4 / 5 - Memuaskan"`
  - `5` -> `"5 / 5 - Luar Biasa!"`
- Menyediakan tombol `btnLewati` (`DialogResult.Cancel`) dan tombol `btnKirim` (`DialogResult.OK`).

### Alur Penyimpanan (`OnKirimClick` & `ModPesanan.SimpanRating`)
```
Pelanggan memilih skor pada ratingStar & mengisi txtKomentar (opsional)
  -> Klik btnKirim
  -> Nilai bintang dibatasi ke rentang [1, 5]
  -> ModPesanan.SimpanRating(_idPesanan, bintang, txtKomentar.Text.Trim())
     - Mode Live : INSERT ... ON CONFLICT (id_pesanan) DO UPDATE ke public.rating_pesanan
     - Mode Dummy: tambah/perbarui RatingPesananData di ModDummyStore.RatingList
  -> Dialog ditutup dengan DialogResult.OK
```

### Skema Tabel (`Database\skema.sql`)
```sql
create table if not exists rating_pesanan (
  id_pesanan int primary key references pesanan(id_pesanan) on delete cascade,
  bintang int not null check (bintang between 1 and 5),
  komentar varchar(300)
);
```
