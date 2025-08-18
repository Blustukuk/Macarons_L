Imports System.Configuration
Imports Connection
Imports Ext
Public Class sGudangMacaronsLeo
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.instance
    Dim ipRemoteServer As String = ConfigurationSettings.AppSettings("DB:IPServer2")

#Region "Start Stop"
    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

#End Region

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

    Private Sub tPenjualanNESP_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tPenjualanNESP.Elapsed
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

    Private Sub bwItem_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwItem.DoWork
        Dim tx As New clsTrans
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                tx.syncItem()
            End If
        End If
    End Sub

    Private Sub bwPenjualanNESP_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwPenjualanNESP.DoWork
        Dim tx As New clsTrans
        Dim sproses As Boolean
        If My.Computer.Network.Ping(ipRemoteServer) Then
            If con.pingserver(ipRemoteServer) >= 0 And con.pingserver(ipRemoteServer) <= 300 Then
                sproses = tx.Penjualan
            End If
        End If
    End Sub
End Class
