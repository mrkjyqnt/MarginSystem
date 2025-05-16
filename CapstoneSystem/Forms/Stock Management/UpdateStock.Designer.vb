<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateStock
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
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        OldTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        Label3 = New Label()
        Label1 = New Label()
        NewTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        Label2 = New Label()
        ConfirmButton = New Guna.UI2.WinForms.Guna2Button()
        ShadowButton = New Guna.UI2.WinForms.Guna2Button()
        ExpirationDateTime = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Label9 = New Label()
        WarehouseComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' OldTextBox
        ' 
        OldTextBox.BackColor = Color.Transparent
        OldTextBox.BorderColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        OldTextBox.BorderRadius = 8
        OldTextBox.CustomizableEdges = CustomizableEdges5
        OldTextBox.DefaultText = ""
        OldTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        OldTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        OldTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        OldTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        OldTextBox.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        OldTextBox.FocusedState.BorderColor = Color.Black
        OldTextBox.Font = New Font("Inter", 10.7999992F)
        OldTextBox.ForeColor = Color.Black
        OldTextBox.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        OldTextBox.Location = New Point(97, 72)
        OldTextBox.Margin = New Padding(8, 6, 8, 6)
        OldTextBox.Name = "OldTextBox"
        OldTextBox.PasswordChar = ChrW(0)
        OldTextBox.PlaceholderForeColor = Color.FromArgb(CByte(174), CByte(174), CByte(178))
        OldTextBox.PlaceholderText = "Backup File Name"
        OldTextBox.ReadOnly = True
        OldTextBox.SelectedText = ""
        OldTextBox.ShadowDecoration.BorderRadius = 8
        OldTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        OldTextBox.ShadowDecoration.Depth = 255
        OldTextBox.ShadowDecoration.Enabled = True
        OldTextBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 3)
        OldTextBox.Size = New Size(259, 40)
        OldTextBox.TabIndex = 4
        OldTextBox.TextOffset = New Point(10, 0)
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(23, 81)
        Label3.Name = "Label3"
        Label3.Size = New Size(39, 21)
        Label3.TabIndex = 2
        Label3.Text = "Old"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Inter Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(25, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(163, 24)
        Label1.TabIndex = 3
        Label1.Text = "Create Backup"
        ' 
        ' NewTextBox
        ' 
        NewTextBox.BackColor = Color.Transparent
        NewTextBox.BorderColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        NewTextBox.BorderRadius = 8
        NewTextBox.CustomizableEdges = CustomizableEdges9
        NewTextBox.DefaultText = ""
        NewTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        NewTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        NewTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        NewTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        NewTextBox.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        NewTextBox.FocusedState.BorderColor = Color.Black
        NewTextBox.Font = New Font("Inter", 10.7999992F)
        NewTextBox.ForeColor = Color.Black
        NewTextBox.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        NewTextBox.Location = New Point(97, 124)
        NewTextBox.Margin = New Padding(8, 6, 8, 6)
        NewTextBox.Name = "NewTextBox"
        NewTextBox.PasswordChar = ChrW(0)
        NewTextBox.PlaceholderForeColor = Color.FromArgb(CByte(174), CByte(174), CByte(178))
        NewTextBox.PlaceholderText = "Backup File Name"
        NewTextBox.SelectedText = ""
        NewTextBox.ShadowDecoration.BorderRadius = 8
        NewTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        NewTextBox.ShadowDecoration.Depth = 255
        NewTextBox.ShadowDecoration.Enabled = True
        NewTextBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 3)
        NewTextBox.Size = New Size(259, 40)
        NewTextBox.TabIndex = 6
        NewTextBox.TextOffset = New Point(10, 0)
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(23, 133)
        Label2.Name = "Label2"
        Label2.Size = New Size(49, 21)
        Label2.TabIndex = 5
        Label2.Text = "New"
        ' 
        ' ConfirmButton
        ' 
        ConfirmButton.Animated = True
        ConfirmButton.BackColor = Color.Transparent
        ConfirmButton.BorderRadius = 8
        ConfirmButton.Cursor = Cursors.Hand
        ConfirmButton.CustomizableEdges = CustomizableEdges1
        ConfirmButton.DisabledState.BorderColor = Color.DarkGray
        ConfirmButton.DisabledState.CustomBorderColor = Color.DarkGray
        ConfirmButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ConfirmButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ConfirmButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        ConfirmButton.Font = New Font("Inter", 10.7999992F)
        ConfirmButton.ForeColor = Color.White
        ConfirmButton.Location = New Point(186, 183)
        ConfirmButton.Name = "ConfirmButton"
        ConfirmButton.ShadowDecoration.BorderRadius = 8
        ConfirmButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        ConfirmButton.ShadowDecoration.Depth = 100
        ConfirmButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ConfirmButton.Size = New Size(170, 40)
        ConfirmButton.TabIndex = 8
        ConfirmButton.Text = "Confirm"
        ' 
        ' ShadowButton
        ' 
        ShadowButton.Animated = True
        ShadowButton.BackColor = Color.Transparent
        ShadowButton.BorderRadius = 8
        ShadowButton.Cursor = Cursors.Hand
        ShadowButton.CustomizableEdges = CustomizableEdges3
        ShadowButton.DisabledState.BorderColor = Color.DarkGray
        ShadowButton.DisabledState.CustomBorderColor = Color.DarkGray
        ShadowButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ShadowButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ShadowButton.FillColor = Color.FromArgb(CByte(28), CByte(28), CByte(30))
        ShadowButton.Font = New Font("Inter", 10.7999992F)
        ShadowButton.ForeColor = Color.White
        ShadowButton.Location = New Point(21, 183)
        ShadowButton.Name = "ShadowButton"
        ShadowButton.ShadowDecoration.BorderRadius = 8
        ShadowButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        ShadowButton.ShadowDecoration.Depth = 100
        ShadowButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ShadowButton.Size = New Size(159, 40)
        ShadowButton.TabIndex = 7
        ShadowButton.Text = "Cancel"
        ' 
        ' ExpirationDateTime
        ' 
        ExpirationDateTime.BackColor = Color.Transparent
        ExpirationDateTime.BorderRadius = 8
        ExpirationDateTime.Checked = True
        ExpirationDateTime.CustomizableEdges = CustomizableEdges11
        ExpirationDateTime.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        ExpirationDateTime.Font = New Font("Inter", 10.7999992F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        ExpirationDateTime.ForeColor = Color.White
        ExpirationDateTime.Format = DateTimePickerFormat.Long
        ExpirationDateTime.Location = New Point(97, 121)
        ExpirationDateTime.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        ExpirationDateTime.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        ExpirationDateTime.Name = "ExpirationDateTime"
        ExpirationDateTime.ShadowDecoration.BorderRadius = 8
        ExpirationDateTime.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        ExpirationDateTime.ShadowDecoration.Depth = 100
        ExpirationDateTime.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ExpirationDateTime.Size = New Size(259, 43)
        ExpirationDateTime.TabIndex = 9
        ExpirationDateTime.TextAlign = HorizontalAlignment.Right
        ExpirationDateTime.Value = New Date(2025, 1, 10, 12, 18, 20, 581)
        ExpirationDateTime.Visible = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        Label9.Cursor = Cursors.Hand
        Label9.Font = New Font("Inter", 12F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        Label9.Location = New Point(116, 132)
        Label9.Name = "Label9"
        Label9.Size = New Size(195, 24)
        Label9.TabIndex = 10
        Label9.Text = "Choose Warehouse"
        Label9.Visible = False
        ' 
        ' WarehouseComboBox
        ' 
        WarehouseComboBox.BackColor = Color.Transparent
        WarehouseComboBox.BorderRadius = 8
        WarehouseComboBox.Cursor = Cursors.Hand
        WarehouseComboBox.CustomizableEdges = CustomizableEdges7
        WarehouseComboBox.DrawMode = DrawMode.OwnerDrawFixed
        WarehouseComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        WarehouseComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        WarehouseComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        WarehouseComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        WarehouseComboBox.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        WarehouseComboBox.ForeColor = Color.White
        WarehouseComboBox.ItemHeight = 34
        WarehouseComboBox.Location = New Point(97, 124)
        WarehouseComboBox.Name = "WarehouseComboBox"
        WarehouseComboBox.ShadowDecoration.BorderRadius = 8
        WarehouseComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        WarehouseComboBox.ShadowDecoration.Depth = 100
        WarehouseComboBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        WarehouseComboBox.Size = New Size(259, 40)
        WarehouseComboBox.TabIndex = 11
        WarehouseComboBox.TextOffset = New Point(20, 0)
        WarehouseComboBox.Visible = False
        ' 
        ' UpdateStock
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(378, 246)
        Controls.Add(ConfirmButton)
        Controls.Add(ShadowButton)
        Controls.Add(Label2)
        Controls.Add(OldTextBox)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Label9)
        Controls.Add(WarehouseComboBox)
        Controls.Add(NewTextBox)
        Controls.Add(ExpirationDateTime)
        FormBorderStyle = FormBorderStyle.None
        Name = "UpdateStock"
        StartPosition = FormStartPosition.CenterScreen
        Text = "UpdateStock"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents OldTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents NewTextBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ConfirmButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ShadowButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ExpirationDateTime As Guna.UI2.WinForms.Guna2DateTimePicker
    Private WithEvents Label9 As Label
    Private WithEvents WarehouseComboBox As Guna.UI2.WinForms.Guna2ComboBox
End Class
