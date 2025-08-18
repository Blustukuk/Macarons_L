Public Class frmDelDataPembelian
    Private Sub frmDelDataPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 231, 127, 103)
        Call frmDelDataPembelianLoad()
    End Sub
    Sub frmDelDataPembelianLoad()
        dgvTemp.DataSource = Nothing
        dgvTemp.Columns.Clear()

        Dim dt As DataTable = loadDataPembelian()
        If dt.Rows.Count > 0 Then
            With dgvTemp
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                        {New DataGridViewButtonColumn() With
                                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Hapus", .Text = "Hapus", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(2).Visible = False
            End With
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub dgvTemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTemp.CellContentClick
        Dim a As New frminputbox
        Dim isAdmin As Boolean
        Dim delpass As String = ""
        If e.ColumnIndex = 3 And e.RowIndex >= 0 Then
            If a.ShowDialog("Hapus Item", "Untuk melanjutkan proses hapus pembelian dibutuhkan kode konfirmasi.",
                                "Kode Konfirmasi", delpass, False) = System.Windows.Forms.DialogResult.Cancel Then
                Beep()
            Else
                isAdmin = validAdmin(delpass)
                If isAdmin Then
                    delDataPembelian(dgvTemp.Rows(e.RowIndex).Cells(0).Value.ToString)
                    frmDelDataPembelianLoad()
                End If
            End If
        End If
    End Sub

    Private Sub btnDelPembelian_Click(sender As Object, e As EventArgs) Handles btnDelPembelian.Click
        Dim a As New frminputbox
        Dim isAdmin As Boolean
        Dim delpass As String = ""

        If a.ShowDialog("Hapus Item", "Untuk melanjutkan proses HAPUS SEMUA pembelian dibutuhkan kode konfirmasi.",
                            "Kode Konfirmasi", delpass, False) = System.Windows.Forms.DialogResult.Cancel Then
            Beep()
        Else
            isAdmin = validAdmin(delpass)
            If isAdmin Then
                delALLDataPembelian()
                frmDelDataPembelianLoad()
            End If
        End If
    End Sub
End Class