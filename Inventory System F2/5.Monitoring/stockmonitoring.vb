Imports MySql.Data.MySqlClient
Public Class stockmonitoring
    Private Sub stock_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1
        dtpicker1.Value = Date.Now
    End Sub

    Private Sub dtpicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker1.ValueChanged
        ' Using parameterized query for security
        Dim query As String = "SELECT ps.partcode AS Partcode, pm.partname AS 'Partname', 
                                SUM(CASE WHEN ps.datein IS NOT NULL THEN ps.qty ELSE 0 END) AS 'Total IN',
                                SUM(CASE WHEN ps.dateout IS NOT NULL THEN ps.qty ELSE 0 END) AS 'Total OUT'
                               FROM f2_parts_scan ps
                               JOIN f2_parts_masterlist pm ON ps.partcode = pm.partcode
                               WHERE ps.datein = @selectedDate
                               GROUP BY ps.partcode, pm.partname"


        Using cmd As New MySqlCommand(query, con)
            ' Add parameter for date
            cmd.Parameters.AddWithValue("@selectedDate", dtpicker1.Value.ToString("yyyy-MM-dd"))
            con.Close()
            ' Open connection
            con.Open()

            ' Execute the query and bind to DataGridView
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                ' Assuming you already have a method to bind the result to datagrid1
                Dim dt As New DataTable()
                dt.Load(reader)
                datagrid1.DataSource = dt
            End Using

        End Using
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        exporttoExcel(datagrid1, "DAILY PARTS REPORT")
    End Sub
End Class