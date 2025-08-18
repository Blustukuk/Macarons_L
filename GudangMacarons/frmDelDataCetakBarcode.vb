Public Class frmDelDataCetakBarcode
    Private Sub frmDelDataCetakBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 255, 234, 167)
        Call frmDelDataBarcodeLoad()
    End Sub
    Sub frmDelDataBarcodeLoad()
        dgvTemp.DataSource = Nothing
        dgvTemp.Columns.Clear()

        Dim dt As DataTable = loadDataPengadaan()
        If dt.Rows.Count > 0 Then
            With dgvTemp
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                        {New DataGridViewButtonColumn() With
                                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Hapus", .Text = "Hapus", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub
    Private Sub btnDelPembelian_Click(sender As Object, e As EventArgs) Handles btnDelPembelian.Click
        Dim a As New frminputbox
        Dim isAdmin As Boolean
        Dim delpass As String = ""

        If a.ShowDialog("Hapus Item", "Untuk melanjutkan proses HAPUS SEMUA cetak barcode dibutuhkan kode konfirmasi.",
                            "Kode Konfirmasi", delpass, False) = System.Windows.Forms.DialogResult.Cancel Then
            Beep()
        Else
            isAdmin = validAdmin(delpass)
            If isAdmin Then
                delALLDataBarcode()
                frmDelDataBarcodeLoad()
            End If
        End If
    End Sub

    Private Sub dgvTemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTemp.CellContentClick
        Dim a As New frminputbox
        Dim isAdmin As Boolean
        Dim delpass As String = ""
        If e.ColumnIndex = 1 And e.RowIndex >= 0 Then
            If a.ShowDialog("Hapus Item", "Untuk melanjutkan proses hapus pembelian dibutuhkan kode konfirmasi.",
                                "Kode Konfirmasi", delpass, False) = System.Windows.Forms.DialogResult.Cancel Then
                Beep()
            Else
                isAdmin = validAdmin(delpass)
                If isAdmin Then
                    delDataBarcode(dgvTemp.Rows(e.RowIndex).Cells(0).Value.ToString)
                    frmDelDataBarcodeLoad()
                End If
            End If
        End If
    End Sub
End Class