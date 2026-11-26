"""Bangun Laporan_BistroKiosk.docx dari Draft_Isi_BistroKiosk.md (format D-3 TI USU).

Jalankan: python build_laporan.py   (dari folder Laporan)
Data identitas ada di blok DATA di bawah. Isi lalu jalankan ulang.
"""
import copy
import re
from pathlib import Path

from docx import Document
from docx.enum.section import WD_SECTION
from docx.enum.table import WD_TABLE_ALIGNMENT
from docx.enum.text import WD_ALIGN_PARAGRAPH, WD_BREAK
from docx.oxml import OxmlElement
from docx.oxml.ns import qn
from docx.shared import Cm, Pt, RGBColor, Twips
from docx.enum.text import WD_COLOR_INDEX

HERE = Path(__file__).resolve().parent

# ---------------------------------------------------------------- DATA
DATA = {
    "judul_baris": [  # dipotong manual membentuk segitiga terbalik
        "APLIKASI KIOSK PEMESANAN MAKANAN BISTRO",
        "KIOSK NUSANTARA BERBASIS WINDOWS",
        "FORMS VB.NET DAN SUPABASE",
    ],
    "judul_kalimat": "Aplikasi Kiosk Pemesanan Makanan Bistro Kiosk Nusantara Berbasis Windows Forms VB.NET dan Supabase",
    "mata_kuliah": "Praktikum Pemrograman Visual",
    "anggota": [
        ("TEGAR MADYA SHAFWAN", "241712002"),
        ("MICHAEL DERYL AARON MATTHEW", "241712042"),
        ("DHEA TRI LOVA SIMANJUNTAK", "241712017"),
        ("DIMAS SURYA DARMA", "241712018"),
        ("OLO BRILLIANT SIMARMATA", "241712038"),
    ],
    "kom": "KOM A’24",
    "tahun": "2026",
    "bulan": "November",
    "dosen": "Ibu Insidini Fawwaz, M.Kom.",
    "aslab": "Shata Diyaul Haq",
    "syukur": "Tuhan Yang Maha Esa",
    "github": "https://github.com/K1rigayakun/KiosK-Tugas-Akhir-Vispro",
}
OUT_NAME = "Laporan_BistroKiosk.docx"

# Gantt: (kegiatan, {minggu: [hari...]}) hari 0=Senin ... 6=Minggu.
# Minggu 1 = 9-15 Nov 2026 (proyek mulai Sabtu 14 Nov), Minggu 4 = 30 Nov (target selesai akhir November)
GANTT_MINGGU = 4
GANTT = [
    ("Identifikasi Masalah", {1: [5, 6]}),
    ("Analisis Kebutuhan", {2: [0, 1, 2, 3, 4]}),
    ("Studi Literatur", {2: [2, 3, 4, 5, 6]}),
    ("Perancangan Konsep Proyek", {2: [4, 5, 6]}),
    ("Implementasi Proyek (*Coding*)", {3: list(range(7))}),
    ("Pengujian Proyek", {3: [1, 4, 5, 6], 4: [0]}),
    ("Pengembangan Fitur Proyek", {3: [2, 3, 4, 5, 6]}),
    ("Penyusunan Laporan Akhir", {3: [1, 2, 3, 4, 5, 6], 4: [0]}),
]

PUSTAKA = [
    "Hatzivasilis, G. (2017). Password-hashing status. *Cryptography*, *1*(2), 10. https://doi.org/10.3390/cryptography1020010",
    "Huda, M. N., Burhan, M., Satibi, A., Pradita, H. A., Saifudin, A., & Kusyadi, I. (2022). Implementasi black box testing pada aplikasi sistem kasir dengan menggunakan teknik equivalence partitions. *Jurnal Teknologi Sistem Informasi dan Aplikasi*, *5*(2), 120–127. https://doi.org/10.32493/jtsi.v5i2.17645",
    "Koo, W., & Kumar, A. (2026). Moderating role of perceived staff-replacement likelihood on self-ordering kiosk adoption. *International Journal of Technology and Human Interaction*, *22*(1), 1–20. https://doi.org/10.4018/IJTHI.402704",
    "Lee, Y. S., Yen, I. W., & Zheng, M.-C. (2023). Usability evaluation of self-ordering kiosks in fast food restaurants. In *Usability and User Experience* (Vol. 110). AHFE International. https://doi.org/10.54941/ahfe1003203",
    "Marinakou, E., Giousmpasoglou, C., & Sakulrungsap, K. (2023). Customer intention to reuse self-ordering kiosks in fast-food restaurant: The case of Bangkok, Thailand. *Tourism and Hospitality Management*, *29*(4), 545–559. https://doi.org/10.20867/thm.29.4.6",
    "Microsoft. (2017). *How to: Create MDI parent forms*. Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-create-mdi-parent-forms",
    "Microsoft. (2024). *Platform Invoke (P/Invoke)*. Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke",
    "Microsoft. (2025). *What is Windows Forms*. Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/desktop/winforms/overview/",
    "Moriarty, K., Kaliski, B., & Rusch, A. (2017). *PKCS #5: Password-based cryptography specification version 2.1* (RFC 8018). Internet Engineering Task Force. https://doi.org/10.17487/RFC8018",
    "Naya, C., Nugroho, B., & Rilvani, E. (2022). Implementasi aplikasi kasir pada Warung Chicken Geprek Sahabat berbasis desktop menggunakan VB.Net. *SIGMA - Jurnal Teknologi Pelita Bangsa*, *13*(2), 81–86. https://jurnal.pelitabangsa.ac.id/index.php/sigma/article/view/1222",
    "Rafferty, N. E., & Fajar, A. N. (2022). Integrated QR payment system (QRIS): Cashless payment solution in developing country from merchant perspective. *Asia Pacific Journal of Information Systems*, *32*(3), 630–655. https://doi.org/10.14329/apjis.2022.32.3.630",
    "Saran, A. N. (2024). On time-memory trade-offs for password hashing schemes. *Frontiers in Computer Science*, *6*, 1368362. https://doi.org/10.3389/fcomp.2024.1368362",
    "Supabase. (2026). *Connect to your database*. Supabase Docs. https://supabase.com/docs/guides/database/connecting-to-postgres",
]

KATA_PENGANTAR = [
    "Puji syukur penulis panjatkan kepada {syukur} karena berkat rahmat-Nya laporan proyek berjudul "
    "“{judul}” bisa diselesaikan. Laporan ini disusun untuk memenuhi tugas proyek akhir mata kuliah {mk}. "
    "Isinya menjelaskan proses perancangan, pembuatan, dan hasil aplikasi kios pemesanan makanan yang kami kerjakan bersama.",
    "Selama pengerjaan proyek, penulis banyak dibantu oleh berbagai pihak. Terima kasih kami sampaikan kepada "
    "{dosen} selaku dosen pengajar yang sudah memberikan materi dan arahan selama perkuliahan. Terima kasih juga "
    "kepada {aslab} selaku asisten laboratorium yang membimbing kami di setiap pertemuan praktikum. "
    "Kami juga berterima kasih kepada teman-teman yang ikut mencoba aplikasi dan memberi masukan.",
    "Penulis sadar laporan dan aplikasi ini masih punya banyak kekurangan. Kritik dan saran yang membangun "
    "sangat kami harapkan supaya aplikasi bisa diperbaiki ke depannya. Semoga laporan ini bisa bermanfaat bagi pembaca, terutama "
    "mahasiswa yang sedang belajar membuat aplikasi desktop dengan VB.NET.",
]

# ---------------------------------------------------------------- konstanta format (DXA)
TEXT_W = 8221
FONT = "Times New Roman"
CODE_FONT = "Courier New"
L10, L115, L15 = 240, 276, 360


# ---------------------------------------------------------------- util XML
def el(tag, **attrs):
    e = OxmlElement(tag)
    for k, v in attrs.items():
        e.set(qn(k if ":" in k else "w:" + k), str(v))
    return e


def set_rfonts(rpr, font):
    rf = rpr.find(qn("w:rFonts"))
    if rf is None:
        rf = el("w:rFonts")
        rpr.insert(0, rf)
    for a in list(rf.attrib):
        del rf.attrib[a]
    for a in ("ascii", "hAnsi", "cs", "eastAsia"):
        rf.set(qn("w:" + a), font)


def style_run(run, size=12, bold=False, italic=False, font=FONT, highlight=False):
    run.font.name = font
    set_rfonts(run._r.get_or_add_rPr(), font)
    run.font.size = Pt(size)
    run.font.bold = bold
    run.font.italic = italic
    run.font.color.rgb = RGBColor(0, 0, 0)
    if highlight:
        run.font.highlight_color = WD_COLOR_INDEX.YELLOW


def ppr_set(p, align=None, line=L15, first=None, left=None, hanging=None, keep_next=False, tabs=None,
            keep_lines=False):
    pf = p.paragraph_format
    pf.space_before = Pt(0)
    pf.space_after = Pt(0)
    pf.line_spacing = line / 240
    if align is not None:
        p.alignment = align
    if left is not None:
        pf.left_indent = Twips(left)
    if hanging is not None:
        pf.first_line_indent = Twips(-hanging)
    elif first is not None:
        pf.first_line_indent = Twips(first)
    if keep_next:
        pf.keep_with_next = True
    if keep_lines:
        pf.keep_together = True
    pf.widow_control = True
    if tabs:
        for kind, pos in tabs:
            pf.tab_stops.add_tab_stop(pos, kind)


INLINE = re.compile(r"(\*[^*]+\*|\[ISI:[^\]]*\]|\[SISIPKAN SCREENSHOT:[^\]]*\])")


def add_inline(p, text, size=12, bold=False, italic=False, font=FONT):
    """Tambah teks dengan markup *miring* dan [ISI: ...] (highlight kuning)."""
    for part in INLINE.split(text):
        if not part:
            continue
        if part.startswith("*") and part.endswith("*") and len(part) > 2:
            # *miring* bisa berisi [ISI] juga, abaikan kasus itu
            r = p.add_run(part[1:-1])
            style_run(r, size, bold, not italic, font)
        elif part.startswith("[ISI:") or part.startswith("[SISIPKAN"):
            r = p.add_run(part)
            style_run(r, size, bold, italic, font, highlight=True)
        else:
            r = p.add_run(part)
            style_run(r, size, bold, italic, font)


def add_field(p, instr, result, size=12, bold=False, italic=False):
    def mk(child):
        r = p.add_run()
        style_run(r, size, bold, italic)
        r._r.append(child)
        return r

    mk(el("w:fldChar", fldCharType="begin"))
    it = el("w:instrText")
    it.set(qn("xml:space"), "preserve")
    it.text = f" {instr} "
    mk(it)
    mk(el("w:fldChar", fldCharType="separate"))
    r = p.add_run(result)
    style_run(r, size, bold, italic)
    mk(el("w:fldChar", fldCharType="end"))


# ---------------------------------------------------------------- styles
def setup_styles(doc):
    styles = doc.styles
    # docDefaults
    rpr_def = doc.styles.element.find(qn("w:docDefaults")).find(qn("w:rPrDefault")).find(qn("w:rPr"))
    set_rfonts(rpr_def, FONT)
    for t in ("w:lang",):
        old = rpr_def.find(qn(t))
        if old is not None:
            rpr_def.remove(old)
    rpr_def.append(el("w:lang", val="id-ID", eastAsia="id-ID", bidi="ar-SA"))
    ppr_def = doc.styles.element.find(qn("w:docDefaults")).find(qn("w:pPrDefault"))
    if ppr_def is not None:
        ppr = ppr_def.find(qn("w:pPr"))
        sp = ppr.find(qn("w:spacing"))
        if sp is not None:
            ppr.remove(sp)
        ppr.append(el("w:spacing", before=0, after=0, line=L10, lineRule="auto"))

    def fix(name, size, bold, align, line, outline=None):
        st = styles[name]
        st.font.name = FONT
        set_rfonts(st.element.get_or_add_rPr(), FONT)
        st.font.size = Pt(size)
        st.font.bold = bold
        st.font.italic = False
        st.font.color.rgb = RGBColor(0, 0, 0)
        rpr = st.element.get_or_add_rPr()
        for t in ("w:color",):
            for c in rpr.findall(qn(t)):
                if c.get(qn("w:themeColor")):
                    for a in list(c.attrib):
                        if a != qn("w:val"):
                            del c.attrib[a]
        pf = st.paragraph_format
        pf.space_before = Pt(0)
        pf.space_after = Pt(0)
        pf.alignment = align
        pf.left_indent = Cm(0)
        pf.first_line_indent = Cm(0)
        pf.line_spacing = line / 240
        pf.widow_control = True
        return st

    fix("Normal", 12, False, WD_ALIGN_PARAGRAPH.JUSTIFY, L15)
    h1 = fix("Heading 1", 13, True, WD_ALIGN_PARAGRAPH.CENTER, L115)
    h1.paragraph_format.keep_with_next = True
    for n in ("Heading 2", "Heading 3"):
        h = fix(n, 12, True, WD_ALIGN_PARAGRAPH.LEFT, L15)
        h.paragraph_format.keep_with_next = True
        h.paragraph_format.tab_stops.add_tab_stop(Cm(1.25))
    # JudulFrontMatter
    from docx.enum.style import WD_STYLE_TYPE
    jf = styles.add_style("JudulFrontMatter", WD_STYLE_TYPE.PARAGRAPH)
    jf.base_style = styles["Normal"]
    fix("JudulFrontMatter", 13, True, WD_ALIGN_PARAGRAPH.CENTER, L115)
    jf.paragraph_format.keep_with_next = True

    # TOC 1-4 dan Table of Figures (XML langsung, nama bawaan Word)
    def raw_style(style_id, name, ppr_xml, bold):
        st = el("w:style", type="paragraph", styleId=style_id)
        st.append(el("w:name", val=name))
        st.append(el("w:basedOn", val="Normal"))
        st.append(el("w:next", val="Normal"))
        st.append(el("w:uiPriority", val=39))
        st.append(el("w:unhideWhenUsed"))
        ppr = el("w:pPr")
        for child in ppr_xml:
            ppr.append(child)
        st.append(ppr)
        rpr = el("w:rPr")
        rf = el("w:rFonts", ascii=FONT, hAnsi=FONT, cs=FONT, eastAsia=FONT)
        rpr.append(rf)
        if bold:
            rpr.append(el("w:b"))
        else:
            rpr.append(el("w:b", val=0))
        rpr.append(el("w:color", val="000000"))
        rpr.append(el("w:sz", val=24))
        rpr.append(el("w:szCs", val=24))
        st.append(rpr)
        doc.styles.element.append(st)

    def tabs(*items):
        t = el("w:tabs")
        for kind, pos in items:
            t.append(el("w:tab", val=kind, leader="none", pos=pos))
        return t

    def spacing(before=0, line=L10):
        return el("w:spacing", before=before, after=0, line=line, lineRule="auto")

    def ind(left):
        return el("w:ind", left=left, firstLine=0)

    raw_style("TOC1", "toc 1", [tabs(("right", TEXT_W)), spacing(before=240), ind(0), el("w:jc", val="left")], True)
    raw_style("TOC2", "toc 2", [tabs(("left", 1300), ("right", TEXT_W)), spacing(), ind(733), el("w:jc", val="left")], False)
    raw_style("TOC3", "toc 3", [tabs(("left", 1760), ("right", TEXT_W)), spacing(), ind(960), el("w:jc", val="left")], False)
    raw_style("TOC4", "toc 4", [tabs(("right", TEXT_W)), spacing(), ind(0), el("w:jc", val="left")], True)
    raw_style("TableofFigures", "table of figures", [tabs(("right", TEXT_W)), spacing(line=L15), ind(0), el("w:jc", val="left")], False)


def black_hyperlink_style(doc):
    """Word memberi style Hyperlink pada entri daftar isi; buat hitam tanpa garis bawah."""
    st = el("w:style", type="character", styleId="Hyperlink")
    st.append(el("w:name", val="Hyperlink"))
    st.append(el("w:basedOn", val="DefaultParagraphFont"))
    st.append(el("w:uiPriority", val=99))
    st.append(el("w:unhideWhenUsed"))
    rpr = el("w:rPr")
    rpr.append(el("w:color", val="000000"))
    rpr.append(el("w:u", val="none"))
    st.append(rpr)
    doc.styles.element.append(st)


def setup_settings(doc):
    s = doc.settings.element
    s.append(el("w:updateFields", val="true"))


# ---------------------------------------------------------------- numbering
class Numbering:
    def __init__(self, doc):
        self.np = doc.part.numbering_part.element
        self.abs_id = 90
        a = el("w:abstractNum", abstractNumId=self.abs_id)
        a.append(el("w:multiLevelType", val="multilevel"))
        for lvl, fmt, txt, left in ((0, "decimal", "%1.", 357), (1, "lowerLetter", "%2.", 714)):
            l = el("w:lvl", ilvl=lvl)
            l.append(el("w:start", val=1))
            l.append(el("w:numFmt", val=fmt))
            l.append(el("w:lvlText", val=txt))
            l.append(el("w:lvlJc", val="left"))
            ppr = el("w:pPr")
            ppr.append(el("w:tabs"))
            ppr[0].append(el("w:tab", val="num", pos=left))
            ppr.append(el("w:ind", left=left, hanging=357))
            l.append(ppr)
            rpr = el("w:rPr")
            rpr.append(el("w:rFonts", ascii=FONT, hAnsi=FONT, cs=FONT, eastAsia=FONT))
            rpr.append(el("w:b", val=0))
            rpr.append(el("w:i", val=0))
            rpr.append(el("w:color", val="000000"))
            rpr.append(el("w:sz", val=24))
            l.append(rpr)
            a.append(l)
        # abstractNum harus sebelum num
        first_num = self.np.find(qn("w:num"))
        if first_num is not None:
            first_num.addprevious(a)
        else:
            self.np.append(a)
        self.next_id = 200

    def new_list(self):
        nid = self.next_id
        self.next_id += 1
        n = el("w:num", numId=nid)
        n.append(el("w:abstractNumId", val=self.abs_id))
        for lvl in (0, 1):
            o = el("w:lvlOverride", ilvl=lvl)
            o.append(el("w:startOverride", val=1))
            n.append(o)
        self.np.append(n)
        return nid


def set_num(p, num_id, ilvl):
    numPr = p._p.get_or_add_pPr().get_or_add_numPr()
    numPr.get_or_add_ilvl().val = ilvl
    numPr.get_or_add_numId().val = num_id


# ---------------------------------------------------------------- tabel util
def table_props(tbl, widths, borders=True, align="center", shading=None):
    t = tbl._tbl
    tblPr = t.tblPr
    for tag in ("w:tblW", "w:jc", "w:tblBorders", "w:tblLayout", "w:tblInd", "w:tblStyle"):
        old = tblPr.find(qn(tag))
        if old is not None:
            tblPr.remove(old)
    tblPr.append(el("w:tblW", w=sum(widths), type="dxa"))
    tblPr.append(el("w:jc", val=align))
    if align == "left":
        tblPr.append(el("w:tblInd", w=0, type="dxa"))
    b = el("w:tblBorders")
    for side in ("top", "left", "bottom", "right", "insideH", "insideV"):
        if borders:
            b.append(el(f"w:{side}", val="single", sz=4, space=0, color="000000"))
        else:
            b.append(el(f"w:{side}", val="nil"))
    tblPr.append(b)
    tblPr.append(el("w:tblLayout", type="fixed"))
    look = tblPr.find(qn("w:tblLook"))
    if look is not None:
        tblPr.remove(look)
        tblPr.append(look)
    grid = t.tblGrid
    for gc, w in zip(grid.findall(qn("w:gridCol")), widths):
        gc.set(qn("w:w"), str(w))
    for row in tbl.rows:
        for cell, w in zip(row.cells, widths):
            tcPr = cell._tc.get_or_add_tcPr()
            old = tcPr.find(qn("w:tcW"))
            if old is not None:
                tcPr.remove(old)
            tcPr.insert(0, el("w:tcW", w=w, type="dxa"))
            if shading:
                tcPr.append(el("w:shd", val="clear", color="auto", fill=shading))


def row_props(row, cant_split=True, header=False):
    trPr = row._tr.get_or_add_trPr()
    if cant_split:
        trPr.append(el("w:cantSplit"))
    if header:
        trPr.append(el("w:tblHeader"))


def cell_text(cell, text, size=12, align=WD_ALIGN_PARAGRAPH.LEFT, line=L15, keep_next=False, shade=None,
              valign="center"):
    p = cell.paragraphs[0]
    ppr_set(p, align=align, line=line, keep_next=keep_next)
    add_inline(p, text, size=size)
    tcPr = cell._tc.get_or_add_tcPr()
    if shade:
        tcPr.append(el("w:shd", val="clear", color="auto", fill=shade))
    tcPr.append(el("w:vAlign", val=valign))


# ---------------------------------------------------------------- builder
class Builder:
    def __init__(self):
        self.doc = Document()
        setup_styles(self.doc)
        setup_settings(self.doc)
        black_hyperlink_style(self.doc)
        self.num = Numbering(self.doc)
        self.prev = "start"
        self.cur_list = None
        self.bab = 0
        self.fig_no = 0
        self.tab_no = 0
        sec = self.doc.sections[0]
        self.page_setup(sec)

    # -------- page / section
    def page_setup(self, sec):
        sec.page_width, sec.page_height = 11906 * 635, 16838 * 635  # DXA -> EMU (1 dxa = 635 EMU)
        sec.top_margin = sec.bottom_margin = Cm(3)
        sec.left_margin = Cm(4)
        sec.right_margin = Cm(2.5)
        sec.header_distance = sec.footer_distance = Cm(1.5)

    def pgnum(self, sec, fmt, start=None):
        sectPr = sec._sectPr
        old = sectPr.find(qn("w:pgNumType"))
        if old is not None:
            sectPr.remove(old)
        pg = el("w:pgNumType", fmt=fmt)
        if start is not None:
            pg.set(qn("w:start"), str(start))
        for tag in ("w:cols", "w:formProt", "w:vAlign", "w:noEndnote", "w:titlePg", "w:textDirection", "w:bidi",
                    "w:rtlGutter", "w:docGrid"):
            nxt = sectPr.find(qn(tag))
            if nxt is not None:
                nxt.addprevious(pg)
                break
        else:
            sectPr.append(pg)

    def hf_empty(self, hf):
        hf.is_linked_to_previous = False
        p = hf.paragraphs[0]
        ppr_set(p, line=L10)

    def hf_page(self, hf, align):
        hf.is_linked_to_previous = False
        p = hf.paragraphs[0]
        ppr_set(p, align=align, line=L10)
        add_field(p, "PAGE", "1")

    def new_section(self, kind):
        sec = self.doc.add_section(WD_SECTION.NEW_PAGE)
        self.page_setup(sec)
        # paragraf penanda section break: rapikan
        if kind == "front":
            sec.different_first_page_header_footer = False
            self.pgnum(sec, "lowerRoman", 1)
            self.hf_empty(sec.header)
            self.hf_page(sec.footer, WD_ALIGN_PARAGRAPH.CENTER)
        else:  # bab / pustaka
            sec.different_first_page_header_footer = True
            self.pgnum(sec, "decimal", 1 if kind == "bab1" else None)
            self.hf_page(sec.header, WD_ALIGN_PARAGRAPH.RIGHT)
            self.hf_empty(sec.first_page_header)
            self.hf_empty(sec.footer)
            self.hf_empty(sec.first_page_footer)
        self.prev = "start"
        return sec

    # -------- basic paragraphs
    def blank(self, n=1, line=L10, size=12):
        for _ in range(n):
            p = self.doc.add_paragraph()
            ppr_set(p, line=line)
            r = p.add_run()
            style_run(r, size)
            # tandai ukuran paragraf kosong
            p._p.get_or_add_pPr().append(self._prsz(size))

    @staticmethod
    def _prsz(size):
        rpr = el("w:rPr")
        rpr.append(el("w:rFonts", ascii=FONT, hAnsi=FONT, cs=FONT, eastAsia=FONT))
        rpr.append(el("w:sz", val=size * 2))
        rpr.append(el("w:szCs", val=size * 2))
        return rpr

    def para(self, text, first=709, left=None, align=WD_ALIGN_PARAGRAPH.JUSTIFY, line=L15, size=12, bold=False):
        p = self.doc.add_paragraph()
        ppr_set(p, align=align, line=line, first=first, left=left)
        add_inline(p, text, size=size, bold=bold)
        return p

    def page_break(self):
        p = self.doc.add_paragraph()
        ppr_set(p, line=L10)
        p.add_run().add_break(WD_BREAK.PAGE)

    # -------- gap logic
    def gap_for(self, kind):
        prev = self.prev
        if kind in ("h2", "h3"):
            if prev not in ("h1", "start"):
                self.blank(2, L10)
        elif kind in ("fig", "table", "code"):
            if prev in ("body", "list", "cont", "fig", "table", "code"):
                self.blank(1, L15)
        elif kind in ("body", "list", "cont"):
            if prev in ("fig", "table", "code"):
                self.blank(1, L15)
        self.prev = kind

    # -------- headings
    def heading1(self, top, title):
        p = self.doc.add_paragraph(style="Heading 1")
        ppr_set(p, align=WD_ALIGN_PARAGRAPH.CENTER, line=L115, keep_next=True)
        r = p.add_run(top)
        style_run(r, 13, True)
        if title:
            r.add_break(WD_BREAK.LINE)
            r2 = p.add_run(title)
            style_run(r2, 13, True)
        self.blank(3, L10)
        self.prev = "h1"

    def heading(self, level, number, title):
        self.gap_for("h2" if level == 2 else "h3")
        p = self.doc.add_paragraph(style=f"Heading {level}")
        ppr_set(p, align=WD_ALIGN_PARAGRAPH.LEFT, line=L15, first=0, left=0, keep_next=True)
        r = p.add_run(number + "\t")
        style_run(r, 12, True)
        add_inline(p, title, size=12, bold=True)
        self.cur_list = None

    # -------- content blocks
    def body(self, text):
        self.gap_for("body")
        self.para(text)
        self.cur_list = None

    def cont(self, text):
        self.gap_for("cont")
        self.para(text, first=0, left=357)

    def list_item(self, level, text):
        self.gap_for("list")
        if self.cur_list is None:
            self.cur_list = self.num.new_list()
        p = self.doc.add_paragraph()
        ppr_set(p, align=WD_ALIGN_PARAGRAPH.JUSTIFY, line=L15)
        set_num(p, self.cur_list, level)
        add_inline(p, text)

    def figure(self, caption, path, width_cm):
        self.gap_for("fig")
        p = self.doc.add_paragraph()
        ppr_set(p, align=WD_ALIGN_PARAGRAPH.CENTER, line=L10, first=0, keep_next=True)
        p.add_run().add_picture(str((HERE / path).resolve()), width=Cm(width_cm))
        self.fig_no += 1
        cap = self.doc.add_paragraph()
        ppr_set(cap, align=WD_ALIGN_PARAGRAPH.CENTER, line=L15, first=0)
        m = re.match(r"Gambar (\d+)\.(\d+) (.*)", caption)
        assert m and int(m.group(1)) == self.bab and int(m.group(2)) == self.fig_no, caption
        r = cap.add_run(f"Gambar {self.bab}.")
        style_run(r)
        add_field(cap, r"SEQ Gambar \* ARABIC \s 1", str(self.fig_no))
        add_inline(cap, " " + m.group(3))

    def caption_table(self, caption):
        self.gap_for("table")
        self.tab_no += 1
        m = re.match(r"Tabel (\d+)\.(\d+) (.*)", caption)
        assert m and int(m.group(1)) == self.bab and int(m.group(2)) == self.tab_no, caption
        cap = self.doc.add_paragraph()
        ppr_set(cap, align=WD_ALIGN_PARAGRAPH.LEFT, line=L15, first=0, keep_next=True)
        r = cap.add_run(f"Tabel {self.bab}.")
        style_run(r)
        add_field(cap, r"SEQ Tabel \* ARABIC \s 1", str(self.tab_no))
        add_inline(cap, " " + m.group(3))

    def data_table(self, rows, widths, short=False):
        tbl = self.doc.add_table(rows=len(rows), cols=len(widths))
        table_props(tbl, widths)
        n = len(rows)
        for i, (row, cells) in enumerate(zip(tbl.rows, rows)):
            row_props(row, cant_split=True, header=(i == 0))
            for j, (cell, txt) in enumerate(zip(row.cells, cells)):
                center = i == 0 or j == 0 or (j == len(widths) - 1)
                cell_text(cell, txt, align=WD_ALIGN_PARAGRAPH.CENTER if center else WD_ALIGN_PARAGRAPH.LEFT,
                          keep_next=(short and i < n - 1))
        return tbl

    def gantt(self):
        self.caption_table("Tabel 3.1 Jadwal Penelitian")
        weeks = GANTT_MINGGU
        day_w = (TEXT_W - 600 - 2300) // (7 * weeks)
        widths = [600, 2300] + [day_w] * (7 * weeks)
        nrows = 3 + len(GANTT)
        tbl = self.doc.add_table(rows=nrows, cols=len(widths))
        table_props(tbl, widths)
        # margin sel kecil supaya kolom hari yang sempit tetap muat satu huruf
        mar = el("w:tblCellMar")
        for side in ("left", "right"):
            mar.append(el(f"w:{side}", w=28, type="dxa"))
        tbl._tbl.tblPr.find(qn("w:tblLayout")).addnext(mar)
        size = 9 if weeks > 3 else 10
        for i, row in enumerate(tbl.rows):
            row_props(row, cant_split=True, header=(i < 3))
        rows = tbl.rows
        # header merges
        a = rows[0].cells[0].merge(rows[2].cells[0])
        b = rows[0].cells[1].merge(rows[2].cells[1])
        c = rows[0].cells[2].merge(rows[0].cells[len(widths) - 1])
        cell_text(a, "No", size, WD_ALIGN_PARAGRAPH.CENTER, L10, True)
        cell_text(b, "Judul Kegiatan", size, WD_ALIGN_PARAGRAPH.CENTER, L10, True)
        cell_text(c, "Minggu/Hari", size, WD_ALIGN_PARAGRAPH.CENTER, L10, True)
        for w in range(weeks):
            mc = rows[1].cells[2 + 7 * w].merge(rows[1].cells[2 + 7 * w + 6])
            cell_text(mc, f"Minggu {w + 1}", size, WD_ALIGN_PARAGRAPH.CENTER, L10, True)
            for d, h in enumerate("SSRKJSM"):
                cell_text(rows[2].cells[2 + 7 * w + d], h, size, WD_ALIGN_PARAGRAPH.CENTER, L10, True)
        for k, (name, act) in enumerate(GANTT):
            r = rows[3 + k]
            last = k == len(GANTT) - 1
            cell_text(r.cells[0], str(k + 1), size, WD_ALIGN_PARAGRAPH.CENTER, L10, not last)
            cell_text(r.cells[1], name, size, WD_ALIGN_PARAGRAPH.LEFT, L10, not last)
            for w in range(weeks):
                for d in range(7):
                    on = d in act.get(w + 1, [])
                    cell_text(r.cells[2 + 7 * w + d], "", size, WD_ALIGN_PARAGRAPH.CENTER, L10, not last,
                              shade="8EAADB" if on else None)
        # tabel pendek dijaga utuh: keepNext di semua paragraf (termasuk sel lanjutan merge) kecuali baris terakhir
        for tr in tbl._tbl.tr_lst[:-1]:
            for p_el in tr.iter(qn("w:p")):
                p_el.get_or_add_pPr().keepNext_val = True
        self.prev = "table"

    def code(self, lines):
        self.gap_for("code")
        tbl = self.doc.add_table(rows=1, cols=1)
        table_props(tbl, [TEXT_W], borders=False, align="left", shading="D9D9D9")
        cell = tbl.rows[0].cells[0]
        first = True
        for ln in lines:
            p = cell.paragraphs[0] if first else cell.add_paragraph()
            first = False
            ppr_set(p, align=WD_ALIGN_PARAGRAPH.LEFT, line=L10, first=0, left=0)
            r = p.add_run(ln if ln else "")
            style_run(r, 10, font=CODE_FONT)
        self.prev = "code"


# ---------------------------------------------------------------- bagian depan
def cover(b):
    d = b.doc
    for i, line in enumerate(DATA["judul_baris"]):
        pass
    p = d.add_paragraph()
    ppr_set(p, align=WD_ALIGN_PARAGRAPH.CENTER, line=L115)
    for i, line in enumerate(DATA["judul_baris"]):
        r = p.add_run(line)
        style_run(r, 14, True)
        if i < len(DATA["judul_baris"]) - 1:
            r.add_break(WD_BREAK.LINE)
    b.blank(3, L115, 14)
    widths = [5556, 2155]
    rows = [("NAMA", "NIM")] + DATA["anggota"]
    tbl = d.add_table(rows=len(rows), cols=2)
    table_props(tbl, widths, borders=False, align="center")
    for row, (n, nim) in zip(tbl.rows, rows):
        cell_text(row.cells[0], n, 14, WD_ALIGN_PARAGRAPH.LEFT, L115)
        cell_text(row.cells[1], nim, 14, WD_ALIGN_PARAGRAPH.LEFT, L115)
        for c in row.cells:
            for r in c.paragraphs[0].runs:
                r.font.bold = True
    p = d.add_paragraph()
    ppr_set(p, align=WD_ALIGN_PARAGRAPH.CENTER, line=L115)
    add_inline(p, DATA["kom"], size=14, bold=True)
    b.blank(3, L115, 14)
    p = d.add_paragraph()
    ppr_set(p, align=WD_ALIGN_PARAGRAPH.CENTER, line=L10)
    p.add_run().add_picture(str(HERE / "gambar" / "logo_usu.png"), width=Cm(5), height=Cm(5))
    b.blank(COVER_GAP, L115, 14)
    for line in ["PROGRAM STUDI D-3 TEKNIK INFORMATIKA", "FAKULTAS VOKASI", "UNIVERSITAS SUMATERA UTARA",
                 "MEDAN", DATA["tahun"]]:
        p = d.add_paragraph()
        ppr_set(p, align=WD_ALIGN_PARAGRAPH.CENTER, line=L115)
        add_inline(p, line, size=13, bold=True)


COVER_GAP = 6


def front_title(b, text):
    p = b.doc.add_paragraph(style="JudulFrontMatter")
    ppr_set(p, align=WD_ALIGN_PARAGRAPH.CENTER, line=L115, keep_next=True)
    r = p.add_run(text)
    style_run(r, 13, True)
    b.blank(3, L10)


def front_matter(b):
    d = b.doc
    front_title(b, "KATA PENGANTAR")
    vals = dict(syukur=DATA["syukur"], judul=DATA["judul_kalimat"], mk=DATA["mata_kuliah"], dosen=DATA["dosen"],
                aslab=DATA["aslab"])
    for t in KATA_PENGANTAR:
        b.para(t.format(**vals))
    b.blank(3, L10)
    b.para(f"Medan,    {DATA['bulan']} {DATA['tahun']}", first=0, left=5103, align=WD_ALIGN_PARAGRAPH.CENTER, line=L15)
    b.blank(3, L10)
    b.para("Penulis", first=0, left=5103, align=WD_ALIGN_PARAGRAPH.CENTER, line=L15)

    b.page_break()
    front_title(b, "DAFTAR ISI")
    p = d.add_paragraph()
    ppr_set(p, align=WD_ALIGN_PARAGRAPH.RIGHT, line=L10)
    add_inline(p, "Halaman")
    p = d.add_paragraph()
    ppr_set(p, line=L10)
    add_field(p, r'TOC \o "1-3" \h \z \t "JudulFrontMatter,4" \n "1-1"', "Tekan F9 untuk memperbarui daftar isi.")

    b.page_break()
    front_title(b, "DAFTAR GAMBAR")
    p = d.add_paragraph()
    ppr_set(p, line=L15)
    add_field(p, r'TOC \h \z \c "Gambar"', "Tekan F9 untuk memperbarui daftar gambar.")

    b.page_break()
    front_title(b, "DAFTAR TABEL")
    p = d.add_paragraph()
    ppr_set(p, line=L15)
    add_field(p, r'TOC \h \z \c "Tabel"', "Tekan F9 untuk memperbarui daftar tabel.")


def pustaka(b):
    sec = b.new_section("pustaka")
    p = b.doc.add_paragraph(style="Heading 1")
    ppr_set(p, align=WD_ALIGN_PARAGRAPH.CENTER, line=L115, keep_next=True)
    style_run(p.add_run("DAFTAR PUSTAKA"), 13, True)
    b.blank(3, L10)
    for ref in [DATA["github"]] + PUSTAKA:
        p = b.doc.add_paragraph()
        ppr_set(p, align=WD_ALIGN_PARAGRAPH.JUSTIFY, line=L15, left=709, hanging=709)
        add_inline(p, ref)


# ---------------------------------------------------------------- parser draf
def parse_draft(b, text):
    text = re.sub(r"<!--.*?-->", "", text, flags=re.S)
    lines = text.splitlines()
    i = 0
    first_bab = True
    while i < len(lines):
        ln = lines[i].rstrip()
        if not ln.strip():
            i += 1
            continue
        if ln.startswith("# "):
            top, title = ln[2:].split("|")
            b.bab = int(top.split()[1])
            b.fig_no = b.tab_no = 0
            b.new_section("bab1" if first_bab else "bab")
            first_bab = False
            b.heading1(top.strip(), title.strip())
        elif ln.startswith("### "):
            num, title = ln[4:].split(" ", 1)
            b.heading(3, num, title)
        elif ln.startswith("## "):
            num, title = ln[3:].split(" ", 1)
            b.heading(2, num, title)
        elif ln.startswith("!["):
            m = re.match(r"!\[(.*?)\]\((.*?)\|([\d.]+)\)", ln)
            b.figure(m.group(1), m.group(2), float(m.group(3)))
        elif ln.startswith("Tabel: "):
            b.caption_table(ln[len("Tabel: "):])
            rows = []
            i += 1
            while i < len(lines) and lines[i].startswith("|"):
                rows.append([c.strip() for c in lines[i].strip().strip("|").split("|")])
                i += 1
            b.data_table(rows, [600, 3000, 3021, 1600])
            b.prev = "table"
            continue
        elif ln.strip() == "[[GANTT]]":
            b.gantt()
        elif ln.startswith("```"):
            code = []
            i += 1
            while not lines[i].startswith("```"):
                code.append(lines[i].rstrip())
                i += 1
            b.code(code)
        elif ln.startswith("> "):
            b.cont(ln[2:])
        elif re.match(r"^\d+\. ", ln):
            b.list_item(0, re.sub(r"^\d+\. ", "", ln))
        elif re.match(r"^\s+[a-z]\. ", ln):
            b.list_item(1, re.sub(r"^\s+[a-z]\. ", "", ln))
        else:
            b.body(ln.strip())
        i += 1


def main():
    b = Builder()
    sec0 = b.doc.sections[0]
    b.hf_empty(sec0.header)
    b.hf_empty(sec0.footer)
    cover(b)
    b.new_section("front")
    front_matter(b)
    parse_draft(b, (HERE / "Draft_Isi_BistroKiosk.md").read_text(encoding="utf-8"))
    pustaka(b)
    out = HERE / OUT_NAME
    b.doc.core_properties.title = DATA["judul_kalimat"]
    b.doc.core_properties.language = "id-ID"
    b.doc.save(out)
    print("saved", out)


if __name__ == "__main__":
    main()
