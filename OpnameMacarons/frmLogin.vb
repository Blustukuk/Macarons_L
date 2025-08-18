Public Class frmLogin
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Me.txtUsername.Text = "" Or Me.txtPassword.Text = "" Then
            MsgBox("Isi terlebih dahulu username dan password", vbCritical, "Macarons")
        Else
            Call loginOpnameMacarons(txtUsername.Text, txtPassword.Text)
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
