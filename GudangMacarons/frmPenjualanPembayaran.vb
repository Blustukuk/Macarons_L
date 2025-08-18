Public Class frmPenjualanPembayaran
    Public total As String
    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnbatal_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
        frmPenjualan.txtkodeitem.Focus()
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked = True Then
            Me.GroupBox2.Enabled = True
            Me.cmbbank.Focus()
        Else
            Me.GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            Me.GroupBox1.Enabled = True
            Me.txtbayar.Focus()
        Else
            Me.GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub txtbayar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtbayar.TextChanged
        If Me.txtbayar.TextLength > 0 And IsNumeric(Me.txtbayar.Text) Then
            txtbayar.Text = FormatNumber(txtbayar.Text, 0, TriState.False, , TriState.True)
            txtbayar.Select(txtbayar.Text.Length, 0)
        End If
        If Me.txtbayar.Text <> "" And IsNumeric(Me.txtbayar.Text) = True Then
            hitungKembalian
        End If
    End Sub

    Private Sub hitungKembalian()
        lblkurang.Text = CInt(txtbayar.Text) - (lbltotal.Text)
    End Sub
    Private Sub frmbayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        total = Me.lbltotal.Text
        txtbayar.Focus()
        AcceptButton = btnProses
        Dim dt As DataTable = getNamaBank
        If dt.Rows.Count > 0 Then
            With cmbbank
                .DataSource = dt
                .DisplayMember = "nama_bank"
                .ValueMember = "nama_bank"
                .SelectedIndex = 0
            End With
        Else
            MsgBox("Daftar Bank tidak ditemukan", vbOKOnly, "Macarons")
        End If
    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F2 Then
            btnok_Click(o, e)
        End If
    End Sub
    Private Sub btnbayar_Click(sender As Object, e As EventArgs) Handles btn100000.Click, btn50000.Click, btn20000.Click, btn10000.Click, btn5000.Click, btn2000.Click, btn1000.Click, btn500.Click, btn200.Click
        If Me.txtbayar.Text <> "" And IsNumeric(Me.txtbayar.Text) = True Then
            Me.txtbayar.Text = CInt(Me.txtbayar.Text) + CInt(Mid(DirectCast(sender, Button).Name, 4, 6))
        Else
            Me.txtbayar.Text = CInt(Mid(DirectCast(sender, Button).Name, 4, 6))
        End If
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Dim proses As Boolean = prosesPenjualan(frmPenjualan.txtnote.Text, If(txtdiskonrupiah.Text = "", "0", txtdiskonrupiah.Text),
                                                If(txtdiskonpersen.Text = "", "0", txtdiskonpersen.Text), cmbbank.Text, txtnoedc.Text, getnumber(txtbayar.Text), frmMain.lblUserID.Text)
        If proses Then
            frmPenjualan.lblProses.Text = "0"
            lbltotal.Text = "0"
            frmPenjualan.lblTotalRp.Text = "0"
            frmPenjualanLoad()
            frmPenjualan.cbx7an.SelectedIndex = 0
            frmPenjualan.txtkodeitem.Text = ""
            frmPenjualan.txtnote.Text = ""
            dellallpenjualantemp()
            frmPenjualan.lblProses.Text = "1"
            Dispose()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbdiskon.CheckedChanged
        If Me.cbdiskon.Checked = True Then
            gbdiskon.Enabled = True
        Else
            gbdiskon.Enabled = False
            Me.lbltotal.Text = total
            Me.lbltotal2.Text = total
        End If
    End Sub

    Private Sub txtdiskonpersen_TextChanged(sender As Object, e As EventArgs) Handles txtdiskonpersen.TextChanged, txtdiskonrupiah.TextChanged
        Dim diskonpersen As Integer
        Dim diskonrupiah As Integer
        If (Me.txtdiskonpersen.Text <> "" And IsNumeric(Me.txtdiskonpersen.Text)) Or (Me.txtdiskonrupiah.Text <> "" And IsNumeric(Me.txtdiskonrupiah.Text)) Then
            If Me.txtdiskonpersen.Text = "" Then
                diskonpersen = 0
            Else
                diskonpersen = (total * CInt(Me.txtdiskonpersen.Text) / 100)
            End If
            If Me.txtdiskonrupiah.Text = "" Then
                diskonrupiah = 0
            Else
                diskonrupiah = CInt(Me.txtdiskonrupiah.Text)
            End If
            Me.lbltotal.Text = CStr(CInt(total) - diskonpersen - diskonrupiah)
            Me.lbltotal2.Text = CStr(CInt(total) - diskonpersen - diskonrupiah)
        Else
            Me.lbltotal.Text = total
            Me.lbltotal2.Text = total
        End If
        hitungKembalian()
    End Sub

    Private Sub frmbayar_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtbayar.Focus()
        AcceptButton = btnProses
    End Sub
End Class