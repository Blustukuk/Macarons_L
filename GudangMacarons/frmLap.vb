Public Class frmLap
    Private Sub CetakUlangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CetakUlangToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmPenjualanCetakUlang).Any Then
            AppActivate(frmPenjualanCetakUlang.Text)
        Else
            frmPenjualanCetakUlang.ShowDialog()
        End If
    End Sub

    Private Sub PeriodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeriodeToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPengadaanPeriode).Any Then
            AppActivate(frmLapPengadaanPeriode.Text)
        Else
            frmLapPengadaanPeriode.ShowDialog()
        End If
    End Sub

    Private Sub PeriodeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PeriodeToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmLapPengirimanPeriode).Any Then
            AppActivate(frmLapPengirimanPeriode.Text)
        Else
            frmLapPengirimanPeriode.ShowDialog()
        End If
    End Sub

    Private Sub StokToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StokToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapStokPeriode).Any Then
            AppActivate(frmLapStokPeriode.Text)
        Else
            frmLapStokPeriode.ShowDialog()
        End If
    End Sub

    Private Sub MarginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarginToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPengadaanMarginPerSupplier).Any Then
            AppActivate(frmLapPengadaanMarginPerSupplier.Text)
        Else
            frmLapPengadaanMarginPerSupplier.ShowDialog()
        End If
    End Sub

    Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapHistoryItem).Any Then
            AppActivate(frmLapHistoryItem.Text)
        Else
            frmLapHistoryItem.ShowDialog()
        End If
    End Sub

    Private Sub ByNamaItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByNamaItemToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPengadaanByNama).Any Then
            AppActivate(frmLapPengadaanByNama.Text)
        Else
            frmLapPengadaanByNama.ShowDialog()
        End If
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapReturPenjualan).Any Then
            AppActivate(frmLapReturPenjualan.Text)
        Else
            frmLapReturPenjualan.ShowDialog()
        End If
    End Sub

End Class