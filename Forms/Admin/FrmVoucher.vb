Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports Npgsql
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Admin

    Public Class FrmVoucher
        Private ReadOnly _bsVoucher As New BindingSource()
        Private ReadOnly _kodeSet As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Private _modeEdit As Boolean = False

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
            MuatData()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)
            ModTema.GayaGunaCard(cardGrid, 14)
            ModTema.GayaGunaCard(cardEd, 14)

            pnlRight.AutoScroll = True
            cardEd.Dock = DockStyle.Top
            cardEd.Height = 470

            ModTema.GayaDataGridView(dgvVoucher)
            colMinBelanja.DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
            AddHandler dgvVoucher.SelectionChanged, AddressOf OnSelectionChanged

            ModTema.GayaGunaTextBox(txtKode)
            ModTema.GayaGunaComboBox(cboJenis)
            cboJenis.Items.Clear()
            cboJenis.Items.AddRange({JenisVoucher.Persen, JenisVoucher.Nominal})
            cboJenis.SelectedIndex = 0

            ModTema.GayaGunaTextBox(txtNilai)
            AddHandler txtNilai.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            ModTema.GayaGunaTextBox(txtMinBelanja)
            AddHandler txtMinBelanja.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)

            ModTema.GayaGunaButtonSekunder(btnBaru, 10)
            AddHandler btnBaru.Click, Sub() ResetForm()

            ModTema.GayaGunaButtonUtama(btnSimpan, 10)
            AddHandler btnSimpan.Click, AddressOf OnSimpanClick

            ModTema.GayaGunaButtonBahaya(btnHapus, 10)
            AddHandler btnHapus.Click, AddressOf OnHapusClick
        End Sub

        Private Sub ResetForm()
            _modeEdit = False
            txtKode.Enabled = True
            txtKode.Text = ""
            txtNilai.Text = ""
            txtMinBelanja.Text = "0"
            dtpMulai.Value = DateTime.Today
            dtpAkhir.Value = DateTime.Today.AddDays(30)
            chkAktif.Checked = True
            errVoucher.Clear()
        End Sub

        Public Sub SegarkanData()
            MuatData()
        End Sub

        Private Sub MuatData()
            _kodeSet.Clear()
            Dim dt As New DataTable()
            dt.Columns.Add("kode", GetType(String))
            dt.Columns.Add("jenis", GetType(String))
            dt.Columns.Add("nilai", GetType(Decimal))
            dt.Columns.Add("min_belanja", GetType(Decimal))
            dt.Columns.Add("tgl_mulai", GetType(DateTime))
            dt.Columns.Add("tgl_akhir", GetType(DateTime))
            dt.Columns.Add("aktif", GetType(Boolean))

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "SELECT kode, jenis, nilai, min_belanja, tgl_mulai, tgl_akhir, aktif " &
                            "FROM public.voucher ORDER BY tgl_akhir DESC, kode", conn)
                            Using rd = cmd.ExecuteReader()
                                Do While rd.Read()
                                    Dim k As String = rd.GetString(0)
                                    _kodeSet.Add(k)
                                    dt.Rows.Add(k, rd.GetString(1), rd.GetDecimal(2), rd.GetDecimal(3),
                                                rd.GetDateTime(4), rd.GetDateTime(5), rd.GetBoolean(6))
                                Loop
                            End Using
                        End Using
                    End Using
                    _bsVoucher.DataSource = dt
                    dgvVoucher.DataSource = _bsVoucher
                    Return
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[FrmVoucher] MuatData live gagal: " & ex.Message)
                End Try
            End If

            ModDummyStore.PastikanInit()
            For Each v In ModDummyStore.VoucherList
                _kodeSet.Add(v.Kode)
                dt.Rows.Add(v.Kode, v.Jenis, v.Nilai, v.MinBelanja, v.TglMulai, v.TglAkhir, v.Aktif)
            Next
            _bsVoucher.DataSource = dt
            dgvVoucher.DataSource = _bsVoucher
        End Sub

        Private Sub OnSelectionChanged(sender As Object, e As EventArgs)
            If dgvVoucher.CurrentRow Is Nothing Then Return
            Dim drv = TryCast(dgvVoucher.CurrentRow.DataBoundItem, DataRowView)
            If drv Is Nothing Then Return
            _modeEdit = True
            txtKode.Enabled = False
            txtKode.Text = CStr(drv("kode"))
            cboJenis.SelectedItem = CStr(drv("jenis"))
            txtNilai.Text = CInt(CDec(drv("nilai"))).ToString()
            txtMinBelanja.Text = CInt(CDec(drv("min_belanja"))).ToString()
            dtpMulai.Value = CDate(drv("tgl_mulai"))
            dtpAkhir.Value = CDate(drv("tgl_akhir"))
            chkAktif.Checked = CBool(drv("aktif"))
            errVoucher.Clear()
        End Sub

        Private Sub OnSimpanClick(sender As Object, e As EventArgs)
            If Not ModValidasi.WajibIsi(txtKode, errVoucher, "Kode voucher wajib diisi.") Then Return
            Dim kode As String = txtKode.Text.Trim().ToUpperInvariant()
            If Not _modeEdit AndAlso _kodeSet.Contains(kode) Then
                errVoucher.SetError(txtKode, $"Kode '{kode}' sudah terdaftar.") : Return
            End If

            Dim nilai, minB As Decimal
            If Not ModValidasi.BacaAngka(txtNilai, errVoucher, nilai) OrElse nilai <= 0D Then
                errVoucher.SetError(txtNilai, "Nilai harus lebih dari 0.") : Return
            End If
            Dim jenis As String = CStr(cboJenis.SelectedItem)
            If jenis = JenisVoucher.Persen AndAlso nilai > 100D Then
                errVoucher.SetError(txtNilai, "Persentase maksimal 100.") : Return
            End If
            If Not ModValidasi.BacaAngka(txtMinBelanja, errVoucher, minB) OrElse minB < 0D Then
                errVoucher.SetError(txtMinBelanja, "Min. belanja tidak boleh negatif.") : Return
            End If
            If dtpAkhir.Value.Date < dtpMulai.Value.Date Then
                errVoucher.SetError(dtpAkhir, "Tanggal akhir harus >= tanggal mulai.") : Return
            End If
            errVoucher.Clear()

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Dim sql As String
                        If Not _modeEdit Then
                            sql = "INSERT INTO public.voucher (kode, jenis, nilai, min_belanja, tgl_mulai, tgl_akhir, aktif) " &
                                  "VALUES (@kode, @jenis, @nilai, @min, @tm, @ta, @aktif)"
                        Else
                            sql = "UPDATE public.voucher SET jenis=@jenis, nilai=@nilai, min_belanja=@min, " &
                                  "tgl_mulai=@tm, tgl_akhir=@ta, aktif=@aktif WHERE kode=@kode"
                        End If
                        Using cmd As New NpgsqlCommand(sql, conn)
                            cmd.Parameters.AddWithValue("kode", kode)
                            cmd.Parameters.AddWithValue("jenis", jenis)
                            cmd.Parameters.AddWithValue("nilai", nilai)
                            cmd.Parameters.AddWithValue("min", minB)
                            cmd.Parameters.AddWithValue("tm", dtpMulai.Value.Date)
                            cmd.Parameters.AddWithValue("ta", dtpAkhir.Value.Date)
                            cmd.Parameters.AddWithValue("aktif", chkAktif.Checked)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    ModCache.HapusAwalan("voucher")
                    ModLog.Catat(KodeAksi.VoucherUbah, $"Simpan voucher {kode}")
                    MuatData()
                    ResetForm()
                    MessageBox.Show("Voucher berhasil disimpan ke Supabase.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                Catch ex As PostgresException When ex.SqlState = "23505"
                    errVoucher.SetError(txtKode, $"Kode '{kode}' sudah terdaftar.")
                    Return
                Catch ex As Exception
                    MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            If Not _modeEdit Then
                ModDummyStore.VoucherList.Add(New Voucher With {
                    .Kode = kode, .Jenis = jenis, .Nilai = nilai, .MinBelanja = minB,
                    .TglMulai = dtpMulai.Value.Date, .TglAkhir = dtpAkhir.Value.Date, .Aktif = chkAktif.Checked
                })
            Else
                Dim ex = ModDummyStore.VoucherList.FirstOrDefault(Function(v) String.Equals(v.Kode, kode, StringComparison.OrdinalIgnoreCase))
                If ex IsNot Nothing Then
                    ex.Jenis = jenis : ex.Nilai = nilai : ex.MinBelanja = minB
                    ex.TglMulai = dtpMulai.Value.Date : ex.TglAkhir = dtpAkhir.Value.Date : ex.Aktif = chkAktif.Checked
                End If
            End If
            ModCache.HapusAwalan("voucher")
            ModLog.Catat(KodeAksi.VoucherUbah, $"Simpan voucher {kode}")
            MuatData()
            MessageBox.Show("Voucher berhasil disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OnHapusClick(sender As Object, e As EventArgs)
            Dim kode As String = txtKode.Text.Trim()
            If String.IsNullOrEmpty(kode) Then Return
            If MessageBox.Show($"Hapus voucher '{kode}'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand("DELETE FROM public.voucher WHERE kode = @kode", conn)
                            cmd.Parameters.AddWithValue("kode", kode)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    ModCache.HapusAwalan("voucher")
                    ModLog.Catat(KodeAksi.VoucherUbah, $"Hapus voucher {kode}")
                    ResetForm()
                    MuatData()
                    Return
                Catch ex As PostgresException When ex.SqlState = "23503"
                    MessageBox.Show("Voucher sudah pernah digunakan dalam pesanan dan tidak dapat dihapus. Nonaktifkan centang Aktif sebagai gantinya.", "Tidak Bisa Dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                Catch ex As Exception
                    MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            ModDummyStore.VoucherList.RemoveAll(Function(v) String.Equals(v.Kode, kode, StringComparison.OrdinalIgnoreCase))
            ModCache.HapusAwalan("voucher")
            ModLog.Catat(KodeAksi.VoucherUbah, $"Hapus voucher {kode}")
            ResetForm()
            MuatData()
        End Sub

    End Class
End Namespace
