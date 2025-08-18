<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPenjualanPembayaran
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPenjualanPembayaran))
        Me.gbdiskon = New System.Windows.Forms.GroupBox()
        Me.txtdiskonpersen = New System.Windows.Forms.TextBox()
        Me.txtdiskonrupiah = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbdiskon = New System.Windows.Forms.CheckBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbbank = New System.Windows.Forms.ComboBox()
        Me.txtnoedc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbltotal2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn200 = New System.Windows.Forms.Button()
        Me.btn500 = New System.Windows.Forms.Button()
        Me.btn1000 = New System.Windows.Forms.Button()
        Me.btn2000 = New System.Windows.Forms.Button()
        Me.btn5000 = New System.Windows.Forms.Button()
        Me.btn10000 = New System.Windows.Forms.Button()
        Me.btn20000 = New System.Windows.Forms.Button()
        Me.btn50000 = New System.Windows.Forms.Button()
        Me.btn100000 = New System.Windows.Forms.Button()
        Me.lblkurang = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtbayar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnProses = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.lblTotalAsli = New System.Windows.Forms.Label()
        Me.gbdiskon.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbdiskon
        '
        Me.gbdiskon.Controls.Add(Me.txtdiskonpersen)
        Me.gbdiskon.Controls.Add(Me.txtdiskonrupiah)
        Me.gbdiskon.Controls.Add(Me.Label3)
        Me.gbdiskon.Controls.Add(Me.Label10)
        Me.gbdiskon.Enabled = False
        Me.gbdiskon.Location = New System.Drawing.Point(590, 295)
        Me.gbdiskon.Name = "gbdiskon"
        Me.gbdiskon.Size = New System.Drawing.Size(322, 119)
        Me.gbdiskon.TabIndex = 196
        Me.gbdiskon.TabStop = False
        '
        'txtdiskonpersen
        '
        Me.txtdiskonpersen.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiskonpersen.Location = New System.Drawing.Point(6, 16)
        Me.txtdiskonpersen.MaxLength = 2
        Me.txtdiskonpersen.Name = "txtdiskonpersen"
        Me.txtdiskonpersen.Size = New System.Drawing.Size(53, 44)
        Me.txtdiskonpersen.TabIndex = 189
        '
        'txtdiskonrupiah
        '
        Me.txtdiskonrupiah.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiskonrupiah.Location = New System.Drawing.Point(6, 66)
        Me.txtdiskonrupiah.MaxLength = 10
        Me.txtdiskonrupiah.Name = "txtdiskonrupiah"
        Me.txtdiskonrupiah.Size = New System.Drawing.Size(194, 44)
        Me.txtdiskonrupiah.TabIndex = 189
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(65, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 37)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(206, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 37)
        Me.Label10.TabIndex = 145
        Me.Label10.Text = "rupiah"
        '
        'cbdiskon
        '
        Me.cbdiskon.AutoSize = True
        Me.cbdiskon.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbdiskon.Location = New System.Drawing.Point(567, 255)
        Me.cbdiskon.Name = "cbdiskon"
        Me.cbdiskon.Size = New System.Drawing.Size(134, 41)
        Me.cbdiskon.TabIndex = 195
        Me.cbdiskon.Text = "Diskon"
        Me.cbdiskon.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(13, 274)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(102, 41)
        Me.RadioButton2.TabIndex = 193
        Me.RadioButton2.Text = "EDC"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbbank)
        Me.GroupBox2.Controls.Add(Me.txtnoedc)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lbltotal2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(12, 321)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(529, 197)
        Me.GroupBox2.TabIndex = 192
        Me.GroupBox2.TabStop = False
        '
        'cmbbank
        '
        Me.cmbbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbank.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbbank.FormattingEnabled = True
        Me.cmbbank.Location = New System.Drawing.Point(243, 67)
        Me.cmbbank.Name = "cmbbank"
        Me.cmbbank.Size = New System.Drawing.Size(279, 45)
        Me.cmbbank.TabIndex = 1
        '
        'txtnoedc
        '
        Me.txtnoedc.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnoedc.Location = New System.Drawing.Point(243, 118)
        Me.txtnoedc.MaxLength = 20
        Me.txtnoedc.Name = "txtnoedc"
        Me.txtnoedc.Size = New System.Drawing.Size(279, 44)
        Me.txtnoedc.TabIndex = 2
        Me.txtnoedc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(196, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 37)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(0, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 37)
        Me.Label13.TabIndex = 151
        Me.Label13.Text = "Nomor"
        '
        'lbltotal2
        '
        Me.lbltotal2.BackColor = System.Drawing.Color.Transparent
        Me.lbltotal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal2.ForeColor = System.Drawing.Color.Black
        Me.lbltotal2.Location = New System.Drawing.Point(243, 12)
        Me.lbltotal2.Name = "lbltotal2"
        Me.lbltotal2.Size = New System.Drawing.Size(279, 44)
        Me.lbltotal2.TabIndex = 149
        Me.lbltotal2.Text = "0"
        Me.lbltotal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(196, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 37)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(196, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 37)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(0, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 37)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "Bank"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(0, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 37)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "Total"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(12, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(124, 41)
        Me.RadioButton1.TabIndex = 194
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "CASH"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn200)
        Me.GroupBox1.Controls.Add(Me.btn500)
        Me.GroupBox1.Controls.Add(Me.btn1000)
        Me.GroupBox1.Controls.Add(Me.btn2000)
        Me.GroupBox1.Controls.Add(Me.btn5000)
        Me.GroupBox1.Controls.Add(Me.btn10000)
        Me.GroupBox1.Controls.Add(Me.btn20000)
        Me.GroupBox1.Controls.Add(Me.btn50000)
        Me.GroupBox1.Controls.Add(Me.btn100000)
        Me.GroupBox1.Controls.Add(Me.lblkurang)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtbayar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbltotal)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(995, 184)
        Me.GroupBox1.TabIndex = 191
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CASH"
        '
        'btn200
        '
        Me.btn200.BackColor = System.Drawing.Color.Silver
        Me.btn200.FlatAppearance.BorderSize = 0
        Me.btn200.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn200.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn200.Location = New System.Drawing.Point(847, 125)
        Me.btn200.Name = "btn200"
        Me.btn200.Size = New System.Drawing.Size(140, 47)
        Me.btn200.TabIndex = 161
        Me.btn200.Text = "+ 200"
        Me.btn200.UseVisualStyleBackColor = False
        '
        'btn500
        '
        Me.btn500.BackColor = System.Drawing.Color.Silver
        Me.btn500.FlatAppearance.BorderSize = 0
        Me.btn500.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn500.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn500.Location = New System.Drawing.Point(847, 73)
        Me.btn500.Name = "btn500"
        Me.btn500.Size = New System.Drawing.Size(140, 47)
        Me.btn500.TabIndex = 160
        Me.btn500.Text = "+ 500"
        Me.btn500.UseVisualStyleBackColor = False
        '
        'btn1000
        '
        Me.btn1000.BackColor = System.Drawing.Color.Silver
        Me.btn1000.FlatAppearance.BorderSize = 0
        Me.btn1000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1000.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1000.Location = New System.Drawing.Point(847, 20)
        Me.btn1000.Name = "btn1000"
        Me.btn1000.Size = New System.Drawing.Size(140, 47)
        Me.btn1000.TabIndex = 159
        Me.btn1000.Text = "+ 1.000"
        Me.btn1000.UseVisualStyleBackColor = False
        '
        'btn2000
        '
        Me.btn2000.BackColor = System.Drawing.Color.Silver
        Me.btn2000.FlatAppearance.BorderSize = 0
        Me.btn2000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2000.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2000.Location = New System.Drawing.Point(701, 125)
        Me.btn2000.Name = "btn2000"
        Me.btn2000.Size = New System.Drawing.Size(140, 47)
        Me.btn2000.TabIndex = 158
        Me.btn2000.Text = "+ 2.000"
        Me.btn2000.UseVisualStyleBackColor = False
        '
        'btn5000
        '
        Me.btn5000.BackColor = System.Drawing.Color.Silver
        Me.btn5000.FlatAppearance.BorderSize = 0
        Me.btn5000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn5000.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5000.Location = New System.Drawing.Point(701, 73)
        Me.btn5000.Name = "btn5000"
        Me.btn5000.Size = New System.Drawing.Size(140, 47)
        Me.btn5000.TabIndex = 157
        Me.btn5000.Text = "+ 5.000"
        Me.btn5000.UseVisualStyleBackColor = False
        '
        'btn10000
        '
        Me.btn10000.BackColor = System.Drawing.Color.Silver
        Me.btn10000.FlatAppearance.BorderSize = 0
        Me.btn10000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn10000.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn10000.Location = New System.Drawing.Point(701, 20)
        Me.btn10000.Name = "btn10000"
        Me.btn10000.Size = New System.Drawing.Size(140, 47)
        Me.btn10000.TabIndex = 156
        Me.btn10000.Text = "+ 10.000"
        Me.btn10000.UseVisualStyleBackColor = False
        '
        'btn20000
        '
        Me.btn20000.BackColor = System.Drawing.Color.Silver
        Me.btn20000.FlatAppearance.BorderSize = 0
        Me.btn20000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn20000.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn20000.Location = New System.Drawing.Point(555, 125)
        Me.btn20000.Name = "btn20000"
        Me.btn20000.Size = New System.Drawing.Size(140, 47)
        Me.btn20000.TabIndex = 155
        Me.btn20000.Text = "+ 20.000"
        Me.btn20000.UseVisualStyleBackColor = False
        '
        'btn50000
        '
        Me.btn50000.BackColor = System.Drawing.Color.Silver
        Me.btn50000.FlatAppearance.BorderSize = 0
        Me.btn50000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn50000.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn50000.Location = New System.Drawing.Point(555, 73)
        Me.btn50000.Name = "btn50000"
        Me.btn50000.Size = New System.Drawing.Size(140, 47)
        Me.btn50000.TabIndex = 154
        Me.btn50000.Text = "+ 50.000"
        Me.btn50000.UseVisualStyleBackColor = False
        '
        'btn100000
        '
        Me.btn100000.BackColor = System.Drawing.Color.Silver
        Me.btn100000.FlatAppearance.BorderSize = 0
        Me.btn100000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn100000.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn100000.Location = New System.Drawing.Point(555, 20)
        Me.btn100000.Name = "btn100000"
        Me.btn100000.Size = New System.Drawing.Size(140, 47)
        Me.btn100000.TabIndex = 153
        Me.btn100000.Text = "+ 100.000"
        Me.btn100000.UseVisualStyleBackColor = False
        '
        'lblkurang
        '
        Me.lblkurang.BackColor = System.Drawing.Color.Transparent
        Me.lblkurang.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblkurang.ForeColor = System.Drawing.Color.Black
        Me.lblkurang.Location = New System.Drawing.Point(243, 132)
        Me.lblkurang.Name = "lblkurang"
        Me.lblkurang.Size = New System.Drawing.Size(279, 44)
        Me.lblkurang.TabIndex = 152
        Me.lblkurang.Text = "0"
        Me.lblkurang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(196, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 37)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(0, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 37)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = "Kembalian"
        '
        'txtbayar
        '
        Me.txtbayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbayar.Location = New System.Drawing.Point(243, 81)
        Me.txtbayar.MaxLength = 20
        Me.txtbayar.Name = "txtbayar"
        Me.txtbayar.Size = New System.Drawing.Size(279, 44)
        Me.txtbayar.TabIndex = 1
        Me.txtbayar.Text = "0"
        Me.txtbayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(196, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 37)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(0, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 37)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Bayar"
        '
        'lbltotal
        '
        Me.lbltotal.BackColor = System.Drawing.Color.Transparent
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.Black
        Me.lbltotal.Location = New System.Drawing.Point(243, 24)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(279, 44)
        Me.lbltotal.TabIndex = 146
        Me.lbltotal.Text = "0"
        Me.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(196, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 37)
        Me.Label14.TabIndex = 145
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(0, 28)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 37)
        Me.Label15.TabIndex = 144
        Me.Label15.Text = "Total"
        '
        'btnProses
        '
        Me.btnProses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnProses.BorderRadius = 20
        Me.btnProses.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnProses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnProses.FillColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.btnProses.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProses.ForeColor = System.Drawing.Color.Black
        Me.btnProses.Location = New System.Drawing.Point(567, 425)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.ShadowDecoration.Shadow = New System.Windows.Forms.Padding(15)
        Me.btnProses.Size = New System.Drawing.Size(440, 59)
        Me.btnProses.TabIndex = 254
        Me.btnProses.Text = "PROSES (F2)"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BorderRadius = 12
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClose.FillColor = System.Drawing.Color.Black
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(567, 490)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(440, 43)
        Me.btnClose.TabIndex = 253
        Me.btnClose.Text = "TUTUP (ESC)"
        '
        'lblTotalAsli
        '
        Me.lblTotalAsli.AutoSize = True
        Me.lblTotalAsli.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAsli.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAsli.ForeColor = System.Drawing.Color.Black
        Me.lblTotalAsli.Location = New System.Drawing.Point(378, 276)
        Me.lblTotalAsli.Name = "lblTotalAsli"
        Me.lblTotalAsli.Size = New System.Drawing.Size(35, 37)
        Me.lblTotalAsli.TabIndex = 255
        Me.lblTotalAsli.Text = "0"
        Me.lblTotalAsli.Visible = False
        '
        'frmPenjualanPembayaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 542)
        Me.Controls.Add(Me.lblTotalAsli)
        Me.Controls.Add(Me.btnProses)
        Me.Controls.Add(Me.gbdiskon)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cbdiskon)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPenjualanPembayaran"
        Me.Text = ".: Pembayaran"
        Me.gbdiskon.ResumeLayout(False)
        Me.gbdiskon.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbdiskon As GroupBox
    Friend WithEvents txtdiskonpersen As TextBox
    Friend WithEvents txtdiskonrupiah As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cbdiskon As CheckBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbbank As ComboBox
    Friend WithEvents txtnoedc As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lbltotal2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn200 As Button
    Friend WithEvents btn500 As Button
    Friend WithEvents btn1000 As Button
    Friend WithEvents btn2000 As Button
    Friend WithEvents btn5000 As Button
    Friend WithEvents btn10000 As Button
    Friend WithEvents btn20000 As Button
    Friend WithEvents btn50000 As Button
    Friend WithEvents btn100000 As Button
    Friend WithEvents lblkurang As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtbayar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbltotal As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents btnProses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTotalAsli As Label
End Class
