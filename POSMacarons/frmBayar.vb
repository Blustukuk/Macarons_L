Public Class frmBayar
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
            lblkurang.Text = "Rp. " & FormatNumber(CInt(txtbayar.Text) - (getnumber(lbltotal.Text.Replace("Rp. ", ""))), 0, TriState.False, TriState.True)
        End If
    End Sub

    Private Sub frmBayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        txtbayar.Focus()
        AcceptButton = btnProses
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim proses As Boolean = prosespenjualancash(frmPOS2.lblUserID.Text, getnumber(txtbayar.Text), frmPOS.lblNoMember.Text, If(frmPOS2.txtdiskonpersen.Text = "", "0", frmPOS2.txtdiskonpersen.Text),
                                                    If(frmPOS2.txtdiskonrupiah.Text = "", "0", frmPOS2.txtdiskonrupiah.Text), frmPOS2.lblKasir.Text)
        If proses Then
            Dispose()
        End If
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnProses_Click(o, e)
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dispose()
    End Sub
End Class