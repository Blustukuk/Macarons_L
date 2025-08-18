Public Class frmPOS
    Private MouseIsDown As Boolean = False
    Private MouseIsDownLoc As Point = Nothing
    Private isProgrammaticChange As Boolean = False
    Private Sub tJam_Tick(sender As Object, e As EventArgs) Handles tJam.Tick
        lblSekarang.Text = CDate(Now).ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

    Private Sub Guna2Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            If MouseIsDown = False Then
                MouseIsDown = True
                MouseIsDownLoc = New Point(e.X, e.Y)
            End If
            Me.Location = New Point(Me.Location.X + e.X - MouseIsDownLoc.X, Me.Location.Y + e.Y - MouseIsDownLoc.Y)
        End If
    End Sub
    Private Sub Guna2Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseUp
        MouseIsDown = False
    End Sub
    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        Dim dt As DataTable = getNamaBank()

        If dt.Rows.Count > 0 Then
            With cmbbank
                .DataSource = dt
                .DisplayMember = "nama_bank"
                .ValueMember = "nama_bank"
                .SelectedIndex = -1
            End With
        Else
            MsgBox("Daftar Bank tidak ditemukan", vbOKOnly, "Macarons")
        End If
        penjualanAfterProses()
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnProses_Click(o, e)
        ElseIf e.KeyCode = Keys.F2 Then
            txtkodeitem.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            txtcariitem.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            cbdiskon_check()
        ElseIf e.KeyCode = Keys.F5 Then
            cbEDC_check()
        ElseIf e.KeyCode = Keys.F6 Then
            btnRetur_Click(o, e)
        ElseIf e.KeyCode = Keys.F9 Then
            btnLaporan_Click(o, e)
        ElseIf e.KeyCode = Keys.F10 Then
            btnCetakUlang_Click(o, e)
        ElseIf e.KeyCode = Keys.F11 Then
            btnLain_Click(o, e)
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If dgvTemp.Rows.Count > 0 Then
            If cbEDC.Checked Then
                Dim proses As Boolean = prosespenjualanedc(lblUserID.Text, getnumber(lbltotalPembulatan.Text.Replace("Rp. ", "")), cmbbank.Text, txtnoedc.Text, lblNoMember.Text,
                                                           If(txtdiskonpersen.Text = "", "0", txtdiskonpersen.Text),
                                                           If(txtdiskonrupiah.Text = "", "0", txtdiskonrupiah.Text), lblKasir.Text)
                If proses <> 0 Then
                    penjualanAfterProses()
                    txtkodeitem.Focus()
                Else
                    MsgBox("Proses penjualan gagal. Hubungi developer.", vbCritical, "Macarons")
                End If
            Else
                frmBayar.lbltotal.Text = lbltotalPembulatan.Text
                frmBayar.ShowDialog(Me)
                penjualanAfterProses()
                txtkodeitem.Focus()
            End If
        Else
            MsgBox("Isi terlebih dahulu daftar penjualan", vbOKOnly, "Macarons")
        End If
    End Sub

    Private Sub txtcariitem_TextChanged(sender As Object, e As EventArgs) Handles txtcariitem.TextChanged
        If Me.txtcariitem.TextLength > 6 Then
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
        Dim stokAman As Boolean = cekStok(kode, 1)
        If stokAman Then
            Dim tambahtemp As Boolean = tambahPenjualanPOSTemp(kode, 1)
            If tambahtemp Then
                penjualanAfterProses()
                txtkodeitem.Text = ""
                txtkodeitem.Focus()
            End If
        Else
            MsgBox("Stok kurang.", vbCritical, "Macarons")
        End If
    End Sub

    Private Sub frmPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Environment.Exit(0)
        End If
    End Sub

    Sub penjualanAfterProses()
        dgvTemp.DataSource = Nothing
        dgvTemp.Columns.Clear()
        dgvdiskon.DataSource = Nothing
        dgvdiskon.Columns.Clear()
        Dim dt As DataTable = loadDataPenjualanTemp(getMacAddress)
        If dt.Rows.Count > 0 Then
            With dgvTemp
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                        {New DataGridViewButtonColumn() With
                                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Del", .Text = "Del", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
            End With
            Dim dt2 As DataTable = loadDataDiskonKembarPenjualan(getMacAddress)
            If dt.Rows.Count > 0 Then
                With dgvdiskon
                    .DataSource = dt2
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                End With
            End If
            Dim total As Integer = 0
            Dim totalrp As Integer = 0
            Dim totaldiskonkembar As Integer = 0
            Dim totaldiskonlain As Integer = 0
            For Each row As DataRow In dt.Rows
                If row("Jumlah") <> Nothing And row("Harga Jual") > 0 Then
                    total += CInt(row("Jumlah"))
                    totalrp += CInt(row("Total"))
                    lbltotalpcs.Text = FormatNumber(total, 0, TriState.False, , TriState.True)
                    lblSubTotal.Text = "Rp. " & FormatNumber(totalrp, 0, TriState.False, , TriState.True)
                End If
                If row("Harga Jual") < 0 Then
                    totaldiskonlain += CInt(row("Harga Jual")) * -1
                End If
            Next
            If dt2.Rows.Count > 0 Then
                For Each row As DataRow In dt2.Rows
                    If row("diskon") <> Nothing Then
                        totaldiskonkembar += CInt(row("diskon"))
                        lblDiskonKembar.Text = "Rp. " & FormatNumber(totaldiskonkembar, 0, TriState.False, , TriState.True)
                    End If
                Next
            End If
            Dim grandTotal As Integer = totalrp - totaldiskonkembar - totaldiskonlain
            Dim diskonpersen As Integer
            Dim diskonrupiah As Integer
            Dim grandTotalwithDiskon As Integer
            If (txtdiskonpersen.Text <> "" And IsNumeric(txtdiskonpersen.Text)) Or (txtdiskonrupiah.Text <> "" And IsNumeric(txtdiskonrupiah.Text)) Then
                If Me.txtdiskonpersen.Text = "" Then
                    diskonpersen = 0
                Else
                    diskonpersen = (grandTotal * CInt(txtdiskonpersen.Text) / 100)
                End If
                If txtdiskonrupiah.Text = "" Then
                    diskonrupiah = 0
                Else
                    diskonrupiah = CInt(txtdiskonrupiah.Text)
                End If
                grandTotalwithDiskon = CStr(CInt(grandTotal) - diskonpersen - diskonrupiah)
            Else
                grandTotalwithDiskon = grandTotal
            End If
            lblDiskonLain.Text = "Rp. " & FormatNumber(totaldiskonlain + diskonpersen + diskonrupiah, 0, TriState.False, , TriState.True)
            lblTotal.Text = "Rp. " & FormatNumber(grandTotalwithDiskon, 0, TriState.False, , TriState.True)
            lbltotalPembulatan.Text = "Rp. " & FormatNumber(BulatkanKebawah500(grandTotalwithDiskon), 0, TriState.False, , TriState.True)
        Else
            dgvdiskon.DataSource = Nothing
            dgvdiskon.Columns.Clear()
            lbltotalpcs.Text = "0"
            lblDiskonLain.Text = "Rp. 0"
            lblTotal.Text = "Rp. 0"
            lbltotalPembulatan.Text = "Rp. 0"
            lblSubTotal.Text = "Rp. 0"
            lblDiskonKembar.Text = "Rp. 0"
            cbdiskon.Checked = False
            cbEDC.Checked = False
        End If
    End Sub

    Private Sub lvitem_DoubleClick(sender As Object, e As EventArgs) Handles lvitem.DoubleClick
        Dim kode As String = lvitem.SelectedItems(0).SubItems(5).Text
        Dim stokAman As Boolean = cekStok(kode, 1)
        If stokAman Then
            Dim tambahtemp As Boolean = tambahPenjualanPOSTemp(kode, 1)
            If tambahtemp Then
                penjualanAfterProses()
                txtkodeitem.Text = ""
                txtkodeitem.Focus()
            End If
        Else
            MsgBox("Stok barang kurang.", vbCritical, "Macarons")
        End If
    End Sub

    Private Sub dgvTemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTemp.CellContentClick
        If e.ColumnIndex = 6 And e.RowIndex >= 0 Then
            delPenjualanTemp(dgvTemp.Rows(e.RowIndex).Cells(0).Value.ToString)
            penjualanAfterProses()
        End If
    End Sub

    Private Sub txtdiskonpersen_TextChanged(sender As Object, e As EventArgs) Handles txtdiskonpersen.TextChanged, txtdiskonrupiah.TextChanged
        penjualanAfterProses()
    End Sub

    Private Sub frmPOS_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtkodeitem.Focus()
    End Sub

    Private Sub btnRetur_Click(sender As Object, e As EventArgs) Handles btnRetur.Click
        If Application.OpenForms().OfType(Of frmRetur).Any Then
            AppActivate(frmRetur.Text)
        Else
            frmRetur.Show()
        End If
    End Sub

    Private Sub btnLain_Click(sender As Object, e As EventArgs) Handles btnLain.Click
        If Application.OpenForms().OfType(Of frmLain).Any Then
            AppActivate(frmLain.Text)
        Else
            frmLain.Show()
        End If
    End Sub

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        If Application.OpenForms().OfType(Of frmPrintLapShift).Any Then
            AppActivate(frmPrintLapShift.Text)
        Else
            frmPrintLapShift.Show()
        End If
    End Sub

    Private Sub btnCetakUlang_Click(sender As Object, e As EventArgs) Handles btnCetakUlang.Click
        If Application.OpenForms().OfType(Of frmCetakUlang).Any Then
            AppActivate(frmCetakUlang.Text)
        Else
            frmCetakUlang.Show()
        End If
    End Sub
    Private Sub cbdiskon_CheckedChanged(sender As Object, e As EventArgs) Handles cbdiskon.CheckedChanged
        If Not isProgrammaticChange Then
            isProgrammaticChange = True

            If cbdiskon.Checked = False Then
                cbdiskon.Checked = False
                txtdiskonpersen.Text = ""
                txtdiskonrupiah.Text = ""
                gbdiskon.Enabled = False
            Else
                cbdiskon.Checked = True
                gbdiskon.Enabled = True
                txtdiskonpersen.Focus()
            End If
            isProgrammaticChange = False
        End If
    End Sub

    Private Sub cbdiskon_check()
        If lblProses.Text = "0" Then
            lblProses.Text = "1"
            If cbdiskon.Checked Then
                cbdiskon.Checked = False
                txtdiskonpersen.Text = ""
                txtdiskonrupiah.Text = ""
                gbdiskon.Enabled = False
            Else
                cbdiskon.Checked = True
                gbdiskon.Enabled = True
                txtdiskonpersen.Focus()
            End If
            lblProses.Text = "0"
        End If
    End Sub

    Private Sub cbEDC_CheckedChanged(sender As Object, e As EventArgs) Handles cbEDC.CheckedChanged
        If Not isProgrammaticChange Then
            isProgrammaticChange = True

            If cbEDC.Checked = False Then
                panelEDC.Enabled = False
                cmbbank.SelectedIndex = -1
                txtnoedc.Text = ""
            Else
                panelEDC.Enabled = True
                cmbbank.DroppedDown = True
                cmbbank.Focus()
            End If

            isProgrammaticChange = False
        End If
    End Sub

    Private Sub cbEDC_check()
        If lblProses.Text = "0" Then
            lblProses.Text = "1"
            If cbEDC.Checked Then
                cbEDC.Checked = False
                cmbbank.SelectedIndex = -1
                txtnoedc.Text = ""
                panelEDC.Enabled = False
            Else
                cbEDC.Checked = True
                panelEDC.Enabled = True
                cmbbank.DroppedDown = True
                cmbbank.Focus()
            End If
            lblProses.Text = "0"
        End If
    End Sub
    Private Sub dgvTemp_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTemp.CellEndEdit
        Dim id As String = dgvTemp.CurrentRow.Cells(0).Value.ToString
        Dim kode As String = dgvTemp.CurrentRow.Cells(1).Value.ToString
        Dim jml As String = dgvTemp.CurrentRow.Cells(3).Value.ToString
        Dim diskonrp As String = dgvTemp.CurrentRow.Cells(5).Value.ToString
        Dim diskonpersen As String = dgvTemp.CurrentRow.Cells(6).Value.ToString
        Dim stokAman As Boolean = cekStok(kode, jml)
        If stokAman Then
            Dim updateTemp As Boolean = updatePenjualanPOSTemp(id, diskonrp, diskonpersen)
            If updateTemp Then
                penjualanAfterProses()
            End If
        Else
            MsgBox("Stok kurang.", vbOKOnly, "Macarons")
        End If
    End Sub

End Class
