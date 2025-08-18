Public Class frmPenjualanCetakUlang
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub txtCariNota_TextChanged(sender As Object, e As EventArgs) Handles txtCariSJ.TextChanged
        If txtCariSJ.TextLength >= 2 Then
            lblProses.Text = "0"
            Dim dt As DataTable = loadDataNoSJ(txtCariSJ.Text)
            With cbxSJ
                .DataSource = dt
                .DisplayMember = "nopenjualan"
                .ValueMember = "nopenjualan"
                .SelectedIndex = -1
            End With
            lblProses.Text = "1"
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        cetakUlangSJClick(cbxSJ.Text)
        Dispose()
    End Sub
End Class