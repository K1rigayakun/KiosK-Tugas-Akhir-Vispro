Option Strict On
Option Explicit On

Imports System.Data
Imports Npgsql
Imports VisproPrakProjectAkhir.Model

Namespace VisproPrakProjectAkhir.Modul

    Public Module ModPromo

        Public Const AmbangDiskon1 As Decimal = 100000D
        Public Const PersenDiskon1 As Decimal = 0.05D
        Public Const AmbangDiskon2 As Decimal = 200000D
        Public Const PersenDiskon2 As Decimal = 0.1D
        Public Const AmbangDiskon3 As Decimal = 300000D
        Public Const PersenDiskon3 As Decimal = 0.15D

        ''' <summary>Cek validitas voucher — live Supabase jika tersambung, dummy jika tidak.</summary>
        Public Function CekVoucher(kode As String, subtotal As Decimal) As HasilVoucher
            Dim hasil As New HasilVoucher With {.Valid = False, .Pesan = "", .Diskon = 0D}
            Dim cleanKode As String = If(kode, "").Trim().ToUpperInvariant()
            If String.IsNullOrEmpty(cleanKode) Then
                hasil.Pesan = "Masukkan kode voucher terlebih dahulu."
                Return hasil
            End If

            If Not ModDatabase.ModeDummyAktif() Then
                Return CekVoucherLive(cleanKode, subtotal)
            End If

            ' Fallback: dummy
            ModDummyStore.PastikanInit()
            Dim v = ModDummyStore.VoucherList.FirstOrDefault(Function(x) String.Equals(x.Kode, cleanKode, StringComparison.OrdinalIgnoreCase))
            Return ValidasiObjekVoucher(v, cleanKode, subtotal)
        End Function

        Private Function CekVoucherLive(cleanKode As String, subtotal As Decimal) As HasilVoucher
            Dim hasil As New HasilVoucher With {.Valid = False, .Pesan = "", .Diskon = 0D}
            Try
                Using conn = ModDatabase.BukaKoneksi()
                    Using cmd As New NpgsqlCommand(
                        "SELECT kode, jenis, nilai, min_belanja, tgl_mulai, tgl_akhir, aktif " &
                        "FROM public.voucher WHERE kode = @kode LIMIT 1", conn)
                        cmd.Parameters.AddWithValue("kode", cleanKode)
                        Using rd = cmd.ExecuteReader()
                            If Not rd.Read() Then
                                hasil.Pesan = $"Voucher '{cleanKode}' tidak ditemukan."
                                Return hasil
                            End If
                            Dim v As New Voucher With {
                                .Kode = rd.GetString(0),
                                .Jenis = rd.GetString(1),
                                .Nilai = rd.GetDecimal(2),
                                .MinBelanja = rd.GetDecimal(3),
                                .TglMulai = rd.GetDateTime(4),
                                .TglAkhir = rd.GetDateTime(5),
                                .Aktif = rd.GetBoolean(6)
                            }
                            Return ValidasiObjekVoucher(v, cleanKode, subtotal)
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                ' Fallback ke dummy saat koneksi gagal
                System.Diagnostics.Debug.WriteLine("[ModPromo] CekVoucher gagal: " & ex.Message)
                ModDummyStore.PastikanInit()
                Dim v = ModDummyStore.VoucherList.FirstOrDefault(Function(x) String.Equals(x.Kode, cleanKode, StringComparison.OrdinalIgnoreCase))
                Return ValidasiObjekVoucher(v, cleanKode, subtotal)
            End Try
        End Function

        Private Function ValidasiObjekVoucher(v As Voucher, cleanKode As String, subtotal As Decimal) As HasilVoucher
            Dim hasil As New HasilVoucher With {.Valid = False, .Pesan = "", .Diskon = 0D}
            If v Is Nothing Then
                hasil.Pesan = $"Voucher '{cleanKode}' tidak ditemukan."
                Return hasil
            End If
            If Not v.Aktif Then
                hasil.Pesan = $"Voucher '{cleanKode}' sedang tidak aktif."
                Return hasil
            End If
            Dim today As DateTime = DateTime.Today
            If today < v.TglMulai.Date Then
                hasil.Pesan = $"Voucher '{cleanKode}' baru berlaku mulai {v.TglMulai:dd MMM yyyy}."
                Return hasil
            End If
            If today > v.TglAkhir.Date Then
                hasil.Pesan = $"Voucher '{cleanKode}' sudah kadaluarsa sejak {v.TglAkhir:dd MMM yyyy}."
                Return hasil
            End If
            If subtotal < v.MinBelanja Then
                hasil.Pesan = $"Minimal belanja untuk '{cleanKode}' adalah {ModFormat.Rupiah(v.MinBelanja)}."
                Return hasil
            End If
            Dim diskon As Decimal
            If String.Equals(v.Jenis, JenisVoucher.Persen, StringComparison.OrdinalIgnoreCase) Then
                diskon = Math.Round(subtotal * (v.Nilai / 100D), 0, MidpointRounding.AwayFromZero)
            Else
                diskon = v.Nilai
            End If
            hasil.Valid = True
            hasil.Diskon = diskon
            hasil.Pesan = $"Voucher '{cleanKode}' berhasil diterapkan (-{ModFormat.Rupiah(diskon)})."
            Return hasil
        End Function

        ''' <summary>Hitung rincian harga lengkap — murni logika lokal, tidak perlu DB.</summary>
        Public Function HitungRincian(subtotal As Decimal, kodeVoucher As String, poinDipakai As Integer) As RincianHarga
            Dim r As New RincianHarga With {
                .Subtotal = Math.Max(0D, subtotal),
                .KodeVoucher = If(kodeVoucher, "").Trim().ToUpperInvariant()
            }

            ' 1. Diskon bertingkat otomatis
            If r.Subtotal >= AmbangDiskon3 Then
                r.DiskonBertingkat = Math.Round(r.Subtotal * PersenDiskon3, 0, MidpointRounding.AwayFromZero)
            ElseIf r.Subtotal >= AmbangDiskon2 Then
                r.DiskonBertingkat = Math.Round(r.Subtotal * PersenDiskon2, 0, MidpointRounding.AwayFromZero)
            ElseIf r.Subtotal >= AmbangDiskon1 Then
                r.DiskonBertingkat = Math.Round(r.Subtotal * PersenDiskon1, 0, MidpointRounding.AwayFromZero)
            End If

            ' 2. Diskon voucher
            If Not String.IsNullOrEmpty(r.KodeVoucher) Then
                Dim hv = CekVoucher(r.KodeVoucher, r.Subtotal)
                If hv.Valid Then
                    r.DiskonVoucher = hv.Diskon
                Else
                    r.KodeVoucher = ""
                End If
            End If

            ' 3. Diskon poin member (maks 50% dari subtotal)
            Dim nilaiPoin As Decimal = ModPengaturan.AmbilDesimal("nilai_poin", 100D)
            If poinDipakai > 0 AndAlso nilaiPoin > 0D Then
                Dim maksSisaDiskon As Decimal = Math.Max(0D, Math.Floor(r.Subtotal * 0.5D) - r.DiskonBertingkat - r.DiskonVoucher)
                Dim poinMaks As Integer = CInt(Math.Floor(maksSisaDiskon / nilaiPoin))
                Dim poinEfektif As Integer = Math.Max(0, Math.Min(poinDipakai, poinMaks))
                r.PoinDipakai = poinEfektif
                r.DiskonPoin = poinEfektif * nilaiPoin
            End If

            ' 4. Pajak & Total
            Dim dasarPajak As Decimal = Math.Max(0D, r.Subtotal - r.TotalDiskon)
            Dim pajakPersen As Decimal = ModPengaturan.AmbilDesimal("pajak_persen", 11D)
            r.Pajak = Math.Round(dasarPajak * (pajakPersen / 100D), 0, MidpointRounding.AwayFromZero)
            r.Total = dasarPajak + r.Pajak

            ' 5. Poin didapat
            Dim poinPerRupiah As Decimal = ModPengaturan.AmbilDesimal("poin_per_rupiah", 10000D)
            If poinPerRupiah > 0D Then
                r.PoinDidapat = CInt(Math.Floor(r.Total / poinPerRupiah))
            End If

            Return r
        End Function

    End Module
End Namespace
