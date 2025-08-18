Public Class frmPembelian
    Private Sub frmPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        Call gantiwarnaform(sender, 231, 127, 103)
        Call frmPembelianLoad()
        pembelianAfterProses()
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F2 Then
            btnProses_Click(o, e)
        ElseIf e.KeyCode = Keys.F1 Then
            If txtNama.Text = "" Or txtJml.Text = "" Or IsNumeric(txtJml.Text) = False Or txtHarga.Text = "" Or IsNumeric(txtHarga.Text) = False Then
                MsgBox("Isi dahulu data pembelian dengan benar")
            Else
                Dim tambahtemp As Boolean = tambahPembelianTemp(DTP1.Value, cbxSupplier.SelectedValue, cbxBrand.SelectedValue, cbxArtikel.SelectedValue, txtNama.Text, txtJml.Text, txtHarga.Text)
                If tambahtemp Then
                    pembelianAfterProses()
                    txtNama.Text = ""
                    txtJml.Text = ""
                    txtHarga.Text = ""
                    txtNama.Focus()
                Else
                    MsgBox("Proses tambah antrian pembelian gagal, cek kembali data pembelian.", vbOKOnly, "Macarons")
                End If
            End If
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub cbxBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBrand.SelectedIndexChanged
        If lblproses.Text = "1" Then
            Dim dt As DataTable = loadDataArtikelByIDBrand(cbxBrand.SelectedValue)
            lblproses.Text = "0"
            With cbxArtikel
                .DataSource = dt
                .DisplayMember = "artikel"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
            lblproses.Text = "1"
        End If
    End Sub

    Private Sub btnAntrian_Click(sender As Object, e As EventArgs) Handles btnAntrian.Click
        If txtNama.Text = "" Or txtJml.Text = "" Or IsNumeric(txtJml.Text) = False Or txtHarga.Text = "" Or IsNumeric(txtHarga.Text) = False Then
            MsgBox("Isi dahulu data pembelian dengan benar")
        Else
            Dim tambahtemp As Boolean = tambahPembelianTemp(DTP1.Value, cbxSupplier.SelectedValue, cbxBrand.SelectedValue, cbxArtikel.SelectedValue, txtNama.Text, txtJml.Text, txtHarga.Text)
            If tambahtemp Then
                pembelianAfterProses()
                txtNama.Text = ""
                txtJml.Text = ""
                txtHarga.Text = ""
                txtNama.Focus()
            Else
                MsgBox("Proses tambah antrian pembelian gagal, cek kembali data pembelian.", vbOKOnly, "Macarons")
            End If
        End If
    End Sub
    Sub pembelianAfterProses()
        dgvtemp.DataSource = Nothing
        dgvtemp.Columns.Clear()
        Dim dt As DataTable = loadDataPembelianTemp(getMacAddress)
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
            cbxSupplier.Enabled = False
        Else
            cbxSupplier.Enabled = True
        End If
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
    End Sub

    Private Sub txtJudul_GotFocus(sender As Object, e As EventArgs) Handles txtJudul.GotFocus, txtNoNota.GotFocus, cbxSupplier.GotFocus, cbxBrand.GotFocus, cbxArtikel.GotFocus, txtNama.GotFocus, txtJml.GotFocus, txtHarga.GotFocus, txtKet.GotFocus
        AcceptButton = btnAntrian
    End Sub

    Private Sub frmPembelian_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Call delAlllPembelianTemp(getMacAddress)
    End Sub

    Private Sub dgvtemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellContentClick
        If e.ColumnIndex = 12 And e.RowIndex >= 0 Then
            delPembelianTemp(dgvtemp.Rows(e.RowIndex).Cells(0).Value.ToString)
            pembelianAfterProses()
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If Me.dgvtemp.Rows.Count > 0 Then
            If txtNoNota.Text <> "" Then
                Dim proses As Boolean = prosesPembelian(txtJudul.Text, txtNoNota.Text, txtKet.Text, frmMain.lblUserID.Text)
                If proses Then
                    pembelianAfterProses()
                    txtJudul.Text = ""
                    txtNoNota.Text = ""
                    cbxSupplier.SelectedIndex = -1
                    cbxBrand.SelectedIndex = -1
                    cbxArtikel.SelectedIndex = -1
                End If
            Else
                MsgBox("Proses pembelian wajib mengisi NOMOR NOTA.", vbOKOnly, "Macarons")
            End If
        End If
    End Sub

    Private Sub cbxArtikel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxArtikel.SelectedIndexChanged
        If lblproses.Text = "1" Then
            Dim nama As String = getNamaItem(cbxSupplier.SelectedValue, cbxArtikel.SelectedValue)
            txtNama.Text = nama
        End If
    End Sub

    Private Sub txtHarga_TextChanged(sender As Object, e As EventArgs) Handles txtHarga.TextChanged
        If txtHarga.TextLength > 0 And IsNumeric(txtHarga.Text) Then
            txtHarga.Text = FormatNumber(txtHarga.Text, 0, TriState.False, , TriState.True)
            txtHarga.Select(txtHarga.Text.Length, 0)
        End If
    End Sub

    Private Sub txtJml_TextChanged(sender As Object, e As EventArgs) Handles txtJml.TextChanged
        If txtJml.TextLength > 0 And IsNumeric(txtJml.Text) Then
            txtJml.Text = FormatNumber(txtJml.Text, 0, TriState.False, , TriState.True)
            txtJml.Select(txtJml.Text.Length, 0)
        End If
    End Sub

    Private Sub dgvtemp_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellEndEdit
        If dgvtemp.Rows.Count > 0 Then
            updatePembelianTemp(getnumber(dgvtemp.CurrentRow.Cells(9).Value.ToString), getnumber(dgvtemp.CurrentRow.Cells(10).Value.ToString), dgvtemp.CurrentRow.Cells(0).Value.ToString)
            pembelianAfterProses()
        End If
    End Sub

End Class