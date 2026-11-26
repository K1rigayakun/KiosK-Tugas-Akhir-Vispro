-- =============================================================
-- Migration 03b: RLS RBAC Minimum Privilege per-command
-- Project  : Bistro Kiosk Nusantara
-- Applied  : 2026-11-26
-- Supabase : eszvojtlvfqyuxigkjcc
-- =============================================================
-- STEP 1 (via apply_migration 03b_01_revoke_grant):
--   Revoke all existing grants; then re-grant minimum privilege.
-- STEP 2 (manual via SQL Editor if apply_migration blocked):
--   Drop all old permissive policies.
-- STEP 3 (via apply_migration 03b_03_policy_katalog):
--   Create new granular policies for catalogue tables.
-- STEP 4 (via apply_migration 03b_04_policy_operasional):
--   Create new granular policies for operational tables.
-- =============================================================

-- ─── STEP 1: REVOKE ALL & GRANT MINIMUM PRIVILEGE ─────────────
REVOKE ALL ON ALL TABLES IN SCHEMA public FROM PUBLIC, anon, authenticated;
REVOKE ALL ON ALL SEQUENCES IN SCHEMA public FROM PUBLIC, anon, authenticated;

-- anon: read-only on public catalogue
GRANT SELECT ON public.kategori, public.produk, public.opsi_produk,
               public.banner_promo, public.voucher, public.pengaturan
  TO anon;

-- authenticated: CRUD on operational tables (further restricted by RLS)
GRANT SELECT, INSERT, UPDATE, DELETE
  ON public.kategori, public.produk, public.opsi_produk,
     public.banner_promo, public.voucher, public.pengaturan,
     public.pengguna, public.member, public.pesanan, public.detail_pesanan
  TO authenticated;
GRANT SELECT, INSERT ON public.log_aktivitas TO authenticated;
GRANT SELECT, INSERT, UPDATE ON public.rating_pesanan TO authenticated;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO authenticated;


-- ─── STEP 2: DROP OLD PERMISSIVE POLICIES ─────────────────────
-- (Run these manually in SQL Editor if apply_migration is blocked by auto-cancel)
DROP POLICY IF EXISTS pol_banner_all       ON public.banner_promo;
DROP POLICY IF EXISTS pol_banner_baca      ON public.banner_promo;
DROP POLICY IF EXISTS pol_detail_all       ON public.detail_pesanan;
DROP POLICY IF EXISTS pol_kategori_all     ON public.kategori;
DROP POLICY IF EXISTS pol_kategori_baca    ON public.kategori;
DROP POLICY IF EXISTS pol_log_insert       ON public.log_aktivitas;
DROP POLICY IF EXISTS pol_log_select       ON public.log_aktivitas;
DROP POLICY IF EXISTS pol_login_attempt    ON public.login_attempt;
DROP POLICY IF EXISTS pol_member_all       ON public.member;
DROP POLICY IF EXISTS pol_opsi_all         ON public.opsi_produk;
DROP POLICY IF EXISTS pol_opsi_baca        ON public.opsi_produk;
DROP POLICY IF EXISTS pol_pengaturan_all   ON public.pengaturan;
DROP POLICY IF EXISTS pol_pengaturan_baca  ON public.pengaturan;
DROP POLICY IF EXISTS pol_pengguna_all     ON public.pengguna;
DROP POLICY IF EXISTS pol_pesanan_all      ON public.pesanan;
DROP POLICY IF EXISTS pol_produk_all       ON public.produk;
DROP POLICY IF EXISTS pol_produk_baca      ON public.produk;
DROP POLICY IF EXISTS pol_rating_all       ON public.rating_pesanan;
DROP POLICY IF EXISTS pol_voucher_all      ON public.voucher;
DROP POLICY IF EXISTS pol_voucher_baca     ON public.voucher;


-- ─── STEP 3: CREATE POLICY KATALOG ────────────────────────────

-- kategori
CREATE POLICY pol_kategori_anon_select   ON public.kategori FOR SELECT TO anon          USING (true);
CREATE POLICY pol_kategori_staff_select  ON public.kategori FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_kategori_admin_insert  ON public.kategori FOR INSERT TO authenticated WITH CHECK (public.is_admin());
CREATE POLICY pol_kategori_admin_update  ON public.kategori FOR UPDATE TO authenticated USING (public.is_admin()) WITH CHECK (public.is_admin());
CREATE POLICY pol_kategori_admin_delete  ON public.kategori FOR DELETE TO authenticated USING (public.is_admin());

-- produk
CREATE POLICY pol_produk_anon_select     ON public.produk FOR SELECT TO anon          USING (true);
CREATE POLICY pol_produk_staff_select    ON public.produk FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_produk_admin_insert    ON public.produk FOR INSERT TO authenticated WITH CHECK (public.is_admin());
CREATE POLICY pol_produk_admin_update    ON public.produk FOR UPDATE TO authenticated USING (public.is_admin()) WITH CHECK (public.is_admin());
CREATE POLICY pol_produk_admin_delete    ON public.produk FOR DELETE TO authenticated USING (public.is_admin());

-- opsi_produk
CREATE POLICY pol_opsi_anon_select       ON public.opsi_produk FOR SELECT TO anon          USING (true);
CREATE POLICY pol_opsi_staff_select      ON public.opsi_produk FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_opsi_admin_insert      ON public.opsi_produk FOR INSERT TO authenticated WITH CHECK (public.is_admin());
CREATE POLICY pol_opsi_admin_update      ON public.opsi_produk FOR UPDATE TO authenticated USING (public.is_admin()) WITH CHECK (public.is_admin());
CREATE POLICY pol_opsi_admin_delete      ON public.opsi_produk FOR DELETE TO authenticated USING (public.is_admin());

-- banner_promo (anon hanya lihat yang aktif)
CREATE POLICY pol_banner_anon_select     ON public.banner_promo FOR SELECT TO anon          USING (aktif = true);
CREATE POLICY pol_banner_staff_select    ON public.banner_promo FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_banner_admin_insert    ON public.banner_promo FOR INSERT TO authenticated WITH CHECK (public.is_admin());
CREATE POLICY pol_banner_admin_update    ON public.banner_promo FOR UPDATE TO authenticated USING (public.is_admin()) WITH CHECK (public.is_admin());
CREATE POLICY pol_banner_admin_delete    ON public.banner_promo FOR DELETE TO authenticated USING (public.is_admin());

-- voucher (anon hanya lihat yang aktif)
CREATE POLICY pol_voucher_anon_select    ON public.voucher FOR SELECT TO anon          USING (aktif = true);
CREATE POLICY pol_voucher_staff_select   ON public.voucher FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_voucher_admin_insert   ON public.voucher FOR INSERT TO authenticated WITH CHECK (public.is_admin());
CREATE POLICY pol_voucher_admin_update   ON public.voucher FOR UPDATE TO authenticated USING (public.is_admin()) WITH CHECK (public.is_admin());
CREATE POLICY pol_voucher_admin_delete   ON public.voucher FOR DELETE TO authenticated USING (public.is_admin());

-- pengaturan (anon tidak bisa baca konfigurasi login_*)
CREATE POLICY pol_pengaturan_anon_select   ON public.pengaturan FOR SELECT TO anon          USING (kunci NOT LIKE 'login_%');
CREATE POLICY pol_pengaturan_staff_select  ON public.pengaturan FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_pengaturan_admin_insert  ON public.pengaturan FOR INSERT TO authenticated WITH CHECK (public.is_admin());
CREATE POLICY pol_pengaturan_admin_update  ON public.pengaturan FOR UPDATE TO authenticated USING (public.is_admin()) WITH CHECK (public.is_admin());
CREATE POLICY pol_pengaturan_admin_delete  ON public.pengaturan FOR DELETE TO authenticated USING (public.is_admin());


-- ─── STEP 4: CREATE POLICY OPERASIONAL ────────────────────────

-- pengguna (admin full; kasir/dapur hanya baca datanya sendiri)
CREATE POLICY pol_pengguna_select        ON public.pengguna FOR SELECT TO authenticated
  USING (public.is_admin() OR auth_user_id = (SELECT auth.uid()));
CREATE POLICY pol_pengguna_admin_insert  ON public.pengguna FOR INSERT TO authenticated WITH CHECK (public.is_admin());
CREATE POLICY pol_pengguna_admin_update  ON public.pengguna FOR UPDATE TO authenticated USING (public.is_admin()) WITH CHECK (public.is_admin());
CREATE POLICY pol_pengguna_admin_delete  ON public.pengguna FOR DELETE TO authenticated USING (public.is_admin());

-- member
CREATE POLICY pol_member_staff_select    ON public.member FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_member_staff_insert    ON public.member FOR INSERT TO authenticated WITH CHECK (public.is_staff());
CREATE POLICY pol_member_staff_update    ON public.member FOR UPDATE TO authenticated USING (public.is_staff()) WITH CHECK (public.is_staff());
CREATE POLICY pol_member_admin_delete    ON public.member FOR DELETE TO authenticated USING (public.is_admin());

-- pesanan
CREATE POLICY pol_pesanan_staff_select   ON public.pesanan FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_pesanan_staff_insert   ON public.pesanan FOR INSERT TO authenticated WITH CHECK (public.is_staff());
CREATE POLICY pol_pesanan_staff_update   ON public.pesanan FOR UPDATE TO authenticated USING (public.is_staff()) WITH CHECK (public.is_staff());
CREATE POLICY pol_pesanan_admin_delete   ON public.pesanan FOR DELETE TO authenticated USING (public.is_admin());

-- detail_pesanan
CREATE POLICY pol_detail_staff_select    ON public.detail_pesanan FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_detail_staff_insert    ON public.detail_pesanan FOR INSERT TO authenticated WITH CHECK (public.is_staff());
CREATE POLICY pol_detail_staff_update    ON public.detail_pesanan FOR UPDATE TO authenticated USING (public.is_staff()) WITH CHECK (public.is_staff());
CREATE POLICY pol_detail_admin_delete    ON public.detail_pesanan FOR DELETE TO authenticated USING (public.is_admin());

-- rating_pesanan
CREATE POLICY pol_rating_staff_select    ON public.rating_pesanan FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_rating_staff_insert    ON public.rating_pesanan FOR INSERT TO authenticated WITH CHECK (public.is_staff());
CREATE POLICY pol_rating_staff_update    ON public.rating_pesanan FOR UPDATE TO authenticated USING (public.is_staff()) WITH CHECK (public.is_staff());

-- log_aktivitas (write-once via fn_log_immutable; authenticated bisa insert, admin bisa baca)
CREATE POLICY pol_log_staff_select       ON public.log_aktivitas FOR SELECT TO authenticated USING (public.is_staff());
CREATE POLICY pol_log_staff_insert       ON public.log_aktivitas FOR INSERT TO authenticated WITH CHECK (public.is_staff());

-- login_attempt: DENY semua akses langsung dari authenticated (hanya lewat SECURITY DEFINER function)
CREATE POLICY pol_login_attempt_deny_all ON public.login_attempt FOR ALL TO authenticated
  USING (false) WITH CHECK (false);



