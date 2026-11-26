Option Strict On
Option Explicit On

Namespace VisproPrakProjectAkhir.Forms.Admin

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmProduk
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
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.components = New System.ComponentModel.Container()
            Me.errProduk = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.tabProduk = New Guna.UI2.WinForms.Guna2TabControl()
            Me.tpProduk = New System.Windows.Forms.TabPage()
            Me.pnlLeftProd = New System.Windows.Forms.Panel()
            Me.cardGridProd = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvProduk = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colProdId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colProdNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colProdKat = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colProdHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colProdStok = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colProdAktif = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.pnlFilterTop = New System.Windows.Forms.Panel()
            Me.cboFilterKat = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.txtCari = New Guna.UI2.WinForms.Guna2TextBox()
            Me.pnlRightProd = New System.Windows.Forms.Panel()
            Me.cardFormProd = New Guna.UI2.WinForms.Guna2Panel()
            Me.picFoto = New System.Windows.Forms.PictureBox()
            Me.btnFoto = New Guna.UI2.WinForms.Guna2Button()
            Me.lblFotoHint = New System.Windows.Forms.Label()
            Me.lblProdNama = New System.Windows.Forms.Label()
            Me.txtNama = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblProdKat = New System.Windows.Forms.Label()
            Me.cboKategori = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblProdHarga = New System.Windows.Forms.Label()
            Me.txtHarga = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblProdStok = New System.Windows.Forms.Label()
            Me.txtStok = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnStok10 = New Guna.UI2.WinForms.Guna2Button()
            Me.btnStok50 = New Guna.UI2.WinForms.Guna2Button()
            Me.lblProdDesk = New System.Windows.Forms.Label()
            Me.txtDeskripsi = New Guna.UI2.WinForms.Guna2TextBox()
            Me.chkTersedia = New System.Windows.Forms.CheckBox()
            Me.chkBestSeller = New System.Windows.Forms.CheckBox()
            Me.btnBaru = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSimpan = New Guna.UI2.WinForms.Guna2Button()
            Me.btnHapus = New Guna.UI2.WinForms.Guna2Button()
            Me.tpKategori = New System.Windows.Forms.TabPage()
            Me.cardGridKat = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvKategori = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colKatId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colKatNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colKatUrutan = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlRightKat = New System.Windows.Forms.Panel()
            Me.cardEdKat = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblNamaKat = New System.Windows.Forms.Label()
            Me.txtNamaKat = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblUrutanKat = New System.Windows.Forms.Label()
            Me.nudUrutan = New System.Windows.Forms.NumericUpDown()
            Me.btnBaruKat = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSimpanKat = New Guna.UI2.WinForms.Guna2Button()
            Me.btnHapusKat = New Guna.UI2.WinForms.Guna2Button()
            Me.tpOpsi = New System.Windows.Forms.TabPage()
            Me.cardGridOpsi = New Guna.UI2.WinForms.Guna2Panel()
            Me.dgvOpsi = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colOpsiId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colOpsiNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colOpsiTipe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colOpsiHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlRightOpsi = New System.Windows.Forms.Panel()
            Me.cardEdOpsi = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblNamaOpsi = New System.Windows.Forms.Label()
            Me.txtNamaOpsi = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblTipeOpsi = New System.Windows.Forms.Label()
            Me.cboTipeOpsi = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblHargaOpsi = New System.Windows.Forms.Label()
            Me.txtTambahanHarga = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnAddOpsi = New Guna.UI2.WinForms.Guna2Button()
            Me.btnDelOpsi = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlTopOpsi = New System.Windows.Forms.Panel()
            Me.lblPilihProdOpsi = New System.Windows.Forms.Label()
            Me.cboOpsiProduk = New Guna.UI2.WinForms.Guna2ComboBox()
            CType(Me.errProduk, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabProduk.SuspendLayout()
            Me.tpProduk.SuspendLayout()
            Me.pnlLeftProd.SuspendLayout()
            Me.cardGridProd.SuspendLayout()
            CType(Me.dgvProduk, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFilterTop.SuspendLayout()
            Me.pnlRightProd.SuspendLayout()
            Me.cardFormProd.SuspendLayout()
            CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpKategori.SuspendLayout()
            Me.cardGridKat.SuspendLayout()
            CType(Me.dgvKategori, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlRightKat.SuspendLayout()
            Me.cardEdKat.SuspendLayout()
            CType(Me.nudUrutan, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpOpsi.SuspendLayout()
            Me.cardGridOpsi.SuspendLayout()
            CType(Me.dgvOpsi, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlRightOpsi.SuspendLayout()
            Me.cardEdOpsi.SuspendLayout()
            Me.pnlTopOpsi.SuspendLayout()
            Me.SuspendLayout()
            '
            'errProduk
            '
            Me.errProduk.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            Me.errProduk.ContainerControl = Me
            '
            'tabProduk
            '
            Me.tabProduk.Alignment = System.Windows.Forms.TabAlignment.Top
            Me.tabProduk.Controls.Add(Me.tpProduk)
            Me.tabProduk.Controls.Add(Me.tpKategori)
            Me.tabProduk.Controls.Add(Me.tpOpsi)
            Me.tabProduk.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabProduk.Location = New System.Drawing.Point(0, 0)
            Me.tabProduk.Name = "tabProduk"
            Me.tabProduk.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.tabProduk.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.tabProduk.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.tabProduk.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.tabProduk.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tabProduk.SelectedIndex = 0
            Me.tabProduk.Size = New System.Drawing.Size(1180, 680)
            Me.tabProduk.TabButtonSize = New System.Drawing.Size(180, 42)
            Me.tabProduk.TabIndex = 0
            Me.tabProduk.TabMenuBackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            '
            'tpProduk
            '
            Me.tpProduk.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tpProduk.Controls.Add(Me.pnlLeftProd)
            Me.tpProduk.Controls.Add(Me.pnlRightProd)
            Me.tpProduk.Location = New System.Drawing.Point(4, 46)
            Me.tpProduk.Name = "tpProduk"
            Me.tpProduk.Padding = New System.Windows.Forms.Padding(16)
            Me.tpProduk.Size = New System.Drawing.Size(1172, 630)
            Me.tpProduk.TabIndex = 0
            Me.tpProduk.Text = "Produk"
            '
            'pnlLeftProd
            '
            Me.pnlLeftProd.Controls.Add(Me.cardGridProd)
            Me.pnlLeftProd.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlLeftProd.Location = New System.Drawing.Point(16, 16)
            Me.pnlLeftProd.Name = "pnlLeftProd"
            Me.pnlLeftProd.Padding = New System.Windows.Forms.Padding(0, 0, 12, 0)
            Me.pnlLeftProd.Size = New System.Drawing.Size(732, 598)
            Me.pnlLeftProd.TabIndex = 0
            '
            'cardGridProd
            '
            Me.cardGridProd.BackColor = System.Drawing.Color.Transparent
            Me.cardGridProd.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGridProd.BorderRadius = 16
            Me.cardGridProd.BorderThickness = 1
            Me.cardGridProd.Controls.Add(Me.dgvProduk)
            Me.cardGridProd.Controls.Add(Me.pnlFilterTop)
            Me.cardGridProd.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGridProd.FillColor = System.Drawing.Color.White
            Me.cardGridProd.Location = New System.Drawing.Point(0, 0)
            Me.cardGridProd.Name = "cardGridProd"
            Me.cardGridProd.Padding = New System.Windows.Forms.Padding(14)
            Me.cardGridProd.Size = New System.Drawing.Size(720, 598)
            Me.cardGridProd.TabIndex = 0
            Me.cardGridProd.UseTransparentBackground = True
            '
            'pnlFilterTop
            '
            Me.pnlFilterTop.BackColor = System.Drawing.Color.Transparent
            Me.pnlFilterTop.Controls.Add(Me.cboFilterKat)
            Me.pnlFilterTop.Controls.Add(Me.txtCari)
            Me.pnlFilterTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilterTop.Location = New System.Drawing.Point(14, 14)
            Me.pnlFilterTop.Name = "pnlFilterTop"
            Me.pnlFilterTop.Size = New System.Drawing.Size(692, 48)
            Me.pnlFilterTop.TabIndex = 0
            '
            'cboFilterKat
            '
            Me.cboFilterKat.BackColor = System.Drawing.Color.Transparent
            Me.cboFilterKat.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboFilterKat.BorderRadius = 12
            Me.cboFilterKat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFilterKat.FillColor = System.Drawing.Color.White
            Me.cboFilterKat.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboFilterKat.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.cboFilterKat.ItemHeight = 32
            Me.cboFilterKat.Location = New System.Drawing.Point(0, 2)
            Me.cboFilterKat.Name = "cboFilterKat"
            Me.cboFilterKat.Size = New System.Drawing.Size(200, 38)
            Me.cboFilterKat.TabIndex = 0
            Me.cboFilterKat.BorderThickness = 1
            '
            'txtCari
            '
            Me.txtCari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtCari.BackColor = System.Drawing.Color.Transparent
            Me.txtCari.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtCari.BorderRadius = 12
            Me.txtCari.DefaultText = ""
            Me.txtCari.FillColor = System.Drawing.Color.White
            Me.txtCari.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtCari.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.txtCari.Location = New System.Drawing.Point(210, 2)
            Me.txtCari.Name = "txtCari"
            Me.txtCari.PlaceholderForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.txtCari.PlaceholderText = "Cari nama produk..."
            Me.txtCari.Size = New System.Drawing.Size(480, 38)
            Me.txtCari.TabIndex = 1
            Me.txtCari.BorderThickness = 1
            '
            'dgvProduk
            '
            Me.dgvProduk.AllowUserToAddRows = False
            Me.dgvProduk.AllowUserToDeleteRows = False
            Me.dgvProduk.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvProduk.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvProduk.AutoGenerateColumns = False
            Me.dgvProduk.BackgroundColor = System.Drawing.Color.White
            Me.dgvProduk.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvProduk.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvProduk.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvProduk.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvProduk.ColumnHeadersHeight = 42
            Me.dgvProduk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvProduk.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProdId, Me.colProdNama, Me.colProdKat, Me.colProdHarga, Me.colProdStok, Me.colProdAktif})
            Me.dgvProduk.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvProduk.EnableHeadersVisualStyles = False
            Me.dgvProduk.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvProduk.Location = New System.Drawing.Point(14, 62)
            Me.dgvProduk.MultiSelect = False
            Me.dgvProduk.Name = "dgvProduk"
            Me.dgvProduk.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvProduk.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvProduk.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvProduk.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvProduk.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvProduk.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvProduk.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvProduk.ThemeStyle.RowsStyle.Height = 40
            Me.dgvProduk.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvProduk.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvProduk.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvProduk.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvProduk.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvProduk.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvProduk.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvProduk.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvProduk.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvProduk.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvProduk.ReadOnly = True
            Me.dgvProduk.RowHeadersVisible = False
            Me.dgvProduk.RowTemplate.Height = 40
            Me.dgvProduk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvProduk.Size = New System.Drawing.Size(692, 522)
            Me.dgvProduk.TabIndex = 1
            '
            'colProdId
            '
            Me.colProdId.DataPropertyName = "id_produk"
            Me.colProdId.HeaderText = "ID"
            Me.colProdId.Name = "colProdId"
            Me.colProdId.ReadOnly = True
            Me.colProdId.Width = 44
            '
            'colProdNama
            '
            Me.colProdNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colProdNama.DataPropertyName = "nama"
            Me.colProdNama.HeaderText = "Nama Produk"
            Me.colProdNama.MinimumWidth = 150
            Me.colProdNama.Name = "colProdNama"
            Me.colProdNama.ReadOnly = True
            '
            'colProdKat
            '
            Me.colProdKat.DataPropertyName = "nama_kategori"
            Me.colProdKat.HeaderText = "Kategori"
            Me.colProdKat.Name = "colProdKat"
            Me.colProdKat.ReadOnly = True
            Me.colProdKat.Width = 108
            '
            'colProdHarga
            '
            Me.colProdHarga.DataPropertyName = "harga"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "C0"
            Me.colProdHarga.DefaultCellStyle = DataGridViewCellStyle3
            Me.colProdHarga.HeaderText = "Harga"
            Me.colProdHarga.Name = "colProdHarga"
            Me.colProdHarga.ReadOnly = True
            Me.colProdHarga.Width = 100
            '
            'colProdStok
            '
            Me.colProdStok.DataPropertyName = "stok"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.colProdStok.DefaultCellStyle = DataGridViewCellStyle4
            Me.colProdStok.HeaderText = "Stok"
            Me.colProdStok.Name = "colProdStok"
            Me.colProdStok.ReadOnly = True
            Me.colProdStok.Width = 62
            '
            'colProdAktif
            '
            Me.colProdAktif.DataPropertyName = "tersedia"
            Me.colProdAktif.HeaderText = "Aktif"
            Me.colProdAktif.MinimumWidth = 70
            Me.colProdAktif.Name = "colProdAktif"
            Me.colProdAktif.ReadOnly = True
            Me.colProdAktif.Width = 76
            '
            'pnlRightProd
            '
            Me.pnlRightProd.Controls.Add(Me.cardFormProd)
            Me.pnlRightProd.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlRightProd.Location = New System.Drawing.Point(748, 16)
            Me.pnlRightProd.Name = "pnlRightProd"
            Me.pnlRightProd.Size = New System.Drawing.Size(408, 598)
            Me.pnlRightProd.TabIndex = 1
            '
            'cardFormProd
            '
            Me.cardFormProd.BackColor = System.Drawing.Color.Transparent
            Me.cardFormProd.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardFormProd.BorderRadius = 16
            Me.cardFormProd.BorderThickness = 1
            Me.cardFormProd.Controls.Add(Me.picFoto)
            Me.cardFormProd.Controls.Add(Me.btnFoto)
            Me.cardFormProd.Controls.Add(Me.lblFotoHint)
            Me.cardFormProd.Controls.Add(Me.lblProdNama)
            Me.cardFormProd.Controls.Add(Me.txtNama)
            Me.cardFormProd.Controls.Add(Me.lblProdKat)
            Me.cardFormProd.Controls.Add(Me.cboKategori)
            Me.cardFormProd.Controls.Add(Me.lblProdHarga)
            Me.cardFormProd.Controls.Add(Me.txtHarga)
            Me.cardFormProd.Controls.Add(Me.lblProdStok)
            Me.cardFormProd.Controls.Add(Me.txtStok)
            Me.cardFormProd.Controls.Add(Me.btnStok10)
            Me.cardFormProd.Controls.Add(Me.btnStok50)
            Me.cardFormProd.Controls.Add(Me.lblProdDesk)
            Me.cardFormProd.Controls.Add(Me.txtDeskripsi)
            Me.cardFormProd.Controls.Add(Me.chkTersedia)
            Me.cardFormProd.Controls.Add(Me.chkBestSeller)
            Me.cardFormProd.Controls.Add(Me.btnBaru)
            Me.cardFormProd.Controls.Add(Me.btnSimpan)
            Me.cardFormProd.Controls.Add(Me.btnHapus)
            Me.cardFormProd.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardFormProd.FillColor = System.Drawing.Color.White
            Me.cardFormProd.Location = New System.Drawing.Point(0, 0)
            Me.cardFormProd.Name = "cardFormProd"
            Me.cardFormProd.Padding = New System.Windows.Forms.Padding(16)
            Me.cardFormProd.Size = New System.Drawing.Size(408, 598)
            Me.cardFormProd.TabIndex = 0
            Me.cardFormProd.UseTransparentBackground = True
            '
            'picFoto
            '
            Me.picFoto.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.picFoto.Location = New System.Drawing.Point(16, 16)
            Me.picFoto.Name = "picFoto"
            Me.picFoto.Size = New System.Drawing.Size(118, 92)
            Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picFoto.TabIndex = 0
            Me.picFoto.TabStop = False
            '
            'btnFoto
            '
            Me.btnFoto.BackColor = System.Drawing.Color.Transparent
            Me.btnFoto.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnFoto.BorderRadius = 12
            Me.btnFoto.BorderThickness = 1
            Me.btnFoto.FillColor = System.Drawing.Color.White
            Me.btnFoto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnFoto.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnFoto.Location = New System.Drawing.Point(146, 16)
            Me.btnFoto.Name = "btnFoto"
            Me.btnFoto.Size = New System.Drawing.Size(134, 38)
            Me.btnFoto.TabIndex = 1
            Me.btnFoto.Text = "Pilih Foto"
            Me.btnFoto.UseTransparentBackground = True
            '
            'lblFotoHint
            '
            Me.lblFotoHint.BackColor = System.Drawing.Color.Transparent
            Me.lblFotoHint.Font = New System.Drawing.Font("Segoe UI", 8.75!)
            Me.lblFotoHint.ForeColor = System.Drawing.Color.FromArgb(107, 83, 68)
            Me.lblFotoHint.Location = New System.Drawing.Point(146, 60)
            Me.lblFotoHint.Name = "lblFotoHint"
            Me.lblFotoHint.Size = New System.Drawing.Size(244, 48)
            Me.lblFotoHint.TabIndex = 2
            Me.lblFotoHint.Text = "Format JPG/PNG, maks. 300 KB. Disimpan ke Asset\Produk."
            '
            'lblProdNama
            '
            Me.lblProdNama.BackColor = System.Drawing.Color.Transparent
            Me.lblProdNama.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblProdNama.Location = New System.Drawing.Point(16, 116)
            Me.lblProdNama.Name = "lblProdNama"
            Me.lblProdNama.Size = New System.Drawing.Size(180, 22)
            Me.lblProdNama.TabIndex = 3
            Me.lblProdNama.Text = "Nama Produk"
            '
            'txtNama
            '
            Me.txtNama.BackColor = System.Drawing.Color.Transparent
            Me.txtNama.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNama.BorderRadius = 12
            Me.txtNama.DefaultText = ""
            Me.txtNama.FillColor = System.Drawing.Color.White
            Me.txtNama.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNama.Location = New System.Drawing.Point(16, 140)
            Me.txtNama.Name = "txtNama"
            Me.txtNama.Size = New System.Drawing.Size(374, 36)
            Me.txtNama.TabIndex = 4
            Me.txtNama.BorderThickness = 1
            '
            'lblProdKat
            '
            Me.lblProdKat.BackColor = System.Drawing.Color.Transparent
            Me.lblProdKat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblProdKat.Location = New System.Drawing.Point(16, 184)
            Me.lblProdKat.Name = "lblProdKat"
            Me.lblProdKat.Size = New System.Drawing.Size(180, 22)
            Me.lblProdKat.TabIndex = 5
            Me.lblProdKat.Text = "Kategori"
            '
            'cboKategori
            '
            Me.cboKategori.BackColor = System.Drawing.Color.Transparent
            Me.cboKategori.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboKategori.BorderRadius = 12
            Me.cboKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboKategori.FillColor = System.Drawing.Color.White
            Me.cboKategori.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboKategori.ItemHeight = 32
            Me.cboKategori.Location = New System.Drawing.Point(16, 208)
            Me.cboKategori.Name = "cboKategori"
            Me.cboKategori.Size = New System.Drawing.Size(182, 36)
            Me.cboKategori.TabIndex = 6
            Me.cboKategori.BorderThickness = 1
            '
            'lblProdHarga
            '
            Me.lblProdHarga.BackColor = System.Drawing.Color.Transparent
            Me.lblProdHarga.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblProdHarga.Location = New System.Drawing.Point(210, 184)
            Me.lblProdHarga.Name = "lblProdHarga"
            Me.lblProdHarga.Size = New System.Drawing.Size(180, 22)
            Me.lblProdHarga.TabIndex = 7
            Me.lblProdHarga.Text = "Harga (Rp)"
            '
            'txtHarga
            '
            Me.txtHarga.BackColor = System.Drawing.Color.Transparent
            Me.txtHarga.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtHarga.BorderRadius = 12
            Me.txtHarga.DefaultText = ""
            Me.txtHarga.FillColor = System.Drawing.Color.White
            Me.txtHarga.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtHarga.Location = New System.Drawing.Point(210, 208)
            Me.txtHarga.Name = "txtHarga"
            Me.txtHarga.Size = New System.Drawing.Size(180, 36)
            Me.txtHarga.TabIndex = 8
            Me.txtHarga.BorderThickness = 1
            '
            'lblProdStok
            '
            Me.lblProdStok.BackColor = System.Drawing.Color.Transparent
            Me.lblProdStok.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblProdStok.Location = New System.Drawing.Point(16, 252)
            Me.lblProdStok.Name = "lblProdStok"
            Me.lblProdStok.Size = New System.Drawing.Size(260, 22)
            Me.lblProdStok.TabIndex = 9
            Me.lblProdStok.Text = "Stok (kosong = tidak dilacak)"
            '
            'txtStok
            '
            Me.txtStok.BackColor = System.Drawing.Color.Transparent
            Me.txtStok.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtStok.BorderRadius = 12
            Me.txtStok.DefaultText = ""
            Me.txtStok.FillColor = System.Drawing.Color.White
            Me.txtStok.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtStok.Location = New System.Drawing.Point(16, 276)
            Me.txtStok.Name = "txtStok"
            Me.txtStok.Size = New System.Drawing.Size(140, 36)
            Me.txtStok.TabIndex = 10
            Me.txtStok.BorderThickness = 1
            '
            'btnStok10
            '
            Me.btnStok10.BackColor = System.Drawing.Color.Transparent
            Me.btnStok10.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnStok10.BorderRadius = 10
            Me.btnStok10.BorderThickness = 1
            Me.btnStok10.FillColor = System.Drawing.Color.White
            Me.btnStok10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnStok10.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnStok10.Location = New System.Drawing.Point(164, 276)
            Me.btnStok10.Name = "btnStok10"
            Me.btnStok10.Size = New System.Drawing.Size(68, 36)
            Me.btnStok10.TabIndex = 11
            Me.btnStok10.Text = "+10"
            Me.btnStok10.UseTransparentBackground = True
            '
            'btnStok50
            '
            Me.btnStok50.BackColor = System.Drawing.Color.Transparent
            Me.btnStok50.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnStok50.BorderRadius = 10
            Me.btnStok50.BorderThickness = 1
            Me.btnStok50.FillColor = System.Drawing.Color.White
            Me.btnStok50.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnStok50.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnStok50.Location = New System.Drawing.Point(238, 276)
            Me.btnStok50.Name = "btnStok50"
            Me.btnStok50.Size = New System.Drawing.Size(68, 36)
            Me.btnStok50.TabIndex = 12
            Me.btnStok50.Text = "+50"
            Me.btnStok50.UseTransparentBackground = True
            '
            'lblProdDesk
            '
            Me.lblProdDesk.BackColor = System.Drawing.Color.Transparent
            Me.lblProdDesk.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblProdDesk.Location = New System.Drawing.Point(16, 320)
            Me.lblProdDesk.Name = "lblProdDesk"
            Me.lblProdDesk.Size = New System.Drawing.Size(180, 22)
            Me.lblProdDesk.TabIndex = 13
            Me.lblProdDesk.Text = "Deskripsi"
            '
            'txtDeskripsi
            '
            Me.txtDeskripsi.BackColor = System.Drawing.Color.Transparent
            Me.txtDeskripsi.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtDeskripsi.BorderRadius = 12
            Me.txtDeskripsi.DefaultText = ""
            Me.txtDeskripsi.FillColor = System.Drawing.Color.White
            Me.txtDeskripsi.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtDeskripsi.Location = New System.Drawing.Point(16, 344)
            Me.txtDeskripsi.Multiline = True
            Me.txtDeskripsi.Name = "txtDeskripsi"
            Me.txtDeskripsi.Size = New System.Drawing.Size(374, 68)
            Me.txtDeskripsi.TabIndex = 14
            Me.txtDeskripsi.BorderThickness = 1
            '
            'chkTersedia
            '
            Me.chkTersedia.BackColor = System.Drawing.Color.Transparent
            Me.chkTersedia.Checked = True
            Me.chkTersedia.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkTersedia.Location = New System.Drawing.Point(16, 422)
            Me.chkTersedia.Name = "chkTersedia"
            Me.chkTersedia.Size = New System.Drawing.Size(130, 24)
            Me.chkTersedia.TabIndex = 15
            Me.chkTersedia.Text = "Tersedia"
            '
            'chkBestSeller
            '
            Me.chkBestSeller.BackColor = System.Drawing.Color.Transparent
            Me.chkBestSeller.Location = New System.Drawing.Point(160, 422)
            Me.chkBestSeller.Name = "chkBestSeller"
            Me.chkBestSeller.Size = New System.Drawing.Size(140, 24)
            Me.chkBestSeller.TabIndex = 16
            Me.chkBestSeller.Text = "Best Seller"
            '
            'btnBaru
            '
            Me.btnBaru.BackColor = System.Drawing.Color.Transparent
            Me.btnBaru.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnBaru.BorderRadius = 12
            Me.btnBaru.BorderThickness = 1
            Me.btnBaru.FillColor = System.Drawing.Color.White
            Me.btnBaru.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnBaru.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnBaru.Location = New System.Drawing.Point(16, 458)
            Me.btnBaru.Name = "btnBaru"
            Me.btnBaru.Size = New System.Drawing.Size(116, 42)
            Me.btnBaru.TabIndex = 17
            Me.btnBaru.Text = "Baru"
            Me.btnBaru.UseTransparentBackground = True
            '
            'btnSimpan
            '
            Me.btnSimpan.BackColor = System.Drawing.Color.Transparent
            Me.btnSimpan.BorderRadius = 12
            Me.btnSimpan.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSimpan.ForeColor = System.Drawing.Color.White
            Me.btnSimpan.Location = New System.Drawing.Point(140, 458)
            Me.btnSimpan.Name = "btnSimpan"
            Me.btnSimpan.BorderThickness = 0
            Me.btnSimpan.Size = New System.Drawing.Size(124, 42)
            Me.btnSimpan.TabIndex = 18
            Me.btnSimpan.Text = "Simpan"
            Me.btnSimpan.UseTransparentBackground = True
            '
            'btnHapus
            '
            Me.btnHapus.BackColor = System.Drawing.Color.Transparent
            Me.btnHapus.BorderColor = System.Drawing.Color.FromArgb(234, 181, 176)
            Me.btnHapus.BorderRadius = 12
            Me.btnHapus.BorderThickness = 1
            Me.btnHapus.FillColor = System.Drawing.Color.FromArgb(253, 236, 236)
            Me.btnHapus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnHapus.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnHapus.Location = New System.Drawing.Point(272, 458)
            Me.btnHapus.Name = "btnHapus"
            Me.btnHapus.Size = New System.Drawing.Size(118, 42)
            Me.btnHapus.TabIndex = 19
            Me.btnHapus.Text = "Hapus"
            Me.btnHapus.UseTransparentBackground = True
            '
            'tpKategori
            '
            Me.tpKategori.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tpKategori.Controls.Add(Me.cardGridKat)
            Me.tpKategori.Controls.Add(Me.pnlRightKat)
            Me.tpKategori.Location = New System.Drawing.Point(4, 46)
            Me.tpKategori.Name = "tpKategori"
            Me.tpKategori.Padding = New System.Windows.Forms.Padding(18)
            Me.tpKategori.Size = New System.Drawing.Size(1172, 630)
            Me.tpKategori.TabIndex = 1
            Me.tpKategori.Text = "Kategori"
            '
            'cardGridKat
            '
            Me.cardGridKat.BackColor = System.Drawing.Color.Transparent
            Me.cardGridKat.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGridKat.BorderRadius = 16
            Me.cardGridKat.BorderThickness = 1
            Me.cardGridKat.Controls.Add(Me.dgvKategori)
            Me.cardGridKat.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGridKat.FillColor = System.Drawing.Color.White
            Me.cardGridKat.Location = New System.Drawing.Point(18, 18)
            Me.cardGridKat.Name = "cardGridKat"
            Me.cardGridKat.Padding = New System.Windows.Forms.Padding(14)
            Me.cardGridKat.Size = New System.Drawing.Size(796, 594)
            Me.cardGridKat.TabIndex = 0
            Me.cardGridKat.UseTransparentBackground = True
            '
            'dgvKategori
            '
            Me.dgvKategori.AllowUserToAddRows = False
            Me.dgvKategori.AllowUserToDeleteRows = False
            Me.dgvKategori.AllowUserToResizeRows = False
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvKategori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
            Me.dgvKategori.AutoGenerateColumns = False
            Me.dgvKategori.BackgroundColor = System.Drawing.Color.White
            Me.dgvKategori.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvKategori.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvKategori.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvKategori.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
            Me.dgvKategori.ColumnHeadersHeight = 42
            Me.dgvKategori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvKategori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colKatId, Me.colKatNama, Me.colKatUrutan})
            Me.dgvKategori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvKategori.EnableHeadersVisualStyles = False
            Me.dgvKategori.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvKategori.Location = New System.Drawing.Point(14, 14)
            Me.dgvKategori.MultiSelect = False
            Me.dgvKategori.Name = "dgvKategori"
            Me.dgvKategori.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKategori.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvKategori.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKategori.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvKategori.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvKategori.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKategori.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvKategori.ThemeStyle.RowsStyle.Height = 40
            Me.dgvKategori.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKategori.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvKategori.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvKategori.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvKategori.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvKategori.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvKategori.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvKategori.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvKategori.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvKategori.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvKategori.ReadOnly = True
            Me.dgvKategori.RowHeadersVisible = False
            Me.dgvKategori.RowTemplate.Height = 40
            Me.dgvKategori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvKategori.Size = New System.Drawing.Size(768, 566)
            Me.dgvKategori.TabIndex = 0
            '
            'colKatId
            '
            Me.colKatId.DataPropertyName = "id_kategori"
            Me.colKatId.HeaderText = "ID"
            Me.colKatId.Name = "colKatId"
            Me.colKatId.ReadOnly = True
            Me.colKatId.Width = 60
            '
            'colKatNama
            '
            Me.colKatNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colKatNama.DataPropertyName = "nama"
            Me.colKatNama.HeaderText = "Nama Kategori"
            Me.colKatNama.Name = "colKatNama"
            Me.colKatNama.ReadOnly = True
            '
            'colKatUrutan
            '
            Me.colKatUrutan.DataPropertyName = "urutan"
            Me.colKatUrutan.HeaderText = "Urutan"
            Me.colKatUrutan.Name = "colKatUrutan"
            Me.colKatUrutan.ReadOnly = True
            Me.colKatUrutan.Width = 90
            '
            'pnlRightKat
            '
            Me.pnlRightKat.Controls.Add(Me.cardEdKat)
            Me.pnlRightKat.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlRightKat.Location = New System.Drawing.Point(814, 18)
            Me.pnlRightKat.Name = "pnlRightKat"
            Me.pnlRightKat.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
            Me.pnlRightKat.Size = New System.Drawing.Size(340, 594)
            Me.pnlRightKat.TabIndex = 1
            '
            'cardEdKat
            '
            Me.cardEdKat.BackColor = System.Drawing.Color.Transparent
            Me.cardEdKat.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardEdKat.BorderRadius = 16
            Me.cardEdKat.BorderThickness = 1
            Me.cardEdKat.Controls.Add(Me.lblNamaKat)
            Me.cardEdKat.Controls.Add(Me.txtNamaKat)
            Me.cardEdKat.Controls.Add(Me.lblUrutanKat)
            Me.cardEdKat.Controls.Add(Me.nudUrutan)
            Me.cardEdKat.Controls.Add(Me.btnBaruKat)
            Me.cardEdKat.Controls.Add(Me.btnSimpanKat)
            Me.cardEdKat.Controls.Add(Me.btnHapusKat)
            Me.cardEdKat.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardEdKat.FillColor = System.Drawing.Color.White
            Me.cardEdKat.Location = New System.Drawing.Point(14, 0)
            Me.cardEdKat.Name = "cardEdKat"
            Me.cardEdKat.Padding = New System.Windows.Forms.Padding(16)
            Me.cardEdKat.Size = New System.Drawing.Size(326, 594)
            Me.cardEdKat.TabIndex = 0
            Me.cardEdKat.UseTransparentBackground = True
            '
            'lblNamaKat
            '
            Me.lblNamaKat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblNamaKat.Location = New System.Drawing.Point(16, 20)
            Me.lblNamaKat.Name = "lblNamaKat"
            Me.lblNamaKat.Size = New System.Drawing.Size(280, 20)
            Me.lblNamaKat.TabIndex = 0
            Me.lblNamaKat.Text = "Nama Kategori"
            '
            'txtNamaKat
            '
            Me.txtNamaKat.BackColor = System.Drawing.Color.Transparent
            Me.txtNamaKat.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNamaKat.BorderRadius = 12
            Me.txtNamaKat.DefaultText = ""
            Me.txtNamaKat.FillColor = System.Drawing.Color.White
            Me.txtNamaKat.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNamaKat.Location = New System.Drawing.Point(16, 44)
            Me.txtNamaKat.Name = "txtNamaKat"
            Me.txtNamaKat.Size = New System.Drawing.Size(290, 38)
            Me.txtNamaKat.TabIndex = 1
            Me.txtNamaKat.BorderThickness = 1
            '
            'lblUrutanKat
            '
            Me.lblUrutanKat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblUrutanKat.Location = New System.Drawing.Point(16, 94)
            Me.lblUrutanKat.Name = "lblUrutanKat"
            Me.lblUrutanKat.Size = New System.Drawing.Size(280, 20)
            Me.lblUrutanKat.TabIndex = 2
            Me.lblUrutanKat.Text = "Urutan Tampil"
            '
            'nudUrutan
            '
            Me.nudUrutan.Location = New System.Drawing.Point(16, 118)
            Me.nudUrutan.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
            Me.nudUrutan.Name = "nudUrutan"
            Me.nudUrutan.Size = New System.Drawing.Size(140, 30)
            Me.nudUrutan.TabIndex = 3
            '
            'btnBaruKat
            '
            Me.btnBaruKat.BackColor = System.Drawing.Color.Transparent
            Me.btnBaruKat.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.btnBaruKat.BorderRadius = 12
            Me.btnBaruKat.BorderThickness = 1
            Me.btnBaruKat.FillColor = System.Drawing.Color.White
            Me.btnBaruKat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnBaruKat.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.btnBaruKat.Location = New System.Drawing.Point(16, 174)
            Me.btnBaruKat.Name = "btnBaruKat"
            Me.btnBaruKat.Size = New System.Drawing.Size(90, 40)
            Me.btnBaruKat.TabIndex = 4
            Me.btnBaruKat.Text = "Baru"
            Me.btnBaruKat.UseTransparentBackground = True
            '
            'btnSimpanKat
            '
            Me.btnSimpanKat.BackColor = System.Drawing.Color.Transparent
            Me.btnSimpanKat.BorderRadius = 12
            Me.btnSimpanKat.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnSimpanKat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSimpanKat.ForeColor = System.Drawing.Color.White
            Me.btnSimpanKat.Location = New System.Drawing.Point(114, 174)
            Me.btnSimpanKat.Name = "btnSimpanKat"
            Me.btnSimpanKat.BorderThickness = 0
            Me.btnSimpanKat.Size = New System.Drawing.Size(94, 40)
            Me.btnSimpanKat.TabIndex = 5
            Me.btnSimpanKat.Text = "Simpan"
            Me.btnSimpanKat.UseTransparentBackground = True
            '
            'btnHapusKat
            '
            Me.btnHapusKat.BackColor = System.Drawing.Color.Transparent
            Me.btnHapusKat.BorderColor = System.Drawing.Color.FromArgb(234, 181, 176)
            Me.btnHapusKat.BorderRadius = 12
            Me.btnHapusKat.BorderThickness = 1
            Me.btnHapusKat.FillColor = System.Drawing.Color.FromArgb(253, 236, 236)
            Me.btnHapusKat.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnHapusKat.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnHapusKat.Location = New System.Drawing.Point(216, 174)
            Me.btnHapusKat.Name = "btnHapusKat"
            Me.btnHapusKat.Size = New System.Drawing.Size(90, 40)
            Me.btnHapusKat.TabIndex = 6
            Me.btnHapusKat.Text = "Hapus"
            Me.btnHapusKat.UseTransparentBackground = True
            '
            'tpOpsi
            '
            Me.tpOpsi.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.tpOpsi.Controls.Add(Me.cardGridOpsi)
            Me.tpOpsi.Controls.Add(Me.pnlRightOpsi)
            Me.tpOpsi.Controls.Add(Me.pnlTopOpsi)
            Me.tpOpsi.Location = New System.Drawing.Point(4, 46)
            Me.tpOpsi.Name = "tpOpsi"
            Me.tpOpsi.Padding = New System.Windows.Forms.Padding(18)
            Me.tpOpsi.Size = New System.Drawing.Size(1172, 630)
            Me.tpOpsi.TabIndex = 2
            Me.tpOpsi.Text = "Opsi Produk"
            '
            'pnlTopOpsi
            '
            Me.pnlTopOpsi.Controls.Add(Me.lblPilihProdOpsi)
            Me.pnlTopOpsi.Controls.Add(Me.cboOpsiProduk)
            Me.pnlTopOpsi.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTopOpsi.Location = New System.Drawing.Point(18, 18)
            Me.pnlTopOpsi.Name = "pnlTopOpsi"
            Me.pnlTopOpsi.Size = New System.Drawing.Size(1136, 52)
            Me.pnlTopOpsi.TabIndex = 0
            '
            'lblPilihProdOpsi
            '
            Me.lblPilihProdOpsi.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblPilihProdOpsi.Location = New System.Drawing.Point(0, 12)
            Me.lblPilihProdOpsi.Name = "lblPilihProdOpsi"
            Me.lblPilihProdOpsi.Size = New System.Drawing.Size(110, 24)
            Me.lblPilihProdOpsi.TabIndex = 0
            Me.lblPilihProdOpsi.Text = "Pilih Produk:"
            '
            'cboOpsiProduk
            '
            Me.cboOpsiProduk.BackColor = System.Drawing.Color.Transparent
            Me.cboOpsiProduk.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboOpsiProduk.BorderRadius = 12
            Me.cboOpsiProduk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboOpsiProduk.FillColor = System.Drawing.Color.White
            Me.cboOpsiProduk.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboOpsiProduk.ItemHeight = 32
            Me.cboOpsiProduk.Location = New System.Drawing.Point(116, 6)
            Me.cboOpsiProduk.Name = "cboOpsiProduk"
            Me.cboOpsiProduk.Size = New System.Drawing.Size(340, 38)
            Me.cboOpsiProduk.TabIndex = 1
            Me.cboOpsiProduk.BorderThickness = 1
            '
            'cardGridOpsi
            '
            Me.cardGridOpsi.BackColor = System.Drawing.Color.Transparent
            Me.cardGridOpsi.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardGridOpsi.BorderRadius = 16
            Me.cardGridOpsi.BorderThickness = 1
            Me.cardGridOpsi.Controls.Add(Me.dgvOpsi)
            Me.cardGridOpsi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardGridOpsi.FillColor = System.Drawing.Color.White
            Me.cardGridOpsi.Location = New System.Drawing.Point(18, 70)
            Me.cardGridOpsi.Name = "cardGridOpsi"
            Me.cardGridOpsi.Padding = New System.Windows.Forms.Padding(14)
            Me.cardGridOpsi.Size = New System.Drawing.Size(796, 542)
            Me.cardGridOpsi.TabIndex = 1
            Me.cardGridOpsi.UseTransparentBackground = True
            '
            'dgvOpsi
            '
            Me.dgvOpsi.AllowUserToAddRows = False
            Me.dgvOpsi.AllowUserToDeleteRows = False
            Me.dgvOpsi.AllowUserToResizeRows = False
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvOpsi.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
            Me.dgvOpsi.AutoGenerateColumns = False
            Me.dgvOpsi.BackgroundColor = System.Drawing.Color.White
            Me.dgvOpsi.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvOpsi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            Me.dgvOpsi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvOpsi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
            Me.dgvOpsi.ColumnHeadersHeight = 42
            Me.dgvOpsi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvOpsi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOpsiId, Me.colOpsiNama, Me.colOpsiTipe, Me.colOpsiHarga})
            Me.dgvOpsi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvOpsi.EnableHeadersVisualStyles = False
            Me.dgvOpsi.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvOpsi.Location = New System.Drawing.Point(14, 14)
            Me.dgvOpsi.MultiSelect = False
            Me.dgvOpsi.Name = "dgvOpsi"
            Me.dgvOpsi.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvOpsi.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvOpsi.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvOpsi.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvOpsi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.dgvOpsi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvOpsi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 240, 230)
            Me.dgvOpsi.ThemeStyle.RowsStyle.Height = 40
            Me.dgvOpsi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvOpsi.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dgvOpsi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
            Me.dgvOpsi.ThemeStyle.HeaderStyle.Height = 42
            Me.dgvOpsi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.dgvOpsi.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.dgvOpsi.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            Me.dgvOpsi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 230)
            Me.dgvOpsi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.dgvOpsi.ThemeStyle.BackColor = System.Drawing.Color.White
            Me.dgvOpsi.ReadOnly = True
            Me.dgvOpsi.RowHeadersVisible = False
            Me.dgvOpsi.RowTemplate.Height = 40
            Me.dgvOpsi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvOpsi.Size = New System.Drawing.Size(768, 514)
            Me.dgvOpsi.TabIndex = 0
            '
            'colOpsiId
            '
            Me.colOpsiId.DataPropertyName = "id_opsi"
            Me.colOpsiId.HeaderText = "ID"
            Me.colOpsiId.Name = "colOpsiId"
            Me.colOpsiId.ReadOnly = True
            Me.colOpsiId.Width = 60
            '
            'colOpsiNama
            '
            Me.colOpsiNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.colOpsiNama.DataPropertyName = "nama_opsi"
            Me.colOpsiNama.HeaderText = "Nama Opsi"
            Me.colOpsiNama.Name = "colOpsiNama"
            Me.colOpsiNama.ReadOnly = True
            '
            'colOpsiTipe
            '
            Me.colOpsiTipe.DataPropertyName = "tipe"
            Me.colOpsiTipe.HeaderText = "Tipe"
            Me.colOpsiTipe.Name = "colOpsiTipe"
            Me.colOpsiTipe.ReadOnly = True
            Me.colOpsiTipe.Width = 110
            '
            'colOpsiHarga
            '
            Me.colOpsiHarga.DataPropertyName = "tambahan_harga"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.Format = "C0"
            Me.colOpsiHarga.DefaultCellStyle = DataGridViewCellStyle9
            Me.colOpsiHarga.HeaderText = "Tambahan Harga"
            Me.colOpsiHarga.Name = "colOpsiHarga"
            Me.colOpsiHarga.ReadOnly = True
            Me.colOpsiHarga.Width = 140
            '
            'pnlRightOpsi
            '
            Me.pnlRightOpsi.Controls.Add(Me.cardEdOpsi)
            Me.pnlRightOpsi.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlRightOpsi.Location = New System.Drawing.Point(814, 70)
            Me.pnlRightOpsi.Name = "pnlRightOpsi"
            Me.pnlRightOpsi.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
            Me.pnlRightOpsi.Size = New System.Drawing.Size(340, 542)
            Me.pnlRightOpsi.TabIndex = 2
            '
            'cardEdOpsi
            '
            Me.cardEdOpsi.BackColor = System.Drawing.Color.Transparent
            Me.cardEdOpsi.BorderColor = System.Drawing.Color.FromArgb(232, 221, 212)
            Me.cardEdOpsi.BorderRadius = 16
            Me.cardEdOpsi.BorderThickness = 1
            Me.cardEdOpsi.Controls.Add(Me.lblNamaOpsi)
            Me.cardEdOpsi.Controls.Add(Me.txtNamaOpsi)
            Me.cardEdOpsi.Controls.Add(Me.lblTipeOpsi)
            Me.cardEdOpsi.Controls.Add(Me.cboTipeOpsi)
            Me.cardEdOpsi.Controls.Add(Me.lblHargaOpsi)
            Me.cardEdOpsi.Controls.Add(Me.txtTambahanHarga)
            Me.cardEdOpsi.Controls.Add(Me.btnAddOpsi)
            Me.cardEdOpsi.Controls.Add(Me.btnDelOpsi)
            Me.cardEdOpsi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardEdOpsi.FillColor = System.Drawing.Color.White
            Me.cardEdOpsi.Location = New System.Drawing.Point(14, 0)
            Me.cardEdOpsi.Name = "cardEdOpsi"
            Me.cardEdOpsi.Padding = New System.Windows.Forms.Padding(16)
            Me.cardEdOpsi.Size = New System.Drawing.Size(326, 542)
            Me.cardEdOpsi.TabIndex = 0
            Me.cardEdOpsi.UseTransparentBackground = True
            '
            'lblNamaOpsi
            '
            Me.lblNamaOpsi.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblNamaOpsi.Location = New System.Drawing.Point(16, 20)
            Me.lblNamaOpsi.Name = "lblNamaOpsi"
            Me.lblNamaOpsi.Size = New System.Drawing.Size(280, 20)
            Me.lblNamaOpsi.TabIndex = 0
            Me.lblNamaOpsi.Text = "Nama Opsi"
            '
            'txtNamaOpsi
            '
            Me.txtNamaOpsi.BackColor = System.Drawing.Color.Transparent
            Me.txtNamaOpsi.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtNamaOpsi.BorderRadius = 12
            Me.txtNamaOpsi.DefaultText = ""
            Me.txtNamaOpsi.FillColor = System.Drawing.Color.White
            Me.txtNamaOpsi.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNamaOpsi.Location = New System.Drawing.Point(16, 44)
            Me.txtNamaOpsi.Name = "txtNamaOpsi"
            Me.txtNamaOpsi.PlaceholderText = "Contoh: Ekstra Keju"
            Me.txtNamaOpsi.Size = New System.Drawing.Size(290, 38)
            Me.txtNamaOpsi.TabIndex = 1
            Me.txtNamaOpsi.BorderThickness = 1
            '
            'lblTipeOpsi
            '
            Me.lblTipeOpsi.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblTipeOpsi.Location = New System.Drawing.Point(16, 94)
            Me.lblTipeOpsi.Name = "lblTipeOpsi"
            Me.lblTipeOpsi.Size = New System.Drawing.Size(280, 20)
            Me.lblTipeOpsi.TabIndex = 2
            Me.lblTipeOpsi.Text = "Tipe"
            '
            'cboTipeOpsi
            '
            Me.cboTipeOpsi.BackColor = System.Drawing.Color.Transparent
            Me.cboTipeOpsi.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.cboTipeOpsi.BorderRadius = 12
            Me.cboTipeOpsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTipeOpsi.FillColor = System.Drawing.Color.White
            Me.cboTipeOpsi.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboTipeOpsi.ItemHeight = 32
            Me.cboTipeOpsi.Location = New System.Drawing.Point(16, 118)
            Me.cboTipeOpsi.Name = "cboTipeOpsi"
            Me.cboTipeOpsi.Size = New System.Drawing.Size(290, 38)
            Me.cboTipeOpsi.TabIndex = 3
            Me.cboTipeOpsi.BorderThickness = 1
            '
            'lblHargaOpsi
            '
            Me.lblHargaOpsi.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblHargaOpsi.Location = New System.Drawing.Point(16, 168)
            Me.lblHargaOpsi.Name = "lblHargaOpsi"
            Me.lblHargaOpsi.Size = New System.Drawing.Size(280, 20)
            Me.lblHargaOpsi.TabIndex = 4
            Me.lblHargaOpsi.Text = "Tambahan Harga (Rp)"
            '
            'txtTambahanHarga
            '
            Me.txtTambahanHarga.BackColor = System.Drawing.Color.Transparent
            Me.txtTambahanHarga.BorderColor = System.Drawing.Color.FromArgb(219, 204, 190)
            Me.txtTambahanHarga.BorderRadius = 12
            Me.txtTambahanHarga.DefaultText = "0"
            Me.txtTambahanHarga.FillColor = System.Drawing.Color.White
            Me.txtTambahanHarga.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtTambahanHarga.Location = New System.Drawing.Point(16, 192)
            Me.txtTambahanHarga.Name = "txtTambahanHarga"
            Me.txtTambahanHarga.Size = New System.Drawing.Size(290, 38)
            Me.txtTambahanHarga.TabIndex = 5
            Me.txtTambahanHarga.BorderThickness = 1
            Me.txtTambahanHarga.Text = "0"
            '
            'btnAddOpsi
            '
            Me.btnAddOpsi.BackColor = System.Drawing.Color.Transparent
            Me.btnAddOpsi.BorderRadius = 12
            Me.btnAddOpsi.FillColor = System.Drawing.Color.FromArgb(255, 107, 53)
            Me.btnAddOpsi.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnAddOpsi.ForeColor = System.Drawing.Color.White
            Me.btnAddOpsi.Location = New System.Drawing.Point(16, 250)
            Me.btnAddOpsi.Name = "btnAddOpsi"
            Me.btnAddOpsi.BorderThickness = 0
            Me.btnAddOpsi.Size = New System.Drawing.Size(140, 42)
            Me.btnAddOpsi.TabIndex = 6
            Me.btnAddOpsi.Text = "Tambah Opsi"
            Me.btnAddOpsi.UseTransparentBackground = True
            '
            'btnDelOpsi
            '
            Me.btnDelOpsi.BackColor = System.Drawing.Color.Transparent
            Me.btnDelOpsi.BorderColor = System.Drawing.Color.FromArgb(234, 181, 176)
            Me.btnDelOpsi.BorderRadius = 12
            Me.btnDelOpsi.BorderThickness = 1
            Me.btnDelOpsi.FillColor = System.Drawing.Color.FromArgb(253, 236, 236)
            Me.btnDelOpsi.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnDelOpsi.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
            Me.btnDelOpsi.Location = New System.Drawing.Point(166, 250)
            Me.btnDelOpsi.Name = "btnDelOpsi"
            Me.btnDelOpsi.Size = New System.Drawing.Size(140, 42)
            Me.btnDelOpsi.TabIndex = 7
            Me.btnDelOpsi.Text = "Hapus Terpilih"
            Me.btnDelOpsi.UseTransparentBackground = True
            '
            'FrmProduk
            '
            Me.BackColor = System.Drawing.Color.FromArgb(255, 250, 240)
            Me.ClientSize = New System.Drawing.Size(1180, 680)
            Me.Controls.Add(Me.tabProduk)
            Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.ForeColor = System.Drawing.Color.FromArgb(44, 24, 16)
            Me.Name = "FrmProduk"
            Me.Text = "Manajemen Produk, Kategori & Opsi"
            CType(Me.errProduk, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabProduk.ResumeLayout(False)
            Me.tpProduk.ResumeLayout(False)
            Me.pnlLeftProd.ResumeLayout(False)
            Me.cardGridProd.ResumeLayout(False)
            CType(Me.dgvProduk, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFilterTop.ResumeLayout(False)
            Me.pnlRightProd.ResumeLayout(False)
            Me.cardFormProd.ResumeLayout(False)
            CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpKategori.ResumeLayout(False)
            Me.cardGridKat.ResumeLayout(False)
            CType(Me.dgvKategori, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlRightKat.ResumeLayout(False)
            Me.cardEdKat.ResumeLayout(False)
            CType(Me.nudUrutan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpOpsi.ResumeLayout(False)
            Me.cardGridOpsi.ResumeLayout(False)
            CType(Me.dgvOpsi, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlRightOpsi.ResumeLayout(False)
            Me.cardEdOpsi.ResumeLayout(False)
            Me.pnlTopOpsi.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents errProduk As System.Windows.Forms.ErrorProvider
        Friend WithEvents tabProduk As Guna.UI2.WinForms.Guna2TabControl
        Friend WithEvents tpProduk As System.Windows.Forms.TabPage
        Friend WithEvents pnlLeftProd As System.Windows.Forms.Panel
        Friend WithEvents cardGridProd As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents pnlFilterTop As System.Windows.Forms.Panel
        Friend WithEvents cboFilterKat As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents txtCari As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents dgvProduk As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colProdId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colProdNama As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colProdKat As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colProdHarga As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colProdStok As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colProdAktif As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents pnlRightProd As System.Windows.Forms.Panel
        Friend WithEvents cardFormProd As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents picFoto As System.Windows.Forms.PictureBox
        Friend WithEvents btnFoto As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblFotoHint As System.Windows.Forms.Label
        Friend WithEvents lblProdNama As System.Windows.Forms.Label
        Friend WithEvents txtNama As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblProdKat As System.Windows.Forms.Label
        Friend WithEvents cboKategori As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblProdHarga As System.Windows.Forms.Label
        Friend WithEvents txtHarga As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblProdStok As System.Windows.Forms.Label
        Friend WithEvents txtStok As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnStok10 As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnStok50 As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblProdDesk As System.Windows.Forms.Label
        Friend WithEvents txtDeskripsi As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents chkTersedia As System.Windows.Forms.CheckBox
        Friend WithEvents chkBestSeller As System.Windows.Forms.CheckBox
        Friend WithEvents btnBaru As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSimpan As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnHapus As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents tpKategori As System.Windows.Forms.TabPage
        Friend WithEvents cardGridKat As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvKategori As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colKatId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colKatNama As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colKatUrutan As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnlRightKat As System.Windows.Forms.Panel
        Friend WithEvents cardEdKat As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblNamaKat As System.Windows.Forms.Label
        Friend WithEvents txtNamaKat As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblUrutanKat As System.Windows.Forms.Label
        Friend WithEvents nudUrutan As System.Windows.Forms.NumericUpDown
        Friend WithEvents btnBaruKat As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSimpanKat As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnHapusKat As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents tpOpsi As System.Windows.Forms.TabPage
        Friend WithEvents pnlTopOpsi As System.Windows.Forms.Panel
        Friend WithEvents lblPilihProdOpsi As System.Windows.Forms.Label
        Friend WithEvents cboOpsiProduk As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents cardGridOpsi As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents dgvOpsi As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents colOpsiId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colOpsiNama As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colOpsiTipe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colOpsiHarga As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnlRightOpsi As System.Windows.Forms.Panel
        Friend WithEvents cardEdOpsi As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblNamaOpsi As System.Windows.Forms.Label
        Friend WithEvents txtNamaOpsi As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblTipeOpsi As System.Windows.Forms.Label
        Friend WithEvents cboTipeOpsi As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblHargaOpsi As System.Windows.Forms.Label
        Friend WithEvents txtTambahanHarga As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnAddOpsi As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnDelOpsi As Guna.UI2.WinForms.Guna2Button

    End Class
End Namespace
