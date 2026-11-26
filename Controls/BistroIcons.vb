Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Namespace VisproPrakProjectAkhir.Controls

    ''' <summary>
    ''' Cache ikon vektor FontAwesome.Sharp ke Bitmap beresolusi tinggi tanpa emoji.
    ''' </summary>
    Public Module BistroIcons

        Private ReadOnly _cache As New Dictionary(Of String, Bitmap)(StringComparer.Ordinal)

        Public Function GetIcon(icon As IconChar, warna As Color, Optional ukuran As Integer = 22) As Bitmap
            Dim key As String = $"{CInt(icon)}_{warna.ToArgb()}_{ukuran}"
            Dim bmp As Bitmap = Nothing
            If _cache.TryGetValue(key, bmp) Then Return bmp

            bmp = icon.ToBitmap(warna, ukuran)
            _cache(key) = bmp
            Return bmp
        End Function

        Public Function GetBadgeIcon(icon As IconChar, iconColor As Color, bgColor As Color, Optional diameter As Integer = 40, Optional iconSize As Integer = 19) As Bitmap
            Dim d As Integer = Math.Max(16, diameter)
            Dim key As String = $"badge_{CInt(icon)}_{iconColor.ToArgb()}_{bgColor.ToArgb()}_{d}_{iconSize}"
            Dim bmp As Bitmap = Nothing
            If _cache.TryGetValue(key, bmp) Then Return bmp

            bmp = New Bitmap(d, d, Drawing.Imaging.PixelFormat.Format32bppArgb)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.Clear(Color.Transparent)
                Using br As New SolidBrush(bgColor)
                    g.FillEllipse(br, 1, 1, d - 2, d - 2)
                End Using
                Dim icBmp As Bitmap = GetIcon(icon, iconColor, iconSize)
                Dim ix As Integer = (d - icBmp.Width) \ 2
                Dim iy As Integer = (d - icBmp.Height) \ 2
                g.DrawImage(icBmp, ix, iy, icBmp.Width, icBmp.Height)
            End Using
            _cache(key) = bmp
            Return bmp
        End Function

        Public Function GetCategoryIcon(namaKategori As String, warna As Color, Optional ukuran As Integer = 20) As Bitmap
            Dim lower As String = If(namaKategori, "").ToLowerInvariant()
            Dim ic As IconChar = IconChar.Utensils
            If lower.Contains("semua") OrElse lower.Contains("all") Then
                ic = IconChar.Fire
            ElseIf lower.Contains("paket") Then
                ic = IconChar.Box
            ElseIf lower.Contains("ayam") Then
                ic = IconChar.DrumstickBite
            ElseIf lower.Contains("burger") Then
                ic = IconChar.Burger
            ElseIf lower.Contains("nasi") Then
                ic = IconChar.BowlFood
            ElseIf lower.Contains("side") OrElse lower.Contains("kentang") Then
                ic = IconChar.PepperHot
            ElseIf lower.Contains("minum") OrElse lower.Contains("kopi") Then
                ic = IconChar.Coffee
            ElseIf lower.Contains("dessert") Then
                ic = IconChar.IceCream
            End If
            Return GetIcon(ic, warna, ukuran)
        End Function

    End Module
End Namespace

