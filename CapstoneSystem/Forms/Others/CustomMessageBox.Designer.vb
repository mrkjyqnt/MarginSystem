<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMessageBox
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        PanelTitleBar = New Panel()
        LabelCaption = New Label()
        CloseButton = New Guna.UI2.WinForms.Guna2ControlBox()
        PanelBody = New Panel()
        PictureBoxIcon = New PictureBox()
        labelMessage = New Label()
        PanelButtons = New Guna.UI2.WinForms.Guna2Panel()
        Button3 = New Guna.UI2.WinForms.Guna2Button()
        Button2 = New Guna.UI2.WinForms.Guna2Button()
        Button1 = New Guna.UI2.WinForms.Guna2Button()
        PanelTitleBar.SuspendLayout()
        PanelBody.SuspendLayout()
        CType(PictureBoxIcon, ComponentModel.ISupportInitialize).BeginInit()
        PanelButtons.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelTitleBar
        ' 
        PanelTitleBar.BackColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        PanelTitleBar.Controls.Add(LabelCaption)
        PanelTitleBar.Controls.Add(CloseButton)
        PanelTitleBar.Dock = DockStyle.Top
        PanelTitleBar.Location = New Point(0, 0)
        PanelTitleBar.Name = "PanelTitleBar"
        PanelTitleBar.Size = New Size(468, 36)
        PanelTitleBar.TabIndex = 2
        ' 
        ' LabelCaption
        ' 
        LabelCaption.AutoSize = True
        LabelCaption.BackColor = Color.Transparent
        LabelCaption.Font = New Font("Inter", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelCaption.Location = New Point(7, 8)
        LabelCaption.Name = "LabelCaption"
        LabelCaption.Size = New Size(189, 20)
        LabelCaption.TabIndex = 2
        LabelCaption.Text = "Message Box Caption "
        ' 
        ' CloseButton
        ' 
        CloseButton.BackColor = Color.Transparent
        CloseButton.CustomizableEdges = CustomizableEdges1
        CloseButton.Dock = DockStyle.Right
        CloseButton.FillColor = Color.Transparent
        CloseButton.HoverState.FillColor = Color.Red
        CloseButton.HoverState.IconColor = Color.Black
        CloseButton.IconColor = Color.Black
        CloseButton.Location = New Point(412, 0)
        CloseButton.Name = "CloseButton"
        CloseButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        CloseButton.Size = New Size(56, 36)
        CloseButton.TabIndex = 1
        CloseButton.UseTransparentBackground = True
        ' 
        ' PanelBody
        ' 
        PanelBody.BackColor = Color.Transparent
        PanelBody.Controls.Add(PictureBoxIcon)
        PanelBody.Controls.Add(labelMessage)
        PanelBody.Dock = DockStyle.Fill
        PanelBody.Location = New Point(0, 36)
        PanelBody.Name = "PanelBody"
        PanelBody.Size = New Size(468, 133)
        PanelBody.TabIndex = 10
        ' 
        ' PictureBoxIcon
        ' 
        PictureBoxIcon.BackColor = Color.Transparent
        PictureBoxIcon.Image = My.Resources.Resources.Information
        PictureBoxIcon.Location = New Point(22, 18)
        PictureBoxIcon.Name = "PictureBoxIcon"
        PictureBoxIcon.Size = New Size(48, 43)
        PictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom
        PictureBoxIcon.TabIndex = 9
        PictureBoxIcon.TabStop = False
        ' 
        ' labelMessage
        ' 
        labelMessage.AutoSize = True
        labelMessage.BackColor = Color.Transparent
        labelMessage.Font = New Font("Inter", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelMessage.Location = New Point(87, 28)
        labelMessage.Name = "labelMessage"
        labelMessage.Size = New Size(132, 20)
        labelMessage.TabIndex = 10
        labelMessage.Text = "Label Message"
        ' 
        ' PanelButtons
        ' 
        PanelButtons.Controls.Add(Button3)
        PanelButtons.Controls.Add(Button2)
        PanelButtons.Controls.Add(Button1)
        PanelButtons.CustomizableEdges = CustomizableEdges9
        PanelButtons.Dock = DockStyle.Bottom
        PanelButtons.FillColor = Color.White
        PanelButtons.Location = New Point(0, 113)
        PanelButtons.Name = "PanelButtons"
        PanelButtons.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        PanelButtons.Size = New Size(468, 56)
        PanelButtons.TabIndex = 11
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Transparent
        Button3.BorderRadius = 8
        Button3.CustomizableEdges = CustomizableEdges3
        Button3.DisabledState.BorderColor = Color.DarkGray
        Button3.DisabledState.CustomBorderColor = Color.DarkGray
        Button3.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Button3.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Button3.Font = New Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.White
        Button3.Location = New Point(305, 10)
        Button3.Name = "Button3"
        Button3.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Button3.Size = New Size(130, 36)
        Button3.TabIndex = 8
        Button3.Text = "Button 3"
        Button3.UseTransparentBackground = True
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.BorderRadius = 8
        Button2.CustomizableEdges = CustomizableEdges5
        Button2.DisabledState.BorderColor = Color.DarkGray
        Button2.DisabledState.CustomBorderColor = Color.DarkGray
        Button2.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Button2.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Button2.Font = New Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.White
        Button2.Location = New Point(169, 10)
        Button2.Name = "Button2"
        Button2.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Button2.Size = New Size(130, 36)
        Button2.TabIndex = 7
        Button2.Text = "Button 2"
        Button2.UseTransparentBackground = True
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.BorderRadius = 8
        Button1.CustomizableEdges = CustomizableEdges7
        Button1.DisabledState.BorderColor = Color.DarkGray
        Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Button1.Font = New Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(33, 10)
        Button1.Name = "Button1"
        Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Button1.Size = New Size(130, 36)
        Button1.TabIndex = 6
        Button1.Text = "Button 1"
        Button1.UseTransparentBackground = True
        ' 
        ' FormMessageBox
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(468, 169)
        Controls.Add(PanelButtons)
        Controls.Add(PanelBody)
        Controls.Add(PanelTitleBar)
        Name = "FormMessageBox"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CustomMessageBox"
        PanelTitleBar.ResumeLayout(False)
        PanelTitleBar.PerformLayout()
        PanelBody.ResumeLayout(False)
        PanelBody.PerformLayout()
        CType(PictureBoxIcon, ComponentModel.ISupportInitialize).EndInit()
        PanelButtons.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents LabelCaption As Label
    Friend WithEvents CloseButton As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents PanelTitleBar As Panel
    Friend WithEvents PanelBody As Panel
    Friend WithEvents PictureBoxIcon As PictureBox
    Friend WithEvents labelMessage As Label
    Friend WithEvents PanelButtons As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Button3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Button1 As Guna.UI2.WinForms.Guna2Button
End Class
