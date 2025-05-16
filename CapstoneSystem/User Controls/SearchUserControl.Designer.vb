<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchUserControl
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
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        ProductIdLabel = New Label()
        ProductNameLabel = New Label()
        PlaceholderImage = New Guna.UI2.WinForms.Guna2PictureBox()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        IdLabel = New Label()
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).BeginInit()
        Guna2Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' ProductIdLabel
        ' 
        ProductIdLabel.AutoSize = True
        ProductIdLabel.BackColor = Color.Transparent
        ProductIdLabel.Cursor = Cursors.Hand
        ProductIdLabel.Font = New Font("Inter", 7.8F)
        ProductIdLabel.ForeColor = Color.Black
        ProductIdLabel.Location = New Point(66, 28)
        ProductIdLabel.Name = "ProductIdLabel"
        ProductIdLabel.Size = New Size(72, 16)
        ProductIdLabel.TabIndex = 19
        ProductIdLabel.Text = "Product ID"
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
        ' Guna2Panel1
        ' 
        Guna2Panel1.BackColor = Color.Transparent
        Guna2Panel1.BorderRadius = 10
        Guna2Panel1.Controls.Add(IdLabel)
        Guna2Panel1.Controls.Add(ProductIdLabel)
        Guna2Panel1.Controls.Add(PlaceholderImage)
        Guna2Panel1.Controls.Add(ProductNameLabel)
        Guna2Panel1.Cursor = Cursors.Hand
        Guna2Panel1.CustomizableEdges = CustomizableEdges3
        Guna2Panel1.FillColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        Guna2Panel1.Location = New Point(4, -2)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2Panel1.Size = New Size(357, 52)
        Guna2Panel1.TabIndex = 22
        Guna2Panel1.UseTransparentBackground = True
        ' 
        ' IdLabel
        ' 
        IdLabel.AutoSize = True
        IdLabel.BackColor = Color.Transparent
        IdLabel.Cursor = Cursors.Hand
        IdLabel.Font = New Font("Inter", 7.8F)
        IdLabel.ForeColor = Color.Black
        IdLabel.Location = New Point(258, 18)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New Size(72, 16)
        IdLabel.TabIndex = 22
        IdLabel.Text = "Product ID"
        IdLabel.Visible = False
        ' 
        ' SearchUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        Controls.Add(Guna2Panel1)
        DoubleBuffered = True
        Name = "SearchUserControl"
        Size = New Size(350, 50)
        CType(PlaceholderImage, ComponentModel.ISupportInitialize).EndInit()
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents ProductIdLabel As Label
    Friend WithEvents ProductNameLabel As Label
    Friend WithEvents PlaceholderImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents IdLabel As Label

End Class
