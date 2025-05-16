<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseUpdate
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
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        StockButton = New Guna.UI2.WinForms.Guna2Button()
        Label1 = New Label()
        ExpirationButton = New Guna.UI2.WinForms.Guna2Button()
        WarehouseButton = New Guna.UI2.WinForms.Guna2Button()
        ShadowButton = New Guna.UI2.WinForms.Guna2Button()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' StockButton
        ' 
        StockButton.Animated = True
        StockButton.BackColor = Color.Transparent
        StockButton.BorderRadius = 8
        StockButton.Cursor = Cursors.Hand
        StockButton.CustomizableEdges = CustomizableEdges5
        StockButton.DisabledState.BorderColor = Color.DarkGray
        StockButton.DisabledState.CustomBorderColor = Color.DarkGray
        StockButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        StockButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        StockButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        StockButton.Font = New Font("Inter", 10.7999992F)
        StockButton.ForeColor = Color.White
        StockButton.Location = New Point(20, 115)
        StockButton.Name = "StockButton"
        StockButton.ShadowDecoration.BorderRadius = 8
        StockButton.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        StockButton.ShadowDecoration.Depth = 100
        StockButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        StockButton.Size = New Size(357, 45)
        StockButton.TabIndex = 6
        StockButton.Text = "Stock"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Inter Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(179, 24)
        Label1.TabIndex = 7
        Label1.Text = "Choose Update:"
        ' 
        ' ExpirationButton
        ' 
        ExpirationButton.Animated = True
        ExpirationButton.BackColor = Color.Transparent
        ExpirationButton.BorderRadius = 8
        ExpirationButton.Cursor = Cursors.Hand
        ExpirationButton.CustomizableEdges = CustomizableEdges7
        ExpirationButton.DisabledState.BorderColor = Color.DarkGray
        ExpirationButton.DisabledState.CustomBorderColor = Color.DarkGray
        ExpirationButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ExpirationButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ExpirationButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        ExpirationButton.Font = New Font("Inter", 10.7999992F)
        ExpirationButton.ForeColor = Color.White
        ExpirationButton.Location = New Point(20, 64)
        ExpirationButton.Name = "ExpirationButton"
        ExpirationButton.ShadowDecoration.BorderRadius = 8
        ExpirationButton.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        ExpirationButton.ShadowDecoration.Depth = 100
        ExpirationButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ExpirationButton.Size = New Size(357, 45)
        ExpirationButton.TabIndex = 5
        ExpirationButton.Text = "Expiration Date"
        ' 
        ' WarehouseButton
        ' 
        WarehouseButton.Animated = True
        WarehouseButton.BackColor = Color.Transparent
        WarehouseButton.BorderRadius = 8
        WarehouseButton.Cursor = Cursors.Hand
        WarehouseButton.CustomizableEdges = CustomizableEdges3
        WarehouseButton.DisabledState.BorderColor = Color.DarkGray
        WarehouseButton.DisabledState.CustomBorderColor = Color.DarkGray
        WarehouseButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        WarehouseButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        WarehouseButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        WarehouseButton.Font = New Font("Inter", 10.7999992F)
        WarehouseButton.ForeColor = Color.White
        WarehouseButton.Location = New Point(20, 166)
        WarehouseButton.Name = "WarehouseButton"
        WarehouseButton.ShadowDecoration.BorderRadius = 8
        WarehouseButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        WarehouseButton.ShadowDecoration.Depth = 100
        WarehouseButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        WarehouseButton.Size = New Size(357, 45)
        WarehouseButton.TabIndex = 8
        WarehouseButton.Text = "Warehouse"
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
        ShadowButton.Location = New Point(20, 229)
        ShadowButton.Name = "ShadowButton"
        ShadowButton.ShadowDecoration.BorderRadius = 8
        ShadowButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        ShadowButton.ShadowDecoration.Depth = 100
        ShadowButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ShadowButton.Size = New Size(357, 45)
        ShadowButton.TabIndex = 9
        ShadowButton.Text = "Cancel"
        ' 
        ' ChooseUpdate
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(397, 286)
        Controls.Add(ShadowButton)
        Controls.Add(WarehouseButton)
        Controls.Add(StockButton)
        Controls.Add(Label1)
        Controls.Add(ExpirationButton)
        FormBorderStyle = FormBorderStyle.None
        Name = "ChooseUpdate"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ChooseUpdate"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents StockButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ExpirationButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents WarehouseButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ShadowButton As Guna.UI2.WinForms.Guna2Button
End Class
