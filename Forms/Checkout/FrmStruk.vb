Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Forms.Kiosk
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Checkout

    Public Class FrmStruk
        Private ReadOnly _idPesanan As Integer
        Private ReadOnly _cetakUlang As Boolean
        Private _pesanan As PesananData

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not DesignMode Then cp.ExStyle = cp.ExStyle Or &H2000000
                Return cp
            End Get
        End Property

        Public Sub New()
            Me.New(1, True)
        End Sub

        Public Sub New(idPesanan As Integer, Optional cetakUlang As Boolean = False)
            InitializeComponent()
            If DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModAnimasi.SiapkanTransisiMasuk(Me, 16)
            _idPesanan = idPesanan
            _cetakUlang = cetakUlang
            ApplyRuntimePolish()
            MuatStruk()
            AddHandler FormClosing, Sub()
                                        If Not _cetakUlang AndAlso ModKeranjang.JumlahItem() > 0 Then
                                            ModKeranjang.Kosongkan()
                                        End If
                                    End Sub
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            BackColor = ModTema.WarnaLatar

            pnlTop.FillColor = ModTema.WarnaCharcoal
            lblAntrian.Font = New Font(ModTema.FontJudulBesar.FontFamily, 32.0F, FontStyle.Bold)

            ModTema.GayaGunaCard(cardStruk, 14)
            cardStruk.ShadowDecoration.Enabled = False
            cardStruk.UseTransparentBackground = True
            txtStruk.Font = ModTema.FontStruk

            btnSimpan.Image = BistroIcons.GetIcon(IconChar.FloppyDisk, ModTema.WarnaTeks, 16)
            btnSimpan.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSekunder(btnSimpan, 10)
            AddHandler btnSimpan.Click, AddressOf OnSimpanTxtClick

            btnCetak.Image = BistroIcons.GetIcon(IconChar.Print, ModTema.WarnaTeks, 16)
            btnCetak.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSekunder(btnCetak, 10)
            AddHandler btnCetak.Click, AddressOf OnCetakClick

            btnSelesai.Image = BistroIcons.GetIcon(IconChar.Check, Color.White, 16)
            btnSelesai.ImageOffset = New Point(-6, 0)
            ModTema.GayaGunaButtonUtama(btnSelesai, 10)
            AddHandler btnSelesai.Click, AddressOf OnSelesaiClick
            AddHandler Shown, Sub() ModAnimasi.SlideUpFadeInModal(Me, 18, 220UL)
        End Sub

        Private Sub MuatStruk()
            _pesanan = ModPesanan.AmbilPesananById(_idPesanan)
            If _pesanan Is Nothing Then
                txtStruk.Text = "Data pesanan tidak ditemukan."
                Return
            End If

            lblAntrian.Text = ModFormat.NoAntrianStr(_pesanan.NoAntrian)
            If _pesanan.StatusPesanan = StatusPesanan.MenungguPembayaran Then
                lblStatusArahan.Text = "Silakan bayar tunai di kasir dengan menunjukkan nomor ini."
            Else
                lblStatusArahan.Text = $"Pembayaran {_pesanan.MetodeBayar} Lunas — Pesanan sedang disiapkan dapur."
            End If

            picQr.Image = ModPesanan.GenerateQrBitmap($"PESANAN-{_pesanan.IdPesanan}-{_pesanan.NoAntrian}", 5)

            Dim dtDetail = ModAntrian.AmbilDetail(_idPesanan)
            Dim sb As New StringBuilder()
            Dim w As Integer = 38
            Dim namaToko As String = ModPengaturan.Ambil("nama_toko", "BISTRO KIOSK NUSANTARA").ToUpperInvariant()
            Dim alamatToko As String = ModPengaturan.Ambil("alamat_toko", "")
            Dim telpToko As String = ModPengaturan.Ambil("telepon_toko", "")
            Dim footerStruk As String = ModPengaturan.Ambil("footer_struk", "Terima kasih atas kunjungan Anda!")

            sb.AppendLine(CenterText(namaToko, w))
            If Not String.IsNullOrWhiteSpace(alamatToko) Then
                sb.AppendLine(CenterText(alamatToko, w))
            Else
                sb.AppendLine(CenterText("Warm Modern Bistro Self-Service", w))
            End If
            If Not String.IsNullOrWhiteSpace(telpToko) Then
                sb.AppendLine(CenterText("Telp: " & telpToko, w))
            End If
            sb.AppendLine(New String("="c, w))
            sb.AppendLine(KiriKanan("No. Antrian", ModFormat.NoAntrianStr(_pesanan.NoAntrian), w))
            sb.AppendLine(KiriKanan("Tanggal", _pesanan.Tanggal.ToString("dd/MM/yyyy HH:mm"), w))
            sb.AppendLine(KiriKanan("Tipe Makan", _pesanan.TipeMakan, w))
            sb.AppendLine(KiriKanan("Metode", $"{_pesanan.MetodeBayar} ({_pesanan.StatusBayar})", w))
            sb.AppendLine(New String("-"c, w))

            For Each row As DataRow In dtDetail.Rows
                Dim nama As String = CStr(row("nama_produk"))
                Dim qty As Integer = CInt(row("qty"))
                Dim subItem As Decimal = CDec(row("subtotal"))
                sb.AppendLine($"{qty}x {nama}")
                Dim opsi As String = If(IsDBNull(row("opsi_dipilih")), "", CStr(row("opsi_dipilih")))
                If Not String.IsNullOrWhiteSpace(opsi) Then
                    sb.AppendLine($"   [{opsi}]")
                End If
                sb.AppendLine(KiriKanan($"   @ {ModFormat.Rupiah(CDec(row("harga_satuan")))}", ModFormat.Rupiah(subItem), w))
            Next

            sb.AppendLine(New String("-"c, w))
            sb.AppendLine(KiriKanan("Subtotal", ModFormat.Rupiah(_pesanan.Subtotal), w))
            If _pesanan.Diskon > 0D Then
                sb.AppendLine(KiriKanan("Total Diskon", "-" & ModFormat.Rupiah(_pesanan.Diskon), w))
            End If
            sb.AppendLine(KiriKanan($"PPN {ModPengaturan.Ambil("pajak_persen", "11")}%", ModFormat.Rupiah(_pesanan.Pajak), w))
            sb.AppendLine(New String("="c, w))
            sb.AppendLine(KiriKanan("TOTAL", ModFormat.Rupiah(_pesanan.Total), w))
            If _pesanan.UangBayar.HasValue Then
                sb.AppendLine(KiriKanan("Uang Bayar", ModFormat.Rupiah(_pesanan.UangBayar.Value), w))
                sb.AppendLine(KiriKanan("Kembalian", ModFormat.Rupiah(If(_pesanan.Kembalian, 0D)), w))
            End If
            sb.AppendLine(New String("="c, w))
            sb.AppendLine(CenterText(footerStruk, w))
            txtStruk.Text = sb.ToString()
            txtStruk.SelectionStart = 0
            txtStruk.SelectionLength = 0
            btnSelesai.Select()
        End Sub

        Private Shared Function CenterText(s As String, w As Integer) As String
            If s.Length >= w Then Return s.Substring(0, w)
            Dim pad As Integer = (w - s.Length) \ 2
            Return New String(" "c, pad) & s
        End Function

        Private Shared Function KiriKanan(kiri As String, kanan As String, w As Integer) As String
            Dim spasi As Integer = Math.Max(1, w - kiri.Length - kanan.Length)
            Return kiri & New String(" "c, spasi) & kanan
        End Function

        Private Sub OnSimpanTxtClick(sender As Object, e As EventArgs)
            Using sfd As New SaveFileDialog()
                sfd.Filter = "Text File (*.txt)|*.txt"
                sfd.FileName = $"Struk-{If(_pesanan IsNot Nothing, _pesanan.NoAntrian.ToString("000"), "001")}.txt"
                If sfd.ShowDialog(Me) <> DialogResult.OK Then Return

                Dim sw As StreamWriter = Nothing
                Try
                    sw = New StreamWriter(sfd.FileName, False, Encoding.UTF8)
                    sw.Write(txtStruk.Text)
                    MessageBox.Show("Struk berhasil disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As IOException
                    MessageBox.Show("Gagal menulis file struk: " & ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If sw IsNot Nothing Then sw.Dispose()
                End Try
            End Using
        End Sub

        Private Sub OnCetakClick(sender As Object, e As EventArgs)
            Using doc As New PrintDocument()
                AddHandler doc.PrintPage, Sub(s, ev)
                                              Dim y As Single = 24
                                              ev.Graphics.DrawString(txtStruk.Text, ModTema.FontStruk, Brushes.Black, 24, y)
                                              If picQr.Image IsNot Nothing Then
                                                  Dim sz = ev.Graphics.MeasureString(txtStruk.Text, ModTema.FontStruk)
                                                  ev.Graphics.DrawImage(picQr.Image, 70, y + sz.Height + 12, 120, 120)
                                              End If
                                          End Sub
                Using prev As New PrintPreviewDialog()
                    prev.Document = doc
                    prev.Width = 640
                    prev.Height = 760
                    prev.ShowDialog(Me)
                End Using
            End Using
        End Sub

        Private Sub OnSelesaiClick(sender As Object, e As EventArgs)
            If Not _cetakUlang Then
                Using frm As New FrmRating(_idPesanan)
                    frm.ShowDialog(Me)
                End Using
                ModKeranjang.Kosongkan()
            End If
            DialogResult = DialogResult.OK
            Close()
        End Sub

    End Class
End Namespace
