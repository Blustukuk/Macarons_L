<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPengadaanJml
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPengadaanJml))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(Me.components)
        Me.txtjml = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnbatal = New System.Windows.Forms.Button()
        Me.btnok = New System.Windows.Forms.Button()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHarga = New System.Windows.Forms.TextBox()
        Me.lblArtikel = New System.Windows.Forms.Label()
        Me.lblNama = New System.Windows.Forms.Label()
        Me.lblBrandID = New System.Windows.Forms.Label()
        Me.lblArtikelID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.AnimateWindow = True
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.ResizeForm = False
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Guna2ShadowForm1
        '
        Me.Guna2ShadowForm1.TargetForm = Me
        '
        'txtjml
        '
        Me.txtjml.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjml.Location = New System.Drawing.Point(146, 98)
        Me.txtjml.MaxLength = 20
        Me.txtjml.Name = "txtjml"
        Me.txtjml.Size = New System.Drawing.Size(245, 29)
        Me.txtjml.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(125, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 24)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(14, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 24)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "Jumlah"
        '
        'btnbatal
        '
        Me.btnbatal.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnbatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbatal.ForeColor = System.Drawing.Color.Red
        Me.btnbatal.Location = New System.Drawing.Point(18, 220)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(373, 38)
        Me.btnbatal.TabIndex = 143
        Me.btnbatal.Text = "BATAL"
        Me.btnbatal.UseVisualStyleBackColor = True
        '
        'btnok
        '
        Me.btnok.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnok.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnok.Location = New System.Drawing.Point(18, 176)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(373, 38)
        Me.btnok.TabIndex = 142
        Me.btnok.Text = "OK (F2)"
        Me.btnok.UseVisualStyleBackColor = True
        '
        'lblBrand
        '
        Me.lblBrand.BackColor = System.Drawing.Color.Transparent
        Me.lblBrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrand.ForeColor = System.Drawing.Color.Black
        Me.lblBrand.Location = New System.Drawing.Point(18, 10)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(373, 24)
        Me.lblBrand.TabIndex = 144
        Me.lblBrand.Text = "-"
        Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 24)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "Harga"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(125, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 24)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = ":"
        '
        'txtHarga
        '
        Me.txtHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarga.Location = New System.Drawing.Point(146, 133)
        Me.txtHarga.MaxLength = 20
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.Size = New System.Drawing.Size(245, 29)
        Me.txtHarga.TabIndex = 2
        '
        'lblArtikel
        '
        Me.lblArtikel.BackColor = System.Drawing.Color.Transparent
        Me.lblArtikel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtikel.ForeColor = System.Drawing.Color.Black
        Me.lblArtikel.Location = New System.Drawing.Point(18, 34)
        Me.lblArtikel.Name = "lblArtikel"
        Me.lblArtikel.Size = New System.Drawing.Size(373, 24)
        Me.lblArtikel.TabIndex = 144
        Me.lblArtikel.Text = "-"
        Me.lblArtikel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNama
        '
        Me.lblNama.BackColor = System.Drawing.Color.Transparent
        Me.lblNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNama.ForeColor = System.Drawing.Color.Black
        Me.lblNama.Location = New System.Drawing.Point(18, 58)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(373, 24)
        Me.lblNama.TabIndex = 144
        Me.lblNama.Text = "-"
        Me.lblNama.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBrandID
        '
        Me.lblBrandID.BackColor = System.Drawing.Color.Transparent
        Me.lblBrandID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandID.ForeColor = System.Drawing.Color.Black
        Me.lblBrandID.Location = New System.Drawing.Point(18, 76)
        Me.lblBrandID.Name = "lblBrandID"
        Me.lblBrandID.Size = New System.Drawing.Size(23, 24)
        Me.lblBrandID.TabIndex = 147
        Me.lblBrandID.Text = "0"
        Me.lblBrandID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblBrandID.Visible = False
        '
        'lblArtikelID
        '
        Me.lblArtikelID.BackColor = System.Drawing.Color.Transparent
        Me.lblArtikelID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtikelID.ForeColor = System.Drawing.Color.Black
        Me.lblArtikelID.Location = New System.Drawing.Point(37, 76)
        Me.lblArtikelID.Name = "lblArtikelID"
        Me.lblArtikelID.Size = New System.Drawing.Size(23, 24)
        Me.lblArtikelID.TabIndex = 148
        Me.lblArtikelID.Text = "0"
        Me.lblArtikelID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblArtikelID.Visible = False
        '
        'frmPengadaanJml
        '
        Me.AcceptButton = Me.btnok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnbatal
        Me.ClientSize = New System.Drawing.Size(405, 267)
        Me.Controls.Add(Me.lblArtikelID)
        Me.Controls.Add(Me.lblBrandID)
        Me.Controls.Add(Me.txtHarga)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtjml)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnbatal)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.lblNama)
        Me.Controls.Add(Me.lblArtikel)
        Me.Controls.Add(Me.lblBrand)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPengadaanJml"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Jumlah Item"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents txtjml As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnbatal As Button
    Friend WithEvents btnok As Button
    Friend WithEvents lblBrand As Label
    Friend WithEvents txtHarga As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNama As Label
    Friend WithEvents lblArtikel As Label
    Friend WithEvents lblArtikelID As Label
    Friend WithEvents lblBrandID As Label
End Class
