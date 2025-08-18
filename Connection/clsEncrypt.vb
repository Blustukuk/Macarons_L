Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Public Class clsEncrypt
    Public Function Decrypt2(ByVal phrase As String, ByVal salt As String, ByVal hash As String, ByVal vector As String, ByVal cipherText As String) As String
        If cipherText <> "" Then
            Dim passPhrase As String = phrase
            Dim saltValue As String = salt
            Dim hashAlgorithm As String = hash
            Dim passwordIterations As Integer = 2
            Dim initVector As String = vector
            Dim keySize As Integer = 256
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
            Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)
            Dim password As New Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations)
            Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
            Dim symmetricKey As New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
            Dim memoryStream As New MemoryStream(cipherTextBytes)
            Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
            cryptoStream.Close()
            memoryStream.Close()
            Return plainText
        End If

        Return ""
    End Function
    Public Function Decrypt3(ByVal phrase As String, ByVal salt As String, ByVal hash As String, ByVal vector As String, ByVal cipherText As String) As String
        If cipherText <> "" Then
            Dim passPhrase As String = phrase
            Dim saltValue As String = salt
            Dim hashAlgorithm As String = hash
            Dim passwordIterations As Integer = 2
            Dim initVector As String = vector
            Dim keySize As Integer = 256
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
            Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)
            Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
            Dim symmetricKey As New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
            Dim memoryStream As New MemoryStream(cipherTextBytes)
            Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
            Return plainText
            memoryStream.Close()
            cryptoStream.Close()
        End If
    End Function
End Class
