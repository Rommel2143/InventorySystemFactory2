Imports MySql.Data.MySqlClient
Public Class Parts_In

    Dim batch As String
    Dim supplier As String

    'duplicate info
    Dim status As String
    Dim located As String
    Dim datein As String
    Dim partcode As String
    Dim qrcode As String
    Dim lotnumber As String
    Dim remarks As String
    Dim qty As Integer
    Dim serial As String

    'selected item
    Dim itemid As String = ""
    Dim itempartcode As String = ""
    Dim itemqty As Integer = 0

    Private Sub Scan_In_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1

       
    End Sub

    Private Sub txtqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr.KeyDown

        If e.KeyCode = Keys.Enter Then
            qrcode = txtqr.Text
            processQRcode(txtqr.Text)

        End If
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
                serial = parts(5).Remove(0, 2).Trim

                con.Close()
                con.Open()
                Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_parts_masterlist` WHERE `partcode`='" & partcode & "' and `supplier`= '" & supplier & "'", con)
                dr = cmdpartcode.ExecuteReader
                If dr.Read = True Then
                    Dim dataid As String = dr.GetInt32("id")
                    'SAVING
                    insert_to_scan_parts()
                    ' add_to_parts(qty, dataid)
                    refreshgrid()
                    refreshgrid2()

                Else  'CON 3 : PARTCODE
                    showerror("No Partcode Exists!")
                End If


            Else  'CON 1 : QR SPLITING
                showerror("INVALID QR SCANNED!")
                con.Close()
                txtqr.Text = ""
                txtqr.Focus()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
            txtqr.Clear()
            txtqr.Focus()
        End Try

    End Sub


    Private Sub Guna2TextBox2_TextChanged(sender As Object, e As EventArgs) Handles batchcode.TextChanged, txtdrsi.TextChanged
        Try
            batch = batchcode.Text
            If batchcode.Text = "" Or txtdrsi.Text = "" Then
                txtqr.Enabled = False
                Label4.Visible = False
                Label7.Visible = False

            Else

                viewdata("SELECT `batch`, `userin`, `datein` FROM `f2_parts_scan`
                         WHERE `datein`='" & datedb & "' and `userin`='" & idno & "' and `batch`= '" & batchcode.Text & "' LIMIT 1")
                If dr.Read = True Then
                    Label4.Visible = True
                    Label7.Visible = True
                    txtqr.Enabled = False
                Else
                    txtqr.Enabled = True
                    Label4.Visible = False
                    Label7.Visible = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)
        Parts_IN_Results.Show()
        Parts_IN_Results.BringToFront()
    End Sub

    Private Sub insert_to_scan_parts()
        Try
            con.Close()
            con.Open()

            Dim query As String = "INSERT INTO `f2_parts_scan` (`status`, `batch`, `drsi`, `userin`, `datein`, `timein`, `partcode`, `suppliercode`, `qrcode`, `lotnumber`, `serial`, `remarks`, `qty`) 
                               VALUES (@status, @batch, @drsi, @userin, CURDATE(), CURTIME(), @partcode, @suppliercode, @qrcode, @lotnumber, @serial, @remarks, @qty)"

            Using cmdinsert As New MySqlCommand(query, con)
                cmdinsert.Parameters.AddWithValue("@status", "P")
                cmdinsert.Parameters.AddWithValue("@batch", batch)
                cmdinsert.Parameters.AddWithValue("@drsi", txtdrsi.Text)
                cmdinsert.Parameters.AddWithValue("@userin", idno)
                cmdinsert.Parameters.AddWithValue("@partcode", partcode)
                cmdinsert.Parameters.AddWithValue("@suppliercode", supplier)
                cmdinsert.Parameters.AddWithValue("@qrcode", qrcode)
                cmdinsert.Parameters.AddWithValue("@lotnumber", lotnumber)
                cmdinsert.Parameters.AddWithValue("@serial", serial)
                cmdinsert.Parameters.AddWithValue("@remarks", remarks)
                cmdinsert.Parameters.AddWithValue("@qty", Convert.ToInt32(qty)) ' Assuming qty is an integer

                cmdinsert.ExecuteNonQuery()
            End Using
            labelerror.Visible = False
        Catch ex As MySqlException When ex.Number = 1062
            showduplicate()
        Catch ex As Exception
            showerror(ex.Message)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub






    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub
    Private Sub QRisWIP()
        Try
            labelerror.Visible = True
            texterror.Text = "QR marked as WIP"
            sounderror()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub showduplicate()
        Try
            labelerror.Visible = True
            texterror.Text = "DUPLICATE! Already scanned"
            soundduplicate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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



    Private Sub refreshgrid()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `id`,`batch`,`qrcode`,`partcode`,  `lotnumber`, `remarks`, `qty` FROM `f2_parts_scan`
                                                    WHERE `datein`='" & datedb & "' and `userin`='" & idno & "' and `batch`='" & batch & "' and  `status`='P' ", con)

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
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `partcode`, SUM(`qty`) FROM `f2_parts_scan`
                                                    WHERE `datein`='" & datedb & "' and `batch`='" & batch & "' and  `userin`='" & idno & "'
                                                    GROUP BY partcode", con)

            Dim da As New MySqlDataAdapter(cmdrefreshgrid)
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

    Private Sub datagrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub datagrid1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellContentClick

    End Sub

    Private Sub datagrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellClick
        Try
            With datagrid1
                itemid = .SelectedCells(0).Value.ToString()
                itempartcode = .SelectedCells(2).Value.ToString()
                itemqty = .SelectedCells(5).Value()

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            If itemid = "" Then
                MessageBox.Show("No item selected!")
            Else
                If MsgBox("Are you sure to DELETE this record?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    con.Close()
                    con.Open()
                    Dim cmddelete As New MySqlCommand("DELETE FROM `f2_parts_scan` WHERE `id`= '" & itemid & "'", con)
                    cmddelete.ExecuteNonQuery()


                    '///////
                    'deduct_to_parts(qty, partcode, dataid)
                    itemid = ""
                    itempartcode = ""
                    itemqty = 0
                    refreshgrid()
                    refreshgrid2()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub deduct_to_stock()
        Try

            con.Close()
                    con.Open()
            Dim cmdupdate As New MySqlCommand("UPDATE `tblmaster` SET `stockF2`= (`stockF2`-" & itemqty & ") WHERE `partcode`='" & itempartcode & "'", con)
            cmdupdate.ExecuteNonQuery()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

        txtqr.Enabled = True
        Label4.Visible = False
        Label7.Visible = False

        refreshgrid()
        refreshgrid2()
    End Sub

    Private Sub cmbsearch_TextChanged(sender As Object, e As EventArgs) Handles cmbsearch.TextChanged
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `id`,`batch`,`qrcode`,`partcode`,  `lotnumber`, `remarks`, `qty` FROM `f2_parts_scan`
                                                     WHERE `datein`='" & datedb & "' and `userin`='" & idno & "' and `status`='IN' and (`qrcode` REGEXP '" & cmbsearch.Text & "' or `batch` REGEXP '" & cmbsearch.Text & "')", con)

            Dim da As New MySqlDataAdapter(cmdrefreshgrid)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid1.DataSource = dt
            datagrid1.AutoResizeColumns()

            con.Close()
            con.Open()
            Dim cmdrefreshgrid2 As New MySqlCommand("SELECT `partcode`, SUM(`qty`) FROM `f2_parts_scan`
                                                  WHERE `datein`='" & datedb & "'  and `userin`='" & idno & "' and `status`='IN' and (`qrcode` REGEXP '" & cmbsearch.Text & "' or `batch` REGEXP '" & cmbsearch.Text & "')               
                                                  GROUP BY partcode", con)

            Dim da2 As New MySqlDataAdapter(cmdrefreshgrid2)
            Dim dt2 As New DataTable
            da2.Fill(dt2)
            datagrid2.DataSource = dt2
            datagrid2.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        PARTS_IN_Results.Show()
        PARTS_IN_Results.BringToFront()

    End Sub
End Class