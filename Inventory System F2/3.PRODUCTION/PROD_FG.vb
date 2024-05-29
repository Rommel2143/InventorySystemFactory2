Imports MySql.Data.MySqlClient
Public Class PROD_FG
    Dim selectedfg As String
    Dim partcode As String
    Dim lotnumber As String
    Dim qty As Integer
    Dim remarks As String
    Dim supplier As String
    Dim status As String
    Dim datein As String
    Private Sub PROD_FG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1

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

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

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

    Private Sub cmb_data_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_data.SelectedIndexChanged
        refreshgrid()
        txtqr.Enabled = True
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


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally


            con.Close()
        End Try
    End Sub

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub
    Private Sub processQRcode(qrcode As String)
        Try

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
                Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status`,`datein` FROM `f2_fg_scan` WHERE `qrcode`='" & qrcode & "'", con)
                dr = cmdselect.ExecuteReader
                'CON 2 : DUPLICATE QR or GET location
                If dr.Read = True Then
                    status = dr.GetString("status")
                    datein = dr.GetDateTime("datein")
                    con.Close()

                    'duplicate
                    showduplicate(datein)
                    txtqr.Clear()
                    txtqr.Focus()

                Else 'CON 2 : NOT DUPLICATE
                    If selectedfg = partcode Then
                        'saving
                        con.Close()
                        con.Open()
                        Dim cmdinsert As New MySqlCommand(" INSERT INTO `f2_fg_scan`(`status`, 
                                                                                    `datacode`,
                                                                                    `userin`, 
                                                                                    `datein`, 
                                                                                    `partcode`,
                                                                                    `qrcode`, 
                                                                                    `lotnumber`, 
                                                                                    `remarks`,
                                                                                    `qty`,
                                                                                    `located`) 

                                                                            VALUES ('F',
                                                                                    '" & cmb_data.Text & "',
                                                                                    '" & idno & "',
                                                                                    '" & datedb & "',
                                                                                    '" & partcode & "',
                                                                                    '" & qrcode & "',
                                                                                    '" & lotnumber & "',
                                                                                    '" & remarks & "',
                                                                                    '" & qty & "',
                                                                                    '" & PClocation & "')", con)

                        cmdinsert.ExecuteNonQuery()



                    Else
                        'partcode not equal
                        showerror("PARTCODE NOT EQUAL!")
                        con.Close()
                        txtqr.Text = ""
                        txtqr.Focus()
                    End If
                End If

                '
            Else  'CON 1 : QR SPLITING
                showerror("INVALID QR SCANNED!")
                con.Close()
                txtqr.Text = ""
                txtqr.Focus()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Function GetPartCodesAndUsageFromGrid() As List(Of Tuple(Of String, String, String))
        Dim partCodesAndsupplier As New List(Of Tuple(Of String, String, String))

        For Each row As DataGridViewRow In datagrid1.Rows
            If Not row.IsNewRow Then ' Exclude the new row if it exists
                Dim partCode As String = row.Cells("partcode").Value.ToString()
                Dim suppliercode As String = row.Cells("suppliercode").Value.ToString()
                Dim qtyused As String = row.Cells("qtyused").Value
                partCodesAndsupplier.Add(New Tuple(Of String, String, String)(partCode, suppliercode, qtyused))
            End If
        Next
        Return partCodesAndsupplier
    End Function
    Private Sub update_wipstock()
        Try
            ' Retrieve part codes and fgusage from the grid
            Dim partCodesAndsupplier As List(Of Tuple(Of String, String, String)) = GetPartCodesAndUsageFromGrid()
            con.Close()
            con.Open()

            ' Iterate through the list of part codes and fgusage, and insert each one into the table
            For Each partCodeAndsupplier As Tuple(Of String, String, String) In partCodesAndsupplier
                con.Close()
                con.Open()
                Dim cmdupdate As New MySqlCommand("UPDATE `f2_parts_masterlist` SET `wipstockf2`= (`wipstockf2`-(" & qty & " * " & partCodeAndsupplier.Item3 & ")) WHERE `partcode`='" & partCodeAndsupplier.Item1 & "' and `supplier`='" & partCodeAndsupplier.Item2 & "' ", con)
                cmdupdate.ExecuteNonQuery()

            Next
            MessageBox.Show("saved success!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
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

    Private Sub showduplicate(ByVal datetext As String)
        Try
            labelerror.Visible = True
            texterror.Text = "DUPLICATE! Already scanned on '" & datetext & "'"
            soundduplicate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr.KeyDown
        If e.KeyCode = Keys.Enter Then
            processQRcode(txtqr.Text)
            update_wipstock()
        End If
    End Sub
End Class