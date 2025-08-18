Imports MySqlConnector
Imports System.Configuration
Imports Ext
Public Class clsConn
    Dim enkrip As New clsEncrypt
    Dim ext As clsExt = clsExt.Instance
    Private Shared ReadOnly _instance As New clsConn()
    Private Sub New()
        ' Private constructor to prevent object instantiation outside of this class
    End Sub
    Public Shared ReadOnly Property Instance As clsConn
        Get
            Return _instance
        End Get
    End Property
#Region "Ping"
    Public Function Ping321(ByVal strHost As String) As Integer
        Dim pingObj As Object = GetObject("winmgmts:{impersonationLevel=impersonate}").ExecQuery("select * from Win32_PingStatus where address='" & strHost & "'")
        Dim pingStatus As Object
        Dim responseTime As Integer = 0

        For Each pingStatus In pingObj
            If Not IsDBNull(pingStatus.StatusCode) AndAlso pingStatus.StatusCode = 0 Then
                responseTime = pingStatus.ResponseTime
            End If
        Next

        pingObj = Nothing
        pingStatus = Nothing

        Return responseTime
    End Function
    Function pingserver(ByVal ipserver As String)
        pingserver = Ping321(ipserver)
    End Function
#End Region
#Region "ADODB"
    Public Function GetDataSource() As String
        Dim user As String = ConfigurationManager.AppSettings("1")
        Dim pass As String = ConfigurationManager.AppSettings("2")
        Dim sourceData As String = ConfigurationManager.AppSettings("DB:SourceData")

        If String.IsNullOrEmpty(sourceData) Then
            Return ""
        Else
            Return sourceData & "User ID=" & enkrip.Decrypt2("WorthIt", "Blukutuk", "SHA1", "4weQ14reQ15wxQ1G", user) & ";" &
                    "Password=" & enkrip.Decrypt2("NotABadThing", "gerrydesnat", "MD5", "323qA323qA323qA1", pass) & ";"
        End If
    End Function
    Dim user As String = ConfigurationManager.AppSettings("1")
    Dim pass As String = ConfigurationManager.AppSettings("2")
    Dim datasrc As String = ConfigurationManager.AppSettings("DB:SourceData") &
                "User ID=" & enkrip.Decrypt2("WorthIt", "Blukutuk", "SHA1", "4weQ14reQ15wxQ1G", user) & ";" &
                "Password=" & enkrip.Decrypt2("NotABadThing", "gerrydesnat", "MD5", "323qA323qA323qA1", pass) & ";"
    Dim user2 As String = ConfigurationManager.AppSettings("3")
    Dim pass2 As String = ConfigurationManager.AppSettings("4")
    Dim datasrc2 As String = ConfigurationManager.AppSettings("DB:SourceData2") &
                "User ID=" & enkrip.Decrypt3("NEWESP", "aRLin", "SHA1", "4weQ14reQ15wxQ1G", user2) & ";" &
                "Password=" & enkrip.Decrypt3("NEWESP", "dESy", "MD5", "323qA323qA323qA1", pass2) & ";"
    Dim user3 As String = ConfigurationManager.AppSettings("5")
    Dim pass3 As String = ConfigurationManager.AppSettings("6")
    Dim datasrc3 As String = ConfigurationManager.AppSettings("DB:SourceData3") &
                "User ID=" & enkrip.Decrypt3("MACARONS", "dElLaNO", "SHA1", "4weQ14reQ25wxQ1G", user3) & ";" &
                "Password=" & enkrip.Decrypt3("MACARONS", "ArAkAtA", "MD5", "323qA323qA323qA8", pass3) & ";"
    Public Function ExecuteTrans(ByVal queries As List(Of String), ByVal sync As Boolean) As Boolean
        Using connection As New MySqlConnection(datasrc)
            connection.Open()
            Dim transaction As MySqlTransaction = connection.BeginTransaction()
            Try
                For Each query As String In queries
                    Using command As New MySqlCommand(query, connection, transaction)
                        command.ExecuteNonQuery()
                    End Using
                    If sync Then
                        isiSync(query, Nothing)
                    End If
                Next
                transaction.Commit()
                Return True

            Catch ex As Exception
                transaction.Rollback()
                Dim allQueries As String = String.Join(Environment.NewLine, queries)
                ext.WriteToErrorLog(ex.Message, allQueries, "Error")
                MsgBox(ex.Message, vbCritical, "Macarons")
                Return False
            End Try
        End Using
    End Function
    Public Function ExecuteScalar(ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As Object
        Try
            Using dbcon As New MySqlConnection(datasrc)
                dbcon.Open()

                Using SQLcmd As New MySqlCommand(queryString, dbcon)
                    If parameters IsNot Nothing Then
                        For Each parameter In parameters
                            SQLcmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                        Next
                    End If

                    Return SQLcmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, queryString, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
            Return Nothing
        End Try
    End Function
    Public Function FillDataTable(ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As DataTable
        Dim dbcon As MySqlConnection = Nothing
        Dim SQLcmd As MySqlCommand
        Dim myDataReader As MySqlDataReader = Nothing
        Try
            dbcon = New MySqlConnection(datasrc)
            SQLcmd = New MySqlCommand(queryString, dbcon)

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
            ext.WriteToErrorLog(ex.Message, queryString, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
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
    Function ubahdatabaseado(ByVal spName As String, ByVal parameters As Dictionary(Of String, Object), ByVal sync As Boolean) As Integer
        Dim dbcon As New MySqlConnection(datasrc)
        Dim cmd As New MySqlCommand(spName, dbcon)
        Try
            cmd.CommandType = CommandType.StoredProcedure

            If parameters IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Object) In parameters
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                Next
            End If

            dbcon.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If sync Then
                isiSync(spName, parameters)
            End If

            Return rowsAffected
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, spName, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
            Return 0
        Finally
            dbcon.Close()
        End Try
    End Function
    Public Function ExecuteTrans2(ByVal queries As List(Of String), ByVal sync As Boolean) As Boolean
        Using connection As New MySqlConnection(datasrc2)
            connection.Open()
            Dim transaction As MySqlTransaction = connection.BeginTransaction()
            Try
                For Each query As String In queries
                    Using command As New MySqlCommand(query, connection, transaction)
                        command.ExecuteNonQuery()
                    End Using
                    If sync Then
                        isiSync2(query, Nothing)
                    End If
                Next
                transaction.Commit()
                Return True

            Catch ex As Exception
                transaction.Rollback()
                Dim allQueries As String = String.Join(Environment.NewLine, queries)
                ext.WriteToErrorLog(ex.Message, allQueries, "Error")
                MsgBox(ex.Message, vbCritical, "Macarons")
                Return False
            End Try
        End Using
    End Function
    Public Function ExecuteScalar2(ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As Object
        Try
            Using dbcon As New MySqlConnection(datasrc2)
                dbcon.Open()

                Using SQLcmd As New MySqlCommand(queryString, dbcon)
                    If parameters IsNot Nothing Then
                        For Each parameter In parameters
                            SQLcmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                        Next
                    End If

                    Return SQLcmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, queryString, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
            Return Nothing
        End Try
    End Function
    Public Function FillDataTable2(ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As DataTable
        Dim dbcon As MySqlConnection = Nothing
        Dim SQLcmd As MySqlCommand
        Dim myDataReader As MySqlDataReader = Nothing
        Try
            dbcon = New MySqlConnection(datasrc2)
            SQLcmd = New MySqlCommand(queryString, dbcon)

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
            ext.WriteToErrorLog(ex.Message, queryString, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
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

    Function ubahdatabaseado2(ByVal spName As String, ByVal parameters As Dictionary(Of String, Object), ByVal sync As Boolean) As Integer
        Dim dbcon As New MySqlConnection(datasrc2)
        Dim cmd As New MySqlCommand(spName, dbcon)
        Try
            cmd.CommandType = CommandType.StoredProcedure

            If parameters IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Object) In parameters
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                Next
            End If

            dbcon.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If sync Then
                isiSync2(spName, parameters)
            End If

            Return rowsAffected
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, spName, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
            Return 0
        Finally
            dbcon.Close()
        End Try
    End Function
    Public Function ExecuteTrans3(ByVal queries As List(Of String), ByVal sync As Boolean) As Boolean
        Using connection As New MySqlConnection(datasrc3)
            connection.Open()
            Dim transaction As MySqlTransaction = connection.BeginTransaction()
            Try
                For Each query As String In queries
                    Using command As New MySqlCommand(query, connection, transaction)
                        command.ExecuteNonQuery()
                    End Using
                    If sync Then
                        isiSync3(query, Nothing)
                    End If
                Next
                transaction.Commit()
                Return True

            Catch ex As Exception
                transaction.Rollback()
                Dim allQueries As String = String.Join(Environment.NewLine, queries)
                ext.WriteToErrorLog(ex.Message, allQueries, "Error")
                MsgBox(ex.Message, vbCritical, "Macarons")
                Return False
            End Try
        End Using
    End Function
    Public Function ExecuteScalar3(ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As Object
        Try
            Using dbcon As New MySqlConnection(datasrc3)
                dbcon.Open()

                Using SQLcmd As New MySqlCommand(queryString, dbcon)
                    If parameters IsNot Nothing Then
                        For Each parameter In parameters
                            SQLcmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                        Next
                    End If

                    Return SQLcmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, queryString, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
            Return Nothing
        End Try
    End Function
    Public Function FillDataTable3(ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As DataTable
        Dim dbcon As MySqlConnection = Nothing
        Dim SQLcmd As MySqlCommand
        Dim myDataReader As MySqlDataReader = Nothing
        Try
            dbcon = New MySqlConnection(datasrc3)
            SQLcmd = New MySqlCommand(queryString, dbcon)

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
            ext.WriteToErrorLog(ex.Message, queryString, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
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
    Function ubahdatabaseado3(ByVal spName As String, ByVal parameters As Dictionary(Of String, Object), ByVal sync As Boolean) As Integer
        Dim dbcon As New MySqlConnection(datasrc3)
        Dim cmd As New MySqlCommand(spName, dbcon)
        Try
            cmd.CommandType = CommandType.StoredProcedure

            If parameters IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Object) In parameters
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                Next
            End If

            dbcon.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If sync Then
                isiSync3(spName, parameters)
            End If

            Return rowsAffected
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, spName, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
            Return 0
        Finally
            dbcon.Close()
        End Try
    End Function

    Public Function ExecuteTrans4(ByVal queries As List(Of String), ByVal sync As Boolean) As Boolean
        Using connection As New MySqlConnection(GetDataSource)
            connection.Open()
            Dim transaction As MySqlTransaction = connection.BeginTransaction()
            Try
                For Each query As String In queries
                    Using command As New MySqlCommand(query, connection, transaction)
                        command.ExecuteNonQuery()
                    End Using
                    If sync Then
                        isiSync4(query, Nothing)
                    End If
                Next
                transaction.Commit()
                Return True

            Catch ex As Exception
                transaction.Rollback()
                Dim allQueries As String = String.Join(Environment.NewLine, queries)
                ext.WriteToErrorLog(ex.Message, allQueries, "Error")
                MsgBox(ex.Message, vbCritical, "Macarons")
                Return False
            End Try
        End Using
    End Function
    Public Function ExecuteScalar4(ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As Object
        Try
            Using dbcon As New MySqlConnection(GetDataSource)
                dbcon.Open()

                Using SQLcmd As New MySqlCommand(queryString, dbcon)
                    If parameters IsNot Nothing Then
                        For Each parameter In parameters
                            SQLcmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                        Next
                    End If

                    Return SQLcmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, queryString, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
            Return Nothing
        End Try
    End Function
    Public Function FillDataTable4(ByVal queryString As String, ByVal parameters As Dictionary(Of String, Object)) As DataTable
        Dim dbcon As MySqlConnection = Nothing
        Dim SQLcmd As MySqlCommand
        Dim myDataReader As MySqlDataReader = Nothing
        Try
            dbcon = New MySqlConnection(GetDataSource)
            SQLcmd = New MySqlCommand(queryString, dbcon)

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
            ext.WriteToErrorLog(ex.Message, queryString, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
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
    Function ubahdatabaseado4(ByVal spName As String, ByVal parameters As Dictionary(Of String, Object), ByVal sync As Boolean) As Integer
        Dim dbcon As New MySqlConnection(GetDataSource)
        Dim cmd As New MySqlCommand(spName, dbcon)
        Try
            cmd.CommandType = CommandType.StoredProcedure

            If parameters IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Object) In parameters
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                Next
            End If

            dbcon.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If sync Then
                isiSync4(spName, parameters)
            End If

            Return rowsAffected
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, spName, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
            Return 0
        Finally
            dbcon.Close()
        End Try
    End Function

#End Region
#Region "Sync"
    Sub isiSync(ByVal strSQL As String, ByVal parametersSQL As Dictionary(Of String, Object))
        Dim id As String = ""
        Try
            Dim combinedSQL As String = If(parametersSQL IsNot Nothing, strSQL, "")

            If parametersSQL IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Object) In parametersSQL
                    combinedSQL &= $"{vbCrLf}{kvp.Key} = '{kvp.Value}'"
                Next
            End If

            id = ext.getidenkripsiplus(strSQL)
            Dim spName As String = "isiSync"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@sync_id", id)
            If combinedSQL = "" Then
                parameters.Add("@strSQL", strSQL)
            Else
                parameters.Add("@strSQL", combinedSQL)
            End If

            Dim rowsAffected As Integer = ubahdatabaseado(spName, parameters, False)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, "Query Log : " & strSQL, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
        End Try
    End Sub
    Sub isiSync2(ByVal strSQL As String, ByVal parametersSQL As Dictionary(Of String, Object))
        Dim id As String = ""
        Try
            Dim combinedSQL As String = If(parametersSQL IsNot Nothing, strSQL, "")

            If parametersSQL IsNot Nothing Then
                ' Gabungkan parametersSQL dengan strSQL
                For Each kvp As KeyValuePair(Of String, Object) In parametersSQL
                    combinedSQL &= $"{vbCrLf}{kvp.Key} = '{kvp.Value}'"
                Next
            End If

            id = ext.getidenkripsiplus(strSQL)
            Dim spName As String = "isiSync"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@sync_id", id)
            If combinedSQL = "" Then
                parameters.Add("@strSQL", strSQL)
            Else
                parameters.Add("@strSQL", combinedSQL)
            End If

            Dim rowsAffected As Integer = ubahdatabaseado2(spName, parameters, False)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, "Query Log : " & strSQL, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
        End Try
    End Sub
    Sub isiSync3(ByVal strSQL As String, ByVal parametersSQL As Dictionary(Of String, Object))
        Dim id As String = ""
        Try
            Dim combinedSQL As String = If(parametersSQL IsNot Nothing, strSQL, "")

            If parametersSQL IsNot Nothing Then
                ' Gabungkan parametersSQL dengan strSQL
                For Each kvp As KeyValuePair(Of String, Object) In parametersSQL
                    combinedSQL &= $"{vbCrLf}{kvp.Key} = '{kvp.Value}'"
                Next
            End If

            id = ext.getidenkripsiplus(strSQL)
            Dim spName As String = "isiSync"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@sync_id", id)
            If combinedSQL = "" Then
                parameters.Add("@strSQL", strSQL)
            Else
                parameters.Add("@strSQL", combinedSQL)
            End If

            Dim rowsAffected As Integer = ubahdatabaseado3(spName, parameters, False)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, "Query Log : " & strSQL, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
        End Try
    End Sub
    Sub isiSync4(ByVal strSQL As String, ByVal parametersSQL As Dictionary(Of String, Object))
        Dim id As String = ""
        Try
            Dim combinedSQL As String = If(parametersSQL IsNot Nothing, strSQL, "")

            If parametersSQL IsNot Nothing Then
                ' Gabungkan parametersSQL dengan strSQL
                For Each kvp As KeyValuePair(Of String, Object) In parametersSQL
                    combinedSQL &= $"{vbCrLf}{kvp.Key} = '{kvp.Value}'"
                Next
            End If

            id = ext.getidenkripsiplus(strSQL)
            Dim spName As String = "isiSync"
            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@sync_id", id)
            If combinedSQL = "" Then
                parameters.Add("@strSQL", strSQL)
            Else
                parameters.Add("@strSQL", combinedSQL)
            End If

            Dim rowsAffected As Integer = ubahdatabaseado4(spName, parameters, False)
        Catch ex As Exception
            ext.WriteToErrorLog(ex.Message, "Query Log : " & strSQL, "Error")
            MsgBox(ex.Message, vbCritical, "Macarons")
        End Try
    End Sub
#End Region
#Region "Logger"
    Sub isiLog(ByVal userid As String, ByVal aktifitas As String)
        Dim idlog As String = ext.getidenkripsi()
        Dim spName As String = "isiLog"
        Dim parameters As New Dictionary(Of String, Object)()
        parameters.Add("@idlog", idlog)
        parameters.Add("@userid", userid)
        parameters.Add("@act", aktifitas)

        Dim rowsAffected As Integer = ubahdatabaseado(spName, parameters, True)
    End Sub
    Sub isiLog2(ByVal userid As String, ByVal aktifitas As String)
        Dim idlog As String = ext.getidenkripsi()
        Dim spName As String = "isiLog"
        Dim parameters As New Dictionary(Of String, Object)()
        parameters.Add("@idlog", idlog)
        parameters.Add("@userid", userid)
        parameters.Add("@act", aktifitas)

        Dim rowsAffected As Integer = ubahdatabaseado2(spName, parameters, True)
    End Sub
    Sub isiLog4(ByVal userid As String, ByVal aktifitas As String)
        Dim idlog As String = ext.getidenkripsi()
        Dim spName As String = "isiLog"
        Dim parameters As New Dictionary(Of String, Object)()
        parameters.Add("@idlog", idlog)
        parameters.Add("@userid", userid)
        parameters.Add("@act", aktifitas)

        Dim rowsAffected As Integer = ubahdatabaseado4(spName, parameters, True)
    End Sub

#End Region
End Class
