Imports System.Configuration
Imports Connection
Imports Ext
Imports System.Net.Http
Imports System.Text
Public Class clsTrans
#Region "Declare"
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance
#End Region
#Region "Sync NESP"
    Public Function Penjualan() As String
        Try
            Dim queries As New List(Of String)()
            Dim valuesPenjualan As String = ""
            Dim valuesItem As String = ""
            Dim dt As DataTable = getPenjualanForNESP()
            Dim nopenjualan As String = ""
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row("id").ToString
                    nopenjualan = row("nopenjualan").ToString
                    Dim tanggal_kirim As String = CDate(row("tgl_jual")).ToString("yyyy-MM-dd")
                    Dim custID As String = row("customer_id").ToString
                    Dim bcode As String = row("kode").ToString
                    Dim nama As String = row("nama").ToString
                    Dim jml_item As String = row("jml").ToString
                    Dim ttl As String = row("total").ToString
                    Dim catatan As String = row("catatan").ToString
                    Dim userID As String = row("user_id").ToString
                    Dim harga As String = ttl / jml_item
                    valuesPenjualan &= $"('{id}','{nopenjualan}','{tanggal_kirim}','{bcode}','{nama}','{harga}','{jml_item}','{userID}','1','{custID}','Lt.1','{catatan}','1',now(),0),"
                    Dim cekItem As Boolean = validItemNESP(bcode)
                    If Not cekItem Then
                        valuesItem &= $"('{bcode}','Macarons','{bcode}','{nama}','1'),"
                    End If
                    Dim queryString As String = "update_PenjualanSync"
                    Dim parameters As New Dictionary(Of String, Object)()
                    parameters.Add("@idJual", id)

                    Dim upd As Integer = con.ubahdatabaseado(queryString, parameters, False)
                Next
                valuesPenjualan = "(" & Chr(34) & Left(valuesPenjualan, valuesPenjualan.Length - 1) & Chr(34) & ")"
                Dim penjualanTambahQuery As String = $"CALL add_DataPengirimanNESP {valuesPenjualan};"
                queries.Add(penjualanTambahQuery)

                If valuesItem <> "" Then
                    valuesItem = "(" & Chr(34) & Left(valuesItem, valuesItem.Length - 1) & Chr(34) & ")"
                    Dim itemTambahQuery As String = $"CALL add_DataItemSync {valuesItem};"
                    queries.Add(itemTambahQuery)
                End If

                Dim PengirimanSync As Boolean = con.ExecuteTrans2(queries, False)

                Dim queryString2 As String = "update_SyncTime"
                Dim updt As Integer = con.ubahdatabaseado(queryString2, Nothing, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Function
    Private Function getPenjualanForNESP() As DataTable
        Try
            Dim queryString As String = "CALL get_PenjualanSyncForNESP()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
    Private Function validItemNESP(ByVal bcode As String) As Boolean
        Try
            Dim queryString As String = "CALL valIdItem(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)

            Dim result As Object = con.ExecuteScalar2(queryString, parameters)
            Return Convert.ToInt32(result) > 0
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return False
        End Try
    End Function

#End Region
#Region "Sync Macarons"
    Public Function PenjualanMacarons() As String
        Try
            Dim queries As New List(Of String)()
            Dim valuesPenjualan As String = ""
            Dim valuesItem As String = ""
            Dim dt As DataTable = getPenjualanForMacarons()
            Dim nopenjualan As String = ""
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row("id").ToString
                    nopenjualan = row("nopenjualan").ToString
                    Dim tanggal_kirim As String = CDate(row("tgl_jual")).ToString("yyyy-MM-dd")
                    Dim custID As String = row("customer_id").ToString
                    Dim bcode As String = row("kode").ToString
                    Dim nama As String = row("nama").ToString
                    Dim jml_item As String = row("jml").ToString
                    Dim ttl As String = row("total").ToString
                    Dim catatan As String = row("catatan").ToString
                    Dim userID As String = row("user_id").ToString
                    Dim logo As String = row("logo").ToString
                    Dim harga As String = row("harga").ToString
                    Dim harga_jual As String = row("harga_jual").ToString
                    valuesPenjualan &= $"('{id}','{nopenjualan}','{tanggal_kirim}','{bcode}','{nama}','{harga}','{harga_jual}','{jml_item}','{userID}','1','{custID}','{logo}','{catatan}','1',now(),0),"
                    Dim cekItem As Boolean = validItemMacarons(bcode)
                    If Not cekItem Then
                        valuesItem &= $"('{bcode}','{id}','{bcode}','{nama}','1'),"
                    End If
                    Dim queryString As String = "update_PenjualanSync"
                    Dim parameters As New Dictionary(Of String, Object)()
                    parameters.Add("@idJual", id)

                    Dim upd As Integer = con.ubahdatabaseado(queryString, parameters, False)
                Next
                valuesPenjualan = "(" & Chr(34) & Left(valuesPenjualan, valuesPenjualan.Length - 1) & Chr(34) & ")"
                Dim penjualanTambahQuery As String = $"CALL add_DataPengirimanMacarons {valuesPenjualan};"
                queries.Add(penjualanTambahQuery)

                If valuesItem <> "" Then
                    valuesItem = "(" & Chr(34) & Left(valuesItem, valuesItem.Length - 1) & Chr(34) & ")"
                    Dim itemTambahQuery As String = $"CALL add_DataItemSyncMacarons {valuesItem};"
                    queries.Add(itemTambahQuery)
                End If

                Dim PengirimanSync As Boolean = con.ExecuteTrans3(queries, False)

                If PengirimanSync Then
                    Try
                        Dim serverUrl As String = "http://100.107.14.58:5000/sj_trigger"
                        Dim json As String = $"{{""nopenjualan"":""""}}"
                        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

                        Using client As New HttpClient()
                            Dim response = client.PostAsync(serverUrl, content).Result
                            If response.IsSuccessStatusCode Then
                                ' Optional logging kalau mau tahu sukses
                                Console.WriteLine("Trigger berhasil dikirim ke server Ubuntu.")
                            Else
                                Console.WriteLine("Gagal kirim trigger ke server Ubuntu.")
                            End If
                        End Using
                    Catch ex As Exception
                        ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error kirim trigger")
                    End Try
                End If

                Dim queryString2 As String = "update_SyncTime"
                Dim updt As Integer = con.ubahdatabaseado(queryString2, Nothing, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Function
    Private Function getPenjualanForMacarons() As DataTable
        Try
            Dim queryString As String = "CALL get_PenjualanSyncForPOSMacarons()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
    Private Function validItemMacarons(ByVal bcode As String) As Boolean
        Try
            Dim queryString As String = "CALL valIdItem(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)

            Dim result As Object = con.ExecuteScalar3(queryString, parameters)
            Return Convert.ToInt32(result) > 0
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return False
        End Try
    End Function

#End Region
#Region "Supplier"
    Public Sub syncSupplier()
        Dim strID As String = ""
        Dim strDtl As String = ""
        Try
            Dim dt As DataTable = getIDSupplierOnline()
            strID = String.Join(","c, dt.AsEnumerable().Select(Function(x) "'" & x.Field(Of String)("id") & "'").ToArray())
            Dim dt2 As DataTable = getSupplierOffline(strID)

            If dt2.Rows.Count > 0 Then
                For Each row As DataRow In dt2.Rows
                    Dim id As String = row.Item("id").ToString
                    Dim nama As String = row.Item("nama").ToString
                    Dim pic As String = row.Item("pic").ToString
                    Dim alamat As String = row.Item("alamat").ToString
                    Dim telp As String = row.Item("telp").ToString
                    Dim flg_aktif As String = row.Item("flg_aktif").ToString
                    Dim kode As String = row.Item("kode").ToString
                    strDtl &= "('" & id & "','" & nama & "','" & pic & "','" & alamat & "','" & telp & "','" &
                        flg_aktif & "','" & kode & "'),"
                Next
                strDtl = Strings.Left(strDtl, strDtl.Length - 1)
                Dim spName As String = "add_DataSupplier"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@valuesList", strDtl)

                Dim upd As Integer = con.ubahdatabaseado3(spName, parameters, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getIDSupplierOnline() As DataTable
        Try
            Dim queryString As String = "CALL get_IDSupplier()"
            Return con.FillDataTable3(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
    Private Function getSupplierOffline(ByVal idSupp As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataSupplier(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", idSupp)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Brand"
    Public Sub syncBrand()
        Dim strID As String = ""
        Dim strDtl As String = ""
        Try
            Dim dt As DataTable = getIDBrandOnline()
            strID = String.Join(","c, dt.AsEnumerable().Select(Function(x) "'" & x.Field(Of String)("id") & "'").ToArray())
            Dim dt2 As DataTable = getBrandOffline(strID)

            If dt2.Rows.Count > 0 Then
                For Each row As DataRow In dt2.Rows
                    Dim id As String = row.Item("id").ToString
                    Dim kode As String = row.Item("kode").ToString
                    Dim nama As String = row.Item("nama").ToString
                    Dim flg_aktif As String = row.Item("flg_aktif").ToString
                    strDtl &= "('" & id & "','" & kode & "','" & nama & "','" & flg_aktif & "','1'),"
                Next
                strDtl = Strings.Left(strDtl, strDtl.Length - 1)
                Dim spName As String = "add_DataBrand"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@valuesList", strDtl)

                Dim upd As Integer = con.ubahdatabaseado3(spName, parameters, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getIDBrandOnline() As DataTable
        Try
            Dim queryString As String = "CALL get_IDBrand()"
            Return con.FillDataTable3(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
    Private Function getBrandOffline(ByVal idBrand As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataBrand(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", idBrand)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Artikel"
    Public Sub syncArtikel()
        Dim strID As String = ""
        Dim strDtl As String = ""
        Try
            Dim dt As DataTable = getIDArtikelOnline()
            strID = String.Join(","c, dt.AsEnumerable().Select(Function(x) "'" & x.Field(Of String)("id") & "'").ToArray())
            Dim dt2 As DataTable = getArtikelOffline(strID)

            If dt2.Rows.Count > 0 Then
                For Each row As DataRow In dt2.Rows
                    Dim id As String = row.Item("id").ToString
                    Dim kode As String = row.Item("kode").ToString
                    Dim nama As String = row.Item("nama").ToString
                    Dim brandID As String = row.Item("brand_id").ToString
                    Dim flg_aktif As String = row.Item("flg_aktif").ToString
                    strDtl &= "('" & id & "','" & kode & "','" & nama & "','" & brandID & "','1','1'),"
                Next
                strDtl = Strings.Left(strDtl, strDtl.Length - 1)
                Dim spName As String = "add_DataArtikel"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@valuesList", strDtl)

                Dim upd As Integer = con.ubahdatabaseado3(spName, parameters, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getIDArtikelOnline() As DataTable
        Try
            Dim queryString As String = "CALL get_IDArtikel()"
            Return con.FillDataTable3(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
    Private Function getArtikelOffline(ByVal idArtikel As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataArtikel(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", idArtikel)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace & vbCrLf & idArtikel, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Item"
    Public Sub syncItem()
        Dim queries As New List(Of String)()
        Dim strUpdFlg As String = ""
        Dim strDtl As String = ""
        Try
            Dim dt As DataTable = getItemOffline

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row.Item("id").ToString
                    Dim pengadaanID As String = row.Item("pengadaan_id").ToString
                    Dim kode As String = row.Item("kode").ToString
                    Dim nama As String = row.Item("nama").ToString
                    Dim flg_aktif As String = row.Item("flg_aktif").ToString
                    strDtl &= "('" & kode & "','MacaronsV2','" & kode & "','" & nama & "','" & flg_aktif & "'),"
                    strUpdFlg &= "'" & id & "',"
                Next
                strDtl = Strings.Left(strDtl, strDtl.Length - 1)
                strUpdFlg = Strings.Left(strUpdFlg, strUpdFlg.Length - 1)

                Dim spName As String = "add_DataItem"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@valuesList", strDtl)
                Dim add As Integer = con.ubahdatabaseado2(spName, parameters, False)

                Dim queryString As String = "update_FlgSyncItem"
                Dim parameters2 As New Dictionary(Of String, Object)()
                parameters2.Add("@valuesList", strUpdFlg)
                Dim iupd As Integer = con.ubahdatabaseado(queryString, parameters2, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getItemOffline() As DataTable
        Try
            Dim queryString As String = "CALL get_DataItem"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace & vbCrLf & "Get Data Item Error", "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Voucher"
    Public Sub syncVoucher()
        Dim queries As New List(Of String)()
        Dim valuesVoucher As String = ""
        Try
            Dim dt As DataTable = getVoucherOffline()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row.Item("id").ToString
                    Dim nominal As String = row.Item("nominal").ToString
                    Dim barcode As String = row.Item("barcode").ToString
                    Dim tgl_cetak As String = Convert.ToDateTime(row("tgl_cetak")).ToString("yyyy-MM-dd HH:mm:ss")
                    Dim aktif As String = row("flg_aktif").ToString
                    valuesVoucher &= "('" & id & "','" & nominal & "','" & barcode & "','" & tgl_cetak & "','0','" & aktif & "'),"

                    Dim spName As String = "update_FlgSyncVoucher"
                    Dim parameters As New Dictionary(Of String, Object)()
                    parameters.Add("@idVoucher", id)
                    con.ubahdatabaseado(spName, parameters, False)

                Next
                valuesVoucher = "(" & Chr(34) & Left(valuesVoucher, valuesVoucher.Length - 1) & Chr(34) & ")"
                Dim addVoucher As String = $"CALL add_DataVoucher {valuesVoucher};"
                queries.Add(addVoucher)

                con.ExecuteTrans3(queries, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getVoucherOffline() As DataTable
        Try
            Dim queryString As String = "CALL get_DataVoucher()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Retur Pengiriman"

#End Region
#Region "Retur Penjualan"
    Public Function syncReturPenjualan() As String
        Try
            Dim queries As New List(Of String)()
            Dim valuesPenjualan As String = ""
            Dim valuesItem As String = ""
            Dim dt As DataTable = getReturPenjualanOnline()
            Dim noretur As String = ""
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row("id").ToString
                    noretur = row("no_retur").ToString
                    Dim tanggal As String = CDate(row("tgl")).ToString("yyyy-MM-dd")
                    Dim bcode As String = row("kode").ToString
                    Dim harga As String = row("harga").ToString
                    Dim jml_item As String = row("jumlah").ToString
                    Dim userID As String = row("userid").ToString
                    Dim kasir As String = row("kasir").ToString
                    Dim waktu As String = row("waktu").ToString
                    valuesPenjualan &= $"('{id}','{bcode}','{harga}','{jml_item}','{waktu}','{noretur}','-'),"
                    Dim queryString As String = "update_ReturPenjualanSync"
                    Dim parameters As New Dictionary(Of String, Object)()
                    parameters.Add("@idVoucher", id)
                    Dim upd As Integer = con.ubahdatabaseado3(queryString, parameters, False)
                Next
                valuesPenjualan = "(" & Chr(34) & Left(valuesPenjualan, valuesPenjualan.Length - 1) & Chr(34) & ")"
                Dim penjualanTambahQuery As String = $"CALL add_DataReturTemp2 {valuesPenjualan};"
                queries.Add(penjualanTambahQuery)

                Dim returPenjualan As Boolean = con.ExecuteTrans(queries, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Function
    Private Function getReturPenjualanOnline() As DataTable
        Try
            Dim queryString As String = "CALL get_returPenjualan()"
            Return con.FillDataTable3(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
End Class
