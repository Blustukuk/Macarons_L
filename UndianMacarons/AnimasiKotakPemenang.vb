Public Class AnimasiKotakPemenang
    Inherits Label

    Private WithEvents animTimer As New Timer()
    Private currentSize As Integer
    Private maxSize As Integer

    Public Sub New(textIsi As String, Optional isPemenang As Boolean = False)
        Me.Text = textIsi
        Me.BackColor = If(isPemenang, Color.Transparent, Color.Transparent)
        Me.ForeColor = Color.White
        Me.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        Me.TextAlign = ContentAlignment.MiddleCenter
        Me.AutoSize = False
        Me.BorderStyle = BorderStyle.None

        ' Ukuran awal & maksimum tergantung apakah ini kotak pemenang atau bukan
        If isPemenang Then
            currentSize = 200
            maxSize = 800
        Else
            currentSize = 10
            maxSize = 400
        End If

        Me.Width = currentSize
        Me.Height = currentSize

        animTimer.Interval = 20
        animTimer.Start()
    End Sub
    Private Sub animTimer_Tick(sender As Object, e As EventArgs) Handles animTimer.Tick
        currentSize += 20

        If currentSize >= maxSize Then
            currentSize = maxSize
            animTimer.Stop() ' stop animasi setelah zoom in selesai
        End If

        Me.Width = currentSize
        Me.Height = currentSize
        Me.Font = New Font("Segoe UI", CSng(Math.Max(8, currentSize / 10)), FontStyle.Bold)
    End Sub
End Class
