Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kasir

    Public Class FrmLog
        Private ReadOnly _bsLog As New BindingSource()

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not DesignMode Then cp.ExStyle = cp.ExStyle Or &H2000000
                Return cp
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ApplyRuntimePolish()
            MuatLog()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar

            dtpDari.Value = DateTime.Today.AddDays(-7)
            dtpSampai.Value = DateTime.Today

            txtCari.IconLeft = BistroIcons.GetIcon(IconChar.MagnifyingGlass, ModTema.WarnaTeksRedup, 15)
            ModTema.GayaGunaTextBox(txtCari, "Cari aksi atau keterangan...")
            AddHandler txtCari.TextChanged, Sub() TerapkanFilter()

            ModTema.GayaGunaButtonUtama(btnTampil, 10)
            AddHandler btnTampil.Click, Sub() MuatLog()

            ModTema.GayaGunaCard(card, 14)
            card.ShadowDecoration.Enabled = False
            card.UseTransparentBackground = True

            ModTema.GayaDataGridView(dgvLog)
        End Sub

        Public Sub SegarkanData()
            MuatLog()
        End Sub

        Private Sub MuatLog()
            Dim dt = ModLog.AmbilLog(dtpDari.Value.Date, dtpSampai.Value.Date)
            _bsLog.DataSource = dt
            dgvLog.DataSource = _bsLog
            TerapkanFilter()
        End Sub

        Private Sub TerapkanFilter()
            Dim kw As String = txtCari.Text.Trim().Replace("'", "''")
            _bsLog.Filter = If(String.IsNullOrEmpty(kw), "", $"aksi LIKE '%{kw}%' OR keterangan LIKE '%{kw}%' OR pengguna LIKE '%{kw}%'")
        End Sub

    End Class
End Namespace
