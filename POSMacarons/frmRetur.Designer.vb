<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRetur))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcarinota = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnTutup = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lbListItem = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbReturTemp = New System.Windows.Forms.ListBox()
        Me.btnProses = New Guna.UI2.WinForms.Guna2Button()
        Me.panahkiri = New System.Windows.Forms.PictureBox()
        Me.panahkanan = New System.Windows.Forms.PictureBox()
        Me.lblpengadaanid = New System.Windows.Forms.Label()
        Me.lblproses = New System.Windows.Forms.Label()
        Me.btnKodeOK = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCariNoNota = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.panahkiri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panahkanan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(94, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 24)
        Me.Label5.TabIndex = 283
        Me.Label5.Text = ":"
        '
        'txtcarinota
        '
        Me.txtcarinota.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcarinota.Location = New System.Drawing.Point(112, 6)
        Me.txtcarinota.MaxLength = 50
        Me.txtcarinota.Name = "txtcarinota"
        Me.txtcarinota.Size = New System.Drawing.Size(325, 29)
        Me.txtcarinota.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 24)
        Me.Label4.TabIndex = 282
        Me.Label4.Text = "No. Nota"
        '
        'btnTutup
        '
        Me.btnTutup.BorderRadius = 10
        Me.btnTutup.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTutup.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTutup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTutup.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTutup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnTutup.FillColor = System.Drawing.Color.Black
        Me.btnTutup.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTutup.ForeColor = System.Drawing.Color.Red
        Me.btnTutup.Location = New System.Drawing.Point(12, 654)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(525, 82)
        Me.btnTutup.TabIndex = 285
        Me.btnTutup.Text = "TUTUP (ESC)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 24)
        Me.Label1.TabIndex = 282
        Me.Label1.Text = "Barcode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(94, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 24)
        Me.Label2.TabIndex = 283
        Me.Label2.Text = ":"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(112, 44)
        Me.txtBarcode.MaxLength = 50
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(325, 29)
        Me.txtBarcode.TabIndex = 2
        '
        'lbListItem
        '
        Me.lbListItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbListItem.FormattingEnabled = True
        Me.lbListItem.ItemHeight = 24
        Me.lbListItem.Location = New System.Drawing.Point(16, 79)
        Me.lbListItem.Name = "lbListItem"
        Me.lbListItem.Size = New System.Drawing.Size(521, 556)
        Me.lbListItem.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(821, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 24)
        Me.Label12.TabIndex = 288
        Me.Label12.Text = "Daftar Retur"
        '
        'lbReturTemp
        '
        Me.lbReturTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbReturTemp.FormattingEnabled = True
        Me.lbReturTemp.ItemHeight = 24
        Me.lbReturTemp.Location = New System.Drawing.Point(825, 79)
        Me.lbReturTemp.Name = "lbReturTemp"
        Me.lbReturTemp.Size = New System.Drawing.Size(521, 556)
        Me.lbReturTemp.TabIndex = 4
        '
        'btnProses
        '
        Me.btnProses.BorderRadius = 10
        Me.btnProses.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnProses.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnProses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnProses.FillColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.btnProses.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProses.ForeColor = System.Drawing.Color.Yellow
        Me.btnProses.Location = New System.Drawing.Point(821, 654)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(525, 82)
        Me.btnProses.TabIndex = 5
        Me.btnProses.Text = "PROSES (F1)"
        '
        'panahkiri
        '
        Me.panahkiri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panahkiri.Image = CType(resources.GetObject("panahkiri.Image"), System.Drawing.Image)
        Me.panahkiri.Location = New System.Drawing.Point(542, 380)
        Me.panahkiri.Name = "panahkiri"
        Me.panahkiri.Size = New System.Drawing.Size(277, 77)
        Me.panahkiri.TabIndex = 290
        Me.panahkiri.TabStop = False
        '
        'panahkanan
        '
        Me.panahkanan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panahkanan.Image = CType(resources.GetObject("panahkanan.Image"), System.Drawing.Image)
        Me.panahkanan.Location = New System.Drawing.Point(542, 261)
        Me.panahkanan.Name = "panahkanan"
        Me.panahkanan.Size = New System.Drawing.Size(277, 77)
        Me.panahkanan.TabIndex = 289
        Me.panahkanan.TabStop = False
        '
        'lblpengadaanid
        '
        Me.lblpengadaanid.AutoSize = True
        Me.lblpengadaanid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpengadaanid.Location = New System.Drawing.Point(675, 343)
        Me.lblpengadaanid.Name = "lblpengadaanid"
        Me.lblpengadaanid.Size = New System.Drawing.Size(13, 13)
        Me.lblpengadaanid.TabIndex = 292
        Me.lblpengadaanid.Text = "0"
        Me.lblpengadaanid.Visible = False
        '
        'lblproses
        '
        Me.lblproses.AutoSize = True
        Me.lblproses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproses.Location = New System.Drawing.Point(675, 363)
        Me.lblproses.Name = "lblproses"
        Me.lblproses.Size = New System.Drawing.Size(13, 13)
        Me.lblproses.TabIndex = 291
        Me.lblproses.Text = "0"
        Me.lblproses.Visible = False
        '
        'btnKodeOK
        '
        Me.btnKodeOK.BorderRadius = 10
        Me.btnKodeOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnKodeOK.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnKodeOK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnKodeOK.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnKodeOK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnKodeOK.FillColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.btnKodeOK.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKodeOK.ForeColor = System.Drawing.Color.Yellow
        Me.btnKodeOK.Location = New System.Drawing.Point(443, 48)
        Me.btnKodeOK.Name = "btnKodeOK"
        Me.btnKodeOK.Size = New System.Drawing.Size(17, 23)
        Me.btnKodeOK.TabIndex = 293
        Me.btnKodeOK.Visible = False
        '
        'btnCariNoNota
        '
        Me.btnCariNoNota.BorderRadius = 10
        Me.btnCariNoNota.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCariNoNota.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCariNoNota.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCariNoNota.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCariNoNota.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCariNoNota.FillColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.btnCariNoNota.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCariNoNota.ForeColor = System.Drawing.Color.Yellow
        Me.btnCariNoNota.Location = New System.Drawing.Point(443, 9)
        Me.btnCariNoNota.Name = "btnCariNoNota"
        Me.btnCariNoNota.Size = New System.Drawing.Size(17, 23)
        Me.btnCariNoNota.TabIndex = 293
        Me.btnCariNoNota.Visible = False
        '
        'frmRetur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnTutup
        Me.ClientSize = New System.Drawing.Size(1353, 748)
        Me.Controls.Add(Me.btnCariNoNota)
        Me.Controls.Add(Me.btnKodeOK)
        Me.Controls.Add(Me.lblpengadaanid)
        Me.Controls.Add(Me.lblproses)
        Me.Controls.Add(Me.panahkiri)
        Me.Controls.Add(Me.panahkanan)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lbReturTemp)
        Me.Controls.Add(Me.lbListItem)
        Me.Controls.Add(Me.btnProses)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.txtcarinota)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRetur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Retur"
        CType(Me.panahkiri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panahkanan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As Label
    Friend WithEvents txtcarinota As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnTutup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lbListItem As ListBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lbReturTemp As ListBox
    Friend WithEvents btnProses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents panahkiri As PictureBox
    Friend WithEvents panahkanan As PictureBox
    Friend WithEvents lblpengadaanid As Label
    Friend WithEvents lblproses As Label
    Friend WithEvents btnKodeOK As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCariNoNota As Guna.UI2.WinForms.Guna2Button
End Class
