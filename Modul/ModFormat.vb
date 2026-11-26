Option Strict On
Option Explicit On

Imports System.Globalization

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModFormat

        Private ReadOnly _idCulture As New CultureInfo("id-ID")

        Public Function Rupiah(nilai As Decimal) As String
            Dim bulat As Decimal = Math.Round(nilai, 0, MidpointRounding.AwayFromZero)
            If bulat < 0D Then
                Return "-Rp" & Math.Abs(bulat).ToString("N0", _idCulture)
            End If
            Return "Rp" & bulat.ToString("N0", _idCulture)
        End Function

        Public Function Angka(nilai As Decimal) As String
            Return nilai.ToString("N0", _idCulture)
        End Function

        Public Function Durasi(d As TimeSpan) As String
            If d < TimeSpan.Zero Then d = TimeSpan.Zero
            Dim totalMenit As Integer = CInt(Math.Floor(d.TotalMinutes))
            Return $"{totalMenit:00}:{d.Seconds:00}"
        End Function

        Public Function FormatTanggal(nilaiTanggal As DateTime) As String
            Return nilaiTanggal.ToString("dd MMMM yyyy", _idCulture)
        End Function

        Public Function TanggalJam(tanggal As DateTime) As String
            Return tanggal.ToString("dd MMMM yyyy HH:mm:ss", _idCulture)
        End Function

        Public Function NoAntrianStr(noAntrian As Integer) As String
            Return $"#{noAntrian:000}"
        End Function

    End Module
End Namespace
