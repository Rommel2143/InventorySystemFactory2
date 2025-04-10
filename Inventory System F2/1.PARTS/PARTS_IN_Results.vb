Imports MySql.Data.MySqlClient

Public Class Parts_IN_Results
    Dim itempartcode As String
    Dim batchselect As String

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
        If rad_batch.Checked = True Then
            loaddata("`batch`='" & cmbbatchin.Text & "'")
        ElseIf rad_drsi.Checked = True Then
            loaddata("drsi='" & cmbbatchin.Text & "'")
        End If
    End Sub

    Private Sub loaddata(text As String)
        Try


            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT ts.`qrcode`,ts.`partcode`,ts.`lotnumber`, ts.`remarks`, ts.`qty`
                                                    FROM `f2_parts_scan` ts
                                                    LEFT JOIN f2_scanoperator_is so ON ts.userin = so.IDno
                                                    WHERE       `datein`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' 
                                                           
                                                            and `Fullname`='" & cmbuser.Text & "'  
                                                            and " & text & "", con)

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
                                                            and " & text & "     
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
        rad_drsi.Checked = False
        rad_batch.Checked = False
        cmbbatchin.Items.Clear()
        datagrid1.DataSource = Nothing
        datagrid2.DataSource = Nothing

    End Sub
    Private Sub datagrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellContentClick

    End Sub



    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If batchselect = "" Then
        Else
            delivery_report.viewdata(dtpicker.Value.ToString("yyyy-MM-dd"), cmbuser.Text, batchselect, cmbbatchin.Text)
            delivery_report.Show()
            delivery_report.BringToFront()
        End If
    End Sub

    Private Sub Guna2RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rad_batch.CheckedChanged

        Try
            If rad_batch.Checked = True Then
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
                batchselect = "batch"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Guna2RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rad_drsi.CheckedChanged
        Try
            If rad_drsi.Checked = True Then
                con.Close()
                con.Open()
                Dim cmdselect As New MySqlCommand("Select distinct ts.drsi FROM `f2_parts_scan` ts
                                              Left Join f2_scanoperator_is tsoout ON ts.userin = tsoout.IDno
                                               
                                                WHERE ts.drsi IS NOT NULL and `datein`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' and `fullname`='" & cmbuser.Text & "'", con)
                dr = cmdselect.ExecuteReader
                cmbbatchin.Items.Clear()
                While (dr.Read())
                    cmbbatchin.Items.Add(dr.GetString("drsi"))
                End While
                batchselect = "drsi"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        exporttoExcel(datagrid2, "INCOMING DELIVERY REPORT -" & cmbbatchin.Text)
    End Sub
End Class