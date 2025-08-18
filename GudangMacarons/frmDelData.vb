Public Class frmDelData
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnDelPembelian_Click(sender As Object, e As EventArgs) Handles btnDelPembelian.Click
        If Application.OpenForms().OfType(Of frmDelDataPembelian).Any Then
            AppActivate(frmDelDataPembelian.Text)
        Else
            frmDelDataPembelian.Show()
        End If
        Dispose()
    End Sub

    Private Sub btnDelCetakBarcode_Click(sender As Object, e As EventArgs) Handles btnDelCetakBarcode.Click
        If Application.OpenForms().OfType(Of frmDelDataCetakBarcode).Any Then
            AppActivate(frmDelDataCetakBarcode.Text)
        Else
            frmDelDataCetakBarcode.Show()
        End If
        Dispose()
    End Sub
End Class