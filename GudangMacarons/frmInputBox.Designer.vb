<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frminputbox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frminputbox))
        Me.But_Ok = New System.Windows.Forms.Button()
        Me.But_Cancel = New System.Windows.Forms.Button()
        Me.Txt_TextEntry = New System.Windows.Forms.TextBox()
        Me.Lbl_Prompt = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'But_Ok
        '
        Me.But_Ok.Location = New System.Drawing.Point(405, 42)
        Me.But_Ok.Name = "But_Ok"
        Me.But_Ok.Size = New System.Drawing.Size(93, 23)
        Me.But_Ok.TabIndex = 11
        Me.But_Ok.Text = "OK"
        Me.But_Ok.UseVisualStyleBackColor = True
        '
        'But_Cancel
        '
        Me.But_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.But_Cancel.ForeColor = System.Drawing.Color.Red
        Me.But_Cancel.Location = New System.Drawing.Point(405, 8)
        Me.But_Cancel.Name = "But_Cancel"
        Me.But_Cancel.Size = New System.Drawing.Size(93, 23)
        Me.But_Cancel.TabIndex = 10
        Me.But_Cancel.Text = "BATAL"
        Me.But_Cancel.UseVisualStyleBackColor = True
        '
        'Txt_TextEntry
        '
        Me.Txt_TextEntry.Location = New System.Drawing.Point(10, 45)
        Me.Txt_TextEntry.Name = "Txt_TextEntry"
        Me.Txt_TextEntry.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_TextEntry.Size = New System.Drawing.Size(389, 20)
        Me.Txt_TextEntry.TabIndex = 9
        '
        'Lbl_Prompt
        '
        Me.Lbl_Prompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Lbl_Prompt.Location = New System.Drawing.Point(10, 8)
        Me.Lbl_Prompt.Name = "Lbl_Prompt"
        Me.Lbl_Prompt.Size = New System.Drawing.Size(388, 33)
        Me.Lbl_Prompt.TabIndex = 8
        '
        'frminputbox
        '
        Me.AcceptButton = Me.But_Ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.CancelButton = Me.But_Cancel
        Me.ClientSize = New System.Drawing.Size(508, 73)
        Me.Controls.Add(Me.But_Ok)
        Me.Controls.Add(Me.But_Cancel)
        Me.Controls.Add(Me.Txt_TextEntry)
        Me.Controls.Add(Me.Lbl_Prompt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frminputbox"
        Me.Text = ".: Input"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents But_Ok As Button
    Friend WithEvents But_Cancel As Button
    Friend WithEvents Txt_TextEntry As TextBox
    Friend WithEvents Lbl_Prompt As Label
End Class
