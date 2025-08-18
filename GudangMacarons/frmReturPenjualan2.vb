Public Class frmReturPenjualan2
    Private Sub frmReturPenjualan2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 231, 127, 103)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim retur As Boolean
        Dim sj As String = txtSJ.Text
        retur = prosesReturPenjualan(sj, frmMain.lblUserID.Text)
        If retur Then
            MsgBox("Proses Penerimaan dengan SJ = " & sj & " sukses", vbOKOnly, "Macarons")
            txtSJ.Text = ""
        End If
    End Sub
End Class