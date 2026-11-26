Option Strict On
Option Explicit On

Imports System.Data
Imports System.Threading.Tasks
Imports Npgsql
Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModLaporan

        Public Function JumlahStokMenipis() As Integer
            Dim ambang As Integer = ModPengaturan.AmbilInt("ambang_stok", 5)
            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT COUNT(*) FROM public.produk WHERE stok IS NOT NULL AND stok <= @ambang AND tersedia = TRUE", conn)
                            cmd.Parameters.AddWithValue("ambang", ambang)
                            Return Convert.ToInt32(cmd.ExecuteScalar())
                        End Using
                    End Using
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModLaporan] JumlahStokMenipis live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Return ModDummyStore.ProdukList.Where(Function(p) p.Stok.HasValue AndAlso p.Stok.Value <= ambang).Count()
        End Function

        Public Function AmbilRingkasanDashboard() As RingkasanDashboard
            Dim ambang As Integer = ModPengaturan.AmbilInt("ambang_stok", 5)
            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Dim pendapatan As Decimal = 0D
                        Dim jumlahHariIni As Integer = 0
                        Dim jumlahSah As Integer = 0
                        Dim batal As Integer = 0

                        Using cmd As New NpgsqlCommand(
                            "SELECT " &
                            "COALESCE(SUM(total) FILTER (WHERE status_bayar = 'Lunas' AND status_pesanan <> 'Dibatalkan'), 0), " &
                            "COUNT(*), " &
                            "COUNT(*) FILTER (WHERE status_bayar = 'Lunas' AND status_pesanan <> 'Dibatalkan'), " &
                            "COUNT(*) FILTER (WHERE status_pesanan = 'Dibatalkan') " &
                            "FROM public.pesanan WHERE tanggal::date = CURRENT_DATE", conn)
                            Using rd = cmd.ExecuteReader()
                                If rd.Read() Then
                                    pendapatan = rd.GetDecimal(0)
                                    jumlahHariIni = rd.GetInt32(1)
                                    jumlahSah = rd.GetInt32(2)
                                    batal = rd.GetInt32(3)
                                End If
                            End Using
                        End Using

                        Dim stokTipis As Integer = 0
                        Using cmdStok As New NpgsqlCommand(
                            "SELECT COUNT(*) FROM public.produk WHERE stok IS NOT NULL AND stok <= @ambang AND tersedia = TRUE", conn)
                            cmdStok.Parameters.AddWithValue("ambang", ambang)
                            stokTipis = Convert.ToInt32(cmdStok.ExecuteScalar())
                        End Using

                        Dim rata As Decimal = If(jumlahSah > 0, Math.Round(pendapatan / jumlahSah, 0, MidpointRounding.AwayFromZero), 0D)
                        Return New RingkasanDashboard With {
                            .PendapatanHariIni = pendapatan,
                            .JumlahPesananHariIni = jumlahHariIni,
                            .RataRataOrder = rata,
                            .PesananDibatalkan = batal,
                            .ProdukStokMenipis = stokTipis
                        }
                    End Using
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModLaporan] AmbilRingkasanDashboard live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim hariIni = ModDummyStore.PesananList.Where(Function(p) p.Tanggal.Date = DateTime.Today).ToList()
            Dim sah = hariIni.Where(Function(p) p.StatusBayar = Model.StatusBayar.Lunas AndAlso p.StatusPesanan <> Model.StatusPesanan.Dibatalkan).ToList()
            Dim pendapatanD As Decimal = sah.Sum(Function(p) p.Total)
            Dim batalD As Integer = hariIni.Where(Function(p) p.StatusPesanan = Model.StatusPesanan.Dibatalkan).Count()
            Dim rataD As Decimal = If(sah.Count > 0, Math.Round(pendapatanD / sah.Count, 0, MidpointRounding.AwayFromZero), 0D)

            Return New RingkasanDashboard With {
                .PendapatanHariIni = pendapatanD,
                .JumlahPesananHariIni = hariIni.Count,
                .RataRataOrder = rataD,
                .PesananDibatalkan = batalD,
                .ProdukStokMenipis = JumlahStokMenipis()
            }
        End Function

        Public Function AmbilPenjualan7Hari() As List(Of GrafikTitik)
            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Dim perHari As New Dictionary(Of DateTime, Decimal)()
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT tanggal::date AS tgl, COALESCE(SUM(total), 0) AS omzet " &
                            "FROM public.pesanan " &
                            "WHERE tanggal::date >= CURRENT_DATE - INTERVAL '6 days' " &
                            "AND status_bayar = 'Lunas' AND status_pesanan <> 'Dibatalkan' " &
                            "GROUP BY tanggal::date", conn)
                            Using rd = cmd.ExecuteReader()
                                Do While rd.Read()
                                    perHari(rd.GetDateTime(0).Date) = rd.GetDecimal(1)
                                Loop
                            End Using
                        End Using
                    End Using

                    Dim hasilLive As New List(Of GrafikTitik)()
                    For i As Integer = 6 To 0 Step -1
                        Dim tgl As DateTime = DateTime.Today.AddDays(-i)
                        Dim omzet As Decimal = perHari.GetValueOrDefault(tgl, 0D)
                        hasilLive.Add(New GrafikTitik With {
                            .Label = tgl.ToString("dd MMM"),
                            .Nilai = omzet,
                            .Keterangan = $"{tgl:dddd, dd MMM yyyy}: {ModFormat.Rupiah(omzet)}"
                        })
                    Next
                    Return hasilLive
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModLaporan] AmbilPenjualan7Hari live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim hasil As New List(Of GrafikTitik)()
            For i As Integer = 6 To 0 Step -1
                Dim tgl As DateTime = DateTime.Today.AddDays(-i)
                Dim omzet As Decimal = ModDummyStore.PesananList _
                    .Where(Function(p) p.Tanggal.Date = tgl AndAlso p.StatusBayar = Model.StatusBayar.Lunas AndAlso p.StatusPesanan <> Model.StatusPesanan.Dibatalkan) _
                    .Sum(Function(p) p.Total)
                hasil.Add(New GrafikTitik With {
                    .Label = tgl.ToString("dd MMM"),
                    .Nilai = omzet,
                    .Keterangan = $"{tgl:dddd, dd MMM yyyy}: {ModFormat.Rupiah(omzet)}"
                })
            Next
            Return hasil
        End Function

        Public Function AmbilRiwayat(tglDari As DateTime, tglSampai As DateTime) As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("id_pesanan", GetType(Integer))
            dt.Columns.Add("no_antrian", GetType(Integer))
            dt.Columns.Add("tanggal", GetType(DateTime))
            dt.Columns.Add("tipe_makan", GetType(String))
            dt.Columns.Add("metode_bayar", GetType(String))
            dt.Columns.Add("status_bayar", GetType(String))
            dt.Columns.Add("status_pesanan", GetType(String))
            dt.Columns.Add("subtotal", GetType(Decimal))
            dt.Columns.Add("diskon", GetType(Decimal))
            dt.Columns.Add("pajak", GetType(Decimal))
            dt.Columns.Add("total", GetType(Decimal))

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT id_pesanan, no_antrian, tanggal, tipe_makan, metode_bayar, " &
                            "status_bayar, status_pesanan, subtotal, diskon, pajak, total " &
                            "FROM public.pesanan WHERE tanggal::date BETWEEN @dari AND @sampai " &
                            "ORDER BY tanggal DESC LIMIT 1000", conn)
                            cmd.Parameters.AddWithValue("dari", tglDari.Date)
                            cmd.Parameters.AddWithValue("sampai", tglSampai.Date)
                            Using rd = cmd.ExecuteReader()
                                Do While rd.Read()
                                    dt.Rows.Add(
                                        rd.GetInt32(0), rd.GetInt32(1), rd.GetDateTime(2), rd.GetString(3),
                                        rd.GetString(4), rd.GetString(5), rd.GetString(6),
                                        rd.GetDecimal(7), rd.GetDecimal(8), rd.GetDecimal(9), rd.GetDecimal(10)
                                    )
                                Loop
                            End Using
                        End Using
                    End Using
                    Return dt
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModLaporan] AmbilRiwayat live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim q = ModDummyStore.PesananList _
                .Where(Function(p) p.Tanggal.Date >= tglDari.Date AndAlso p.Tanggal.Date <= tglSampai.Date) _
                .OrderByDescending(Function(p) p.Tanggal)

            For Each p In q
                dt.Rows.Add(p.IdPesanan, p.NoAntrian, p.Tanggal, p.TipeMakan, p.MetodeBayar, p.StatusBayar, p.StatusPesanan, p.Subtotal, p.Diskon, p.Pajak, p.Total)
            Next
            Return dt
        End Function

        Public Function AmbilMenuTerlaris(Optional batas As Integer = 10, Optional tglDari As DateTime? = Nothing, Optional tglSampai As DateTime? = Nothing) As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("peringkat", GetType(Integer))
            dt.Columns.Add("nama_produk", GetType(String))
            dt.Columns.Add("total_qty", GetType(Integer))
            dt.Columns.Add("total_omzet", GetType(Decimal))

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Dim sql As String =
                            "SELECT d.nama_produk, SUM(d.qty)::INT AS total_qty, COALESCE(SUM(d.subtotal), 0) AS total_omzet " &
                            "FROM public.detail_pesanan d " &
                            "INNER JOIN public.pesanan p ON p.id_pesanan = d.id_pesanan " &
                            "WHERE p.status_bayar = 'Lunas' AND p.status_pesanan <> 'Dibatalkan' "
                        If tglDari.HasValue Then sql &= "AND p.tanggal::date >= @dari "
                        If tglSampai.HasValue Then sql &= "AND p.tanggal::date <= @sampai "
                        sql &= "GROUP BY d.nama_produk ORDER BY total_qty DESC, total_omzet DESC LIMIT @batas"

                        Using cmd As New NpgsqlCommand(sql, conn)
                            If tglDari.HasValue Then cmd.Parameters.AddWithValue("dari", tglDari.Value.Date)
                            If tglSampai.HasValue Then cmd.Parameters.AddWithValue("sampai", tglSampai.Value.Date)
                            cmd.Parameters.AddWithValue("batas", Math.Max(1, batas))
                            Using rd = cmd.ExecuteReader()
                                Dim rankLive As Integer = 1
                                Do While rd.Read()
                                    dt.Rows.Add(rankLive, rd.GetString(0), rd.GetInt32(1), rd.GetDecimal(2))
                                    rankLive += 1
                                Loop
                            End Using
                        End Using
                    End Using
                    Return dt
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModLaporan] AmbilMenuTerlaris live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim pesananSah As HashSet(Of Integer) = ModDummyStore.PesananList _
                .Where(Function(p) p.StatusBayar = Model.StatusBayar.Lunas AndAlso p.StatusPesanan <> Model.StatusPesanan.Dibatalkan AndAlso
                                   (Not tglDari.HasValue OrElse p.Tanggal.Date >= tglDari.Value.Date) AndAlso
                                   (Not tglSampai.HasValue OrElse p.Tanggal.Date <= tglSampai.Value.Date)) _
                .Select(Function(p) p.IdPesanan) _
                .ToHashSet()

            Dim dictQty As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            Dim dictOmzet As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)

            For Each d In ModDummyStore.DetailList
                If Not pesananSah.Contains(d.IdPesanan) Then Continue For
                dictQty(d.NamaProduk) = dictQty.GetValueOrDefault(d.NamaProduk, 0) + d.Qty
                dictOmzet(d.NamaProduk) = dictOmzet.GetValueOrDefault(d.NamaProduk, 0D) + d.Subtotal
            Next

            Dim rank As Integer = 1
            For Each kvp In dictQty.OrderByDescending(Function(x) x.Value).Take(batas)
                dt.Rows.Add(rank, kvp.Key, kvp.Value, dictOmzet(kvp.Key))
                rank += 1
            Next
            Return dt
        End Function

        ''' <summary>
        ''' Menghasilkan Array 2D (Kategori x Hari) untuk tab Rekap Laporan sesuai materi P5 &amp; P8.
        ''' </summary>
        Public Function AmbilRekapKategoriHari(tglDari As DateTime, tglSampai As DateTime) As (Kategori As String(), Tanggal As DateTime(), Matriks As Decimal(,))
            Dim jumlahHari As Integer = Math.Max(1, CInt((tglSampai.Date - tglDari.Date).TotalDays) + 1)
            If jumlahHari > 14 Then
                tglDari = tglSampai.Date.AddDays(-13)
                jumlahHari = 14
            End If

            Dim dates(jumlahHari - 1) As DateTime
            For c As Integer = 0 To jumlahHari - 1
                dates(c) = tglDari.Date.AddDays(c)
            Next

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Dim dtKat = ModProduk.AmbilKategori()
                    Dim catNamesLive As String() = dtKat.AsEnumerable().Select(Function(r) CStr(r("nama"))).ToArray()
                    Dim catIdsLive As Integer() = dtKat.AsEnumerable().Select(Function(r) CInt(r("id_kategori"))).ToArray()
                    Dim catIdToIdxLive As New Dictionary(Of Integer, Integer)()
                    For i As Integer = 0 To catIdsLive.Length - 1
                        catIdToIdxLive(catIdsLive(i)) = i
                    Next

                    Dim matriksLive(Math.Max(0, catNamesLive.Length - 1), jumlahHari - 1) As Decimal
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT pr.id_kategori, p.tanggal::date AS tgl, COALESCE(SUM(d.subtotal), 0) AS total_sub " &
                            "FROM public.detail_pesanan d " &
                            "INNER JOIN public.pesanan p ON p.id_pesanan = d.id_pesanan " &
                            "INNER JOIN public.produk pr ON pr.id_produk = d.id_produk " &
                            "WHERE p.tanggal::date BETWEEN @dari AND @sampai " &
                            "AND p.status_bayar = 'Lunas' AND p.status_pesanan <> 'Dibatalkan' " &
                            "GROUP BY pr.id_kategori, p.tanggal::date", conn)
                            cmd.Parameters.AddWithValue("dari", tglDari.Date)
                            cmd.Parameters.AddWithValue("sampai", tglSampai.Date)
                            Using rd = cmd.ExecuteReader()
                                Do While rd.Read()
                                    Dim idKat As Integer = rd.GetInt32(0)
                                    Dim tgl As DateTime = rd.GetDateTime(1).Date
                                    Dim subVal As Decimal = rd.GetDecimal(2)
                                    Dim rowIdx As Integer
                                    If catIdToIdxLive.TryGetValue(idKat, rowIdx) Then
                                        Dim colIdx As Integer = CInt((tgl - tglDari.Date).TotalDays)
                                        If colIdx >= 0 AndAlso colIdx < jumlahHari Then
                                            matriksLive(rowIdx, colIdx) += subVal
                                        End If
                                    End If
                                Loop
                            End Using
                        End Using
                    End Using
                    Return (catNamesLive, dates, matriksLive)
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModLaporan] AmbilRekapKategoriHari live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim cats = ModDummyStore.KategoriList.OrderBy(Function(k) k.Urutan).ToList()
            Dim catNames As String() = cats.Select(Function(k) k.Nama).ToArray()
            Dim matriks(catNames.Length - 1, jumlahHari - 1) As Decimal

            Dim pesananSah = ModDummyStore.PesananList _
                .Where(Function(p) p.Tanggal.Date >= tglDari.Date AndAlso p.Tanggal.Date <= tglSampai.Date AndAlso
                                   p.StatusBayar = Model.StatusBayar.Lunas AndAlso p.StatusPesanan <> Model.StatusPesanan.Dibatalkan) _
                .ToDictionary(Function(p) p.IdPesanan)

            Dim prodToCat = ModDummyStore.ProdukList.ToDictionary(Function(p) p.IdProduk, Function(p) p.IdKategori)
            Dim catIdToIdx As New Dictionary(Of Integer, Integer)()
            For i As Integer = 0 To cats.Count - 1
                catIdToIdx(cats(i).IdKategori) = i
            Next

            For Each d In ModDummyStore.DetailList
                Dim pes As PesananData = Nothing
                If Not pesananSah.TryGetValue(d.IdPesanan, pes) Then Continue For

                Dim idKat As Integer
                If Not prodToCat.TryGetValue(d.IdProduk, idKat) Then Continue For

                Dim rowIdx As Integer
                If Not catIdToIdx.TryGetValue(idKat, rowIdx) Then Continue For

                Dim colIdx As Integer = CInt((pes.Tanggal.Date - tglDari.Date).TotalDays)
                If colIdx >= 0 AndAlso colIdx < jumlahHari Then
                    matriks(rowIdx, colIdx) += d.Subtotal
                End If
            Next

            Return (catNames, dates, matriks)
        End Function

        Public Function AmbilRingkasanDashboardAsync() As Task(Of RingkasanDashboard)
            Return Task.Run(Function() AmbilRingkasanDashboard())
        End Function

        Public Function AmbilPenjualan7HariAsync() As Task(Of List(Of GrafikTitik))
            Return Task.Run(Function() AmbilPenjualan7Hari())
        End Function

        Public Function AmbilMenuTerlarisAsync(Optional batas As Integer = 10) As Task(Of DataTable)
            Return Task.Run(Function() AmbilMenuTerlaris(batas))
        End Function

    End Module
End Namespace
