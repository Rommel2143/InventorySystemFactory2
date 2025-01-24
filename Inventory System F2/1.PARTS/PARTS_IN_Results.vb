Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class Parts_IN_Results
    Dim itempartcode As String

    Private Sub scan_results_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpicker.Value = Date.Now.ToString("yyyy-MM-dd")
    End Sub




    Private Sub cmbbatchout_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub datagrid1_CellContextMenuStripChanged(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellContextMenuStripChanged

    End Sub

    Private Sub datagrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellClick
        Try
            With datagrid1
                itempartcode = .SelectedCells(0).Value.ToString()
            End With

            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT ts.`qrcode`,ts.`partcode`,ts.`lotnumber`, ts.`remarks`, ts.`qty`
                                                    FROM `f2_parts_scan` ts
                                                    LEFT JOIN f2_scanoperator_is so ON ts.userin = so.IDno
                                                    WHERE       `datein`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' 
                                                    and `partcode`='" & itempartcode & "'
                                                            
                                                            and `Fullname`='" & cmbuser.Text & "'  
                                                            and `batch`='" & cmbbatchin.Text & "' ", con)

            Dim da As New MySqlDataAdapter(cmdrefreshgrid)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid2.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbbatchout_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbbatchin.SelectedIndexChanged
        Try


            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT ts.`qrcode`,ts.`partcode`,ts.`lotnumber`, ts.`remarks`, ts.`qty`
                                                    FROM `f2_parts_scan` ts
                                                    LEFT JOIN f2_scanoperator_is so ON ts.userin = so.IDno
                                                    WHERE       `datein`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' 
                                                           
                                                            and `Fullname`='" & cmbuser.Text & "'  
                                                            and `batch`='" & cmbbatchin.Text & "' ", con)

            Dim da As New MySqlDataAdapter(cmdrefreshgrid)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid2.DataSource = dt


            con.Close()
            con.Open()
            Dim cmdrefreshgrid2 As New MySqlCommand("SELECT ts.`partcode` AS Partcode, SUM(`qty`) AS TOTAL 
                                                  FROM `f2_parts_scan` ts
                                                    LEFT JOIN f2_scanoperator_is so ON ts.userin = so.IDno
                                                    WHERE       `datein`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' 
                                                           
                                                            and `Fullname`='" & cmbuser.Text & "'  
                                                            and `batch`='" & cmbbatchin.Text & "'          
                                                  GROUP BY partcode", con)

            Dim da2 As New MySqlDataAdapter(cmdrefreshgrid2)
            Dim dt2 As New DataTable
            da2.Fill(dt2)
            datagrid1.DataSource = dt2
            datagrid1.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub dtpicker_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpicker.ValueChanged
        Try
            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("Select distinct `fullname` FROM `f2_parts_scan`
                                                INNER JOIN `f2_scanoperator_is` ON `userin` = `IDno`
                                                WHERE `datein`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "'", con)
            dr = cmdselect.ExecuteReader
            cmbuser.Items.Clear()
            While (dr.Read())
                cmbuser.Items.Add(dr.GetString("fullname"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbuser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbuser.SelectedIndexChanged
        Try
            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("Select distinct ts.`batch` FROM `f2_parts_scan` ts
                                              Left Join f2_scanoperator_is tsoout ON ts.userin = tsoout.IDno
                                               
                                                WHERE `datein`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' and `fullname`='" & cmbuser.Text & "'", con)
            dr = cmdselect.ExecuteReader
            cmbbatchin.Items.Clear()
            While (dr.Read())
                cmbbatchin.Items.Add(dr.GetString("batch"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub datagrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellContentClick

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        savetoPDF(datagrid2, "Recieved Delivery Report")
    End Sub
    Private Sub savetoPDF(datagrid As Guna.UI2.WinForms.Guna2DataGridView, title As String)
        Try
            ' Get the selected date from dtpicker1
            Dim selectedDate As String = dtpicker.Value.ToString("MMMMdd-yyyy")

            ' Prompt the user for the save location with the date in the file name
            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
                saveDialog.FileName = "" & title & "_" & selectedDate & ".pdf"

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    ' Export DataGridView to PDF using iTextSharp with landscape orientation
                    Dim pdfDoc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
                    Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(saveDialog.FileName, FileMode.Create))
                    pdfDoc.Open()

                    ' Adding title with Helvetica font
                    Dim titleFont As Font = FontFactory.GetFont("Helvetica", CSng(16), CType(Font.Bold, Integer))
                    pdfDoc.Add(New Paragraph(title, titleFont) With {.Alignment = Element.ALIGN_CENTER})

                    ' Add selected date from dtpicker1
                    Dim dateFont As Font = FontFactory.GetFont("Helvetica", CSng(12), CType(Font.Bold, Integer))
                    pdfDoc.Add(New Paragraph("Date: " & dtpicker.Value.ToString("MMMM-dd-yyyy"), dateFont) With {.Alignment = Element.ALIGN_CENTER})
                    pdfDoc.Add(New Paragraph(Environment.NewLine)) ' Add a space after the title and date

                    ' Add batch information
                    Dim batchFont As Font = FontFactory.GetFont("Helvetica", CSng(12), CType(Font.Bold, Integer))
                    pdfDoc.Add(New Paragraph("Batch: " & cmbbatchin.Text, batchFont) With {.Alignment = Element.ALIGN_CENTER})
                    pdfDoc.Add(New Paragraph(Environment.NewLine)) ' Add a space after the title and date

                    ' Create PDF table
                    Dim pdfTable As New PdfPTable(datagrid.ColumnCount) With {
                        .WidthPercentage = 100,
                        .SpacingBefore = 10,
                        .SpacingAfter = 10
                    }

                    ' Add table headers
                    For Each column As DataGridViewColumn In datagrid.Columns
                        Dim headerFont As Font = FontFactory.GetFont("Helvetica", CSng(12), CType(Font.Bold, Integer))
                        Dim headerCell As New PdfPCell(New Phrase(column.HeaderText, headerFont)) With {
                            .HorizontalAlignment = Element.ALIGN_CENTER,
                            .FixedHeight = Utilities.MillimetersToPoints(10) ' Set header row height to 10mm
                        }
                        pdfTable.AddCell(headerCell)
                    Next

                    ' Add table data
                    Dim rowFont As Font = FontFactory.GetFont("Helvetica", CSng(9)) ' Set row font size to 9
                    For Each row As DataGridViewRow In datagrid.Rows
                        If Not row.IsNewRow Then
                            For Each cell As DataGridViewCell In row.Cells
                                Dim cellValue As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                                Dim pdfCell As New PdfPCell(New Phrase(cellValue, rowFont)) With {
                                    .FixedHeight = Utilities.MillimetersToPoints(8) ' Set data row height to 10mm
                                }
                                pdfTable.AddCell(pdfCell)
                            Next
                        End If
                    Next

                    ' Add table to document
                    pdfDoc.Add(pdfTable)
                    pdfDoc.Close()
                    writer.Close()

                    MessageBox.Show("Exported to PDF successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while exporting: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        delivery_report.viewdata(dtpicker.Value.ToString("yyyy-MM-dd"), cmbuser.Text, cmbbatchin.Text)
        delivery_report.Show()
        delivery_report.BringToFront()
    End Sub
End Class