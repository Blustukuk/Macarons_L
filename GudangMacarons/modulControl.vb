Imports Connection
Imports Ext
Imports System.Net.NetworkInformation
Imports System.Globalization
Imports System.Configuration
Imports ZXing
Imports System.Drawing.Imaging
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module modulControl
#Region "Declare"
    Dim con As clsConn = clsConn.Instance
    Dim ext As clsExt = clsExt.Instance
    Dim enkrip As New clsencrypt
    Dim rptpath As String = ConfigurationManager.AppSettings("rptpath")
    Dim mainprinter As String = ConfigurationManager.AppSettings("mainprinter")
    Dim barcodefilepath As String = ConfigurationManager.AppSettings("barcodefilepath")
    Dim barcodeprinter As String = ConfigurationManager.AppSettings("barcodeprinter")
    Dim pc As String = ConfigurationManager.AppSettings("pc")
    Dim stat As String = ConfigurationManager.AppSettings("stat")
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
    Function randomStr(ByVal n As Integer) As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz"
        Dim r As New Random
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 1 To n
            Dim idx As Integer = r.Next(0, 61)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function
    Function randomStrBarcode(ByVal n As Integer) As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 1 To n
            Dim idx As Integer = r.Next(0, 36)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function
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
    Sub ClearListView(ByRef lv As ListView)
        lv.Items.Clear()
        lv.Columns.Clear()
    End Sub
    Function getnumber(ByVal number As String) As String
        getnumber = number.Replace(".", "").Replace(",", "")
    End Function
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
    Sub printSuratJalan(ByVal noPenjualan As String)
        Dim cryRpt As New ReportDocument
        Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions
        Dim QRCodePath As String = Application.StartupPath & "\QRCode\SuratJalan.PNG"

        Try
            With cryRpt
                repOptions = .PrintOptions
                With repOptions
                    .PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                    .PaperSize = GetPapersizeID(mainprinter, "A4")
                    .PrinterName = mainprinter
                End With
                .Load(rptpath & "SuratJalan.rpt")
                .SetParameterValue("noJual", noPenjualan)
                .SetParameterValue("imgURL", QRCodePath)
                .PrintToPrinter(1, True, 0, 0)
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub printPengadaan()
        Dim cryRpt As New ReportDocument
        Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions

            Try
                With cryRpt
                    repOptions = .PrintOptions
                With repOptions
                    .PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                    .PaperSize = GetPapersizeID(mainprinter, "A4")
                    .PrinterName = mainprinter
                End With
                .Load(rptpath & "Pengadaan.rpt")
                .SetParameterValue("macAddr", getMacAddress)
                If stat <> "1" Then
                    Dim connectionInfo As New ConnectionInfo()
                    connectionInfo.ServerName = "Macarons"
                    connectionInfo.DatabaseName = "macarons_leo"
                    connectionInfo.UserID = "monty"
                    connectionInfo.Password = "montyelek"
                    For Each table As Table In cryRpt.Database.Tables
                        Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                        tableLogOnInfo.ConnectionInfo = connectionInfo
                        table.ApplyLogOnInfo(tableLogOnInfo)
                    Next
                    For Each subreport As ReportDocument In cryRpt.Subreports
                        For Each table As Table In subreport.Database.Tables
                            Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                            tableLogOnInfo.ConnectionInfo = connectionInfo
                            table.ApplyLogOnInfo(tableLogOnInfo)
                        Next
                    Next

                End If
                .PrintToPrinter(1, True, 0, 0)
            End With
            Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
#End Region
#Region "Login"
    Sub loginMacarons(username As String, password As String)
        Dim enkrip As New clsencrypt
        Dim isUser As DataTable
        isUser = validUser(username, password)
        If isUser.Rows.Count > 0 Then
            With frmMain
                .lblUserID.Text = CStr(isUser.Rows(0)("id"))
                .btnDashboardLogOut.Text = "LOGOUT (" & CStr(isUser.Rows(0)("nama")) & ")"
                Call con.isiLog(frmMain.lblUserID.Text, CStr(isUser.Rows(0)("nama")) & " login")
                .Show()
            End With

            frmLogin.txtUsername.Text = ""
            frmLogin.txtPassword.Text = ""
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
        frmMain.lblUserID.Text = "0"
        frmMain.btnDashboardLogOut.Text = "LOGOUT"
        If userid <> "0" Then
            Dim dt As DataTable = getUserInfo(userid)
            Dim username As String = dt.Rows(0).Item("nama")
            Call con.isiLog(userid, username & " logout")
        End If
        frmLogin.Show()
        frmMain.Hide()
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
#Region "Master Supplier"
    Function loadDataSupplier(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataSupplierByName(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekSupplier(ByVal kode As String, ByVal nama As String) As Boolean
        Try
            Dim queryString As String = "CALL cek_DataSupplier(@kodeCek,@namaCek)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@kodeCek", kode)
            parameters.Add("@namaCek", nama)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return IsNothing(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function mastersuppliertambah(ByVal nama As String, ByVal pic As String, ByVal alamat As String,
                              ByVal telp As String, ByVal aktif As String, ByVal kode As String) As Boolean
        Dim flgaktif As Integer
        Dim idsupplier As String

        If aktif = True Then
            flgaktif = 1
        Else
            flgaktif = 0
        End If
        idsupplier = getidenkripsi()
        Try
            Dim spName As String = "add_DataSupplier"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idSupp", idsupplier)
            parameters.Add("@namaSupp", nama)
            parameters.Add("@picSupp", pic)
            parameters.Add("@alamatSupp", alamat)
            parameters.Add("@telpSupp", telp)
            parameters.Add("@aktifSupp", flgaktif)
            parameters.Add("@kodeSupp", kode)

            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function mastersupplieredit(ByVal id As String, ByVal nama As String, ByVal pic As String, ByVal alamat As String,
                            ByVal telp As String, ByVal aktif As String, ByVal kode As String) As Boolean
        Dim flgaktif As Integer

        If aktif = True Then
            flgaktif = 1
        Else
            flgaktif = 0
        End If
        Try
            Dim spName As String = "update_DataSupplier"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idSupp", id)
            parameters.Add("@namaSupp", nama)
            parameters.Add("@picSupp", pic)
            parameters.Add("@alamatSupp", alamat)
            parameters.Add("@telpSupp", telp)
            parameters.Add("@aktifSupp", flgaktif)

            Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function cekDeleteSupplier(ByVal id As String) As Boolean
        Try
            Dim queryString As String = "CALL cek_DeleteDataSupplier(@idDel)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idDel", id)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Not IsNothing(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function mastersupplierdel(ByVal id As String) As Boolean
        Try
            Dim spName As String = "del_DataSupplier"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idSupp", id)
            Dim del As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return del <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataSupplierID(ByVal id As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataSupplierByID(@IDCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDCari", id)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Master Brand"
    Function loaddatabrand(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataBrandByName(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekBrand(ByVal kode As String, ByVal nama As String) As Boolean
        Try
            Dim queryString As String = "CALL cek_DataBrand(@kodeCek,@namaCek)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@kodeCek", kode)
            parameters.Add("@namaCek", nama)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return IsNothing(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function masterbrandtambah(ByVal nama As String, ByVal aktif As String, ByVal kode As String) As Boolean
        Dim flgaktif As Integer
        Dim idbrand As String

        If aktif = True Then
            flgaktif = 1
        Else
            flgaktif = 0
        End If
        idbrand = getidenkripsi()
        Try
            Dim spName As String = "add_DataBrand"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idBrand", idbrand)
            parameters.Add("@namaBrand", nama)
            parameters.Add("@aktifBrand", flgaktif)
            parameters.Add("@kodeBrand", kode)

            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function masterbrandedit(ByVal id As String, ByVal nama As String, ByVal aktif As String, ByVal kode As String) As Boolean
        Dim flgaktif As Integer

        If aktif = True Then
            flgaktif = 1
        Else
            flgaktif = 0
        End If
        Try
            Dim spName As String = "update_DataBrand"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idBrand", id)
            parameters.Add("@namaBrand", nama)
            parameters.Add("@aktifBrand", flgaktif)

            Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function cekDeleteBrand(ByVal id As String) As Boolean
        Try
            Dim queryString As String = "CALL cek_DeleteDataBrand(@idDel)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idDel", id)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Not IsNothing(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function masterbranddel(ByVal id As String) As Boolean
        Try
            Dim spName As String = "del_DataBrand"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idBrand", id)
            Dim del As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return del <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataBrandID(ByVal id As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataBrandByID(@IDCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDCari", id)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Master Artikel"
    Sub frmmasterartikelload()
        frmMasterArtikel.dgvtemp.DataSource = Nothing
        frmMasterArtikel.dgvtemp.Columns.Clear()
        frmMasterArtikel.lblproses.Text = "0"
        Try
            Dim dt As DataTable = loaddatabrand("")
            With frmMasterArtikel.cbxBrand
                .DataSource = dt
                .DisplayMember = "brand"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
            frmMasterArtikel.cbxBrand.Focus()
        Catch ex As Exception
            ext.errHandler(ex)
        Finally
            frmMasterArtikel.lblproses.Text = "1"
        End Try
    End Sub
    Function loadDataArtikel(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataArtikelByName(@namaCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataArtikelByIDBrand(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataArtikelByIDBrand(@IDCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDCari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekArtikel(ByVal kode As String, ByVal nama As String) As Boolean
        Try
            Dim queryString As String = "CALL cek_DataArtikel(@kodeCek,@namaCek)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@kodeCek", kode)
            parameters.Add("@namaCek", nama)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return IsNothing(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function masterartikeltambah(ByVal nama As String, ByVal idBrand As String, ByVal aktif As String, ByVal kode As String) As Boolean
        Dim flgaktif As Integer
        Dim idArtikel As String

        If aktif = True Then
            flgaktif = 1
        Else
            flgaktif = 0
        End If
        idArtikel = getidenkripsi()
        Try
            Dim spName As String = "add_DataArtikel"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idArtikel", idArtikel)
            parameters.Add("@idBrand", idBrand)
            parameters.Add("@namaArtikel", nama)
            parameters.Add("@aktifArtikel", flgaktif)
            parameters.Add("@kodeArtikel", kode)

            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function masterartikeledit(ByVal id As String, ByVal nama As String, ByVal idBrand As String, ByVal aktif As String, ByVal kode As String) As Boolean
        Dim flgaktif As Integer

        If aktif = True Then
            flgaktif = 1
        Else
            flgaktif = 0
        End If
        Try
            Dim spName As String = "update_DataArtikel"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idArtikel", id)
            parameters.Add("@idBrand", idBrand)
            parameters.Add("@namaArtikel", nama)
            parameters.Add("@aktifArtikel", flgaktif)

            Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function cekDeleteArtikel(ByVal id As String) As Boolean
        Try
            Dim queryString As String = "CALL cek_DeleteDataArtikel(@idDel)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idDel", id)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Not IsNothing(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function masterartikeldel(ByVal id As String) As Boolean
        Try
            Dim spName As String = "del_DataArtikel"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idArtikel", id)
            Dim del As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return del <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataArtikelID(ByVal id As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataArtikelByID(@IDCari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDCari", id)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function

#End Region
#Region "Pembelian"
    Sub frmPembelianLoad()
        Try
            frmPembelian.lblproses.Text = "0"
            Dim dt As DataTable = loadDataSupplier("")
            With frmPembelian.cbxSupplier
                .DataSource = dt
                .DisplayMember = "Nama"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
            Dim dt2 As DataTable = loaddatabrand("")
            With frmPembelian.cbxBrand
                .DataSource = dt2
                .DisplayMember = "brand"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        Finally
            frmPembelian.lblproses.Text = "1"
        End Try
    End Sub
    Function tambahPembelianTemp(ByVal tgl_beli As String, ByVal suppID As String, ByVal brandID As String, ByVal artikelID As String, ByVal nama As String, ByVal jml As String, ByVal harga As String) As Boolean
        Dim pembelianTempID As String = getidenkripsi()
        Try
            Dim spName As String = "add_DataPembelianTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", pembelianTempID)
            parameters.Add("@tglBeli", tgl_beli)
            parameters.Add("@IDSupp", suppID)
            parameters.Add("@IDBrand", brandID)
            parameters.Add("@IDArtikel", artikelID)
            parameters.Add("@namaItem", nama)
            parameters.Add("@jmlItem", getnumber(jml))
            parameters.Add("@hargaItem", getnumber(harga))
            parameters.Add("@ttl", getnumber(jml) * getnumber(harga))
            parameters.Add("@macAddr", getMacAddress)
            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, False)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataPembelianTemp(ByVal macAddr As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPembelianTemp(@macAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@macAddr", macAddr)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub delAlllPembelianTemp(ByVal macAddr As String)
        Try
            Dim spName As String = "del_ALLDataPembelianTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@macAddr", macAddr)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub delPembelianTemp(ByVal IDTemp As String)
        Try
            Dim spName As String = "del_DataPembelianTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)

            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function prosesPembelian(ByVal judul As String, ByVal nonota As String, ByVal ket As String, ByVal userid As String) As Boolean
        Dim i As Integer
        Try
            Dim dt As DataTable = loadDataPembelianTemp(getMacAddress)
            If dt.Rows.Count > 0 Then
                Dim noPembelian As String = generateNoPembelian()
                i = 0
                Dim queries As New List(Of String)()
                Dim queryString As String = ""
                Dim values As String = ""
                For Each row As DataRow In dt.Rows
                    Dim pembelianID As String = getidenkripsiplus(i)
                    values &= $"('{pembelianID}','{noPembelian}','{judul}','{nonota}','{row("tgl_beli")}','{row("No")}','{row("supp_id")}','{row("brand_id")}','{row("artikel_id")}','{row("Nama")}','{getnumber(row("Jumlah"))}','{getnumber(row("Harga"))}','{getnumber(row("Total"))}','{ket}','{userid}','1',now()),"
                    i += 1
                Next
                values = "(" & Chr(34) & Left(values, values.Length - 1) & Chr(34) & ")"
                Dim pembelianTambahQuery As String = $"CALL add_DataPembelian {values};"
                queries.Add(pembelianTambahQuery)
                Dim pembelian As Boolean = con.ExecuteTrans(queries, True)
                If pembelian Then
                    delAlllPembelianTemp(getMacAddress)
                    con.isiLog(userid, $"Pembelian untuk nonota = {nonota}")
                    MsgBox("Proses tambah data pembelian sukses.", vbOKOnly, "Macarons")
                    Return pembelian
                Else
                    MsgBox("Proses pembelian GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
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
    Function generateNoPembelian() As String
        Try
            Dim resetHarian As Boolean = resetNoPembelianHarian()
            If resetHarian Then
                generateNoPembelian = getNoPembelianHarian()
            Else
                generateNoPembelian = getNoPembelianBulanan()
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Function resetNoPembelianHarian() As Boolean
        Try
            Dim queryString As String = "CALL get_resetPembelian"
            Dim result As Object = con.ExecuteScalar(queryString, Nothing)
            Return Convert.ToInt32(result) = 1
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getNoPembelianBulanan() As String
        Dim blnskrng, thnskrng, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampPembelian()
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            blnpenerimaan = dt.Rows(0).Item("blnpembelian")
            thnpenerimaan = dt.Rows(0).Item("thnpembelian")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    Return rumusNoPembelian()
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterPembelian()
                    Return rumusNoPembelian()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterPembelian()
                Return rumusNoPembelian()
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
    Function getNoPembelianHarian() As String
        Dim tglskrng, blnskrng, thnskrng, tglpenerimaan, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampPembelian()
            tglskrng = dt.Rows(0).Item("tglskrng")
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            tglpenerimaan = dt.Rows(0).Item("tglpembelian")
            blnpenerimaan = dt.Rows(0).Item("blnpembelian")
            thnpenerimaan = dt.Rows(0).Item("thnpembelian")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    If tglskrng = tglpenerimaan Then
                        Return rumusNoPembelian()
                    ElseIf tglskrng > tglpenerimaan Then
                        Call resetCounterPembelian()
                        Return rumusNoPembelian()
                    ElseIf tglskrng < tglpenerimaan Then
                        MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                        Return ""
                    End If
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterPembelian()
                    Return rumusNoPembelian()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterPembelian()
                Return rumusNoPembelian()
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
    Function rumusNoPembelian() As String
        Dim sekarang, formattgl, jmlcounter, cpo As String
        Try
            Dim dt As DataTable = getRumusPembelian()
            sekarang = dt.Rows(0).Item("sekarang")
            formattgl = dt.Rows(0).Item("format_pembelian")
            jmlcounter = dt.Rows(0).Item("digit_counter_pembelian")
            cpo = dt.Rows(0).Item("pembelian")
            Call updateCounterPembelian()
            Dim tgl As DateTime = DateTime.ParseExact(sekarang, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim reformatted As String = tgl.ToString(formattgl, CultureInfo.InvariantCulture)
            Return reformatted & CInt(cpo).ToString("D" & jmlcounter)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updateCounterPembelian()
        Try
            Dim spName As String = "update_CounterPembelian"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub resetCounterPembelian()
        Try
            Dim spName As String = "update_ResetCounterPembelian"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getTimeStampPembelian() As DataTable
        Try
            Dim queryString As String = "CALL get_timestampPembelian()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getRumusPembelian() As DataTable
        Try
            Dim queryString As String = "CALL get_rumusPembelian()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getNamaItem(ByVal suppID As String, ByVal artikelID As String) As String
        Try
            Dim queryString As String = "CALL get_NamaItemPembelian(@suppID,@artikelID)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@suppID", suppID)
            parameters.Add("@artikelID", artikelID)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToString(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updatePembelianTemp(ByVal jml As String, ByVal harga As String, ByVal pembelianTempID As String)
        Try
            Dim dt As DataTable = loadDataPembelianTempByID(pembelianTempID)
            If dt.Rows.Count > 0 Then
                Dim ttl As Integer = harga * jml
                Dim spName As String = "update_PembelianTemp"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@idTemp", pembelianTempID)
                parameters.Add("@jmlItem", jml)
                parameters.Add("@hrg", harga)
                parameters.Add("@ttl", ttl)
                con.ubahdatabaseado(spName, parameters, False)
            End If
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function loadDataPembelianTempByID(ByVal IDTemp As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPembelianTempByID(@IDTemp)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "Pengadaan"
    Sub frmPengadaanLoad()
        frmPengadaan.lblproses.Text = "0"
        Try
            Dim dt As DataTable = loadDataPembelian()
            With frmPengadaan.cbxNoNota
                .DataSource = dt
                .DisplayMember = "id"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
            Dim dt2 As DataTable = loadDataLogo()
            With frmPengadaan.cbxLogo
                .DataSource = dt2
                .DisplayMember = "nama"
                .ValueMember = "id"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        Finally
            frmPengadaan.lblproses.Text = "1"
        End Try
    End Sub
    Sub frmPengadaanKhususLoad()
        frmPengadaanKhusus.lblproses.Text = "0"
        Try
            Dim dt As DataTable = loadDataPembelian()
            With frmPengadaanKhusus.cbxNoNota
                .DataSource = dt
                .DisplayMember = "id"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
            Dim dt2 As DataTable = loadDataLogo()
            With frmPengadaanKhusus.cbxLogo
                .DataSource = dt2
                .DisplayMember = "nama"
                .ValueMember = "id"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        Finally
            frmPengadaanKhusus.lblproses.Text = "1"
        End Try
    End Sub
    Function loadDataPembelian() As DataTable
        Try
            Dim queryString As String = "CALL get_DataPembelian()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataLogo() As DataTable
        Try
            Dim queryString As String = "CALL get_DataLogo()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub addPengadaanTemp(ByVal nonota As String, ByVal tgl As String)
        Dim i As Integer
        Try
            Dim dt As DataTable = loadDataPembelianByNoNota(nonota)
            If dt.Rows.Count > 0 Then
                Dim queries As New List(Of String)()
                Dim queryString As String = ""
                Dim values As String = ""
                i = 0
                For Each row As DataRow In dt.Rows
                    Dim pengadaanTempID As String = getidenkripsiplus(i)
                    values &= $"('{pengadaanTempID}','{tgl}','{nonota}','{row("No")}','{row("supp_id")}','{row("brand_id")}','{row("artikel_id")}','{row("Nama")}','{row("Jumlah")}','{row("Harga")}','0','0','{getMacAddress()}'),"
                    i += 1
                Next
                values = "(" & Chr(34) & Left(values, values.Length - 1) & Chr(34) & ")"
                Dim pengadaanTempTambahQuery As String = $"CALL add_DataPengadaanTemp {values};"
                queries.Add(pengadaanTempTambahQuery)

                Dim pengadaanTemp As Boolean = con.ExecuteTrans(queries, False)
                If pengadaanTemp Then

                Else
                    MsgBox("Proses tambah data ke antrian GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                End If
            End If
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function addPengadaanTempManual(ByVal nonota As String, ByVal tgl As String, ByVal brandID As String, ByVal artikelID As String, ByVal nama As String, ByVal jml As String, ByVal harga As String) As Boolean
        Try
            Dim queries As New List(Of String)()
            Dim queryString As String = ""
            Dim values As String = ""
            Dim pengadaanTempID As String = getidenkripsi()
            values &= $"('{pengadaanTempID}','{tgl}','{nonota}','0','-','{brandID}','{artikelID}','{nama}','{jml}','{harga}','0','0','{getMacAddress()}'),"
            values = "(" & Chr(34) & Left(values, values.Length - 1) & Chr(34) & ")"
            Dim pengadaanTempTambahQuery As String = $"CALL add_DataPengadaanTemp {values};"
            queries.Add(pengadaanTempTambahQuery)

            Dim pengadaanTemp As Boolean = con.ExecuteTrans(queries, False)
            If pengadaanTemp Then
                Return True
            Else
                MsgBox("Proses tambah data ke antrian GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataPembelianByNoNota(ByVal nonota As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPembelianByNoNota(@nonota)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nonota", nonota)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub delAlllPengadaanTemp(ByVal macAddr As String)
        Try
            Dim spName As String = "del_ALLDataPengadaanTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@macAddr", macAddr)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function loadDataPengadaanTemp(ByVal macAddr As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPengadaanTemp(@macAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@macAddr", macAddr)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataPengadaanTempByID(ByVal IDTemp As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPengadaanTempByID(@IDTemp)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub setMarginPengadaanTemp(ByVal margin As String, ByVal macAddr As String)
        Dim i As Integer
        Dim hargaJual As Integer
        Try
            Dim dt As DataTable = loadDataPengadaanTemp(macAddr)
            If dt.Rows.Count > 0 Then
                Dim queries As New List(Of String)()
                Dim queryString As String = ""
                i = 0
                For Each row As DataRow In dt.Rows
                    hargaJual = BulatkanKeAtas500((row("Harga") * ((100 + CInt(margin)) / 100)))
                    Dim updateStatOrder As String = $"CALL update_marginPengadaanTemp('{row("id")}','{margin}',{hargaJual},'{getMacAddress()}');"
                    queries.Add(updateStatOrder)
                    i += 1
                Next
                Dim updateMargin As Boolean = con.ExecuteTrans(queries, False)
                If updateMargin Then

                Else
                    MsgBox("Proses update margin GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                End If
            End If
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub delPengadaanTemp(ByVal IDTemp As String)
        Try
            Dim spName As String = "del_DataPengadaanTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function BulatkanKeAtas500(ByVal value As Integer) As Integer
        Dim remainder As Integer = value Mod 500
        If remainder > 0 Then
            Return (value + (500 - remainder))
        Else
            Return value
        End If
    End Function
    Sub updatePengadaanTemp(ByVal jml As String, ByVal margin As String, ByVal hargaKhusus As String, ByVal pengadaanTempID As String)
        Dim hargaJual As Integer
        Try
            Dim dt As DataTable = loadDataPengadaanTempByID(pengadaanTempID)
            If dt.Rows.Count > 0 Then
                If hargaKhusus <> "" Then
                    hargaJual = hargaKhusus
                Else
                    hargaJual = BulatkanKeAtas500((dt.Rows(0)("Harga") * ((100 + CInt(margin)) / 100)))
                End If
                Dim spName As String = "update_PengadaanTemp"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@idTemp", pengadaanTempID)
                parameters.Add("@jmlItem", jml)
                parameters.Add("@marg", margin)
                parameters.Add("@hargaJual", hargaJual)
                con.ubahdatabaseado(spName, parameters, False)
            End If
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
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
    Function prosesPengadaan(ByVal judul As String, ByVal logo As String, ByVal userid As String) As Boolean
        Dim i As Integer
        Dim nonota As String = ""
        Try
            Dim dt As DataTable = loadDataPengadaanTemp(getMacAddress)
            If dt.Rows.Count > 0 Then
                Dim noPengadaan As String = generateNoPengadaan()
                i = 0
                Dim queries As New List(Of String)()
                Dim valuesPengadaan As String = ""
                Dim valuesItem As String = ""
                Dim valuesStok As String = ""
                For Each row As DataRow In dt.Rows
                    If row("Margin") = "0" Then
                        MsgBox("Mohon setting MARGIN terlebih dahulu.", vbOKOnly, "Macarons")
                        Return False
                    End If
                    Dim pengadaanID As String = getidenkripsiplus(i)
                    Dim itemID As String = getidenkripsiplus(i & "item")
                    Dim stokID As String = getidenkripsiplus(i & "stok")
                    Dim barcode As String = getBarcodeItem()
                    valuesPengadaan &= $"('{pengadaanID}','{noPengadaan}','{judul}','{row("nonota")}','{row("tgl_pengadaan")}','{barcode}','{row("No")}','{row("supp_id")}','{row("brand_id")}','{row("artikel_id")}','{row("Nama")}','{getnumber(row("Jumlah"))}','{getnumber(row("Harga"))}','{userid}','1',{row("Margin")},'{getnumber(row("Harga Jual"))}','1',now()),"
                    valuesItem &= $"('{itemID}','{pengadaanID}','{barcode}','{row("Nama")}','1'),"
                    valuesStok &= $"('{stokID}','{itemID}','{getnumber(row("Jumlah"))}','{row("tgl_pengadaan")}',now(),'{pengadaanID}','0','{getnumber(row("Harga"))}','{getnumber(row("Harga Jual"))}',{logo}),"
                    i += 1
                    nonota = row("nonota")
                Next
                valuesPengadaan = "(" & Chr(34) & Left(valuesPengadaan, valuesPengadaan.Length - 1) & Chr(34) & ")"
                valuesItem = "(" & Chr(34) & Left(valuesItem, valuesItem.Length - 1) & Chr(34) & ")"
                valuesStok = "(" & Chr(34) & Left(valuesStok, valuesStok.Length - 1) & Chr(34) & ")"
                Dim pengadaanTambahQuery As String = $"CALL add_DataPengadaan {valuesPengadaan};"
                Dim itemTambahQuery As String = $"CALL add_DataItem {valuesItem};"
                Dim stokTambahQuery As String = $"CALL add_DataStok {valuesStok};"
                queries.Add(pengadaanTambahQuery)
                queries.Add(itemTambahQuery)
                queries.Add(stokTambahQuery)

                Dim pengadaan As Boolean = con.ExecuteTrans(queries, True)
                If pengadaan Then
                    updateFlgPembelian(nonota)
                    con.isiLog(userid, $"Pengadaan untuk nonota = {nonota}")
                    MsgBox("Proses tambah data pengadaan sukses.", vbOKOnly, "Macarons")
                    Return pengadaan
                Else
                    MsgBox("Proses pengadaan GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
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
    Function prosesPengadaanKhusus(ByVal judul As String, ByVal logo As String, ByVal userid As String) As Boolean
        Dim i As Integer
        Dim nonota As String = ""
        Try
            Dim dt As DataTable = loadDataPengadaanTemp(getMacAddress)
            If dt.Rows.Count > 0 Then
                Dim noPengadaan As String = generateNoPengadaan()
                i = 0
                Dim queries As New List(Of String)()
                Dim valuesPengadaan As String = ""
                Dim valuesItem As String = ""
                Dim valuesStok As String = ""
                For Each row As DataRow In dt.Rows
                    If row("Margin") = "0" Then
                        MsgBox("Mohon setting MARGIN terlebih dahulu.", vbOKOnly, "Macarons")
                        Return False
                    End If
                    Dim pengadaanID As String = getidenkripsiplus(i)
                    Dim itemID As String = getidenkripsiplus(i & "item")
                    Dim stokID As String = getidenkripsiplus(i & "stok")
                    Dim barcode As String = getBarcodeItemKhusus()
                    valuesPengadaan &= $"('{pengadaanID}','{noPengadaan}','{judul}','{row("nonota")}','{row("tgl_pengadaan")}','{barcode}','{row("No")}','{row("supp_id")}','{row("brand_id")}','{row("artikel_id")}','{row("Nama")}','{getnumber(row("Jumlah"))}','{getnumber(row("Harga"))}','{userid}','1',{row("Margin")},'{getnumber(row("Harga Jual"))}','1'),"
                    valuesItem &= $"('{itemID}','{pengadaanID}','{barcode}','{row("Nama")}','1'),"
                    valuesStok &= $"('{stokID}','{itemID}','{getnumber(row("Jumlah"))}','{row("tgl_pengadaan")}',now(),'{pengadaanID}','0','{getnumber(row("Harga"))}','{getnumber(row("Harga Jual"))}',{logo}),"
                    i += 1
                    nonota = row("nonota")
                Next
                valuesPengadaan = "(" & Chr(34) & Left(valuesPengadaan, valuesPengadaan.Length - 1) & Chr(34) & ")"
                valuesItem = "(" & Chr(34) & Left(valuesItem, valuesItem.Length - 1) & Chr(34) & ")"
                valuesStok = "(" & Chr(34) & Left(valuesStok, valuesStok.Length - 1) & Chr(34) & ")"
                Dim pengadaanTambahQuery As String = $"CALL add_DataPengadaan {valuesPengadaan};"
                Dim itemTambahQuery As String = $"CALL add_DataItem {valuesItem};"
                Dim stokTambahQuery As String = $"CALL add_DataStok {valuesStok};"
                queries.Add(pengadaanTambahQuery)
                queries.Add(itemTambahQuery)
                queries.Add(stokTambahQuery)

                Dim pengadaan As Boolean = con.ExecuteTrans(queries, True)
                If pengadaan Then
                    updateFlgPembelian(nonota)
                    con.isiLog(userid, $"Pengadaan untuk nonota = {nonota}")
                    MsgBox("Proses tambah data pengadaan sukses.", vbOKOnly, "Macarons")
                    Return pengadaan
                Else
                    MsgBox("Proses pengadaan GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
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
    Function generateNoPengadaan() As String
        Dim resetHarian As Boolean = resetNoPengadaanHarian()
        If resetHarian Then
            generateNoPengadaan = getNoPengadaanHarian()
        Else
            generateNoPengadaan = getNoPengadaanBulanan()
        End If
    End Function
    Function resetNoPengadaanHarian() As Boolean
        Try
            Dim queryString As String = "CALL get_resetPengadaan"
            Dim result As Object = con.ExecuteScalar(queryString, Nothing)
            Return Convert.ToInt32(result) = 1
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getNoPengadaanBulanan() As String

        Dim blnskrng, thnskrng, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampPengadaan()
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            blnpenerimaan = dt.Rows(0).Item("blnpengadaan")
            thnpenerimaan = dt.Rows(0).Item("thnpengadaan")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    Return rumusNoPengadaan()
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterPengadaan()
                    Return rumusNoPengadaan()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterPengadaan()
                Return rumusNoPengadaan()
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
    Function getNoPengadaanHarian() As String
        Dim tglskrng, blnskrng, thnskrng, tglpenerimaan, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampPengadaan()
            tglskrng = dt.Rows(0).Item("tglskrng")
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            tglpenerimaan = dt.Rows(0).Item("tglpengadaan")
            blnpenerimaan = dt.Rows(0).Item("blnpengadaan")
            thnpenerimaan = dt.Rows(0).Item("thnpengadaan")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    If tglskrng = tglpenerimaan Then
                        Return rumusNoPengadaan()
                    ElseIf tglskrng > tglpenerimaan Then
                        Call resetCounterPengadaan()
                        Return rumusNoPengadaan()
                    ElseIf tglskrng < tglpenerimaan Then
                        MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                        Return ""
                    End If
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterPengadaan()
                    Return rumusNoPengadaan()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterPengadaan()
                Return rumusNoPengadaan()
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
    Function rumusNoPengadaan() As String
        Dim sekarang, formattgl, jmlcounter, cpo As String
        Try
            Dim dt As DataTable = getRumusPengadaan()
            sekarang = dt.Rows(0).Item("sekarang")
            formattgl = dt.Rows(0).Item("format_pengadaan")
            jmlcounter = dt.Rows(0).Item("digit_counter_pengadaan")
            cpo = dt.Rows(0).Item("pengadaan")
            Call updateCounterPengadaan()
            Dim tgl As DateTime = DateTime.ParseExact(sekarang, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim reformatted As String = tgl.ToString(formattgl, CultureInfo.InvariantCulture)
            Return reformatted & CInt(cpo).ToString("D" & jmlcounter)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updateCounterPengadaan()
        Try
            Dim spName As String = "update_CounterPengadaan"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub resetCounterPengadaan()
        Try
            Dim spName As String = "update_ResetCounterPengadaan"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getTimeStampPengadaan() As DataTable
        Try
            Dim queryString As String = "CALL get_timestampPengadaan()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getRumusPengadaan() As DataTable
        Try
            Dim queryString As String = "CALL get_rumusPengadaan()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getBarcodeItem()
        Try
            Dim barcode As String = randomStrBarcode(10)
            Dim queryString As String = "CALL get_kodeItem(@barcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@barcode", barcode)

            Dim count As Integer
            Dim result As Object

            ' Lakukan permintaan pertama untuk memeriksa apakah barcode sudah ada di database
            result = con.ExecuteScalar(queryString, parameters)
            count = Convert.ToInt32(result)

            ' Selama barcode sudah ada di database, generate barcode baru dan cek lagi
            While count > 0
                barcode = randomStrBarcode(10) ' Ganti 10 dengan panjang barcode yang diinginkan
                parameters("@barcode") = barcode
                result = con.ExecuteScalar(queryString, parameters)
                count = Convert.ToInt32(result)
            End While

            ' Jika keluar dari loop, berarti barcode yang unik telah ditemukan
            Return barcode
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getBarcodeItemKhusus()
        Try
            Dim barcode As String = "13" & randomStrBarcode(10)
            Dim queryString As String = "CALL get_kodeItem(@barcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@barcode", barcode)

            Dim count As Integer
            Dim result As Object

            result = con.ExecuteScalar(queryString, parameters)
            count = Convert.ToInt32(result)

            While count > 0
                barcode = "13" & randomStrBarcode(10)
                parameters("@barcode") = barcode
                result = con.ExecuteScalar(queryString, parameters)
                count = Convert.ToInt32(result)
            End While

            Return barcode
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Sub updateFlgPembelian(ByVal nonota As String)
        Try
            Dim spName As String = "update_FlagPembelian"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nota", nonota)
            Dim del As Integer = con.ubahdatabaseado(spName, parameters, True)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
#End Region
#Region "Cetak Barcode"
    Sub frmCetakBarcodeLoad()
        frmCetakBarcode.lblproses.Text = "0"
        Try
            Dim dt As DataTable = loadDataPengadaan()
            With frmCetakBarcode.cbxNoNota
                .DataSource = dt
                .DisplayMember = "nonota"
                .ValueMember = "nonota"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        Finally
            frmCetakBarcode.lblproses.Text = "1"
        End Try
    End Sub
    Function loadDataPengadaan() As DataTable
        Try
            Dim queryString As String = "CALL get_DataPengadaan()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataCetakBarcode(ByVal nonota As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataCetakBarcode(@nota)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nota", nonota)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function insertDataPrintBarcode(ByVal nonota As String) As Boolean
        Try
            Dim dt As DataTable = loadDataCetakBarcode(nonota)
            If dt.Rows.Count > 0 Then
                Dim queries As New List(Of String)()
                Dim queryString As String = ""
                Dim values As String = ""
                For Each row As DataRow In dt.Rows
                    For a = 1 To row("Jml")
                        values &= $"('{row("Kode")}','{row("Harga")}','{row("Nama")}','{row("Logo")}',now(),'0','{row("tgl_pengadaan")}'),"
                    Next
                Next
                values = "(" & Chr(34) & Left(values, values.Length - 1) & Chr(34) & ")"
                Dim cetakBarcodeTambahQuery As String = $"CALL add_DataCetakBarcode {values};"
                queries.Add(cetakBarcodeTambahQuery)

                Dim cetak As Boolean = con.ExecuteTrans(queries, True)
                If cetak Then
                    Return cetak
                Else
                    MsgBox("Proses tambah antrian cetak barcode GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Tidak ditemukan data barcode yang akan dicetak", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Sub printBarcode(ByVal qr As Boolean)
        Dim btapp As New BarTender.Application
        Dim btformat As BarTender.Format
        Try
            If qr Then
                btformat = btapp.Formats.Open(barcodefilepath & "MacaronsQRcode.btw", False, barcodeprinter)
                btformat.PrintSetup.IdenticalCopiesOfLabel = 1
                btformat.Print("MacaronsQRcode", True, -1)
            Else
                btformat = btapp.Formats.Open(barcodefilepath & "MacaronsBarcode.btw", False, barcodeprinter)
                btformat.PrintSetup.IdenticalCopiesOfLabel = 1
                btformat.Print("MacaronsBarcode", True, -1)
            End If

            btformat.Close()
            updateFlagBarcode()
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub updateFlagBarcode()
        Try
            Dim spName As String = "update_FlagBarcode"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function updateFlagPrintStok(ByVal nonota As String, ByVal flg As Integer) As Boolean
        Try
            Dim spName As String = "update_FlagPrintStok"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nota", nonota)
            parameters.Add("@flg", flg)
            Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
#End Region
#Region "Cetak Barcode Manual"
    Sub frmCetakBarcodeManualLoad()
        Try
            With frmCetakBarcodeManual
                .rbBarcode.Checked = True
                .cbxBarcode.SelectedIndex = -1
                .cbxNota.SelectedIndex = -1
                .txtJml.Text = ""
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function loadDataBarcode(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPrintByBarcode(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function loadDataNonota(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPrintByNoNota(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getDataBarcodeByNota(ByVal nota As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPrintBarcodeByNoNota(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", nota)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function

    Function insertDataPrintBarcodeManual(ByVal kode As String, ByVal nama As String, ByVal harga As String, ByVal logo As String, ByVal jml As String, ByVal tgl As String) As Boolean
        Try
            Dim queries As New List(Of String)()
            Dim queryString As String = ""
            Dim values As String = ""
            Dim a As Integer
            For a = 1 To jml
                values &= $"('{kode}','{harga}','{nama}','{logo}',now(),'0','{tgl}'),"
            Next
            values = "(" & Chr(34) & Left(values, values.Length - 1) & Chr(34) & ")"
            Dim cetakBarcodeTambahQuery As String = $"CALL add_DataCetakBarcode {values};"
            queries.Add(cetakBarcodeTambahQuery)

            Dim cetak As Boolean = con.ExecuteTrans(queries, True)
            If cetak Then
                Return cetak
            Else
                MsgBox("Proses tambah antrian cetak barcode GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function insertDataPrintBarcodeManualByNota(ByVal nonota As String) As Boolean
        Try
            Dim queries As New List(Of String)()
            Dim queryString As String = ""
            Dim values As String = ""
            Dim dt As DataTable = getDataBarcodeByNota(nonota)
            If dt.Rows.Count > 0 Then
                Dim a As Integer
                For Each row As DataRow In dt.Rows
                    For a = 1 To row("jml")
                        values &= $"('{row("kode")}','{row("harga_jual")}','{row("nama")}','{row("logo")}',now(),'0','{row("tgl_pengadaan")}'),"
                    Next
                Next
                values = "(" & Chr(34) & Left(values, values.Length - 1) & Chr(34) & ")"
                Dim cetakBarcodeTambahQuery As String = $"CALL add_DataCetakBarcode {values};"
                queries.Add(cetakBarcodeTambahQuery)

                Dim cetak As Boolean = con.ExecuteTrans(queries, True)
                If cetak Then
                    Return cetak
                Else
                    MsgBox("Proses tambah antrian cetak barcode GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                    Return False
                End If
            Else
                MsgBox("Data barang untuk Nota = " & nonota & " tidak ditemukan.", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function

#End Region
#Region "Penjualan"
    Sub frmPenjualanLoad()
        Try
            frmPenjualan.lblProses.Text = "0"
            Dim dt As DataTable = loadDataCustomer("")
            With frmPenjualan.cbx7an
                .DataSource = dt
                .DisplayMember = "Nama"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
            frmPenjualan.lblProses.Text = "1"
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
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
    Sub dellallpenjualantemp()
        Try
            Dim spName As String = "del_ALLDataPenjualanTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@macAddr", pc)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getNamaByBarcode(ByVal bcode As String) As DataTable
        Try
            Dim queryString As String = "CALL get_NamaItemHargaJualByBarcode(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function tambahPenjualanTemp(ByVal tgl As String, ByVal custID As String, ByVal bcode As String, ByVal jml As String, ByVal harga As String) As Boolean
        Try
            Dim idTemp As String = getidenkripsi()
            Dim total As Integer = CInt(harga) * CInt(jml)
            Dim spName As String = "add_DataPenjualanTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idTemp", idTemp)
            parameters.Add("@tgl", tgl)
            parameters.Add("@custID", custID)
            parameters.Add("@bcode", bcode)
            parameters.Add("@jmlitem", jml)
            parameters.Add("@harga", harga)
            parameters.Add("@ttl", total)
            parameters.Add("@macAddr", pc)
            Dim ins As Integer = con.ubahdatabaseado(spName, parameters, True)
            Return ins <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getHargaJualByBarcode(ByVal bcode As String) As String
        Try
            Dim queryString As String = "CALL get_HargaJualByBarcode(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)
            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return Convert.ToString(result)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Function loadDataPenjualanTemp() As DataTable
        Try
            Dim queryString As String = "CALL get_DataPenjualanTemp(@macAddr)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@macAddr", pc)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub delPenjualanTemp(ByVal IDTemp As String)
        Try
            Dim spName As String = "del_DataPenjualanTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function cekStok(ByVal bcode As String, ByVal jml As String, ByVal tujuan As String) As Integer
        Try
            Dim queryString As String = "CALL get_StokStatus(@bcode,@jmlitem,@tujuan)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", bcode)
            parameters.Add("@jmlitem", jml)
            parameters.Add("@tujuan", tujuan)

            Dim result As Object = con.ExecuteScalar(queryString, parameters)
            Return result
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function prosesPenjualan(ByVal note As String, ByVal diskontotalrp As String, ByVal diskontotalpersen As String, ByVal edc As String,
                             ByVal noedc As String, ByVal bayar As String, ByVal userid As String) As Boolean
        Dim i As Integer
        Dim print As MsgBoxResult
        Try
            Dim dt As DataTable = loadDataPenjualanTemp()
            If dt.Rows.Count > 0 Then
                Dim noPenjualan As String = generateNoPenjualan()
                i = 0
                Dim queries As New List(Of String)()
                Dim valuesPenjualan As String = ""
                Dim updateStok As String = ""
                For Each row As DataRow In dt.Rows
                    Dim penjualanID As String = getidenkripsiplus(i)
                    valuesPenjualan &= $"('{penjualanID}','{noPenjualan}','{row("Tanggal")}','{row("custID")}','{row("Barcode")}','{getnumber(row("Jumlah"))}','{getnumber(row("Harga Jual"))}','{row("Diskon Rp")}','{row("Diskon %")}','{getnumber(row("Total"))}','{userid}','1','','',{diskontotalrp},{diskontotalpersen},'{note}','{bayar}',now(),0),"
                    updateStok = $"CALL update_StokForPenjualan('{row("Barcode")}', '{row("Jumlah")}');"
                    queries.Add(updateStok)
                    i += 1
                Next
                valuesPenjualan = "(" & Chr(34) & Left(valuesPenjualan, valuesPenjualan.Length - 1) & Chr(34) & ")"
                Dim penjualanTambahQuery As String = $"CALL add_DataPenjualan {valuesPenjualan};"
                queries.Add(penjualanTambahQuery)

                Dim penjualan As Boolean = con.ExecuteTrans(queries, True)
                If penjualan Then
                    con.isiLog(userid, $"Penjualan dengan No. Penjualan = {noPenjualan}")
                    print = MsgBox("Proses penjualan sukses. Cetak Nota ?", vbYesNo, "Macarons")
                    If print = vbYes Then
                        Dim QRCodePath As String = Application.StartupPath & "\QRCode\SuratJalan.PNG"
                        GenerateAndSaveQRCode(noPenjualan, QRCodePath)
                        printSuratJalan(noPenjualan)
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
    Function generateNoPenjualan() As String
        Dim resetHarian As Boolean = resetNoPenjualanHarian()
        If resetHarian Then
            generateNoPenjualan = getNoPenjualanHarian()
        Else
            generateNoPenjualan = getNoPenjualanBulanan()
        End If
    End Function
    Function resetNoPenjualanHarian() As Boolean
        Try
            Dim queryString As String = "CALL get_resetPenjualan"
            Dim result As Object = con.ExecuteScalar(queryString, Nothing)
            Return Convert.ToInt32(result) = 1
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getNoPenjualanBulanan() As String

        Dim blnskrng, thnskrng, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampPenjualan()
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            blnpenerimaan = dt.Rows(0).Item("blnpenjualan")
            thnpenerimaan = dt.Rows(0).Item("thnpenjualan")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    Return rumusNoPenjualan()
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterPenjualan()
                    Return rumusNoPenjualan()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterPenjualan()
                Return rumusNoPenjualan()
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
    Function getNoPenjualanHarian() As String
        Dim tglskrng, blnskrng, thnskrng, tglpenerimaan, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampPenjualan()
            tglskrng = dt.Rows(0).Item("tglskrng")
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            tglpenerimaan = dt.Rows(0).Item("tglPenjualan")
            blnpenerimaan = dt.Rows(0).Item("blnPenjualan")
            thnpenerimaan = dt.Rows(0).Item("thnPenjualan")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    If tglskrng = tglpenerimaan Then
                        Return rumusNoPenjualan()
                    ElseIf tglskrng > tglpenerimaan Then
                        Call resetCounterPenjualan()
                        Return rumusNoPenjualan()
                    ElseIf tglskrng < tglpenerimaan Then
                        MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                        Return ""
                    End If
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterPenjualan()
                    Return rumusNoPenjualan()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterPenjualan()
                Return rumusNoPenjualan()
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
    Function rumusNoPenjualan() As String
        Dim sekarang, formattgl, jmlcounter, cpo As String
        Try
            Dim dt As DataTable = getRumusPenjualan()
            sekarang = dt.Rows(0).Item("sekarang")
            formattgl = dt.Rows(0).Item("format_Penjualan")
            jmlcounter = dt.Rows(0).Item("digit_counter_Penjualan")
            cpo = dt.Rows(0).Item("Penjualan")
            Call updateCounterPenjualan()
            Dim tgl As DateTime = DateTime.ParseExact(sekarang, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim reformatted As String = tgl.ToString(formattgl, CultureInfo.InvariantCulture)
            Return reformatted & CInt(cpo).ToString("D" & jmlcounter)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updateCounterPenjualan()
        Try
            Dim spName As String = "update_CounterPenjualan"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub resetCounterPenjualan()
        Try
            Dim spName As String = "update_ResetCounterPenjualan"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getTimeStampPenjualan() As DataTable
        Try
            Dim queryString As String = "CALL get_timestampPenjualan()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getRumusPenjualan() As DataTable
        Try
            Dim queryString As String = "CALL get_rumusPenjualan()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub updatePenjualanTemp(ByVal idTemp As String, ByVal jml As String, ByVal diskonrp As String, ByVal diskonpersen As String)
        Try
            Dim total As Integer
            Dim dt As DataTable = loadDataPenjualanTempByID(idTemp)
            If dt.Rows.Count > 0 Then
                total = BulatkanKeAtas500((dt.Rows(0)("Harga Jual") * jml) * ((100 - diskonpersen) / 100) - diskonrp)
                Dim spName As String = "update_PenjualanTemp"
                Dim parameters As New Dictionary(Of String, Object)()
                parameters.Add("@idTemp", idTemp)
                parameters.Add("@jmlItem", jml)
                parameters.Add("@diskPersen", diskonpersen)
                parameters.Add("@diskRP", diskonrp)
                parameters.Add("@ttl", total)
                con.ubahdatabaseado(spName, parameters, False)
            End If
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function loadDataPenjualanTempByID(ByVal IDTemp As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPenjualanTempByID(@IDTemp)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@IDTemp", IDTemp)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getNamaBank() As DataTable
        Try
            Dim queryString As String = "CALL get_DataBank()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Public Sub GenerateAndSaveQRCode(text As String, filePath As String)
        Dim barcodeWriter As New BarcodeWriter()
        barcodeWriter.Format = BarcodeFormat.QR_CODE

        Dim barcodeBitmap As Bitmap = barcodeWriter.Write(text)

        barcodeBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)

        barcodeBitmap.Dispose()
    End Sub
#End Region
#Region "Edit Stok"
    Function loadDataStok(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataStok(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function editStok(ByVal id As String, ByVal stk As String, ByVal ket As String) As Boolean
        Try
            Dim spName As String = "update_Stok"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@idStok", id)
            parameters.Add("@stk", stk)

            Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            con.isiLog(frmMain.lblUserID.Text, "Edit stok dengan id = " & id & " jumlah menjadi = " & stk & " dengan keterangan = " & ket & ".")

            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
#End Region
#Region "Batal Pembelian"
    Sub frmBatalPembelianLoad()
        frmBatalPembelian.lblproses.Text = "0"
        Try
            Dim dt As DataTable = loadDataPembelian()
            With frmBatalPembelian.cbxNoNota
                .DataSource = dt
                .DisplayMember = "nonota"
                .ValueMember = "nonota"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        Finally
            frmBatalPembelian.lblproses.Text = "1"
        End Try
    End Sub
    Function batalPembelian(ByVal nonota As String) As Boolean
        Try
            Dim spName As String = "update_FlagPembelian"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nota", nonota)

            Dim upd As Integer = con.ubahdatabaseado(spName, parameters, True)
            con.isiLog(frmMain.lblUserID.Text, "Batal Pembelian Nota = " & nonota & ".")
            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function

#End Region
#Region "Laporan"
    Function loadDataNoSJ(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPrintSuratJalan(@cari)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@cari", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub cetakUlangSJClick(ByVal noSJ As String)
        Dim cryRpt As New ReportDocument
        Try
            Dim QRCodePath As String = Application.StartupPath & "\QRCode\SuratJalan.PNG"
            GenerateAndSaveQRCode(noSJ, QRCodePath)

            cryRpt.Load(rptpath & "SuratJalan.rpt")
            cryRpt.SetParameterValue("noJual", noSJ)
            cryRpt.SetParameterValue("imgURL", QRCodePath)

            If stat <> "1" Then
                Dim connectionInfo As New ConnectionInfo()
                connectionInfo.ServerName = "Macarons"
                connectionInfo.DatabaseName = "macarons_leo"
                connectionInfo.UserID = "monty"
                connectionInfo.Password = "montyelek"
                For Each table As Table In cryRpt.Database.Tables
                    Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                    tableLogOnInfo.ConnectionInfo = connectionInfo
                    table.ApplyLogOnInfo(tableLogOnInfo)
                Next
            End If
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
    Sub frmLapPengadaanPeriodeLoad()
        Try
            Dim dt As DataTable = loadDataSupplier("")
            Dim dr As DataRow = dt.NewRow()
            dr("id") = "0"
            dr("Kode") = "-"
            dr("Nama") = "-SEMUA-"
            dr("Alamat") = "-"
            dr("PIC") = "-"
            dr("Telp") = "-"
            dr("flg_aktif") = "1"
            dt.Rows.InsertAt(dr, 0)
            With frmLapPengadaanPeriode.cbxSupplier
                .DataSource = dt
                .DisplayMember = "Nama"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub frmLapPengadaanMarginPerSupplierLoad()
        Try
            Dim dt As DataTable = loadDataSupplier("")
            Dim dr As DataRow = dt.NewRow()
            dr("id") = "0"
            dr("Kode") = "-"
            dr("Nama") = "-SEMUA-"
            dr("Alamat") = "-"
            dr("PIC") = "-"
            dr("Telp") = "-"
            dr("flg_aktif") = "1"
            dt.Rows.InsertAt(dr, 0)
            With frmLapPengadaanMarginPerSupplier.cbxSupplier
                .DataSource = dt
                .DisplayMember = "Nama"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub lappengadaanperiodeclick(ByVal tgl1 As String, ByVal tgl2 As String, ByVal suppID As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "pengadaanperiode.rpt")

            cryRpt.SetParameterValue("bdate", CDate(tgl1).ToString("yyyy-MM-dd"))
            cryRpt.SetParameterValue("edate", CDate(tgl2).ToString("yyyy-MM-dd"))
            If suppID <> "0" Then
                cryRpt.SetParameterValue("suppID", suppID)
            Else
                cryRpt.SetParameterValue("suppID", "")
            End If
            If stat <> "1" Then
                Dim connectionInfo As New ConnectionInfo()
                connectionInfo.ServerName = "Macarons"
                connectionInfo.DatabaseName = "macarons_leo"
                connectionInfo.UserID = "monty"
                connectionInfo.Password = "montyelek"
                For Each table As Table In cryRpt.Database.Tables
                    Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                    tableLogOnInfo.ConnectionInfo = connectionInfo
                    table.ApplyLogOnInfo(tableLogOnInfo)
                Next
            End If
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
    Sub lappengadaanMarginPerSupplierclick(ByVal suppID As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "pengadaanMarginPerSupplier.rpt")

            If suppID <> "0" Then
                cryRpt.SetParameterValue("suppID", suppID)
            Else
                cryRpt.SetParameterValue("suppID", "")
            End If
            If stat <> "1" Then
                Dim connectionInfo As New ConnectionInfo()
                connectionInfo.ServerName = "Macarons"
                connectionInfo.DatabaseName = "macarons_leo"
                connectionInfo.UserID = "monty"
                connectionInfo.Password = "montyelek"
                For Each table As Table In cryRpt.Database.Tables
                    Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                    tableLogOnInfo.ConnectionInfo = connectionInfo
                    table.ApplyLogOnInfo(tableLogOnInfo)
                Next
            End If
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
    Sub lappengadaanByNamaclick(ByVal suppID As String, ByVal brandID As String, ByVal artikelID As String, ByVal nama As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "pengadaanByNama.rpt")

            cryRpt.SetParameterValue("suppID", suppID)
            cryRpt.SetParameterValue("brandID", brandID)
            cryRpt.SetParameterValue("artikelID", artikelID)
            cryRpt.SetParameterValue("namaItem", nama)
            If stat <> "1" Then
                Dim connectionInfo As New ConnectionInfo()
                connectionInfo.ServerName = "Macarons"
                connectionInfo.DatabaseName = "macarons_leo"
                connectionInfo.UserID = "monty"
                connectionInfo.Password = "montyelek"
                For Each table As Table In cryRpt.Database.Tables
                    Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                    tableLogOnInfo.ConnectionInfo = connectionInfo
                    table.ApplyLogOnInfo(tableLogOnInfo)
                Next
            End If
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
    Sub lapHistoryItem(ByVal bcode As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "historyItem.rpt")

            cryRpt.SetParameterValue("bcode", bcode)
            If stat <> "1" Then
                Dim connectionInfo As New ConnectionInfo()
                connectionInfo.ServerName = "Macarons"
                connectionInfo.DatabaseName = "macarons_leo"
                connectionInfo.UserID = "monty"
                connectionInfo.Password = "montyelek"
                For Each table As Table In cryRpt.Database.Tables
                    Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                    tableLogOnInfo.ConnectionInfo = connectionInfo
                    table.ApplyLogOnInfo(tableLogOnInfo)
                Next
            End If
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
    Sub frmLapPengadaanByNamaLoad()
        With frmLapPengadaanByNama
            Try
                .lblproses.Text = "0"
                Dim dt As DataTable = loadDataSupplier("")
                With .cbxSupplier
                    .DataSource = dt
                    .DisplayMember = "Nama"
                    .ValueMember = "id"
                    .SelectedIndex = -1
                End With
                Dim dt2 As DataTable = loaddatabrand("")
                With .cbxBrand
                    .DataSource = dt2
                    .DisplayMember = "brand"
                    .ValueMember = "id"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
                ext.errHandler(ex)
            Finally
                .lblproses.Text = "1"
            End Try
        End With
    End Sub
    Sub frmLapStokPeriodeLoad()
        Try
            Dim dt As DataTable = loadDataSupplier("")
            Dim dr As DataRow = dt.NewRow()
            dr("id") = "0"
            dr("Kode") = "-"
            dr("Nama") = "-SEMUA-"
            dr("Alamat") = "-"
            dr("PIC") = "-"
            dr("Telp") = "-"
            dr("flg_aktif") = "1"
            dt.Rows.InsertAt(dr, 0)
            With frmLapStokPeriode.cbxSupplier
                .DataSource = dt
                .DisplayMember = "Nama"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub lapstokperiodeclick(ByVal suppID As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "stoknow.rpt")

            If suppID <> "0" Then
                cryRpt.SetParameterValue("suppID", suppID)
            Else
                cryRpt.SetParameterValue("suppID", "")
            End If
            If stat <> "1" Then
                Dim connectionInfo As New ConnectionInfo()
                connectionInfo.ServerName = "Macarons"
                connectionInfo.DatabaseName = "macarons_leo"
                connectionInfo.UserID = "monty"
                connectionInfo.Password = "montyelek"
                For Each table As Table In cryRpt.Database.Tables
                    Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                    tableLogOnInfo.ConnectionInfo = connectionInfo
                    table.ApplyLogOnInfo(tableLogOnInfo)
                Next
            End If
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
            With frmLapPengirimanPeriode.cbxTenant
                .DataSource = dt
                .DisplayMember = "Nama"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub lappenjualanperiodeclick(ByVal tgl1 As String, ByVal tgl2 As String, ByVal tenantID As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "penjualanperiode.rpt")

            cryRpt.SetParameterValue("bdate", CDate(tgl1).ToString("yyyy-MM-dd"))
            cryRpt.SetParameterValue("edate", CDate(tgl2).ToString("yyyy-MM-dd"))
            cryRpt.SetParameterValue("custID", tenantID)
            If stat <> "1" Then
                Dim connectionInfo As New ConnectionInfo()
                connectionInfo.ServerName = "Macarons"
                connectionInfo.DatabaseName = "macarons_leo"
                connectionInfo.UserID = "monty"
                connectionInfo.Password = "montyelek"
                For Each table As Table In cryRpt.Database.Tables
                    Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                    tableLogOnInfo.ConnectionInfo = connectionInfo
                    table.ApplyLogOnInfo(tableLogOnInfo)
                Next
            End If
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
    Sub lapreturpenjualanclick(ByVal tgl1 As String, ByVal tgl2 As String)
        Dim cryRpt As New ReportDocument
        Try
            cryRpt.Load(rptpath & "ReturByTgl.rpt")

            cryRpt.SetParameterValue("bdate", CDate(tgl1).ToString("yyyy-MM-dd"))
            cryRpt.SetParameterValue("edate", CDate(tgl2).ToString("yyyy-MM-dd"))
            If stat <> "1" Then
                Dim connectionInfo As New ConnectionInfo()
                connectionInfo.ServerName = "Macarons"
                connectionInfo.DatabaseName = "macarons_leo"
                connectionInfo.UserID = "monty"
                connectionInfo.Password = "montyelek"
                For Each table As Table In cryRpt.Database.Tables
                    Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
                    tableLogOnInfo.ConnectionInfo = connectionInfo
                    table.ApplyLogOnInfo(tableLogOnInfo)
                Next
            End If
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
#Region "Voucher"
    Function printVoucher(ByVal nominal As String, ByVal jml As String, ByVal aktif As String) As Boolean
        Try
            Dim queries As New List(Of String)()
            Dim queryString As String = ""
            Dim values As String = ""
            Dim a As Integer
            Dim id As String = ""
            Dim barcode As String = ""
            For a = 1 To jml
                id = getidenkripsiplus(a)
                barcode = "19" & getBarcodeVoucher()
                values &= $"('{id}','{nominal}','{barcode}',now(),'0','0','{aktif}'),"
            Next
            values = "(" & Chr(34) & Left(values, values.Length - 1) & Chr(34) & ")"
            Dim cetakBarcodeTambahQuery As String = $"CALL add_DataVoucher {values};"
            queries.Add(cetakBarcodeTambahQuery)

            Dim cetak As Boolean = con.ExecuteTrans(queries, True)
            If cetak Then
                printBarcodeVoucher()
                Return cetak
            Else
                MsgBox("Proses tambah antrian cetak barcode GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
                Return False
            End If
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getBarcodeVoucher()
        Try
            Dim barcode As String = randomStrBarcode(10)
            Dim queryString As String = "CALL get_kodeVoucher(@bcode)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@bcode", barcode)

            Dim count As Integer
            Dim result As Object

            ' Lakukan permintaan pertama untuk memeriksa apakah barcode sudah ada di database
            result = con.ExecuteScalar(queryString, parameters)
            count = Convert.ToInt32(result)

            ' Selama barcode sudah ada di database, generate barcode baru dan cek lagi
            While count > 0
                barcode = randomStrBarcode(10) ' Ganti 10 dengan panjang barcode yang diinginkan
                parameters("@bcode") = barcode
                result = con.ExecuteScalar(queryString, parameters)
                count = Convert.ToInt32(result)
            End While

            ' Jika keluar dari loop, berarti barcode yang unik telah ditemukan
            Return barcode
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Sub printBarcodeVoucher()
        Dim btapp As New BarTender.Application
        Dim btformat As BarTender.Format
        Try
            btformat = btapp.Formats.Open(barcodefilepath & "MacaronsBarcodeVoucher.btw", False, barcodeprinter)
            btformat.PrintSetup.IdenticalCopiesOfLabel = 1
            btformat.Print("MacaronsBarcodeVoucher", True, -1)

            btformat.Close()
            updateFlagBarcodeVoucher()
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub updateFlagBarcodeVoucher()
        Try
            Dim spName As String = "update_FlagBarcodeVoucher"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub

#End Region
#Region "Retur Penjualan"
    Function loadDataPenjualanPOS(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataPenjualan(@namaCari)"
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
            Dim queryString As String = "CALL get_DataRetur(@namaCari)"
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
            Dim queryString As String = "CALL get_DataReturTemp(@namaCari,@mcAdd)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@namaCari", cari)
            parameters.Add("@mcAdd", getMacAddress)

            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function cekJmlRetur(ByVal kode As String, ByVal nota As String) As DataTable
        Try
            Dim queryString As String = "CALL get_ValidRetur(@barcode,@nota,@mcAdd)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@barcode", kode)
            parameters.Add("@nota", nota)
            parameters.Add("@mcAdd", getMacAddress)

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
                    Dim queryString As String = "add_DataReturTemp"
                    Dim parameters As New Dictionary(Of String, Object)()

                    parameters.Add("@barcode", kode)
                    parameters.Add("@hargaJual", dt.Rows(0)("harga_jual"))
                    parameters.Add("@nomorNota", nota)
                    parameters.Add("@mcAdd", getMacAddress)

                    Dim upd As Integer = con.ubahdatabaseado(queryString, parameters, True)
                    Return upd <> 0
                Else
                    MsgBox("Jumlah retur melebihi jumlah jual.", vbCritical, "Macarons")
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
            Dim queryString As String = "del_DataReturTemp"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@barcode", kode)
            parameters.Add("@nomornota", nota)

            Dim upd As Integer = con.ubahdatabaseado(queryString, parameters, True)
            Return upd <> 0
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function loadDataReturPenjualanTemp(ByVal cari As String) As DataTable
        Try
            Dim queryString As String = "CALL get_DataReturPenjualanTemp(@srtJln)"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@srtJln", cari)
            Return con.FillDataTable(queryString, parameters)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function prosesReturPenjualan(ByVal nosj As String, ByVal userID As String) As Boolean
        Dim queries As New List(Of String)()
        Dim i As Integer

        Dim dt As DataTable = loadDataReturPenjualanTemp(nosj)

        Try
            If dt.Rows.Count > 0 Then
                Dim valuesReturPenjualan As String = ""
                Dim updateStok As String = ""
                For Each row As DataRow In dt.Rows
                    Dim returPenjualanID As String = getidenkripsiplus(i)
                    valuesReturPenjualan &= $"('{returPenjualanID}','{(UCase(nosj))}','{CDate(row("tgl_insert")).ToString("yyyy-MM-dd")}','{UCase(row("kode"))}','{row("harga_jual")}','{row("jumlah")}',now(),'-','{userID}','00','0',now()),"
                    updateStok &= $"CALL update_StokForRetur('{row("kode")}', '{row("jumlah")}');"
                    i += 1
                Next

                valuesReturPenjualan = "(" & Chr(34) & Left(valuesReturPenjualan, valuesReturPenjualan.Length - 1) & Chr(34) & ")"
                Dim penerimaanTambahQuery As String = $"CALL add_DataRetur {valuesReturPenjualan};"
                queries.Add(penerimaanTambahQuery)

                queries.Add(updateStok)

                Dim delPenerimaanTemp As String = $"CALL del_ALLDataReturTemp('{nosj}');"
                queries.Add(delPenerimaanTemp)

                Dim terima As Boolean = con.ExecuteTrans(queries, True)
                If terima Then
                    con.isiLog(userID, $"Retur Penjualan dengan No. SJ = {nosj}")
                    Return terima
                Else
                    MsgBox("Proses Retur Penjualan GAGAL. Hubungi developer.", vbOKOnly, "Macarons")
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
    Function returpenjualan(ByVal nonota As String, ByVal kasir As String) As Boolean
        Dim userid As String
        Dim queries As New List(Of String)()
        Dim i As Integer

        Dim dt As DataTable = loadDataPenjualanReturTemp(nonota)
        Try
            If dt.Rows.Count > 0 Then
                Dim noRetur As String = generateNoRetur()
                userid = frmMain.lblUserID.Text
                Dim valuesRetur As String = ""
                For Each row As DataRow In dt.Rows
                    Dim returID As String = getidenkripsiplus(i)
                    valuesRetur &= $"('{returID}','{noRetur}',curdate(),'{row("kode")}','{row("harga_jual")}','{row("jumlah")}',now(),'{nonota}','{userid}','{kasir}'),"
                    Dim updateStok As String = $"CALL update_StokForRetur('{row("kode")}', {row("jumlah")});"
                    queries.Add(updateStok)
                    i += 1
                Next

                valuesRetur = "(" & Chr(34) & Left(valuesRetur, valuesRetur.Length - 1) & Chr(34) & ")"

                Dim returTambahQuery As String = $"CALL add_DataRetur {valuesRetur};"
                queries.Add(returTambahQuery)

                Dim delReturTemp As String = $"CALL del_ALLDataReturTemp('{getMacAddress()}');"
                queries.Add(delReturTemp)

                Dim retur As Boolean = con.ExecuteTrans(queries, True)
                If retur Then
                    con.isiLog(userid, $"Retur dengan No. SJ = {nonota}")
                    Dim print As MsgBoxResult
                    print = MsgBox("Retur sukses. Cetak Bukti Retur ?", vbYesNo, "Macarons")
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
            Dim queryString As String = "CALL get_DataReturPenjualanTemp(@nota)"
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
    Function generateNoRetur() As String
        Dim resetHarian As Boolean = resetNoReturHarian()
        If resetHarian Then
            generateNoRetur = getNoReturHarian()
        Else
            generateNoRetur = getNoReturBulanan()
        End If
    End Function
    Function resetNoReturHarian() As Boolean
        Try
            Dim queryString As String = "CALL get_resetRetur"
            Dim result As Object = con.ExecuteScalar(queryString, Nothing)
            Return Convert.ToInt32(result) = 1
        Catch ex As Exception
            ext.errHandler(ex)
            Return False
        End Try
    End Function
    Function getNoReturBulanan() As String

        Dim blnskrng, thnskrng, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampRetur()
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            blnpenerimaan = dt.Rows(0).Item("blnRetur")
            thnpenerimaan = dt.Rows(0).Item("thnRetur")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    Return rumusNoRetur()
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterRetur()
                    Return rumusNoRetur()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterRetur()
                Return rumusNoRetur()
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
    Function getNoReturHarian() As String
        Dim tglskrng, blnskrng, thnskrng, tglpenerimaan, blnpenerimaan, thnpenerimaan As Integer
        Try
            Dim dt As DataTable = getTimeStampRetur()
            tglskrng = dt.Rows(0).Item("tglskrng")
            blnskrng = dt.Rows(0).Item("blnskrng")
            thnskrng = dt.Rows(0).Item("thnskrng")
            tglpenerimaan = dt.Rows(0).Item("tglRetur")
            blnpenerimaan = dt.Rows(0).Item("blnRetur")
            thnpenerimaan = dt.Rows(0).Item("thnRetur")
            If thnskrng = thnpenerimaan Then
                If blnskrng = blnpenerimaan Then
                    If tglskrng = tglpenerimaan Then
                        Return rumusNoRetur()
                    ElseIf tglskrng > tglpenerimaan Then
                        Call resetCounterRetur()
                        Return rumusNoRetur()
                    ElseIf tglskrng < tglpenerimaan Then
                        MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                        Return ""
                    End If
                ElseIf blnskrng > blnpenerimaan Then
                    Call resetCounterRetur()
                    Return rumusNoRetur()
                ElseIf blnskrng < blnpenerimaan Then
                    MsgBox("Tanggal server dan tanggal update database terakhir tidak cocok.", vbCritical, "Macarons")
                    Return ""
                End If
            ElseIf thnskrng > thnpenerimaan Then
                Call resetCounterRetur()
                Return rumusNoRetur()
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
    Function rumusNoRetur() As String
        Dim sekarang, formattgl, jmlcounter, cpo As String
        Try
            Dim dt As DataTable = getRumusRetur()
            sekarang = dt.Rows(0).Item("sekarang")
            formattgl = dt.Rows(0).Item("format_Retur")
            jmlcounter = dt.Rows(0).Item("digit_counter_Retur")
            cpo = dt.Rows(0).Item("Retur")
            Dim tgl As DateTime = DateTime.ParseExact(sekarang, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim reformatted As String = tgl.ToString(formattgl, CultureInfo.InvariantCulture)
            updateCounterRetur()
            Return reformatted & CInt(cpo).ToString("D" & jmlcounter)
        Catch ex As Exception
            ext.errHandler(ex)
            Return ""
        End Try
    End Function
    Sub updateCounterRetur()
        Try
            Dim spName As String
            spName = "update_CounterRetur"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub resetCounterRetur()
        Try
            Dim spName As String = "update_ResetCounterRetur"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Function getTimeStampRetur() As DataTable
        Try
            Dim queryString As String = "CALL get_timestampRetur()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Function getRumusRetur() As DataTable
        Try
            Dim queryString As String = "CALL get_rumusRetur()"
            Return con.FillDataTable(queryString, Nothing)
        Catch ex As Exception
            ext.errHandler(ex)
            Return Nothing
        End Try
    End Function
    Sub printRetur(ByVal noNota As String)
        Dim cryRpt As New ReportDocument

        Try
            cryRpt.Load(rptpath & "Retur.rpt")
            cryRpt.SetParameterValue("nota", noNota)
            cryRpt.PrintOptions.PrinterName = mainprinter
            cryRpt.PrintToPrinter(1, False, 0, 0)

            cryRpt.Close()
            cryRpt.Dispose()
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
#End Region
#Region "Delete Data"
    Sub delDataPembelian(ByVal nonota As String)
        Try
            Dim spName As String = "del_DataPembelian"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nota", nonota)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub delALLDataPembelian()
        Try
            Dim spName As String = "del_ALLDataPembelian"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub delDataBarcode(ByVal nonota As String)
        Try
            Dim spName As String = "del_DataBarcode"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@nota", nonota)
            con.ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
    Sub delALLDataBarcode()
        Try
            Dim spName As String = "del_ALLDataBarcode"
            con.ubahdatabaseado(spName, Nothing, False)
        Catch ex As Exception
            ext.errHandler(ex)
        End Try
    End Sub
#End Region
End Module
