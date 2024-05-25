<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WIP_Return
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WIP_Return))
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtdate = New System.Windows.Forms.Label()
        Me.labelerror = New Guna.UI2.WinForms.Guna2Panel()
        Me.texterror = New System.Windows.Forms.Label()
        Me.txtqr = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.panelqty = New Guna.UI2.WinForms.Guna2Panel()
        Me.txt_displayqty = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_save = New Guna.UI2.WinForms.Guna2Button()
        Me.qty_error = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_qty = New Guna.UI2.WinForms.Guna2TextBox()
        Me.chck_manualqty = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.labelerror.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.panelqty.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.BackColor = System.Drawing.Color.CadetBlue
        Me.Guna2Panel2.Controls.Add(Me.PictureBox1)
        Me.Guna2Panel2.Controls.Add(Me.Label10)
        Me.Guna2Panel2.Controls.Add(Me.txtdate)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1264, 20)
        Me.Guna2Panel2.TabIndex = 205
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1116, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 205
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 21)
        Me.Label10.TabIndex = 204
        Me.Label10.Text = "SCAN RETURN"
        '
        'txtdate
        '
        Me.txtdate.AutoSize = True
        Me.txtdate.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtdate.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdate.ForeColor = System.Drawing.Color.White
        Me.txtdate.Location = New System.Drawing.Point(1137, 0)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.Size = New System.Drawing.Size(127, 20)
        Me.txtdate.TabIndex = 1
        Me.txtdate.Text = "MMMM-dd-yyyy"
        Me.txtdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelerror
        '
        Me.labelerror.BackColor = System.Drawing.Color.Tomato
        Me.labelerror.Controls.Add(Me.texterror)
        Me.labelerror.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.labelerror.Location = New System.Drawing.Point(0, 291)
        Me.labelerror.Name = "labelerror"
        Me.labelerror.Size = New System.Drawing.Size(509, 19)
        Me.labelerror.TabIndex = 202
        Me.labelerror.Visible = False
        '
        'texterror
        '
        Me.texterror.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.texterror.AutoSize = True
        Me.texterror.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.texterror.ForeColor = System.Drawing.Color.White
        Me.texterror.Location = New System.Drawing.Point(217, -1)
        Me.texterror.Name = "texterror"
        Me.texterror.Size = New System.Drawing.Size(74, 21)
        Me.texterror.TabIndex = 203
        Me.texterror.Text = "INVALID"
        '
        'txtqr
        '
        Me.txtqr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtqr.DefaultText = ""
        Me.txtqr.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtqr.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtqr.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtqr.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtqr.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtqr.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtqr.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtqr.IconLeft = CType(resources.GetObject("txtqr.IconLeft"), System.Drawing.Image)
        Me.txtqr.Location = New System.Drawing.Point(64, 104)
        Me.txtqr.Name = "txtqr"
        Me.txtqr.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtqr.PlaceholderText = "Scan QR..."
        Me.txtqr.SelectedText = ""
        Me.txtqr.Size = New System.Drawing.Size(389, 36)
        Me.txtqr.TabIndex = 1
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.BorderRadius = 15
        Me.Guna2Panel1.Controls.Add(Me.panelqty)
        Me.Guna2Panel1.Controls.Add(Me.chck_manualqty)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.txtqr)
        Me.Guna2Panel1.Controls.Add(Me.labelerror)
        Me.Guna2Panel1.FillColor = System.Drawing.Color.White
        Me.Guna2Panel1.Location = New System.Drawing.Point(378, 167)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.ShadowDecoration.BorderRadius = 20
        Me.Guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.Silver
        Me.Guna2Panel1.ShadowDecoration.Enabled = True
        Me.Guna2Panel1.Size = New System.Drawing.Size(509, 310)
        Me.Guna2Panel1.TabIndex = 206
        Me.Guna2Panel1.TabStop = True
        '
        'panelqty
        '
        Me.panelqty.Controls.Add(Me.txt_displayqty)
        Me.panelqty.Controls.Add(Me.btn_save)
        Me.panelqty.Controls.Add(Me.qty_error)
        Me.panelqty.Controls.Add(Me.Label3)
        Me.panelqty.Controls.Add(Me.txt_qty)
        Me.panelqty.Location = New System.Drawing.Point(44, 149)
        Me.panelqty.Name = "panelqty"
        Me.panelqty.Size = New System.Drawing.Size(421, 136)
        Me.panelqty.TabIndex = 210
        Me.panelqty.Visible = False
        '
        'txt_displayqty
        '
        Me.txt_displayqty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_displayqty.DefaultText = ""
        Me.txt_displayqty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_displayqty.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_displayqty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_displayqty.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_displayqty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_displayqty.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_displayqty.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_displayqty.Location = New System.Drawing.Point(62, 8)
        Me.txt_displayqty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_displayqty.Name = "txt_displayqty"
        Me.txt_displayqty.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_displayqty.PlaceholderText = "Quantity..."
        Me.txt_displayqty.ReadOnly = True
        Me.txt_displayqty.SelectedText = ""
        Me.txt_displayqty.Size = New System.Drawing.Size(99, 35)
        Me.txt_displayqty.TabIndex = 209
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Animated = True
        Me.btn_save.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_save.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_save.FillColor = System.Drawing.Color.DodgerBlue
        Me.btn_save.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_save.ForeColor = System.Drawing.Color.White
        Me.btn_save.Image = CType(resources.GetObject("btn_save.Image"), System.Drawing.Image)
        Me.btn_save.Location = New System.Drawing.Point(144, 76)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(132, 37)
        Me.btn_save.TabIndex = 206
        Me.btn_save.Text = "Return Remaining"
        '
        'qty_error
        '
        Me.qty_error.AutoSize = True
        Me.qty_error.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qty_error.ForeColor = System.Drawing.Color.Tomato
        Me.qty_error.Location = New System.Drawing.Point(65, 47)
        Me.qty_error.Name = "qty_error"
        Me.qty_error.Size = New System.Drawing.Size(184, 15)
        Me.qty_error.TabIndex = 208
        Me.qty_error.Text = "Value must be less than its QTY!"
        Me.qty_error.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "QTY :"
        '
        'txt_qty
        '
        Me.txt_qty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_qty.DefaultText = ""
        Me.txt_qty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_qty.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_qty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_qty.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_qty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_qty.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qty.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_qty.Location = New System.Drawing.Point(169, 7)
        Me.txt_qty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_qty.Name = "txt_qty"
        Me.txt_qty.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_qty.PlaceholderText = "Remaining..."
        Me.txt_qty.SelectedText = ""
        Me.txt_qty.Size = New System.Drawing.Size(146, 36)
        Me.txt_qty.TabIndex = 204
        '
        'chck_manualqty
        '
        Me.chck_manualqty.AutoSize = True
        Me.chck_manualqty.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chck_manualqty.CheckedState.BorderRadius = 0
        Me.chck_manualqty.CheckedState.BorderThickness = 0
        Me.chck_manualqty.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chck_manualqty.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.chck_manualqty.Location = New System.Drawing.Point(64, 74)
        Me.chck_manualqty.Name = "chck_manualqty"
        Me.chck_manualqty.Size = New System.Drawing.Size(111, 24)
        Me.chck_manualqty.TabIndex = 205
        Me.chck_manualqty.Text = "Manual QTY"
        Me.chck_manualqty.UncheckedState.BorderColor = System.Drawing.Color.DimGray
        Me.chck_manualqty.UncheckedState.BorderRadius = 3
        Me.chck_manualqty.UncheckedState.BorderThickness = 1
        Me.chck_manualqty.UncheckedState.FillColor = System.Drawing.Color.White
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(114, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 32)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = "SCAN RETURNABLE WIP"
        '
        'WIP_Return
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1264, 644)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WIP_Return"
        Me.Text = "Scan_return"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.labelerror.ResumeLayout(False)
        Me.labelerror.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.panelqty.ResumeLayout(False)
        Me.panelqty.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtdate As Label
    Friend WithEvents labelerror As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents texterror As Label
    Friend WithEvents txtqr As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_qty As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents chck_manualqty As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents btn_save As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_displayqty As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents qty_error As Label
    Friend WithEvents panelqty As Guna.UI2.WinForms.Guna2Panel
End Class
