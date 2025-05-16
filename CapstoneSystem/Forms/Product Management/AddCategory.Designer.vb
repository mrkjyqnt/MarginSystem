<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCategory
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Label1 = New Label()
        Label8 = New Label()
        CategoryTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        NextButton = New Guna.UI2.WinForms.Guna2Button()
        ShadowButton = New Guna.UI2.WinForms.Guna2Button()
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
        Label1.Font = New Font("Inter Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(183, 28)
        Label1.TabIndex = 0
        Label1.Text = "New Category"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Inter", 10.7999992F)
        Label8.ForeColor = Color.Black
        Label8.Location = New Point(20, 90)
        Label8.Name = "Label8"
        Label8.Size = New Size(89, 21)
        Label8.TabIndex = 0
        Label8.Text = "Category"
        ' 
        ' CategoryTextBox
        ' 
        CategoryTextBox.BackColor = Color.Transparent
        CategoryTextBox.BorderRadius = 8
        CategoryTextBox.CustomizableEdges = CustomizableEdges5
        CategoryTextBox.DefaultText = ""
        CategoryTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        CategoryTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        CategoryTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        CategoryTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        CategoryTextBox.FillColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        CategoryTextBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        CategoryTextBox.Font = New Font("Inter", 10.7999992F)
        CategoryTextBox.ForeColor = Color.Black
        CategoryTextBox.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        CategoryTextBox.IconLeftOffset = New Point(20, 0)
        CategoryTextBox.Location = New Point(150, 76)
        CategoryTextBox.Margin = New Padding(6, 5, 6, 5)
        CategoryTextBox.Name = "CategoryTextBox"
        CategoryTextBox.PasswordChar = ChrW(0)
        CategoryTextBox.PlaceholderForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        CategoryTextBox.PlaceholderText = "Category Name"
        CategoryTextBox.SelectedText = ""
        CategoryTextBox.ShadowDecoration.BorderRadius = 8
        CategoryTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        CategoryTextBox.ShadowDecoration.Depth = 100
        CategoryTextBox.ShadowDecoration.Enabled = True
        CategoryTextBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        CategoryTextBox.Size = New Size(305, 40)
        CategoryTextBox.TabIndex = 1
        CategoryTextBox.TextOffset = New Point(10, 0)
        ' 
        ' NextButton
        ' 
        NextButton.Animated = True
        NextButton.BackColor = Color.Transparent
        NextButton.BorderColor = Color.Transparent
        NextButton.BorderRadius = 8
        NextButton.Cursor = Cursors.Hand
        NextButton.CustomizableEdges = CustomizableEdges1
        NextButton.DisabledState.BorderColor = Color.DarkGray
        NextButton.DisabledState.CustomBorderColor = Color.DarkGray
        NextButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        NextButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        NextButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        NextButton.Font = New Font("Inter", 12F)
        NextButton.ForeColor = Color.White
        NextButton.Location = New Point(239, 140)
        NextButton.Name = "NextButton"
        NextButton.ShadowDecoration.BorderRadius = 8
        NextButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        NextButton.ShadowDecoration.Depth = 100
        NextButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        NextButton.Size = New Size(216, 40)
        NextButton.TabIndex = 3
        NextButton.Text = "Enter"
        ' 
        ' ShadowButton
        ' 
        ShadowButton.Animated = True
        ShadowButton.BackColor = Color.Transparent
        ShadowButton.BorderColor = Color.Transparent
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
        ShadowButton.Location = New Point(20, 140)
        ShadowButton.Name = "ShadowButton"
        ShadowButton.ShadowDecoration.BorderRadius = 8
        ShadowButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        ShadowButton.ShadowDecoration.Depth = 100
        ShadowButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ShadowButton.Size = New Size(213, 40)
        ShadowButton.TabIndex = 2
        ShadowButton.Text = "Cancel"
        ' 
        ' AddCategory
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(478, 204)
        Controls.Add(NextButton)
        Controls.Add(ShadowButton)
        Controls.Add(Label8)
        Controls.Add(CategoryTextBox)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "AddCategory"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AddCategory"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CategoryTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents NextButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ShadowButton As Guna.UI2.WinForms.Guna2Button
End Class
