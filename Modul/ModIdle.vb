Option Strict On
Option Explicit On

Imports System.Windows.Forms
Imports VisproPrakProjectAkhir.Forms.Kiosk

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModIdle

        Private Class ActivityMessageFilter
            Implements IMessageFilter

            Private Const WM_MOUSEMOVE As Integer = &H200
            Private Const WM_LBUTTONDOWN As Integer = &H201
            Private Const WM_RBUTTONDOWN As Integer = &H204
            Private Const WM_KEYDOWN As Integer = &H100
            Private Const WM_MOUSEWHEEL As Integer = &H20A

            Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
                Select Case m.Msg
                    Case WM_MOUSEMOVE, WM_LBUTTONDOWN, WM_RBUTTONDOWN, WM_KEYDOWN, WM_MOUSEWHEEL
                        _lastActivityTick = ModWindowsApi.WaktuAktif()
                End Select
                Return False
            End Function
        End Class

        Private _filter As ActivityMessageFilter
        Private _timer As Timer
        Private _batasDetik As Integer = 60
        Private _lastActivityTick As ULong = 0UL
        Private _aktif As Boolean = False
        Private _dialogSedangBuka As Boolean = False

        Public Event Habis()

        Public Sub Mulai(Optional batasDetik As Integer = 60)
            _batasDetik = Math.Max(10, batasDetik)
            _lastActivityTick = ModWindowsApi.WaktuAktif()

            If _filter Is Nothing Then
                _filter = New ActivityMessageFilter()
                Application.AddMessageFilter(_filter)
            End If

            If _timer Is Nothing Then
                _timer = New Timer() With {.Interval = 1000}
                AddHandler _timer.Tick, AddressOf OnTimerTick
            End If

            _aktif = True
            _timer.Start()
        End Sub

        Public Sub Berhenti()
            _aktif = False
            If _timer IsNot Nothing Then _timer.Stop()
        End Sub

        Public Sub CatatAktivitas()
            _lastActivityTick = ModWindowsApi.WaktuAktif()
        End Sub

        Public Sub SimulasikanIdle()
            If _dialogSedangBuka Then Return
            TampilkanPeringatanIdle()
        End Sub

        Private Sub OnTimerTick(sender As Object, e As EventArgs)
            If Not _aktif OrElse _dialogSedangBuka Then Return
            ' Jangan hitung idle bila sedang di FrmWelcome (tidak ada form pelanggan aktif terlihat) atau mode staff
            If ModSesi.SudahLogin() Then Return

            Dim adaFormPelangganAktif As Boolean = Application.OpenForms.Cast(Of Form)().Any(
                Function(f) f IsNot Nothing AndAlso Not f.IsDisposed AndAlso f.Visible AndAlso
                            Not TypeOf f Is FrmWelcome AndAlso
                            Not TypeOf f Is Forms.Umum.FrmUtama AndAlso
                            Not TypeOf f Is Forms.Kasir.FrmAntrian AndAlso
                            Not TypeOf f Is Forms.Umum.FrmLogin)
            If Not adaFormPelangganAktif Then
                _lastActivityTick = ModWindowsApi.WaktuAktif()
                Return
            End If

            Dim elapsedMs As ULong = ModWindowsApi.WaktuAktif() - _lastActivityTick
            If elapsedMs >= CULng(_batasDetik) * 1000UL Then
                TampilkanPeringatanIdle()
            End If
        End Sub

        Private Sub TampilkanPeringatanIdle()
            _dialogSedangBuka = True
            Try
                Using frm As New FrmIdle()
                    Dim activeOwner As Form = Form.ActiveForm
                    Dim res As DialogResult = If(activeOwner IsNot Nothing AndAlso Not activeOwner.IsDisposed AndAlso activeOwner.Visible,
                                                 frm.ShowDialog(activeOwner),
                                                 frm.ShowDialog())
                    If res = DialogResult.OK Then
                        _lastActivityTick = ModWindowsApi.WaktuAktif()
                    Else
                        RaiseEvent Habis()
                    End If
                End Using
            Finally
                _dialogSedangBuka = False
            End Try
        End Sub

    End Module
End Namespace

