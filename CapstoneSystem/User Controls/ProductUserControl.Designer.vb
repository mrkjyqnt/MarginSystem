<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductUserControl
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        ElipseForm = New Guna.UI2.WinForms.Guna2Elipse(components)
        ItemPriceLabel = New Label()
        CategoryProductCodeLabel = New Label()
        ProductNameLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        ProductIdLabel = New Label()
        ProductCategoryLabel = New Label()
        ElipseLabel = New Label()
        ElipseContextMenu = New Guna.UI2.WinForms.Guna2ContextMenuStrip()
        UpdateToolStripMenuItem = New ToolStripMenuItem()
        RestockToolStripMenuItem = New ToolStripMenuItem()
        DisableToolStripMenuItem = New ToolStripMenuItem()
        ContextElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        ElipseContextMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' ElipseForm
        ' 
        ElipseForm.BorderRadius = 8
        ElipseForm.TargetControl = Me
        ' 
        ' ItemPriceLabel
        ' 
        ItemPriceLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ItemPriceLabel.AutoSize = True
        ItemPriceLabel.BackColor = Color.Transparent
        ItemPriceLabel.Font = New Font("Inter", 16.2F)
        ItemPriceLabel.ForeColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        ItemPriceLabel.Location = New Point(795, 33)
        ItemPriceLabel.Name = "ItemPriceLabel"
        ItemPriceLabel.Size = New Size(92, 34)
        ItemPriceLabel.TabIndex = 14
        ItemPriceLabel.Text = "₱ 100"
        ' 
        ' CategoryProductCodeLabel
        ' 
        CategoryProductCodeLabel.AutoSize = True
        CategoryProductCodeLabel.BackColor = Color.Transparent
        CategoryProductCodeLabel.Font = New Font("Inter", 12F)
        CategoryProductCodeLabel.ForeColor = Color.Black
        CategoryProductCodeLabel.Location = New Point(92, 55)
        CategoryProductCodeLabel.Name = "CategoryProductCodeLabel"
        CategoryProductCodeLabel.Size = New Size(247, 24)
        CategoryProductCodeLabel.TabIndex = 15
        CategoryProductCodeLabel.Text = "Category | Product Code"
        ' 
        ' ProductNameLabel
        ' 
        ProductNameLabel.AutoSize = True
        ProductNameLabel.BackColor = Color.Transparent
        ProductNameLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold)
        ProductNameLabel.ForeColor = Color.Black
        ProductNameLabel.Location = New Point(91, 16)
        ProductNameLabel.Name = "ProductNameLabel"
        ProductNameLabel.Size = New Size(150, 34)
        ProductNameLabel.TabIndex = 16
        ProductNameLabel.Text = "Product 1"
        ' 
        ' PlaceholderImage
        ' 
        PlaceholderImage.BackColor = Color.Transparent
        PlaceholderImage.CustomizableEdges = CustomizableEdges1
        PlaceholderImage.Image = My.Resources.Resources.ProductPlaceholder
        PlaceholderImage.ImageRotate = 0F
        PlaceholderImage.Location = New Point(24, 23)
        PlaceholderImage.Name = "PlaceholderImage"
        PlaceholderImage.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        PlaceholderImage.Size = New Size(48, 49)
        PlaceholderImage.SizeMode = PictureBoxSizeMode.Zoom
        PlaceholderImage.TabIndex = 18
        PlaceholderImage.TabStop = False
        PlaceholderImage.UseTransparentBackground = True
        ' 
        ' ProductIdLabel
        ' 
        ProductIdLabel.AutoSize = True
        ProductIdLabel.BackColor = Color.Transparent
        ProductIdLabel.Font = New Font("Inter", 12F)
        ProductIdLabel.ForeColor = Color.Black
        ProductIdLabel.Location = New Point(439, 23)
        ProductIdLabel.Name = "ProductIdLabel"
        ProductIdLabel.Size = New Size(109, 24)
        ProductIdLabel.TabIndex = 21
        ProductIdLabel.Text = "Product ID"
        ProductIdLabel.Visible = False
        ' 
        ' ProductCategoryLabel
        ' 
        ProductCategoryLabel.AutoSize = True
        ProductCategoryLabel.BackColor = Color.Transparent
        ProductCategoryLabel.Font = New Font("Inter", 12F)
        ProductCategoryLabel.ForeColor = Color.Black
        ProductCategoryLabel.Location = New Point(439, 53)
        ProductCategoryLabel.Name = "ProductCategoryLabel"
        ProductCategoryLabel.Size = New Size(177, 24)
        ProductCategoryLabel.TabIndex = 22
        ProductCategoryLabel.Text = "Product Category"
        ProductCategoryLabel.Visible = False
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
        ElipseLabel.TabIndex = 23
        ElipseLabel.Text = "..."
        ' 
        ' ElipseContextMenu
        ' 
        ElipseContextMenu.ImageScalingSize = New Size(20, 20)
        ElipseContextMenu.Items.AddRange(New ToolStripItem() {UpdateToolStripMenuItem, RestockToolStripMenuItem, DisableToolStripMenuItem})
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
        ElipseContextMenu.Size = New Size(143, 76)
        ' 
        ' UpdateToolStripMenuItem
        ' 
        UpdateToolStripMenuItem.BackColor = Color.White
        UpdateToolStripMenuItem.Font = New Font("Inter", 10.1999989F)
        UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        UpdateToolStripMenuItem.Size = New Size(142, 24)
        UpdateToolStripMenuItem.Text = "Update"
        ' 
        ' RestockToolStripMenuItem
        ' 
        RestockToolStripMenuItem.BackColor = Color.White
        RestockToolStripMenuItem.Font = New Font("Inter", 10.1999989F)
        RestockToolStripMenuItem.Name = "RestockToolStripMenuItem"
        RestockToolStripMenuItem.Size = New Size(142, 24)
        RestockToolStripMenuItem.Text = "Restock"
        ' 
        ' DisableToolStripMenuItem
        ' 
        DisableToolStripMenuItem.BackColor = Color.White
        DisableToolStripMenuItem.Font = New Font("Inter", 10.1999989F)
        DisableToolStripMenuItem.Name = "DisableToolStripMenuItem"
        DisableToolStripMenuItem.Size = New Size(142, 24)
        DisableToolStripMenuItem.Text = "Disable"
        ' 
        ' ContextElipse
        ' 
        ContextElipse.BorderRadius = 15
        ContextElipse.TargetControl = ElipseContextMenu
        ' 
        ' ProductUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(ElipseLabel)
        Controls.Add(ProductCategoryLabel)
        Controls.Add(ProductIdLabel)
        Controls.Add(ItemPriceLabel)
        Controls.Add(CategoryProductCodeLabel)
        Controls.Add(ProductNameLabel)
        Controls.Add(PlaceholderImage)
        DoubleBuffered = True
        Name = "ProductUserControl"
        Size = New Size(1040, 100)
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        ElipseContextMenu.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ElipseForm As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents ItemPriceLabel As Label
    Friend WithEvents CategoryProductCodeLabel As Label
    Friend WithEvents ProductNameLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents ProductIdLabel As Label
    Friend WithEvents ProductCategoryLabel As Label
    Friend WithEvents ElipseLabel As Label
    Friend WithEvents ElipseContextMenu As Guna.UI2.WinForms.Guna2ContextMenuStrip
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents DisableToolStripMenuItem As ToolStripMenuItem

End Class
