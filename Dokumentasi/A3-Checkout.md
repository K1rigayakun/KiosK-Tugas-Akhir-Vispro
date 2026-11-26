# Modul A3 — Checkout, Pembayaran & Struk (`FrmKeranjang`, `FrmPembayaran`, `FrmStruk`)

## Komponen Utama
1. **FrmKeranjang (`Forms\Checkout\FrmKeranjang.vb`)**
   - Menampilkan daftar item pada `ModKeranjang`, pengubah qty (+/-) dan hapus item.
   - Integrasi Member (`ModMember.Cari`): mencari member berdasarkan nomor HP di `public.member` dan menukar poin menjadi potongan harga (`ModPromo.HitungRincian`).
   - Validasi Voucher (`ModPromo.CekVoucher`): verifikasi kode promo terhadap tabel `public.voucher` (status `aktif`, rentang `tgl_mulai` s/d `tgl_akhir`, dan `min_belanja`).
   - Diskon gabungan (Bertingkat + Voucher + Poin) dibatasi maksimal 50% dari subtotal sebelum PPN 11%.
   - **Upsell Dinamis**: memeriksa item berdasarkan nama kategori (`Side Dish` / `Minuman`) dan menawarkan rekomendasi produk aktif dari database sebelum masuk pembayaran.
   - Panel kanan menggunakan area gulir (`pnlScrollKanan` + `pnlAksiKanan` docked bottom) agar tombol aksi tetap terlihat pada resolusi kompak (`1060x680`).

2. **FrmPembayaran (`Forms\Checkout\FrmPembayaran.vb`)**
   - Mendukung metode **QRIS** (QR dinamis via QRCoder + hitung mundur 2 menit), **Tunai** (saran nominal cerdas dari `ModPesanan.SaranUangBayar` + rincian pecahan kembalian `ModPesanan.PecahKembalian`), serta **Kartu / E-Wallet**.
   - Menyimpan pesanan secara atomik via `ModPesanan.SimpanPesananLive` (lock antrian harian + validasi stok & voucher `FOR UPDATE` + pengurangan stok & poin).

3. **FrmStruk (`Forms\Checkout\FrmStruk.vb`)**
   - Menampilkan nomor antrian besar, QR verifikasi pesanan, rincian item dari `ModAntrian.AmbilDetail`, total & kembalian.
   - Mendukung simpan struk ke `.txt` dan cetak langsung (`PrintDocument`).

