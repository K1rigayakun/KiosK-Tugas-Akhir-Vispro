Option Strict On
Option Explicit On

Imports System.Data
Imports Npgsql
Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModAntrian

        Private ReadOnly _transisiValid As New Dictionary(Of String, String())(StringComparer.OrdinalIgnoreCase) From {
            {Model.StatusPesanan.MenungguPembayaran, New String() {Model.StatusPesanan.Diproses, Model.StatusPesanan.Dibatalkan}},
            {Model.StatusPesanan.Diproses, New String() {Model.StatusPesanan.Siap, Model.StatusPesanan.Dibatalkan}},
            {Model.StatusPesanan.Siap, New String() {Model.StatusPesanan.Selesai}},
            {Model.StatusPesanan.Selesai, Array.Empty(Of String)()},
            {Model.StatusPesanan.Dibatalkan, Array.Empty(Of String)()}
        }

        Public Function AmbilPesanan(Optional status As String = "") As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("id_pesanan", GetType(Integer))
            dt.Columns.Add("no_antrian", GetType(Integer))
            dt.Columns.Add("tipe_makan", GetType(String))
            dt.Columns.Add("tanggal", GetType(DateTime))
            dt.Columns.Add("total", GetType(Decimal))
            dt.Columns.Add("metode_bayar", GetType(String))
            dt.Columns.Add("status_bayar", GetType(String))
            dt.Columns.Add("status_pesanan", GetType(String))
            dt.Columns.Add("waktu_diproses", GetType(Object))
            dt.Columns.Add("waktu_siap", GetType(Object))

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Dim sql As String =
                            "SELECT id_pesanan, no_antrian, tipe_makan, tanggal, total, metode_bayar, " &
                            "status_bayar, status_pesanan, waktu_diproses, waktu_siap " &
                            "FROM public.pesanan WHERE tanggal::date = CURRENT_DATE "
                        Dim filterStatus As Boolean = Not String.IsNullOrWhiteSpace(status) AndAlso
                                                      Not String.Equals(status, "Semua", StringComparison.OrdinalIgnoreCase)
                        If filterStatus Then
                            sql &= "AND LOWER(status_pesanan) = LOWER(@st) "
                        End If
                        sql &= "ORDER BY no_antrian DESC"

                        Using cmd As New NpgsqlCommand(sql, conn)
                            If filterStatus Then cmd.Parameters.AddWithValue("st", status.Trim())
                            Using rd = cmd.ExecuteReader()
                                Do While rd.Read()
                                    dt.Rows.Add(
                                        rd.GetInt32(0),
                                        rd.GetInt32(1),
                                        rd.GetString(2),
                                        rd.GetDateTime(3),
                                        rd.GetDecimal(4),
                                        rd.GetString(5),
                                        rd.GetString(6),
                                        rd.GetString(7),
                                        If(rd.IsDBNull(8), DBNull.Value, CObj(rd.GetDateTime(8))),
                                        If(rd.IsDBNull(9), DBNull.Value, CObj(rd.GetDateTime(9)))
                                    )
                                Loop
                            End Using
                        End Using
                    End Using
                    Return dt
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModAntrian] AmbilPesanan live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim q = ModDummyStore.PesananList.Where(Function(p) p.Tanggal.Date = DateTime.Today)
            If Not String.IsNullOrWhiteSpace(status) AndAlso Not String.Equals(status, "Semua", StringComparison.OrdinalIgnoreCase) Then
                q = q.Where(Function(p) String.Equals(p.StatusPesanan, status, StringComparison.OrdinalIgnoreCase))
            End If

            For Each p In q.OrderByDescending(Function(x) x.NoAntrian)
                dt.Rows.Add(
                    p.IdPesanan,
                    p.NoAntrian,
                    p.TipeMakan,
                    p.Tanggal,
                    p.Total,
                    p.MetodeBayar,
                    p.StatusBayar,
                    p.StatusPesanan,
                    If(p.WaktuDiproses.HasValue, CObj(p.WaktuDiproses.Value), DBNull.Value),
                    If(p.WaktuSiap.HasValue, CObj(p.WaktuSiap.Value), DBNull.Value)
                )
            Next
            Return dt
        End Function

        Public Function AmbilDetail(idPesanan As Integer) As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("id_detail", GetType(Integer))
            dt.Columns.Add("id_produk", GetType(Integer))
            dt.Columns.Add("nama_produk", GetType(String))
            dt.Columns.Add("qty", GetType(Integer))
            dt.Columns.Add("harga_satuan", GetType(Decimal))
            dt.Columns.Add("opsi_dipilih", GetType(String))
            dt.Columns.Add("catatan", GetType(String))
            dt.Columns.Add("subtotal", GetType(Decimal))

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT id_detail, id_produk, nama_produk, qty, harga_satuan, " &
                            "COALESCE(opsi_dipilih, ''), COALESCE(catatan, ''), subtotal " &
                            "FROM public.detail_pesanan WHERE id_pesanan = @id ORDER BY id_detail", conn)
                            cmd.Parameters.AddWithValue("id", idPesanan)
                            Using rd = cmd.ExecuteReader()
                                Do While rd.Read()
                                    dt.Rows.Add(
                                        rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2), rd.GetInt32(3),
                                        rd.GetDecimal(4), rd.GetString(5), rd.GetString(6), rd.GetDecimal(7)
                                    )
                                Loop
                            End Using
                        End Using
                    End Using
                    Return dt
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModAntrian] AmbilDetail live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            For Each d In ModDummyStore.DetailList.Where(Function(x) x.IdPesanan = idPesanan)
                dt.Rows.Add(d.IdDetail, d.IdProduk, d.NamaProduk, d.Qty, d.HargaSatuan, d.OpsiDipilih, d.Catatan, d.Subtotal)
            Next
            Return dt
        End Function

        Public Function RingkasanItemTeks(idPesanan As Integer) As String
            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT COALESCE(STRING_AGG(qty || 'x ' || nama_produk, ', ' ORDER BY id_detail), '') " &
                            "FROM public.detail_pesanan WHERE id_pesanan = @id", conn)
                            cmd.Parameters.AddWithValue("id", idPesanan)
                            Dim res = cmd.ExecuteScalar()
                            Return If(res Is Nothing OrElse Convert.IsDBNull(res), "", Convert.ToString(res))
                        End Using
                    End Using
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModAntrian] RingkasanItemTeks live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim parts As New List(Of String)()
            For Each d In ModDummyStore.DetailList.Where(Function(x) x.IdPesanan = idPesanan)
                parts.Add($"{d.Qty}x {d.NamaProduk}")
            Next
            Return String.Join(", ", parts)
        End Function

        Public Function UbahStatus(idPesanan As Integer, statusBaru As String) As Boolean
            If Not ModDatabase.ModeDummyAktif() Then
                Using conn = ModDatabase.BukaKoneksi()
                    Using tx = conn.BeginTransaction()
                        Try
                            Dim statusSaatIni As String = ""
                            Using cmdGet As New NpgsqlCommand(
                                "SELECT status_pesanan FROM public.pesanan WHERE id_pesanan = @id FOR UPDATE", conn, tx)
                                cmdGet.Parameters.AddWithValue("id", idPesanan)
                                Dim obj = cmdGet.ExecuteScalar()
                                If obj Is Nothing OrElse Convert.IsDBNull(obj) Then
                                    tx.Rollback()
                                    Return False
                                End If
                                statusSaatIni = Convert.ToString(obj)
                            End Using

                            Dim boleh As String() = Nothing
                            If Not _transisiValid.TryGetValue(statusSaatIni, boleh) Then
                                tx.Rollback()
                                Return False
                            End If
                            If Not boleh.Any(Function(s) String.Equals(s, statusBaru, StringComparison.OrdinalIgnoreCase)) Then
                                tx.Rollback()
                                Return False
                            End If

                            Dim sqlUpd As String = "UPDATE public.pesanan SET status_pesanan = @sb"
                            If String.Equals(statusBaru, Model.StatusPesanan.Diproses, StringComparison.OrdinalIgnoreCase) Then
                                sqlUpd &= ", waktu_diproses = NOW()"
                            ElseIf String.Equals(statusBaru, Model.StatusPesanan.Siap, StringComparison.OrdinalIgnoreCase) Then
                                sqlUpd &= ", waktu_siap = NOW()"
                            End If
                            sqlUpd &= " WHERE id_pesanan = @id"

                            Using cmdUpd As New NpgsqlCommand(sqlUpd, conn, tx)
                                cmdUpd.Parameters.AddWithValue("sb", statusBaru)
                                cmdUpd.Parameters.AddWithValue("id", idPesanan)
                                cmdUpd.ExecuteNonQuery()
                            End Using

                            If String.Equals(statusBaru, Model.StatusPesanan.Dibatalkan, StringComparison.OrdinalIgnoreCase) Then
                                ' Kembalikan stok semua item dalam pesanan
                                Using cmdRestok As New NpgsqlCommand(
                                    "UPDATE public.produk pr SET stok = pr.stok + d.qty, tersedia = TRUE " &
                                    "FROM (SELECT id_produk, SUM(qty) AS qty FROM public.detail_pesanan WHERE id_pesanan = @id GROUP BY id_produk) d " &
                                    "WHERE pr.id_produk = d.id_produk AND pr.stok IS NOT NULL", conn, tx)
                                    cmdRestok.Parameters.AddWithValue("id", idPesanan)
                                    cmdRestok.ExecuteNonQuery()
                                End Using
                                ModCache.HapusAwalan("produk")
                            End If

                            tx.Commit()
                            Return True
                        Catch
                            Try
                                tx.Rollback()
                            Catch
                            End Try
                            Throw
                        End Try
                    End Using
                End Using
            End If

            ModDummyStore.PastikanInit()
            Dim p = ModDummyStore.PesananList.FirstOrDefault(Function(x) x.IdPesanan = idPesanan)
            If p Is Nothing Then Return False

            Dim bolehD As String() = Nothing
            If Not _transisiValid.TryGetValue(p.StatusPesanan, bolehD) Then Return False
            If Not bolehD.Any(Function(s) String.Equals(s, statusBaru, StringComparison.OrdinalIgnoreCase)) Then
                Return False
            End If

            p.StatusPesanan = statusBaru
            If String.Equals(statusBaru, Model.StatusPesanan.Diproses, StringComparison.OrdinalIgnoreCase) Then
                p.WaktuDiproses = DateTime.Now
            ElseIf String.Equals(statusBaru, Model.StatusPesanan.Siap, StringComparison.OrdinalIgnoreCase) Then
                p.WaktuSiap = DateTime.Now
            ElseIf String.Equals(statusBaru, Model.StatusPesanan.Dibatalkan, StringComparison.OrdinalIgnoreCase) Then
                For Each d In ModDummyStore.DetailList.Where(Function(x) x.IdPesanan = idPesanan)
                    Dim prod = ModDummyStore.ProdukList.FirstOrDefault(Function(pr) pr.IdProduk = d.IdProduk)
                    If prod IsNot Nothing AndAlso prod.Stok.HasValue Then
                        prod.Stok = prod.Stok.Value + d.Qty
                        If prod.Stok.Value > 0 Then prod.Tersedia = True
                    End If
                Next
                ModCache.HapusAwalan("produk")
            End If

            Return True
        End Function

        Public Function KonfirmasiTunai(idPesanan As Integer, uangBayar As Decimal) As Boolean
            If Not ModDatabase.ModeDummyAktif() Then
                Using conn = ModDatabase.BukaKoneksi()
                    Using tx = conn.BeginTransaction()
                        Try
                            Dim statusPes As String = ""
                            Dim metode As String = ""
                            Dim totalPes As Decimal = 0D
                            Dim idMember As Integer? = Nothing
                            Dim poinDidapat As Integer = 0

                            Using cmdGet As New NpgsqlCommand(
                                "SELECT status_pesanan, metode_bayar, total, id_member, poin_didapat " &
                                "FROM public.pesanan WHERE id_pesanan = @id FOR UPDATE", conn, tx)
                                cmdGet.Parameters.AddWithValue("id", idPesanan)
                                Using rd = cmdGet.ExecuteReader()
                                    If Not rd.Read() Then
                                        tx.Rollback()
                                        Return False
                                    End If
                                    statusPes = rd.GetString(0)
                                    metode = rd.GetString(1)
                                    totalPes = rd.GetDecimal(2)
                                    If Not rd.IsDBNull(3) Then idMember = rd.GetInt32(3)
                                    poinDidapat = If(rd.IsDBNull(4), 0, rd.GetInt32(4))
                                End Using
                            End Using

                            If Not String.Equals(statusPes, Model.StatusPesanan.MenungguPembayaran, StringComparison.OrdinalIgnoreCase) OrElse
                               Not String.Equals(metode, Model.MetodeBayar.Tunai, StringComparison.OrdinalIgnoreCase) OrElse
                               uangBayar < totalPes Then
                                tx.Rollback()
                                Return False
                            End If

                            Dim kembalian As Decimal = ModPesanan.HitungKembalian(totalPes, uangBayar)
                            Dim idKasir As Object = If(ModSesi.SudahLogin(), CObj(ModSesi.IdPengguna), DBNull.Value)

                            Using cmdUpd As New NpgsqlCommand(
                                "UPDATE public.pesanan SET status_bayar = @sb, status_pesanan = @sp, " &
                                "id_kasir = @kasir, uang_bayar = @ub, kembalian = @kmb, waktu_diproses = NOW() " &
                                "WHERE id_pesanan = @id", conn, tx)
                                cmdUpd.Parameters.AddWithValue("sb", Model.StatusBayar.Lunas)
                                cmdUpd.Parameters.AddWithValue("sp", Model.StatusPesanan.Diproses)
                                cmdUpd.Parameters.AddWithValue("kasir", idKasir)
                                cmdUpd.Parameters.AddWithValue("ub", uangBayar)
                                cmdUpd.Parameters.AddWithValue("kmb", kembalian)
                                cmdUpd.Parameters.AddWithValue("id", idPesanan)
                                cmdUpd.ExecuteNonQuery()
                            End Using

                            ' Berikan poin member setelah pembayaran tunai dikonfirmasi kasir
                            If idMember.HasValue AndAlso poinDidapat > 0 Then
                                Using cmdMem As New NpgsqlCommand(
                                    "UPDATE public.member SET poin = poin + @pd WHERE id_member = @mid", conn, tx)
                                    cmdMem.Parameters.AddWithValue("pd", poinDidapat)
                                    cmdMem.Parameters.AddWithValue("mid", idMember.Value)
                                    cmdMem.ExecuteNonQuery()
                                End Using
                            End If

                            tx.Commit()
                            Return True
                        Catch
                            Try
                                tx.Rollback()
                            Catch
                            End Try
                            Throw
                        End Try
                    End Using
                End Using
            End If

            ModDummyStore.PastikanInit()
            Dim p = ModDummyStore.PesananList.FirstOrDefault(Function(x) x.IdPesanan = idPesanan)
            If p Is Nothing Then Return False
            If Not String.Equals(p.StatusPesanan, Model.StatusPesanan.MenungguPembayaran, StringComparison.OrdinalIgnoreCase) Then Return False
            If Not String.Equals(p.MetodeBayar, Model.MetodeBayar.Tunai, StringComparison.OrdinalIgnoreCase) Then Return False
            If uangBayar < p.Total Then Return False

            p.StatusBayar = Model.StatusBayar.Lunas
            p.StatusPesanan = Model.StatusPesanan.Diproses
            p.IdKasir = If(ModSesi.SudahLogin(), CType(ModSesi.IdPengguna, Integer?), Nothing)
            p.UangBayar = uangBayar
            p.Kembalian = ModPesanan.HitungKembalian(p.Total, uangBayar)
            p.WaktuDiproses = DateTime.Now

            If p.IdMember.HasValue AndAlso p.PoinDidapat > 0 Then
                Dim mem = ModDummyStore.MemberList.FirstOrDefault(Function(m) m.IdMember = p.IdMember.Value)
                If mem IsNot Nothing Then mem.Poin += p.PoinDidapat
            End If
            Return True
        End Function

        Public Sub SimulasikanPesananMasukDapur()
            ' Ambil produk secara dinamis agar kompatibel baik di Supabase maupun DummyStore
            Dim dtProd = ModProduk.AmbilProduk(0)
            Dim listProd As New List(Of (Id As Integer, Nama As String, Harga As Decimal))()
            For Each r As DataRow In dtProd.Rows
                If CBool(r("tersedia")) Then
                    listProd.Add((CInt(r("id_produk")), CStr(r("nama")), CDec(r("harga"))))
                    If listProd.Count >= 2 Then Exit For
                End If
            Next
            If listProd.Count = 0 Then Return
            If listProd.Count = 1 Then listProd.Add(listProd(0))

            Dim p1 = listProd(0)
            Dim p2 = listProd(1)
            Dim subtotal As Decimal = p1.Harga + p2.Harga
            Dim pajak As Decimal = Math.Round(subtotal * 0.11D, 0, MidpointRounding.AwayFromZero)
            Dim total As Decimal = subtotal + pajak

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using tx = conn.BeginTransaction()
                            Using cmdLock As New NpgsqlCommand("SELECT pg_advisory_xact_lock(1234567890)", conn, tx)
                                cmdLock.ExecuteNonQuery()
                            End Using

                            Dim noAntrian As Integer = 1
                            Using cmdA As New NpgsqlCommand(
                                "SELECT COALESCE(MAX(no_antrian), 0) + 1 FROM public.pesanan WHERE tanggal::date = CURRENT_DATE", conn, tx)
                                noAntrian = Convert.ToInt32(cmdA.ExecuteScalar())
                            End Using

                            Dim idPesanan As Integer
                            Using cmdP As New NpgsqlCommand(
                                "INSERT INTO public.pesanan (no_antrian, tipe_makan, subtotal, diskon, pajak, total, metode_bayar, " &
                                "status_bayar, status_pesanan, waktu_diproses) " &
                                "VALUES (@ant, @tipe, @sub, 0, @pjk, @tot, @met, @sbyr, @spes, NOW()) RETURNING id_pesanan", conn, tx)
                                cmdP.Parameters.AddWithValue("ant", noAntrian)
                                cmdP.Parameters.AddWithValue("tipe", Model.TipeMakan.DineIn)
                                cmdP.Parameters.AddWithValue("sub", subtotal)
                                cmdP.Parameters.AddWithValue("pjk", pajak)
                                cmdP.Parameters.AddWithValue("tot", total)
                                cmdP.Parameters.AddWithValue("met", Model.MetodeBayar.Qris)
                                cmdP.Parameters.AddWithValue("sbyr", Model.StatusBayar.Lunas)
                                cmdP.Parameters.AddWithValue("spes", Model.StatusPesanan.Diproses)
                                idPesanan = Convert.ToInt32(cmdP.ExecuteScalar())
                            End Using

                            For Each item In {p1, p2}
                                Using cmdD As New NpgsqlCommand(
                                    "INSERT INTO public.detail_pesanan (id_pesanan, id_produk, nama_produk, qty, harga_satuan, opsi_dipilih, catatan, subtotal) " &
                                    "VALUES (@id_p, @id_pr, @nama, 1, @hrg, '', '', @hrg)", conn, tx)
                                    cmdD.Parameters.AddWithValue("id_p", idPesanan)
                                    cmdD.Parameters.AddWithValue("id_pr", item.Id)
                                    cmdD.Parameters.AddWithValue("nama", item.Nama)
                                    cmdD.Parameters.AddWithValue("hrg", item.Harga)
                                    cmdD.ExecuteNonQuery()
                                End Using
                            Next

                            tx.Commit()
                            Return
                        End Using
                    End Using
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModAntrian] Simulasi dapur live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim maxAntrian As Integer = ModDummyStore.PesananList _
                .Where(Function(x) x.Tanggal.Date = DateTime.Today) _
                .Select(Function(x) x.NoAntrian) _
                .DefaultIfEmpty(0) _
                .Max() + 1

            Dim idPes As Integer = ModDummyStore.NextPesananId
            ModDummyStore.NextPesananId += 1

            ModDummyStore.PesananList.Add(New PesananData With {
                .IdPesanan = idPes,
                .NoAntrian = maxAntrian,
                .TipeMakan = Model.TipeMakan.DineIn,
                .Tanggal = DateTime.Now,
                .Subtotal = subtotal,
                .Diskon = 0D,
                .Pajak = pajak,
                .Total = total,
                .MetodeBayar = Model.MetodeBayar.Qris,
                .StatusBayar = Model.StatusBayar.Lunas,
                .StatusPesanan = Model.StatusPesanan.Diproses,
                .WaktuDiproses = DateTime.Now
            })
            ModDummyStore.DetailList.Add(New DetailPesananData With {.IdDetail = ModDummyStore.NextDetailId, .IdPesanan = idPes, .IdProduk = p1.Id, .NamaProduk = p1.Nama, .Qty = 1, .HargaSatuan = p1.Harga, .Subtotal = p1.Harga})
            ModDummyStore.NextDetailId += 1
            ModDummyStore.DetailList.Add(New DetailPesananData With {.IdDetail = ModDummyStore.NextDetailId, .IdPesanan = idPes, .IdProduk = p2.Id, .NamaProduk = p2.Nama, .Qty = 1, .HargaSatuan = p2.Harga, .Subtotal = p2.Harga})
            ModDummyStore.NextDetailId += 1
        End Sub

        Public Function AmbilStatistikDapur() As (RataMenit As Double, SelesaiHariIni As Integer, TerlamaMenit As Double, PerJam As Integer())
            Dim slots(23) As Integer
            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Dim rata As Double = 0.0
                        Dim selesaiHariIni As Integer = 0
                        Dim terlama As Double = 0.0

                        Using cmdStat As New NpgsqlCommand(
                            "SELECT " &
                            "COALESCE(AVG(GREATEST(1.0, EXTRACT(EPOCH FROM (waktu_siap - waktu_diproses)) / 60.0)) FILTER (WHERE waktu_diproses IS NOT NULL AND waktu_siap IS NOT NULL), 0.0), " &
                            "COUNT(*) FILTER (WHERE status_pesanan IN ('Siap', 'Selesai')), " &
                            "COALESCE(MAX(GREATEST(0.0, EXTRACT(EPOCH FROM (NOW() - waktu_diproses)) / 60.0)) FILTER (WHERE status_pesanan = 'Diproses' AND waktu_diproses IS NOT NULL), 0.0) " &
                            "FROM public.pesanan WHERE tanggal::date = CURRENT_DATE", conn)
                            Using rd = cmdStat.ExecuteReader()
                                If rd.Read() Then
                                    rata = rd.GetDouble(0)
                                    selesaiHariIni = rd.GetInt32(1)
                                    terlama = rd.GetDouble(2)
                                End If
                            End Using
                        End Using

                        Using cmdJam As New NpgsqlCommand(
                            "SELECT EXTRACT(HOUR FROM tanggal)::INT AS jam, COUNT(*)::INT AS jml " &
                            "FROM public.pesanan WHERE tanggal::date = CURRENT_DATE GROUP BY jam", conn)
                            Using rd = cmdJam.ExecuteReader()
                                Do While rd.Read()
                                    Dim j As Integer = rd.GetInt32(0)
                                    If j >= 0 AndAlso j < 24 Then slots(j) = rd.GetInt32(1)
                                Loop
                            End Using
                        End Using

                        Return (rata, selesaiHariIni, terlama, slots)
                    End Using
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModAntrian] AmbilStatistikDapur live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim hariIni = ModDummyStore.PesananList.Where(Function(x) x.Tanggal.Date = DateTime.Today).ToList()
            Dim selesai = hariIni.Where(Function(x) x.WaktuDiproses.HasValue AndAlso x.WaktuSiap.HasValue).ToList()
            Dim rataD As Double = 0.0
            If selesai.Count > 0 Then
                rataD = selesai.Average(Function(x) Math.Max(1.0, (x.WaktuSiap.Value - x.WaktuDiproses.Value).TotalMinutes))
            End If
            Dim jumlahSelesai As Integer = hariIni.Where(Function(x) x.StatusPesanan = Model.StatusPesanan.Siap OrElse x.StatusPesanan = Model.StatusPesanan.Selesai).Count()
            Dim aktifDiproses = hariIni.Where(Function(x) x.StatusPesanan = Model.StatusPesanan.Diproses AndAlso x.WaktuDiproses.HasValue).ToList()
            Dim terlamaD As Double = 0.0
            If aktifDiproses.Count > 0 Then
                terlamaD = aktifDiproses.Max(Function(x) Math.Max(0.0, (DateTime.Now - x.WaktuDiproses.Value).TotalMinutes))
            End If

            For Each p In hariIni
                slots(p.Tanggal.Hour) += 1
            Next
            Return (rataD, jumlahSelesai, terlamaD, slots)
        End Function

    End Module
End Namespace
