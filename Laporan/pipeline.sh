#!/bin/sh
# build docx -> update field di Word -> PDF -> laporan keterisian halaman
cd "$(dirname "$0")"
python build_laporan.py && timeout 240 python word_update.py Laporan_BistroKiosk.docx && python -c "
import fitz,sys
sys.stdout.reconfigure(encoding='utf-8')
d=fitz.open('Laporan_BistroKiosk.pdf')
top=3/2.54*72; bot=d[0].rect.height-3/2.54*72; H=bot-top
for i,pg in enumerate(d):
    ys=[b[3] for b in pg.get_text('blocks') if b[1]>top-5 and b[3]<bot+5 and b[4].strip()]
    imgs=[r.y1 for img in pg.get_images() for r in pg.get_image_rects(img[0])]
    y=max(ys+imgs+[top]); f=(y-top)/H
    nxt=d[i+1].get_text().strip().split('\n')[0] if i+1<len(d) else ''
    flag='  <-- KURANG' if f<0.8 and not nxt.startswith(('BAB','DAFTAR')) else ''
    print(i+1, f'{f:.0%}', pg.get_text().strip().split('\n')[:2], flag)
"
