Public Class frminputbox
    Protected m_BlankValid As Boolean = True
    Protected m_ReturnText As String = ""

    Public Overloads Function ShowDialog(
          ByVal TitleText As String,
          ByVal PromptText As String,
          ByVal DefaultText As String,
          ByRef EnteredText As String,
          ByVal BlankValid As Boolean) As System.Windows.Forms.DialogResult
        m_BlankValid = BlankValid
        Me.Lbl_Prompt.Text = PromptText
        Me.Text = TitleText
        Me.Txt_TextEntry.Text = DefaultText
        Me.ShowDialog()
        EnteredText = m_ReturnText
        Return Me.DialogResult
    End Function

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_TextEntry.TextChanged
        If Me.Txt_TextEntry.Text = "" Then
            Me.But_Ok.Enabled = m_BlankValid
        Else
            Me.But_Ok.Enabled = True
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles But_Ok.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        m_ReturnText = Me.Txt_TextEntry.Text
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles But_Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        m_ReturnText = ""
        Me.Close()
    End Sub

    Private Sub frminputbox_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
    End Sub
End Class