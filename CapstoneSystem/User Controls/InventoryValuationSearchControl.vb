Public Class InventoryValuationSearchControl
    Private Async Sub InventoryValuationSearchControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RetailValuationLabel.Left = Width - RetailValuationLabel.Width - 10

        Using ms As New IO.MemoryStream(Await StockManagementModule.GetProductImage(Await StockManagementModule.GetProductIdByStockId(StockIdLabel.Text)))

            PlaceholderImage.Image = Image.FromStream(ms)

        End Using

        ProductNameLabel.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockIdLabel.Text))
        BatchLabel.Text = Await StockManagementModule.GetBatchFromStock(StockIdLabel.Text)

    End Sub

    Private Async Sub Guna2Panel1_Click(sender As Object, e As EventArgs) Handles Guna2Panel1.Click, StockIdLabel.Click, RetailValuationLabel.Click, ValuationIdLabel.Click, BatchLabel.Click, PlaceholderImage.Click, ProductNameLabel.Click

        InventoryValuationInfo.Opacity = 0
        Dim ValuationId As Integer = Integer.Parse(ValuationIdLabel.Text)
        Dim StockId As Integer = Integer.Parse(StockIdLabel.Text)
        Dim TableName As String = "inventory_valuation"
        Dim Parameter As String = "inventory_id"

        Dim ExpiredValue As Double = Await GeneralModule.GetColumn("expiration_valuation", TableName, Parameter, ValuationId)

        If ExpiredValue > 0

            InventoryValuationInfo.ShowExpirationPanel = True
            InventoryValuationInfo.ProductNameTextBox.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))
            InventoryValuationInfo.BatchCodeTextBox.Text = Await StockManagementModule.GetBatchFromStock(StockId)
            InventoryValuationInfo.QuantityTextBox.Text = Await GeneralModule.GetColumn("current_stock", "stock", "stock_id", StockId)
            InventoryValuationInfo.ValuationValueTextBox.Text = $"- ₱ {Await GeneralModule.GetColumn("expiration_valuation", "inventory_valuation", "inventory_id", ValuationId)}"
            InventoryValuationInfo.ExpirationTextBox.Text = Await GeneralModule.GetColumn("expiration_date", "stock", "stock_id", StockId)

        Else

            InventoryValuationInfo.ShowExpirationPanel = False
            InventoryValuationInfo.ProductNameTextBox1.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))
            InventoryValuationInfo.BatchCodeTextBox1.Text = Await StockManagementModule.GetBatchFromStock(StockId)
            InventoryValuationInfo.QuantityTextBox1.Text = Await GeneralModule.GetColumn("total_stock", "stock", "stock_id", StockId)
            InventoryValuationInfo.RetailValuationTextBox.Text = $"+ ₱ {Await GeneralModule.GetColumn("retail_valuation", "inventory_valuation", "inventory_id", ValuationId)}"
            InventoryValuationInfo.WholesaleValuationTextBox.Text = $"+ ₱ {Await GeneralModule.GetColumn("wholesale_Valuation", "inventory_valuation", "inventory_id", ValuationId)}"
            InventoryValuationInfo.DateTextBox.Text = Await GeneralModule.GetColumn("date_added", "inventory_valuation", "inventory_id", ValuationId)
            InventoryValuationInfo.TimeTextBox.Text = Await GeneralModule.GetColumn("time_added", "inventory_valuation", "inventory_id", ValuationId)

        End If

        GeneralModule.ShowOverlay(MainForm, InventoryValuationInfo)
        InventoryValuation.FormPanel.Focus()
        InventoryValuation.ActiveControl = InventoryValuation.FormPanel

    End Sub

    Private Sub Guna2Panel1_MouseEnter(sender As Object, e As EventArgs) Handles Guna2Panel1.MouseEnter, StockIdLabel.MouseEnter, RetailValuationLabel.MouseEnter, ValuationIdLabel.MouseEnter, BatchLabel.MouseEnter, PlaceholderImage.MouseEnter, ProductNameLabel.MouseEnter

        InventoryValuation.ActiveControl = InventoryValuation.ResultSearchPanel

    End Sub
End Class
