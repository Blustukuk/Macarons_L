Public Class frmLapPenjualanPerNota
    Private Sub frmLapPenjualanPerNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 255, 234, 167)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        lappenjualanpernotaclick(dtp1.Value, dtp2.Value)
        Dispose()
    End Sub
End Class