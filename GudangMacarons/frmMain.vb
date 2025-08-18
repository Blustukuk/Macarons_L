Public Class frmMain
    Private MouseIsDown As Boolean = False
    Private MouseIsDownLoc As Point = Nothing
    Private Sub btnDashboardHargaBarang_Click(sender As Object, e As EventArgs) Handles btnMasterSupplier.Click
        If Application.OpenForms().OfType(Of frmMasterSupplier).Any Then
            AppActivate(frmMasterSupplier.Text)
        Else
            frmMasterSupplier.Show()
        End If
    End Sub

    Private Sub tJam_Tick(sender As Object, e As EventArgs) Handles tJam.Tick
        lbltgljam.Text = "Sekarang : " & CDate(Now).ToString("yyyy-MM-dd HH:mm:ss")
    End Sub
    Private Sub Guna2Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            If MouseIsDown = False Then
                MouseIsDown = True
                MouseIsDownLoc = New Point(e.X, e.Y)
            End If
            Me.Location = New Point(Me.Location.X + e.X - MouseIsDownLoc.X, Me.Location.Y + e.Y - MouseIsDownLoc.Y)
        End If
    End Sub
    Private Sub Guna2Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseUp
        MouseIsDown = False
    End Sub

    Private Sub btnDashboardMasterCustomer_Click(sender As Object, e As EventArgs) Handles btnMasterBrand.Click
        If Application.OpenForms().OfType(Of frmMasterBrand).Any Then
            AppActivate(frmMasterBrand.Text)
        Else
            frmMasterBrand.Show()
        End If
    End Sub

    Private Sub btnDashboardMasterSupplier_Click(sender As Object, e As EventArgs) Handles btnMasterArtikel.Click
        If Application.OpenForms().OfType(Of frmMasterArtikel).Any Then
            AppActivate(frmMasterArtikel.Text)
        Else
            frmMasterArtikel.Show()
        End If
    End Sub

    Private Sub btnDashboardPembayaranInvoice_Click(sender As Object, e As EventArgs) Handles btnCetakBarcode.Click
        If Application.OpenForms().OfType(Of frmCetakBarcode).Any Then
            AppActivate(frmCetakBarcode.Text)
        Else
            frmCetakBarcode.Show()
        End If
    End Sub

    Private Sub btnBarcodeManual_Click(sender As Object, e As EventArgs) Handles btnBarcodeManual.Click
        If Application.OpenForms().OfType(Of frmCetakBarcodeManual).Any Then
            AppActivate(frmCetakBarcodeManual.Text)
        Else
            frmCetakBarcodeManual.Show()
        End If
    End Sub

    Private Sub btnPembelian_Click(sender As Object, e As EventArgs) Handles btnPembelian.Click
        If Application.OpenForms().OfType(Of frmPembelian).Any Then
            AppActivate(frmPembelian.Text)
        Else
            frmPembelian.Show()
        End If
    End Sub

    Private Sub btnPengadaan_Click(sender As Object, e As EventArgs) Handles btnPengadaan.Click
        If Application.OpenForms().OfType(Of frmPengadaan).Any Then
            AppActivate(frmPengadaan.Text)
        Else
            frmPengadaan.Show()
        End If
    End Sub

    Private Sub btnPenjualan_Click(sender As Object, e As EventArgs) Handles btnPenjualan.Click
        If Application.OpenForms().OfType(Of frmPenjualan).Any Then
            AppActivate(frmPenjualan.Text)
        Else
            frmPenjualan.Show()
        End If
    End Sub

    Private Sub btnDashboardLogOut_Click(sender As Object, e As EventArgs) Handles btnDashboardLogOut.Click
        statuslogout(lblUserID.Text)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Environment.Exit(0)
        End If
    End Sub

    Private Sub btnGantiPassword_Click(sender As Object, e As EventArgs) Handles btnGantiPassword.Click
        If Application.OpenForms().OfType(Of frmGantiPass).Any Then
            AppActivate(frmGantiPass.Text)
        Else
            frmGantiPass.Show()
        End If
    End Sub

    Private Sub btnEditStok_Click(sender As Object, e As EventArgs) Handles btnEditStok.Click
        If Application.OpenForms().OfType(Of frmEditStok).Any Then
            AppActivate(frmEditStok.Text)
        Else
            frmEditStok.Show()
        End If
    End Sub

    Private Sub btnBatalPembelian_Click(sender As Object, e As EventArgs) Handles btnBatalPembelian.Click
        If Application.OpenForms().OfType(Of frmBatalPembelian).Any Then
            AppActivate(frmBatalPembelian.Text)
        Else
            frmBatalPembelian.Show()
        End If
    End Sub

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        If Application.OpenForms().OfType(Of frmLap).Any Then
            AppActivate(frmLap.Text)
        Else
            frmLap.Show()
        End If
    End Sub

    Private Sub btnVoucher_Click(sender As Object, e As EventArgs) Handles btnVoucher.Click
        If Application.OpenForms().OfType(Of frmVoucher).Any Then
            AppActivate(frmVoucher.Text)
        Else
            frmVoucher.Show()
        End If
    End Sub

    Private Sub btnPengadaanKhusus_Click(sender As Object, e As EventArgs) Handles btnPengadaanKhusus.Click
        If Application.OpenForms().OfType(Of frmPengadaanKhusus).Any Then
            AppActivate(frmPengadaanKhusus.Text)
        Else
            frmPengadaanKhusus.Show()
        End If
    End Sub

    Private Sub btnReturPenjualan_Click(sender As Object, e As EventArgs) Handles btnReturPenjualan.Click
        If Application.OpenForms().OfType(Of frmReturPenjualan2).Any Then
            AppActivate(frmReturPenjualan2.Text)
        Else
            frmReturPenjualan2.Show()
        End If
    End Sub

    Private Sub btnDelAllData_Click(sender As Object, e As EventArgs) Handles btnDelAllData.Click
        If Application.OpenForms().OfType(Of frmDelData).Any Then
            AppActivate(frmDelData.Text)
        Else
            frmDelData.Show()
        End If
    End Sub
End Class