Public Class frmCetakBarcodeManual
    Private Sub frmCetakBarcodeManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Me.KeyPreview = True
        Call gantiwarnaform(sender, 231, 127, 103)
        Call frmCetakBarcodeManualLoad()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        If rbBarcode.Checked Then
            If cbxBarcode.SelectedIndex <> -1 Or txtJml.Text <> "" Or IsNumeric(txtJml.Text) <> False Then
                Dim cetak As Boolean = insertDataPrintBarcodeManual(Split(cbxBarcode.SelectedValue, "^")(0), Split(cbxBarcode.SelectedValue, "^")(1), Split(cbxBarcode.SelectedValue, "^")(2), Split(cbxBarcode.SelectedValue, "^")(3), txtJml.Text, Split(cbxBarcode.SelectedValue, "^")(4))
                If cetak Then
                    Dim qr As Boolean = rbModeQRcode.Checked
                    printBarcode(qr)
                    frmCetakBarcodeManualLoad()
                End If
            Else
                MsgBox("Isi dahulu data cetak barcode dengan lengkap", vbOKOnly, "Macarons")
            End If
        ElseIf rbNota.Checked Then
            If cbxNota.SelectedIndex <> -1 Then
                Dim cetak As Boolean = insertDataPrintBarcodeManualByNota(cbxNota.Text)
                If cetak Then
                    Dim qr As Boolean = rbModeQRcode.Checked
                    printBarcode(qr)
                    frmCetakBarcodeManualLoad()
                End If
            Else
                MsgBox("Isi dahulu data cetak barcode dengan lengkap", vbOKOnly, "Macarons")
            End If
        End If
    End Sub

    Private Sub rbBarcode_CheckedChanged(sender As Object, e As EventArgs) Handles rbBarcode.CheckedChanged, rbNota.CheckedChanged
        If rbBarcode.Checked Then
            panelBarcode.Enabled = True
            panelNota.Enabled = False
        Else
            panelBarcode.Enabled = False
            panelNota.Enabled = True
        End If
    End Sub

    Private Sub txtCariBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtCariBarcode.TextChanged
        If txtCariBarcode.TextLength >= 2 Then
            lblproses.Text = "0"
            Dim dt As DataTable = loadDataBarcode(txtCariBarcode.Text)
            With cbxBarcode
                .DataSource = dt
                .DisplayMember = "info"
                .ValueMember = "info"
                .SelectedIndex = -1
            End With
            lblproses.Text = "1"
        End If
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
End Class