<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryTransactionSearchUserControl
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
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        TransactionIdLabel = New Label()
        StockIdLabel = New Label()
        TypeLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        ProductNameLabel = New Label()
        Guna2Panel1.SuspendLayout()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.BackColor = Color.Transparent
        Guna2Panel1.BorderRadius = 10
        Guna2Panel1.Controls.Add(TransactionIdLabel)
        Guna2Panel1.Controls.Add(StockIdLabel)
        Guna2Panel1.Controls.Add(TypeLabel)
        Guna2Panel1.Controls.Add(PlaceholderImage)
        Guna2Panel1.Controls.Add(ProductNameLabel)
        Guna2Panel1.Cursor = Cursors.Hand
        Guna2Panel1.CustomizableEdges = CustomizableEdges3
        Guna2Panel1.FillColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        Guna2Panel1.Location = New Point(4, -2)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2Panel1.Size = New Size(357, 52)
        Guna2Panel1.TabIndex = 24
        Guna2Panel1.UseTransparentBackground = True
        ' 
        ' TransactionIdLabel
        ' 
        TransactionIdLabel.AutoSize = True
        TransactionIdLabel.BackColor = Color.Transparent
        TransactionIdLabel.Cursor = Cursors.Hand
        TransactionIdLabel.Font = New Font("Inter", 7.8F)
        TransactionIdLabel.ForeColor = Color.Black
        TransactionIdLabel.Location = New Point(231, 18)
        TransactionIdLabel.Name = "TransactionIdLabel"
        TransactionIdLabel.Size = New Size(18, 16)
        TransactionIdLabel.TabIndex = 25
        TransactionIdLabel.Text = "Id"
        TransactionIdLabel.Visible = False
        ' 
        ' StockIdLabel
        ' 
        StockIdLabel.AutoSize = True
        StockIdLabel.BackColor = Color.Transparent
        StockIdLabel.Cursor = Cursors.Hand
        StockIdLabel.Font = New Font("Inter", 7.8F)
        StockIdLabel.ForeColor = Color.Black
        StockIdLabel.Location = New Point(272, 18)
        StockIdLabel.Name = "StockIdLabel"
        StockIdLabel.Size = New Size(18, 16)
        StockIdLabel.TabIndex = 24
        StockIdLabel.Text = "Id"
        StockIdLabel.Visible = False
        ' 
        ' TypeLabel
        ' 
        TypeLabel.AutoSize = True
        TypeLabel.BackColor = Color.Transparent
        TypeLabel.Cursor = Cursors.Hand
        TypeLabel.Font = New Font("Inter", 7.8F)
        TypeLabel.ForeColor = Color.Black
        TypeLabel.Location = New Point(66, 28)
        TypeLabel.Name = "TypeLabel"
        TypeLabel.Size = New Size(113, 16)
        TypeLabel.TabIndex = 19
        TypeLabel.Text = "Transaction Type"
        ' 
        ' PlaceholderImage
        ' 
        PlaceholderImage.BackColor = Color.Transparent
        PlaceholderImage.Cursor = Cursors.Hand
        PlaceholderImage.CustomizableEdges = CustomizableEdges1
        PlaceholderImage.Image = My.Resources.Resources.ProductPlaceholder
        PlaceholderImage.ImageRotate = 0F
        PlaceholderImage.Location = New Point(21, 11)
        PlaceholderImage.Name = "PlaceholderImage"
        PlaceholderImage.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        PlaceholderImage.Size = New Size(30, 30)
        PlaceholderImage.SizeMode = PictureBoxSizeMode.Zoom
        PlaceholderImage.TabIndex = 21
        PlaceholderImage.TabStop = False
        PlaceholderImage.UseTransparentBackground = True
        ' 
        ' ProductNameLabel
        ' 
        ProductNameLabel.AutoSize = True
        ProductNameLabel.BackColor = Color.Transparent
        ProductNameLabel.Cursor = Cursors.Hand
        ProductNameLabel.Font = New Font("Inter SemiBold", 10.1999989F, FontStyle.Bold)
        ProductNameLabel.ForeColor = Color.Black
        ProductNameLabel.Location = New Point(65, 9)
        ProductNameLabel.Name = "ProductNameLabel"
        ProductNameLabel.Size = New Size(86, 20)
        ProductNameLabel.TabIndex = 20
        ProductNameLabel.Text = "Product 1"
        ' 
        ' InventoryTransactionSearchUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        Controls.Add(Guna2Panel1)
        Name = "InventoryTransactionSearchUserControl"
        Size = New Size(350, 50)
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel1.PerformLayout()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents StockIdLabel As Label
    Friend WithEvents TypeLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents ProductNameLabel As Label
    Friend WithEvents TransactionIdLabel As Label

End Class
