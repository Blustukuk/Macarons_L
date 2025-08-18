Imports System.Threading
Imports System.Configuration

Public Class frmLogin
    Dim kasir As String = ConfigurationManager.AppSettings("Kasir")
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Me.txtUsername.Text = "" Or Me.txtPassword.Text = "" Then
            MsgBox("Isi terlebih dahulu username dan password", vbCritical, "Macarons")
        Else
            Call loginMacarons(txtUsername.Text, txtPassword.Text, kasir)
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmSplash.Show()
        frmSplash.Refresh()

        Thread.Sleep(2000)
        txtKasir.Text = kasir
        frmSplash.Hide()
        frmSplash.Close()
        txtUsername.Focus()
    End Sub

    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtUsername.Focus()
    End Sub
End Class
