Imports System.Configuration
Imports Connection
Imports Ext
Public Class clsTrans
#Region "Declare"
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance
    Dim idtoko As String = ConfigurationSettings.AppSettings("ID")
#End Region
#Region "Penerimaan"
    Public Function addPenerimaanTemp() As String
        Try
            Dim queries As New List(Of String)()
            Dim valuesPenerimaanTemp As String = ""
            Dim dt As DataTable = getPengirimanFromMacarons()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row("id").ToString
                    Dim no_sj As String = row("nopengiriman").ToString
                    Dim tanggal_kirim As String = CDate(row("tanggal_kirim")).ToString("yyyy-MM-dd")
                    Dim itemID As String = row("item_id").ToString
                    Dim bcode As String = row("kode").ToString
                    Dim harga As String = row("harga").ToString
                    Dim harga_jual As String = row("harga_jual").ToString
                    Dim jml_item As String = row("jml_item").ToString
                    Dim userID As String = row("user_id").ToString
                    Dim tenant As String = row("tujuan_id").ToString
                    Dim section As String = row("section").ToString
                    Dim catatan As String = row("ket").ToString
                    Dim asal As String = row("toko_id").ToString
                    valuesPenerimaanTemp &= $"('{tanggal_kirim}','{itemID}','{jml_item}','{no_sj}','{tenant}','{bcode}','{harga}','{harga_jual}','{section}'),"
                    Dim queryString As String = "update_PengirimanSync"
                    Dim parameters As New Dictionary(Of String, Object)()
                    parameters.Add("@idKirim", id)
                    Dim upd As Integer = con.ubahdatabaseado3(queryString, parameters, False)
                Next
                valuesPenerimaanTemp = "(" & Chr(34) & Left(valuesPenerimaanTemp, valuesPenerimaanTemp.Length - 1) & Chr(34) & ")"
                Dim penjualanTambahQuery As String = $"CALL add_PenerimaanTempMacarons {valuesPenerimaanTemp};"
                queries.Add(penjualanTambahQuery)

                Dim PengirimanSync As Boolean = con.ExecuteTrans(queries, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Function

    Private Function getPengirimanFromMacarons() As DataTable
        Try
            Dim queryString As String = "CALL get_PengirimanFromMacarons()"
            Return con.FillDataTable3(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Voucher"
    Public Function addVoucher() As String
        Try
            Dim queries As New List(Of String)()
            Dim valuesVoucher As String = ""
            Dim dt As DataTable = getVoucher()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row("id").ToString
                    Dim nominal As String = row("nominal").ToString
                    Dim barcode As String = row("barcode").ToString
                    Dim tgl_cetak As String = Convert.ToDateTime(row("tgl_cetak")).ToString("yyyy-MM-dd HH:mm:ss")
                    Dim aktif As String = row("flg_aktif").ToString
                    valuesVoucher &= $"('{id}','{nominal}','{barcode}','{tgl_cetak}','0',now(),'{aktif}'),"
                    Dim queryString As String = "update_VoucherSync"
                    Dim parameters As New Dictionary(Of String, Object)()
                    parameters.Add("@idVoucher", id)
                    Dim upd As Integer = con.ubahdatabaseado3(queryString, parameters, False)
                Next
                valuesVoucher = "(" & Chr(34) & Left(valuesVoucher, valuesVoucher.Length - 1) & Chr(34) & ")"
                Dim voucherTambahQuery As String = $"CALL add_VoucherMacarons {valuesVoucher};"
                queries.Add(voucherTambahQuery)

                con.ExecuteTrans(queries, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Function

    Private Function getVoucher() As DataTable
        Try
            Dim queryString As String = "CALL get_DataVoucher()"
            Return con.FillDataTable3(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Supplier"
    Public Sub addSupplier()
        Dim strID As String = ""
        Dim strDtl As String = ""
        Try
            Dim dt As DataTable = getIDSupplierOffline()
            strID = String.Join(","c, dt.AsEnumerable().Select(Function(x) "'" & x.Field(Of String)("id") & "'").ToArray())
            Dim dt2 As DataTable = getSupplierOnline(strID)

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
                Dim spName As String = "add_DataSupplierBulk"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@valuesList", strDtl)

                Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getIDSupplierOffline() As DataTable
        Try
            Dim queryString As String = "CALL get_IDSupplier()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
    Private Function getSupplierOnline(ByVal idSupp As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataSupplier(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", idSupp)
            Return con.FillDataTable3(queryString, parameters)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Brand"
    Public Sub addBrand()
        Dim strID As String = ""
        Dim strDtl As String = ""
        Try
            Dim dt As DataTable = getIDBrandOffline()
            strID = String.Join(","c, dt.AsEnumerable().Select(Function(x) "'" & x.Field(Of String)("id") & "'").ToArray())
            Dim dt2 As DataTable = getBrandOnline(strID)

            If dt2.Rows.Count > 0 Then
                For Each row As DataRow In dt2.Rows
                    Dim id As String = row.Item("id").ToString
                    Dim kode As String = row.Item("kode").ToString
                    Dim nama As String = row.Item("nama").ToString
                    Dim flg_aktif As String = row.Item("flg_aktif").ToString
                    strDtl &= "('" & id & "','" & kode & "','" & nama & "','" & flg_aktif & "','1'),"
                Next
                strDtl = Strings.Left(strDtl, strDtl.Length - 1)
                Dim spName As String = "add_DataBrandBulk"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@valuesList", strDtl)

                Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getIDBrandOffline() As DataTable
        Try
            Dim queryString As String = "CALL get_IDBrand()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
    Private Function getBrandOnline(ByVal idBrand As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataBrand(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", idBrand)
            Return con.FillDataTable3(queryString, parameters)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Artikel"
    Public Sub addArtikel()
        Dim strID As String = ""
        Dim strDtl As String = ""
        Try
            Dim dt As DataTable = getIDArtikelOffline()
            strID = String.Join(","c, dt.AsEnumerable().Select(Function(x) "'" & x.Field(Of String)("id") & "'").ToArray())
            Dim dt2 As DataTable = getArtikelOnline(strID)

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
                Dim spName As String = "add_DataArtikelBulk"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@valuesList", strDtl)

                Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getIDArtikelOffline() As DataTable
        Try
            Dim queryString As String = "CALL get_IDArtikel()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
    Private Function getArtikelOnline(ByVal idArtikel As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataArtikel(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", idArtikel)
            Return con.FillDataTable3(queryString, parameters)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Retur Pengiriman"
    Public Sub syncReturPengiriman()
        Dim queries As New List(Of String)()
        Dim valuesRetur As String = ""
        Try
            Dim dt As DataTable = getReturPengirimanOffline()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row.Item("id").ToString
                    Dim no_retur As String = row.Item("no_retur").ToString
                    Dim tgl As String = CDate(row("tgl")).ToString("yyyy-MM-dd")
                    Dim kode As String = row.Item("kode").ToString
                    Dim harga As String = row.Item("harga").ToString
                    Dim jumlah As String = row.Item("jumlah").ToString
                    Dim tgl_insert As String = Convert.ToDateTime(row.Item("tgl_insert")).ToString("yyyy-MM-dd HH:mm:ss")
                    Dim userID As String = row.Item("userid").ToString
                    Dim kasir As String = row.Item("kasir").ToString
                    valuesRetur &= "('" & id & "','" & no_retur & "','" & tgl & "','" & kode & "','" & harga & "','" & jumlah &
                        "','" & tgl_insert & "','" & userID & "','" & kasir & "','0',now()),"

                    Dim spName As String = "POS_update_FlgSyncReturPengiriman"
                    Dim parameters As New Dictionary(Of String, Object)()
                    parameters.Add("@idRetur", id)
                    con.ubahdatabaseado(spName, parameters, False)

                Next
                valuesRetur = "(" & Chr(34) & Left(valuesRetur, valuesRetur.Length - 1) & Chr(34) & ")"
                Dim addRetur As String = $"CALL add_DataReturPengirimanBulk {valuesRetur};"
                queries.Add(addRetur)

                con.ExecuteTrans3(queries, False)
            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Private Function getReturPengirimanOffline() As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataReturPengiriman()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
#Region "Sync Penjualan"
    Public Function syncPenjualan() As String
        Dim queries As New List(Of String)()
        Dim queries2 As New List(Of String)()
        Dim valuesPosPenjualan As String = ""
        Dim maxRetry As Integer = 5
        Dim attempt As Integer = 0
        Dim success As Boolean = False
        Dim idList As New List(Of String)
        Try
            Dim dt As DataTable = getSyncPosPenjualan()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim id As String = row.Item("id").ToString
                    Dim nonota As String = row.Item("nonota").ToString
                    Dim tanggal_jual As String = CDate(row.Item("tanggal_jual")).ToString("yyyy-MM-dd")
                    Dim nomember As String = row.Item("nomember").ToString
                    Dim kode As String = row.Item("kode").ToString
                    Dim jml As String = row.Item("jml").ToString
                    Dim harga_item As String = row.Item("harga_item").ToString
                    Dim diskon_rp As String = row.Item("diskon_rp").ToString
                    Dim diskon_persen As String = row.Item("diskon_persen").ToString
                    Dim total As String = row.Item("total").ToString
                    Dim user_id As String = row.Item("user_id").ToString
                    Dim flg_aktif As String = row.Item("flg_aktif").ToString
                    Dim bayar As String = row.Item("bayar").ToString
                    Dim flg_edc As String = row.Item("flg_edc").ToString
                    Dim bank_id As String = row.Item("bank_id").ToString
                    Dim no_edc As String = row.Item("no_edc").ToString
                    Dim diskon_total_rp As String = row.Item("diskon_total_rp").ToString
                    Dim diskon_total_persen As String = row.Item("diskon_total_persen").ToString
                    Dim kasir As String = row.Item("kasir").ToString
                    Dim flg_print As String = row.Item("flg_print").ToString
                    Dim waktu_print As String = row.Item("flg_print").ToString
                    Dim flg_qris As String = row.Item("flg_qris").ToString
                    Dim total_asli As String = row.Item("total_asli").ToString
                    Dim total_pembulatan As String = row.Item("total_pembulatan").ToString
                    Dim no_member As String = row.Item("no_member").ToString
                    Dim diskon_member As String = row.Item("diskon_member").ToString
                    Dim ts As String = ""
                    If Not IsDBNull(row.Item("ts")) AndAlso Not String.IsNullOrEmpty(row.Item("ts").ToString()) Then
                        ts = Convert.ToDateTime(row.Item("ts")).ToString("yyyy-MM-dd HH:mm:ss")
                    End If

                    valuesPosPenjualan &= "('" & id & "','" & nonota & "','" & tanggal_jual & "','" & nomember & "','" & kode & "','" & jml & "','" & harga_item &
                        "','" & diskon_rp & "','" & diskon_persen & "','" & total & "','" & user_id & "','" & flg_aktif & "','" & bayar & "','" &
                        flg_edc & "','" & bank_id & "','" & no_edc & "','" & diskon_total_rp & "','" & diskon_total_persen & "','" & kasir &
                        "','" & flg_print & "','" & waktu_print & "','" & flg_qris & "','" & total_asli & "','" & total_pembulatan & "','" &
                        no_member & "','" & diskon_member & "','" & ts & "'),"

                    ' Kumpulkan semua ID
                    idList.Add("'" & row.Item("id").ToString() & "'")

                Next
                If idList.Count > 0 Then
                    Dim idInClause As String = String.Join(",", idList)
                    idInClause = "(" & Chr(34) & idInClause & Chr(34) & ")"
                    Dim bulkUpdateQuery As String = $"CALL update_pos_penjualan_sync {idInClause};"
                    queries2.Add(bulkUpdateQuery) ' Masukkan ke dalam query batch untuk dieksekusi bersama yang lainnya
                    con.ExecuteTrans(queries2, False)
                End If

                valuesPosPenjualan = "(" & Chr(34) & Left(valuesPosPenjualan, valuesPosPenjualan.Length - 1) & Chr(34) & ")"
                Dim posPenjualanTambahQuery As String = $"CALL add_DataSyncPosPenjualan {valuesPosPenjualan};"
                queries.Add(posPenjualanTambahQuery)

                Do While Not success AndAlso attempt < maxRetry
                    Try
                        success = con.ExecuteTrans3(queries, False)
                    Catch ex As Exception

                    End Try

                    attempt += 1

                    If Not success Then
                        Threading.Thread.Sleep(3000)
                    End If
                Loop

            End If
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return ""
        End Try
    End Function
    Private Function getSyncPosPenjualan() As DataTable
        Try
            Dim queryString As String = "CALL get_DataSyncPosPenjualan()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return Nothing
        End Try
    End Function
#End Region
End Class
