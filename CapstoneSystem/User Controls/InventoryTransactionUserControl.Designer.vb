<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryTransactionUserControl
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
        TransactionTypeLabel = New Label()
        QuantityDateLabel = New Label()
        StockNameLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        TransactionIdLabel = New Label()
        StockIdLabel = New Label()
        ElipseLabel = New Label()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ElipseForm
        ' 
        ElipseForm.BorderRadius = 8
        ElipseForm.TargetControl = Me
        ' 
        ' TransactionTypeLabel
        ' 
        TransactionTypeLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TransactionTypeLabel.AutoSize = True
        TransactionTypeLabel.BackColor = Color.Transparent
        TransactionTypeLabel.Font = New Font("Inter", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TransactionTypeLabel.ForeColor = Color.Black
        TransactionTypeLabel.Location = New Point(795, 33)
        TransactionTypeLabel.Name = "TransactionTypeLabel"
        TransactionTypeLabel.Size = New Size(101, 34)
        TransactionTypeLabel.TabIndex = 24
        TransactionTypeLabel.Text = "Added"
        ' 
        ' QuantityDateLabel
        ' 
        QuantityDateLabel.AutoSize = True
        QuantityDateLabel.BackColor = Color.Transparent
        QuantityDateLabel.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        QuantityDateLabel.ForeColor = Color.Black
        QuantityDateLabel.Location = New Point(92, 55)
        QuantityDateLabel.Name = "QuantityDateLabel"
        QuantityDateLabel.Size = New Size(127, 24)
        QuantityDateLabel.TabIndex = 25
        QuantityDateLabel.Text = "Stock | Date"
        ' 
        ' StockNameLabel
        ' 
        StockNameLabel.AutoSize = True
        StockNameLabel.BackColor = Color.Transparent
        StockNameLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        StockNameLabel.ForeColor = Color.Black
        StockNameLabel.Location = New Point(91, 16)
        StockNameLabel.Name = "StockNameLabel"
        StockNameLabel.Size = New Size(150, 34)
        StockNameLabel.TabIndex = 26
        StockNameLabel.Text = "Product 1"
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
        PlaceholderImage.TabIndex = 28
        PlaceholderImage.TabStop = False
        PlaceholderImage.UseTransparentBackground = True
        ' 
        ' TransactionIdLabel
        ' 
        TransactionIdLabel.AutoSize = True
        TransactionIdLabel.BackColor = Color.Transparent
        TransactionIdLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TransactionIdLabel.ForeColor = Color.Black
        TransactionIdLabel.Location = New Point(466, 33)
        TransactionIdLabel.Name = "TransactionIdLabel"
        TransactionIdLabel.Size = New Size(43, 34)
        TransactionIdLabel.TabIndex = 29
        TransactionIdLabel.Text = "Id"
        TransactionIdLabel.Visible = False
        ' 
        ' StockIdLabel
        ' 
        StockIdLabel.AutoSize = True
        StockIdLabel.BackColor = Color.Transparent
        StockIdLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        StockIdLabel.ForeColor = Color.Black
        StockIdLabel.Location = New Point(537, 33)
        StockIdLabel.Name = "StockIdLabel"
        StockIdLabel.Size = New Size(43, 34)
        StockIdLabel.TabIndex = 30
        StockIdLabel.Text = "Id"
        StockIdLabel.Visible = False
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
        ElipseLabel.TabIndex = 31
        ElipseLabel.Text = "..."
        ElipseLabel.Visible = False
        ' 
        ' InventoryTransactionUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(ElipseLabel)
        Controls.Add(StockIdLabel)
        Controls.Add(TransactionIdLabel)
        Controls.Add(TransactionTypeLabel)
        Controls.Add(QuantityDateLabel)
        Controls.Add(StockNameLabel)
        Controls.Add(PlaceholderImage)
        Name = "InventoryTransactionUserControl"
        Size = New Size(1040, 100)
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ElipseForm As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents TransactionTypeLabel As Label
    Friend WithEvents QuantityDateLabel As Label
    Friend WithEvents StockNameLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents TransactionIdLabel As Label
    Friend WithEvents StockIdLabel As Label
    Friend WithEvents ElipseLabel As Label

End Class
