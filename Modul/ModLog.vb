Option Strict On
Option Explicit On

Imports System.Diagnostics
Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModLog

        Public Sub Catat(aksi As String, Optional keterangan As String = "")
            If String.IsNullOrWhiteSpace(aksi) Then Return
            ModDummyStore.PastikanInit()

            Dim idUser As Integer? = If(ModSesi.SudahLogin(), CType(ModSesi.IdPengguna, Integer?), Nothing)
            Dim namaUser As String = If(ModSesi.SudahLogin(), ModSesi.NamaPengguna, "Pelanggan Kiosk")
            ModDummyStore.TambahLogInternal(DateTime.Now, idUser, namaUser, aksi.Trim(), keterangan)

            If ModDatabase.DatabaseTerhubung() Then
                Try
                    Dim idObj As Object = If(idUser.HasValue, CObj(idUser.Value), DBNull.Value)
                    Dim prm As New Dictionary(Of String, Object) From {
                        {"id_pengguna", idObj},
                        {"aksi", aksi.Trim()},
                        {"keterangan", If(keterangan, "")}
                    }
                    Dim sql As String = "INSERT INTO log_aktivitas (id_pengguna, aksi, keterangan) VALUES (@id_pengguna, @aksi, @keterangan)"
                    ModFunction.EksekusiData(sql, prm)
                Catch ex As Exception
                    Debug.WriteLine("Gagal mencatat log ke database: " & ex.Message)
                End Try
            End If
        End Sub

        Public Function AmbilLog(Optional tglDari As DateTime? = Nothing, Optional tglSampai As DateTime? = Nothing) As DataTable
            ModDummyStore.PastikanInit()

            If ModDatabase.DatabaseTerhubung() Then
                Try
                    Dim dari As DateTime = If(tglDari, DateTime.Today.AddDays(-30)).Date
                    Dim sampai As DateTime = If(tglSampai, DateTime.Today).Date
                    Dim prm As New Dictionary(Of String, Object) From {
                        {"dari", dari},
                        {"sampai", sampai}
                    }
                    Dim sql As String =
                        "SELECT l.id_log, l.waktu, COALESCE(p.nama, 'Pelanggan Kiosk') AS pengguna, l.aksi, COALESCE(l.keterangan, '') AS keterangan " &
                        "FROM log_aktivitas l " &
                        "LEFT JOIN pengguna p ON p.id_pengguna = l.id_pengguna " &
                        "WHERE l.waktu::date BETWEEN @dari AND @sampai " &
                        "ORDER BY l.waktu DESC LIMIT 500"
                    Dim dtDb = ModFunction.AmbilData(sql, prm)
                    If dtDb IsNot Nothing Then Return dtDb
                Catch ex As Exception
                    Debug.WriteLine("Gagal memuat log dari database: " & ex.Message)
                End Try
            End If

            Dim dt As New DataTable()
            dt.Columns.Add("id_log", GetType(Long))
            dt.Columns.Add("waktu", GetType(DateTime))
            dt.Columns.Add("pengguna", GetType(String))
            dt.Columns.Add("aksi", GetType(String))
            dt.Columns.Add("keterangan", GetType(String))

            Dim q = ModDummyStore.LogList.AsEnumerable()
            If tglDari.HasValue Then
                q = q.Where(Function(x) x.Waktu.Date >= tglDari.Value.Date)
            End If
            If tglSampai.HasValue Then
                q = q.Where(Function(x) x.Waktu.Date <= tglSampai.Value.Date)
            End If

            For Each item In q.OrderByDescending(Function(x) x.Waktu).Take(500)
                dt.Rows.Add(item.IdLog, item.Waktu, item.NamaPengguna, item.Aksi, item.Keterangan)
            Next
            Return dt
        End Function

    End Module
End Namespace
