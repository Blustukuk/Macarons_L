Imports MySqlConnector
Imports Connection
Imports Ext
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.Net.NetworkInformation
Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Win32

Module moduleControl
#Region "Declare"
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance
    Dim enkrip As New clsEncrypt
    Dim user As String = ConfigurationManager.AppSettings("1")
    Dim pass As String = ConfigurationManager.AppSettings("2")
    Dim rptpath As String = ConfigurationManager.AppSettings("rptpath")
    Dim mainprinter As String = ConfigurationManager.AppSettings("mainprinter")

#End Region
#Region "ID Enkripsi"
    Function getidenkripsi() As String
        getidenkripsi = enkrip.getSHA1Hash(enkrip.md5(getMacAddress() & Now))
    End Function
    Function getidenkripsiplus(ByVal plus As String) As String
        Dim enkrip As New clsencrypt
        getidenkripsiplus = enkrip.getSHA1Hash(enkrip.md5(getMacAddress() & Now & plus & CInt(Math.Ceiling(Rnd() * 99)) + 1))
    End Function
#End Region
#Region "Etc"
    Sub gantiwarnaform(ByVal sender As Object, ByVal r As Integer, ByVal g As Integer, ByVal b As Integer)
        Dim frm As Form
        frm = CType(sender, Form)

        frm.BackColor = Color.FromArgb(r, g, b)
    End Sub
    Function getnumber(ByVal number As String) As String
        getnumber = number.Replace(".", "").Replace(",", "")
    End Function
    Function getMacAddress()
        Dim nics() As NetworkInterface =
              NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function
    Sub ClearListView(ByRef lv As ListView)
        lv.Items.Clear()
        lv.Columns.Clear()
    End Sub
    Function FillDataTable(ByVal ipSrc As String, ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As DataTable
        Dim datasrc As String = "Data Source=" & ipSrc & ";Initial Catalog=macarons;Convert Zero Datetime=True;" &
                "User ID=" & enkrip.Decrypt2("WorthIt", "Blukutuk", "SHA1", "4weQ14reQ15wxQ1G", user) & ";" &
                "Password=" & enkrip.Decrypt2("NotABadThing", "gerrydesnat", "MD5", "323qA323qA323qA1", pass) & ";"
        Dim dbcon As MySqlConnection = Nothing
        Dim SQLcmd As MySqlCommand
        Dim myDataReader As MySqlDataReader = Nothing
        Try
            dbcon = New MySqlConnection(datasrc)
            SQLcmd = New MySqlCommand(queryString, dbcon)
            SQLcmd.CommandTimeout = 1
            If parameters IsNot Nothing Then
                For Each parameter In parameters
                    SQLcmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                Next
            End If

            dbcon.Open()

            myDataReader = SQLcmd.ExecuteReader()
            Dim dt As DataTable = New DataTable()
            dt.Load(myDataReader)
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            If myDataReader IsNot Nothing Then
                myDataReader.Close()
            End If
            If dbcon IsNot Nothing Then
                dbcon.Close()
            End If
        End Try
    End Function
#End Region
#Region "Print"
    Sub CreateODBCConnection()
        Try
            ' Buka kunci registri untuk penyimpanan data pengguna DSN ODBC
            Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\ODBC\ODBC.INI")

            ' Buat subkunci baru untuk koneksi ODBC Anda (versadb)
            Dim subKey As RegistryKey = regKey.CreateSubKey("versadb")

            ' Tentukan detail koneksi
            subKey.SetValue("Driver", "{MySQL ODBC 5.2 Driver}") ' Ganti {MySQL ODBC xx Driver} dengan driver MySQL ODBC yang tepat
            subKey.SetValue("Server", "192.168.1.211")
            subKey.SetValue("Port", "3306") ' Port default MySQL
            subKey.SetValue("Database", "versa")
            subKey.SetValue("User", "monty") ' Ganti "username" dengan nama pengguna MySQL Anda
            subKey.SetValue("Password", "122333")
            ' Tambahkan opsi tambahan sesuai kebutuhan, seperti CHARSET, dll.

            ' Tutup kunci registri
            subKey.Close()
            regKey.Close()

            MessageBox.Show("Koneksi ODBC baru berhasil dibuat.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Gagal membuat koneksi ODBC: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub printStokOpname(ByVal noStokOpname As String)
        Dim mainReport As New ReportDocument
        Try
            ' Load main report
            mainReport.Load(rptpath & "StokOpname.rpt")
            mainReport.SetParameterValue("noStokOpname", noStokOpname)

            mainReport.PrintOptions.PrinterName = mainprinter
            mainReport.PrintToPrinter(1, False, 0, 0)

            mainReport.Close()
            mainReport.Dispose()
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
#End Region
#Region "Login"
    Sub loginOpnameMacarons(username As String, password As String)
        Dim enkrip As New clsencrypt
        Dim isUser As DataTable
        isUser = validUser(username, password)
        If isUser.Rows.Count > 0 Then
            With frmStokOpnam
                .lblUserID.Text = CStr(isUser.Rows(0)("id"))
                .lblPengkoreksi.Text = "Korektor : " & CStr(isUser.Rows(0)("nama"))
                ext.setUserID(CStr(isUser.Rows(0)("id")))
                Call con.isiLog4(frmStokOpnam.lblUserID.Text, CStr(isUser.Rows(0)("nama")) & " login Stok Opname")
            End With
            frmLogin.Dispose()
        Else
            MsgBox("Error: Username dan password tidak cocok.", vbCritical, "Macarons")
            frmLogin.txtUsername.Text = ""
            frmLogin.txtPassword.Text = ""
            frmLogin.txtUsername.Focus()
        End If
    End Sub
    Function validUser(ByVal user As String, ByVal pass As String) As DataTable
        Try
            Dim queryString As String = "CALL validUser(@users,@pass)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@users", user)
            parameters.Add("@pass", enkrip.getSHA1Hash(enkrip.md5(pass)))

            Return con.FillDataTable4(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function

#End Region
    Function getDataToko(ByVal ipSrv As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataToko"
            Return FillDataTable(ipSrv, queryString, Nothing)
        Catch ex As Exception
            'ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataItemByNama(ByVal namaCari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataItemByName(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", namaCari)
            Return con.FillDataTable4(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekConfig() As String
        Dim src As String = ConfigurationManager.AppSettings("DB:SourceData")
        If src <> "" Then
            Dim ipPattern As String = "(?:[0-9]{1,3}\.){3}[0-9]{1,3}"
            Dim regex As New Regex(ipPattern)

            Dim match As Match = regex.Match(src)
            If match.Success Then
                Dim ipAddress As String = match.Value
                Return ipAddress
            Else
                Return ""
            End If
        Else
            Return ""
        End If
        Return ""
    End Function
    Function cekStok(ByVal bcode As String) As String
        Dim queryString As String = ""
        Try
            queryString = "CALL op_get_StokStatus(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)

            Dim result As Object = con.ExecuteScalar4(queryString, parameters)
            Return If(IsNothing(result), "", result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function tambahOpnamTemp(ByVal bcode As String, ByVal stokKomp As String, ByVal jml As String) As Boolean
        Try
            Dim idTemp As String = getidenkripsi()
            Dim spName As String = "op_add_DataOpnameTemp"

            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idTemp", idTemp)
            parameters.Add("@bcode", bcode)
            parameters.Add("@jmlkomp", stokKomp)
            parameters.Add("@jmlitem", jml)
            parameters.Add("@mcAddr", getMacAddress)

            Dim ins As Integer = con.ubahdatabaseado4(spName, parameters, True)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function tambahWarningtemp(ByVal bcode As String, ByVal jml As String) As Boolean
        Try
            Dim idTemp As String = getidenkripsi()
            Dim spName As String = "op_add_DataWarning"

            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idTemp", idTemp)
            parameters.Add("@bcode", bcode)
            parameters.Add("@jmlitem", jml)
            parameters.Add("@mcAddr", getMacAddress)

            Dim ins As Integer = con.ubahdatabaseado4(spName, parameters, False)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataOpnameTemp() As DataTable
        Try
            Dim queryString As String = "CALL op_get_DataopnameTemp(@mcAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@mcAddr", getMacAddress)
            Return con.FillDataTable4(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataWarning() As DataTable
        Try
            Dim queryString As String = "CALL op_get_DataWarning(@mcAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@mcAddr", getMacAddress)
            Return con.FillDataTable4(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub delOpnamTemp(ByVal IDTemp As String)
        Try
            Dim spName As String = "op_del_DataOpnameTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)
            con.ubahdatabaseado4(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function prosesSimpanStokOpnam(ByVal userID As String)
        Dim i As Integer
        Try
            Dim dt As DataTable = loadALLDataStokOpnam()
            If dt.Rows.Count > 0 Then
                Dim noStokOpname As String = generateNoStokOpname()
                i = 0
                Dim queries As New List(Of String)()
                Dim valuesStokOpname As String = ""
                Dim bcode As String = ""
                For Each row As DataRow In dt.Rows
                    bcode = row("kode")
                    valuesStokOpname &= $"('{row("id")}','{noStokOpname}',CURDATE(),'{bcode}','{getnumber(row("qty_komp"))}','{getnumber(row("qty_scan"))}','{getnumber(row("opnam"))}',{row("flg_stat")},now(),'1','{userID}'),"
                Next
                valuesStokOpname = "(" & Chr(34) & Left(valuesStokOpname, valuesStokOpname.Length - 1) & Chr(34) & ")"
                Dim stokOpnameTambahQuery As String = $"CALL op_add_DataStokOpname {valuesStokOpname};"
                queries.Add(stokOpnameTambahQuery)

                Dim delStokOpnameTemp As String = $"CALL op_del_ALLDataStokOpnameTemp;"
                queries.Add(delStokOpnameTemp)

                Dim stokOpname As Boolean = con.ExecuteTrans4(queries, True)
                If stokOpname Then
                    con.isiLog4(userID, $"Simpan data stok opname dengan No. Stok Opname = {noStokOpname}")
                    Return stokOpname
                Else
                    MsgBox("Proses simpan data stok opname GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Masukan data stok opname ke daftar antrian proses terlebih dahulu", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadALLDataStokOpnam() As DataTable
        Try
            Dim queryString As String = "CALL op_get_ALLDataStokOpname()"
            Return con.FillDataTable4(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub delALLStokOpname()
        Try
            Dim spName As String = "op_del_ALLDataStokOpnameTemp"
            con.ubahdatabaseado4(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function editStok(ByVal kode As String, ByVal stkAwal As String, ByVal stkAkhir As String, ByVal ket As String) As Boolean
        Try

            Dim queries As New List(Of String)()
            Dim valuesOpname As String = ""
            Dim updateStok As String = ""
            updateStok = $"CALL op_update_Stok('{kode}', '{stkAwal}', '{stkAkhir}', '{ket}');"
            queries.Add(updateStok)

            Dim updateflgOpnameOK As String = $"CALL op_update_flg_StokOpnameOK('{kode}');"
            queries.Add(updateflgOpnameOK)

            Dim upd As Boolean = con.ExecuteTrans4(queries, True)

            con.isiLog4(frmStokOpnam.lblUserID.Text, "Edit stok (opname) dengan kode = " & kode & " jumlah menjadi = " & stkAkhir & " dengan keterangan = " & ket & ".")

            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function

#Region "Generate No Stok Opname"
    Function generateNoStokOpname() As String
        Dim resetHarian As Boolean = resetNoStokOpnameHarianPOS()
        If resetHarian Then
            generateNoStokOpname = getNoStokOpnameHarianPOS()
        Else
            generateNoStokOpname = getNoStokOpnameBulananPOS()
        End If
    End Function
    Function resetNoStokOpnameHarianPOS() As Boolean
        Try
            Dim queryString As String = "CALL op_get_resetStokOpname"
            Dim result As Object = con.ExecuteScalar4(queryString, Nothing)
            Return Convert.ToInt32(result) = 1
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getNoStokOpnameBulananPOS() As String

        Dim blnskrng, thnskrng, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampStokOpname()
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            blnpenerimaan = dt.Rows(0).Item("blnStokOpname")
            thnpenerimaan = dt.Rows(0).Item("thnStokOpname")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    Return rumusNoStokOpname()
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterStokOpname()
                    Return rumusNoStokOpname()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterStokOpname()
                Return rumusNoStokOpname()
            ElseIf thnskrng < thnpenerimaan Then
                MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                Return ""
            End If
            Return ""
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Function getNoStokOpnameHarianPOS() As String
        Dim tglskrng, blnskrng, thnskrng, tglpenerimaan, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampStokOpname()
            tglskrng = dt.Rows(0).Item("tglskrng")
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            tglpenerimaan = dt.Rows(0).Item("tglStokOpname")
            blnpenerimaan = dt.Rows(0).Item("blnStokOpname")
            thnpenerimaan = dt.Rows(0).Item("thnStokOpname")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    If tglskrng = tglpenerimaan Then
                        Return rumusNoStokOpname()
                    ElseIf tglskrng > tglpenerimaan Then
                        Call resetCounterStokOpname()
                        Return rumusNoStokOpname()
                    ElseIf tglskrng < tglpenerimaan Then
                        MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                        Return ""
                    End If
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterStokOpname()
                    Return rumusNoStokOpname()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterStokOpname()
                Return rumusNoStokOpname()
            ElseIf thnskrng < thnpenerimaan Then
                MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                Return ""
            End If
            Return ""
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Function rumusNoStokOpname() As String
        Dim sekarang, formattgl, jmlcounter, cpo As String
        Try
            Dim dt As DataTable = getRumusStokOpname()
            sekarang = dt.Rows(0).Item("sekarang")
            formattgl = dt.Rows(0).Item("format_Stok_Opname")
            jmlcounter = dt.Rows(0).Item("digit_counter_Stok_Opname")
            cpo = dt.Rows(0).Item("Stok_Opname")
            Dim tgl As DateTime = DateTime.ParseExact(sekarang, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim reformatted As String = tgl.ToString(formattgl, CultureInfo.InvariantCulture)
            updateCounterPenjualanPOS()
            Return reformatted & CInt(cpo).ToString("D" & jmlcounter)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updateCounterPenjualanPOS()
        Try
            Dim spName As String
            spName = "op_update_CounterStokOpname"
            con.ubahdatabaseado4(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub resetCounterStokOpname()
        Try
            Dim spName As String = "op_update_ResetCounterStokOpname"
            con.ubahdatabaseado4(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getTimeStampStokOpname() As DataTable
        Try
            Dim queryString As String = "CALL op_get_timestampStokOpname()"
            Return con.FillDataTable4(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getRumusStokOpname() As DataTable
        Try
            Dim queryString As String = "CALL op_get_rumusStokOpname()"
            Return con.FillDataTable4(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
End Module
