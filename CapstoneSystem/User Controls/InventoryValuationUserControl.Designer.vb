<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryValuationUserControl
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
        InventoryValuationLabel = New Label()
        ElipseForm = New Guna.UI2.WinForms.Guna2Elipse(components)
        NoDateLabel = New Label()
        ValuationNameLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        ElipseLabel = New Label()
        InventoryIdLabel = New Label()
        StockIdLabel = New Label()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' InventoryValuationLabel
        ' 
        InventoryValuationLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        InventoryValuationLabel.AutoSize = True
        InventoryValuationLabel.BackColor = Color.Transparent
        InventoryValuationLabel.Font = New Font("Inter", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        InventoryValuationLabel.ForeColor = Color.Black
        InventoryValuationLabel.Location = New Point(788, 33)
        InventoryValuationLabel.Name = "InventoryValuationLabel"
        InventoryValuationLabel.Size = New Size(143, 34)
        InventoryValuationLabel.TabIndex = 34
        InventoryValuationLabel.Text = "- ₱ 3600 "
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
        NoDateLabel.TabIndex = 35
        NoDateLabel.Text = "No | Date"
        ' 
        ' ValuationNameLabel
        ' 
        ValuationNameLabel.AutoSize = True
        ValuationNameLabel.BackColor = Color.Transparent
        ValuationNameLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ValuationNameLabel.ForeColor = Color.Black
        ValuationNameLabel.Location = New Point(91, 16)
        ValuationNameLabel.Name = "ValuationNameLabel"
        ValuationNameLabel.Size = New Size(150, 34)
        ValuationNameLabel.TabIndex = 36
        ValuationNameLabel.Text = "Product 1"
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
        PlaceholderImage.TabIndex = 38
        PlaceholderImage.TabStop = False
        PlaceholderImage.UseTransparentBackground = True
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
        ElipseLabel.TabIndex = 39
        ElipseLabel.Text = "..."
        ElipseLabel.Visible = False
        ' 
        ' InventoryIdLabel
        ' 
        InventoryIdLabel.AutoSize = True
        InventoryIdLabel.BackColor = Color.Transparent
        InventoryIdLabel.Font = New Font("Inter", 12F)
        InventoryIdLabel.ForeColor = Color.Black
        InventoryIdLabel.Location = New Point(420, 38)
        InventoryIdLabel.Name = "InventoryIdLabel"
        InventoryIdLabel.Size = New Size(122, 24)
        InventoryIdLabel.TabIndex = 42
        InventoryIdLabel.Text = "Inventory Id"
        InventoryIdLabel.Visible = False
        ' 
        ' StockIdLabel
        ' 
        StockIdLabel.AutoSize = True
        StockIdLabel.BackColor = Color.Transparent
        StockIdLabel.Font = New Font("Inter", 12F)
        StockIdLabel.ForeColor = Color.Black
        StockIdLabel.Location = New Point(567, 38)
        StockIdLabel.Name = "StockIdLabel"
        StockIdLabel.Size = New Size(87, 24)
        StockIdLabel.TabIndex = 41
        StockIdLabel.Text = "Stock Id"
        StockIdLabel.Visible = False
        ' 
        ' InventoryValuationUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(InventoryIdLabel)
        Controls.Add(StockIdLabel)
        Controls.Add(ElipseLabel)
        Controls.Add(InventoryValuationLabel)
        Controls.Add(NoDateLabel)
        Controls.Add(ValuationNameLabel)
        Controls.Add(PlaceholderImage)
        Name = "InventoryValuationUserControl"
        Size = New Size(1040, 100)
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents InventoryValuationLabel As Label
    Friend WithEvents ElipseForm As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents NoDateLabel As Label
    Friend WithEvents ValuationNameLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents ElipseLabel As Label
    Friend WithEvents InventoryIdLabel As Label
    Friend WithEvents StockIdLabel As Label

End Class
