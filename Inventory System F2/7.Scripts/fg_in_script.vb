
Imports MySql.Data.MySqlClient
Public Class fg_in_script

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
                Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status`,`datein` FROM `f2_fg_scan` WHERE `qrcode`='" & qrcode & "'", con)
                dr = cmdselect.ExecuteReader
                'CON 2 : DUPLICATE QR or GET location
                If dr.Read = True Then
                    status = dr.GetString("status")
                    datein = dr.GetDateTime("datein")

                    Select Case status
                        Case "FG"
                            showduplicate(datein) 'duplicate
                            txtqr.Text = ""
                            txtqr.Focus()
                        Case "OUT"
                            'out
                            txtqr.Text = ""
                            txtqr.Focus()
                        Case "R"
                            'returned
                            txtqr.Text = ""
                            txtqr.Focus()
                    End Select
                    con.Close()

                Else 'CON 2 : NOT DUPLICATE
                    con.Close()
                    con.Open()
                    Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_fg_masterlist` WHERE `partcode`='" & partcode & "'", con)
                    dr = cmdpartcode.ExecuteReader
                    If dr.Read = True Then
                        Dim dataid As String = dr.GetInt32("id")
                        'SAVING
                        insert_to_scan_fg()
                        add_to_fg(qty, partcode)
                        refreshgrid()

                        return_ok()


                    Else  'CON 3 : PARTCODE
                        showerror("No Partcode Exists!")
                    End If

                End If
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

                viewdata("SELECT `batch`, `userin`, `datein` FROM `f2_fg_scan`
                         WHERE `datein`='" & datedb & "' and `userin`='" & idno & "' and `batch`= '" & batchcode.Text & "'")
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



    Private Sub insert_to_scan_fg()
        Try

            con.Close()
            con.Open()
            Dim cmdinsert As New MySqlCommand(" INSERT INTO `f2_fg_scan` (`status`,
                                                                            `batch`,
                                                                            `userin`,
                                                                            `datein`,
                                                                            `partcode`,
                                                                            `qrcode`,
                                                                            `lotnumber`,
                                                                            `remarks`,
                                                                            `qty`,
                                                                             `serial`) 

                                                       VALUES ('FG',
                                                              '" & batch & "',
                                                              '" & idno & "',
                                                              '" & datedb & "',
                                                              '" & partcode & "',
                                                              '" & qrcode & "',
                                                              '" & lotnumber & "',
                                                              '" & remarks & "',
                                                              '" & qty & "',
                                                              '" & serial & "')", con)
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
    Private Sub showduplicate(ByVal datetext As String)
        Try
            labelerror.Visible = True
            texterror.Text = "DUPLICATE! Already scanned on '" & datetext & "'"
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
            Dim cmdrefreshgrid As New MySqlCommand("SELECT `id`,`batch`,`qrcode`,`partcode`,  `lotnumber`, `remarks`, `qty` FROM `f2_fg_scan`
                                                    WHERE `datein`='" & datedb & "' and `userin`='" & idno & "' and `batch`='" & batch & "' and  `status`='FG' ", con)

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