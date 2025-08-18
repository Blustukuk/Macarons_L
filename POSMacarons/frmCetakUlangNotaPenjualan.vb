Public Class frmCetakUlangNotaPenjualan
    Private Sub frmCetakUlangNotaPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub txtCariNota_TextChanged(sender As Object, e As EventArgs) Handles txtCariNota.TextChanged
        If txtCariNota.TextLength >= 2 Then
            lblproses.Text = "0"
            Dim dt As DataTable = loadDataNoNota(txtCariNota.Text)
            With cbxNota
                .DataSource = dt
                .DisplayMember = "nota"
                .ValueMember = "nota"
                .SelectedIndex = -1
            End With
            lblproses.Text = "1"
        End If
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        If cbxNota.SelectedIndex <> -1 Then
            Dim nonota As String = cbxNota.Text
            Dim cetak As Boolean = insertCetakUlang(nonota, "Nota Penjualan")
            If cetak Then
                printNota(nonota)
                cbxNota.SelectedIndex = -1
            End If
        Else
            MsgBox("Isi dahulu data cetak ulang nota dengan lengkap", vbOKOnly, "Macarons")
        End If
    End Sub
End Class