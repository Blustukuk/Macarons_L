Public Class frmStokOpnameSpc
#Region "Jam"
    Private Sub tJam_Tick(sender As Object, e As EventArgs) Handles tJam.Tick
        lblSekarang.Text = "Sekarang : " & CDate(Now).ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

#End Region
    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim prosesStokOpname As MsgBoxResult = MsgBox("Yakin akan menyimpan data stok opname ?", vbYesNo, "Macarons")
        If prosesStokOpname = vbYes Then
            Dim proses As Boolean = prosesSimpanStokOpnamSpc(lblUserID.Text)
            If proses Then
                MsgBox("Proses simpan data stok opname sukses.", vbOKOnly, "Macarons")
            Else
                MsgBox("Proses simpan data stok opname GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
            End If
            opnamAfterProses()
        Else
            txtkodeitem.Focus()
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
            End With
        ElseIf Me.txtcariitem.Text = "" Then
            Call ClearListView(lvitem)
        End If
    End Sub

    Private Sub txtkodeitem_GotFocus(sender As Object, e As EventArgs) Handles txtkodeitem.GotFocus
        AcceptButton = btnKodeOK
    End Sub
    Private Sub txtkodeitem_LostFocus(sender As Object, e As EventArgs) Handles txtkodeitem.LostFocus
        AcceptButton = Nothing
    End Sub

    Private Sub btnKodeOK_Click(sender As Object, e As EventArgs) Handles btnKodeOK.Click
        Dim kode As String = txtkodeitem.Text
        Dim cek As String = cekStok(kode)
        If cek <> "" Then
            Dim tambahtemp As Boolean = tambahOpnamSpcTemp(kode, 1)
            If tambahtemp Then
                opnamAfterProses()
                txtkodeitem.Text = ""
                txtkodeitem.Focus()
            End If
        Else
            MsgBox("Stok barang tidak ditemukan, proses SO kode barang " & kode & " tidak bisa dilanjutkan.")
        End If
    End Sub
    Sub opnamAfterProses()
        lblProses.Text = "1"
        dgvOpnam.DataSource = Nothing
        dgvOpnam.Columns.Clear()
        Dim dt As DataTable = loadDataOpnameSpcTemp()
        If dt.Rows.Count > 0 Then
            With dgvOpnam
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                        {New DataGridViewButtonColumn() With
                                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Del", .Text = "Del", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
            End With
        Else
            dgvOpnam.DataSource = Nothing
            dgvOpnam.Columns.Clear()
        End If
        lblProses.Text = "0"
        txtkodeitem.Text = ""
    End Sub

    Private Sub dgvOpnam_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOpnam.CellContentClick
        If e.ColumnIndex = 5 And e.RowIndex >= 0 Then
            delOpnameSpcTemp(dgvOpnam.Rows(e.RowIndex).Cells(0).Value.ToString)
            opnamAfterProses()
        End If
    End Sub

    Private Sub lvitem_DoubleClick(sender As Object, e As EventArgs) Handles lvitem.DoubleClick
        Dim kode As String = lvitem.SelectedItems(0).SubItems(5).Text
        Dim tambahtemp As Boolean = tambahOpnamSpcTemp(kode, 1)
        If tambahtemp Then
            opnamAfterProses()
            txtkodeitem.Text = ""
            txtkodeitem.Focus()
        End If
    End Sub

    Private Sub frmStokOpnameSpc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler

        opnamAfterProses()
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnProses_Click(o, e)
        ElseIf e.KeyCode = Keys.F4 Then
            txtkodeitem.Focus()
        ElseIf e.KeyCode = Keys.F5 Then
            txtcariitem.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Application.OpenForms().OfType(Of frmLaporanSO).Any Then
            AppActivate(frmLaporanSO.Text)
        Else
            frmLaporanSO.ShowDialog()
        End If
    End Sub
End Class