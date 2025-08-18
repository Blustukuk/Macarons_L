Public Class frmPengadaanJml
    Private Sub frmPengadaanJml_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        txtjml.Focus()
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Dispose()
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        Dim tambahtemp As Boolean
        If lblBrand.Text = "" Or txtjml.Text = "" Or IsNumeric(txtjml.Text) = False Or txtHarga.Text = "" Or IsNumeric(txtHarga.Text) = False Then
            MsgBox("Isi dahulu data jumlah pengadaan dengan benar")
        Else
            Dim nonota As String = Split(frmPengadaan.cbxNoNota.SelectedValue, "^")(0)
            tambahtemp = addPengadaanTempManual(nonota, frmPengadaan.DTP1.Value, lblBrandID.Text, lblArtikelID.Text, lblNama.Text, txtjml.Text, txtHarga.Text)
            If tambahtemp Then
                lblBrand.Text = "-"
                lblArtikel.Text = "-"
                lblNama.Text = "-"
                lblBrandID.Text = "0"
                lblArtikelID.Text = "0"
                txtjml.Text = ""
                txtHarga.Text = ""
                Me.Dispose()
            Else
                MsgBox("Proses pengadaan manual gagal, cek kembali data pengadaan manual.", vbOKOnly, "Macarons")
            End If
        End If
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F2 Then
            Dim tambahtemp As Boolean
            If lblBrand.Text = "" Or txtjml.Text = "" Or IsNumeric(txtjml.Text) = False Or txtHarga.Text = "" Or IsNumeric(txtHarga.Text) = False Then
                MsgBox("Isi dahulu data jumlah pengadaan dengan benar")
            Else
                Dim nonota As String = Split(frmPengadaan.cbxNoNota.SelectedValue, "^")(0)
                tambahtemp = addPengadaanTempManual(nonota, frmPengadaan.DTP1.Value, lblBrandID.Text, lblArtikelID.Text, lblNama.Text, txtjml.Text, txtharga.text)
                If tambahtemp Then
                    lblBrand.Text = "-"
                    lblArtikel.Text = "-"
                    lblNama.Text = "-"
                    lblBrandID.Text = "0"
                    lblArtikelID.Text = "0"
                    Me.Dispose()
                Else
                    MsgBox("Proses pengadaan manual gagal, cek kembali data pengadaan manual.", vbOKOnly, "Macarons")
                End If
            End If
        End If
    End Sub
End Class