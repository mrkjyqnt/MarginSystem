<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActivityValuationUserControl
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
        ElipseForm = New Guna.UI2.WinForms.Guna2Elipse(components)
        DateManagementLabel = New Label()
        ActivityNameLabel = New Label()
        ActtivityIdLabel = New Label()
        ElipseLabel = New Label()
        SuspendLayout()
        ' 
        ' ElipseForm
        ' 
        ElipseForm.BorderRadius = 8
        ElipseForm.TargetControl = Me
        ' 
        ' DateManagementLabel
        ' 
        DateManagementLabel.AutoSize = True
        DateManagementLabel.BackColor = Color.Transparent
        DateManagementLabel.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateManagementLabel.ForeColor = Color.FromArgb(CByte(199), CByte(199), CByte(204))
        DateManagementLabel.Location = New Point(20, 55)
        DateManagementLabel.Name = "DateManagementLabel"
        DateManagementLabel.Size = New Size(197, 24)
        DateManagementLabel.TabIndex = 20
        DateManagementLabel.Text = "Date | Management"
        ' 
        ' ActivityNameLabel
        ' 
        ActivityNameLabel.AutoSize = True
        ActivityNameLabel.BackColor = Color.Transparent
        ActivityNameLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ActivityNameLabel.ForeColor = Color.Black
        ActivityNameLabel.Location = New Point(17, 16)
        ActivityNameLabel.Name = "ActivityNameLabel"
        ActivityNameLabel.Size = New Size(141, 34)
        ActivityNameLabel.TabIndex = 21
        ActivityNameLabel.Text = "Changes"
        ' 
        ' ActtivityIdLabel
        ' 
        ActtivityIdLabel.AutoSize = True
        ActtivityIdLabel.BackColor = Color.Transparent
        ActtivityIdLabel.Font = New Font("Inter Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ActtivityIdLabel.ForeColor = Color.Black
        ActtivityIdLabel.Location = New Point(404, 33)
        ActtivityIdLabel.Name = "ActtivityIdLabel"
        ActtivityIdLabel.Size = New Size(43, 34)
        ActtivityIdLabel.TabIndex = 23
        ActtivityIdLabel.Text = "Id"
        ActtivityIdLabel.Visible = False
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
        ElipseLabel.TabIndex = 25
        ElipseLabel.Text = "..."
        ElipseLabel.Visible = False
        ' 
        ' ActivityValuationUserControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(ElipseLabel)
        Controls.Add(ActtivityIdLabel)
        Controls.Add(DateManagementLabel)
        Controls.Add(ActivityNameLabel)
        Name = "ActivityValuationUserControl"
        Size = New Size(1040, 100)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ElipseForm As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents DateManagementLabel As Label
    Friend WithEvents ActivityNameLabel As Label
    Friend WithEvents ActtivityIdLabel As Label
    Friend WithEvents ElipseLabel As Label

End Class
