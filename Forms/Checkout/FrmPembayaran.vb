Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Guna.UI2.WinForms
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Checkout

    Public Class FrmPembayaran
        Private ReadOnly _rincian As RincianHarga
        Private ReadOnly _errBayar As New ErrorProvider()
        Private _metodeAktif As String = MetodeBayar.Qris

        Private ReadOnly _tmrQris As New Timer()
        Private _sisaQrisDetik As Integer = 120

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not DesignMode Then cp.ExStyle = cp.ExStyle Or &H2000000
                Return cp
            End Get
        End Property

        Public Sub New()
            Me.New(ModPromo.HitungRincian(Math.Max(50000D, ModKeranjang.Subtotal()), "", 0))
        End Sub

        Public Sub New(rincian As RincianHarga)
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModAnimasi.SiapkanTransisiMasuk(Me, 0)
            ModNavigasi.DaftarkanHalamanPenuh(Me)
            _rincian = rincian
            _errBayar.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ApplyRuntimePolish()
            PilihMetode(MetodeBayar.Qris)
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar
            ModTema.AktifkanDoubleBuffer(pnlKananWrap)
            ModTema.AktifkanDoubleBuffer(cardDetail)

            pnlHead.FillColor = ModTema.WarnaCharcoal
            lblHead.Font = New Font(ModTema.FontJudul.FontFamily, 16.0F, FontStyle.Bold)

            cardTotal.FillColor = ModTema.WarnaCharcoal
            cardTotal.BorderRadius = 16
            cardTotal.BorderThickness = 0
            cardTotal.BorderColor = ModTema.WarnaUtama
            cardTotal.BackColor = Color.Transparent
            cardTotal.UseTransparentBackground = True
            ModTema.PasangSoftShadow(cardTotal, 0, 4, Color.FromArgb(52, 255, 107, 53))
            lblTotVal.Font = New Font(ModTema.FontJudulBesar.FontFamily, 22.0F, FontStyle.Bold)
            lblTotVal.ForeColor = ModTema.WarnaUtama
            lblTotVal.Text = ModFormat.Rupiah(_rincian.Total)

            AturTombolMetode(btnQris, IconChar.Qrcode, MetodeBayar.Qris)
            AturTombolMetode(btnTunai, IconChar.MoneyBillWave, MetodeBayar.Tunai)
            AturTombolMetode(btnKartu, IconChar.CreditCard, MetodeBayar.Kartu)
            AturTombolMetode(btnEWallet, IconChar.Wallet, MetodeBayar.EWallet)

            ModTema.GayaGunaButtonSekunder(btnKembali, 12)
            AddHandler btnKembali.Click, Sub()
                                             _tmrQris.Stop()
                                             ModAnimasi.StopActive(pgbSimulasi)
                                             DialogResult = DialogResult.Cancel
                                             Close()
                                         End Sub

            ModTema.GayaGunaCard(cardDetail, 16)
            cardDetail.ShadowDecoration.Enabled = False
            cardDetail.UseTransparentBackground = True

            ' QRIS Panel
            lblQrisJudul.Font = ModTema.FontJudul
            lblQrisSub.Font = ModTema.FontBiasa
            picQris.Image = ModPesanan.GenerateQrBitmap($"QRIS-SIMULASI|{_rincian.Total}|BISTRO-{DateTime.Now:HHmmss}", 7)
            lblCountdownQris.Font = ModTema.FontSubJudul
            lblCountdownQris.ForeColor = ModTema.WarnaUtama
            btnSudahBayar.Image = BistroIcons.GetIcon(IconChar.Check, Color.White, 18)
            btnSudahBayar.ImageOffset = New Point(-8, 0)
            ModTema.GayaGunaButtonSukses(btnSudahBayar, 10)
            AddHandler btnSudahBayar.Click, Sub() SelesaikanPesanan(MetodeBayar.Qris, Nothing)

            _tmrQris.Interval = 1000
            AddHandler _tmrQris.Tick, Sub()
                                          _sisaQrisDetik -= 1
                                          If _sisaQrisDetik <= 0 Then
                                              _tmrQris.Stop()
                                              MessageBox.Show("Waktu QRIS habis. Silakan ulangi pemilihan metode pembayaran.", "QRIS Kedaluwarsa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                              PilihMetode(MetodeBayar.Tunai)
                                              Return
                                          End If
                                          lblCountdownQris.Text = $"Berlaku selama {ModFormat.Durasi(TimeSpan.FromSeconds(_sisaQrisDetik))}"
                                      End Sub

            ' Tunai Panel
            lblTunaiJudul.Font = ModTema.FontJudul
            lblTunaiSub.Font = ModTema.FontBiasa
            ModTema.GayaGunaTextBox(txtUangBayar, "Nominal uang tunai...")
            txtUangBayar.Text = CInt(Math.Ceiling(_rincian.Total)).ToString()
            AddHandler txtUangBayar.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            AddHandler txtUangBayar.TextChanged, Sub() HitungEstimasiKembalian()

            Dim saran = ModPesanan.SaranUangBayar(_rincian.Total)
            Dim nom1 As Decimal = _rincian.Total
            Dim nom2 As Decimal = If(saran.Count > 0 AndAlso saran(0) > _rincian.Total, saran(0), Math.Ceiling(_rincian.Total / 50000D) * 50000D)
            Dim nom3 As Decimal = If(saran.Count > 1 AndAlso saran(1) > nom2, saran(1), nom2 + 50000D)
            Dim nom4 As Decimal = If(saran.Count > 2 AndAlso saran(2) > nom3, saran(2), nom3 + 50000D)

            AturChipNominal(btnNomPas, nom1, "Uang Pas")
            AturChipNominal(btnNom50, nom2)
            AturChipNominal(btnNom100, nom3)
            AturChipNominal(btnNom200, nom4)

            pnlKiri.AutoScroll = True
            pnlQris.AutoScroll = True
            pnlTunai.AutoScroll = True
            pnlNonTunai.AutoScroll = True

            lblKembalian.Font = ModTema.FontSubJudul
            lstPecahan.Font = ModTema.FontStruk
            lstPecahan.BackColor = ModTema.WarnaLatar
            btnBayarTunai.Image = BistroIcons.GetIcon(IconChar.Receipt, Color.White, 18)
            btnBayarTunai.ImageOffset = New Point(-8, 0)
            ModTema.GayaGunaButtonUtama(btnBayarTunai, 10)
            AddHandler btnBayarTunai.Click, AddressOf OnBayarTunaiClick
            HitungEstimasiKembalian()

            ' Non-Tunai Panel
            lblNonTunaiJudul.Font = ModTema.FontJudul
            lblNonTunaiSub.Font = ModTema.FontBiasa
            picTerminal.FillColor = ModTema.WarnaUtamaLembut
            Dim badgeD As Integer = Math.Max(64, Math.Min(picTerminal.Width, picTerminal.Height))
            picTerminal.Image = BistroIcons.GetBadgeIcon(IconChar.CreditCard, ModTema.WarnaUtama, ModTema.WarnaUtamaLembut, badgeD, 42)
            pgbSimulasi.BorderRadius = 6
            pgbSimulasi.FillColor = ModTema.WarnaSekunderLatar
            pgbSimulasi.ProgressColor = ModTema.WarnaUtama
            pgbSimulasi.ProgressColor2 = ModTema.WarnaSukses
            ModTema.GayaGunaButtonUtama(btnMulaiSimulasi, 10)
            AddHandler btnMulaiSimulasi.Click, Sub()
                                                   btnMulaiSimulasi.Enabled = False
                                                   pgbSimulasi.Value = 0
                                                   ModAnimasi.AnimateFloat(pgbSimulasi, pgbSimulasi, 0.0F, 100.0F, 1800UL,
                                                       Sub(v) pgbSimulasi.Value = Math.Min(100, CInt(Math.Round(v))),
                                                       Sub()
                                                           btnMulaiSimulasi.Enabled = True
                                                           SelesaikanPesanan(_metodeAktif, Nothing)
                                                       End Sub,
                                                       easing:=AddressOf WinFormAnimation.AnimationFunctions.CubicEaseInOut)
                                               End Sub

            AddHandler Load, Sub() CenterPaymentContent()
            AddHandler cardDetail.Resize, Sub() CenterPaymentContent()
            AddHandler Shown, Sub() ModAnimasi.FadeInForm(Me, 200UL)
            AddHandler FormClosing, Sub()
                                        _tmrQris.Stop()
                                        ModAnimasi.StopActive(pgbSimulasi)
                                    End Sub
        End Sub

        Private Sub CenterPaymentContent()
            Dim wQris As Integer = Math.Max(460, pnlQris.Width)
            lblQrisJudul.Left = Math.Max(10, (wQris - lblQrisJudul.Width) \ 2)
            lblQrisJudul.TextAlign = ContentAlignment.MiddleCenter
            lblQrisSub.Left = Math.Max(10, (wQris - lblQrisSub.Width) \ 2)
            lblQrisSub.TextAlign = ContentAlignment.MiddleCenter
            picQris.Left = Math.Max(10, (wQris - picQris.Width) \ 2)
            lblCountdownQris.Left = Math.Max(10, (wQris - lblCountdownQris.Width) \ 2)
            btnSudahBayar.Left = Math.Max(10, (wQris - btnSudahBayar.Width) \ 2)

            Dim wTunai As Integer = Math.Max(460, pnlTunai.Width)
            Dim tunaiBlockLeft As Integer = Math.Max(10, (wTunai - 520) \ 2)
            lblTunaiJudul.Left = tunaiBlockLeft
            lblTunaiSub.Left = tunaiBlockLeft
            lblUangCap.Left = tunaiBlockLeft
            txtUangBayar.Left = tunaiBlockLeft
            btnNomPas.Left = tunaiBlockLeft
            btnNom50.Left = tunaiBlockLeft + 118
            btnNom100.Left = tunaiBlockLeft + 236
            btnNom200.Left = tunaiBlockLeft + 354
            lblKembalian.Left = tunaiBlockLeft
            lblPecCap.Left = tunaiBlockLeft
            lstPecahan.Left = tunaiBlockLeft
            btnBayarTunai.Left = tunaiBlockLeft

            Dim wNon As Integer = Math.Max(460, pnlNonTunai.Width)
            lblNonTunaiJudul.Left = Math.Max(10, (wNon - lblNonTunaiJudul.Width) \ 2)
            lblNonTunaiSub.Left = Math.Max(10, (wNon - lblNonTunaiSub.Width) \ 2)
            picTerminal.Left = Math.Max(10, (wNon - picTerminal.Width) \ 2)
            pgbSimulasi.Left = Math.Max(10, (wNon - pgbSimulasi.Width) \ 2)
            btnMulaiSimulasi.Left = Math.Max(10, (wNon - btnMulaiSimulasi.Width) \ 2)
        End Sub

        Private Sub AturTombolMetode(btn As Guna2Button, ic As IconChar, metode As String)
            btn.BorderRadius = 12
            btn.BorderThickness = 1
            btn.Image = BistroIcons.GetIcon(ic, ModTema.WarnaUtama, 24)
            btn.Font = ModTema.FontSubJudul
            btn.Tag = metode
            ModTema.PasangSoftShadow(btn, 0, 2)
            AddHandler btn.Click, Sub() PilihMetode(metode)
        End Sub

        Private Sub AturChipNominal(btn As Guna2Button, nominal As Decimal, Optional labelKustom As String = "")
            btn.Text = If(String.IsNullOrEmpty(labelKustom), ModFormat.Rupiah(nominal), labelKustom)
            ModTema.GayaGunaButtonSekunder(btn, 10)
            AddHandler btn.Click, Sub() txtUangBayar.Text = CInt(Math.Ceiling(nominal)).ToString()
        End Sub

        Private Sub PilihMetode(metode As String)
            _metodeAktif = metode
            _tmrQris.Stop()
            ModAnimasi.StopActive(pgbSimulasi)
            btnMulaiSimulasi.Enabled = True

            For Each b In {btnQris, btnTunai, btnKartu, btnEWallet}
                Dim aktif As Boolean = String.Equals(CStr(b.Tag), metode, StringComparison.OrdinalIgnoreCase)
                b.FillColor = If(aktif, ModTema.WarnaUtamaLembut, ModTema.WarnaPermukaan)
                b.ForeColor = If(aktif, ModTema.WarnaUtama, ModTema.WarnaTeks)
                b.BorderThickness = If(aktif, 2, 1)
                b.BorderColor = If(aktif, ModTema.WarnaUtama, ModTema.WarnaGaris)
            Next

            pnlQris.Visible = (metode = MetodeBayar.Qris)
            pnlTunai.Visible = (metode = MetodeBayar.Tunai)
            pnlNonTunai.Visible = (metode = MetodeBayar.Kartu OrElse metode = MetodeBayar.EWallet)

            If metode = MetodeBayar.Qris Then
                _sisaQrisDetik = 120
                lblCountdownQris.Text = "Berlaku selama 02:00"
                _tmrQris.Start()
            ElseIf metode = MetodeBayar.Kartu Then
                lblNonTunaiJudul.Text = "Pembayaran Kartu Debit / Kredit"
                btnMulaiSimulasi.Text = "Tempel Kartu (Simulasi 2 Detik)"
                pgbSimulasi.Value = 0
            ElseIf metode = MetodeBayar.EWallet Then
                lblNonTunaiJudul.Text = "Pembayaran E-Wallet Instan"
                btnMulaiSimulasi.Text = "Konfirmasi E-Wallet (Simulasi)"
                pgbSimulasi.Value = 0
            End If
        End Sub

        Private Sub HitungEstimasiKembalian()
            lstPecahan.Items.Clear()
            Dim uang As Decimal = 0D
            If Not ModValidasi.BacaAngka(txtUangBayar, _errBayar, uang) Then
                lblKembalian.Text = "Kembalian: -"
                Return
            End If
            If uang < _rincian.Total Then
                _errBayar.SetError(txtUangBayar, $"Uang bayar minimal {ModFormat.Rupiah(_rincian.Total)}.")
                lblKembalian.Text = "Uang belum mencukupi"
                lblKembalian.ForeColor = ModTema.WarnaBahaya
                Return
            End If
            _errBayar.SetError(txtUangBayar, "")
            Dim kembalian As Decimal = ModPesanan.HitungKembalian(_rincian.Total, uang)
            lblKembalian.Text = $"Estimasi Kembalian: {ModFormat.Rupiah(kembalian)}"
            lblKembalian.ForeColor = ModTema.WarnaSukses

            Dim pec = ModPesanan.PecahKembalian(kembalian)
            If pec.Count = 0 Then
                lstPecahan.Items.Add("Uang pas (tanpa kembalian).")
            Else
                For Each kvp In pec
                    lstPecahan.Items.Add($"{kvp.Value}x  {ModFormat.Rupiah(kvp.Key)}")
                Next
            End If
        End Sub

        Private Sub OnBayarTunaiClick(sender As Object, e As EventArgs)
            Dim uang As Decimal = 0D
            If Not String.IsNullOrWhiteSpace(txtUangBayar.Text) Then
                If Not ModValidasi.BacaAngka(txtUangBayar, _errBayar, uang) Then
                    ModAnimasi.ShakeControl(txtUangBayar)
                    Return
                End If
                If uang < _rincian.Total Then
                    _errBayar.SetError(txtUangBayar, $"Uang bayar harus minimal {ModFormat.Rupiah(_rincian.Total)}.")
                    ModAnimasi.ShakeControl(txtUangBayar)
                    Return
                End If
            End If
            SelesaikanPesanan(MetodeBayar.Tunai, If(uang >= _rincian.Total, CType(uang, Decimal?), Nothing))
        End Sub

        Private Sub SelesaikanPesanan(metode As String, uangBayar As Decimal?)
            _tmrQris.Stop()
            ModAnimasi.StopActive(pgbSimulasi)
            Try
                Dim idMem As Integer? = If(ModKeranjang.MemberAktif IsNot Nothing, CType(ModKeranjang.MemberAktif.IdMember, Integer?), Nothing)
                Dim hasil = ModPesanan.SimpanPesanan(metode, _rincian, idMem, uangBayar)
                Using struk As New FrmStruk(hasil.IdPesanan, False)
                    struk.ShowDialog(Me)
                End Using
                DialogResult = DialogResult.OK
                Close()
            Catch ex As Exception
                MessageBox.Show("Gagal memproses pesanan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace
