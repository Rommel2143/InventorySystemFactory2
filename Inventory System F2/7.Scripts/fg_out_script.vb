
Imports MySql.Data.MySqlClient
Public Class fg_out_script

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
    Dim boxnumber As String

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




    Private Sub update_to_scan_fg()
        Try

            con.Close()
            con.Open()
            Dim cmdinsert As New MySqlCommand("UPDATE `f2_fg_scan` SET 
                                                                    `status`='OUT',
                                                                    `boxno`='" & boxnumber & "',
                                                                    `batchout`='" & batchcode.Text & "',
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




    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

        txtqr.Enabled = True
        Label4.Visible = False
        Label7.Visible = False

        refreshgrid()

    End Sub




    Private Sub Guna2TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_box.KeyDown
        If e.KeyCode = Keys.Enter Then
            qrcode = txtqr.Text
            processQRcode(txtqr.Text)
            txtqr.Clear()
            txtqr.Focus()
        End If
    End Sub


    Private Sub btn_runscript_Click(sender As Object, e As EventArgs) Handles btn_runscript.Click
        'complete a code that run script for processQR for every lines in txtqr

        Try
            ' Split the QR codes by new lines
            Dim qrCodes() As String = txtqr.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
            Dim boxno() As String = txt_box.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            ' Process each QR code with its corresponding box number
            For i As Integer = 0 To qrCodes.Length - 1
                qrcode = qrCodes(i).Trim()
                boxnumber = boxno(i).Trim()

                ' Update the box number for this QR code in the database
                processQRcode(qrCodes(i).Trim())
            Next
            txtqr.Clear()
            txt_box.Clear()
            ' Optionally show a message when done
            MessageBox.Show("All QR codes processed.", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub batchcode_TextChanged(sender As Object, e As EventArgs) Handles batchcode.TextChanged
        txtqr.Enabled = True
        txt_box.Enabled = True
    End Sub

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub
End Class