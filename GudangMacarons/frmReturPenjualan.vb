Public Class frmReturPenjualan
    Dim dt As DataTable
    Dim dt2 As DataTable
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Dispose()
    End Sub

    Private Sub tampilkanData(ByVal dt As DataTable, ByVal dt2 As DataTable)
        ' Menyimpan indeks yang dipilih sebelumnya
        Dim selectedItemIndex As Integer = lbListItem.SelectedIndex
        Dim selectedReturIndex As Integer = lbReturTemp.SelectedIndex

        dt = loadDataPenjualanPOS(txtcarisj.Text)
        dt2 = loadDataReturPOS(txtcarisj.Text)

        ' Mengatur DataSource untuk lbListItem
        If dt.Rows.Count > 0 Then
            lbListItem.DataSource = dt
            lbListItem.DisplayMember = "Item"
            lbListItem.ValueMember = "kode"
            txtBarcode.Focus()

            ' Mengembalikan indeks yang dipilih sebelumnya
            If selectedItemIndex >= 0 And selectedItemIndex < lbListItem.Items.Count Then
                lbListItem.SelectedIndex = selectedItemIndex
            End If
        Else
            lbListItem.DataSource = Nothing
        End If

        ' Mengatur DataSource untuk lbReturTemp
        If dt2.Rows.Count > 0 Then
            lbReturTemp.DataSource = dt2
            lbReturTemp.DisplayMember = "Item"
            lbReturTemp.ValueMember = "kode"
            lbListItem.Enabled = False
            lbReturTemp.Enabled = False
            panahkanan.Enabled = False
            panahkiri.Enabled = False
            btnProses.Enabled = False

            ' Mengembalikan indeks yang dipilih sebelumnya
            If selectedReturIndex >= 0 And selectedReturIndex < lbReturTemp.Items.Count Then
                lbReturTemp.SelectedIndex = selectedReturIndex
            End If
        Else
            dt2 = loadDataReturTempPOS(txtcarisj.Text)
            If dt2.Rows.Count > 0 Then
                lbReturTemp.DataSource = dt2
                lbReturTemp.DisplayMember = "Item"
                lbReturTemp.ValueMember = "kode"
                lbListItem.Enabled = True
                lbReturTemp.Enabled = True
                panahkanan.Enabled = True
                panahkiri.Enabled = True
                btnProses.Enabled = True

                ' Mengembalikan indeks yang dipilih sebelumnya
                If selectedReturIndex >= 0 And selectedReturIndex < lbReturTemp.Items.Count Then
                    lbReturTemp.SelectedIndex = selectedReturIndex
                End If
            Else
                lbReturTemp.DataSource = Nothing
                lbListItem.Enabled = True
                lbReturTemp.Enabled = True
                panahkanan.Enabled = True
                panahkiri.Enabled = True
                btnProses.Enabled = True
            End If
        End If
    End Sub

    Private Sub frmRetur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 255, 234, 167)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
    End Sub

    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnProses_Click(o, e)
        End If
    End Sub
    Private Sub panahkanan_Click(sender As Object, e As EventArgs) Handles panahkanan.Click, lbListItem.DoubleClick
        pilihItem(lbListItem.SelectedValue.ToString, txtcarisj.Text)
        tampilkanData(dt, dt2)
    End Sub

    Private Sub panahkiri_Click(sender As Object, e As EventArgs) Handles panahkiri.Click, lbReturTemp.DoubleClick
        buangItem(lbReturTemp.SelectedValue.ToString, txtcarisj.Text)
        tampilkanData(dt, dt2)
    End Sub

    Private Sub txtBarcode_GotFocus(sender As Object, e As EventArgs) Handles txtBarcode.GotFocus
        AcceptButton = btnKodeOK
    End Sub

    Private Sub txtBarcode_LostFocus(sender As Object, e As EventArgs) Handles txtBarcode.LostFocus
        AcceptButton = Nothing
    End Sub

    Private Sub btnKodeOK_Click(sender As Object, e As EventArgs) Handles btnKodeOK.Click
        pilihItem(txtBarcode.Text, txtcarisj.Text)
        tampilkanData(dt, dt2)
        txtBarcode.Text = ""
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim proses As Boolean = returpenjualan(txtcarisj.Text, frmMain.lblUserID.Text)
        If proses Then
            Dispose()
        End If
    End Sub

    Private Sub btnCariNoNota_Click(sender As Object, e As EventArgs) Handles btnCariNoNota.Click
        If txtcarisj.TextLength >= 4 Then
            tampilkanData(dt, dt2)
        Else
            lbListItem.DataSource = Nothing
            lbReturTemp.DataSource = Nothing
        End If
    End Sub

    Private Sub txtcarinota_GotFocus(sender As Object, e As EventArgs) Handles txtcarisj.GotFocus
        AcceptButton = btnCariNoNota
    End Sub

    Private Sub txtcarinota_LostFocus(sender As Object, e As EventArgs) Handles txtcarisj.LostFocus
        AcceptButton = Nothing
    End Sub

End Class