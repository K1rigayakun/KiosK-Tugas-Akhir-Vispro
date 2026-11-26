Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Model

    Public Class Kategori
        Public Property IdKategori As Integer
        Public Property Nama As String = ""
        Public Property Urutan As Integer
    End Class

    Public Class Produk
        Public Property IdProduk As Integer
        Public Property IdKategori As Integer
        Public Property NamaKategori As String = ""
        Public Property Nama As String = ""
        Public Property Deskripsi As String = ""
        Public Property Harga As Decimal
        Public Property Gambar As String = ""
        Public Property Tersedia As Boolean = True
        Public Property BestSeller As Boolean = False
        Public Property Stok As Integer? = Nothing
        Public Property DibuatPada As DateTime = DateTime.Now
    End Class

    Public Class OpsiProduk
        Public Property IdOpsi As Integer
        Public Property IdProduk As Integer
        Public Property NamaOpsi As String = ""
        Public Property Tipe As String = TipeOpsi.Ukuran
        Public Property TambahanHarga As Decimal
    End Class

    Public Class ItemKeranjang
        Public Property Kunci As String = ""
        Public Property IdProduk As Integer
        Public Property NamaProduk As String = ""
        Public Property Gambar As String = ""
        Public Property HargaDasar As Decimal
        Public Property TambahanOpsi As Decimal
        Public Property OpsiDipilih As String = ""
        Public Property Catatan As String = ""
        Public Property Qty As Integer

        Public ReadOnly Property HargaSatuan As Decimal
            Get
                Return HargaDasar + TambahanOpsi
            End Get
        End Property

        Public ReadOnly Property SubtotalItem As Decimal
            Get
                Return HargaSatuan * Qty
            End Get
        End Property
    End Class

    Public Class Pengguna
        Public Property IdPengguna As Integer
        Public Property Username As String = ""
        Public Property PasswordHash As String = ""
        Public Property Nama As String = ""
        Public Property Peran As String = Model.Peran.Kasir
        Public Property Role As String
            Get
                Return Peran
            End Get
            Set(value As String)
                Peran = If(value, Model.Peran.Kasir)
            End Set
        End Property
        Public Property Aktif As Boolean = True
    End Class

    Public Class Voucher
        Public Property IdVoucher As Integer
        Public Property Kode As String = ""
        Public Property Jenis As String = JenisVoucher.Persen
        Public Property Nilai As Decimal
        Public Property MinBelanja As Decimal
        Public Property TglMulai As DateTime
        Public Property TglAkhir As DateTime
        Public Property Aktif As Boolean = True
    End Class

    Public Class Member
        Public Property IdMember As Integer
        Public Property NoHp As String = ""
        Public Property Nama As String = ""
        Public Property Poin As Integer
    End Class

    Public Class RincianHarga
        Public Property Subtotal As Decimal
        Public Property DiskonBertingkat As Decimal
        Public Property DiskonVoucher As Decimal
        Public Property DiskonPoin As Decimal
        Public Property PersenPajak As Decimal
        Public Property Pajak As Decimal
        Public Property BiayaLayanan As Decimal
        Public Property Total As Decimal
        Public Property KodeVoucher As String = ""
        Public Property PoinDipakai As Integer
        Public Property PoinDidapat As Integer

        Public ReadOnly Property Diskon As Decimal
            Get
                Return TotalDiskon
            End Get
        End Property

        Public ReadOnly Property TotalDiskon As Decimal
            Get
                Dim gabungan As Decimal = DiskonBertingkat + DiskonVoucher + DiskonPoin
                Dim maksDiskon As Decimal = Math.Floor(Subtotal * 0.5D)
                Return Math.Min(gabungan, maksDiskon)
            End Get
        End Property
    End Class

    Public Class HasilVoucher
        Public Property Valid As Boolean
        Public Property Pesan As String = ""
        Public Property Voucher As Voucher
        Public Property Diskon As Decimal
    End Class

    Public Class HasilPesanan
        Public Property Berhasil As Boolean = True
        Public Property IdPesanan As Integer
        Public Property NoAntrian As Integer
        Public Property KodePesanan As String = ""
        Public Property Pesan As String = ""
    End Class

    Public Class BannerPromo
        Public Property IdBanner As Integer
        Public Property Judul As String = ""
        Public Property Subjudul As String = ""
        Public Property Gambar As String = ""
        Public Property Urutan As Integer
        Public Property Aktif As Boolean = True
    End Class

    Public Class PesananData
        Public Property IdPesanan As Integer
        Public Property NoAntrian As Integer
        Public Property TipeMakan As String = Model.TipeMakan.DineIn
        Public Property Tanggal As DateTime
        Public Property Subtotal As Decimal
        Public Property Diskon As Decimal
        Public Property Pajak As Decimal
        Public Property Total As Decimal
        Public Property MetodeBayar As String = Model.MetodeBayar.Tunai
        Public Property StatusBayar As String = Model.StatusBayar.Belum
        Public Property StatusPesanan As String = Model.StatusPesanan.MenungguPembayaran
        Public Property IdKasir As Integer?
        Public Property KodeVoucher As String = ""
        Public Property IdMember As Integer?
        Public Property PoinDipakai As Integer
        Public Property PoinDidapat As Integer
        Public Property UangBayar As Decimal?
        Public Property Kembalian As Decimal?
        Public Property WaktuDiproses As DateTime?
        Public Property WaktuSiap As DateTime?
    End Class

    Public Class DetailPesananData
        Public Property IdDetail As Integer
        Public Property IdPesanan As Integer
        Public Property IdProduk As Integer
        Public Property NamaProduk As String = ""
        Public Property Qty As Integer
        Public Property HargaSatuan As Decimal
        Public Property OpsiDipilih As String = ""
        Public Property Catatan As String = ""
        Public Property Subtotal As Decimal
    End Class

    Public Class LogAktivitasData
        Public Property IdLog As Long
        Public Property Waktu As DateTime
        Public Property IdPengguna As Integer?
        Public Property NamaPengguna As String = ""
        Public Property Aksi As String = ""
        Public Property Keterangan As String = ""
    End Class

    Public Class RatingPesananData
        Public Property IdPesanan As Integer
        Public Property Bintang As Integer
        Public Property Komentar As String = ""
    End Class

    Public Class RingkasanDashboard
        Public Property PendapatanHariIni As Decimal
        Public Property JumlahPesananHariIni As Integer
        Public Property RataRataOrder As Decimal
        Public Property PesananDibatalkan As Integer
        Public Property ProdukStokMenipis As Integer
    End Class

    Public Class GrafikTitik
        Public Property Label As String = ""
        Public Property Nilai As Decimal
        Public Property Keterangan As String = ""
    End Class

End Namespace
