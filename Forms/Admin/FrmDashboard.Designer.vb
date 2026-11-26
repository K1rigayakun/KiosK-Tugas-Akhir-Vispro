Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Admin

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmDashboard
        Inherits System.Windows.Forms.Form

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlRoot = New System.Windows.Forms.Panel()
            Me.tlpBottom = New System.Windows.Forms.TableLayoutPanel()
            Me.cardGrafik = New Guna.UI2.WinForms.Guna2Panel()
            Me.pnlGrafikHost = New System.Windows.Forms.Panel()
            Me.barPrev1 = New Guna.UI2.WinForms.Guna2Panel()
            Me.barPrev2 = New Guna.UI2.WinForms.Guna2Panel()
            Me.barPrev3 = New Guna.UI2.WinForms.Guna2Panel()
            Me.barPrev4 = New Guna.UI2.WinForms.Guna2Panel()
            Me.barPrev5 = New Guna.UI2.WinForms.Guna2Panel()
            Me.barPrev6 = New Guna.UI2.WinForms.Guna2Panel()
            Me.barPrev7 = New Guna.UI2.WinForms.Guna2Panel()
            Me.pnlPrevAxis = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblGraf = New System.Windows.Forms.Label()
            Me.cardTop5 = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvTop5 = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colPeringkat = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colNamaMenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTerjual = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colOmzet = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblTop = New System.Windows.Forms.Label()
            Me.tlpKpi = New System.Windows.Forms.TableLayoutPanel()
            Me.cardKpiPendapatan = New Guna.UI2.WinForms.Guna2Panel()
            Me.stripPendapatan = New Guna.UI2.WinForms.Guna2Panel()
            Me.icoPendapatan = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblJudulPendapatan = New System.Windows.Forms.Label()
            Me.lblValPendapatan = New System.Windows.Forms.Label()
            Me.lblSubPendapatan = New System.Windows.Forms.Label()
            Me.cardKpiJumlah = New Guna.UI2.WinForms.Guna2Panel()
            Me.stripJumlah = New Guna.UI2.WinForms.Guna2Panel()
            Me.icoJumlah = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblJudulJumlah = New System.Windows.Forms.Label()
            Me.lblValJumlah = New System.Windows.Forms.Label()
            Me.lblSubJumlah = New System.Windows.Forms.Label()
            Me.cardKpiRata = New Guna.UI2.WinForms.Guna2Panel()
            Me.stripRata = New Guna.UI2.WinForms.Guna2Panel()
            Me.icoRata = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblJudulRata = New System.Windows.Forms.Label()
            Me.lblValRata = New System.Windows.Forms.Label()
            Me.lblSubRata = New System.Windows.Forms.Label()
            Me.cardKpiBatal = New Guna.UI2.WinForms.Guna2Panel()
            Me.stripBatal = New Guna.UI2.WinForms.Guna2Panel()
            Me.icoBatal = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblJudulBatal = New System.Windows.Forms.Label()
            Me.lblValBatal = New System.Windows.Forms.Label()
            Me.lblSubBatal = New System.Windows.Forms.Label()
            Me.cardKpiStok = New Guna.UI2.WinForms.Guna2Panel()
            Me.stripStok = New Guna.UI2.WinForms.Guna2Panel()
            Me.icoStok = New Guna.UI2.WinForms.Guna2CirclePictureBox()
            Me.lblJudulStok = New System.Windows.Forms.Label()
            Me.lblValStok = New System.Windows.Forms.Label()
            Me.lblSubStok = New System.Windows.Forms.Label()
            Me.pnlHead = New System.Windows.Forms.Panel()
            Me.lblH = New System.Windows.Forms.Label()
            Me.btnRef = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlRoot.SuspendLayout()
            Me.tlpBottom.SuspendLayout()
            Me.cardGrafik.SuspendLayout()
            Me.pnlGrafikHost.SuspendLayout()
            Me.cardTop5.SuspendLayout()
            CType(Me.dgvTop5, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tlpKpi.SuspendLayout()
            Me.cardKpiPendapatan.SuspendLayout()
            CType(Me.icoPendapatan, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardKpiJumlah.SuspendLayout()
            CType(Me.icoJumlah, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardKpiRata.SuspendLayout()
            CType(Me.icoRata, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardKpiBatal.SuspendLayout()
            CType(Me.icoBatal, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardKpiStok.SuspendLayout()
            CType(Me.icoStok, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlHead.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlRoot
            '
            Me.pnlRoot.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.pnlRoot.Controls.Add(Me.tlpBottom)
            Me.pnlRoot.Controls.Add(Me.tlpKpi)
            Me.pnlRoot.Controls.Add(Me.pnlHead)
            Me.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlRoot.Location = New System.Drawing.Point(0, 0)
            Me.pnlRoot.Name = "pnlRoot"
            Me.pnlRoot.Padding = New System.Windows.Forms.Padding(20)
            Me.pnlRoot.Size = New System.Drawing.Size(1180, 680)
            Me.pnlRoot.TabIndex = 0
            '
            'pnlHead
            '
            Me.pnlHead.BackColor = System.Drawing.Color.Transparent
            Me.pnlHead.Controls.Add(Me.btnRef)
            Me.pnlHead.Controls.Add(Me.lblH)
            Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHead.Location = New System.Drawing.Point(20, 20)
            Me.pnlHead.Name = "pnlHead"
            Me.pnlHead.Size = New System.Drawing.Size(1140, 48)
            Me.pnlHead.TabIndex = 0
            '
            'lblH
            '
            Me.lblH.Font = New System.Drawing.Font("Georgia", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblH.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblH.Location = New System.Drawing.Point(0, 4)
            Me.lblH.Name = "lblH"
            Me.lblH.Size = New System.Drawing.Size(540, 34)
            Me.lblH.TabIndex = 0
            Me.lblH.Text = "Ringkasan Eksekutif Hari Ini"
            '
            'btnRef
            '
            Me.btnRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRef.BackColor = System.Drawing.Color.Transparent
            Me.btnRef.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnRef.BorderRadius = 12
            Me.btnRef.BorderThickness = 1
            Me.btnRef.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRef.FillColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.btnRef.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnRef.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnRef.Location = New System.Drawing.Point(1010, 4)
            Me.btnRef.Name = "btnRef"
            Me.btnRef.Size = New System.Drawing.Size(128, 38)
            Me.btnRef.TabIndex = 1
            Me.btnRef.Text = "Segarkan"
            Me.btnRef.UseTransparentBackground = True
            '
            'tlpKpi
            '
            Me.tlpKpi.BackColor = System.Drawing.Color.Transparent
            Me.tlpKpi.ColumnCount = 5
            Me.tlpKpi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.tlpKpi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.tlpKpi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.tlpKpi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.tlpKpi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.tlpKpi.Controls.Add(Me.cardKpiPendapatan, 0, 0)
            Me.tlpKpi.Controls.Add(Me.cardKpiJumlah, 1, 0)
            Me.tlpKpi.Controls.Add(Me.cardKpiRata, 2, 0)
            Me.tlpKpi.Controls.Add(Me.cardKpiBatal, 3, 0)
            Me.tlpKpi.Controls.Add(Me.cardKpiStok, 4, 0)
            Me.tlpKpi.Dock = System.Windows.Forms.DockStyle.Top
            Me.tlpKpi.Location = New System.Drawing.Point(20, 68)
            Me.tlpKpi.Name = "tlpKpi"
            Me.tlpKpi.RowCount = 1
            Me.tlpKpi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.tlpKpi.Size = New System.Drawing.Size(1140, 128)
            Me.tlpKpi.TabIndex = 1
            '
            'cardKpiPendapatan
            '
            Me.cardKpiPendapatan.BackColor = System.Drawing.Color.Transparent
            Me.cardKpiPendapatan.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardKpiPendapatan.BorderRadius = 16
            Me.cardKpiPendapatan.BorderThickness = 1
            Me.cardKpiPendapatan.Controls.Add(Me.stripPendapatan)
            Me.cardKpiPendapatan.Controls.Add(Me.icoPendapatan)
            Me.cardKpiPendapatan.Controls.Add(Me.lblJudulPendapatan)
            Me.cardKpiPendapatan.Controls.Add(Me.lblValPendapatan)
            Me.cardKpiPendapatan.Controls.Add(Me.lblSubPendapatan)
            Me.cardKpiPendapatan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardKpiPendapatan.FillColor = System.Drawing.Color.White
            Me.cardKpiPendapatan.Location = New System.Drawing.Point(0, 4)
            Me.cardKpiPendapatan.Margin = New System.Windows.Forms.Padding(0, 4, 12, 10)
            Me.cardKpiPendapatan.Name = "cardKpiPendapatan"
            Me.cardKpiPendapatan.Size = New System.Drawing.Size(216, 114)
            Me.cardKpiPendapatan.TabIndex = 0
            Me.cardKpiPendapatan.UseTransparentBackground = True
            '
            'stripPendapatan
            '
            Me.stripPendapatan.BackColor = System.Drawing.Color.Transparent
            Me.stripPendapatan.BorderRadius = 3
            Me.stripPendapatan.FillColor = System.Drawing.Color.FromArgb(74, 124, 89)
            Me.stripPendapatan.Location = New System.Drawing.Point(12, 19)
            Me.stripPendapatan.Name = "stripPendapatan"
            Me.stripPendapatan.Size = New System.Drawing.Size(5, 76)
            Me.stripPendapatan.TabIndex = 0
            Me.stripPendapatan.UseTransparentBackground = True
            '
            'icoPendapatan
            '
            Me.icoPendapatan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.icoPendapatan.BackColor = System.Drawing.Color.Transparent
            Me.icoPendapatan.FillColor = System.Drawing.Color.FromArgb(234, 243, 236)
            Me.icoPendapatan.Location = New System.Drawing.Point(162, 14)
            Me.icoPendapatan.Name = "icoPendapatan"
            Me.icoPendapatan.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.icoPendapatan.Size = New System.Drawing.Size(40, 40)
            Me.icoPendapatan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icoPendapatan.TabIndex = 1
            Me.icoPendapatan.TabStop = False
            Me.icoPendapatan.UseTransparentBackground = True
            '
            'lblJudulPendapatan
            '
            Me.lblJudulPendapatan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblJudulPendapatan.BackColor = System.Drawing.Color.Transparent
            Me.lblJudulPendapatan.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblJudulPendapatan.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblJudulPendapatan.Location = New System.Drawing.Point(24, 14)
            Me.lblJudulPendapatan.Name = "lblJudulPendapatan"
            Me.lblJudulPendapatan.Size = New System.Drawing.Size(134, 22)
            Me.lblJudulPendapatan.TabIndex = 2
            Me.lblJudulPendapatan.Text = "Pendapatan Hari Ini"
            '
            'lblValPendapatan
            '
            Me.lblValPendapatan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblValPendapatan.BackColor = System.Drawing.Color.Transparent
            Me.lblValPendapatan.Font = New System.Drawing.Font("Georgia", 17.5!, System.Drawing.FontStyle.Bold)
            Me.lblValPendapatan.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblValPendapatan.Location = New System.Drawing.Point(24, 40)
            Me.lblValPendapatan.Name = "lblValPendapatan"
            Me.lblValPendapatan.Size = New System.Drawing.Size(180, 36)
            Me.lblValPendapatan.TabIndex = 3
            Me.lblValPendapatan.Text = "Rp0"
            '
            'lblSubPendapatan
            '
            Me.lblSubPendapatan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubPendapatan.BackColor = System.Drawing.Color.Transparent
            Me.lblSubPendapatan.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblSubPendapatan.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSubPendapatan.Location = New System.Drawing.Point(24, 80)
            Me.lblSubPendapatan.Name = "lblSubPendapatan"
            Me.lblSubPendapatan.Size = New System.Drawing.Size(180, 22)
            Me.lblSubPendapatan.TabIndex = 4
            Me.lblSubPendapatan.Text = "Pesanan Lunas hari ini"
            '
            'cardKpiJumlah
            '
            Me.cardKpiJumlah.BackColor = System.Drawing.Color.Transparent
            Me.cardKpiJumlah.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardKpiJumlah.BorderRadius = 16
            Me.cardKpiJumlah.BorderThickness = 1
            Me.cardKpiJumlah.Controls.Add(Me.stripJumlah)
            Me.cardKpiJumlah.Controls.Add(Me.icoJumlah)
            Me.cardKpiJumlah.Controls.Add(Me.lblJudulJumlah)
            Me.cardKpiJumlah.Controls.Add(Me.lblValJumlah)
            Me.cardKpiJumlah.Controls.Add(Me.lblSubJumlah)
            Me.cardKpiJumlah.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardKpiJumlah.FillColor = System.Drawing.Color.White
            Me.cardKpiJumlah.Location = New System.Drawing.Point(228, 4)
            Me.cardKpiJumlah.Margin = New System.Windows.Forms.Padding(0, 4, 12, 10)
            Me.cardKpiJumlah.Name = "cardKpiJumlah"
            Me.cardKpiJumlah.Size = New System.Drawing.Size(216, 114)
            Me.cardKpiJumlah.TabIndex = 1
            Me.cardKpiJumlah.UseTransparentBackground = True
            '
            'stripJumlah
            '
            Me.stripJumlah.BackColor = System.Drawing.Color.Transparent
            Me.stripJumlah.BorderRadius = 3
            Me.stripJumlah.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.stripJumlah.Location = New System.Drawing.Point(12, 19)
            Me.stripJumlah.Name = "stripJumlah"
            Me.stripJumlah.Size = New System.Drawing.Size(5, 76)
            Me.stripJumlah.TabIndex = 0
            Me.stripJumlah.UseTransparentBackground = True
            '
            'icoJumlah
            '
            Me.icoJumlah.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.icoJumlah.BackColor = System.Drawing.Color.Transparent
            Me.icoJumlah.FillColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.icoJumlah.Location = New System.Drawing.Point(162, 14)
            Me.icoJumlah.Name = "icoJumlah"
            Me.icoJumlah.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.icoJumlah.Size = New System.Drawing.Size(40, 40)
            Me.icoJumlah.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icoJumlah.TabIndex = 1
            Me.icoJumlah.TabStop = False
            Me.icoJumlah.UseTransparentBackground = True
            '
            'lblJudulJumlah
            '
            Me.lblJudulJumlah.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblJudulJumlah.BackColor = System.Drawing.Color.Transparent
            Me.lblJudulJumlah.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblJudulJumlah.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblJudulJumlah.Location = New System.Drawing.Point(24, 14)
            Me.lblJudulJumlah.Name = "lblJudulJumlah"
            Me.lblJudulJumlah.Size = New System.Drawing.Size(134, 22)
            Me.lblJudulJumlah.TabIndex = 2
            Me.lblJudulJumlah.Text = "Jumlah Pesanan"
            '
            'lblValJumlah
            '
            Me.lblValJumlah.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblValJumlah.BackColor = System.Drawing.Color.Transparent
            Me.lblValJumlah.Font = New System.Drawing.Font("Georgia", 17.5!, System.Drawing.FontStyle.Bold)
            Me.lblValJumlah.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblValJumlah.Location = New System.Drawing.Point(24, 40)
            Me.lblValJumlah.Name = "lblValJumlah"
            Me.lblValJumlah.Size = New System.Drawing.Size(180, 36)
            Me.lblValJumlah.TabIndex = 3
            Me.lblValJumlah.Text = "0"
            '
            'lblSubJumlah
            '
            Me.lblSubJumlah.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubJumlah.BackColor = System.Drawing.Color.Transparent
            Me.lblSubJumlah.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblSubJumlah.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSubJumlah.Location = New System.Drawing.Point(24, 80)
            Me.lblSubJumlah.Name = "lblSubJumlah"
            Me.lblSubJumlah.Size = New System.Drawing.Size(180, 22)
            Me.lblSubJumlah.TabIndex = 4
            Me.lblSubJumlah.Text = "Total transaksi hari ini"
            '
            'cardKpiRata
            '
            Me.cardKpiRata.BackColor = System.Drawing.Color.Transparent
            Me.cardKpiRata.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardKpiRata.BorderRadius = 16
            Me.cardKpiRata.BorderThickness = 1
            Me.cardKpiRata.Controls.Add(Me.stripRata)
            Me.cardKpiRata.Controls.Add(Me.icoRata)
            Me.cardKpiRata.Controls.Add(Me.lblJudulRata)
            Me.cardKpiRata.Controls.Add(Me.lblValRata)
            Me.cardKpiRata.Controls.Add(Me.lblSubRata)
            Me.cardKpiRata.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardKpiRata.FillColor = System.Drawing.Color.White
            Me.cardKpiRata.Location = New System.Drawing.Point(456, 4)
            Me.cardKpiRata.Margin = New System.Windows.Forms.Padding(0, 4, 12, 10)
            Me.cardKpiRata.Name = "cardKpiRata"
            Me.cardKpiRata.Size = New System.Drawing.Size(216, 114)
            Me.cardKpiRata.TabIndex = 2
            Me.cardKpiRata.UseTransparentBackground = True
            '
            'stripRata
            '
            Me.stripRata.BackColor = System.Drawing.Color.Transparent
            Me.stripRata.BorderRadius = 3
            Me.stripRata.FillColor = System.Drawing.Color.FromArgb(139, 69, 19)
            Me.stripRata.Location = New System.Drawing.Point(12, 19)
            Me.stripRata.Name = "stripRata"
            Me.stripRata.Size = New System.Drawing.Size(5, 76)
            Me.stripRata.TabIndex = 0
            Me.stripRata.UseTransparentBackground = True
            '
            'icoRata
            '
            Me.icoRata.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.icoRata.BackColor = System.Drawing.Color.Transparent
            Me.icoRata.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.icoRata.Location = New System.Drawing.Point(162, 14)
            Me.icoRata.Name = "icoRata"
            Me.icoRata.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.icoRata.Size = New System.Drawing.Size(40, 40)
            Me.icoRata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icoRata.TabIndex = 1
            Me.icoRata.TabStop = False
            Me.icoRata.UseTransparentBackground = True
            '
            'lblJudulRata
            '
            Me.lblJudulRata.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblJudulRata.BackColor = System.Drawing.Color.Transparent
            Me.lblJudulRata.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblJudulRata.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblJudulRata.Location = New System.Drawing.Point(24, 14)
            Me.lblJudulRata.Name = "lblJudulRata"
            Me.lblJudulRata.Size = New System.Drawing.Size(134, 22)
            Me.lblJudulRata.TabIndex = 2
            Me.lblJudulRata.Text = "Rata-Rata Order"
            '
            'lblValRata
            '
            Me.lblValRata.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblValRata.BackColor = System.Drawing.Color.Transparent
            Me.lblValRata.Font = New System.Drawing.Font("Georgia", 17.5!, System.Drawing.FontStyle.Bold)
            Me.lblValRata.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblValRata.Location = New System.Drawing.Point(24, 40)
            Me.lblValRata.Name = "lblValRata"
            Me.lblValRata.Size = New System.Drawing.Size(180, 36)
            Me.lblValRata.TabIndex = 3
            Me.lblValRata.Text = "Rp0"
            '
            'lblSubRata
            '
            Me.lblSubRata.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubRata.BackColor = System.Drawing.Color.Transparent
            Me.lblSubRata.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblSubRata.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSubRata.Location = New System.Drawing.Point(24, 80)
            Me.lblSubRata.Name = "lblSubRata"
            Me.lblSubRata.Size = New System.Drawing.Size(180, 22)
            Me.lblSubRata.TabIndex = 4
            Me.lblSubRata.Text = "Nilai per transaksi sah"
            '
            'cardKpiBatal
            '
            Me.cardKpiBatal.BackColor = System.Drawing.Color.Transparent
            Me.cardKpiBatal.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardKpiBatal.BorderRadius = 16
            Me.cardKpiBatal.BorderThickness = 1
            Me.cardKpiBatal.Controls.Add(Me.stripBatal)
            Me.cardKpiBatal.Controls.Add(Me.icoBatal)
            Me.cardKpiBatal.Controls.Add(Me.lblJudulBatal)
            Me.cardKpiBatal.Controls.Add(Me.lblValBatal)
            Me.cardKpiBatal.Controls.Add(Me.lblSubBatal)
            Me.cardKpiBatal.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardKpiBatal.FillColor = System.Drawing.Color.White
            Me.cardKpiBatal.Location = New System.Drawing.Point(684, 4)
            Me.cardKpiBatal.Margin = New System.Windows.Forms.Padding(0, 4, 12, 10)
            Me.cardKpiBatal.Name = "cardKpiBatal"
            Me.cardKpiBatal.Size = New System.Drawing.Size(216, 114)
            Me.cardKpiBatal.TabIndex = 3
            Me.cardKpiBatal.UseTransparentBackground = True
            '
            'stripBatal
            '
            Me.stripBatal.BackColor = System.Drawing.Color.Transparent
            Me.stripBatal.BorderRadius = 3
            Me.stripBatal.FillColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.stripBatal.Location = New System.Drawing.Point(12, 19)
            Me.stripBatal.Name = "stripBatal"
            Me.stripBatal.Size = New System.Drawing.Size(5, 76)
            Me.stripBatal.TabIndex = 0
            Me.stripBatal.UseTransparentBackground = True
            '
            'icoBatal
            '
            Me.icoBatal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.icoBatal.BackColor = System.Drawing.Color.Transparent
            Me.icoBatal.FillColor = System.Drawing.Color.FromArgb(253, 236, 236)
            Me.icoBatal.Location = New System.Drawing.Point(162, 14)
            Me.icoBatal.Name = "icoBatal"
            Me.icoBatal.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.icoBatal.Size = New System.Drawing.Size(40, 40)
            Me.icoBatal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icoBatal.TabIndex = 1
            Me.icoBatal.TabStop = False
            Me.icoBatal.UseTransparentBackground = True
            '
            'lblJudulBatal
            '
            Me.lblJudulBatal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblJudulBatal.BackColor = System.Drawing.Color.Transparent
            Me.lblJudulBatal.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblJudulBatal.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblJudulBatal.Location = New System.Drawing.Point(24, 14)
            Me.lblJudulBatal.Name = "lblJudulBatal"
            Me.lblJudulBatal.Size = New System.Drawing.Size(134, 22)
            Me.lblJudulBatal.TabIndex = 2
            Me.lblJudulBatal.Text = "Pesanan Dibatalkan"
            '
            'lblValBatal
            '
            Me.lblValBatal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblValBatal.BackColor = System.Drawing.Color.Transparent
            Me.lblValBatal.Font = New System.Drawing.Font("Georgia", 17.5!, System.Drawing.FontStyle.Bold)
            Me.lblValBatal.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblValBatal.Location = New System.Drawing.Point(24, 40)
            Me.lblValBatal.Name = "lblValBatal"
            Me.lblValBatal.Size = New System.Drawing.Size(180, 36)
            Me.lblValBatal.TabIndex = 3
            Me.lblValBatal.Text = "0"
            '
            'lblSubBatal
            '
            Me.lblSubBatal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubBatal.BackColor = System.Drawing.Color.Transparent
            Me.lblSubBatal.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblSubBatal.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSubBatal.Location = New System.Drawing.Point(24, 80)
            Me.lblSubBatal.Name = "lblSubBatal"
            Me.lblSubBatal.Size = New System.Drawing.Size(180, 22)
            Me.lblSubBatal.TabIndex = 4
            Me.lblSubBatal.Text = "Transaksi batal hari ini"
            '
            'cardKpiStok
            '
            Me.cardKpiStok.BackColor = System.Drawing.Color.Transparent
            Me.cardKpiStok.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardKpiStok.BorderRadius = 16
            Me.cardKpiStok.BorderThickness = 1
            Me.cardKpiStok.Controls.Add(Me.stripStok)
            Me.cardKpiStok.Controls.Add(Me.icoStok)
            Me.cardKpiStok.Controls.Add(Me.lblJudulStok)
            Me.cardKpiStok.Controls.Add(Me.lblValStok)
            Me.cardKpiStok.Controls.Add(Me.lblSubStok)
            Me.cardKpiStok.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardKpiStok.FillColor = System.Drawing.Color.White
            Me.cardKpiStok.Location = New System.Drawing.Point(912, 4)
            Me.cardKpiStok.Margin = New System.Windows.Forms.Padding(0, 4, 0, 10)
            Me.cardKpiStok.Name = "cardKpiStok"
            Me.cardKpiStok.Size = New System.Drawing.Size(228, 114)
            Me.cardKpiStok.TabIndex = 4
            Me.cardKpiStok.UseTransparentBackground = True
            '
            'stripStok
            '
            Me.stripStok.BackColor = System.Drawing.Color.Transparent
            Me.stripStok.BorderRadius = 3
            Me.stripStok.FillColor = System.Drawing.Color.FromArgb(200, 116, 30)
            Me.stripStok.Location = New System.Drawing.Point(12, 19)
            Me.stripStok.Name = "stripStok"
            Me.stripStok.Size = New System.Drawing.Size(5, 76)
            Me.stripStok.TabIndex = 0
            Me.stripStok.UseTransparentBackground = True
            '
            'icoStok
            '
            Me.icoStok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.icoStok.BackColor = System.Drawing.Color.Transparent
            Me.icoStok.FillColor = System.Drawing.Color.FromArgb(255, 243, 223)
            Me.icoStok.Location = New System.Drawing.Point(174, 14)
            Me.icoStok.Name = "icoStok"
            Me.icoStok.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
            Me.icoStok.Size = New System.Drawing.Size(40, 40)
            Me.icoStok.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.icoStok.TabIndex = 1
            Me.icoStok.TabStop = False
            Me.icoStok.UseTransparentBackground = True
            '
            'lblJudulStok
            '
            Me.lblJudulStok.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblJudulStok.BackColor = System.Drawing.Color.Transparent
            Me.lblJudulStok.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblJudulStok.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblJudulStok.Location = New System.Drawing.Point(24, 14)
            Me.lblJudulStok.Name = "lblJudulStok"
            Me.lblJudulStok.Size = New System.Drawing.Size(144, 22)
            Me.lblJudulStok.TabIndex = 2
            Me.lblJudulStok.Text = "Stok Menipis"
            '
            'lblValStok
            '
            Me.lblValStok.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblValStok.BackColor = System.Drawing.Color.Transparent
            Me.lblValStok.Font = New System.Drawing.Font("Georgia", 17.5!, System.Drawing.FontStyle.Bold)
            Me.lblValStok.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblValStok.Location = New System.Drawing.Point(24, 40)
            Me.lblValStok.Name = "lblValStok"
            Me.lblValStok.Size = New System.Drawing.Size(192, 36)
            Me.lblValStok.TabIndex = 3
            Me.lblValStok.Text = "0"
            '
            'lblSubStok
            '
            Me.lblSubStok.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubStok.BackColor = System.Drawing.Color.Transparent
            Me.lblSubStok.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblSubStok.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblSubStok.Location = New System.Drawing.Point(24, 80)
            Me.lblSubStok.Name = "lblSubStok"
            Me.lblSubStok.Size = New System.Drawing.Size(192, 22)
            Me.lblSubStok.TabIndex = 4
            Me.lblSubStok.Text = "Produk di bawah 5 unit"
            '
            'tlpBottom
            '
            Me.tlpBottom.BackColor = System.Drawing.Color.Transparent
            Me.tlpBottom.ColumnCount = 2
            Me.tlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.0!))
            Me.tlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.0!))
            Me.tlpBottom.Controls.Add(Me.cardGrafik, 0, 0)
            Me.tlpBottom.Controls.Add(Me.cardTop5, 1, 0)
            Me.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tlpBottom.Location = New System.Drawing.Point(20, 196)
            Me.tlpBottom.Name = "tlpBottom"
            Me.tlpBottom.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
            Me.tlpBottom.RowCount = 1
            Me.tlpBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.tlpBottom.Size = New System.Drawing.Size(1140, 464)
            Me.tlpBottom.TabIndex = 2
            '
            'cardGrafik
            '
            Me.cardGrafik.BackColor = System.Drawing.Color.Transparent
            Me.cardGrafik.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGrafik.BorderRadius = 16
            Me.cardGrafik.BorderThickness = 1
            Me.cardGrafik.Controls.Add(Me.pnlGrafikHost)
            Me.cardGrafik.Controls.Add(Me.lblGraf)
            Me.cardGrafik.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGrafik.FillColor = System.Drawing.Color.White
            Me.cardGrafik.Location = New System.Drawing.Point(0, 8)
            Me.cardGrafik.Margin = New System.Windows.Forms.Padding(0, 0, 14, 0)
            Me.cardGrafik.Name = "cardGrafik"
            Me.cardGrafik.Padding = New System.Windows.Forms.Padding(18)
            Me.cardGrafik.Size = New System.Drawing.Size(647, 456)
            Me.cardGrafik.TabIndex = 0
            Me.cardGrafik.UseTransparentBackground = True
            '
            'lblGraf
            '
            Me.lblGraf.BackColor = System.Drawing.Color.Transparent
            Me.lblGraf.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblGraf.Font = New System.Drawing.Font("Georgia", 14.5!, System.Drawing.FontStyle.Bold)
            Me.lblGraf.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblGraf.Location = New System.Drawing.Point(18, 18)
            Me.lblGraf.Name = "lblGraf"
            Me.lblGraf.Size = New System.Drawing.Size(611, 34)
            Me.lblGraf.TabIndex = 0
            Me.lblGraf.Text = "Tren Omzet 7 Hari Terakhir"
            '
            'pnlGrafikHost
            '
            Me.pnlGrafikHost.BackColor = System.Drawing.Color.White
            Me.pnlGrafikHost.Controls.Add(Me.barPrev1)
            Me.pnlGrafikHost.Controls.Add(Me.barPrev2)
            Me.pnlGrafikHost.Controls.Add(Me.barPrev3)
            Me.pnlGrafikHost.Controls.Add(Me.barPrev4)
            Me.pnlGrafikHost.Controls.Add(Me.barPrev5)
            Me.pnlGrafikHost.Controls.Add(Me.barPrev6)
            Me.pnlGrafikHost.Controls.Add(Me.barPrev7)
            Me.pnlGrafikHost.Controls.Add(Me.pnlPrevAxis)
            Me.pnlGrafikHost.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlGrafikHost.Location = New System.Drawing.Point(18, 52)
            Me.pnlGrafikHost.Name = "pnlGrafikHost"
            Me.pnlGrafikHost.Size = New System.Drawing.Size(611, 386)
            Me.pnlGrafikHost.TabIndex = 1
            '
            'barPrev1
            '
            Me.barPrev1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.barPrev1.BackColor = System.Drawing.Color.Transparent
            Me.barPrev1.BorderRadius = 6
            Me.barPrev1.BorderThickness = 0
            Me.barPrev1.CustomizableEdges.BottomLeft = False
            Me.barPrev1.CustomizableEdges.BottomRight = False
            Me.barPrev1.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.barPrev1.Location = New System.Drawing.Point(64, 166)
            Me.barPrev1.Name = "barPrev1"
            Me.barPrev1.Size = New System.Drawing.Size(44, 174)
            Me.barPrev1.TabIndex = 0
            Me.barPrev1.UseTransparentBackground = True
            '
            'barPrev2
            '
            Me.barPrev2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.barPrev2.BackColor = System.Drawing.Color.Transparent
            Me.barPrev2.BorderRadius = 6
            Me.barPrev2.BorderThickness = 0
            Me.barPrev2.CustomizableEdges.BottomLeft = False
            Me.barPrev2.CustomizableEdges.BottomRight = False
            Me.barPrev2.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.barPrev2.Location = New System.Drawing.Point(134, 72)
            Me.barPrev2.Name = "barPrev2"
            Me.barPrev2.Size = New System.Drawing.Size(44, 268)
            Me.barPrev2.TabIndex = 1
            Me.barPrev2.UseTransparentBackground = True
            '
            'barPrev3
            '
            Me.barPrev3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.barPrev3.BackColor = System.Drawing.Color.Transparent
            Me.barPrev3.BorderRadius = 6
            Me.barPrev3.BorderThickness = 0
            Me.barPrev3.CustomizableEdges.BottomLeft = False
            Me.barPrev3.CustomizableEdges.BottomRight = False
            Me.barPrev3.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.barPrev3.Location = New System.Drawing.Point(204, 122)
            Me.barPrev3.Name = "barPrev3"
            Me.barPrev3.Size = New System.Drawing.Size(44, 218)
            Me.barPrev3.TabIndex = 2
            Me.barPrev3.UseTransparentBackground = True
            '
            'barPrev4
            '
            Me.barPrev4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.barPrev4.BackColor = System.Drawing.Color.Transparent
            Me.barPrev4.BorderRadius = 6
            Me.barPrev4.BorderThickness = 0
            Me.barPrev4.CustomizableEdges.BottomLeft = False
            Me.barPrev4.CustomizableEdges.BottomRight = False
            Me.barPrev4.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.barPrev4.Location = New System.Drawing.Point(274, 148)
            Me.barPrev4.Name = "barPrev4"
            Me.barPrev4.Size = New System.Drawing.Size(44, 192)
            Me.barPrev4.TabIndex = 3
            Me.barPrev4.UseTransparentBackground = True
            '
            'barPrev5
            '
            Me.barPrev5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.barPrev5.BackColor = System.Drawing.Color.Transparent
            Me.barPrev5.BorderRadius = 6
            Me.barPrev5.BorderThickness = 0
            Me.barPrev5.CustomizableEdges.BottomLeft = False
            Me.barPrev5.CustomizableEdges.BottomRight = False
            Me.barPrev5.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.barPrev5.Location = New System.Drawing.Point(344, 62)
            Me.barPrev5.Name = "barPrev5"
            Me.barPrev5.Size = New System.Drawing.Size(44, 278)
            Me.barPrev5.TabIndex = 4
            Me.barPrev5.UseTransparentBackground = True
            '
            'barPrev6
            '
            Me.barPrev6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.barPrev6.BackColor = System.Drawing.Color.Transparent
            Me.barPrev6.BorderRadius = 6
            Me.barPrev6.BorderThickness = 0
            Me.barPrev6.CustomizableEdges.BottomLeft = False
            Me.barPrev6.CustomizableEdges.BottomRight = False
            Me.barPrev6.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.barPrev6.Location = New System.Drawing.Point(414, 92)
            Me.barPrev6.Name = "barPrev6"
            Me.barPrev6.Size = New System.Drawing.Size(44, 248)
            Me.barPrev6.TabIndex = 5
            Me.barPrev6.UseTransparentBackground = True
            '
            'barPrev7
            '
            Me.barPrev7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.barPrev7.BackColor = System.Drawing.Color.Transparent
            Me.barPrev7.BorderRadius = 6
            Me.barPrev7.BorderThickness = 0
            Me.barPrev7.CustomizableEdges.BottomLeft = False
            Me.barPrev7.CustomizableEdges.BottomRight = False
            Me.barPrev7.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.barPrev7.Location = New System.Drawing.Point(484, 158)
            Me.barPrev7.Name = "barPrev7"
            Me.barPrev7.Size = New System.Drawing.Size(44, 182)
            Me.barPrev7.TabIndex = 6
            Me.barPrev7.UseTransparentBackground = True
            '
            'pnlPrevAxis
            '
            Me.pnlPrevAxis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlPrevAxis.BackColor = System.Drawing.Color.Transparent
            Me.pnlPrevAxis.BorderRadius = 0
            Me.pnlPrevAxis.FillColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.pnlPrevAxis.Location = New System.Drawing.Point(36, 340)
            Me.pnlPrevAxis.Name = "pnlPrevAxis"
            Me.pnlPrevAxis.Size = New System.Drawing.Size(540, 2)
            Me.pnlPrevAxis.TabIndex = 7
            Me.pnlPrevAxis.UseTransparentBackground = True
            '
            'cardTop5
            '
            Me.cardTop5.BackColor = System.Drawing.Color.Transparent
            Me.cardTop5.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardTop5.BorderRadius = 16
            Me.cardTop5.BorderThickness = 1
            Me.cardTop5.Controls.Add(Me.dgvTop5)
            Me.cardTop5.Controls.Add(Me.lblTop)
            Me.cardTop5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardTop5.FillColor = System.Drawing.Color.White
            Me.cardTop5.Location = New System.Drawing.Point(661, 8)
            Me.cardTop5.Margin = New System.Windows.Forms.Padding(0)
            Me.cardTop5.Name = "cardTop5"
            Me.cardTop5.Padding = New System.Windows.Forms.Padding(18)
            Me.cardTop5.Size = New System.Drawing.Size(479, 456)
            Me.cardTop5.TabIndex = 1
            Me.cardTop5.UseTransparentBackground = True
            '
            'lblTop
            '
            Me.lblTop.BackColor = System.Drawing.Color.Transparent
            Me.lblTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblTop.Font = New System.Drawing.Font("Georgia", 14.5!, System.Drawing.FontStyle.Bold)
            Me.lblTop.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.lblTop.Location = New System.Drawing.Point(18, 18)
            Me.lblTop.Name = "lblTop"
            Me.lblTop.Size = New System.Drawing.Size(443, 34)
            Me.lblTop.TabIndex = 0
            Me.lblTop.Text = "Top 5 Menu Terlaris"
            '
            'dgvTop5
            '
            Me.dgvTop5.AllowUserToAddRows = False
            Me.dgvTop5.AllowUserToDeleteRows = False
            Me.dgvTop5.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvTop5.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvTop5.AutoGenerateColumns = False
            Me.dgvTop5.BackgroundColor = System.Drawing.Color.White
            Me.dgvTop5.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvTop5.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvTop5.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTop5.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvTop5.ColumnHeadersHeight = 42
            Me.dgvTop5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvTop5.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPeringkat, Me.colNamaMenu, Me.colTerjual, Me.colOmzet})
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTop5.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvTop5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvTop5.EnableHeadersVisualStyles = False
            Me.dgvTop5.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvTop5.Location = New System.Drawing.Point(18, 52)
            Me.dgvTop5.MultiSelect = False
            Me.dgvTop5.Name = "dgvTop5"
            Me.dgvTop5.ReadOnly = True
            Me.dgvTop5.RowHeadersVisible = False
            Me.dgvTop5.RowTemplate.Height = 40
            Me.dgvTop5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvTop5.Size = New System.Drawing.Size(443, 386)
            Me.dgvTop5.TabIndex = 1
            Me.dgvTop5.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvTop5.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvTop5.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTop5.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvTop5.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTop5.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvTop5.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvTop5.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvTop5.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvTop5.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvTop5.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTop5.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvTop5.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvTop5.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvTop5.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvTop5.ThemeStyle.RowsStyle.Height = 40
            Me.dgvTop5.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvTop5.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            '
            'colPeringkat
            '
            Me.colPeringkat.DataPropertyName = "peringkat"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.colPeringkat.DefaultCellStyle = DataGridViewCellStyle4
            Me.colPeringkat.HeaderText = "#"
            Me.colPeringkat.Name = "colPeringkat"
            Me.colPeringkat.ReadOnly = True
            Me.colPeringkat.Width = 42
            '
            'colNamaMenu
            '
            Me.colNamaMenu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colNamaMenu.DataPropertyName = "nama_produk"
            Me.colNamaMenu.HeaderText = "Menu"
            Me.colNamaMenu.MinimumWidth = 140
            Me.colNamaMenu.Name = "colNamaMenu"
            Me.colNamaMenu.ReadOnly = True
            '
            'colTerjual
            '
            Me.colTerjual.DataPropertyName = "total_qty"
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.colTerjual.DefaultCellStyle = DataGridViewCellStyle5
            Me.colTerjual.HeaderText = "Terjual"
            Me.colTerjual.Name = "colTerjual"
            Me.colTerjual.ReadOnly = True
            Me.colTerjual.Width = 72
            '
            'colOmzet
            '
            Me.colOmzet.DataPropertyName = "total_omzet"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.Format = "C0"
            Me.colOmzet.DefaultCellStyle = DataGridViewCellStyle6
            Me.colOmzet.HeaderText = "Omzet"
            Me.colOmzet.Name = "colOmzet"
            Me.colOmzet.ReadOnly = True
            Me.colOmzet.Width = 115
            '
            'FrmDashboard
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1180, 680)
            Me.Controls.Add(Me.pnlRoot)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.Name = "FrmDashboard"
            Me.Text = "Dashboard Penjualan & Ringkasan Bistro"
            Me.pnlRoot.ResumeLayout(False)
            Me.tlpBottom.ResumeLayout(False)
            Me.cardGrafik.ResumeLayout(False)
            Me.pnlGrafikHost.ResumeLayout(False)
            Me.cardTop5.ResumeLayout(False)
            CType(Me.dgvTop5, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tlpKpi.ResumeLayout(False)
            Me.cardKpiPendapatan.ResumeLayout(False)
            CType(Me.icoPendapatan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardKpiJumlah.ResumeLayout(False)
            CType(Me.icoJumlah, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardKpiRata.ResumeLayout(False)
            CType(Me.icoRata, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardKpiBatal.ResumeLayout(False)
            CType(Me.icoBatal, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardKpiStok.ResumeLayout(False)
            CType(Me.icoStok, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlHead.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlRoot As System.Windows.Forms.Panel
        Friend WithEvents pnlHead As System.Windows.Forms.Panel
        Friend WithEvents lblH As System.Windows.Forms.Label
        Friend WithEvents btnRef As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents tlpKpi As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents cardKpiPendapatan As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents stripPendapatan As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icoPendapatan As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudulPendapatan As System.Windows.Forms.Label
        Friend WithEvents lblValPendapatan As System.Windows.Forms.Label
        Friend WithEvents lblSubPendapatan As System.Windows.Forms.Label
        Friend WithEvents cardKpiJumlah As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents stripJumlah As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icoJumlah As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudulJumlah As System.Windows.Forms.Label
        Friend WithEvents lblValJumlah As System.Windows.Forms.Label
        Friend WithEvents lblSubJumlah As System.Windows.Forms.Label
        Friend WithEvents cardKpiRata As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents stripRata As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icoRata As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudulRata As System.Windows.Forms.Label
        Friend WithEvents lblValRata As System.Windows.Forms.Label
        Friend WithEvents lblSubRata As System.Windows.Forms.Label
        Friend WithEvents cardKpiBatal As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents stripBatal As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icoBatal As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudulBatal As System.Windows.Forms.Label
        Friend WithEvents lblValBatal As System.Windows.Forms.Label
        Friend WithEvents lblSubBatal As System.Windows.Forms.Label
        Friend WithEvents cardKpiStok As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents stripStok As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents icoStok As Guna.UI2.WinForms.Guna2CirclePictureBox
        Friend WithEvents lblJudulStok As System.Windows.Forms.Label
        Friend WithEvents lblValStok As System.Windows.Forms.Label
        Friend WithEvents lblSubStok As System.Windows.Forms.Label
        Friend WithEvents tlpBottom As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents cardGrafik As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblGraf As System.Windows.Forms.Label
        Friend WithEvents pnlGrafikHost As System.Windows.Forms.Panel
        Friend WithEvents barPrev1 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents barPrev2 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents barPrev3 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents barPrev4 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents barPrev5 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents barPrev6 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents barPrev7 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents pnlPrevAxis As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents cardTop5 As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTop As System.Windows.Forms.Label
        Friend WithEvents dgvTop5 As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colPeringkat As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colNamaMenu As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTerjual As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colOmzet As System.Windows.Forms.DataGridViewTextBoxColumn

    End Class
End Namespace
