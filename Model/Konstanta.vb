Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Model

    Public Class StatusPesanan
        Public Const MenungguPembayaran As String = "Menunggu Pembayaran"
        Public Const Diproses As String = "Diproses"
        Public Const Siap As String = "Siap"
        Public Const Selesai As String = "Selesai"
        Public Const Dibatalkan As String = "Dibatalkan"
    End Class

    Public Class StatusBayar
        Public Const Belum As String = "Belum"
        Public Const Lunas As String = "Lunas"
    End Class

    Public Class MetodeBayar
        Public Const Tunai As String = "Tunai"
        Public Const Qris As String = "QRIS"
        Public Const Kartu As String = "Kartu"
        Public Const EWallet As String = "E-Wallet"
    End Class

    Public Class TipeMakan
        Public Const DineIn As String = "Dine In"
        Public Const TakeAway As String = "Take Away"
    End Class

    Public Class Peran
        Public Const Admin As String = "Admin"
        Public Const Kasir As String = "Kasir"
    End Class

    Public Class TipeOpsi
        Public Const Ukuran As String = "Ukuran"
        Public Const Addon As String = "Addon"
        Public Const Pedas As String = "Pedas"
    End Class

    Public Class JenisVoucher
        Public Const Persen As String = "Persen"
        Public Const Nominal As String = "Nominal"
    End Class

    Public Class KodeAksi
        Public Const Login As String = "LOGIN"
        Public Const Logout As String = "LOGOUT"
        Public Const LoginGagal As String = "LOGIN_GAGAL"
        Public Const BayarTunai As String = "BAYAR_TUNAI"
        Public Const PesananBatal As String = "PESANAN_BATAL"
        Public Const StatusUbah As String = "STATUS_UBAH"
        Public Const ProdukTambah As String = "PRODUK_TAMBAH"
        Public Const ProdukUbah As String = "PRODUK_UBAH"
        Public Const ProdukHapus As String = "PRODUK_HAPUS"
        Public Const PenggunaUbah As String = "PENGGUNA_UBAH"
        Public Const VoucherUbah As String = "VOUCHER_UBAH"
        Public Const MemberUbah As String = "MEMBER_UBAH"
        Public Const PengaturanUbah As String = "PENGATURAN_UBAH"
    End Class

    ''' <summary>
    ''' Konstanta kompatibilitas Modul A1 (KioskResto).
    ''' </summary>
    Public Module ModKonstanta
        Public Const ROLE_ADMIN As String = "Admin"
        Public Const ROLE_KASIR As String = "Kasir"

        Public Const STATUS_MENUNGGU As String = "Menunggu"
        Public Const STATUS_DIPROSES As String = "Diproses"
        Public Const STATUS_SIAP As String = "Siap"
        Public Const STATUS_SELESAI As String = "Selesai"
        Public Const STATUS_DIBATALKAN As String = "Dibatalkan"

        Public Const BAYAR_TUNAI As String = "Tunai"
        Public Const BAYAR_QRIS As String = "QRIS"
        Public Const BAYAR_TRANSFER As String = "Transfer"

        Public Const JENIS_DINE_IN As String = "Dine In"
        Public Const JENIS_TAKE_AWAY As String = "Take Away"

        Public Const OPSI_UKURAN As String = "Ukuran"
        Public Const OPSI_ADDON As String = "Addon"
        Public Const OPSI_PEDAS As String = "Pedas"

        Public Const VOUCHER_PERSEN As String = "Persen"
        Public Const VOUCHER_NOMINAL As String = "Nominal"

        Public Const PEMBAYARAN_BELUM As String = "Belum Bayar"
        Public Const PEMBAYARAN_LUNAS As String = "Lunas"
        Public Const PEMBAYARAN_GAGAL As String = "Gagal"
    End Module

End Namespace

