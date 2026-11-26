Option Strict On
Option Explicit On

Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModKeranjang

        Private ReadOnly _items As New Dictionary(Of String, ItemKeranjang)(StringComparer.Ordinal)

        Public Property TipeMakan As String = Model.TipeMakan.DineIn
        Public Property KodeVoucherAktif As String = ""
        Public Property MemberAktif As Member = Nothing
        Public Property PoinDipakaiAktif As Integer = 0

        Public Event KeranjangBerubah()

        Public Function Isi() As List(Of ItemKeranjang)
            Return _items.Values.Select(Function(x) New ItemKeranjang With {
                .Kunci = x.Kunci,
                .IdProduk = x.IdProduk,
                .NamaProduk = x.NamaProduk,
                .Gambar = x.Gambar,
                .HargaDasar = x.HargaDasar,
                .TambahanOpsi = x.TambahanOpsi,
                .OpsiDipilih = x.OpsiDipilih,
                .Catatan = x.Catatan,
                .Qty = x.Qty
            }).ToList()
        End Function

        Public Sub Tambah(item As ItemKeranjang)
            If item Is Nothing OrElse item.Qty <= 0 Then Return
            If String.IsNullOrWhiteSpace(item.Kunci) Then
                item.Kunci = $"{item.IdProduk}|{item.OpsiDipilih}|{item.Catatan}"
            End If

            Dim existing As ItemKeranjang = Nothing
            If _items.TryGetValue(item.Kunci, existing) Then
                existing.Qty = Math.Min(20, existing.Qty + item.Qty)
            Else
                item.Qty = Math.Min(20, item.Qty)
                _items(item.Kunci) = item
            End If
            RaiseEvent KeranjangBerubah()
        End Sub

        Public Sub UbahQty(kunci As String, qtyBaru As Integer)
            Dim existing As ItemKeranjang = Nothing
            If Not _items.TryGetValue(kunci, existing) Then Return
            If qtyBaru <= 0 Then
                _items.Remove(kunci)
            Else
                existing.Qty = Math.Min(20, qtyBaru)
            End If
            RaiseEvent KeranjangBerubah()
        End Sub

        Public Sub Hapus(kunci As String)
            If _items.Remove(kunci) Then
                RaiseEvent KeranjangBerubah()
            End If
        End Sub

        Public Sub Kosongkan()
            _items.Clear()
            KodeVoucherAktif = ""
            MemberAktif = Nothing
            PoinDipakaiAktif = 0
            RaiseEvent KeranjangBerubah()
        End Sub

        Public Function JumlahItem() As Integer
            Return _items.Values.Sum(Function(x) x.Qty)
        End Function

        Public Function Subtotal() As Decimal
            Return _items.Values.Sum(Function(x) x.SubtotalItem)
        End Function

        ''' <summary>
        ''' Mengisi keranjang dengan data demo untuk pengujian alur checkout.
        ''' Jika koneksi live aktif, cari produk berdasarkan nama atau ambil 2 produk pertama yang tersedia.
        ''' </summary>
        Public Sub IsiContohDemo()
            ModDummyStore.PastikanInit()
            _items.Clear()

            ' Default: ID dari dummy store
            Dim id1 As Integer = 1
            Dim nama1 As String = "Paket Hemat Bistro 1"
            Dim harga1 As Decimal = 42000D
            Dim gambar1 As String = "paket_combo.jpg"

            Dim id2 As Integer = 9
            Dim nama2 As String = "Double Smash Beef Burger"
            Dim harga2 As Decimal = 46000D
            Dim gambar2 As String = "burger_beef.jpg"

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Dim dt = ModProduk.AmbilProduk(0)
                    ' Kandidat nama untuk produk paket (live DB pakai "Paket Hemat 1")
                    Dim kandidatPaket As String() = {"Paket Hemat Bistro 1", "Paket Hemat 1", "Paket Hemat"}
                    Dim kandidatBurger As String() = {"Double Smash Beef Burger", "Double Smash Burger", "Classic Burger", "Burger"}

                    Dim found1 As Boolean = False
                    Dim found2 As Boolean = False
                    Dim firstAvailableId As Integer = -1
                    Dim secondAvailableId As Integer = -1
                    Dim availableCount As Integer = 0

                    For Each r As DataRow In dt.Rows
                        Dim nm As String = CStr(r("nama")).Trim()
                        Dim pid As Integer = CInt(r("id_produk"))
                        Dim pharga As Decimal = CDec(r("harga"))
                        ' Kolom gambar di DataTable dari AmbilProdukLive adalah "gambar" (bukan "gambar_url")
                        Dim pgambar As String = ""
                        If dt.Columns.Contains("gambar") AndAlso Not IsDBNull(r("gambar")) Then
                            pgambar = CStr(r("gambar"))
                        ElseIf dt.Columns.Contains("gambar_url") AndAlso Not IsDBNull(r("gambar_url")) Then
                            pgambar = CStr(r("gambar_url"))
                        End If

                        ' Kumpul 2 produk tersedia pertama sebagai fallback
                        availableCount += 1
                        If availableCount = 1 Then firstAvailableId = pid
                        If availableCount = 2 Then secondAvailableId = pid

                        ' Cocokkan kandidat paket
                        If Not found1 Then
                            For Each kand As String In kandidatPaket
                                If nm.StartsWith(kand, StringComparison.OrdinalIgnoreCase) Then
                                    id1 = pid : nama1 = nm : harga1 = pharga
                                    If pgambar.Length > 0 Then gambar1 = pgambar
                                    found1 = True
                                    Exit For
                                End If
                            Next
                        End If

                        ' Cocokkan kandidat burger
                        If Not found2 Then
                            For Each kand As String In kandidatBurger
                                If nm.IndexOf(kand, StringComparison.OrdinalIgnoreCase) >= 0 Then
                                    id2 = pid : nama2 = nm : harga2 = pharga
                                    If pgambar.Length > 0 Then gambar2 = pgambar
                                    found2 = True
                                    Exit For
                                End If
                            Next
                        End If

                        If found1 AndAlso found2 Then Exit For
                    Next

                    ' Fallback: gunakan 2 produk pertama yang tersedia
                    If Not found1 AndAlso firstAvailableId > 0 Then id1 = firstAvailableId
                    If Not found2 AndAlso secondAvailableId > 0 AndAlso secondAvailableId <> id1 Then
                        id2 = secondAvailableId
                    ElseIf Not found2 AndAlso firstAvailableId > 0 Then
                        id2 = firstAvailableId
                    End If
                Catch
                    ' Biarkan fallback ke ID dummy store (1 dan 9)
                End Try
            End If

            Tambah(New ItemKeranjang With {
                .Kunci = $"{id1}|Regular, Pedas Sedang (1)|",
                .IdProduk = id1,
                .NamaProduk = nama1,
                .Gambar = gambar1,
                .HargaDasar = harga1,
                .TambahanOpsi = 0D,
                .OpsiDipilih = "Regular, Pedas Sedang (1)",
                .Catatan = "",
                .Qty = 1
            })
            Tambah(New ItemKeranjang With {
                .Kunci = $"{id2}|Ekstra Keju Cheddar|Tanpa acar",
                .IdProduk = id2,
                .NamaProduk = nama2,
                .Gambar = gambar2,
                .HargaDasar = harga2,
                .TambahanOpsi = 3000D,
                .OpsiDipilih = "Ekstra Keju Cheddar",
                .Catatan = "Tanpa acar",
                .Qty = 1
            })
        End Sub

    End Module
End Namespace

