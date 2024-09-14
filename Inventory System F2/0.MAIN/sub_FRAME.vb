Imports System
Public Class sub_FRAME

    Private Sub Scan_Frame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userstrip.Text = fname
    End Sub

    Private Sub PARTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PARTSToolStripMenuItem.Click
        display_formscan(Parts_In)
    End Sub

    Private Sub display_formscan(form As Form)
        With form
            .Refresh()
            .TopLevel = False
            Panel1.Controls.Add(form)
            .BringToFront()
            .Show()

        End With
    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        con.Close()
        Application.Exit()

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        display_form(Login)
        Login.txtbarcode.Clear()
        script_tool.Visible = False
        Panel1.Controls.Clear()
    End Sub

    Private Sub DeviceInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeviceInfoToolStripMenuItem.Click
        MessageBox.Show("SERVER:29 Device loc:" & PClocation & "   /  Mac:" & PCmac & "   /  Device:" & PCname & "")
    End Sub

    Private Sub SuggestToImproveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuggestToImproveToolStripMenuItem.Click
        suggest_improvent.Show()
        suggest_improvent.BringToFront()
    End Sub

    Private Sub RETURNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RETURNToolStripMenuItem.Click
        display_formscan(PARTS_Return)
    End Sub

    Private Sub QRCheckerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QRCheckerToolStripMenuItem.Click

    End Sub

    Private Sub QRCheckerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QRCheckerToolStripMenuItem1.Click
        display_formscan(QR_checker)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        display_formscan(WIP_In)
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        display_formscan(WIP_Return)
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        display_formscan(PROD_Setup)
    End Sub

    Private Sub SCANWIPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SCANWIPToolStripMenuItem.Click
        display_formscan(PROD_Scan)
    End Sub

    Private Sub SCANFGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SCANFGToolStripMenuItem.Click
        display_formscan(PROD_FG)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        display_formscan(FG_IN)
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        display_formscan(FG_out)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        display_formscan(FG_Return)
    End Sub

    Private Sub ManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem.Click
        display_formscan(Add_item)
    End Sub

    Private Sub StockMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockMonitoringToolStripMenuItem.Click
        display_formscan(stockmonitoring)
    End Sub

    Private Sub userstrip_Click(sender As Object, e As EventArgs) Handles userstrip.Click

    End Sub

    Private Sub CheckUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckUpdatesToolStripMenuItem.Click
        Try
            Dim setupPath As String = "\\ptif1-ds\SystemServer\Inventorysystem-F2\setup.exe"
            If System.IO.File.Exists(setupPath) Then
                Process.Start(setupPath)
                Application.Exit()
            Else
                MessageBox.Show("Update file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while trying to update: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PartsINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartsINToolStripMenuItem.Click
        display_formscan(parts_script)
    End Sub

    Private Sub WIPINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WIPINToolStripMenuItem.Click
        display_formscan(wip_In_script)
    End Sub

    Private Sub FGINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FGINToolStripMenuItem.Click
        display_formscan(fg_in_script)
    End Sub
End Class