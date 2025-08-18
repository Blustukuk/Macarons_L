<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLapPengirimanPeriode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLapPengirimanPeriode))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Guna2BorderlessForm2 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.btnProses = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxTenant = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Guna2BorderlessForm2
        '
        Me.Guna2BorderlessForm2.ContainerControl = Me
        Me.Guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm2.TransparentWhileDrag = True
        '
        'btnProses
        '
        Me.btnProses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProses.BorderRadius = 20
        Me.btnProses.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnProses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnProses.FillColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.btnProses.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProses.ForeColor = System.Drawing.Color.Black
        Me.btnProses.Location = New System.Drawing.Point(21, 164)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.ShadowDecoration.Shadow = New System.Windows.Forms.Padding(15)
        Me.btnProses.Size = New System.Drawing.Size(349, 58)
        Me.btnProses.TabIndex = 265
        Me.btnProses.Text = "PROSES"
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
        Me.btnClose.Location = New System.Drawing.Point(21, 225)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(349, 45)
        Me.btnClose.TabIndex = 264
        Me.btnClose.Text = "TUTUP (ESC)"
        '
        'dtp2
        '
        Me.dtp2.CustomFormat = "yyyy-MM-dd"
        Me.dtp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp2.Location = New System.Drawing.Point(129, 46)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(187, 29)
        Me.dtp2.TabIndex = 263
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 24)
        Me.Label2.TabIndex = 262
        Me.Label2.Text = "Tgl Akhir   :"
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "yyyy-MM-dd"
        Me.dtp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp1.Location = New System.Drawing.Point(129, 8)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(187, 29)
        Me.dtp1.TabIndex = 261
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 24)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Tgl Awal   :"
        '
        'cbxTenant
        '
        Me.cbxTenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTenant.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTenant.FormattingEnabled = True
        Me.cbxTenant.Location = New System.Drawing.Point(129, 86)
        Me.cbxTenant.Name = "cbxTenant"
        Me.cbxTenant.Size = New System.Drawing.Size(253, 32)
        Me.cbxTenant.TabIndex = 267
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 266
        Me.Label3.Text = "Tenant      :"
        '
        'frmLapPengirimanPeriode
        '
        Me.AcceptButton = Me.btnProses
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(387, 278)
        Me.Controls.Add(Me.cbxTenant)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnProses)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dtp2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLapPengirimanPeriode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Pengiriman Periode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents btnProses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2BorderlessForm2 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents cbxTenant As ComboBox
    Friend WithEvents Label3 As Label
End Class
