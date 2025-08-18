Imports System.IO
Imports System.Net.NetworkInformation

Public Class clsExt
    Dim userid As String
    Private Shared ReadOnly _instance As New clsExt()
    Private Sub New()
        ' Private constructor to prevent object instantiation outside of this class
    End Sub
    Public Shared ReadOnly Property Instance As clsExt
        Get
            Return _instance
        End Get
    End Property
#Region "Global Variables"
    Function getUserID() As String
        Return userid
    End Function
    Sub setUserID(ByVal user_id As String)
        userid = user_id
    End Sub
#End Region
#Region "ErrHandler"
    Sub errHandler(ByVal ex As Exception)
        Dim rslt As String = GetExceptionInfo(ex)
        WriteToErrorLog(ex.Message, rslt & vbCrLf & ex.StackTrace, "Error")
    End Sub
    Public Function GetExceptionInfo(ex As Exception) As String
        Dim Result As String
        Dim hr As Integer = Runtime.InteropServices.Marshal.GetHRForException(ex)
        Result = ex.GetType.ToString & "(0x" & hr.ToString("X8") & "): " & ex.Message & Environment.NewLine & ex.StackTrace & Environment.NewLine
        Dim st As StackTrace = New StackTrace(ex, True)
        For Each sf As StackFrame In st.GetFrames
            If sf.GetFileLineNumber() > 0 Then
                Result &= "Line:" & sf.GetFileLineNumber() & " Filename: " & IO.Path.GetFileName(sf.GetFileName) & Environment.NewLine
            End If
        Next
        Return Result
    End Function
    Public Sub WriteToErrorLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)
        If Not System.IO.Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Errors\") Then
            System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory & "\Errors\")
        End If

        Dim filePath As String = System.AppDomain.CurrentDomain.BaseDirectory & "\Errors\errorLog-" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

        Dim content As String = ""

        If File.Exists(filePath) Then
            Using sr As StreamReader = File.OpenText(filePath)
                content = sr.ReadToEnd()
            End Using
        End If

        Using sw As StreamWriter = New StreamWriter(filePath)
            sw.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
            sw.Write("Message: " & msg & vbCrLf)
            sw.Write("StackTrace: " & stkTrace & vbCrLf)
            sw.Write("===================================Macarons=Error=Logger===========================================" & vbCrLf & vbCrLf)
            sw.Write(content)
        End Using
        MsgBox(msg, vbCritical, "Macarons")
    End Sub
#End Region
#Region "ID Generator"
    Function getidenkripsi() As String
        Dim enkrip As New clsEncrypt
        getidenkripsi = enkrip.getSHA1Hash(enkrip.md5(getMacAddress() & Now))
    End Function
    Function getidenkripsiplus(ByVal plus As String) As String
        Dim enkrip As New clsEncrypt
        getidenkripsiplus = enkrip.getSHA1Hash(enkrip.md5(getMacAddress() & Now & plus & CInt(Math.Ceiling(Rnd() * 99)) + 1))
    End Function
#End Region
#Region "Etc"
    Function getMacAddress()
        Dim nics() As NetworkInterface =
              NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function
    Function strClear(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[^a-zA-Z0-9]", " ")
    End Function

#End Region
End Class
