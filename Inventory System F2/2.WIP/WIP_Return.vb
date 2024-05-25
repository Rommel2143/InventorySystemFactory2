Imports MySql.Data.MySqlClient
Public Class WIP_Return

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

    Private Sub Scan_out_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1


    End Sub

    Private Sub txtqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr.KeyDown
        If e.KeyCode = Keys.Enter Then
            If chck_manualqty.Checked = True Then
                qrcode = txtqr.Text
                Dim parts() As String = txtqr.Text.Split("|")

                'CON 1 : QR SPLITING
                If parts.Length >= 5 AndAlso parts.Length <= 8 Then
                    partcode = parts(0).Remove(0, 2).Trim
                    lotnumber = parts(2).Remove(0, 2).Trim

                    remarks = parts(4).Remove(0, 2).Trim
                    supplier = parts(1).Remove(0, 2).Trim
                    'CON 2: DUPLICATION
                    con.Close()
                    con.Open()
                    Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status`,`qty` FROM `f2_parts_scan` WHERE `qrcode`='" & qrcode & "'", con)
                    dr = cmdselect.ExecuteReader
                    If dr.Read = True Then
                        status = dr.GetString("status")
                        qty = dr.GetInt32("qty")

                        txt_displayqty.Text = qty
                        txt_qty.Clear()
                        txt_qty.Focus()
                    Else 'CON 2 else: DUPLICATION 
                        showerror("NO RECORD FOUND!")
                        con.Close()
                        txtqr.Text = ""
                        txtqr.Focus()

                    End If


                Else  'CON 1 : QR SPLITING
                    showerror("INVALID QR SCANNED!")
                    con.Close()
                    txtqr.Text = ""
                    txtqr.Focus()
                End If
            Else

                qrcode = txtqr.Text
                processQRcode(txtqr.Text)

            End If
        End If
    End Sub
    Private Sub processQRcode(qrcode As String)
        Try

            Dim parts() As String = qrcode.Split("|")

            'CON 1 : QR SPLITING
            If parts.Length >= 5 AndAlso parts.Length <= 8 Then
                partcode = parts(0).Remove(0, 2).Trim
                lotnumber = parts(2).Remove(0, 2).Trim

                remarks = parts(4).Remove(0, 2).Trim
                supplier = parts(1).Remove(0, 2).Trim
                txt_displayqty.Text = qty
                'CON 2: DUPLICATION

                con.Close()
                con.Open()
                Dim cmdselect As New MySqlCommand("SELECT `qrcode`,`status`,`qty` FROM `f2_parts_scan` WHERE `qrcode`='" & qrcode & "'", con)
                dr = cmdselect.ExecuteReader
                If dr.Read = True Then
                    status = dr.GetString("status")
                    qty = dr.GetInt32("qty")

                    Select Case status
                        Case "W"
                            con.Close()
                            con.Open()
                            Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_parts_masterlist` WHERE `partcode`='" & partcode & "' and `supplier`= '" & supplier & "'", con)
                            dr = cmdpartcode.ExecuteReader
                            If dr.Read = True Then
                                Dim dataid As String = dr.GetInt32("id")
                                'SAVING
                                deduct_to_WIP(qty, dataid)
                                add_to_parts(qty, dataid)
                                update_scan_return()
                                return_ok()

                                return_ok()


                            Else  'CON 3 : PARTCODE
                                showerror("No Partcode Exists!")
                            End If

                        Case "P"
                            'duplicate
                            showduplicate()
                            txtqr.Text = ""
                            txtqr.Focus()

                        Case "F"
                            showerror("INVALID! MARKED AS FG")
                            txtqr.Text = ""
                            txtqr.Focus()

                        Case "R"
                            showerror("INVALID! MARKED AS RETURNED ITEM")
                            txtqr.Text = ""
                            txtqr.Focus()

                    End Select

                Else 'CON 2 else: DUPLICATION 
                    showerror("NO RECORD FOUND!")
                    con.Close()
                    txtqr.Text = ""
                    txtqr.Focus()

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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub update_scan_return()
        Try
            con.Close()
            con.Open()
            Dim cmdupdate As New MySqlCommand("UPDATE `f2_parts_scan` SET `status`='P', `wipreturns`=(`wipreturns`+ 1 )
            WHERE `qrcode`='" & qrcode & "'", con)
            cmdupdate.ExecuteNonQuery()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub update_scan_return_manual()
        Try
            con.Close()
            con.Open()
            Dim cmdupdate As New MySqlCommand("UPDATE `f2_parts_scan` SET `qty`='" & txt_qty.Text & "',`status`='P', `wipreturns`=(`wipreturns`+ 1 )
            WHERE `qrcode`='" & qrcode & "'", con)
            cmdupdate.ExecuteNonQuery()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
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


    Private Sub return_ok()
        Try
            labelerror.Visible = False
            txtqr.Clear()
            txtqr.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub

    Private Sub chck_manualqty_CheckedChanged(sender As Object, e As EventArgs) Handles chck_manualqty.CheckedChanged
        If chck_manualqty.Checked = True Then
            panelqty.Visible = True

        Else
            panelqty.Visible = False
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try


            Select Case status
                    Case "W"
                        con.Close()
                        con.Open()
                        Dim cmdpartcode As New MySqlCommand("SELECT `id` FROM `f2_parts_masterlist` WHERE `partcode`='" & partcode & "' and `supplier`= '" & supplier & "'", con)
                        dr = cmdpartcode.ExecuteReader
                        If dr.Read = True Then
                            Dim dataid As String = dr.GetInt32("id")
                            'SAVING
                            add_to_parts(Val(txt_qty.Text), dataid)
                            deduct_to_WIP(Val(txt_qty.Text), dataid)
                            update_scan_return_manual()
                            return_ok()
                        txt_displayqty.Clear()
                        txt_qty.Clear()
                    Else  'CON 3 : PARTCODE
                            showerror("No Partcode Exists!")
                        End If

                    Case "P"
                        'duplicate
                        showduplicate()
                        txtqr.Text = ""
                        txtqr.Focus()

                    Case "F"
                        showerror("INVALID! MARKED AS FG")
                        txtqr.Text = ""
                        txtqr.Focus()

                    Case "R"
                        showerror("INVALID! MARKED AS RETURNED TO SUPPLIER ITEM")
                        txtqr.Text = ""
                        txtqr.Focus()

                End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txt_qty_TextChanged(sender As Object, e As EventArgs) Handles txt_qty.TextChanged
        If Val(txt_qty.Text) > qty Then
            qty_error.Visible = True
        Else
            qty_error.Visible = False
        End If
    End Sub

    Private Sub txtqr_Invalidated(sender As Object, e As InvalidateEventArgs) Handles txtqr.Invalidated

    End Sub
End Class