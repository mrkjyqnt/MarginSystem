Public Class RecordSale

    Public ProductCode As String
    Public ItemPrice As Double

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Close
        Dispose

    End Sub

    Private Async Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        If String.IsNullOrEmpty(ProductComboBox.Text) OrElse String.IsNullOrEmpty(BatchComboBox.Text) OrElse
            String.IsNullOrEmpty(QuantityTextBox.Text)

            MessageBox.Show("Input neccessary data in the fields.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            ProductComboBox.Focus

        End If

        If Not Await InventoryTransactionDatabaseModule.CheckIfDataExist("product", "product_name", "ProductName", ProductComboBox.Text)

            MessageBox.Show("Product does not exists.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            ProductComboBox.Focus

        End If

        If Not Await InventoryTransactionDatabaseModule.CheckIfDataExist("stock", "batch_code", "BatchCode", BatchComboBox.Text)

            MessageBox.Show("Product batch does not exists.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            BatchComboBox.Focus

        End If

        Dim ProductName As String = ProductComboBox.SelectedItem.ToString
        Dim BatchCode As String = BatchComboBox.SelectedItem.ToString
        Dim AllowedQuantity As Integer = Await StockManagementModule.GetCurrentStock(Await StockManagementModule.GetStockIdByBatchcode(BatchComboBox.SelectedItem.ToString))
        Dim Quantity As String = QuantityTextBox.Text
        ProductManagementDatabaseModule.QuantitySold = QuantityTextBox.Text
        ItemPrice = ItemPriceTextBox.Text

        If Quantity > AllowedQuantity

            MessageBox.Show($"Batch {BatchComboBox.SelectedItem.ToString} only have {AllowedQuantity} stocks available", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            QuantityTextBox.Focus

        Else

            Await ProductManagementDatabaseModule.UpdateSold(BatchCode, AllowedQuantity, Quantity)

            If ProductManagementDatabaseModule.UpdateSuccessul Then

                MessageBox.Show($"Sold {ProductManagementDatabaseModule.QuantitySold} items.", "Successful transactions.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If Not String.IsNullOrEmpty(ProductCode)

                    Close
                    Dispose

                Else

                    ProductComboBox.SelectedIndex = -1
                    BatchComboBox.SelectedIndex = -1
                    BatchComboBox.Text = ""
                    BatchComboBox.Items.Clear
                    QuantityTextBox.Clear
                    Label8.Show
                    Label2.Show
                    ItemPriceTextBox.Clear
                    SwitchPricePictureBox.Enabled = False
                    QuantityTextBox.ReadOnly = True

                End If

            Else

                QuantityTextBox.Clear

            End If

            Dim TotalStocksSearched As Integer
            Dim StockQuery As String = "SELECT * FROM stock WHERE active = 1 ORDER BY stock_id DESC"
            GeneralModule.DeleteUserControls(StockManagement.FormPanel)
            Await StockManagementModule.RetrieveALL(StockQuery)
            Await StockManagement.CreateStockUserControl()
            TotalStocksSearched = Variables.ListOfStockId.Count
            StockManagement.Label3.Text = TotalStocksSearched & " batches found"
            StockManagement.ActiveControl = StockManagement.FormPanel

            Dim TotalTransaction As Integer
            Dim TransactionQuery As String = "SELECT * FROM stock_transaction ORDER BY transaction_id DESC"
            GeneralModule.DeleteUserControls(InventoryTransactions.FormPanel)
            Await InventoryTransactionDatabaseModule.RetrieveALL(TransactionQuery)
            Await InventoryTransactions.CreateTransactionUserControl()
            TotalTransaction = Variables.ListOfTransactionId.Count
            InventoryTransactions.Label3.Text = TotalTransaction & " Transaction found"
            InventoryTransactions.ActiveControl = InventoryTransactions.FormPanel

            Dim TotalSales As Integer
            Dim SalesQuery As String = "SELECT * FROM sale ORDER BY sale_id DESC"
            GeneralModule.DeleteUserControls(SalesValuation.FormPanel)
            Await SaleValuationModule.RetrieveAll(SalesQuery)
            Await SalesValuation.CreateSaleUserControl()
            TotalSales = Variables.ListOfSaleId.Count
            SalesValuation.Label3.Text = TotalSales & " Sales found"
            SalesValuation.ActiveControl = SalesValuation.FormPanel

            Dim TotalSold As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Sold", Variables.CurrentMonth)
            InventoryMonitoring.SoldLabel.Text = TotalSold
            InventoryTransactions.SoldLabel.Text = TotalSold

            Dim lowStock As Integer = Await DashboardModule.CountLowStock
            Dashboard.LowStockLabel.Text = lowStock
            InventoryMonitoring.LowStockLabel.Text = lowStock
            InventoryTransactions.LowStockLabel.Text = lowStock

            Dim TotalQuantitySold As Integer = Await SaleValuationModule.CountSum("quantity_sold", "sale", Variables.CurrentMonth, "transaction_date")
            SalesValuation.TotalQuantitySoldLabel.Text = TotalQuantitySold

            Dim TotalProfit As Integer = Await SaleValuationModule.CountSum("net_sale", "sale", Variables.CurrentMonth, "transaction_date")
            SalesValuation.TotalProfitLabel.Text = $"₱ {TotalProfit}"

            Dim TotalSumSales As Integer = Await SaleValuationModule.CountSum("gross_sale", "sale", Variables.CurrentMonth, "transaction_date")
            SalesValuation.TotalSalesLabel.Text = $"₱ {TotalSumSales}"

            Dim ThisMonthSale As Double = Await SaleValuationModule.CountSum("gross_sale", "sale", Variables.CurrentMonth, "transaction_date")
            Dashboard.ThisMonthLabel.Text = $"₱ {ThisMonthSale}"

            Dim ThisWeekValuation As Double = Await DashboardModule.ThisWeekTotalValuation
            Dashboard.ThisWeekLabel.Text = $"₱ {ThisWeekValuation}"

            Dim TodayValuation As Double = Await DashboardModule.YesterdayTodayTotalValuation
            Dashboard.TodayLabel.Text = $"₱ {TodayValuation}"

        End If

    End Sub

    Private Async Sub RecordSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ListOfProduct As List(Of Object) = Await StockManagementModule.GetProducts()

        For Each Item As Object In ListOfProduct
            If Item IsNot Nothing Then
                ProductComboBox.Items.Add(Item.ToString())
            End If
        Next

        If Not String.IsNullOrEmpty(ProductCode) Then

            Guna2Panel2.Show
            Guna2Panel1.hide
            Size = New Size(580, 328)

            Dim ProductName As String = Await StockManagementModule.GetProductName(
                Await ProductManagementDatabaseModule.GetProductIdByBarcode(ProductCode)
            )
            ProductNameTextBox.Text = ProductName
            AutomaticQuantityTextBox.Focus
            AutomaticRetailPriceTextBox.Text = Await ProductManagementDatabaseModule.GetRetail(Await StockManagementModule.GetProductId(ProductName))

        Else

            Guna2Panel2.Hide
            Guna2Panel1.Show
            Size = New Size(580, 352)

        End If

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Async Sub ProductComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProductComboBox.SelectedIndexChanged

        BatchComboBox.Items.Clear

        If ProductComboBox.SelectedIndex < 0 Then

            Label8.Show
            Label2.Show
            BatchComboBox.SelectedIndex = -1
            SwitchPricePictureBox.Enabled = False

        Else

            Label8.Hide
            Dim ListOfBatches As List(Of Object)
            ListOfBatches = Await StockManagementModule.GetBatches(Await StockManagementModule.GetProductId(ProductComboBox.SelectedItem.ToString))
            ListOfBatches.ToString

            For each Item As String In ListOfBatches

                BatchComboBox.Items.Add(Item)

            Next

            SwitchPricePictureBox.Enabled = True

            ItemPriceTextBox.Text = Await ProductManagementDatabaseModule.GetRetail(Await StockManagementModule.GetProductId(ProductComboBox.SelectedItem.ToString))

            BatchComboBox.SelectedIndex = 0
            QuantityTextBox.Focus

        End If

    End Sub

    Private Async Sub ProductComboBox_TextChanged(sender As Object, e As EventArgs) Handles ProductComboBox.TextChanged

        If String.IsNullOrEmpty(ProductComboBox.Text) Then

            Label8.Show
            BatchComboBox.SelectedIndex = -1
            Label2.Show
            ItemPriceTextBox.Clear

        Else

            If Not Await ProductManagementDatabaseModule.IsProductCodeExists(ProductComboBox.Text) then

                BatchComboBox.SelectedIndex = -1
                Label2.Show
                ItemPriceTextBox.Clear

            End If

            Label8.Hide

        End If

    End Sub

    Private Sub BatchComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BatchComboBox.SelectedIndexChanged

        If BatchComboBox.SelectedIndex < 0 Then

            Label2.Show
            ItemPriceTextBox.Clear


        Else

            Label2.Hide

        End If

    End Sub

    Private Sub BatchComboBox_TextChanged(sender As Object, e As EventArgs) Handles BatchComboBox.TextChanged

        If String.IsNullOrEmpty(ProductComboBox.Text) Then

            Label2.Show
            ItemPriceTextBox.Clear

        Else

            Label2.Hide

        End If

    End Sub

    Private Sub QuantityTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles QuantityTextBox.KeyPress

        GeneralModule.CheckNumericNumber(e, QuantityTextBox)

    End Sub

    Private Async Sub SwitchPricePictureBox_Click(sender As Object, e As EventArgs) Handles SwitchPricePictureBox.Click

        If Label5.Text = "Retail Price"

            Label5.Text = "Wholesale Price"
            ItemPriceTextBox.Text = Await ProductManagementDatabaseModule.GetWholeSale(Await StockManagementModule.GetProductId(ProductComboBox.SelectedItem.ToString))
            QuantityTextBox.focus

        Else

            Label5.Text = "Retail Price"
            ItemPriceTextBox.Text = Await ProductManagementDatabaseModule.GetRetail(Await StockManagementModule.GetProductId(ProductComboBox.SelectedItem.ToString))
            QuantityTextBox.focus

        End If

    End Sub

    Private Sub SwitchPricePictureBox_MouseEnter(sender As Object, e As EventArgs) Handles SwitchPricePictureBox.MouseEnter

        SwitchPricePictureBox.Image = My.Resources.HoveredSwitch

    End Sub

    Private Sub SwitchPricePictureBox_MouseLeave(sender As Object, e As EventArgs) Handles SwitchPricePictureBox.MouseLeave

        SwitchPricePictureBox.Image = My.Resources.switch

    End Sub

    Private Async Sub ProductComboBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ProductComboBox.KeyDown

        If e.KeyCode = Keys.Enter

            If Not Await ProductManagementDatabaseModule.IsProductCodeExists(ProductComboBox.Text) then

                Exit Sub

            Else

                Dim ProductName As String = Await StockManagementModule.GetProductName(Await ProductManagementDatabaseModule.GetProductIdByBarcode(ProductComboBox.Text))
                ProductComboBox.SelectedItem = ProductName

            End If

        End If

    End Sub

    Private Async Sub AutomaticSwitchPrice_Click(sender As Object, e As EventArgs) Handles AutomaticSwitchPrice.Click

        If Label7.Text = "Retail Price"

            Label7.Text = "Wholesale Price"
            AutomaticRetailPriceTextBox.Text = Await ProductManagementDatabaseModule.GetWholeSale(Await StockManagementModule.GetProductId(ProductNameTextBox.Text))
            AutomaticQuantityTextBox.Focus

        Else

            Label7.Text = "Retail Price"
            AutomaticRetailPriceTextBox.Text = Await ProductManagementDatabaseModule.GetRetail(Await StockManagementModule.GetProductId(ProductNameTextBox.Text))
            AutomaticQuantityTextBox.Focus

        End If

    End Sub

    Private Async Sub ConfirmButton2_Click(sender As Object, e As EventArgs) Handles ConfirmButton2.Click

        If String.IsNullOrEmpty(AutomaticQuantityTextBox.Text)

            MessageBox.Show("Provide product quantity", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            AutomaticQuantityTextBox.Focus

        End If

        Dim ProductName As String = ProductNameTextBox.Text
        Dim ProductId As Integer = Await StockManagementModule.GetProductId(ProductName)
        Dim Quantity As String = AutomaticQuantityTextBox.Text
        ProductManagementDatabaseModule.QuantitySold = AutomaticQuantityTextBox.Text
        ItemPrice = AutomaticRetailPriceTextBox.Text
        Await ProductManagementDatabaseModule.UpdateAndRemoveStock(ProductId, Quantity)

        If ProductManagementDatabaseModule.UpdateSuccessul Then

            MessageBox.Show($"Sold {ProductManagementDatabaseModule.QuantitySold} items.", "Successful transactions.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Hide
            ProductCode = String.Empty
            ItemPrice = 0
            Barcode.Show
            AutomaticQuantityTextBox.Clear

        Else

            AutomaticQuantityTextBox.Clear

        End If

        Dim TotalStocksSearched As Integer
        Dim StockQuery As String = "SELECT * FROM stock WHERE active = 1 ORDER BY stock_id DESC"
        GeneralModule.DeleteUserControls(StockManagement.FormPanel)
        Await StockManagementModule.RetrieveALL(StockQuery)
        Await StockManagement.CreateStockUserControl()
        TotalStocksSearched = Variables.ListOfStockId.Count
        StockManagement.Label3.Text = TotalStocksSearched & " batches found"
        StockManagement.ActiveControl = StockManagement.FormPanel

        Dim TotalTransaction As Integer
        Dim TransactionQuery As String = "SELECT * FROM stock_transaction ORDER BY transaction_id DESC"
        GeneralModule.DeleteUserControls(InventoryTransactions.FormPanel)
        Await InventoryTransactionDatabaseModule.RetrieveALL(TransactionQuery)
        Await InventoryTransactions.CreateTransactionUserControl()
        TotalTransaction = Variables.ListOfTransactionId.Count
        InventoryTransactions.Label3.Text = TotalTransaction & " Transaction found"
        InventoryTransactions.ActiveControl = InventoryTransactions.FormPanel
        
        Dim TotalSales As Integer
        Dim SalesQuery As String = "SELECT * FROM sale ORDER BY sale_id DESC"
        GeneralModule.DeleteUserControls(SalesValuation.FormPanel)
        Await SaleValuationModule.RetrieveAll(SalesQuery)
        Await SalesValuation.CreateSaleUserControl()
        TotalSales = Variables.ListOfSaleId.Count
        SalesValuation.Label3.Text = TotalSales & " Sales found"
        SalesValuation.ActiveControl = SalesValuation.FormPanel
        
        Dim TotalSold As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Sold", Variables.CurrentMonth)
        InventoryMonitoring.SoldLabel.Text = TotalSold
        InventoryTransactions.SoldLabel.Text = TotalSold
        
        Dim lowStock As Integer = Await DashboardModule.CountLowStock
        Dashboard.LowStockLabel.Text = lowStock
        InventoryMonitoring.LowStockLabel.Text = lowStock
        InventoryTransactions.LowStockLabel.Text = lowStock
        
        Dim TotalQuantitySold As Integer = Await SaleValuationModule.CountSum("quantity_sold", "sale", Variables.CurrentMonth, "transaction_date")
        SalesValuation.TotalQuantitySoldLabel.Text = TotalQuantitySold
        
        Dim TotalProfit As Integer = Await SaleValuationModule.CountSum("net_sale", "sale", Variables.CurrentMonth, "transaction_date")
        SalesValuation.TotalProfitLabel.Text = $"₱ {TotalProfit}"
        
        Dim TotalSumSales As Integer = Await SaleValuationModule.CountSum("gross_sale", "sale", Variables.CurrentMonth, "transaction_date")
        SalesValuation.TotalSalesLabel.Text = $"₱ {TotalSumSales}"

        Dim ThisMonthSale As Double = Await SaleValuationModule.CountSum("gross_sale", "sale", Variables.CurrentMonth, "transaction_date")
        Dashboard.ThisMonthLabel.Text = $"₱ {ThisMonthSale}"

        Dim ThisWeekValuation As Double = Await DashboardModule.ThisWeekTotalValuation
        Dashboard.ThisWeekLabel.Text = $"₱ {ThisWeekValuation}"

        Dim TodayValuation As Double = Await DashboardModule.YesterdayTodayTotalValuation
        Dashboard.TodayLabel.Text = $"₱ {TodayValuation}"

    End Sub

    Private Sub ShadowButton2_Click(sender As Object, e As EventArgs) Handles ShadowButton2.Click

        Close
        Dispose

    End Sub

    Private Sub AutomaticQuantityTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AutomaticQuantityTextBox.KeyPress

        GeneralModule.CheckNumericNumber(e, AutomaticQuantityTextBox)

    End Sub

    Private Sub AutomaticQuantityTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AutomaticQuantityTextBox.KeyDown

        If e.KeyCode = Keys.Enter

            ConfirmButton2.PerformClick

        End If

    End Sub

    Private Sub QuantityTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles QuantityTextBox.KeyDown

        If e.KeyCode = Keys.Enter

            ConfirmButton.PerformClick

        End If

    End Sub

End Class