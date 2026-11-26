Option Strict On
Option Explicit On

Imports System.IO
Imports Microsoft.Extensions.Configuration
Imports Npgsql

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModDatabase

        Private _connStr As String = ""
        Private _connStrLoaded As Boolean = False
        Private _dbTersedia As Boolean? = Nothing
        Private _lastCheckUtc As DateTime = DateTime.MinValue

        Public Property PaksaModeDummy As Boolean = False

        ''' <summary>Kunci enkripsi untuk config — dibaca dari env var BISTRO_CONFIG_KEY saat runtime.</summary>
        Private Function AmbilKunciEnkripsi() As String
            Dim k As String = Environment.GetEnvironmentVariable("BISTRO_CONFIG_KEY")
            If String.IsNullOrWhiteSpace(k) Then
                ' Fallback: gunakan machine name + app name (cukup untuk dev; production pakai env var)
                k = $"BistroKiosk_{Environment.MachineName}_2026"
            End If
            Return k
        End Function

        Public Function AmbilConnectionString() As String
            If _connStrLoaded Then Return _connStr
            _connStrLoaded = True

            Dim appDir As String = AppContext.BaseDirectory
            Dim cfgPath As String = Path.Combine(appDir, "appsettings.json")
            If Not File.Exists(cfgPath) Then
                _connStr = ""
                Return _connStr
            End If

            Try
                Dim config = New ConfigurationBuilder() _
                    .SetBasePath(appDir) _
                    .AddJsonFile("appsettings.json", optional:=True, reloadOnChange:=False) _
                    .Build()

                Dim cs As String = config.GetConnectionString("Default")
                If String.IsNullOrWhiteSpace(cs) Then
                    cs = config.GetConnectionString("Supabase")
                End If
                If Not String.IsNullOrWhiteSpace(cs) AndAlso cs.StartsWith("ENCv1$") Then
                    Try
                        cs = VisproPrakProjectAkhir.Modul.ModKeamananConfig.DekripsiTeks(cs, AmbilKunciEnkripsi())
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("[ModDatabase] Dekripsi config gagal: " & ex.Message)
                        cs = ""
                    End Try
                End If
                _connStr = If(cs, "")
            Catch
                _connStr = ""
            End Try
            Return _connStr
        End Function

        ''' <summary>Ambil konfigurasi Supabase (URL, bucket, anon key) dari appsettings.json.</summary>
        Public Function AmbilConfigSupabase() As (Url As String, Bucket As String, AnonKey As String)
            Dim appDir As String = AppContext.BaseDirectory
            Try
                Dim config = New ConfigurationBuilder() _
                    .SetBasePath(appDir) _
                    .AddJsonFile("appsettings.json", optional:=True, reloadOnChange:=False) _
                    .Build()
                Dim url As String = config("AppSettings:SupabaseUrl")
                Dim bucket As String = config("AppSettings:SupabaseBucket")
                Dim key As String = config("AppSettings:SupabaseAnonKey")
                Return (If(url, ""), If(bucket, "kiosk-assets"), If(key, ""))
            Catch
                Return ("", "kiosk-assets", "")
            End Try
        End Function

        ''' <summary>Pesan kesalahan yang aman untuk ditampilkan ke pengguna (tanpa detail teknis sensitif).</summary>
        Public Function PesanKesalahanAman(ex As Exception) As String
            Dim msg As String = ex.Message
            ' Sembunyikan detail koneksi dari pesan error
            If msg.Contains("password") OrElse msg.Contains("Password") OrElse
               msg.Contains("Host=") OrElse msg.Contains("Username=") Then
                Return "Koneksi database gagal. Hubungi administrator sistem."
            End If
            If TypeOf ex Is Npgsql.NpgsqlException Then
                Dim npgEx = DirectCast(ex, Npgsql.NpgsqlException)
                Return $"Kesalahan database ({npgEx.SqlState}): {SanitasiPesan(msg)}"
            End If
            Return "Terjadi kesalahan: " & SanitasiPesan(msg)
        End Function

        Private Function SanitasiPesan(msg As String) As String
            ' Potong pesan panjang dan hilangkan detail teknis
            If msg.Length > 200 Then msg = msg.Substring(0, 200) & "..."
            Return msg
        End Function

        Private Function KonfigurasiValid(cs As String) As Boolean
            If String.IsNullOrWhiteSpace(cs) Then Return False
            If cs.Contains("<PROJECT_REF>", StringComparison.OrdinalIgnoreCase) Then Return False
            If cs.Contains("ISI_HOST", StringComparison.OrdinalIgnoreCase) Then Return False
            If cs.Contains("ISI_PASSWORD", StringComparison.OrdinalIgnoreCase) Then Return False
            Return True
        End Function

        Public Function DatabaseTerhubung(Optional paksaCekUlang As Boolean = False) As Boolean
            If PaksaModeDummy Then Return False
            Dim cs As String = AmbilConnectionString()
            If Not KonfigurasiValid(cs) Then Return False

            If Not paksaCekUlang AndAlso _dbTersedia.HasValue AndAlso (DateTime.UtcNow - _lastCheckUtc).TotalSeconds < 30 Then
                Return _dbTersedia.Value
            End If

            Dim hasil As Boolean = TesKoneksi()
            _dbTersedia = hasil
            _lastCheckUtc = DateTime.UtcNow
            Return hasil
        End Function

        Public Function ModeDummyAktif() As Boolean
            If PaksaModeDummy Then Return True
            Dim cs As String = AmbilConnectionString()
            If Not KonfigurasiValid(cs) Then Return True
            Return Not DatabaseTerhubung(False)
        End Function

        Public Function BukaKoneksi() As NpgsqlConnection
            Dim cs As String = AmbilConnectionString()
            If Not KonfigurasiValid(cs) Then
                Throw New InvalidOperationException("appsettings.json belum dikonfigurasi. Aplikasi berjalan dalam Mode Visual Dummy.")
            End If
            ' Pastikan SSL + keamanan koneksi
            Dim csb As New Npgsql.NpgsqlConnectionStringBuilder(cs)
            csb.SslMode = Npgsql.SslMode.Require
            csb.PersistSecurityInfo = False
            csb.CommandTimeout = 30
            Dim conn As New NpgsqlConnection(csb.ConnectionString)
            Try
                conn.Open()
                Return conn
            Catch ex As Exception
                conn.Dispose()
                Throw New Exception(PesanKesalahanAman(ex), ex)
            End Try
        End Function

        Public Function TesKoneksi() As Boolean
            If PaksaModeDummy Then Return False
            Dim cs As String = AmbilConnectionString()
            If Not KonfigurasiValid(cs) Then Return False
            Try
                Using conn = BukaKoneksi()
                    Using cmd As New NpgsqlCommand("SELECT 1", conn)
                        Dim res = cmd.ExecuteScalar()
                        Return Convert.ToInt32(res) = 1
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("Tes koneksi gagal: " & ex.Message)
                Return False
            End Try
        End Function

        Public Async Function TesKoneksiAsync() As Task(Of Boolean)
            If PaksaModeDummy Then Return False
            Dim cs As String = AmbilConnectionString()
            If Not KonfigurasiValid(cs) Then Return False
            Try
                Using conn As New NpgsqlConnection(cs)
                    Await conn.OpenAsync()
                    Using cmd As New NpgsqlCommand("SELECT 1", conn)
                        Dim res = Await cmd.ExecuteScalarAsync()
                        Return Convert.ToInt32(res) = 1
                    End Using
                End Using
            Catch
                Return False
            End Try
        End Function

        Public Function CekKoneksiDetail() As String
            If PaksaModeDummy Then
                Return "MODE DUMMY AKTIF (PaksaModeDummy = True)."
            End If
            Dim cs As String = AmbilConnectionString()
            If Not KonfigurasiValid(cs) Then
                Return "KONEKSI BELUM DIKONFIGURASI." & Environment.NewLine & "Berjalan dalam Mode Visual Dummy."
            End If
            Try
                Using conn = BukaKoneksi()
                    Using cmd As New NpgsqlCommand("SELECT COUNT(*) FROM pengguna", conn)
                        Dim cnt = Convert.ToInt32(cmd.ExecuteScalar())
                        _dbTersedia = True
                        _lastCheckUtc = DateTime.UtcNow
                        Return $"KONEKSI BERHASIL!{Environment.NewLine}Terhubung ke Supabase PostgreSQL (jumlah pengguna: {cnt})."
                    End Using
                End Using
            Catch ex As Exception
                _dbTersedia = False
                _lastCheckUtc = DateTime.UtcNow
                Return "KONEKSI GAGAL!" & Environment.NewLine & Environment.NewLine & "Penyebab: " & ex.Message
            End Try
        End Function

    End Module
End Namespace
