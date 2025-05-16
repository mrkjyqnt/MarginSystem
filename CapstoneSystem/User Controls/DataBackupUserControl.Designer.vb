<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataBackupUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        ElipseForm = New Guna.UI2.WinForms.Guna2Elipse(components)
        DateLabel = New Label()
        BackupNameLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        DeleteButton = New Guna.UI2.WinForms.Guna2Button()
        ExportButton = New Guna.UI2.WinForms.Guna2Button()
        RestoreButton = New Guna.UI2.WinForms.Guna2Button()
        IdLabel = New Label()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ElipseForm
        ' 
        ElipseForm.BorderRadius = 8
        ElipseForm.TargetControl = Me
        ' 
        ' DateLabel
        ' 
        DateLabel.AutoSize = True
        DateLabel.BackColor = Color.Transparent
        DateLabel.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateLabel.ForeColor = Color.Black
        DateLabel.Location = New Point(92, 54)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New Size(54, 24)
        DateLabel.TabIndex = 20
        DateLabel.Text = "Date"
        ' 
        ' BackupNameLabel
        ' 
        BackupNameLabel.AutoSize = True
        BackupNameLabel.BackColor = Color.Transparent
        BackupNameLabel.Font = New Font("Inter Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BackupNameLabel.ForeColor = Color.Black
        BackupNameLabel.Location = New Point(91, 23)
        BackupNameLabel.Name = "BackupNameLabel"
        BackupNameLabel.Size = New Size(283, 28)
        BackupNameLabel.TabIndex = 21
        BackupNameLabel.Text = "Management [Backup]"
        ' 
        ' PlaceholderImage
        ' 
        PlaceholderImage.BackColor = Color.Transparent
        PlaceholderImage.CustomizableEdges = CustomizableEdges7
        PlaceholderImage.Image = My.Resources.Resources.DatabasePlaceholder
        PlaceholderImage.ImageRotate = 0F
        PlaceholderImage.Location = New Point(24, 23)
        PlaceholderImage.Name = "PlaceholderImage"
        PlaceholderImage.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        PlaceholderImage.Size = New Size(48, 49)
        PlaceholderImage.SizeMode = PictureBoxSizeMode.AutoSize
        PlaceholderImage.TabIndex = 23
        PlaceholderImage.TabStop = False
        PlaceholderImage.UseTransparentBackground = True
        ' 
        ' DeleteButton
        ' 
        DeleteButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        DeleteButton.BackColor = Color.Transparent
        DeleteButton.BorderColor = Color.FromArgb(CByte(255), CByte(59), CByte(48))
        DeleteButton.BorderRadius = 8
        DeleteButton.BorderThickness = 1
        DeleteButton.Cursor = Cursors.Hand
        DeleteButton.CustomizableEdges = CustomizableEdges1
        DeleteButton.DisabledState.BorderColor = Color.DarkGray
        DeleteButton.DisabledState.CustomBorderColor = Color.DarkGray
        DeleteButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        DeleteButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        DeleteButton.FillColor = Color.White
        DeleteButton.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DeleteButton.ForeColor = Color.FromArgb(CByte(255), CByte(59), CByte(48))
        DeleteButton.HoverState.FillColor = Color.FromArgb(CByte(255), CByte(59), CByte(48))
        DeleteButton.HoverState.ForeColor = Color.White
        DeleteButton.ImageAlign = HorizontalAlignment.Left
        DeleteButton.ImageOffset = New Point(10, 0)
        DeleteButton.Location = New Point(559, 30)
        DeleteButton.Name = "DeleteButton"
        DeleteButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        DeleteButton.Size = New Size(137, 40)
        DeleteButton.TabIndex = 24
        DeleteButton.Text = "Delete"
        DeleteButton.UseTransparentBackground = True
        ' 
        ' ExportButton
        ' 
        ExportButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ExportButton.BackColor = Color.Transparent
        ExportButton.BorderColor = Color.FromArgb(CByte(51), CByte(199), CByte(90))
        ExportButton.BorderRadius = 8
        ExportButton.BorderThickness = 1
        ExportButton.Cursor = Cursors.Hand
        ExportButton.CustomizableEdges = CustomizableEdges3
        ExportButton.DisabledState.BorderColor = Color.DarkGray
        ExportButton.DisabledState.CustomBorderColor = Color.DarkGray
        ExportButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ExportButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ExportButton.FillColor = Color.White
        ExportButton.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ExportButton.ForeColor = Color.Black
        ExportButton.HoverState.FillColor = Color.FromArgb(CByte(51), CByte(199), CByte(90))
        ExportButton.ImageAlign = HorizontalAlignment.Left
        ExportButton.ImageOffset = New Point(10, 0)
        ExportButton.Location = New Point(702, 30)
        ExportButton.Name = "ExportButton"
        ExportButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        ExportButton.Size = New Size(137, 40)
        ExportButton.TabIndex = 25
        ExportButton.Text = "Export"
        ExportButton.UseTransparentBackground = True
        ' 
        ' RestoreButton
        ' 
        RestoreButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        RestoreButton.BackColor = Color.Transparent
        RestoreButton.BorderColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        RestoreButton.BorderRadius = 8
        RestoreButton.BorderThickness = 1
        RestoreButton.Cursor = Cursors.Hand
        RestoreButton.CustomizableEdges = CustomizableEdges5
        RestoreButton.DisabledState.BorderColor = Color.DarkGray
        RestoreButton.DisabledState.CustomBorderColor = Color.DarkGray
        RestoreButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        RestoreButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        RestoreButton.FillColor = Color.White
        RestoreButton.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RestoreButton.ForeColor = Color.Black
        RestoreButton.HoverState.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        RestoreButton.HoverState.Image = My.Resources.Resources.HoveredReload
        RestoreButton.Image = My.Resources.Resources.Reload
        RestoreButton.ImageAlign = HorizontalAlignment.Left
        RestoreButton.ImageOffset = New Point(10, 0)
        RestoreButton.Location = New Point(845, 30)
        RestoreButton.Name = "RestoreButton"
        RestoreButton.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        RestoreButton.Size = New Size(164, 40)
        RestoreButton.TabIndex = 26
        RestoreButton.Text = "Restore"
        RestoreButton.TextAlign = HorizontalAlignment.Right
        RestoreButton.TextOffset = New Point(-5, 0)
        RestoreButton.UseTransparentBackground = True
        ' 
        ' IdLabel
        ' 
        IdLabel.AutoSize = True
        IdLabel.BackColor = Color.Transparent
        IdLabel.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IdLabel.ForeColor = Color.Black
        IdLabel.Location = New Point(473, 30)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New Size(29, 24)
        IdLabel.TabIndex = 27
        IdLabel.Text = "ID"
        IdLabel.Visible = False
        ' 
        ' DataBackupUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(IdLabel)
        Controls.Add(DeleteButton)
        Controls.Add(ExportButton)
        Controls.Add(RestoreButton)
        Controls.Add(DateLabel)
        Controls.Add(BackupNameLabel)
        Controls.Add(PlaceholderImage)
        Name = "DataBackupUserControl"
        Size = New Size(1040, 100)
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ElipseForm As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents DateLabel As Label
    Friend WithEvents BackupNameLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents DeleteButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ExportButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents RestoreButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents IdLabel As Label

End Class
