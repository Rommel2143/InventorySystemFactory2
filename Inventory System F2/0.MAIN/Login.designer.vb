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
        Me.panel_admin = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.enable_admin = New Guna.UI2.WinForms.Guna2TextBox()
        Me.labelerror = New System.Windows.Forms.Label()
        Me.txtpclocation = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtbarcode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2PictureBox2 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lbl_pcinfo = New System.Windows.Forms.Label()
        Me.error_panel = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.Guna2PictureBox3 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lbl_error = New System.Windows.Forms.Label()
        Me.Guna2Panel1.SuspendLayout()
        Me.panel_admin.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.error_panel.SuspendLayout()
        CType(Me.Guna2PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.BorderRadius = 10
        Me.Guna2Panel1.Controls.Add(Me.error_panel)
        Me.Guna2Panel1.Controls.Add(Me.panel_admin)
        Me.Guna2Panel1.Controls.Add(Me.Guna2PictureBox2)
        Me.Guna2Panel1.Controls.Add(Me.lbl_pcinfo)
        Me.Guna2Panel1.Controls.Add(Me.Guna2PictureBox1)
        Me.Guna2Panel1.Controls.Add(Me.labelerror)
        Me.Guna2Panel1.Controls.Add(Me.txtpclocation)
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
        'panel_admin
        '
        Me.panel_admin.BackColor = System.Drawing.Color.Red
        Me.panel_admin.Controls.Add(Me.Guna2Button1)
        Me.panel_admin.Controls.Add(Me.enable_admin)
        Me.panel_admin.Location = New System.Drawing.Point(249, 303)
        Me.panel_admin.Name = "panel_admin"
        Me.panel_admin.Size = New System.Drawing.Size(306, 61)
        Me.panel_admin.TabIndex = 26
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
        Me.txtpclocation.Location = New System.Drawing.Point(370, 155)
        Me.txtpclocation.Name = "txtpclocation"
        Me.txtpclocation.Size = New System.Drawing.Size(36, 25)
        Me.txtpclocation.TabIndex = 5
        Me.txtpclocation.Text = "---"
        Me.txtpclocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(370, 130)
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
        Me.Label1.Location = New System.Drawing.Point(370, 100)
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
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Image = CType(resources.GetObject("Guna2PictureBox1.Image"), System.Drawing.Image)
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(230, 90)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(134, 80)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 27
        Me.Guna2PictureBox1.TabStop = False
        Me.Guna2PictureBox1.UseTransparentBackground = True
        '
        'Guna2PictureBox2
        '
        Me.Guna2PictureBox2.Image = CType(resources.GetObject("Guna2PictureBox2.Image"), System.Drawing.Image)
        Me.Guna2PictureBox2.ImageRotate = 0!
        Me.Guna2PictureBox2.Location = New System.Drawing.Point(375, 303)
        Me.Guna2PictureBox2.Name = "Guna2PictureBox2"
        Me.Guna2PictureBox2.Size = New System.Drawing.Size(39, 37)
        Me.Guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox2.TabIndex = 29
        Me.Guna2PictureBox2.TabStop = False
        '
        'lbl_pcinfo
        '
        Me.lbl_pcinfo.AutoSize = True
        Me.lbl_pcinfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pcinfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lbl_pcinfo.Location = New System.Drawing.Point(372, 343)
        Me.lbl_pcinfo.Name = "lbl_pcinfo"
        Me.lbl_pcinfo.Size = New System.Drawing.Size(19, 13)
        Me.lbl_pcinfo.TabIndex = 28
        Me.lbl_pcinfo.Text = "---"
        Me.lbl_pcinfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'error_panel
        '
        Me.error_panel.BorderRadius = 10
        Me.error_panel.Controls.Add(Me.Guna2PictureBox3)
        Me.error_panel.Controls.Add(Me.lbl_error)
        Me.error_panel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.error_panel.FillColor = System.Drawing.Color.Red
        Me.error_panel.FillColor2 = System.Drawing.Color.Salmon
        Me.error_panel.Location = New System.Drawing.Point(0, 441)
        Me.error_panel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.error_panel.Name = "error_panel"
        Me.error_panel.Size = New System.Drawing.Size(810, 43)
        Me.error_panel.TabIndex = 209
        Me.error_panel.Visible = False
        '
        'Guna2PictureBox3
        '
        Me.Guna2PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox3.Image = CType(resources.GetObject("Guna2PictureBox3.Image"), System.Drawing.Image)
        Me.Guna2PictureBox3.ImageRotate = 0!
        Me.Guna2PictureBox3.Location = New System.Drawing.Point(13, 9)
        Me.Guna2PictureBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Guna2PictureBox3.Name = "Guna2PictureBox3"
        Me.Guna2PictureBox3.Size = New System.Drawing.Size(23, 23)
        Me.Guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox3.TabIndex = 1
        Me.Guna2PictureBox3.TabStop = False
        '
        'lbl_error
        '
        Me.lbl_error.AutoSize = True
        Me.lbl_error.BackColor = System.Drawing.Color.Transparent
        Me.lbl_error.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_error.ForeColor = System.Drawing.Color.White
        Me.lbl_error.Location = New System.Drawing.Point(42, 13)
        Me.lbl_error.Name = "lbl_error"
        Me.lbl_error.Size = New System.Drawing.Size(119, 17)
        Me.lbl_error.TabIndex = 0
        Me.lbl_error.Text = "Invalid Credentials"
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
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.error_panel.ResumeLayout(False)
        Me.error_panel.PerformLayout()
        CType(Me.Guna2PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtbarcode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtpclocation As Label
    Friend WithEvents labelerror As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents enable_admin As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents panel_admin As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2PictureBox2 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lbl_pcinfo As Label
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents error_panel As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Guna2PictureBox3 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lbl_error As Label
End Class
