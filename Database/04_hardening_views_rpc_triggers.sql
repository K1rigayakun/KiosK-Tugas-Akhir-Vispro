-- =============================================================
-- Migration 04: Security Hardening, Integrity Triggers, Views & RPC
-- Project  : Bistro Kiosk Nusantara
-- Date     : 2026-11-26
-- Supabase : eszvojtlvfqyuxigkjcc
--
-- Mencakup:
--   1. Schema non-exposed `app_private` untuk helper RLS (tutup lint 0029)
--   2. Rebind semua RLS policy ke `app_private.*` & drop helper publik
--   3. Tutup lubang upload publik pada `storage.objects` (kiosk-assets)
--   4. Cabut EXECUTE fungsi sensitif (`fn_ambil_kredensial_login`, dll)
--      dari PUBLIC, anon, authenticated (anti-dump password_hash via Data API)
--   5. Column-level security pada `public.pengguna` (sembunyikan password_hash)
--   6. Check constraints & triggers validasi (state machine pesanan,
--      normalisasi voucher, validasi rating, audit harga produk)
--   7. Analytics views dengan `security_invoker = true`
--   8. RPC aman untuk WinForms Data API (Kiosk + Kasir/Admin)
-- =============================================================

BEGIN;

-- ─── 1. SCHEMA app_private & HELPER FUNCTIONS ─────────────────
CREATE SCHEMA IF NOT EXISTS app_private;
REVOKE ALL ON SCHEMA app_private FROM PUBLIC;
GRANT USAGE ON SCHEMA app_private TO authenticated, anon;

CREATE OR REPLACE FUNCTION app_private.current_app_role()
RETURNS text
LANGUAGE sql
STABLE
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
  SELECT role
  FROM public.pengguna
  WHERE auth_user_id = (SELECT auth.uid())
    AND aktif = TRUE
  LIMIT 1;
$$;

CREATE OR REPLACE FUNCTION app_private.is_admin()
RETURNS boolean
LANGUAGE sql
STABLE
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
  SELECT COALESCE(app_private.current_app_role() = 'Admin', FALSE);
$$;

CREATE OR REPLACE FUNCTION app_private.is_staff()
RETURNS boolean
LANGUAGE sql
STABLE
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
  SELECT COALESCE(app_private.current_app_role() IN ('Admin', 'Kasir'), FALSE);
$$;

CREATE OR REPLACE FUNCTION app_private.my_pengguna_id()
RETURNS integer
LANGUAGE sql
STABLE
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
  SELECT id_pengguna
  FROM public.pengguna
  WHERE auth_user_id = (SELECT auth.uid())
    AND aktif = TRUE
  LIMIT 1;
$$;

REVOKE ALL ON ALL FUNCTIONS IN SCHEMA app_private FROM PUBLIC;
GRANT EXECUTE ON FUNCTION app_private.current_app_role() TO authenticated, anon;
GRANT EXECUTE ON FUNCTION app_private.is_admin() TO authenticated, anon;
GRANT EXECUTE ON FUNCTION app_private.is_staff() TO authenticated, anon;
GRANT EXECUTE ON FUNCTION app_private.my_pengguna_id() TO authenticated, anon;


-- ─── 2. REBIND SEMUA RLS POLICY KE app_private.* ──────────────
-- Katalog: kategori, produk, opsi_produk, banner_promo, voucher, pengaturan
ALTER POLICY pol_kategori_staff_select   ON public.kategori     USING (app_private.is_staff());
ALTER POLICY pol_kategori_admin_insert   ON public.kategori     WITH CHECK (app_private.is_admin());
ALTER POLICY pol_kategori_admin_update   ON public.kategori     USING (app_private.is_admin()) WITH CHECK (app_private.is_admin());
ALTER POLICY pol_kategori_admin_delete   ON public.kategori     USING (app_private.is_admin());

ALTER POLICY pol_produk_staff_select     ON public.produk       USING (app_private.is_staff());
ALTER POLICY pol_produk_admin_insert     ON public.produk       WITH CHECK (app_private.is_admin());
ALTER POLICY pol_produk_admin_update     ON public.produk       USING (app_private.is_admin()) WITH CHECK (app_private.is_admin());
ALTER POLICY pol_produk_admin_delete     ON public.produk       USING (app_private.is_admin());

ALTER POLICY pol_opsi_staff_select       ON public.opsi_produk  USING (app_private.is_staff());
ALTER POLICY pol_opsi_admin_insert       ON public.opsi_produk  WITH CHECK (app_private.is_admin());
ALTER POLICY pol_opsi_admin_update       ON public.opsi_produk  USING (app_private.is_admin()) WITH CHECK (app_private.is_admin());
ALTER POLICY pol_opsi_admin_delete       ON public.opsi_produk  USING (app_private.is_admin());

ALTER POLICY pol_banner_staff_select     ON public.banner_promo USING (app_private.is_staff());
ALTER POLICY pol_banner_admin_insert     ON public.banner_promo WITH CHECK (app_private.is_admin());
ALTER POLICY pol_banner_admin_update     ON public.banner_promo USING (app_private.is_admin()) WITH CHECK (app_private.is_admin());
ALTER POLICY pol_banner_admin_delete     ON public.banner_promo USING (app_private.is_admin());

ALTER POLICY pol_voucher_staff_select    ON public.voucher      USING (app_private.is_staff());
ALTER POLICY pol_voucher_admin_insert    ON public.voucher      WITH CHECK (app_private.is_admin());
ALTER POLICY pol_voucher_admin_update    ON public.voucher      USING (app_private.is_admin()) WITH CHECK (app_private.is_admin());
ALTER POLICY pol_voucher_admin_delete    ON public.voucher      USING (app_private.is_admin());

ALTER POLICY pol_pengaturan_staff_select ON public.pengaturan   USING (app_private.is_staff());
ALTER POLICY pol_pengaturan_admin_insert ON public.pengaturan   WITH CHECK (app_private.is_admin());
ALTER POLICY pol_pengaturan_admin_update ON public.pengaturan   USING (app_private.is_admin()) WITH CHECK (app_private.is_admin());
ALTER POLICY pol_pengaturan_admin_delete ON public.pengaturan   USING (app_private.is_admin());

-- Operasional: pengguna, member, pesanan, detail_pesanan, rating_pesanan, log_aktivitas
ALTER POLICY pol_pengguna_select         ON public.pengguna     USING (app_private.is_admin() OR auth_user_id = (SELECT auth.uid()));
ALTER POLICY pol_pengguna_admin_insert   ON public.pengguna     WITH CHECK (app_private.is_admin());
ALTER POLICY pol_pengguna_admin_update   ON public.pengguna     USING (app_private.is_admin()) WITH CHECK (app_private.is_admin());
ALTER POLICY pol_pengguna_admin_delete   ON public.pengguna     USING (app_private.is_admin());

ALTER POLICY pol_member_staff_select     ON public.member       USING (app_private.is_staff());
ALTER POLICY pol_member_staff_insert     ON public.member       WITH CHECK (app_private.is_staff());
ALTER POLICY pol_member_staff_update     ON public.member       USING (app_private.is_staff()) WITH CHECK (app_private.is_staff());
ALTER POLICY pol_member_admin_delete     ON public.member       USING (app_private.is_admin());

ALTER POLICY pol_pesanan_staff_select    ON public.pesanan      USING (app_private.is_staff());
ALTER POLICY pol_pesanan_staff_insert    ON public.pesanan      WITH CHECK (app_private.is_staff());
ALTER POLICY pol_pesanan_staff_update    ON public.pesanan      USING (app_private.is_staff()) WITH CHECK (app_private.is_staff());
ALTER POLICY pol_pesanan_admin_delete    ON public.pesanan      USING (app_private.is_admin());

ALTER POLICY pol_detail_staff_select     ON public.detail_pesanan USING (app_private.is_staff());
DROP POLICY IF EXISTS pol_detail_staff_insert ON public.detail_pesanan;
CREATE POLICY pol_detail_staff_insert ON public.detail_pesanan FOR INSERT TO authenticated WITH CHECK (app_private.is_staff());
ALTER POLICY pol_detail_staff_update     ON public.detail_pesanan USING (app_private.is_staff()) WITH CHECK (app_private.is_staff());
ALTER POLICY pol_detail_admin_delete     ON public.detail_pesanan USING (app_private.is_admin());

ALTER POLICY pol_rating_staff_select     ON public.rating_pesanan USING (app_private.is_staff());
DROP POLICY IF EXISTS pol_rating_staff_insert ON public.rating_pesanan;
CREATE POLICY pol_rating_staff_insert ON public.rating_pesanan FOR INSERT TO authenticated WITH CHECK (app_private.is_staff());
ALTER POLICY pol_rating_staff_update     ON public.rating_pesanan USING (app_private.is_staff()) WITH CHECK (app_private.is_staff());

ALTER POLICY pol_log_staff_select        ON public.log_aktivitas  USING (app_private.is_staff());
DROP POLICY IF EXISTS pol_log_staff_insert ON public.log_aktivitas;
CREATE POLICY pol_log_staff_insert ON public.log_aktivitas FOR INSERT TO authenticated WITH CHECK (app_private.is_staff());

-- Hapus helper RBAC publik yang menyebabkan lint warning 0029
DROP FUNCTION IF EXISTS public.is_admin();
DROP FUNCTION IF EXISTS public.is_staff();
DROP FUNCTION IF EXISTS public.current_app_role();


-- ─── 3. TUTUP LUBANG STORAGE OBJECTS (kiosk-assets) ───────────
DROP POLICY IF EXISTS pol_kiosk_assets_temp_upload  ON storage.objects;
DROP POLICY IF EXISTS pol_kiosk_assets_temp_update  ON storage.objects;
DROP POLICY IF EXISTS pol_kiosk_assets_admin_insert ON storage.objects;
DROP POLICY IF EXISTS pol_kiosk_assets_admin_update ON storage.objects;
DROP POLICY IF EXISTS pol_kiosk_assets_admin_delete ON storage.objects;

CREATE POLICY pol_kiosk_assets_admin_insert ON storage.objects
  FOR INSERT TO authenticated
  WITH CHECK (bucket_id = 'kiosk-assets' AND app_private.is_admin());

CREATE POLICY pol_kiosk_assets_admin_update ON storage.objects
  FOR UPDATE TO authenticated
  USING (bucket_id = 'kiosk-assets' AND app_private.is_admin())
  WITH CHECK (bucket_id = 'kiosk-assets' AND app_private.is_admin());

CREATE POLICY pol_kiosk_assets_admin_delete ON storage.objects
  FOR DELETE TO authenticated
  USING (bucket_id = 'kiosk-assets' AND app_private.is_admin());


-- ─── 4. HARDEN FUNGSI INTERNAL & COLUMN-LEVEL PRIVILEGE ───────
ALTER FUNCTION public.fn_ambil_kredensial_login(text) SET search_path = public, pg_temp;
ALTER FUNCTION public.fn_catat_login_gagal(text) SET search_path = public, pg_temp;
ALTER FUNCTION public.fn_reset_login(text) SET search_path = public, pg_temp;
ALTER FUNCTION public.fn_bersihkan_duplikat_internal() SET search_path = public, pg_temp;
ALTER FUNCTION public.fn_log_immutable() SET search_path = public, pg_temp;
ALTER FUNCTION public.fn_pengguna_guard_last_admin() SET search_path = public, pg_temp;

REVOKE ALL ON FUNCTION public.fn_ambil_kredensial_login(text) FROM PUBLIC, anon, authenticated;
REVOKE ALL ON FUNCTION public.fn_catat_login_gagal(text) FROM PUBLIC, anon, authenticated;
REVOKE ALL ON FUNCTION public.fn_reset_login(text) FROM PUBLIC, anon, authenticated;
REVOKE ALL ON FUNCTION public.fn_bersihkan_duplikat_internal() FROM PUBLIC, anon, authenticated;
REVOKE ALL ON FUNCTION public.fn_log_immutable() FROM PUBLIC, anon, authenticated;
REVOKE ALL ON FUNCTION public.fn_pengguna_guard_last_admin() FROM PUBLIC, anon, authenticated;

-- Column-level security pada public.pengguna:
-- authenticated (kasir/admin lewat Data API) TIDAK PERNAH bisa SELECT/UPDATE password_hash
REVOKE SELECT, INSERT, UPDATE ON public.pengguna FROM authenticated;
GRANT SELECT (id_pengguna, username, nama, role, aktif, email, auth_user_id) ON public.pengguna TO authenticated;
GRANT INSERT (username, password_hash, nama, role, aktif, email, auth_user_id) ON public.pengguna TO authenticated;
GRANT UPDATE (username, nama, role, aktif, email, auth_user_id) ON public.pengguna TO authenticated;


-- ─── 5. CHECK CONSTRAINTS INTEGRITAS DATA ─────────────────────
DO $$
BEGIN
  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'chk_pesanan_non_neg' AND connamespace = 'public'::regnamespace) THEN
    ALTER TABLE public.pesanan ADD CONSTRAINT chk_pesanan_non_neg
      CHECK (subtotal >= 0 AND diskon >= 0 AND pajak >= 0 AND total >= 0 AND poin_dipakai >= 0 AND poin_didapat >= 0);
  END IF;

  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'chk_pesanan_tipe_makan' AND connamespace = 'public'::regnamespace) THEN
    ALTER TABLE public.pesanan ADD CONSTRAINT chk_pesanan_tipe_makan
      CHECK (tipe_makan IN ('Dine In', 'DineIn', 'Take Away', 'TakeAway'));
  END IF;

  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'chk_pesanan_metode_bayar' AND connamespace = 'public'::regnamespace) THEN
    ALTER TABLE public.pesanan ADD CONSTRAINT chk_pesanan_metode_bayar
      CHECK (metode_bayar IN ('Tunai', 'QRIS', 'Kartu', 'E-Wallet', 'EWallet', 'Transfer'));
  END IF;

  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'chk_pesanan_status_bayar' AND connamespace = 'public'::regnamespace) THEN
    ALTER TABLE public.pesanan ADD CONSTRAINT chk_pesanan_status_bayar
      CHECK (status_bayar IN ('Belum', 'Lunas'));
  END IF;

  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'chk_pesanan_status_pesanan' AND connamespace = 'public'::regnamespace) THEN
    ALTER TABLE public.pesanan ADD CONSTRAINT chk_pesanan_status_pesanan
      CHECK (status_pesanan IN ('Menunggu Pembayaran', 'Diproses', 'Siap', 'Selesai', 'Dibatalkan'));
  END IF;

  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'chk_detail_non_neg' AND connamespace = 'public'::regnamespace) THEN
    ALTER TABLE public.detail_pesanan ADD CONSTRAINT chk_detail_non_neg
      CHECK (harga_satuan >= 0 AND subtotal >= 0);
  END IF;

  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'chk_member_poin_non_neg' AND connamespace = 'public'::regnamespace) THEN
    ALTER TABLE public.member ADD CONSTRAINT chk_member_poin_non_neg
      CHECK (poin >= 0);
  END IF;

  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'chk_voucher_min_non_neg' AND connamespace = 'public'::regnamespace) THEN
    ALTER TABLE public.voucher ADD CONSTRAINT chk_voucher_min_non_neg
      CHECK (min_belanja >= 0);
  END IF;
END $$;


-- ─── 6. TRIGGERS STATE MACHINE & AUDIT OTOMATIS ───────────────

-- 6a. State Machine Transisi Status Pesanan
CREATE OR REPLACE FUNCTION public.fn_pesanan_state_machine()
RETURNS trigger
LANGUAGE plpgsql
SET search_path = public, pg_temp
AS $$
BEGIN
  IF NEW.status_pesanan IS DISTINCT FROM OLD.status_pesanan THEN
    IF OLD.status_pesanan = 'Menunggu Pembayaran' AND NEW.status_pesanan NOT IN ('Diproses', 'Dibatalkan') THEN
      RAISE EXCEPTION 'Transisi status tidak valid: "%" -> "%"', OLD.status_pesanan, NEW.status_pesanan;
    ELSIF OLD.status_pesanan = 'Diproses' AND NEW.status_pesanan NOT IN ('Siap', 'Dibatalkan') THEN
      RAISE EXCEPTION 'Transisi status tidak valid: "%" -> "%"', OLD.status_pesanan, NEW.status_pesanan;
    ELSIF OLD.status_pesanan = 'Siap' AND NEW.status_pesanan <> 'Selesai' THEN
      RAISE EXCEPTION 'Transisi status tidak valid: "%" -> "%"', OLD.status_pesanan, NEW.status_pesanan;
    ELSIF OLD.status_pesanan IN ('Selesai', 'Dibatalkan') THEN
      RAISE EXCEPTION 'Pesanan berstatus "%" sudah final dan tidak dapat diubah lagi.', OLD.status_pesanan;
    END IF;

    IF NEW.status_pesanan = 'Diproses' AND NEW.waktu_diproses IS NULL THEN
      NEW.waktu_diproses := (NOW() AT TIME ZONE 'Asia/Jakarta');
    ELSIF NEW.status_pesanan = 'Siap' AND NEW.waktu_siap IS NULL THEN
      NEW.waktu_siap := (NOW() AT TIME ZONE 'Asia/Jakarta');
    END IF;
  END IF;
  RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_pesanan_state_machine ON public.pesanan;
CREATE TRIGGER trg_pesanan_state_machine
  BEFORE UPDATE OF status_pesanan ON public.pesanan
  FOR EACH ROW
  EXECUTE FUNCTION public.fn_pesanan_state_machine();

-- 6b. Normalisasi kode voucher selalu UPPERCASE & TRIM
CREATE OR REPLACE FUNCTION public.fn_voucher_normalize()
RETURNS trigger
LANGUAGE plpgsql
SET search_path = public, pg_temp
AS $$
BEGIN
  NEW.kode := UPPER(BTRIM(NEW.kode));
  IF NEW.kode = '' THEN
    RAISE EXCEPTION 'Kode voucher tidak boleh kosong.';
  END IF;
  RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_voucher_normalize ON public.voucher;
CREATE TRIGGER trg_voucher_normalize
  BEFORE INSERT OR UPDATE ON public.voucher
  FOR EACH ROW
  EXECUTE FUNCTION public.fn_voucher_normalize();

-- 6c. Validasi rating: pesanan harus ada & tidak dibatalkan
CREATE OR REPLACE FUNCTION public.fn_rating_validasi_pesanan()
RETURNS trigger
LANGUAGE plpgsql
SET search_path = public, pg_temp
AS $$
DECLARE
  v_status text;
BEGIN
  SELECT status_pesanan INTO v_status FROM public.pesanan WHERE id_pesanan = NEW.id_pesanan;
  IF NOT FOUND THEN
    RAISE EXCEPTION 'Pesanan ID % tidak ditemukan.', NEW.id_pesanan;
  END IF;
  IF v_status = 'Dibatalkan' THEN
    RAISE EXCEPTION 'Pesanan yang dibatalkan tidak dapat diberi rating.';
  END IF;
  RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_rating_validasi_pesanan ON public.rating_pesanan;
CREATE TRIGGER trg_rating_validasi_pesanan
  BEFORE INSERT OR UPDATE ON public.rating_pesanan
  FOR EACH ROW
  EXECUTE FUNCTION public.fn_rating_validasi_pesanan();

-- 6d. Audit otomatis perubahan harga/status produk di server
CREATE OR REPLACE FUNCTION public.fn_produk_audit_perubahan()
RETURNS trigger
LANGUAGE plpgsql
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
DECLARE
  v_ket text := '';
  v_uid int := app_private.my_pengguna_id();
BEGIN
  IF NEW.harga IS DISTINCT FROM OLD.harga OR NEW.tersedia IS DISTINCT FROM OLD.tersedia THEN
    v_ket := FORMAT('DB Audit Produk #%s (%s): ', NEW.id_produk, NEW.nama);
    IF NEW.harga IS DISTINCT FROM OLD.harga THEN
      v_ket := v_ket || FORMAT('harga %s -> %s; ', OLD.harga, NEW.harga);
    END IF;
    IF NEW.tersedia IS DISTINCT FROM OLD.tersedia THEN
      v_ket := v_ket || FORMAT('tersedia %s -> %s;', OLD.tersedia, NEW.tersedia);
    END IF;
    INSERT INTO public.log_aktivitas (id_pengguna, aksi, keterangan)
    VALUES (v_uid, 'PRODUK_AUDIT_DB', BTRIM(v_ket));
  END IF;
  RETURN NEW;
END;
$$;

REVOKE ALL ON FUNCTION public.fn_pesanan_state_machine() FROM PUBLIC, anon, authenticated;
REVOKE ALL ON FUNCTION public.fn_voucher_normalize() FROM PUBLIC, anon, authenticated;
REVOKE ALL ON FUNCTION public.fn_rating_validasi_pesanan() FROM PUBLIC, anon, authenticated;
REVOKE ALL ON FUNCTION public.fn_produk_audit_perubahan() FROM PUBLIC, anon, authenticated;

DROP TRIGGER IF EXISTS trg_produk_audit_perubahan ON public.produk;
CREATE TRIGGER trg_produk_audit_perubahan
  AFTER UPDATE OF harga, tersedia ON public.produk
  FOR EACH ROW
  EXECUTE FUNCTION public.fn_produk_audit_perubahan();


-- ─── 7. ANALYTICS VIEWS (WITH security_invoker = true) ─────────
CREATE OR REPLACE VIEW public.v_ringkasan_harian
WITH (security_invoker = true)
AS
SELECT
  tanggal::date AS tanggal,
  COUNT(*)::int AS total_order,
  COUNT(*) FILTER (WHERE status_bayar = 'Lunas' AND status_pesanan <> 'Dibatalkan')::int AS order_lunas,
  COUNT(*) FILTER (WHERE status_pesanan = 'Dibatalkan')::int AS order_batal,
  COALESCE(SUM(total) FILTER (WHERE status_bayar = 'Lunas' AND status_pesanan <> 'Dibatalkan'), 0)::numeric(14,0) AS total_omzet,
  COALESCE(
    ROUND(AVG(total) FILTER (WHERE status_bayar = 'Lunas' AND status_pesanan <> 'Dibatalkan'), 0),
    0
  )::numeric(14,0) AS rata_rata_order
FROM public.pesanan
GROUP BY tanggal::date;

CREATE OR REPLACE VIEW public.v_menu_terlaris
WITH (security_invoker = true)
AS
SELECT
  d.id_produk,
  d.nama_produk,
  COALESCE(k.nama, '-') AS nama_kategori,
  SUM(d.qty)::int AS total_qty,
  COALESCE(SUM(d.subtotal), 0)::numeric(14,0) AS total_omzet
FROM public.detail_pesanan d
INNER JOIN public.pesanan p ON p.id_pesanan = d.id_pesanan
LEFT JOIN public.produk pr ON pr.id_produk = d.id_produk
LEFT JOIN public.kategori k ON k.id_kategori = pr.id_kategori
WHERE p.status_bayar = 'Lunas'
  AND p.status_pesanan <> 'Dibatalkan'
GROUP BY d.id_produk, d.nama_produk, k.nama;

CREATE OR REPLACE VIEW public.v_performa_dapur
WITH (security_invoker = true)
AS
SELECT
  COALESCE(AVG(GREATEST(1.0, EXTRACT(EPOCH FROM (waktu_siap - waktu_diproses)) / 60.0))
    FILTER (WHERE waktu_diproses IS NOT NULL AND waktu_siap IS NOT NULL), 0.0)::double precision AS rata_menit,
  COUNT(*) FILTER (WHERE status_pesanan IN ('Siap', 'Selesai'))::int AS selesai_hari_ini,
  COALESCE(MAX(GREATEST(0.0, EXTRACT(EPOCH FROM ((NOW() AT TIME ZONE 'Asia/Jakarta') - waktu_diproses)) / 60.0))
    FILTER (WHERE status_pesanan = 'Diproses' AND waktu_diproses IS NOT NULL), 0.0)::double precision AS terlama_menit
FROM public.pesanan
WHERE tanggal::date = (NOW() AT TIME ZONE 'Asia/Jakarta')::date;

REVOKE ALL ON public.v_ringkasan_harian, public.v_menu_terlaris, public.v_performa_dapur FROM PUBLIC, anon;
GRANT SELECT ON public.v_ringkasan_harian, public.v_menu_terlaris, public.v_performa_dapur TO authenticated;


-- ─── 8. RPC TRANSAKSIONAL & DATA API (PERTEMUAN 13 READY) ──────

-- 8a. Profil pengguna aktif berdasarkan JWT auth.uid() (SECURITY INVOKER!)
CREATE OR REPLACE FUNCTION public.fn_profil_saya()
RETURNS TABLE (
  id_pengguna int,
  username varchar,
  nama varchar,
  role varchar,
  aktif boolean,
  email varchar
)
LANGUAGE sql
STABLE
SECURITY INVOKER
SET search_path = public, pg_temp
AS $$
  SELECT id_pengguna, username, nama, role, aktif, email
  FROM public.pengguna
  WHERE auth_user_id = (SELECT auth.uid())
    AND aktif = TRUE
  LIMIT 1;
$$;
REVOKE ALL ON FUNCTION public.fn_profil_saya() FROM PUBLIC, anon;
GRANT EXECUTE ON FUNCTION public.fn_profil_saya() TO authenticated;

-- 8b. Rekap Kategori x Hari untuk Laporan (SECURITY INVOKER!)
CREATE OR REPLACE FUNCTION public.fn_laporan_rekap_kategori(p_tgl_dari date, p_tgl_sampai date)
RETURNS TABLE (
  id_kategori int,
  tgl date,
  total_sub numeric
)
LANGUAGE sql
STABLE
SECURITY INVOKER
SET search_path = public, pg_temp
AS $$
  SELECT pr.id_kategori, p.tanggal::date AS tgl, COALESCE(SUM(d.subtotal), 0)::numeric AS total_sub
  FROM public.detail_pesanan d
  INNER JOIN public.pesanan p ON p.id_pesanan = d.id_pesanan
  INNER JOIN public.produk pr ON pr.id_produk = d.id_produk
  WHERE p.tanggal::date BETWEEN p_tgl_dari AND p_tgl_sampai
    AND p.status_bayar = 'Lunas'
    AND p.status_pesanan <> 'Dibatalkan'
  GROUP BY pr.id_kategori, p.tanggal::date;
$$;
REVOKE ALL ON FUNCTION public.fn_laporan_rekap_kategori(date, date) FROM PUBLIC, anon;
GRANT EXECUTE ON FUNCTION public.fn_laporan_rekap_kategori(date, date) TO authenticated;

-- 8c. Menu terlaris terfilter tanggal (SECURITY INVOKER!)
CREATE OR REPLACE FUNCTION public.fn_laporan_menu_terlaris(p_tgl_dari date DEFAULT NULL, p_tgl_sampai date DEFAULT NULL, p_batas int DEFAULT 10)
RETURNS TABLE (
  nama_produk varchar,
  total_qty int,
  total_omzet numeric
)
LANGUAGE sql
STABLE
SECURITY INVOKER
SET search_path = public, pg_temp
AS $$
  SELECT d.nama_produk, SUM(d.qty)::int AS total_qty, COALESCE(SUM(d.subtotal), 0)::numeric AS total_omzet
  FROM public.detail_pesanan d
  INNER JOIN public.pesanan p ON p.id_pesanan = d.id_pesanan
  WHERE p.status_bayar = 'Lunas'
    AND p.status_pesanan <> 'Dibatalkan'
    AND (p_tgl_dari IS NULL OR p.tanggal::date >= p_tgl_dari)
    AND (p_tgl_sampai IS NULL OR p.tanggal::date <= p_tgl_sampai)
  GROUP BY d.nama_produk
  ORDER BY total_qty DESC, total_omzet DESC
  LIMIT GREATEST(1, COALESCE(p_batas, 10));
$$;
REVOKE ALL ON FUNCTION public.fn_laporan_menu_terlaris(date, date, int) FROM PUBLIC, anon;
GRANT EXECUTE ON FUNCTION public.fn_laporan_menu_terlaris(date, date, int) TO authenticated;

-- 8d. Statistik jam sibuk dapur hari ini (SECURITY INVOKER!)
CREATE OR REPLACE FUNCTION public.fn_dapur_pesanan_per_jam()
RETURNS TABLE (jam int, jml int)
LANGUAGE sql
STABLE
SECURITY INVOKER
SET search_path = public, pg_temp
AS $$
  SELECT EXTRACT(HOUR FROM tanggal)::int AS jam, COUNT(*)::int AS jml
  FROM public.pesanan
  WHERE tanggal::date = (NOW() AT TIME ZONE 'Asia/Jakarta')::date
  GROUP BY EXTRACT(HOUR FROM tanggal)::int
  ORDER BY jam;
$$;
REVOKE ALL ON FUNCTION public.fn_dapur_pesanan_per_jam() FROM PUBLIC, anon;
GRANT EXECUTE ON FUNCTION public.fn_dapur_pesanan_per_jam() TO authenticated;

-- 8e. Konfirmasi pembayaran tunai oleh Kasir/Admin (SECURITY INVOKER!)
CREATE OR REPLACE FUNCTION public.fn_staff_konfirmasi_tunai(p_id_pesanan int, p_uang_bayar numeric)
RETURNS boolean
LANGUAGE plpgsql
SECURITY INVOKER
SET search_path = public, pg_temp
AS $$
DECLARE
  v_status text;
  v_metode text;
  v_total numeric;
  v_id_member int;
  v_poin_didapat int;
  v_kembalian numeric;
  v_kasir int;
BEGIN
  IF NOT app_private.is_staff() THEN
    RAISE EXCEPTION 'Akses ditolak: hanya staf yang berwenang.';
  END IF;

  SELECT status_pesanan, metode_bayar, total, id_member, poin_didapat
  INTO v_status, v_metode, v_total, v_id_member, v_poin_didapat
  FROM public.pesanan
  WHERE id_pesanan = p_id_pesanan
  FOR UPDATE;

  IF NOT FOUND THEN
    RETURN FALSE;
  END IF;

  IF LOWER(v_status) <> LOWER('Menunggu Pembayaran')
     OR LOWER(v_metode) <> 'tunai'
     OR p_uang_bayar < v_total THEN
    RETURN FALSE;
  END IF;

  v_kembalian := GREATEST(0, p_uang_bayar - v_total);
  v_kasir := app_private.my_pengguna_id();

  UPDATE public.pesanan
  SET status_bayar = 'Lunas',
      status_pesanan = 'Diproses',
      id_kasir = v_kasir,
      uang_bayar = p_uang_bayar,
      kembalian = v_kembalian,
      waktu_diproses = (NOW() AT TIME ZONE 'Asia/Jakarta')
  WHERE id_pesanan = p_id_pesanan;

  IF v_id_member IS NOT NULL AND COALESCE(v_poin_didapat, 0) > 0 THEN
    UPDATE public.member SET poin = poin + v_poin_didapat WHERE id_member = v_id_member;
  END IF;

  INSERT INTO public.log_aktivitas (id_pengguna, aksi, keterangan)
  VALUES (v_kasir, 'BAYAR_TUNAI', FORMAT('Konfirmasi bayar tunai pesanan #%s (%s)', p_id_pesanan, p_uang_bayar));

  RETURN TRUE;
END;
$$;
REVOKE ALL ON FUNCTION public.fn_staff_konfirmasi_tunai(int, numeric) FROM PUBLIC, anon;
GRANT EXECUTE ON FUNCTION public.fn_staff_konfirmasi_tunai(int, numeric) TO authenticated;

-- 8f. Kiosk RPCs (dipanggil oleh Kiosk self-service lewat anon key maupun authenticated)
-- Catatan: dibungkus ke schema `public` dengan validasi penuh & batasan minimum.

CREATE OR REPLACE FUNCTION public.fn_kiosk_cari_member(p_no_hp text)
RETURNS TABLE (id_member int, no_hp varchar, nama varchar, poin int)
LANGUAGE sql
STABLE
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
  SELECT id_member, no_hp, nama, poin
  FROM public.member
  WHERE no_hp = BTRIM(COALESCE(p_no_hp, ''))
  LIMIT 1;
$$;
REVOKE ALL ON FUNCTION public.fn_kiosk_cari_member(text) FROM PUBLIC;
GRANT EXECUTE ON FUNCTION public.fn_kiosk_cari_member(text) TO anon, authenticated;

CREATE OR REPLACE FUNCTION public.fn_kiosk_daftar_member(p_no_hp text, p_nama text)
RETURNS TABLE (id_member int, no_hp varchar, nama varchar, poin int)
LANGUAGE plpgsql
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
DECLARE
  v_hp text := BTRIM(COALESCE(p_no_hp, ''));
  v_nama text := BTRIM(COALESCE(p_nama, ''));
BEGIN
  IF v_hp = '' OR v_nama = '' THEN
    RAISE EXCEPTION 'Nomor HP dan nama member wajib diisi.';
  END IF;
  RETURN QUERY
  INSERT INTO public.member (no_hp, nama, poin)
  VALUES (v_hp, v_nama, 0)
  ON CONFLICT (no_hp) DO UPDATE SET nama = EXCLUDED.nama
  RETURNING member.id_member, member.no_hp, member.nama, member.poin;
END;
$$;
REVOKE ALL ON FUNCTION public.fn_kiosk_daftar_member(text, text) FROM PUBLIC;
GRANT EXECUTE ON FUNCTION public.fn_kiosk_daftar_member(text, text) TO anon, authenticated;

CREATE OR REPLACE FUNCTION public.fn_kiosk_antrian_publik()
RETURNS TABLE (
  id_pesanan int,
  no_antrian int,
  tipe_makan varchar,
  status_pesanan varchar,
  waktu_diproses timestamp,
  waktu_siap timestamp
)
LANGUAGE sql
STABLE
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
  SELECT id_pesanan, no_antrian, tipe_makan, status_pesanan, waktu_diproses, waktu_siap
  FROM public.pesanan
  WHERE tanggal::date = (NOW() AT TIME ZONE 'Asia/Jakarta')::date
    AND status_pesanan IN ('Menunggu Pembayaran', 'Diproses', 'Siap')
  ORDER BY no_antrian ASC;
$$;
REVOKE ALL ON FUNCTION public.fn_kiosk_antrian_publik() FROM PUBLIC;
GRANT EXECUTE ON FUNCTION public.fn_kiosk_antrian_publik() TO anon, authenticated;

CREATE OR REPLACE FUNCTION public.fn_kiosk_beri_rating(p_id_pesanan int, p_bintang int, p_komentar text DEFAULT '')
RETURNS void
LANGUAGE plpgsql
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
BEGIN
  IF p_bintang < 1 OR p_bintang > 5 THEN
    RAISE EXCEPTION 'Rating bintang harus bernilai 1 sampai 5.';
  END IF;
  INSERT INTO public.rating_pesanan (id_pesanan, bintang, komentar)
  VALUES (p_id_pesanan, p_bintang, NULLIF(BTRIM(COALESCE(p_komentar, '')), ''))
  ON CONFLICT (id_pesanan) DO UPDATE
    SET bintang = EXCLUDED.bintang,
        komentar = EXCLUDED.komentar;
END;
$$;
REVOKE ALL ON FUNCTION public.fn_kiosk_beri_rating(int, int, text) FROM PUBLIC;
GRANT EXECUTE ON FUNCTION public.fn_kiosk_beri_rating(int, int, text) TO anon, authenticated;

CREATE OR REPLACE FUNCTION public.fn_staff_ubah_status_pesanan(p_id_pesanan int, p_status_baru text)
RETURNS boolean
LANGUAGE plpgsql
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
DECLARE
  v_status text;
  v_uid int := app_private.my_pengguna_id();
BEGIN
  IF NOT app_private.is_staff() THEN
    RAISE EXCEPTION 'Akses ditolak: hanya staf yang berwenang.';
  END IF;

  SELECT status_pesanan INTO v_status FROM public.pesanan WHERE id_pesanan = p_id_pesanan FOR UPDATE;
  IF NOT FOUND THEN RETURN FALSE; END IF;

  -- Validasi & auto-timestamp dikerjakan trigger trg_pesanan_state_machine
  UPDATE public.pesanan SET status_pesanan = p_status_baru WHERE id_pesanan = p_id_pesanan;

  IF LOWER(p_status_baru) = 'dibatalkan' THEN
    UPDATE public.produk pr
    SET stok = pr.stok + d.qty_sum,
        tersedia = TRUE
    FROM (
      SELECT id_produk, SUM(qty)::int AS qty_sum
      FROM public.detail_pesanan
      WHERE id_pesanan = p_id_pesanan
      GROUP BY id_produk
    ) d
    WHERE pr.id_produk = d.id_produk AND pr.stok IS NOT NULL;
  END IF;

  INSERT INTO public.log_aktivitas (id_pengguna, aksi, keterangan)
  VALUES (v_uid, CASE WHEN LOWER(p_status_baru) = 'dibatalkan' THEN 'PESANAN_BATAL' ELSE 'STATUS_UBAH' END,
          FORMAT('Status pesanan #%s: %s -> %s', p_id_pesanan, v_status, p_status_baru));
  RETURN TRUE;
EXCEPTION
  WHEN raise_exception THEN
    RETURN FALSE;
END;
$$;
REVOKE ALL ON FUNCTION public.fn_staff_ubah_status_pesanan(int, text) FROM PUBLIC, anon;
GRANT EXECUTE ON FUNCTION public.fn_staff_ubah_status_pesanan(int, text) TO authenticated;

CREATE OR REPLACE FUNCTION public.fn_kiosk_buat_pesanan(
  p_tipe_makan text,
  p_metode_bayar text,
  p_kode_voucher text DEFAULT NULL,
  p_id_member int DEFAULT NULL,
  p_poin_dipakai int DEFAULT 0,
  p_uang_bayar numeric DEFAULT NULL,
  p_items jsonb DEFAULT '[]'::jsonb
)
RETURNS TABLE (
  id_pesanan int,
  no_antrian int,
  subtotal numeric,
  diskon numeric,
  pajak numeric,
  total numeric,
  poin_dipakai int,
  poin_didapat int
)
LANGUAGE plpgsql
SECURITY DEFINER
SET search_path = public, pg_temp
AS $$
DECLARE
  v_elem jsonb;
  v_id_prod int;
  v_qty int;
  v_opsi_txt text;
  v_catatan text;
  v_prod record;
  v_tambahan_opsi numeric := 0;
  v_harga_satuan numeric := 0;
  v_sub_item numeric := 0;
  v_subtotal numeric := 0;
  v_diskon_bertingkat numeric := 0;
  v_diskon_voucher numeric := 0;
  v_diskon_poin numeric := 0;
  v_total_diskon numeric := 0;
  v_pajak numeric := 0;
  v_total numeric := 0;
  v_pajak_persen numeric := 11;
  v_nilai_poin numeric := 100;
  v_poin_per_rupiah numeric := 10000;
  v_poin_tersedia int := 0;
  v_poin_efektif int := 0;
  v_poin_maks int := 0;
  v_poin_didapat int := 0;
  v_kode_v text := UPPER(BTRIM(COALESCE(p_kode_voucher, '')));
  v_v record;
  v_today date := (NOW() AT TIME ZONE 'Asia/Jakarta')::date;
  v_no_antrian int;
  v_id_pesanan int;
  v_is_tunai boolean := (LOWER(COALESCE(p_metode_bayar, '')) = 'tunai');
  v_status_bayar text;
  v_status_pesanan text;
  v_kembalian numeric := NULL;
  v_kasir int := app_private.my_pengguna_id();
BEGIN
  IF p_items IS NULL OR jsonb_typeof(p_items) <> 'array' OR jsonb_array_length(p_items) = 0 THEN
    RAISE EXCEPTION 'Keranjang masih kosong.';
  END IF;

  PERFORM pg_advisory_xact_lock(1234567890);

  SELECT COALESCE((SELECT NULLIF(nilai,'')::numeric FROM public.pengaturan WHERE kunci = 'pajak_persen'), 11),
         COALESCE((SELECT NULLIF(nilai,'')::numeric FROM public.pengaturan WHERE kunci = 'nilai_poin'), 100),
         COALESCE((SELECT NULLIF(nilai,'')::numeric FROM public.pengaturan WHERE kunci = 'poin_per_rupiah'), 10000)
  INTO v_pajak_persen, v_nilai_poin, v_poin_per_rupiah;

  -- Pass 1: Kunci & validasi produk + hitung subtotal server-side dari DB
  CREATE TEMP TABLE _tmp_items_pesanan (
    id_produk int,
    nama_produk varchar(100),
    qty int,
    harga_satuan numeric(12,0),
    opsi_dipilih text,
    catatan varchar(200),
    subtotal numeric(12,0)
  ) ON COMMIT DROP;

  FOR v_elem IN SELECT * FROM jsonb_array_elements(p_items)
  LOOP
    v_id_prod := (v_elem->>'id_produk')::int;
    v_qty := GREATEST(1, LEAST(20, COALESCE((v_elem->>'qty')::int, 1)));
    v_opsi_txt := COALESCE(v_elem->>'opsi_dipilih', '');
    v_catatan := LEFT(COALESCE(v_elem->>'catatan', ''), 200);

    SELECT p.id_produk, p.nama, p.harga, p.tersedia, p.stok
    INTO v_prod
    FROM public.produk p
    WHERE p.id_produk = v_id_prod
    FOR UPDATE;

    IF NOT FOUND THEN
      RAISE EXCEPTION 'Menu ID % tidak ditemukan di database.', v_id_prod;
    END IF;
    IF NOT v_prod.tersedia THEN
      RAISE EXCEPTION 'Menu "%" sedang tidak tersedia.', v_prod.nama;
    END IF;
    IF v_prod.stok IS NOT NULL AND v_prod.stok < v_qty THEN
      RAISE EXCEPTION 'Stok "%" tidak cukup (tersisa %).', v_prod.nama, v_prod.stok;
    END IF;

    -- Cocokkan opsi yang dipilih terhadap opsi_produk di database
    SELECT COALESCE(SUM(o.tambahan_harga), 0)
    INTO v_tambahan_opsi
    FROM public.opsi_produk o
    WHERE o.id_produk = v_prod.id_produk
      AND v_opsi_txt <> ''
      AND o.nama_opsi = ANY(
        SELECT BTRIM(x) FROM unnest(string_to_array(v_opsi_txt, ',')) AS x
      );

    v_harga_satuan := ROUND(v_prod.harga + v_tambahan_opsi, 0);
    v_sub_item := v_harga_satuan * v_qty;
    v_subtotal := v_subtotal + v_sub_item;

    INSERT INTO _tmp_items_pesanan VALUES (
      v_prod.id_produk, v_prod.nama, v_qty, v_harga_satuan,
      NULLIF(BTRIM(v_opsi_txt), ''), NULLIF(BTRIM(v_catatan), ''), v_sub_item
    );
  END LOOP;

  -- Diskon bertingkat otomatis
  IF v_subtotal >= 300000 THEN
    v_diskon_bertingkat := ROUND(v_subtotal * 0.15, 0);
  ELSIF v_subtotal >= 200000 THEN
    v_diskon_bertingkat := ROUND(v_subtotal * 0.10, 0);
  ELSIF v_subtotal >= 100000 THEN
    v_diskon_bertingkat := ROUND(v_subtotal * 0.05, 0);
  END IF;

  -- Validasi voucher server-side
  IF v_kode_v <> '' THEN
    SELECT kode, jenis, nilai, min_belanja, tgl_mulai, tgl_akhir, aktif
    INTO v_v
    FROM public.voucher
    WHERE kode = v_kode_v
    FOR UPDATE;

    IF NOT FOUND OR NOT v_v.aktif OR v_today < v_v.tgl_mulai OR v_today > v_v.tgl_akhir THEN
      RAISE EXCEPTION 'Voucher "%" tidak valid atau sudah kadaluarsa.', v_kode_v;
    END IF;
    IF v_subtotal < v_v.min_belanja THEN
      RAISE EXCEPTION 'Belanja minimal untuk voucher "%" adalah Rp%.', v_kode_v, v_v.min_belanja;
    END IF;

    IF LOWER(v_v.jenis) = 'persen' THEN
      v_diskon_voucher := ROUND(v_subtotal * (v_v.nilai / 100.0), 0);
    ELSE
      v_diskon_voucher := ROUND(v_v.nilai, 0);
    END IF;
  ELSE
    v_kode_v := NULL;
  END IF;

  -- Validasi member & poin
  IF p_id_member IS NOT NULL THEN
    SELECT poin INTO v_poin_tersedia FROM public.member WHERE id_member = p_id_member FOR UPDATE;
    IF NOT FOUND THEN
      RAISE EXCEPTION 'Member ID % tidak ditemukan.', p_id_member;
    END IF;
    IF COALESCE(p_poin_dipakai, 0) > 0 AND v_nilai_poin > 0 THEN
      v_poin_maks := FLOOR(GREATEST(0, FLOOR(v_subtotal * 0.5) - v_diskon_bertingkat - v_diskon_voucher) / v_nilai_poin)::int;
      v_poin_efektif := GREATEST(0, LEAST(p_poin_dipakai, v_poin_tersedia, v_poin_maks));
      v_diskon_poin := v_poin_efektif * v_nilai_poin;
    END IF;
  END IF;

  v_total_diskon := v_diskon_bertingkat + v_diskon_voucher + v_diskon_poin;
  v_pajak := ROUND(GREATEST(0, v_subtotal - v_total_diskon) * (v_pajak_persen / 100.0), 0);
  v_total := GREATEST(0, v_subtotal - v_total_diskon) + v_pajak;

  IF p_id_member IS NOT NULL AND v_poin_per_rupiah > 0 THEN
    v_poin_didapat := FLOOR(v_total / v_poin_per_rupiah)::int;
  END IF;

  SELECT COALESCE(MAX(p.no_antrian), 0) + 1
  INTO v_no_antrian
  FROM public.pesanan p
  WHERE p.tanggal::date = v_today;

  v_status_bayar := CASE WHEN v_is_tunai THEN 'Belum' ELSE 'Lunas' END;
  v_status_pesanan := CASE WHEN v_is_tunai THEN 'Menunggu Pembayaran' ELSE 'Diproses' END;
  IF v_is_tunai AND p_uang_bayar IS NOT NULL AND p_uang_bayar >= v_total THEN
    v_kembalian := GREATEST(0, p_uang_bayar - v_total);
  END IF;

  INSERT INTO public.pesanan (
    no_antrian, tipe_makan, subtotal, diskon, pajak, total, metode_bayar,
    status_bayar, status_pesanan, id_kasir, kode_voucher, id_member,
    poin_dipakai, poin_didapat, uang_bayar, kembalian, waktu_diproses
  ) VALUES (
    v_no_antrian, p_tipe_makan, v_subtotal, v_total_diskon, v_pajak, v_total, p_metode_bayar,
    v_status_bayar, v_status_pesanan, v_kasir, v_kode_v, p_id_member,
    v_poin_efektif, v_poin_didapat, p_uang_bayar, v_kembalian,
    CASE WHEN v_is_tunai THEN NULL ELSE (NOW() AT TIME ZONE 'Asia/Jakarta') END
  )
  RETURNING pesanan.id_pesanan INTO v_id_pesanan;

  INSERT INTO public.detail_pesanan (
    id_pesanan, id_produk, nama_produk, qty, harga_satuan, opsi_dipilih, catatan, subtotal
  )
  SELECT v_id_pesanan, t.id_produk, t.nama_produk, t.qty, t.harga_satuan, t.opsi_dipilih, t.catatan, t.subtotal
  FROM _tmp_items_pesanan t;

  UPDATE public.produk pr
  SET stok = GREATEST(0, pr.stok - d.qty_sum),
      tersedia = CASE WHEN pr.stok - d.qty_sum <= 0 THEN FALSE ELSE pr.tersedia END
  FROM (
    SELECT t.id_produk, SUM(t.qty)::int AS qty_sum
    FROM _tmp_items_pesanan t
    GROUP BY t.id_produk
  ) d
  WHERE pr.id_produk = d.id_produk AND pr.stok IS NOT NULL;

  IF p_id_member IS NOT NULL AND NOT v_is_tunai THEN
    UPDATE public.member
    SET poin = GREATEST(0, poin - v_poin_efektif + v_poin_didapat)
    WHERE id_member = p_id_member;
  END IF;

  INSERT INTO public.log_aktivitas (id_pengguna, aksi, keterangan)
  VALUES (v_kasir, 'PESANAN_BARU', FORMAT('Pesanan #%s (%s) total Rp%s', LPAD(v_no_antrian::text, 3, '0'), p_metode_bayar, v_total));

  RETURN QUERY SELECT v_id_pesanan, v_no_antrian, v_subtotal, v_total_diskon, v_pajak, v_total, v_poin_efektif, v_poin_didapat;
END;
$$;
REVOKE ALL ON FUNCTION public.fn_kiosk_buat_pesanan(text, text, text, int, int, numeric, jsonb) FROM PUBLIC;
GRANT EXECUTE ON FUNCTION public.fn_kiosk_buat_pesanan(text, text, text, int, int, numeric, jsonb) TO anon, authenticated;

COMMIT;
