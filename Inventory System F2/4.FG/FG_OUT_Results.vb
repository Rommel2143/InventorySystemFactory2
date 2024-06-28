Imports MySql.Data.MySqlClient

Public Class FG_OUT_Results


    Private Sub print_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpicker.Value = Date.Now.ToString("MMMM-dd-yyyy")
    End Sub
    Sub viewdata()
        con.Close()
        con.Open()
        Dim showreport As New MySqlCommand("SELECT
    ts.id,
    ts.status,
    ts.batch,
ts.qrcode,
ts.partcode,
ts.lotnumber,
ts.remarks,
    ts.qty,
ts.datein,
ts.userin,
    ts.batchout,
ts.userout,
 ts.dateout,
    ts.boxno,
    tsoout.Fullname,
    tm.partname AS PartName
FROM
        f2_fg_scan ts
    Left Join f2_scanoperator_is tsoout ON ts.userout = tsoout.IDno
    Left Join f2_fg_masterlist tm ON ts.partcode = tm.partcode
WHERE
        ts.dateout = '" & dtpicker.Value.ToString("yyyy-MM-dd") & "' and tsoout.Fullname = '" & cmbuser.Text & "' and ts.batchout='" & cmbbatchout.Text & "'
ORDER BY
    ts.dateout;", con)
        Dim da As New MySqlDataAdapter(showreport)
        da.Fill(dt)
        con.Close()

    End Sub

    Private Sub Guna2DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker.ValueChanged
        Try
            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("Select distinct `fullname` FROM `f2_fg_scan`
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
            Dim cmdselect As New MySqlCommand("Select distinct ts.`batchout` FROM `f2_fg_scan` ts
                                              Left Join F2_scanoperator_is tsoout ON ts.userout = tsoout.IDno
                                               
                                                WHERE `dateout`='" & dtpicker.Value.ToString("yyyy-MM-dd") & "' and `fullname`='" & cmbuser.Text & "'", con)
            dr = cmdselect.ExecuteReader
            cmbbatchout.Items.Clear()
            While (dr.Read())
                cmbbatchout.Items.Add(dr.GetString("batchout"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbbatchout_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbatchout.SelectedIndexChanged
        Dim myrpt As New CrystalReport1
        dt.Clear()
        viewdata()
        myrpt.Database.Tables("f2_fg_scan").SetDataSource(dt)
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.ReportSource = myrpt
    End Sub
End Class