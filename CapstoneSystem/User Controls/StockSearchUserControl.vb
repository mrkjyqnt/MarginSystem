Public Class StockSearchUserControl
    Private Async Sub StockSearchUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using ms As New IO.MemoryStream(Await StockManagementModule.GetProductImage(ProductIdLabel.Text))
            PlaceholderImage.Image = Image.FromStream(ms)
        End Using

        ProductNameLabel.Text = Await StockManagementModule.GetProductName(ProductIdLabel.Text)

    End Sub

    Private Async Sub StockSearchUserControl_Click(sender As Object, e As EventArgs) Handles Guna2Panel1.Click, ProductIdLabel.Click, BatchLabel.Click, PlaceholderImage.Click, ProductNameLabel.Click, MyBase.Click

        StockInfo.Opacity = 0
        Dim ProductId As Integer = Integer.Parse(ProductIdLabel.Text)
        Dim StockIdNum As Integer = Integer.Parse(StockId.Text)

        StockInfo.ProductCodeTextBox.Text = Await StockManagementModule.GetBarcode(ProductId)
        StockInfo.BatchCodeTextBox.Text = Await StockManagementModule.GetBatchFromStock(StockIdNum)
        StockInfo.ProductNameTextBox.Text = Await StockManagementModule.GetProductName(ProductId)
        StockInfo.QuantityTextBox.Text = Await StockManagementModule.GetCurrentStock(StockIdNum)
        StockInfo.InventoryPriceTextBox.Text = Await ProductManagementDatabaseModule.GetRetail(ProductId)
        StockInfo.ExpirationTextBox.Text = Await StockManagementModule.GetExpiration(StockIdNum)
        StockInfo.WarehouseTextBox.Text = Await StockManagementModule.GetWarehouse(Await StockManagementModule.GetWarehouseFromStock(StockIdNum))

        GeneralModule.ShowOverlay(MainForm, StockInfo)
        StockManagement.FormPanel.Focus()
        StockManagement.ActiveControl = StockManagement.FormPanel

    End Sub

    Private Sub Guna2Panel1_MouseEnter(sender As Object, e As EventArgs) Handles Guna2Panel1.MouseEnter, StockId.MouseEnter, ProductIdLabel.MouseEnter, BatchLabel.MouseEnter, PlaceholderImage.MouseEnter, ProductNameLabel.MouseEnter

        StockManagement.ActiveControl = StockManagement.ResultSearchPanel

    End Sub

    Private Sub StockSearchUserControl_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter

        StockManagement.ActiveControl = StockManagement.ResultSearchPanel

    End Sub
End Class
