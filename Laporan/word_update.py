"""Buka laporan di Microsoft Word, perbarui semua field (Daftar Isi/Gambar/Tabel, SEQ, PAGE), simpan, ekspor PDF."""
import sys
from pathlib import Path

import pythoncom
import win32com.client as win32

src = Path(sys.argv[1]).resolve()
pdf = src.with_suffix(".pdf")
pythoncom.CoInitialize()
word = win32.DispatchEx("Word.Application")
word.Visible = False
word.DisplayAlerts = 0
try:
    doc = word.Documents.Open(str(src), ConfirmConversions=False, ReadOnly=False, AddToRecentFiles=False)
    doc.Fields.Update()
    for i in range(1, doc.TablesOfContents.Count + 1):
        doc.TablesOfContents(i).Update()
    for i in range(1, doc.TablesOfFigures.Count + 1):
        doc.TablesOfFigures(i).Update()
    doc.Repaginate()
    for i in range(1, doc.TablesOfContents.Count + 1):
        doc.TablesOfContents(i).UpdatePageNumbers()
    for i in range(1, doc.TablesOfFigures.Count + 1):
        doc.TablesOfFigures(i).UpdatePageNumbers()
    print("pages", doc.ComputeStatistics(2))
    doc.Save()
    doc.ExportAsFixedFormat(str(pdf), 17)  # wdExportFormatPDF
    doc.Close(False)
    print("ok", pdf)
finally:
    word.Quit()
