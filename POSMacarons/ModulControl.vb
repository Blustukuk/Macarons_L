Imports Connection
Imports Ext
Imports System.Globalization
Imports System.Net.NetworkInformation
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports ZXing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Module ModulControl
#Region "Declare"
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance
    Dim enkrip As New clsencrypt
    Dim rptpath As String = ConfigurationManager.AppSettings("rptpath")
    Dim printerKasir As String = ConfigurationManager.AppSettings("Printer Kasir")
    Dim mainprinter As String = ConfigurationManager.AppSettings("mainprinter")
    Dim kasir As String = CInt(ConfigurationManager.AppSettings("kasir")).ToString("D2")
    Dim memberTemplatePath As String = ConfigurationManager.AppSettings("memberTemplatePath")
    Dim memberOutputPath As String = ConfigurationManager.AppSettings("memberOutputPath")
#End Region
#Region "Etc"
    Public Sub delay(ByVal miliseconds As Integer)
        Dim sw2 As New Stopwatch
        sw2.Start()
        Do
        Loop Until sw2.ElapsedMilliseconds >= miliseconds
    End Sub
    Function validAdmin(ByVal pass As String) As Boolean
        Try
            Dim queryString As String = "CALL validAdmin(@pass)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@pass", enkrip.getSHA1Hash(enkrip.md5(pass)))

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToInt32(result) > 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataBrandBarangKhusus() As DataTable
        Try
            Dim queryString As String = "CALL get_DataBrandBarangKhusus()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataCustomer(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataCustomerByName(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)
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
    Sub gantiwarnaform(ByVal sender As Object, ByVal r As Integer, ByVal g As Integer, ByVal b As Integer)
        Dim frm As Form
        frm = CType(sender, Form)

        frm.BackColor = Color.FromArgb(r, g, b)
    End Sub
    Public Sub GenerateAndSaveQRCode(text As String, filePath As String)
        Dim barcodeWriter As New BarcodeWriter()
        barcodeWriter.Format = BarcodeFormat.QR_CODE

        Dim barcodeBitmap As Bitmap = barcodeWriter.Write(text)

        barcodeBitmap.Save(filePath, ImageFormat.Png)

        barcodeBitmap.Dispose()
    End Sub

#End Region
#Region "Network"
    Function pingserver(ByVal ipserver As String)
        Dim objPingHost As New clsping()
        pingserver = objPingHost.Ping321(ipserver)
    End Function
    Function getMacAddress()
        Dim nics() As NetworkInterface =
              NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function
#End Region
#Region "ID Generator"
    Function getidenkripsi() As String
        getidenkripsi = enkrip.getSHA1Hash(enkrip.md5(getMacAddress() & Now))
    End Function
    Function getidenkripsiplus(ByVal plus As String) As String
        Dim enkrip As New clsencrypt
        getidenkripsiplus = enkrip.getSHA1Hash(enkrip.md5(getMacAddress() & Now & plus & CInt(Math.Ceiling(Rnd() * 99)) + 1))
    End Function
#End Region
#Region "Login"
    Sub loginMacarons(username As String, password As String, kasir As String)
        Dim enkrip As New clsencrypt
        Dim isUser As DataTable
        isUser = validUser(username, password)
        If isUser.Rows.Count > 0 Then
            With frmPOS2
                .lblUserID.Text = CStr(isUser.Rows(0)("id"))
                .lblKasir.Text = CInt(kasir).ToString("D2")
                ext.setUserID(CStr(isUser.Rows(0)("id")))
                Call con.isiLog(frmPOS2.lblUserID.Text, CStr(isUser.Rows(0)("nama")) & " login")
                .Show()
            End With

            'frmLogin.txtUsername.Text = ""
            'frmLogin.txtPassword.Text = ""
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
    Sub statuslogout(Optional ByVal userid As String = "0")
        frmPOS2.lblUserID.Text = "0"
        If userid <> "0" Then
            Dim dt As DataTable = getUserInfo(userid)
            Dim username As String = dt.Rows(0).Item("nama")
            Call con.isiLog(userid, username & " logout")
        End If
        frmLogin.Show()
        frmPOS2.Hide()
    End Sub
    Function getUserInfo(ByVal userID As String) As DataTable
        Try
            Dim queryString As String = "CALL get_UserInfo(@userID)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@userID", userID)

            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Print"

    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        Dim s As String = ""
        doctoprint.PrinterSettings.PrinterName = PrinterName
        For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind",
                Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function
    Sub printNota(ByVal noNota As String)
        Dim mainReport As New ReportDocument
        Dim QRCodePath As String = Application.StartupPath & "\QRCode\Nota.PNG"
        GenerateAndSaveQRCode(noNota, QRCodePath)

        Try
            ' Load main report
            mainReport.Load(rptpath & "Nota.rpt")
            mainReport.SetParameterValue("nota", noNota)
            mainReport.SetParameterValue("imgURL", QRCodePath)

            Dim subs As New ReportDocument
            subs.Load(rptpath & "Nota-DiskonKembar.rpt")


            mainReport.PrintOptions.PrinterName = printerKasir
            mainReport.PrintToPrinter(1, False, 0, 0)

            mainReport.Close()
            mainReport.Dispose()
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub printReturPengiriman(ByVal noRetur As String)
        Dim cryRpt As New ReportDocument
        Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions
        Dim QRCodePath As String = Application.StartupPath & "\QRCode\ReturPengiriman.PNG"
        GenerateAndSaveQRCode(noRetur, QRCodePath)

        Try
            With cryRpt
                repOptions = .PrintOptions
                With repOptions
                    .PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                    .PaperSize = GetPapersizeID(mainprinter, "A4")
                    .PrinterName = mainprinter
                End With
                .Load(rptpath & "ReturPengiriman.rpt")
                .SetParameterValue("noRetur", noRetur)
                .SetParameterValue("imgURL", QRCodePath)
                .PrintToPrinter(1, True, 0, 0)
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub

    Sub printRetur(ByVal noNota As String)
        Dim cryRpt As New ReportDocument
        Dim QRCodePath As String = Application.StartupPath & "\QRCode\Retur.PNG"
        GenerateAndSaveQRCode(noNota, QRCodePath)

        Try
            cryRpt.Load(rptpath & "Retur.rpt")
            cryRpt.SetParameterValue("nota", noNota)
            cryRpt.SetParameterValue("imgURL", QRCodePath)
            cryRpt.PrintOptions.PrinterName = printerKasir
            cryRpt.PrintToPrinter(1, False, 0, 0)

            cryRpt.Close()
            cryRpt.Dispose()
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
#End Region
#Region "POS"
    Function getNamaBank() As DataTable
        Try
            Dim queryString As String = "CALL get_DataBank()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
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
    Function loadDataItemByNamaDetail(ByVal namaCari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataItemByNameDetail(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", namaCari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataPenjualanByNama(ByVal namaCari As String, bdate As String, edate As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataPenjualanByNama(@namaCari,@bdate,@edate)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", namaCari)
            parameters.Add("@bdate", CDate(bdate).ToString("yyyy-MM-dd"))
            parameters.Add("@edate", CDate(edate).ToString("yyyy-MM-dd"))
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekStok(ByVal bcode As String, ByVal jml As String) As String
        Dim queryString As String = ""
        Try
            If bcode.Length = 10 Then
                queryString = "CALL POS_get_StokStatus(@bcode,@jmlitem)"
            ElseIf bcode.Length = 12 And Left(bcode, 2) = "19" Then
                queryString = "CALL POS_get_VoucherStatus(@bcode,@jmlitem)"
            ElseIf bcode.Length = 12 And Left(bcode, 2) = "11" Then
                queryString = "CALL POS_get_ReturStatus(@bcode,@jmlitem)"
            ElseIf bcode.Length = 12 And Left(bcode, 2) = "12" Then
                Return "Y"
            ElseIf bcode.Length = 12 And Left(bcode, 2) = "13" Then
                queryString = "CALL POS_get_StokStatus(@bcode,@jmlitem)"
            ElseIf bcode.Length = 7 And (Left(bcode, 2) = "BD" Or Left(bcode, 2) = "PR" Or Left(bcode, 2) = "RS") Then
                Return "M"
            End If
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)
            parameters.Add("@jmlitem", jml)

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToString(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function tambahPenjualanPOSTemp(ByVal bcode As String, ByVal jml As String, Optional ByVal namaManual As String = "",
                                    Optional ByVal hargaManual As Integer = 0) As Boolean
        Try
            Dim idTemp As String = getidenkripsi()
            Dim harga As Integer = 0
            Dim total As Integer = 0
            Dim spName As String = "POS_add_DataPenjualanTemp"

            If bcode = "" Then
                bcode = namaManual
                harga = hargaManual
            ElseIf bcode.Length = 10 Then
                harga = getHargaItem(bcode)
            ElseIf bcode.Length = 12 Then
                If Left(bcode, 2) = "19" Then
                    harga = getHargaVoucher(bcode)
                ElseIf Left(bcode, 2) = "11" Then
                    harga = getHargaRetur(bcode) * -1
                ElseIf Left(bcode, 2) = "12" Then
                    harga = getHargaBungkus(bcode)
                ElseIf Left(bcode, 2) = "13" Then
                    harga = getHargaItem(bcode)
                End If
            End If
            total = CDec(harga) * CDec(jml)

            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idTemp", idTemp)
            parameters.Add("@bcode", bcode)
            parameters.Add("@jmlitem", jml)
            parameters.Add("@hrg", harga)
            parameters.Add("@ttl", total)
            parameters.Add("@macAddr", kasir)
            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, False)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function updatePenjualanPOSTemp(ByVal id As String, ByVal diskonrp As String, ByVal diskonpersen As String) As Boolean
        Try
            Dim spName As String = "POS_update_PenjualanTemp"

            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idTemp", id)
            parameters.Add("@diskonrp", diskonrp)
            parameters.Add("@diskonpersen", diskonpersen)
            Dim update As Integer = con.ubahdatabaseado(spName, parameters, False)
            Return update <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getHargaItem(ByVal bcode As String) As Integer
        Try
            Dim queryString As String = "CALL POS_get_HargaItem(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getHargaVoucher(ByVal bcode As String) As Integer
        Try
            Dim queryString As String = "CALL POS_get_HargaVoucher(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getHargaRetur(ByVal bcode As String) As Integer
        Try
            Dim queryString As String = "CALL POS_get_HargaRetur(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getHargaBungkus(ByVal bcode As String) As Integer
        Try
            Dim queryString As String = "CALL POS_get_HargaBungkus(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataPenjualanTemp(ByVal macAddr As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataPenjualanTemp(@macAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@macAddr", macAddr)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataDiskonKembarPenjualan(ByVal macAddr As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataDiskonKembarPenjualan(@macAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@macAddr", macAddr)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub delPenjualanTemp(ByVal IDTemp As String)
        Try
            Dim spName As String = "POS_del_DataPenjualanTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function BulatkanKebawah500(ByVal value As Integer) As Integer
        Return (value \ 500) * 500
    End Function
    Function getnumber(ByVal number As String) As String
        getnumber = number.Replace(",", "").Replace("%", "")
    End Function
    Sub dellallPOSpenjualantemp(ByVal macAddr As String)
        Try
            Dim spName As String = "POS_del_ALLDataPenjualanTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@mcAdd", macAddr)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function prosespenjualan(ByVal userid As String, ByVal bayar As String, ByVal totalsementara As String, ByVal totalasli As String,
                             ByVal diskonpersen As String, ByVal diskonrupiah As String, ByVal nokasir As String, ByVal flg_edc As String, ByVal flg_qris As String,
                             ByVal diskem As Boolean, ByVal noMember As String, Optional ByVal bank_id As String = "0", Optional ByVal noedc As String = "0") As Integer
        Dim print As MsgBoxResult
        Try
            Dim dt As DataTable = loadDataPenjualanTemp(kasir)
            If dt.Rows.Count > 0 Then
                If IsNumeric(diskonpersen) And IsNumeric(diskonrupiah) Then
                    print = MsgBox("Cetak Nota ?", vbYesNo, "Macarons")
                    Dim noPenjualan As String = generateNoPenjualanPOS()
                    Dim queries As New List(Of String)()
                    Dim valuesHeader As String = ""
                    Dim valuesDetail As String = ""
                    Dim updateStok As String = ""
                    Dim bcode As String = ""
                    ' HEADER
                    valuesHeader =
                            $"""('{noPenjualan}',NOW(),'{noMember}','{userid}','1','{bayar}','{flg_edc}','{bank_id}','{noedc}',{diskonrupiah},{diskonpersen},'{nokasir}','{flg_qris}','{totalsementara}','{totalasli}')"""

                    ' DETAIL
                    valuesDetail = ""
                    Dim i As Integer = 0
                    For Each row As DataRow In dt.Rows
                        If row("Barcode") = "-" Then
                            bcode = row("Nama")
                        Else
                            bcode = row("Barcode")
                            updateStok = $"CALL update_StokForPenjualan('{row("Barcode")}', '{row("Jumlah")}');"
                            queries.Add(updateStok)
                        End If

                        ' Penting: pakai {header_id} sesuai format SP
                        valuesDetail &= $"('{{header_id}}','{bcode}','{getnumber(row("Jumlah"))}','{getnumber(row("Harga Jual"))}','{getnumber(row("Cashback"))}','{getnumber(row("Diskon Persen"))}','{getnumber(row("Total"))}'),"
                        i += 1
                    Next

                    ' Hilangkan koma terakhir
                    If valuesDetail.Length > 0 Then
                        valuesDetail = "(" & Chr(34) & Left(valuesDetail, valuesDetail.Length - 1) & Chr(34) & ")"
                    End If

                    ' === Panggil SP ===
                    Dim penjualanTambahQuery As String =
                        $"CALL POS_add_DataPenjualanPOS2({valuesHeader}, {valuesDetail});"
                    queries.Add(penjualanTambahQuery)

                    If diskem Then
                        Dim dt2 As DataTable = loadDataDiskonKembarPenjualan(kasir)
                        Dim valuesDiskon As String = ""
                        If dt2.Rows.Count > 0 Then
                            i = 0
                            For Each row As DataRow In dt2.Rows
                                Dim diskonID As String = getidenkripsiplus(i)
                                valuesDiskon &= $"('{diskonID}','{noPenjualan}','{row("jumlah")}','{getnumber(row("harga"))}','{getnumber(row("diskon"))}'),"
                                i += 1
                            Next
                        End If
                        If valuesDiskon <> "" Then
                            valuesDiskon = "(" & Chr(34) & Left(valuesDiskon, valuesDiskon.Length - 1) & Chr(34) & ")"
                            Dim diskonTambahQuery As String = $"CALL POS_add_DataDiskonPOS {valuesDiskon};"
                            queries.Add(diskonTambahQuery)
                        End If
                    End If
                    If noMember <> "-" Then
                        Dim poinID As String = getidenkripsi()
                        Dim poin As String = BulatKeBawah(totalasli) / 1000
                        Dim valuesMember As String = $"CALL POS_add_Member_Poin ('{poinID}','{noPenjualan}','{noMember}','{totalasli}','{poin}');"
                        queries.Add(valuesMember)
                        Dim valuesUpdateMember As String = $"CALL POS_update_Member_Poin ('{noMember}','{poin}');"
                        queries.Add(valuesUpdateMember)
                    End If
                    Dim delPenjualanTemp As String = $"CALL POS_del_ALLDataPenjualanTemp ('{kasir}');"
                    queries.Add(delPenjualanTemp)

                    Dim penjualan As Boolean = con.ExecuteTrans(queries, True)
                    If penjualan Then
                        con.isiLog(userid, $"Penjualan dengan No. Nota = {noPenjualan}")
                        If print = vbYes Then
                            printNota(noPenjualan)
                        End If
                        Return penjualan
                    Else
                        MsgBox("Proses penjualan GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                        Return False
                    End If
                Else
                    MsgBox("Masukan diskon dengan benar.", vbOKOnly, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Masukan transaksi ke daftar antrian proses terlebih dahulu.", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function BulatKeBawah(angka As Integer) As Integer
        Dim kelipatan As Integer = 1000
        Return Math.Floor(angka / kelipatan) * kelipatan
    End Function
    Function prosespenjualancash(ByVal userid As String, ByVal bayar As String, ByVal nomember As String,
                                 ByVal diskonpersen As String, ByVal diskonrupiah As String, ByVal nokasir As String) As Integer
        Dim i As Integer
        Dim print As MsgBoxResult
        Try
            Dim dt As DataTable = loadDataPenjualanTemp(kasir)
            If dt.Rows.Count > 0 Then
                print = MsgBox("Cetak Nota ?", vbYesNo, "Macarons")
                Dim noPenjualan As String = generateNoPenjualanPOS()
                i = 0
                Dim queries As New List(Of String)()
                Dim valuesPenjualan As String = ""
                Dim updateStok As String = ""
                For Each row As DataRow In dt.Rows
                    Dim penjualanID As String = getidenkripsiplus(i)
                    valuesPenjualan &= $"('{penjualanID}','{noPenjualan}',now(),'{nomember}','{row("Barcode")}','{getnumber(row("Jumlah"))}','{getnumber(row("Harga Jual"))}','{getnumber(row("Total"))}','{userid}','1','{bayar}','0','0','0',{diskonrupiah},{diskonpersen},'{nokasir}'),"
                    updateStok = $"CALL update_StokForPenjualan('{row("Barcode")}', '{row("Jumlah")}');"
                    queries.Add(updateStok)
                    i += 1
                Next
                valuesPenjualan = "(" & Chr(34) & Left(valuesPenjualan, valuesPenjualan.Length - 1) & Chr(34) & ")"
                Dim penjualanTambahQuery As String = $"CALL POS_add_DataPenjualanPOS {valuesPenjualan};"
                queries.Add(penjualanTambahQuery)

                Dim dt2 As DataTable = loadDataDiskonKembarPenjualan(kasir)
                Dim valuesDiskon As String = ""
                If dt2.Rows.Count > 0 Then
                    i = 0
                    For Each row As DataRow In dt2.Rows
                        Dim diskonID As String = getidenkripsiplus(i)
                        valuesDiskon &= $"('{diskonID}','{noPenjualan}','{row("jumlah")}','{getnumber(row("harga"))}','{getnumber(row("diskon"))}'),"
                        i += 1
                    Next
                End If
                If valuesDiskon <> "" Then
                    valuesDiskon = "(" & Chr(34) & Left(valuesDiskon, valuesDiskon.Length - 1) & Chr(34) & ")"
                    Dim diskonTambahQuery As String = $"CALL POS_add_DataDiskonPOS {valuesDiskon};"
                    queries.Add(diskonTambahQuery)
                End If
                Dim delPenjualanTemp As String = $"CALL POS_del_ALLDataPenjualanTemp ('{kasir}');"
                queries.Add(delPenjualanTemp)

                Dim penjualan As Boolean = con.ExecuteTrans(queries, True)
                If penjualan Then
                    con.isiLog(userid, $"Penjualan dengan No. Nota = {noPenjualan}")
                    If print = vbYes Then
                        printNota(noPenjualan)
                    End If
                    Return penjualan
                Else
                    MsgBox("Proses penjualan GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Masukan transaksi ke daftar antrian proses terlebih dahulu", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function prosespenjualanedc(ByVal userid As String, ByVal bayar As String, ByVal bankid As String, ByVal noedc As String, ByVal nomember As String,
                                ByVal diskonpersen As String, ByVal diskonrupiah As String, ByVal nokasir As String) As Integer
        Dim i As Integer
        Dim print As MsgBoxResult
        Try
            Dim dt As DataTable = loadDataPenjualanTemp(kasir)
            If dt.Rows.Count > 0 Then
                print = MsgBox("Cetak Nota ?", vbYesNo, "Macarons")
                Dim noPenjualan As String = generateNoPenjualanPOS()
                i = 0
                Dim queries As New List(Of String)()
                Dim valuesPenjualan As String = ""
                Dim updateStok As String = ""
                For Each row As DataRow In dt.Rows
                    Dim penjualanID As String = getidenkripsiplus(i)
                    valuesPenjualan &= $"('{penjualanID}','{noPenjualan}',now(),'{nomember}','{row("Barcode")}','{getnumber(row("Jumlah"))}','{getnumber(row("Harga Jual"))}','{getnumber(row("Total"))}','{userid}','1','{bayar}','1','{bankid}','{noedc}',{diskonrupiah},{diskonpersen},'{nokasir}'),"
                    updateStok = $"CALL update_StokForPenjualan('{row("Barcode")}', '{row("Jumlah")}');"
                    queries.Add(updateStok)
                    i += 1
                Next
                valuesPenjualan = "(" & Chr(34) & Left(valuesPenjualan, valuesPenjualan.Length - 1) & Chr(34) & ")"
                Dim penjualanTambahQuery As String = $"CALL POS_add_DataPenjualanPOS {valuesPenjualan};"
                queries.Add(penjualanTambahQuery)

                Dim dt2 As DataTable = loadDataDiskonKembarPenjualan(kasir)
                Dim valuesDiskon As String = ""
                If dt2.Rows.Count > 0 Then
                    i = 0
                    For Each row As DataRow In dt2.Rows
                        Dim diskonID As String = getidenkripsiplus(i)
                        valuesDiskon &= $"('{diskonID}','{noPenjualan}','{row("Jumlah")}','{getnumber(row("harga"))}','{getnumber(row("diskon"))}'),"
                        i += 1
                    Next
                End If
                valuesDiskon = "(" & Chr(34) & Left(valuesDiskon, valuesDiskon.Length - 1) & Chr(34) & ")"
                Dim diskonTambahQuery As String = $"CALL POS_add_DataDiskonPOS {valuesDiskon};"
                queries.Add(diskonTambahQuery)

                Dim delPenjualanTemp As String = $"CALL POS_del_ALLDataPenjualanTemp ('{kasir}');"
                queries.Add(delPenjualanTemp)

                Dim penjualan As Boolean = con.ExecuteTrans(queries, True)
                If penjualan Then
                    con.isiLog(userid, $"Penjualan dengan No. Nota = {noPenjualan}")
                    If print = vbYes Then
                        printNota(noPenjualan)
                    End If
                    Return penjualan
                Else
                    MsgBox("Proses penjualan GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Masukan transaksi ke daftar antrian proses terlebih dahulu", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function generateNoPenjualanPOS() As String
        Dim resetHarian As Boolean = resetNoPenjualanHarianPOS()
        If resetHarian Then
            generateNoPenjualanPOS = getNoPenjualanHarianPOS()
        Else
            generateNoPenjualanPOS = getNoPenjualanBulananPOS()
        End If
    End Function
    Function resetNoPenjualanHarianPOS() As Boolean
        Try
            Dim queryString As String = "CALL POS_get_resetPenjualanPOS"
            Dim result As Object = con.ExecuteScalar(queryString, Nothing)
            Return Convert.ToInt32(result) = 1
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getNoPenjualanBulananPOS() As String

        Dim blnskrng, thnskrng, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampPenjualanPOS()
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            blnpenerimaan = dt.Rows(0).Item("blnpenjualanPOS")
            thnpenerimaan = dt.Rows(0).Item("thnpenjualanPOS")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    Return rumusNoPenjualanPOS()
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterPenjualanPOS()
                    Return rumusNoPenjualanPOS()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterPenjualanPOS()
                Return rumusNoPenjualanPOS()
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
    Function getNoPenjualanHarianPOS() As String
        Dim tglskrng, blnskrng, thnskrng, tglpenerimaan, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampPenjualanPOS()
            tglskrng = dt.Rows(0).Item("tglskrng")
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            tglpenerimaan = dt.Rows(0).Item("tglPenjualanPOS")
            blnpenerimaan = dt.Rows(0).Item("blnPenjualanPOS")
            thnpenerimaan = dt.Rows(0).Item("thnPenjualanPOS")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    If tglskrng = tglpenerimaan Then
                        Return rumusNoPenjualanPOS()
                    ElseIf tglskrng > tglpenerimaan Then
                        Call resetCounterPenjualanPOS()
                        Return rumusNoPenjualanPOS()
                    ElseIf tglskrng < tglpenerimaan Then
                        MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                        Return ""
                    End If
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterPenjualanPOS()
                    Return rumusNoPenjualanPOS()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterPenjualanPOS()
                Return rumusNoPenjualanPOS()
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
    Function rumusNoPenjualanPOS() As String
        Dim sekarang, formattgl, jmlcounter, jml_nonota, cpo, ctr As String
        Try
            Dim dt As DataTable = getRumusPenjualanPOS()
            sekarang = dt.Rows(0).Item("sekarang")
            formattgl = dt.Rows(0).Item("format_Penjualan_POS")
            jmlcounter = dt.Rows(0).Item("digit_counter_Penjualan_POS")
            jml_nonota = dt.Rows(0).Item("jml_penjualan_pos")
            cpo = dt.Rows(0).Item("Penjualan_pos")
            ctr = dt.Rows(0).Item("penjualan_pos_ctr")
            Dim tgl As DateTime = DateTime.ParseExact(sekarang, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim reformatted As String = tgl.ToString(formattgl, CultureInfo.InvariantCulture)
            If jml_nonota = ctr Then
                updateCounterPenjualanPOS(1)
            Else
                updateCounterPenjualanPOS(2)
            End If
            Return reformatted & CInt(cpo).ToString("D" & jmlcounter) & "-" & ctr
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updateCounterPenjualanPOS(ByVal tipe As Integer)
        Try
            Dim spName As String
            If tipe = 1 Then
                spName = "POS_update_CounterPenjualanPOS"
            Else
                spName = "POS_update_Counter2PenjualanPOS"
            End If
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub resetCounterPenjualanPOS()
        Try
            Dim spName As String = "POS_update_ResetCounterPenjualanPOS"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getTimeStampPenjualanPOS() As DataTable
        Try
            Dim queryString As String = "CALL POS_get_timestampPenjualanPOS()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getRumusPenjualanPOS() As DataTable
        Try
            Dim queryString As String = "CALL POS_get_rumusPenjualanPOS()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Retur"
    Function loadDataPenjualanPOS(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataPenjualanPOS(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)

            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataReturPOS(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataReturPOS(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataReturTempPOS(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataReturTempPOS(@namaCari,@mcAdd)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)
            parameters.Add("@mcAdd", kasir)

            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekJmlRetur(ByVal kode As String, ByVal nota As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_ValidRetur(@barcode,@nota,@mcAdd)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@barcode", kode)
            parameters.Add("@nota", nota)
            parameters.Add("@mcAdd", kasir)

            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function pilihItem(ByVal kode As String, ByVal nota As String) As Boolean
        Try
            Dim dt As DataTable = cekJmlRetur(kode, nota)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("stat") = "Y" Then

                    Dim queryString As String = "POS_add_DataReturTemp"
                    Dim parameters As New Dictionary(Of String, Object)()

                    parameters.Add("@barcode", kode)
                    parameters.Add("@hargaJual", dt.Rows(0)("hargaJual"))
                    parameters.Add("@nomorNota", nota)
                    parameters.Add("@mcAdd", kasir)

                    Dim upd As Integer = con.ubahdatabaseado(queryString, parameters, False)
                    Return upd <> 0
                Else
                    MsgBox("Jumlah retur melebihi jumlah beli.", vbCritical, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Data barang tidak ditemukan.", vbCritical, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function buangItem(ByVal kode As String, ByVal nota As String) As Boolean
        Try
            Dim queryString As String = "POS_del_DataReturTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@barcode", kode)
            parameters.Add("@nomornota", nota)

            Dim upd As Integer = con.ubahdatabaseado(queryString, parameters, False)
            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function returpenjualan(ByVal nonota As String, ByVal kasir As String) As Boolean
        Dim userid As String
        Dim queries As New List(Of String)()
        Dim i As Integer

        Dim dt As DataTable = loadDataPenjualanReturTemp(nonota)

        Try
            If dt.Rows.Count > 0 Then
                Dim noRetur As String = generateNoReturPOS()
                userid = frmPOS2.lblUserID.Text
                Dim valuesHeader As String = ""
                Dim valuesDetail As String = ""
                Dim grandttl As Integer = 0

                For Each row As DataRow In dt.Rows
                    Dim ttl As Integer = row("jumlah") * row("harga_jual")
                    grandttl += ttl
                    valuesDetail &= $"('{{header_id}}','{row("kode")}','{row("harga_jual")}','{row("jumlah")}','{ttl}'),"
                    Dim updateStok As String = $"CALL POS_update_StokForRetur('{row("kode")}', {row("jumlah")});"
                    queries.Add(updateStok)
                    i += 1
                Next
                valuesHeader = $"""('{noRetur}',curdate(),'{nonota}','{userid}','{kasir}',now(),now(),{grandttl})"""
                valuesDetail = "(" & Chr(34) & Left(valuesDetail, valuesDetail.Length - 1) & Chr(34) & ")"


                Dim returTambahQuery As String = $"CALL POS_add_DataReturPOS2 ({valuesHeader}, {valuesDetail});"
                queries.Add(returTambahQuery)

                Dim delReturTemp As String = $"CALL POS_del_ALLDataReturTemp('{kasir}');"
                queries.Add(delReturTemp)

                Dim retur As Boolean = con.ExecuteTrans(queries, True)
                If retur Then
                    con.isiLog(userid, $"Retur dengan No. Nota = {nonota}")
                    Dim print As MsgBoxResult
                    print = MsgBox("Retur sukses. Cetak Nota ?", vbYesNo, "Macarons")
                    If print = vbYes Then
                        printRetur(noRetur)
                    End If
                    Return retur
                Else
                    MsgBox("Proses retur GAGAL. Hubungi developer.", vbCritical, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Data retur tidak ditemukan.", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataPenjualanReturTemp(ByVal nota As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataReturPenjualanTemp(@nota)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nota", nota)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataDiskonKembar(ByVal nota As String, ByVal harga As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataDiskonKembarForRetur(@nota,@hrg)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nota", nota)
            parameters.Add("@hrg", harga)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try

    End Function
    Function generateNoReturPOS() As String
        Dim resetHarian As Boolean = resetNoReturHarianPOS()
        If resetHarian Then
            generateNoReturPOS = getNoReturHarianPOS()
        Else
            generateNoReturPOS = getNoReturBulananPOS()
        End If
    End Function
    Function resetNoReturHarianPOS() As Boolean
        Try
            Dim queryString As String = "CALL POS_get_resetReturPOS"
            Dim result As Object = con.ExecuteScalar(queryString, Nothing)
            Return Convert.ToInt32(result) = 1
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getNoReturBulananPOS() As String

        Dim blnskrng, thnskrng, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampReturPOS()
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            blnpenerimaan = dt.Rows(0).Item("blnReturPOS")
            thnpenerimaan = dt.Rows(0).Item("thnReturPOS")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    Return rumusNoReturPOS()
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterReturPOS()
                    Return rumusNoReturPOS()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterReturPOS()
                Return rumusNoReturPOS()
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
    Function getNoReturHarianPOS() As String
        Dim tglskrng, blnskrng, thnskrng, tglpenerimaan, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampReturPOS()
            tglskrng = dt.Rows(0).Item("tglskrng")
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            tglpenerimaan = dt.Rows(0).Item("tglReturPOS")
            blnpenerimaan = dt.Rows(0).Item("blnReturPOS")
            thnpenerimaan = dt.Rows(0).Item("thnReturPOS")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    If tglskrng = tglpenerimaan Then
                        Return rumusNoReturPOS()
                    ElseIf tglskrng > tglpenerimaan Then
                        Call resetCounterReturPOS()
                        Return rumusNoReturPOS()
                    ElseIf tglskrng < tglpenerimaan Then
                        MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                        Return ""
                    End If
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterReturPOS()
                    Return rumusNoReturPOS()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterReturPOS()
                Return rumusNoReturPOS()
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
    Function rumusNoReturPOS() As String
        Dim sekarang, formattgl, jmlcounter, cpo As String
        Try
            Dim dt As DataTable = getRumusReturPOS()
            sekarang = dt.Rows(0).Item("sekarang")
            formattgl = dt.Rows(0).Item("format_Retur_POS")
            jmlcounter = dt.Rows(0).Item("digit_counter_Retur_POS")
            cpo = dt.Rows(0).Item("Retur_pos")
            Dim tgl As DateTime = DateTime.ParseExact(sekarang, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim reformatted As String = tgl.ToString(formattgl, CultureInfo.InvariantCulture)
            updateCounterReturPOS()
            Return reformatted & CInt(cpo).ToString("D" & jmlcounter)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updateCounterReturPOS()
        Try
            Dim spName As String
            spName = "POS_update_CounterReturPOS"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub resetCounterReturPOS()
        Try
            Dim spName As String = "POS_update_ResetCounterReturPOS"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getTimeStampReturPOS() As DataTable
        Try
            Dim queryString As String = "CALL POS_get_timestampReturPOS()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getRumusReturPOS() As DataTable
        Try
            Dim queryString As String = "CALL POS_get_rumusReturPOS()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Retur Pengiriman"
    Function prosesReturPengiriman(ByVal kasir As String) As Boolean
        Dim userid As String
        Dim queries As New List(Of String)()
        Dim i As Integer

        Dim dt As DataTable = loadDataReturPengirimanTemp()

        Try
            If dt.Rows.Count > 0 Then
                Dim noRetur As String = generateNoReturPengirimanPOS()
                userid = frmPOS2.lblUserID.Text
                Dim valuesRetur As String = ""
                Dim valuesPenerimaan As String = ""
                For Each row As DataRow In dt.Rows
                    Dim returID As String = getidenkripsiplus(i)
                    Dim ttl As Integer = row("jumlah") * row("harga_jual")
                    valuesRetur &= $"('{returID}','{noRetur}',curdate(),'{row("kode")}','{row("harga_jual")}','{row("jumlah")}',now(),'{userid}','{kasir}','0',now()),"
                    Dim updateStok As String = $"CALL POS_update_StokForReturPengiriman('{row("kode")}', {row("jumlah")});"
                    queries.Add(updateStok)
                    i += 1
                Next

                valuesRetur = "(" & Chr(34) & Left(valuesRetur, valuesRetur.Length - 1) & Chr(34) & ")"

                Dim returTambahQuery As String = $"CALL POS_add_DataReturPengiriman {valuesRetur};"
                queries.Add(returTambahQuery)

                Dim delReturTemp As String = $"CALL POS_del_ALLDataReturPengirimanTemp('{getMacAddress()}');"
                queries.Add(delReturTemp)

                Dim retur As Boolean = con.ExecuteTrans(queries, True)
                If retur Then
                    con.isiLog(userid, $"Retur Pengiriman dengan No. Retur = {noRetur}")
                    'Dim print As MsgBoxResult
                    'Print = MsgBox("Retur sukses. Cetak Surat Jalan Retur ?", vbYesNo, "Macarons")
                    'If print = vbYes Then
                    printReturPengiriman(noRetur)
                    'End If
                    Return retur
                Else
                    MsgBox("Proses retur GAGAL. Hubungi developer.", vbCritical, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Data retur tidak ditemukan.", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Sub delReturPengirimanTemp(ByVal IDTemp As String)
        Try
            Dim spName As String = "POS_del_DataReturPengirimanTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)

            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function loadDataReturPengirimanTemp() As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataReturPengirimanTemp(@mcAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@mcAddr", getMacAddress)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function addItemReturPengiriman(ByVal kode As String) As Boolean
        Try
            Dim dt As DataTable = cekJmlReturPengiriman(kode)
            If dt.Rows.Count >= 0 Then
                If dt.Rows(0)("ada_stat_Y") = "Y" Then

                    Dim queryString As String = "POS_add_DataReturPengirimanTemp"
                    Dim parameters As New Dictionary(Of String, Object)()

                    parameters.Add("@barcode", kode)
                    parameters.Add("@hargaJual", dt.Rows(0)("harga"))
                    parameters.Add("@mcAdd", getMacAddress)

                    Dim upd As Integer = con.ubahdatabaseado(queryString, parameters, True)
                    Return upd <> 0
                Else
                    MsgBox("Jumlah retur melebihi jumlah stok.", vbCritical, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Data barang tidak ditemukan.", vbCritical, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function cekJmlReturPengiriman(ByVal kode As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_ValidReturPengiriman(@barcode,@mcAdd)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@barcode", kode)
            parameters.Add("@mcAdd", getMacAddress)

            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function generateNoReturPengirimanPOS() As String
        Dim resetHarian As Boolean = resetNoReturPengirimanHarianPOS()
        If resetHarian Then
            generateNoReturPengirimanPOS = getNoReturPengirimanHarianPOS()
        Else
            generateNoReturPengirimanPOS = getNoReturPengirimanBulananPOS()
        End If
    End Function
    Function resetNoReturPengirimanHarianPOS() As Boolean
        Try
            Dim queryString As String = "CALL POS_get_resetReturPengiriman"
            Dim result As Object = con.ExecuteScalar(queryString, Nothing)
            Return Convert.ToInt32(result) = 1
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getNoReturPengirimanBulananPOS() As String

        Dim blnskrng, thnskrng, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampReturPengirimanPOS()
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            blnpenerimaan = dt.Rows(0).Item("blnReturPengirimanPOS")
            thnpenerimaan = dt.Rows(0).Item("thnReturPengirimanPOS")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    Return rumusNoReturPengirimanPOS()
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterReturPengirimanPOS()
                    Return rumusNoReturPengirimanPOS()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterReturPengirimanPOS()
                Return rumusNoReturPengirimanPOS()
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
    Function getNoReturPengirimanHarianPOS() As String
        Dim tglskrng, blnskrng, thnskrng, tglpenerimaan, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampReturPengirimanPOS()
            tglskrng = dt.Rows(0).Item("tglskrng")
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            tglpenerimaan = dt.Rows(0).Item("tglReturPengirimanPOS")
            blnpenerimaan = dt.Rows(0).Item("blnReturPengirimanPOS")
            thnpenerimaan = dt.Rows(0).Item("thnReturPengirimanPOS")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    If tglskrng = tglpenerimaan Then
                        Return rumusNoReturPengirimanPOS()
                    ElseIf tglskrng > tglpenerimaan Then
                        Call resetCounterReturPengirimanPOS()
                        Return rumusNoReturPengirimanPOS()
                    ElseIf tglskrng < tglpenerimaan Then
                        MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                        Return ""
                    End If
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterReturPengirimanPOS()
                    Return rumusNoReturPengirimanPOS()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterReturPengirimanPOS()
                Return rumusNoReturPengirimanPOS()
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
    Function rumusNoReturPengirimanPOS() As String
        Dim sekarang, formattgl, jmlcounter, cpo As String
        Try
            Dim dt As DataTable = getRumusReturPengirimanPOS()
            sekarang = dt.Rows(0).Item("sekarang")
            formattgl = dt.Rows(0).Item("format_Retur_Pengiriman_POS")
            jmlcounter = dt.Rows(0).Item("digit_counter_Retur_Pengiriman_POS")
            cpo = dt.Rows(0).Item("Retur_Pengiriman_pos")
            Dim tgl As DateTime = DateTime.ParseExact(sekarang, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim reformatted As String = tgl.ToString(formattgl, CultureInfo.InvariantCulture)
            updateCounterReturPengirimanPOS()
            Return reformatted & CInt(cpo).ToString("D" & jmlcounter)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updateCounterReturPengirimanPOS()
        Try
            Dim spName As String
            spName = "POS_update_CounterReturPengiriman"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub resetCounterReturPengirimanPOS()
        Try
            Dim spName As String = "POS_update_ResetCounterReturPengiriman"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getTimeStampReturPengirimanPOS() As DataTable
        Try
            Dim queryString As String = "CALL POS_get_timestampReturPengiriman()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getRumusReturPengirimanPOS() As DataTable
        Try
            Dim queryString As String = "CALL POS_get_rumusReturPengiriman()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Ganti Password"
    Function gantipassword(ByVal userid As String, ByVal password As String) As Boolean
        Dim passwordmd5 As String = enkrip.getSHA1Hash(enkrip.md5(password))
        Try
            Dim queryString As String = "gantiPass"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@users", userid)
            parameters.Add("@pass", passwordmd5)

            Dim upd As Integer = con.ubahdatabaseado(queryString, parameters, True)
            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function

#End Region
#Region "Penerimaan"
    Function loadDataPenerimaanTemp(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataPenerimaanTempBySJ(@srtJln)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@srtJln", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function prosesPenerimaan(ByVal nosj As String, ByVal kasir As String) As Boolean
        Dim userid As String
        Dim queries As New List(Of String)()
        Dim i As Integer

        Dim dt As DataTable = loadDataPenerimaanTemp(nosj)

        Try
            If dt.Rows.Count > 0 Then
                userid = frmPOS2.lblUserID.Text
                Dim valuesPenerimaan As String = ""
                Dim updateStok As String = ""
                For Each row As DataRow In dt.Rows
                    Dim penerimaanID As String = getidenkripsiplus(i)
                    valuesPenerimaan &= $"('{penerimaanID}','{nosj}',now(),'{row("item_id")}','{UCase(row("kode"))}','{row("jml_item")}','{userid}','1','{row("Section")}','{row("tanggal_terima")}'),"
                    updateStok &= $"CALL POS_update_StokForPenerimaan('{penerimaanID}','{CDate(row("tanggal_terima")).ToString("yyyy-MM-dd")}','{row("item_id")}', '{row("jml_item")}','{row("harga")}','{row("harga_jual")}','{row("kode")}','{row("logo")}');"
                    i += 1
                Next

                valuesPenerimaan = "(" & Chr(34) & Left(valuesPenerimaan, valuesPenerimaan.Length - 1) & Chr(34) & ")"
                Dim penerimaanTambahQuery As String = $"CALL POS_add_DataPenerimaan {valuesPenerimaan};"
                queries.Add(penerimaanTambahQuery)

                queries.Add(updateStok)

                Dim delPenerimaanTemp As String = $"CALL POS_del_DataPenerimaanTemp('{nosj}');"
                queries.Add(delPenerimaanTemp)

                Dim terima As Boolean = con.ExecuteTrans(queries, True)
                If terima Then
                    con.isiLog(userid, $"Penerimaan dengan No. SJ = {nosj}")
                    Return terima
                Else
                    MsgBox("Proses penerimaan GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Nomor Surat Jalan Tidak Ditemukan.", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
#End Region
#Region "Cetak Ulang"
    Function loadDataNonota(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataPrintByNoNota(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function insertCetakUlang(ByVal nota As String, ByVal ket As String) As Boolean
        Try
            Dim spName As String = "POS_add_DataCetakUlangPenjualan"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nonota", nota)
            parameters.Add("@keterangan", ket)
            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataNoRetur(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataPrintByNoRetur(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Lap Shift"
    Sub CekLapShift()
        Dim cryRpt As New ReportDocument
        Dim userID As String = ext.getUserID
        Try
            cryRpt.Load(rptpath & "LapShift2.rpt")
            cryRpt.SetParameterValue("userID", userID)

            If Application.OpenForms().OfType(Of frmLap).Any Then
                AppActivate(frmLap.Text)
            Else
                frmLap.MenuStrip1.Visible = False
                frmLap.Show()
            End If
            frmLap.crv.ReportSource = cryRpt
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub

    Sub CetakLapShift()
        Dim mainReport As New ReportDocument
        Dim userID As String = ext.getUserID
        Try
            mainReport.Load(rptpath & "LapShift2.rpt")
            mainReport.SetParameterValue("userID", userID)

            mainReport.PrintOptions.PrinterName = printerKasir
            mainReport.PrintToPrinter(1, False, 0, 0)

            mainReport.Close()
            mainReport.Dispose()
            updateFlgPenjualanShift(userID)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub updateFlgPenjualanShift(ByVal userID As String)
        Try
            Dim spName As String = "update_FlgPrintPenjualan"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@userID", userID)

            con.ubahdatabaseado(spName, parameters, True)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
#End Region
#Region "Laporan"

    Sub frmLapPenjualanBarangKhususLoad()
        With frmLapPenjualanBarangKhusus
            .lblProses.Text = "0"
            Try
                Dim dt As DataTable = loadDataBrandBarangKhusus()
                With .cbxBrand
                    .DataSource = dt
                    .DisplayMember = "brand"
                    .ValueMember = "brand"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
                ext.errHandler(ex)
            Finally
                .lblProses.Text = "1"
            End Try
        End With
    End Sub

    Sub lappenjualanpertenantclick(ByVal tgl1 As String, ByVal tgl2 As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "PenjualanPerTenant2.rpt")

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
    Sub frmLapPengirimanPeriodeLoad()
        Try
            Dim dt As DataTable = loadDataCustomer("")
            With frmLapPenerimaanPeriode.cbxTenant
                .DataSource = dt
                .DisplayMember = "Nama"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub lappenerimaanperiodeclick(ByVal tgl1 As String, ByVal tgl2 As String, ByVal tenantID As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "PenerimaanPeriode.rpt")

            cryRpt.SetParameterValue("bdate", CDate(tgl1).ToString("yyyy-MM-dd"))
            cryRpt.SetParameterValue("edate", CDate(tgl2).ToString("yyyy-MM-dd"))
            cryRpt.SetParameterValue("custID", tenantID)
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
    Sub lappenjualanperiodeclick(ByVal tgl1 As String, ByVal tgl2 As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "PenjualanPeriode2.rpt")

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
    Sub lappenjualanBarangKhususclick(ByVal tgl1 As String, ByVal tgl2 As String, ByVal brand As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "PenjualanBarangKhusus.rpt")

            cryRpt.SetParameterValue("brand", brand)
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
    Sub lappenjualanEDCQRISclick(ByVal tgl1 As String, ByVal tgl2 As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "PenjualanEDCQRIS.rpt")

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
    Sub lappenjualanpernotaclick(ByVal tgl1 As String, ByVal tgl2 As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "PenjualanPerNota2.rpt")

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
    Sub lappenjualanperkasirclick(ByVal tgl1 As String, ByVal tgl2 As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "PenjualanPerKasir.rpt")

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
    Sub lapstokpertglbeliclick()
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "StokTglBeli.rpt")
            cryRpt.SetParameterValue("cari", "")
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
    Sub lapstokpertenantclick()
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "StokTenant.rpt")
            cryRpt.SetParameterValue("cari", "")
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
    Sub lapstokopnameclick(ByVal tgl1 As String, ByVal tgl2 As String)
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
#Region "Member"
    Function GenerateQRCode(text As String) As Bitmap
        Dim barcodeWriter As New BarcodeWriter()
        barcodeWriter.Format = BarcodeFormat.QR_CODE

        ' Generate QR code dan kembalikan sebagai Bitmap
        Return barcodeWriter.Write(text)
    End Function
    <Extension()>
    Public Sub FillRoundedRectangle(ByVal g As Graphics, ByVal brush As Brush, ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single, ByVal radius As Single)
        Dim path As New GraphicsPath()
        path.AddArc(x, y, radius, radius, 180, 90)
        path.AddArc(x + width - radius, y, radius, radius, 270, 90)
        path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90)
        path.AddArc(x, y + height - radius, radius, radius, 90, 90)
        path.CloseFigure()
        g.FillPath(brush, path)
    End Sub
    Function virtualCard(ByVal jenis As String, ByVal telp As String, ByVal noMember As String, ByVal nama As String, ByVal ktp As String) As String
        Dim templatePath As String = memberTemplatePath & jenis & ".jpg"
        If Not File.Exists(templatePath) Then
            Throw New FileNotFoundException("Template gambar tidak ditemukan.")
        End If
        Dim outputPath As String = memberOutputPath & telp & "_" & noMember & ".jpg"
        Dim template As Bitmap = New Bitmap(templatePath)
        Dim qrCodeContent As String = noMember ' Isi QR code
        Dim qrCode As Bitmap = GenerateQRCode(qrCodeContent)

        Dim qrCodeWidth As Integer = 300
        Dim qrCodeHeight As Integer = 300

        Dim qrCodeX As Integer = (template.Width - qrCodeWidth) \ 2
        Dim qrCodeY As Integer = 350 ' Jarak dari atas


        Using g As Graphics = Graphics.FromImage(template)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias


            g.DrawImage(qrCode, qrCodeX, qrCodeY, qrCodeWidth, qrCodeHeight)


            Dim titleFont As New Font("Arial", 32, FontStyle.Bold)
            Dim detailFont As New Font("Consolas", 24, FontStyle.Regular) ' Gunakan font monospaced
            Dim brush As Brush = Brushes.White
            Dim brushBlack As Brush = Brushes.Black


            Dim titleText As String = jenis & " Member Card"
            Dim titleX As Integer = (template.Width - CInt(g.MeasureString(titleText, titleFont).Width)) \ 2
            Dim titleY As Integer = qrCodeY + qrCodeHeight + 20 ' Jarak di bawah QR code
            g.DrawString(titleText, titleFont, brush, titleX, titleY)


            Dim details() As String = {
                "No. Member : " & noMember,
                "Nama       : " & nama,
                "No. KTP    : " & ktp,
                "No. Hp     : " & telp
            }
            Dim detailX As Integer = 35 ' Mulai dari kiri
            Dim detailY As Integer = titleY + 60 ' Jarak di bawah judul
            For Each line As String In details
                g.DrawString(line, detailFont, brush, detailX, detailY)
                detailY += 40 ' Jarak antar baris
            Next

            Dim diskon1 As String = ""
            Dim diskon2 As String = ""
            Dim ruleno3 As String = ""
            If jenis = "BD" Then
                diskon1 = "    - 2.5% untuk pembelian 500ribu - 1juta"
                diskon2 = "    - 5% untuk pembelian di atas 1juta"
                ruleno3 = "3. Member BD Arjuna berhak mengikuti undian berhadiah menarik yang diadakan secara periodik, terkecuali hadiah utama 1,2, dan 3."
            ElseIf jenis = "Personal" Then
                diskon1 = "    - 2.5% untuk pembelian 500ribu - 1juta"
                diskon2 = "    - 5% untuk pembelian di atas 1juta"
                ruleno3 = "3. Member Personal Arjuna berhak mengikuti undian berhadiah menarik yang diadakan secara periodik."
            ElseIf jenis = "Reseller" Then
                diskon1 = "    - 5% untuk pembelian 1juta - 3juta"
                diskon2 = "    - 10% untuk pembelian di atas 3juta"
                ruleno3 = "3. Member Reseller Arjuna berhak mengikuti undian berhadiah menarik yang diadakan secara periodik."
            End If
            ' Menambahkan peraturan member dengan bullet
            Dim rulesText As New List(Of String) From {
                        "1. Kartu member " & jenis & " otomatis mendapatkan diskon pembelanjaan",
                        diskon1,
                        diskon2,
                        "2. Member berhak mendapatkan 1 poin setiap pembelian senilai 1.000 rupiah, dan berlaku kelipatan.",
                        ruleno3,
                        "4. Masa berlaku sesuai yang tertulis pada kartu. Apabila masa berlaku habis, kartu tidak dapat dipakai, namun akumulasi point tetap disimpan dan dinormalkan saat masa berlaku diperpanjang (kartu aktif kembali).",
                        "5. Poin yang dikumpulkan akan berlaku kumulatif selama masa berlaku kartu.",
                        "6. Poin dapat digunakan dalam program promosi toko Arjuna seperti undian berhadiah, special rewards, member loyalti rewards, dan lain sebagainya."
                                                        }

            ' Font dan format teks
            Dim rulesFont As New Font("Consolas", 10, FontStyle.Regular) ' Font untuk aturan
            Dim format As New StringFormat()
            format.Alignment = StringAlignment.Near ' Rata kiri
            format.LineAlignment = StringAlignment.Near ' Rata atas
            format.Trimming = StringTrimming.Word ' Menjaga agar teks tidak terpotong

            ' Posisi awal untuk teks
            Dim textX As Integer = 15 ' Mulai dari kiri
            Dim textY As Integer = detailY + 20 ' Mulai di bawah detail terakhir
            Dim textWidthrule As Integer = template.Width - 15 ' Sesuaikan dengan lebar template, beri margin
            Dim bulletWidth As Integer = 20 ' Lebar indentasi untuk bullet
            Dim lineSpacing As Integer = 5 ' Jarak antar baris tambahan

            For Each rule As String In rulesText
                ' Pisahkan bullet dari teks
                Dim splitRule As String() = rule.Split(New Char() {" "c}, 2)
                Dim bullet As String = splitRule(0)
                Dim content As String = If(splitRule.Length > 1, splitRule(1), "")

                ' Gambar bullet
                g.DrawString(bullet, rulesFont, Brushes.White, New PointF(textX, textY))

                ' Gambar teks dengan indentasi
                Dim contentArea As New RectangleF(textX + bulletWidth, textY, textWidthrule - bulletWidth, template.Height - textY)
                Dim contentSize As SizeF = g.MeasureString(content, rulesFont, CInt(contentArea.Width))
                g.DrawString(content, rulesFont, Brushes.White, contentArea, format)

                ' Perbarui posisi Y untuk aturan berikutnya
                textY += CInt(contentSize.Height) + lineSpacing
            Next


            Dim footerText As String = "Arjuna " & jenis & " Member Card berlaku s/d 18 April 2030"

            ' Ukur lebar teks footer dan sesuaikan ukuran font
            Dim footerFontSize As Single = 18 ' Ukuran font awal
            Dim footerFont As New Font("Arial", footerFontSize, FontStyle.Bold)
            Dim maxWidth As Single = template.Width - 40 ' Margin kiri-kanan 20 px
            Dim textWidth As Single = g.MeasureString(footerText, footerFont).Width

            ' Jika lebar teks lebih besar dari lebar yang tersedia, kecilkan font
            While textWidth > maxWidth And footerFontSize > 10
                footerFontSize -= 1
                footerFont = New Font("Arial", footerFontSize, FontStyle.Bold)
                textWidth = g.MeasureString(footerText, footerFont).Width
            End While

            ' Hitung posisi X agar teks berada di tengah
            Dim footerX As Integer = (template.Width - textWidth) / 2 ' Posisi X di tengah gambar
            Dim footerY As Integer = 1240 ' Posisi Y footer tetap

            ' Gambar Footer
            g.DrawString(footerText, footerFont, brushBlack, footerX, footerY)

        End Using


        template.Save(outputPath, ImageFormat.Jpeg)


        template.Dispose()
        qrCode.Dispose()

        Return outputPath
    End Function
    Sub modeMemberAktif(ByVal strCari As String)
        Dim dt As DataTable = loadDataMember(strCari)
        If dt.Rows.Count > 0 Then
            Dim jenis As String = CStr(dt.Rows(0).Item("Jenis"))
            With frmPOS2
                If jenis = "Personal" Then
                    .BackColor = Color.FromArgb(0, 184, 148)
                ElseIf jenis = "Reseller" Then
                    .BackColor = Color.FromArgb(9, 132, 227)
                ElseIf jenis = "BD" Then
                    .BackColor = Color.FromArgb(253, 121, 168)
                End If
                .lblMemberJenis.Text = "Member " & jenis
                .cbMember.Enabled = True
                .cbMember.Checked = True
                .lblNoMember.Text = CStr(dt.Rows(0).Item("No Member"))
                .lblNoKTP.Text = CStr(dt.Rows(0).Item("No KTP"))
                .lblNamaMember.Text = CStr(dt.Rows(0).Item("Nama"))
                .lblAlamat.Text = CStr(dt.Rows(0).Item("Alamat"))
                .lblTelpMember.Text = CStr(dt.Rows(0).Item("Telp"))
            End With
        Else
            MsgBox("Data member tidak ditemukan.", vbCritical, "Macarons")
        End If
    End Sub
    Sub modeMemberNonaktif()
        With frmPOS2
            .BackColor = Color.FromArgb(99, 110, 114)
            .cbMember.Enabled = False
            .cbMember.Checked = False
            .lblNoMember.Text = "-"
            .lblNoKTP.Text = "-"
            .lblNamaMember.Text = "-"
            .lblAlamat.Text = "-"
            .lblTelpMember.Text = "-"
            .lblMemberJenis.Text = "Member "
        End With
    End Sub
    Sub updateDiskonMember(ByVal jenis As String, ByVal kasir As String, ByVal total As String)
        If jenis = "BD" Then
            updateDiskonBD(total, kasir)
        ElseIf jenis = "Personal" Then
            updateDiskonPR(total, kasir)
        ElseIf jenis = "Reseller" Then
            updateDiskonRS(total, kasir)
        ElseIf jenis = "-" Then
            updateDiskonClear(kasir)
        End If
    End Sub
    Sub updateDiskonBD(ByVal total As String, ByVal kasir As String)
        Dim spName As String = "POS_update_DiskonMember"
        Dim param As New Dictionary(Of String, Object)()
        param.Add("@jenisMember", "BD")
        param.Add("@totalBlanja", total)
        param.Add("@kasir", kasir)

        con.ubahdatabaseado(spName, param, False)
    End Sub
    Sub updateDiskonPR(ByVal total As String, ByVal kasir As String)
        Dim spName As String = "POS_update_DiskonMember"
        Dim param As New Dictionary(Of String, Object)()
        param.Add("@jenisMember", "PR")
        param.Add("@totalBlanja", total)
        param.Add("@kasir", kasir)

        con.ubahdatabaseado(spName, param, False)
    End Sub
    Sub updateDiskonRS(ByVal total As String, ByVal kasir As String)
        Dim spName As String = "POS_update_DiskonMember"
        Dim param As New Dictionary(Of String, Object)()
        param.Add("@jenisMember", "RS")
        param.Add("@totalBlanja", total)
        param.Add("@kasir", kasir)

        con.ubahdatabaseado(spName, param, False)
    End Sub
    Sub updateDiskonClear(ByVal kasir As String)
        Dim spName As String = "POS_update_DiskonMember"
        Dim param As New Dictionary(Of String, Object)()
        param.Add("@jenisMember", "-")
        param.Add("@totalBlanja", 0)
        param.Add("@kasir", kasir)

        con.ubahdatabaseado(spName, param, False)
    End Sub
    Function loadDataMember(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataMember(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataMemberID(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL POS_get_DataMemberByID(@IDCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDCari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekDeleteMember(ByVal id As String) As Boolean
        Try
            Dim queryString As String = "CALL POS_cek_DeleteDataMember(@idDel)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idDel", id)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Not IsNothing(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function memberDel(ByVal id As String) As Boolean
        Try
            Dim spName As String = "POS_del_DataMember"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idMember", id)
            Dim del As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return del <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getkodeMember(ByVal jenis As String) As String
        Try
            Dim queryString As String = "CALL POS_get_NomorMember(@jenisMember)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@jenisMember", jenis)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Dim spName As String = "POS_update_CounterMember"
            Dim param As New Dictionary(Of String, Object)()
            param.Add("@jenisMember", jenis)

            con.ubahdatabaseado(spName, parameters, True)

            If result IsNot Nothing Then
                Return result.ToString()
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return String.Empty
        End Try
    End Function
    Function cekMember(ByVal telp As String, ByVal ktp As String) As Boolean
        Try
            Dim queryString As String = "CALL POS_cek_DataMember(@telpMember,@ktpMember)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@telpMember", telp)
            parameters.Add("@ktpMember", ktp)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return IsNothing(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function memberTambah(ByVal ktp As String, ByVal nama As String, ByVal alamat As String,
                          ByVal telp As String, ByVal ket As String, ByVal jenis As String, ByVal noMember As String) As Boolean
        Dim idmember As String

        idmember = getidenkripsi()
        Try
            Dim spName As String = "POS_add_DataMember"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idMember", idmember)
            parameters.Add("@noMember", noMember)
            parameters.Add("@namaMember", nama)
            parameters.Add("@telpMember", telp)
            parameters.Add("@noKTP", ktp)
            parameters.Add("@alamatMember", alamat)
            parameters.Add("@ketMember", ket)
            parameters.Add("@jenisMember", jenis)

            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
#End Region
End Module
