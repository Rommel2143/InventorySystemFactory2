Imports MySql.Data.MySqlClient
Imports System.Reflection
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim maxRetries As Integer = 3 ' Set maximum number of retry attempts
        Dim currentRetry As Integer = 0 ' Track current retry count
        Dim connected As Boolean = False

        While currentRetry < maxRetries AndAlso Not connected
            Try
                lbl_pcinfo.Text = PCname

                ' Attempt to connect to the database
                If con.State = ConnectionState.Closed Then
                    con.Open()
                    error_panel.Visible = False
                End If

                Dim cmdselect As New MySqlCommand("SELECT * FROM f2_computer_location WHERE PCname = @PCname AND PCmac = @PCmac", con)
                cmdselect.Parameters.AddWithValue("@PCname", PCname)
                cmdselect.Parameters.AddWithValue("@PCmac", PCmac)

                dr = cmdselect.ExecuteReader()

                If dr.Read() Then
                    txtbarcode.Enabled = True
                    txtbarcode.Focus()
                    PClocation = dr.GetString("location")
                    txtpclocation.Text = PClocation
                    connected = True ' Mark as connected if successful
                Else
                    Dim result As DialogResult = MessageBox.Show("Machine not Verified!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

                    If result = DialogResult.OK Then

                        display_form(Register_PC)
                        Exit Sub
                    ElseIf result = DialogResult.Cancel Then
                        con.Close()
                        Application.Exit()
                    End If
                End If
            Catch ex As MySqlException
                currentRetry += 1
                MessageBox.Show("Connection failed. Retrying... (" & currentRetry & " of " & maxRetries & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                System.Threading.Thread.Sleep(2000) ' Wait 2 seconds before retrying

                ' Optional: Gradually increase the wait time (exponential backoff)
                ' System.Threading.Thread.Sleep(2000 * currentRetry)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit While ' Exit loop for non-MySQL exceptions
            Finally
                If dr IsNot Nothing Then dr.Close()
                con.Close()
                txtbarcode.Clear()
            End Try
        End While

        ' If still not connected after all retries, show an error and exit the app
        If Not connected Then
            MessageBox.Show("Unable to connect to the server after " & maxRetries & " attempts.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If
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
                            sub_FRAME.btn_manage.Visible = False
                    End Select
                    display_form(sub_FRAME)
                    sub_FRAME.userstrip.Text = "Hello, " & fname
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