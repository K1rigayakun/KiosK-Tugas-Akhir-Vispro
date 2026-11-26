Option Strict On
Option Explicit On

Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Text.Json

Namespace VisproPrakProjectAkhir.Modul

    ''' <summary>
    ''' ModSupabaseApi — Lapisan integrasi Supabase Data API (PostgREST) + Auth JWT untuk WinForms.
    '''
    ''' Pola yang diimplementasikan:
    '''   1. Konfigurasi URL dan anon key dibaca dari <see cref="ModDatabase.AmbilConfigSupabase"/> (tanpa hardcode secret).
    '''   2. Login via POST /auth/v1/token?grant_type=password untuk memperoleh access_token JWT.
    '''   3. Pemanggilan RPC authenticated (SECURITY INVOKER / DEFINER) dengan Bearer JWT token.
    '''   4. Pemanggilan RPC kiosk publik dan REST query tabel/view dengan RLS aktif.
    ''' </summary>
    Public Module ModSupabaseApi

        ' HttpClient singleton per proses agar efisien dan menghindari socket exhaustion
        Private ReadOnly _http As New HttpClient() With {
            .Timeout = TimeSpan.FromSeconds(15)
        }

        Private _supabaseJwt As String = ""
        Private _jwtExpiry As DateTimeOffset = DateTimeOffset.MinValue

        ''' <summary>Hasil standar panggilan Supabase REST / Auth API.</summary>
        Public Class HasilApi
            Public Property Sukses As Boolean
            Public Property Data As String = ""
            Public Property PesanError As String = ""
            Public Property KodeHttp As Integer
        End Class

        Private Function AmbilKonfigurasi() As (Valid As Boolean, Url As String, AnonKey As String)
            Dim cfg = ModDatabase.AmbilConfigSupabase()
            Dim url As String = If(cfg.Url, "").Trim().TrimEnd("/"c)
            Dim key As String = If(cfg.AnonKey, "").Trim()
            Dim valid As Boolean = url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) AndAlso key.Length > 20
            Return (valid, url, key)
        End Function

        Private Function ErrorKonfigurasi() As HasilApi
            Return New HasilApi With {
                .Sukses = False,
                .KodeHttp = 0,
                .PesanError = "Konfigurasi AppSettings:SupabaseUrl / SupabaseAnonKey belum diatur di appsettings.json."
            }
        End Function

        ' ── 1. Auth — Login via Supabase Auth ───────────────────────────────────

        ''' <summary>
        ''' Login ke Supabase Auth menggunakan email dan password pengguna <c>auth.users</c>.
        ''' Menyimpan JWT <c>access_token</c> di memori sesi untuk panggilan RPC terautentikasi.
        ''' </summary>
        Public Async Function LoginSupabaseAuthAsync(email As String, password As String) As Task(Of HasilApi)
            Dim cfg = AmbilKonfigurasi()
            If Not cfg.Valid Then Return ErrorKonfigurasi()

            Dim url As String = $"{cfg.Url}/auth/v1/token?grant_type=password"
            Dim payload As String = JsonSerializer.Serialize(New With {
                Key .email = email,
                Key .password = password
            })

            Try
                Using req As New HttpRequestMessage(HttpMethod.Post, url)
                    req.Headers.Add("apikey", cfg.AnonKey)
                    req.Content = New StringContent(payload, Encoding.UTF8, "application/json")

                    Using resp As HttpResponseMessage = Await _http.SendAsync(req)
                        Dim body As String = Await resp.Content.ReadAsStringAsync()
                        If resp.IsSuccessStatusCode Then
                            Using doc = JsonDocument.Parse(body)
                                _supabaseJwt = If(doc.RootElement.GetProperty("access_token").GetString(), "")
                                Dim expiresIn As Integer = doc.RootElement.GetProperty("expires_in").GetInt32()
                                _jwtExpiry = DateTimeOffset.UtcNow.AddSeconds(Math.Max(60, expiresIn - 60))
                            End Using
                            Return New HasilApi With {.Sukses = True, .Data = body, .KodeHttp = CInt(resp.StatusCode)}
                        End If
                        Return New HasilApi With {.Sukses = False, .PesanError = body, .KodeHttp = CInt(resp.StatusCode)}
                    End Using
                End Using
            Catch ex As Exception
                Return New HasilApi With {.Sukses = False, .PesanError = ex.Message, .KodeHttp = 0}
            End Try
        End Function

        ''' <summary>Memeriksa apakah token JWT Supabase Auth masih aktif.</summary>
        Public Function TokenMasihValid() As Boolean
            Return _supabaseJwt.Length > 0 AndAlso DateTimeOffset.UtcNow < _jwtExpiry
        End Function

        ''' <summary>Menghapus token JWT Supabase Auth dari memori sesi.</summary>
        Public Sub HapusToken()
            _supabaseJwt = ""
            _jwtExpiry = DateTimeOffset.MinValue
        End Sub

        ' ── 2. Helper Request Builder & Eksekutor ────────────────────────────────

        Private Function BuatRequest(metode As HttpMethod, url As String, anonKey As String,
                                     Optional pakaiJwt As Boolean = True,
                                     Optional prefer As String = "") As HttpRequestMessage
            Dim req As New HttpRequestMessage(metode, url)
            req.Headers.Add("apikey", anonKey)
            Dim bearer As String = If(pakaiJwt AndAlso TokenMasihValid(), _supabaseJwt, anonKey)
            req.Headers.Authorization = New AuthenticationHeaderValue("Bearer", bearer)
            req.Headers.Add("Accept", "application/json")
            If prefer.Length > 0 Then req.Headers.Add("Prefer", prefer)
            Return req
        End Function

        Private Async Function KirimJsonAsync(metode As HttpMethod, pathRelatif As String,
                                              Optional bodyObj As Object = Nothing,
                                              Optional pakaiJwt As Boolean = True,
                                              Optional prefer As String = "") As Task(Of HasilApi)
            Dim cfg = AmbilKonfigurasi()
            If Not cfg.Valid Then Return ErrorKonfigurasi()
            If pakaiJwt AndAlso Not TokenMasihValid() Then
                Return New HasilApi With {.Sukses = False, .KodeHttp = 401, .PesanError = "Sesi JWT Supabase belum login atau kedaluwarsa."}
            End If

            Try
                Using req As HttpRequestMessage = BuatRequest(metode, cfg.Url & pathRelatif, cfg.AnonKey, pakaiJwt, prefer)
                    If bodyObj IsNot Nothing Then
                        req.Content = New StringContent(JsonSerializer.Serialize(bodyObj), Encoding.UTF8, "application/json")
                    End If
                    Using resp As HttpResponseMessage = Await _http.SendAsync(req)
                        Dim body As String = Await resp.Content.ReadAsStringAsync()
                        Return New HasilApi With {
                            .Sukses = resp.IsSuccessStatusCode,
                            .Data = If(resp.IsSuccessStatusCode, body, ""),
                            .PesanError = If(resp.IsSuccessStatusCode, "", body),
                            .KodeHttp = CInt(resp.StatusCode)
                        }
                    End Using
                End Using
            Catch ex As Exception
                Return New HasilApi With {.Sukses = False, .PesanError = ex.Message, .KodeHttp = 0}
            End Try
        End Function

        Private Async Function PanggilRpcAsync(namaFungsi As String, paramsObj As Object,
                                               Optional pakaiJwt As Boolean = True) As Task(Of HasilApi)
            Return Await KirimJsonAsync(HttpMethod.Post, $"/rest/v1/rpc/{namaFungsi}", paramsObj, pakaiJwt)
        End Function

        ' ── 3. RPC Authenticated (Staff / Admin) ─────────────────────────────────

        ''' <summary>Mengambil profil staf yang sedang login via <c>fn_profil_saya()</c>.</summary>
        Public Async Function AmbilProfilSayaAsync() As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_profil_saya", New Object(), pakaiJwt:=True)
        End Function

        ''' <summary>Laporan menu terlaris dalam rentang tanggal via <c>fn_laporan_menu_terlaris</c>.</summary>
        Public Async Function AmbilMenuTerlarisAsync(dari As Date, sampai As Date,
                                                     Optional batas As Integer = 10) As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_laporan_menu_terlaris", New With {
                Key .p_tgl_dari = dari.ToString("yyyy-MM-dd"),
                Key .p_tgl_sampai = sampai.ToString("yyyy-MM-dd"),
                Key .p_batas = batas
            }, pakaiJwt:=True)
        End Function

        ''' <summary>Laporan rekap kategori per hari via <c>fn_laporan_rekap_kategori</c>.</summary>
        Public Async Function AmbilRekapKategoriAsync(dari As Date, sampai As Date) As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_laporan_rekap_kategori", New With {
                Key .p_tgl_dari = dari.ToString("yyyy-MM-dd"),
                Key .p_tgl_sampai = sampai.ToString("yyyy-MM-dd")
            }, pakaiJwt:=True)
        End Function

        ''' <summary>Mengubah status pesanan staf via <c>fn_staff_ubah_status_pesanan</c>.</summary>
        Public Async Function UbahStatusPesananAsync(idPesanan As Integer,
                                                     statusBaru As String) As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_staff_ubah_status_pesanan", New With {
                Key .p_id_pesanan = idPesanan,
                Key .p_status_baru = statusBaru
            }, pakaiJwt:=True)
        End Function

        ''' <summary>Konfirmasi pembayaran tunai oleh kasir/admin via <c>fn_staff_konfirmasi_tunai</c>.</summary>
        Public Async Function KonfirmasiTunaiAsync(idPesanan As Integer,
                                                   uangBayar As Decimal) As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_staff_konfirmasi_tunai", New With {
                Key .p_id_pesanan = idPesanan,
                Key .p_uang_bayar = uangBayar
            }, pakaiJwt:=True)
        End Function

        ''' <summary>Membaca view ringkasan harian via Data API (membutuhkan JWT staf/admin).</summary>
        Public Async Function AmbilRingkasanHarianViaApiAsync(Optional batas As Integer = 30) As Task(Of HasilApi)
            Return Await KirimJsonAsync(HttpMethod.Get,
                $"/rest/v1/v_ringkasan_harian?select=*&order=tanggal.desc&limit={Math.Max(1, batas)}",
                pakaiJwt:=True)
        End Function

        ' ── 4. RPC Anon (Kiosk Self-Service Publik) ──────────────────────────────

        ''' <summary>Mengambil daftar antrian aktif publik via <c>fn_kiosk_antrian_publik()</c>.</summary>
        Public Async Function AmbilAntrianPublikAsync() As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_kiosk_antrian_publik", New Object(), pakaiJwt:=False)
        End Function

        ''' <summary>Mencari member berdasarkan nomor HP via <c>fn_kiosk_cari_member</c>.</summary>
        Public Async Function CariMemberAsync(noHp As String) As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_kiosk_cari_member", New With {
                Key .p_no_hp = noHp
            }, pakaiJwt:=False)
        End Function

        ''' <summary>Mendaftarkan member baru via <c>fn_kiosk_daftar_member</c>.</summary>
        Public Async Function DaftarMemberAsync(noHp As String, nama As String) As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_kiosk_daftar_member", New With {
                Key .p_no_hp = noHp,
                Key .p_nama = nama
            }, pakaiJwt:=False)
        End Function

        ''' <summary>Memberi rating pesanan via <c>fn_kiosk_beri_rating</c>.</summary>
        Public Async Function BeriRatingAsync(idPesanan As Integer, bintang As Integer,
                                              komentar As String) As Task(Of HasilApi)
            Return Await PanggilRpcAsync("fn_kiosk_beri_rating", New With {
                Key .p_id_pesanan = idPesanan,
                Key .p_bintang = bintang,
                Key .p_komentar = komentar
            }, pakaiJwt:=False)
        End Function

        ' ── 5. REST Read Publik (PostgREST + RLS) ────────────────────────────────

        ''' <summary>Mengambil daftar produk via REST API (<c>GET /rest/v1/produk</c>).</summary>
        Public Async Function AmbilProdukViaApiAsync(Optional idKategori As Integer = 0,
                                                     Optional hanyaTersedia As Boolean = True) As Task(Of HasilApi)
            Dim filter As String = ""
            If hanyaTersedia Then filter &= "&tersedia=eq.true"
            If idKategori > 0 Then filter &= $"&id_kategori=eq.{idKategori}"
            Return Await KirimJsonAsync(HttpMethod.Get,
                $"/rest/v1/produk?select=id_produk,id_kategori,nama,deskripsi,harga,gambar,tersedia,best_seller,stok{filter}&order=id_produk.asc",
                pakaiJwt:=False)
        End Function

        ''' <summary>Mengambil daftar kategori via REST API (<c>GET /rest/v1/kategori</c>).</summary>
        Public Async Function AmbilKategoriViaApiAsync() As Task(Of HasilApi)
            Return Await KirimJsonAsync(HttpMethod.Get,
                "/rest/v1/kategori?select=id_kategori,nama,urutan&order=urutan.asc",
                pakaiJwt:=False)
        End Function

        ''' <summary>Memverifikasi konektivitas ke Supabase REST API lewat RPC anon publik.</summary>
        Public Async Function VerifikasiKoneksiAsync() As Task(Of Boolean)
            Try
                Dim hasil As HasilApi = Await AmbilAntrianPublikAsync()
                Return hasil.KodeHttp = 200
            Catch
                Return False
            End Try
        End Function

    End Module

End Namespace
