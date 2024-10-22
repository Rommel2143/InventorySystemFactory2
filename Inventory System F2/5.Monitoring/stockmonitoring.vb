Imports MySql.Data.MySqlClient
Public Class stockmonitoring
    Private Sub stock_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1
    End Sub
    Private Sub refreshgridfg()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT fm.partname, fs.partcode, sum(fs.qty) AS TOTAL FROM f2_fg_scan fs
                                                    JOIN f2_fg_masterlist fm ON fs.partcode = fm.partcode
                                                    WHERE fs.status='FG' or fs.status='R'
                                                    GROUP BY fs.partcode
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
            Dim cmdrefreshgrid As New MySqlCommand("SELECT pm.partname, ps.partcode, sum(ps.qty) AS TOTAL FROM f2_parts_scan ps
                                                    JOIN f2_parts_masterlist pm ON ps.partcode = pm.partcode
                                                    WHERE ps.status='P'
                                                    GROUP BY ps.partcode
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