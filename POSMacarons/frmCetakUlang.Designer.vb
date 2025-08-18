<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCetakUlang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCetakUlang))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.btnNotaRetur = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNotaPenjualan = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'btnNotaRetur
        '
        Me.btnNotaRetur.BorderRadius = 10
        Me.btnNotaRetur.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnNotaRetur.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnNotaRetur.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnNotaRetur.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnNotaRetur.FillColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.btnNotaRetur.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotaRetur.ForeColor = System.Drawing.Color.Black
        Me.btnNotaRetur.Location = New System.Drawing.Point(12, 72)
        Me.btnNotaRetur.Name = "btnNotaRetur"
        Me.btnNotaRetur.Size = New System.Drawing.Size(376, 54)
        Me.btnNotaRetur.TabIndex = 1
        Me.btnNotaRetur.Text = "NOTA RETUR (F2)"
        '
        'btnNotaPenjualan
        '
        Me.btnNotaPenjualan.BorderRadius = 10
        Me.btnNotaPenjualan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnNotaPenjualan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnNotaPenjualan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnNotaPenjualan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnNotaPenjualan.FillColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.btnNotaPenjualan.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotaPenjualan.ForeColor = System.Drawing.Color.Black
        Me.btnNotaPenjualan.Location = New System.Drawing.Point(12, 12)
        Me.btnNotaPenjualan.Name = "btnNotaPenjualan"
        Me.btnNotaPenjualan.Size = New System.Drawing.Size(376, 54)
        Me.btnNotaPenjualan.TabIndex = 2
        Me.btnNotaPenjualan.Text = "NOTA PENJUALAN (F1)"
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
        Me.btnClose.Location = New System.Drawing.Point(13, 151)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(377, 58)
        Me.btnClose.TabIndex = 255
        Me.btnClose.Text = "TUTUP (ESC)"
        '
        'frmCetakUlang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(402, 221)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNotaRetur)
        Me.Controls.Add(Me.btnNotaPenjualan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCetakUlang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Cetak Ulang"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents btnNotaRetur As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNotaPenjualan As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
End Class
