Imports MySql.Data.MySqlClient
Public Class FG_Return
    Dim batch As String = "Returned"
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

    'selected item
    Dim itemid As String = ""
    Dim itempartcode As String = ""
    Dim itemqty As Integer = 0
    Dim scanstatus As String = "R"
    Private Sub txtqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr.KeyDown

        If e.KeyCode = Keys.Enter Then
            qrcode = txtqr.Text

            Select Case scanstatus
                Case "NG"
                    processQRcodeNG(txtqr.Text)

                Case "R"
                    processQRcode(txtqr.Text)
            End Select

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
                Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status`,`datein` FROM `f2_fg_scan` WHERE `qrcode`='" & qrcode & "'", con)
                dr = cmdselect.ExecuteReader
                'CON 2 : DUPLICATE QR or GET location
                If dr.Read = True Then
                    status = dr.GetString("status")
                    datein = dr.GetDateTime("datein")

                    Select Case status
                        Case "FG"
                            showerror("Marked as FG!") '
                            return_error()

                        Case "OUT"
                            'Return
                            con.Close()
                            con.Open()
                            Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_fg_masterlist` WHERE `partcode`='" & partcode & "'", con)
                            dr = cmdpartcode.ExecuteReader
                            If dr.Read = True Then
                                Dim dataid As String = dr.GetInt32("id")
                                'SAVING
                                update_to_scan_fg()
                                add_to_fg(qty, partcode)
                                return_ok()


                            Else  'CON 3 : PARTCODE
                                showerror("No Partcode Exists!")
                            End If
                        Case "R"
                            showduplicate()
                        Case "NG"
                            'duplicate
                            showNG()

                    End Select
                    con.Close()


                Else 'CON 2 : NOT DUPLICATE
                    showerror("No Record Exists!")
                    return_error()
                End If

            Else  'CON 1 : QR SPLITING
                showerror("INVALID QR SCANNED!")
                con.Close()
                return_error()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub processQRcodeNG(qrcode As String)
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
                Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status`,`datein` FROM `f2_fg_scan` WHERE `qrcode`='" & qrcode & "'", con)
                dr = cmdselect.ExecuteReader
                'CON 2 : DUPLICATE QR or GET location
                If dr.Read = True Then
                    status = dr.GetString("status")
                    datein = dr.GetDateTime("datein")

                    Select Case status
                        Case "FG"
                            showerror("Marked as FG!") '
                            return_error()

                        Case "OUT"
                            'Return
                            con.Close()
                            con.Open()
                            Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_fg_masterlist` WHERE `partcode`='" & partcode & "'", con)
                            dr = cmdpartcode.ExecuteReader
                            If dr.Read = True Then
                                Dim dataid As String = dr.GetInt32("id")
                                'SAVING
                                update_to_scan_fg()

                                return_ok()


                            Else  'CON 3 : PARTCODE
                                showerror("No Partcode Exists!")
                            End If
                        Case "R"
                            showduplicate()
                        Case "NG"
                            'duplicate
                            showNG()

                    End Select
                    con.Close()


                Else 'CON 2 : NOT DUPLICATE
                    showerror("No Record Exists!")
                    return_error()
                End If

            Else  'CON 1 : QR SPLITING
                showerror("INVALID QR SCANNED!")
                con.Close()
                return_error()
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
                                                                    `status`='" & scanstatus & "',
                                                                    `batch`='" & batch & "',
                                                                    `userin`='" & idno & "',
                                                                    `datein`='" & datedb & "'
                                                                    WHERE `qrcode`='" & qrcode & "'", con)
            cmdinsert.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
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

    Private Sub return_error()
        Try
            labelerror.Visible = True
            txtqr.Clear()
            txtqr.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub showduplicate()
        Try
            labelerror.Visible = True
            texterror.Text = "DUPLICATE! Already scanned as Returned"
            soundduplicate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub showNG()
        Try
            labelerror.Visible = True
            texterror.Text = "DUPLICATE! Already scanned as NG"
            soundduplicate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub

    Private Sub chck_NG_CheckedChanged(sender As Object, e As EventArgs) Handles chck_NG.CheckedChanged
        If chck_NG.Checked = True Then
            scanstatus = "NG"
        Else
            scanstatus = "R"
        End If

    End Sub
End Class