Public Class frmBatalPembelian
    Private Sub frmBatalPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 247, 143, 179)
        frmBatalPembelianLoad()
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnProses_Click(o, e)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim edit As Integer
        If cbxNoNota.SelectedIndex <> -1 Then
            edit = batalPembelian(cbxNoNota.Text)
            If edit <> 0 Then
                MsgBox("Proses batal pembelian sukses.", vbOKOnly, "Macarons")
                frmBatalPembelianLoad()
                dgvtemp.Columns.Clear()
            Else
                MsgBox("Proses edit data gagal. Hubungi developer.", vbCritical, "Macarons")
            End If
        End If
    End Sub

    Private Sub cbxNoNota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNoNota.SelectedIndexChanged
        If lblproses.Text = "1" Then
            dgvtemp.Columns.Clear()
            Dim nonota As String = cbxNoNota.SelectedValue
            Dim dt As DataTable = loadDataPembelianByNoNota(nonota)
            dgvtemp.Columns.Add("id", "id")
            dgvtemp.Columns.Add("tgl_beli", "tgl_beli")
            dgvtemp.Columns.Add("supp_id", "supp_id")
            dgvtemp.Columns.Add("brand_id", "brand_id")
            dgvtemp.Columns.Add("artikel_id", "artikel_id")
            dgvtemp.Columns.Add("No", "No")
            dgvtemp.Columns.Add("Brand", "Brand")
            dgvtemp.Columns.Add("Artikel", "Artikel")
            dgvtemp.Columns.Add("Nama", "Nama")
            dgvtemp.Columns.Add("Jumlah", "Jumlah")
            dgvtemp.Columns.Add("Harga", "Harga")
            For Each rowBarcode In dt.Rows
                Dim row As DataGridViewRow = New DataGridViewRow()
                row.CreateCells(dgvtemp)
                row.Cells(0).Value = rowBarcode("id")
                row.Cells(1).Value = rowBarcode("tgl_beli")
                row.Cells(2).Value = rowBarcode("supp_id")
                row.Cells(3).Value = rowBarcode("brand_id")
                row.Cells(4).Value = rowBarcode("artikel_id")
                row.Cells(5).Value = rowBarcode("No")
                row.Cells(6).Value = rowBarcode("Brand")
                row.Cells(7).Value = rowBarcode("Artikel")
                row.Cells(8).Value = rowBarcode("Nama")
                row.Cells(9).Value = rowBarcode("Jumlah")
                row.Cells(10).Value = rowBarcode("Harga")
                dgvtemp.Rows.Add(row)
            Next
            dgvtemp.Columns(0).Visible = False
            dgvtemp.Columns(1).Visible = False
            dgvtemp.Columns(2).Visible = False
            dgvtemp.Columns(3).Visible = False
            dgvtemp.Columns(4).Visible = False
        End If

    End Sub
End Class