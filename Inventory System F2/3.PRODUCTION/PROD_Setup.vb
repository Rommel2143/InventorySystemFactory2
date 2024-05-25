Imports MySql.Data.MySqlClient
Public Class PROD_Setup
    Dim selectedfg As String
    Dim selectedid As String
    Dim selectedpartcode As String
    Dim concatenatedValue As String
    ' Get today's date in the desired format
    Dim todayDate As String = DateTime.Now.ToString("Mdy")


    Private Sub PROD_Process_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1
        refreshgrid2()

        Try
            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("SELECT `partcode`, `partname` FROM `f2_fg_masterlist` ORDER BY `partcode`", con)
            dr = cmdselect.ExecuteReader
            cmb_fgcode.Items.Clear()
            While (dr.Read())
                ' Concatenate partcode and partname into a single string
                Dim combinedString As String = dr.GetString("partcode") & "-" & dr.GetString("partname")
                ' Add the combined string to the ComboBox
                cmb_fgcode.Items.Add(combinedString)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmb_fgcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_fgcode.SelectedIndexChanged
        If cmb_fgcode.SelectedIndex <> -1 Then
            ' Split the selected item by the hyphen separator
            Dim selectedParts() As String = cmb_fgcode.SelectedItem.ToString().Split("-"c)
            ' Display only the partcode
            If selectedParts.Length > 0 Then
                selectedfg = (selectedParts(0)) ' Display partcode
                refreshgrid(selectedfg)
                selectedid = ""

            End If
        End If
    End Sub

    Private Sub refreshgrid(fg As String)
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT u.`id`, u.`partcode`,m.`partname`, u.`fgusage` FROM `f2_fg_usage` u
                                               INNER JOIN `f2_parts_masterlist` m ON u.`partcode`=m.partcode
                                                WHERE `fgcode`='" & fg & "'
                                                  GROUP BY u.`id`", con)

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

    Private Sub refreshgrid2()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid2 As New MySqlCommand("SELECT `id`, `partcode`, `partname` FROM `f2_parts_masterlist` ORDER BY `partcode`", con)

            Dim da As New MySqlDataAdapter(cmdrefreshgrid2)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid2.DataSource = dt
            datagrid2.AutoResizeColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function GetPartCodesAndUsageFromGrid() As List(Of Tuple(Of String, String))
        Dim partCodesAndUsage As New List(Of Tuple(Of String, String))
        For Each row As DataGridViewRow In datagrid1.Rows
            If Not row.IsNewRow Then ' Exclude the new row if it exists
                Dim partCode As String = row.Cells("partcode").Value.ToString()
                Dim fgUsage As String = row.Cells("fgusage").Value.ToString()
                partCodesAndUsage.Add(New Tuple(Of String, String)(partCode, fgUsage))
            End If
        Next
        Return partCodesAndUsage
    End Function

    Private Sub insert_to_traceability()
        Try
            ' Concatenate today's date and serial number
            concatenatedValue = selectedfg & "_" & todayDate & "_" & "1"

            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("SELECT `datacode` FROM `f2_fg_traceability` WHERE `datacode`='" & concatenatedValue & "'", con)
            dr = cmdselect.ExecuteReader
            If dr.Read = True Then

                showduplicate()
            Else
                ' Retrieve part codes and fgusage from the grid
                Dim partCodesAndUsage As List(Of Tuple(Of String, String)) = GetPartCodesAndUsageFromGrid()
                con.Close()
                con.Open()

                ' Iterate through the list of part codes and fgusage, and insert each one into the table
                For Each partCodeAndUsage As Tuple(Of String, String) In partCodesAndUsage
                    Dim cmdinsert As New MySqlCommand("INSERT INTO `f2_fg_traceability`(`line`,
                                                                                `fgcode`,
                                                                                `datacode`,
                                                                                `partcode`,
                                                                                `qtyused`, 
                                                                                `date1`,
                                                                                `shift`) 
                                                                        VALUES ('" & cmbline.Text & "',
                                                                                '" & selectedfg & "',
                                                                                 '" & concatenatedValue & "',
                                                                                '" & partCodeAndUsage.Item1 & "',
                                                                                '" & partCodeAndUsage.Item2 & "',
                                                                                '" & datedb & "',
                                                                                '" & shift1 & "')", con)
                    cmdinsert.ExecuteNonQuery()

                Next
                MessageBox.Show("saved success!")
                refreshgrid2()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub insert_to_fgscan()
        Try

            con.Close()
            con.Open()
            Dim cmdinsert As New MySqlCommand("INSERT INTO `f2_fg_scan`(`datacode`,`userin`, `datein`, `partcode`, `located`) VALUES ('" & concatenatedValue & "','" & fname & "','" & datedb & "','" & selectedfg & "','" & PClocation & "')", con)
            cmdinsert.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub showduplicate()
        Try
            labelerror.Visible = True
            texterror.Text = "DUPLICATE! Already Recorded"
            soundduplicate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            con.Close()
            con.Open()
            Dim cmdinsert As New MySqlCommand("INSERT INTO `f2_fg_usage`(`fgcode`, `partcode`, `fgusage`) VALUES ('" & selectedfg & "','" & selectedpartcode & "','" & txtusage.Value & "')", con)
            cmdinsert.ExecuteNonQuery()
            refreshgrid(selectedfg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtpass_TextChanged(sender As Object, e As EventArgs) Handles txtpass.TextChanged
        If txtpass.Text = "1230" Then
            paneladd.Visible = True
        Else
            paneladd.Visible = False
        End If
    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles btn_save.Click
        insert_to_traceability()
    End Sub

    Private Sub Panel2_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub datagrid2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid2.CellContentClick
        Try
            With datagrid2

                selectedpartcode = .SelectedCells(1).Value.ToString()

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btndelete_Click_1(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            If selectedid = "" Then
                MessageBox.Show("No item selected!")
            Else
                If MsgBox("Are you sure to DELETE this record?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    con.Close()
                    con.Open()
                    Dim cmddelete As New MySqlCommand("DELETE FROM `f2_fg_usage` WHERE `id`= '" & selectedid & "'", con)
                    cmddelete.ExecuteNonQuery()


                    '///////
                    'deduct_to_parts(qty, partcode, dataid)
                    selectedid = ""
                    refreshgrid(selectedfg)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub datagrid1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellContentClick

    End Sub

    Private Sub datagrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellClick
        Try
            With datagrid1
                selectedid = .SelectedCells(0).Value.ToString()

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbsearch_TextChanged(sender As Object, e As EventArgs) Handles cmbsearch.TextChanged
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid2 As New MySqlCommand("SELECT `id`, `partcode`, `partname` FROM `f2_parts_masterlist` WHERE `partcode` REGEXP '" & cmbsearch.Text & "' or `partname`  REGEXP '" & cmbsearch.Text & "' ORDER BY `partcode`", con)

            Dim da As New MySqlDataAdapter(cmdrefreshgrid2)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid2.DataSource = dt
            datagrid2.AutoResizeColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


End Class