Option Strict On
Option Explicit On

Imports System.Data
Imports Npgsql
Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModMember

        Public Function Cari(noHp As String) As Member
            Dim clean As String = If(noHp, "").Trim()
            If String.IsNullOrEmpty(clean) Then Return Nothing

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT id_member, no_hp, nama, poin FROM public.member WHERE no_hp = @hp LIMIT 1", conn)
                            cmd.Parameters.AddWithValue("hp", clean)
                            Using rd = cmd.ExecuteReader()
                                If rd.Read() Then
                                    Return New Member With {
                                        .IdMember = rd.GetInt32(0),
                                        .NoHp = rd.GetString(1),
                                        .Nama = rd.GetString(2),
                                        .Poin = rd.GetInt32(3)
                                    }
                                End If
                                Return Nothing
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModMember] Cari live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            Return ModDummyStore.MemberList.FirstOrDefault(Function(m) String.Equals(m.NoHp, clean, StringComparison.OrdinalIgnoreCase))
        End Function

        Public Function Daftar(noHp As String, nama As String) As Member
            Dim hpClean As String = If(noHp, "").Trim()
            Dim namaClean As String = If(nama, "").Trim()
            If String.IsNullOrEmpty(hpClean) OrElse String.IsNullOrEmpty(namaClean) Then
                Throw New ArgumentException("Nomor HP dan nama member wajib diisi.")
            End If

            If Not ModDatabase.ModeDummyAktif() Then
                Using conn = ModDatabase.BukaKoneksi()
                    Using cmd As New NpgsqlCommand(
                        "INSERT INTO public.member (no_hp, nama, poin) VALUES (@hp, @nama, 0) " &
                        "ON CONFLICT (no_hp) DO UPDATE SET nama = EXCLUDED.nama " &
                        "RETURNING id_member, no_hp, nama, poin", conn)
                        cmd.Parameters.AddWithValue("hp", hpClean)
                        cmd.Parameters.AddWithValue("nama", namaClean)
                        Using rd = cmd.ExecuteReader()
                            If rd.Read() Then
                                Dim res As New Member With {
                                    .IdMember = rd.GetInt32(0),
                                    .NoHp = rd.GetString(1),
                                    .Nama = rd.GetString(2),
                                    .Poin = rd.GetInt32(3)
                                }
                                ModLog.Catat(KodeAksi.MemberUbah, $"Daftar/update member: {res.Nama} ({res.NoHp})")
                                Return res
                            End If
                        End Using
                    End Using
                End Using
            End If

            ModDummyStore.PastikanInit()
            Dim existing = ModDummyStore.MemberList.FirstOrDefault(Function(m) String.Equals(m.NoHp, hpClean, StringComparison.OrdinalIgnoreCase))
            If existing IsNot Nothing Then Return existing

            Dim mem As New Member With {
                .IdMember = ModDummyStore.NextMemberId,
                .NoHp = hpClean,
                .Nama = namaClean,
                .Poin = 0
            }
            ModDummyStore.NextMemberId += 1
            ModDummyStore.MemberList.Add(mem)
            ModLog.Catat(KodeAksi.MemberUbah, $"Daftar member baru: {mem.Nama} ({mem.NoHp})")
            Return mem
        End Function

        Public Function AmbilSemua() As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("id_member", GetType(Integer))
            dt.Columns.Add("no_hp", GetType(String))
            dt.Columns.Add("nama", GetType(String))
            dt.Columns.Add("poin", GetType(Integer))

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT id_member, no_hp, nama, poin FROM public.member ORDER BY poin DESC, nama", conn)
                            Using rd = cmd.ExecuteReader()
                                Do While rd.Read()
                                    dt.Rows.Add(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3))
                                Loop
                            End Using
                        End Using
                    End Using
                    Return dt
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[ModMember] AmbilSemua live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            For Each m In ModDummyStore.MemberList.OrderByDescending(Function(x) x.Poin)
                dt.Rows.Add(m.IdMember, m.NoHp, m.Nama, m.Poin)
            Next
            Return dt
        End Function

        Public Function Ubah(idMember As Integer, noHp As String, nama As String) As Boolean
            Dim hpClean As String = If(noHp, "").Trim()
            Dim namaClean As String = If(nama, "").Trim()
            If idMember <= 0 OrElse String.IsNullOrEmpty(hpClean) OrElse String.IsNullOrEmpty(namaClean) Then Return False

            If Not ModDatabase.ModeDummyAktif() Then
                Using conn = ModDatabase.BukaKoneksi()
                    Using cmd As New NpgsqlCommand(
                        "UPDATE public.member SET no_hp = @hp, nama = @nama WHERE id_member = @id", conn)
                        cmd.Parameters.AddWithValue("hp", hpClean)
                        cmd.Parameters.AddWithValue("nama", namaClean)
                        cmd.Parameters.AddWithValue("id", idMember)
                        Dim affected = cmd.ExecuteNonQuery()
                        If affected > 0 Then
                            ModLog.Catat(KodeAksi.MemberUbah, $"Ubah data member {namaClean} ({hpClean})")
                            Return True
                        End If
                        Return False
                    End Using
                End Using
            End If

            ModDummyStore.PastikanInit()
            Dim ex = ModDummyStore.MemberList.FirstOrDefault(Function(m) m.IdMember = idMember)
            If ex Is Nothing Then Return False
            ex.NoHp = hpClean
            ex.Nama = namaClean
            ModLog.Catat(KodeAksi.MemberUbah, $"Ubah data member {ex.Nama}")
            Return True
        End Function

        Public Function AturSaldoPoin(idMember As Integer, poinBaru As Integer, alasan As String) As Boolean
            If idMember <= 0 OrElse poinBaru < 0 Then Return False

            If Not ModDatabase.ModeDummyAktif() Then
                Using conn = ModDatabase.BukaKoneksi()
                    Dim namaMem As String = ""
                    Dim poinLama As Integer = 0
                    Using cmdGet As New NpgsqlCommand("SELECT nama, poin FROM public.member WHERE id_member = @id", conn)
                        cmdGet.Parameters.AddWithValue("id", idMember)
                        Using rd = cmdGet.ExecuteReader()
                            If Not rd.Read() Then Return False
                            namaMem = rd.GetString(0)
                            poinLama = rd.GetInt32(1)
                        End Using
                    End Using
                    Using cmdUpd As New NpgsqlCommand("UPDATE public.member SET poin = @poin WHERE id_member = @id", conn)
                        cmdUpd.Parameters.AddWithValue("poin", poinBaru)
                        cmdUpd.Parameters.AddWithValue("id", idMember)
                        cmdUpd.ExecuteNonQuery()
                    End Using
                    ModLog.Catat(KodeAksi.MemberUbah, $"Poin {namaMem} diubah {poinLama} -> {poinBaru} ({If(alasan, "").Trim()})")
                    Return True
                End Using
            End If

            ModDummyStore.PastikanInit()
            Dim ex = ModDummyStore.MemberList.FirstOrDefault(Function(m) m.IdMember = idMember)
            If ex Is Nothing Then Return False
            Dim lama As Integer = ex.Poin
            ex.Poin = poinBaru
            ModLog.Catat(KodeAksi.MemberUbah, $"Poin {ex.Nama} diubah {lama} -> {ex.Poin} ({If(alasan, "").Trim()})")
            Return True
        End Function

    End Module
End Namespace
