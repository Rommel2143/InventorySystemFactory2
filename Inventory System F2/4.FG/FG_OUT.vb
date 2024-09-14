Imports MySql.Data.MySqlClient
Public Class FG_OUT

    Dim batch As String
    Dim supplier As String

    'duplicate info
    Dim status As String
    Dim located As String
    Dim dateout As String
    Dim partcode As String
    Dim qrcode As String
    Dim lotnumber As String
    Dim remarks As String
    Dim qty As Integer

    'selected item
    Dim itemid As String = ""
    Dim itempartcode As String = ""
    Dim itemqty As Integer = 0

    Private Sub Scan_In_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1


    End Sub

    Private Sub txtqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr.KeyDown

        If e.KeyCode = Keys.Enter Then
            txt_box.Clear()
            txt_box.Focus()
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

                con.Close()
                con.Open()
                Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status` FROM `f2_fg_scan` WHERE `qrcode`='" & qrcode & "'", con)
                dr = cmdselect.ExecuteReader

                'CON 2 : DUPLICATE QR or GET location
                If dr.Read = True Then
                    status = dr.GetString("status")


                    Select Case status

                        Case "FG"
                            'deduct to fg
                            con.Close()
                            con.Open()
                            Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_fg_masterlist` WHERE `partcode`='" & partcode & "'", con)
                            dr = cmdpartcode.ExecuteReader
                            If dr.Read = True Then
                                Dim dataid As String = dr.GetInt32("id")
                                'SAVING
                                update_to_scan_fg()
                                deduct_to_fg(qty, partcode)
                                refreshgrid()
                                refreshgrid2()
                                return_ok()

                            Else  'CON 3 : PARTCODE
                                showerror("No Partcode Exists!")
                            End If

                        Case "R"
                            'deduct to fg
                            con.Close()
                            con.Open()
                            Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_fg_masterlist` WHERE `partcode`='" & partcode & "'", con)
                            dr = cmdpartcode.ExecuteReader
                            If dr.Read = True Then
                                Dim dataid As String = dr.GetInt32("id")
                                'SAVING
                                update_to_scan_fg()
                                deduct_to_fg(qty, partcode)
                                refreshgrid()
                                refreshgrid2()
                                return_ok()

                            Else  'CON 3 : PARTCODE
                                showerror("No Partcode Exists!")
                            End If

                        Case "OUT"
                            showduplicate()


                        Case "NG"
                            'returned
                            showerror("Marked as Return NG!")

                    End Select
                    con.Close()

                Else 'CON 2 : No Record
                    'no record
                    showerror("No Record Found!")
                End If

            Else  'CON 1 : QR SPLITING
                showerror("INVALID QR SCANNED!")
                con.Close()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub Guna2TextBox2_TextChanged(sender As Object, e As EventArgs) Handles batchcode.TextChanged
        Try
            batch = batchcode.Text
            If batchcode.Text = "" Then
                panelscan.Enabled = False

            Else

                viewdata("SELECT `batchout`, `userout`, `dateout` FROM `f2_fg_scan`
                         WHERE `dateout`='" & datedb & "' and `userout`='" & idno & "' and `batchout`= '" & batchcode.Text & "'")
                If dr.Read = True Then
                    Label4.Visible = True
                    Label7.Visible = True
                    panelscan.Enabled = False
                Else

                    Label4.Visible = False
                    Label7.Visible = False
                    panelscan.Enabled = True

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub



    Private Sub update_to_scan_fg()
        Try

            con.Close()
            con.Open()
            Dim cmdinsert As New MySqlCommand("UPDATE `f2_fg_scan` SET 
                                                                    `status`='OUT',
                                                                    `boxno`='" & txt_box.Text & "',
                                                                    `batchout`='" & batch & "',
                                                                    `userout`='" & idno & "',
                                                                    `dateout`='" & datedb & "'
                                                                    WHERE `qrcode`='" & qrcode & "'", con)
            cmdinsert.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

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
            texterror.Text = "DUPLICATE! Already scanned as OUT"
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


    Private Sub return_ok()
        Try
            labelerror.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub refreshgrid()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `id`,`batch`,`qrcode`,`partcode`,  `lotnumber`, `remarks`, `qty` FROM `f2_fg_scan`
                                                    WHERE `dateout`='" & datedb & "' and `userout`='" & idno & "' and `batchout`='" & batch & "' and  `status`='OUT' ", con)

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
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `partcode`, SUM(`qty`) FROM `f2_fg_scan`
                                                    WHERE `dateout`='" & datedb & "' and `batchout`='" & batch & "' and  `userout`='" & idno & "'
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



    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

        txtqr.Enabled = True
        Label4.Visible = False
        Label7.Visible = False

        refreshgrid()
        refreshgrid2()
    End Sub


    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        FG_OUT_Results.Show()
        FG_OUT_Results.BringToFront()
    End Sub

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub

    Private Sub txtqr_ParentChanged(sender As Object, e As EventArgs) Handles txtqr.ParentChanged

    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_box.TextChanged


    End Sub

    Private Sub Guna2TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_box.KeyDown
        If e.KeyCode = Keys.Enter Then
            qrcode = txtqr.Text
            processQRcode(txtqr.Text)
            txtqr.Clear()
            txtqr.Focus()
        End If
    End Sub

    Private Sub txtqr_Layout(sender As Object, e As LayoutEventArgs) Handles txtqr.Layout

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class