Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Controls

    ''' <summary>
    ''' Grafik batang GDI+ dengan puncak melengkung 6px, tooltip rounded 8px, dan animasi tumbuh 60 FPS via WinFormAnimation.
    ''' </summary>
    Public Class GrafikBatang
        Inherits UserControl

        Private _data As New List(Of GrafikTitik)()
        Private ReadOnly _barRects As New List(Of Rectangle)()
        Private _hoverIndex As Integer = -1
        Private _formatRupiah As Boolean = True
        Private _animProgress As Single = 1.0F
        Private _pendingAnimate As Boolean = False

        Public Sub New()
            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
            BackColor = ModTema.WarnaPermukaan
            Size = New Size(560, 280)
        End Sub

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property FormatSebagaiRupiah As Boolean
            Get
                Return _formatRupiah
            End Get
            Set(value As Boolean)
                _formatRupiah = value
                Invalidate()
            End Set
        End Property

        Private Shared Function DataSama(a As List(Of GrafikTitik), b As List(Of GrafikTitik)) As Boolean
            If a Is Nothing AndAlso b Is Nothing Then Return True
            If a Is Nothing OrElse b Is Nothing OrElse a.Count <> b.Count Then Return False
            For i As Integer = 0 To a.Count - 1
                If a(i).Label <> b(i).Label OrElse a(i).Nilai <> b(i).Nilai Then Return False
            Next
            Return True
        End Function

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property Data As List(Of GrafikTitik)
            Get
                Return _data
            End Get
            Set(value As List(Of GrafikTitik))
                Dim incoming = If(value, New List(Of GrafikTitik)())
                If DataSama(_data, incoming) AndAlso _animProgress >= 0.99F Then
                    _data = incoming
                    Invalidate()
                    Return
                End If
                _data = incoming
                _hoverIndex = -1
                If DesignMode OrElse ModAnimasi.NonaktifkanAnimasi Then
                    _pendingAnimate = False
                    _animProgress = 1.0F
                    Invalidate()
                ElseIf IsHandleCreated AndAlso Visible Then
                    MulaiAnimasiBatang()
                Else
                    _pendingAnimate = True
                    _animProgress = 0.0F
                    Invalidate()
                End If
            End Set
        End Property

        Protected Overrides Sub OnHandleCreated(e As EventArgs)
            MyBase.OnHandleCreated(e)
            If _pendingAnimate AndAlso Visible AndAlso Not DesignMode AndAlso Not ModAnimasi.NonaktifkanAnimasi Then
                MulaiAnimasiBatang()
            End If
        End Sub

        Protected Overrides Sub OnVisibleChanged(e As EventArgs)
            MyBase.OnVisibleChanged(e)
            If _pendingAnimate AndAlso Visible AndAlso IsHandleCreated AndAlso Not DesignMode AndAlso Not ModAnimasi.NonaktifkanAnimasi Then
                MulaiAnimasiBatang()
            End If
        End Sub

        Private Sub MulaiAnimasiBatang()
            _pendingAnimate = False
            _animProgress = 0.0F
            ModAnimasi.AnimateFloat(Me, Me, 0.0F, 1.0F, 560UL,
                Sub(v)
                    _animProgress = v
                    Invalidate()
                End Sub,
                easing:=AddressOf WinFormAnimation.AnimationFunctions.QuarticEaseOut)
        End Sub

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            Dim found As Integer = -1
            For i As Integer = 0 To _barRects.Count - 1
                Dim hitRect = New Rectangle(_barRects(i).X - 6, 30, _barRects(i).Width + 12, Height - 65)
                If hitRect.Contains(e.Location) Then
                    found = i
                    Exit For
                End If
            Next
            If found <> _hoverIndex Then
                _hoverIndex = found
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            If _hoverIndex <> -1 Then
                _hoverIndex = -1
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            g.Clear(BackColor)

            _barRects.Clear()
            If _data Is Nothing OrElse _data.Count = 0 Then
                Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    Using br As New SolidBrush(ModTema.WarnaTeksRedup)
                        g.DrawString("Belum ada data untuk ditampilkan.", ModTema.FontBiasa, br, ClientRectangle, sf)
                    End Using
                End Using
                Return
            End If

            Dim padLeft As Integer = If(_formatRupiah, 78, 42)
            Dim padRight As Integer = 20
            Dim padTop As Integer = 28
            Dim padBottom As Integer = 38
            Dim plotW As Integer = Math.Max(80, Width - padLeft - padRight)
            Dim plotH As Integer = Math.Max(60, Height - padTop - padBottom)
            Dim plotRect As New Rectangle(padLeft, padTop, plotW, plotH)

            Dim maxVal As Decimal = _data.Max(Function(d) d.Nilai)
            Dim niceMax As Decimal = HitungNiceMax(maxVal, _formatRupiah)

            ' Gridlines horizontal (4 garis)
            Using gridPen As New Pen(ModTema.WarnaGaris, 1.0F) With {.DashStyle = DashStyle.Dash}
                Using brAxis As New SolidBrush(ModTema.WarnaTeksRedup)
                    Using sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}
                        For stepIdx As Integer = 0 To 4
                            Dim frac As Double = stepIdx / 4.0
                            Dim y As Integer = plotRect.Bottom - CInt(Math.Round(plotRect.Height * frac))
                            g.DrawLine(gridPen, plotRect.Left, y, plotRect.Right, y)

                            Dim tickVal As Decimal = niceMax * CDec(frac)
                            Dim tickStr As String = If(_formatRupiah, FormatSingkatRupiah(tickVal), CInt(Math.Round(tickVal)).ToString())
                            g.DrawString(tickStr, ModTema.FontKecil, brAxis, New RectangleF(2, y - 10, padLeft - 10, 20), sfRight)
                        Next
                    End Using
                End Using
            End Using

            ' Garis sumbu dasar halus #DBCCBE
            Using basePen As New Pen(ModTema.WarnaGarisTegas, 1.5F)
                g.DrawLine(basePen, plotRect.Left, plotRect.Bottom, plotRect.Right, plotRect.Bottom)
            End Using

            ' Batang grafik dengan puncak melengkung 8px & gradasi hangat modern tanpa outline hitam
            Dim count As Integer = _data.Count
            Dim slotW As Double = plotRect.Width / CDbl(count)
            Dim barW As Integer = Math.Max(10, Math.Min(54, CInt(slotW * 0.56)))

            For i As Integer = 0 To count - 1
                Dim pt = _data(i)
                Dim ratio As Double = CDbl(pt.Nilai) / CDbl(niceMax)
                Dim fullBarH As Integer = Math.Max(If(pt.Nilai > 0D, 6, 0), CInt(Math.Round(plotRect.Height * ratio)))
                Dim barH As Integer = CInt(Math.Round(fullBarH * _animProgress))
                Dim cx As Integer = plotRect.Left + CInt(Math.Round(slotW * (i + 0.5)))
                Dim bx As Integer = cx - barW \ 2
                Dim by As Integer = plotRect.Bottom - barH
                Dim barRect As New Rectangle(bx, by, barW, barH)
                _barRects.Add(New Rectangle(bx, plotRect.Bottom - fullBarH, barW, fullBarH))

                If barH > 2 Then
                    Dim topCol As Color = If(i = _hoverIndex, ModTema.WarnaUtama, Color.FromArgb(255, 134, 87))
                    Dim botCol As Color = If(i = _hoverIndex, Color.FromArgb(217, 75, 31), ModTema.WarnaUtama)
                    Using barPath = ModTema.BuatTopRoundedPath(barRect, Math.Min(8, barH \ 2))
                        Using lgBar As New LinearGradientBrush(barRect, topCol, botCol, LinearGradientMode.Vertical)
                            g.FillPath(lgBar, barPath)
                        End Using
                    End Using
                End If

                ' Label X
                Using sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}
                    Dim lblCol As Color = If(i = _hoverIndex, ModTema.WarnaUtama, ModTema.WarnaTeksRedup)
                    Using brLbl As New SolidBrush(lblCol)
                        Using fntLbl As New Font(ModTema.FontKecil.FontFamily, 8.0F, If(i = _hoverIndex, FontStyle.Bold, FontStyle.Regular))
                            g.DrawString(pt.Label, fntLbl, brLbl, New RectangleF(CSng(cx - slotW / 2.0), plotRect.Bottom + 6, CSng(slotW), 26), sfCenter)
                        End Using
                    End Using
                End Using
            Next

            ' Tooltip interaktif rounded saat hover
            If _hoverIndex >= 0 AndAlso _hoverIndex < _data.Count Then
                Dim item = _data(_hoverIndex)
                Dim tipTxt As String = If(Not String.IsNullOrWhiteSpace(item.Keterangan), item.Keterangan,
                                          $"{item.Label}: {If(_formatRupiah, ModFormat.Rupiah(item.Nilai), item.Nilai.ToString("N0"))}")
                Dim sz = g.MeasureString(tipTxt, ModTema.FontKecil)
                Dim tw As Integer = CInt(Math.Ceiling(sz.Width)) + 20
                Dim th As Integer = 28
                Dim barR = _barRects(_hoverIndex)
                Dim tx As Integer = Math.Max(plotRect.Left, Math.Min(plotRect.Right - tw, barR.X + barR.Width \ 2 - tw \ 2))
                Dim ty As Integer = Math.Max(4, barR.Top - th - 6)
                Dim tipRect As New Rectangle(tx, ty, tw, th)
                Using tipPath = ModTema.BuatRoundedPath(tipRect, 10)
                    Using brDark As New SolidBrush(ModTema.WarnaCharcoal)
                        g.FillPath(brDark, tipPath)
                    End Using
                    Using penTip As New Pen(ModTema.WarnaUtama, 1.0F)
                        g.DrawPath(penTip, tipPath)
                    End Using
                End Using
                Using sfTip As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    Using brW As New SolidBrush(ModTema.WarnaLatar)
                        g.DrawString(tipTxt, ModTema.FontKecil, brW, tipRect, sfTip)
                    End Using
                End Using
            End If
        End Sub

        Private Shared Function HitungNiceMax(maxVal As Decimal, isRupiah As Boolean) As Decimal
            If maxVal <= 0D Then Return If(isRupiah, 400000D, 8D)
            Dim rawStep As Double = CDbl(maxVal * 1.08D) / 4.0
            Dim exp As Double = Math.Pow(10.0, Math.Floor(Math.Log10(Math.Max(1.0, rawStep))))
            Dim norm As Double = rawStep / exp
            Dim niceNorm As Double
            If norm <= 1.0 Then
                niceNorm = 1.0
            ElseIf norm <= 2.0 Then
                niceNorm = 2.0
            ElseIf norm <= 2.5 Then
                niceNorm = 2.5
            ElseIf norm <= 5.0 Then
                niceNorm = 5.0
            Else
                niceNorm = 10.0
            End If
            Dim niceStep As Decimal = CDec(niceNorm * exp)
            If isRupiah AndAlso niceStep < 25000D Then niceStep = 25000D
            If Not isRupiah AndAlso niceStep < 1D Then niceStep = 1D
            Return niceStep * 4D
        End Function

        Private Function FormatSingkatRupiah(val As Decimal) As String
            If val >= 1000000D Then
                Return $"Rp{val / 1000000D:0.#}jt"
            ElseIf val >= 1000D Then
                Return $"Rp{val / 1000D:0}rb"
            End If
            Return $"Rp{CInt(val)}"
        End Function

    End Class
End Namespace
