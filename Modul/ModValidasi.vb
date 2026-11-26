Option Strict On
Option Explicit On

Imports System.Globalization
Imports System.Windows.Forms

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModValidasi

        Public Function WajibIsi(ctrl As Control, ep As ErrorProvider, pesan As String) As Boolean
            If ctrl Is Nothing Then Return False
            Dim teks As String = If(ctrl.Text, "").Trim()
            If String.IsNullOrEmpty(teks) Then
                If ep IsNot Nothing Then ep.SetError(ctrl, pesan)
                Return False
            End If
            If ep IsNot Nothing Then ep.SetError(ctrl, "")
            Return True
        End Function

        Public Function BacaAngka(ctrl As Control, ep As ErrorProvider, ByRef hasil As Decimal) As Boolean
            If ctrl Is Nothing Then
                hasil = 0D
                Return False
            End If
            Dim raw As String = If(ctrl.Text, "").Trim()
            ' Izinkan pemisah ribuan titik atau koma jika pengguna mengetik angka bersih
            Dim cleaned As String = raw.Replace(".", "").Replace(",", "").Replace("Rp", "").Trim()
            If Decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.InvariantCulture, hasil) Then
                If ep IsNot Nothing Then ep.SetError(ctrl, "")
                Return True
            End If
            If Decimal.TryParse(raw, NumberStyles.Number, New CultureInfo("id-ID"), hasil) Then
                If ep IsNot Nothing Then ep.SetError(ctrl, "")
                Return True
            End If
            If ep IsNot Nothing Then ep.SetError(ctrl, "Masukkan angka yang valid.")
            hasil = 0D
            Return False
        End Function

        Public Sub HanyaAngka(e As KeyPressEventArgs)
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        End Sub

    End Module
End Namespace

