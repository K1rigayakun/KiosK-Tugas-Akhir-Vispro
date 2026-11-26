Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Umum

    Public Class FrmPengaturan
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
            MuatNilai()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            ModTema.GayaGunaCard(card, 14)
            pnlWrap.AutoScroll = True
            card.Dock = DockStyle.Top
            card.Height = 540

            For Each tb In {txtNamaToko, txtAlamat, txtTelepon, txtFooter, txtPajak, txtService, txtIdle, txtAmbangStok, txtAmbangTunggu, txtPoinPerRupiah, txtNilaiPoin}
                ModTema.GayaGunaTextBox(tb)
            Next
            ModTema.GayaGunaTextBox(txtVersi)
            txtVersi.FillColor = ModTema.WarnaSekunderLatar

            For Each tNum In {txtPajak, txtService, txtIdle, txtAmbangStok, txtAmbangTunggu, txtPoinPerRupiah, txtNilaiPoin}
                AddHandler tNum.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            Next

            ModTema.GayaGunaComboBox(cboBahasa)
            cboBahasa.Items.Clear()
            cboBahasa.Items.AddRange({"ID", "EN"})

            btnMuatUlang.Image = BistroIcons.GetIcon(IconChar.ArrowsRotate, ModTema.WarnaTeks, 15)
            btnMuatUlang.ImageOffset = New Point(-4, 0)
            ModTema.GayaGunaButtonSekunder(btnMuatUlang, 12)
            AddHandler btnMuatUlang.Click, AddressOf OnMuatUlangClick

            btnSimpan.Image = BistroIcons.GetIcon(IconChar.Check, Color.White, 16)
            btnSimpan.ImageOffset = New Point(-6, 0)
            ModTema.GayaGunaButtonUtama(btnSimpan, 12)
            AddHandler btnSimpan.Click, AddressOf OnSimpanClick
        End Sub

        Private Sub MuatNilai()
            txtNamaToko.Text = ModPengaturan.Ambil("nama_toko", "Bistro Kiosk Nusantara")
            txtAlamat.Text = ModPengaturan.Ambil("alamat_toko", "Jl. Kuliner Nusantara No. 18, Bandung")
            txtTelepon.Text = ModPengaturan.Ambil("telepon_toko", "022-8881234")
            txtFooter.Text = ModPengaturan.Ambil("footer_struk", "Terima kasih telah berkunjung!")
            txtVersi.Text = ModPengaturan.Ambil("versi_aplikasi", "1.0.0")
            txtPajak.Text = ModPengaturan.Ambil("pajak_persen", "11")
            txtService.Text = ModPengaturan.Ambil("service_persen", "0")
            txtIdle.Text = ModPengaturan.Ambil("idle_detik", "60")
            txtAmbangStok.Text = ModPengaturan.Ambil("ambang_stok", "5")
            txtAmbangTunggu.Text = ModPengaturan.Ambil("ambang_tunggu_menit", "10")
            txtPoinPerRupiah.Text = ModPengaturan.Ambil("poin_per_rupiah", "10000")
            txtNilaiPoin.Text = ModPengaturan.Ambil("nilai_poin", "100")
            cboBahasa.SelectedItem = ModPengaturan.Ambil("bahasa_default", "ID")
        End Sub

        Private Sub OnMuatUlangClick(sender As Object, e As EventArgs)
            Dim konfirmasi = MessageBox.Show(
                "Muat ulang pengaturan dari database? Perubahan yang belum disimpan akan hilang.",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )
            If konfirmasi = DialogResult.Yes Then
                ModCache.HapusAwalan("cfg:")
                MuatNilai()
            End If
        End Sub

        Private Sub OnSimpanClick(sender As Object, e As EventArgs)
            If Not ModValidasi.WajibIsi(txtNamaToko, err, "Nama toko wajib diisi.") Then Return

            Dim pajak, service, idle, stok, tunggu, poinRp, nilaiPoin As Decimal
            If Not ModValidasi.BacaAngka(txtPajak, err, pajak) OrElse pajak < 0D OrElse pajak > 100D Then
                err.SetError(txtPajak, "Pajak harus 0 - 100%.") : Return
            End If
            If Not ModValidasi.BacaAngka(txtService, err, service) OrElse service < 0D OrElse service > 100D Then
                err.SetError(txtService, "Service charge harus 0 - 100%.") : Return
            End If
            If Not ModValidasi.BacaAngka(txtIdle, err, idle) OrElse idle < 15D OrElse idle > 600D Then
                err.SetError(txtIdle, "Idle harus 15 - 600 detik.") : Return
            End If
            If Not ModValidasi.BacaAngka(txtAmbangStok, err, stok) OrElse stok < 1D OrElse stok > 100D Then
                err.SetError(txtAmbangStok, "Ambang stok harus 1 - 100.") : Return
            End If
            If Not ModValidasi.BacaAngka(txtAmbangTunggu, err, tunggu) OrElse tunggu < 1D OrElse tunggu > 60D Then
                err.SetError(txtAmbangTunggu, "Ambang tunggu harus 1 - 60 menit.") : Return
            End If
            If Not ModValidasi.BacaAngka(txtPoinPerRupiah, err, poinRp) OrElse poinRp < 1000D Then
                err.SetError(txtPoinPerRupiah, "Minimal Rp1.000 per poin.") : Return
            End If
            If Not ModValidasi.BacaAngka(txtNilaiPoin, err, nilaiPoin) OrElse nilaiPoin < 1D Then
                err.SetError(txtNilaiPoin, "Minimal Rp1.") : Return
            End If
            err.Clear()

            Try
                ModPengaturan.Simpan("nama_toko", txtNamaToko.Text.Trim())
                ModPengaturan.Simpan("alamat_toko", txtAlamat.Text.Trim())
                ModPengaturan.Simpan("telepon_toko", txtTelepon.Text.Trim())
                ModPengaturan.Simpan("footer_struk", txtFooter.Text.Trim())
                ModPengaturan.Simpan("versi_aplikasi", txtVersi.Text.Trim())
                ModPengaturan.Simpan("pajak_persen", CInt(pajak).ToString(CultureInfo.InvariantCulture))
                ModPengaturan.Simpan("service_persen", CInt(service).ToString(CultureInfo.InvariantCulture))
                ModPengaturan.Simpan("idle_detik", CInt(idle).ToString())
                ModPengaturan.Simpan("ambang_stok", CInt(stok).ToString())
                ModPengaturan.Simpan("ambang_tunggu_menit", CInt(tunggu).ToString())
                ModPengaturan.Simpan("poin_per_rupiah", CInt(poinRp).ToString())
                ModPengaturan.Simpan("nilai_poin", CInt(nilaiPoin).ToString())
                ModPengaturan.Simpan("bahasa_default", CStr(cboBahasa.SelectedItem))

                ModLog.Catat(KodeAksi.PengaturanUbah, $"Pengaturan diperbarui oleh {ModSesi.NamaPengguna}")
                MessageBox.Show("Pengaturan berhasil disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan pengaturan: " & ex.Message, "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace
