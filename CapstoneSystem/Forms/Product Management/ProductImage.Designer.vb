<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductImage
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
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Label1 = New Label()
        CloseButton = New Guna.UI2.WinForms.Guna2Button()
        ProductImagePictureBox = New Guna.UI2.WinForms.Guna2PictureBox()
        CType(ProductImagePictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' FormElipse
        ' 
        FormElipse.BorderRadius = 8
        FormElipse.TargetControl = Me
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Inter Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(162, 24)
        Label1.TabIndex = 1
        Label1.Text = "Product Image"
        ' 
        ' CloseButton
        ' 
        CloseButton.Animated = True
        CloseButton.BackColor = Color.Transparent
        CloseButton.BorderRadius = 8
        CloseButton.Cursor = Cursors.Hand
        CloseButton.CustomizableEdges = CustomizableEdges3
        CloseButton.DisabledState.BorderColor = Color.DarkGray
        CloseButton.DisabledState.CustomBorderColor = Color.DarkGray
        CloseButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        CloseButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        CloseButton.FillColor = Color.FromArgb(CByte(28), CByte(28), CByte(30))
        CloseButton.Font = New Font("Inter", 12F)
        CloseButton.ForeColor = Color.White
        CloseButton.Location = New Point(20, 406)
        CloseButton.Name = "CloseButton"
        CloseButton.ShadowDecoration.BorderRadius = 8
        CloseButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        CloseButton.ShadowDecoration.Depth = 100
        CloseButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        CloseButton.Size = New Size(380, 40)
        CloseButton.TabIndex = 3
        CloseButton.Text = "Close"
        ' 
        ' ProductImagePictureBox
        ' 
        ProductImagePictureBox.CustomizableEdges = CustomizableEdges1
        ProductImagePictureBox.FillColor = Color.Transparent
        ProductImagePictureBox.ImageRotate = 0F
        ProductImagePictureBox.Location = New Point(65, 125)
        ProductImagePictureBox.Name = "ProductImagePictureBox"
        ProductImagePictureBox.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        ProductImagePictureBox.Size = New Size(291, 160)
        ProductImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ProductImagePictureBox.TabIndex = 36
        ProductImagePictureBox.TabStop = False
        ' 
        ' ProductImage
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(420, 470)
        Controls.Add(ProductImagePictureBox)
        Controls.Add(CloseButton)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "ProductImage"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ProductImage"
        CType(ProductImagePictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label1 As Label
    Friend WithEvents CloseButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ProductImagePictureBox As Guna.UI2.WinForms.Guna2PictureBox
End Class
