Imports System.Transactions

Public Class SalesValuationUserControl
    Private Sub SalesValuationUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TotalSaleLabel.ForeColor = Color.FromArgb(55, 199, 90)
        TotalSaleLabel.Left = ElipseLabel.Left - TotalSaleLabel.Width - 5

    End Sub

    Private Sub TotalSaleLabel_MouseEnter(sender As Object, e As EventArgs) Handles TotalSaleLabel.MouseEnter, NoDateLabel.MouseEnter, SaleNameLabel.MouseEnter, PlaceholderImage.MouseEnter, MyBase.MouseEnter

        GeneralModule.UserControlToButton(Me, 210)

    End Sub

    Private Sub SalesValuationUserControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave

        GeneralModule.UserControlToButton(Me, 247)

    End Sub

    Private Sub TotalSaleLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles TotalSaleLabel.MouseDown, NoDateLabel.MouseDown, SaleNameLabel.MouseDown, PlaceholderImage.MouseDown, MyBase.MouseDown

        GeneralModule.UserControlToButton(Me, 147)

    End Sub

    Private Async Sub SalesValuationUserControl_Click(sender As Object, e As EventArgs) Handles TotalSaleLabel.Click, NoDateLabel.Click, SaleNameLabel.Click, StockIdLabel.Click, SaleIdLabel.Click, PlaceholderImage.Click, MyBase.Click

        SaleInfo.Opacity = 0
        Dim SaleId As Integer = Integer.Parse(SaleIdLabel.Text)
        Dim StockId As Integer = Integer.Parse(StockIdLabel.Text)
        Dim TableName As String = "sale"
        Dim Parameter As String = "sale_id"

        Dim ProductName As String = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))
        Dim Batch As String = Await StockManagementModule.GetBatchFromStock(StockId)
        Dim Quantity As Integer = Await GeneralModule.GetColumn("quantity_sold", TableName, Parameter, SaleId)
        Dim Price As Double = Await GeneralModule.GetColumn("item_price", TableName, Parameter, SaleId)
        Dim Expenses As Double = Await GeneralModule.GetColumn("expenses", TableName, Parameter, SaleId)
        Dim GrossSale As Double = Await GeneralModule.GetColumn("gross_sale", TableName, Parameter, SaleId)
        Dim NetSale As Double = Await GeneralModule.GetColumn("net_sale", TableName, Parameter, SaleId)
        Dim TransactionDate As String = Await GeneralModule.GetColumn("transaction_date", TableName, Parameter, SaleId)
        Dim TransactionTime As String = Await GeneralModule.GetColumn("transaction_time", TableName, Parameter, SaleId)

        SaleInfo.ProductNameTextBox.Text = ProductName
        SaleInfo.BatchCodeTextBox.Text = Batch
        SaleInfo.QuantityTextBox.Text = Quantity
        SaleInfo.ItemPriceTextBox.Text = $"₱ {Price}"
        SaleInfo.ExpensesTextBox.Text = $"₱ {Expenses}"
        SaleInfo.GrossSaleTextBox.Text = $"₱ {GrossSale}"
        SaleInfo.NetSaleTextBox.Text = $"₱ {NetSale}"
        SaleInfo.DateTextBox.Text = TransactionDate
        SaleInfo.TimeTextBox.Text = TransactionTime

        GeneralModule.ShowOverlay(MainForm, SaleInfo)
        GeneralModule.UserControlToButton(Me, 247)
        SalesValuation.FormPanel.Focus
        SalesValuation.ActiveControl = SalesValuation.FormPanel

    End Sub

End Class
