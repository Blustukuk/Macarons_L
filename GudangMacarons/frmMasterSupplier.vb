Public Class frmMasterSupplier
    Dim dt As DataTable
    Private Sub frmMasterSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        gantiwarnaform(sender, 99, 205, 218)
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Dispose()
    End Sub

    Private Sub cball_CheckedChanged(sender As Object, e As EventArgs) Handles cball.CheckedChanged
        If Me.cball.Checked = True Then
            dt = loadDataSupplier("")
            tampilkanData(dt)
        Else
            dgvtemp.DataSource = Nothing
            dgvtemp.Columns.Clear()
        End If
    End Sub
    Private Sub txtnamasupplier_GotFocus(sender As Object, e As EventArgs) Handles txtnamasupplier.GotFocus, txtpic.GotFocus, txtalamatsupplier.GotFocus, txttelpsupplier.GotFocus
        Me.AcceptButton = Me.btntambah
    End Sub
    Private Sub txtcari_GotFocus(sender As Object, e As EventArgs) Handles txtcari.GotFocus
        Me.AcceptButton = Me.btncari
    End Sub
    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        Dim namasupplier, kode, pic As String
        Dim tambah As Integer
        Dim cek As Boolean
        namasupplier = System.Text.RegularExpressions.Regex.Replace(Me.txtnamasupplier.Text, "[^a-zA-Z0-9]", " ")
        pic = System.Text.RegularExpressions.Regex.Replace(Me.txtpic.Text, "[^a-zA-Z0-9]", " ")
        kode = randomStr(3)
        If Me.txtnamasupplier.Text = "" Then
            MsgBox("Isi terlebih dahulu nama supplier.", vbCritical, "Macarons")
        Else
            cek = cekSupplier(kode, namasupplier)
            If cek Then
                tambah = mastersuppliertambah(namasupplier, pic, Me.txtalamatsupplier.Text, Me.txttelpsupplier.Text, Me.chkbaktif.Checked, kode)
                If tambah <> 0 Then
                    MsgBox("Proses tambah data sukses.", vbOKOnly, "Macarons")
                    dt = loadDataSupplier("")
                    tampilkanData(dt)
                    txtnamasupplier.Text = ""
                    txtpic.Text = ""
                    txtalamatsupplier.Text = ""
                    txttelpsupplier.Text = ""
                    chkbaktif.Checked = True
                Else
                    MsgBox("Proses tambah data gagal. Hubungi developer.", vbOKOnly, "Macarons")
                End If
            Else
                MsgBox("Nama sudah ada. Silahkan gunakan nama lainnya.", vbOKOnly, "Macarons")
            End If
        End If
    End Sub
    Sub tampilkanData(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            dgvtemp.DataSource = Nothing
            dgvtemp.Columns.Clear()
            'lblproses.Text = "0"
            With dgvtemp
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                {New DataGridViewButtonColumn() With
                                                 {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Del", .Text = "Del", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(6).Visible = False
            End With

            lblsupplierid.Text = CStr(dt.Rows(0).Item("id"))
            txtkode.Text = CStr(dt.Rows(0).Item("kode"))
            txtnamasupplier.Text = CStr(dt.Rows(0).Item("nama"))
            txtpic.Text = CStr(dt.Rows(0).Item("pic"))
            txtalamatsupplier.Text = CStr(dt.Rows(0).Item("alamat"))
            txttelpsupplier.Text = CStr(dt.Rows(0).Item("telp"))
            If dt.Rows(0).Item("flg_aktif") = 0 Then
                chkbaktif.Checked = False
            Else
                chkbaktif.Checked = True
            End If
        End If
    End Sub
    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Me.txtnamasupplier.Text = ""
        Me.txtalamatsupplier.Text = ""
        Me.txttelpsupplier.Text = ""
        Me.txtpic.Text = ""
        Me.chkbaktif.Checked = False
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        dt = loadDataSupplier(txtcari.Text)
        tampilkanData(dt)
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        Dim namasupplier, pic As String
        Dim edit As Integer
        Dim cek As Boolean
        namasupplier = System.Text.RegularExpressions.Regex.Replace(Me.txtnamasupplier.Text, "[^a-zA-Z0-9]", " ")
        pic = System.Text.RegularExpressions.Regex.Replace(Me.txtpic.Text, "[^a-zA-Z0-9]", " ")
        If lblsupplierid.Text <> "0" Then
            cek = cekSupplier("", namasupplier)
            If cek Then
                edit = mastersupplieredit(lblsupplierid.Text, namasupplier, pic, txtalamatsupplier.Text, txttelpsupplier.Text, chkbaktif.Checked, txtkode.Text)
                If edit <> 0 Then
                    MsgBox("Proses edit data sukses.", vbOKOnly, "Macarons")
                    dt = loadDataSupplier("")
                    tampilkanData(dt)
                    txtnamasupplier.Text = ""
                    txtpic.Text = ""
                    txtalamatsupplier.Text = ""
                    txttelpsupplier.Text = ""
                    chkbaktif.Checked = True
                Else
                    MsgBox("Proses edit data gagal. Hubungi developer.", vbCritical, "Macarons")
                End If
            Else
                MsgBox("Nama sudah ada. Silahkan gunakan nama lainnya.", vbOKOnly, "Macarons")
            End If
        End If
    End Sub

    Private Sub dgvtemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellContentClick
        Dim del, cek As Boolean
        Dim delpass As String = ""
        Dim a As New frminputbox
        Dim isAdmin As Boolean
        Try
            If e.ColumnIndex = 7 And e.RowIndex >= 0 Then
                If a.ShowDialog("Hapus Item", "Untuk melanjutkan proses hapus item dibutuhkan kode konfirmasi.",
                                "Kode Konfirmasi", delpass, False) = System.Windows.Forms.DialogResult.Cancel Then
                    Beep()
                Else
                    isAdmin = validAdmin(delpass)
                    If isAdmin Then
                        Dim idDel As String = dgvtemp.Rows(e.RowIndex).Cells(0).Value.ToString
                        cek = cekDeleteSupplier(idDel)
                        If cek Then
                            del = mastersupplierdel(idDel)
                            If del Then
                                MsgBox("Proses delete item sukses.", vbOKOnly, "Macarons")
                                dt = loadDataSupplier("")
                                tampilkanData(dt)
                                txtnamasupplier.Text = ""
                                txtpic.Text = ""
                                txtalamatsupplier.Text = ""
                                txttelpsupplier.Text = ""
                                chkbaktif.Checked = False
                            Else
                                MsgBox("Proses delete item gagal. Hubungi developer.", vbCritical, "Macarons")
                            End If
                        Else
                            MsgBox("ID Supplier tidak ditemukan.", vbCritical, "Macarons")
                        End If
                    Else
                        MsgBox("Kode konfirmasi salah.", vbCritical, "Macarons")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Macarons")
            MsgBox("Stack Trace: " & vbCrLf & ex.StackTrace, vbCritical, "Macarons")
        End Try
    End Sub

    Private Sub dgvtemp_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim idDel As String = dgvtemp.Rows(e.RowIndex).Cells(0).Value.ToString
            Dim dt2 As DataTable = loadDataSupplierID(idDel)
            If dt2.Rows.Count > 0 Then
                lblsupplierid.Text = CStr(dt2.Rows(0).Item("id"))
                txtkode.Text = CStr(dt2.Rows(0).Item("kode"))
                txtnamasupplier.Text = CStr(dt2.Rows(0).Item("nama"))
                txtpic.Text = CStr(dt2.Rows(0).Item("pic"))
                txtalamatsupplier.Text = CStr(dt2.Rows(0).Item("alamat"))
                txttelpsupplier.Text = CStr(dt2.Rows(0).Item("telp"))
                If dt2.Rows(0).Item("flg_aktif") = 0 Then
                    chkbaktif.Checked = False
                Else
                    chkbaktif.Checked = True
                End If
            Else
                MsgBox("Data supplier tidak ada.", vbCritical, "Macarons")
            End If
        End If
    End Sub
End Class