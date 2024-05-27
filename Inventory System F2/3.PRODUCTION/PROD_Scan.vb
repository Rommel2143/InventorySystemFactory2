Imports MySql.Data.MySqlClient
Public Class PROD_Scan
    Dim selectedfg As String
    Dim status As String
    Private Sub PROD_Scan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1
        lbl_shift.Text = shift1

        AddHandler datagrid1.RowEnter, AddressOf datagrid1_RowEnter
        'AddHandler btnsave.Click, AddressOf btnSave_Click
    End Sub

    Private Sub cmbline_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbline.SelectedIndexChanged
        Try
            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("SELECT t.`fgcode`, m.`partname` FROM `f2_fg_traceability` t 
                                                        INNER JOIN `f2_fg_masterlist` m ON t.`fgcode`= m.`partcode`
                                                        WHERE t.`date1`='" & datedb & "' and t.`shift`='" & shift1 & "' and t.`line`='" & cmbline.Text & "'
                                                         GROUP BY m.`partcode`", con)
            dr = cmdselect.ExecuteReader
            cmb_fgcode.Items.Clear()
            While (dr.Read())
                ' Concatenate partcode and partname into a single string
                Dim combinedString As String = dr.GetString("fgcode") & "-" & dr.GetString("partname")
                ' Add the combined string to the ComboBox
                cmb_fgcode.Items.Add(combinedString)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmb_fgcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_fgcode.SelectedIndexChanged
        Try
            If cmb_fgcode.SelectedIndex <> -1 Then
                ' Split the selected item by the hyphen separator
                Dim selectedParts() As String = cmb_fgcode.SelectedItem.ToString().Split("-"c)
                ' Display only the partcode
                If selectedParts.Length > 0 Then
                    selectedfg = (selectedParts(0)) ' Display partcode
                    con.Close()
                    con.Open()
                    Dim cmdselect As New MySqlCommand("SELECT distinct `datacode` FROM `f2_fg_traceability`
                                                        WHERE `date1`='" & datedb & "' and `shift`='" & shift1 & "' and `line`='" & cmbline.Text & "' and `fgcode`='" & selectedfg & "'", con)
                    dr = cmdselect.ExecuteReader
                    cmb_data.Items.Clear()
                    While (dr.Read())
                        cmb_data.Items.Add(dr.GetString("datacode"))
                    End While

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub refreshgrid()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT t.`id`, t.`partcode`,m.`partname`, t.`qtyused`, t.`partqr`,t.`suppliercode` FROM `f2_fg_traceability` t
                                                    INNER JOIN `f2_parts_masterlist` m ON m.`partcode`=t.`partcode`
                                                     WHERE `date1`='" & datedb & "' and `shift`='" & shift1 & "' and `line`='" & cmbline.Text & "' and `fgcode`='" & selectedfg & "' and `datacode`='" & cmb_data.Text & "'
                                                     GROUP BY t.`id`", con)

            Dim da As New MySqlDataAdapter(cmdrefreshgrid)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid1.DataSource = dt
            datagrid1.AutoResizeColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally


            con.Close()
        End Try
    End Sub

    Private Sub cmb_data_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_data.SelectedIndexChanged
        refreshgrid()
    End Sub
    Private Sub SaveChanges()
        Try
            con.Close()
            con.Open()

            For Each row As DataGridViewRow In datagrid1.Rows
                    If row.Tag IsNot Nothing AndAlso row.Tag.ToString() = "Modified" Then
                        ' Prepare the update command with parameters
                        Dim query As String = "UPDATE `f2_fg_traceability` SET `partcode` = @partcode, `qtyused` = @qtyused, `partqr` = @partqr, `suppliercode` = @suppliercode WHERE `id` = @id"
                        Using cmd As New MySqlCommand(query, con)
                            ' Add parameters
                            cmd.Parameters.AddWithValue("@id", row.Cells("id").Value)
                            cmd.Parameters.AddWithValue("@partcode", row.Cells("partcode").Value)
                            cmd.Parameters.AddWithValue("@qtyused", row.Cells("qtyused").Value)
                            cmd.Parameters.AddWithValue("@partqr", row.Cells("partqr").Value)
                            cmd.Parameters.AddWithValue("@suppliercode", row.Cells("suppliercode").Value)

                            ' Execute the command
                            cmd.ExecuteNonQuery()
                        End Using
                        ' Reset the tag
                        row.Tag = Nothing
                    End If
                Next


            MessageBox.Show("Changes saved successfully.")

        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message)
        End Try
    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        SaveChanges()
    End Sub

    Private Sub datagrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellContentClick

    End Sub

    Private Sub datagrid1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellValueChanged
        If e.RowIndex >= 0 Then
            ' Mark the row as modified
            datagrid1.Rows(e.RowIndex).Tag = "Modified"
        End If
    End Sub

    Private selectedRowIndex As Integer

    Private Sub datagrid1_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.RowEnter
        selectedRowIndex = e.RowIndex
    End Sub
    Private Sub UpdateQR()
        Try
            Dim partcode As String
            Dim lotnumber As String
            Dim qty As Integer
            Dim remarks As String
            Dim supplier As String


            Dim qrcode As String = txtpartqr.Text
            Dim parts() As String = qrcode.Split("|")

            'CON 1 : QR SPLITING
            If parts.Length >= 5 AndAlso parts.Length <= 8 Then
                partcode = parts(0).Remove(0, 2).Trim
                lotnumber = parts(2).Remove(0, 2).Trim
                qty = parts(3).Remove(0, 2).Trim
                remarks = parts(4).Remove(0, 2).Trim
                supplier = parts(1).Remove(0, 2).Trim


                con.Close()
                con.Open()
                Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status` FROM `f2_parts_scan` WHERE `qrcode`='" & txtpartqr.Text & "'", con)
                dr = cmdselect.ExecuteReader

                If dr.Read = True Then
                    status = dr.GetString("status")

                    Select Case status
                        Case "W"
                            Dim selectedpartcode As Integer = CInt(datagrid1.Rows(selectedRowIndex).Cells("partcode").Value)
                            ' Ensure a row is selected
                            If selectedpartcode = partcode Then

                                If selectedRowIndex < 0 OrElse selectedRowIndex >= datagrid1.Rows.Count Then
                                    MessageBox.Show("Please select a valid row.")
                                    Return
                                End If


                                Dim newPartQR As String = qrcode
                                Dim newsupplier As String = supplier
                                datagrid1.Rows(selectedRowIndex).Cells("partqr").Value = newPartQR
                                datagrid1.Rows(selectedRowIndex).Cells("suppliercode").Value = newsupplier
                                txtpartqr.Text = ""
                                txtpartqr.Focus()
                            Else
                                showerror("PARTCODE DOES'NT MATCH!")
                                txtpartqr.Text = ""
                                txtpartqr.Focus()
                            End If
                        Case "P"
                            showerror("QR Not yet scanned as WIP!")
                            txtpartqr.Text = ""
                            txtpartqr.Focus()
                    End Select
                Else
                    'noqr
                    showerror("No QR Recorded")
                    txtpartqr.Text = ""
                    txtpartqr.Focus()
                End If
            Else
                showerror("INVALID QR!")
                txtpartqr.Text = ""
                txtpartqr.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub



    Private Sub txtpartqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpartqr.KeyDown
        If e.KeyCode = Keys.Enter Then
            UpdateQR()
        End If
    End Sub

    Private Sub txtpartqr_TextChanged(sender As Object, e As EventArgs) Handles txtpartqr.TextChanged

    End Sub
    Public Sub showerror(text As String)

        Try
            labelerror.Visible = True
            texterror.Text = text
            sounderror()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs)

    End Sub
End Class