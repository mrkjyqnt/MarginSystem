<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Barcode
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Label1 = New Label()
        CloseButton = New Guna.UI2.WinForms.Guna2Button()
        BarcodeImage = New Guna.UI2.WinForms.Guna2PictureBox()
        Label2 = New Label()
        Label3 = New Label()
        ProductCodeTextBox = New Guna.UI2.WinForms.Guna2TextBox()
        CType(BarcodeImage, ComponentModel.ISupportInitialize).BeginInit()
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
        Label1.Size = New Size(97, 24)
        Label1.TabIndex = 0
        Label1.Text = "Barcode"
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
        CloseButton.TabIndex = 2
        CloseButton.Text = "Close"
        ' 
        ' BarcodeImage
        ' 
        BarcodeImage.CustomizableEdges = CustomizableEdges1
        BarcodeImage.FillColor = Color.Transparent
        BarcodeImage.ImageRotate = 0F
        BarcodeImage.Location = New Point(65, 133)
        BarcodeImage.Name = "BarcodeImage"
        BarcodeImage.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        BarcodeImage.Size = New Size(291, 160)
        BarcodeImage.SizeMode = PictureBoxSizeMode.Zoom
        BarcodeImage.TabIndex = 35
        BarcodeImage.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(158, 217)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 21)
        Label2.TabIndex = 0
        Label2.Text = "Scanning..."
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(147, 296)
        Label3.Name = "Label3"
        Label3.Size = New Size(127, 21)
        Label3.TabIndex = 36
        Label3.Text = "Product Code"
        ' 
        ' ProductCodeTextBox
        ' 
        ProductCodeTextBox.BorderRadius = 8
        ProductCodeTextBox.CustomizableEdges = CustomizableEdges5
        ProductCodeTextBox.DefaultText = ""
        ProductCodeTextBox.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        ProductCodeTextBox.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        ProductCodeTextBox.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        ProductCodeTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        ProductCodeTextBox.FillColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        ProductCodeTextBox.FocusedState.BorderColor = Color.Black
        ProductCodeTextBox.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ProductCodeTextBox.ForeColor = Color.Black
        ProductCodeTextBox.HoverState.BorderColor = Color.Black
        ProductCodeTextBox.IconLeftOffset = New Point(20, 0)
        ProductCodeTextBox.Location = New Point(60, 473)
        ProductCodeTextBox.Margin = New Padding(4, 5, 4, 5)
        ProductCodeTextBox.Name = "ProductCodeTextBox"
        ProductCodeTextBox.PasswordChar = ChrW(0)
        ProductCodeTextBox.PlaceholderForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        ProductCodeTextBox.PlaceholderText = "Barcode"
        ProductCodeTextBox.SelectedText = ""
        ProductCodeTextBox.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        ProductCodeTextBox.Size = New Size(334, 31)
        ProductCodeTextBox.TabIndex = 1
        ProductCodeTextBox.TextOffset = New Point(10, 0)
        ' 
        ' Barcode
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(420, 470)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(BarcodeImage)
        Controls.Add(CloseButton)
        Controls.Add(Label1)
        Controls.Add(ProductCodeTextBox)
        FormBorderStyle = FormBorderStyle.None
        Name = "Barcode"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Barcode"
        CType(BarcodeImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label1 As Label
    Friend WithEvents CloseButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BarcodeImage As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ProductCodeTextBox As Guna.UI2.WinForms.Guna2TextBox
End Class
