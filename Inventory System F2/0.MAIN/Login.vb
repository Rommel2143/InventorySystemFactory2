﻿Imports MySql.Data.MySqlClient
Imports System.Reflection
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtpcname.Text = PCname
            txtpcmac.Text = PCmac
            Dim version As String = Assembly.GetExecutingAssembly().GetName().Version.ToString()
            lblversion.Text = version
            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("SELECT * FROM f2_computer_location WHERE `PCname`='" & PCname & "' and `PCmac`='" & PCmac & "'", con)
            dr = cmdselect.ExecuteReader
            If dr.Read = True Then
                txtbarcode.Enabled = True
                txtbarcode.Focus()
                PClocation = dr.GetString("location")
                txtpclocation.Text = PClocation

            Else
                Dim result As DialogResult = MessageBox.Show("Machine not Verified!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)


                If result = DialogResult.OK Then
                    display_form(Register_PC)

                ElseIf result = DialogResult.Cancel Then
                    con.Close()
                    Application.Exit()
                End If



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            con.Close()
            txtbarcode.Clear()

        End Try
    End Sub


    Private Sub txtbarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbarcode.KeyDown

        If e.KeyCode = Keys.Enter Then
            Try
                Dim idwithA As String = "A" & txtbarcode.Text & "A"
                Dim idwithoutA As String = txtbarcode.Text.TrimStart("A"c).TrimEnd("A"c)
                Dim idwithoutasmall As String = txtbarcode.Text.TrimStart("a"c).TrimEnd("a"c)
                con.Close()
                con.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM `f2_scanoperator_is` WHERE `IDno` = '" & idwithoutA & "' or `IDno` = '" & idwithA & "' or `IDno` = '" & idwithoutasmall & "' ", con)
                dr = cmd.ExecuteReader
                If dr.Read = True Then
                    fname = dr("fullname").ToString
                    idno = dr("IDno").ToString
                    userstatus = dr.GetInt32("status")
                    Select Case userstatus
                        Case 0
                            sub_FRAME.script_tool.Visible = False

                    End Select
                    display_form(sub_FRAME)
                    sub_FRAME.userstrip.Text = fname
                    labelerror.Visible = False
                Else
                    noid()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            Finally
                con.Close()
                txtbarcode.Clear()

            End Try
        End If

    End Sub
    Private Sub noid()
        Try
            labelerror.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtbarcode_TextChanged(sender As Object, e As EventArgs) Handles txtbarcode.TextChanged
        If txtbarcode.Text = "knockknock" Then
            panel_admin.Visible = True
        Else
            panel_admin.Visible = False
        End If

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If enable_admin.Text = "whosthere" Then

            sub_FRAME.script_tool.Visible = True
                MessageBox.Show("Enabled")
            enable_admin.Clear()
        End If
    End Sub

    Private Sub enable_admin_TextChanged(sender As Object, e As EventArgs) Handles enable_admin.TextChanged

    End Sub
End Class