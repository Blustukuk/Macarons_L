Public Class frmPenjualanManual
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmPenjualanManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 231, 127, 103)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        txtNamaItem.Focus()
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F2 Then
            btnProses_Click(o, e)
        End If
    End Sub
    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If txtNamaItem.Text <> "" And txtHarga.Text <> "" And txtNamaItem.TextLength > 12 And txtJml.Text <> "" _
            And IsNumeric(txtHarga.Text) And IsNumeric(txtJml.Text) Then
            Dim tambahtemp As Boolean = tambahPenjualanPOSTemp("", txtJml.Text, txtNamaItem.Text, txtHarga.Text)
            If tambahtemp Then
                Dispose()
            End If
        Else
            MsgBox("Cek kembali data penjualan manual.", vbCritical, "Macarons")
        End If
    End Sub

    Private Sub txtHarga_TextChanged(sender As Object, e As EventArgs) Handles txtHarga.TextChanged
        If txtHarga.TextLength > 0 And IsNumeric(txtHarga.Text) Then
            txtHarga.Text = FormatNumber(txtHarga.Text, 0, TriState.False, , TriState.True)
            txtHarga.Select(txtHarga.Text.Length, 0)
        End If
    End Sub
End Class