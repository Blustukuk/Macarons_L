Imports System.ServiceProcess
Public Class frmLain
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnGantiPass.Click
        If Application.OpenForms().OfType(Of frmGantiPass).Any Then
            AppActivate(frmGantiPass.Text)
        Else
            frmGantiPass.Show()
        End If
    End Sub

    Private Sub btnPenerimaan_Click(sender As Object, e As EventArgs) Handles btnPenerimaan.Click
        If Application.OpenForms().OfType(Of frmPenerimaan).Any Then
            AppActivate(frmPenerimaan.Text)
        Else
            frmPenerimaan.Show()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnRetur_Click(sender As Object, e As EventArgs) Handles btnRetur.Click
        If Application.OpenForms().OfType(Of frmReturPengiriman).Any Then
            AppActivate(frmReturPengiriman.Text)
        Else
            frmReturPengiriman.Show()
        End If
        Dispose()
    End Sub

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        Dim a As New frminputbox
        Dim delpass As String = ""
        Dim isAdmin As Boolean
        If a.ShowDialog("Laporan", "Untuk melanjutkan proses lihat laporan dibutuhkan kode konfirmasi.",
                           "Kode Konfirmasi", delpass, False) = System.Windows.Forms.DialogResult.Cancel Then
            Beep()
        Else
            isAdmin = validAdmin(delpass)
            If isAdmin Then
                If Application.OpenForms().OfType(Of frmLap).Any Then
                    AppActivate(frmLap.Text)
                Else
                    frmLap.Show()
                End If
            Else
                MsgBox("Kode konfirmasi salah.", vbCritical, "Macarons")
            End If
        End If
    End Sub

    Private Sub frmLain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RestartService("sPOSGudangMacarons")
    End Sub
    Private Sub RestartService(serviceName As String)
        Try
            Dim serviceController As New ServiceController(serviceName)
            If serviceController.Status = ServiceControllerStatus.Running Then
                ' Hentikan layanan jika sedang berjalan
                serviceController.Stop()
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped)
            End If
            ' Mulai kembali layanan
            serviceController.Start()
            serviceController.WaitForStatus(ServiceControllerStatus.Running)
            'MessageBox.Show("Layanan " & serviceName & " telah dimulai kembali.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Gagal memulai ulang layanan " & serviceName & ": " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCariCepatStok_Click(sender As Object, e As EventArgs) Handles btnCariCepatStok.Click
        If Application.OpenForms().OfType(Of frmCariCepatStok).Any Then
            AppActivate(frmCariCepatStok.Text)
        Else
            frmCariCepatStok.Show()
        End If
    End Sub

    Private Sub btnCariCepatPenjualan_Click(sender As Object, e As EventArgs) Handles btnCariCepatPenjualan.Click
        If Application.OpenForms().OfType(Of frmCariCepatPenjualan).Any Then
            AppActivate(frmCariCepatPenjualan.Text)
        Else
            frmCariCepatPenjualan.Show()
        End If
    End Sub
End Class