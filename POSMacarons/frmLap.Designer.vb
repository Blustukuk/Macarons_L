<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLap))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PengadaanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeriodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerTenantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerNotaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerKasirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EDCQRISToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PengadaanKhususToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PengirimanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeriodeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StokToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ALLTglBeliToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ALLTenantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpnameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PengadaanToolStripMenuItem, Me.PengirimanToolStripMenuItem, Me.StokToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 29)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PengadaanToolStripMenuItem
        '
        Me.PengadaanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PeriodeToolStripMenuItem, Me.PerTenantToolStripMenuItem, Me.PerNotaToolStripMenuItem, Me.PerKasirToolStripMenuItem, Me.EDCQRISToolStripMenuItem, Me.PengadaanKhususToolStripMenuItem})
        Me.PengadaanToolStripMenuItem.Name = "PengadaanToolStripMenuItem"
        Me.PengadaanToolStripMenuItem.Size = New System.Drawing.Size(89, 25)
        Me.PengadaanToolStripMenuItem.Text = "Penjualan"
        '
        'PeriodeToolStripMenuItem
        '
        Me.PeriodeToolStripMenuItem.Name = "PeriodeToolStripMenuItem"
        Me.PeriodeToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.PeriodeToolStripMenuItem.Text = "Periode"
        '
        'PerTenantToolStripMenuItem
        '
        Me.PerTenantToolStripMenuItem.Name = "PerTenantToolStripMenuItem"
        Me.PerTenantToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.PerTenantToolStripMenuItem.Text = "Per Tenant"
        Me.PerTenantToolStripMenuItem.Visible = False
        '
        'PerNotaToolStripMenuItem
        '
        Me.PerNotaToolStripMenuItem.Name = "PerNotaToolStripMenuItem"
        Me.PerNotaToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.PerNotaToolStripMenuItem.Text = "Per Nota"
        '
        'PerKasirToolStripMenuItem
        '
        Me.PerKasirToolStripMenuItem.Name = "PerKasirToolStripMenuItem"
        Me.PerKasirToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.PerKasirToolStripMenuItem.Text = "Per Kasir"
        '
        'EDCQRISToolStripMenuItem
        '
        Me.EDCQRISToolStripMenuItem.Name = "EDCQRISToolStripMenuItem"
        Me.EDCQRISToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.EDCQRISToolStripMenuItem.Text = "EDC - QRIS"
        '
        'PengadaanKhususToolStripMenuItem
        '
        Me.PengadaanKhususToolStripMenuItem.Name = "PengadaanKhususToolStripMenuItem"
        Me.PengadaanKhususToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.PengadaanKhususToolStripMenuItem.Text = "Pengadaan Khusus"
        '
        'PengirimanToolStripMenuItem
        '
        Me.PengirimanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PeriodeToolStripMenuItem1})
        Me.PengirimanToolStripMenuItem.Name = "PengirimanToolStripMenuItem"
        Me.PengirimanToolStripMenuItem.Size = New System.Drawing.Size(104, 25)
        Me.PengirimanToolStripMenuItem.Text = "Penerimaan"
        '
        'PeriodeToolStripMenuItem1
        '
        Me.PeriodeToolStripMenuItem1.Name = "PeriodeToolStripMenuItem1"
        Me.PeriodeToolStripMenuItem1.Size = New System.Drawing.Size(132, 26)
        Me.PeriodeToolStripMenuItem1.Text = "Periode"
        '
        'StokToolStripMenuItem
        '
        Me.StokToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ALLTglBeliToolStripMenuItem, Me.ALLTenantToolStripMenuItem, Me.OpnameToolStripMenuItem})
        Me.StokToolStripMenuItem.Name = "StokToolStripMenuItem"
        Me.StokToolStripMenuItem.Size = New System.Drawing.Size(52, 25)
        Me.StokToolStripMenuItem.Text = "Stok"
        '
        'ALLTglBeliToolStripMenuItem
        '
        Me.ALLTglBeliToolStripMenuItem.Name = "ALLTglBeliToolStripMenuItem"
        Me.ALLTglBeliToolStripMenuItem.Size = New System.Drawing.Size(188, 26)
        Me.ALLTglBeliToolStripMenuItem.Text = "Per Tanggal Beli"
        '
        'ALLTenantToolStripMenuItem
        '
        Me.ALLTenantToolStripMenuItem.Name = "ALLTenantToolStripMenuItem"
        Me.ALLTenantToolStripMenuItem.Size = New System.Drawing.Size(188, 26)
        Me.ALLTenantToolStripMenuItem.Text = "Per Tenant"
        '
        'OpnameToolStripMenuItem
        '
        Me.OpnameToolStripMenuItem.Name = "OpnameToolStripMenuItem"
        Me.OpnameToolStripMenuItem.Size = New System.Drawing.Size(188, 26)
        Me.OpnameToolStripMenuItem.Text = "Opname"
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crv.Location = New System.Drawing.Point(0, 29)
        Me.crv.Name = "crv"
        Me.crv.ShowCloseButton = False
        Me.crv.ShowCopyButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowParameterPanelButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(800, 421)
        Me.crv.TabIndex = 2
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmLap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Laporan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PengadaanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PeriodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PengirimanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PeriodeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents StokToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PerTenantToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PerNotaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PerKasirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EDCQRISToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ALLTglBeliToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ALLTenantToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpnameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PengadaanKhususToolStripMenuItem As ToolStripMenuItem
End Class
