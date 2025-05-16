<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockSearchUserControl
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
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        StockId = New Label()
        ProductIdLabel = New Label()
        BatchLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        ProductNameLabel = New Label()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Guna2Panel1.SuspendLayout()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.BackColor = Color.Transparent
        Guna2Panel1.BorderRadius = 10
        Guna2Panel1.Controls.Add(StockId)
        Guna2Panel1.Controls.Add(ProductIdLabel)
        Guna2Panel1.Controls.Add(BatchLabel)
        Guna2Panel1.Controls.Add(PlaceholderImage)
        Guna2Panel1.Controls.Add(ProductNameLabel)
        Guna2Panel1.Cursor = Cursors.Hand
        Guna2Panel1.CustomizableEdges = CustomizableEdges3
        Guna2Panel1.FillColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        Guna2Panel1.Location = New Point(4, -2)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2Panel1.Size = New Size(357, 52)
        Guna2Panel1.TabIndex = 23
        Guna2Panel1.UseTransparentBackground = True
        ' 
        ' StockId
        ' 
        StockId.AutoSize = True
        StockId.BackColor = Color.Transparent
        StockId.Cursor = Cursors.Hand
        StockId.Font = New Font("Inter", 7.8F)
        StockId.ForeColor = Color.Black
        StockId.Location = New Point(221, 18)
        StockId.Name = "StockId"
        StockId.Size = New Size(18, 16)
        StockId.TabIndex = 24
        StockId.Text = "Id"
        StockId.Visible = False
        ' 
        ' ProductIdLabel
        ' 
        ProductIdLabel.AutoSize = True
        ProductIdLabel.BackColor = Color.Transparent
        ProductIdLabel.Cursor = Cursors.Hand
        ProductIdLabel.Font = New Font("Inter", 7.8F)
        ProductIdLabel.ForeColor = Color.Black
        ProductIdLabel.Location = New Point(182, 18)
        ProductIdLabel.Name = "ProductIdLabel"
        ProductIdLabel.Size = New Size(18, 16)
        ProductIdLabel.TabIndex = 23
        ProductIdLabel.Text = "Id"
        ProductIdLabel.Visible = False
        ' 
        ' BatchLabel
        ' 
        BatchLabel.AutoSize = True
        BatchLabel.BackColor = Color.Transparent
        BatchLabel.Cursor = Cursors.Hand
        BatchLabel.Font = New Font("Inter", 7.8F)
        BatchLabel.ForeColor = Color.Black
        BatchLabel.Location = New Point(66, 28)
        BatchLabel.Name = "BatchLabel"
        BatchLabel.Size = New Size(78, 16)
        BatchLabel.TabIndex = 19
        BatchLabel.Text = "BatchName"
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
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' StockSearchUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        Controls.Add(Guna2Panel1)
        Name = "StockSearchUserControl"
        Size = New Size(350, 50)
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel1.PerformLayout()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents BatchLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents ProductNameLabel As Label
    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents ProductIdLabel As Label
    Friend WithEvents StockId As Label

End Class
