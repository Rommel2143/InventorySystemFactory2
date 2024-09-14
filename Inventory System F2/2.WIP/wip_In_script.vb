
Imports MySql.Data.MySqlClient
Public Class wip_In_script
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


    Private Sub processQRcode(qrcode As String)
        Try

            Dim parts() As String = qrcode.Split("|")

            'CON 1 : QR SPLITING
            If parts.Length >= 5 AndAlso parts.Length <= 8 Then
                partcode = parts(0).Remove(0, 2).Trim
                lotnumber = parts(2).Remove(0, 2).Trim

                remarks = parts(4).Remove(0, 2).Trim
                supplier = parts(1).Remove(0, 2).Trim


                con.Close()
                con.Open()
                Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status`,`dateout`,`qty` FROM `f2_parts_scan` WHERE `qrcode`='" & qrcode & "'", con)
                dr = cmdselect.ExecuteReader
                'CON 2 : HAS RECORD
                If dr.Read = True Then
                    status = dr.GetString("status")
                    qty = dr.GetInt32("qty")
                    Select Case status
                        Case "P"
                            con.Close()
                            con.Open()
                            Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_parts_masterlist` WHERE `partcode`='" & partcode & "' and `supplier`= '" & supplier & "'", con)
                            dr = cmdpartcode.ExecuteReader
                            If dr.Read = True Then
                                Dim dataid As String = dr.GetInt32("id")
                                'deduct to stock and change status to W
                                deduct_to_parts(qty, dataid)
                                add_to_WIP(qty, dataid)
                                update_to_WIP()
                                refreshgrid()

                                return_ok()
                            Else
                                showerror("PARTCODE NOT EXISTS!")
                                txtqr.Clear()
                                txtqr.Focus()
                            End If
                        Case "W"
                            'duplicate
                            showduplicate()
                            txtqr.Text = ""
                            txtqr.Focus()
                        Case "R"
                            showerror("Invalid! Marked as Returned to Supplier Item!")
                            txtqr.Text = ""
                            txtqr.Focus()
                    End Select



                Else  'CON 3 : PARTCODE
                    showerror("NO RECORD FOUND!")
                End If

                con.Close()


            Else  'CON 1 : QR SPLITING
                showerror("INVALID QR SCANNED!")
                con.Close()
                txtqr.Text = ""
                txtqr.Focus()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub Guna2TextBox2_TextChanged(sender As Object, e As EventArgs) Handles batchcode.TextChanged
        Try
            batch = batchcode.Text
            If batchcode.Text = "" Then
                txtqr.Enabled = False
                Label4.Visible = False
                Label7.Visible = False

            Else

                viewdata("SELECT `batch`, `userout`, `dateout` FROM `f2_parts_scan`
                         WHERE `dateout`='" & datedb & "' and `userout`='" & idno & "' and `batchout`= '" & batchcode.Text & "'")
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


    Private Sub return_ok()
        Try
            labelerror.Visible = False
            txtqr.Clear()
            txtqr.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub refreshgrid()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `id`,`batchout`,`qrcode`,`partcode`, `lotnumber`, `remarks`, `qty` FROM `f2_parts_scan`
                                                    WHERE `dateout`='" & datedb & "' and `userout`='" & idno & "' and `batchout`='" & batch & "' and  `status`='W' ", con)

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


    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

        txtqr.Enabled = True
        Label4.Visible = False
        Label7.Visible = False

        refreshgrid()

    End Sub


    Private Sub update_to_WIP()
        con.Close()
        con.Open()
        Dim cmdupdate As New MySqlCommand("UPDATE `f2_parts_scan` SET   `status`='W',
                                                                        `batchout`='" & batch & "',
                                                                        `dateout`= '" & datedb & "',
                                                                        `userout`='" & idno & "' 
                                          WHERE `qrcode`='" & qrcode & "' ", con)
        cmdupdate.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub btn_runscript_Click(sender As Object, e As EventArgs) Handles btn_runscript.Click
        'complete a code that run script for processQR for every lines in txtqr

        Try
            ' Split the QR codes by new lines
            Dim qrCodes() As String = txtqr.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            ' Process each QR code
            For Each qrCode1 As String In qrCodes
                qrcode = (qrCode1.Trim)
                processQRcode(qrCode1.Trim)
            Next

            ' Optionally show a message when done
            MessageBox.Show("All QR codes processed.", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class