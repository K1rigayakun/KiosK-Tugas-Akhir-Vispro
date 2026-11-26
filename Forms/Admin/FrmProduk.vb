Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Npgsql
Imports VisproPrakProjectAkhir.Controls
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Admin

    Public Class FrmProduk
        Private ReadOnly _bsProduk As New BindingSource()
        Private _selectedProdukId As Integer = 0
        Private _selectedGambarFile As String = "paket1.jpg"
        Private _selectedKatId As Integer = 0

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
            MuatSemua()
        End Sub

        Private Sub ApplyRuntimePolish()
            ModTema.TerapkanForm(Me)

            tabProduk.TabMenuBackColor = ModTema.WarnaLatar
            tabProduk.TabButtonIdleState.FillColor = ModTema.WarnaLatar
            tabProduk.TabButtonIdleState.ForeColor = ModTema.WarnaTeksRedup
            tabProduk.TabButtonIdleState.Font = ModTema.FontTebal
            tabProduk.TabButtonSelectedState.FillColor = ModTema.WarnaSekunderLatar
            tabProduk.TabButtonSelectedState.ForeColor = ModTema.WarnaTeks
            tabProduk.TabButtonSelectedState.InnerColor = ModTema.WarnaUtama
            tabProduk.TabButtonSelectedState.Font = ModTema.FontTebal

            For Each c In {cardGridProd, cardFormProd, cardGridKat, cardEdKat, cardGridOpsi, cardEdOpsi}
                ModTema.GayaGunaCard(c, 14)
            Next

            ' Pastikan panel kanan dapat di-scroll agar form tidak terpotong di resolusi rendah
            pnlRightProd.AutoScroll = True
            cardFormProd.Dock = DockStyle.Top
            cardFormProd.Height = 520
            pnlRightKat.AutoScroll = True
            cardEdKat.Dock = DockStyle.Top
            cardEdKat.Height = 320
            pnlRightOpsi.AutoScroll = True
            cardEdOpsi.Dock = DockStyle.Top
            cardEdOpsi.Height = 360

            ModTema.GayaGunaComboBox(cboFilterKat)
            AddHandler cboFilterKat.SelectedIndexChanged, Sub() TerapkanFilterProduk()

            ModTema.GayaGunaTextBox(txtCari, "Cari nama produk...")
            txtCari.IconLeft = BistroIcons.GetIcon(IconChar.MagnifyingGlass, ModTema.WarnaTeksRedup, 14)
            AddHandler txtCari.TextChanged, Sub() TerapkanFilterProduk()

            ModTema.GayaDataGridView(dgvProduk)
            colProdHarga.DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
            AddHandler dgvProduk.SelectionChanged, AddressOf OnProdukSelected
            AddHandler dgvProduk.CellFormatting, AddressOf OnProdukCellFormatting

            ModTema.GayaGunaButtonSekunder(btnFoto, 10)
            AddHandler btnFoto.Click, AddressOf OnPilihFotoClick

            ModTema.GayaGunaTextBox(txtNama)
            ModTema.GayaGunaComboBox(cboKategori)
            ModTema.GayaGunaTextBox(txtHarga)
            AddHandler txtHarga.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            ModTema.GayaGunaTextBox(txtStok)
            AddHandler txtStok.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            ModTema.GayaGunaButtonSekunder(btnStok10, 8)
            AddHandler btnStok10.Click, Sub() TambahStokCepat(10)
            ModTema.GayaGunaButtonSekunder(btnStok50, 8)
            AddHandler btnStok50.Click, Sub() TambahStokCepat(50)
            ModTema.GayaGunaTextBox(txtDeskripsi)

            ModTema.GayaGunaButtonSekunder(btnBaru, 10)
            AddHandler btnBaru.Click, Sub() ResetFormProduk()
            ModTema.GayaGunaButtonUtama(btnSimpan, 10)
            AddHandler btnSimpan.Click, AddressOf OnSimpanProdukClick
            ModTema.GayaGunaButtonBahaya(btnHapus, 10)
            AddHandler btnHapus.Click, AddressOf OnHapusProdukClick

            ' Tab Kategori
            ModTema.GayaDataGridView(dgvKategori)
            AddHandler dgvKategori.SelectionChanged, Sub()
                                                         If dgvKategori.CurrentRow Is Nothing Then Return
                                                         Dim drv = TryCast(dgvKategori.CurrentRow.DataBoundItem, DataRowView)
                                                         If drv Is Nothing Then Return
                                                         _selectedKatId = CInt(drv("id_kategori"))
                                                         txtNamaKat.Text = CStr(drv("nama"))
                                                         nudUrutan.Value = CDec(drv("urutan"))
                                                     End Sub
            ModTema.GayaGunaTextBox(txtNamaKat)
            ModTema.GayaGunaButtonSekunder(btnBaruKat, 10)
            AddHandler btnBaruKat.Click, Sub()
                                             _selectedKatId = 0
                                             txtNamaKat.Text = ""
                                             nudUrutan.Value = Math.Max(1, dgvKategori.Rows.Count + 1)
                                         End Sub
            ModTema.GayaGunaButtonUtama(btnSimpanKat, 10)
            AddHandler btnSimpanKat.Click, AddressOf OnSimpanKategoriClick
            ModTema.GayaGunaButtonBahaya(btnHapusKat, 10)
            AddHandler btnHapusKat.Click, AddressOf OnHapusKategoriClick

            ' Tab Opsi
            ModTema.GayaGunaComboBox(cboOpsiProduk)
            AddHandler cboOpsiProduk.SelectedIndexChanged, Sub() MuatOpsiProdukTerpilih()
            ModTema.GayaDataGridView(dgvOpsi)
            colOpsiHarga.DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
            ModTema.GayaGunaTextBox(txtNamaOpsi, "Contoh: Ekstra Keju")
            ModTema.GayaGunaComboBox(cboTipeOpsi)
            cboTipeOpsi.Items.Clear()
            cboTipeOpsi.Items.AddRange({TipeOpsi.Ukuran, TipeOpsi.Addon, TipeOpsi.Pedas})
            cboTipeOpsi.SelectedIndex = 1
            ModTema.GayaGunaTextBox(txtTambahanHarga)
            AddHandler txtTambahanHarga.KeyPress, Sub(s, ev) ModValidasi.HanyaAngka(ev)
            ModTema.GayaGunaButtonUtama(btnAddOpsi, 10)
            AddHandler btnAddOpsi.Click, AddressOf OnTambahOpsiClick
            ModTema.GayaGunaButtonBahaya(btnDelOpsi, 10)
            AddHandler btnDelOpsi.Click, AddressOf OnHapusOpsiClick
        End Sub

        Public Sub SegarkanData()
            MuatSemua()
        End Sub

        Private Sub MuatSemua()
            ModCache.Hapus("kategori")
            ModCache.HapusAwalan("produk")

            Dim dtKat = ModProduk.AmbilKategori()
            dgvKategori.DataSource = dtKat

            Dim katObjs As New List(Of Kategori)()
            For Each r As DataRow In dtKat.Rows
                katObjs.Add(New Kategori With {
                    .IdKategori = CInt(r("id_kategori")),
                    .Nama = CStr(r("nama")),
                    .Urutan = CInt(r("urutan"))
                })
            Next

            Dim listFilter As New List(Of Kategori) From {New Kategori With {.IdKategori = 0, .Nama = "Semua Kategori"}}
            listFilter.AddRange(katObjs)
            cboFilterKat.DataSource = listFilter
            cboFilterKat.DisplayMember = "Nama"
            cboFilterKat.ValueMember = "IdKategori"

            cboKategori.DataSource = katObjs.ToList()
            cboKategori.DisplayMember = "Nama"
            cboKategori.ValueMember = "IdKategori"

            Dim dtProd = ModProduk.AmbilProduk(0)
            _bsProduk.DataSource = dtProd
            dgvProduk.DataSource = _bsProduk
            TerapkanFilterProduk()

            Dim prodObjs As New List(Of Produk)()
            For Each r As DataRow In dtProd.Rows
                prodObjs.Add(New Produk With {
                    .IdProduk = CInt(r("id_produk")),
                    .IdKategori = CInt(r("id_kategori")),
                    .Nama = CStr(r("nama"))
                })
            Next
            cboOpsiProduk.DataSource = prodObjs.OrderBy(Function(p) p.Nama).ToList()
            cboOpsiProduk.DisplayMember = "Nama"
            cboOpsiProduk.ValueMember = "IdProduk"
            MuatOpsiProdukTerpilih()
        End Sub

        Private Sub TerapkanFilterProduk()
            Dim bagian As New List(Of String)()
            Dim katSel = TryCast(cboFilterKat.SelectedItem, Kategori)
            If katSel IsNot Nothing AndAlso katSel.IdKategori > 0 Then
                bagian.Add($"id_kategori = {katSel.IdKategori}")
            End If
            Dim kw As String = txtCari.Text.Trim().Replace("'", "''")
            If Not String.IsNullOrEmpty(kw) Then
                bagian.Add($"nama LIKE '%{kw}%'")
            End If
            _bsProduk.Filter = String.Join(" AND ", bagian)
        End Sub

        Private Sub OnProdukCellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
            If e.RowIndex < 0 OrElse e.RowIndex >= dgvProduk.Rows.Count Then Return
            Dim drv = TryCast(dgvProduk.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If drv Is Nothing OrElse IsDBNull(drv("stok")) Then Return
            Dim stokVal As Integer = CInt(drv("stok"))
            Dim ambang As Integer = ModPengaturan.AmbilInt("ambang_stok", 5)
            If stokVal = 0 Then
                e.CellStyle.BackColor = ModTema.WarnaBahayaLembut
                e.CellStyle.ForeColor = ModTema.WarnaBahaya
            ElseIf stokVal <= ambang Then
                e.CellStyle.BackColor = ModTema.WarnaPeringatanLembut
                e.CellStyle.ForeColor = ModTema.WarnaPeringatan
            End If
        End Sub

        Private Sub OnProdukSelected(sender As Object, e As EventArgs)
            If dgvProduk.CurrentRow Is Nothing Then Return
            Dim drv = TryCast(dgvProduk.CurrentRow.DataBoundItem, DataRowView)
            If drv Is Nothing Then Return
            _selectedProdukId = CInt(drv("id_produk"))
            txtNama.Text = CStr(drv("nama"))
            cboKategori.SelectedValue = CInt(drv("id_kategori"))
            txtHarga.Text = CInt(CDec(drv("harga"))).ToString()
            txtDeskripsi.Text = CStr(drv("deskripsi"))
            txtStok.Text = If(IsDBNull(drv("stok")), "", CInt(drv("stok")).ToString())
            chkTersedia.Checked = CBool(drv("tersedia"))
            chkBestSeller.Checked = CBool(drv("best_seller"))
            _selectedGambarFile = CStr(drv("gambar"))
            picFoto.Image = ModProduk.AmbilGambar(_selectedGambarFile)
            errProduk.Clear()
        End Sub

        Private Sub ResetFormProduk()
            _selectedProdukId = 0
            txtNama.Text = ""
            txtHarga.Text = ""
            txtDeskripsi.Text = ""
            txtStok.Text = ""
            chkTersedia.Checked = True
            chkBestSeller.Checked = False
            _selectedGambarFile = "paket1.jpg"
            picFoto.Image = ModProduk.AmbilGambar(_selectedGambarFile)
            errProduk.Clear()
            txtNama.Focus()
        End Sub

        Private Sub TambahStokCepat(delta As Integer)
            Dim cur As Integer = 0
            Integer.TryParse(txtStok.Text.Trim(), cur)
            Dim baru As Integer = cur + delta
            txtStok.Text = baru.ToString()
            If cur = 0 AndAlso baru > 0 Then chkTersedia.Checked = True
        End Sub

        Private Sub OnPilihFotoClick(sender As Object, e As EventArgs)
            Using ofd As New OpenFileDialog()
                ofd.Filter = "Gambar (*.jpg;*.jpeg;*.png;*.webp;*.bmp)|*.jpg;*.jpeg;*.png;*.webp;*.bmp"
                If ofd.ShowDialog(Me) <> DialogResult.OK Then Return
                Try
                    Dim fi As New FileInfo(ofd.FileName)
                    If fi.Length > 2 * 1024 * 1024 Then
                        MessageBox.Show("Ukuran gambar asal maksimal 2 MB.", "File Terlalu Besar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                    Dim namaRef As String = If(String.IsNullOrWhiteSpace(txtNama.Text), $"produk_{DateTime.Now:HHmmss}", $"{txtNama.Text.Trim()}_{DateTime.Now:HHmmss}")
                    Dim fileBaru As String = ModProduk.KonversiDanSimpanGambarProduk(ofd.FileName, namaRef)
                    If String.IsNullOrEmpty(fileBaru) Then
                        MessageBox.Show("Gagal mengonversi gambar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    ModProduk.HapusCacheGambar(fileBaru)
                    _selectedGambarFile = fileBaru
                    picFoto.Image = ModProduk.AmbilGambar(fileBaru)
                Catch ex As IOException
                    MessageBox.Show("Gagal menyalin file gambar: " & ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Sub

        Private Sub OnSimpanProdukClick(sender As Object, e As EventArgs)
            If Not ModValidasi.WajibIsi(txtNama, errProduk, "Nama produk wajib diisi.") Then Return
            Dim harga As Decimal = 0D
            If Not ModValidasi.BacaAngka(txtHarga, errProduk, harga) OrElse harga <= 0D Then
                errProduk.SetError(txtHarga, "Harga harus lebih dari 0.") : Return
            End If

            Dim stokVal As Integer? = Nothing
            If Not String.IsNullOrWhiteSpace(txtStok.Text) Then
                Dim sInt As Integer = 0
                If Not Integer.TryParse(txtStok.Text.Trim(), sInt) OrElse sInt < 0 Then
                    errProduk.SetError(txtStok, "Stok harus angka >= 0.") : Return
                End If
                stokVal = sInt
            End If

            Dim kat = TryCast(cboKategori.SelectedItem, Kategori)
            If kat Is Nothing Then Return
            Dim namaBaru = txtNama.Text.Trim()
            errProduk.Clear()

            Dim tersediaAkhir As Boolean = chkTersedia.Checked
            If stokVal.HasValue AndAlso stokVal.Value = 0 Then tersediaAkhir = False

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        ' Cek duplikat nama
                        Using cmdDup As New NpgsqlCommand(
                            "SELECT COUNT(*) FROM public.produk WHERE LOWER(nama) = LOWER(@n) AND id_produk <> @id", conn)
                            cmdDup.Parameters.AddWithValue("n", namaBaru)
                            cmdDup.Parameters.AddWithValue("id", _selectedProdukId)
                            If Convert.ToInt32(cmdDup.ExecuteScalar()) > 0 Then
                                errProduk.SetError(txtNama, "Nama produk sudah ada.")
                                Return
                            End If
                        End Using

                        Dim sql As String
                        If _selectedProdukId = 0 Then
                            sql = "INSERT INTO public.produk (id_kategori, nama, deskripsi, harga, gambar, tersedia, best_seller, stok) " &
                                  "VALUES (@kat, @nama, @desk, @hrg, @gbr, @trs, @bs, @stok)"
                        Else
                            sql = "UPDATE public.produk SET id_kategori=@kat, nama=@nama, deskripsi=@desk, harga=@hrg, " &
                                  "gambar=@gbr, tersedia=@trs, best_seller=@bs, stok=@stok WHERE id_produk=@id"
                        End If
                        Using cmd As New NpgsqlCommand(sql, conn)
                            cmd.Parameters.AddWithValue("kat", kat.IdKategori)
                            cmd.Parameters.AddWithValue("nama", namaBaru)
                            cmd.Parameters.AddWithValue("desk", txtDeskripsi.Text.Trim())
                            cmd.Parameters.AddWithValue("hrg", harga)
                            cmd.Parameters.AddWithValue("gbr", _selectedGambarFile)
                            cmd.Parameters.AddWithValue("trs", tersediaAkhir)
                            cmd.Parameters.AddWithValue("bs", chkBestSeller.Checked)
                            cmd.Parameters.AddWithValue("stok", If(stokVal.HasValue, CObj(stokVal.Value), DBNull.Value))
                            If _selectedProdukId > 0 Then cmd.Parameters.AddWithValue("id", _selectedProdukId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    ModLog.Catat(If(_selectedProdukId = 0, KodeAksi.ProdukTambah, KodeAksi.ProdukUbah), $"{If(_selectedProdukId = 0, "Tambah", "Ubah")} produk {namaBaru}")
                    MuatSemua()
                    MessageBox.Show("Produk berhasil disimpan ke Supabase.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                Catch ex As PostgresException When ex.SqlState = "23505"
                    errProduk.SetError(txtNama, "Nama produk sudah terdaftar.")
                    Return
                Catch ex As Exception
                    MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            ModDummyStore.PastikanInit()
            If ModDummyStore.ProdukList.Any(Function(p) p.IdProduk <> _selectedProdukId AndAlso String.Equals(p.Nama, namaBaru, StringComparison.OrdinalIgnoreCase)) Then
                errProduk.SetError(txtNama, "Nama produk sudah ada.") : Return
            End If

            If _selectedProdukId = 0 Then
                Dim pBaru As New Produk With {
                    .IdProduk = ModDummyStore.NextProdukId,
                    .IdKategori = kat.IdKategori,
                    .NamaKategori = kat.Nama,
                    .Nama = namaBaru,
                    .Deskripsi = txtDeskripsi.Text.Trim(),
                    .Harga = harga,
                    .Gambar = _selectedGambarFile,
                    .Tersedia = tersediaAkhir,
                    .BestSeller = chkBestSeller.Checked,
                    .Stok = stokVal
                }
                ModDummyStore.NextProdukId += 1
                ModDummyStore.ProdukList.Add(pBaru)
                ModLog.Catat(KodeAksi.ProdukTambah, $"Tambah produk {namaBaru}")
            Else
                Dim existing = ModDummyStore.ProdukList.FirstOrDefault(Function(p) p.IdProduk = _selectedProdukId)
                If existing IsNot Nothing Then
                    existing.IdKategori = kat.IdKategori
                    existing.NamaKategori = kat.Nama
                    existing.Nama = namaBaru
                    existing.Deskripsi = txtDeskripsi.Text.Trim()
                    existing.Harga = harga
                    existing.Gambar = _selectedGambarFile
                    existing.Tersedia = tersediaAkhir
                    existing.BestSeller = chkBestSeller.Checked
                    existing.Stok = stokVal
                    ModLog.Catat(KodeAksi.ProdukUbah, $"Ubah produk {namaBaru}")
                End If
            End If

            MuatSemua()
            MessageBox.Show("Produk berhasil disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub OnHapusProdukClick(sender As Object, e As EventArgs)
            If _selectedProdukId = 0 Then Return

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmdCek As New NpgsqlCommand("SELECT COUNT(*) FROM public.detail_pesanan WHERE id_produk = @id", conn)
                            cmdCek.Parameters.AddWithValue("id", _selectedProdukId)
                            If Convert.ToInt32(cmdCek.ExecuteScalar()) > 0 Then
                                Dim res = MessageBox.Show("Produk sudah tercatat di transaksi pesanan dan tidak bisa dihapus permanen. Nonaktifkan produk ini?", "Produk Dipakai", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                If res = DialogResult.Yes Then
                                    Using cmdOff As New NpgsqlCommand("UPDATE public.produk SET tersedia = FALSE WHERE id_produk = @id", conn)
                                        cmdOff.Parameters.AddWithValue("id", _selectedProdukId)
                                        cmdOff.ExecuteNonQuery()
                                    End Using
                                    ModLog.Catat(KodeAksi.ProdukUbah, $"Nonaktifkan produk ID {_selectedProdukId}")
                                    MuatSemua()
                                End If
                                Return
                            End If
                        End Using

                        Dim konfLive = MessageBox.Show("Yakin hapus produk ini secara permanen?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If konfLive <> DialogResult.Yes Then Return
                        Using cmdDel As New NpgsqlCommand("DELETE FROM public.produk WHERE id_produk = @id", conn)
                            cmdDel.Parameters.AddWithValue("id", _selectedProdukId)
                            cmdDel.ExecuteNonQuery()
                        End Using
                        ModLog.Catat(KodeAksi.ProdukHapus, $"Hapus produk ID {_selectedProdukId}")
                        ResetFormProduk()
                        MuatSemua()
                        Return
                    End Using
                Catch ex As PostgresException When ex.SqlState = "23503"
                    MessageBox.Show("Produk terhubung ke pesanan dan tidak dapat dihapus permanen. Nonaktifkan Tersedia sebagai gantinya.", "Tidak Bisa Dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                Catch ex As Exception
                    MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            ModDummyStore.PastikanInit()
            Dim dipakaiDiPesanan = ModDummyStore.DetailList.Any(Function(d) d.IdProduk = _selectedProdukId)
            If dipakaiDiPesanan Then
                Dim res = MessageBox.Show("Produk sudah tercatat di transaksi pesanan dan tidak bisa dihapus permanen. Nonaktifkan produk ini?", "Produk Dipakai", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res = DialogResult.Yes Then
                    Dim p = ModDummyStore.ProdukList.FirstOrDefault(Function(x) x.IdProduk = _selectedProdukId)
                    If p IsNot Nothing Then p.Tersedia = False
                    ModLog.Catat(KodeAksi.ProdukUbah, $"Nonaktifkan produk ID {_selectedProdukId}")
                    MuatSemua()
                End If
                Return
            End If

            Dim konf = MessageBox.Show("Yakin hapus produk ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If konf = DialogResult.Yes Then
                ModDummyStore.ProdukList.RemoveAll(Function(p) p.IdProduk = _selectedProdukId)
                ModLog.Catat(KodeAksi.ProdukHapus, $"Hapus produk ID {_selectedProdukId}")
                ResetFormProduk()
                MuatSemua()
            End If
        End Sub

        Private Sub OnSimpanKategoriClick(sender As Object, e As EventArgs)
            If String.IsNullOrWhiteSpace(txtNamaKat.Text) Then Return
            Dim nama = txtNamaKat.Text.Trim()
            Dim urt As Integer = CInt(nudUrutan.Value)

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Dim sql As String = If(_selectedKatId = 0,
                            "INSERT INTO public.kategori (nama, urutan) VALUES (@n, @u)",
                            "UPDATE public.kategori SET nama=@n, urutan=@u WHERE id_kategori=@id")
                        Using cmd As New NpgsqlCommand(sql, conn)
                            cmd.Parameters.AddWithValue("n", nama)
                            cmd.Parameters.AddWithValue("u", urt)
                            If _selectedKatId > 0 Then cmd.Parameters.AddWithValue("id", _selectedKatId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    MuatSemua()
                    Return
                Catch ex As Exception
                    MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            ModDummyStore.PastikanInit()
            If _selectedKatId = 0 Then
                ModDummyStore.KategoriList.Add(New Kategori With {.IdKategori = ModDummyStore.NextKategoriId, .Nama = nama, .Urutan = urt})
                ModDummyStore.NextKategoriId += 1
            Else
                Dim kat = ModDummyStore.KategoriList.FirstOrDefault(Function(k) k.IdKategori = _selectedKatId)
                If kat IsNot Nothing Then
                    kat.Nama = nama
                    kat.Urutan = urt
                End If
            End If
            MuatSemua()
        End Sub

        Private Sub OnHapusKategoriClick(sender As Object, e As EventArgs)
            If _selectedKatId = 0 Then Return

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmdDel As New NpgsqlCommand("DELETE FROM public.kategori WHERE id_kategori = @id", conn)
                            cmdDel.Parameters.AddWithValue("id", _selectedKatId)
                            cmdDel.ExecuteNonQuery()
                        End Using
                    End Using
                    _selectedKatId = 0
                    MuatSemua()
                    Return
                Catch ex As PostgresException When ex.SqlState = "23503"
                    MessageBox.Show("Kategori masih memiliki produk sehingga tidak dapat dihapus.", "Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                Catch ex As Exception
                    MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            ModDummyStore.PastikanInit()
            If ModDummyStore.ProdukList.Any(Function(p) p.IdKategori = _selectedKatId) Then
                MessageBox.Show("Kategori masih memiliki produk sehingga tidak dapat dihapus.", "Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            ModDummyStore.KategoriList.RemoveAll(Function(k) k.IdKategori = _selectedKatId)
            MuatSemua()
        End Sub

        Private Sub MuatOpsiProdukTerpilih()
            Dim p = TryCast(cboOpsiProduk.SelectedItem, Produk)
            If p Is Nothing Then Return
            dgvOpsi.DataSource = ModProduk.AmbilOpsi(p.IdProduk)
        End Sub

        Private Sub OnTambahOpsiClick(sender As Object, e As EventArgs)
            Dim p = TryCast(cboOpsiProduk.SelectedItem, Produk)
            If p Is Nothing OrElse String.IsNullOrWhiteSpace(txtNamaOpsi.Text) Then Return
            Dim hrg As Decimal = 0D
            Decimal.TryParse(txtTambahanHarga.Text.Trim(), hrg)
            Dim namaOpsi = txtNamaOpsi.Text.Trim()
            Dim tipeOpsi = CStr(cboTipeOpsi.SelectedItem)

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand(
                            "INSERT INTO public.opsi_produk (id_produk, nama_opsi, tipe, tambahan_harga) " &
                            "VALUES (@id, @nama, @tipe, @hrg)", conn)
                            cmd.Parameters.AddWithValue("id", p.IdProduk)
                            cmd.Parameters.AddWithValue("nama", namaOpsi)
                            cmd.Parameters.AddWithValue("tipe", tipeOpsi)
                            cmd.Parameters.AddWithValue("hrg", hrg)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    txtNamaOpsi.Text = ""
                    txtTambahanHarga.Text = "0"
                    MuatOpsiProdukTerpilih()
                    Return
                Catch ex As PostgresException When ex.SqlState = "23505"
                    MessageBox.Show($"Opsi '{namaOpsi}' ({tipeOpsi}) sudah ada untuk produk ini.", "Duplikat Opsi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                Catch ex As Exception
                    MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            ModDummyStore.PastikanInit()
            ModDummyStore.OpsiList.Add(New OpsiProduk With {
                .IdOpsi = ModDummyStore.NextOpsiId,
                .IdProduk = p.IdProduk,
                .NamaOpsi = namaOpsi,
                .Tipe = tipeOpsi,
                .TambahanHarga = hrg
            })
            ModDummyStore.NextOpsiId += 1
            txtNamaOpsi.Text = ""
            txtTambahanHarga.Text = "0"
            MuatOpsiProdukTerpilih()
        End Sub

        Private Sub OnHapusOpsiClick(sender As Object, e As EventArgs)
            If dgvOpsi.CurrentRow Is Nothing Then Return
            Dim drv = TryCast(dgvOpsi.CurrentRow.DataBoundItem, DataRowView)
            If drv Is Nothing Then Return
            Dim idOpsi As Integer = CInt(drv("id_opsi"))

            If Not ModDatabase.ModeDummyAktif() Then
                Try
                    Using conn = ModDatabase.BukaKoneksi()
                        Using cmd As New NpgsqlCommand("DELETE FROM public.opsi_produk WHERE id_opsi = @id", conn)
                            cmd.Parameters.AddWithValue("id", idOpsi)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    MuatOpsiProdukTerpilih()
                    Return
                Catch ex As Exception
                    MessageBox.Show(ModDatabase.PesanKesalahanAman(ex), "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            ModDummyStore.PastikanInit()
            ModDummyStore.OpsiList.RemoveAll(Function(o) o.IdOpsi = idOpsi)
            MuatOpsiProdukTerpilih()
        End Sub

    End Class
End Namespace
