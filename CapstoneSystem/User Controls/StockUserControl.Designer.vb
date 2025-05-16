<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockUserControl
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        ElipseForm = New Guna.UI2.WinForms.Guna2Elipse(components)
        StockLabel = New Label()
        WarehouseBatchLabel = New Label()
        StockNameLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        StockIdLabel = New Label()
        ElipseContextMenu = New Guna.UI2.WinForms.Guna2ContextMenuStrip()
        UpdateToolStripMenuItem = New ToolStripMenuItem()
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        ElipseLabel = New Label()
        ProductIdLabel = New Label()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        ElipseContextMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' ElipseForm
        ' 
        ElipseForm.BorderRadius = 8
        ElipseForm.TargetControl = Me
        ' 
        ' StockLabel
        ' 
        StockLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        StockLabel.AutoSize = True
        StockLabel.BackColor = Color.Transparent
        StockLabel.Font = New Font("Inter", 16.2F)
        StockLabel.ForeColor = Color.Black
        StockLabel.Location = New Point(788, 33)
        StockLabel.Name = "StockLabel"
        StockLabel.Size = New Size(49, 34)
        StockLabel.TabIndex = 19
        StockLabel.Text = "25"
        ' 
        ' WarehouseBatchLabel
        ' 
        WarehouseBatchLabel.AutoSize = True
        WarehouseBatchLabel.BackColor = Color.Transparent
        WarehouseBatchLabel.Font = New Font("Inter", 12F)
        WarehouseBatchLabel.ForeColor = Color.Black
        WarehouseBatchLabel.Location = New Point(92, 55)
        WarehouseBatchLabel.Name = "WarehouseBatchLabel"
        WarehouseBatchLabel.Size = New Size(154, 24)
        WarehouseBatchLabel.TabIndex = 20
        WarehouseBatchLabel.Text = "Warehouse | ID"
        ' 
        ' StockNameLabel
        ' 
        StockNameLabel.AutoSize = True
        StockNameLabel.BackColor = Color.Transparent
        StockNameLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold)
        StockNameLabel.ForeColor = Color.Black
        StockNameLabel.Location = New Point(91, 16)
        StockNameLabel.Name = "StockNameLabel"
        StockNameLabel.Size = New Size(150, 34)
        StockNameLabel.TabIndex = 21
        StockNameLabel.Text = "Product 1"
        ' 
        ' PlaceholderImage
        ' 
        PlaceholderImage.BackColor = Color.Transparent
        PlaceholderImage.CustomizableEdges = CustomizableEdges5
        PlaceholderImage.Image = My.Resources.Resources.ProductPlaceholder
        PlaceholderImage.ImageRotate = 0F
        PlaceholderImage.Location = New Point(24, 23)
        PlaceholderImage.Name = "PlaceholderImage"
        PlaceholderImage.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        PlaceholderImage.Size = New Size(48, 49)
        PlaceholderImage.SizeMode = PictureBoxSizeMode.Zoom
        PlaceholderImage.TabIndex = 23
        PlaceholderImage.TabStop = False
        PlaceholderImage.UseTransparentBackground = True
        ' 
        ' StockIdLabel
        ' 
        StockIdLabel.AutoSize = True
        StockIdLabel.BackColor = Color.Transparent
        StockIdLabel.Font = New Font("Inter", 12F)
        StockIdLabel.ForeColor = Color.Black
        StockIdLabel.Location = New Point(539, 33)
        StockIdLabel.Name = "StockIdLabel"
        StockIdLabel.Size = New Size(87, 24)
        StockIdLabel.TabIndex = 24
        StockIdLabel.Text = "Stock Id"
        StockIdLabel.Visible = False
        ' 
        ' ElipseContextMenu
        ' 
        ElipseContextMenu.ImageScalingSize = New Size(20, 20)
        ElipseContextMenu.Items.AddRange(New ToolStripItem() {UpdateToolStripMenuItem, DeleteToolStripMenuItem})
        ElipseContextMenu.Name = "Guna2ContextMenuStrip1"
        ElipseContextMenu.RenderStyle.ArrowColor = Color.FromArgb(CByte(151), CByte(143), CByte(255))
        ElipseContextMenu.RenderStyle.BorderColor = Color.Gainsboro
        ElipseContextMenu.RenderStyle.ColorTable = Nothing
        ElipseContextMenu.RenderStyle.RoundedEdges = True
        ElipseContextMenu.RenderStyle.SelectionArrowColor = Color.White
        ElipseContextMenu.RenderStyle.SelectionBackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        ElipseContextMenu.RenderStyle.SelectionForeColor = Color.White
        ElipseContextMenu.RenderStyle.SeparatorColor = Color.Gainsboro
        ElipseContextMenu.RenderStyle.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        ElipseContextMenu.Size = New Size(211, 80)
        ' 
        ' UpdateToolStripMenuItem
        ' 
        UpdateToolStripMenuItem.BackColor = Color.White
        UpdateToolStripMenuItem.Font = New Font("Inter", 10.1999989F)
        UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        UpdateToolStripMenuItem.Size = New Size(210, 24)
        UpdateToolStripMenuItem.Text = "Update"
        ' 
        ' DeleteToolStripMenuItem
        ' 
        DeleteToolStripMenuItem.BackColor = Color.White
        DeleteToolStripMenuItem.Font = New Font("Inter", 10.1999989F)
        DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        DeleteToolStripMenuItem.Size = New Size(210, 24)
        DeleteToolStripMenuItem.Text = "Delete"
        ' 
        ' ElipseLabel
        ' 
        ElipseLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ElipseLabel.AutoSize = True
        ElipseLabel.BackColor = Color.Transparent
        ElipseLabel.Cursor = Cursors.Hand
        ElipseLabel.Font = New Font("Inter", 12F)
        ElipseLabel.ForeColor = Color.Black
        ElipseLabel.Location = New Point(977, 32)
        ElipseLabel.Name = "ElipseLabel"
        ElipseLabel.Size = New Size(28, 24)
        ElipseLabel.TabIndex = 26
        ElipseLabel.Text = "..."
        ' 
        ' ProductIdLabel
        ' 
        ProductIdLabel.AutoSize = True
        ProductIdLabel.BackColor = Color.Transparent
        ProductIdLabel.Font = New Font("Inter", 12F)
        ProductIdLabel.ForeColor = Color.Black
        ProductIdLabel.Location = New Point(415, 33)
        ProductIdLabel.Name = "ProductIdLabel"
        ProductIdLabel.Size = New Size(107, 24)
        ProductIdLabel.TabIndex = 27
        ProductIdLabel.Text = "Product Id"
        ProductIdLabel.Visible = False
        ' 
        ' StockUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(ProductIdLabel)
        Controls.Add(ElipseLabel)
        Controls.Add(StockIdLabel)
        Controls.Add(StockLabel)
        Controls.Add(WarehouseBatchLabel)
        Controls.Add(StockNameLabel)
        Controls.Add(PlaceholderImage)
        Name = "StockUserControl"
        Size = New Size(1040, 100)
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        ElipseContextMenu.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ElipseForm As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents StockLabel As Label
    Friend WithEvents WarehouseBatchLabel As Label
    Friend WithEvents StockNameLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents StockIdLabel As Label
    Friend WithEvents ElipseContextMenu As Guna.UI2.WinForms.Guna2ContextMenuStrip
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElipseLabel As Label
    Friend WithEvents ProductIdLabel As Label

End Class
