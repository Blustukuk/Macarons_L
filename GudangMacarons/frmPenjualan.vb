Public Class frmPenjualan
    Dim warnaArray As Color() = {Color.LightGreen, Color.LightBlue, Color.LightPink, Color.LightYellow, Color.LightCoral}
    Dim indeksWarnaTerakhir As Integer = 0
    Private Sub frmPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        Call gantiwarnaform(sender, 247, 143, 179)
        Call frmPenjualanLoad()
        txtkodeitem.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmPenjualan_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        dellallpenjualantemp()
    End Sub

    Private Sub txtkodeitem_GotFocus(sender As Object, e As EventArgs) Handles txtkodeitem.GotFocus
        AcceptButton = btnTambah
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnTambah_Click(o, e)
        ElseIf e.KeyCode = Keys.F2 Then
            btnProses_Click(o, e)
        End If
    End Sub
    Sub penjualanAfterProses()
        dgvtemp.DataSource = Nothing
        dgvtemp.Columns.Clear()
        Dim dt As DataTable = loadDataPenjualanTemp()
        If dt.Rows.Count > 0 Then
            With dgvtemp
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                        {New DataGridViewButtonColumn() With
                                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Del", .Text = "Del", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
            End With
            cbx7an.Enabled = False
            Dim i As Integer = 0
            lbltotal.Text = "0"
            lblTotalRp.Text = "0"
            Dim total As Integer = 0
            Dim totalRP As Integer = 0
            For Each row As DataRow In dt.Rows
                If dt.Rows(i).Item("Jumlah") <> Nothing Then
                    total += CInt(dt.Rows(i).Item("Jumlah"))
                    lbltotal.Text = FormatNumber(total, 0, TriState.False, , TriState.True)
                    totalRP += CInt(dt.Rows(i).Item("Total"))
                    lblTotalRp.Text = FormatNumber(totalRP, 0, TriState.False, , TriState.True)
                End If
                i = i + 1
            Next
            For Each row As DataGridViewRow In dgvtemp.Rows
                row.DefaultCellStyle.BackColor = Color.White
            Next
            Dim newestRowIndex As Integer = FindNewestRowIndex()

            If newestRowIndex >= 0 Then
                Dim warnaBaru As Color = warnaArray(indeksWarnaTerakhir)

                dgvtemp.Rows(newestRowIndex).DefaultCellStyle.BackColor = warnaBaru

                indeksWarnaTerakhir = (indeksWarnaTerakhir + 1) Mod warnaArray.Length
            End If
        Else
            cbx7an.Enabled = True
            lbltotal.Text = "0"
            lblTotalRp.Text = "0"
        End If
    End Sub

    Private Function FindNewestRowIndex() As Integer
        Dim newestTimestamp As DateTime = DateTime.MinValue
        Dim newestRowIndex As Integer = -1

        For Each row As DataGridViewRow In dgvtemp.Rows
            If row.Cells("waktu").Value IsNot Nothing AndAlso IsDate(row.Cells("waktu").Value) Then
                Dim timestamp As DateTime = Convert.ToDateTime(row.Cells("waktu").Value)
                If timestamp > newestTimestamp Then
                    newestTimestamp = timestamp
                    newestRowIndex = row.Index
                End If
            End If
        Next

        Return newestRowIndex
    End Function
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
            End With
        ElseIf Me.txtcariitem.Text = "" Then
            ClearListView(lvitem)
        End If
    End Sub

    Private Sub dgvtemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellContentClick
        If e.ColumnIndex = 12 And e.RowIndex >= 0 Then
            delPenjualanTemp(dgvtemp.Rows(e.RowIndex).Cells(1).Value.ToString)
            penjualanAfterProses()
        End If
    End Sub

    Private Sub dgvtemp_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellEndEdit
        Dim id As String = dgvtemp.CurrentRow.Cells(1).Value.ToString
        Dim kode As String = dgvtemp.CurrentRow.Cells(4).Value.ToString
        Dim jml As String = getnumber(dgvtemp.CurrentRow.Cells(6).Value.ToString)
        Dim diskonpersen As String = dgvtemp.CurrentRow.Cells(9).Value.ToString
        Dim diskonrp As String = dgvtemp.CurrentRow.Cells(8).Value.ToString
        Dim stokAman As Boolean = cekStok(kode, jml, cbx7an.SelectedValue)
        If stokAman Then
            updatePenjualanTemp(id, jml, diskonrp, diskonpersen)
        Else
            MsgBox("Stok barang kurang.", vbCritical, "Macarons")
        End If
        penjualanAfterProses()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If cbx7an.SelectedIndex = -1 Then
            MsgBox("Silahkan pilih terlebih dahulu tujuan penjualan.", vbOKOnly, "Macarons")
        Else
            If lblProses.Text = "1" Then
                Dim kode As String = txtkodeitem.Text
                Dim jml As String = "1"
                Dim stokAman As Integer = cekStok(kode, jml, cbx7an.SelectedValue)
                If stokAman = 1 Then
                    Dim dt As DataTable = getNamaByBarcode(kode)
                    If dt.Rows.Count > 0 Then
                        frmPenjualanJml.lblNama.Text = dt.Rows(0)("nama")
                        frmPenjualanJml.lblHarga.Text = FormatNumber(CStr(dt.Rows(0)("harga_jual")), 0, TriState.False, , TriState.True)
                        frmPenjualanJml.lblbarcode.Text = kode
                        frmPenjualanJml.txtjml.Text = "1"
                        frmPenjualanJml.ShowDialog()
                        txtkodeitem.Text = ""
                        txtkodeitem.Focus()
                        penjualanAfterProses()
                    Else
                        MsgBox("Kode barang tidak ditemukan.", vbCritical, "Macarons")
                    End If
                ElseIf stokAman = 0 Then
                    MsgBox("Stok barang kurang.", vbCritical, "Macarons")
                ElseIf stokAman = -1 Then
                    MsgBox("Barang dan Tenant tidak cocok.", vbCritical, "Macarons")
                End If
            End If
        End If
        'Dim kode As String = txtkodeitem.Text
        'Dim jml As String = "1"
        'Dim stokAman As Boolean = cekStok(kode, jml, cbx7an.SelectedValue)
        'If stokAman Then
        '    Dim dt As DataTable = getNamaByBarcode(kode)
        '    If dt.Rows.Count > 0 Then
        '        Dim tambahtemp As Boolean = tambahPenjualanTemp(dtp1.Value, cbx7an.SelectedValue, kode, jml, CStr(dt.Rows(0)("harga_jual")))
        '        If tambahtemp Then
        '            penjualanAfterProses()
        '            txtkodeitem.Text = ""
        '            txtkodeitem.Focus()
        '        End If
        '    Else
        '        MsgBox("Kode barang tidak ditemukan.", vbCritical, "Macarons")
        '    End If
        'Else
        '    MsgBox("Stok barang kurang.", vbCritical, "Macarons")
        'End If
    End Sub
    Private Sub lvitem_DoubleClick(sender As Object, e As EventArgs) Handles lvitem.DoubleClick
        If cbx7an.SelectedIndex = -1 Then
            MsgBox("Silahkan pilih terlebih dahulu tujuan penjualan.", vbOKOnly, "Macarons")
        Else
            If lblProses.Text = "1" Then
                Dim kode As String = lvitem.SelectedItems(0).SubItems(5).Text
                Dim jml As String = "1"
                Dim stokAman As Integer = cekStok(kode, jml, cbx7an.SelectedValue)
                If stokAman = 1 Then
                    Dim dt As DataTable = getNamaByBarcode(kode)
                    If dt.Rows.Count > 0 Then
                        frmPenjualanJml.lblNama.Text = dt.Rows(0)("nama")
                        frmPenjualanJml.lblHarga.Text = FormatNumber(CStr(dt.Rows(0)("harga_jual")), 0, TriState.False, , TriState.True)
                        frmPenjualanJml.lblbarcode.Text = kode
                        frmPenjualanJml.txtjml.Text = "1"
                        frmPenjualanJml.ShowDialog()
                        txtkodeitem.Text = ""
                        txtkodeitem.Focus()
                        penjualanAfterProses()
                    Else
                        MsgBox("Kode barang tidak ditemukan.", vbCritical, "Macarons")
                    End If
                ElseIf stokAman = 0 Then
                    MsgBox("Stok barang kurang.", vbCritical, "Macarons")
                ElseIf stokAman = -1 Then
                    MsgBox("Barang dan Tenant tidak cocok.", vbCritical, "Macarons")
                End If
            End If
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim proses As MsgBoxResult
        If Me.dgvtemp.Rows.Count > 0 Then
            proses = MsgBox("Proses penjualan ke " & cbx7an.Text.ToUpper & " ?", vbYesNo, "Macarons")
            If proses = vbYes Then
                frmPenjualanPembayaran.lbltotal.Text = lblTotalRp.Text
                frmPenjualanPembayaran.lbltotal2.Text = lblTotalRp.Text
                frmPenjualanPembayaran.lblTotalAsli.Text = lblTotalRp.Text
                frmPenjualanPembayaran.ShowDialog(Me)
                penjualanAfterProses()
            End If
        Else
            MsgBox("Isi terlebih dahulu penjualan", vbOKOnly, "EasyShopPro")
        End If
        txtcariitem.Text = ""
        txtkodeitem.Focus()
    End Sub

End Class