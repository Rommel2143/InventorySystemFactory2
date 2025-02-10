﻿Imports MySql.Data.MySqlClient
Public Class Add_item
    Dim qrcode As String
    Dim partcode As String
    Dim supplier As String
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Try
            If P_partcode.Text = "" And P_Partname.Text = "" Then
                MessageBox.Show("All Fields Required!")
            Else
                con.Close()
                con.Open()
                Dim cmdinsert As New MySqlCommand(" INSERT INTO `f2_parts_masterlist`
(`partname`, `partcode`, `supplier`, `stockf2`, `wipstockf2`) 
VALUES ('" & P_Partname.Text & "','" & P_partcode.Text & "','" & P_supplier.Text & "','0','0')", con)
                cmdinsert.ExecuteNonQuery()
                MessageBox.Show("Partcode Added successfully!")
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub processQRcode(qrcode As String)
        Try

            Dim parts() As String = qrcode.Split("|")

            'CON 1 : QR SPLITING
            If parts.Length >= 5 AndAlso parts.Length <= 8 Then
                partcode = parts(0).Remove(0, 2).Trim

                supplier = parts(1).Remove(0, 2).Trim

            Else  'CON 1 : QR SPLITING
                MessageBox.Show("Invalid QR!")
                con.Close()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub




    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If fgcode.Text = "" And fg_partname.Text = "" Then
            MessageBox.Show("All Fields Required!")
        Else


            Try

                con.Close()
                con.Open()
                Dim cmdinsert As New MySqlCommand(" INSERT INTO `f2_fg_masterlist`
(`partname`, `partcode`, `stockf2`) 
VALUES ('" & fg_partname.Text & "','" & fgcode.Text & "','0')", con)
                cmdinsert.ExecuteNonQuery()
                MessageBox.Show("FG Added successfully!")
                con.Close()
                fgcode.Clear()
                fg_partname.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub Guna2TextBox2_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Try

            con.Close()
            con.Open()
            Dim cmdinsert As New MySqlCommand(" INSERT INTO `f2_scanoperator_is`(`IDno`, `Fullname`, `status`) VALUES ('" & idno.Text & "','" & fname.Text & "',0)", con)
            cmdinsert.ExecuteNonQuery()
            MessageBox.Show("USER Added successfully!")
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub fg_txtqr_TextChanged(sender As Object, e As EventArgs)

    End Sub





    Private Sub Guna2GroupBox1_Click(sender As Object, e As EventArgs) Handles Guna2GroupBox1.Click

    End Sub
End Class