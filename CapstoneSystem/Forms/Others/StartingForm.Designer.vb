<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StartingForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartingForm))
        LoadingTimer = New Timer(components)
        Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LoadingTimer
        ' 
        LoadingTimer.Interval = 1000
        ' 
        ' Guna2PictureBox1
        ' 
        Guna2PictureBox1.BackColor = Color.Transparent
        Guna2PictureBox1.CustomizableEdges = CustomizableEdges1
        Guna2PictureBox1.Dock = DockStyle.Fill
        Guna2PictureBox1.Image = My.Resources.Resources.TestingSplash
        Guna2PictureBox1.ImageRotate = 0F
        Guna2PictureBox1.Location = New Point(0, 0)
        Guna2PictureBox1.Name = "Guna2PictureBox1"
        Guna2PictureBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2PictureBox1.Size = New Size(1022, 593)
        Guna2PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        Guna2PictureBox1.TabIndex = 0
        Guna2PictureBox1.TabStop = False
        Guna2PictureBox1.UseTransparentBackground = True
        ' 
        ' StartingForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1022, 593)
        Controls.Add(Guna2PictureBox1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "StartingForm"
        Opacity = 0R
        StartPosition = FormStartPosition.CenterScreen
        Text = " Welcome!"
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents LoadingTimer As Timer
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox

End Class
