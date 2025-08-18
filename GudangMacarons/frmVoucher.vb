Public Class frmVoucher
    Private Sub txtNominal_TextChanged(sender As Object, e As EventArgs) Handles txtNominal.TextChanged
        If txtNominal.TextLength > 0 And IsNumeric(txtNominal.Text) Then
            txtNominal.Text = FormatNumber(txtNominal.Text, 0, TriState.False, , TriState.True)
            txtNominal.Select(txtNominal.Text.Length, 0)
        End If
    End Sub

    Private Sub frmVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Me.KeyPreview = True
        Call gantiwarnaform(sender, 231, 127, 103)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        If txtNominal.Text <> "" And IsNumeric(txtNominal.Text) And txtJml.Text <> "" And IsNumeric(txtJml.Text) Then
            Dim nominal As String = getnumber(txtNominal.Text)
            Dim jml As String = txtJml.Text
            Dim aktif As String = If(rbAktif.Checked, "1", "0")
            Dim print As MsgBoxResult
            print = MsgBox("Yakin akan cetak barcode untuk voucher ? ", vbYesNo, "Macarons")
            If print = vbYes Then
                printVoucher(nominal, jml, aktif)
                txtNominal.Text = ""
                txtJml.Text = ""
                txtNominal.Focus()
                MsgBox("Proses cetak barcode voucher sukses.", vbOKOnly, "Macarons")
            End If
        Else
            MsgBox("Isi dahulu data cetak voucher dengan lengkap", vbOKOnly, "Macarons")
        End If
    End Sub

    Private Sub txtJml_TextChanged(sender As Object, e As EventArgs) Handles txtJml.TextChanged
        If txtJml.TextLength > 0 And IsNumeric(txtJml.Text) Then
            txtJml.Text = FormatNumber(txtJml.Text, 0, TriState.False, , TriState.True)
            txtJml.Select(txtNominal.Text.Length, 0)
        End If
    End Sub
End Class