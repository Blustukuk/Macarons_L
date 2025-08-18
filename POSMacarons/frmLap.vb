Public Class frmLap
    Private Sub PeriodeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PeriodeToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmLapPenerimaanPeriode).Any Then
            AppActivate(frmLapPenerimaanPeriode.Text)
        Else
            frmLapPenerimaanPeriode.ShowDialog()
        End If
    End Sub

    Private Sub PeriodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeriodeToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPenjualanPeriode).Any Then
            AppActivate(frmLapPenjualanPeriode.Text)
        Else
            frmLapPenjualanPeriode.ShowDialog()
        End If
    End Sub

    Private Sub PerTenantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerTenantToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPenjualanPerTenant).Any Then
            AppActivate(frmLapPenjualanPerTenant.Text)
        Else
            frmLapPenjualanPerTenant.ShowDialog()
        End If
    End Sub

    Private Sub PerNotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerNotaToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPenjualanPerNota).Any Then
            AppActivate(frmLapPenjualanPerNota.Text)
        Else
            frmLapPenjualanPerNota.ShowDialog()
        End If
    End Sub

    Private Sub PerKasirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerKasirToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPenjualanPerKasir).Any Then
            AppActivate(frmLapPenjualanPerKasir.Text)
        Else
            frmLapPenjualanPerKasir.ShowDialog()
        End If
    End Sub

    Private Sub ALLTglBeliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ALLTglBeliToolStripMenuItem.Click
        lapstokpertglbeliclick()
    End Sub

    Private Sub ALLTenantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ALLTenantToolStripMenuItem.Click
        lapstokpertenantclick()
    End Sub

    Private Sub EDCQRISToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EDCQRISToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPenjualanEDCQRIS).Any Then
            AppActivate(frmLapPenjualanEDCQRIS.Text)
        Else
            frmLapPenjualanEDCQRIS.ShowDialog()
        End If
    End Sub

    Private Sub OpnameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpnameToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapStokOpname).Any Then
            AppActivate(frmLapStokOpname.Text)
        Else
            frmLapStokOpname.ShowDialog()
        End If
    End Sub

    Private Sub PengadaanKhususToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengadaanKhususToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLapPenjualanBarangKhusus).Any Then
            AppActivate(frmLapPenjualanBarangKhusus.Text)
        Else
            frmLapPenjualanBarangKhusus.ShowDialog()
        End If
    End Sub
End Class