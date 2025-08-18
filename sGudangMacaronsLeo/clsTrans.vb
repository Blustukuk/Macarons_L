Imports System.Configuration
Imports Connection
Imports Ext
Public Class clsTrans
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance

#Region "Item"
    Public Sub syncItem()
        Dim queries As New List(Of String)()
        Dim strUpdFlg As String = ""
        Dim strDtl As String = ""
        Try
            Dim dt As DataTable = getItemOffline()

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
            Ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getItemOffline() As DataTable
        Try
            Dim queryString As String = "CALL get_DataItem"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            Ext.WriteToErrorLog(ex.Message, ex.StackTrace & vbCrLf & "Get Data Item Error", "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Sync NESP"
    Public Function Penjualan() As Boolean
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
                Return True
            End If
            Return False
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return False
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

End Class
