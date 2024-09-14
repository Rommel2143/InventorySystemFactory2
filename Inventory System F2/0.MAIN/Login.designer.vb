<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblversion = New System.Windows.Forms.Label()
        Me.labelerror = New System.Windows.Forms.Label()
        Me.txtpclocation = New System.Windows.Forms.Label()
        Me.txtpcmac = New System.Windows.Forms.Label()
        Me.txtpcname = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtbarcode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.enable_admin = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.panel_admin = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel1.SuspendLayout()
        Me.panel_admin.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.BorderRadius = 10
        Me.Guna2Panel1.Controls.Add(Me.panel_admin)
        Me.Guna2Panel1.Controls.Add(Me.lblversion)
        Me.Guna2Panel1.Controls.Add(Me.labelerror)
        Me.Guna2Panel1.Controls.Add(Me.txtpclocation)
        Me.Guna2Panel1.Controls.Add(Me.txtpcmac)
        Me.Guna2Panel1.Controls.Add(Me.txtpcname)
        Me.Guna2Panel1.Controls.Add(Me.Label2)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.txtbarcode)
        Me.Guna2Panel1.FillColor = System.Drawing.Color.White
        Me.Guna2Panel1.Location = New System.Drawing.Point(50, 42)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.ShadowDecoration.BorderRadius = 15
        Me.Guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.Silver
        Me.Guna2Panel1.ShadowDecoration.Enabled = True
        Me.Guna2Panel1.Size = New System.Drawing.Size(810, 484)
        Me.Guna2Panel1.TabIndex = 0
        '
        'lblversion
        '
        Me.lblversion.AutoSize = True
        Me.lblversion.Location = New System.Drawing.Point(729, 440)
        Me.lblversion.Name = "lblversion"
        Me.lblversion.Size = New System.Drawing.Size(16, 13)
        Me.lblversion.TabIndex = 23
        Me.lblversion.Text = "---"
        '
        'labelerror
        '
        Me.labelerror.AutoSize = True
        Me.labelerror.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelerror.ForeColor = System.Drawing.Color.Tomato
        Me.labelerror.Location = New System.Drawing.Point(267, 259)
        Me.labelerror.Name = "labelerror"
        Me.labelerror.Size = New System.Drawing.Size(106, 15)
        Me.labelerror.TabIndex = 22
        Me.labelerror.Text = "ID not Registered!"
        Me.labelerror.Visible = False
        '
        'txtpclocation
        '
        Me.txtpclocation.AutoSize = True
        Me.txtpclocation.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpclocation.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtpclocation.Location = New System.Drawing.Point(387, 156)
        Me.txtpclocation.Name = "txtpclocation"
        Me.txtpclocation.Size = New System.Drawing.Size(36, 25)
        Me.txtpclocation.TabIndex = 5
        Me.txtpclocation.Text = "---"
        Me.txtpclocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtpcmac
        '
        Me.txtpcmac.AutoSize = True
        Me.txtpcmac.Location = New System.Drawing.Point(17, 463)
        Me.txtpcmac.Name = "txtpcmac"
        Me.txtpcmac.Size = New System.Drawing.Size(16, 13)
        Me.txtpcmac.TabIndex = 4
        Me.txtpcmac.Text = "---"
        '
        'txtpcname
        '
        Me.txtpcname.AutoSize = True
        Me.txtpcname.Location = New System.Drawing.Point(17, 450)
        Me.txtpcname.Name = "txtpcname"
        Me.txtpcname.Size = New System.Drawing.Size(16, 13)
        Me.txtpcname.TabIndex = 3
        Me.txtpcname.Text = "---"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(324, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Inventory System"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(306, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Philippines TRC Inc."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtbarcode
        '
        Me.txtbarcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtbarcode.DefaultText = ""
        Me.txtbarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtbarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtbarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtbarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtbarcode.Enabled = False
        Me.txtbarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtbarcode.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtbarcode.IconLeft = CType(resources.GetObject("txtbarcode.IconLeft"), System.Drawing.Image)
        Me.txtbarcode.Location = New System.Drawing.Point(270, 216)
        Me.txtbarcode.Margin = New System.Windows.Forms.Padding(5)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtbarcode.PlaceholderText = ""
        Me.txtbarcode.SelectedText = ""
        Me.txtbarcode.Size = New System.Drawing.Size(270, 42)
        Me.txtbarcode.TabIndex = 0
        Me.txtbarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'enable_admin
        '
        Me.enable_admin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.enable_admin.DefaultText = ""
        Me.enable_admin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.enable_admin.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.enable_admin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.enable_admin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.enable_admin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.enable_admin.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enable_admin.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.enable_admin.IconLeft = CType(resources.GetObject("enable_admin.IconLeft"), System.Drawing.Image)
        Me.enable_admin.IconLeftSize = New System.Drawing.Size(30, 30)
        Me.enable_admin.Location = New System.Drawing.Point(5, 8)
        Me.enable_admin.Margin = New System.Windows.Forms.Padding(5)
        Me.enable_admin.Name = "enable_admin"
        Me.enable_admin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.enable_admin.PlaceholderText = ""
        Me.enable_admin.SelectedText = ""
        Me.enable_admin.Size = New System.Drawing.Size(192, 42)
        Me.enable_admin.TabIndex = 24
        Me.enable_admin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Button1
        '
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.FillColor = System.Drawing.SystemColors.HotTrack
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(205, 8)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(89, 45)
        Me.Guna2Button1.TabIndex = 25
        Me.Guna2Button1.Text = "Admin mode"
        '
        'panel_admin
        '
        Me.panel_admin.BackColor = System.Drawing.Color.Red
        Me.panel_admin.Controls.Add(Me.Guna2Button1)
        Me.panel_admin.Controls.Add(Me.enable_admin)
        Me.panel_admin.Location = New System.Drawing.Point(255, 277)
        Me.panel_admin.Name = "panel_admin"
        Me.panel_admin.Size = New System.Drawing.Size(306, 61)
        Me.panel_admin.TabIndex = 26
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 572)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.panel_admin.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtbarcode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtpcmac As Label
    Friend WithEvents txtpcname As Label
    Friend WithEvents txtpclocation As Label
    Friend WithEvents labelerror As Label
    Friend WithEvents lblversion As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents enable_admin As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents panel_admin As Guna.UI2.WinForms.Guna2Panel
End Class
