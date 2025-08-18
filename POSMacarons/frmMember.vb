Public Class frmMember
    Dim dt As DataTable
    Private Sub frmMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 85, 239, 196)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        txtktp.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F2 Then
            btnProses_Click(o, e)
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim namaMember, kode, telp, alamat, ktp, ket As String
        Dim tambah As Integer
        Dim cek As Boolean
        Dim jenis As String = ""
        namaMember = System.Text.RegularExpressions.Regex.Replace(txtnama.Text, "[^a-zA-Z0-9]", " ")
        alamat = System.Text.RegularExpressions.Regex.Replace(txtalamat.Text, "[^a-zA-Z0-9]", " ")
        telp = System.Text.RegularExpressions.Regex.Replace(txttelp.Text, "[^a-zA-Z0-9]", " ")
        ktp = System.Text.RegularExpressions.Regex.Replace(txtktp.Text, "[^a-zA-Z0-9]", " ")
        ket = System.Text.RegularExpressions.Regex.Replace(txtnote.Text, "[^a-zA-Z0-9]", " ")
        If rbBD.Checked Then
            jenis = "BD"
        ElseIf rbPersonal.Checked Then
            jenis = "Personal"
        ElseIf rbReseller.Checked Then
            jenis = "Reseller"
        End If
        If namaMember = "" Then
            MsgBox("Isi terlebih dahulu nama member.", vbCritical, "Macarons")
        Else
            cek = cekMember(telp, ktp)
            If cek Then
                kode = getkodeMember(jenis)
                tambah = memberTambah(ktp, namaMember, alamat, telp, ket, jenis, kode)
                If tambah <> 0 Then
                    Dim imgPath As String = virtualCard(jenis, telp, kode, namaMember, ktp)
                    lblNoMember.Text = "-"
                    txtktp.Text = ""
                    txtnama.Text = ""
                    txtalamat.Text = ""
                    txttelp.Text = ""
                    txtnote.Text = ""
                    rbPersonal.Checked = True
                    MsgBox("Proses tambah data sukses.", vbOKOnly, "Macarons")
                    'dt = loadDataMember("")
                    'tampilkanData(dt)
                Else
                    MsgBox("Proses tambah data gagal. Hubungi developer.", vbOKOnly, "Macarons")
                End If
            Else
                MsgBox("No. Telepon atau No. KTP yang sama ditemukan." & vbCrLf & "Silahkan gunakan No. Telepon atau No. KTP lainnya.", vbOKOnly, "Macarons")
            End If
        End If
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cball_CheckedChanged(sender As Object, e As EventArgs) Handles cball.CheckedChanged
        If Me.cball.Checked = True Then
            dt = loadDataMember("")
            tampilkanData(dt)
        Else
            dgvtemp.DataSource = Nothing
            dgvtemp.Columns.Clear()
        End If
    End Sub

    Private Sub dgvtemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellContentClick
        Dim del, cek As Boolean
        Dim delpass As String = ""
        Dim a As New frminputbox
        Dim isAdmin As Boolean
        Try
            If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                modeMemberAktif(dgvtemp.Rows(e.RowIndex).Cells(4).Value.ToString)
                Dispose()
            ElseIf e.ColumnIndex = 12 And e.RowIndex >= 0 Then
                If a.ShowDialog("Hapus Member", "Untuk melanjutkan proses hapus member dibutuhkan kode konfirmasi.",
                                "Kode Konfirmasi", delpass, False) = System.Windows.Forms.DialogResult.Cancel Then
                    Beep()
                Else
                    isAdmin = validAdmin(delpass)
                    If isAdmin Then
                        Dim idDel As String = dgvtemp.Rows(e.RowIndex).Cells(1).Value.ToString
                        cek = cekDeleteMember(idDel)
                        If cek Then
                            del = memberDel(idDel)
                            If del Then
                                MsgBox("Proses delete member sukses.", vbOKOnly, "Macarons")
                                dgvtemp.DataSource = Nothing
                                dgvtemp.Columns.Clear()
                            Else
                                MsgBox("Proses delete member gagal. Hubungi developer.", vbCritical, "Macarons")
                            End If
                        Else
                            MsgBox("ID Member tidak ditemukan.", vbCritical, "Macarons")
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
    Sub tampilkanData(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            dgvtemp.DataSource = Nothing
            dgvtemp.Columns.Clear()
            'lblproses.Text = "0"
            With dgvtemp
                .Columns.Add(New DataGridViewButtonColumn() With {
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                            .HeaderText = "USE",
                            .Text = "USE",
                            .UseColumnTextForButtonValue = True,
                            .FlatStyle = FlatStyle.Standard,
                            .MinimumWidth = 100})
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                {New DataGridViewButtonColumn() With
                                                 {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                                                 .HeaderText = "Del",
                                                 .Text = "Del",
                                                 .UseColumnTextForButtonValue = True,
                                                 .FlatStyle = FlatStyle.Standard,
                                                 .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(7).Visible = False
                .Columns(9).Visible = False
                .Columns(9).Visible = False
                .Columns(11).Visible = False

            End With
            dtp1.Value = CDate(dt.Rows(0).Item("Tgl Daftar")).ToString("yyyy-MM-dd")
            If CStr(dt.Rows(0).Item("Jenis")) = "Personal" Then
                rbPersonal.Checked = True
            ElseIf CStr(dt.Rows(0).Item("jenis")) = "Reseller" Then
                rbReseller.Checked = True
            ElseIf CStr(dt.Rows(0).Item("jenis")) = "BD" Then
                rbBD.Checked = True
            Else
                rbPersonal.Checked = True
            End If
            lblNoMember.Text = CStr(dt.Rows(0).Item("No Member"))
            txtktp.Text = CStr(dt.Rows(0).Item("No KTP"))
            txtnama.Text = CStr(dt.Rows(0).Item("Nama"))
            txtalamat.Text = CStr(dt.Rows(0).Item("Alamat"))
            txttelp.Text = CStr(dt.Rows(0).Item("Telp"))
            txtnote.Text = CStr(dt.Rows(0).Item("Ket"))
            txtPoin.Text = CStr(dt.Rows(0).Item("Poin"))
        End If
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        If txtcari.TextLength > 2 Then
            dt = loadDataMember(txtcari.Text)
            tampilkanData(dt)
        Else
            dgvtemp.DataSource = Nothing
            dgvtemp.Columns.Clear()
        End If
    End Sub

    Private Sub dgvtemp_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtemp.CellContentDoubleClick
        If e.ColumnIndex > 0 And e.RowIndex >= 0 Then
            Dim idmember As String = dgvtemp.Rows(e.RowIndex).Cells(1).Value.ToString
            Dim dt2 As DataTable = loadDataMemberID(idmember)
            'If dt2.Rows.Count > 0 Then
            dtp1.Value = CDate(dt2.Rows(0).Item("Tgl Daftar")).ToString("yyyy-MM-dd")
            If CStr(dt2.Rows(0).Item("Jenis")) = "Personal" Then
                rbPersonal.Checked = True
            ElseIf CStr(dt2.Rows(0).Item("jenis")) = "Reseller" Then
                rbReseller.Checked = True
            ElseIf CStr(dt2.Rows(0).Item("jenis")) = "BD" Then
                rbBD.Checked = True
            Else
                rbPersonal.Checked = True
            End If
            lblNoMember.Text = CStr(dt2.Rows(0).Item("No Member"))
            txtktp.Text = CStr(dt2.Rows(0).Item("No KTP"))
            txtnama.Text = CStr(dt2.Rows(0).Item("Nama"))
            txtalamat.Text = CStr(dt2.Rows(0).Item("Alamat"))
            txttelp.Text = CStr(dt2.Rows(0).Item("Telp"))
            txtnote.Text = CStr(dt2.Rows(0).Item("Ket"))
            txtPoin.Text = CStr(dt2.Rows(0).Item("Poin"))
        Else
            MsgBox("Data member tidak ada.", vbCritical, "Macarons")
        End If
    End Sub
End Class