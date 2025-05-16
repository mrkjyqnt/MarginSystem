<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateReport
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
        Dim CustomizableEdges15 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges16 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges13 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges14 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        FormElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Label1 = New Label()
        Label2 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        FromMonthComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Label6 = New Label()
        FromDayComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Label7 = New Label()
        FromYearComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Label8 = New Label()
        ToYearComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Label10 = New Label()
        ToDayComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Label11 = New Label()
        ToMonthComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        ConfirmButton = New Guna.UI2.WinForms.Guna2Button()
        ShadowButton = New Guna.UI2.WinForms.Guna2Button()
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
        Label1.Font = New Font("Inter Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(17, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(213, 28)
        Label1.TabIndex = 0
        Label1.Text = "Generate Report"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Inter", 10.7999992F)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(25, 150)
        Label2.Name = "Label2"
        Label2.Size = New Size(77, 21)
        Label2.TabIndex = 0
        Label2.Text = "To Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Inter", 10.7999992F)
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(25, 86)
        Label5.Name = "Label5"
        Label5.Size = New Size(100, 21)
        Label5.TabIndex = 0
        Label5.Text = "From Date"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        Label4.Cursor = Cursors.Hand
        Label4.Font = New Font("Inter", 10.7999992F)
        Label4.ForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        Label4.Location = New Point(366, 83)
        Label4.Name = "Label4"
        Label4.Size = New Size(66, 21)
        Label4.TabIndex = 0
        Label4.Text = "Month"
        ' 
        ' FromMonthComboBox
        ' 
        FromMonthComboBox.BackColor = Color.Transparent
        FromMonthComboBox.BorderRadius = 8
        FromMonthComboBox.Cursor = Cursors.Hand
        FromMonthComboBox.CustomizableEdges = CustomizableEdges15
        FromMonthComboBox.DrawMode = DrawMode.OwnerDrawFixed
        FromMonthComboBox.DropDownHeight = 160
        FromMonthComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        FromMonthComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        FromMonthComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        FromMonthComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        FromMonthComboBox.Font = New Font("Inter", 10.7999992F)
        FromMonthComboBox.ForeColor = Color.White
        FromMonthComboBox.IntegralHeight = False
        FromMonthComboBox.ItemHeight = 40
        FromMonthComboBox.Location = New Point(347, 71)
        FromMonthComboBox.Name = "FromMonthComboBox"
        FromMonthComboBox.ShadowDecoration.BorderRadius = 8
        FromMonthComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges16
        FromMonthComboBox.ShadowDecoration.Depth = 100
        FromMonthComboBox.ShadowDecoration.Enabled = True
        FromMonthComboBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        FromMonthComboBox.Size = New Size(189, 46)
        FromMonthComboBox.TabIndex = 0
        FromMonthComboBox.TextOffset = New Point(10, 0)
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        Label6.Cursor = Cursors.Hand
        Label6.Font = New Font("Inter", 10.7999992F)
        Label6.ForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        Label6.Location = New Point(561, 83)
        Label6.Name = "Label6"
        Label6.Size = New Size(43, 21)
        Label6.TabIndex = 0
        Label6.Text = "Day"
        ' 
        ' FromDayComboBox
        ' 
        FromDayComboBox.BackColor = Color.Transparent
        FromDayComboBox.BorderRadius = 8
        FromDayComboBox.Cursor = Cursors.Hand
        FromDayComboBox.CustomizableEdges = CustomizableEdges13
        FromDayComboBox.DrawMode = DrawMode.OwnerDrawFixed
        FromDayComboBox.DropDownHeight = 160
        FromDayComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        FromDayComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        FromDayComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        FromDayComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        FromDayComboBox.Font = New Font("Inter", 10.7999992F)
        FromDayComboBox.ForeColor = Color.White
        FromDayComboBox.IntegralHeight = False
        FromDayComboBox.ItemHeight = 40
        FromDayComboBox.Location = New Point(542, 71)
        FromDayComboBox.Name = "FromDayComboBox"
        FromDayComboBox.ShadowDecoration.BorderRadius = 8
        FromDayComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges14
        FromDayComboBox.ShadowDecoration.Depth = 100
        FromDayComboBox.ShadowDecoration.Enabled = True
        FromDayComboBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        FromDayComboBox.Size = New Size(189, 46)
        FromDayComboBox.TabIndex = 0
        FromDayComboBox.TextOffset = New Point(10, 0)
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        Label7.Cursor = Cursors.Hand
        Label7.Font = New Font("Inter", 10.7999992F)
        Label7.ForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        Label7.Location = New Point(171, 83)
        Label7.Name = "Label7"
        Label7.Size = New Size(48, 21)
        Label7.TabIndex = 0
        Label7.Text = "Year"
        ' 
        ' FromYearComboBox
        ' 
        FromYearComboBox.BackColor = Color.Transparent
        FromYearComboBox.BorderRadius = 8
        FromYearComboBox.Cursor = Cursors.Hand
        FromYearComboBox.CustomizableEdges = CustomizableEdges11
        FromYearComboBox.DrawMode = DrawMode.OwnerDrawFixed
        FromYearComboBox.DropDownHeight = 160
        FromYearComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        FromYearComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        FromYearComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        FromYearComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        FromYearComboBox.Font = New Font("Inter", 10.7999992F)
        FromYearComboBox.ForeColor = Color.White
        FromYearComboBox.IntegralHeight = False
        FromYearComboBox.ItemHeight = 40
        FromYearComboBox.Items.AddRange(New Object() {"2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030"})
        FromYearComboBox.Location = New Point(152, 71)
        FromYearComboBox.Name = "FromYearComboBox"
        FromYearComboBox.ShadowDecoration.BorderRadius = 8
        FromYearComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        FromYearComboBox.ShadowDecoration.Depth = 100
        FromYearComboBox.ShadowDecoration.Enabled = True
        FromYearComboBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        FromYearComboBox.Size = New Size(189, 46)
        FromYearComboBox.TabIndex = 0
        FromYearComboBox.TextOffset = New Point(10, 0)
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        Label8.Cursor = Cursors.Hand
        Label8.Font = New Font("Inter", 10.7999992F)
        Label8.ForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        Label8.Location = New Point(171, 147)
        Label8.Name = "Label8"
        Label8.Size = New Size(48, 21)
        Label8.TabIndex = 7
        Label8.Text = "Year"
        ' 
        ' ToYearComboBox
        ' 
        ToYearComboBox.BackColor = Color.Transparent
        ToYearComboBox.BorderRadius = 8
        ToYearComboBox.Cursor = Cursors.Hand
        ToYearComboBox.CustomizableEdges = CustomizableEdges5
        ToYearComboBox.DrawMode = DrawMode.OwnerDrawFixed
        ToYearComboBox.DropDownHeight = 160
        ToYearComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ToYearComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        ToYearComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        ToYearComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        ToYearComboBox.Font = New Font("Inter", 10.7999992F)
        ToYearComboBox.ForeColor = Color.White
        ToYearComboBox.IntegralHeight = False
        ToYearComboBox.ItemHeight = 40
        ToYearComboBox.Items.AddRange(New Object() {"2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030"})
        ToYearComboBox.Location = New Point(152, 135)
        ToYearComboBox.Name = "ToYearComboBox"
        ToYearComboBox.ShadowDecoration.BorderRadius = 8
        ToYearComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        ToYearComboBox.ShadowDecoration.Depth = 100
        ToYearComboBox.ShadowDecoration.Enabled = True
        ToYearComboBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ToYearComboBox.Size = New Size(189, 46)
        ToYearComboBox.TabIndex = 0
        ToYearComboBox.TextOffset = New Point(10, 0)
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        Label10.Cursor = Cursors.Hand
        Label10.Font = New Font("Inter", 10.7999992F)
        Label10.ForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        Label10.Location = New Point(561, 147)
        Label10.Name = "Label10"
        Label10.Size = New Size(43, 21)
        Label10.TabIndex = 0
        Label10.Text = "Day"
        ' 
        ' ToDayComboBox
        ' 
        ToDayComboBox.BackColor = Color.Transparent
        ToDayComboBox.BorderRadius = 8
        ToDayComboBox.Cursor = Cursors.Hand
        ToDayComboBox.CustomizableEdges = CustomizableEdges7
        ToDayComboBox.DrawMode = DrawMode.OwnerDrawFixed
        ToDayComboBox.DropDownHeight = 160
        ToDayComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ToDayComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        ToDayComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        ToDayComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        ToDayComboBox.Font = New Font("Inter", 10.7999992F)
        ToDayComboBox.ForeColor = Color.White
        ToDayComboBox.IntegralHeight = False
        ToDayComboBox.ItemHeight = 40
        ToDayComboBox.Location = New Point(542, 135)
        ToDayComboBox.Name = "ToDayComboBox"
        ToDayComboBox.ShadowDecoration.BorderRadius = 8
        ToDayComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        ToDayComboBox.ShadowDecoration.Depth = 100
        ToDayComboBox.ShadowDecoration.Enabled = True
        ToDayComboBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ToDayComboBox.Size = New Size(189, 46)
        ToDayComboBox.TabIndex = 0
        ToDayComboBox.TextOffset = New Point(10, 0)
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        Label11.Cursor = Cursors.Hand
        Label11.Font = New Font("Inter", 10.7999992F)
        Label11.ForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(147))
        Label11.Location = New Point(366, 147)
        Label11.Name = "Label11"
        Label11.Size = New Size(66, 21)
        Label11.TabIndex = 0
        Label11.Text = "Month"
        ' 
        ' ToMonthComboBox
        ' 
        ToMonthComboBox.BackColor = Color.Transparent
        ToMonthComboBox.BorderRadius = 8
        ToMonthComboBox.Cursor = Cursors.Hand
        ToMonthComboBox.CustomizableEdges = CustomizableEdges9
        ToMonthComboBox.DrawMode = DrawMode.OwnerDrawFixed
        ToMonthComboBox.DropDownHeight = 160
        ToMonthComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ToMonthComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        ToMonthComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        ToMonthComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        ToMonthComboBox.Font = New Font("Inter", 10.7999992F)
        ToMonthComboBox.ForeColor = Color.White
        ToMonthComboBox.IntegralHeight = False
        ToMonthComboBox.ItemHeight = 40
        ToMonthComboBox.Location = New Point(347, 135)
        ToMonthComboBox.Name = "ToMonthComboBox"
        ToMonthComboBox.ShadowDecoration.BorderRadius = 8
        ToMonthComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        ToMonthComboBox.ShadowDecoration.Depth = 100
        ToMonthComboBox.ShadowDecoration.Enabled = True
        ToMonthComboBox.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ToMonthComboBox.Size = New Size(189, 46)
        ToMonthComboBox.TabIndex = 0
        ToMonthComboBox.TextOffset = New Point(10, 0)
        ' 
        ' ConfirmButton
        ' 
        ConfirmButton.Animated = True
        ConfirmButton.BackColor = Color.Transparent
        ConfirmButton.BorderRadius = 8
        ConfirmButton.Cursor = Cursors.Hand
        ConfirmButton.CustomizableEdges = CustomizableEdges1
        ConfirmButton.DisabledState.BorderColor = Color.DarkGray
        ConfirmButton.DisabledState.CustomBorderColor = Color.DarkGray
        ConfirmButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ConfirmButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ConfirmButton.FillColor = Color.FromArgb(CByte(39), CByte(110), CByte(241))
        ConfirmButton.Font = New Font("Inter", 10.7999992F)
        ConfirmButton.ForeColor = Color.White
        ConfirmButton.Location = New Point(399, 209)
        ConfirmButton.Name = "ConfirmButton"
        ConfirmButton.ShadowDecoration.BorderRadius = 8
        ConfirmButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        ConfirmButton.ShadowDecoration.Depth = 100
        ConfirmButton.ShadowDecoration.Enabled = True
        ConfirmButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ConfirmButton.Size = New Size(332, 40)
        ConfirmButton.TabIndex = 2
        ConfirmButton.Text = "Confirm"
        ' 
        ' ShadowButton
        ' 
        ShadowButton.Animated = True
        ShadowButton.BackColor = Color.Transparent
        ShadowButton.BorderRadius = 8
        ShadowButton.Cursor = Cursors.Hand
        ShadowButton.CustomizableEdges = CustomizableEdges3
        ShadowButton.DisabledState.BorderColor = Color.DarkGray
        ShadowButton.DisabledState.CustomBorderColor = Color.DarkGray
        ShadowButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ShadowButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ShadowButton.FillColor = Color.FromArgb(CByte(28), CByte(28), CByte(30))
        ShadowButton.Font = New Font("Inter", 10.7999992F)
        ShadowButton.ForeColor = Color.White
        ShadowButton.Location = New Point(25, 209)
        ShadowButton.Name = "ShadowButton"
        ShadowButton.ShadowDecoration.BorderRadius = 8
        ShadowButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        ShadowButton.ShadowDecoration.Depth = 100
        ShadowButton.ShadowDecoration.Enabled = True
        ShadowButton.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        ShadowButton.Size = New Size(367, 40)
        ShadowButton.TabIndex = 1
        ShadowButton.Text = "Back"
        ' 
        ' GenerateReport
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(754, 271)
        Controls.Add(ConfirmButton)
        Controls.Add(ShadowButton)
        Controls.Add(Label8)
        Controls.Add(ToYearComboBox)
        Controls.Add(Label10)
        Controls.Add(ToDayComboBox)
        Controls.Add(Label11)
        Controls.Add(ToMonthComboBox)
        Controls.Add(Label7)
        Controls.Add(FromYearComboBox)
        Controls.Add(Label6)
        Controls.Add(FromDayComboBox)
        Controls.Add(Label4)
        Controls.Add(FromMonthComboBox)
        Controls.Add(Label2)
        Controls.Add(Label5)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Location = New Point(17, 85)
        Name = "GenerateReport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GenerateReport"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FormElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents FromDayComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents FromMonthComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ToYearComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ToDayComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ToMonthComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents FromYearComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents ConfirmButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ShadowButton As Guna.UI2.WinForms.Guna2Button
End Class
