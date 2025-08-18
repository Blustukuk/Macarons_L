Imports Microsoft.Office.Interop.Excel
Public Class frmCariCepatPenjualan
    Private Sub frmCariCepatPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtKeyword.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        dgvTemp.DataSource = Nothing
        dgvTemp.Columns.Clear()
        Dim dt As System.Data.DataTable = loadDataPenjualanByNama(txtKeyword.Text, dtp1.Value, dtp2.Value)
        If dt.Rows.Count > 0 Then
            With dgvTemp
                .DataSource = dt
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                '.Columns(1).Visible = False
            End With
        Else
            MsgBox("Data pencarian tidak ditemukan.", vbCritical, "Macarons")
        End If
        txtKeyword.Focus()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim keyword As String = txtKeyword.Text
        Dim bdate As String = CDate(dtp1.Value).ToString("yyyyMMdd")
        Dim edate As String = CDate(dtp2.Value).ToString("yyyyMMdd")
        Dim dt As System.Data.DataTable = loadDataPenjualanByNama(txtKeyword.Text, dtp1.Value, dtp2.Value)
        If dt.Rows.Count > 0 Then
            Dim exportPath As String = "D:\JUAL_" & keyword & "_" & bdate & "_" & edate & ".xlsx"
            ExportDataTableToExcel(dt, exportPath)
        Else
            MsgBox("Data export tidak ditemukan.", vbCritical, "Macarons")
        End If

    End Sub
    Public Sub ExportDataTableToExcel(ByVal dt As System.Data.DataTable, ByVal excelFilePath As String)
        Dim excelApp As New Application
        Dim excelWorkbook As Workbook = excelApp.Workbooks.Add
        Dim excelWorksheet As Worksheet = CType(excelWorkbook.Sheets(1), Worksheet)

        Try
            ' Menulis header kolom
            For col As Integer = 1 To dt.Columns.Count
                excelWorksheet.Cells(1, col) = dt.Columns(col - 1).ColumnName
            Next

            ' Menulis baris data
            For row As Integer = 0 To dt.Rows.Count - 1
                For col As Integer = 0 To dt.Columns.Count - 1
                    excelWorksheet.Cells(row + 2, col + 1) = dt.Rows(row)(col).ToString()
                Next
            Next

            ' Simpan file Excel
            excelWorkbook.SaveAs(excelFilePath)
            excelWorkbook.Close()
            excelApp.Quit()

            MessageBox.Show("Data berhasil diekspor ke Excel di path :" & vbCrLf & excelFilePath & ".", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Membersihkan objek COM
            ReleaseObject(excelWorksheet)
            ReleaseObject(excelWorkbook)
            ReleaseObject(excelApp)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class