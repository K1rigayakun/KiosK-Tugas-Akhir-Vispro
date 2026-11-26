Option Strict On
Option Explicit On

Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Namespace VisproPrakProjectAkhir.Modul

    ''' <summary>
    ''' Utilitas pembuatan dan verifikasi hash password PBKDF2-SHA256 (integrasi Modul A1).
    ''' </summary>
    Public Class BuatPassword

        Public Shared Function BuatHash(password As String) As String
            Dim salt(15) As Byte
            RandomNumberGenerator.Fill(salt)

            Dim iterasi As Integer = 100000
            Dim hasil As Byte() = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterasi,
                HashAlgorithmName.SHA256,
                32
            )

            Return "pbkdf2$" & iterasi.ToString() & "$" & Convert.ToBase64String(salt) & "$" & Convert.ToBase64String(hasil)
        End Function

        Public Shared Function VerifikasiHash(password As String, passwordHash As String) As Boolean
            Try
                ' Trim whitespace - penting untuk data lama yang mungkin punya leading/trailing space
                passwordHash = If(passwordHash, "").Trim()
                If String.IsNullOrWhiteSpace(passwordHash) Then Return False
                If passwordHash.StartsWith("pbkdf2$", StringComparison.Ordinal) Then
                    Dim bagian() As String = passwordHash.Split("$"c)
                    If bagian.Length <> 4 Then Return False

                    Dim iterasi As Integer
                    If Not Integer.TryParse(bagian(1), iterasi) Then Return False
                    If iterasi < 100000 OrElse iterasi > 10000000 Then Return False

                    Dim salt As Byte() = Convert.FromBase64String(bagian(2))
                    Dim hashAsli As Byte() = Convert.FromBase64String(bagian(3))
                    If salt.Length <> 16 OrElse hashAsli.Length <> 32 Then Return False

                    Dim hashInput As Byte() = Rfc2898DeriveBytes.Pbkdf2(
                        Encoding.UTF8.GetBytes(password),
                        salt,
                        iterasi,
                        HashAlgorithmName.SHA256,
                        hashAsli.Length
                    )
                    Return CryptographicOperations.FixedTimeEquals(hashInput, hashAsli)
                Else
                    Dim bytes As Byte() = SHA256.HashData(Encoding.UTF8.GetBytes(password))
                    Dim hex As String = Convert.ToHexString(bytes).ToLowerInvariant()
                    Return CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(hex), Encoding.UTF8.GetBytes(passwordHash.ToLowerInvariant()))
                End If
            Catch
                Return False
            End Try
        End Function

        Public Shared Sub Jalankan()
            Dim password As String = Interaction.InputBox(
                "Masukkan password baru untuk admin:",
                "Reset Password Admin"
            )
            If String.IsNullOrWhiteSpace(password) Then Return

            Dim hash As String = BuatHash(password)
            Clipboard.SetText(hash)
            MessageBox.Show(
                "Hash berhasil dibuat dan disalin." & Environment.NewLine &
                "Silakan simpan hash tersebut untuk update Supabase.",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

    End Class
End Namespace

