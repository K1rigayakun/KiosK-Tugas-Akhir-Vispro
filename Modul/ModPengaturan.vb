Option Strict On
Option Explicit On

Imports System.Globalization

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModPengaturan

        Public Sub Muat()
            ModDummyStore.PastikanInit()
            If Not ModDatabase.DatabaseTerhubung() Then Return
            Try
                Dim dt = ModFunction.AmbilData("SELECT kunci, nilai FROM pengaturan")
                For Each row As DataRow In dt.Rows
                    Dim k As String = Convert.ToString(row("kunci"), CultureInfo.InvariantCulture)
                    Dim v As String = Convert.ToString(row("nilai"), CultureInfo.InvariantCulture)
                    If Not String.IsNullOrWhiteSpace(k) Then
                        ModDummyStore.PengaturanDict(k) = If(v, "")
                    End If
                Next
            Catch
            End Try
        End Sub

        Public Function Ambil(kunci As String, Optional def As String = "") As String
            ModDummyStore.PastikanInit()
            If String.IsNullOrWhiteSpace(kunci) Then Return def

            Dim keyTrim As String = kunci.Trim()
            If ModDatabase.DatabaseTerhubung() Then
                Try
                    Return ModCache.Ambil("cfg:" & keyTrim, 30, Function()
                                                                   Dim prm As New Dictionary(Of String, Object) From {{"kunci", keyTrim}}
                                                                   Dim sql As String = "SELECT nilai FROM pengaturan WHERE kunci = @kunci LIMIT 1"
                                                                   Dim res = ModFunction.EksekusiScalar(sql, prm)
                                                                   If res Is Nothing OrElse Convert.IsDBNull(res) Then
                                                                       Dim localFallback As String = ""
                                                                       If ModDummyStore.PengaturanDict.TryGetValue(keyTrim, localFallback) Then Return localFallback
                                                                       Return def
                                                                   End If
                                                                   Dim s = Convert.ToString(res, CultureInfo.InvariantCulture)
                                                                   ModDummyStore.PengaturanDict(keyTrim) = If(s, "")
                                                                   Return If(s, def)
                                                               End Function)
                Catch
                End Try
            End If

            Dim val As String = ""
            If ModDummyStore.PengaturanDict.TryGetValue(keyTrim, val) Then
                Return val
            End If
            Return def
        End Function

        Public Function AmbilInt(kunci As String, def As Integer) As Integer
            Dim raw As String = Ambil(kunci, "")
            Dim hasil As Integer
            If Integer.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, hasil) Then
                Return hasil
            End If
            Return def
        End Function

        Public Function AmbilDesimal(kunci As String, def As Decimal) As Decimal
            Dim raw As String = Ambil(kunci, "")
            Dim hasil As Decimal
            If Decimal.TryParse(raw, NumberStyles.Number, CultureInfo.InvariantCulture, hasil) Then
                Return hasil
            End If
            Return def
        End Function

        Public Sub Simpan(kunci As String, nilai As String)
            ModDummyStore.PastikanInit()
            If String.IsNullOrWhiteSpace(kunci) Then
                Throw New ArgumentException("Kunci pengaturan tidak boleh kosong.")
            End If

            Dim keyTrim As String = kunci.Trim()
            Dim valClean As String = If(nilai, "")
            ModDummyStore.PengaturanDict(keyTrim) = valClean
            ModCache.Hapus("cfg:" & keyTrim)

            If ModDatabase.DatabaseTerhubung() Then
                Dim prm As New Dictionary(Of String, Object) From {
                    {"kunci", keyTrim},
                    {"nilai", valClean}
                }
                Dim sql As String = "INSERT INTO pengaturan (kunci, nilai) VALUES (@kunci, @nilai) ON CONFLICT (kunci) DO UPDATE SET nilai = EXCLUDED.nilai"
                ModFunction.EksekusiData(sql, prm)
            End If
        End Sub

        Public Function AmbilSemua() As Dictionary(Of String, String)
            ModDummyStore.PastikanInit()
            Return New Dictionary(Of String, String)(ModDummyStore.PengaturanDict, StringComparer.OrdinalIgnoreCase)
        End Function

    End Module
End Namespace
