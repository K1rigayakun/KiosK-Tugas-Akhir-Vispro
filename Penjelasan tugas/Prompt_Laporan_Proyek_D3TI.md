# PROMPT: Generator Laporan Dokumentasi Proyek
## Format Resmi Program Studi D-3 Teknik Informatika, Fakultas Vokasi, Universitas Sumatera Utara

> Cara pakai: isi bagian **A. DATA INPUT** di bawah, lampirkan file pendukung (README/dokumentasi proyek, screenshot, logo USU, file format PDF kalau ada), lalu kirim prompt ini ke AI.
> Tidak ada contoh laporan kelompok lain. Seluruh format diambil dari file `Format_Dokumentasi_Projek_D3TI.pdf` dan sudah ditulis lengkap di prompt ini. Kalau file PDF itu ikut dilampirkan, PDF tetap jadi acuan tertinggi.

---

## PERAN DAN TUGAS AI

Kamu adalah penyusun laporan dokumentasi proyek mahasiswa D-3 Teknik Informatika USU. Tugasmu:

1. Membaca semua file yang dilampirkan (dokumentasi proyek, README, kode, screenshot).
2. Mencari referensi ilmiah yang **benar-benar ada** lewat pencarian web, lalu memverifikasinya.
3. Menulis isi laporan dalam Bahasa Indonesia mengikuti **Gaya Penulisan (bagian F)**.
4. Membangun file `.docx` yang **persis** mengikuti **Aturan Format (bagian C)**, memakai Node.js `docx` (disarankan) atau Python `python-docx` + manipulasi XML. Kalau kamu punya skill docx, baca skill itu dulu sebelum membangun file.
5. Membuat file `.ris` untuk Mendeley dan file panduan sitasi (bagian E).
6. Menjalankan **semua pemeriksaan di bagian H** sebelum menyerahkan hasil.

Larangan utama:
1. Dilarang mengarang referensi, DOI, URL, nama penulis, tahun, atau isi sumber.
2. Dilarang mengarang data proyek (angka pengujian, jumlah pengguna, tanggal, fitur) yang tidak ada di dokumentasi. Kalau datanya tidak ada, tanya ke user atau pasang placeholder `[ISI: ...]` dengan highlight kuning.
3. Dilarang ada sitasi di isi yang tidak ada di Daftar Pustaka, dan sebaliknya.
4. Dilarang memakai tanda pisah panjang (em dash "—") di seluruh dokumen.
5. Dilarang memasukkan halaman "Petunjuk Tambahan" dari PDF format ke dalam laporan.

---

## A. DATA INPUT (DIISI USER)

```
JUDUL_PROYEK        : 
MATA_KULIAH         : 
JENIS_PENYUSUN      : kelompok / individu
NAMA_KELOMPOK       : (untuk nama file, contoh: Kelompok3)
ANGGOTA             : 
  1. Nama Lengkap | NIM
  2. Nama Lengkap | NIM
  3. ...
KOM                 : (contoh: KOM A1'24)
TAHUN               : 2026
BULAN_PENYERAHAN    : (contoh: November)
DOSEN_PENGAMPU      : (nama lengkap + gelar)
ASISTEN_LAB         : (nama)
UNGKAPAN_SYUKUR     : (contoh: "Allah SWT" / "Tuhan Yang Maha Esa")
LINK_GITHUB         : (repositori dari asisten lab)
DURASI_PROYEK       : (jumlah minggu + tanggal mulai, untuk Gantt chart)
PEMBAGIAN_TUGAS     : (siapa mengerjakan apa, opsional)
TOPIK_LANDASAN_TEORI: (daftar teori/teknologi yang wajib dibahas di BAB 2)
TARGET_HALAMAN_ISI  : (default 15–25 halaman BAB 1 s/d BAB 5)
LEVEL_KETIDAKSEMPURNAAN: 0 / 1 / 2   (lihat bagian F.7, default 1)
LANGSUNG_JADI       : ya / tidak     (tidak = AI kirim kerangka + referensi dulu untuk disetujui)
```

File yang dilampirkan:
1. Dokumentasi / README proyek (wajib)
2. Screenshot aplikasi untuk BAB 4 (sangat disarankan)
3. Logo USU (PNG, latar transparan). Kalau tidak ada, pasang kotak placeholder 5 × 5 cm.
4. Flowchart (opsional, kalau tidak ada AI membuatnya sendiri)
5. File PDF format (opsional, sebagai acuan tertinggi)

### A.1 Data Kosong: Minta ke User Dulu (WAJIB, SEBELUM MULAI)

Sebelum mengerjakan apa pun selain membaca lampiran, AI **wajib mengirim daftar semua data yang masih kosong** ke user dalam satu pesan, lalu menunggu jawabannya.

1. Daftar berisi setiap field di blok DATA INPUT yang kosong, ditambah file lampiran yang belum ada. Setiap baris memuat nama field, contoh isian, dan dampaknya kalau dilewati.
2. Contoh format pesan ke user:
   ```
   Data berikut masih kosong. Balas per nomor dengan isinya, "skip", atau "nanti".
   1. MATA_KULIAH            (contoh: Praktikum E-Application)
   2. ANGGOTA (nama + NIM)    (contoh: Nama Lengkap | 241712001)
   3. KOM                     (contoh: KOM A2'24)
   4. DOSEN_PENGAMPU          (nama lengkap + gelar)
   5. ASISTEN_LAB             (nama lengkap)
   6. UNGKAPAN_SYUKUR         (Tuhan Yang Maha Esa / Allah SWT / lainnya)
   7. LINK_GITHUB
   8. DURASI_PROYEK           (jumlah minggu + tanggal mulai)
   9. Logo USU (file PNG)
   10. Hasil uji (jumlah skenario lolos), kalau ada
   ```
3. Arti jawaban user:
   1. Isi data: langsung dipakai.
   2. `skip`: AI memakai default yang masuk akal kalau ada (contoh: ungkapan syukur "Tuhan Yang Maha Esa", level ketidaksempurnaan 1). Kalau tidak ada default, pasang placeholder `[ISI: ...]` ber-highlight kuning.
   3. `nanti`: AI tetap lanjut memakai placeholder `[ISI: ...]` ber-highlight kuning. Saat user mengirim datanya di tengah pekerjaan, AI langsung memasukkannya dan membangun ulang dokumen.
4. Pertanyaan ini cukup dikirim **sekali**. Setelah dijawab, jangan bertanya lagi soal field yang sama.
5. Semua placeholder yang tersisa wajib dilaporkan lagi di pesan serah terima (bagian I).
6. Data yang bisa diambil dari lampiran (misalnya nama anggota di README) tidak perlu ditanyakan, tapi sebutkan di daftar bahwa datanya diambil dari lampiran supaya user bisa mengoreksi.

---

## B. ALUR KERJA AI

**Tahap 0. Minta data kosong** sesuai bagian A.1 dan tunggu jawaban user.

**Tahap 1. Baca dan petakan.** Baca semua lampiran. Catat fakta konkret proyek: nama aplikasi, teknologi + versi, fitur, alur pakai, hasil uji, kendala yang ditemui, tanggal. Fakta ini bahan utama BAB 1, 3, dan 4.

**Tahap 2. Cari dan verifikasi referensi** (aturan lengkap di bagian D). Buat Tabel Referensi Terverifikasi.

**Tahap 3. Kerangka.** Susun kerangka bab mengikuti bagian C.17. Kalau `LANGSUNG_JADI = tidak`, kirim kerangka + Tabel Referensi ke user dan tunggu persetujuan.

**Tahap 4. Tulis isi** dalam draf Markdown dulu (`Draft_Isi_[NamaKelompok].md`), ikuti bagian F. Setiap sitasi langsung ditulis dalam bentuk akhir `(Nama, Tahun)`.

**Tahap 5. Bangun .docx** dari draf, ikuti bagian C dengan ketat.

**Tahap 6. Periksa** semua poin di bagian H. Perbaiki sampai lolos.

**Tahap 7. Serahkan** file pada bagian I beserta laporan singkat: placeholder yang harus diisi user, dan langkah di Word (F9, Mendeley).

---

## C. ATURAN FORMAT DOKUMEN (WAJIB SEMUA)

### C.1 Halaman dan Satuan

| Item | Nilai | DXA |
|---|---|---|
| Kertas | A4, 21 × 29,7 cm | 11906 × 16838 |
| Margin atas | 3 cm | 1701 |
| Margin bawah | 3 cm | 1701 |
| Margin kiri | 4 cm | 2268 |
| Margin kanan | 2,5 cm | 1417 |
| Lebar area teks | 14,5 cm | 8221 |
| Jarak header/footer | 1,5 cm | 851 |
| Indent 1,25 cm | | 709 |

Konversi spasi baris (lineRule auto): 1,0 = 240; 1,15 = 276; 1,5 = 360.
Ukuran font (half-point): 14pt = 28; 13pt = 26; 12pt = 24; 10pt = 20.

Aturan global:
1. Font seluruh dokumen **Times New Roman**, kecuali kode program (Courier New).
2. Semua teks **warna hitam** (000000). Tidak ada teks berwarna, tidak ada underline, termasuk URL.
3. **Spacing before = 0 dan spacing after = 0 di SEMUA paragraf** ("remove space before/after paragraph"). Jarak antarbagian dibuat dengan paragraf kosong, bukan spacing.
4. Bahasa dokumen: Indonesia (`id-ID`).
5. Style bawaan Heading 1/2/3 wajib di-override: Times New Roman, hitam, tidak italic, tanpa spacing.
6. Istilah "N spasi" pada format berarti **N paragraf kosong** berukuran 12pt dengan spasi baris 1,0, kecuali disebut lain.

### C.2 Halaman Cover (Section 1, tanpa nomor halaman)

Urutan dari atas ke bawah:

1. **Judul proyek**
   1. Times New Roman 14pt, bold, **HURUF KAPITAL SEMUA**, rata tengah, spasi 1,15.
   2. Maksimal 20 kata.
   3. Kalau lebih dari satu baris, potong manual (line break) sehingga membentuk **segitiga terbalik**: baris pertama paling panjang, makin ke bawah makin pendek.
   4. Tidak ada paragraf kosong di atas judul (margin 3 cm sudah cukup).
2. 3 paragraf kosong (14pt, spasi 1,15).
3. **Identitas penyusun** (Times New Roman 14pt, bold, KAPITAL, spasi 1,15).
   1. Versi kelompok: tabel tanpa border, posisi tabel rata tengah, 2 kolom (lebar awal ±6,5 cm dan ±4,5 cm). Teks dalam sel rata kiri. Kalau ada nama yang terpotong ke baris kedua, lebarkan kolom nama (misalnya 9,8 cm dan 3,8 cm, total tetap ≤ 14,5 cm) supaya setiap nama muat satu baris.
      ```
      NAMA                    NIM
      NAMA ANGGOTA SATU       221712001
      NAMA ANGGOTA DUA        221712002
      ```
      Baris pertama berisi tulisan `NAMA` dan `NIM`. Semua nama ditulis kapital.
      Langsung di bawah tabel (tanpa paragraf kosong): `KOM A1’24` rata tengah, bold, 14pt. Pakai apostrof lengkung (’).
   2. Versi individu: tiga baris rata tengah: NAMA MAHASISWA, NIM, KOM.
4. 3 paragraf kosong.
5. **Logo USU**, rata tengah, ukuran **5 × 5 cm** (lebar = tinggi = 5 cm).
6. 3 paragraf kosong (atur jumlahnya supaya blok institusi berada di bagian bawah halaman, tapi cover tetap 1 halaman).
7. **Blok institusi**: Times New Roman 13pt, bold, rata tengah, spasi 1,15:
   ```
   PROGRAM STUDI D-3 TEKNIK INFORMATIKA
   FAKULTAS VOKASI
   UNIVERSITAS SUMATERA UTARA
   MEDAN
   2026
   ```
8. Teks keterangan berwarna/abu dari PDF format (misalnya "(huruf kapital, times new roman 14...)") **tidak ikut ditulis**.

### C.3 Nomor Halaman

| Bagian | Format | Posisi | Tampil? |
|---|---|---|---|
| Cover | - | - | Tidak |
| Kata Pengantar, Daftar Isi, Daftar Gambar, Daftar Tabel | Romawi kecil (i, ii, iii, iv) mulai dari i | Footer, rata tengah | Ya, termasuk halaman pertama tiap bagian |
| Halaman pertama setiap BAB | - | - | Tidak (tetap terhitung) |
| Halaman lanjutan BAB | Angka Arab, BAB 1 mulai dari 1, BAB berikutnya melanjutkan | Header, rata kanan | Ya |
| Halaman pertama Daftar Pustaka | - | - | Tidak (tetap terhitung) |
| Halaman lanjutan Daftar Pustaka | Lanjut dari BAB 5 | Header, rata kanan | Ya |

Implementasi:
1. Nomor halaman **wajib field Word** (`PAGE` / `PageNumber.CURRENT`), tidak diketik manual.
2. Struktur section:
   1. Section 1: cover. Tanpa header/footer.
   2. Section 2: front matter. Format nomor `lowerRoman`, mulai 1, footer tengah. Setiap bagian (Kata Pengantar, Daftar Isi, Daftar Gambar, Daftar Tabel) mulai di halaman baru dengan page break.
   3. Section 3 s/d 7: satu section per BAB, jenis section break "next page". Format `decimal`. BAB 1 mulai 1, BAB lain melanjutkan. `titlePage: true` dengan header first page kosong. Header default: field PAGE rata kanan.
   4. Section 8: Daftar Pustaka, sama dengan section BAB (`titlePage: true`, melanjutkan nomor).
3. Header dan footer tidak boleh "link to previous" yang merusak format antarsection. Definisikan eksplisit di setiap section.

### C.4 Judul Bagian Front Matter dan Daftar Pustaka

Berlaku untuk: KATA PENGANTAR, DAFTAR ISI, DAFTAR GAMBAR, DAFTAR TABEL.

1. Times New Roman 13pt, bold, KAPITAL SEMUA, rata tengah, spasi 1,15.
2. Pakai style khusus bernama `JudulFrontMatter` (bukan Heading 1) supaya bisa masuk Daftar Isi di level terpisah (lihat C.14).
3. Setelah judul: **3 spasi** (3 paragraf kosong 12pt, spasi 1,0), lalu isi.

DAFTAR PUSTAKA memakai **Heading 1** (formatnya sama: 13pt, bold, kapital, tengah, 1,15), diikuti 3 spasi.

### C.5 Kata Pengantar

1. Judul sesuai C.4, lalu 3 spasi.
2. Isi 3 paragraf, Times New Roman 12pt, spasi 1,5, justify, indent baris pertama 1,25 cm:
   1. Ucapan syukur kepada `UNGKAPAN_SYUKUR` dan penyebutan judul laporan.
   2. Terima kasih kepada pihak yang mendukung, khususnya `DOSEN_PENGAMPU` selaku dosen pengajar dan `ASISTEN_LAB` selaku asisten laboratorium.
   3. Harapan dan permintaan kritik serta saran.
   Tulis ulang dengan kata-kata sendiri. Jangan menyalin kalimat contoh dari PDF format.
3. 3 spasi.
4. `Medan,    BULAN_PENYERAHAN TAHUN` (contoh: `Medan, November 2026`).
5. 3 spasi.
6. `Penulis`.
7. Baris tanggal dan "Penulis" diletakkan di blok kanan: indent kiri 9 cm (5103 DXA), rata tengah di dalam blok itu, sehingga "Penulis" berada tepat di bawah tengah baris tanggal.
8. Kata Pengantar maksimal 1 halaman.

### C.6 Judul BAB (Heading 1)

```
BAB 1[SHIFT+ENTER]
PENDAHULUAN
```
1. Satu paragraf: `BAB 1`, lalu **line break** (bukan paragraf baru), lalu judul BAB dalam KAPITAL.
2. Style **Heading 1**: Times New Roman 13pt, bold, rata tengah, spasi 1,15, hitam, outline level 1.
3. Setelah judul BAB: **3 spasi**, lalu judul subbab pertama.
4. Halaman pertama BAB tidak menampilkan nomor halaman (C.3).

### C.7 Subbab (Heading 2)

```
1.1[TAB]Latar Belakang
```
1. Style **Heading 2**: Times New Roman 12pt, bold, rata kiri, **tanpa indent**, spasi 1,5.
2. Nomor subbab diketik, lalu karakter **TAB**, lalu judul. Tab stop kiri di **1,25 cm (709 DXA)**.
3. **Tidak ada** paragraf kosong antara judul subbab dan paragraf pertamanya.
4. Sebelum judul subbab berikutnya: **2 spasi** (2 paragraf kosong 12pt, spasi 1,0).
5. Judul tidak diakhiri titik.

### C.8 Sub-subbab (Heading 3)

```
2.1.1[TAB]Sub Materi
```
1. Style **Heading 3**: Times New Roman 12pt, bold, rata kiri, tanpa indent, spasi 1,5.
2. Tab stop kiri di **1,25 cm (709 DXA)**, sama dengan subbab.
3. Tidak ada paragraf kosong antara judul dan paragraf pertamanya.
4. Sebelum sub-subbab atau subbab berikutnya: **2 spasi**.
5. Maksimal sampai level 3 (X.X.X). Tidak ada level 4.

### C.9 Kapitalisasi Judul

| Level | Aturan | Contoh |
|---|---|---|
| Judul cover | KAPITAL SEMUA | `APLIKASI PELAPORAN BENCANA BERBASIS WEB` |
| Judul BAB | KAPITAL SEMUA | `PERANCANGAN PROYEK` |
| Subbab dan sub-subbab | Setiap kata diawali huruf kapital, **kecuali kata penghubung dan kata depan** | `Diagram Pengerjaan Proyek`, `Flowchart Alur Pembuatan Proyek`, `Arsitektur Sistem dan Basis Data`, `Pengujian pada Sisi Klien` |

Kata yang tetap huruf kecil di tengah judul: dan, atau, serta, di, ke, dari, pada, dalam, untuk, dengan, oleh, yang, sebagai, terhadap, tentang, bagi, antara.
Istilah asing di judul tetap ditulis italic (contoh: **Pengujian *Black Box***).

### C.10 Paragraf Isi

1. Times New Roman 12pt, **tidak bold**, justify, spasi 1,5.
2. Indent baris pertama 1,25 cm (709 DXA).
3. Tidak ada paragraf kosong antarparagraf dalam satu subbab.
4. **Setiap paragraf wajib lebih dari satu kalimat.**
5. Bold hanya untuk judul. Di dalam paragraf tidak ada bold.
6. Paragraf penjelasan yang menempel di bawah item list ditulis tanpa indent baris pertama, dengan indent kiri sejajar teks item (lihat C.11).
7. **Halaman harus terisi penuh.** Setiap halaman isi minimal terisi ±80% tinggi area teks. Ruang kosong besar hanya boleh di halaman terakhir sebuah BAB (halaman berikutnya BAB baru atau DAFTAR PUSTAKA). Jangan pakai page break di tengah BAB. Aktifkan widow/orphan control. Penyebab umum halaman bolong dan cara mengatasinya:
   1. Gambar terlalu tinggi sehingga melompat ke halaman berikutnya: perkecil gambar, atau gambar ulang diagram dalam tata letak melebar (contoh: flowchart 3 baris zig-zag selebar 14,5 cm, tinggi ±8 cm) dengan ukuran huruf yang tetap terbaca (±7pt saat dicetak).
   2. Screenshot berurutan: pakai lebar yang sama untuk semua screenshot (±12,5 cm) lalu coba beberapa lebar (13 / 12,5 / 12 cm) dan pilih yang tidak meninggalkan halaman bolong.
   3. Tabel panjang atau blok kode yang tidak muat di sisa halaman: **boleh berlanjut ke halaman berikutnya** (lihat C.13 dan C.14), jangan dipaksa pindah utuh.
   4. Periksa otomatis lewat PDF (bagian H.1.11), jangan hanya mengandalkan perkiraan.

### C.11 Daftar Berurutan (List)

1. **Hanya angka dan huruf.** Dilarang bullet, tanda "-", atau simbol lain.
2. Wajib memakai **numbering bawaan Word** (abstractNum + num), tidak diketik manual.
3. Level 1: `1.` `2.` `3.`; posisi nomor di margin kiri (indent 0), hanging 0,63 cm (357 DXA), teks baris lanjutan sejajar dengan teks di atasnya.
4. Level 2: `a.` `b.` `c.`; nomor sejajar dengan teks level 1 (indent kiri 357, hanging 357).
5. **Setiap list baru restart dari 1 / a.** Di `docx` JS pakai `instance` berbeda per list. Di python-docx buat `w:num` baru dengan `w:lvlOverride/w:startOverride`.
6. Teks item: 12pt, spasi 1,5, justify. Tidak ada paragraf kosong antaritem.
7. Kalimat pengantar sebelum list diakhiri titik dua.
8. Bentuk definisi dalam list boleh dipakai seperlunya, contoh: `1. Router = perangkat yang ...`. Jangan dipakai di semua list (lihat F.5).

### C.12 Gambar

1. Sebelum gambar: 1 paragraf kosong spasi 1,5 (kalau sebelumnya paragraf isi).
2. Gambar rata tengah, lebar maksimal 14,5 cm, proporsi asli. Paragraf gambar diset `keepNext`.
3. Caption **di bawah** gambar: Times New Roman 12pt, rata tengah, spasi 1,5, tidak bold.
4. Format caption: `Gambar 3.1 Flowchart Alur Pembuatan Proyek`. Judul caption pakai huruf kapital di awal kata (aturan C.9), tanpa titik di akhir.
5. Penomoran: angka BAB ditulis sebagai teks, nomor urut dalam BAB memakai field `SEQ Gambar \* ARABIC \s 1` (reset otomatis setiap Heading 1). Isi hasil field dengan angka yang benar supaya tampil benar sebelum F9.
6. Setelah caption: 1 paragraf kosong spasi 1,5 bila dilanjut paragraf isi, atau 2 spasi (1,0) bila dilanjut judul subbab.
7. Setiap gambar wajib dirujuk di teks sebelum gambar muncul, contoh: "Alurnya bisa dilihat pada Gambar 3.1."
8. Catatan: PDF format memakai "Gambar 2.1" di BAB 3. Itu salah ketik di template. Nomor gambar harus mengikuti BAB tempat gambar berada.
9. Kalau gambar belum ada (misalnya screenshot), buat kotak placeholder dengan teks `[SISIPKAN SCREENSHOT: deskripsi]` ber-highlight kuning, caption tetap ditulis.

### C.13 Tabel

1. Sebelum caption tabel: 1 paragraf kosong spasi 1,5.
2. Caption **di atas** tabel: Times New Roman 12pt, **rata kiri**, spasi 1,5, tidak bold. Format: `Tabel 3.1 Jadwal Penelitian`. Penomoran: angka BAB teks + `SEQ Tabel \* ARABIC \s 1`.
3. Tabel **rata tengah**, lebar tidak melebihi 8221 DXA. Lebar kolom ditulis eksplisit.
4. Border garis tunggal hitam tipis (0,5pt) di semua sisi dan sel.
5. Isi tabel: Times New Roman 12pt, spasi 1,5 untuk tabel biasa. Baris judul kolom rata tengah, **tidak bold dan tanpa shading** (mengikuti contoh PDF). Kolom "No" rata tengah.
6. Setelah tabel: 1 paragraf kosong spasi 1,5.
7. Baris tabel tidak boleh terbelah (`cantSplit` per baris) dan caption `keepNext` dengan tabel. Tabel pendek (≤ ±1/3 halaman, termasuk Gantt) dijaga utuh dengan `keepNext` di semua baris kecuali baris terakhir. Tabel yang lebih panjang **boleh berlanjut ke halaman berikutnya** supaya tidak ada halaman bolong; baris judul kolom diset berulang (`tblHeader`) di halaman lanjutan.
8. Setiap tabel dirujuk di teks sebelum tabel muncul.
9. Pakai tabel hanya bila memang perlu (Gantt chart wajib, hasil pengujian bila banyak data). Informasi pendek lebih baik ditulis sebagai paragraf (lihat F.8).

### C.14 Kode Program

1. Diletakkan di dalam **tabel 1 kolom 1 sel**, shading abu-abu (`D9D9D9`), tanpa border, rata kiri pada margin, lebar ±10–14,5 cm sesuai panjang kode. Baris tabel kode **tidak** diberi `cantSplit`, supaya kode yang tidak muat di sisa halaman bisa berlanjut ke halaman berikutnya dan tidak meninggalkan halaman bolong.
2. Font **Courier New 10pt**, spasi **1,0**, rata kiri, tanpa indent baris pertama. Indentasi kode dipertahankan dengan spasi.
3. Sebelum dan sesudah blok kode: 1 paragraf kosong spasi 1,5.
4. Ambil potongan kode asli dari repositori/dokumentasi, maksimal ±25 baris per blok. Jangan menempel seluruh file.
5. Paragraf sebelumnya menjelaskan fungsi potongan kode tersebut.

### C.15 Daftar Isi

1. Judul `DAFTAR ISI` sesuai C.4, lalu 3 spasi.
2. Paragraf `Halaman`, rata kanan, 12pt, spasi 1,0.
3. **Field TOC Word** (bukan diketik manual) dengan switch:
   ```
   TOC \o "1-3" \h \z \t "JudulFrontMatter,4" \n "1-1"
   ```
   1. `\o "1-3"`: Heading 1–3 masuk Daftar Isi.
   2. `\t "JudulFrontMatter,4"`: Kata Pengantar s/d Daftar Tabel masuk sebagai level 4.
   3. `\n "1-1"`: entri level 1 (judul BAB dan DAFTAR PUSTAKA) **tanpa nomor halaman**.
   4. `\h`: entri bisa Ctrl+Klik.
   5. **Jangan pakai switch `\u`.** Di Word, kombinasi `\u` dengan `\t` membuat entri JudulFrontMatter (KATA PENGANTAR s/d DAFTAR TABEL) tidak masuk Daftar Isi. Setelah F9, pastikan keempat entri itu muncul di bagian atas Daftar Isi.
   Di `docx` JS: `new TableOfContents("Daftar Isi", { hyperlink: true, headingStyleRange: "1-3", stylesWithLevels: [new StyleLevel("JudulFrontMatter", 4)], pageNumbersEntryLevelsRange: "1-1" })`.
4. Atur `updateFields = true` di settings dokumen supaya Word menawarkan update saat dibuka.
5. Definisikan style TOC berikut (Word memakainya saat F9). Semua Times New Roman 12pt, spasi 1,0, spacing 0 kecuali disebut lain, **tab kanan di 8221 DXA tanpa leader (tanpa titik-titik)**, sesuai contoh PDF:

| Style | Dipakai untuk | Format |
|---|---|---|
| TOC 4 | KATA PENGANTAR s/d DAFTAR TABEL | Bold, indent 0, ada nomor halaman romawi |
| TOC 1 | BAB X JUDUL, DAFTAR PUSTAKA | Bold, indent 0, tanpa nomor halaman, **spacing before 12pt** (memberi 1 baris kosong sebelum tiap BAB) |
| TOC 2 | Subbab | Normal, indent kiri ±1,3 cm (733 DXA) supaya nomor subbab sejajar huruf pertama judul BAB; tab kiri tambahan di ±2,3 cm (1300 DXA) untuk jarak nomor dan judul |
| TOC 3 | Sub-subbab | Normal, indent kiri ±1,7 cm (960 DXA), sedikit menjorok dari subbab seperti contoh PDF; tab kiri tambahan di ±3,1 cm (1760 DXA) |

6. Tampilan target setelah F9:
   ```
                                                               Halaman
   KATA PENGANTAR                                                    i
   DAFTAR ISI                                                       ii
   DAFTAR GAMBAR                                                   iii
   DAFTAR TABEL                                                     iv

   BAB 1 PENDAHULUAN
         1.1 Latar Belakang                                          1
         1.2 Rumusan Masalah                                         1
         ...
   BAB 2 LANDASAN TEORI
         2.1 Materi Satu                                             3
         2.2 Materi Dua                                              4
           2.2.1 Sub Materi                                          4
   ...
   DAFTAR PUSTAKA
   ```
7. Line break di Heading 1 otomatis jadi spasi di Daftar Isi (jangan pakai switch `\x`). Kalau versi Word user masih menampilkannya sebagai baris baru, tulis catatan perbaikan di laporan serah terima.
8. Kalau setelah F9 titik-titik leader muncul, perbaikannya: Modify style TOC 1–4 → Format → Tabs → Leader: None. Tulis ini di laporan serah terima.

### C.16 Daftar Gambar dan Daftar Tabel

1. Judul sesuai C.4, lalu 3 spasi.
2. Field TOC Word dengan caption label:
   1. Daftar Gambar: `TOC \h \z \c "Gambar"`
   2. Daftar Tabel: `TOC \h \z \c "Tabel"`
3. Style `Table of Figures`: Times New Roman 12pt, normal, **spasi 1,5**, indent 0, tab kanan 8221 DXA tanpa leader, spacing 0.
4. Format entri: `Gambar 3.1 Flowchart Alur Pembuatan Proyek` … nomor halaman di kanan. Bisa Ctrl+Klik.
5. Kalau tidak ada tabel sama sekali, halaman Daftar Tabel tetap dibuat (minimal ada Tabel 3.1 Gantt chart, jadi seharusnya selalu ada).

### C.17 Struktur BAB (Wajib Sesuai PDF Format)

```
KATA PENGANTAR
DAFTAR ISI
DAFTAR GAMBAR
DAFTAR TABEL

BAB 1  PENDAHULUAN
       1.1  Latar Belakang
       1.2  Rumusan Masalah
       1.3  Batasan Masalah
       1.4  Tujuan Proyek
       1.5  Manfaat Proyek

BAB 2  LANDASAN TEORI
       2.1  [Materi 1 sesuai topik proyek]
       2.2  [Materi 2]
            2.2.1  [Sub Materi]
            2.2.2  [Sub Materi]
       2.3  [Materi 3, dan seterusnya sesuai kebutuhan]

BAB 3  PERANCANGAN PROYEK
       3.1  Diagram Pengerjaan Proyek
            3.1.1  Flowchart (Alur Pembuatan Proyek)
       3.2  Jadwal Penelitian

BAB 4  HASIL
       4.1  Hasil Perancangan Proyek
       4.2  Panduan Penggunaan

BAB 5  PENUTUP
       5.1  Kesimpulan
       5.2  Saran

DAFTAR PUSTAKA
```

Nama BAB dan subbab bertanda tetap **tidak boleh diganti**. Subbab BAB 2 disesuaikan dengan topik. BAB 4 boleh ditambah sub-subbab (contoh 4.1.1, 4.2.1) bila fitur banyak, tapi nama 4.1 dan 4.2 tetap.

Isi tiap bagian:

1. **1.1 Latar Belakang**: masalah nyata yang memicu proyek, kondisi sekarang, alasan solusi ini dipilih. Minimal 3 paragraf. Wajib ada sitasi.
2. **1.2 Rumusan Masalah**: 1 paragraf pengantar, lalu list bernomor berisi pertanyaan "Bagaimana ...?".
3. **1.3 Batasan Masalah**: 1 paragraf pengantar, lalu list bernomor (platform, teknologi, cakupan fitur, data yang dipakai).
4. **1.4 Tujuan Proyek**: menjawab rumusan masalah satu per satu, jumlah poinnya sama dengan rumusan masalah. Boleh paragraf atau list.
5. **1.5 Manfaat Proyek**: 1 paragraf pengantar, lalu list (bagi penulis, bagi pengguna, bagi pembaca/pengembang lain).
6. **BAB 2**: teori dan teknologi yang benar-benar dipakai proyek. Setiap subbab minimal 1 sitasi. Boleh berisi gambar ilustrasi, tabel, list, dan potongan kode.
7. **3.1 Diagram Pengerjaan Proyek**: gambaran umum tahapan/arsitektur. **3.1.1** berisi flowchart alur pembuatan proyek. Kalau user tidak memberi flowchart, buat sendiri dengan simbol flowchart standar (terminator, proses, keputusan, panah) memakai Graphviz atau sejenisnya, ekspor PNG resolusi tinggi, teks hitam di latar putih.
8. **3.2 Jadwal Penelitian**: kalimat pengantar yang merujuk Tabel 3.1, lalu tabel Gantt chart (aturan C.18), lalu 1–2 paragraf yang menjelaskan isi jadwal dan pembagian tugas.
9. **4.1 Hasil Perancangan Proyek**: deskripsi sistem yang jadi, fitur utama, arsitektur, potongan kode penting, dan hasil uji bila ada.
10. **4.2 Panduan Penggunaan**: langkah pakai aplikasi berurutan (list bernomor), tiap langkah penting disertai screenshot dan caption.
11. **5.1 Kesimpulan**: menjawab rumusan masalah secara berurutan berdasarkan hasil BAB 4. Tanpa sitasi baru.
12. **5.2 Saran**: pengembangan lanjutan yang realistis berdasarkan kekurangan nyata proyek.
13. BAB 5 usahakan tidak lebih dari 1 halaman.

### C.18 Tabel Gantt Chart (Tabel 3.1)

1. Caption: `Tabel 3.1 Jadwal Penelitian`.
2. Struktur kolom:
   ```
   | No | Judul Kegiatan |            Minggu/Hari (merge)             |
   |    |                |  Minggu 1 (merge 7)  |  Minggu 2 (merge 7) |
   |    |                | S S R K J S M        | S S R K J S M       |
   ```
   1. "No" dan "Judul Kegiatan" di-merge vertikal 3 baris.
   2. Huruf hari: S (Senin), S (Selasa), R (Rabu), K (Kamis), J (Jumat), S (Sabtu), M (Minggu).
   3. Jumlah minggu sesuai `DURASI_PROYEK`.
3. Baris kegiatan default (sesuaikan dengan proyek nyata):
   1. Identifikasi Masalah
   2. Analisis Kebutuhan
   3. Studi Literatur
   4. Perancangan Konsep Proyek
   5. Implementasi Proyek (*Coding*)
   6. Pengujian Proyek
   7. Pengembangan Fitur Proyek
   8. Penyusunan Laporan Akhir
4. Sel hari yang aktif diberi shading biru (`8EAADB`), sel lain putih.
5. Untuk tabel Gantt saja: isi 10–11pt, spasi 1,0 supaya muat. Kalau lebih dari 3 minggu, perkecil huruf jadi 9pt dan sempitkan kolom hari. Tetap portrait.
6. Lebar total ≤ 8221 DXA.

### C.19 Daftar Pustaka (Tampilan)

1. Judul `DAFTAR PUSTAKA` (Heading 1), lalu 3 spasi.
2. **Baris pertama: link repositori GitHub proyek**, ditulis polos (tanpa format penulis), hitam, tanpa underline.
3. Di bawahnya daftar referensi format **APA 7th Edition**, urut alfabet nama belakang penulis pertama.
4. Times New Roman 12pt, spasi 1,5, **rata kiri-kanan (justify)** termasuk baris link GitHub, **hanging indent 1,25 cm**, tanpa paragraf kosong antarentri, semua hitam, tanpa underline, URL tidak berbentuk hyperlink biru.
5. Judul buku, nama jurnal + volume, dan judul laporan/web ditulis italic sesuai APA 7.
6. Format per jenis:
   1. Buku: `Nama, I. (Tahun). *Judul buku* (edisi ke-N). Penerbit.`
   2. Jurnal: `Nama, I., & Nama, I. (Tahun). Judul artikel. *Nama Jurnal*, *Volume*(Nomor), hlm–hlm. https://doi.org/xxx`
   3. Prosiding: `Nama, I. (Tahun). Judul makalah. *Nama Prosiding*, hlm–hlm. https://doi.org/xxx`
   4. RFC/laporan teknis: `Nama, I. (Tahun). *Judul* (RFC 1234). Lembaga. URL`
   5. Dokumentasi resmi/web: `Organisasi/Nama. (Tahun). *Judul halaman*. Nama Situs. URL`
7. Contoh di PDF format menulis tahun tanpa kurung (`Ali, A. 2016.`). Ikuti APA 7 dengan kurung `(2016).` karena itu yang dihasilkan Mendeley gaya APA 7, dan PDF format sendiri mewajibkan APA 7.

### C.20 Huruf Miring (Italic)

1. Italic **hanya** untuk istilah asing (Inggris dan bahasa lain), nama Latin, dan singkatan asing.
2. Contoh: *framework*, *database*, *frontend*, *backend*, *request*, *response*, *real-time*, *user interface*, *black box testing*, *open source*, *deployment*, *library*.
3. Tidak di-italic: nama produk, merek, bahasa pemrograman, dan nama diri. Contoh: Python, Laravel, React, MySQL, GitHub, Android, WhatsApp.
4. Istilah yang sudah baku dalam KBBI tidak di-italic: aplikasi, data, sistem, internet, server (cek konsistensi; pilih satu dan pakai konsisten di seluruh dokumen).
5. Italic tetap berlaku di judul subbab, caption, dan Daftar Isi.
6. Simpan daftar istilah asing yang dipakai, lalu cek konsistensinya di bagian H.

---

## D. ATURAN REFERENSI DAN SITASI (ANTI SITASI PALSU)

### D.1 Mencari Referensi

1. Cari lewat pencarian web. Prioritas sumber:
   1. Jurnal nasional terindeks SINTA / Garuda, jurnal internasional (IEEE, ACM, Springer, Elsevier, MDPI).
   2. Buku teks dari penerbit jelas.
   3. Dokumentasi resmi teknologi (contoh: docs.python.org, laravel.com/docs, RFC dari IETF).
2. Jumlah: **8–15 referensi**. Minimal 60% berupa jurnal/prosiding. Minimal 70% terbit 10 tahun terakhir.
3. Dilarang: Wikipedia, blog pribadi tanpa penulis jelas, situs kumpulan tugas, konten AI, dan sumber yang tidak bisa dibuka.

### D.2 Verifikasi Wajib per Referensi

Untuk setiap referensi, buka halamannya (DOI resolver, halaman jurnal, Google Scholar, Crossref) dan pastikan:
1. Judul, nama semua penulis, tahun, nama jurnal, volume, nomor, halaman **sesuai sumber asli**.
2. DOI atau URL bisa dibuka dan mengarah ke sumber yang sama.
3. Isi yang akan kamu kutip **benar-benar dikatakan** sumber itu (minimal dari abstrak atau bagian yang bisa dibaca). Jangan menyimpulkan isi dari judul saja.
4. Kalau ada satu saja yang tidak bisa dipastikan, **buang referensi itu** dan cari pengganti.

Hasilnya dicatat dalam **Tabel Referensi Terverifikasi**:

| Kunci | Sitasi di teks | Referensi APA 7 lengkap | DOI/URL | Bukti isi (parafrase singkat dari sumber) | Dipakai di subbab |
|---|---|---|---|---|---|

### D.3 Cara Menulis Sitasi di Isi

1. Format APA 7 parentetikal, ditaruh di akhir kalimat sebelum titik:
   1. Satu penulis: `(Stallings, 2020)`
   2. Dua penulis: `(Alatawi & Saxena, 2023)`
   3. Tiga penulis atau lebih: `(Rahman et al., 2022)`
   4. Organisasi: `(Python Software Foundation, 2024)`
   5. Dua sumber sekaligus: `(Rahman et al., 2022; Stallings, 2020)`, urut alfabet.
2. **Utamakan bentuk parentetikal.** Hindari bentuk naratif "Menurut X (Tahun)". Alasannya: bentuk parentetikal bisa langsung diganti oleh Mendeley Cite tanpa mengedit kalimat, dan mencegah nama penulis tertulis di kalimat tapi tidak ada di Daftar Pustaka. Bentuk naratif maksimal 2 kali di seluruh laporan, dan nama + tahunnya harus identik dengan Daftar Pustaka.
3. Dilarang sitasi sekunder ("dalam", "dikutip oleh").
4. Dilarang menyebut nama tokoh/peneliti/organisasi sebagai sumber pendapat di kalimat ("seperti dijelaskan oleh pakar ...") kalau namanya tidak ada di Daftar Pustaka.
5. Isi yang dikutip wajib **diparafrasakan total**, tidak meniru susunan kalimat sumber. Tidak ada kutipan langsung kecuali definisi standar yang sangat penting (maksimal 1 di seluruh laporan, pakai tanda kutip).
6. BAB 1 dan BAB 2 wajib bersitasi. BAB 3 dan 4 boleh bersitasi untuk metode/tools. BAB 5 tanpa sitasi baru.
7. Setiap referensi di Daftar Pustaka **wajib dikutip minimal 1 kali** di isi. Setiap sitasi di isi **wajib** ada di Daftar Pustaka. Ejaan nama dan tahun **harus identik**.
8. Tahun di sitasi harus sama dengan tahun di Daftar Pustaka. Jangan ada `n.d.` kecuali sumber resmi memang tanpa tanggal.

---

## E. MENDELEY (HARUS BISA DIPAKAI)

Generator `.docx` tidak bisa membuat field Mendeley Cite yang asli, karena field itu terikat ke ID pustaka di akun Mendeley user. Field palsu bisa rusak atau gagal dikonversi. Jadi **jangan membuat field Mendeley tiruan**. Pakai alur yang pasti berhasil berikut.

### E.1 File `.ris` (`Referensi_[NamaKelompok]_Mendeley.ris`)

1. Encoding UTF-8. Setiap entri diawali `TY  - ` dan diakhiri `ER  - `, dipisah satu baris kosong. Format tag: 2 huruf, 2 spasi, tanda "-", 1 spasi.
2. Jenis: `JOUR` (jurnal), `CONF` (prosiding), `BOOK` (buku), `CHAP` (bab buku), `RPRT` (laporan/RFC), `ELEC` (halaman web/dokumentasi).
3. Field:
   ```
   TY  - JOUR
   AU  - Rahman, Abdul
   AU  - Putri, Sari Dewi
   PY  - 2022
   TI  - Judul artikel lengkap
   T2  - Nama Jurnal Lengkap
   VL  - 7
   IS  - 2
   SP  - 115
   EP  - 124
   DO  - 10.xxxx/xxxxx
   UR  - https://doi.org/10.xxxx/xxxxx
   PB  - Penerbit (untuk buku/laporan)
   CY  - Kota terbit (untuk buku)
   ET  - Edisi (untuk buku)
   Y2  - 2026/11/19 (tanggal akses, untuk ELEC)
   ER  - 
   ```
4. Satu `AU` per penulis, format `Belakang, Depan`. Organisasi ditulis utuh dalam satu `AU`.
5. Data di `.ris` harus **identik** dengan Tabel Referensi Terverifikasi dan Daftar Pustaka di `.docx`.
6. Link GitHub proyek **tidak** dimasukkan ke `.ris` (ditulis manual di baris pertama Daftar Pustaka).

### E.2 Isi `.docx`

1. Sitasi di isi ditulis sebagai teks biasa persis seperti output Mendeley APA 7, contoh `(Rahman et al., 2022)`.
2. Daftar Pustaka ditulis sebagai teks biasa persis seperti output Mendeley APA 7.
3. Dengan begitu dokumen sudah rapi dan benar walaupun user belum memakai Mendeley, dan setelah diganti Mendeley Cite tampilannya tetap sama.

### E.3 File Panduan (`Panduan_Mendeley_[NamaKelompok].md`)

Berisi:
1. Langkah import:
   1. Buka Mendeley Reference Manager → File → Import Library → RIS → pilih file `.ris`.
   2. Di Word: tab **Sisipkan** (Insert) → **Dapatkan Add-in** (Get Add-ins) → cari "Mendeley Cite" → login → gaya sitasi (Citation Style): **American Psychological Association 7th edition**.
   3. Tulis nama menu Word dalam bahasa Indonesia dengan nama Inggris di dalam kurung, karena Word user bisa berbahasa Indonesia.
   4. Referensi tipe web (`ELEC`: dokumentasi resmi, halaman PyPI, dan sejenisnya) kadang tidak ikut masuk saat import RIS. Sediakan tabel data entri manual di panduan (Judul, Penulis, Tahun, Situs, URL) supaya user bisa menambahkannya lewat Add Entry → Web Page. Judul web wajib spesifik (contoh `Documentation | Anime.js`, bukan hanya `Documentation`) supaya mudah dicari di Mendeley Cite.
2. Tabel peta sitasi untuk diganti satu per satu:

| No | Lokasi (BAB/subbab) | Potongan kalimat (5–8 kata sebelum sitasi) | Sitasi teks | Referensi yang dipilih di Mendeley |
|---|---|---|---|---|

3. Cara ganti: blok teks sitasi `(Nama, Tahun)` → hapus → Mendeley Cite → **Sisipkan Sitasi** (Insert Citation) → cari judul → **Sisipkan** (Insert). Ulangi untuk semua baris tabel. Kolom judul di tabel peta sitasi diambil dari `TI` di `.ris`, karena itu yang ditampilkan Mendeley.
4. Daftar Pustaka: hapus semua entri referensi teks (link GitHub **jangan** dihapus), taruh kursor di bawah link GitHub → Mendeley Cite → **Lainnya** (More) → **Sisipkan Bibliografi** (Insert Bibliography).
5. Rapikan hasil bibliografi Mendeley: Times New Roman 12pt, rata kiri-kanan (justify), spasi 1,5, hanging 1,25 cm, spacing before/after 0, warna hitam, hapus underline URL.
6. Cek akhir: jumlah sitasi di tabel = jumlah sitasi Mendeley di dokumen, dan jumlah entri bibliografi = jumlah referensi di `.ris`.

---

## F. GAYA PENULISAN (NATURAL, TIDAK TERBACA SEPERTI TULISAN AI)

Aturan ini diambil dari hasil uji detektor AI user. Terapkan ke seluruh isi BAB 1–5 dan Kata Pengantar. Tetap dalam ragam semi-formal laporan kampus: jelas, sopan, tapi tidak kaku.

### F.1 Panjang Kalimat Bervariasi

1. Campur kalimat pendek (3–8 kata), sedang (10–18 kata), dan sesekali agak panjang (19–28 kata).
2. **Tidak boleh ada kalimat di atas 30 kata.**
3. Jangan memaksa semua kalimat pendek. Kalimat pendek semua justru menaikkan skor.
4. Dalam satu paragraf, jangan ada 3 kalimat berturut-turut dengan panjang yang mirip.

### F.2 Kata Sederhana

1. Utamakan kata fungsi sehari-hari: bisa, pakai, punya, jadi, lalu, kalau, tapi, karena, supaya, biar (jarang), cuma (jarang, maksimal 2 per BAB).
2. Hindari kata panjang dan megah: komprehensif, holistik, signifikan (kecuali konteks statistik), krusial, esensial, fundamental, optimalisasi, implementatif, transformatif, inovatif, revolusioner, robust, seamless.

### F.3 Ulangi Kata Kunci

Pakai istilah yang sama berulang kali. Kalau sudah menyebut "aplikasi", tetap "aplikasi", jangan berganti-ganti jadi "platform", "sistem", "perangkat lunak", "solusi" demi variasi.

### F.4 Frasa dan Pola yang Dilarang

1. Kata sambung khas AI: akibatnya, selain itu, oleh karena itu, dengan demikian, lebih lanjut, di sisi lain, pada akhirnya, secara keseluruhan, hal ini menunjukkan bahwa, perlu dicatat bahwa, tidak dapat dipungkiri, dalam hal ini.
2. Pembuka bergaya pidato: "Di era digital saat ini", "Seiring perkembangan zaman", "Dalam dunia yang semakin ...".
3. Frasa klise: "memainkan peran penting", "menjadi kunci", "tidak hanya ... tetapi juga ...", "berbagai macam", "memberikan kemudahan bagi pengguna" (tulis kemudahan konkretnya).
4. **Pola tiga serangkai** (A, B, dan C) yang berulang. Kalau memang ada daftar, pakai jumlah yang tidak selalu tiga.
5. **Kalimat ringkasan di akhir paragraf** yang mengulang isi paragraf.
6. Pertanyaan retoris, kata "Nah", dan seruan.
7. Tanda pisah panjang (—).

### F.5 Variasi Pola Paragraf

1. Format "Label: isi" maksimal 1–2 kali di seluruh laporan.
2. Jangan semua paragraf dibuka dengan pola "X adalah ...". Variasikan pembuka: mulai dari contoh, dari masalah, dari fungsi, atau dari hubungan dengan proyek.
3. Jangan pakai struktur yang sama di semua subbab BAB 2.

### F.6 Tulis Ulang dari Nol

1. Kalimat definisi di BAB 2 ditulis dengan susunan sendiri, bukan parafrase tipis dari sumber. Kalimat definisi paling sering ditandai detektor (dan juga Turnitin).
2. Hubungkan teori langsung ke proyek. Contoh: setelah menjelaskan konsep, langsung sebutkan di bagian mana proyek memakainya.
3. Contoh ilustrasi pakai situasi sehari-hari mahasiswa usia 20-an: bayar pakai QRIS, login portal akademik, chat grup WhatsApp, pesan ojek online, antre di loket kampus. Jangan pakai contoh acak yang tidak nyambung.

### F.7 Ketidaksempurnaan Ringan (Sesuai `LEVEL_KETIDAKSEMPURNAAN`)

| Level | Aturan |
|---|---|
| 0 | Tidak ada. Ejaan rapi total. |
| 1 (default) | Sekitar 1 per 2 paragraf: campur "tapi" dan "tetapi", sesekali "karna" di antara "karena", sesekali kata yang lebih santai. |
| 2 | Sekitar 1–2 per paragraf: seperti level 1, ditambah satu typo huruf ringan atau "di" yang terpisah/menyambung kurang tepat. |

Batasan untuk semua level:
1. Hanya di paragraf isi.
2. **Jangan pernah** menyentuh judul, caption, isi tabel, kode, angka, rumus, nama orang, nama teknologi, istilah teknis, sitasi, dan Daftar Pustaka.
3. Jangan menghilangkan spasi sebelum kurung sitasi (sitasi akan diganti Mendeley).
4. Catat semua ketidaksempurnaan yang sengaja dibuat di laporan serah terima, supaya user bisa memutuskan mau dipertahankan atau tidak.

### F.8 Tabel Jadi Paragraf

Informasi pendek yang bisa ditulis sebagai kalimat (perbandingan 2–3 hal, spesifikasi singkat) ditulis sebagai paragraf. List bernomor tetap dipakai untuk langkah berurutan, rumusan masalah, batasan, dan daftar yang memang berupa daftar. Tabel Gantt tetap wajib berupa tabel.

### F.9 Detail Nyata

1. Masukkan detail konkret dari dokumentasi: nama fitur, versi teknologi, jumlah halaman/menu, tanggal pengerjaan, hasil uji (misalnya 18 dari 20 skenario berhasil), kendala nyata dan cara mengatasinya.
2. **Jangan mengarang detail.** Kalau tidak ada, pasang `[ISI: contoh angka hasil uji]` ber-highlight kuning, lalu masukkan ke daftar placeholder.
3. Kalimat yang bisa ditempel ke laporan topik apa saja harus diganti dengan kalimat yang hanya cocok untuk proyek ini.

### F.10 Hal yang Terbukti Menaikkan Skor (Hindari)

1. Semua kalimat dipaksa pendek ditambah "Nah", pertanyaan retoris, dan daftar skor per baris.
2. Teks tanpa variasi dengan banyak kalimat panjang.
3. Menyalin kalimat contoh tulisan manusia apa adanya.
4. Pola yang sama diulang di semua bagian.

---

## G. CONTOH GAYA (ILUSTRASI, JANGAN DISALIN)

Terlalu "AI":
> Di era digital saat ini, keamanan data memainkan peran yang sangat penting dalam berbagai aspek kehidupan. Oleh karena itu, diperlukan sebuah solusi yang komprehensif, efisien, dan andal untuk melindungi data pengguna. Dengan demikian, aplikasi ini diharapkan dapat memberikan kemudahan bagi pengguna.

Lebih natural:
> Banyak mahasiswa menyimpan file tugas di grup WhatsApp angkatan. File itu bisa diunduh siapa saja yang masuk grup, termasuk orang yang sudah tidak aktif kuliah. Kelompok kami membuat aplikasi enkripsi file supaya isi file cuma bisa dibuka orang yang punya kunci. Aplikasi ini memakai AES-256 karena algoritma tersebut sudah jadi standar enkripsi simetris (Stallings, 2020).

---

## H. PEMERIKSAAN WAJIB SEBELUM SERAH TERIMA

Jalankan pemeriksaan otomatis dengan skrip (baca ulang `.docx` hasil, bukan draf), lalu perbaiki semua temuan.

### H.1 Format

1. Ukuran kertas dan margin tiap section sesuai C.1.
2. Semua run teks memakai Times New Roman (kode: Courier New 10pt), semua warna hitam, tidak ada underline.
3. Semua paragraf spacing before/after = 0 (kecuali style TOC 1 sesuai C.15).
4. Heading 1/2/3 dipakai di semua judul BAB/subbab/sub-subbab, tidak ada judul yang diketik sebagai paragraf biasa.
5. Ada field TOC (3 buah: isi, gambar, tabel), field PAGE di header/footer, dan field SEQ di semua caption.
6. Section: cover tanpa nomor, front matter romawi di footer tengah, BAB dan Daftar Pustaka `titlePage` aktif dengan nomor Arab di header kanan, BAB 1 mulai dari 1.
7. Semua list memakai numbering Word, tidak ada bullet, tidak ada nomor yang diketik manual, setiap list restart.
8. Tidak ada teks bold di paragraf isi.
9. Caption tabel di atas rata kiri, caption gambar di bawah rata tengah, nomor sesuai BAB.
10. Tidak ada paragraf isi yang hanya satu kalimat.
11. Konversi ke PDF (Microsoft Word lewat COM kalau tersedia, karena Word sekaligus mengisi TOC; kalau tidak ada, LibreOffice). Hitung otomatis tinggi isi setiap halaman dari PDF: halaman isi yang terisi < 80% dan bukan halaman terakhir sebuah BAB **wajib diperbaiki** (lihat C.10.7). Lalu render beberapa halaman jadi gambar dan periksa visual: cover, Kata Pengantar, halaman pertama BAB, halaman isi, Gantt chart, Daftar Pustaka. Pastikan tidak ada halaman dengan ruang kosong besar di bawah kecuali sebelum BAB baru. (LibreOffice bisa tidak menampilkan isi TOC sebelum di-update; itu normal.)

### H.2 Sitasi (Paling Penting)

1. Ekstrak semua sitasi dari isi dengan regex (bentuk parentetikal dan naratif).
2. Ekstrak semua entri Daftar Pustaka.
3. Cocokkan dua arah:
   1. Setiap sitasi di isi punya entri Daftar Pustaka dengan nama belakang dan tahun identik.
   2. Setiap entri Daftar Pustaka dikutip minimal 1 kali.
4. Cari nama orang/organisasi di isi yang disebut sebagai sumber pendapat tapi tidak ada di Daftar Pustaka.
5. Cocokkan Daftar Pustaka ↔ `.ris` ↔ Tabel Referensi Terverifikasi (judul, penulis, tahun, DOI).
6. Pastikan urutan Daftar Pustaka alfabetis dan link GitHub di baris pertama.
7. Kalau ada ketidakcocokan, **dokumen belum boleh diserahkan**.

### H.3 Gaya Penulisan

1. Hitung panjang setiap kalimat. Tidak boleh ada yang > 30 kata. Laporkan rata-rata dan sebaran per BAB.
2. Scan frasa terlarang di F.4 dan kata megah di F.2. Hasilnya harus nol.
3. Scan tanda "—". Harus nol.
4. Scan kalimat terakhir tiap paragraf: tidak boleh berupa ringkasan yang mengulang paragraf.
5. Cek konsistensi italic istilah asing (istilah yang sama selalu italic atau selalu tidak).
6. Cek angka, nama, versi, dan sitasi tidak berubah dari dokumentasi asli.

---

## I. OUTPUT YANG DISERAHKAN

1. `Laporan_[NamaKelompok].docx`: laporan lengkap.
2. `Referensi_[NamaKelompok]_Mendeley.ris`: file import Mendeley.
3. `Panduan_Mendeley_[NamaKelompok].md`: langkah Mendeley + tabel peta sitasi.
4. `Draft_Isi_[NamaKelompok].md`: isi laporan dalam teks biasa untuk diedit cepat.
5. Pesan serah terima singkat berisi:
   1. Daftar placeholder `[ISI: ...]` dan `[SISIPKAN SCREENSHOT: ...]` beserta lokasinya.
   2. Tabel Referensi Terverifikasi.
   3. Daftar ketidaksempurnaan yang sengaja dibuat (F.7).
   4. Langkah setelah membuka di Word:
      1. Klik "Yes" saat Word menawarkan update field, atau tekan Ctrl+A lalu F9 dan pilih "Update entire table".
      2. Cek Daftar Isi, Daftar Gambar, Daftar Tabel sudah berisi nomor halaman yang benar.
      3. Ganti sitasi dengan Mendeley Cite mengikuti file panduan.
      4. Isi placeholder, lalu tekan F9 sekali lagi.

---

## J. YANG DILAKUKAN USER SETELAH AI SELESAI

1. Baca sendiri, lalu ganti **3–5 kalimat** dengan kata-kata sendiri, terutama kalimat definisi di BAB 2 dan contoh di BAB 1. Ini langkah yang paling berpengaruh.
2. Cek ulang angka, rumus, nama, dan sitasi, karena kadang berubah tanpa sengaja saat menulis ulang.
3. Tes di detektor. Pegang skor persentasenya saja, jangan mengikuti kalimat yang ditandai. Kalau masih tinggi, tulis ulang hanya bagian yang paling bermasalah.
4. Skor rendah di satu detektor tidak menjamin hasil sama di detektor lain.
5. Cek aturan dosen atau kampus soal pemakaian AI, karena aturan itu lebih menentukan daripada skor detektor.

---

## CHECKLIST AKHIR

- [ ] Daftar data kosong sudah dikirim ke user di awal dan jawabannya (isi / skip / nanti) sudah diterapkan
- [ ] Cover: judul kapital 14pt bold 1,15 segitiga terbalik, tabel NAMA/NIM tanpa border, KOM, logo 5 × 5 cm, institusi 13pt bold
- [ ] Nomor halaman: tidak ada di cover, romawi footer tengah di front matter, Arab header kanan di isi, kosong di halaman pertama BAB dan Daftar Pustaka
- [ ] Semua spacing before/after paragraf = 0, jarak dibuat dengan paragraf kosong
- [ ] Judul BAB `BAB X` + line break + JUDUL, Heading 1, lalu 3 spasi
- [ ] Subbab/sub-subbab `X.X[TAB]Judul`, Heading 2/3, tab 1,25 cm, rata kiri, 2 spasi sebelum judul berikutnya
- [ ] Kapitalisasi judul subbab: kata penghubung dan kata depan huruf kecil
- [ ] Paragraf 12pt, 1,5, justify, indent 1,25 cm, minimal 2 kalimat
- [ ] List pakai numbering Word, angka/huruf saja, restart tiap list
- [ ] Gambar: caption bawah tengah; Tabel: caption atas kiri; nomor pakai SEQ sesuai BAB
- [ ] Kode: tabel 1 sel abu-abu, Courier New 10pt, spasi 1,0
- [ ] Gantt chart Tabel 3.1 dengan hari S S R K J S M
- [ ] Daftar Isi field TOC, BAB tanpa nomor halaman, tanpa titik-titik, Ctrl+Klik jalan
- [ ] Daftar Gambar/Tabel field TOC, spasi 1,5
- [ ] Daftar Pustaka: link GitHub pertama, APA 7, alfabetis, justify, hanging 1,25 cm, hitam, tanpa underline
- [ ] Tidak ada halaman isi yang terisi < 80% kecuali halaman terakhir BAB (tabel panjang dan kode boleh berlanjut ke halaman berikutnya)
- [ ] Sitasi isi ↔ Daftar Pustaka ↔ `.ris` cocok 100%, semua referensi terverifikasi nyata
- [ ] Tidak ada kalimat > 30 kata, frasa terlarang, dan em dash
- [ ] Istilah asing italic dan konsisten
- [ ] Semua placeholder dilaporkan ke user
