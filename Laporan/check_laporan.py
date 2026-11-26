"""Pemeriksaan otomatis bagian H pada Laporan_BistroKiosk.docx (hasil akhir, bukan draf)."""
import re
import sys
from collections import Counter, defaultdict
from pathlib import Path

from docx import Document
from docx.oxml.ns import qn

sys.stdout.reconfigure(encoding="utf-8")
HERE = Path(__file__).resolve().parent
doc = Document(HERE / "Laporan_BistroKiosk.docx")
body = doc.element.body
errors = []


def err(msg):
    errors.append(msg)


W = qn("w:val")

# ---------------- H.1.1 halaman dan margin
for i, s in enumerate(doc.sections):
    vals = (s.page_width.twips if hasattr(s.page_width, "twips") else int(s.page_width / 635),
            int(s.page_height / 635), int(s.top_margin / 635), int(s.bottom_margin / 635),
            int(s.left_margin / 635), int(s.right_margin / 635))
    if vals[:2] != (11906, 16838) or abs(vals[2] - 1701) > 2 or abs(vals[3] - 1701) > 2 or abs(vals[4] - 2268) > 2 or abs(vals[5] - 1417) > 2:
        err(f"section {i + 1}: ukuran/margin {vals}")

# ---------------- style fonts
styles = {s.style_id: s for s in doc.styles if s.type == 1}


def style_font(sid):
    st = doc.styles.element.find(f".//w:style[@w:styleId='{sid}']", namespaces={"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}) if sid else None
    while st is not None:
        rf = st.find(qn("w:rPr") + "/" + qn("w:rFonts"))
        if rf is not None and rf.get(qn("w:ascii")):
            return rf.get(qn("w:ascii"))
        based = st.find(qn("w:basedOn"))
        if based is None:
            break
        st = doc.styles.element.find(f".//w:style[@w:styleId='{based.get(W)}']", namespaces={"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"})
    return "Times New Roman"  # docDefaults sudah TNR


ID2NAME = {st.get(qn("w:styleId")): st.find(qn("w:name")).get(W) for st in doc.styles.element.findall(qn("w:style"))}
NAME_MAP = {"heading 1": "Heading1", "heading 2": "Heading2", "heading 3": "Heading3", "toc 1": "TOC1",
            "toc 2": "TOC2", "toc 3": "TOC3", "toc 4": "TOC4", "table of figures": "TOF"}


def para_style(p):
    """Nama style yang tidak tergantung bahasa Word (Word Indonesia menyimpan Heading1 sebagai Judul1)."""
    ps = p.find(qn("w:pPr") + "/" + qn("w:pStyle"))
    if ps is None:
        return "Normal"
    name = ID2NAME.get(ps.get(W), ps.get(W))
    return NAME_MAP.get(name.lower(), name)


def text_of(p):
    return "".join(t.text or "" for t in p.iter(qn("w:t")))


all_ps = list(doc.element.iter(qn("w:p")))
for hdr_part in [s.header for s in doc.sections] + [s.footer for s in doc.sections]:
    pass

# ---------------- H.1.2 font/warna/underline per run, H.1.3 spacing
for p in all_ps:
    sid = para_style(p)
    ppr = p.find(qn("w:pPr"))
    sp = ppr.find(qn("w:spacing")) if ppr is not None else None
    if sp is not None and sid not in ("TOC1",):
        for a in ("before", "after"):
            v = sp.get(qn("w:" + a))
            if v not in (None, "0"):
                err(f"spacing {a}={v} pada paragraf: {text_of(p)[:50]!r}")
    for r in p.iter(qn("w:r")):
        if not "".join(t.text or "" for t in r.iter(qn("w:t"))).strip():
            continue
        rpr = r.find(qn("w:rPr"))
        font = None
        if rpr is not None:
            rf = rpr.find(qn("w:rFonts"))
            if rf is not None:
                font = rf.get(qn("w:ascii"))
            col = rpr.find(qn("w:color"))
            if col is not None and col.get(W) not in ("000000", "auto"):
                err(f"warna {col.get(W)}: {text_of(p)[:40]!r}")
            u = rpr.find(qn("w:u"))
            if u is not None and u.get(W) not in ("none", None):
                err(f"underline: {text_of(p)[:40]!r}")
            rs = rpr.find(qn("w:rStyle"))

        font = font or style_font(sid)
        if font not in ("Times New Roman", "Courier New"):
            err(f"font {font}: {text_of(p)[:40]!r}")

# style Hyperlink (dipakai Word di entri daftar isi) harus hitam tanpa garis bawah
hl = doc.styles.element.find(f".//w:style[@w:styleId='Hyperlink']", namespaces={"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"})
if hl is not None:
    c = hl.find(qn("w:rPr") + "/" + qn("w:color"))
    u = hl.find(qn("w:rPr") + "/" + qn("w:u"))
    if (c is not None and c.get(W) != "000000") or (u is not None and u.get(W) != "none"):
        err("style Hyperlink tidak hitam/masih bergaris bawah")

# ---------------- dokumen utama: urutan paragraf dengan konteks
blocks = []  # (kind, element)
for child in body.iterchildren():
    if child.tag == qn("w:p"):
        blocks.append(("p", child))
    elif child.tag == qn("w:tbl"):
        blocks.append(("tbl", child))

# H.1.4 heading
heads = [(para_style(p), text_of(p)) for k, p in blocks if k == "p" and para_style(p) in ("Heading1", "Heading2", "Heading3", "JudulFrontMatter")]
print("Heading:", Counter(s for s, _ in heads))
for k, p in blocks:
    if k != "p":
        continue
    t = text_of(p)
    if re.match(r"^(BAB \d|\d+\.\d+(\.\d+)?\t)", t) and para_style(p) == "Normal":
        err(f"judul tanpa style heading: {t[:40]!r}")

# H.1.5 field
instr = [x.text.strip() for x in doc.element.iter(qn("w:instrText"))]
tocs = [x for x in instr if x.startswith("TOC")]
seqg = [x for x in instr if x.startswith("SEQ Gambar")]
seqt = [x for x in instr if x.startswith("SEQ Tabel")]
print("TOC field:", len(tocs), tocs)
hdr_pages = 0
for s in doc.sections:
    for part in (s.header, s.footer):
        if not part.is_linked_to_previous:
            hdr_pages += sum(1 for x in part._element.iter(qn("w:instrText")) if "PAGE" in x.text)
print("PAGE field di header/footer:", hdr_pages)
caps_g = [text_of(p) for k, p in blocks if k == "p" and para_style(p) == "Normal" and re.match(r"^Gambar \d+\.\d+ ", text_of(p))]
caps_t = [text_of(p) for k, p in blocks if k == "p" and para_style(p) == "Normal" and re.match(r"^Tabel \d+\.\d+ ", text_of(p))]
if len(tocs) != 3:
    err("jumlah TOC bukan 3")
if len(seqg) != len(caps_g) or len(seqt) != len(caps_t):
    err(f"SEQ {len(seqg)}/{len(caps_g)} gambar, {len(seqt)}/{len(caps_t)} tabel")
print(f"Caption: {len(caps_g)} gambar, {len(caps_t)} tabel")

# H.1.6 section
for i, s in enumerate(doc.sections):
    pg = s._sectPr.find(qn("w:pgNumType"))
    fmt = pg.get(qn("w:fmt")) if pg is not None else None
    start = pg.get(qn("w:start")) if pg is not None else None
    print(f"section {i + 1}: fmt={fmt} start={start} titlePg={s.different_first_page_header_footer}")

# H.1.7 list: tidak ada bullet / nomor manual
num_part = doc.part.numbering_part.element
used = Counter()
for k, p in blocks:
    if k != "p":
        continue
    npr = p.find(qn("w:pPr") + "/" + qn("w:numPr"))
    if npr is not None:
        used[npr.find(qn("w:numId")).get(W)] += 1
    t = text_of(p)
    if re.match(r"^\s*([•\-–]|\d+\.\s|[a-z]\.\s)", t) and npr is None and para_style(p) == "Normal":
        err(f"nomor/bullet manual: {t[:40]!r}")
for numid in used:
    n = num_part.find(f"w:num[@w:numId='{numid}']", namespaces={"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"})
    if n is None or n.find(qn("w:lvlOverride")) is None:
        err(f"list {numid} tanpa restart")
print("List:", len(used), "list,", sum(used.values()), "item")

# ---------------- teks isi BAB (paragraf Normal berindent 709) untuk cek gaya
in_bab = False
isi = []  # (bab, text)
bab = None
for k, p in blocks:
    if k != "p":
        continue
    t = text_of(p)
    st = para_style(p)
    if st == "Heading1":
        in_bab = t.startswith("BAB")
        bab = t[:5]
        continue
    if not in_bab or st != "Normal" or not t.strip():
        continue
    if re.match(r"^(Gambar|Tabel) \d", t):
        continue
    ppr = p.find(qn("w:pPr"))
    if ppr is not None and ppr.find(qn("w:jc")) is not None and ppr.find(qn("w:jc")).get(W) == "center":
        continue
    is_item = ppr is not None and ppr.find(qn("w:numPr")) is not None
    # H.1.8 bold di paragraf isi
    for r in p.iter(qn("w:r")):
        b = r.find(qn("w:rPr") + "/" + qn("w:b")) if r.find(qn("w:rPr")) is not None else None
        if b is not None and b.get(W) not in ("0", "false"):
            err(f"bold di isi: {t[:40]!r}")
    isi.append((bab, t, is_item))

SENT = re.compile(r"(?<=[.!?])\s+(?=[A-Z\[“])")


def sentences(t):
    t = re.sub(r"\[ISI:[^\]]*\]", "", t)
    t = re.sub(r"\b(et al|dkk|hlm|No|Vol|M\.Kom|Ed)\.", r"\1", t)
    t = re.sub(r"(\d)\.(\d)", r"\1\2", t)
    return [s for s in SENT.split(t.strip()) if s.strip()]


# H.1.10 paragraf minimal 2 kalimat
for bab_, t, item in isi:
    if not item and len(sentences(t)) < 2:
        err(f"paragraf 1 kalimat: {t[:60]!r}")

# H.3.1 panjang kalimat
per_bab = defaultdict(list)
for bab_, t, item in isi:
    for s in sentences(t):
        n = len(s.split())
        per_bab[bab_].append(n)
        if n > 30:
            err(f"kalimat {n} kata: {s[:70]!r}")
for b_, ns in per_bab.items():
    print(f"{b_}: {len(ns)} kalimat, rata-rata {sum(ns) / len(ns):.1f} kata, maks {max(ns)}, "
          f"pendek(<=8) {sum(n <= 8 for n in ns)}, sedang(9-18) {sum(9 <= n <= 18 for n in ns)}, panjang(>18) {sum(n > 18 for n in ns)}")

# H.3.2-3 frasa terlarang
BANNED = ["akibatnya", "selain itu", "oleh karena itu", "dengan demikian", "lebih lanjut", "di sisi lain",
          "pada akhirnya", "secara keseluruhan", "hal ini menunjukkan bahwa", "perlu dicatat bahwa",
          "tidak dapat dipungkiri", "dalam hal ini", "di era digital", "seiring perkembangan zaman",
          "dalam dunia yang semakin", "memainkan peran penting", "menjadi kunci", "tidak hanya",
          "berbagai macam", "memberikan kemudahan bagi pengguna", "komprehensif", "holistik", "signifikan",
          "krusial", "esensial", "fundamental", "optimalisasi", "implementatif", "transformatif", "inovatif",
          "revolusioner", "robust", "seamless", "nah", "karena itu"]
full_isi = " ".join(t for _, t, _ in isi)
kp = " ".join(text_of(p) for k, p in blocks[:80] if k == "p")
for w in BANNED:
    for src, txt in (("isi", full_isi), ("depan", kp)):
        if re.search(r"\b" + re.escape(w) + r"\b", txt, re.I):
            err(f"frasa terlarang ({src}): {w}")
alltext = " ".join(text_of(p) for p in all_ps)
if "—" in alltext:
    err("ada em dash")
if "?" in " ".join(t for _, t, item in isi if not item):
    err("ada tanda tanya di paragraf isi (pertanyaan retoris?)")

# H.3.5 konsistensi italic istilah asing
ital = Counter()
plain_text = []
for k, p in blocks:
    if k != "p":
        continue
    for r in p.iter(qn("w:r")):
        t = "".join(x.text or "" for x in r.iter(qn("w:t")))
        rpr = r.find(qn("w:rPr"))
        i = rpr is not None and rpr.find(qn("w:i")) is not None and rpr.find(qn("w:i")).get(W) not in ("0", "false")
        if i and t.strip():
            ital[t.strip().lower()] += 1
        elif t:
            plain_text.append(t)
plain = " ".join(plain_text)
plain_wo_ref = plain.split("DAFTAR PUSTAKA")[0]
for term in sorted(ital):
    if len(term) < 3 or term in ("cryptography",):
        continue
    hits = re.findall(r"(?<![\w-])" + re.escape(term) + r"(?![\w-])", plain_wo_ref, re.I)
    if hits:
        print(f"  catatan italic: '{term}' juga muncul tanpa italic {len(hits)}x")
print("Istilah italic:", ", ".join(sorted(ital)))

# ---------------- H.2 sitasi
cit_re = re.compile(r"\(([^()]*?\d{4}[a-z]?)\)")
cites = Counter()
for m in cit_re.finditer(full_isi):
    for part in m.group(1).split(";"):
        part = part.strip()
        mm = re.match(r"(.+?),\s*(\d{4})$", part)
        if mm:
            cites[(mm.group(1).strip(), mm.group(2))] += 1
# daftar pustaka
pus = []
seen = False
for k, p in blocks:
    if k == "p" and para_style(p) == "Heading1" and text_of(p) == "DAFTAR PUSTAKA":
        seen = True
        continue
    if seen and k == "p" and text_of(p).strip():
        pus.append(text_of(p))
print("Entri pustaka (termasuk GitHub):", len(pus))
if not (pus and ("github" in pus[0].lower() or "[ISI" in pus[0])):
    err("baris pertama pustaka bukan link GitHub")
refs = pus[1:]
keys = []
for r in refs:
    m = re.match(r"(.+?)\((\d{4})\)", r)
    authors = m.group(1)
    names = re.findall(r"([A-Z][\w'\-]+(?: [A-Z][\w'\-]+)*), (?:[A-Z]\.[ -]?)+", authors)
    if not names:
        names = [authors.strip().rstrip(".")]
    keys.append((names, m.group(2), r))
if [k[2] for k in keys] != sorted([k[2] for k in keys], key=lambda s: s.lower()):
    err("pustaka tidak urut alfabet")


def cite_key(names):
    if len(names) == 1:
        return names[0]
    if len(names) == 2:
        return f"{names[0]} & {names[1]}"
    return f"{names[0]} et al."


expected = Counter()
for names, yr, _ in keys:
    expected[(cite_key(names), yr)] += 1
for c in cites:
    if c not in expected:
        err(f"sitasi tanpa pustaka: {c}")
for e in expected:
    if e not in cites:
        err(f"pustaka tidak dikutip: {e}")
print("Sitasi unik:", len(cites), "| total sitasi:", sum(cites.values()))
narr = re.findall(r"[A-Z][a-z]+(?: et al\.| & [A-Z][a-z]+)? \(\d{4}\)", full_isi)
print("Sitasi naratif:", narr)

# H.2.5 cocokkan dengan .ris
ris_path = HERE / "Referensi_BistroKiosk_Mendeley.ris"
if ris_path.exists():
    ris = ris_path.read_text(encoding="utf-8")
    entries = [e for e in ris.split("ER  - ") if e.strip()]
    if len(entries) != len(refs):
        err(f".ris {len(entries)} entri vs pustaka {len(refs)}")
    for names, yr, r in keys:
        doi = re.search(r"https://doi\.org/(\S+)", r)
        if doi and doi.group(1) not in ris:
            err(f"DOI tidak ada di .ris: {doi.group(1)}")
        if f"PY  - {yr}" not in ris:
            err(f"tahun {yr} tidak ada di .ris")
else:
    print("(.ris belum ada)")

print()
print("TEMUAN:", len(errors))
for e in errors:
    print(" -", e)
