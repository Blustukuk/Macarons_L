Public Class frmOpname
    Private Sub frmOpname_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 255, 234, 167)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
    End Sub

    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F2 Then
            btnStokOpname_Click(o, e)
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnStokOpname_Click(sender As Object, e As EventArgs) Handles btnStokOpname.Click
        Dim gantiStokOpname As MsgBoxResult = MsgBox("Yakin akan merubah data stok ?", vbYesNo, "Macarons")
        If gantiStokOpname = vbYes Then
            Dim edit As Integer = editStok(lblBarcode.Text, lblQtyKomp.Text, lblQtyScan.Text, txtKet.Text)
            If edit <> 0 Then
                MsgBox("Proses stok opname sukses.", vbOKOnly, "Macarons")
                Dispose()
            Else
                MsgBox("Proses stok opname GAGAL. Hubungi developer.", vbCritical, "Macarons")
                Dispose()
            End If
        End If
    End Sub

    Private Sub frmOpname_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtKet.Focus()
    End Sub
End Class