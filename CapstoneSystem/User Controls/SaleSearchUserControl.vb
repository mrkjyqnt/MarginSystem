Public Class SaleSearchUserControl
    Private Async Sub SaleSearchUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using ms As New IO.MemoryStream(Await StockManagementModule.GetProductImage(Await StockManagementModule.GetProductIdByStockId(StockIdLabel.Text)))

            PlaceholderImage.Image = Image.FromStream(ms)

        End Using

        ProductNameLabel.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockIdLabel.Text))

    End Sub

    Private Async Sub SaleIdLabel_Click(sender As Object, e As EventArgs) Handles Guna2Panel1.Click, StockIdLabel.Click, GrossSaleLabel.Click, SaleIdLabel.Click, QuantityLabel.Click, PlaceholderImage.Click, ProductNameLabel.Click

        SaleInfo.Opacity = 0
        Dim SaleId As Integer = Integer.Parse(SaleIdLabel.Text)
        Dim StockId As Integer = Integer.Parse(StockIdLabel.Text)
        Dim TableName As String = "sale"
        Dim Parameter As String = "sale_id"

        Dim Quantity As Integer = Await GeneralModule.GetColumn("quantity_sold", TableName, Parameter, SaleId)
        Dim ItemPrice As Double = Await GeneralModule.GetColumn("item_price", TableName, Parameter, SaleId)
        Dim Expenses As Double = Await GeneralModule.GetColumn("expenses", TableName, Parameter, SaleId)
        Dim GrossSale As Double = Await GeneralModule.GetColumn("gross_sale", TableName, Parameter, SaleId)
        Dim NetSale As Double = Await GeneralModule.GetColumn("net_sale", TableName, Parameter, SaleId)
        Dim TransactionDate As String = Await GeneralModule.GetColumn("transaction_date", TableName, Parameter, SaleId)
        Dim TransactionTime As String = Await GeneralModule.GetColumn("transaction_time", TableName, Parameter, SaleId)

        SaleInfo.ProductNameTextBox.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))
        SaleInfo.BatchCodeTextBox.Text = Await StockManagementModule.GetBatchFromStock(StockId)
        SaleInfo.QuantityTextBox.Text = Quantity
        SaleInfo.ItemPriceTextBox.Text = ItemPrice
        SaleInfo.ExpensesTextBox.Text = Expenses
        SaleInfo.GrossSaleTextBox.Text = GrossSale
        SaleInfo.NetSaleTextBox.Text = NetSale
        SaleInfo.DateTextBox.Text = TransactionDate
        SaleInfo.TimeTextBox.Text = TransactionTime

        GeneralModule.ShowOverlay(MainForm, SaleInfo)
        InventoryTransactions.FormPanel.Focus
        InventoryTransactions.ActiveControl = InventoryTransactions.FormPanel

    End Sub

    Private Sub Guna2Panel1_MouseEnter(sender As Object, e As EventArgs) Handles Guna2Panel1.MouseEnter, StockIdLabel.MouseEnter, GrossSaleLabel.MouseEnter, SaleIdLabel.MouseEnter, QuantityLabel.MouseEnter, PlaceholderImage.MouseEnter, ProductNameLabel.MouseEnter

        SalesValuation.ActiveControl = SalesValuation.ResultSearchPanel

    End Sub
End Class
