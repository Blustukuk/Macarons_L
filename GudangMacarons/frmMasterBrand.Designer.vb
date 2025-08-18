<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterBrand
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterBrand))
        Me.btncari = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvtemp = New System.Windows.Forms.DataGridView()
        Me.cbautokode = New System.Windows.Forms.CheckBox()
        Me.txtkode = New System.Windows.Forms.TextBox()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblkelompokid = New System.Windows.Forms.Label()
        Me.lblproses = New System.Windows.Forms.Label()
        Me.cball = New System.Windows.Forms.CheckBox()
        Me.btnclear = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.chkbaktif = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvtemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btncari
        '
        Me.btncari.BackColor = System.Drawing.Color.Black
        Me.btncari.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncari.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncari.ForeColor = System.Drawing.Color.White
        Me.btncari.Location = New System.Drawing.Point(488, 6)
        Me.btncari.Name = "btncari"
        Me.btncari.Size = New System.Drawing.Size(92, 32)
        Me.btncari.TabIndex = 2
        Me.btncari.Text = "Cari"
        Me.btncari.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(61, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 24)
        Me.Label5.TabIndex = 129
        Me.Label5.Text = ":"
        '
        'txtcari
        '
        Me.txtcari.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcari.Location = New System.Drawing.Point(82, 7)
        Me.txtcari.MaxLength = 20
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(400, 29)
        Me.txtcari.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 24)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Cari"
        '
        'dgvtemp
        '
        Me.dgvtemp.AllowUserToAddRows = False
        Me.dgvtemp.AllowUserToDeleteRows = False
        Me.dgvtemp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvtemp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvtemp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtemp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvtemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvtemp.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvtemp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvtemp.Location = New System.Drawing.Point(12, 42)
        Me.dgvtemp.MultiSelect = False
        Me.dgvtemp.Name = "dgvtemp"
        Me.dgvtemp.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtemp.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvtemp.Size = New System.Drawing.Size(568, 575)
        Me.dgvtemp.TabIndex = 127
        '
        'cbautokode
        '
        Me.cbautokode.AutoSize = True
        Me.cbautokode.Checked = True
        Me.cbautokode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbautokode.Enabled = False
        Me.cbautokode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbautokode.Location = New System.Drawing.Point(850, 43)
        Me.cbautokode.Name = "cbautokode"
        Me.cbautokode.Size = New System.Drawing.Size(68, 28)
        Me.cbautokode.TabIndex = 142
        Me.cbautokode.Text = "Auto"
        Me.cbautokode.UseVisualStyleBackColor = True
        '
        'txtkode
        '
        Me.txtkode.Enabled = False
        Me.txtkode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkode.Location = New System.Drawing.Point(759, 42)
        Me.txtkode.MaxLength = 10
        Me.txtkode.Name = "txtkode"
        Me.txtkode.Size = New System.Drawing.Size(85, 29)
        Me.txtkode.TabIndex = 136
        '
        'txtBrand
        '
        Me.txtBrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrand.Location = New System.Drawing.Point(759, 77)
        Me.txtBrand.MaxLength = 100
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(356, 29)
        Me.txtBrand.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(738, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 24)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(738, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 24)
        Me.Label8.TabIndex = 141
        Me.Label8.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(598, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 24)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Kode"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(598, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 24)
        Me.Label7.TabIndex = 139
        Me.Label7.Text = "Brand"
        '
        'lblkelompokid
        '
        Me.lblkelompokid.AutoSize = True
        Me.lblkelompokid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblkelompokid.Location = New System.Drawing.Point(679, 310)
        Me.lblkelompokid.Name = "lblkelompokid"
        Me.lblkelompokid.Size = New System.Drawing.Size(13, 13)
        Me.lblkelompokid.TabIndex = 149
        Me.lblkelompokid.Text = "0"
        Me.lblkelompokid.Visible = False
        '
        'lblproses
        '
        Me.lblproses.AutoSize = True
        Me.lblproses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproses.Location = New System.Drawing.Point(679, 330)
        Me.lblproses.Name = "lblproses"
        Me.lblproses.Size = New System.Drawing.Size(13, 13)
        Me.lblproses.TabIndex = 148
        Me.lblproses.Text = "0"
        Me.lblproses.Visible = False
        '
        'cball
        '
        Me.cball.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cball.AutoSize = True
        Me.cball.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cball.Location = New System.Drawing.Point(685, 400)
        Me.cball.Name = "cball"
        Me.cball.Size = New System.Drawing.Size(203, 29)
        Me.cball.TabIndex = 5
        Me.cball.Text = "Tampilkan Semua"
        Me.cball.UseVisualStyleBackColor = True
        '
        'btnclear
        '
        Me.btnclear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnclear.BackColor = System.Drawing.Color.Black
        Me.btnclear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnclear.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclear.ForeColor = System.Drawing.Color.White
        Me.btnclear.Location = New System.Drawing.Point(1083, 451)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(84, 80)
        Me.btnclear.TabIndex = 8
        Me.btnclear.Text = "C"
        Me.btnclear.UseVisualStyleBackColor = False
        '
        'btnclose
        '
        Me.btnclose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnclose.BackColor = System.Drawing.Color.Black
        Me.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.Red
        Me.btnclose.Location = New System.Drawing.Point(1083, 537)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(225, 80)
        Me.btnclose.TabIndex = 9
        Me.btnclose.Text = "Tutup"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'btntambah
        '
        Me.btntambah.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btntambah.BackColor = System.Drawing.Color.Black
        Me.btntambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntambah.ForeColor = System.Drawing.Color.White
        Me.btntambah.Location = New System.Drawing.Point(684, 451)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(225, 80)
        Me.btntambah.TabIndex = 6
        Me.btntambah.Text = "Tambah"
        Me.btntambah.UseVisualStyleBackColor = False
        '
        'btnedit
        '
        Me.btnedit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnedit.BackColor = System.Drawing.Color.Black
        Me.btnedit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.ForeColor = System.Drawing.Color.White
        Me.btnedit.Location = New System.Drawing.Point(684, 537)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(225, 80)
        Me.btnedit.TabIndex = 7
        Me.btnedit.Text = "Update"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'chkbaktif
        '
        Me.chkbaktif.AutoSize = True
        Me.chkbaktif.Checked = True
        Me.chkbaktif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkbaktif.Location = New System.Drawing.Point(759, 127)
        Me.chkbaktif.Name = "chkbaktif"
        Me.chkbaktif.Size = New System.Drawing.Size(15, 14)
        Me.chkbaktif.TabIndex = 4
        Me.chkbaktif.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(738, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 24)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(598, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 24)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "Aktif"
        '
        'frmMasterBrand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnclose
        Me.ClientSize = New System.Drawing.Size(1318, 629)
        Me.Controls.Add(Me.chkbaktif)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblkelompokid)
        Me.Controls.Add(Me.lblproses)
        Me.Controls.Add(Me.cball)
        Me.Controls.Add(Me.btnclear)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btntambah)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.cbautokode)
        Me.Controls.Add(Me.txtkode)
        Me.Controls.Add(Me.txtBrand)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btncari)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvtemp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMasterBrand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Master Brand"
        CType(Me.dgvtemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btncari As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtcari As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvtemp As DataGridView
    Friend WithEvents cbautokode As CheckBox
    Friend WithEvents txtkode As TextBox
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblkelompokid As Label
    Friend WithEvents lblproses As Label
    Friend WithEvents cball As CheckBox
    Friend WithEvents btnclear As Button
    Friend WithEvents btnclose As Button
    Friend WithEvents btntambah As Button
    Friend WithEvents btnedit As Button
    Friend WithEvents chkbaktif As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
End Class
