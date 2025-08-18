Public Class frmLapPengadaanByNama
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmLapPengadaanByNama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = (mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Call gantiwarnaform(sender, 231, 127, 103)
        Call frmLapPengadaanByNamaLoad()
    End Sub

    Private Sub cbxBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBrand.SelectedIndexChanged
        If lblproses.Text = "1" Then
            Dim dt As DataTable = loadDataArtikelByIDBrand(cbxBrand.SelectedValue)
            lblproses.Text = "0"
            With cbxArtikel
                .DataSource = dt
                .DisplayMember = "artikel"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
            lblproses.Text = "1"
        End If
    End Sub

    Private Sub cbxArtikel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxArtikel.SelectedIndexChanged
        If lblproses.Text = "1" Then
            Dim nama As String = getNamaItem(cbxSupplier.SelectedValue, cbxArtikel.SelectedValue)
            txtNama.Text = nama
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        lappengadaanByNamaclick(cbxSupplier.SelectedValue, cbxBrand.SelectedValue, cbxArtikel.SelectedValue, txtNama.Text)
        Dispose()
    End Sub
End Class