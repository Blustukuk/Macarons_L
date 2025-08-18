<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.lblTglJam = New System.Windows.Forms.Label()
        Me.Guna2ControlBox3 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2ControlBox2 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnGantiPassword = New Guna.UI2.WinForms.Guna2Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDelAllData = New Guna.UI2.WinForms.Guna2Button()
        Me.btnReturPenjualan = New Guna.UI2.WinForms.Guna2Button()
        Me.btnLaporan = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPembelian = New Guna.UI2.WinForms.Guna2Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDashboardLogOut = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMasterBrand = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPengadaanKhusus = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPengadaan = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMasterArtikel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMasterSupplier = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPenjualan = New Guna.UI2.WinForms.Guna2Button()
        Me.btnVoucher = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator3 = New Guna.UI2.WinForms.Guna2Separator()
        Me.btnCetakBarcode = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator2 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.btnBatalPembelian = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEditStok = New Guna.UI2.WinForms.Guna2Button()
        Me.btnBarcodeManual = New Guna.UI2.WinForms.Guna2Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.tJam = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Panel1.Controls.Add(Me.lblUserID)
        Me.Guna2Panel1.Controls.Add(Me.lblTglJam)
        Me.Guna2Panel1.Controls.Add(Me.Guna2ControlBox3)
        Me.Guna2Panel1.Controls.Add(Me.Guna2ControlBox2)
        Me.Guna2Panel1.Controls.Add(Me.Guna2ControlBox1)
        Me.Guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.Guna2Panel1.CustomBorderThickness = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1920, 33)
        Me.Guna2Panel1.TabIndex = 1
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.Location = New System.Drawing.Point(142, 9)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(13, 13)
        Me.lblUserID.TabIndex = 195
        Me.lblUserID.Text = "0"
        Me.lblUserID.Visible = False
        '
        'lblTglJam
        '
        Me.lblTglJam.AutoSize = True
        Me.lblTglJam.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTglJam.ForeColor = System.Drawing.Color.White
        Me.lblTglJam.Location = New System.Drawing.Point(5, 5)
        Me.lblTglJam.Name = "lblTglJam"
        Me.lblTglJam.Size = New System.Drawing.Size(100, 24)
        Me.lblTglJam.TabIndex = 3
        Me.lblTglJam.Text = "Sekarang :"
        '
        'Guna2ControlBox3
        '
        Me.Guna2ControlBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Guna2ControlBox3.BorderRadius = 8
        Me.Guna2ControlBox3.BorderThickness = 2
        Me.Guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.Guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Guna2ControlBox3.IconColor = System.Drawing.Color.White
        Me.Guna2ControlBox3.Location = New System.Drawing.Point(1803, 5)
        Me.Guna2ControlBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2ControlBox3.Name = "Guna2ControlBox3"
        Me.Guna2ControlBox3.Size = New System.Drawing.Size(34, 24)
        Me.Guna2ControlBox3.TabIndex = 0
        '
        'Guna2ControlBox2
        '
        Me.Guna2ControlBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Guna2ControlBox2.BorderRadius = 8
        Me.Guna2ControlBox2.BorderThickness = 2
        Me.Guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox
        Me.Guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Guna2ControlBox2.IconColor = System.Drawing.Color.White
        Me.Guna2ControlBox2.Location = New System.Drawing.Point(1841, 5)
        Me.Guna2ControlBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2ControlBox2.Name = "Guna2ControlBox2"
        Me.Guna2ControlBox2.Size = New System.Drawing.Size(34, 24)
        Me.Guna2ControlBox2.TabIndex = 0
        '
        'Guna2ControlBox1
        '
        Me.Guna2ControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Guna2ControlBox1.BorderRadius = 8
        Me.Guna2ControlBox1.BorderThickness = 2
        Me.Guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Guna2ControlBox1.IconColor = System.Drawing.Color.White
        Me.Guna2ControlBox1.Location = New System.Drawing.Point(1879, 5)
        Me.Guna2ControlBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2ControlBox1.Name = "Guna2ControlBox1"
        Me.Guna2ControlBox1.Size = New System.Drawing.Size(34, 24)
        Me.Guna2ControlBox1.TabIndex = 0
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Guna2Panel2.Controls.Add(Me.btnGantiPassword)
        Me.Guna2Panel2.Controls.Add(Me.Label5)
        Me.Guna2Panel2.Controls.Add(Me.btnDelAllData)
        Me.Guna2Panel2.Controls.Add(Me.btnReturPenjualan)
        Me.Guna2Panel2.Controls.Add(Me.btnLaporan)
        Me.Guna2Panel2.Controls.Add(Me.Label1)
        Me.Guna2Panel2.Controls.Add(Me.Label3)
        Me.Guna2Panel2.Controls.Add(Me.btnPembelian)
        Me.Guna2Panel2.Controls.Add(Me.Label4)
        Me.Guna2Panel2.Controls.Add(Me.btnDashboardLogOut)
        Me.Guna2Panel2.Controls.Add(Me.btnMasterBrand)
        Me.Guna2Panel2.Controls.Add(Me.btnPengadaanKhusus)
        Me.Guna2Panel2.Controls.Add(Me.btnPengadaan)
        Me.Guna2Panel2.Controls.Add(Me.btnMasterArtikel)
        Me.Guna2Panel2.Controls.Add(Me.btnMasterSupplier)
        Me.Guna2Panel2.Controls.Add(Me.btnPenjualan)
        Me.Guna2Panel2.Controls.Add(Me.btnVoucher)
        Me.Guna2Panel2.Controls.Add(Me.Guna2Separator3)
        Me.Guna2Panel2.Controls.Add(Me.btnCetakBarcode)
        Me.Guna2Panel2.Controls.Add(Me.Guna2Separator2)
        Me.Guna2Panel2.Controls.Add(Me.Guna2Separator1)
        Me.Guna2Panel2.Controls.Add(Me.btnBatalPembelian)
        Me.Guna2Panel2.Controls.Add(Me.btnEditStok)
        Me.Guna2Panel2.Controls.Add(Me.btnBarcodeManual)
        Me.Guna2Panel2.Controls.Add(Me.Label2)
        Me.Guna2Panel2.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.Guna2Panel2.CustomBorderThickness = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 33)
        Me.Guna2Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(188, 1047)
        Me.Guna2Panel2.TabIndex = 2
        '
        'btnGantiPassword
        '
        Me.btnGantiPassword.Animated = True
        Me.btnGantiPassword.BorderRadius = 8
        Me.btnGantiPassword.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnGantiPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnGantiPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnGantiPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnGantiPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnGantiPassword.FillColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.btnGantiPassword.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnGantiPassword.ForeColor = System.Drawing.Color.Black
        Me.btnGantiPassword.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnGantiPassword.Location = New System.Drawing.Point(5, 798)
        Me.btnGantiPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGantiPassword.Name = "btnGantiPassword"
        Me.btnGantiPassword.Size = New System.Drawing.Size(176, 37)
        Me.btnGantiPassword.TabIndex = 14
        Me.btnGantiPassword.Text = "Ganti Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 819)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "User"
        '
        'btnDelAllData
        '
        Me.btnDelAllData.Animated = True
        Me.btnDelAllData.BorderRadius = 8
        Me.btnDelAllData.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnDelAllData.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelAllData.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelAllData.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelAllData.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelAllData.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnDelAllData.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnDelAllData.ForeColor = System.Drawing.Color.White
        Me.btnDelAllData.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnDelAllData.Location = New System.Drawing.Point(5, 696)
        Me.btnDelAllData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelAllData.Name = "btnDelAllData"
        Me.btnDelAllData.Size = New System.Drawing.Size(176, 37)
        Me.btnDelAllData.TabIndex = 9
        Me.btnDelAllData.Text = "Hapus Data"
        '
        'btnReturPenjualan
        '
        Me.btnReturPenjualan.Animated = True
        Me.btnReturPenjualan.BorderRadius = 8
        Me.btnReturPenjualan.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnReturPenjualan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnReturPenjualan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnReturPenjualan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnReturPenjualan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnReturPenjualan.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnReturPenjualan.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnReturPenjualan.ForeColor = System.Drawing.Color.White
        Me.btnReturPenjualan.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnReturPenjualan.Location = New System.Drawing.Point(5, 655)
        Me.btnReturPenjualan.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReturPenjualan.Name = "btnReturPenjualan"
        Me.btnReturPenjualan.Size = New System.Drawing.Size(176, 37)
        Me.btnReturPenjualan.TabIndex = 9
        Me.btnReturPenjualan.Text = "Retur Penjualan"
        '
        'btnLaporan
        '
        Me.btnLaporan.Animated = True
        Me.btnLaporan.BorderRadius = 8
        Me.btnLaporan.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnLaporan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnLaporan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnLaporan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnLaporan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnLaporan.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnLaporan.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnLaporan.ForeColor = System.Drawing.Color.White
        Me.btnLaporan.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnLaporan.Location = New System.Drawing.Point(5, 614)
        Me.btnLaporan.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLaporan.Name = "btnLaporan"
        Me.btnLaporan.Size = New System.Drawing.Size(176, 37)
        Me.btnLaporan.TabIndex = 9
        Me.btnLaporan.Text = "Laporan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Curlz MT", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(78, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 28)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Solutions"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 222)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Gudang"
        '
        'btnPembelian
        '
        Me.btnPembelian.Animated = True
        Me.btnPembelian.BorderRadius = 8
        Me.btnPembelian.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnPembelian.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPembelian.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPembelian.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPembelian.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPembelian.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPembelian.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnPembelian.ForeColor = System.Drawing.Color.White
        Me.btnPembelian.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnPembelian.Location = New System.Drawing.Point(5, 241)
        Me.btnPembelian.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPembelian.Name = "btnPembelian"
        Me.btnPembelian.Size = New System.Drawing.Size(176, 37)
        Me.btnPembelian.TabIndex = 5
        Me.btnPembelian.Text = "Pembelian"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("NewsGoth Cn BT", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(53, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Macarons"
        '
        'btnDashboardLogOut
        '
        Me.btnDashboardLogOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDashboardLogOut.Animated = True
        Me.btnDashboardLogOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnDashboardLogOut.BorderRadius = 8
        Me.btnDashboardLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDashboardLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDashboardLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDashboardLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDashboardLogOut.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnDashboardLogOut.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashboardLogOut.ForeColor = System.Drawing.Color.White
        Me.btnDashboardLogOut.Location = New System.Drawing.Point(8, 1012)
        Me.btnDashboardLogOut.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDashboardLogOut.Name = "btnDashboardLogOut"
        Me.btnDashboardLogOut.Size = New System.Drawing.Size(173, 25)
        Me.btnDashboardLogOut.TabIndex = 10
        Me.btnDashboardLogOut.Text = "LOGOUT"
        '
        'btnMasterBrand
        '
        Me.btnMasterBrand.Animated = True
        Me.btnMasterBrand.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnMasterBrand.BorderRadius = 8
        Me.btnMasterBrand.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnMasterBrand.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterBrand.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterBrand.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnMasterBrand.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnMasterBrand.FillColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnMasterBrand.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnMasterBrand.ForeColor = System.Drawing.Color.White
        Me.btnMasterBrand.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnMasterBrand.Location = New System.Drawing.Point(5, 130)
        Me.btnMasterBrand.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMasterBrand.Name = "btnMasterBrand"
        Me.btnMasterBrand.Size = New System.Drawing.Size(176, 37)
        Me.btnMasterBrand.TabIndex = 2
        Me.btnMasterBrand.Text = "Master Brand"
        '
        'btnPengadaanKhusus
        '
        Me.btnPengadaanKhusus.Animated = True
        Me.btnPengadaanKhusus.BorderRadius = 8
        Me.btnPengadaanKhusus.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnPengadaanKhusus.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPengadaanKhusus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPengadaanKhusus.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPengadaanKhusus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPengadaanKhusus.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPengadaanKhusus.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnPengadaanKhusus.ForeColor = System.Drawing.Color.White
        Me.btnPengadaanKhusus.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnPengadaanKhusus.Location = New System.Drawing.Point(5, 324)
        Me.btnPengadaanKhusus.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPengadaanKhusus.Name = "btnPengadaanKhusus"
        Me.btnPengadaanKhusus.Size = New System.Drawing.Size(176, 37)
        Me.btnPengadaanKhusus.TabIndex = 6
        Me.btnPengadaanKhusus.Text = "Pengadaan Khusus"
        '
        'btnPengadaan
        '
        Me.btnPengadaan.Animated = True
        Me.btnPengadaan.BorderRadius = 8
        Me.btnPengadaan.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnPengadaan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPengadaan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPengadaan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPengadaan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPengadaan.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPengadaan.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnPengadaan.ForeColor = System.Drawing.Color.White
        Me.btnPengadaan.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnPengadaan.Location = New System.Drawing.Point(5, 283)
        Me.btnPengadaan.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPengadaan.Name = "btnPengadaan"
        Me.btnPengadaan.Size = New System.Drawing.Size(176, 37)
        Me.btnPengadaan.TabIndex = 6
        Me.btnPengadaan.Text = "Pengadaan"
        '
        'btnMasterArtikel
        '
        Me.btnMasterArtikel.Animated = True
        Me.btnMasterArtikel.BorderRadius = 8
        Me.btnMasterArtikel.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnMasterArtikel.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterArtikel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterArtikel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnMasterArtikel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnMasterArtikel.FillColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnMasterArtikel.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnMasterArtikel.ForeColor = System.Drawing.Color.White
        Me.btnMasterArtikel.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnMasterArtikel.Location = New System.Drawing.Point(5, 170)
        Me.btnMasterArtikel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMasterArtikel.Name = "btnMasterArtikel"
        Me.btnMasterArtikel.Size = New System.Drawing.Size(176, 37)
        Me.btnMasterArtikel.TabIndex = 3
        Me.btnMasterArtikel.Text = "Master Artikel"
        '
        'btnMasterSupplier
        '
        Me.btnMasterSupplier.Animated = True
        Me.btnMasterSupplier.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnMasterSupplier.BorderRadius = 8
        Me.btnMasterSupplier.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnMasterSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnMasterSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnMasterSupplier.FillColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnMasterSupplier.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMasterSupplier.ForeColor = System.Drawing.Color.White
        Me.btnMasterSupplier.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnMasterSupplier.Location = New System.Drawing.Point(5, 89)
        Me.btnMasterSupplier.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMasterSupplier.Name = "btnMasterSupplier"
        Me.btnMasterSupplier.Size = New System.Drawing.Size(176, 37)
        Me.btnMasterSupplier.TabIndex = 1
        Me.btnMasterSupplier.Text = "Master Supplier"
        '
        'btnPenjualan
        '
        Me.btnPenjualan.Animated = True
        Me.btnPenjualan.BorderRadius = 8
        Me.btnPenjualan.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnPenjualan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPenjualan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPenjualan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPenjualan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPenjualan.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPenjualan.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnPenjualan.ForeColor = System.Drawing.Color.White
        Me.btnPenjualan.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnPenjualan.Location = New System.Drawing.Point(5, 365)
        Me.btnPenjualan.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPenjualan.Name = "btnPenjualan"
        Me.btnPenjualan.Size = New System.Drawing.Size(176, 37)
        Me.btnPenjualan.TabIndex = 9
        Me.btnPenjualan.Text = "Penjualan"
        '
        'btnVoucher
        '
        Me.btnVoucher.Animated = True
        Me.btnVoucher.BorderRadius = 8
        Me.btnVoucher.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnVoucher.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnVoucher.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnVoucher.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnVoucher.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnVoucher.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnVoucher.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnVoucher.ForeColor = System.Drawing.Color.White
        Me.btnVoucher.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnVoucher.Location = New System.Drawing.Point(5, 572)
        Me.btnVoucher.Margin = New System.Windows.Forms.Padding(2)
        Me.btnVoucher.Name = "btnVoucher"
        Me.btnVoucher.Size = New System.Drawing.Size(176, 37)
        Me.btnVoucher.TabIndex = 9
        Me.btnVoucher.Text = "Voucher"
        '
        'Guna2Separator3
        '
        Me.Guna2Separator3.Location = New System.Drawing.Point(8, 756)
        Me.Guna2Separator3.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Separator3.Name = "Guna2Separator3"
        Me.Guna2Separator3.Size = New System.Drawing.Size(172, 17)
        Me.Guna2Separator3.TabIndex = 2
        '
        'btnCetakBarcode
        '
        Me.btnCetakBarcode.Animated = True
        Me.btnCetakBarcode.BorderRadius = 8
        Me.btnCetakBarcode.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnCetakBarcode.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCetakBarcode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCetakBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCetakBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCetakBarcode.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnCetakBarcode.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnCetakBarcode.ForeColor = System.Drawing.Color.White
        Me.btnCetakBarcode.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnCetakBarcode.Location = New System.Drawing.Point(5, 407)
        Me.btnCetakBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCetakBarcode.Name = "btnCetakBarcode"
        Me.btnCetakBarcode.Size = New System.Drawing.Size(176, 37)
        Me.btnCetakBarcode.TabIndex = 7
        Me.btnCetakBarcode.Text = "Cetak Barcode"
        '
        'Guna2Separator2
        '
        Me.Guna2Separator2.Location = New System.Drawing.Point(9, 209)
        Me.Guna2Separator2.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Separator2.Name = "Guna2Separator2"
        Me.Guna2Separator2.Size = New System.Drawing.Size(172, 8)
        Me.Guna2Separator2.TabIndex = 2
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.Location = New System.Drawing.Point(9, 60)
        Me.Guna2Separator1.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(174, 8)
        Me.Guna2Separator1.TabIndex = 2
        '
        'btnBatalPembelian
        '
        Me.btnBatalPembelian.Animated = True
        Me.btnBatalPembelian.BorderRadius = 8
        Me.btnBatalPembelian.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBatalPembelian.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnBatalPembelian.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnBatalPembelian.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnBatalPembelian.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnBatalPembelian.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnBatalPembelian.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnBatalPembelian.ForeColor = System.Drawing.Color.White
        Me.btnBatalPembelian.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnBatalPembelian.Location = New System.Drawing.Point(5, 531)
        Me.btnBatalPembelian.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBatalPembelian.Name = "btnBatalPembelian"
        Me.btnBatalPembelian.Size = New System.Drawing.Size(176, 37)
        Me.btnBatalPembelian.TabIndex = 8
        Me.btnBatalPembelian.Text = "Batal Pembelian"
        '
        'btnEditStok
        '
        Me.btnEditStok.Animated = True
        Me.btnEditStok.BorderRadius = 8
        Me.btnEditStok.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnEditStok.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnEditStok.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnEditStok.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnEditStok.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnEditStok.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnEditStok.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnEditStok.ForeColor = System.Drawing.Color.White
        Me.btnEditStok.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnEditStok.Location = New System.Drawing.Point(5, 490)
        Me.btnEditStok.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditStok.Name = "btnEditStok"
        Me.btnEditStok.Size = New System.Drawing.Size(176, 37)
        Me.btnEditStok.TabIndex = 8
        Me.btnEditStok.Text = "Edit Stok"
        '
        'btnBarcodeManual
        '
        Me.btnBarcodeManual.Animated = True
        Me.btnBarcodeManual.BorderRadius = 8
        Me.btnBarcodeManual.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBarcodeManual.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnBarcodeManual.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnBarcodeManual.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnBarcodeManual.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnBarcodeManual.FillColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnBarcodeManual.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.btnBarcodeManual.ForeColor = System.Drawing.Color.White
        Me.btnBarcodeManual.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnBarcodeManual.Location = New System.Drawing.Point(5, 449)
        Me.btnBarcodeManual.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBarcodeManual.Name = "btnBarcodeManual"
        Me.btnBarcodeManual.Size = New System.Drawing.Size(176, 37)
        Me.btnBarcodeManual.TabIndex = 8
        Me.btnBarcodeManual.Text = "Barcode Manual"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 71)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Admin"
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.Image = Global.GudangMacarons.My.Resources.Resources.logo2
        Me.Guna2CirclePictureBox1.ImageRotate = 0!
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.Guna2CirclePictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(48, 52)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox1.TabIndex = 0
        Me.Guna2CirclePictureBox1.TabStop = False
        '
        'tJam
        '
        Me.tJam.Enabled = True
        Me.tJam.Interval = 1000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2ControlBox3 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2ControlBox2 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnPembelian As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDashboardLogOut As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMasterBrand As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPengadaan As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMasterArtikel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMasterSupplier As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLaporan As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator3 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents btnCetakBarcode As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator2 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents btnBarcodeManual As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTglJam As Label
    Friend WithEvents tJam As Timer
    Friend WithEvents lblUserID As Label
    Friend WithEvents btnPenjualan As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnGantiPassword As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnEditStok As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnBatalPembelian As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnVoucher As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPengadaanKhusus As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnReturPenjualan As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelAllData As Guna.UI2.WinForms.Guna2Button
End Class
