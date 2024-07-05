Imports MySql.Data.MySqlClient
Public Class WIP_IN_Results
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
                                                    LEFT JOIN f2_scanoperator_is so ON ts.userout = so.IDno
                                                    WHERE       `dateout`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' 
                                                    and `partcode`='" & itempartcode & "'
                                                            
                                                            and `Fullname`='" & cmbuser.Text & "'  
                                                            and `batchout`='" & cmbbatchin.Text & "' ", con)

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
                                                    LEFT JOIN f2_scanoperator_is so ON ts.userout = so.IDno
                                                    WHERE       `dateout`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' 
                                                           
                                                            and `Fullname`='" & cmbuser.Text & "'  
                                                            and `batchout`='" & cmbbatchin.Text & "' ", con)

            Dim da As New MySqlDataAdapter(cmdrefreshgrid)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid2.DataSource = dt


            con.Close()
            con.Open()
            Dim cmdrefreshgrid2 As New MySqlCommand("SELECT ts.`partcode` AS Partcode, SUM(`qty`) AS TOTAL 
                                                  FROM `f2_parts_scan` ts
                                                    LEFT JOIN f2_scanoperator_is so ON ts.userout = so.IDno
                                                    WHERE       `dateout`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' 
                                                           
                                                            and `Fullname`='" & cmbuser.Text & "'  
                                                            and `batchout`='" & cmbbatchin.Text & "'          
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
                                                INNER JOIN `f2_scanoperator_is` ON `userout` = `IDno`
                                                WHERE `dateout`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "'", con)
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
            Dim cmdselect As New MySqlCommand("Select distinct ts.`batchout` FROM `f2_parts_scan` ts
                                              Left Join f2_scanoperator_is tsoout ON ts.userout = tsoout.IDno
                                               
                                                WHERE `dateout`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' and `fullname`='" & cmbuser.Text & "'", con)
            dr = cmdselect.ExecuteReader
            cmbbatchin.Items.Clear()
            While (dr.Read())
                cmbbatchin.Items.Add(dr.GetString("batchout"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub datagrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellContentClick

    End Sub
End Class