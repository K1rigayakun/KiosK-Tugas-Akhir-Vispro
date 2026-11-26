Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModTema

        ' Palet Editorial Warm Bistro (konsisten 1:1 antara Designer dan Runtime)
        Public ReadOnly WarnaUtama As Color = Color.FromArgb(255, 107, 53)         ' #FF6B35 Vibrant Terracotta Orange
        Public ReadOnly WarnaUtamaHover As Color = Color.FromArgb(229, 90, 43)     ' #E55A2B Deep CTA Hover
        Public ReadOnly WarnaUtamaLembut As Color = Color.FromArgb(255, 240, 230)   ' #FFF0E6 Soft Apricot Tint
        Public ReadOnly WarnaSekunder As Color = Color.FromArgb(139, 69, 19)       ' #8B4513 Saddle Brown
        Public ReadOnly WarnaAksen As Color = Color.FromArgb(255, 107, 53)         ' #FF6B35 Warm Accent
        Public ReadOnly WarnaAksenLembut As Color = Color.FromArgb(255, 245, 230)  ' #FFF5E6 Warm Cream Accent
        Public ReadOnly WarnaLatar As Color = Color.FromArgb(255, 250, 240)        ' #FFFAF0 Warm Floral Cream
        Public ReadOnly WarnaPermukaan As Color = Color.FromArgb(255, 255, 255)    ' #FFFFFF Crisp Surface
        Public ReadOnly WarnaSekunderLatar As Color = Color.FromArgb(255, 245, 230) ' #FFF5E6 Warm Cream Panel
        Public ReadOnly WarnaGaris As Color = Color.FromArgb(232, 221, 212)        ' #E8DDD4 Warm Ink Divider / Soft Card Border
        Public ReadOnly WarnaGarisTegas As Color = Color.FromArgb(219, 204, 190)   ' #DBCCBE Soft Input & Button Border
        Public ReadOnly WarnaSekunderHover As Color = Color.FromArgb(255, 236, 219) ' #FFECDB Warm Secondary Hover
        Public ReadOnly WarnaCharcoal As Color = Color.FromArgb(44, 24, 16)        ' #2C1810 Dark Espresso
        Public ReadOnly WarnaCharcoalLembut As Color = Color.FromArgb(63, 37, 26)  ' #3F251A Elevated Espresso
        Public ReadOnly WarnaTeks As Color = Color.FromArgb(44, 24, 16)            ' #2C1810 Espresso Ink
        Public ReadOnly WarnaTeksRedup As Color = Color.FromArgb(107, 83, 68)      ' #6B5344 Roasted Muted Cocoa
        Public ReadOnly WarnaSukses As Color = Color.FromArgb(74, 124, 89)         ' #4A7C59 Accent Sage Green
        Public ReadOnly WarnaSuksesLembut As Color = Color.FromArgb(234, 243, 236) ' #EAF3EC
        Public ReadOnly WarnaPeringatan As Color = Color.FromArgb(200, 116, 30)    ' #C8741E Warm Amber
        Public ReadOnly WarnaPeringatanLembut As Color = Color.FromArgb(255, 243, 223)
        Public ReadOnly WarnaBahaya As Color = Color.FromArgb(192, 57, 43)         ' #C0392B Terracotta Crimson
        Public ReadOnly WarnaBahayaLembut As Color = Color.FromArgb(253, 236, 236)

        Public ReadOnly WarnaBayanganLuar As Color = Color.FromArgb(14, 44, 24, 16)
        Public ReadOnly WarnaBayanganDalam As Color = Color.FromArgb(22, 44, 24, 16)
        Public ReadOnly WarnaBayanganLembut As Color = Color.FromArgb(22, 44, 24, 16)

        Private Const FR_PRIVATE As UInteger = &H10UI

        <DllImport("gdi32.dll", CharSet:=CharSet.Unicode)>
        Private Function AddFontResourceExW(lpszFilename As String, fl As UInteger, pdv As IntPtr) As Integer
        End Function

        Private ReadOnly _pfc As New PrivateFontCollection()
        Private ReadOnly _fontsLoaded As Boolean = MuatFontPrivat()

        Private ReadOnly _familyDisplay As String = PilihFont({"Georgia", "Cambria", "Segoe UI"})
        Private ReadOnly _familyText As String = PilihFont({"Segoe UI Variable Text", "Segoe UI", "Calibri"})
        Private ReadOnly _familyMono As String = PilihFont({"Cascadia Mono", "Consolas", "Courier New"})

        Public ReadOnly FontJudulBesar As New Font(_familyDisplay, 21.0F, FontStyle.Bold)
        Public ReadOnly FontJudul As New Font(_familyDisplay, 14.5F, FontStyle.Bold)
        Public ReadOnly FontSubJudul As New Font(_familyText, 11.0F, FontStyle.Bold)
        Public ReadOnly FontBiasa As New Font(_familyText, 10.0F, FontStyle.Regular)
        Public ReadOnly FontTebal As New Font(_familyText, 10.0F, FontStyle.Bold)
        Public ReadOnly FontKecil As New Font(_familyText, 8.75F, FontStyle.Regular)
        Public ReadOnly FontStruk As New Font(_familyMono, 9.5F, FontStyle.Regular)

        Private Class HardShadowEntry
            Public Target As Control
            Public AttachedParent As Control
            Public BaseOffsetX As Single
            Public BaseOffsetY As Single
            Public ShadowColor As Color?
            Public LastShadowBounds As Rectangle
        End Class

        Private ReadOnly _shadowRegistry As New Dictionary(Of Control, List(Of HardShadowEntry))()
        Private ReadOnly _controlEntryMap As New Dictionary(Of Control, HardShadowEntry)()

        Private Function MuatFontPrivat() As Boolean
            Try
                Dim baseDir As String = AppContext.BaseDirectory
                Dim fontFolder As String = Path.Combine(baseDir, "Asset", "Fonts")
                If Not Directory.Exists(fontFolder) Then
                    Dim alt As String = Path.Combine(Directory.GetCurrentDirectory(), "Asset", "Fonts")
                    If Directory.Exists(alt) Then fontFolder = alt
                End If
                If Not Directory.Exists(fontFolder) Then Return False

                For Each fName In {"PlayfairDisplaySC-Bold.ttf", "Karla-Regular.ttf", "Karla-Bold.ttf"}
                    Dim fp As String = Path.Combine(fontFolder, fName)
                    If File.Exists(fp) Then
                        AddFontResourceExW(fp, FR_PRIVATE, IntPtr.Zero)
                        _pfc.AddFontFile(fp)
                    End If
                Next
                Return True
            Catch
                Return False
            End Try
        End Function

        Private Function PilihFont(kandidat As String()) As String
            Dim names As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            Try
                For Each fam In _pfc.Families
                    names.Add(fam.Name)
                Next
            Catch
            End Try
            Using fc As New InstalledFontCollection()
                For Each x In fc.Families
                    names.Add(x.Name)
                Next
            End Using
            For Each k In kandidat
                If names.Contains(k) Then Return k
            Next
            Return "Segoe UI"
        End Function

        Public Sub PasangSoftShadow(ctrl As Control, Optional offsetX As Integer = 0, Optional offsetY As Integer = 3, Optional shadowColor As Color? = Nothing)
            PasangHardShadow(ctrl, offsetX, offsetY, shadowColor)
        End Sub

        Public Sub PasangHardShadow(ctrl As Control, Optional offsetX As Integer = 0, Optional offsetY As Integer = 3, Optional shadowColor As Color? = Nothing)
            If ctrl Is Nothing OrElse ctrl.IsDisposed Then Return

            Dim entry As HardShadowEntry = Nothing
            If _controlEntryMap.TryGetValue(ctrl, entry) Then
                Dim oldDirty = entry.LastShadowBounds
                entry.BaseOffsetX = offsetX
                entry.BaseOffsetY = offsetY
                entry.ShadowColor = shadowColor
                Dim newBounds = HitungBoundsShadow(entry)
                entry.LastShadowBounds = newBounds
                If entry.AttachedParent IsNot Nothing AndAlso Not entry.AttachedParent.IsDisposed Then
                    Dim dirty = If(oldDirty.IsEmpty, newBounds, Rectangle.Union(oldDirty, newBounds))
                    dirty.Inflate(4, 4)
                    entry.AttachedParent.Invalidate(dirty, False)
                End If
                Return
            End If

            entry = New HardShadowEntry With {
                .Target = ctrl,
                .BaseOffsetX = offsetX,
                .BaseOffsetY = offsetY,
                .ShadowColor = shadowColor,
                .LastShadowBounds = Rectangle.Empty
            }
            _controlEntryMap(ctrl) = entry

            Dim invalidateDirty As Action =
                Sub()
                    If entry.AttachedParent Is Nothing OrElse entry.AttachedParent.IsDisposed Then Return
                    Dim oldR = entry.LastShadowBounds
                    Dim newR = HitungBoundsShadow(entry)
                    entry.LastShadowBounds = newR
                    Dim dirty = If(oldR.IsEmpty, newR, If(newR.IsEmpty, oldR, Rectangle.Union(oldR, newR)))
                    If Not dirty.IsEmpty Then
                        dirty.Inflate(4, 4)
                        entry.AttachedParent.Invalidate(dirty, False)
                    End If
                End Sub

            AddHandler ctrl.ParentChanged, Sub() SinkronParentShadow(entry)
            AddHandler ctrl.LocationChanged, Sub() invalidateDirty()
            AddHandler ctrl.SizeChanged, Sub() invalidateDirty()
            AddHandler ctrl.VisibleChanged, Sub() invalidateDirty()
            AddHandler ctrl.Disposed, Sub() LepasShadowEntry(entry)

            SinkronParentShadow(entry)
        End Sub

        Private Function HitungBoundsShadow(entry As HardShadowEntry) As Rectangle
            Dim t = entry.Target
            If t Is Nothing OrElse t.IsDisposed OrElse Not t.Visible Then Return Rectangle.Empty
            Dim oy As Integer = Math.Max(2, CInt(Math.Round(entry.BaseOffsetY)))
            Dim ox As Integer = CInt(Math.Round(entry.BaseOffsetX))
            Dim r As New Rectangle(t.Left + ox - 3, t.Top + oy - 1, t.Width + 6, t.Height + oy + 5)
            Return r
        End Function

        Private Sub SinkronParentShadow(entry As HardShadowEntry)
            If entry.AttachedParent Is entry.Target.Parent Then Return

            If entry.AttachedParent IsNot Nothing Then
                Dim oldList As List(Of HardShadowEntry) = Nothing
                If _shadowRegistry.TryGetValue(entry.AttachedParent, oldList) Then
                    oldList.Remove(entry)
                End If
                If Not entry.AttachedParent.IsDisposed AndAlso Not entry.LastShadowBounds.IsEmpty Then
                    Dim r = entry.LastShadowBounds
                    r.Inflate(4, 4)
                    entry.AttachedParent.Invalidate(r, False)
                End If
            End If

            Dim p As Control = entry.Target.Parent
            entry.AttachedParent = p
            If p Is Nothing OrElse p.IsDisposed Then Return

            Dim lst As List(Of HardShadowEntry) = Nothing
            If Not _shadowRegistry.TryGetValue(p, lst) Then
                lst = New List(Of HardShadowEntry)()
                _shadowRegistry(p) = lst
                AktifkanDoubleBuffer(p)
                AddHandler p.Paint, AddressOf OnParentShadowPaint
                AddHandler p.Disposed, AddressOf OnParentDisposed
            End If
            If Not lst.Contains(entry) Then lst.Add(entry)
            entry.LastShadowBounds = HitungBoundsShadow(entry)
            If Not entry.LastShadowBounds.IsEmpty Then
                Dim dirty = entry.LastShadowBounds
                dirty.Inflate(4, 4)
                p.Invalidate(dirty, False)
            End If
        End Sub

        Private Sub LepasShadowEntry(entry As HardShadowEntry)
            If entry.AttachedParent IsNot Nothing Then
                Dim lst As List(Of HardShadowEntry) = Nothing
                If _shadowRegistry.TryGetValue(entry.AttachedParent, lst) Then
                    lst.Remove(entry)
                End If
                If Not entry.AttachedParent.IsDisposed AndAlso Not entry.LastShadowBounds.IsEmpty Then
                    Dim r = entry.LastShadowBounds
                    r.Inflate(4, 4)
                    entry.AttachedParent.Invalidate(r, False)
                End If
            End If
            _controlEntryMap.Remove(entry.Target)
        End Sub

        Private Sub OnParentDisposed(sender As Object, e As EventArgs)
            Dim p = TryCast(sender, Control)
            If p IsNot Nothing Then _shadowRegistry.Remove(p)
        End Sub

        Private Function AmbilBorderRadiusTarget(t As Control) As Integer
            If TypeOf t Is Guna2Button Then Return DirectCast(t, Guna2Button).BorderRadius
            If TypeOf t Is Guna2Panel Then Return DirectCast(t, Guna2Panel).BorderRadius
            If TypeOf t Is Guna2PictureBox Then Return DirectCast(t, Guna2PictureBox).BorderRadius
            Return 0
        End Function

        Private Sub OnParentShadowPaint(sender As Object, e As PaintEventArgs)
            Dim p = TryCast(sender, Control)
            If p Is Nothing Then Return
            Dim lst As List(Of HardShadowEntry) = Nothing
            If Not _shadowRegistry.TryGetValue(p, lst) OrElse lst.Count = 0 Then Return

            Dim bg As Color = p.BackColor
            If TypeOf p Is Guna2Panel Then
                bg = DirectCast(p, Guna2Panel).FillColor
            ElseIf bg = Color.Transparent AndAlso p.Parent IsNot Nothing Then
                bg = p.Parent.BackColor
            End If
            Dim luma As Integer = (CInt(bg.R) * 299 + CInt(bg.G) * 587 + CInt(bg.B) * 114) \ 1000

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            For Each entry In lst
                Dim t = entry.Target
                If t Is Nothing OrElse t.IsDisposed OrElse Not t.Visible Then Continue For
                If t.Dock = DockStyle.Fill AndAlso (p.Padding.Right < 4 OrElse p.Padding.Bottom < 4) Then Continue For
                If Not entry.ShadowColor.HasValue AndAlso luma < 85 Then Continue For

                Dim bounds = HitungBoundsShadow(entry)
                If bounds.IsEmpty OrElse Not e.ClipRectangle.IntersectsWith(bounds) Then Continue For

                Dim baseCol As Color = If(entry.ShadowColor, WarnaCharcoal)
                Dim oy As Integer = Math.Max(2, CInt(Math.Round(entry.BaseOffsetY)))
                Dim ox As Integer = CInt(Math.Round(entry.BaseOffsetX))
                Dim rad As Integer = Math.Max(2, AmbilBorderRadiusTarget(t))

                ' Lapisan luar lembut terdiffusi
                Dim outerAlpha As Integer = If(entry.ShadowColor.HasValue, Math.Min(30, CInt(baseCol.A \ 2)), 13)
                Dim outerRect As New Rectangle(t.Left + ox - 2, t.Top + oy + 1, t.Width + 4, t.Height + 2)
                Using brOuter As New SolidBrush(Color.FromArgb(outerAlpha, baseCol.R, baseCol.G, baseCol.B))
                    Using pOuter = BuatRoundedPath(outerRect, rad + 2)
                        e.Graphics.FillPath(brOuter, pOuter)
                    End Using
                End Using

                ' Lapisan dalam tipis di bawah komponen
                Dim innerAlpha As Integer = If(entry.ShadowColor.HasValue, Math.Min(46, CInt(baseCol.A)), 21)
                Dim innerRect As New Rectangle(t.Left + ox, t.Top + Math.Max(1, oy - 1), t.Width, t.Height + 1)
                Using brInner As New SolidBrush(Color.FromArgb(innerAlpha, baseCol.R, baseCol.G, baseCol.B))
                    Using pInner = BuatRoundedPath(innerRect, rad + 1)
                        e.Graphics.FillPath(brInner, pInner)
                    End Using
                End Using
            Next
        End Sub

        Public Sub TerapkanForm(f As Form)
            If f Is Nothing Then Return
            f.BackColor = WarnaLatar
            f.ForeColor = WarnaTeks
            f.Font = FontBiasa
        End Sub

        Public Sub AktifkanDoubleBuffer(ctrl As Control)
            If ctrl Is Nothing Then Return
            Try
                Dim pi = ctrl.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
                If pi IsNot Nothing Then pi.SetValue(ctrl, True, Nothing)
            Catch
            End Try
        End Sub

        Public Sub TombolUtama(b As Button)
            If b Is Nothing Then Return
            b.FlatStyle = FlatStyle.Flat
            b.FlatAppearance.BorderSize = 2
            b.FlatAppearance.BorderColor = WarnaTeks
            b.BackColor = WarnaUtama
            b.ForeColor = Color.White
            b.Font = FontTebal
            b.Cursor = Cursors.Hand
            If b.Height < 42 Then b.Height = 44
            AddHandler b.MouseEnter, Sub() b.BackColor = WarnaUtamaHover
            AddHandler b.MouseLeave, Sub() b.BackColor = WarnaUtama
        End Sub

        Public Sub TombolSekunder(b As Button)
            If b Is Nothing Then Return
            b.FlatStyle = FlatStyle.Flat
            b.FlatAppearance.BorderSize = 2
            b.FlatAppearance.BorderColor = WarnaTeks
            b.BackColor = WarnaLatar
            b.ForeColor = WarnaTeks
            b.Font = FontTebal
            b.Cursor = Cursors.Hand
            If b.Height < 42 Then b.Height = 44
            AddHandler b.MouseEnter, Sub()
                                         b.BackColor = WarnaTeks
                                         b.ForeColor = WarnaLatar
                                     End Sub
            AddHandler b.MouseLeave, Sub()
                                         b.BackColor = WarnaLatar
                                         b.ForeColor = WarnaTeks
                                     End Sub
        End Sub

        Public Sub GayaGunaButtonUtama(b As Guna2Button, Optional radius As Integer = 12)
            b.BackColor = Color.Transparent
            b.UseTransparentBackground = True
            b.FillColor = WarnaUtama
            b.ForeColor = Color.White
            b.Font = FontTebal
            b.BorderRadius = radius
            b.BorderThickness = 0
            b.BorderColor = WarnaUtama
            b.Animated = True
            b.Cursor = Cursors.Hand
            b.HoverState.FillColor = WarnaUtamaHover
            b.HoverState.BorderColor = WarnaUtamaHover
            b.PressedColor = Color.FromArgb(204, 72, 28)
            b.ShadowDecoration.Enabled = False
            PasangSoftShadow(b, 0, 3, Color.FromArgb(38, 255, 107, 53))
        End Sub

        Public Sub GayaGunaButtonSekunder(b As Guna2Button, Optional radius As Integer = 12)
            b.BackColor = Color.Transparent
            b.UseTransparentBackground = True
            b.FillColor = WarnaSekunderLatar
            b.ForeColor = WarnaTeks
            b.Font = FontTebal
            b.BorderRadius = radius
            b.BorderThickness = 1
            b.BorderColor = WarnaGarisTegas
            b.Animated = True
            b.Cursor = Cursors.Hand
            b.HoverState.FillColor = WarnaSekunderHover
            b.HoverState.ForeColor = WarnaTeks
            b.HoverState.BorderColor = WarnaUtama
            b.ShadowDecoration.Enabled = False
            PasangSoftShadow(b, 0, 2)
        End Sub

        Public Sub GayaGunaButtonDark(b As Guna2Button, Optional radius As Integer = 12)
            b.BackColor = Color.Transparent
            b.UseTransparentBackground = True
            b.FillColor = WarnaCharcoal
            b.ForeColor = WarnaLatar
            b.Font = FontTebal
            b.BorderRadius = radius
            b.BorderThickness = 0
            b.BorderColor = WarnaCharcoal
            b.Animated = True
            b.Cursor = Cursors.Hand
            b.HoverState.FillColor = WarnaUtama
            b.HoverState.ForeColor = Color.White
            b.HoverState.BorderColor = WarnaUtama
            b.ShadowDecoration.Enabled = False
        End Sub

        Public Sub GayaGunaButtonSukses(b As Guna2Button, Optional radius As Integer = 12)
            b.BackColor = Color.Transparent
            b.UseTransparentBackground = True
            b.FillColor = WarnaSukses
            b.ForeColor = Color.White
            b.Font = FontTebal
            b.BorderRadius = radius
            b.BorderThickness = 0
            b.BorderColor = WarnaSukses
            b.Animated = True
            b.Cursor = Cursors.Hand
            b.HoverState.FillColor = Color.FromArgb(58, 100, 71)
            b.HoverState.BorderColor = Color.FromArgb(58, 100, 71)
            b.ShadowDecoration.Enabled = False
            PasangSoftShadow(b, 0, 3, Color.FromArgb(36, 74, 124, 89))
        End Sub

        Public Sub GayaGunaButtonBahaya(b As Guna2Button, Optional radius As Integer = 12)
            b.BackColor = Color.Transparent
            b.UseTransparentBackground = True
            b.FillColor = WarnaBahayaLembut
            b.ForeColor = WarnaBahaya
            b.Font = FontTebal
            b.BorderRadius = radius
            b.BorderThickness = 1
            b.BorderColor = Color.FromArgb(234, 181, 176)
            b.Animated = True
            b.Cursor = Cursors.Hand
            b.HoverState.FillColor = WarnaBahaya
            b.HoverState.ForeColor = Color.White
            b.HoverState.BorderColor = WarnaBahaya
            b.ShadowDecoration.Enabled = False
            PasangSoftShadow(b, 0, 2, Color.FromArgb(32, 192, 57, 43))
        End Sub

        Public Sub GayaGunaCard(p As Guna2Panel, Optional radius As Integer = 16)
            p.BackColor = Color.Transparent
            p.UseTransparentBackground = True
            p.FillColor = WarnaPermukaan
            p.BorderColor = WarnaGaris
            p.BorderThickness = 1
            p.BorderRadius = radius
            p.ShadowDecoration.Enabled = False
            PasangSoftShadow(p, 0, 3)
        End Sub

        Public Sub GayaGunaTextBox(t As Guna2TextBox, Optional placeholder As String = "", Optional radius As Integer = 12)
            t.BackColor = Color.Transparent
            t.FillColor = WarnaPermukaan
            t.ForeColor = WarnaTeks
            t.Font = FontBiasa
            t.BorderRadius = radius
            t.BorderThickness = 1
            t.BorderColor = WarnaGarisTegas
            t.FocusedState.BorderColor = WarnaUtama
            t.HoverState.BorderColor = WarnaTeksRedup
            t.PlaceholderForeColor = WarnaTeksRedup
            If Not String.IsNullOrEmpty(placeholder) Then t.PlaceholderText = placeholder
            t.ShadowDecoration.Enabled = False
        End Sub

        Public Sub GayaGunaComboBox(c As Guna2ComboBox, Optional radius As Integer = 12)
            c.BackColor = Color.Transparent
            c.FillColor = WarnaPermukaan
            c.ForeColor = WarnaTeks
            c.Font = FontBiasa
            c.BorderRadius = radius
            c.BorderThickness = 1
            c.BorderColor = WarnaGarisTegas
            c.FocusedState.BorderColor = WarnaUtama
            c.HoverState.BorderColor = WarnaTeksRedup
            c.ItemHeight = 32
        End Sub

        Public Sub GayaDataGridView(dgv As DataGridView)
            dgv.BackgroundColor = WarnaPermukaan
            dgv.BorderStyle = BorderStyle.None
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            dgv.GridColor = WarnaGaris
            dgv.EnableHeadersVisualStyles = False
            dgv.RowHeadersVisible = False
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.AllowUserToResizeRows = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.MultiSelect = False
            dgv.RowTemplate.Height = 40
            dgv.ColumnHeadersHeight = 42
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            dgv.ColumnHeadersDefaultCellStyle.BackColor = WarnaSekunderLatar
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = WarnaTeks
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = WarnaSekunderLatar
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = WarnaTeks
            dgv.ColumnHeadersDefaultCellStyle.Font = FontTebal
            dgv.ColumnHeadersDefaultCellStyle.Padding = New Padding(8, 0, 8, 0)
            dgv.DefaultCellStyle.BackColor = WarnaPermukaan
            dgv.DefaultCellStyle.ForeColor = WarnaTeks
            dgv.DefaultCellStyle.Font = FontBiasa
            dgv.DefaultCellStyle.Padding = New Padding(8, 4, 8, 4)
            dgv.DefaultCellStyle.SelectionBackColor = WarnaUtamaLembut
            dgv.DefaultCellStyle.SelectionForeColor = WarnaTeks
            dgv.AlternatingRowsDefaultCellStyle.BackColor = WarnaLatar

            Dim gDgv = TryCast(dgv, Guna2DataGridView)
            If gDgv IsNot Nothing Then
                gDgv.ThemeStyle.BackColor = WarnaPermukaan
                gDgv.ThemeStyle.GridColor = WarnaGaris
                gDgv.ThemeStyle.HeaderStyle.BackColor = WarnaSekunderLatar
                gDgv.ThemeStyle.HeaderStyle.ForeColor = WarnaTeks
                gDgv.ThemeStyle.HeaderStyle.Font = FontTebal
                gDgv.ThemeStyle.HeaderStyle.Height = 42
                gDgv.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
                gDgv.ThemeStyle.RowsStyle.BackColor = WarnaPermukaan
                gDgv.ThemeStyle.RowsStyle.ForeColor = WarnaTeks
                gDgv.ThemeStyle.RowsStyle.Font = FontBiasa
                gDgv.ThemeStyle.RowsStyle.Height = 40
                gDgv.ThemeStyle.RowsStyle.SelectionBackColor = WarnaUtamaLembut
                gDgv.ThemeStyle.RowsStyle.SelectionForeColor = WarnaTeks
                gDgv.ThemeStyle.AlternatingRowsStyle.BackColor = WarnaLatar
                gDgv.ThemeStyle.AlternatingRowsStyle.ForeColor = WarnaTeks
                gDgv.ThemeStyle.AlternatingRowsStyle.Font = FontBiasa
                gDgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = WarnaUtamaLembut
                gDgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = WarnaTeks
            End If
        End Sub

        Public Function BuatRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()
            If rect.Width <= 0 OrElse rect.Height <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If
            Dim r As Integer = Math.Max(1, Math.Min(radius, Math.Min(rect.Width, rect.Height) \ 2))
            Dim d As Integer = r * 2
            path.AddArc(rect.X, rect.Y, d, d, 180, 90)
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
            path.CloseFigure()
            Return path
        End Function

        Public Function BuatTopRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()
            If rect.Width <= 0 OrElse rect.Height <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If
            Dim r As Integer = Math.Max(1, Math.Min(radius, Math.Min(rect.Width \ 2, rect.Height)))
            Dim d As Integer = r * 2
            path.AddArc(rect.X, rect.Y, d, d, 180, 90)
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
            path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom)
            path.CloseFigure()
            Return path
        End Function

    End Module
End Namespace
