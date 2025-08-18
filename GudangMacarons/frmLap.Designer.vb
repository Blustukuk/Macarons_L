<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLap))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PengadaanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeriodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByNamaItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PengirimanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeriodeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CetakUlangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StokToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReturToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PengadaanToolStripMenuItem, Me.PengirimanToolStripMenuItem, Me.StokToolStripMenuItem, Me.ItemToolStripMenuItem, Me.ReturToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1904, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PengadaanToolStripMenuItem
        '
        Me.PengadaanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PeriodeToolStripMenuItem, Me.MarginToolStripMenuItem, Me.ByNamaItemToolStripMenuItem})
        Me.PengadaanToolStripMenuItem.Name = "PengadaanToolStripMenuItem"
        Me.PengadaanToolStripMenuItem.Size = New System.Drawing.Size(98, 25)
        Me.PengadaanToolStripMenuItem.Text = "Pengadaan"
        '
        'PeriodeToolStripMenuItem
        '
        Me.PeriodeToolStripMenuItem.Name = "PeriodeToolStripMenuItem"
        Me.PeriodeToolStripMenuItem.Size = New System.Drawing.Size(194, 26)
        Me.PeriodeToolStripMenuItem.Text = "Periode"
        '
        'MarginToolStripMenuItem
        '
        Me.MarginToolStripMenuItem.Name = "MarginToolStripMenuItem"
        Me.MarginToolStripMenuItem.Size = New System.Drawing.Size(194, 26)
        Me.MarginToolStripMenuItem.Text = "Margin/Supplier"
        '
        'ByNamaItemToolStripMenuItem
        '
        Me.ByNamaItemToolStripMenuItem.Name = "ByNamaItemToolStripMenuItem"
        Me.ByNamaItemToolStripMenuItem.Size = New System.Drawing.Size(194, 26)
        Me.ByNamaItemToolStripMenuItem.Text = "By Nama Item"
        '
        'PengirimanToolStripMenuItem
        '
        Me.PengirimanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PeriodeToolStripMenuItem1, Me.CetakUlangToolStripMenuItem})
        Me.PengirimanToolStripMenuItem.Name = "PengirimanToolStripMenuItem"
        Me.PengirimanToolStripMenuItem.Size = New System.Drawing.Size(101, 25)
        Me.PengirimanToolStripMenuItem.Text = "Pengiriman"
        '
        'PeriodeToolStripMenuItem1
        '
        Me.PeriodeToolStripMenuItem1.Name = "PeriodeToolStripMenuItem1"
        Me.PeriodeToolStripMenuItem1.Size = New System.Drawing.Size(164, 26)
        Me.PeriodeToolStripMenuItem1.Text = "Periode"
        '
        'CetakUlangToolStripMenuItem
        '
        Me.CetakUlangToolStripMenuItem.Name = "CetakUlangToolStripMenuItem"
        Me.CetakUlangToolStripMenuItem.Size = New System.Drawing.Size(164, 26)
        Me.CetakUlangToolStripMenuItem.Text = "Cetak Ulang"
        '
        'StokToolStripMenuItem
        '
        Me.StokToolStripMenuItem.Name = "StokToolStripMenuItem"
        Me.StokToolStripMenuItem.Size = New System.Drawing.Size(52, 25)
        Me.StokToolStripMenuItem.Text = "Stok"
        '
        'ItemToolStripMenuItem
        '
        Me.ItemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistoryToolStripMenuItem})
        Me.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem"
        Me.ItemToolStripMenuItem.Size = New System.Drawing.Size(53, 25)
        Me.ItemToolStripMenuItem.Text = "Item"
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(130, 26)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'ReturToolStripMenuItem
        '
        Me.ReturToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PenjualanToolStripMenuItem})
        Me.ReturToolStripMenuItem.Name = "ReturToolStripMenuItem"
        Me.ReturToolStripMenuItem.Size = New System.Drawing.Size(60, 25)
        Me.ReturToolStripMenuItem.Text = "Retur"
        '
        'PenjualanToolStripMenuItem
        '
        Me.PenjualanToolStripMenuItem.Name = "PenjualanToolStripMenuItem"
        Me.PenjualanToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.PenjualanToolStripMenuItem.Text = "Penjualan"
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
        Me.crv.Size = New System.Drawing.Size(1904, 1012)
        Me.crv.TabIndex = 1
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmLap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
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
    Friend WithEvents CetakUlangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StokToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarginToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ByNamaItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReturToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem As ToolStripMenuItem
End Class
