Imports Connection
Imports Ext
Module moduleControl
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance
    Function Undian_Get_DataPeserta() As DataTable
        Try
            Dim queryString As String = "CALL get_DataPesertaUndian()"

            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil data peserta: " & ex.Message)
            Return Nothing
        End Try
    End Function
    Function SimpanPemenangKeDatabase(kode As String) As Boolean
        Try
            Dim queryString As String = "CALL insert_PemenangUndian(@barcode)"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@barcode", kode}
            }

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToInt32(result) > 0
        Catch ex As Exception
            MessageBox.Show("Gagal simpan pemenang: " & ex.Message)
            Return False
        End Try
    End Function
End Module
