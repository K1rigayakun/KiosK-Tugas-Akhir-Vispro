Option Strict On
Option Explicit On

Imports System.Threading
Imports System.Threading.Tasks
Imports Npgsql

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModFunction

        Private Sub TambahParameter(cmd As NpgsqlCommand, prm As Dictionary(Of String, Object))
            If prm Is Nothing Then Return
            For Each kvp In prm
                Dim nama As String = kvp.Key.TrimStart("@"c, ":"c)
                cmd.Parameters.AddWithValue(nama, If(kvp.Value, DBNull.Value))
            Next
        End Sub

        Public Function AmbilData(sql As String, Optional prm As Dictionary(Of String, Object) = Nothing) As DataTable
            Dim dt As New DataTable()
            Using conn = ModDatabase.BukaKoneksi()
                Using cmd As New NpgsqlCommand(sql, conn)
                    TambahParameter(cmd, prm)
                    Using rdr = cmd.ExecuteReader()
                        dt.Load(rdr)
                    End Using
                End Using
            End Using
            Return dt
        End Function

        Public Function EksekusiData(sql As String, Optional prm As Dictionary(Of String, Object) = Nothing) As Integer
            Using conn = ModDatabase.BukaKoneksi()
                Using cmd As New NpgsqlCommand(sql, conn)
                    TambahParameter(cmd, prm)
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using
        End Function

        Public Function EksekusiScalar(sql As String, Optional prm As Dictionary(Of String, Object) = Nothing) As Object
            Using conn = ModDatabase.BukaKoneksi()
                Using cmd As New NpgsqlCommand(sql, conn)
                    TambahParameter(cmd, prm)
                    Return cmd.ExecuteScalar()
                End Using
            End Using
        End Function

        Public Async Function AmbilDataAsync(sql As String,
                                             Optional prm As Dictionary(Of String, Object) = Nothing,
                                             Optional cancellationToken As CancellationToken = Nothing) As Task(Of DataTable)
            Dim dt As New DataTable()
            Using conn As New NpgsqlConnection(ModDatabase.AmbilConnectionString())
                Await conn.OpenAsync(cancellationToken)
                Using cmd As New NpgsqlCommand(sql, conn)
                    TambahParameter(cmd, prm)
                    Using rdr = Await cmd.ExecuteReaderAsync(cancellationToken)
                        For i As Integer = 0 To rdr.FieldCount - 1
                            dt.Columns.Add(rdr.GetName(i), rdr.GetFieldType(i))
                        Next
                        While Await rdr.ReadAsync(cancellationToken)
                            Dim vals(rdr.FieldCount - 1) As Object
                            rdr.GetValues(vals)
                            dt.Rows.Add(vals)
                        End While
                    End Using
                End Using
            End Using
            Return dt
        End Function

        Public Async Function EksekusiDataAsync(sql As String,
                                                Optional prm As Dictionary(Of String, Object) = Nothing,
                                                Optional cancellationToken As CancellationToken = Nothing) As Task(Of Integer)
            Using conn As New NpgsqlConnection(ModDatabase.AmbilConnectionString())
                Await conn.OpenAsync(cancellationToken)
                Using cmd As New NpgsqlCommand(sql, conn)
                    TambahParameter(cmd, prm)
                    Return Await cmd.ExecuteNonQueryAsync(cancellationToken)
                End Using
            End Using
        End Function

        Public Async Function EksekusiScalarAsync(sql As String,
                                                  Optional prm As Dictionary(Of String, Object) = Nothing,
                                                  Optional cancellationToken As CancellationToken = Nothing) As Task(Of Object)
            Using conn As New NpgsqlConnection(ModDatabase.AmbilConnectionString())
                Await conn.OpenAsync(cancellationToken)
                Using cmd As New NpgsqlCommand(sql, conn)
                    TambahParameter(cmd, prm)
                    Return Await cmd.ExecuteScalarAsync(cancellationToken)
                End Using
            End Using
        End Function

    End Module
End Namespace
