<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDelData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDelData))
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelPembelian = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelCetakBarcode = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
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
        Me.btnClose.Location = New System.Drawing.Point(12, 135)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(376, 45)
        Me.btnClose.TabIndex = 223
        Me.btnClose.Text = "TUTUP (ESC)"
        '
        'btnDelPembelian
        '
        Me.btnDelPembelian.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelPembelian.BorderRadius = 12
        Me.btnDelPembelian.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDelPembelian.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelPembelian.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelPembelian.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelPembelian.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelPembelian.FillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnDelPembelian.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelPembelian.ForeColor = System.Drawing.Color.Black
        Me.btnDelPembelian.Location = New System.Drawing.Point(12, 12)
        Me.btnDelPembelian.Name = "btnDelPembelian"
        Me.btnDelPembelian.Size = New System.Drawing.Size(376, 45)
        Me.btnDelPembelian.TabIndex = 223
        Me.btnDelPembelian.Text = "DELETE DATA PEMBELIAN"
        '
        'btnDelCetakBarcode
        '
        Me.btnDelCetakBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelCetakBarcode.BorderRadius = 12
        Me.btnDelCetakBarcode.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDelCetakBarcode.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelCetakBarcode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelCetakBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelCetakBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelCetakBarcode.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.btnDelCetakBarcode.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelCetakBarcode.ForeColor = System.Drawing.Color.Black
        Me.btnDelCetakBarcode.Location = New System.Drawing.Point(13, 63)
        Me.btnDelCetakBarcode.Name = "btnDelCetakBarcode"
        Me.btnDelCetakBarcode.Size = New System.Drawing.Size(376, 45)
        Me.btnDelCetakBarcode.TabIndex = 223
        Me.btnDelCetakBarcode.Text = "DELETE DATA CETAK BARCODE"
        '
        'frmDelData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(401, 192)
        Me.Controls.Add(Me.btnDelCetakBarcode)
        Me.Controls.Add(Me.btnDelPembelian)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDelData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Delete Data"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelPembelian As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelCetakBarcode As Guna.UI2.WinForms.Guna2Button
End Class
