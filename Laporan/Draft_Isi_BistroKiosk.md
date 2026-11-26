<!--
Draft isi laporan. File ini juga dibaca langsung oleh build_laporan.py, jadi ikuti markup:
# BAB n|JUDUL          judul BAB (Heading 1)
## n.n Judul           subbab (Heading 2)
### n.n.n Judul        sub-subbab (Heading 3)
1. teks                list angka (baris kosong sebelum list baru = list baru, restart)
   a. teks             list huruf (level 2)
> teks                 paragraf lanjutan di bawah item list (tanpa indent baris pertama)
![Gambar n.m Judul](path/gambar.png|lebar_cm)
Tabel: Tabel n.m Judul  lalu tabel pipa | ... |   (atau [[GANTT]] untuk Tabel 3.1)
```kode```             blok kode (tabel 1 sel abu-abu)
*miring*               istilah asing
[ISI: ...]             placeholder, otomatis highlight kuning
-->

# BAB 1|PENDAHULUAN

## 1.1 Latar Belakang

Antrean di kasir restoran cepat saji biasanya paling panjang saat jam makan siang. Pelanggan harus menunggu giliran hanya untuk menyebutkan pesanan, lalu menunggu lagi sampai makanannya siap. Kasir juga sering salah dengar karena suasana ramai, padahal satu pesanan bisa punya banyak pilihan seperti ukuran, level pedas, dan tambahan saus. Banyak mahasiswa tentu pernah mengalaminya waktu membeli makan siang di sela jadwal praktikum yang padat.

Restoran besar seperti McDonald's dan KFC sudah memakai kios pemesanan mandiri atau *self-ordering kiosk* untuk mengurangi masalah itu. Lewat kios ini pelanggan bisa memilih menu, mengatur pesanan, dan membayar sendiri tanpa harus berbicara dengan kasir. Kepuasan pelanggan terhadap kios seperti ini ternyata dipengaruhi kualitas layanan, nilai yang dirasakan, dan pengalaman memakai mesinnya (Marinakou et al., 2023). Kemauan pelanggan untuk memakai kios juga bergantung pada seberapa berguna dan seberapa mudah kios itu dipakai (Koo & Kumar, 2026).

Rumah makan kecil dan menengah belum tentu punya anggaran untuk membeli sistem kios komersial. Banyak warung dan kafe masih mencatat penjualan secara manual, sehingga laporan mudah hilang dan rawan dimanipulasi (Naya et al., 2022). Untuk pembayaran, Indonesia sudah punya QRIS sebagai standar pembayaran kode QR, tapi pemakaiannya di pedagang kecil masih terhambat infrastruktur, inklusi keuangan, dan pengetahuan digital (Rafferty & Fajar, 2022).

Kelompok kami membuat aplikasi Bistro Kiosk Nusantara untuk menjawab kebutuhan itu dalam skala praktikum. Aplikasi ini dibangun dengan Windows Forms VB.NET dan memakai basis data PostgreSQL di Supabase. Satu aplikasi punya dua mode, yaitu Mode Kiosk untuk pelanggan dan Mode Staff untuk kasir, dapur, serta admin. Dengan rancangan ini satu pesanan bisa dilacak dari kios, lalu ke kasir dan dapur, sampai masuk ke laporan penjualan.

## 1.2 Rumusan Masalah

Latar belakang di atas memunculkan beberapa pertanyaan. Masalah yang dibahas dalam proyek ini dirumuskan sebagai berikut:

1. Bagaimana merancang aplikasi kios pemesanan makanan berbasis Windows Forms VB.NET yang bisa dipakai pelanggan untuk memesan dan membayar sendiri?
2. Bagaimana menghubungkan alur pesanan dari kios ke kasir, dapur, dan layar antrian supaya status setiap pesanan selalu jelas?
3. Bagaimana menyediakan fitur pengelolaan produk, *voucher*, *member*, dan laporan penjualan untuk admin dalam aplikasi yang sama?
4. Bagaimana menerapkan materi praktikum Pemrograman Visual, terutama validasi input, *Multiple Document Interface*, dan Windows API, ke dalam satu aplikasi yang utuh?

## 1.3 Batasan Masalah

Waktu pengerjaan proyek ini terbatas. Supaya pengerjaan tetap terarah, proyek ini dibatasi pada beberapa hal berikut:

1. Aplikasi berjalan di sistem operasi Windows dan dibangun dengan VB.NET, Windows Forms, serta .NET 10 (target net10.0-windows).
2. Basis data yang dipakai adalah PostgreSQL di Supabase dengan koneksi lewat *library* Npgsql.
3. Pembayaran QRIS, kartu, dan *e-wallet* hanya berupa simulasi, sedangkan pembayaran tunai dikonfirmasi oleh kasir.
4. Pengguna Mode Staff dibagi menjadi dua peran, yaitu Admin dan Kasir.
5. Data menu, *voucher*, dan *member* yang dipakai saat pengembangan adalah data contoh, bukan data restoran sungguhan.

## 1.4 Tujuan Proyek

Setiap tujuan menjawab satu rumusan masalah. Tujuan proyek ini disusun sebagai berikut:

1. Membuat aplikasi kios pemesanan makanan berbasis Windows Forms VB.NET yang bisa dipakai pelanggan untuk memilih menu, mengatur pesanan, dan membayar sendiri.
2. Menghubungkan kios dengan kasir, dapur, dan layar antrian lewat status pesanan yang tersimpan di satu basis data.
3. Menyediakan *form* admin untuk mengelola produk, *voucher*, *member*, pengguna, dan laporan penjualan.
4. Menerapkan materi praktikum Pemrograman Visual ke dalam satu aplikasi yang bisa didemokan dari awal sampai akhir.

## 1.5 Manfaat Proyek

Proyek ini tidak cuma berguna bagi kelompok kami. Manfaat yang diharapkan untuk beberapa pihak adalah sebagai berikut:

1. Bagi penulis, proyek ini jadi latihan membangun aplikasi desktop yang dikerjakan lima orang secara paralel, lengkap dengan pembagian *form*, modul, dan aturan kerja tim.
2. Bagi pengguna, pelanggan bisa memesan tanpa antre di kasir, sedangkan staf restoran bisa memantau pesanan dan penjualan dari satu aplikasi.
3. Bagi pembaca dan pengembang lain, laporan ini bisa dijadikan contoh penerapan Windows Forms, Supabase, dan Windows API pada kasus pemesanan makanan.

# BAB 2|LANDASAN TEORI

## 2.1 Kios Pemesanan Mandiri

Bayangkan memesan ojek online, tapi di depan sebuah layar sentuh di restoran. Pelanggan memilih menu, mengatur pilihan, lalu membayar tanpa dilayani kasir. Mesin seperti ini disebut kios pemesanan mandiri atau *self-ordering kiosk*. Pelanggan bisa memilih, menyesuaikan, dan membayar makanannya sendiri lewat perangkat tersebut (Marinakou et al., 2023).

Kios yang tersedia belum tentu langsung dipakai pelanggan. Penelitian pada pelanggan restoran menunjukkan bahwa harapan terhadap kinerja kios, kemudahan pemakaian, pengaruh orang sekitar, dan rasa aman ikut menentukan niat memakai kios (Koo & Kumar, 2026). Uji kegunaan pada tiga jaringan restoran cepat saji di Taiwan juga menemukan peserta yang salah mengoperasikan antarmuka kios. Penelitinya menyarankan informasi dan petunjuk di layar dibuat lebih jelas, karena alur pemesanannya masih membingungkan (Lee et al., 2023).

Temuan itu kami pakai sebagai pegangan saat merancang Mode Kiosk. Tombol di layar dibuat besar, pilihan *dine in* dan *take away* ditaruh di layar pertama, dan setiap produk tampil sebagai kartu bergambar. Kios juga kembali ke layar awal kalau lama tidak disentuh, supaya pelanggan berikutnya tidak melihat pesanan orang sebelumnya.

## 2.2 Windows Forms dan VB.NET

Windows Forms adalah kerangka antarmuka untuk membuat aplikasi desktop di Windows. Kerangka ini menyediakan kontrol, grafik, *data binding*, dan penanganan input pengguna (Microsoft, 2025). Visual Studio menyediakan desainer visual, jadi tombol dan kotak teks cukup diseret ke *form* lalu diatur propertinya. Cara kerja aplikasinya berbasis *event*, misalnya kode baru dijalankan saat tombol diklik atau saat teks berubah.

VB.NET sudah lama dipakai untuk aplikasi kasir desktop skala kecil. Salah satu contohnya adalah aplikasi kasir Warung Chicken Geprek Sahabat yang mengolah data menu, pengguna, transaksi, dan laporan harian (Naya et al., 2022). Proyek kami memakai bahasa yang sama, tetapi menambahkan basis data daring, dua mode tampilan, dan pembagian modul per anggota tim. Pengaturan Option Strict On juga diaktifkan supaya kesalahan tipe data ketahuan saat *compile*.

### 2.2.1 Antarmuka *Multiple Document Interface*

*Multiple Document Interface* atau MDI memungkinkan satu jendela induk menampung beberapa jendela anak. Jendela induk dibuat dengan mengisi properti IsMdiContainer bernilai True, dan jendela inilah yang menampung jendela anak tempat pengguna bekerja (Microsoft, 2017). Cara ini mirip portal akademik kampus yang membuka KRS, nilai, dan jadwal di dalam satu jendela yang sama.

Mode Staff pada aplikasi kami memakai pola ini lewat FrmUtama. Setiap *form* anak diberi properti MdiParent yang menunjuk ke FrmUtama sebelum ditampilkan. Kasir, dapur, produk, laporan, dan *form* admin lain dibuka sebagai jendela anak di dalamnya. Menu Window menyediakan perintah Cascade, Tile Horizontal, dan Tile Vertical memakai method LayoutMdi.

### 2.2.2 Windows API melalui *Platform Invoke*

Beberapa kemampuan Windows tidak tersedia langsung di Windows Forms, contohnya membuat jendela selalu berada di atas jendela lain. Kemampuan itu ada di pustaka sistem seperti user32.dll dan kernel32.dll. .NET menyediakan teknologi *Platform Invoke* (P/Invoke) supaya kode terkelola bisa memanggil fungsi dari pustaka tidak terkelola tersebut (Microsoft, 2024). Fungsi yang dipanggil cukup dideklarasikan dengan atribut DllImport, lalu dipakai seperti method biasa.

Aplikasi kami memanggil empat fungsi Windows API lewat ModWindowsApi. SetWindowPos membuat kios selalu di atas, RegisterHotKey mendaftarkan tombol pintas Ctrl+Alt+F12 untuk staf, MessageBeep membunyikan notifikasi pesanan baru, dan GetTickCount64 dipakai untuk menghitung waktu diam. Deklarasi fungsinya diambil langsung dari kode proyek dan ditampilkan di bawah ini.

```
<DllImport("user32.dll", SetLastError:=True)>
Private Function SetWindowPos(hWnd As IntPtr,
    hWndInsertAfter As IntPtr, X As Integer, Y As Integer,
    cx As Integer, cy As Integer, uFlags As UInteger) As Boolean
End Function

<DllImport("user32.dll", SetLastError:=True)>
Private Function RegisterHotKey(hWnd As IntPtr, id As Integer,
    fsModifiers As UInteger, vk As UInteger) As Boolean
End Function

<DllImport("kernel32.dll")>
Private Function GetTickCount64() As ULong
End Function

Public Sub SelaluDiAtas(f As Form, aktif As Boolean)
    If f Is Nothing OrElse f.IsDisposed OrElse
       Not f.IsHandleCreated Then Return
    If Debugger.IsAttached AndAlso aktif Then Return
    Dim target = If(aktif, HWND_TOPMOST, HWND_NOTOPMOST)
    SetWindowPos(f.Handle, target, 0, 0, 0, 0,
                 SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
End Sub
```

Baris Debugger.IsAttached sengaja ditambahkan supaya kios tidak menutupi Visual Studio saat sedang *debug*. Tanpa pengecekan itu, jendela kios akan terus berada di atas dan sulit ditutup selama pengembangan.

## 2.3 Basis Data PostgreSQL di Supabase

Supabase menyediakan basis data PostgreSQL yang bisa diakses dari internet tanpa harus memasang server sendiri. Aplikasi bisa tersambung lewat koneksi langsung atau lewat *pooler* (Supabase, 2026). Koneksi langsung cocok untuk aplikasi yang berjalan terus dan jaringannya mendukung IPv6. Kalau jaringan hanya mendukung IPv4, Supabase menyarankan *shared pooler* dengan *session mode* (Supabase, 2026).

Pilihan ini penting untuk proyek kami karena anggota tim mengerjakan aplikasi dari rumah masing-masing dengan jaringan yang berbeda. *Connection string* disimpan di file appsettings.json yang tidak ikut dibagikan ke repositori. Yang dibagikan hanya appsettings.example.json berisi nilai contoh, karna kata sandi basis data tidak boleh terbuka di repositori publik.

Rancangan basis data proyek terdiri dari 12 tabel, di antaranya kategori, produk, opsi_produk, pesanan, detail_pesanan, voucher, member, dan pengguna. Semua *query* ditulis berparameter, sehingga input pengguna tidak pernah disambung langsung ke teks SQL. Parameter dikirim lewat Dictionary(Of String, Object) ke ModFunction, lalu diteruskan ke Npgsql.

## 2.4 Keamanan *Password* dengan PBKDF2

Menyimpan *password* apa adanya di basis data sangat berbahaya. Kalau data bocor, semua akun langsung bisa dipakai orang lain. Teknik *password hashing* mengubah *password* menjadi bentuk yang tidak bisa dikembalikan, supaya teks aslinya tidak ikut terbuka saat terjadi kebocoran data (Saran, 2024).

PBKDF2 adalah fungsi turunan kunci berbasis *password* yang dijelaskan dalam spesifikasi PKCS #5 versi 2.1 (Moriarty et al., 2017). Fungsi ini menggabungkan *password* dengan *salt* acak, lalu mengulang proses *hash* sebanyak jumlah iterasi tertentu. Kajian tentang skema *password hashing* menyebut PBKDF2 sebagai primitif yang sudah distandardisasi, sedangkan Bcrypt dan Scrypt juga banyak dipakai (Hatzivasilis, 2017).

Aplikasi kami memakai PBKDF2 dengan SHA-256, *salt* acak 16 byte, dan 100.000 iterasi. Hasilnya disimpan dalam satu teks berformat pbkdf2$iterasi$salt$hash. Potongan kodenya dapat dilihat di bawah ini.

```
Public Function HashPasswordPbkdf2(password As String) As String
    Dim salt(15) As Byte
    RandomNumberGenerator.Fill(salt)
    Dim iterasi As Integer = 100000
    Dim hash As Byte() = Rfc2898DeriveBytes.Pbkdf2(
        Encoding.UTF8.GetBytes(password), salt, iterasi,
        HashAlgorithmName.SHA256, 32)
    Return $"pbkdf2${iterasi}${Convert.ToBase64String(salt)}" &
           $"${Convert.ToBase64String(hash)}"
End Function
```

Saat pengguna *login*, *password* yang diketik diproses ulang dengan *salt* dan jumlah iterasi yang sama. Hasilnya dibandingkan memakai CryptographicOperations.FixedTimeEquals supaya lama perbandingan tidak membocorkan petunjuk apa pun. *Form* *login* juga mengunci tombol Masuk selama 30 detik setelah lima kali gagal berturut-turut.

## 2.5 Pembayaran QRIS

QRIS adalah standar kode QR untuk pembayaran di Indonesia. Satu kode QR bisa dibayar dari berbagai aplikasi bank dan dompet digital, seperti saat mahasiswa membayar es kopi di kantin. Penelitian pada pedagang UMKM menemukan bahwa kecocokan dengan usaha, dukungan fasilitas, kepercayaan, dan keuntungan yang dirasakan mendorong pedagang memakai QRIS (Rafferty & Fajar, 2022).

Aplikasi kami belum tersambung ke penyedia pembayaran sungguhan. QRIS di aplikasi ini dibuat sebagai simulasi di FrmPembayaran. Kode QR dibuat dengan *library* QRCoder, diberi hitung mundur dua menit, lalu pembayaran dianggap lunas saat tombol simulasi ditekan.

## 2.6 Pengujian *Black Box*

Pengujian *black box* memeriksa apakah program berjalan sesuai yang diharapkan tanpa melihat kode di dalamnya. Penguji cukup memberi input lalu mencocokkan output dengan hasil yang diharapkan. Salah satu tekniknya adalah *equivalence partitions*, yaitu mengelompokkan input di setiap halaman menjadi valid dan tidak valid (Huda et al., 2022).

Teknik ini cocok untuk aplikasi kami yang punya banyak kolom input. Contohnya kolom jumlah pesanan hanya menerima angka 1 sampai 20, dan kolom uang bayar harus lebih besar atau sama dengan total. Input di luar rentang itu masuk kelompok tidak valid dan harus ditolak dengan pesan lewat ErrorProvider.

# BAB 3|PERANCANGAN PROYEK

## 3.1 Diagram Pengerjaan Proyek

Aplikasi Bistro Kiosk Nusantara dibagi menjadi tiga lapisan. Lapisan pertama berisi *form* untuk Mode Kiosk dan Mode Staff. Lapisan kedua berisi modul VB.NET yang menyimpan logika, misalnya keranjang, perhitungan promo, dan antrian. Lapisan ketiga adalah basis data PostgreSQL di Supabase yang diakses lewat ModDatabase dan ModFunction. Hubungan ketiga lapisan tersebut digambarkan pada Gambar 3.1.

![Gambar 3.1 Arsitektur Aplikasi Bistro Kiosk Nusantara](gambar/arsitektur.png|14.5)

Pekerjaan dibagi ke lima anggota dengan prinsip satu *form* atau modul hanya punya satu pemilik. Pembagian ini membuat lima orang bisa bekerja bersamaan tanpa saling menimpa file. Titik temu antaranggota hanya ada di paket fondasi, modul keranjang, tabel pesanan, dan konstanta status. Selama basis data belum siap, setiap modul memakai data *dummy* supaya *form* tetap bisa dijalankan.

### 3.1.1 Flowchart Alur Pembuatan Proyek

Proyek dikerjakan dalam beberapa fase yang berurutan, mulai dari kerangka sampai pembekuan fitur. Fase 0 hanya dikerjakan anggota pertama untuk membuat kerangka proyek, skema basis data, dan modul *stub*. Setelah kerangka dibagikan, kelima anggota bekerja paralel dengan data *dummy*, lalu menyambungkan modulnya ke Supabase. Alur lengkapnya dapat dilihat pada Gambar 3.2.

![Gambar 3.2 Flowchart Alur Pembuatan Proyek](gambar/flowchart.png|14.5)

Uji alur lengkap menjadi titik keputusan utama dalam flowchart tersebut. Kalau masih ada kesalahan lintas modul, tim kembali ke tahap perbaikan dan menguji ulang. Kalau uji alur lulus, tim membekukan fitur lalu menyiapkan *build* .exe dan dokumentasi.

## 3.2 Jadwal Penelitian

Pengerjaan proyek dimulai pada 14 November 2026 dan ditargetkan selesai akhir November 2026. Rincian kegiatan per hari disusun dalam bentuk *Gantt chart* pada Tabel 3.1.

[[GANTT]]

Dua hari pertama, yaitu 14 dan 15 November, dipakai untuk identifikasi masalah. Minggu berikutnya diisi analisis kebutuhan, studi literatur, dan perancangan konsep. *Brief* tiap anggota, skema basis data, dan kontrak modul disepakati pada 20 November. Implementasi lalu dikerjakan paralel oleh kelima anggota mulai 23 November, disusul pengujian dan pengembangan fitur tambahan. Penyusunan laporan dikerjakan sambil jalan supaya *screenshot* dan catatan kendala tidak hilang.

Pembagian tugas mengikuti *brief* anggota yang disepakati tim. Dhea Tri Lova Simanjuntak (A1) mengerjakan fondasi, *login*, jendela MDI, pengguna, pengaturan, dan integrasi akhir. Dimas Surya Darma (A2) mengerjakan sisi pelanggan, yaitu layar awal, menu, detail produk, dan reset otomatis. Tegar Madya Shafwan (A3) memegang keranjang, pembayaran, dan struk. Michael Deryl Aaron Matthew (A4) mengerjakan kasir, dapur, layar antrian, dan log aktivitas. Olo Brilliant Simarmata (A5) mengerjakan admin produk, *voucher*, laporan, *dashboard*, dan *member*.

# BAB 4|HASIL

## 4.1 Hasil Perancangan Proyek

Hasil proyek ini adalah aplikasi desktop bernama Bistro Kiosk Nusantara. Sampai laporan ini ditulis, antarmuka dan logika utama sudah selesai dan bisa dijalankan dalam Mode Visual *Dummy*. Mode ini memakai data contoh di memori, yaitu 7 kategori, 24 produk, dan beberapa pesanan contoh. Koneksi ke Supabase sudah disiapkan lewat appsettings.json, tetapi penyambungan semua modul ke basis data asli masih berjalan. [ISI: status akhir koneksi Supabase]

Aplikasi ini terdiri dari 22 *form* dan 24 file modul. Mode Kiosk berisi layar awal, menu, detail produk, keranjang, pembayaran, struk, rating, dan peringatan diam. Mode Staff dibuka dengan Ctrl+Alt+F12 atau dengan mengklik logo lima kali, lalu pengguna harus *login* dulu. Menu yang tampil di Mode Staff menyesuaikan peran, sehingga Kasir tidak bisa membuka *form* khusus Admin.

Setiap pesanan bergerak melalui status yang sudah disepakati. Pesanan tunai dimulai dari Menunggu Pembayaran, sedangkan pesanan QRIS, kartu, dan *e-wallet* langsung masuk ke Diproses. Setelah itu dapur menandainya Siap, lalu pesanan menjadi Selesai saat diambil pelanggan. Pembatalan hanya boleh dilakukan sebelum pesanan Siap, seperti terlihat pada Gambar 4.1.

![Gambar 4.1 Alur Status Pesanan](gambar/status.png|13)

Aturan transisi itu disimpan di ModAntrian dalam bentuk Dictionary. Kuncinya adalah status saat ini, sedangkan nilainya adalah daftar status tujuan yang boleh dipilih. Kalau tujuan tidak ada di daftar, fungsi UbahStatus langsung mengembalikan False.

```
Private ReadOnly _transisiValid As _
    New Dictionary(Of String, String())(
        StringComparer.OrdinalIgnoreCase) From {
    {StatusPesanan.MenungguPembayaran,
        New String() {StatusPesanan.Diproses,
                      StatusPesanan.Dibatalkan}},
    {StatusPesanan.Diproses,
        New String() {StatusPesanan.Siap,
                      StatusPesanan.Dibatalkan}},
    {StatusPesanan.Siap, New String() {StatusPesanan.Selesai}},
    {StatusPesanan.Selesai, Array.Empty(Of String)()},
    {StatusPesanan.Dibatalkan, Array.Empty(Of String)()}
}
```

Perhitungan harga dikumpulkan di satu fungsi, yaitu ModPromo.HitungRincian. Urutannya dimulai dari diskon bertingkat, diskon *voucher*, lalu diskon poin *member*. Total diskon dibatasi paling banyak 50% subtotal, kemudian pajak dihitung dari subtotal setelah diskon. Potongan kode berikut memperlihatkan bagian diskon bertingkat dan pajak.

```
' 1. Diskon bertingkat otomatis
If r.Subtotal >= AmbangDiskon3 Then
    r.DiskonBertingkat = Math.Round(r.Subtotal * PersenDiskon3, 0,
                                    MidpointRounding.AwayFromZero)
ElseIf r.Subtotal >= AmbangDiskon2 Then
    r.DiskonBertingkat = Math.Round(r.Subtotal * PersenDiskon2, 0,
                                    MidpointRounding.AwayFromZero)
ElseIf r.Subtotal >= AmbangDiskon1 Then
    r.DiskonBertingkat = Math.Round(r.Subtotal * PersenDiskon1, 0,
                                    MidpointRounding.AwayFromZero)
End If

' 2. Diskon voucher (dari subtotal)
If Not String.IsNullOrEmpty(r.KodeVoucher) Then
    Dim hv = CekVoucher(r.KodeVoucher, r.Subtotal)
    If hv.Valid Then
        r.DiskonVoucher = hv.Diskon
    Else
        r.KodeVoucher = ""
    End If
End If

' 4. Pajak & Total
Dim dasarPajak As Decimal = Math.Max(0D,
        r.Subtotal - r.TotalDiskon)
Dim pajakPersen As Decimal =
        ModPengaturan.AmbilDesimal("pajak_persen", 11D)
r.Pajak = Math.Round(dasarPajak * (pajakPersen / 100D), 0,
                     MidpointRounding.AwayFromZero)
r.Total = dasarPajak + r.Pajak
```

Logika inti diuji dengan perintah --self-test yang menjalankan 18 pemeriksaan otomatis. Pemeriksaan ini memakai dua contoh hitungan dari *brief*, yaitu subtotal Rp250.000 dengan *voucher* HEMAT10 dan subtotal Rp90.000 dengan *voucher* POTONG5K. Ringkasan hasilnya dapat dilihat pada Tabel 4.1.

Tabel: Tabel 4.1 Hasil *Self-Test* Logika Inti
| No | Bagian yang Diuji | Hasil yang Diharapkan | Status |
| 1 | ModPromo Uji 1 (subtotal Rp250.000, HEMAT10) | Diskon bertingkat Rp25.000, diskon *voucher* Rp25.000, pajak Rp22.000, total Rp222.000 | Lulus (4 pemeriksaan) |
| 2 | ModPromo Uji 2 (subtotal Rp90.000, POTONG5K) | Diskon bertingkat Rp0, diskon *voucher* Rp5.000, pajak Rp9.350, total Rp94.350 | Lulus (4 pemeriksaan) |
| 3 | *Voucher* kedaluwarsa | Ditolak dengan pesan tanggal kedaluwarsa | Lulus |
| 4 | Pecahan kembalian Rp138.500 | Tujuh jenis pecahan uang | Lulus |
| 5 | Subtotal keranjang contoh | Rp91.000 | Lulus |
| 6 | Batal pesanan berstatus Siap | Ditolak | Lulus |
| 7 | Rekap kategori x hari | *Array* 7 x 7 | Lulus |
| 8 | Verifikasi PBKDF2 akun Admin | Cocok | Lulus |
| 9 | Animasi angka, transisi *form*, layar penuh | Berjalan sesuai harapan | Lulus (3 pemeriksaan) |
| 10 | Validasi ulang minimal belanja *voucher* | Rp40.000 ditolak, Rp60.000 diterima | Lulus |

Semua 18 pemeriksaan lulus tanpa kegagalan. Pengujian ini baru mencakup logika di modul, belum uji alur lengkap dengan basis data asli. Uji *black box* seluruh *form* dan uji alur dari kios sampai laporan masih dijadwalkan setelah semua modul tersambung ke Supabase. [ISI: hasil uji black box dan uji alur lengkap, misalnya jumlah skenario lolos]

## 4.2 Panduan Penggunaan

Bagian ini menjelaskan cara memakai aplikasi dari sisi pelanggan dan dari sisi staf. Semua tampilan diambil dari aplikasi yang berjalan dalam Mode Visual *Dummy*.

### 4.2.1 Pemesanan oleh Pelanggan

Pelanggan cukup memakai layar kios. Urutan pemesanannya adalah sebagai berikut:

1. Pilih cara makan di layar awal, yaitu Makan di Tempat atau Bawa Pulang. Layar ini juga menampilkan *banner* promo yang berganti otomatis dan tombol bahasa ID/EN, seperti pada Gambar 4.2.

![Gambar 4.2 Layar Awal Mode Kiosk](../testing/screenshoot/01_welcome.png|10)

2. Pilih produk di halaman menu. Kategori ada di sisi kiri, kolom pencarian di bagian atas, dan total belanja tampil di bagian bawah seperti pada Gambar 4.3.

![Gambar 4.3 Halaman Menu Produk](../testing/screenshoot/02_menu.png|12)

3. Atur pesanan di jendela detail produk. Pelanggan bisa memilih *add-on*, menulis catatan, dan mengubah jumlah antara 1 sampai 20, lalu menekan Tambah ke Keranjang seperti pada Gambar 4.4.

![Gambar 4.4 Jendela Detail Produk](../testing/screenshoot/03_detail_produk.png|9.5)

4. Periksa keranjang. Di halaman ini pelanggan bisa mengubah jumlah, menghapus item, memakai *voucher*, dan mencari *member* berdasarkan nomor HP. Rincian subtotal, diskon, pajak, dan total tampil di sisi kanan seperti pada Gambar 4.5.

![Gambar 4.5 Halaman Keranjang Pesanan](../testing/screenshoot/04_keranjang.png|11.5)

5. Pilih metode pembayaran. Pembayaran tunai diarahkan ke kasir, sedangkan QRIS menampilkan kode QR simulasi dengan batas waktu dua menit seperti pada Gambar 4.6.

![Gambar 4.6 Halaman Pembayaran QRIS Simulasi](../testing/screenshoot/05_pembayaran_qris.png|10)

6. Ambil nomor antrian dari struk. Struk memuat nomor antrian, daftar item, pajak, dan kode QR, lalu bisa disimpan sebagai file .txt atau dicetak seperti pada Gambar 4.7.

![Gambar 4.7 Struk dan Nomor Antrian](../testing/screenshoot/06_struk.png|6)

> Setelah menekan Selesai, pelanggan bisa memberi rating bintang satu sampai lima. Kios lalu kembali ke layar awal dan keranjang dikosongkan untuk pelanggan berikutnya.

### 4.2.2 Pengoperasian oleh Staf

Staf restoran bekerja lewat Mode Staff. Langkah pengoperasiannya adalah sebagai berikut:

1. Tekan Ctrl+Alt+F12 di layar kios, lalu masukkan *username* dan *password* di *form* *login* seperti pada Gambar 4.8. Peran Admin atau Kasir diambil dari data pengguna, bukan dipilih sendiri.

![Gambar 4.8 Form Login Mode Staff](../testing/screenshoot/08_login.png|8.5)

2. Lihat ringkasan penjualan di *dashboard*. Halaman ini menampilkan pendapatan hari ini, jumlah pesanan, grafik omzet tujuh hari, dan lima menu terlaris seperti pada Gambar 4.9.

![Gambar 4.9 Dashboard pada Jendela MDI](../testing/screenshoot/09_mdi_dashboard.png|12)

3. Konfirmasi pembayaran tunai di *form* kasir. Kasir memilih pesanan berstatus Menunggu Pembayaran, mengisi uang yang diterima, lalu aplikasi menghitung kembalian beserta pecahannya seperti pada Gambar 4.10.

![Gambar 4.10 Form Kasir](../testing/screenshoot/10_kasir.png|12)

4. Proses pesanan di *form* dapur. Waktu tunggu dihitung otomatis dan baris yang terlalu lama menunggu berubah merah, lalu dapur menekan Tandai Siap seperti pada Gambar 4.11.

![Gambar 4.11 Form Dapur](../testing/screenshoot/11_dapur.png|12)

5. Tampilkan layar antrian untuk pelanggan. Layar ini membagi nomor menjadi Sedang Disiapkan dan Siap Diambil, lalu memperbarui isinya setiap tiga detik seperti pada Gambar 4.12.

![Gambar 4.12 Layar Antrian Pesanan](../testing/screenshoot/12_antrian.png|11.5)

6. Kelola data dan laporan lewat menu Master dan Laporan. Admin bisa menambah produk beserta foto dan stok, lalu melihat riwayat transaksi dan mengekspornya ke CSV seperti pada Gambar 4.13 dan Gambar 4.14.

![Gambar 4.13 Form Admin Produk](../testing/screenshoot/13_admin_produk.png|12)

![Gambar 4.14 Form Laporan Penjualan](../testing/screenshoot/14_admin_laporan.png|12)

> Menu Kembali ke Kiosk menutup semua *form* anak dan mengeluarkan sesi staf. Aplikasi lalu kembali menampilkan layar awal kios dalam keadaan selalu di atas.

# BAB 5|PENUTUP

## 5.1 Kesimpulan

Aplikasi sudah bisa didemokan dari awal sampai akhir. Kesimpulan yang bisa diambil dari proyek ini adalah sebagai berikut:

1. Aplikasi kios pemesanan makanan berhasil dibangun dengan Windows Forms VB.NET. Pelanggan bisa memilih menu, mengatur opsi, memakai *voucher*, dan membayar sendiri, lalu mendapat nomor antrian.
2. Alur pesanan dari kios ke kasir, dapur, dan layar antrian berjalan lewat status yang disepakati. Transisi yang tidak sah, misalnya membatalkan pesanan yang sudah Siap, ditolak oleh ModAntrian.
3. Admin bisa mengelola produk, *voucher*, *member*, pengguna, dan pengaturan, serta melihat *dashboard* dan laporan penjualan dalam satu jendela MDI.
4. Materi praktikum sudah diterapkan, antara lain validasi dengan ErrorProvider dan TryParse, MDI pada Mode Staff, dan Windows API untuk *topmost*, *hotkey*, bunyi, serta waktu diam. Logika inti lulus 18 dari 18 pemeriksaan *self-test*, tetapi penyambungan penuh ke Supabase belum selesai.

## 5.2 Saran

Aplikasi ini masih bisa dikembangkan. Beberapa saran untuk proyek berikutnya adalah sebagai berikut:

1. Menyelesaikan penyambungan semua modul ke Supabase, lalu menjalankan uji *black box* dan uji alur lengkap dengan data asli.
2. Menghubungkan pembayaran QRIS ke penyedia pembayaran sungguhan supaya tidak lagi berupa simulasi.
3. Mencoba aplikasi pada layar sentuh dan menguji kenyamanannya langsung bersama calon pelanggan.
