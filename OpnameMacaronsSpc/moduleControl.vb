Imports MySqlConnector
Imports Connection
Imports Ext
Imports System.Configuration
Imports System.Net.NetworkInformation
Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine

Module moduleControl
#Region "Declare"
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance
    Dim enkrip As New clsencrypt
    Dim user As String = ConfigurationManager.AppSettings("1")
    Dim pass As String = ConfigurationManager.AppSettings("2")
    Dim rptpath As String = ConfigurationManager.AppSettings("rptpath")
#End Region
#Region "Etc"
    Sub gantiwarnaform(ByVal sender As Object, ByVal r As Integer, ByVal g As Integer, ByVal b As Integer)
        Dim frm As Form
        'Dim ctl As Object
        'Dim C = System.Drawing.Color.FromArgb(vwarna.Replace("Color[", "").Replace("]", ""))
        frm = CType(sender, Form)

        frm.BackColor = Color.FromArgb(r, g, b)
        'For Each ctl In frm.Controls
        '    If TypeOf ctl Is Button Then
        '        ctl.BackColor = C
        '        ctl.ForeColor = Color.Black
        '    ElseIf TypeOf ctl Is Label Then
        '        ctl.ForeColor = Color.Black
        '    ElseIf TypeOf ctl Is CheckBox Then
        '        If ctl.Name = "btnmode" Then
        '            ctl.BackColor = C
        '            ctl.ForeColor = Color.Black
        '        End If
        '    End If
        'Next
    End Sub
    Function getMacAddress()
        Dim nics() As NetworkInterface =
              NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function
    Function getnumber(ByVal number As String) As String
        getnumber = number.Replace(".", "").Replace(",", "")
    End Function

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
#Region "Login"
    Sub loginOpnameMacaronsSpc(username As String, password As String)
        Dim enkrip As New clsencrypt
        Dim isUser As DataTable
        isUser = validUser(username, password)
        If isUser.Rows.Count > 0 Then
            With frmStokOpnameSpc
                .lblUserID.Text = CStr(isUser.Rows(0)("id"))
                ext.setUserID(CStr(isUser.Rows(0)("id")))
                Call con.isiLog(frmStokOpnameSpc.lblUserID.Text, CStr(isUser.Rows(0)("nama")) & " login Stok Opname Special")
                .Show()
                .txtkodeitem.Focus()
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

            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Proses"
    Function loadDataItemByNama(ByVal namaCari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataItemByName(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", namaCari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub ClearListView(ByRef lv As ListView)
        lv.Items.Clear()
        lv.Columns.Clear()
    End Sub
    Function loadDataOpnameSpcTemp() As DataTable
        Try
            Dim queryString As String = "CALL op_get_DataopnameSpcTemp(@mcAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@mcAddr", getMacAddress)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekStok(ByVal bcode As String) As String
        Dim queryString As String = ""
        Try
            queryString = "CALL op_get_StokStatus(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return If(IsNothing(result), "", result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Function tambahOpnamSpcTemp(ByVal bcode As String, ByVal jml As String) As Boolean
        Try
            Dim idTemp As String = getidenkripsi()
            Dim spName As String = "op_add_DataOpnameSpcTemp"

            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idTemp", idTemp)
            parameters.Add("@bcode", bcode)
            parameters.Add("@jmlitem", jml)
            parameters.Add("@mcAddr", getMacAddress)

            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Sub delOpnameSpcTemp(ByVal IDTemp As String)
        Try
            Dim spName As String = "op_del_DataOpnameSpcTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function prosesSimpanStokOpnamSpc(ByVal userID As String)
        Dim i As Integer
        Try
            Dim dt As DataTable = loadDataOpnameSpcTemp()
            If dt.Rows.Count > 0 Then
                Dim noStokOpname As String = generateNoStokOpname()
                i = 0
                Dim queries As New List(Of String)()
                Dim valuesStokOpname As String = ""
                Dim valuesupdateStok As String = ""
                Dim bcode As String = ""
                For Each row As DataRow In dt.Rows
                    bcode = row("Barcode")
                    valuesStokOpname &= $"('{row("id")}','{noStokOpname}',CURDATE(),'{bcode}','{getnumber(row("Qty Scan"))}',1,now(),'1','{userID}'),"
                    valuesupdateStok &= $"CALL op_update_StokForStokOpnameSpc('{bcode}', {getnumber(row("Qty Scan"))});"
                Next
                valuesStokOpname = "(" & Chr(34) & Left(valuesStokOpname, valuesStokOpname.Length - 1) & Chr(34) & ")"
                Dim stokOpnameTambahQuery As String = $"CALL op_add_DataStokOpnameSpc {valuesStokOpname};"
                queries.Add(stokOpnameTambahQuery)

                Dim delStokOpnameTemp As String = $"CALL op_del_ALLDataStokOpnameSpcTemp ('{getMacAddress()}');"
                queries.Add(delStokOpnameTemp)

                queries.Add(valuesupdateStok)

                Dim stokOpname As Boolean = con.ExecuteTrans(queries, True)
                If stokOpname Then
                    con.isiLog(userID, $"Sukses mengubah stok dan simpan data stok opname dengan No. Stok Opname = {noStokOpname}")
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
#End Region
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
#Region "Laporan"
    Sub lapSOclick(ByVal tgl1 As String, ByVal tgl2 As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "StokOpname.rpt")

            cryRpt.SetParameterValue("bdate", CDate(tgl1).ToString("yyyy-MM-dd"))
            cryRpt.SetParameterValue("edate", CDate(tgl2).ToString("yyyy-MM-dd"))
            If Application.OpenForms().OfType(Of frmLap).Any Then
                AppActivate(frmLap.Text)
            Else
                frmLap.Show()
            End If
            frmLap.crv.ReportSource = cryRpt
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
#End Region
End Module
