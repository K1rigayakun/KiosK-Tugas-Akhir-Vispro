Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Kiosk

    Public Class FrmRating
        Private ReadOnly _idPesanan As Integer

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not DesignMode Then cp.ExStyle = cp.ExStyle Or &H2000000
                Return cp
            End Get
        End Property

        Public Sub New()
            Me.New(1)
        End Sub

        Public Sub New(idPesanan As Integer)
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModAnimasi.SiapkanTransisiMasuk(Me, 16)
            _idPesanan = idPesanan
            ApplyRuntimePolish()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar

            ModTema.GayaGunaCard(card, 14)
            card.ShadowDecoration.Enabled = False
            card.UseTransparentBackground = True

            picBadge.FillColor = ModTema.WarnaAksenLembut
            picBadge.Image = BistroIcons.GetBadgeIcon(IconChar.Star, ModTema.WarnaUtama, ModTema.WarnaAksenLembut, 64, 28)

            lblJudul.Font = ModTema.FontJudul
            lblJudul.Text = ModBahasa.T("rating_judul")
            lblSub.Font = ModTema.FontKecil
            lblSkor.Font = ModTema.FontTebal
            lblSkor.ForeColor = ModTema.WarnaUtama

            ratingStar.FillColor = ModTema.WarnaAksen
            ratingStar.BorderColor = ModTema.WarnaGaris
            ratingStar.RatingColor = ModTema.WarnaAksen
            AddHandler ratingStar.ValueChanged, AddressOf OnRatingChanged

            ModTema.GayaGunaTextBox(txtKomentar, "Tulis komentar opsional (maks. 300 karakter)...")

            btnLewati.Text = ModBahasa.T("lewati")
            ModTema.GayaGunaButtonSekunder(btnLewati, 10)
            AddHandler btnLewati.Click, Sub()
                                            DialogResult = DialogResult.Cancel
                                            Close()
                                        End Sub

            btnKirim.Image = BistroIcons.GetIcon(IconChar.Check, Color.White, 18)
            btnKirim.ImageOffset = New Point(-8, 0)
            ModTema.GayaGunaButtonUtama(btnKirim, 10)
            AddHandler btnKirim.Click, AddressOf OnKirimClick
            AddHandler Shown, Sub() ModAnimasi.SlideUpFadeInModal(Me, 18, 220UL)
        End Sub

        Private Sub OnRatingChanged(sender As Object, e As EventArgs)
            Dim val As Integer = Math.Max(1, Math.Min(5, CInt(Math.Round(ratingStar.Value))))
            Dim label As String
            Select Case val
                Case 1 : label = "1 / 5 - Perlu Perbaikan"
                Case 2 : label = "2 / 5 - Kurang Memuaskan"
                Case 3 : label = "3 / 5 - Cukup Baik"
                Case 4 : label = "4 / 5 - Memuaskan"
                Case Else : label = "5 / 5 - Luar Biasa!"
            End Select
            lblSkor.Text = label
        End Sub

        Private Sub OnKirimClick(sender As Object, e As EventArgs)
            Try
                Dim bintang As Integer = Math.Max(1, Math.Min(5, CInt(Math.Round(ratingStar.Value))))
                ModPesanan.SimpanRating(_idPesanan, bintang, txtKomentar.Text.Trim())
                MessageBox.Show("Terima kasih atas penilaian Anda!", "Bistro Kiosk", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = DialogResult.OK
                Close()
            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan rating: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

    End Class
End Namespace
