<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseExport
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
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        LocalButton = New Guna.UI2.WinForms.Guna2Button()
        Label1 = New Label()
        GdriveButton = New Guna.UI2.WinForms.Guna2Button()
        ShadowButton = New Guna.UI2.WinForms.Guna2Button()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' LocalButton
        ' 
        LocalButton.Animated = True
        LocalButton.BackColor = Color.Transparent
        LocalButton.BorderRadius = 8
        LocalButton.Cursor = Cursors.Hand
        LocalButton.CustomizableEdges = CustomizableEdges5
        LocalButton.DisabledState.BorderColor = Color.DarkGray
        LocalButton.DisabledState.CustomBorderColor = Color.DarkGray
        LocalButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        LocalButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        LocalButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        LocalButton.Font = New Font("Inter", 10.7999992F)
        LocalButton.ForeColor = Color.White
        LocalButton.Location = New Point(20, 64)
        LocalButton.Name = "LocalButton"
        LocalButton.ShadowDecoration.BorderRadius = 8
        LocalButton.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        LocalButton.ShadowDecoration.Depth = 100
        LocalButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        LocalButton.Size = New Size(357, 45)
        LocalButton.TabIndex = 1
        LocalButton.Text = "Local"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Inter Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(197, 24)
        Label1.TabIndex = 4
        Label1.Text = "Export this file to:"
        ' 
        ' GdriveButton
        ' 
        GdriveButton.Animated = True
        GdriveButton.BackColor = Color.Transparent
        GdriveButton.BorderRadius = 8
        GdriveButton.Cursor = Cursors.Hand
        GdriveButton.CustomizableEdges = CustomizableEdges3
        GdriveButton.DisabledState.BorderColor = Color.DarkGray
        GdriveButton.DisabledState.CustomBorderColor = Color.DarkGray
        GdriveButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        GdriveButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        GdriveButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        GdriveButton.Font = New Font("Inter", 10.7999992F)
        GdriveButton.ForeColor = Color.White
        GdriveButton.Location = New Point(20, 115)
        GdriveButton.Name = "GdriveButton"
        GdriveButton.ShadowDecoration.BorderRadius = 8
        GdriveButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        GdriveButton.ShadowDecoration.Depth = 100
        GdriveButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        GdriveButton.Size = New Size(357, 45)
        GdriveButton.TabIndex = 2
        GdriveButton.Text = "Gdrive"
        ' 
        ' ShadowButton
        ' 
        ShadowButton.Animated = True
        ShadowButton.BackColor = Color.Transparent
        ShadowButton.BorderRadius = 8
        ShadowButton.Cursor = Cursors.Hand
        ShadowButton.CustomizableEdges = CustomizableEdges1
        ShadowButton.DisabledState.BorderColor = Color.DarkGray
        ShadowButton.DisabledState.CustomBorderColor = Color.DarkGray
        ShadowButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ShadowButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ShadowButton.FillColor = Color.FromArgb(CByte(28), CByte(28), CByte(30))
        ShadowButton.Font = New Font("Inter", 10.7999992F)
        ShadowButton.ForeColor = Color.White
        ShadowButton.Location = New Point(20, 187)
        ShadowButton.Name = "ShadowButton"
        ShadowButton.ShadowDecoration.BorderRadius = 8
        ShadowButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        ShadowButton.ShadowDecoration.Depth = 100
        ShadowButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ShadowButton.Size = New Size(357, 45)
        ShadowButton.TabIndex = 3
        ShadowButton.Text = "Cancel"
        ' 
        ' ChooseExport
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(397, 250)
        Controls.Add(ShadowButton)
        Controls.Add(GdriveButton)
        Controls.Add(Label1)
        Controls.Add(LocalButton)
        FormBorderStyle = FormBorderStyle.None
        Name = "ChooseExport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ChooseExport"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents LocalButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GdriveButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ShadowButton As Guna.UI2.WinForms.Guna2Button
End Class
