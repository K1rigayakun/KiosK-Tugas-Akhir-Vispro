-- Skema Database PostgreSQL (Supabase) - Kiosk Pemesanan Makanan
-- Sesuai Brief A1 Bagian 2.5

create table if not exists kategori (
  id_kategori serial primary key,
  nama varchar(50) not null unique,
  urutan int not null default 0
);

create table if not exists produk (
  id_produk serial primary key,
  id_kategori int not null references kategori(id_kategori),
  nama varchar(100) not null,
  deskripsi text,
  harga numeric(12,0) not null check (harga >= 0),
  gambar varchar(150),
  tersedia boolean not null default true,
  best_seller boolean not null default false,
  stok int,
  dibuat_pada timestamp not null default (now() at time zone 'Asia/Jakarta')
);

create table if not exists opsi_produk (
  id_opsi serial primary key,
  id_produk int not null references produk(id_produk) on delete cascade,
  nama_opsi varchar(50) not null,
  tipe varchar(20) not null check (tipe in ('Ukuran','Addon','Pedas')),
  tambahan_harga numeric(12,0) not null default 0
);

create table if not exists pengguna (
  id_pengguna serial primary key,
  username varchar(50) not null unique,
  password_hash text not null,
  nama varchar(100) not null,
  role varchar(20) not null check (role in ('Admin','Kasir')),
  aktif boolean not null default true
);

create table if not exists member (
  id_member serial primary key,
  no_hp varchar(20) not null unique,
  nama varchar(100) not null,
  poin int not null default 0
);

create table if not exists voucher (
  kode varchar(30) primary key,
  jenis varchar(10) not null check (jenis in ('Persen','Nominal')),
  nilai numeric(12,2) not null check (nilai > 0),
  min_belanja numeric(12,0) not null default 0,
  tgl_mulai date not null,
  tgl_akhir date not null,
  aktif boolean not null default true,
  check (tgl_akhir >= tgl_mulai)
);

create table if not exists pesanan (
  id_pesanan serial primary key,
  no_antrian int not null,
  tipe_makan varchar(20) not null,
  tanggal timestamp not null default (now() at time zone 'Asia/Jakarta'),
  subtotal numeric(12,0) not null,
  diskon numeric(12,0) not null default 0,
  pajak numeric(12,0) not null default 0,
  total numeric(12,0) not null,
  metode_bayar varchar(20) not null,
  status_bayar varchar(10) not null default 'Belum',
  status_pesanan varchar(30) not null default 'Menunggu Pembayaran',
  id_kasir int references pengguna(id_pengguna),
  kode_voucher varchar(30) references voucher(kode),
  id_member int references member(id_member),
  poin_dipakai int not null default 0,
  poin_didapat int not null default 0,
  uang_bayar numeric(12,0),
  kembalian numeric(12,0),
  waktu_diproses timestamp,
  waktu_siap timestamp
);

create unique index if not exists ux_pesanan_antrian_harian on pesanan ((tanggal::date), no_antrian);
create index if not exists ix_pesanan_status on pesanan (status_pesanan, tanggal);

create table if not exists detail_pesanan (
  id_detail serial primary key,
  id_pesanan int not null references pesanan(id_pesanan) on delete cascade,
  id_produk int not null references produk(id_produk),
  nama_produk varchar(100) not null,
  qty int not null check (qty > 0),
  harga_satuan numeric(12,0) not null,
  opsi_dipilih text,
  catatan varchar(200),
  subtotal numeric(12,0) not null
);

create table if not exists log_aktivitas (
  id_log bigserial primary key,
  waktu timestamp not null default (now() at time zone 'Asia/Jakarta'),
  id_pengguna int references pengguna(id_pengguna),
  aksi varchar(50) not null,
  keterangan text
);

create table if not exists pengaturan (
  kunci varchar(50) primary key,
  nilai text not null
);

create table if not exists rating_pesanan (
  id_pesanan int primary key references pesanan(id_pesanan) on delete cascade,
  bintang int not null check (bintang between 1 and 5),
  komentar varchar(300)
);

create table if not exists banner_promo (
  id_banner serial primary key,
  judul varchar(100) not null,
  gambar varchar(150) not null,
  urutan int not null default 0,
  aktif boolean not null default true
);

-- Aktifkan RLS tanpa policy pada setiap tabel
alter table kategori enable row level security;
alter table produk enable row level security;
alter table opsi_produk enable row level security;
alter table pengguna enable row level security;
alter table member enable row level security;
alter table voucher enable row level security;
alter table pesanan enable row level security;
alter table detail_pesanan enable row level security;
alter table log_aktivitas enable row level security;
alter table pengaturan enable row level security;
alter table rating_pesanan enable row level security;
alter table banner_promo enable row level security;

