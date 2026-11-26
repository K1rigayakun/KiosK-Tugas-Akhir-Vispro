Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModBahasa

        Private _bahasa As String = "ID"
        Public Event BahasaBerubah()

        Private ReadOnly _idDict As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
            {"welcome_tagline", "Rasa Hangat, Pesan Cepat Tanpa Antre"},
            {"welcome_sub", "Pilih cara bersantap Anda untuk mulai memesan"},
            {"dine_in", "Makan di Tempat"},
            {"dine_in_sub", "Disajikan hangat di meja"},
            {"take_away", "Bawa Pulang"},
            {"take_away_sub", "Kemasan praktis siap bawa"},
            {"promo_badge", "PROMO HARI INI"},
            {"semua_kategori", "Semua Menu"},
            {"cari_placeholder", "Cari ayam, burger, kopi, atau paket..."},
            {"batal_pesanan", "Batal Pesanan"},
            {"lihat_keranjang", "Lihat Keranjang"},
            {"item_dipilih", "item"},
            {"habis", "HABIS"},
            {"best_seller", "BEST SELLER"},
            {"tambah_keranjang", "Tambah ke Keranjang"},
            {"batal", "Batal"},
            {"ukuran", "Pilih Ukuran"},
            {"addon", "Tambahan (Add-on)"},
            {"pedas", "Level Pedas"},
            {"catatan", "Catatan Khusus"},
            {"jumlah", "Jumlah"},
            {"keranjang_judul", "Keranjang Pesanan"},
            {"lanjut_bayar", "Lanjut Bayar"},
            {"kembali_menu", "Kembali ke Menu"},
            {"upsell_judul", "Lengkapi Pesananmu dengan Minuman atau Camilan!"},
            {"lewati", "Lewati"},
            {"idle_judul", "Apakah Anda masih di sana?"},
            {"idle_lanjut", "Lanjutkan Pesanan"},
            {"rating_judul", "Bagaimana Pengalaman Pesan Anda?"}
        }

        Private ReadOnly _enDict As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
            {"welcome_tagline", "Warm Flavors, Fast Self-Order"},
            {"welcome_sub", "Choose how you would like to dine today"},
            {"dine_in", "Dine In"},
            {"dine_in_sub", "Served warm and fresh at your table"},
            {"take_away", "Take Away"},
            {"take_away_sub", "Packed neatly ready to go"},
            {"promo_badge", "TODAY'S SPECIAL"},
            {"semua_kategori", "All Menu"},
            {"cari_placeholder", "Search chicken, burgers, coffee, or combos..."},
            {"batal_pesanan", "Cancel Order"},
            {"lihat_keranjang", "View Cart"},
            {"item_dipilih", "items"},
            {"habis", "SOLD OUT"},
            {"best_seller", "BEST SELLER"},
            {"tambah_keranjang", "Add to Cart"},
            {"batal", "Cancel"},
            {"ukuran", "Select Size"},
            {"addon", "Add-ons"},
            {"pedas", "Spice Level"},
            {"catatan", "Special Notes"},
            {"jumlah", "Quantity"},
            {"keranjang_judul", "Your Order Cart"},
            {"lanjut_bayar", "Proceed to Payment"},
            {"kembali_menu", "Back to Menu"},
            {"upsell_judul", "Complete Your Meal with Drinks or Sides!"},
            {"lewati", "Skip"},
            {"idle_judul", "Are you still there?"},
            {"idle_lanjut", "Continue Order"},
            {"rating_judul", "How Was Your Ordering Experience?"}
        }

        Public Property Bahasa As String
            Get
                Return _bahasa
            End Get
            Set(value As String)
                Dim norm As String = If(String.Equals(value, "EN", StringComparison.OrdinalIgnoreCase), "EN", "ID")
                If _bahasa <> norm Then
                    _bahasa = norm
                    RaiseEvent BahasaBerubah()
                End If
            End Set
        End Property

        Public Function T(kunci As String) As String
            Dim dict = If(_bahasa = "EN", _enDict, _idDict)
            Dim val As String = ""
            If dict.TryGetValue(kunci, val) Then Return val
            Return kunci
        End Function

    End Module
End Namespace

