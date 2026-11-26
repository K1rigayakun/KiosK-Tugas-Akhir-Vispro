-- Seed Data Awal - Kiosk Pemesanan Makanan (Warm Modern Bistro)

insert into kategori (nama, urutan) values
  ('Paket Hemat', 1),
  ('Ayam', 2),
  ('Burger', 3),
  ('Nasi', 4),
  ('Side Dish', 5),
  ('Minuman', 6),
  ('Dessert', 7)
on conflict (nama) do nothing;

insert into pengaturan (kunci, nilai) values
  ('nama_toko', 'Bistro Kiosk Nusantara'),
  ('pajak_persen', '11'),
  ('idle_detik', '60'),
  ('ambang_stok', '5'),
  ('ambang_tunggu_menit', '10'),
  ('poin_per_rupiah', '10000'),
  ('nilai_poin', '100'),
  ('bahasa_default', 'ID')
on conflict (kunci) do nothing;

insert into voucher (kode, jenis, nilai, min_belanja, tgl_mulai, tgl_akhir, aktif) values
  ('HEMAT10', 'Persen', 10, 50000, current_date - interval '7 days', current_date + interval '60 days', true),
  ('POTONG5K', 'Nominal', 5000, 30000, current_date - interval '7 days', current_date + interval '60 days', true),
  ('EXPIRED2025', 'Persen', 20, 40000, '2025-01-01', '2025-12-31', true)
on conflict (kode) do nothing;

insert into member (no_hp, nama, poin) values
  ('081234567890', 'Alya Maharani', 250),
  ('081298765432', 'Dimas Wijaya', 120),
  ('085611223344', 'Siti Rahma', 480)
on conflict (no_hp) do nothing;

insert into banner_promo (judul, gambar, urutan, aktif) values
  ('Paket Hemat Bistro Spesial', 'banner_hemat.jpg', 1, true),
  ('Crispy Chicken Sambal Terakota', 'banner_crispy.jpg', 2, true),
  ('Double Poin Member Setiap Hari', 'banner_member.jpg', 3, true);

