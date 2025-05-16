<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesValuationUserControl
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
        TotalSaleLabel = New Label()
        ElipseForm = New Guna.UI2.WinForms.Guna2Elipse(components)
        NoDateLabel = New Label()
        SaleNameLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        StockIdLabel = New Label()
        SaleIdLabel = New Label()
        ElipseLabel = New Label()
        ElipseContextMenu = New Guna.UI2.WinForms.Guna2ContextMenuStrip()
        UpdateToolStripMenuItem = New ToolStripMenuItem()
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        MoveToInventoryToolStripMenuItem = New ToolStripMenuItem()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        ElipseContextMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' TotalSaleLabel
        ' 
        TotalSaleLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TotalSaleLabel.AutoSize = True
        TotalSaleLabel.BackColor = Color.Transparent
        TotalSaleLabel.Font = New Font("Inter", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TotalSaleLabel.ForeColor = Color.Black
        TotalSaleLabel.Location = New Point(788, 33)
        TotalSaleLabel.Name = "TotalSaleLabel"
        TotalSaleLabel.Size = New Size(148, 34)
        TotalSaleLabel.TabIndex = 29
        TotalSaleLabel.Text = "+ ₱ 3600 "
        ' 
        ' ElipseForm
        ' 
        ElipseForm.BorderRadius = 8
        ElipseForm.TargetControl = Me
        ' 
        ' NoDateLabel
        ' 
        NoDateLabel.AutoSize = True
        NoDateLabel.BackColor = Color.Transparent
        NoDateLabel.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NoDateLabel.ForeColor = Color.Black
        NoDateLabel.Location = New Point(92, 55)
        NoDateLabel.Name = "NoDateLabel"
        NoDateLabel.Size = New Size(100, 24)
        NoDateLabel.TabIndex = 30
        NoDateLabel.Text = "No | Date"
        ' 
        ' SaleNameLabel
        ' 
        SaleNameLabel.AutoSize = True
        SaleNameLabel.BackColor = Color.Transparent
        SaleNameLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SaleNameLabel.ForeColor = Color.Black
        SaleNameLabel.Location = New Point(91, 16)
        SaleNameLabel.Name = "SaleNameLabel"
        SaleNameLabel.Size = New Size(150, 34)
        SaleNameLabel.TabIndex = 31
        SaleNameLabel.Text = "Product 1"
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
        PlaceholderImage.TabIndex = 33
        PlaceholderImage.TabStop = False
        PlaceholderImage.UseTransparentBackground = True
        ' 
        ' StockIdLabel
        ' 
        StockIdLabel.AutoSize = True
        StockIdLabel.BackColor = Color.Transparent
        StockIdLabel.Font = New Font("Inter", 12F)
        StockIdLabel.ForeColor = Color.Black
        StockIdLabel.Location = New Point(536, 33)
        StockIdLabel.Name = "StockIdLabel"
        StockIdLabel.Size = New Size(87, 24)
        StockIdLabel.TabIndex = 34
        StockIdLabel.Text = "Stock Id"
        StockIdLabel.Visible = False
        ' 
        ' SaleIdLabel
        ' 
        SaleIdLabel.AutoSize = True
        SaleIdLabel.BackColor = Color.Transparent
        SaleIdLabel.Font = New Font("Inter", 12F)
        SaleIdLabel.ForeColor = Color.Black
        SaleIdLabel.Location = New Point(422, 33)
        SaleIdLabel.Name = "SaleIdLabel"
        SaleIdLabel.Size = New Size(74, 24)
        SaleIdLabel.TabIndex = 35
        SaleIdLabel.Text = "Sale Id"
        SaleIdLabel.Visible = False
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
        ElipseLabel.TabIndex = 36
        ElipseLabel.Text = "..."
        ElipseLabel.Visible = False
        ' 
        ' ElipseContextMenu
        ' 
        ElipseContextMenu.ImageScalingSize = New Size(20, 20)
        ElipseContextMenu.Items.AddRange(New ToolStripItem() {UpdateToolStripMenuItem, DeleteToolStripMenuItem, MoveToInventoryToolStripMenuItem})
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
        ElipseContextMenu.Size = New Size(223, 76)
        ' 
        ' UpdateToolStripMenuItem
        ' 
        UpdateToolStripMenuItem.BackColor = Color.White
        UpdateToolStripMenuItem.Font = New Font("Inter", 10.1999989F)
        UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        UpdateToolStripMenuItem.Size = New Size(222, 24)
        UpdateToolStripMenuItem.Text = "Update"
        ' 
        ' DeleteToolStripMenuItem
        ' 
        DeleteToolStripMenuItem.BackColor = Color.White
        DeleteToolStripMenuItem.Font = New Font("Inter", 10.1999989F)
        DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        DeleteToolStripMenuItem.Size = New Size(222, 24)
        DeleteToolStripMenuItem.Text = "Delete"
        ' 
        ' MoveToInventoryToolStripMenuItem
        ' 
        MoveToInventoryToolStripMenuItem.BackColor = Color.White
        MoveToInventoryToolStripMenuItem.Font = New Font("Inter", 10.1999989F)
        MoveToInventoryToolStripMenuItem.Name = "MoveToInventoryToolStripMenuItem"
        MoveToInventoryToolStripMenuItem.Size = New Size(222, 24)
        MoveToInventoryToolStripMenuItem.Text = "Move to Inventory"
        ' 
        ' SalesValuationUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(ElipseLabel)
        Controls.Add(SaleIdLabel)
        Controls.Add(StockIdLabel)
        Controls.Add(TotalSaleLabel)
        Controls.Add(NoDateLabel)
        Controls.Add(SaleNameLabel)
        Controls.Add(PlaceholderImage)
        Name = "SalesValuationUserControl"
        Size = New Size(1040, 100)
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        ElipseContextMenu.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TotalSaleLabel As Label
    Friend WithEvents ElipseForm As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents NoDateLabel As Label
    Friend WithEvents SaleNameLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents StockIdLabel As Label
    Friend WithEvents SaleIdLabel As Label
    Friend WithEvents ElipseLabel As Label
    Friend WithEvents ElipseContextMenu As Guna.UI2.WinForms.Guna2ContextMenuStrip
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveToInventoryToolStripMenuItem As ToolStripMenuItem

End Class
