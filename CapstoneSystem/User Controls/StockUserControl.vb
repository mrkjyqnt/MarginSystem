Public Class StockUserControl

    Dim ClickElipse As Integer = 0
    Dim BatchExpired As Boolean
    Dim BatchAboutToExpired As Boolean

    Private Sub StockLabel_MouseEnter(sender As Object, e As EventArgs) Handles StockLabel.MouseEnter, WarehouseBatchLabel.MouseEnter, StockNameLabel.MouseEnter, PlaceholderImage.MouseEnter, MyBase.MouseEnter

        GeneralModule.UserControlToButton(Me, 210)

    End Sub

    Private Sub StockUserControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave

        GeneralModule.UserControlToButton(Me, 247)

    End Sub

    Private Sub StockLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles StockLabel.MouseDown, WarehouseBatchLabel.MouseDown, StockNameLabel.MouseDown, PlaceholderImage.MouseDown, MyBase.MouseDown

        GeneralModule.UserControlToButton(Me, 147)

    End Sub

    Private Async Sub StockUserControl_Click(sender As Object, e As EventArgs) Handles StockLabel.Click, WarehouseBatchLabel.Click, ProductIdLabel.Click, StockNameLabel.Click, PlaceholderImage.Click, MyBase.Click

        StockInfo.Opacity = 0

        Dim ProductId As Integer = Integer.Parse(ProductIdLabel.Text)
        Dim StockId As Integer = Integer.Parse(StockIdLabel.Text)

        StockInfo.ProductCodeTextBox.Text = Await StockManagementModule.GetBarcode(ProductId)
        StockInfo.BatchCodeTextBox.Text = Await StockManagementModule.GetBatchFromStock(StockId)
        StockInfo.ProductNameTextBox.Text = Await StockManagementModule.GetProductName(ProductId)
        StockInfo.QuantityTextBox.Text = Await StockManagementModule.GetCurrentStock(StockId)
        StockInfo.InventoryPriceTextBox.Text = Await ProductManagementDatabaseModule.GetRetail(ProductId)
        StockInfo.ExpirationTextBox.Text = Await StockManagementModule.GetExpiration(StockId)
        StockInfo.WarehouseTextBox.Text = Await StockManagementModule.GetWarehouse(Await StockManagementModule.GetWarehouseFromStock(StockId))

        If BatchExpired

            StockInfo.BatchStatusLabel.ForeColor = Color.FromArgb(255, 59, 48)
            StockInfo.BatchStatusLabel.Text = "Expired"

        ElseIf BatchAboutToExpired

            StockInfo.BatchStatusLabel.ForeColor = Color.FromArgb(255, 192, 67)
            StockInfo.BatchStatusLabel.Text = "About To Expired"

        Else

            StockInfo.BatchStatusLabel.ForeColor = Color.FromArgb(51, 199, 90)
            StockInfo.BatchStatusLabel.Text = "Normal"

        End If

        GeneralModule.ShowOverlay(MainForm, StockInfo)
        StockManagement.FormPanel.Focus()
        StockManagement.ActiveControl = StockManagement.FormPanel
        GeneralModule.UserControlToButton(Me, 247)

    End Sub

    Private Sub ElipseLabel_Click(sender As Object, e As EventArgs) Handles ElipseLabel.Click

        ClickElipse += 1
        Dim ContextLocation = ElipseLabel.PointToScreen(New Point(0, ElipseLabel.Height + 1))

        If ClickElipse Mod 2 = 1 Then ElipseContextMenu.Show(ContextLocation) Else ElipseContextMenu.Hide

    End Sub

    Private Sub ElipseLabel_MouseLeave(sender As Object, e As EventArgs) Handles ElipseLabel.MouseLeave

        ElipseLabel.Font = New Font("Inter", 12)

    End Sub

    Private Sub ElipseLabel_MouseEnter(sender As Object, e As EventArgs) Handles ElipseLabel.MouseEnter

        ElipseLabel.Font = New Font("Inter Black", 12)
        GeneralModule.UserControlToButton(Me, 210)

    End Sub

    Private Async Sub StockUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BatchExpired = Await StockManagementModule.IsStockExpired(Integer.Parse(StockIdLabel.Text))
        BatchAboutToExpired = Await StockManagementModule.IsStockAboutToExpire(Integer.Parse(StockIdLabel.Text))
        StockLabel.Left = ElipseLabel.Left - (StockLabel.Width + 10)

    End Sub

    Private Async Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

        Dim StockId As Integer = Integer.Parse(StockIdLabel.Text)

        ' Confirm before deleting
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this batch?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then

            Await StockmanagementModule.DeleteStock(StockId) 

        Else

            Exit Sub

        End If

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click

        ChooseUpdate.Opacity = 0
        Dim StockId As Integer = Integer.Parse(StockIdLabel.Text)
        ChooseUpdate.StockId = StockId
        GeneralModule.ShowOverlay(MainForm, ChooseUpdate)

    End Sub
End Class
