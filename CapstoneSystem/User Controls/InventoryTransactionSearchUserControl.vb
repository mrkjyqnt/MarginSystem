Public Class InventoryTransactionSearchUserControl
    Private Async Sub InventoryTransactionSearchUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using ms As New IO.MemoryStream(Await StockManagementModule.GetProductImage(Await StockManagementModule.GetProductIdByStockId(StockIdLabel.Text)))

            PlaceholderImage.Image = Image.FromStream(ms)

        End Using

        ProductNameLabel.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockIdLabel.Text))

    End Sub

    Private Sub Guna2Panel1_MouseEnter(sender As Object, e As EventArgs) Handles Guna2Panel1.MouseEnter, TransactionIdLabel.MouseEnter, StockIdLabel.MouseEnter, TypeLabel.MouseEnter, PlaceholderImage.MouseEnter, ProductNameLabel.MouseEnter

        InventoryTransactions.ActiveControl = InventoryTransactions.ResultSearchPanel

    End Sub

    Private Async Sub Guna2Panel1_Click(sender As Object, e As EventArgs) Handles Guna2Panel1.Click, TransactionIdLabel.Click, StockIdLabel.Click, TypeLabel.Click, PlaceholderImage.Click, ProductNameLabel.Click

        InventoryTransactionInfo.Opacity = 0
        Dim TransactionId As Integer = Integer.Parse(TransactionIdLabel.Text)

        Dim TableName As String = "stock_transaction"
        Dim Parameter As String = "transaction_id"

        Dim StockId As Integer = Await GeneralModule.GetColumn("stock_id", TableName, Parameter, TransactionId)
        Dim TransactionType As String = Await GeneralModule.GetColumn("transaction_type", TableName, Parameter, TransactionId)
        Dim Quantity As Integer = Await GeneralModule.GetColumn("quantity", TableName, Parameter, TransactionId)
        Dim TransDate As String = Await GeneralModule.GetColumn("transaction_date", TableName, Parameter, TransactionId)
        Dim TransTime As String = Await GeneralModule.GetColumn("transaction_time", TableName, Parameter, TransactionId)
        Dim ActionBy As String = Await GeneralModule.GetColumn("action_by", TableName, Parameter, TransactionId)

        InventoryTransactionInfo.BatchCodeTextBox.Text = Await StockManagementModule.GetBatchFromStock(StockId)
        InventoryTransactionInfo.ProductNameTextBox.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))
        InventoryTransactionInfo.QuantityTextBox.Text = Quantity
        InventoryTransactionInfo.TypeTextBox.Text = TransactionType
        InventoryTransactionInfo.DateTextBox.Text = TransDate
        InventoryTransactionInfo.TimeTextBox.Text = TransTime
        InventoryTransactionInfo.ActionByTextBox.Text = Await ProductManagementDatabaseModule.GetAddedBy(ActionBy)
        
        GeneralModule.ShowOverlay(MainForm, InventoryTransactionInfo)
        InventoryTransactions.ResultSearchPanel.Focus
        InventoryTransactions.ActiveControl = InventoryTransactions.ResultSearchPanel

    End Sub
End Class
