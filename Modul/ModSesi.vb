Option Strict On
Option Explicit On

Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModSesi

        Private _idPengguna As Integer = 0
        Private _username As String = ""
        Private _namaPengguna As String = ""
        Private _peran As String = ""

        Public ReadOnly Property IdPengguna As Integer
            Get
                Return _idPengguna
            End Get
        End Property

        Public ReadOnly Property Username As String
            Get
                Return _username
            End Get
        End Property

        Public ReadOnly Property NamaPengguna As String
            Get
                Return _namaPengguna
            End Get
        End Property

        Public ReadOnly Property Peran As String
            Get
                Return _peran
            End Get
        End Property

        Public Sub Masuk(p As Pengguna)
            If p Is Nothing Then Return
            _idPengguna = p.IdPengguna
            _username = p.Username
            _namaPengguna = p.Nama
            _peran = p.Peran
        End Sub

        Public Sub Keluar()
            _idPengguna = 0
            _username = ""
            _namaPengguna = ""
            _peran = ""
        End Sub

        Public Function SudahLogin() As Boolean
            Return _idPengguna > 0 AndAlso Not String.IsNullOrEmpty(_peran)
        End Function

        Public Function BolehAkses(namaForm As String) As Boolean
            If Not SudahLogin() Then Return False
            If String.Equals(_peran.Trim(), Model.Peran.Admin, StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
            ' Peran Kasir: hanya Kasir, Dapur, Layar Antrian, Member
            Select Case If(namaForm, "").Trim().ToLowerInvariant()
                Case "frmkasir", "frmdapur", "frmantrian", "frmmember"
                    Return True
                Case Else
                    Return False
            End Select
        End Function

    End Module
End Namespace

