Public Class clsping
    Public Function Ping321(strHost)
        Dim oPing, oRetStatus, bReturn
        oPing = GetObject("winmgmts:{impersonationLevel=impersonate}").ExecQuery("select * from Win32_PingStatus where address='" & strHost & "'")

        For Each oRetStatus In oPing
            If IsDBNull(oRetStatus.StatusCode) Or oRetStatus.StatusCode <> 0 Then
                bReturn = 0

                ' WScript.Echo "Status code is " & oRetStatus.StatusCode
            Else
                bReturn = oRetStatus.ResponseTime

                'Wscript.Echo("Bytes = " & vbTab & oRetStatus.BufferSize)
                'Wscript.Echo("Time (ms) = " & vbTab & oRetStatus.ResponseTime)
                'Wscript.Echo("TTL (s) = " & vbTab & oRetStatus.ResponseTimeToLive)
            End If
            oRetStatus = Nothing
        Next
        oPing = Nothing

        Ping321 = bReturn
    End Function
End Class
