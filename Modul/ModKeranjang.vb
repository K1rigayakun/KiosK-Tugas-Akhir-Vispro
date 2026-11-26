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

        Public Sub IsiContohDemo()
            ModDummyStore.PastikanInit()
            _items.Clear()

            Dim id1 As Integer = 1
            Dim id2 As Integer = 9
            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Dim dt = ModProduk.AmbilProduk(0)
                    For Each r As DataRow In dt.Rows
                        Dim nm = CStr(r("nama"))
                        If String.Equals(nm, "Paket Hemat Bistro 1", StringComparison.OrdinalIgnoreCase) Then
                            id1 = CInt(r("id_produk"))
                        ElseIf String.Equals(nm, "Double Smash Beef Burger", StringComparison.OrdinalIgnoreCase) Then
                            id2 = CInt(r("id_produk"))
                        End If
                    Next
                Catch
                End Try
            End If

            Tambah(New ItemKeranjang With {
                .Kunci = $"{id1}|Regular, Pedas Sedang (1)|",
                .IdProduk = id1,
                .NamaProduk = "Paket Hemat Bistro 1",
                .Gambar = "paket1.jpg",
                .HargaDasar = 42000D,
                .TambahanOpsi = 0D,
                .OpsiDipilih = "Regular, Pedas Sedang (1)",
                .Catatan = "",
                .Qty = 1
            })
            Tambah(New ItemKeranjang With {
                .Kunci = $"{id2}|Ekstra Keju Cheddar|Tanpa acar",
                .IdProduk = id2,
                .NamaProduk = "Double Smash Beef Burger",
                .Gambar = "burger1.jpg",
                .HargaDasar = 46000D,
                .TambahanOpsi = 3000D,
                .OpsiDipilih = "Ekstra Keju Cheddar",
                .Catatan = "Tanpa acar",
                .Qty = 1
            })
        End Sub

    End Module
End Namespace

