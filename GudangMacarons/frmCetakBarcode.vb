Public Class frmCetakBarcode
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmCetakBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 48, 57, 82)
        frmCetakBarcodeLoad
    End Sub

    Private Sub cbxNoNota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNoNota.SelectedIndexChanged
        If lblproses.Text = "1" Then
            dgvtemp.Columns.Clear()
            Dim nonota As String = cbxNoNota.SelectedValue
            Dim dt As DataTable = loadDataCetakBarcode(nonota)
            dgvtemp.Columns.Add("Nama", "Nama")
            dgvtemp.Columns.Add("Kode", "Kode")
            dgvtemp.Columns.Add("Jml", "Jml")
            dgvtemp.Columns.Add("Harga", "Harga")
            dgvtemp.Columns.Add("Logo", "Logo")
            For Each rowBarcode In dt.Rows
                Dim row As DataGridViewRow = New DataGridViewRow()
                row.CreateCells(dgvtemp)
                row.Cells(0).Value = rowBarcode("Nama")
                row.Cells(1).Value = rowBarcode("Kode")
                row.Cells(2).Value = rowBarcode("Jml")
                row.Cells(3).Value = rowBarcode("Harga")
                row.Cells(4).Value = rowBarcode("Logo")
                dgvtemp.Rows.Add(row)
            Next
        End If
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        If cbxNoNota.SelectedIndex <> -1 Then
            Dim cetak As Boolean = insertDataPrintBarcode(cbxNoNota.SelectedValue)
            Dim qr As Boolean = rbModeQRcode.Checked
            If cetak Then
                updateFlagPrintStok(cbxNoNota.SelectedValue, 1)
                printBarcode(qr)
                frmCetakBarcodeLoad()
                dgvtemp.DataSource = Nothing
                dgvtemp.Columns.Clear()
            End If
        Else
            MsgBox("Pilih terlebih dahulu NOMOR NOTA yang akan dicetak barcode.", vbOKOnly, "Macarons")
        End If
    End Sub
End Class