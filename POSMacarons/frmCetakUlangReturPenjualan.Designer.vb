<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCetakUlangReturPenjualan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCetakUlangReturPenjualan))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelNota = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxRetur = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCariRetur = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2BorderlessForm2 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.lblProses = New System.Windows.Forms.Label()
        Me.btnprint = New System.Windows.Forms.Button()
        Me.panelNota.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'panelNota
        '
        Me.panelNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelNota.Controls.Add(Me.Label6)
        Me.panelNota.Controls.Add(Me.cbxRetur)
        Me.panelNota.Controls.Add(Me.Label7)
        Me.panelNota.Controls.Add(Me.txtCariRetur)
        Me.panelNota.Controls.Add(Me.Label8)
        Me.panelNota.Controls.Add(Me.Label10)
        Me.panelNota.Location = New System.Drawing.Point(12, 12)
        Me.panelNota.Name = "panelNota"
        Me.panelNota.Size = New System.Drawing.Size(685, 96)
        Me.panelNota.TabIndex = 220
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(14, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 24)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "No. Retur"
        '
        'cbxRetur
        '
        Me.cbxRetur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRetur.FormattingEnabled = True
        Me.cbxRetur.Location = New System.Drawing.Point(146, 49)
        Me.cbxRetur.Name = "cbxRetur"
        Me.cbxRetur.Size = New System.Drawing.Size(531, 32)
        Me.cbxRetur.TabIndex = 213
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
        'txtCariRetur
        '
        Me.txtCariRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCariRetur.Location = New System.Drawing.Point(146, 8)
        Me.txtCariRetur.Name = "txtCariRetur"
        Me.txtCariRetur.Size = New System.Drawing.Size(531, 29)
        Me.txtCariRetur.TabIndex = 210
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
        Me.btnClose.Location = New System.Drawing.Point(12, 263)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(685, 45)
        Me.btnClose.TabIndex = 218
        Me.btnClose.Text = "TUTUP (ESC)"
        '
        'Guna2BorderlessForm2
        '
        Me.Guna2BorderlessForm2.ContainerControl = Me
        Me.Guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm2.TransparentWhileDrag = True
        '
        'lblProses
        '
        Me.lblProses.AutoSize = True
        Me.lblProses.Location = New System.Drawing.Point(80, 127)
        Me.lblProses.Name = "lblProses"
        Me.lblProses.Size = New System.Drawing.Size(13, 13)
        Me.lblProses.TabIndex = 221
        Me.lblProses.Text = "0"
        Me.lblProses.Visible = False
        '
        'btnprint
        '
        Me.btnprint.BackgroundImage = Global.POSMacarons.My.Resources.Resources.Printer_Barcode
        Me.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnprint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnprint.Location = New System.Drawing.Point(304, 156)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(100, 89)
        Me.btnprint.TabIndex = 219
        Me.btnprint.UseVisualStyleBackColor = True
        '
        'frmCetakUlangReturPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 320)
        Me.Controls.Add(Me.panelNota)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblProses)
        Me.Controls.Add(Me.btnprint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCetakUlangReturPenjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Cetak Ulang Retur Penjualan"
        Me.panelNota.ResumeLayout(False)
        Me.panelNota.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents panelNota As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxRetur As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCariRetur As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblProses As Label
    Friend WithEvents btnprint As Button
    Friend WithEvents Guna2BorderlessForm2 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
