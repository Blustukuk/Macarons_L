Imports System.Configuration
Imports Connection
Imports Ext
Public Class sPOSGudangMacarons
#Region "StartStop"
    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

#End Region
#Region "Declare"
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance
    Dim ipRemoteServer As String = ConfigurationManager.AppSettings("DB:IPServer3")
#End Region
#Region "PenerimaanTemp"
    Private Sub _taddPenerimaanTemp_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles taddPenerimaanTemp.Elapsed
        Try
            If (bwaddPenerimaanTemp.IsBusy) Then
                bwaddPenerimaanTemp.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwaddPenerimaanTemp.RunWorkerAsync()))
                myTask.Start()
            Else
                bwaddPenerimaanTemp.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub _bwaddPenerimaanTemp_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwaddPenerimaanTemp.DoWork
        Dim tx As New clsTrans
        Dim sproses As String
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 400 Then
                sproses = tx.addPenerimaanTemp
            End If
        End If
    End Sub

#End Region
#Region "Voucher"
    Private Sub tVoucher_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tVoucher.Elapsed
        Try
            If (bwVoucher.IsBusy) Then
                bwVoucher.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwVoucher.RunWorkerAsync()))
                myTask.Start()
            Else
                bwVoucher.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwVoucher_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwVoucher.DoWork
        Dim tx As New clsTrans
        Dim sproses As String
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                sproses = tx.addVoucher
            End If
        End If
    End Sub


#End Region
#Region "Retur Pengiriman"
    Private Sub tReturPengiriman_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tReturPengiriman.Elapsed
        Try
            If (bwReturPengiriman.IsBusy) Then
                bwReturPengiriman.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwReturPengiriman.RunWorkerAsync()))
                myTask.Start()
            Else
                bwReturPengiriman.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwReturPengiriman_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwReturPengiriman.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncReturPengiriman()
            End If
        End If
    End Sub

#End Region
#Region "Brand"
    Private Sub tBrand_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tBrand.Elapsed
        Try
            If (bwBrand.IsBusy) Then
                bwBrand.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwBrand.RunWorkerAsync()))
                myTask.Start()
            Else
                bwBrand.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwBrand_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwBrand.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.addBrand()
            End If
        End If
    End Sub

#End Region
#Region "Artikel"
    Private Sub tArtikel_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tArtikel.Elapsed
        Try
            If (bwArtikel.IsBusy) Then
                bwArtikel.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwArtikel.RunWorkerAsync()))
                myTask.Start()
            Else
                bwArtikel.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwArtikel_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwArtikel.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.addArtikel()
            End If
        End If
    End Sub

#End Region
#Region "Supplier"
    Private Sub tSupplier_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tSupplier.Elapsed
        Try
            If (bwSupplier.IsBusy) Then
                bwSupplier.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwSupplier.RunWorkerAsync()))
                myTask.Start()
            Else
                bwSupplier.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwSupplier_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwSupplier.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.addSupplier()
            End If
        End If
    End Sub

#End Region

#Region "Sync Penjualan"
    Private Sub tPenjualan_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tPenjualan.Elapsed
        Try
            If (bwPenjualan.IsBusy) Then
                bwPenjualan.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwPenjualan.RunWorkerAsync()))
                myTask.Start()
            Else
                bwPenjualan.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwPenjualan_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwPenjualan.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncPenjualan()
            End If
        End If
    End Sub

#End Region
End Class
