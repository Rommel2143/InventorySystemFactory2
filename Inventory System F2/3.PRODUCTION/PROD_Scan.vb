Imports MySql.Data.MySqlClient
Public Class PROD_Scan
    Dim selectedfg As String
    Private Sub PROD_Scan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdate.Text = date1
        lbl_shift.Text = shift1
    End Sub

    Private Sub cmbline_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbline.SelectedIndexChanged
        Try
            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("SELECT t.`fgcode`, m.`partname` FROM `f2_fg_traceability` t 
                                                        INNER JOIN `f2_fg_masterlist` m ON t.`fgcode`= m.`partcode`
                                                        WHERE t.`date1`='" & datedb & "' and t.`shift`='" & shift1 & "' and t.`line`='" & cmbline.Text & "'
                                                         GROUP BY m.`partcode`", con)
            dr = cmdselect.ExecuteReader
            cmb_fgcode.Items.Clear()
            While (dr.Read())
                ' Concatenate partcode and partname into a single string
                Dim combinedString As String = dr.GetString("fgcode") & "-" & dr.GetString("partname")
                ' Add the combined string to the ComboBox
                cmb_fgcode.Items.Add(combinedString)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmb_fgcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_fgcode.SelectedIndexChanged
        Try
            If cmb_fgcode.SelectedIndex <> -1 Then
                ' Split the selected item by the hyphen separator
                Dim selectedParts() As String = cmb_fgcode.SelectedItem.ToString().Split("-"c)
                ' Display only the partcode
                If selectedParts.Length > 0 Then
                    selectedfg = (selectedParts(0)) ' Display partcode
                    con.Close()
                    con.Open()
                    Dim cmdselect As New MySqlCommand("SELECT distinct `datacode` FROM `f2_fg_traceability`
                                                        WHERE `date1`='" & datedb & "' and `shift`='" & shift1 & "' and `line`='" & cmbline.Text & "' and `fgcode`='" & selectedfg & "'", con)
                    dr = cmdselect.ExecuteReader
                    cmb_data.Items.Clear()
                    While (dr.Read())
                        cmb_data.Items.Add(dr.GetString("datacode"))
                    End While

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub refreshgrid()
        Try
            con.Close()
            con.Open()
            Dim cmdrefreshgrid As New MySqlCommand("SELECT t.`id`, t.`partcode`,m.`partname`, t.`qtyused`, t.`partqr`,t.`suppliercode` FROM `f2_fg_traceability` t
                                                    INNER JOIN `f2_parts_masterlist` m ON m.`partcode`=t.`partcode`
                                                     WHERE `date1`='" & datedb & "' and `shift`='" & shift1 & "' and `line`='" & cmbline.Text & "' and `fgcode`='" & selectedfg & "' and `datacode`='" & cmb_data.Text & "'", con)

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

    Private Sub cmb_data_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_data.SelectedIndexChanged
        refreshgrid()
    End Sub

    Private Sub datagrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellContentClick

    End Sub
End Class