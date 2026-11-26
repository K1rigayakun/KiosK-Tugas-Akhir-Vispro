Option Strict On
Option Explicit On

Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModWindowsApi

        Public Const WM_HOTKEY As Integer = &H312
        Public Const MOD_ALT As UInteger = &H1UI
        Public Const MOD_CONTROL As UInteger = &H2UI
        Public Const MOD_NOREPEAT As UInteger = &H4000UI

        Private ReadOnly HWND_TOPMOST As New IntPtr(-1)
        Private ReadOnly HWND_NOTOPMOST As New IntPtr(-2)
        Private Const SWP_NOMOVE As UInteger = &H2UI
        Private Const SWP_NOSIZE As UInteger = &H1UI
        Private Const SWP_NOACTIVATE As UInteger = &H10UI
        Private Const WM_SETREDRAW As Integer = &HB

        <DllImport("user32.dll", SetLastError:=True)>
        Private Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr,
                                      X As Integer, Y As Integer, cx As Integer, cy As Integer,
                                      uFlags As UInteger) As Boolean
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Auto)>
        Private Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
        End Function

        <DllImport("user32.dll", SetLastError:=True)>
        Private Function RegisterHotKey(hWnd As IntPtr, id As Integer, fsModifiers As UInteger, vk As UInteger) As Boolean
        End Function

        <DllImport("user32.dll", SetLastError:=True)>
        Private Function UnregisterHotKey(hWnd As IntPtr, id As Integer) As Boolean
        End Function

        <DllImport("user32.dll")>
        Private Function MessageBeep(uType As UInteger) As Boolean
        End Function

        <DllImport("kernel32.dll")>
        Private Function GetTickCount64() As ULong
        End Function

        Public Sub SelaluDiAtas(f As Form, aktif As Boolean)
            If f Is Nothing OrElse f.IsDisposed OrElse Not f.IsHandleCreated Then Return
            If Debugger.IsAttached AndAlso aktif Then Return
            Dim target = If(aktif, HWND_TOPMOST, HWND_NOTOPMOST)
            SetWindowPos(f.Handle, target, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
        End Sub

        Public Function DaftarHotkey(handle As IntPtr, id As Integer, modifier As UInteger, kunci As Keys) As Boolean
            If handle = IntPtr.Zero Then Return False
            Try
                Return RegisterHotKey(handle, id, modifier, CUInt(kunci))
            Catch
                Return False
            End Try
        End Function

        Public Sub BatalHotkey(handle As IntPtr, id As Integer)
            If handle = IntPtr.Zero Then Return
            Try
                UnregisterHotKey(handle, id)
            Catch
            End Try
        End Sub

        Public Sub Bunyi()
            Try
                MessageBeep(&H40UI)
            Catch
            End Try
        End Sub

        Public Function WaktuAktif() As ULong
            Return GetTickCount64()
        End Function

        Public Sub SuspendDrawing(ctrl As Control)
            If ctrl Is Nothing OrElse ctrl.IsDisposed OrElse Not ctrl.IsHandleCreated Then Return
            Try
                SendMessage(ctrl.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero)
            Catch
            End Try
        End Sub

        Public Sub ResumeDrawing(ctrl As Control)
            If ctrl Is Nothing OrElse ctrl.IsDisposed OrElse Not ctrl.IsHandleCreated Then Return
            Try
                SendMessage(ctrl.Handle, WM_SETREDRAW, New IntPtr(1), IntPtr.Zero)
                ctrl.Invalidate(True)
                ctrl.Update()
            Catch
            End Try
        End Sub

    End Module
End Namespace

