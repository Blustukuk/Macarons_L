Public Class frmPengadaan
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmPengadaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        Call gantiwarnaform(sender, 196, 69, 105)
        Call frmPengadaanLoad()
    End Sub

    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F2 Then
            If dgvtemp.Rows.Count > 0 Then
                Dim proses As Boolean = prosesPengadaan(txtJudul.Text, cbxLogo.SelectedValue, frmMain.lblUserID.Text)
                If proses Then
                    lblproses.Text = "0"
                    lbltotal.Text = "0"
                    frmPengadaanLoad()
                    txtJudul.Text = ""
                    cbxNoNota.SelectedIndex = -1
                    cbxLogo.SelectedIndex = 0
                    txtMargin.Text = ""
                    delAlllPengadaanTemp(getMacAddress)
                    lblproses.Text = "1"
                    pengadaanAfterProses()
                End If
            End If
        End If
    End Sub
    Private Sub cbxNoNota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNoNota.SelectedIndexChanged
        If lblproses.Text = "1" Then
            Dim nonota As String = Split(cbxNoNota.SelectedValue, "^")(0)
            delAlllPengadaanTemp(getMacAddress)
            addPengadaanTemp(nonota, DTP1.Value)
            pengadaanAfterProses()
        End If
    End Sub
    Sub pengadaanAfterProses()
        dgvtemp.DataSource = Nothing
        dgvtemp.Columns.Clear()
        Dim dt As DataTable = loadDataPengadaanTemp(getMacAddress)
        If dt.Rows.Count > 0 Then
            With dgvtemp
                .DataSource = dt
                '.Columns.AddRange(New DataGridViewColumn(0) _
                '                                        {New DataGridViewButtonColumn() With
                '                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Del", .Text = "Del", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
                .Columns(5).Visible = False
            End With
            Dim i As Integer = 0
            lbltotal.Text = "0"
            Dim total As Integer
            For Each row As DataRow In dt.Rows
                If dt.Rows(i).Item("Jumlah") <> Nothing Then
                    total += CInt(dt.Rows(i).Item("Jumlah"))
                    lbltotal.Text = FormatNumber(total, 0, TriState.False, , TriState.True)
                End If
                i = i + 1
            Next
        End If
    End Sub

    Private Sub frmPengadaan_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Call delAlllPengadaanTemp(getMacAddress)
    End Sub

    Private Sub btnSetMargin_Click(sender As Object, e As EventArgs) Handles btnSetMargin.Click
        If dgvtemp.Rows.Count > 0 Then
            setMarginPengadaanTemp(txtMargin.Text, getMacAddress)
            pengadaanAfterProses()
        End If
    End Sub

    Private Sub dgvtemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellContentClick
        'If e.ColumnIndex = 14 And e.RowIndex >= 0 Then
        '    delPengadaanTemp(dgvtemp.Rows(e.RowIndex).Cells(0).Value.ToString)
        '    pengadaanAfterProses()
        'End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If dgvtemp.Rows.Count > 0 Then
            Dim proses As Boolean = prosesPengadaan(txtJudul.Text, cbxLogo.SelectedValue, frmMain.lblUserID.Text)
            If proses Then
                lblproses.Text = "0"
                lbltotal.Text = "0"
                frmPengadaanLoad()
                txtJudul.Text = ""
                cbxNoNota.SelectedIndex = -1
                cbxLogo.SelectedIndex = 0
                txtMargin.Text = ""
                delAlllPengadaanTemp(getMacAddress)
                lblproses.Text = "1"
                pengadaanAfterProses()
            End If
        End If
    End Sub

    Private Sub dgvtemp_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellEndEdit
        If dgvtemp.Rows.Count > 0 Then
            updatePengadaanTemp(getnumber(dgvtemp.CurrentRow.Cells(10).Value.ToString), getnumber(dgvtemp.CurrentRow.Cells(12).Value.ToString), "", dgvtemp.CurrentRow.Cells(0).Value.ToString)
            pengadaanAfterProses()
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

    Private Sub lvitem_DoubleClick(sender As Object, e As EventArgs) Handles lvitem.DoubleClick
        If lblproses.Text = "1" Then
            frmPengadaanJml.lblNama.Text = lvitem.SelectedItems(0).SubItems(0).Text
            frmPengadaanJml.lblBrand.Text = lvitem.SelectedItems(0).SubItems(1).Text
            frmPengadaanJml.lblArtikel.Text = lvitem.SelectedItems(0).SubItems(2).Text
            frmPengadaanJml.lblBrandID.Text = lvitem.SelectedItems(0).SubItems(3).Text
            frmPengadaanJml.lblArtikelID.Text = lvitem.SelectedItems(0).SubItems(4).Text
            frmPengadaanJml.ShowDialog()
            pengadaanAfterProses()
            txtcariitem.Text = ""
            txtcariitem.Focus()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If cbxNoNota.SelectedIndex <> -1 And dgvtemp.Rows.Count > 0 Then
            printPengadaan()
        End If
    End Sub
End Class