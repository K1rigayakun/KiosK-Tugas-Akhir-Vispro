Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports VisproPrakProjectAkhir.Forms.Admin
Imports VisproPrakProjectAkhir.Forms.Checkout
Imports VisproPrakProjectAkhir.Forms.Kasir
Imports VisproPrakProjectAkhir.Forms.Kiosk
Imports VisproPrakProjectAkhir.Forms.Umum
Imports VisproPrakProjectAkhir.Model
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir
    Public Module ModProgram

        Private Class DemoShortcutMessageFilter
            Implements IMessageFilter

            Private Const WM_KEYDOWN As Integer = &H100

            Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
                If m.Msg = WM_KEYDOWN Then
                    Dim key As Keys = CType(m.WParam.ToInt32(), Keys)
                    If key = Keys.F11 Then
                        Dim active = Form.ActiveForm
                        If active IsNot Nothing Then
                            ModNavigasi.ToggleFullscreen(active)
                            Return True
                        End If
                    ElseIf key = Keys.F9 Then
                        Dim active = Form.ActiveForm
                        If active IsNot Nothing AndAlso
                           Not TypeOf active Is FrmDemoHub AndAlso
                           Not TypeOf active Is FrmLogin AndAlso
                           Not TypeOf active Is FrmIdle AndAlso
                           Not TypeOf active Is FrmRating AndAlso
                           Not TypeOf active Is FrmDetailProduk Then
                            FrmDemoHub.ShowHub(active)
                            Return True
                        End If
                    End If
                End If
                Return False
            End Function
        End Class

        <STAThread()>
        Public Sub Main(args As String())
            Application.SetHighDpiMode(HighDpiMode.SystemAware)
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            ModDummyStore.PastikanInit()

            If args IsNot Nothing AndAlso args.Length > 0 Then
                Select Case args(0)
                    Case "--test-db"
                        ModDatabase.PaksaModeDummy = False
                        Console.WriteLine(ModDatabase.CekKoneksiDetail())
                        Return
                    Case "--encrypt-config"
                        Dim cfgPath As String = If(args.Length > 1, args(1), Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                        Dim kunci As String = Environment.GetEnvironmentVariable("BISTRO_CONFIG_KEY")
                        If String.IsNullOrWhiteSpace(kunci) Then
                            kunci = $"BistroKiosk_{Environment.MachineName}_2026"
                        End If
                        ModKeamananConfig.EnskripsiKonfigurasi(cfgPath, kunci)
                        Return
                    Case "--verify-supabase"
                        ModDatabase.PaksaModeDummy = False
                        ModPengaturan.Muat()
                        Dim okSupa As Boolean = RunVerifySupabase()
                        Environment.ExitCode = If(okSupa, 0, 1)
                        Return
                    Case "--self-test"
                        ModDatabase.PaksaModeDummy = True
                        ModPengaturan.Muat()
                        Dim outPath As String = If(args.Length > 1, args(1), Path.Combine(AppContext.BaseDirectory, "self_test_report.txt"))
                        Dim ok As Boolean = RunSelfTests(outPath)
                        Environment.ExitCode = If(ok, 0, 1)
                        Return
                    Case "--capture-tour"
                        ModDatabase.PaksaModeDummy = True
                        ModPengaturan.Muat()
                        Dim outDir As String = If(args.Length > 1, args(1), Path.Combine(AppContext.BaseDirectory, "screenshoot"))
                        Dim capW As Integer = If(args.Length > 2 AndAlso Integer.TryParse(args(2), capW), capW, 0)
                        Dim capH As Integer = If(args.Length > 3 AndAlso Integer.TryParse(args(3), capH), capH, 0)
                        RunCaptureTour(outDir, capW, capH)
                        Return
                End Select
            End If

            ModPengaturan.Muat()
            Application.AddMessageFilter(New DemoShortcutMessageFilter())
            Application.Run(New FrmWelcome())
        End Sub

        Private Function RunSelfTests(reportPath As String) As Boolean
            Dim sb As New StringBuilder()
            Dim failures As Integer = 0

            Dim check As Action(Of String, Boolean, String) =
                Sub(nama As String, cond As Boolean, detail As String)
                    If cond Then
                        sb.AppendLine($"[PASS] {nama} — {detail}")
                    Else
                        failures += 1
                        sb.AppendLine($"[FAIL] {nama} — {detail}")
                    End If
                End Sub

            ' 1. ModPromo Contoh Uji 1: subtotal 250.000, HEMAT10 => total 222.000
            Dim r1 = ModPromo.HitungRincian(250000D, "HEMAT10", 0)
            check("ModPromo Uji 1 (Diskon Bertingkat 10% = 25rb)", r1.DiskonBertingkat = 25000D, $"Got {r1.DiskonBertingkat}")
            check("ModPromo Uji 1 (Voucher HEMAT10 = 25rb)", r1.DiskonVoucher = 25000D, $"Got {r1.DiskonVoucher}")
            check("ModPromo Uji 1 (Pajak 11% = 22rb)", r1.Pajak = 22000D, $"Got {r1.Pajak}")
            check("ModPromo Uji 1 (Total = 222rb)", r1.Total = 222000D, $"Got {r1.Total}")

            ' 2. ModPromo Contoh Uji 2: subtotal 90.000, POTONG5K => total 94.350
            Dim r2 = ModPromo.HitungRincian(90000D, "POTONG5K", 0)
            check("ModPromo Uji 2 (Diskon Bertingkat = 0)", r2.DiskonBertingkat = 0D, $"Got {r2.DiskonBertingkat}")
            check("ModPromo Uji 2 (Voucher POTONG5K = 5rb)", r2.DiskonVoucher = 5000D, $"Got {r2.DiskonVoucher}")
            check("ModPromo Uji 2 (Pajak 11% = 9.350)", r2.Pajak = 9350D, $"Got {r2.Pajak}")
            check("ModPromo Uji 2 (Total = 94.350)", r2.Total = 94350D, $"Got {r2.Total}")

            ' 3. Voucher kadaluarsa ditolak
            Dim vExp = ModPromo.CekVoucher("EXPIRED2025", 100000D)
            check("ModPromo Voucher Kadaluarsa Ditolak", Not vExp.Valid, vExp.Pesan)

            ' 4. PecahKembalian
            Dim pec = ModPesanan.PecahKembalian(138500D)
            Dim pecOk As Boolean = (pec.GetValueOrDefault(100000) = 1 AndAlso pec.GetValueOrDefault(20000) = 1 AndAlso
                                    pec.GetValueOrDefault(10000) = 1 AndAlso pec.GetValueOrDefault(5000) = 1 AndAlso
                                    pec.GetValueOrDefault(2000) = 1 AndAlso pec.GetValueOrDefault(1000) = 1 AndAlso
                                    pec.GetValueOrDefault(500) = 1)
            check("ModPesanan PecahKembalian(138.500)", pecOk, $"Count keys = {pec.Count}")

            ' 5. Keranjang merge & subtotal
            ModKeranjang.Kosongkan()
            ModKeranjang.IsiContohDemo()
            check("ModKeranjang IsiContohDemo Subtotal = 91.000", ModKeranjang.Subtotal() = 91000D, $"Got {ModKeranjang.Subtotal()}")
            ModKeranjang.Kosongkan()

            ' 6. Transisi status & pengembalian stok
            Dim invalidTrans = ModAntrian.UbahStatus(3, StatusPesanan.Dibatalkan) ' #3 status Siap -> tidak boleh batal
            check("ModAntrian Tolak Batal saat Status Siap", Not invalidTrans, $"Returned {invalidTrans}")

            ' 7. Rekap 2D & PBKDF2
            Dim rekap = ModLaporan.AmbilRekapKategoriHari(DateTime.Today.AddDays(-6), DateTime.Today)
            check("ModLaporan Rekap Array 2D", rekap.Kategori.Length = 7 AndAlso rekap.Tanggal.Length = 7, $"{rekap.Kategori.Length}x{rekap.Tanggal.Length}")

            Dim adm = ModDummyStore.PenggunaList.First(Function(u) u.Username = "admin")
            check("PBKDF2 Verifikasi Admin", ModDummyStore.VerifikasiPassword("admin123", adm.PasswordHash), "PBKDF2 OK")

            Dim prevAnimState As Boolean = ModAnimasi.NonaktifkanAnimasi
            ModAnimasi.NonaktifkanAnimasi = True
            Using tmpLbl As New Label()
                ModAnimasi.AnimateNumber(tmpLbl, 42000D, Function(v) ModFormat.Rupiah(v), 300UL)
                check("ModAnimasi Snap Mode AnimateNumber", tmpLbl.Text = ModFormat.Rupiah(42000D), tmpLbl.Text)
            End Using

            ' 8. SiapkanTransisiMasuk snap vs animated opacity staging
            Using tmpFrm As New Form()
                ModAnimasi.NonaktifkanAnimasi = True
                ModAnimasi.SiapkanTransisiMasuk(tmpFrm, 0)
                Dim opSnap As Double = tmpFrm.Opacity
                ModAnimasi.NonaktifkanAnimasi = False
                ModAnimasi.SiapkanTransisiMasuk(tmpFrm, 0)
                Dim opAnim As Double = tmpFrm.Opacity
                check("ModAnimasi SiapkanTransisiMasuk Pre-Paint", opSnap = 1.0 AndAlso opAnim = 0.0, $"Snap={opSnap}, Anim={opAnim}")
            End Using
            ModAnimasi.NonaktifkanAnimasi = prevAnimState

            ' 9. ModNavigasi fullscreen state & event sync
            ModNavigasi.ResetUntukTest()
            Dim eventChanges As Integer = 0
            Dim navHandler As ModNavigasi.ModeFullscreenBerubahEventHandler = Sub(akt As Boolean) eventChanges += 1
            AddHandler ModNavigasi.ModeFullscreenBerubah, navHandler
            ModNavigasi.SetFullscreen(True)
            Dim fsOn As Boolean = ModNavigasi.ModeFullscreen
            ModNavigasi.SetFullscreen(False)
            Dim fsOff As Boolean = ModNavigasi.ModeFullscreen
            RemoveHandler ModNavigasi.ModeFullscreenBerubah, navHandler
            ModNavigasi.ResetUntukTest()
            check("ModNavigasi Fullscreen Sync", fsOn AndAlso Not fsOff AndAlso eventChanges = 2, $"On={fsOn}, Off={fsOff}, Events={eventChanges}")

            ' 10. Voucher minimum belanja validation (cart shrink scenario)
            Dim vLow = ModPromo.CekVoucher("HEMAT10", 40000D)
            Dim vOk = ModPromo.CekVoucher("HEMAT10", 60000D)
            check("ModPromo Validasi Ulang MinBelanja Voucher", (Not vLow.Valid) AndAlso vOk.Valid, $"40rb={vLow.Valid}, 60rb={vOk.Valid}")

            sb.AppendLine($"TOTAL FAILURES: {failures}")
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath))
            File.WriteAllText(reportPath, sb.ToString(), Encoding.UTF8)
            Return (failures = 0)
        End Function

        Private Function RunVerifySupabase() As Boolean
            Dim failures As Integer = 0
            Dim cek As Action(Of String, Boolean, String) =
                Sub(nama As String, cond As Boolean, detail As String)
                    If cond Then
                        Console.WriteLine($"[PASS] {nama} — {detail}")
                    Else
                        failures += 1
                        Console.WriteLine($"[FAIL] {nama} — {detail}")
                    End If
                End Sub

            Dim connected As Boolean = ModDatabase.DatabaseTerhubung(True)
            cek("Koneksi Supabase", connected, If(connected, "Terhubung", "Gagal"))
            If Not connected Then Return False

            Dim dtKat = ModProduk.AmbilKategori()
            cek("Baca Kategori Live", dtKat.Rows.Count >= 7, $"Count={dtKat.Rows.Count}")

            Dim dtProd = ModProduk.AmbilProduk(0)
            cek("Baca Produk Live", dtProd.Rows.Count >= 24, $"Count={dtProd.Rows.Count}")

            Dim banners = ModProduk.AmbilBannerAktif()
            cek("Baca Banner Live", banners.Count >= 3, $"Count={banners.Count}")

            Dim hv = ModPromo.CekVoucher("HEMAT10", 100000D)
            cek("Cek Voucher HEMAT10 Live", hv.Valid AndAlso hv.Diskon = 10000D, $"Valid={hv.Valid}, Diskon={hv.Diskon}")

            Dim dtCred = ModFunction.AmbilData(
                "SELECT id_pengguna, username, password_hash, terkunci FROM public.fn_ambil_kredensial_login(@u)",
                New Dictionary(Of String, Object) From {{"u", "admin"}})
            Dim credOk As Boolean = dtCred.Rows.Count > 0 AndAlso Not IsDBNull(dtCred.Rows(0)("id_pengguna")) AndAlso
                                    BuatPassword.VerifikasiHash("admin123", Convert.ToString(dtCred.Rows(0)("password_hash")))
            cek("RPC fn_ambil_kredensial_login + PBKDF2 Admin", credOk, $"Rows={dtCred.Rows.Count}")

            ' Tes Storage gambar produk publik
            Dim img = ModProduk.AmbilGambar("paket1.jpg")
            cek("Storage Publik paket1.jpg", img IsNot Nothing AndAlso img.Width >= 480, $"{img.Width}x{img.Height}")

            ' Tes round-trip simpan pesanan -> baca -> batalkan & bersihkan row uji
            ModKeranjang.Kosongkan()
            ModKeranjang.TipeMakan = TipeMakan.DineIn
            ModKeranjang.IsiContohDemo()
            Dim rincian = ModPromo.HitungRincian(ModKeranjang.Subtotal(), "HEMAT10", 0)
            Dim resPes = ModPesanan.SimpanPesanan(MetodeBayar.Qris, rincian, Nothing, Nothing)
            Dim pesDb = ModPesanan.AmbilPesananById(resPes.IdPesanan)
            Dim rtOk As Boolean = (resPes.IdPesanan > 0 AndAlso pesDb IsNot Nothing AndAlso pesDb.Total = rincian.Total)
            cek("Round-trip Simpan & Baca Pesanan", rtOk, $"IdPesanan={resPes.IdPesanan}, Total={If(pesDb IsNot Nothing, pesDb.Total, 0D)}")

            ' Bersihkan data uji & kembalikan stok agar database tetap rapi
            If resPes.IdPesanan > 0 Then
                Try
                    ModAntrian.UbahStatus(resPes.IdPesanan, StatusPesanan.Dibatalkan)
                Catch
                End Try
                Using conn = ModDatabase.BukaKoneksi()
                    Using tx = conn.BeginTransaction()
                        Using cmd1 As New Npgsql.NpgsqlCommand("DELETE FROM public.detail_pesanan WHERE id_pesanan = @id", conn, tx)
                            cmd1.Parameters.AddWithValue("id", resPes.IdPesanan)
                            cmd1.ExecuteNonQuery()
                        End Using
                        Using cmd2 As New Npgsql.NpgsqlCommand("DELETE FROM public.pesanan WHERE id_pesanan = @id", conn, tx)
                            cmd2.Parameters.AddWithValue("id", resPes.IdPesanan)
                            cmd2.ExecuteNonQuery()
                        End Using
                        tx.Commit()
                    End Using
                End Using
            End If
            ModKeranjang.Kosongkan()

            Console.WriteLine($"VERIFY SUPABASE FAILURES: {failures}")
            Return (failures = 0)
        End Function

        <DllImport("user32.dll", SetLastError:=True)>
        Private Function PrintWindow(hwnd As IntPtr, hDC As IntPtr, nFlags As UInteger) As Boolean
        End Function

        Private Const PW_RENDERFULLCONTENT As UInteger = &H2UI

        Private Sub RunCaptureTour(outDir As String, Optional targetW As Integer = 0, Optional targetH As Integer = 0)
            Directory.CreateDirectory(outDir)
            Dim prevAnim As Boolean = ModAnimasi.NonaktifkanAnimasi
            ModAnimasi.NonaktifkanAnimasi = True
            Try
                Dim snap As Action(Of Form, String, Integer) =
                    Sub(f As Form, fileName As String, delayMs As Integer)
                        f.StartPosition = FormStartPosition.Manual
                        f.Location = New Point(40, 20)
                        If targetW > 0 AndAlso targetH > 0 AndAlso f.FormBorderStyle <> FormBorderStyle.FixedDialog Then
                            f.Size = New Size(targetW, targetH)
                        End If
                        f.Show()
                        f.BringToFront()
                        f.Refresh()
                        Application.DoEvents()
                        Threading.Thread.Sleep(delayMs)
                        Application.DoEvents()
                        f.Refresh()
                        Using bmp As New Bitmap(Math.Max(1, f.Width), Math.Max(1, f.Height), PixelFormat.Format32bppArgb)
                            Dim ok As Boolean = False
                            Try
                                Using g = Graphics.FromImage(bmp)
                                    Dim hdc As IntPtr = g.GetHdc()
                                    Try
                                        ok = PrintWindow(f.Handle, hdc, PW_RENDERFULLCONTENT)
                                    Finally
                                        g.ReleaseHdc(hdc)
                                    End Try
                                End Using
                            Catch
                                ok = False
                            End Try
                            If Not ok Then
                                f.DrawToBitmap(bmp, New Rectangle(0, 0, f.Width, f.Height))
                            End If
                            bmp.Save(Path.Combine(outDir, fileName), ImageFormat.Png)
                        End Using
                        GC.Collect()
                        GC.WaitForPendingFinalizers()
                    End Sub

                ' 01. FrmWelcome
                Using w As New FrmWelcome()
                    snap(w, "01_welcome.png", 450)
                    w.Hide()
                End Using

                ' 02. FrmMenu
                ModKeranjang.TipeMakan = TipeMakan.DineIn
                ModKeranjang.IsiContohDemo()
                Using m As New FrmMenu()
                    snap(m, "02_menu.png", 450)
                    m.Hide()
                End Using

                ' 03. FrmDetailProduk (ambil id pertama secara dinamis)
                Dim dtFirst = ModProduk.AmbilProduk(0)
                Dim firstProdId As Integer = If(dtFirst.Rows.Count > 0, CInt(dtFirst.Rows(0)("id_produk")), 1)
                Using dp As New FrmDetailProduk(firstProdId)
                    snap(dp, "03_detail_produk.png", 350)
                End Using

                ' 04. FrmKeranjang
                Using kj As New FrmKeranjang()
                    snap(kj, "04_keranjang.png", 400)
                End Using

                ' 05. FrmPembayaran (QRIS)
                Dim rincian = ModPromo.HitungRincian(ModKeranjang.Subtotal(), "HEMAT10", 0)
                Using pb As New FrmPembayaran(rincian)
                    snap(pb, "05_pembayaran_qris.png", 400)
                End Using

                ' 06. FrmStruk
                Using st As New FrmStruk(3, True)
                    snap(st, "06_struk.png", 350)
                End Using

                ' 07. FrmRating
                Using rt As New FrmRating(3)
                    snap(rt, "07_rating.png", 300)
                End Using

                ' 08. FrmLogin
                Using lg As New FrmLogin()
                    snap(lg, "08_login.png", 300)
                End Using

                ' 09-14. MDI Staff Screens (Admin)
                Dim adm = ModDummyStore.PenggunaList.First(Function(u) u.Peran = Peran.Admin)
                ModSesi.Masuk(adm)
                Using mdi As New FrmUtama()
                    snap(mdi, "09_mdi_dashboard.png", 550)

                    mdi.BukaFormAnak("FrmKasir")
                    Application.DoEvents()
                    mdi.Refresh()
                    snap(mdi, "10_kasir.png", 400)

                    mdi.BukaFormAnak("FrmDapur")
                    Application.DoEvents()
                    mdi.Refresh()
                    snap(mdi, "11_dapur.png", 400)

                    mdi.BukaFormAnak("FrmProduk")
                    Application.DoEvents()
                    mdi.Refresh()
                    snap(mdi, "13_admin_produk.png", 400)

                    mdi.BukaFormAnak("FrmLaporan")
                    Application.DoEvents()
                    mdi.Refresh()
                    snap(mdi, "14_admin_laporan.png", 400)
                End Using
                ModSesi.Keluar()

                ' 12. FrmAntrian
                Using ant As New FrmAntrian()
                    snap(ant, "12_antrian.png", 400)
                End Using

                ' 15. FrmDemoHub
                Using hub As New FrmDemoHub()
                    snap(hub, "15_demo_hub.png", 300)
                End Using

                ModKeranjang.Kosongkan()
            Catch ex As Exception
                File.WriteAllText(Path.Combine(outDir, "capture_error.txt"), ex.ToString(), Encoding.UTF8)
                Environment.ExitCode = 1
            Finally
                ModAnimasi.NonaktifkanAnimasi = prevAnim
            End Try
        End Sub

    End Module
End Namespace
