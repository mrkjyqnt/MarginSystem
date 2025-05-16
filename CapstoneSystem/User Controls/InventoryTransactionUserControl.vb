Public Class InventoryTransactionUserControl
    Private Sub InventoryUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TransactionTypeLabel.Left = ElipseLabel.Left - TransactionTypeLabel.Width - 5

        If TransactionTypeLabel.Text = "Added"

            TransactionTypeLabel.ForeColor = Color.FromArgb(51, 199, 90)

        ElseIf TransactionTypeLabel.Text = "Removed"

            TransactionTypeLabel.ForeColor = Color.FromArgb(255, 59, 48)

        ElseIf TransactionTypeLabel.Text = "Sold"

            TransactionTypeLabel.ForeColor = Color.FromArgb(39, 110, 241)

        End If

    End Sub

    Private Sub ActionLabel_MouseEnter(sender As Object, e As EventArgs) Handles TransactionTypeLabel.MouseEnter, QuantityDateLabel.MouseEnter, StockNameLabel.MouseEnter, PlaceholderImage.MouseEnter, MyBase.MouseEnter

        GeneralModule.UserControlToButton(Me, 210)

    End Sub

    Private Sub InventoryUserControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave

        GeneralModule.UserControlToButton(Me, 247)

    End Sub

    Private Sub ActionLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles TransactionTypeLabel.MouseDown, QuantityDateLabel.MouseDown, StockNameLabel.MouseDown, PlaceholderImage.MouseDown, MyBase.MouseDown

        GeneralModule.UserControlToButton(Me, 147)

    End Sub

    Private Async Sub InventoryUserControl_Click(sender As Object, e As EventArgs) Handles TransactionTypeLabel.Click, QuantityDateLabel.Click, StockNameLabel.Click, PlaceholderImage.Click, TransactionIdLabel.Click, StockIdLabel.Click, MyBase.Click

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
        GeneralModule.UserControlToButton(Me, 247)
        InventoryTransactions.FormPanel.Focus
        InventoryTransactions.ActiveControl = InventoryTransactions.FormPanel

    End Sub

End Class
