Imports System.Net
Imports System.Net.NetworkInformation
Imports System.ComponentModel
Imports System.Configuration
Imports System.Threading
Public Class frmStokOpnam
#Region "Declare"
    Private WithEvents bgWorker1 As New BackgroundWorker()
    Private WithEvents bgWorker2 As New BackgroundWorker()
    Private WithEvents bgWorker3 As New BackgroundWorker()
    Private WithEvents bgWorker4 As New BackgroundWorker()
    Private WithEvents bgWorker5 As New BackgroundWorker()
    Private WithEvents bgWorker6 As New BackgroundWorker()
    Private WithEvents bgWorker7 As New BackgroundWorker()
    Private WithEvents bgWorker8 As New BackgroundWorker()
    Private WithEvents bgWorker9 As New BackgroundWorker()
    Private WithEvents bgWorker10 As New BackgroundWorker()
    Private WithEvents bgWorker11 As New BackgroundWorker()
    Private WithEvents bgWorker12 As New BackgroundWorker()
    Private WithEvents bgWorker13 As New BackgroundWorker()
    Private WithEvents bgWorker14 As New BackgroundWorker()
    Private WithEvents bgWorker15 As New BackgroundWorker()
    Private WithEvents bgWorker16 As New BackgroundWorker()
    Dim activeHosts As New List(Of String)()
    Dim namatoko As String = ""
    Dim ipSrv As String = ""
    Dim baseIP As String = ""
#End Region
#Region "Jam"
    Private Sub tJam_Tick(sender As Object, e As EventArgs) Handles tJam.Tick
        lblSekarang.Text = "Sekarang : " & CDate(Now).ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

#End Region
#Region "BgWorker"
    Private Function GetLocalIPAddress() As String
        'Dim lanIpAddress As String = GetLANIPAddress()
        'If Not String.IsNullOrEmpty(lanIpAddress) Then
        '    Return lanIpAddress
        'End If
        Return GetWifiIPAddress()
    End Function
    Private Function GetLANIPAddress() As String
        Dim networkInterfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

        For Each networkInterface As NetworkInterface In networkInterfaces
            If Not networkInterface.Description.Contains("Radmin VPN") AndAlso
           networkInterface.NetworkInterfaceType = NetworkInterfaceType.Ethernet AndAlso
           networkInterface.OperationalStatus = OperationalStatus.Up Then
                Dim ipProperties As IPInterfaceProperties = networkInterface.GetIPProperties()
                Dim unicastAddresses As UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses

                For Each unicastAddress As UnicastIPAddressInformation In unicastAddresses
                    If unicastAddress.Address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                        Return unicastAddress.Address.ToString()
                    End If
                Next
            End If
        Next

        Return ""
    End Function
    Private Function GetWifiIPAddress() As String
        Dim networkInterfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

        For Each networkInterface As NetworkInterface In networkInterfaces
            If networkInterface.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 AndAlso
           networkInterface.OperationalStatus = OperationalStatus.Up Then
                Dim ipProperties As IPInterfaceProperties = networkInterface.GetIPProperties()
                Dim unicastAddresses As UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses

                For Each unicastAddress As UnicastIPAddressInformation In unicastAddresses
                    If unicastAddress.Address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                        Return unicastAddress.Address.ToString()
                    End If
                Next
            End If
        Next

        Return ""
    End Function
    Private Function GetBaseIP(ByVal ipAddress As String) As String
        Dim baseIP As String = ""
        Dim ipParts() As String = ipAddress.Split(".")

        If ipParts.Length = 4 Then
            baseIP = ipParts(0) & "." & ipParts(1) & "." & ipParts(2) & "."
        End If

        Return baseIP
    End Function
    Private Sub bgWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker1.DoWork

        For i As Integer = 1 To 16
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker2.DoWork
        For i As Integer = 17 To 32
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker3.DoWork

        For i As Integer = 33 To 48
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker4_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker4.DoWork
        For i As Integer = 49 To 64
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker5_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker5.DoWork
        For i As Integer = 65 To 80
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker6_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker6.DoWork
        For i As Integer = 81 To 96
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker7_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker7.DoWork
        For i As Integer = 97 To 112
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker8_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker8.DoWork
        For i As Integer = 113 To 128
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker9_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker9.DoWork
        For i As Integer = 129 To 144
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker10_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker10.DoWork
        For i As Integer = 145 To 160
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker11_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker11.DoWork
        For i As Integer = 161 To 176
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker12_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker12.DoWork
        For i As Integer = 177 To 192
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker13_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker13.DoWork
        For i As Integer = 193 To 208
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker14_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker14.DoWork
        For i As Integer = 209 To 224
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker15_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker15.DoWork
        For i As Integer = 225 To 240
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then

                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker16_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker16.DoWork
        For i As Integer = 241 To 255
            Dim ip As String = baseIP & i.ToString()
            Dim reply As PingReply = PingHost(ip)

            If reply.Status = IPStatus.Success Then
                activeHosts.Add(ip)
            End If
        Next
    End Sub
    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgWorker1.RunWorkerCompleted,
        bgWorker2.RunWorkerCompleted, bgWorker3.RunWorkerCompleted, bgWorker4.RunWorkerCompleted, bgWorker5.RunWorkerCompleted,
        bgWorker6.RunWorkerCompleted, bgWorker7.RunWorkerCompleted, bgWorker8.RunWorkerCompleted, bgWorker9.RunWorkerCompleted,
        bgWorker10.RunWorkerCompleted, bgWorker11.RunWorkerCompleted, bgWorker12.RunWorkerCompleted, bgWorker13.RunWorkerCompleted,
        bgWorker14.RunWorkerCompleted, bgWorker15.RunWorkerCompleted, bgWorker16.RunWorkerCompleted
        CheckAllWorkersCompleted()
    End Sub
    Private Sub CheckAllWorkersCompleted()
        If Not bgWorker1.IsBusy And Not bgWorker2.IsBusy And Not bgWorker3.IsBusy And Not bgWorker4.IsBusy And
            Not bgWorker5.IsBusy And Not bgWorker6.IsBusy And Not bgWorker7.IsBusy And Not bgWorker8.IsBusy And
            Not bgWorker9.IsBusy And Not bgWorker10.IsBusy And Not bgWorker11.IsBusy And Not bgWorker12.IsBusy And
            Not bgWorker13.IsBusy And Not bgWorker14.IsBusy And Not bgWorker15.IsBusy And Not bgWorker16.IsBusy Then
            For Each ip As String In activeHosts
                Console.WriteLine("Coba IP : " & ip)
                Dim dt As DataTable = getDataToko(ip)
                If IsNothing(dt) Then
                ElseIf dt.Rows.Count > 0 Then
                    namatoko = dt.Rows(0)("toko")
                    ipSrv = ip
                    Exit For
                End If
            Next
            lblLokasi.Text = "Lokasi : " & namatoko
            lblIP.Text = "IP Server : " & ipSrv
            UpdateAppSetting("DB:SourceData", "Data Source=" & ipSrv & ";Initial Catalog=macarons;Convert Zero Datetime=True;")
            btnCariServer.Enabled = True
            picSearch.Visible = False
        End If
    End Sub
    Private Sub UpdateAppSetting(ByVal key As String, ByVal value As String)
        Dim configFile As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        configFile.AppSettings.Settings(key).Value = value
        configFile.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name)
    End Sub
    Function PingHost(ip As String) As PingReply
        Dim pingSender As New Ping()
        Dim options As New PingOptions()
        Dim timeout As Integer = 50

        Return pingSender.Send(ip, timeout)
    End Function
#End Region
    Private Sub btnCariServer_Click(sender As Object, e As EventArgs) Handles btnCariServer.Click

        If Not bgWorker1.IsBusy And Not bgWorker2.IsBusy And Not bgWorker3.IsBusy And Not bgWorker4.IsBusy And
            Not bgWorker5.IsBusy And Not bgWorker6.IsBusy And Not bgWorker7.IsBusy And Not bgWorker8.IsBusy And
            Not bgWorker9.IsBusy And Not bgWorker10.IsBusy And Not bgWorker11.IsBusy And Not bgWorker12.IsBusy And
            Not bgWorker13.IsBusy And Not bgWorker14.IsBusy And Not bgWorker15.IsBusy And Not bgWorker16.IsBusy Then
            btnCariServer.Enabled = False
            picSearch.Visible = True
            activeHosts.Clear()
            bgWorker1.RunWorkerAsync()
            bgWorker2.RunWorkerAsync()
            bgWorker3.RunWorkerAsync()
            bgWorker4.RunWorkerAsync()
            bgWorker5.RunWorkerAsync()
            bgWorker6.RunWorkerAsync()
            bgWorker7.RunWorkerAsync()
            bgWorker8.RunWorkerAsync()
            bgWorker9.RunWorkerAsync()
            bgWorker10.RunWorkerAsync()
            bgWorker11.RunWorkerAsync()
            bgWorker12.RunWorkerAsync()
            bgWorker13.RunWorkerAsync()
            bgWorker14.RunWorkerAsync()
            bgWorker15.RunWorkerAsync()
            bgWorker16.RunWorkerAsync()
        End If
    End Sub
    Private Sub txtcariitem_TextChanged(sender As Object, e As EventArgs) Handles txtcariitem.TextChanged
        If Me.txtcariitem.TextLength > 3 Then
            Dim i As Integer
            Dim itemcoll(100) As String
            Dim items As New List(Of ListViewItem)
            With lvitem
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = False
                Dim dt As DataTable = loadDataItemByNama(txtcariitem.Text)
                For i = 0 To dt.Columns.Count - 1
                    .Columns.Add(dt.Columns(i).ColumnName.ToString())
                Next
                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        itemcoll(j) = dt.Rows(i)(j).ToString()
                    Next
                    Dim lvi As New ListViewItem(itemcoll)
                    items.Add(lvi)
                Next
                .Items.AddRange(items.ToArray)
                .AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
                .Columns(1).Width = 0
                .Columns(2).Width = 0
                .Columns(3).Width = 0
                .Columns(4).Width = 0
            End With
        ElseIf Me.txtcariitem.Text = "" Then
            Call ClearListView(lvitem)
        End If
    End Sub
    Private Sub frmStokOpnam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmSplash.Show()
        frmSplash.Refresh()

        Thread.Sleep(2000)

        frmSplash.Hide()
        frmSplash.Close()

        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler

        Dim ipSrc As String = cekConfig()
        If ipSrc <> "" Then
            Dim dt As DataTable = getDataToko(ipSrc)
            If IsNothing(dt) Then
            ElseIf dt.Rows.Count > 0 Then
                namatoko = dt.Rows(0)("toko")
                ipSrv = ipSrc
            End If
            lblLokasi.Text = "Lokasi : " & namatoko
            lblIP.Text = "IP Server : " & ipSrv
        End If
        baseIP = GetBaseIP(GetLocalIPAddress)
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            btnProses_Click(o, e)
        ElseIf e.KeyCode = Keys.F2 Then
            btnCariServer_Click(o, e)
        ElseIf e.KeyCode = Keys.F3 Then
            btnLogin_Click(o, e)
        ElseIf e.KeyCode = Keys.F4 Then
            txtkodeitem.Focus()
        ElseIf e.KeyCode = Keys.F5 Then
            txtcariitem.Focus()
        End If
    End Sub
    Private Sub txtkodeitem_GotFocus(sender As Object, e As EventArgs) Handles txtkodeitem.GotFocus
        AcceptButton = btnKodeOK
    End Sub
    Private Sub txtkodeitem_LostFocus(sender As Object, e As EventArgs) Handles txtkodeitem.LostFocus
        AcceptButton = Nothing
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnKodeOK.Click
        Dim kode As String = txtkodeitem.Text
        If lblPengkoreksi.Text <> "Korektor :" Then
            Dim adaStok As String = cekStok(kode)
            If adaStok <> "" Then
                Dim tambahtemp As Boolean = tambahOpnamTemp(kode, adaStok, 1)
                If tambahtemp Then
                    opnamAfterProses()
                    txtkodeitem.Text = ""
                    txtkodeitem.Focus()
                End If
            Else
                Dim tambahWarning As Boolean = tambahWarningtemp(kode, 1)
                If tambahWarning Then
                    opnamAfterProses()
                    txtkodeitem.Text = ""
                    txtkodeitem.Focus()
                End If
            End If
        End If
    End Sub
    Sub opnamAfterProses()
        lblProses.Text = "1"
        dgvOpnam.DataSource = Nothing
        dgvOpnam.Columns.Clear()
        dgvWarning.DataSource = Nothing
        dgvWarning.Columns.Clear()
        Dim dt As DataTable = loadDataOpnameTemp()
        If dt.Rows.Count > 0 Then
            With dgvOpnam
                .DataSource = dt
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                        {New DataGridViewButtonColumn() With
                                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Del", .Text = "Del", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                '.Columns.AddRange(New DataGridViewColumn(0) _
                '                                        {New DataGridViewButtonColumn() With
                '                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Opname", .Text = "Opname", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
            End With
        Else
            dgvOpnam.DataSource = Nothing
            dgvOpnam.Columns.Clear()
        End If
        Dim dt2 As DataTable = loadDataWarning()
        If dt2.Rows.Count > 0 Then
            With dgvWarning
                .DataSource = dt2
                .Columns.AddRange(New DataGridViewColumn(0) _
                                                        {New DataGridViewButtonColumn() With
                                                         {.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .HeaderText = "Del", .Text = "Del", .UseColumnTextForButtonValue = True, .FlatStyle = FlatStyle.Standard, .MinimumWidth = 100}})
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns(0).Visible = False
            End With
        Else
            dgvWarning.DataSource = Nothing
            dgvWarning.Columns.Clear()
        End If
        lblProses.Text = "0"
        txtkodeitem.Text = ""
    End Sub
    Private Sub dgvOpnam_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOpnam.CellContentClick
        If e.ColumnIndex = 8 And e.RowIndex >= 0 Then
            delOpnamTemp(dgvOpnam.Rows(e.RowIndex).Cells(0).Value.ToString)
            opnamAfterProses()
        ElseIf e.ColumnIndex = 9 And e.RowIndex >= 0 Then
            With frmOpname
                .lblBarcode.Text = dgvOpnam.Rows(e.RowIndex).Cells(1).Value.ToString
                .lblNama.Text = dgvOpnam.Rows(e.RowIndex).Cells(2).Value.ToString
                .lblHarga.Text = dgvOpnam.Rows(e.RowIndex).Cells(3).Value.ToString
                .lblQtyKomp.Text = dgvOpnam.Rows(e.RowIndex).Cells(4).Value.ToString
                .lblQtyScan.Text = dgvOpnam.Rows(e.RowIndex).Cells(5).Value.ToString
                .ShowDialog()
            End With
            opnamAfterProses()
        End If
    End Sub
    Private Sub dgvWarning_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWarning.CellContentClick
        If e.ColumnIndex = 3 And e.RowIndex >= 0 Then
            delOpnamTemp(dgvWarning.Rows(e.RowIndex).Cells(0).Value.ToString)
            opnamAfterProses()
        End If
    End Sub
    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If lblPengkoreksi.Text = "Korektor :" Then
            MsgBox("Silahkan LOGIN terlebih dahulu untuk melanjutkan proses simpan data.", vbCritical, "Macarons")
        Else
            Dim prosesStokOpname As MsgBoxResult = MsgBox("Yakin akan menyimpan data stok opname ?" & vbCrLf & "Setelah disimpan, data tidak akan bisa dirubah.", vbYesNo, "Macarons")
            If prosesStokOpname = vbYes Then
                Dim proses As Boolean = prosesSimpanStokOpnam(lblUserID.Text)
                opnamAfterProses()
            Else
                txtkodeitem.Focus()
            End If
        End If
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If lblLokasi.Text <> "Lokasi :" Or lblIP.Text <> "IP Server :" Then
            frmLogin.ShowDialog()
        Else
            MsgBox("Lokasi dan IP Server belum ditemukan. Silahkan klik tombol CARI SERVER terlebih dahulu", vbCritical, "Macarons")
        End If
    End Sub
    Private Sub btnHapusSemua_Click(sender As Object, e As EventArgs) Handles btnHapusSemua.Click
        delALLStokOpname()
        opnamAfterProses()
    End Sub
    Private Sub lvitem_DoubleClick(sender As Object, e As EventArgs) Handles lvitem.DoubleClick
        Dim kode As String = lvitem.SelectedItems(0).SubItems(5).Text
        If lblPengkoreksi.Text <> "Korektor :" Then
            Dim adaStok As String = cekStok(kode)
            If adaStok <> "" Then
                Dim tambahtemp As Boolean = tambahOpnamTemp(kode, adaStok, 1)
                If tambahtemp Then
                    opnamAfterProses()
                    txtkodeitem.Text = ""
                    txtkodeitem.Focus()
                End If
            Else
                Dim tambahWarning As Boolean = tambahWarningtemp(kode, 1)
                If tambahWarning Then
                    opnamAfterProses()
                    txtkodeitem.Text = ""
                    txtkodeitem.Focus()
                End If
            End If
        End If
    End Sub
End Class