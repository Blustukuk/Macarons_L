<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLain))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.btnLaporan = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPenerimaan = New Guna.UI2.WinForms.Guna2Button()
        Me.btnGantiPass = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRetur = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCariCepatPenjualan = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCariCepatStok = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'btnLaporan
        '
        Me.btnLaporan.BorderRadius = 10
        Me.btnLaporan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnLaporan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnLaporan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnLaporan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnLaporan.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.btnLaporan.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaporan.ForeColor = System.Drawing.Color.Black
        Me.btnLaporan.Location = New System.Drawing.Point(12, 12)
        Me.btnLaporan.Name = "btnLaporan"
        Me.btnLaporan.Size = New System.Drawing.Size(376, 54)
        Me.btnLaporan.TabIndex = 1
        Me.btnLaporan.Text = "LAPORAN (ADMIN)"
        '
        'btnPenerimaan
        '
        Me.btnPenerimaan.BorderRadius = 10
        Me.btnPenerimaan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPenerimaan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPenerimaan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPenerimaan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPenerimaan.FillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnPenerimaan.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPenerimaan.ForeColor = System.Drawing.Color.Black
        Me.btnPenerimaan.Location = New System.Drawing.Point(12, 72)
        Me.btnPenerimaan.Name = "btnPenerimaan"
        Me.btnPenerimaan.Size = New System.Drawing.Size(376, 54)
        Me.btnPenerimaan.TabIndex = 2
        Me.btnPenerimaan.Text = "PENERIMAAN"
        '
        'btnGantiPass
        '
        Me.btnGantiPass.BorderRadius = 10
        Me.btnGantiPass.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnGantiPass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnGantiPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnGantiPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnGantiPass.FillColor = System.Drawing.Color.FromArgb(CType(CType(162, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnGantiPass.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGantiPass.ForeColor = System.Drawing.Color.Black
        Me.btnGantiPass.Location = New System.Drawing.Point(13, 312)
        Me.btnGantiPass.Name = "btnGantiPass"
        Me.btnGantiPass.Size = New System.Drawing.Size(376, 54)
        Me.btnGantiPass.TabIndex = 3
        Me.btnGantiPass.Text = "GANTI PASSWORD"
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
        Me.btnClose.Location = New System.Drawing.Point(12, 372)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(377, 58)
        Me.btnClose.TabIndex = 254
        Me.btnClose.Text = "TUTUP (ESC)"
        '
        'btnRetur
        '
        Me.btnRetur.BorderRadius = 10
        Me.btnRetur.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnRetur.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnRetur.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnRetur.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnRetur.FillColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.btnRetur.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetur.ForeColor = System.Drawing.Color.Black
        Me.btnRetur.Location = New System.Drawing.Point(12, 252)
        Me.btnRetur.Name = "btnRetur"
        Me.btnRetur.Size = New System.Drawing.Size(376, 54)
        Me.btnRetur.TabIndex = 255
        Me.btnRetur.Text = "RETUR PENGIRIMAN"
        '
        'btnCariCepatPenjualan
        '
        Me.btnCariCepatPenjualan.BorderRadius = 10
        Me.btnCariCepatPenjualan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCariCepatPenjualan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCariCepatPenjualan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCariCepatPenjualan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCariCepatPenjualan.FillColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.btnCariCepatPenjualan.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCariCepatPenjualan.ForeColor = System.Drawing.Color.White
        Me.btnCariCepatPenjualan.Location = New System.Drawing.Point(12, 132)
        Me.btnCariCepatPenjualan.Name = "btnCariCepatPenjualan"
        Me.btnCariCepatPenjualan.Size = New System.Drawing.Size(376, 54)
        Me.btnCariCepatPenjualan.TabIndex = 2
        Me.btnCariCepatPenjualan.Text = "CARI CEPAT PENJUALAN"
        '
        'btnCariCepatStok
        '
        Me.btnCariCepatStok.BorderRadius = 10
        Me.btnCariCepatStok.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCariCepatStok.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCariCepatStok.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCariCepatStok.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCariCepatStok.FillColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnCariCepatStok.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCariCepatStok.ForeColor = System.Drawing.Color.White
        Me.btnCariCepatStok.Location = New System.Drawing.Point(13, 192)
        Me.btnCariCepatStok.Name = "btnCariCepatStok"
        Me.btnCariCepatStok.Size = New System.Drawing.Size(376, 54)
        Me.btnCariCepatStok.TabIndex = 2
        Me.btnCariCepatStok.Text = "CARI CEPAT STOK"
        '
        'frmLain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(401, 442)
        Me.Controls.Add(Me.btnRetur)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnGantiPass)
        Me.Controls.Add(Me.btnCariCepatStok)
        Me.Controls.Add(Me.btnCariCepatPenjualan)
        Me.Controls.Add(Me.btnPenerimaan)
        Me.Controls.Add(Me.btnLaporan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Lain-Lain"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents btnLaporan As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPenerimaan As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnGantiPass As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRetur As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCariCepatStok As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCariCepatPenjualan As Guna.UI2.WinForms.Guna2Button
End Class
