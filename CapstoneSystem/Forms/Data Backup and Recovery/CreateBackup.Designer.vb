<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateBackup
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
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Label1 = New Label()
        Label2 = New Label()
        PinTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        ConfirmButton = New Guna.UI2.WinForms.Guna2Button()
        ShadowButton = New Guna.UI2.WinForms.Guna2Button()
        BackUpNameTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Inter Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(163, 24)
        Label1.TabIndex = 0
        Label1.Text = "Create Backup"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(18, 132)
        Label2.Name = "Label2"
        Label2.Size = New Size(84, 21)
        Label2.TabIndex = 0
        Label2.Text = "User PIN"
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
        PinTextBox.Font = New Font("Inter", 10.7999992F)
        PinTextBox.ForeColor = Color.Black
        PinTextBox.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        PinTextBox.IconRight = My.Resources.Resources.Hide
        PinTextBox.IconRightOffset = New Point(10, 0)
        PinTextBox.Location = New Point(158, 121)
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
        PinTextBox.Size = New Size(259, 40)
        PinTextBox.TabIndex = 2
        PinTextBox.TextOffset = New Point(10, 0)
        PinTextBox.UseSystemPasswordChar = True
        ' 
        ' ConfirmButton
        ' 
        ConfirmButton.Animated = True
        ConfirmButton.BackColor = Color.Transparent
        ConfirmButton.BorderRadius = 8
        ConfirmButton.Cursor = Cursors.Hand
        ConfirmButton.CustomizableEdges = CustomizableEdges3
        ConfirmButton.DisabledState.BorderColor = Color.DarkGray
        ConfirmButton.DisabledState.CustomBorderColor = Color.DarkGray
        ConfirmButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ConfirmButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ConfirmButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        ConfirmButton.Font = New Font("Inter", 10.7999992F)
        ConfirmButton.ForeColor = Color.White
        ConfirmButton.Location = New Point(228, 183)
        ConfirmButton.Name = "ConfirmButton"
        ConfirmButton.ShadowDecoration.BorderRadius = 8
        ConfirmButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        ConfirmButton.ShadowDecoration.Depth = 100
        ConfirmButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ConfirmButton.Size = New Size(188, 40)
        ConfirmButton.TabIndex = 4
        ConfirmButton.Text = "Confirm"
        ' 
        ' ShadowButton
        ' 
        ShadowButton.Animated = True
        ShadowButton.BackColor = Color.Transparent
        ShadowButton.BorderRadius = 8
        ShadowButton.Cursor = Cursors.Hand
        ShadowButton.CustomizableEdges = CustomizableEdges5
        ShadowButton.DisabledState.BorderColor = Color.DarkGray
        ShadowButton.DisabledState.CustomBorderColor = Color.DarkGray
        ShadowButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ShadowButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ShadowButton.FillColor = Color.FromArgb(CByte(28), CByte(28), CByte(30))
        ShadowButton.Font = New Font("Inter", 10.7999992F)
        ShadowButton.ForeColor = Color.White
        ShadowButton.Location = New Point(16, 183)
        ShadowButton.Name = "ShadowButton"
        ShadowButton.ShadowDecoration.BorderRadius = 8
        ShadowButton.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        ShadowButton.ShadowDecoration.Depth = 100
        ShadowButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ShadowButton.Size = New Size(206, 40)
        ShadowButton.TabIndex = 3
        ShadowButton.Text = "Cancel"
        ' 
        ' BackUpNameTextBox
        ' 
        BackUpNameTextBox.BackColor = Color.Transparent
        BackUpNameTextBox.BorderColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        BackUpNameTextBox.BorderRadius = 8
        BackUpNameTextBox.CustomizableEdges = CustomizableEdges1
        BackUpNameTextBox.DefaultText = ""
        BackUpNameTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        BackUpNameTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        BackUpNameTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        BackUpNameTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        BackUpNameTextBox.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        BackUpNameTextBox.FocusedState.BorderColor = Color.Black
        BackUpNameTextBox.Font = New Font("Inter", 10.7999992F)
        BackUpNameTextBox.ForeColor = Color.Black
        BackUpNameTextBox.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        BackUpNameTextBox.Location = New Point(157, 69)
        BackUpNameTextBox.Margin = New Padding(8, 6, 8, 6)
        BackUpNameTextBox.Name = "BackUpNameTextBox"
        BackUpNameTextBox.PasswordChar = ChrW(0)
        BackUpNameTextBox.PlaceholderForeColor = Color.FromArgb(CByte(174), CByte(174), CByte(178))
        BackUpNameTextBox.PlaceholderText = "Backup File Name"
        BackUpNameTextBox.SelectedText = ""
        BackUpNameTextBox.ShadowDecoration.BorderRadius = 8
        BackUpNameTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        BackUpNameTextBox.ShadowDecoration.Depth = 255
        BackUpNameTextBox.ShadowDecoration.Enabled = True
        BackUpNameTextBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 3)
        BackUpNameTextBox.Size = New Size(259, 40)
        BackUpNameTextBox.TabIndex = 1
        BackUpNameTextBox.TextOffset = New Point(10, 0)
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(18, 79)
        Label3.Name = "Label3"
        Label3.Size = New Size(128, 21)
        Label3.TabIndex = 0
        Label3.Text = "Backup Name"
        ' 
        ' CreateBackup
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(446, 246)
        Controls.Add(BackUpNameTextBox)
        Controls.Add(Label3)
        Controls.Add(ConfirmButton)
        Controls.Add(ShadowButton)
        Controls.Add(PinTextBox)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "CreateBackup"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CreateBackup"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PinTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents ConfirmButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ShadowButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BackUpNameTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
End Class
