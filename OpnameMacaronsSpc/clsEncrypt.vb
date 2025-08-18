Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Public Class clsencrypt
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

    Public Function md5(teks) As String
        Dim hp As New Security.Cryptography.MD5CryptoServiceProvider
        Dim stringBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(teks)
        Dim resultBytes() As Byte = hp.ComputeHash(stringBytes)
        Dim resultHash As String = (From x As Byte In resultBytes Select x.ToString("X2")).Aggregate(Function(x, y) x & y)

        md5 = resultHash
    End Function

    Public Function Encrypt(ByVal plainText As String) As String
        Dim passPhrase As String = "EaSySHOpProvERSideSktOP"
        Dim saltValue As String = "EasyShopProVersiDesktop"
        Dim hashAlgorithm As String = "SHA1"
        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1{2<3D!e5?6g:H8"
        Dim keySize As Integer = 256
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
        Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
        Dim symmetricKey As New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
        Dim memoryStream As New MemoryStream()
        Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()
        Dim cipherTextBytes As Byte() = memoryStream.ToArray()
        memoryStream.Close()
        cryptoStream.Close()
        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
        Return cipherText
    End Function


    Public Function Decrypt(ByVal cipherText As String) As String
        Dim passPhrase As String = "EaSySHOpProvERSideSktOP"
        Dim saltValue As String = "EasyShopProVersiDesktop"
        Dim hashAlgorithm As String = "SHA1"
        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1{2<3D!e5?6g:H8"
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
    End Function

    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
        End Try
        Return encrypted
    End Function

    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
        End Try
    End Function


End Class
