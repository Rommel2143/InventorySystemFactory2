Imports ClosedXML.Excel
Imports System.IO

Module exportExcel

    'Public Sub exporttoExcel(datagrid As Object) 'Guna.UI2.WinForms.Guna2DataGridView
    '    Try
    '        If datagrid.Rows.Count = 0 Then
    '            MessageBox.Show("No data available to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return
    '        End If

    '        Dim dt As New DataTable()

    '        ' Adding the Columns
    '        For Each column As DataGridViewColumn In datagrid.Columns
    '            Dim colType As Type = If(column.ValueType IsNot Nothing, column.ValueType, GetType(String))
    '            dt.Columns.Add(column.HeaderText, colType)
    '        Next

    '        ' Adding the Rows
    '        For Each row As DataGridViewRow In datagrid.Rows
    '            If Not row.IsNewRow Then
    '                Dim newRow As DataRow = dt.NewRow()
    '                For Each cell As DataGridViewCell In row.Cells
    '                    newRow(cell.ColumnIndex) = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
    '                Next
    '                dt.Rows.Add(newRow)
    '            End If
    '        Next

    '        ' Save the data to an Excel file
    '        Using sfd As New SaveFileDialog()
    '            sfd.Filter = "Excel Workbook|*.xlsx"
    '            sfd.Title = "Save an Excel File"
    '            sfd.FileName = "" ' Default file name

    '            If sfd.ShowDialog() = DialogResult.OK AndAlso sfd.FileName <> "" Then
    '                ' Check if file already exists
    '                If File.Exists(sfd.FileName) Then
    '                    Dim result As DialogResult = MessageBox.Show("The file already exists. Do you want to overwrite it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    If result <> DialogResult.Yes Then
    '                        Return
    '                    End If
    '                End If

    '                Using wb As New XLWorkbook()
    '                    wb.Worksheets.Add(dt, "Sheet1")
    '                    wb.SaveAs(sfd.FileName)
    '                End Using

    '                MessageBox.Show("Data successfully exported to Excel.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        ' Log the exception (optional)
    '        ' File.AppendAllText("error_log.txt", $"{DateTime.Now}: {ex.Message}{Environment.NewLine}")
    '    End Try
    'End Sub

    Public Sub exporttoExcel(datagrid As Object, title As String) 'Guna.UI2.WinForms.Guna2DataGridView
        Try
            If datagrid.Rows.Count = 0 Then
                MessageBox.Show("No data available to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dt As New DataTable()

            ' Add Columns
            For Each column As DataGridViewColumn In datagrid.Columns
                Dim colType As Type = If(column.ValueType IsNot Nothing, column.ValueType, GetType(String))
                dt.Columns.Add(column.HeaderText, colType)
            Next

            ' Add Rows
            For Each row As DataGridViewRow In datagrid.Rows
                If Not row.IsNewRow Then
                    Dim newRow As DataRow = dt.NewRow()
                    For Each cell As DataGridViewCell In row.Cells
                        newRow(cell.ColumnIndex) = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                    Next
                    dt.Rows.Add(newRow)
                End If
            Next

            Using sfd As New SaveFileDialog()
                sfd.Filter = "Excel Workbook|*.xlsx"
                sfd.Title = "Save an Excel File"
                sfd.FileName = title & "- " & DateTime.Now.ToString("MMMM dd, yyyy")

                If sfd.ShowDialog() = DialogResult.OK AndAlso sfd.FileName <> "" Then
                    If File.Exists(sfd.FileName) Then
                        Dim result As DialogResult = MessageBox.Show("The file already exists. Do you want to overwrite it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If result <> DialogResult.Yes Then Return
                    End If

                    Using wb As New XLWorkbook()
                        Dim ws = wb.Worksheets.Add("Sheet1")

                        ' Insert Title at the top (e.g., cell A1)

                        ws.Cell("A1").Value = title & "- " & DateTime.Now.ToString("MMMM dd, yyyy")
                        ws.Range("A1:" & Chr(64 + dt.Columns.Count) & "1").Merge()
                        ws.Range("A1").Style.Font.Bold = True
                        ws.Range("A1").Style.Font.FontSize = 14
                        ws.Range("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                        ' Load the datatable starting from row 3 (to leave a gap after the title)
                        ws.Cell(3, 1).InsertTable(dt)

                        wb.SaveAs(sfd.FileName)
                    End Using

                    MessageBox.Show("Data successfully exported to Excel.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Module