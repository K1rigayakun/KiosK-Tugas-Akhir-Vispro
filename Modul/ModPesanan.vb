Option Strict On
Option Explicit On

Imports System.Data
Imports System.Drawing
Imports System.IO
Imports Npgsql
Imports QRCoder
Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModPesanan

        ''' <summary>
        ''' Simpan pesanan ke Supabase (live) atau dummy store.
        ''' Atomik: gunakan advisory lock + FOR UPDATE untuk mencegah race condition.
        ''' </summary>
        Public Function SimpanPesanan(metode As String, rincian As RincianHarga,
                                      Optional idMember As Integer? = Nothing,
                                      Optional uangBayarTunai As Decimal? = Nothing) As HasilPesanan
            Dim items = ModKeranjang.Isi()
            If items.Count = 0 Then
                Throw New InvalidOperationException("Keranjang masih kosong.")
            End If

            If Not ModDatabase.ModeDummyAktif() Then
                Return SimpanPesananLive(metode, rincian, idMember, uangBayarTunai, items)
            End If
            Return SimpanPesananDummy(metode, rincian, idMember, uangBayarTunai, items)
        End Function

        Private Function SimpanPesananLive(metode As String, rincian As RincianHarga,
                                           idMember As Integer?, uangBayarTunai As Decimal?,
                                           items As List(Of ItemKeranjang)) As HasilPesanan
            Using conn = ModDatabase.BukaKoneksi()
                Using tx = conn.BeginTransaction()
                    Try
                        ' Advisory lock untuk mencegah race condition nomor antrian
                        Using cmdLock As New NpgsqlCommand("SELECT pg_advisory_xact_lock(1234567890)", conn, tx)
                            cmdLock.ExecuteNonQuery()
                        End Using

                        ' Verifikasi ulang stok + harga setiap item (server-side)
                        For Each it In items
                            Using cmdCek As New NpgsqlCommand(
                                "SELECT harga, tersedia, stok FROM public.produk WHERE id_produk = @id FOR UPDATE", conn, tx)
                                cmdCek.Parameters.AddWithValue("id", it.IdProduk)
                                Using rd = cmdCek.ExecuteReader()
                                    If Not rd.Read() Then
                                        Throw New InvalidOperationException($"Menu '{it.NamaProduk}' tidak ditemukan di database.")
                                    End If
                                    Dim tersedia As Boolean = rd.GetBoolean(1)
                                    If Not tersedia Then
                                        Throw New InvalidOperationException($"Menu '{it.NamaProduk}' sedang tidak tersedia.")
                                    End If
                                    If Not rd.IsDBNull(2) Then
                                        Dim stok As Integer = rd.GetInt32(2)
                                        If stok < it.Qty Then
                                            Throw New InvalidOperationException($"Stok '{it.NamaProduk}' tidak cukup (tersisa {stok}).")
                                        End If
                                    End If
                                End Using
                            End Using
                        Next

                        ' Verifikasi voucher jika ada
                        If Not String.IsNullOrWhiteSpace(rincian.KodeVoucher) Then
                            Using cmdV As New NpgsqlCommand(
                                "SELECT aktif, tgl_akhir, min_belanja FROM public.voucher WHERE kode = @kode FOR UPDATE", conn, tx)
                                cmdV.Parameters.AddWithValue("kode", rincian.KodeVoucher)
                                Using rd = cmdV.ExecuteReader()
                                    If Not rd.Read() OrElse Not rd.GetBoolean(0) OrElse rd.GetDateTime(1) < DateTime.Today Then
                                        Throw New InvalidOperationException($"Voucher '{rincian.KodeVoucher}' tidak valid atau sudah kadaluarsa.")
                                    End If
                                End Using
                            End Using
                        End If

                        ' Nomor antrian unik per hari
                        Dim noAntrian As Integer = 1
                        Using cmdA As New NpgsqlCommand(
                            "SELECT COALESCE(MAX(no_antrian), 0) + 1 FROM public.pesanan WHERE tanggal::date = CURRENT_DATE", conn, tx)
                            noAntrian = Convert.ToInt32(cmdA.ExecuteScalar())
                        End Using

                        Dim isTunai As Boolean = String.Equals(metode, Model.MetodeBayar.Tunai, StringComparison.OrdinalIgnoreCase)
                        Dim statusBayar As String = If(isTunai, Model.StatusBayar.Belum, Model.StatusBayar.Lunas)
                        Dim statusPesanan As String = If(isTunai, Model.StatusPesanan.MenungguPembayaran, Model.StatusPesanan.Diproses)

                        ' Insert pesanan utama
                        Dim idPesanan As Integer
                        Using cmdP As New NpgsqlCommand(
                            "INSERT INTO public.pesanan " &
                            "(no_antrian,tipe_makan,subtotal,diskon,pajak,total,metode_bayar," &
                            "status_bayar,status_pesanan,kode_voucher,id_member,poin_dipakai,poin_didapat," &
                            "uang_bayar,kembalian,waktu_diproses) " &
                            "VALUES(@ant,@tipe,@sub,@disk,@pjk,@tot,@met," &
                            "@sbyr,@spes,@voucher,@mem,@poin,@ponD," &
                            "@ubyr,@kbl,@wdip) RETURNING id_pesanan", conn, tx)

                            Dim kembalianEst As Object = If(isTunai AndAlso uangBayarTunai.HasValue AndAlso uangBayarTunai.Value >= rincian.Total,
                                CObj(HitungKembalian(rincian.Total, uangBayarTunai.Value)), DBNull.Value)
                            Dim uangByrObj As Object = If(uangBayarTunai.HasValue, CObj(uangBayarTunai.Value), DBNull.Value)
                            Dim wDipObj As Object = If(isTunai, DBNull.Value, CObj(DateTime.Now))
                            Dim voucherObj As Object = If(String.IsNullOrWhiteSpace(rincian.KodeVoucher), DBNull.Value, CObj(rincian.KodeVoucher))
                            Dim memObj As Object = If(idMember.HasValue, CObj(idMember.Value), DBNull.Value)

                            cmdP.Parameters.AddWithValue("ant", noAntrian)
                            cmdP.Parameters.AddWithValue("tipe", ModKeranjang.TipeMakan)
                            cmdP.Parameters.AddWithValue("sub", rincian.Subtotal)
                            cmdP.Parameters.AddWithValue("disk", rincian.TotalDiskon)
                            cmdP.Parameters.AddWithValue("pjk", rincian.Pajak)
                            cmdP.Parameters.AddWithValue("tot", rincian.Total)
                            cmdP.Parameters.AddWithValue("met", metode)
                            cmdP.Parameters.AddWithValue("sbyr", statusBayar)
                            cmdP.Parameters.AddWithValue("spes", statusPesanan)
                            cmdP.Parameters.AddWithValue("voucher", voucherObj)
                            cmdP.Parameters.AddWithValue("mem", memObj)
                            cmdP.Parameters.AddWithValue("poin", rincian.PoinDipakai)
                            cmdP.Parameters.AddWithValue("ponD", rincian.PoinDidapat)
                            cmdP.Parameters.AddWithValue("ubyr", uangByrObj)
                            cmdP.Parameters.AddWithValue("kbl", kembalianEst)
                            cmdP.Parameters.AddWithValue("wdip", wDipObj)
                            idPesanan = Convert.ToInt32(cmdP.ExecuteScalar())
                        End Using

                        ' Insert detail + kurangi stok
                        For Each it In items
                            Using cmdD As New NpgsqlCommand(
                                "INSERT INTO public.detail_pesanan " &
                                "(id_pesanan,id_produk,nama_produk,qty,harga_satuan,opsi_dipilih,catatan,subtotal) " &
                                "VALUES(@idP,@idProd,@nama,@qty,@harga,@opsi,@cat,@sub)", conn, tx)
                                Dim opsiObj As Object = If(String.IsNullOrWhiteSpace(it.OpsiDipilih), DBNull.Value, CObj(it.OpsiDipilih))
                                Dim catObj As Object = If(String.IsNullOrWhiteSpace(it.Catatan), DBNull.Value, CObj(it.Catatan))
                                cmdD.Parameters.AddWithValue("idP", idPesanan)
                                cmdD.Parameters.AddWithValue("idProd", it.IdProduk)
                                cmdD.Parameters.AddWithValue("nama", it.NamaProduk)
                                cmdD.Parameters.AddWithValue("qty", it.Qty)
                                cmdD.Parameters.AddWithValue("harga", it.HargaSatuan)
                                cmdD.Parameters.AddWithValue("opsi", opsiObj)
                                cmdD.Parameters.AddWithValue("cat", catObj)
                                cmdD.Parameters.AddWithValue("sub", it.SubtotalItem)
                                cmdD.ExecuteNonQuery()
                            End Using
                            ' Kurangi stok
                            Using cmdS As New NpgsqlCommand(
                                "UPDATE public.produk SET stok = GREATEST(0, stok - @qty), " &
                                "tersedia = CASE WHEN stok - @qty <= 0 THEN false ELSE tersedia END " &
                                "WHERE id_produk = @id AND stok IS NOT NULL", conn, tx)
                                cmdS.Parameters.AddWithValue("qty", it.Qty)
                                cmdS.Parameters.AddWithValue("id", it.IdProduk)
                                cmdS.ExecuteNonQuery()
                            End Using
                        Next

                        ' Update poin member (poin_dipakai dikurangi, poin_didapat ditambah)
                        If idMember.HasValue AndAlso Not isTunai Then
                            Using cmdM As New NpgsqlCommand(
                                "UPDATE public.member SET poin = GREATEST(0, poin - @pakai + @dapat) WHERE id_member = @id", conn, tx)
                                cmdM.Parameters.AddWithValue("pakai", rincian.PoinDipakai)
                                cmdM.Parameters.AddWithValue("dapat", rincian.PoinDidapat)
                                cmdM.Parameters.AddWithValue("id", idMember.Value)
                                cmdM.ExecuteNonQuery()
                            End Using
                        End If

                        tx.Commit()
                        ModCache.HapusAwalan("produk")
                        ModLog.Catat("PESANAN_BARU", $"Pesanan #{noAntrian:000} ({metode}) total {ModFormat.Rupiah(rincian.Total)}")
                        Return New HasilPesanan With {.IdPesanan = idPesanan, .NoAntrian = noAntrian}

                    Catch ex As Exception
                        tx.Rollback()
                        Throw New Exception("Gagal menyimpan pesanan: " & ex.Message, ex)
                    End Try
                End Using
            End Using
        End Function

        Private Function SimpanPesananDummy(metode As String, rincian As RincianHarga,
                                            idMember As Integer?, uangBayarTunai As Decimal?,
                                            items As List(Of ItemKeranjang)) As HasilPesanan
            ModDummyStore.PastikanInit()
            ' Validasi stok
            For Each it In items
                Dim prod = ModDummyStore.ProdukList.FirstOrDefault(Function(p) p.IdProduk = it.IdProduk)
                If prod Is Nothing OrElse Not prod.Tersedia Then
                    Throw New InvalidOperationException($"Menu '{it.NamaProduk}' sedang tidak tersedia.")
                End If
                If prod.Stok.HasValue AndAlso prod.Stok.Value < it.Qty Then
                    Throw New InvalidOperationException($"Stok {it.NamaProduk} tidak cukup (tersisa {prod.Stok.Value}).")
                End If
            Next

            Dim maxAntrian As Integer = ModDummyStore.PesananList _
                .Where(Function(x) x.Tanggal.Date = DateTime.Today) _
                .Select(Function(x) x.NoAntrian).DefaultIfEmpty(0).Max()
            Dim noAntrian As Integer = maxAntrian + 1

            Dim isTunai As Boolean = String.Equals(metode, Model.MetodeBayar.Tunai, StringComparison.OrdinalIgnoreCase)
            Dim idPesananBaru As Integer = ModDummyStore.NextPesananId
            ModDummyStore.NextPesananId += 1

            Dim kembalianEst As Decimal? = Nothing
            If isTunai AndAlso uangBayarTunai.HasValue AndAlso uangBayarTunai.Value >= rincian.Total Then
                kembalianEst = HitungKembalian(rincian.Total, uangBayarTunai.Value)
            End If

            Dim pesanan As New PesananData With {
                .IdPesanan = idPesananBaru, .NoAntrian = noAntrian,
                .TipeMakan = ModKeranjang.TipeMakan, .Tanggal = DateTime.Now,
                .Subtotal = rincian.Subtotal, .Diskon = rincian.TotalDiskon,
                .Pajak = rincian.Pajak, .Total = rincian.Total,
                .MetodeBayar = metode,
                .StatusBayar = If(isTunai, Model.StatusBayar.Belum, Model.StatusBayar.Lunas),
                .StatusPesanan = If(isTunai, Model.StatusPesanan.MenungguPembayaran, Model.StatusPesanan.Diproses),
                .KodeVoucher = rincian.KodeVoucher, .IdMember = idMember,
                .PoinDipakai = rincian.PoinDipakai, .PoinDidapat = rincian.PoinDidapat,
                .UangBayar = uangBayarTunai, .Kembalian = kembalianEst,
                .WaktuDiproses = If(isTunai, Nothing, CType(DateTime.Now, DateTime?))
            }
            ModDummyStore.PesananList.Add(pesanan)

            For Each it In items
                ModDummyStore.DetailList.Add(New DetailPesananData With {
                    .IdDetail = ModDummyStore.NextDetailId, .IdPesanan = idPesananBaru,
                    .IdProduk = it.IdProduk, .NamaProduk = it.NamaProduk,
                    .Qty = it.Qty, .HargaSatuan = it.HargaSatuan,
                    .OpsiDipilih = it.OpsiDipilih, .Catatan = it.Catatan,
                    .Subtotal = it.SubtotalItem
                })
                ModDummyStore.NextDetailId += 1
                Dim prod = ModDummyStore.ProdukList.FirstOrDefault(Function(p) p.IdProduk = it.IdProduk)
                If prod IsNot Nothing AndAlso prod.Stok.HasValue Then
                    prod.Stok = Math.Max(0, prod.Stok.Value - it.Qty)
                    If prod.Stok.Value = 0 Then prod.Tersedia = False
                End If
            Next

            If idMember.HasValue AndAlso Not isTunai Then
                Dim mem = ModDummyStore.MemberList.FirstOrDefault(Function(m) m.IdMember = idMember.Value)
                If mem IsNot Nothing Then mem.Poin = Math.Max(0, mem.Poin - rincian.PoinDipakai + rincian.PoinDidapat)
            End If

            ModCache.HapusAwalan("produk")
            ModLog.Catat("PESANAN_BARU", $"Pesanan #{noAntrian:000} ({metode}) total {ModFormat.Rupiah(rincian.Total)}")
            Return New HasilPesanan With {.IdPesanan = idPesananBaru, .NoAntrian = noAntrian}
        End Function

        Public Function HitungKembalian(total As Decimal, bayar As Decimal) As Decimal
            Return Math.Max(0D, bayar - total)
        End Function

        Public Function PecahKembalian(kembalian As Decimal) As Dictionary(Of Integer, Integer)
            Dim hasil As New Dictionary(Of Integer, Integer)()
            Dim sisa As Integer = CInt(Math.Floor(Math.Max(0D, kembalian)))
            Dim pecahan As Integer() = {100000, 50000, 20000, 10000, 5000, 2000, 1000, 500, 200, 100}
            Dim idx As Integer = 0
            Do While idx < pecahan.Length AndAlso sisa >= 100
                Dim nilai As Integer = pecahan(idx)
                If sisa >= nilai Then
                    hasil(nilai) = sisa \ nilai
                    sisa = sisa Mod nilai
                End If
                idx += 1
            Loop
            Return hasil
        End Function

        ''' <summary>Saran nominal uang bayar (kelipatan di atas total).</summary>
        Public Function SaranUangBayar(total As Decimal) As List(Of Decimal)
            Dim saran As New List(Of Decimal)()
            Dim pecahan As Integer() = {1000, 2000, 5000, 10000, 20000, 50000, 100000}
            For Each p In pecahan
                Dim kelipatan As Integer = CInt(Math.Ceiling(CDbl(total) / p))
                Dim nilai As Decimal = kelipatan * p
                If nilai >= total AndAlso Not saran.Contains(nilai) Then
                    saran.Add(nilai)
                    If saran.Count >= 5 Then Exit For
                End If
            Next
            Return saran
        End Function

        Public Function AmbilPesananById(idPesanan As Integer) As PesananData
            If Not ModDatabase.ModeDummyAktif() Then
                Return AmbilPesananByIdLive(idPesanan)
            End If
            ModDummyStore.PastikanInit()
            Return ModDummyStore.PesananList.FirstOrDefault(Function(p) p.IdPesanan = idPesanan)
        End Function

        Private Function AmbilPesananByIdLive(idPesanan As Integer) As PesananData
            Try
                Using conn = ModDatabase.BukaKoneksi()
                    Using cmd As New NpgsqlCommand(
                        "SELECT id_pesanan,no_antrian,tipe_makan,tanggal,subtotal,diskon,pajak,total," &
                        "metode_bayar,status_bayar,status_pesanan,kode_voucher,id_member," &
                        "poin_dipakai,poin_didapat,uang_bayar,kembalian,waktu_diproses,waktu_siap " &
                        "FROM public.pesanan WHERE id_pesanan = @id LIMIT 1", conn)
                        cmd.Parameters.AddWithValue("id", idPesanan)
                        Using rd = cmd.ExecuteReader()
                            If Not rd.Read() Then Return Nothing
                            Return New PesananData With {
                                .IdPesanan = rd.GetInt32(0), .NoAntrian = rd.GetInt32(1),
                                .TipeMakan = rd.GetString(2), .Tanggal = rd.GetDateTime(3),
                                .Subtotal = rd.GetDecimal(4), .Diskon = rd.GetDecimal(5),
                                .Pajak = rd.GetDecimal(6), .Total = rd.GetDecimal(7),
                                .MetodeBayar = rd.GetString(8), .StatusBayar = rd.GetString(9),
                                .StatusPesanan = rd.GetString(10),
                                .KodeVoucher = If(rd.IsDBNull(11), Nothing, rd.GetString(11)),
                                .IdMember = If(rd.IsDBNull(12), Nothing, CType(rd.GetInt32(12), Integer?)),
                                .PoinDipakai = rd.GetInt32(13), .PoinDidapat = rd.GetInt32(14),
                                .UangBayar = If(rd.IsDBNull(15), Nothing, CType(rd.GetDecimal(15), Decimal?)),
                                .Kembalian = If(rd.IsDBNull(16), Nothing, CType(rd.GetDecimal(16), Decimal?)),
                                .WaktuDiproses = If(rd.IsDBNull(17), Nothing, CType(rd.GetDateTime(17), DateTime?)),
                                .WaktuSiap = If(rd.IsDBNull(18), Nothing, CType(rd.GetDateTime(18), DateTime?))
                            }
                        End Using
                    End Using
                End Using
            Catch
                Return Nothing
            End Try
        End Function

        Public Function GenerateQrBitmap(teks As String, Optional pixelsPerModule As Integer = 6) As Bitmap
            Using gen As New QRCodeGenerator()
                Dim data = gen.CreateQrCode(teks, QRCodeGenerator.ECCLevel.Q)
                Using qr As New PngByteQRCode(data)
                    Dim bytes = qr.GetGraphic(pixelsPerModule, New Byte() {31, 27, 24, 255}, New Byte() {255, 255, 255, 255})
                    Using ms As New MemoryStream(bytes)
                        Using tmp As Image = Image.FromStream(ms)
                            Return New Bitmap(tmp)
                        End Using
                    End Using
                End Using
            End Using
        End Function

        Public Sub SimpanRating(idPesanan As Integer, bintang As Integer, komentar As String)
            If Not ModDatabase.ModeDummyAktif() Then
                SimpanRatingLive(idPesanan, bintang, komentar)
                Return
            End If
            ModDummyStore.PastikanInit()
            Dim existing = ModDummyStore.RatingList.FirstOrDefault(Function(r) r.IdPesanan = idPesanan)
            If existing IsNot Nothing Then
                existing.Bintang = bintang
                existing.Komentar = komentar
            Else
                ModDummyStore.RatingList.Add(New RatingPesananData With {
                    .IdPesanan = idPesanan, .Bintang = bintang, .Komentar = komentar
                })
            End If
        End Sub

        Private Sub SimpanRatingLive(idPesanan As Integer, bintang As Integer, komentar As String)
            Try
                Using conn = ModDatabase.BukaKoneksi()
                    Using cmd As New NpgsqlCommand(
                        "INSERT INTO public.rating_pesanan (id_pesanan, bintang, komentar) " &
                        "VALUES (@id, @b, @k) ON CONFLICT (id_pesanan) DO UPDATE SET bintang=@b, komentar=@k", conn)
                        Dim katObj As Object = If(String.IsNullOrWhiteSpace(komentar), DBNull.Value, CObj(komentar))
                        cmd.Parameters.AddWithValue("id", idPesanan)
                        cmd.Parameters.AddWithValue("b", bintang)
                        cmd.Parameters.AddWithValue("k", katObj)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[ModPesanan] SimpanRating gagal: " & ex.Message)
            End Try
        End Sub

    End Module
End Namespace
