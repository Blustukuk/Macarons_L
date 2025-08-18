<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReturPengiriman
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReturPengiriman))
        Me.btnKodeOK = New Guna.UI2.WinForms.Guna2Button()
        Me.lblproses = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnProses = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTutup = New Guna.UI2.WinForms.Guna2Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvTemp = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lvitem = New System.Windows.Forms.ListView()
        Me.txtcariitem = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnKodeOK.Location = New System.Drawing.Point(325, 39)
        Me.btnKodeOK.Name = "btnKodeOK"
        Me.btnKodeOK.Size = New System.Drawing.Size(17, 23)
        Me.btnKodeOK.TabIndex = 306
        Me.btnKodeOK.Visible = False
        '
        'lblproses
        '
        Me.lblproses.AutoSize = True
        Me.lblproses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproses.Location = New System.Drawing.Point(570, 340)
        Me.lblproses.Name = "lblproses"
        Me.lblproses.Size = New System.Drawing.Size(13, 13)
        Me.lblproses.TabIndex = 304
        Me.lblproses.Text = "0"
        Me.lblproses.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(12, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 24)
        Me.Label12.TabIndex = 301
        Me.Label12.Text = "Daftar Retur"
        '
        'btnProses
        '
        Me.btnProses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProses.BorderRadius = 10
        Me.btnProses.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnProses.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnProses.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnProses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnProses.FillColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.btnProses.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProses.ForeColor = System.Drawing.Color.Yellow
        Me.btnProses.Location = New System.Drawing.Point(16, 652)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(850, 54)
        Me.btnProses.TabIndex = 4
        Me.btnProses.Text = "PROSES (F1)"
        '
        'btnTutup
        '
        Me.btnTutup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTutup.BorderRadius = 10
        Me.btnTutup.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTutup.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTutup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTutup.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTutup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnTutup.FillColor = System.Drawing.Color.Black
        Me.btnTutup.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTutup.ForeColor = System.Drawing.Color.Red
        Me.btnTutup.Location = New System.Drawing.Point(16, 721)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(850, 54)
        Me.btnTutup.TabIndex = 5
        Me.btnTutup.Text = "TUTUP (ESC)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(94, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 24)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = ":"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(112, 6)
        Me.txtBarcode.MaxLength = 50
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(230, 29)
        Me.txtBarcode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 24)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "Barcode"
        '
        'dgvTemp
        '
        Me.dgvTemp.AllowUserToAddRows = False
        Me.dgvTemp.AllowUserToDeleteRows = False
        Me.dgvTemp.AllowUserToOrderColumns = True
        Me.dgvTemp.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(212, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(160, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvTemp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTemp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTemp.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTemp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTemp.ColumnHeadersHeight = 4
        Me.dgvTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(226, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(160, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTemp.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTemp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvTemp.GridColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.dgvTemp.Location = New System.Drawing.Point(16, 157)
        Me.dgvTemp.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvTemp.MultiSelect = False
        Me.dgvTemp.Name = "dgvTemp"
        Me.dgvTemp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(226, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(226, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTemp.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTemp.RowHeadersVisible = False
        Me.dgvTemp.RowHeadersWidth = 51
        Me.dgvTemp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTemp.RowTemplate.Height = 40
        Me.dgvTemp.Size = New System.Drawing.Size(848, 490)
        Me.dgvTemp.TabIndex = 307
        Me.dgvTemp.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Emerald
        Me.dgvTemp.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dgvTemp.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTemp.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvTemp.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.dgvTemp.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvTemp.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgvTemp.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.dgvTemp.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.dgvTemp.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvTemp.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTemp.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvTemp.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvTemp.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvTemp.ThemeStyle.ReadOnly = False
        Me.dgvTemp.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.dgvTemp.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvTemp.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTemp.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvTemp.ThemeStyle.RowsStyle.Height = 40
        Me.dgvTemp.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.dgvTemp.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.Guna2Panel4.Controls.Add(Me.Label10)
        Me.Guna2Panel4.Controls.Add(Me.lvitem)
        Me.Guna2Panel4.Controls.Add(Me.txtcariitem)
        Me.Guna2Panel4.Controls.Add(Me.Label9)
        Me.Guna2Panel4.Location = New System.Drawing.Point(348, 6)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.Size = New System.Drawing.Size(518, 146)
        Me.Guna2Panel4.TabIndex = 308
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(10, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 24)
        Me.Label10.TabIndex = 218
        Me.Label10.Text = "Item"
        '
        'lvitem
        '
        Me.lvitem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvitem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvitem.FullRowSelect = True
        Me.lvitem.HideSelection = False
        Me.lvitem.Location = New System.Drawing.Point(11, 40)
        Me.lvitem.MultiSelect = False
        Me.lvitem.Name = "lvitem"
        Me.lvitem.Size = New System.Drawing.Size(504, 94)
        Me.lvitem.TabIndex = 3
        Me.lvitem.UseCompatibleStateImageBehavior = False
        '
        'txtcariitem
        '
        Me.txtcariitem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcariitem.Location = New System.Drawing.Point(127, 5)
        Me.txtcariitem.MaxLength = 50
        Me.txtcariitem.Name = "txtcariitem"
        Me.txtcariitem.Size = New System.Drawing.Size(388, 29)
        Me.txtcariitem.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(106, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 24)
        Me.Label9.TabIndex = 219
        Me.Label9.Text = ":"
        '
        'frmReturPengiriman
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnTutup
        Me.ClientSize = New System.Drawing.Size(875, 783)
        Me.Controls.Add(Me.Guna2Panel4)
        Me.Controls.Add(Me.dgvTemp)
        Me.Controls.Add(Me.btnKodeOK)
        Me.Controls.Add(Me.lblproses)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnProses)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReturPengiriman"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Retur Pengiriman"
        CType(Me.dgvTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnKodeOK As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblproses As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnProses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTutup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvTemp As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents lvitem As ListView
    Friend WithEvents txtcariitem As TextBox
    Friend WithEvents Label9 As Label
End Class
