<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataBackupSearchUserControl
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
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        BackupIdLabel = New Label()
        BackupNameLabel = New Label()
        Guna2Panel1.SuspendLayout()
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
        Guna2Panel1.Controls.Add(BackupIdLabel)
        Guna2Panel1.Controls.Add(BackupNameLabel)
        Guna2Panel1.Cursor = Cursors.Hand
        Guna2Panel1.CustomizableEdges = CustomizableEdges1
        Guna2Panel1.FillColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        Guna2Panel1.Location = New Point(4, -2)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2Panel1.Size = New Size(357, 52)
        Guna2Panel1.TabIndex = 25
        Guna2Panel1.UseTransparentBackground = True
        ' 
        ' BackupIdLabel
        ' 
        BackupIdLabel.AutoSize = True
        BackupIdLabel.BackColor = Color.Transparent
        BackupIdLabel.Cursor = Cursors.Hand
        BackupIdLabel.Font = New Font("Inter", 7.8F)
        BackupIdLabel.ForeColor = Color.Black
        BackupIdLabel.Location = New Point(231, 18)
        BackupIdLabel.Name = "BackupIdLabel"
        BackupIdLabel.Size = New Size(18, 16)
        BackupIdLabel.TabIndex = 25
        BackupIdLabel.Text = "Id"
        BackupIdLabel.Visible = False
        ' 
        ' BackupNameLabel
        ' 
        BackupNameLabel.AutoSize = True
        BackupNameLabel.BackColor = Color.Transparent
        BackupNameLabel.Cursor = Cursors.Hand
        BackupNameLabel.Font = New Font("Inter Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BackupNameLabel.ForeColor = Color.Black
        BackupNameLabel.Location = New Point(21, 18)
        BackupNameLabel.Name = "BackupNameLabel"
        BackupNameLabel.Size = New Size(74, 16)
        BackupNameLabel.TabIndex = 20
        BackupNameLabel.Text = "Product 1"
        ' 
        ' DataBackupSearchUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        Controls.Add(Guna2Panel1)
        Name = "DataBackupSearchUserControl"
        Size = New Size(350, 50)
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents BackupIdLabel As Label
    Friend WithEvents BackupNameLabel As Label

End Class
