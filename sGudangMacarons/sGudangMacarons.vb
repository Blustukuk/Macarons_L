Imports System.Configuration
Imports Connection
Imports Ext
Public Class sGudangMacarons
#Region "Declare"
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.instance
    Dim ipRemoteServer As String = ConfigurationSettings.AppSettings("DB:IPServer2")
#End Region
#Region "StartStop"
    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

#End Region

#Region "Penjualan"
    Private Sub _tGetPengiriman_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tPenjualanNESP.Elapsed
        Try
            If (bwPenjualanNESP.IsBusy) Then
                bwPenjualanNESP.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwPenjualanNESP.RunWorkerAsync()))
                myTask.Start()
            Else
                bwPenjualanNESP.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub _bwPenjualan_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwPenjualanNESP.DoWork
        Dim tx As New clsTrans
        Dim sproses As String
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                sproses = tx.Penjualan
            End If
        End If
    End Sub

    Private Sub _tPenjualanMacarons_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tPenjualanMacarons.Elapsed
        Try
            If (bwPenjualanMacarons.IsBusy) Then
                bwPenjualanMacarons.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwPenjualanMacarons.RunWorkerAsync()))
                myTask.Start()
            Else
                bwPenjualanMacarons.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub _bwPenjualanMacarons_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwPenjualanMacarons.DoWork
        Dim tx As New clsTrans
        Dim sproses As String
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                sproses = tx.PenjualanMacarons
            End If
        End If
    End Sub

#End Region
#Region "Supplier"
    Private Sub _tSupplier_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tSupplier.Elapsed
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

    Private Sub _bwSupplier_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwSupplier.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncSupplier()
            End If
        End If

    End Sub
#End Region
#Region "Brand"
    Private Sub _tBrand_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tBrand.Elapsed
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

    Private Sub _bwBrand_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwBrand.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncBrand()
            End If
        End If
    End Sub

#End Region
#Region "Artikel"
    Private Sub _tArtikel_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tArtikel.Elapsed
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

    Private Sub _bwArtikel_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwArtikel.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncArtikel()
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
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncVoucher()
            End If
        End If
    End Sub
#End Region
#Region "Item"
    Private Sub bwItem_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwItem.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncItem()
            End If
        End If
    End Sub

    Private Sub tItem_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tItem.Elapsed
        Try
            If (bwItem.IsBusy) Then
                bwItem.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwItem.RunWorkerAsync()))
                myTask.Start()
            Else
                bwItem.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
#End Region
#Region "Retur Penjualan"
    Private Sub tReturPenjualan_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tReturPenjualan.Elapsed
        Try
            If (bwReturPenjualan.IsBusy) Then
                bwReturPenjualan.CancelAsync()
                Dim myTask As New Task(Sub()
                                           Threading.Thread.Sleep(30000)
                                       End Sub)
                myTask.ContinueWith((Sub() bwReturPenjualan.RunWorkerAsync()))
                myTask.Start()
            Else
                bwReturPenjualan.RunWorkerAsync()
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwReturPenjualan_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwReturPenjualan.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncReturPenjualan()
            End If
        End If
    End Sub

#End Region
End Class
