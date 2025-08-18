<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBayar
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBayar))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
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
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1007, 292)
        Me.GroupBox1.TabIndex = 185
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Curlz MT", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(121, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 39)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "Solutions"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("NewsGoth Cn BT", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(112, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 45)
        Me.Label6.TabIndex = 201
        Me.Label6.Text = "Macarons"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.POSMacarons.My.Resources.Resources.logo2
        Me.PictureBox1.Location = New System.Drawing.Point(7, 188)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 93)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 199
        Me.PictureBox1.TabStop = False
        '
        'btn200
        '
        Me.btn200.BackColor = System.Drawing.Color.Silver
        Me.btn200.FlatAppearance.BorderSize = 0
        Me.btn200.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn200.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn200.Location = New System.Drawing.Point(851, 199)
        Me.btn200.Name = "btn200"
        Me.btn200.Size = New System.Drawing.Size(144, 82)
        Me.btn200.TabIndex = 161
        Me.btn200.Text = "+ 200"
        Me.btn200.UseVisualStyleBackColor = False
        '
        'btn500
        '
        Me.btn500.BackColor = System.Drawing.Color.Silver
        Me.btn500.FlatAppearance.BorderSize = 0
        Me.btn500.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn500.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn500.Location = New System.Drawing.Point(851, 111)
        Me.btn500.Name = "btn500"
        Me.btn500.Size = New System.Drawing.Size(144, 82)
        Me.btn500.TabIndex = 160
        Me.btn500.Text = "+ 500"
        Me.btn500.UseVisualStyleBackColor = False
        '
        'btn1000
        '
        Me.btn1000.BackColor = System.Drawing.Color.Silver
        Me.btn1000.FlatAppearance.BorderSize = 0
        Me.btn1000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1000.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1000.Location = New System.Drawing.Point(851, 23)
        Me.btn1000.Name = "btn1000"
        Me.btn1000.Size = New System.Drawing.Size(144, 82)
        Me.btn1000.TabIndex = 159
        Me.btn1000.Text = "+ 1.000"
        Me.btn1000.UseVisualStyleBackColor = False
        '
        'btn2000
        '
        Me.btn2000.BackColor = System.Drawing.Color.Silver
        Me.btn2000.FlatAppearance.BorderSize = 0
        Me.btn2000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2000.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2000.Location = New System.Drawing.Point(701, 199)
        Me.btn2000.Name = "btn2000"
        Me.btn2000.Size = New System.Drawing.Size(144, 82)
        Me.btn2000.TabIndex = 158
        Me.btn2000.Text = "+ 2.000"
        Me.btn2000.UseVisualStyleBackColor = False
        '
        'btn5000
        '
        Me.btn5000.BackColor = System.Drawing.Color.Silver
        Me.btn5000.FlatAppearance.BorderSize = 0
        Me.btn5000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn5000.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5000.Location = New System.Drawing.Point(701, 111)
        Me.btn5000.Name = "btn5000"
        Me.btn5000.Size = New System.Drawing.Size(144, 82)
        Me.btn5000.TabIndex = 157
        Me.btn5000.Text = "+ 5.000"
        Me.btn5000.UseVisualStyleBackColor = False
        '
        'btn10000
        '
        Me.btn10000.BackColor = System.Drawing.Color.Silver
        Me.btn10000.FlatAppearance.BorderSize = 0
        Me.btn10000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn10000.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn10000.Location = New System.Drawing.Point(701, 23)
        Me.btn10000.Name = "btn10000"
        Me.btn10000.Size = New System.Drawing.Size(144, 82)
        Me.btn10000.TabIndex = 156
        Me.btn10000.Text = "+ 10.000"
        Me.btn10000.UseVisualStyleBackColor = False
        '
        'btn20000
        '
        Me.btn20000.BackColor = System.Drawing.Color.Silver
        Me.btn20000.FlatAppearance.BorderSize = 0
        Me.btn20000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn20000.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn20000.Location = New System.Drawing.Point(551, 199)
        Me.btn20000.Name = "btn20000"
        Me.btn20000.Size = New System.Drawing.Size(144, 82)
        Me.btn20000.TabIndex = 155
        Me.btn20000.Text = "+ 20.000"
        Me.btn20000.UseVisualStyleBackColor = False
        '
        'btn50000
        '
        Me.btn50000.BackColor = System.Drawing.Color.Silver
        Me.btn50000.FlatAppearance.BorderSize = 0
        Me.btn50000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn50000.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn50000.Location = New System.Drawing.Point(551, 111)
        Me.btn50000.Name = "btn50000"
        Me.btn50000.Size = New System.Drawing.Size(144, 82)
        Me.btn50000.TabIndex = 154
        Me.btn50000.Text = "+ 50.000"
        Me.btn50000.UseVisualStyleBackColor = False
        '
        'btn100000
        '
        Me.btn100000.BackColor = System.Drawing.Color.Silver
        Me.btn100000.FlatAppearance.BorderSize = 0
        Me.btn100000.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn100000.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn100000.Location = New System.Drawing.Point(551, 23)
        Me.btn100000.Name = "btn100000"
        Me.btn100000.Size = New System.Drawing.Size(144, 82)
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
        Me.btnProses.BorderRadius = 10
        Me.btnProses.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnProses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnProses.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnProses.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProses.ForeColor = System.Drawing.Color.Black
        Me.btnProses.Location = New System.Drawing.Point(713, 310)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(294, 82)
        Me.btnProses.TabIndex = 228
        Me.btnProses.Text = "PROSES (F1)"
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BorderRadius = 10
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.FillColor = System.Drawing.Color.Black
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button1.ForeColor = System.Drawing.Color.Red
        Me.Guna2Button1.Location = New System.Drawing.Point(12, 310)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(294, 82)
        Me.Guna2Button1.TabIndex = 229
        Me.Guna2Button1.Text = "BATAL (ESC)"
        '
        'frmBayar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1034, 409)
        Me.Controls.Add(Me.Guna2Button1)
        Me.Controls.Add(Me.btnProses)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBayar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Bayar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
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
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnProses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
End Class
