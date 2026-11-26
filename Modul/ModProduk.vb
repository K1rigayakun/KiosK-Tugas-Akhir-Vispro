Option Strict On
Option Explicit On

Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.Http
Imports Npgsql
Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModProduk

        Private ReadOnly _imageCache As New Dictionary(Of String, Image)(StringComparer.OrdinalIgnoreCase)
        Private ReadOnly _httpClient As New HttpClient() With {.Timeout = TimeSpan.FromSeconds(10)}

        Public Function AmbilKategori() As DataTable
            Return ModCache.Ambil("kategori", 300, Function()
                If Not ModDatabase.ModeDummyAktif() Then Return AmbilKategoriLive()
                ModDummyStore.PastikanInit()
                Dim dt As New DataTable()
                dt.Columns.Add("id_kategori", GetType(Integer))
                dt.Columns.Add("nama", GetType(String))
                dt.Columns.Add("urutan", GetType(Integer))
                For Each k In ModDummyStore.KategoriList.OrderBy(Function(x) x.Urutan)
                    dt.Rows.Add(k.IdKategori, k.Nama, k.Urutan)
                Next
                Return dt
            End Function)
        End Function

        Private Function AmbilKategoriLive() As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("id_kategori", GetType(Integer))
            dt.Columns.Add("nama", GetType(String))
            dt.Columns.Add("urutan", GetType(Integer))
            Try
                Using conn = ModDatabase.BukaKoneksi()
                    Using cmd As New NpgsqlCommand(
                        "SELECT id_kategori, nama, urutan FROM public.kategori ORDER BY urutan, nama", conn)
                        Using rd = cmd.ExecuteReader()
                            Do While rd.Read()
                                dt.Rows.Add(rd.GetInt32(0), rd.GetString(1), rd.GetInt32(2))
                            Loop
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[ModProduk] AmbilKategori gagal: " & ex.Message)
            End Try
            Return dt
        End Function

        Public Function AmbilProduk(Optional idKategori As Integer = 0) As DataTable
            Return ModCache.Ambil($"produk:{idKategori}", 60, Function()
                If Not ModDatabase.ModeDummyAktif() Then Return AmbilProdukLive(idKategori)
                ModDummyStore.PastikanInit()
                Dim dt As New DataTable()
                dt.Columns.Add("id_produk", GetType(Integer))
                dt.Columns.Add("id_kategori", GetType(Integer))
                dt.Columns.Add("nama_kategori", GetType(String))
                dt.Columns.Add("nama", GetType(String))
                dt.Columns.Add("deskripsi", GetType(String))
                dt.Columns.Add("harga", GetType(Decimal))
                dt.Columns.Add("gambar", GetType(String))
                dt.Columns.Add("tersedia", GetType(Boolean))
                dt.Columns.Add("best_seller", GetType(Boolean))
                dt.Columns.Add("stok", GetType(Integer))
                Dim q = ModDummyStore.ProdukList.AsEnumerable()
                If idKategori > 0 Then q = q.Where(Function(p) p.IdKategori = idKategori)
                For Each p In q.OrderBy(Function(x) x.IdKategori).ThenBy(Function(x) x.IdProduk)
                    Dim kat = ModDummyStore.KategoriList.FirstOrDefault(Function(k) k.IdKategori = p.IdKategori)
                    Dim namaKat As String = If(kat IsNot Nothing, kat.Nama, p.NamaKategori)
                    Dim stokObj As Object = If(p.Stok.HasValue, CObj(p.Stok.Value), DBNull.Value)
                    dt.Rows.Add(p.IdProduk, p.IdKategori, namaKat, p.Nama, p.Deskripsi, p.Harga, p.Gambar, p.Tersedia, p.BestSeller, stokObj)
                Next
                Return dt
            End Function)
        End Function

        Private Function AmbilProdukLive(idKategori As Integer) As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("id_produk", GetType(Integer))
            dt.Columns.Add("id_kategori", GetType(Integer))
            dt.Columns.Add("nama_kategori", GetType(String))
            dt.Columns.Add("nama", GetType(String))
            dt.Columns.Add("deskripsi", GetType(String))
            dt.Columns.Add("harga", GetType(Decimal))
            dt.Columns.Add("gambar", GetType(String))
            dt.Columns.Add("tersedia", GetType(Boolean))
            dt.Columns.Add("best_seller", GetType(Boolean))
            dt.Columns.Add("stok", GetType(Integer))
            Try
                Using conn = ModDatabase.BukaKoneksi()
                    Dim sql As String = "SELECT p.id_produk, p.id_kategori, k.nama AS nama_kategori, " &
                                        "p.nama, p.deskripsi, p.harga, p.gambar, p.tersedia, p.best_seller, p.stok " &
                                        "FROM public.produk p JOIN public.kategori k ON k.id_kategori = p.id_kategori " &
                                        If(idKategori > 0, " WHERE p.id_kategori = @kat", "") &
                                        " ORDER BY k.urutan, p.id_produk"
                    Using cmd As New NpgsqlCommand(sql, conn)
                        If idKategori > 0 Then cmd.Parameters.AddWithValue("kat", idKategori)
                        Using rd = cmd.ExecuteReader()
                            Do While rd.Read()
                                Dim stokObj As Object = If(rd.IsDBNull(9), DBNull.Value, CObj(rd.GetInt32(9)))
                                dt.Rows.Add(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2),
                                           rd.GetString(3), If(rd.IsDBNull(4), "", rd.GetString(4)),
                                           rd.GetDecimal(5), If(rd.IsDBNull(6), "", rd.GetString(6)),
                                           rd.GetBoolean(7), rd.GetBoolean(8), stokObj)
                            Loop
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[ModProduk] AmbilProduk gagal: " & ex.Message)
            End Try
            Return dt
        End Function

        Public Function AmbilProdukObj(idProduk As Integer) As Produk
            If Not ModDatabase.ModeDummyAktif() Then
                Return AmbilProdukObjLive(idProduk)
            End If
            ModDummyStore.PastikanInit()
            Return ModDummyStore.ProdukList.FirstOrDefault(Function(p) p.IdProduk = idProduk)
        End Function

        Private Function AmbilProdukObjLive(idProduk As Integer) As Produk
            Try
                Using conn = ModDatabase.BukaKoneksi()
                    Using cmd As New NpgsqlCommand(
                        "SELECT p.id_produk, p.id_kategori, k.nama, p.nama, p.deskripsi, p.harga, p.gambar, p.tersedia, p.best_seller, p.stok " &
                        "FROM public.produk p JOIN public.kategori k ON k.id_kategori = p.id_kategori " &
                        "WHERE p.id_produk = @id LIMIT 1", conn)
                        cmd.Parameters.AddWithValue("id", idProduk)
                        Using rd = cmd.ExecuteReader()
                            If Not rd.Read() Then Return Nothing
                            Return New Produk With {
                                .IdProduk = rd.GetInt32(0), .IdKategori = rd.GetInt32(1),
                                .NamaKategori = rd.GetString(2), .Nama = rd.GetString(3),
                                .Deskripsi = If(rd.IsDBNull(4), "", rd.GetString(4)),
                                .Harga = rd.GetDecimal(5),
                                .Gambar = If(rd.IsDBNull(6), "", rd.GetString(6)),
                                .Tersedia = rd.GetBoolean(7), .BestSeller = rd.GetBoolean(8),
                                .Stok = If(rd.IsDBNull(9), Nothing, CType(rd.GetInt32(9), Integer?))
                            }
                        End Using
                    End Using
                End Using
            Catch
                Return Nothing
            End Try
        End Function

        Public Function AmbilOpsi(idProduk As Integer) As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("id_opsi", GetType(Integer))
            dt.Columns.Add("id_produk", GetType(Integer))
            dt.Columns.Add("nama_opsi", GetType(String))
            dt.Columns.Add("tipe", GetType(String))
            dt.Columns.Add("tambahan_harga", GetType(Decimal))
            If Not ModDatabase.ModeDummyAktif() Then
                Return AmbilOpsiLive(idProduk, dt)
            End If
            ModDummyStore.PastikanInit()
            For Each o In ModDummyStore.OpsiList.Where(Function(x) x.IdProduk = idProduk)
                dt.Rows.Add(o.IdOpsi, o.IdProduk, o.NamaOpsi, o.Tipe, o.TambahanHarga)
            Next
            Return dt
        End Function

        Private Function AmbilOpsiLive(idProduk As Integer, dt As DataTable) As DataTable
            Try
                Using conn = ModDatabase.BukaKoneksi()
                    Using cmd As New NpgsqlCommand(
                        "SELECT id_opsi, id_produk, nama_opsi, tipe, tambahan_harga " &
                        "FROM public.opsi_produk WHERE id_produk = @id ORDER BY tipe, nama_opsi", conn)
                        cmd.Parameters.AddWithValue("id", idProduk)
                        Using rd = cmd.ExecuteReader()
                            Do While rd.Read()
                                dt.Rows.Add(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2), rd.GetString(3), rd.GetDecimal(4))
                            Loop
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[ModProduk] AmbilOpsi gagal: " & ex.Message)
            End Try
            Return dt
        End Function

        Public Function AmbilBannerAktif() As List(Of BannerPromo)
            If Not ModDatabase.ModeDummyAktif() Then
                Return AmbilBannerAktifLive()
            End If
            ModDummyStore.PastikanInit()
            Return ModDummyStore.BannerList.Where(Function(b) b.Aktif).OrderBy(Function(b) b.Urutan).ToList()
        End Function

        Private Function AmbilBannerAktifLive() As List(Of BannerPromo)
            Dim hasil As New List(Of BannerPromo)()
            Try
                Using conn = ModDatabase.BukaKoneksi()
                    ' Coba dengan kolom subjudul, fallback jika tidak ada
                    Dim sql As String = "SELECT id_banner, judul, gambar, urutan, aktif, " &
                                        "COALESCE(subjudul,'') AS subjudul " &
                                        "FROM public.banner_promo WHERE aktif = true ORDER BY urutan"
                    Using cmd As New NpgsqlCommand(sql, conn)
                        Using rd = cmd.ExecuteReader()
                            Do While rd.Read()
                                hasil.Add(New BannerPromo With {
                                    .IdBanner = rd.GetInt32(0), .Judul = rd.GetString(1),
                                    .Gambar = rd.GetString(2), .Urutan = rd.GetInt32(3),
                                    .Aktif = rd.GetBoolean(4),
                                    .Subjudul = If(rd.FieldCount > 5, rd.GetString(5), "")
                                })
                            Loop
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[ModProduk] AmbilBanner gagal: " & ex.Message)
            End Try
            Return hasil
        End Function

        ''' <summary>Ambil gambar produk — coba lokal dulu, lalu Supabase Storage.</summary>
        Public Function AmbilGambar(namaFile As String) As Image
            Dim key As String = If(namaFile, "").Trim()
            If String.IsNullOrEmpty(key) Then key = "__placeholder__"

            Dim cached As Image = Nothing
            If _imageCache.TryGetValue(key, cached) Then Return cached

            ' 1. Cari lokal
            Dim fullPath As String = CariPathGambar(key, "Produk")
            If Not String.IsNullOrEmpty(fullPath) AndAlso File.Exists(fullPath) Then
                Try
                    Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                        Using tmp As Image = Image.FromStream(fs)
                            Dim clone As New Bitmap(tmp)
                            _imageCache(key) = clone
                            Return clone
                        End Using
                    End Using
                Catch
                End Try
            End If

            ' 2. Coba unduh dari Supabase Storage
            Dim imgDariStorage = UnduhDariStorage("produk/" & key)
            If imgDariStorage IsNot Nothing Then
                _imageCache(key) = imgDariStorage
                ' Simpan lokal untuk cache berikutnya
                Try
                    Dim dirProduk As String = Path.Combine(AppContext.BaseDirectory, "Asset", "Produk")
                    If Not Directory.Exists(dirProduk) Then Directory.CreateDirectory(dirProduk)
                    imgDariStorage.Save(Path.Combine(dirProduk, key), Imaging.ImageFormat.Jpeg)
                Catch
                End Try
                Return imgDariStorage
            End If

            Dim ph = BuatPlaceholderProduk(key)
            _imageCache(key) = ph
            Return ph
        End Function

        Public Function AmbilGambarBanner(namaFile As String) As Image
            Dim key As String = "banner:" & If(namaFile, "").Trim()
            Dim cached As Image = Nothing
            If _imageCache.TryGetValue(key, cached) Then Return cached

            Dim fullPath As String = CariPathGambar(namaFile, "Banner")
            If Not String.IsNullOrEmpty(fullPath) AndAlso File.Exists(fullPath) Then
                Try
                    Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                        Using tmp As Image = Image.FromStream(fs)
                            Dim clone As New Bitmap(tmp)
                            _imageCache(key) = clone
                            Return clone
                        End Using
                    End Using
                Catch
                End Try
            End If

            Dim imgDariStorage = UnduhDariStorage("banner/" & namaFile)
            If imgDariStorage IsNot Nothing Then
                _imageCache(key) = imgDariStorage
                Try
                    Dim dirBanner As String = Path.Combine(AppContext.BaseDirectory, "Asset", "Banner")
                    If Not Directory.Exists(dirBanner) Then Directory.CreateDirectory(dirBanner)
                    imgDariStorage.Save(Path.Combine(dirBanner, namaFile), Imaging.ImageFormat.Jpeg)
                Catch
                End Try
                Return imgDariStorage
            End If

            Dim bmp As New Bitmap(1280, 380)
            Using g = Graphics.FromImage(bmp)
                Using br As New LinearGradientBrush(New Rectangle(0, 0, 1280, 380), ModTema.WarnaCharcoal, ModTema.WarnaUtama, 15.0F)
                    g.FillRectangle(br, 0, 0, 1280, 380)
                End Using
            End Using
            _imageCache(key) = bmp
            Return bmp
        End Function

        Public Function AmbilLogoBistro() As Image
            Const key As String = "__logo_bistro__"
            Dim cached As Image = Nothing
            If _imageCache.TryGetValue(key, cached) Then Return cached
            Dim p1 As String = Path.Combine(AppContext.BaseDirectory, "Asset", "logo_bistro.png")
            If File.Exists(p1) Then
                Try
                    Using fs As New FileStream(p1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                        Using tmp As Image = Image.FromStream(fs)
                            Dim clone As New Bitmap(tmp)
                            _imageCache(key) = clone
                            Return clone
                        End Using
                    End Using
                Catch
                End Try
            End If
            ' Coba dari Storage
            Dim fromStorage = UnduhDariStorage("logo_bistro.png")
            If fromStorage IsNot Nothing Then
                _imageCache(key) = fromStorage
                Return fromStorage
            End If
            Dim ph = BuatPlaceholderProduk("Bistro")
            _imageCache(key) = ph
            Return ph
        End Function

        Private Function UnduhDariStorage(storagePath As String) As Image
            Try
                Dim cfg = ModDatabase.AmbilConfigSupabase()
                If String.IsNullOrWhiteSpace(cfg.Url) OrElse String.IsNullOrWhiteSpace(cfg.Bucket) Then Return Nothing
                Dim url As String = $"{cfg.Url}/storage/v1/object/public/{cfg.Bucket}/{storagePath}"
                Dim t = _httpClient.GetByteArrayAsync(url)
                t.Wait(TimeSpan.FromSeconds(8))
                If Not t.IsCompletedSuccessfully Then Return Nothing
                Using ms As New MemoryStream(t.Result)
                    Using tmp As Image = Image.FromStream(ms)
                        Return New Bitmap(tmp)
                    End Using
                End Using
            Catch
                Return Nothing
            End Try
        End Function

        ''' <summary>Konversi dan simpan gambar produk ke format standar, kembalikan nama file.</summary>
        Public Function KonversiDanSimpanGambarProduk(pathAsal As String, namaProduk As String) As String
            If Not File.Exists(pathAsal) Then Return ""
            Try
                Dim namaFile As String = SlugNama(namaProduk) & ".jpg"
                Dim dirProduk As String = Path.Combine(AppContext.BaseDirectory, "Asset", "Produk")
                If Not Directory.Exists(dirProduk) Then Directory.CreateDirectory(dirProduk)
                Dim destPath As String = Path.Combine(dirProduk, namaFile)

                Using bmp As New System.Drawing.Bitmap(pathAsal)
                    Dim target As New System.Drawing.Bitmap(640, 480)
                    Using g = Graphics.FromImage(target)
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic
                        g.DrawImage(bmp, 0, 0, 640, 480)
                    End Using
                    ' Simpan sebagai JPEG baseline RGB
                    Dim encoder = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders().First(Function(e) e.FormatID = Imaging.ImageFormat.Jpeg.Guid)
                    Dim ep As New System.Drawing.Imaging.EncoderParameters(1)
                    ep.Param(0) = New System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L)
                    target.Save(destPath, encoder, ep)
                    target.Dispose()
                End Using
                Return namaFile
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[ModProduk] KonversiGambar gagal: " & ex.Message)
                Return ""
            End Try
        End Function

        Private Function SlugNama(nama As String) As String
            Dim slug As String = If(nama, "produk").ToLowerInvariant()
            slug = System.Text.RegularExpressions.Regex.Replace(slug, "[^a-z0-9]+", "_")
            If slug.Length > 30 Then slug = slug.Substring(0, 30)
            Return slug.Trim("_"c)
        End Function

        Private Function CariPathGambar(namaFile As String, subFolder As String) As String
            If String.IsNullOrWhiteSpace(namaFile) OrElse namaFile = "__placeholder__" Then Return ""
            If Path.IsPathRooted(namaFile) AndAlso File.Exists(namaFile) Then Return namaFile
            Dim p1 As String = Path.Combine(AppContext.BaseDirectory, "Asset", subFolder, namaFile)
            If File.Exists(p1) Then Return p1
            Dim p2 As String = Path.Combine(AppContext.BaseDirectory, "Asset", namaFile)
            If File.Exists(p2) Then Return p2
            Return ""
        End Function

        Private Function BuatPlaceholderProduk(label As String) As Image
            Dim bmp As New Bitmap(480, 360)
            Using g = Graphics.FromImage(bmp)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.Clear(ModTema.WarnaSekunderLatar)
                Using br As New SolidBrush(ModTema.WarnaUtamaLembut)
                    g.FillEllipse(br, 165, 95, 150, 150)
                End Using
                Using pen As New Pen(ModTema.WarnaUtama, 4.0F)
                    g.DrawArc(pen, 195, 130, 90, 80, 180, 180)
                    g.DrawLine(pen, 185, 175, 295, 175)
                End Using
                Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    Using brTxt As New SolidBrush(ModTema.WarnaTeksRedup)
                        g.DrawString(If(String.IsNullOrWhiteSpace(label), "Menu Bistro", Path.GetFileNameWithoutExtension(label)),
                                     ModTema.FontSubJudul, brTxt, New RectangleF(20, 265, 440, 40), sf)
                    End Using
                End Using
            End Using
            Return bmp
        End Function

        Public Sub HapusCacheGambar(namaFile As String)
            If Not String.IsNullOrWhiteSpace(namaFile) Then
                _imageCache.Remove(namaFile)
                _imageCache.Remove("banner:" & namaFile)
            End If
        End Sub

    End Module
End Namespace
