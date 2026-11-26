Option Strict On
Option Explicit On

Imports System.Collections.Concurrent

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModCache

        Private Class CacheEntry
            Public Property Nilai As Object
            Public Property Kedaluwarsa As DateTime
        End Class

        Private ReadOnly _store As New ConcurrentDictionary(Of String, CacheEntry)(StringComparer.OrdinalIgnoreCase)

        Public Function Ambil(Of T)(kunci As String, ttlDetik As Integer, pengambil As Func(Of T)) As T
            If String.IsNullOrWhiteSpace(kunci) Then
                Throw New ArgumentException("Kunci cache tidak boleh kosong.", NameOf(kunci))
            End If
            If pengambil Is Nothing Then
                Throw New ArgumentNullException(NameOf(pengambil))
            End If
            If ttlDetik < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(ttlDetik))
            End If

            Dim sekarang As DateTime = DateTime.UtcNow
            Dim entry As CacheEntry = Nothing
            If _store.TryGetValue(kunci, entry) AndAlso entry.Kedaluwarsa > sekarang Then
                If entry.Nilai Is Nothing Then Return Nothing
                If TypeOf entry.Nilai Is T Then
                    Return DirectCast(entry.Nilai, T)
                End If
            End If

            Dim nilaiBaru As T = pengambil()
            Dim cacheBaru As New CacheEntry With {
                .Nilai = nilaiBaru,
                .Kedaluwarsa = sekarang.AddSeconds(ttlDetik)
            }
            _store.AddOrUpdate(kunci, cacheBaru, Function(key, oldVal) cacheBaru)
            Return nilaiBaru
        End Function

        Public Sub Hapus(kunci As String)
            If String.IsNullOrWhiteSpace(kunci) Then Return
            Dim removed As CacheEntry = Nothing
            _store.TryRemove(kunci, removed)
        End Sub

        Public Sub HapusAwalan(awalan As String)
            If String.IsNullOrWhiteSpace(awalan) Then Return
            For Each k As String In _store.Keys
                If k.StartsWith(awalan, StringComparison.OrdinalIgnoreCase) Then
                    Hapus(k)
                End If
            Next
        End Sub

        Public Sub HapusSemua()
            _store.Clear()
        End Sub

    End Module
End Namespace
