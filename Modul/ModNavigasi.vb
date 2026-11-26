Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms

Namespace VisproPrakProjectAkhir.Modul

    ''' <summary>
    ''' Pengelola navigasi antar layar penuh, sinkronisasi mode fullscreen (F11),
    ''' dan transisi modal agar bebas kedip dan menjaga ukuran/posisi jendela konsisten.
    ''' </summary>
    Public Module ModNavigasi

        Private _modeFullscreen As Boolean = False
        Private ReadOnly _halamanPenuh As New HashSet(Of Form)()
        Private ReadOnly _normalSizeMap As New Dictionary(Of Form, Size)()

        Public ReadOnly Property ModeFullscreen As Boolean
            Get
                Return _modeFullscreen
            End Get
        End Property

        Public Property BoundsNormal As Rectangle = Rectangle.Empty

        Public Event ModeFullscreenBerubah(aktif As Boolean)

        Public Sub DaftarkanHalamanPenuh(f As Form)
            If f Is Nothing OrElse f.IsDisposed OrElse f.IsMdiChild Then Return

            If Not _halamanPenuh.Contains(f) Then
                _halamanPenuh.Add(f)
                _normalSizeMap(f) = f.Size

                AddHandler f.Disposed, Sub()
                                           _halamanPenuh.Remove(f)
                                           _normalSizeMap.Remove(f)
                                       End Sub

                Dim simpanBounds As Action =
                    Sub()
                        If Not _modeFullscreen AndAlso f.Visible AndAlso f.WindowState = FormWindowState.Normal AndAlso f.FormBorderStyle <> FormBorderStyle.None Then
                            BoundsNormal = f.Bounds
                        End If
                    End Sub
                AddHandler f.ResizeEnd, Sub() simpanBounds()
                AddHandler f.Move, Sub() simpanBounds()
            End If

            TerapkanModeJendela(f)
        End Sub

        Public Sub TerapkanModeJendela(f As Form)
            If f Is Nothing OrElse f.IsDisposed OrElse f.IsMdiChild Then Return
            If ModAnimasi.NonaktifkanAnimasi AndAlso Not _modeFullscreen Then Return

            Dim suspended As Boolean = f.IsHandleCreated
            If suspended Then ModWindowsApi.SuspendDrawing(f)
            Try
                If _modeFullscreen Then
                    If f.WindowState = FormWindowState.Normal AndAlso f.FormBorderStyle <> FormBorderStyle.None AndAlso f.Visible Then
                        BoundsNormal = f.Bounds
                    End If
                    If f.FormBorderStyle <> FormBorderStyle.None OrElse f.WindowState <> FormWindowState.Maximized Then
                        Dim targetScreen = Screen.FromControl(f)
                        f.WindowState = FormWindowState.Normal
                        f.FormBorderStyle = FormBorderStyle.None
                        f.Bounds = targetScreen.Bounds
                        f.WindowState = FormWindowState.Maximized
                    End If
                Else
                    If f.FormBorderStyle = FormBorderStyle.None OrElse f.WindowState = FormWindowState.Maximized Then
                        Dim targetScreen = Screen.FromControl(f)
                        f.WindowState = FormWindowState.Normal
                        f.FormBorderStyle = FormBorderStyle.Sizable

                        Dim fallbackSize As Size = f.Size
                        If _normalSizeMap.ContainsKey(f) Then fallbackSize = _normalSizeMap(f)
                        Dim targetBounds As Rectangle = BoundsNormal
                        If targetBounds.IsEmpty OrElse targetBounds.Width < f.MinimumSize.Width OrElse targetBounds.Height < f.MinimumSize.Height Then
                            Dim area = targetScreen.WorkingArea
                            Dim w As Integer = Math.Min(area.Width, Math.Max(f.MinimumSize.Width, fallbackSize.Width))
                            Dim h As Integer = Math.Min(area.Height, Math.Max(f.MinimumSize.Height, fallbackSize.Height))
                            targetBounds = New Rectangle(area.X + (area.Width - w) \ 2, area.Y + (area.Height - h) \ 2, w, h)
                        End If
                        f.Bounds = targetBounds
                    End If
                End If
            Finally
                If suspended Then ModWindowsApi.ResumeDrawing(f)
            End Try
        End Sub

        Public Sub SetFullscreen(aktif As Boolean, Optional activeForm As Form = Nothing)
            If _modeFullscreen = aktif Then Return
            _modeFullscreen = aktif

            For Each frm In _halamanPenuh.ToList()
                If frm IsNot Nothing AndAlso Not frm.IsDisposed Then
                    TerapkanModeJendela(frm)
                End If
            Next

            If activeForm IsNot Nothing AndAlso Not activeForm.IsDisposed AndAlso activeForm.Visible Then
                activeForm.Activate()
            End If

            RaiseEvent ModeFullscreenBerubah(_modeFullscreen)
        End Sub

        Public Sub ToggleFullscreen(Optional activeForm As Form = Nothing)
            SetFullscreen(Not _modeFullscreen, activeForm)
        End Sub

        Public Sub PindahHalaman(dari As Form, ke As Form)
            If ke Is Nothing OrElse ke.IsDisposed Then Return

            DaftarkanHalamanPenuh(ke)

            If Not _modeFullscreen AndAlso dari IsNot Nothing AndAlso Not dari.IsDisposed Then
                Dim area = Screen.FromControl(dari).WorkingArea
                Dim srcBounds As Rectangle = If(dari.WindowState = FormWindowState.Normal, dari.Bounds, BoundsNormal)
                If srcBounds.IsEmpty Then srcBounds = dari.Bounds
                Dim w As Integer = Math.Min(area.Width, Math.Max(ke.MinimumSize.Width, srcBounds.Width))
                Dim h As Integer = Math.Min(area.Height, Math.Max(ke.MinimumSize.Height, srcBounds.Height))
                Dim x As Integer = Math.Max(area.X, Math.Min(area.Right - w, srcBounds.X + (srcBounds.Width - w) \ 2))
                Dim y As Integer = Math.Max(area.Y, Math.Min(area.Bottom - h, srcBounds.Y + (srcBounds.Height - h) \ 2))
                ke.StartPosition = FormStartPosition.Manual
                ke.Bounds = New Rectangle(x, y, w, h)
            End If

            If ModAnimasi.NonaktifkanAnimasi Then
                ke.Opacity = 1.0
                ke.Show()
                ke.BringToFront()
                ke.Activate()
                If dari IsNot Nothing AndAlso Not dari.IsDisposed AndAlso dari IsNot ke Then
                    dari.Hide()
                End If
                Return
            End If

            ModAnimasi.StopActive(ke)
            ke.Opacity = 0.0
            ke.Show()
            ke.BringToFront()
            ke.Activate()
            ModAnimasi.FadeInForm(ke, 190UL,
                Sub()
                    If dari IsNot Nothing AndAlso Not dari.IsDisposed AndAlso dari IsNot ke Then
                        dari.Hide()
                    End If
                End Sub)
        End Sub

        Public Function BukaHalamanModal(owner As Form, target As Form) As DialogResult
            If target Is Nothing OrElse target.IsDisposed Then Return DialogResult.Cancel
            DaftarkanHalamanPenuh(target)
            If Not _modeFullscreen Then
                target.StartPosition = If(owner IsNot Nothing AndAlso Not owner.IsDisposed, FormStartPosition.CenterParent, FormStartPosition.CenterScreen)
            End If
            ModAnimasi.SiapkanTransisiMasuk(target, 0)
            If owner IsNot Nothing AndAlso Not owner.IsDisposed Then
                Return target.ShowDialog(owner)
            End If
            Return target.ShowDialog()
        End Function

        Public Sub ResetUntukTest()
            _modeFullscreen = False
            BoundsNormal = Rectangle.Empty
            _halamanPenuh.Clear()
            _normalSizeMap.Clear()
        End Sub

    End Module
End Namespace

