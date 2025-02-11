Imports MySql.Data.MySqlClient
Public Class delivery_report
    Private Sub delivery_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub viewdata(datetext As String, user As String, column As String, batch As String)
        dt.Clear()

        con.Close()
        con.Open()
        Dim showreport As New MySqlCommand("SELECT
    ts.id,
  ts.datein AS date,
    ts.batch,
ts.suppliercode,
 tm.partname,
ts.partcode,
   sum( ts.qty) AS qty,
   so.Fullname AS firstname,
  ts.remarks,
ts.drsi,
ts.timein
FROM
    f2_parts_scan ts
    Left Join f2_scanoperator_is so ON ts.userin = so.IDno
    Left Join f2_parts_masterlist tm ON ts.partcode = tm.partcode
WHERE
        ts.datein = '" & datetext & "' and so.Fullname = '" & user & "' and " & column & "='" & batch & "'
GROUP BY
        ts.partcode,ts.suppliercode
ORDER BY
    ts.datein;", con)
        Dim da As New MySqlDataAdapter(showreport)
        da.Fill(dt)
        con.Close()


        Dim myrpt As New IncomingDelivery

        myrpt.Database.Tables("incoming_delivery").SetDataSource(dt)
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.ReportSource = myrpt


    End Sub
End Class