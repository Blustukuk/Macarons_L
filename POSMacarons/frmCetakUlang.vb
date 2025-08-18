Public Class frmCetakUlang
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnNotaPenjualan_Click(sender As Object, e As EventArgs) Handles btnNotaPenjualan.Click
        If Application.OpenForms().OfType(Of frmCetakUlangNotaPenjualan).Any Then
            AppActivate(frmCetakUlangNotaPenjualan.Text)
        Else
            frmCetakUlangNotaPenjualan.Show()
        End If
    End Sub

    Private Sub frmCetakUlang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnNotaPenjualan_Click(o, e)
        ElseIf e.KeyCode = Keys.F2 Then
            btnNotaRetur_Click(o, e)
        End If
    End Sub

    Private Sub btnNotaRetur_Click(sender As Object, e As EventArgs) Handles btnNotaRetur.Click
        If Application.OpenForms().OfType(Of frmCetakUlangReturPenjualan).Any Then
            AppActivate(frmCetakUlangReturPenjualan.Text)
        Else
            frmCetakUlangReturPenjualan.Show()
        End If
    End Sub
End Class