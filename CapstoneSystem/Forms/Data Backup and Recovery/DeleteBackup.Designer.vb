<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeleteBackup
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
        components = New ComponentModel.Container()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        ConfirmButton = New Guna.UI2.WinForms.Guna2Button()
        ShadowButton = New Guna.UI2.WinForms.Guna2Button()
        Label1 = New Label()
        PinTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        Label3 = New Label()
        EmailTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        Label6 = New Label()
        CodeTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        Label5 = New Label()
        GetCodeButton = New Guna.UI2.WinForms.Guna2Button()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' ConfirmButton
        ' 
        ConfirmButton.BackColor = Color.Transparent
        ConfirmButton.BorderRadius = 8
        ConfirmButton.Cursor = Cursors.Hand
        ConfirmButton.CustomizableEdges = CustomizableEdges9
        ConfirmButton.DisabledState.BorderColor = Color.DarkGray
        ConfirmButton.DisabledState.CustomBorderColor = Color.DarkGray
        ConfirmButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ConfirmButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ConfirmButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        ConfirmButton.Font = New Font("Inter", 10.7999992F)
        ConfirmButton.ForeColor = Color.White
        ConfirmButton.Location = New Point(250, 242)
        ConfirmButton.Name = "ConfirmButton"
        ConfirmButton.ShadowDecoration.BorderRadius = 8
        ConfirmButton.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        ConfirmButton.ShadowDecoration.Depth = 100
        ConfirmButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ConfirmButton.Size = New Size(238, 40)
        ConfirmButton.TabIndex = 4
        ConfirmButton.Text = "Confirm"
        ' 
        ' ShadowButton
        ' 
        ShadowButton.BackColor = Color.Transparent
        ShadowButton.BorderRadius = 8
        ShadowButton.Cursor = Cursors.Hand
        ShadowButton.CustomizableEdges = CustomizableEdges11
        ShadowButton.DisabledState.BorderColor = Color.DarkGray
        ShadowButton.DisabledState.CustomBorderColor = Color.DarkGray
        ShadowButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ShadowButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ShadowButton.FillColor = Color.FromArgb(CByte(28), CByte(28), CByte(30))
        ShadowButton.Font = New Font("Inter", 10.7999992F)
        ShadowButton.ForeColor = Color.White
        ShadowButton.Location = New Point(20, 242)
        ShadowButton.Name = "ShadowButton"
        ShadowButton.ShadowDecoration.BorderRadius = 8
        ShadowButton.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        ShadowButton.ShadowDecoration.Depth = 100
        ShadowButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ShadowButton.Size = New Size(224, 40)
        ShadowButton.TabIndex = 3
        ShadowButton.Text = "Cancel"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Inter Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(160, 24)
        Label1.TabIndex = 0
        Label1.Text = "Delete Backup"
        ' 
        ' PinTextBox
        ' 
        PinTextBox.BackColor = Color.Transparent
        PinTextBox.BorderColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        PinTextBox.BorderRadius = 8
        PinTextBox.CustomizableEdges = CustomizableEdges7
        PinTextBox.DefaultText = ""
        PinTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        PinTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        PinTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        PinTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        PinTextBox.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        PinTextBox.FocusedState.BorderColor = Color.Black
        PinTextBox.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PinTextBox.ForeColor = Color.Black
        PinTextBox.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        PinTextBox.IconRight = My.Resources.Resources.Hide
        PinTextBox.IconRightOffset = New Point(10, 0)
        PinTextBox.Location = New Point(163, 73)
        PinTextBox.Margin = New Padding(8, 6, 8, 6)
        PinTextBox.Name = "PinTextBox"
        PinTextBox.PasswordChar = "●"c
        PinTextBox.PlaceholderForeColor = Color.FromArgb(CByte(174), CByte(174), CByte(178))
        PinTextBox.PlaceholderText = "Enter PIN"
        PinTextBox.SelectedText = ""
        PinTextBox.ShadowDecoration.BorderRadius = 8
        PinTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        PinTextBox.ShadowDecoration.Depth = 255
        PinTextBox.ShadowDecoration.Enabled = True
        PinTextBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 3)
        PinTextBox.Size = New Size(325, 40)
        PinTextBox.TabIndex = 2
        PinTextBox.TextOffset = New Point(10, 0)
        PinTextBox.UseSystemPasswordChar = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(20, 82)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 21)
        Label3.TabIndex = 0
        Label3.Text = "User PIN"
        ' 
        ' EmailTextBox
        ' 
        EmailTextBox.BackColor = Color.Transparent
        EmailTextBox.BorderColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        EmailTextBox.BorderRadius = 8
        EmailTextBox.CustomizableEdges = CustomizableEdges5
        EmailTextBox.DefaultText = "marginbusinessemail@gmail.com"
        EmailTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        EmailTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        EmailTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        EmailTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        EmailTextBox.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        EmailTextBox.FocusedState.BorderColor = Color.Black
        EmailTextBox.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        EmailTextBox.ForeColor = Color.Black
        EmailTextBox.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        EmailTextBox.Location = New Point(163, 125)
        EmailTextBox.Margin = New Padding(8, 6, 8, 6)
        EmailTextBox.Name = "EmailTextBox"
        EmailTextBox.PasswordChar = ChrW(0)
        EmailTextBox.PlaceholderForeColor = Color.FromArgb(CByte(174), CByte(174), CByte(178))
        EmailTextBox.PlaceholderText = "marginbusinessemail"
        EmailTextBox.ReadOnly = True
        EmailTextBox.SelectedText = ""
        EmailTextBox.ShadowDecoration.BorderRadius = 8
        EmailTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        EmailTextBox.ShadowDecoration.Depth = 255
        EmailTextBox.ShadowDecoration.Enabled = True
        EmailTextBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 3)
        EmailTextBox.Size = New Size(325, 40)
        EmailTextBox.TabIndex = 6
        EmailTextBox.TextOffset = New Point(10, 0)
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(20, 134)
        Label6.Name = "Label6"
        Label6.Size = New Size(55, 21)
        Label6.TabIndex = 5
        Label6.Text = "Email"
        ' 
        ' CodeTextBox
        ' 
        CodeTextBox.BackColor = Color.Transparent
        CodeTextBox.BorderColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        CodeTextBox.BorderRadius = 8
        CodeTextBox.CustomizableEdges = CustomizableEdges3
        CodeTextBox.DefaultText = ""
        CodeTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        CodeTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        CodeTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        CodeTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        CodeTextBox.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        CodeTextBox.FocusedState.BorderColor = Color.Black
        CodeTextBox.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CodeTextBox.ForeColor = Color.Black
        CodeTextBox.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        CodeTextBox.Location = New Point(163, 177)
        CodeTextBox.Margin = New Padding(8, 6, 8, 6)
        CodeTextBox.Name = "CodeTextBox"
        CodeTextBox.PasswordChar = ChrW(0)
        CodeTextBox.PlaceholderForeColor = Color.FromArgb(CByte(174), CByte(174), CByte(178))
        CodeTextBox.PlaceholderText = "****"
        CodeTextBox.SelectedText = ""
        CodeTextBox.ShadowDecoration.BorderRadius = 8
        CodeTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        CodeTextBox.ShadowDecoration.Depth = 255
        CodeTextBox.ShadowDecoration.Enabled = True
        CodeTextBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 3)
        CodeTextBox.Size = New Size(175, 40)
        CodeTextBox.TabIndex = 8
        CodeTextBox.TextOffset = New Point(10, 0)
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(20, 187)
        Label5.Name = "Label5"
        Label5.Size = New Size(129, 21)
        Label5.TabIndex = 7
        Label5.Text = "Request Code"
        ' 
        ' GetCodeButton
        ' 
        GetCodeButton.Animated = True
        GetCodeButton.BackColor = Color.Transparent
        GetCodeButton.BorderRadius = 8
        GetCodeButton.Cursor = Cursors.Hand
        GetCodeButton.CustomizableEdges = CustomizableEdges1
        GetCodeButton.DisabledState.BorderColor = Color.DarkGray
        GetCodeButton.DisabledState.CustomBorderColor = Color.DarkGray
        GetCodeButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        GetCodeButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        GetCodeButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        GetCodeButton.Font = New Font("Inter", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GetCodeButton.ForeColor = Color.White
        GetCodeButton.Location = New Point(349, 179)
        GetCodeButton.Name = "GetCodeButton"
        GetCodeButton.ShadowDecoration.BorderRadius = 8
        GetCodeButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        GetCodeButton.ShadowDecoration.Depth = 100
        GetCodeButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        GetCodeButton.Size = New Size(139, 40)
        GetCodeButton.TabIndex = 9
        GetCodeButton.Text = "Get Code"
        ' 
        ' DeleteBackup
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(510, 310)
        Controls.Add(GetCodeButton)
        Controls.Add(CodeTextBox)
        Controls.Add(Label5)
        Controls.Add(EmailTextBox)
        Controls.Add(Label6)
        Controls.Add(PinTextBox)
        Controls.Add(Label3)
        Controls.Add(ConfirmButton)
        Controls.Add(ShadowButton)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "DeleteBackup"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ImportBackup"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents PinTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ConfirmButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ShadowButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents EmailTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CodeTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GetCodeButton As Guna.UI2.WinForms.Guna2Button
End Class
