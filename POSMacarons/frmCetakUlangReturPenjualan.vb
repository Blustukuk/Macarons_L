Public Class frmCetakUlangReturPenjualan
    Private Sub frmCetakUlangReturPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Me.KeyPreview = True
        gantiwarnaform(sender, 231, 127, 103)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub txtCariRetur_TextChanged(sender As Object, e As EventArgs) Handles txtCariRetur.TextChanged
        If txtCariRetur.TextLength >= 2 Then
            lblProses.Text = "0"
            Dim dt As DataTable = loadDataNoRetur(txtCariRetur.Text)
            With cbxRetur
                .DataSource = dt
                .DisplayMember = "no_retur"
                .ValueMember = "no_retur"
                .SelectedIndex = -1
            End With
            lblProses.Text = "1"
        End If
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        If cbxRetur.SelectedIndex <> -1 Then
            Dim noRetur As String = cbxRetur.Text
            Dim cetak As Boolean = insertCetakUlang(noRetur, "Retur Penjualan")
            If cetak Then
                printRetur(noRetur)
                cbxRetur.SelectedIndex = -1
            End If
        Else
            MsgBox("Isi dahulu data cetak ulang retur dengan lengkap", vbOKOnly, "Macarons")
        End If
    End Sub
End Class