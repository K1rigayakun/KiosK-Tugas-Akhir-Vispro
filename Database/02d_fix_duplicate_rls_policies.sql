-- ============================================================
-- Migration: 02d_fix_duplicate_rls_policies.sql
-- Purpose  : Batasi RLS policy SELECT publik (pol_X_baca) ke
--            role `anon` saja pada 6 tabel yang sudah memiliki
--            pol_X_all (role `authenticated`), sehingga akses
--            baca anon tetap terjaga tanpa memicu peringatan
--            "multiple permissive policies" untuk authenticated.
-- Author   : Bistro Kiosk Nusantara
-- Date     : 2026-11-26
-- ============================================================

ALTER POLICY pol_banner_baca     ON public.banner_promo TO anon;
ALTER POLICY pol_kategori_baca   ON public.kategori     TO anon;
ALTER POLICY pol_opsi_baca       ON public.opsi_produk  TO anon;
ALTER POLICY pol_pengaturan_baca ON public.pengaturan   TO anon;
ALTER POLICY pol_produk_baca     ON public.produk       TO anon;
ALTER POLICY pol_voucher_baca    ON public.voucher      TO anon;
