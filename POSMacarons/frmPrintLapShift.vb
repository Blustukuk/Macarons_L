Public Class frmPrintLapShift
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmPrintLapShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Me.KeyPreview = True
        gantiwarnaform(sender, 231, 127, 103)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnCetak_Click(o, e)
        ElseIf e.KeyCode = Keys.F2 Then
            btnCek_Click(o, e)
        End If
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Dim cetak As MsgBoxResult
        cetak = MsgBox("Yakin akan cetak laporan Shift ?" & vbCrLf &
                       "Lakukan jika akan pergantian shift." & vbCrLf &
                       "Setelah cetak laporan shift, maka semua penjualan yang dilakukan pada shift ini tidak bisa dicetak ulang.", vbYesNo, "Macarons")
        cetakLapShift
        Dispose()
    End Sub

    Private Sub btnCek_Click(sender As Object, e As EventArgs) Handles btnCek.Click
        CekLapShift()
        Dispose()
    End Sub
End Class