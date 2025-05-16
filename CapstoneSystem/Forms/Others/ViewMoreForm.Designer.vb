<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewMoreForm
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        BackLabel = New Label()
        InventoryTransactionDataGridView = New Guna.UI2.WinForms.Guna2DataGridView()
        Label24 = New Label()
        FilterByComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Label26 = New Label()
        SortByComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Label28 = New Label()
        DateComboBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        SearchByLabel = New Label()
        FoundLabel = New Label()
        DatagridElipse = New Guna.UI2.WinForms.Guna2Elipse(components)
        Label1 = New Label()
        BackLabel2 = New Label()
        CType(InventoryTransactionDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BackLabel
        ' 
        BackLabel.AutoSize = True
        BackLabel.Cursor = Cursors.Hand
        BackLabel.Font = New Font("Inter SemiBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BackLabel.Location = New Point(-2, 0)
        BackLabel.Name = "BackLabel"
        BackLabel.Size = New Size(383, 41)
        BackLabel.TabIndex = 1
        BackLabel.Text = "Valuation and Reports"
        ' 
        ' InventoryTransactionDataGridView
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        InventoryTransactionDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        InventoryTransactionDataGridView.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        InventoryTransactionDataGridView.BackgroundColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        InventoryTransactionDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        InventoryTransactionDataGridView.ColumnHeadersHeight = 4
        InventoryTransactionDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        InventoryTransactionDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        InventoryTransactionDataGridView.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        InventoryTransactionDataGridView.Location = New Point(12, 185)
        InventoryTransactionDataGridView.Name = "InventoryTransactionDataGridView"
        InventoryTransactionDataGridView.RowHeadersVisible = False
        InventoryTransactionDataGridView.RowHeadersWidth = 51
        InventoryTransactionDataGridView.Size = New Size(1045, 536)
        InventoryTransactionDataGridView.TabIndex = 0
        InventoryTransactionDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        InventoryTransactionDataGridView.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        InventoryTransactionDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        InventoryTransactionDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        InventoryTransactionDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        InventoryTransactionDataGridView.ThemeStyle.BackColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        InventoryTransactionDataGridView.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        InventoryTransactionDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        InventoryTransactionDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        InventoryTransactionDataGridView.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        InventoryTransactionDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White
        InventoryTransactionDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        InventoryTransactionDataGridView.ThemeStyle.HeaderStyle.Height = 4
        InventoryTransactionDataGridView.ThemeStyle.ReadOnly = False
        InventoryTransactionDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White
        InventoryTransactionDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        InventoryTransactionDataGridView.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        InventoryTransactionDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        InventoryTransactionDataGridView.ThemeStyle.RowsStyle.Height = 29
        InventoryTransactionDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        InventoryTransactionDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' Label24
        ' 
        Label24.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label24.AutoSize = True
        Label24.BackColor = Color.Transparent
        Label24.Cursor = Cursors.Hand
        Label24.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label24.ForeColor = Color.Black
        Label24.Location = New Point(523, 124)
        Label24.Name = "Label24"
        Label24.Size = New Size(84, 21)
        Label24.TabIndex = 0
        Label24.Text = "Filter by:"
        ' 
        ' FilterByComboBox
        ' 
        FilterByComboBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        FilterByComboBox.BackColor = Color.Transparent
        FilterByComboBox.BorderRadius = 8
        FilterByComboBox.Cursor = Cursors.Hand
        FilterByComboBox.CustomizableEdges = CustomizableEdges1
        FilterByComboBox.DrawMode = DrawMode.OwnerDrawFixed
        FilterByComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        FilterByComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        FilterByComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        FilterByComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        FilterByComboBox.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FilterByComboBox.ForeColor = Color.White
        FilterByComboBox.ItemHeight = 40
        FilterByComboBox.Location = New Point(615, 112)
        FilterByComboBox.Name = "FilterByComboBox"
        FilterByComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        FilterByComboBox.Size = New Size(157, 46)
        FilterByComboBox.TabIndex = 5
        ' 
        ' Label26
        ' 
        Label26.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label26.AutoSize = True
        Label26.BackColor = Color.Transparent
        Label26.Cursor = Cursors.Hand
        Label26.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label26.ForeColor = Color.Black
        Label26.Location = New Point(781, 124)
        Label26.Name = "Label26"
        Label26.Size = New Size(79, 21)
        Label26.TabIndex = 0
        Label26.Text = "Sort By:"
        ' 
        ' SortByComboBox
        ' 
        SortByComboBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SortByComboBox.BackColor = Color.Transparent
        SortByComboBox.BorderRadius = 8
        SortByComboBox.Cursor = Cursors.Hand
        SortByComboBox.CustomizableEdges = CustomizableEdges3
        SortByComboBox.DrawMode = DrawMode.OwnerDrawFixed
        SortByComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        SortByComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        SortByComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        SortByComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        SortByComboBox.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SortByComboBox.ForeColor = Color.White
        SortByComboBox.ItemHeight = 40
        SortByComboBox.Location = New Point(865, 112)
        SortByComboBox.Name = "SortByComboBox"
        SortByComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        SortByComboBox.Size = New Size(192, 46)
        SortByComboBox.TabIndex = 6
        ' 
        ' Label28
        ' 
        Label28.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label28.AutoSize = True
        Label28.BackColor = Color.Transparent
        Label28.Cursor = Cursors.Hand
        Label28.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label28.ForeColor = Color.Black
        Label28.Location = New Point(762, 72)
        Label28.Name = "Label28"
        Label28.Size = New Size(55, 21)
        Label28.TabIndex = 0
        Label28.Text = "Date:"
        ' 
        ' DateComboBox
        ' 
        DateComboBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        DateComboBox.BackColor = Color.Transparent
        DateComboBox.BorderRadius = 8
        DateComboBox.Cursor = Cursors.Hand
        DateComboBox.CustomizableEdges = CustomizableEdges5
        DateComboBox.DrawMode = DrawMode.OwnerDrawFixed
        DateComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        DateComboBox.FillColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        DateComboBox.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        DateComboBox.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        DateComboBox.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateComboBox.ForeColor = Color.White
        DateComboBox.ItemHeight = 40
        DateComboBox.Location = New Point(832, 60)
        DateComboBox.Name = "DateComboBox"
        DateComboBox.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        DateComboBox.Size = New Size(225, 46)
        DateComboBox.TabIndex = 4
        ' 
        ' Guna2TextBox1
        ' 
        Guna2TextBox1.BackColor = Color.Transparent
        Guna2TextBox1.BorderColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        Guna2TextBox1.BorderRadius = 8
        Guna2TextBox1.CustomizableEdges = CustomizableEdges7
        Guna2TextBox1.DefaultText = ""
        Guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        Guna2TextBox1.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox1.FillColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        Guna2TextBox1.FocusedState.BorderColor = Color.Black
        Guna2TextBox1.Font = New Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Guna2TextBox1.ForeColor = Color.Black
        Guna2TextBox1.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox1.Location = New Point(42, 93)
        Guna2TextBox1.Margin = New Padding(4, 5, 4, 5)
        Guna2TextBox1.Name = "Guna2TextBox1"
        Guna2TextBox1.PasswordChar = ChrW(0)
        Guna2TextBox1.PlaceholderForeColor = Color.FromArgb(CByte(174), CByte(174), CByte(178))
        Guna2TextBox1.PlaceholderText = "Search"
        Guna2TextBox1.SelectedText = ""
        Guna2TextBox1.ShadowDecoration.BorderRadius = 8
        Guna2TextBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2TextBox1.ShadowDecoration.Depth = 255
        Guna2TextBox1.ShadowDecoration.Enabled = True
        Guna2TextBox1.ShadowDecoration.Shadow = New Padding(0, 0, 0, 3)
        Guna2TextBox1.Size = New Size(311, 40)
        Guna2TextBox1.TabIndex = 3
        Guna2TextBox1.TextOffset = New Point(10, 0)
        ' 
        ' Guna2PictureBox1
        ' 
        Guna2PictureBox1.BackColor = Color.Transparent
        Guna2PictureBox1.CustomizableEdges = CustomizableEdges9
        Guna2PictureBox1.Image = My.Resources.Resources.Search
        Guna2PictureBox1.ImageRotate = 0F
        Guna2PictureBox1.Location = New Point(7, 101)
        Guna2PictureBox1.Name = "Guna2PictureBox1"
        Guna2PictureBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        Guna2PictureBox1.Size = New Size(24, 24)
        Guna2PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        Guna2PictureBox1.TabIndex = 91
        Guna2PictureBox1.TabStop = False
        Guna2PictureBox1.UseTransparentBackground = True
        ' 
        ' SearchByLabel
        ' 
        SearchByLabel.AutoSize = True
        SearchByLabel.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SearchByLabel.Location = New Point(3, 64)
        SearchByLabel.Name = "SearchByLabel"
        SearchByLabel.Size = New Size(262, 21)
        SearchByLabel.TabIndex = 0
        SearchByLabel.Text = "Search Inventory Transaction"
        ' 
        ' FoundLabel
        ' 
        FoundLabel.AutoSize = True
        FoundLabel.Font = New Font("Inter", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FoundLabel.ForeColor = Color.FromArgb(CByte(72), CByte(72), CByte(74))
        FoundLabel.Location = New Point(8, 156)
        FoundLabel.Name = "FoundLabel"
        FoundLabel.Size = New Size(186, 21)
        FoundLabel.TabIndex = 0
        FoundLabel.Text = "10 transaction found"
        ' 
        ' DatagridElipse
        ' 
        DatagridElipse.BorderRadius = 10
        DatagridElipse.TargetControl = InventoryTransactionDataGridView
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Inter SemiBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(683, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(192, 41)
        Label1.TabIndex = 0
        Label1.Text = ">  Records"
        ' 
        ' BackLabel2
        ' 
        BackLabel2.AutoSize = True
        BackLabel2.Cursor = Cursors.Hand
        BackLabel2.Font = New Font("Inter SemiBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BackLabel2.Location = New Point(377, 0)
        BackLabel2.Name = "BackLabel2"
        BackLabel2.Size = New Size(312, 41)
        BackLabel2.TabIndex = 2
        BackLabel2.Text = ">  Sales Valuation"
        ' 
        ' ViewMoreForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(229), CByte(229), CByte(234))
        ClientSize = New Size(1085, 725)
        Controls.Add(BackLabel)
        Controls.Add(InventoryTransactionDataGridView)
        Controls.Add(Label24)
        Controls.Add(FilterByComboBox)
        Controls.Add(Label26)
        Controls.Add(SortByComboBox)
        Controls.Add(Label28)
        Controls.Add(DateComboBox)
        Controls.Add(Guna2TextBox1)
        Controls.Add(Guna2PictureBox1)
        Controls.Add(SearchByLabel)
        Controls.Add(FoundLabel)
        Controls.Add(Label1)
        Controls.Add(BackLabel2)
        FormBorderStyle = FormBorderStyle.None
        Name = "ViewMoreForm"
        Text = "ViewMoreSale"
        CType(InventoryTransactionDataGridView, ComponentModel.ISupportInitialize).EndInit()
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BackLabel As Label
    Friend WithEvents InventoryTransactionDataGridView As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Label24 As Label
    Friend WithEvents FilterByComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents SortByComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents DateComboBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents SearchByLabel As Label
    Friend WithEvents FoundLabel As Label
    Friend WithEvents DatagridElipse As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label1 As Label
    Friend WithEvents BackLabel2 As Label
End Class
