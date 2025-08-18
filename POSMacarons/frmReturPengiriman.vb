Public Class frmReturPengiriman
    Dim dt As DataTable
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Dispose()
    End Sub

    Private Sub frmReturPengiriman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 255, 234, 167)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        tampilkanData()
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnProses_Click(o, e)
        End If
    End Sub
    Private Sub txtBarcode_GotFocus(sender As Object, e As EventArgs) Handles txtBarcode.GotFocus
        AcceptButton = btnKodeOK
    End Sub

    Private Sub txtBarcode_LostFocus(sender As Object, e As EventArgs) Handles txtBarcode.LostFocus
        AcceptButton = Nothing
    End Sub

    Private Sub btnKodeOK_Click(sender As Object, e As EventArgs) Handles btnKodeOK.Click
        Dim kode As String = txtBarcode.Text
        Dim stokAman As String = cekStok(kode, 1)
        If stokAman = "Y" Then
            addItemReturPengiriman(kode)
            tampilkanData()
            txtBarcode.Text = ""
        Else
            MsgBox("Stok barang kurang.", vbCritical, "Macarons")
        End If
    End Sub
    Private Sub lvitem_DoubleClick(sender As Object, e As EventArgs) Handles lvitem.DoubleClick
        Dim kode As String = lvitem.SelectedItems(0).SubItems(5).Text
        Dim stokAman As String = cekStok(kode, 1)
        If stokAman = "Y" Then
            addItemReturPengiriman(kode)
            tampilkanData()
        Else
            MsgBox("Stok barang kurang.", vbCritical, "Macarons")
        End If
    End Sub
    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim proses As Boolean = prosesReturPengiriman(frmPOS2.lblKasir.Text)
        If proses Then
            Dispose()
        End If
    End Sub
    Private Sub tampilkanData()
        dt = loadDataReturPengirimanTemp()
        If dt.Rows.Count > 0 Then
            dgvTemp.DataSource = Nothing
            dgvTemp.Columns.Clear()
            With dgvTemp
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                        {New DataGridViewButtonColumn() With
                                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Del", .Text = "Del", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
            End With
        Else
            dgvTemp.DataSource = Nothing
            dgvTemp.Columns.Clear()
        End If
    End Sub

    Private Sub dgvTemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTemp.CellContentClick
        If e.ColumnIndex = 5 And e.RowIndex >= 0 Then
            delReturPengirimanTemp(dgvTemp.Rows(e.RowIndex).Cells(0).Value.ToString)
            tampilkanData()
        End If
    End Sub

    Private Sub txtcariitem_TextChanged(sender As Object, e As EventArgs) Handles txtcariitem.TextChanged
        If Me.txtcariitem.TextLength > 3 Then
            Dim i As Integer
            Dim itemcoll(100) As String
            Dim items As New List(Of ListViewItem)
            With lvitem
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = False
                Dim dt As DataTable = loadDataItemByNama(txtcariitem.Text)
                For i = 0 To dt.Columns.Count - 1
                    .Columns.Add(dt.Columns(i).ColumnName.ToString())
                Next
                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        itemcoll(j) = dt.Rows(i)(j).ToString()
                    Next
                    Dim lvi As New ListViewItem(itemcoll)
                    items.Add(lvi)
                Next
                .Items.AddRange(items.ToArray)
                .AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
                .Columns(1).Width = 0
                .Columns(2).Width = 0
                .Columns(3).Width = 0
                .Columns(4).Width = 0
                .Columns(8).Width = 0
            End With
        ElseIf Me.txtcariitem.Text = "" Then
            Call ClearListView(lvitem)
        End If
    End Sub


End Class