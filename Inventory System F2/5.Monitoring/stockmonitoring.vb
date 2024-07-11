Imports MySql.Data.MySqlClient
Public Class stockmonitoring
    Private Sub stock_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1
    End Sub
    Private Sub refreshgridfg()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `id`, `partname`, `partcode`, `stockF2` FROM `f2_fg_masterlist`  
                                                    ORDER BY partname ASC", con)

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
    Private Sub refreshgridparts()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `id`, `partname`, `partcode`, `supplier`, `stockf2`, `wipstockf2` FROM `f2_parts_masterlist`  
                                                    ORDER BY partname ASC", con)

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


    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbselect.SelectedIndexChanged
        Select Case cmbselect.Text
            Case "Parts"
                refreshgridparts()
            Case "FG"
                refreshgridfg()
        End Select
    End Sub
End Class