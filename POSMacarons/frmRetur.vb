Public Class frmRetur
    Dim dt As DataTable
    Dim dt2 As DataTable
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Dispose()
    End Sub

    Private Sub tampilkanData(ByVal dt As DataTable, ByVal dt2 As DataTable)
        dt = loadDataPenjualanPOS(txtcarinota.Text)
        dt2 = loadDataReturPOS(txtcarinota.Text)
        If dt.Rows.Count > 0 Then
            lbListItem.DataSource = dt
            lbListItem.DisplayMember = "Item"
            lbListItem.ValueMember = "kode"
            txtBarcode.Focus()
        Else
            lbListItem.DataSource = Nothing
        End If
        If dt2.Rows.Count > 0 Then
            lbReturTemp.DataSource = dt2
            lbReturTemp.DisplayMember = "Item"
            lbReturTemp.ValueMember = "kode"
            lbListItem.Enabled = False
            lbReturTemp.Enabled = False
            panahkanan.Enabled = False
            panahkiri.Enabled = False
            btnProses.Enabled = False
            lbListItem.SelectedIndex = -1
            lbReturTemp.SelectedIndex = -1
        Else
            dt2 = loadDataReturTempPOS(txtcarinota.Text)
            If dt2.Rows.Count > 0 Then
                lbReturTemp.DataSource = dt2
                lbReturTemp.DisplayMember = "Item"
                lbReturTemp.ValueMember = "kode"
                lbListItem.Enabled = True
                lbReturTemp.Enabled = True
                panahkanan.Enabled = True
                panahkiri.Enabled = True
                btnProses.Enabled = True
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
        pilihItem(lbListItem.SelectedValue.ToString, txtcarinota.Text)
        tampilkanData(dt, dt2)
    End Sub

    Private Sub panahkiri_Click(sender As Object, e As EventArgs) Handles panahkiri.Click, lbReturTemp.DoubleClick
        buangItem(lbReturTemp.SelectedValue.ToString, txtcarinota.Text)
        tampilkanData(dt, dt2)
    End Sub

    Private Sub txtBarcode_GotFocus(sender As Object, e As EventArgs) Handles txtBarcode.GotFocus
        AcceptButton = btnKodeOK
    End Sub

    Private Sub txtBarcode_LostFocus(sender As Object, e As EventArgs) Handles txtBarcode.LostFocus
        AcceptButton = Nothing
    End Sub

    Private Sub btnKodeOK_Click(sender As Object, e As EventArgs) Handles btnKodeOK.Click
        pilihItem(txtBarcode.Text, txtcarinota.Text)
        tampilkanData(dt, dt2)
        txtBarcode.Text = ""
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim proses As Boolean = returpenjualan(txtcarinota.Text, frmPOS2.lblKasir.Text)
        If proses Then
            Dispose()
        End If
    End Sub

    Private Sub btnCariNoNota_Click(sender As Object, e As EventArgs) Handles btnCariNoNota.Click
        If txtcarinota.TextLength >= 4 Then
            tampilkanData(dt, dt2)
        Else
            lbListItem.DataSource = Nothing
            lbReturTemp.DataSource = Nothing
        End If
    End Sub

    Private Sub txtcarinota_GotFocus(sender As Object, e As EventArgs) Handles txtcarinota.GotFocus
        AcceptButton = btnCariNoNota
    End Sub

    Private Sub txtcarinota_LostFocus(sender As Object, e As EventArgs) Handles txtcarinota.LostFocus
        AcceptButton = Nothing
    End Sub

End Class