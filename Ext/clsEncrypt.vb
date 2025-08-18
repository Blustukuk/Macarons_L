Public Class clsEncrypt
    Public Function md5(teks) As String
        Dim hp As New Security.Cryptography.MD5CryptoServiceProvider
        Dim stringBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(teks)
        Dim resultBytes() As Byte = hp.ComputeHash(stringBytes)
        Dim resultHash As String = (From x As Byte In resultBytes Select x.ToString("X2")).Aggregate(Function(x, y) x & y)

        md5 = resultHash
    End Function
    Public Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function

End Class
