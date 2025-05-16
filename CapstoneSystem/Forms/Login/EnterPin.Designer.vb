<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnterPin
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
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Label3 = New Label()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        UsernameLabel = New Label()
        Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        PinTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        ShadowButton = New Guna.UI2.WinForms.Guna2Button()
        ConfirmButton = New Guna.UI2.WinForms.Guna2Button()
        Guna2Panel1.SuspendLayout()
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Inter Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(20, 26)
        Label3.Name = "Label3"
        Label3.Size = New Size(270, 28)
        Label3.TabIndex = 4
        Label3.Text = "Enter your secret PIN"
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.Controls.Add(UsernameLabel)
        Guna2Panel1.Controls.Add(Guna2PictureBox1)
        Guna2Panel1.CustomizableEdges = CustomizableEdges9
        Guna2Panel1.Location = New Point(20, 74)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        Guna2Panel1.Size = New Size(462, 72)
        Guna2Panel1.TabIndex = 5
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.AutoSize = True
        UsernameLabel.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        UsernameLabel.Location = New Point(172, 25)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(155, 24)
        UsernameLabel.TabIndex = 5
        UsernameLabel.Text = "Juan Dela Cruz"
        ' 
        ' Guna2PictureBox1
        ' 
        Guna2PictureBox1.CustomizableEdges = CustomizableEdges7
        Guna2PictureBox1.Image = My.Resources.Resources.User
        Guna2PictureBox1.ImageRotate = 0F
        Guna2PictureBox1.Location = New Point(135, 24)
        Guna2PictureBox1.Name = "Guna2PictureBox1"
        Guna2PictureBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2PictureBox1.Size = New Size(25, 25)
        Guna2PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        Guna2PictureBox1.TabIndex = 0
        Guna2PictureBox1.TabStop = False
        ' 
        ' PinTextBox
        ' 
        PinTextBox.BorderColor = Color.Black
        PinTextBox.BorderRadius = 8
        PinTextBox.CustomizableEdges = CustomizableEdges5
        PinTextBox.DefaultText = ""
        PinTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        PinTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        PinTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        PinTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        PinTextBox.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        PinTextBox.FocusedState.BorderColor = Color.Black
        PinTextBox.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PinTextBox.ForeColor = Color.Black
        PinTextBox.HoverState.BorderColor = Color.Black
        PinTextBox.IconLeftOffset = New Point(20, 0)
        PinTextBox.IconRight = My.Resources.Resources.Hide
        PinTextBox.IconRightCursor = Cursors.Hand
        PinTextBox.IconRightOffset = New Point(20, 0)
        PinTextBox.Location = New Point(20, 165)
        PinTextBox.Margin = New Padding(11, 7, 11, 7)
        PinTextBox.Name = "PinTextBox"
        PinTextBox.PasswordChar = "●"c
        PinTextBox.PlaceholderForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        PinTextBox.PlaceholderText = "Enter PIN"
        PinTextBox.SelectedText = ""
        PinTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        PinTextBox.Size = New Size(462, 40)
        PinTextBox.TabIndex = 7
        PinTextBox.TextOffset = New Point(10, 0)
        PinTextBox.UseSystemPasswordChar = True
        ' 
        ' ShadowButton
        ' 
        ShadowButton.Animated = True
        ShadowButton.BorderRadius = 8
        ShadowButton.Cursor = Cursors.Hand
        ShadowButton.CustomizableEdges = CustomizableEdges3
        ShadowButton.DisabledState.BorderColor = Color.DarkGray
        ShadowButton.DisabledState.CustomBorderColor = Color.DarkGray
        ShadowButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ShadowButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ShadowButton.FillColor = Color.FromArgb(CByte(28), CByte(28), CByte(30))
        ShadowButton.Font = New Font("Inter", 12F)
        ShadowButton.ForeColor = Color.White
        ShadowButton.Location = New Point(20, 226)
        ShadowButton.Name = "ShadowButton"
        ShadowButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        ShadowButton.Size = New Size(225, 40)
        ShadowButton.TabIndex = 8
        ShadowButton.Text = "Cancel"
        ' 
        ' ConfirmButton
        ' 
        ConfirmButton.Animated = True
        ConfirmButton.BorderRadius = 8
        ConfirmButton.Cursor = Cursors.Hand
        ConfirmButton.CustomizableEdges = CustomizableEdges1
        ConfirmButton.DisabledState.BorderColor = Color.DarkGray
        ConfirmButton.DisabledState.CustomBorderColor = Color.DarkGray
        ConfirmButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ConfirmButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ConfirmButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        ConfirmButton.Font = New Font("Inter", 12F)
        ConfirmButton.ForeColor = Color.White
        ConfirmButton.Location = New Point(251, 226)
        ConfirmButton.Name = "ConfirmButton"
        ConfirmButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        ConfirmButton.Size = New Size(231, 40)
        ConfirmButton.TabIndex = 9
        ConfirmButton.Text = "Confirm"
        ' 
        ' EnterPin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(507, 288)
        Controls.Add(ConfirmButton)
        Controls.Add(ShadowButton)
        Controls.Add(PinTextBox)
        Controls.Add(Guna2Panel1)
        Controls.Add(Label3)
        FormBorderStyle = FormBorderStyle.None
        Name = "EnterPin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "EnterPin"
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel1.PerformLayout()
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PinTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents ShadowButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ConfirmButton As Guna.UI2.WinForms.Guna2Button
End Class
