# Modul A4 — Kasir, Dapur & Log Aktivitas (`FrmKasir`, `FrmDapur`, `FrmLog`)

## 1. FrmKasir (`Forms\Kasir\FrmKasir.vb`)

### Tanggung Jawab
- Menampilkan pesanan hari ini pada `dgvPesanan` menggunakan `ModAntrian.AmbilPesanan("")` dengan filter status (`cboStatus`) dan nomor antrian (`txtCariAntrian`).
- Memproses pembayaran tunai: validasi nominal (`ModValidasi.BacaAngka`), perhitungan kembalian real-time (`ModPesanan.HitungKembalian`), dan daftar pecahan uang (`ModPesanan.PecahKembalian`).
- Mengonfirmasi pembayaran tunai melalui `ModAntrian.KonfirmasiTunai(_selectedPesananId, uang)` yang dijalankan dalam transaksi atomik (`FOR UPDATE`), mencatat `ModLog.Catat(KodeAksi.BayarTunai, ...)`, lalu menawarkan cetak struk via `FrmStruk(_selectedPesananId, True)`.
- Membatalkan pesanan (`MenungguPembayaran` atau `Diproses`) melalui `ModAntrian.UbahStatus(_selectedPesananId, StatusPesanan.Dibatalkan)` yang sekaligus mengembalikan stok produk dan mencatat `ModLog.Catat(KodeAksi.PesananBatal, ...)`.
- Auto-refresh data pesanan setiap `5000 ms` melalui `_tmrRefresh` selama form terbuka.

### Alur Konfirmasi Tunai
```
Pilih pesanan (status = Menunggu Pembayaran, metode = Tunai)
  -> Masukkan nominal pada txtUangBayar
  -> HitungKembalianLive() menampilkan kembalian dan pecahan di lstPecahan
  -> Klik btnKonfirmasiTunai
  -> ModAntrian.KonfirmasiTunai(idPesanan, uangBayar) [Supabase / DummyStore]
  -> status_bayar = Lunas, status_pesanan = Diproses, poin_didapat member ditambahkan
  -> Opsional buka FrmStruk(idPesanan, True)
```

### Pewarnaan Baris Status (`OnPesananCellFormatting`)
| Status | Warna Latar Sel |
|---|---|
| `Menunggu Pembayaran` | `ModTema.WarnaPeringatanLembut` |
| `Siap` | `ModTema.WarnaSuksesLembut` |
| `Dibatalkan` | `ModTema.WarnaBahayaLembut` |

---

## 2. FrmDapur (`Forms\Kasir\FrmDapur.vb`)

### Tanggung Jawab
- Memantau pesanan hari ini berstatus `Diproses` dan `Siap` melalui `cboTampil` (`btnSiap` hanya aktif saat status `Diproses`; `btnSelesai` hanya aktif saat status `Siap`).
- Mengubah status pesanan melalui `ModAntrian.UbahStatus(idPes, statusBaru)` dan mencatat log `ModLog.Catat(KodeAksi.StatusUbah, ...)`.
- Menampilkan 3 kartu KPI (`Rata-rata`, `Selesai Hari Ini`, `Terlama`) serta grafik batang per jam (`08`–`22`) menggunakan `ModAntrian.AmbilStatistikDapur()` dan kontrol `GrafikBatang`.
- Menyediakan tombol simulasi pesanan masuk (`btnSimulasiMasuk`) yang memanggil `ModAntrian.SimulasikanPesananMasukDapur()`.
- Menampilkan notifikasi toast geser (`pnlToast` berdurasi `4500 ms` dengan `ModAnimasi.AnimateTop`) dan suara (`ModWindowsApi.Bunyi()`, dapat dimatikan lewat `btnMute`) ketika ada pesanan baru masuk berstatus `Diproses`.

### Optimasi Performa & Peringatan Antrian
- Timer `_tmrTampil` berjalan tiap `1000 ms` untuk memperbarui kolom `waktu_tunggu` secara langsung tanpa membebani database, sementara polling ke `ModAntrian.AmbilPesanan` / `AmbilStatistikDapur` dilakukan setiap `5000 ms` berbasis `ModWindowsApi.WaktuAktif()`.
- Pengecekan tanda tangan `_lastDapurSig` mencegah rebinding ulang `dgvDapur` apabila daftar `id_pesanan:status_pesanan` belum berubah.
- Baris berstatus `Diproses` yang waktu tunggunya mencapai atau melebihi pengaturan `ambang_tunggu_menit` (default `10` menit) ditandai dengan `ModTema.WarnaBahayaLembut` dan teks `ModTema.WarnaBahaya`.

---

## 3. FrmLog (`Forms\Kasir\FrmLog.vb`) & `ModLog` (`Modul\ModLog.vb`)

- `FrmLog` menampilkan maksimal `500` catatan aktivitas terbaru dari `ModLog.AmbilLog(dtpDari, dtpSampai)` (default 7 hari terakhir) dengan pencarian kata kunci pada kolom `aksi`, `keterangan`, atau `pengguna`.
- `ModLog.Catat` menyimpan catatan ke memori lokal (`ModDummyStore`) dan tabel `public.log_aktivitas` di Supabase bila database terhubung.

---

## 4. Ringkasan `ModAntrian` (`Modul\ModAntrian.vb`)

| Fungsi | Perilaku |
|---|---|
| `AmbilPesanan(status)` | Mengambil pesanan `CURRENT_DATE` (Supabase) / `DateTime.Today` (DummyStore), opsional filter status |
| `AmbilDetail(idPesanan)` | Mengambil rincian item dari `public.detail_pesanan` atau `ModDummyStore.DetailList` |
| `RingkasanItemTeks(idPesanan)` | Menggabungkan item pesanan (`qty`x `nama_produk`) dengan `STRING_AGG` di PostgreSQL |
| `UbahStatus(idPesanan, statusBaru)` | Memvalidasi transisi lewat `_transisiValid`, memperbarui `waktu_diproses` / `waktu_siap`, dan mengembalikan stok saat `Dibatalkan` |
| `KonfirmasiTunai(idPesanan, uangBayar)` | Memvalidasi pesanan tunai `MenungguPembayaran`, mengonfirmasi lunas, mencatat kasir, dan menambah poin member |
| `SimulasikanPesananMasukDapur()` | Memilih maksimal 2 produk tersedia secara dinamis dan menyisipkan pesanan simulasi QRIS berstatus `Diproses` |
| `AmbilStatistikDapur()` | Menghitung rata-rata waktu proses, jumlah selesai hari ini, pesanan terlama, serta distribusi per jam (`0`–`23`) |

### Peta Transisi Status (`_transisiValid`)
```
Menunggu Pembayaran -> Diproses | Dibatalkan
Diproses            -> Siap     | Dibatalkan
Siap                -> Selesai
```
Transisi di luar peta tersebut ditolak (`Return False`).
