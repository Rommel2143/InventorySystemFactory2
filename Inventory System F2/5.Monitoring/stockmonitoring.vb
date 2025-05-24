Imports MySql.Data.MySqlClient
Public Class stockmonitoring
    Private Sub stock_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1
        dtpicker1.Value = Date.Now
        reload(query(1), datagrid2)
    End Sub

    Private Sub dtpicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker1.ValueChanged
        ' Using parameterized query for security
        Dim query As String = "SELECT ps.partcode AS Partcode, pm.partname AS 'Partname', ps.suppliercode, 
                        SUM(CASE WHEN ps.datein IS NOT NULL THEN ps.qty ELSE 0 END) AS 'Total IN', 
                        SUM(CASE WHEN ps.dateout IS NOT NULL THEN ps.qty ELSE 0 END) AS 'Total OUT', 
                        (SUM(CASE WHEN ps.datein IS NOT NULL THEN ps.qty ELSE 0 END)) - 
                        (SUM(CASE WHEN ps.dateout IS NOT NULL THEN ps.qty ELSE 0 END)) AS 'Balance' 
                        FROM f2_parts_scan ps 
                        JOIN f2_parts_masterlist pm ON ps.partcode = pm.partcode 
                        WHERE ps.datein = @selectedDate 
                        GROUP BY ps.partcode, pm.partname, ps.suppliercode"



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

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged

    End Sub

    Private Sub Guna2TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Guna2TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Guna2TextBox1.Text.Trim = "" Then
                reload(query(1), datagrid2)
            Else
                reload(query("partcode REGEXP '" & Guna2TextBox1.Text & "'"), datagrid2)

            End If
        End If

    End Sub

    Function query(text As String) As String
        Return "SELECT s.partcode, s.suppliercode, " &
           "SUM(s.qty) AS `TOTAL as of now` " &
           "FROM f2_parts_scan s " &
           "WHERE " & text & " AND s.status = 'P' " &
           "GROUP BY s.partcode, s.suppliercode " &
           "ORDER BY s.partcode"
    End Function
    'Function query(text As String) As String
    '    Return "SELECT s.partcode, m.partname, s.suppliercode, " &
    '       "SUM(s.qty) AS `TOTAL as of now` " &
    '       "FROM f2_parts_scan s " &
    '       "LEFT JOIN f2_parts_masterlist m ON s.partcode = m.partcode " &
    '       "WHERE " & text & " AND s.status = 'P' " &
    '       "GROUP BY s.partcode, m.partname, s.suppliercode " &
    '       "ORDER BY s.partcode"
    'End Function


    '     "LEFT JOIN f2_parts_masterlist ON f2_parts_scan.partcode = f2_parts_masterlist.partcode " &

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        exporttoExcel(datagrid2, "Total Stocks")
    End Sub
End Class