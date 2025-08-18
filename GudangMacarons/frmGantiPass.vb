Public Class frmGantiPass
    Private Sub frmGantiPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 232, 67, 147)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If Me.txtpass.Text <> Me.txtpass2.Text Then
            MsgBox("Ulangi Password dengan benar", vbCritical, "Macarons")
            txtpass.Text = ""
            txtpass2.Text = ""
            txtpass.Focus()
        ElseIf txtpass.Text = "" Or txtpass2.Text = "" Then
            MsgBox("Isi data diri dengan lengkap", vbCritical, "Macarons")
            txtpass.Focus
        Else
            Dim ganti As Boolean = gantipassword(frmMain.lblUserID.Text, txtpass.Text)
            If ganti Then
                MsgBox("Ganti password sukses.", vbOKOnly, "Macarons")
                Dispose()
            Else
                MsgBox("Ganti password GAGAL. Silahkan hubungi developer.", vbCritical, "Macarons")
                txtpass.Text = ""
                txtpass2.Text = ""
                txtpass.Focus()
            End If
        End If
    End Sub
End Class