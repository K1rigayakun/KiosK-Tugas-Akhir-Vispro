Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms
Imports WinFormAnimation

Namespace VisproPrakProjectAkhir.Modul

    ''' <summary>
    ''' Pembungkus WinFormAnimation 60 FPS (Animator, Animator2D, Animator3D, Path chaining, SafeInvoker)
    ''' untuk transisi form, entrance hero/CTA, count-up KPI, grafik, validasi shake, dan efek hover/color.
    ''' </summary>
    Public Module ModAnimasi

        Public Property NonaktifkanAnimasi As Boolean = False

        Private ReadOnly _anim1D As New Dictionary(Of Object, Animator)()
        Private ReadOnly _anim2D As New Dictionary(Of Object, Animator2D)()
        Private ReadOnly _anim3D As New Dictionary(Of Object, Animator3D)()
        Private ReadOnly _shakeBaseX As New Dictionary(Of Control, Integer)()
        Private ReadOnly _hookedControls As New HashSet(Of Control)()
        Private ReadOnly _stagedTargetTop As New Dictionary(Of Form, Integer)()
        Private ReadOnly _stagedSlidePx As New Dictionary(Of Form, Integer)()
        Private ReadOnly _stagedLoadHooked As New HashSet(Of Form)()

        Public Sub StopActive(key As Object)
            If key Is Nothing Then Return

            Dim a1 As Animator = Nothing
            If _anim1D.TryGetValue(key, a1) Then
                Try
                    a1.Stop()
                Catch
                End Try
                _anim1D.Remove(key)
            End If

            Dim a2 As Animator2D = Nothing
            If _anim2D.TryGetValue(key, a2) Then
                Try
                    a2.Stop()
                Catch
                End Try
                _anim2D.Remove(key)
            End If

            Dim a3 As Animator3D = Nothing
            If _anim3D.TryGetValue(key, a3) Then
                Try
                    a3.Stop()
                Catch
                End Try
                _anim3D.Remove(key)
            End If
        End Sub

        Private Sub HookDisposeCleanup(ctrl As Control)
            If ctrl Is Nothing OrElse ctrl.IsDisposed OrElse _hookedControls.Contains(ctrl) Then Return
            _hookedControls.Add(ctrl)
            AddHandler ctrl.Disposed, Sub()
                                          StopActive(ctrl)
                                          _shakeBaseX.Remove(ctrl)
                                          _hookedControls.Remove(ctrl)
                                          Dim frm = TryCast(ctrl, Form)
                                          If frm IsNot Nothing Then
                                              _stagedTargetTop.Remove(frm)
                                              _stagedSlidePx.Remove(frm)
                                              _stagedLoadHooked.Remove(frm)
                                          End If
                                      End Sub
        End Sub

        Public Sub SiapkanTransisiMasuk(f As Form, Optional slidePx As Integer = 0)
            If f Is Nothing OrElse f.IsDisposed OrElse f.IsMdiChild Then Return
            If NonaktifkanAnimasi Then
                f.Opacity = 1.0
                _stagedTargetTop.Remove(f)
                _stagedSlidePx.Remove(f)
                Return
            End If

            HookDisposeCleanup(f)
            f.Opacity = 0.0
            If slidePx > 0 Then
                _stagedSlidePx(f) = slidePx
                If Not _stagedLoadHooked.Contains(f) Then
                    _stagedLoadHooked.Add(f)
                    AddHandler f.Load, Sub()
                                           If NonaktifkanAnimasi OrElse f.IsDisposed Then Return
                                           Dim px As Integer = 0
                                           If _stagedSlidePx.TryGetValue(f, px) AndAlso px > 0 Then
                                               Dim tgtTop As Integer = f.Top
                                               _stagedTargetTop(f) = tgtTop
                                               f.Top = tgtTop + px
                                           End If
                                       End Sub
                End If
            End If
        End Sub

        Private Function IsAlive(ctrl As Control, ownerForm As Form) As Boolean
            If ctrl Is Nothing OrElse ctrl.IsDisposed Then Return False
            If ownerForm Is Nothing OrElse ownerForm.IsDisposed OrElse Not ownerForm.IsHandleCreated Then Return False
            Return True
        End Function

        Public Sub AnimateWidth(ctrl As Control, targetWidth As Integer, Optional durationMs As ULong = 240UL, Optional onDone As Action = Nothing)
            If ctrl Is Nothing OrElse ctrl.IsDisposed Then Return
            Dim startW As Integer = ctrl.Width
            If startW = targetWidth OrElse NonaktifkanAnimasi Then
                StopActive(ctrl)
                ctrl.Width = targetWidth
                onDone?.Invoke()
                Return
            End If
            StopActive(ctrl)
            HookDisposeCleanup(ctrl)

            Dim ownerForm As Form = ctrl.FindForm()
            If Not IsAlive(ctrl, ownerForm) Then
                ctrl.Width = targetWidth
                onDone?.Invoke()
                Return
            End If

            Dim anim As New Animator(
                New Path(CSng(startW), CSng(targetWidth), durationMs, AddressOf AnimationFunctions.QuinticEaseOut),
                FPSLimiterKnownValues.LimitSixty)
            _anim1D(ctrl) = anim

            Dim stepInvoker As New SafeInvoker(Of Single)(
                Sub(v As Single)
                    If IsAlive(ctrl, ownerForm) Then
                        ctrl.Width = CInt(Math.Round(v))
                    End If
                End Sub, ownerForm)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim1D.Remove(ctrl)
                    If IsAlive(ctrl, ownerForm) Then ctrl.Width = targetWidth
                    onDone?.Invoke()
                End Sub, ownerForm)

            anim.Play(stepInvoker, endInvoker)
        End Sub

        Public Sub AnimateTop(ctrl As Control, targetTop As Integer, Optional durationMs As ULong = 260UL, Optional onDone As Action = Nothing)
            If ctrl Is Nothing OrElse ctrl.IsDisposed Then Return
            Dim startTop As Integer = ctrl.Top
            If startTop = targetTop OrElse NonaktifkanAnimasi Then
                StopActive(ctrl)
                ctrl.Top = targetTop
                onDone?.Invoke()
                Return
            End If
            StopActive(ctrl)
            HookDisposeCleanup(ctrl)

            Dim ownerForm As Form = ctrl.FindForm()
            If Not IsAlive(ctrl, ownerForm) Then
                ctrl.Top = targetTop
                onDone?.Invoke()
                Return
            End If

            Dim anim As New Animator(
                New Path(CSng(startTop), CSng(targetTop), durationMs, AddressOf AnimationFunctions.CubicEaseOut),
                FPSLimiterKnownValues.LimitSixty)
            _anim1D(ctrl) = anim

            Dim stepInvoker As New SafeInvoker(Of Single)(
                Sub(v As Single)
                    If IsAlive(ctrl, ownerForm) Then
                        ctrl.Top = CInt(Math.Round(v))
                    End If
                End Sub, ownerForm)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim1D.Remove(ctrl)
                    If IsAlive(ctrl, ownerForm) Then ctrl.Top = targetTop
                    onDone?.Invoke()
                End Sub, ownerForm)

            anim.Play(stepInvoker, endInvoker)
        End Sub

        Public Sub FadeInForm(f As Form, Optional durationMs As ULong = 200UL, Optional onDone As Action = Nothing)
            If f Is Nothing OrElse f.IsDisposed OrElse f.IsMdiChild Then
                onDone?.Invoke()
                Return
            End If
            If NonaktifkanAnimasi OrElse Not f.IsHandleCreated Then
                f.Opacity = 1.0
                onDone?.Invoke()
                Return
            End If

            StopActive(f)
            HookDisposeCleanup(f)
            Dim startOpacity As Single = If(f.Opacity >= 0.99, 0.0F, Math.Max(0.0F, CSng(f.Opacity)))
            f.Opacity = startOpacity

            Dim anim As New Animator(
                New Path(startOpacity, 1.0F, durationMs, AddressOf AnimationFunctions.CubicEaseOut),
                FPSLimiterKnownValues.LimitSixty)
            _anim1D(f) = anim

            Dim stepInvoker As New SafeInvoker(Of Single)(
                Sub(v As Single)
                    If IsAlive(f, f) Then
                        f.Opacity = Math.Max(0.0, Math.Min(1.0, CDbl(v)))
                    End If
                End Sub, f)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim1D.Remove(f)
                    If IsAlive(f, f) Then f.Opacity = 1.0
                    onDone?.Invoke()
                End Sub, f)

            anim.Play(stepInvoker, endInvoker)
        End Sub

        Public Sub SlideUpFadeInModal(f As Form, Optional slidePx As Integer = 18, Optional durationMs As ULong = 230UL)
            If f Is Nothing OrElse f.IsDisposed OrElse f.IsMdiChild Then Return

            Dim hasTarget As Boolean = _stagedTargetTop.ContainsKey(f)
            Dim targetTop As Integer = If(hasTarget, _stagedTargetTop(f), f.Top)
            Dim actualSlidePx As Integer = slidePx
            If _stagedSlidePx.ContainsKey(f) Then actualSlidePx = _stagedSlidePx(f)

            _stagedTargetTop.Remove(f)
            _stagedSlidePx.Remove(f)

            If NonaktifkanAnimasi OrElse Not f.IsHandleCreated Then
                If hasTarget Then f.Top = targetTop
                f.Opacity = 1.0
                Return
            End If

            StopActive(f)
            HookDisposeCleanup(f)
            If Not hasTarget Then
                f.Top = targetTop + actualSlidePx
            End If
            If f.Opacity >= 0.99 Then f.Opacity = 0.0

            Dim anim As New Animator(
                New Path(0.0F, 1.0F, durationMs, AddressOf AnimationFunctions.QuarticEaseOut),
                FPSLimiterKnownValues.LimitSixty)
            _anim1D(f) = anim

            Dim stepInvoker As New SafeInvoker(Of Single)(
                Sub(v As Single)
                    If IsAlive(f, f) Then
                        f.Opacity = Math.Max(0.0, Math.Min(1.0, CDbl(v)))
                        f.Top = targetTop + CInt(Math.Round((1.0F - v) * actualSlidePx))
                    End If
                End Sub, f)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim1D.Remove(f)
                    If IsAlive(f, f) Then
                        f.Top = targetTop
                        f.Opacity = 1.0
                    End If
                End Sub, f)

            anim.Play(stepInvoker, endInvoker)
        End Sub

        Public Sub AnimateEntranceSlide(ctrl As Control, offsetX As Integer, offsetY As Integer, Optional durationMs As ULong = 340UL, Optional delayMs As ULong = 0UL)
            If ctrl Is Nothing OrElse ctrl.IsDisposed Then Return
            If ctrl.Dock <> DockStyle.None OrElse TypeOf ctrl.Parent Is TableLayoutPanel Then Return
            If NonaktifkanAnimasi Then Return

            Dim ownerForm As Form = ctrl.FindForm()
            If Not IsAlive(ctrl, ownerForm) Then Return

            Dim endX As Integer = ctrl.Left
            Dim endY As Integer = ctrl.Top
            StopActive(ctrl)
            HookDisposeCleanup(ctrl)

            ctrl.Location = New Point(endX + offsetX, endY + offsetY)
            Dim p2d As New Path2D(
                New Float2D(CSng(endX + offsetX), CSng(endY + offsetY)),
                New Float2D(CSng(endX), CSng(endY)),
                durationMs,
                delayMs,
                AddressOf AnimationFunctions.QuinticEaseOut)

            Dim anim As New Animator2D(p2d, FPSLimiterKnownValues.LimitSixty)
            _anim2D(ctrl) = anim

            Dim stepInvoker As New SafeInvoker(Of Float2D)(
                Sub(pt As Float2D)
                    If IsAlive(ctrl, ownerForm) Then
                        ctrl.Location = New Point(CInt(Math.Round(pt.X)), CInt(Math.Round(pt.Y)))
                    End If
                End Sub, ownerForm)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim2D.Remove(ctrl)
                    If IsAlive(ctrl, ownerForm) Then
                        ctrl.Location = New Point(endX, endY)
                    End If
                End Sub, ownerForm)

            anim.Play(stepInvoker, endInvoker)
        End Sub

        Public Sub ShakeControl(ctrl As Control, Optional amplitude As Integer = 8)
            If ctrl Is Nothing OrElse ctrl.IsDisposed OrElse NonaktifkanAnimasi Then Return
            If ctrl.Dock <> DockStyle.None Then Return

            Dim ownerForm As Form = ctrl.FindForm()
            If Not IsAlive(ctrl, ownerForm) Then Return

            Dim baseX As Integer
            If Not _shakeBaseX.TryGetValue(ctrl, baseX) Then
                baseX = ctrl.Left
                _shakeBaseX(ctrl) = baseX
            End If

            StopActive(ctrl)
            HookDisposeCleanup(ctrl)
            ctrl.Left = baseX

            Dim easing As AnimationFunctions.Function = AddressOf AnimationFunctions.SinusoidalEaseInOut
            Dim seg1 As New Path(CSng(baseX), CSng(baseX + amplitude), 42UL, easing)
            Dim segs As Path() = PathExtensions.ContinueTo(seg1, CSng(baseX - amplitude), 45UL, easing)
            segs = PathExtensions.ContinueTo(segs, CSng(baseX + 5), 42UL, easing)
            segs = PathExtensions.ContinueTo(segs, CSng(baseX - 5), 42UL, easing)
            segs = PathExtensions.ContinueTo(segs, CSng(baseX + 2), 40UL, easing)
            segs = PathExtensions.ContinueTo(segs, CSng(baseX), 40UL, easing)

            Dim anim As New Animator(segs, FPSLimiterKnownValues.LimitSixty)
            _anim1D(ctrl) = anim

            Dim stepInvoker As New SafeInvoker(Of Single)(
                Sub(v As Single)
                    If IsAlive(ctrl, ownerForm) Then
                        ctrl.Left = CInt(Math.Round(v))
                    End If
                End Sub, ownerForm)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim1D.Remove(ctrl)
                    _shakeBaseX.Remove(ctrl)
                    If IsAlive(ctrl, ownerForm) Then ctrl.Left = baseX
                End Sub, ownerForm)

            anim.Play(stepInvoker, endInvoker)
        End Sub

        Public Sub AnimateNumber(lbl As Label, targetValue As Decimal, formatter As Func(Of Decimal, String), Optional durationMs As ULong = 520UL, Optional delayMs As ULong = 0UL)
            If lbl Is Nothing OrElse lbl.IsDisposed OrElse formatter Is Nothing Then Return
            StopActive(lbl)

            Dim ownerForm As Form = lbl.FindForm()
            If NonaktifkanAnimasi OrElse Not IsAlive(lbl, ownerForm) OrElse targetValue <= 0D Then
                lbl.Text = formatter(targetValue)
                Return
            End If

            HookDisposeCleanup(lbl)
            lbl.Text = formatter(0D)

            Dim anim As New Animator(
                New Path(0.0F, CSng(targetValue), durationMs, delayMs, AddressOf AnimationFunctions.QuarticEaseOut),
                FPSLimiterKnownValues.LimitSixty)
            _anim1D(lbl) = anim

            Dim stepInvoker As New SafeInvoker(Of Single)(
                Sub(v As Single)
                    If IsAlive(lbl, ownerForm) Then
                        Dim clamped As Decimal = Math.Max(0D, Math.Min(targetValue, CDec(Math.Round(v))))
                        lbl.Text = formatter(clamped)
                    End If
                End Sub, ownerForm)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim1D.Remove(lbl)
                    If IsAlive(lbl, ownerForm) Then lbl.Text = formatter(targetValue)
                End Sub, ownerForm)

            anim.Play(stepInvoker, endInvoker)
        End Sub

        Public Sub AnimateFloat(owner As Control, key As Object, startVal As Single, endVal As Single, durationMs As ULong, onStep As Action(Of Single), Optional onDone As Action = Nothing, Optional delayMs As ULong = 0UL, Optional easing As AnimationFunctions.Function = Nothing)
            If onStep Is Nothing OrElse key Is Nothing Then Return
            StopActive(key)

            Dim ownerForm As Form = If(owner IsNot Nothing, owner.FindForm(), Nothing)
            If NonaktifkanAnimasi OrElse durationMs = 0UL OrElse Math.Abs(endVal - startVal) < 0.0001F OrElse Not IsAlive(owner, ownerForm) Then
                onStep(endVal)
                onDone?.Invoke()
                Return
            End If

            HookDisposeCleanup(owner)
            Dim easeFn As AnimationFunctions.Function = If(easing, AddressOf AnimationFunctions.CubicEaseOut)
            Dim anim As New Animator(
                New Path(startVal, endVal, durationMs, delayMs, easeFn),
                FPSLimiterKnownValues.LimitSixty)
            _anim1D(key) = anim

            Dim stepInvoker As New SafeInvoker(Of Single)(
                Sub(v As Single)
                    If IsAlive(owner, ownerForm) Then
                        onStep(v)
                    End If
                End Sub, ownerForm)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim1D.Remove(key)
                    If IsAlive(owner, ownerForm) Then
                        onStep(endVal)
                        onDone?.Invoke()
                    End If
                End Sub, ownerForm)

            anim.Play(stepInvoker, endInvoker)
        End Sub

        Public Sub AnimateColor(ctrl As Control, key As Object, fromColor As Color, toColor As Color, applyColor As Action(Of Color), Optional durationMs As ULong = 340UL, Optional onDone As Action = Nothing, Optional easing As AnimationFunctions.Function = Nothing)
            If applyColor Is Nothing OrElse key Is Nothing Then Return
            StopActive(key)

            Dim ownerForm As Form = If(ctrl IsNot Nothing, ctrl.FindForm(), Nothing)
            If NonaktifkanAnimasi OrElse durationMs = 0UL OrElse Not IsAlive(ctrl, ownerForm) Then
                applyColor(toColor)
                onDone?.Invoke()
                Return
            End If

            HookDisposeCleanup(ctrl)
            Dim easeFn As AnimationFunctions.Function = If(easing, AddressOf AnimationFunctions.SinusoidalEaseInOut)
            Dim p3d As New Path3D(
                New Float3D(fromColor.R, fromColor.G, fromColor.B),
                New Float3D(toColor.R, toColor.G, toColor.B),
                durationMs,
                easeFn)
            Dim anim As New Animator3D(p3d, FPSLimiterKnownValues.LimitSixty)
            _anim3D(key) = anim

            Dim stepInvoker As New SafeInvoker(Of Float3D)(
                Sub(pt As Float3D)
                    If IsAlive(ctrl, ownerForm) Then
                        Dim r As Integer = Math.Max(0, Math.Min(255, CInt(Math.Round(pt.X))))
                        Dim g As Integer = Math.Max(0, Math.Min(255, CInt(Math.Round(pt.Y))))
                        Dim b As Integer = Math.Max(0, Math.Min(255, CInt(Math.Round(pt.Z))))
                        applyColor(Color.FromArgb(r, g, b))
                    End If
                End Sub, ownerForm)

            Dim endInvoker As New SafeInvoker(
                Sub()
                    _anim3D.Remove(key)
                    If IsAlive(ctrl, ownerForm) Then
                        applyColor(toColor)
                        onDone?.Invoke()
                    End If
                End Sub, ownerForm)

            anim.Play(stepInvoker, endInvoker)
        End Sub

    End Module
End Namespace
