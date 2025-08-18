<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReturPenjualan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReturPenjualan))
        Me.btnCariNoNota = New Guna.UI2.WinForms.Guna2Button()
        Me.btnKodeOK = New Guna.UI2.WinForms.Guna2Button()
        Me.lblpengadaanid = New System.Windows.Forms.Label()
        Me.lblproses = New System.Windows.Forms.Label()
        Me.panahkiri = New System.Windows.Forms.PictureBox()
        Me.panahkanan = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbReturTemp = New System.Windows.Forms.ListBox()
        Me.lbListItem = New System.Windows.Forms.ListBox()
        Me.btnProses = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTutup = New Guna.UI2.WinForms.Guna2Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtcarisj = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.panahkiri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panahkanan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnCariNoNota.TabIndex = 310
        Me.btnCariNoNota.Visible = False
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
        Me.btnKodeOK.TabIndex = 309
        Me.btnKodeOK.Visible = False
        '
        'lblpengadaanid
        '
        Me.lblpengadaanid.AutoSize = True
        Me.lblpengadaanid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpengadaanid.Location = New System.Drawing.Point(723, 360)
        Me.lblpengadaanid.Name = "lblpengadaanid"
        Me.lblpengadaanid.Size = New System.Drawing.Size(13, 13)
        Me.lblpengadaanid.TabIndex = 308
        Me.lblpengadaanid.Text = "0"
        Me.lblpengadaanid.Visible = False
        '
        'lblproses
        '
        Me.lblproses.AutoSize = True
        Me.lblproses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproses.Location = New System.Drawing.Point(723, 380)
        Me.lblproses.Name = "lblproses"
        Me.lblproses.Size = New System.Drawing.Size(13, 13)
        Me.lblproses.TabIndex = 307
        Me.lblproses.Text = "0"
        Me.lblproses.Visible = False
        '
        'panahkiri
        '
        Me.panahkiri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panahkiri.Image = CType(resources.GetObject("panahkiri.Image"), System.Drawing.Image)
        Me.panahkiri.Location = New System.Drawing.Point(708, 397)
        Me.panahkiri.Name = "panahkiri"
        Me.panahkiri.Size = New System.Drawing.Size(277, 77)
        Me.panahkiri.TabIndex = 306
        Me.panahkiri.TabStop = False
        '
        'panahkanan
        '
        Me.panahkanan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panahkanan.Image = CType(resources.GetObject("panahkanan.Image"), System.Drawing.Image)
        Me.panahkanan.Location = New System.Drawing.Point(708, 278)
        Me.panahkanan.Name = "panahkanan"
        Me.panahkanan.Size = New System.Drawing.Size(277, 77)
        Me.panahkanan.TabIndex = 305
        Me.panahkanan.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(1003, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 24)
        Me.Label12.TabIndex = 304
        Me.Label12.Text = "Daftar Retur"
        '
        'lbReturTemp
        '
        Me.lbReturTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbReturTemp.FormattingEnabled = True
        Me.lbReturTemp.ItemHeight = 24
        Me.lbReturTemp.Location = New System.Drawing.Point(1007, 81)
        Me.lbReturTemp.Name = "lbReturTemp"
        Me.lbReturTemp.Size = New System.Drawing.Size(670, 556)
        Me.lbReturTemp.TabIndex = 297
        '
        'lbListItem
        '
        Me.lbListItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbListItem.FormattingEnabled = True
        Me.lbListItem.ItemHeight = 24
        Me.lbListItem.Location = New System.Drawing.Point(16, 79)
        Me.lbListItem.Name = "lbListItem"
        Me.lbListItem.Size = New System.Drawing.Size(670, 556)
        Me.lbListItem.TabIndex = 296
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
        Me.btnProses.Location = New System.Drawing.Point(1007, 654)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(670, 82)
        Me.btnProses.TabIndex = 298
        Me.btnProses.Text = "PROSES (F1)"
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
        Me.btnTutup.Size = New System.Drawing.Size(670, 82)
        Me.btnTutup.TabIndex = 303
        Me.btnTutup.Text = "TUTUP (ESC)"
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
        Me.Label2.TabIndex = 301
        Me.Label2.Text = ":"
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
        Me.Label5.TabIndex = 302
        Me.Label5.Text = ":"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(112, 44)
        Me.txtBarcode.MaxLength = 50
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(404, 29)
        Me.txtBarcode.TabIndex = 295
        '
        'txtcarisj
        '
        Me.txtcarisj.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcarisj.Location = New System.Drawing.Point(112, 6)
        Me.txtcarisj.MaxLength = 50
        Me.txtcarisj.Name = "txtcarisj"
        Me.txtcarisj.Size = New System.Drawing.Size(404, 29)
        Me.txtcarisj.TabIndex = 294
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
        Me.Label1.TabIndex = 299
        Me.Label1.Text = "Barcode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 24)
        Me.Label4.TabIndex = 300
        Me.Label4.Text = "No. SJ"
        '
        'frmReturPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnTutup
        Me.ClientSize = New System.Drawing.Size(1689, 746)
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
        Me.Controls.Add(Me.txtcarisj)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReturPenjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Retur Penjualan"
        CType(Me.panahkiri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panahkanan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCariNoNota As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnKodeOK As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblpengadaanid As Label
    Friend WithEvents lblproses As Label
    Friend WithEvents panahkiri As PictureBox
    Friend WithEvents panahkanan As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lbReturTemp As ListBox
    Friend WithEvents lbListItem As ListBox
    Friend WithEvents btnProses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTutup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtcarisj As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
End Class
