Public Class frmEditStok
    Dim dt As DataTable
    Private Sub frmEditStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 232, 67, 147)
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


    Private Sub txtstok_GotFocus(sender As Object, e As EventArgs) Handles txtstok.GotFocus, txtket.GotFocus
        AcceptButton = btnProses
    End Sub

    Private Sub txtcari_GotFocus(sender As Object, e As EventArgs) Handles txtcari.GotFocus
        AcceptButton = btncari
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim edit As Integer
        If lblstokid.Text <> "0" Then
            edit = editStok(lblstokid.Text, txtstok.Text, txtket.Text)
            If edit <> 0 Then
                MsgBox("Proses edit stok sukses.", vbOKOnly, "Macarons")
                dt = loadDataStok(txtcari.Text)
                tampilkanData(dt)
                txtstok.Text = ""
                txtket.Text = ""
                lblstokid.Text = "0"
            Else
                MsgBox("Proses edit data gagal. Hubungi developer.", vbCritical, "Macarons")
            End If
        End If
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        dt = loadDataStok(txtcari.Text)
        tampilkanData(dt)
    End Sub
    Private Sub tampilkanData(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            dgvtemp.DataSource = Nothing
            dgvtemp.Columns.Clear()
            lblproses.Text = "0"
            With dgvtemp
                .DataSource = dt
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
                .Columns(1).Visible = False
            End With
        End If
    End Sub

    Private Sub dgvtemp_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim kode As String = dgvtemp.Rows(e.RowIndex).Cells(2).Value.ToString
            Dim dt2 As DataTable = loadDataStok(kode)
            If dt2.Rows.Count > 0 Then
                lblstokid.Text = CStr(dt2.Rows(0).Item("id"))
                lblnamaitem.Text = CStr(dt2.Rows(0).Item("Nama"))
                lbltgl.Text = CStr(dt2.Rows(0).Item("tgl_beli"))
                txtstok.Text = CStr(dt2.Rows(0).Item("Stok"))
                txtket.Text = ""
                txtstok.Focus()
            Else
                MsgBox("Data stok dengan kode " & kode & " tidak ditemukan.", vbCritical, "Macarons")
            End If
        End If
    End Sub

End Class