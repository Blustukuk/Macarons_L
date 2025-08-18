
Public Class frmPOS2
    Private MouseIsDown As Boolean = False
    Private MouseIsDownLoc As Point = Nothing
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
        Dim dt2 As DataTable = getNamaBank()

        If dt.Rows.Count > 0 Then
            With cmbbankEDC
                .DataSource = dt
                .DisplayMember = "nama_bank"
                .ValueMember = "nama_bank"
                .SelectedIndex = -1
            End With
            With cmbBankQRIS
                .DataSource = dt2
                .DisplayMember = "nama_bank"
                .ValueMember = "nama_bank"
                .SelectedIndex = -1
            End With
        Else
            MsgBox("Daftar Bank tidak ditemukan", vbOKOnly, "Macarons")
        End If
        penjualanAfterProses(True)
        cbxDiskonKembar.Checked = False
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
            btnPenjualanManual_Click(o, e)
        ElseIf e.KeyCode = Keys.F5 Then
            cbEDC_check()
        ElseIf e.KeyCode = Keys.F6 Then
            cbDiskon_check()
        ElseIf e.KeyCode = Keys.F7 Then
            cbQRIS_check()
        ElseIf e.KeyCode = Keys.F8 Then
            btnRetur_Click(o, e)
        ElseIf e.KeyCode = Keys.F9 Then
            btnLaporan_Click(o, e)
        ElseIf e.KeyCode = Keys.F10 Then
            btnCetakUlang_Click(o, e)
        ElseIf e.KeyCode = Keys.F11 Then
            btnMember_Click(o, e)
        ElseIf e.KeyCode = Keys.F12 Then
            cbCash_check()
        End If
    End Sub
    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If dgvTemp.Rows.Count > 0 Then
            Dim proses As Boolean
            Dim pilihan As MsgBoxResult
            If cbCash.Checked = False And cbEDC.Checked = False And cbQRIS.Checked = False Then
                MsgBox("Pilih terlebih dahulu cara bayarnya.", vbCritical, "Macarons")
            ElseIf cbCash.Checked Then
                pilihan = MsgBox("Proses pembayaran dengan cara CASH ?", vbYesNo, "Macarons")
                If pilihan = vbYes Then
                    proses = prosespenjualan(lblUserID.Text, getnumber(txtbayar.Text.Replace("Rp. ", "")),
                                             getnumber(lblTotal.Text.Replace("Rp. ", "")), getnumber(lbltotalPembulatan.Text.Replace("Rp. ", "")),
                                             If(txtdiskonpersen.Text = "", "0", txtdiskonpersen.Text),
                                             If(txtdiskonrupiah.Text = "", "0", txtdiskonrupiah.Text), lblKasir.Text, "0", "0", cbxDiskonKembar.Checked, lblNoMember.Text)
                End If
            ElseIf cbEDC.Checked Then
                pilihan = MsgBox("Proses pembayaran dengan cara EDC ?", vbYesNo, "Macarons")
                If pilihan = vbYes Then
                    proses = prosespenjualan(lblUserID.Text, getnumber(lbltotalPembulatan.Text.Replace("Rp. ", "")),
                                             getnumber(lblTotal.Text.Replace("Rp. ", "")), getnumber(lbltotalPembulatan.Text.Replace("Rp. ", "")),
                                             If(txtdiskonpersen.Text = "", "0", txtdiskonpersen.Text),
                                             If(txtdiskonrupiah.Text = "", "0", txtdiskonrupiah.Text), lblKasir.Text, "1", "0", cbxDiskonKembar.Checked, lblNoMember.Text,
                                              "EDC (" & cmbbankEDC.Text & ")", txtnoedc.Text)
                End If
            ElseIf cbQRIS.Checked Then
                pilihan = MsgBox("Proses pembayaran dengan cara QRIS ?", vbYesNo, "Macarons")
                If pilihan = vbYes Then
                    proses = prosespenjualan(lblUserID.Text, getnumber(lbltotalPembulatan.Text.Replace("Rp. ", "")),
                                             getnumber(lblTotal.Text.Replace("Rp. ", "")), getnumber(lbltotalPembulatan.Text.Replace("Rp. ", "")),
                                             If(txtdiskonpersen.Text = "", "0", txtdiskonpersen.Text),
                                             If(txtdiskonrupiah.Text = "", "0", txtdiskonrupiah.Text), lblKasir.Text, "0", "1", cbxDiskonKembar.Checked, lblNoMember.Text,
                                             "QRIS (" & cmbBankQRIS.Text & ")")
                End If
            End If
            If proses <> 0 Then
                penjualanAfterProses(True)
                modeMemberNonaktif()
                txtdiskonpersen.Text = "0"
                txtdiskonrupiah.Text = "0"
                txtkodeitem.Focus()
            Else
                MsgBox("Proses penjualan gagal. Hubungi developer.", vbCritical, "Macarons")
            End If
        Else
            MsgBox("Isi terlebih dahulu daftar penjualan", vbOKOnly, "Macarons")
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
    Private Sub txtkodeitem_GotFocus(sender As Object, e As EventArgs) Handles txtkodeitem.GotFocus
        AcceptButton = btnKodeOK
    End Sub

    Private Sub txtkodeitem_LostFocus(sender As Object, e As EventArgs) Handles txtkodeitem.LostFocus
        AcceptButton = Nothing
    End Sub

    Private Sub btnKodeOK_Click(sender As Object, e As EventArgs) Handles btnKodeOK.Click
        Dim kode As String = txtkodeitem.Text
        Dim stokAman As String = cekStok(kode, 1)
        If stokAman = "Y" Then
            Dim tambahtemp As Boolean = tambahPenjualanPOSTemp(kode, 1)
            If tambahtemp Then
                penjualanAfterProses(True)
                txtkodeitem.Text = ""
                txtkodeitem.Focus()
            End If
        ElseIf stokAman = "M" Then 'Member
            modeMemberAktif(kode)
            penjualanAfterProses(True)
            txtkodeitem.Text = ""
            txtkodeitem.Focus()
        Else
            MsgBox("Stok kurang.", vbCritical, "Macarons")
        End If
    End Sub

    Private Sub frmPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Environment.Exit(0)
        End If
    End Sub

    Sub penjualanAfterProses(ByVal member As Boolean)
        lblProses.Text = "1"
        dgvTemp.DataSource = Nothing
        dgvTemp.Columns.Clear()
        dgvdiskon.DataSource = Nothing
        dgvdiskon.Columns.Clear()
        Dim dt As DataTable = loadDataPenjualanTemp(lblKasir.Text)
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
            Dim dt2 As DataTable
            If cbxDiskonKembar.Checked Then
                dt2 = loadDataDiskonKembarPenjualan(lblKasir.Text)
                If dt2.Rows.Count > 0 Then
                    With dgvdiskon
                        .DataSource = dt2
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    End With
                End If
            Else
                dt2 = Nothing
            End If
            Dim totalPCS As Integer = 0
            Dim totalasli As Integer = 0
            Dim totalStlhDiskon As Integer = 0
            Dim totalDiskon As Integer = 0
            Dim totaldiskonkembar As Integer = 0
            Dim totaldiskonlain As Integer = 0
            For Each row As DataRow In dt.Rows
                If row("Jumlah") <> Nothing Then
                    totalPCS += CInt(row("Jumlah"))
                    totalasli += CInt(row("Jumlah")) * CInt(row("Harga Jual"))
                    totalStlhDiskon += CInt(row("total"))
                    lbltotalpcs.Text = FormatNumber(totalPCS, 0, TriState.False, , TriState.True)
                    lblSubTotal.Text = "Rp. " & FormatNumber(totalasli, 0, TriState.False, , TriState.True)
                End If
                'If row("Harga Jual") < 0 Then
                '    totaldiskonlain += CInt(row("Harga Jual")) * -1
                'End If
            Next
            totalDiskon = totalasli - totalStlhDiskon
            If totalDiskon = 0 Then
                lblDiskon.Text = "Rp. 0"
            Else
                lblDiskon.Text = "Rp. " & FormatNumber(totalDiskon, 0, TriState.False, , TriState.True)
            End If
            If Not IsNothing(dt2) Then
                If dt2.Rows.Count > 0 Then
                    For Each row As DataRow In dt2.Rows
                        If row("diskon") <> Nothing Then
                            totaldiskonkembar += CInt(row("diskon"))
                            lblDiskonKembar.Text = "Rp. " & FormatNumber(totaldiskonkembar, 0, TriState.False, , TriState.True)
                        End If
                    Next
                End If
            Else
                lblDiskonKembar.Text = "Rp. 0"
            End If
            Dim grandTotal As Integer = totalasli - totaldiskonkembar - totaldiskonlain
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
            If (totaldiskonlain + diskonpersen + diskonrupiah) = 0 Then
                lblDiskonLain.Text = "Rp. 0"
            Else
                lblDiskonLain.Text = "Rp. " & FormatNumber((totaldiskonlain + diskonpersen + diskonrupiah), 0, TriState.False, , TriState.True)
            End If
            lblTotal.Text = "Rp. " & FormatNumber(totalStlhDiskon, 0, TriState.False, , TriState.True)
            lbltotalPembulatan.Text = "Rp. " & FormatNumber(BulatkanKebawah500(totalStlhDiskon), 0, TriState.False, , TriState.True)
            If member And lblNoMember.Text <> "-" Then
                Dim jenis As String = Split(lblMemberJenis.Text, " ")(1)
                updateDiskonMember(jenis, lblKasir.Text, totalasli)
                penjualanAfterProses(False)
            ElseIf member And lblNoMember.Text = "-" Then
                updateDiskonMember("-", lblKasir.Text, totalasli)
                penjualanAfterProses(False)
            End If
        Else
            dgvdiskon.DataSource = Nothing
            dgvdiskon.Columns.Clear()
            lbltotalpcs.Text = "0"
            lblDiskonLain.Text = "Rp. 0"
            lblTotal.Text = "Rp. 0"
            lbltotalPembulatan.Text = "Rp. 0"
            lblSubTotal.Text = "Rp. 0"
            lblDiskonKembar.Text = "Rp. 0"
            cashNonAktif()
            edcNonAktif()
            QRISNonAktif()
            'diskonNonAktif()
        End If
        lblProses.Text = "0"
    End Sub
    'Private Function hitungDiskonMember(ByVal total As Integer) As Integer
    '    Dim jenis As String = Split(lblMemberJenis.Text, " ")(1)
    '    Dim diskon As Integer
    '    If jenis = "BD" Then
    '        diskon = getdiskonBD(total)
    '    ElseIf jenis = "Personal" Then
    '        diskon = getdiskonPersonal(total)
    '    ElseIf jenis = "Reseller" Then
    '        diskon = getdiskonReseller(total)
    '    End If
    '    Return diskon
    'End Function
    'Private Function getdiskonBD(ByVal total As Integer) As Integer
    '    Dim diskon As Integer
    '    If total > 1000000 Then
    '        diskon = total * 0.05
    '    ElseIf total > 500000 And total <= 1000000 Then
    '        diskon = total * 0.025
    '    Else
    '        diskon = 0
    '    End If
    '    Return diskon
    'End Function
    'Private Function getdiskonPersonal(ByVal total As Integer) As Integer
    '    Dim diskon As Integer
    '    If total > 1000000 Then
    '        diskon = total * 0.05
    '    ElseIf total > 500000 And total <= 1000000 Then
    '        diskon = total * 0.025
    '    Else
    '        diskon = 0
    '    End If
    '    Return diskon
    'End Function
    'Private Function getdiskonReseller(ByVal total As Integer) As Integer
    '    Dim diskon As Integer
    '    If total > 3000000 Then
    '        diskon = total * 0.1
    '    ElseIf total > 1000000 And total <= 3000000 Then
    '        diskon = total * 0.05
    '    Else
    '        diskon = 0
    '    End If
    '    Return diskon
    'End Function
    Private Sub lvitem_DoubleClick(sender As Object, e As EventArgs) Handles lvitem.DoubleClick
        Dim kode As String = lvitem.SelectedItems(0).SubItems(5).Text
        Dim stokAman As String = cekStok(kode, 1)
        If stokAman = "Y" Then
            Dim tambahtemp As Boolean = tambahPenjualanPOSTemp(kode, 1)
            If tambahtemp Then
                penjualanAfterProses(True)
                txtkodeitem.Text = ""
                txtkodeitem.Focus()
            End If
        Else
            MsgBox("Stok barang kurang.", vbCritical, "Macarons")
        End If
    End Sub

    Private Sub dgvTemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTemp.CellContentClick
        If e.ColumnIndex = 8 And e.RowIndex >= 0 Then
            delPenjualanTemp(dgvTemp.Rows(e.RowIndex).Cells(0).Value.ToString)
            penjualanAfterProses(True)
        End If
    End Sub
    Private Sub dgvTemp_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTemp.CellEndEdit
        Dim id As String = dgvTemp.CurrentRow.Cells(0).Value.ToString
        Dim diskonrp As String = getnumber(dgvTemp.CurrentRow.Cells(5).Value.ToString)
        Dim diskonpersen As String = getnumber(dgvTemp.CurrentRow.Cells(6).Value.ToString)

        Dim updateTemp As Boolean = updatePenjualanPOSTemp(id, diskonrp, diskonpersen)
        If updateTemp Then
            penjualanAfterProses(False)
        End If
    End Sub

    Private Sub txtdiskonpersen_TextChanged(sender As Object, e As EventArgs) Handles txtdiskonpersen.TextChanged, txtdiskonrupiah.TextChanged
        penjualanAfterProses(True)
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
        If lblProses.Text = "0" Then
            If cbdiskon.Checked = False Then
                diskonNonAktif()
            Else
                diskonAktif()
            End If
        End If
    End Sub
    Private Sub diskonAktif()
        pnlDiskon.BackColor = Color.FromArgb(0, 184, 148)
        cbdiskon.Checked = True
        gbdiskon.Enabled = True
        txtdiskonpersen.Focus()
    End Sub
    Private Sub diskonNonAktif()
        pnlDiskon.BackColor = Color.FromArgb(178, 190, 195)
        cbdiskon.Checked = False
        txtdiskonpersen.Text = ""
        txtdiskonrupiah.Text = ""
        gbdiskon.Enabled = False
    End Sub
    Private Sub cashAktif()
        pnlCash.BackColor = Color.FromArgb(253, 121, 168)
        txtbayar.Enabled = True
        pnlBtnUang.Enabled = True
        txtbayar.Focus()
        cbCash.Checked = True
    End Sub
    Private Sub cashNonAktif()
        pnlCash.BackColor = Color.FromArgb(178, 190, 195)
        txtbayar.Text = "0"
        lblkurang.Text = "0"
        txtbayar.Enabled = False
        pnlBtnUang.Enabled = False
        cbCash.Checked = False
    End Sub
    Private Sub edcAktif()
        pnlEDC.BackColor = Color.FromArgb(253, 121, 168)
        panelEDC.Enabled = True
        cmbbankEDC.DroppedDown = True
        cmbbankEDC.Focus()
        cbEDC.Checked = True
    End Sub
    Private Sub edcNonAktif()
        pnlEDC.BackColor = Color.FromArgb(178, 190, 195)
        panelEDC.Enabled = False
        txtnoedc.Text = ""
        cmbbankEDC.SelectedIndex = -1
        cbEDC.Checked = False
    End Sub
    Private Sub QRISAktif()
        pnlQRIS.BackColor = Color.FromArgb(253, 121, 168)
        panelQRIS.Enabled = True
        cmbBankQRIS.DroppedDown = True
        cmbBankQRIS.Focus()
        cbQRIS.Checked = True
    End Sub
    Private Sub QRISNonAktif()
        pnlQRIS.BackColor = Color.FromArgb(178, 190, 195)
        panelQRIS.Enabled = False
        cmbBankQRIS.SelectedIndex = -1
        cbQRIS.Checked = False
    End Sub
    Private Sub cbDiskon_check()
        If lblProses.Text = "0" Then
            If cbdiskon.Checked = False Then
                diskonAktif()
            Else
                diskonNonAktif()
            End If
        End If
    End Sub
    Private Sub cbCash_check()
        If lblProses.Text = "0" Then
            lblProses.Text = "1"
            If cbCash.Checked = False Then
                cashAktif()
                edcNonAktif()
                QRISNonAktif()
            Else
                cashNonAktif()
            End If
            lblProses.Text = "0"
        End If
    End Sub
    Private Sub cbCash_CheckedChanged(sender As Object, e As EventArgs) Handles cbCash.CheckedChanged
        If lblProses.Text = "0" Then
            lblProses.Text = "1"
            If cbCash.Checked = False Then
                cashNonAktif()
            Else
                cashAktif()
                edcNonAktif()
                QRISNonAktif()
            End If
            lblProses.Text = "0"
        End If
    End Sub
    Private Sub cbEDC_check()
        If lblProses.Text = "0" Then
            lblProses.Text = "1"
            If cbEDC.Checked = False Then
                edcAktif()
                cashNonAktif()
                QRISNonAktif()
            Else
                edcNonAktif()
            End If
            lblProses.Text = "0"
        End If
    End Sub
    Private Sub cbEDC_CheckedChanged(sender As Object, e As EventArgs) Handles cbEDC.CheckedChanged
        If lblProses.Text = "0" Then
            lblProses.Text = "1"
            If cbEDC.Checked = False Then
                edcNonAktif()
            Else
                edcAktif()
                cashNonAktif()
                QRISNonAktif()
            End If
            lblProses.Text = "0"
        End If
    End Sub
    Private Sub cbQRIS_check()
        If lblProses.Text = "0" Then
            lblProses.Text = "1"
            If cbQRIS.Checked = False Then
                QRISAktif()
                cashNonAktif()
                edcNonAktif()
            Else
                QRISNonAktif()
            End If
            lblProses.Text = "0"
        End If
    End Sub
    Private Sub cbQRIS_CheckedChanged(sender As Object, e As EventArgs) Handles cbQRIS.CheckedChanged
        If lblProses.Text = "0" Then
            lblProses.Text = "1"
            If cbQRIS.Checked = False Then
                QRISNonAktif()
            Else
                QRISAktif()
                cashNonAktif()
                edcNonAktif()
            End If
            lblProses.Text = "0"
        End If
    End Sub

    Private Sub btn100000_Click(sender As Object, e As EventArgs) Handles btn100000.Click, btn50000.Click, btn20000.Click,
        btn10000.Click, btn5000.Click, btn2000.Click, btn1000.Click, btn500.Click, btn200.Click
        If txtbayar.Text <> "" And IsNumeric(txtbayar.Text) = True Then
            txtbayar.Text = CInt(txtbayar.Text) + CInt(Mid(DirectCast(sender, Button).Name, 4, 6))
        Else
            txtbayar.Text = CInt(Mid(DirectCast(sender, Button).Name, 4, 6))
        End If
    End Sub

    Private Sub txtbayar_TextChanged(sender As Object, e As EventArgs) Handles txtbayar.TextChanged
        If txtbayar.TextLength > 0 And IsNumeric(txtbayar.Text) Then
            txtbayar.Text = FormatNumber(txtbayar.Text, 0, TriState.False, , TriState.True)
            txtbayar.Select(txtbayar.Text.Length, 0)
        End If
        If txtbayar.Text <> "" And IsNumeric(txtbayar.Text) = True Then
            lblkurang.Text = "Rp. " & FormatNumber(CInt(txtbayar.Text) - (getnumber(lbltotalPembulatan.Text.Replace("Rp. ", ""))), 0, TriState.False, TriState.True)
        End If
    End Sub

    Private Sub btnPenjualanManual_Click(sender As Object, e As EventArgs) Handles btnPenjualanManual.Click
        If Application.OpenForms().OfType(Of frmPenjualanManual).Any Then
            AppActivate(frmPenjualanManual.Text)
        Else
            frmPenjualanManual.ShowDialog()
        End If
        penjualanAfterProses(True)
        txtkodeitem.Text = ""
        txtkodeitem.Focus()
    End Sub

    Private Sub cbxDiskonKembar_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDiskonKembar.CheckedChanged
        If cbxDiskonKembar.Checked Then
            pnlDiskonKembar.Enabled = True
            dgvdiskon.BackgroundColor = Color.FromArgb(85, 239, 196)
        Else
            pnlDiskonKembar.Enabled = False
            dgvdiskon.BackgroundColor = Color.FromArgb(255, 0, 0)
        End If
        penjualanAfterProses(True)
    End Sub

    Private Sub btnMember_Click(sender As Object, e As EventArgs) Handles btnMember.Click
        If Application.OpenForms().OfType(Of frmMember).Any Then
            AppActivate(frmMember.Text)
        Else
            frmMember.ShowDialog()
        End If
    End Sub

    Private Sub cbMember_CheckedChanged(sender As Object, e As EventArgs) Handles cbMember.CheckedChanged
        If cbMember.Checked = False Then
            modeMemberNonaktif()
            penjualanAfterProses(True)
        End If
    End Sub
End Class
