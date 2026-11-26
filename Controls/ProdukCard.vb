Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Controls

    ''' <summary>
    ''' Kartu produk bergaya Warm Modern Bistro Rounded:
    ''' sudut kartu 16px, badge rounded 10px tanpa bingkai hitam, tombol + rounded 10px, dan efek hover 60 FPS via WinFormAnimation.
    ''' </summary>
    Public Class ProdukCard
        Inherits UserControl

        Private Shared ReadOnly _fntCat As New Font(ModTema.FontKecil.FontFamily, 7.8F, FontStyle.Bold)
        Private Shared ReadOnly _fntNama As New Font(ModTema.FontSubJudul.FontFamily, 10.5F, FontStyle.Bold)
        Private Shared ReadOnly _fntPrice As New Font(ModTema.FontTebal.FontFamily, 12.5F, FontStyle.Bold)
        Private Shared ReadOnly _fntBadge As New Font(ModTema.FontKecil.FontFamily, 7.5F, FontStyle.Bold)

        Private _produk As Produk
        Private _isHovered As Boolean = False
        Private _isPressed As Boolean = False
        Private _hoverProgress As Single = 0.0F

        Public Event Dipilih(produk As Produk)

        Public Sub New()
            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
            Size = New Size(246, 322)
            Margin = New Padding(8)
            BackColor = ModTema.WarnaLatar
            Cursor = Cursors.Hand
        End Sub

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property Produk As Produk
            Get
                Return _produk
            End Get
            Set(value As Produk)
                _produk = value
                Dim habis As Boolean = IsHabis()
                Cursor = If(habis, Cursors.No, Cursors.Hand)
                Invalidate()
            End Set
        End Property

        Private Function IsHabis() As Boolean
            If _produk Is Nothing Then Return True
            If Not _produk.Tersedia Then Return True
            If _produk.Stok.HasValue AndAlso _produk.Stok.Value <= 0 Then Return True
            Return False
        End Function

        Private Sub AnimasiHoverKe(target As Single)
            If ModAnimasi.NonaktifkanAnimasi OrElse Not IsHandleCreated Then
                _hoverProgress = target
                Invalidate()
                Return
            End If
            ModAnimasi.AnimateFloat(Me, Me, _hoverProgress, target, 160UL,
                Sub(v)
                    _hoverProgress = v
                    Invalidate()
                End Sub)
        End Sub

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)
            If Not IsHabis() Then
                _isHovered = True
                AnimasiHoverKe(1.0F)
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            _isHovered = False
            _isPressed = False
            AnimasiHoverKe(0.0F)
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If e.Button = MouseButtons.Left AndAlso Not IsHabis() Then
                _isPressed = True
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            If e.Button = MouseButtons.Left AndAlso _isPressed Then
                _isPressed = False
                Invalidate()
                If Not IsHabis() AndAlso ClientRectangle.Contains(e.Location) Then
                    RaiseEvent Dipilih(_produk)
                End If
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            g.InterpolationMode = InterpolationMode.HighQualityBicubic

            g.Clear(If(Parent IsNot Nothing, Parent.BackColor, ModTema.WarnaLatar))
            If _produk Is Nothing Then Return

            Dim habis As Boolean = IsHabis()
            Dim yOffset As Integer = If(_isPressed, 2, -CInt(Math.Round(4.0F * _hoverProgress)))
            Dim cardRect As New Rectangle(5, 8 + yOffset, Width - 10, Height - 18)

            ' 1. Bayangan 2 lapis lembut terdiffusi (#2C1810 subtle -> elevated saat hover 60 FPS)
            Dim shadowOffset As Integer = 3 + CInt(Math.Round(3.0F * _hoverProgress))
            Dim outerAlpha As Integer = 10 + CInt(Math.Round(12.0F * _hoverProgress))
            Dim innerAlpha As Integer = 16 + CInt(Math.Round(16.0F * _hoverProgress))
            Dim outerShadowRect As New Rectangle(cardRect.X - 2, cardRect.Y + shadowOffset + 1, cardRect.Width + 4, cardRect.Height + 2)
            Using spOuter = ModTema.BuatRoundedPath(outerShadowRect, 18)
                Using sbOuter As New SolidBrush(Color.FromArgb(outerAlpha, 44, 24, 16))
                    g.FillPath(sbOuter, spOuter)
                End Using
            End Using
            Dim shadowRect As New Rectangle(cardRect.X, cardRect.Y + shadowOffset - 1, cardRect.Width, cardRect.Height + 1)
            Using sp = ModTema.BuatRoundedPath(shadowRect, 17)
                Using sb As New SolidBrush(Color.FromArgb(innerAlpha, 44, 24, 16))
                    g.FillPath(sb, sp)
                End Using
            End Using

            ' 2. Badan kartu putih (.menu-card, radius 16px)
            Using cardPath = ModTema.BuatRoundedPath(cardRect, 16)
                Using bgBrush As New SolidBrush(ModTema.WarnaPermukaan)
                    g.FillPath(bgBrush, cardPath)
                End Using

                ' 3. Foto produk atas (clip ke rounded rect atas)
                Dim imgHeight As Integer = 176
                Dim imgRect As New Rectangle(cardRect.X, cardRect.Y, cardRect.Width, imgHeight)
                Dim oldClip = g.Clip
                g.SetClip(cardPath)
                g.SetClip(imgRect, CombineMode.Intersect)

                Dim img As Image = ModProduk.AmbilGambar(_produk.Gambar)
                If img IsNot Nothing Then
                    DrawCoverImage(g, img, imgRect)
                End If

                If habis Then
                    Using dimBrush As New SolidBrush(Color.FromArgb(145, 44, 24, 16))
                        g.FillRectangle(dimBrush, imgRect)
                    End Using
                End If
                g.Clip = oldClip

                ' Garis pemisah tipis bawah foto
                Using sepPen As New Pen(ModTema.WarnaGaris, 1.0F)
                    g.DrawLine(sepPen, cardRect.X, cardRect.Y + imgHeight, cardRect.Right, cardRect.Y + imgHeight)
                End Using

                ' 4. Badge pill modern lembut
                If habis Then
                    DrawRoundedBadge(g, cardRect.X + 12, cardRect.Y + 12, ModBahasa.T("habis"), ModTema.WarnaBahaya, Color.White, False)
                Else
                    If _produk.BestSeller Then
                        DrawRoundedBadge(g, cardRect.X + 12, cardRect.Y + 12, ModBahasa.T("best_seller"), ModTema.WarnaSekunderLatar, ModTema.WarnaTeks, True)
                    End If
                    Dim ambang As Integer = ModPengaturan.AmbilInt("ambang_stok", 5)
                    If _produk.Stok.HasValue AndAlso _produk.Stok.Value <= ambang Then
                        Dim stokTxt As String = $"STOK: {_produk.Stok.Value}"
                        DrawRoundedBadge(g, cardRect.Right - 84, cardRect.Y + 12, stokTxt, ModTema.WarnaUtama, Color.White, False)
                    End If
                End If

                ' 5. Kategori mikro-label (#8B4513)
                Dim textX As Integer = cardRect.X + 14
                Dim textW As Integer = cardRect.Width - 28
                Using brCat As New SolidBrush(ModTema.WarnaSekunder)
                    g.DrawString(_produk.NamaKategori.ToUpperInvariant(), _fntCat, brCat, New RectangleF(textX, cardRect.Y + imgHeight + 10, textW, 18))
                End Using

                ' 6. Nama produk
                Dim nameColor As Color = If(habis, ModTema.WarnaTeksRedup, ModTema.WarnaTeks)
                Using brNama As New SolidBrush(nameColor)
                    Using sfName As New StringFormat() With {.Trimming = StringTrimming.EllipsisWord}
                        g.DrawString(_produk.Nama, _fntNama, brNama, New RectangleF(textX, cardRect.Y + imgHeight + 29, textW, 44), sfName)
                    End Using
                End Using

                ' 7. Harga (#FF6B35) & Tombol + Rounded 10px bersih tanpa border hitam
                Dim priceY As Integer = cardRect.Bottom - 40
                Dim priceColor As Color = If(habis, ModTema.WarnaTeksRedup, ModTema.WarnaUtama)
                Using brPrice As New SolidBrush(priceColor)
                    g.DrawString(ModFormat.Rupiah(_produk.Harga), _fntPrice, brPrice, New PointF(textX, priceY + 4))
                End Using

                Dim btnSize As Integer = 34
                Dim btnRect As New Rectangle(cardRect.Right - btnSize - 14, cardRect.Bottom - btnSize - 14, btnSize, btnSize)
                If Not habis Then
                    Dim shAlpha As Integer = 28 + CInt(Math.Round(18.0F * _hoverProgress))
                    Dim shRect As New Rectangle(btnRect.X, btnRect.Y + 2, btnSize, btnSize)
                    Using shPath = ModTema.BuatRoundedPath(shRect, 10)
                        Using brSh As New SolidBrush(Color.FromArgb(shAlpha, 255, 107, 53))
                            g.FillPath(brSh, shPath)
                        End Using
                    End Using
                End If
                Dim btnFill As Color = If(habis, ModTema.WarnaGaris, If(_isHovered, ModTema.WarnaUtamaHover, ModTema.WarnaUtama))
                Using btnPath = ModTema.BuatRoundedPath(btnRect, 10)
                    Using brBtn As New SolidBrush(btnFill)
                        g.FillPath(brBtn, btnPath)
                    End Using
                End Using
                Dim plusBmp = BistroIcons.GetIcon(IconChar.Plus, Color.White, 15)
                g.DrawImage(plusBmp, btnRect.X + (btnSize - 15) \ 2, btnRect.Y + (btnSize - 15) \ 2, 15, 15)

                ' 8. Border kartu lembut (1.5px #FF6B35 saat hover, 1.0px #E8DDD4 normal)
                Dim borderCol As Color = If(_isHovered AndAlso Not habis, ModTema.WarnaUtama, ModTema.WarnaGaris)
                Dim borderW As Single = If(_isHovered AndAlso Not habis, 1.5F, 1.0F)
                Using borderPen As New Pen(borderCol, borderW)
                    g.DrawPath(borderPen, cardPath)
                End Using
            End Using
        End Sub

        Private Sub DrawCoverImage(g As Graphics, img As Image, target As Rectangle)
            Dim imgRatio As Double = img.Width / Math.Max(1.0, CDbl(img.Height))
            Dim targetRatio As Double = target.Width / Math.Max(1.0, CDbl(target.Height))
            Dim drawRect As Rectangle
            If imgRatio > targetRatio Then
                Dim w As Integer = CInt(target.Height * imgRatio)
                drawRect = New Rectangle(target.X - (w - target.Width) \ 2, target.Y, w, target.Height)
            Else
                Dim h As Integer = CInt(target.Width / imgRatio)
                drawRect = New Rectangle(target.X, target.Y - (h - target.Height) \ 2, target.Width, h)
            End If
            g.DrawImage(img, drawRect)
        End Sub

        Private Sub DrawRoundedBadge(g As Graphics, x As Integer, y As Integer, text As String, bg As Color, fg As Color, useLightBorder As Boolean)
            Dim sz = g.MeasureString(text, _fntBadge)
            Dim rect As New Rectangle(x, y, CInt(Math.Ceiling(sz.Width)) + 16, 22)
            Using path = ModTema.BuatRoundedPath(rect, 10)
                Using br As New SolidBrush(bg)
                    g.FillPath(br, path)
                End Using
                If useLightBorder Then
                    Using penInk As New Pen(Color.FromArgb(40, 44, 24, 16), 1.0F)
                        g.DrawPath(penInk, path)
                    End Using
                End If
            End Using
            Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                Using brFg As New SolidBrush(fg)
                    g.DrawString(text, _fntBadge, brFg, rect, sf)
                End Using
            End Using
        End Sub

    End Class
End Namespace
