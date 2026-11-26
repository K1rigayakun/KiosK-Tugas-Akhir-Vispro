Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Controls

    ''' <summary>
    ''' FlowLayoutPanel DoubleBuffered agar scrolling katalog produk bebas flicker.
    ''' </summary>
    <DesignerCategory("Code")>
    Public Class BistroFlowPanel
        Inherits FlowLayoutPanel

        Public Sub New()
            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
            UpdateStyles()
        End Sub
    End Class

    ''' <summary>
    ''' Kartu KPI eksekutif berbasis Guna2Panel + strip aksen + badge ikon vektor.
    ''' </summary>
    <DesignerCategory("Code")>
    Public Class BistroKpiCard
        Inherits Guna2Panel

        Private ReadOnly _accentStrip As New Guna2Panel()
        Private ReadOnly _iconCircle As New Guna2CirclePictureBox()
        Private ReadOnly _lblTitle As New Label()
        Private ReadOnly _lblValue As New Label()
        Private ReadOnly _lblSub As New Label()
        Private _accentColor As Color = ModTema.WarnaUtama

        Public Sub New()
            Size = New Size(220, 114)
            FillColor = ModTema.WarnaPermukaan
            BorderColor = ModTema.WarnaGaris
            BorderThickness = 1
            BorderRadius = 16
            ShadowDecoration.Enabled = False
            Padding = New Padding(14)

            _accentStrip.Size = New Size(5, 76)
            _accentStrip.Location = New Point(12, 19)
            _accentStrip.BorderRadius = 3
            _accentStrip.FillColor = _accentColor

            _iconCircle.Size = New Size(42, 42)
            _iconCircle.Location = New Point(Width - 56, 16)
            _iconCircle.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            _iconCircle.BackColor = Color.Transparent
            _iconCircle.FillColor = ModTema.WarnaUtamaLembut
            _iconCircle.SizeMode = PictureBoxSizeMode.CenterImage

            _lblTitle.AutoSize = False
            _lblTitle.Location = New Point(26, 14)
            _lblTitle.Size = New Size(Width - 88, 22)
            _lblTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            _lblTitle.Font = ModTema.FontKecil
            _lblTitle.ForeColor = ModTema.WarnaTeksRedup
            _lblTitle.BackColor = Color.Transparent
            _lblTitle.Text = "Judul KPI"

            _lblValue.AutoSize = False
            _lblValue.Location = New Point(26, 38)
            _lblValue.Size = New Size(Width - 86, 38)
            _lblValue.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            _lblValue.Font = New Font(ModTema.FontJudul.FontFamily, 17.5F, FontStyle.Bold)
            _lblValue.ForeColor = ModTema.WarnaTeks
            _lblValue.BackColor = Color.Transparent
            _lblValue.Text = "0"

            _lblSub.AutoSize = False
            _lblSub.Location = New Point(26, 80)
            _lblSub.Size = New Size(Width - 40, 22)
            _lblSub.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            _lblSub.Font = ModTema.FontKecil
            _lblSub.ForeColor = ModTema.WarnaTeksRedup
            _lblSub.BackColor = Color.Transparent
            _lblSub.Text = ""

            Controls.Add(_accentStrip)
            Controls.Add(_iconCircle)
            Controls.Add(_lblTitle)
            Controls.Add(_lblValue)
            Controls.Add(_lblSub)
        End Sub

        Public Sub SetData(judul As String, nilai As String, subTeks As String, icon As IconChar, aksen As Color)
            _accentColor = aksen
            _accentStrip.FillColor = aksen
            _iconCircle.FillColor = Color.Transparent
            _iconCircle.Image = BistroIcons.GetBadgeIcon(icon, aksen, Color.FromArgb(26, aksen), 42, 20)
            _lblTitle.Text = judul
            _lblValue.Text = nilai
            _lblSub.Text = subTeks
        End Sub

    End Class

    ''' <summary>
    ''' Renderer MenuStrip Warm Charcoal untuk Form MDI FrmUtama.
    ''' </summary>
    Public Class BistroColorTable
        Inherits ProfessionalColorTable

        Public Overrides ReadOnly Property MenuStripGradientBegin As Color
            Get
                Return ModTema.WarnaCharcoal
            End Get
        End Property
        Public Overrides ReadOnly Property MenuStripGradientEnd As Color
            Get
                Return ModTema.WarnaCharcoal
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelected As Color
            Get
                Return ModTema.WarnaUtama
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
            Get
                Return ModTema.WarnaUtama
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
            Get
                Return ModTema.WarnaUtama
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
            Get
                Return ModTema.WarnaUtamaHover
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
            Get
                Return ModTema.WarnaUtamaHover
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemBorder As Color
            Get
                Return ModTema.WarnaUtama
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripDropDownBackground As Color
            Get
                Return ModTema.WarnaCharcoalLembut
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientBegin As Color
            Get
                Return ModTema.WarnaCharcoalLembut
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientMiddle As Color
            Get
                Return ModTema.WarnaCharcoalLembut
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientEnd As Color
            Get
                Return ModTema.WarnaCharcoalLembut
            End Get
        End Property
        Public Overrides ReadOnly Property MenuBorder As Color
            Get
                Return ModTema.WarnaCharcoalLembut
            End Get
        End Property
        Public Overrides ReadOnly Property SeparatorDark As Color
            Get
                Return ModTema.WarnaTeksRedup
            End Get
        End Property
    End Class

    Public Class BistroMenuRenderer
        Inherits ToolStripProfessionalRenderer

        Public Sub New()
            MyBase.New(New BistroColorTable())
            RoundedEdges = True
        End Sub

        Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
            e.TextColor = Color.White
            e.TextFont = ModTema.FontBiasa
            MyBase.OnRenderItemText(e)
        End Sub
    End Class

End Namespace

