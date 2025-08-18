Option Explicit On
Public Class frmMain
    Dim dtPeserta As DataTable
    Dim pemenangTerpilih As DataRow
    Dim idPemenangSebelumnya As New List(Of String)
    Dim animasiList As New List(Of AnimasiText)
    Dim fireworkList As New List(Of FireworkParticle)
    Dim WithEvents animasiTimer As New Timer()
    Private rndWarna As New Random()
    Private warnaList As Brush() = {
        Brushes.Yellow, Brushes.Cyan, Brushes.Lime, Brushes.Orange,
        Brushes.Pink, Brushes.LightGreen, Brushes.LightBlue, Brushes.Magenta
    }
    Private lastPickedNumber As Integer = 0
    Private bolehMulaiUndian As Boolean = True
    Private btnLanjut As Button

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnLanjut = New Button()
        btnLanjut.Text = "LANJUTKAN UNDIAN"
        btnLanjut.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        btnLanjut.Size = New Size(300, 60)
        btnLanjut.Visible = False
        btnLanjut.BackColor = Color.Gold
        btnLanjut.ForeColor = Color.Black
        btnLanjut.Location = New Point((Me.ClientSize.Width - btnLanjut.Width) \ 2, Me.ClientSize.Height - 100)
        AddHandler btnLanjut.Click, AddressOf btnLanjut_Click
        Me.Controls.Add(btnLanjut)

        Me.KeyPreview = True
        animasiTimer.Interval = 10
        animasiTimer.Start()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
    End Sub

    Private Sub ResetUndian()
        animasiList.Clear()
        fireworkList.Clear()
        pemenangTerpilih = Nothing
        btnLanjut.Visible = False
        bolehMulaiUndian = True
        lblInfo.Visible = True
        Me.Invalidate()
    End Sub
    Private Sub MulaiUndian()
        animasiList.Clear()
        fireworkList.Clear()
        lblInfo.Visible = False
        If dtPeserta Is Nothing Then
            dtPeserta = Undian_Get_DataPeserta()
        End If

        If dtPeserta Is Nothing OrElse dtPeserta.Rows.Count = 0 Then
            MessageBox.Show("Data peserta kosong.")
            Exit Sub
        End If
        My.Computer.Audio.Play(My.Resources.Undi, AudioPlayMode.Background)

        timerUndian.Start()
    End Sub
    Private Sub BerhentiUndian()
        My.Computer.Audio.Stop()
        timerUndian.Stop()
        bolehMulaiUndian = False

        If pemenangTerpilih IsNot Nothing Then
            Dim idMenang As String = pemenangTerpilih("no_member").ToString()
            Dim namaMenang As String = pemenangTerpilih("nama")
            If Not idPemenangSebelumnya.Contains(idMenang) Then
                idPemenangSebelumnya.Add(idMenang)
                SimpanPemenangKeDatabase(idMenang)
            End If

            Dim textIsi = "🎉 PEMENANG 🎉" & vbCrLf & "No Member: " & idMenang & vbCrLf & "Nama: " & namaMenang & vbCrLf & "Poin: " & pemenangTerpilih("total_poin") & vbCrLf & "Angka Acak: " & lastPickedNumber
            Dim posisiTengah As New Point(Me.ClientSize.Width \ 2, Me.ClientSize.Height \ 2)
            animasiList.Add(New AnimasiText With {
            .Text = textIsi,
            .Position = posisiTengah,
            .FontSize = 40,
            .MaxSize = 100,
            .Growing = False,
            .IsFinal = True,
            .IsPemenang = True,
            .Warna = Brushes.White
        })

            For j = 1 To 10
                Dim x = rndWarna.Next(100, Me.ClientSize.Width - 100)
                Dim y = rndWarna.Next(100, Me.ClientSize.Height - 100)
                Dim posisiAcak As New Point(x, y)
                For i = 1 To 30
                    fireworkList.Add(New FireworkParticle(posisiAcak, rndWarna))
                Next
            Next

            btnLanjut.Visible = True

            My.Computer.Audio.Play(My.Resources.fanfare, AudioPlayMode.Background)
        End If
    End Sub

    Private Sub btnLanjut_Click(sender As Object, e As EventArgs)
        ResetUndian()
        Me.ActiveControl = Nothing
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter AndAlso bolehMulaiUndian Then
            If Not timerUndian.Enabled Then
                MulaiUndian()
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub frmMain_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter AndAlso bolehMulaiUndian Then
            If timerUndian.Enabled Then
                timerUndian.Stop()
                BerhentiUndian()
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub timerUndian_Tick(sender As Object, e As EventArgs) Handles timerUndian.Tick

        For i As Integer = 1 To 5
            Dim calonPemenang As DataRow = UndiPemenangTanpaDuplikat(dtPeserta, idPemenangSebelumnya)

            If calonPemenang IsNot Nothing Then
                pemenangTerpilih = calonPemenang
                Dim textIsi = lastPickedNumber


                Dim posX = rndWarna.Next(100, Me.ClientSize.Width - 100)
                Dim posY = rndWarna.Next(100, Me.ClientSize.Height - 100)

                animasiList.Add(New AnimasiText With {
                .Text = textIsi,
                .Position = New Point(posX, posY),
                .FontSize = 20,
                .Warna = warnaList(rndWarna.Next(warnaList.Length))
            })
            End If
        Next
    End Sub

    Private Sub animasiTimer_Tick(sender As Object, e As EventArgs) Handles animasiTimer.Tick

        For Each anim In animasiList
            If anim.Growing AndAlso Not anim.IsFinal Then
                anim.FontSize += 5
                If anim.FontSize >= anim.MaxSize Then anim.Growing = False
            End If
        Next

        For Each fw In fireworkList
            fw.Update()
        Next

        fireworkList.RemoveAll(Function(fw) fw.LifeTime <= 0)

        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        For Each anim In animasiList
            Using fnt As New Font("Segoe UI", anim.FontSize, FontStyle.Bold)
                Dim format As New StringFormat() With {
                    .Alignment = StringAlignment.Center,
                    .LineAlignment = StringAlignment.Center
                }
                If anim.IsPemenang Then
                    Dim ukuranText As SizeF = e.Graphics.MeasureString(anim.Text, fnt)
                    Dim rect As New RectangleF(
                        anim.Position.X - ukuranText.Width / 2,
                        anim.Position.Y - ukuranText.Height / 2,
                        ukuranText.Width,
                        ukuranText.Height
                    )
                    e.Graphics.FillRectangle(Brushes.Black, rect)
                    e.Graphics.DrawString(anim.Text, fnt, anim.Warna, anim.Position, format)
                Else
                    e.Graphics.DrawString(anim.Text, fnt, anim.Warna, anim.Position, format)
                End If
            End Using
        Next

        For Each fw In fireworkList
            Using b As New SolidBrush(fw.Warna)
                e.Graphics.FillEllipse(b, fw.Position.X, fw.Position.Y, 5, 5)
            End Using
        Next
    End Sub

    Private Function UndiPemenangTanpaDuplikat(dt As DataTable, sudahMenang As List(Of String)) As DataRow
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing
        If sudahMenang Is Nothing Then sudahMenang = New List(Of String)

        Dim kandidatRows = dt.AsEnumerable().
        Where(Function(r) Not IsDBNull(r("no_member")) AndAlso Not sudahMenang.Contains(r("no_member").ToString())).
        ToList()

        If kandidatRows.Count = 0 Then Return Nothing

        Dim totalPoin = kandidatRows.Sum(Function(r) If(IsDBNull(r("total_poin")), 0, Convert.ToInt32(r("total_poin"))))
        If totalPoin = 0 Then Return Nothing

        Dim rand As New Random()
        lastPickedNumber = rand.Next(1, totalPoin + 1)


        Dim cumulative As Integer = 0
        For Each row As DataRow In kandidatRows
            cumulative += Convert.ToInt32(row("total_poin"))
            If lastPickedNumber <= cumulative Then
                Return row
            End If
        Next

        Return Nothing
    End Function
End Class

Public Class AnimasiText
    Public Property Text As String
    Public Property Position As Point
    Public Property FontSize As Single
    Public Property MaxSize As Single = 30
    Public Property Growing As Boolean = True
    Public Property IsFinal As Boolean = False
    Public Property IsPemenang As Boolean = False
    Public Property Warna As Brush = Brushes.White
End Class

Public Class FireworkParticle
    Public Property Position As PointF
    Public Property Velocity As PointF
    Public Property LifeTime As Integer
    Public Property Warna As Color

    Public Sub New(center As Point, rnd As Random)
        Dim angle = rnd.NextDouble() * 2 * Math.PI
        Dim speed = rnd.Next(2, 6)
        Me.Velocity = New PointF(Math.Cos(angle) * speed, Math.Sin(angle) * speed)
        Me.Position = New PointF(center.X, center.Y)
        Me.LifeTime = 30 + rnd.Next(30)
        Me.Warna = Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256))
    End Sub

    Public Sub Update()
        Position = New PointF(Position.X + Velocity.X, Position.Y + Velocity.Y)
        LifeTime -= 1
    End Sub

End Class
