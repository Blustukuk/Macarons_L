<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCetakBarcodeManual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCetakBarcodeManual))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.lblproses = New System.Windows.Forms.Label()
        Me.panelBarcode = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxBarcode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCariBarcode = New System.Windows.Forms.TextBox()
        Me.txtJml = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbNota = New System.Windows.Forms.RadioButton()
        Me.rbBarcode = New System.Windows.Forms.RadioButton()
        Me.panelNota = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxNota = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCariNota = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnprint = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbModeBarcode = New System.Windows.Forms.RadioButton()
        Me.rbModeQRcode = New System.Windows.Forms.RadioButton()
        Me.panelBarcode.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panelNota.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.ResizeForm = False
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
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
        Me.btnClose.Location = New System.Drawing.Point(16, 466)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(659, 45)
        Me.btnClose.TabIndex = 201
        Me.btnClose.Text = "TUTUP (ESC)"
        '
        'lblproses
        '
        Me.lblproses.AutoSize = True
        Me.lblproses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproses.Location = New System.Drawing.Point(84, 117)
        Me.lblproses.Name = "lblproses"
        Me.lblproses.Size = New System.Drawing.Size(13, 13)
        Me.lblproses.TabIndex = 206
        Me.lblproses.Text = "0"
        Me.lblproses.Visible = False
        '
        'panelBarcode
        '
        Me.panelBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelBarcode.Controls.Add(Me.Label1)
        Me.panelBarcode.Controls.Add(Me.cbxBarcode)
        Me.panelBarcode.Controls.Add(Me.Label4)
        Me.panelBarcode.Controls.Add(Me.txtCariBarcode)
        Me.panelBarcode.Controls.Add(Me.txtJml)
        Me.panelBarcode.Controls.Add(Me.Label5)
        Me.panelBarcode.Controls.Add(Me.Label2)
        Me.panelBarcode.Controls.Add(Me.Label3)
        Me.panelBarcode.Controls.Add(Me.Label16)
        Me.panelBarcode.Location = New System.Drawing.Point(3, 76)
        Me.panelBarcode.Name = "panelBarcode"
        Me.panelBarcode.Size = New System.Drawing.Size(685, 127)
        Me.panelBarcode.TabIndex = 210
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 24)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Barcode"
        '
        'cbxBarcode
        '
        Me.cbxBarcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxBarcode.FormattingEnabled = True
        Me.cbxBarcode.Location = New System.Drawing.Point(146, 49)
        Me.cbxBarcode.Name = "cbxBarcode"
        Me.cbxBarcode.Size = New System.Drawing.Size(531, 32)
        Me.cbxBarcode.TabIndex = 213
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(125, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 24)
        Me.Label4.TabIndex = 215
        Me.Label4.Text = ":"
        '
        'txtCariBarcode
        '
        Me.txtCariBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCariBarcode.Location = New System.Drawing.Point(146, 8)
        Me.txtCariBarcode.Name = "txtCariBarcode"
        Me.txtCariBarcode.Size = New System.Drawing.Size(531, 29)
        Me.txtCariBarcode.TabIndex = 210
        '
        'txtJml
        '
        Me.txtJml.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJml.Location = New System.Drawing.Point(146, 87)
        Me.txtJml.Name = "txtJml"
        Me.txtJml.Size = New System.Drawing.Size(102, 29)
        Me.txtJml.TabIndex = 210
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(125, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 24)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(125, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 24)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 24)
        Me.Label3.TabIndex = 211
        Me.Label3.Text = "Cari"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(14, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 24)
        Me.Label16.TabIndex = 211
        Me.Label16.Text = "Jumlah"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.rbNota)
        Me.Panel2.Controls.Add(Me.rbBarcode)
        Me.Panel2.Location = New System.Drawing.Point(3, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(304, 54)
        Me.Panel2.TabIndex = 212
        '
        'rbNota
        '
        Me.rbNota.AutoSize = True
        Me.rbNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNota.Location = New System.Drawing.Point(156, 12)
        Me.rbNota.Name = "rbNota"
        Me.rbNota.Size = New System.Drawing.Size(128, 28)
        Me.rbNota.TabIndex = 0
        Me.rbNota.Text = "By No. Nota"
        Me.rbNota.UseVisualStyleBackColor = True
        '
        'rbBarcode
        '
        Me.rbBarcode.AutoSize = True
        Me.rbBarcode.Checked = True
        Me.rbBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBarcode.Location = New System.Drawing.Point(9, 12)
        Me.rbBarcode.Name = "rbBarcode"
        Me.rbBarcode.Size = New System.Drawing.Size(100, 28)
        Me.rbBarcode.TabIndex = 0
        Me.rbBarcode.TabStop = True
        Me.rbBarcode.Text = "By Code"
        Me.rbBarcode.UseVisualStyleBackColor = True
        '
        'panelNota
        '
        Me.panelNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelNota.Controls.Add(Me.Label6)
        Me.panelNota.Controls.Add(Me.cbxNota)
        Me.panelNota.Controls.Add(Me.Label7)
        Me.panelNota.Controls.Add(Me.txtCariNota)
        Me.panelNota.Controls.Add(Me.Label8)
        Me.panelNota.Controls.Add(Me.Label10)
        Me.panelNota.Location = New System.Drawing.Point(3, 215)
        Me.panelNota.Name = "panelNota"
        Me.panelNota.Size = New System.Drawing.Size(685, 96)
        Me.panelNota.TabIndex = 213
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(14, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 24)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "No. Nota"
        '
        'cbxNota
        '
        Me.cbxNota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxNota.FormattingEnabled = True
        Me.cbxNota.Location = New System.Drawing.Point(146, 49)
        Me.cbxNota.Name = "cbxNota"
        Me.cbxNota.Size = New System.Drawing.Size(531, 32)
        Me.cbxNota.TabIndex = 213
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(125, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 24)
        Me.Label7.TabIndex = 215
        Me.Label7.Text = ":"
        '
        'txtCariNota
        '
        Me.txtCariNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCariNota.Location = New System.Drawing.Point(146, 8)
        Me.txtCariNota.Name = "txtCariNota"
        Me.txtCariNota.Size = New System.Drawing.Size(531, 29)
        Me.txtCariNota.TabIndex = 210
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(125, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 24)
        Me.Label8.TabIndex = 212
        Me.Label8.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(14, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 24)
        Me.Label10.TabIndex = 211
        Me.Label10.Text = "Cari"
        '
        'btnprint
        '
        Me.btnprint.BackgroundImage = Global.GudangMacarons.My.Resources.Resources.Printer_Barcode
        Me.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnprint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnprint.Location = New System.Drawing.Point(295, 359)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(100, 89)
        Me.btnprint.TabIndex = 202
        Me.btnprint.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbModeBarcode)
        Me.Panel1.Controls.Add(Me.rbModeQRcode)
        Me.Panel1.Location = New System.Drawing.Point(384, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(304, 54)
        Me.Panel1.TabIndex = 214
        '
        'rbModeBarcode
        '
        Me.rbModeBarcode.AutoSize = True
        Me.rbModeBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbModeBarcode.Location = New System.Drawing.Point(156, 12)
        Me.rbModeBarcode.Name = "rbModeBarcode"
        Me.rbModeBarcode.Size = New System.Drawing.Size(99, 28)
        Me.rbModeBarcode.TabIndex = 0
        Me.rbModeBarcode.Text = "Barcode"
        Me.rbModeBarcode.UseVisualStyleBackColor = True
        '
        'rbModeQRcode
        '
        Me.rbModeQRcode.AutoSize = True
        Me.rbModeQRcode.Checked = True
        Me.rbModeQRcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbModeQRcode.Location = New System.Drawing.Point(9, 12)
        Me.rbModeQRcode.Name = "rbModeQRcode"
        Me.rbModeQRcode.Size = New System.Drawing.Size(99, 28)
        Me.rbModeQRcode.TabIndex = 0
        Me.rbModeQRcode.TabStop = True
        Me.rbModeQRcode.Text = "QRcode"
        Me.rbModeQRcode.UseVisualStyleBackColor = True
        '
        'frmCetakBarcodeManual
        '
        Me.AcceptButton = Me.btnprint
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(691, 523)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelNota)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.panelBarcode)
        Me.Controls.Add(Me.lblproses)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCetakBarcodeManual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Cetak Barcode Manual"
        Me.panelBarcode.ResumeLayout(False)
        Me.panelBarcode.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panelNota.ResumeLayout(False)
        Me.panelNota.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents btnprint As Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblproses As Label
    Friend WithEvents panelBarcode As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxBarcode As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCariBarcode As TextBox
    Friend WithEvents txtJml As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelNota As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxNota As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCariNota As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents rbNota As RadioButton
    Friend WithEvents rbBarcode As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbModeBarcode As RadioButton
    Friend WithEvents rbModeQRcode As RadioButton
End Class
