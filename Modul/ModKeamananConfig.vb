Option Strict On
Option Explicit On

Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Extensions.Configuration

Namespace VisproPrakProjectAkhir.Modul

    ''' <summary>
    ''' Enkripsi/dekripsi konfigurasi sensitif menggunakan AES-256-GCM.
    ''' Format ciphertext: ENCv1$<base64(salt16)>$<base64(nonce12)>$<base64(tag16+cipher)>
    ''' </summary>
    Public Module ModKeamananConfig

        Private Const HEADER As String = "ENCv1$"
        Private Const PBKDF2_ITER As Integer = 100000
        Private Const KEY_LEN As Integer = 32
        Private Const SALT_LEN As Integer = 16
        Private Const NONCE_LEN As Integer = 12
        Private Const TAG_LEN As Integer = 16

        ''' <summary>Enkripsi teks plaintext menjadi format ENCv1$...</summary>
        Public Function EnskripsiTeks(teks As String, kunciRahasia As String) As String
            Dim salt(SALT_LEN - 1) As Byte
            Dim nonce(NONCE_LEN - 1) As Byte
            Using rng = RandomNumberGenerator.Create()
                rng.GetBytes(salt)
                rng.GetBytes(nonce)
            End Using

            Dim key = DeriveKey(kunciRahasia, salt)
            Dim plainBytes = Encoding.UTF8.GetBytes(teks)
            Dim cipher(plainBytes.Length - 1) As Byte
            Dim tag(TAG_LEN - 1) As Byte

            Using aes = New AesGcm(key, TAG_LEN)
                aes.Encrypt(nonce, plainBytes, cipher, tag)
            End Using

            Dim tagAndCipher = New Byte(TAG_LEN + cipher.Length - 1) {}
            Buffer.BlockCopy(tag, 0, tagAndCipher, 0, TAG_LEN)
            Buffer.BlockCopy(cipher, 0, tagAndCipher, TAG_LEN, cipher.Length)

            Return $"{HEADER}{Convert.ToBase64String(salt)}${Convert.ToBase64String(nonce)}${Convert.ToBase64String(tagAndCipher)}"
        End Function

        ''' <summary>Dekripsi format ENCv1$... kembali ke plaintext.</summary>
        Public Function DekripsiTeks(cipherText As String, kunciRahasia As String) As String
            If Not cipherText.StartsWith(HEADER) Then
                Return cipherText ' Bukan terenkripsi, kembalikan apa adanya
            End If

            Dim parts = cipherText.Substring(HEADER.Length).Split("$"c)
            If parts.Length <> 3 Then
                Throw New CryptographicException("Format ciphertext tidak valid.")
            End If

            Dim salt = Convert.FromBase64String(parts(0))
            Dim nonce = Convert.FromBase64String(parts(1))
            Dim tagAndCipher = Convert.FromBase64String(parts(2))

            If tagAndCipher.Length < TAG_LEN Then
                Throw New CryptographicException("Panjang ciphertext tidak valid.")
            End If

            Dim tag(TAG_LEN - 1) As Byte
            Dim cipher(tagAndCipher.Length - TAG_LEN - 1) As Byte
            Buffer.BlockCopy(tagAndCipher, 0, tag, 0, TAG_LEN)
            Buffer.BlockCopy(tagAndCipher, TAG_LEN, cipher, 0, cipher.Length)

            Dim key = DeriveKey(kunciRahasia, salt)
            Dim plain(cipher.Length - 1) As Byte

            Using aes = New AesGcm(key, TAG_LEN)
                aes.Decrypt(nonce, cipher, tag, plain)
            End Using

            Return Encoding.UTF8.GetString(plain)
        End Function

        ''' <summary>Enkripsi nilai tertentu di appsettings.json dan tulis file baru.</summary>
        Public Sub EnskripsiKonfigurasi(pathAppsettings As String, kunciRahasia As String)
            Dim json = File.ReadAllText(pathAppsettings, Encoding.UTF8)
            Dim config = New ConfigurationBuilder().AddJsonFile(pathAppsettings, optional:=False).Build()

            ' Ambil connection string default
            Dim connStr = config.GetConnectionString("Default")
            If String.IsNullOrWhiteSpace(connStr) Then
                Console.WriteLine("[ModKeamananConfig] Tidak ada ConnectionStrings:Default untuk dienkripsi.")
                Return
            End If

            If connStr.StartsWith(HEADER) Then
                Console.WriteLine("[ModKeamananConfig] ConnectionStrings:Default sudah terenkripsi, dilewati.")
                Return
            End If

            Dim encrypted = EnskripsiTeks(connStr, kunciRahasia)
            ' Ganti nilai di JSON secara manual (sederhana, hindari dependensi tambahan)
            Dim safeConn = EscapeJsonString(connStr)
            Dim safeEnc = EscapeJsonString(encrypted)
            Dim newJson = json.Replace($"""Default"": ""{safeConn}""", $"""Default"": ""{safeEnc}""") _
                             .Replace($"""Default"":""{safeConn}""", $"""Default"":""{safeEnc}""")

            File.WriteAllText(pathAppsettings, newJson, New System.Text.UTF8Encoding(encoderShouldEmitUTF8Identifier:=True))
            Console.WriteLine($"[ModKeamananConfig] ConnectionStrings:Default berhasil dienkripsi.")
        End Sub

        ''' <summary>Verifikasi bahwa kunci rahasia bisa mendekripsi nilai yang ada.</summary>
        Public Function VerifikasiKunci(cipherText As String, kunciRahasia As String) As Boolean
            Try
                Dim plain = DekripsiTeks(cipherText, kunciRahasia)
                Return Not String.IsNullOrWhiteSpace(plain)
            Catch
                Return False
            End Try
        End Function

        Private Function DeriveKey(password As String, salt As Byte()) As Byte()
            Return Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, PBKDF2_ITER, HashAlgorithmName.SHA256, KEY_LEN)
        End Function

        Private Function EscapeJsonString(s As String) As String
            ' Escape karakter khusus JSON untuk replace sederhana
            Return s.Replace("\", "\\") _
                    .Replace("""", "\""") _
                    .Replace("/", "\/")
        End Function

    End Module

End Namespace

