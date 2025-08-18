Public Class frmPenjualanJml
    Private Sub frmPenjualanJml_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call gantiwarnaform(sender, 48, 57, 82)
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        txtjml.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F2 Then
            btnAntrian_Click(o, e)
        End If
    End Sub

    Private Sub btnAntrian_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If lblbarcode.Text = "" Or txtjml.Text = "" Or IsNumeric(txtjml.Text) = False Or txtjml.Text = "0" Then
            MsgBox("Isi dahulu data penjualan dengan benar")
        Else
            Dim kode As String = lblbarcode.Text
            Dim jml As String = txtjml.Text
            Dim tujuan As String = frmPenjualan.cbx7an.SelectedValue
            Dim stokAman As Boolean = cekStok(kode, jml, tujuan)
            If stokaman Then
                Dim tambahtemp As Boolean = tambahPenjualanTemp(frmPenjualan.dtp1.Value, tujuan, kode, jml, getnumber(lblHarga.Text))
                If tambahtemp Then
                    lblbarcode.Text = "-"
                    lblNama.Text = "-"
                    Dispose()
                    frmPenjualan.txtkodeitem.Focus()
                End If
            Else
                MsgBox("Stok barang kurang.", vbCritical, "Macarons")
            End If
        End If
    End Sub
End Class