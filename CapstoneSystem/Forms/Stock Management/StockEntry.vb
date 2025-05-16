Imports System.Globalization

Public Class StockEntry

    Public ProductNameStockEntry As String = String.Empty

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Close
        Dispose

    End Sub

    Private Async Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        'Dim TotalProductsSearched As Integer

        If Not Variables.StockWarehouseId.HasValue Then WarehouseComboBox.SelectedIndex = 0
        Variables.StockBatch = BatchLabel.Text.ToString
        Variables.StockExpiration = ExpirationDateTime.Value.ToString("MMMM d, yyyy").ToString
        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
        Variables.StockWarehouseId = Await StockManagementModule.GetWarehouseId(WarehouseComboBox.SelectedItem.ToString)
        Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)

        If ProductComboBox.SelectedIndex = -1 Then

            If Not String.IsNullOrEmpty(ProductComboBox.Text)

                MessageBox.Show($"There's no {ProductComboBox.Text} product available.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            Else

                MessageBox.Show("Select a product.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

        Else

            Variables.StockProductId = Await StockManagementModule.GetProductId(ProductComboBox.SelectedItem.ToString)

        End If

        If String.IsNullOrEmpty(Variables.StockBatch) OrElse String.IsNullOrEmpty(Variables.StockExpiration) OrElse
            String.IsNullOrEmpty(CurrentStockTextBox.Text)

            MessageBox.Show("Fill in the required fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        Dim MinStock As Integer = Await GeneralModule.GetColumn("min_stock_level", "product", "product_id", Variables.StockProductId)
        Dim MaxStock As Integer = Await GeneralModule.GetColumn("max_stock_level", "product", "product_id", Variables.StockProductId)

        If Not IsNumeric(CurrentStockTextBox.Text) Then
            MessageBox.Show("The value of current stock must be a valid value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Integer.Parse(CurrentStockTextBox.Text) < MinStock

            MessageBox.Show($"The minimum stock for this product's batch is {MinStock}.{vbCrLf}Current stock cannot be lower than minumum stock level", "Invalid Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If Integer.Parse(CurrentStockTextBox.Text) > MaxStock

            MessageBox.Show($"The maximum stock for this product's batch is {MaxStock}.{vbCrLf}Current stock cannot be higher than maximum stock level", "Invalid Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        Variables.CurrentStock = CurrentStockTextBox.Text

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

        Await StockManagementModule.InsertStock(Variables.StockProductId, Variables.StockBatch, Variables.StockExpiration,
                                                Variables.CurrentStock, Variables.StockWarehouseId, DateAdded, TimeAdded, Variables.AddedBy)

        Dim StockQuery As String = "SELECT * FROM stock WHERE active = 1 ORDER BY stock_id DESC"
        GeneralModule.DeleteUserControls(StockManagement.FormPanel)
        Await StockManagementModule.RetrieveALL(StockQuery)
        Await StockManagement.CreateStockUserControl()
        'TotalProductsSearched = Variables.ListOfStockId.Count

        Dim TransactionQuery As String = "SELECT * FROM stock_transaction ORDER BY transaction_id DESC"
        GeneralModule.DeleteUserControls(InventoryTransactions.FormPanel)
        Await InventoryTransactionDatabaseModule.RetrieveALL(TransactionQuery)
        Await InventoryTransactions.CreateTransactionUserControl()

        Dim InventoryValuationQuery As String = "SELECT * FROM inventory_valuation ORDER BY inventory_id DESC"
        GeneralModule.DeleteUserControls(InventoryValuation.FormPanel)
        Await InventoryValuationModule.RetrieveALL(InventoryValuationQuery)
        Await InventoryValuation.CreateValuationUserControl()

        Dim totalValuation As Double = Await DashboardModule.CountTotalValuation
        Dim totalStocks As Integer = Await DashboardModule.CountTotalStocks

        Dim TotalAdded As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Added", Variables.CurrentMonth)
        InventoryMonitoring.AddedLabel.Text = TotalAdded
        InventoryTransactions.AddedLabel.Text = TotalAdded

        Dashboard.TotalValueLabel.Text = $"₱ {totalValuation}"
        InventoryValuation.TotalValueLabel.Text = $"₱ {totalValuation}"
        Dashboard.TotalStockLabel.Text = totalStocks

        Dim lastMonth As String = DateTime.Now.AddMonths(-1).ToString("yyyy-MM")
        Dim thisMonth As String = DateTime.Now.ToString("yyyy-MM")

        Dim message As String = Await DashboardModule.CompareValuation(lastMonth, thisMonth)

        If message = "No change from last month." Then Dashboard.Label9.hide Else Dashboard.Label9.Show

        Dashboard.ValuationPercentLabel.ForeColor = Dashboard.ValuationColor
        Dashboard.ValuationPercentLabel.Text = message
        Dashboard.Label9.Left = Dashboard.ValuationPercentLabel.Right

        Dim aboutToExpire As Integer = Await DashboardModule.CountAboutToExpire
        Dashboard.AboutToExpireLabel.Text = aboutToExpire
        InventoryMonitoring.AboutToExpireLabel.Text = aboutToExpire
        InventoryTransactions.AboutToExpireLabel.Text = aboutToExpire

        Dim expired As Integer = Await DashboardModule.CountExpiredItems
        Dim expiredThisMonth As Integer = Await DashboardModule.CountExpiredItemsThisMonth
        Dashboard.ExpiredLabel.Text = expired
        InventoryMonitoring.ExpiredLabel.Text = expiredThisMonth
        InventoryTransactions.ExpiredLabel.Text = expiredThisMonth

        Dim SumTotalLoss As Double = Await InventoryValuationModule.TotalLoss
        InventoryValuation.TotalLossLabel.Text = $"₱ {SumTotalLoss}"

        Dim SumTotalQuantityExpired As Integer = Await InventoryValuationModule.CountQuantityExpiredItems
        InventoryValuation.TotalQuantityExpiredLabel.Text = SumTotalQuantityExpired

        Dim lastWeek As String = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(-7), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString()
        Dim thisWeek As String = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString()

        Dim weekcomparison As String = Await DashboardModule.WeekComparison(lastWeek, thisWeek)
        If weekcomparison = "No change from last week." Then Dashboard.Label9.hide Else Dashboard.Label9.Show
        Dashboard.ValuationPercentLabel.ForeColor = Dashboard.WeekValuationColor
        Dashboard.LowerThanLastWeekLabel.Text = weekcomparison
        Dashboard.Label23.Left = Dashboard.LowerThanLastWeekLabel.Right

        Dim yesterday As String = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
        Dim today As String = DateTime.Now.ToString("yyyy-MM-dd")

        Dim todaycomparison As String = Await DashboardModule.CompareTodayValuation(yesterday, today)

        Dashboard.HigherThanLastYesterdayLabel.ForeColor = Dashboard.TodayValuationColor
        Dashboard.HigherThanLastYesterdayLabel.Text = todaycomparison
        Dashboard.Label18.Left = Dashboard.HigherThanLastYesterdayLabel.Right

        GeneralModule.ClearStockData

        Me.Close()
        Me.Dispose()

        GeneralModule.CloseOverLay(LoadingScreen)

    End Sub

    Private Async Sub StockEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ListOfProduct As List(Of Object)
        ListOfProduct = Await StockManagementModule.GetProducts()
        ListOfProduct.ToString

        For each Item As String In ListOfProduct

            ProductComboBox.Items.Add(Item)

        Next

        Dim ListOfWarehouse As List(Of Object)
        ListOfWarehouse = Await StockManagementModule.GetWarehouses()
        ListOfWarehouse.ToString

        For Each Item As String In ListOfWarehouse

            WarehouseComboBox.Items.Add(Item)


        Next

        If Not String.IsNullOrEmpty(ProductNameStockEntry)

            ProductComboBox.SelectedIndex = ProductComboBox.Items.IndexOf(ProductNameStockEntry)
            CurrentStockTextBox.Focus
            ProductComboBox.Enabled = False

        End If

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

        ProductComboBox.DroppedDown = True

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

        WarehouseComboBox.DroppedDown = True

    End Sub

    Private Async Sub ProductComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProductComboBox.SelectedIndexChanged

        If ProductComboBox.SelectedIndex < 0 Then

            Label2.Show
            BatchLabel.Clear

        Else

            Label2.Hide
            Dim ProductId = Await StockManagementModule.GetProductId(ProductComboBox.SelectedItem.ToString)
            Dim ProductCode = Await StockManagementModule.GetBarcode(ProductId)
            Dim ExistingBatch = Await StockManagementModule.GetNextBatchNumber(ProductCode)

            BatchLabel.Text = ProductCode & "BTCH" & ExistingBatch

        End If

    End Sub

    Private Sub WarehouseComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WarehouseComboBox.SelectedIndexChanged

        If WarehouseComboBox.SelectedIndex < 0 Then Label9.Show Else Label9.Hide

    End Sub

    Private Sub CurrentStockTextBox_TextChanged(sender As Object, e As EventArgs) Handles CurrentStockTextBox.TextChanged

    End Sub

    Private Sub CurrentStockTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CurrentStockTextBox.KeyPress

        GeneralModule.CheckDemicalNumber(e, CurrentStockTextBox)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

        ProductComboBox.Focus

    End Sub

    Private Async Sub ProductComboBox_TextChanged(sender As Object, e As EventArgs) Handles ProductComboBox.TextChanged

        If String.IsNullOrEmpty(ProductComboBox.Text) Then

            Label2.Show
            BatchLabel.Clear
        Else

            If Not Await ProductManagementDatabaseModule.IsProductCodeExists(ProductComboBox.Text) then

                BatchLabel.Clear

            End If

            Label2.Hide

        End If

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

    Private Sub AddCategoryButton_Click(sender As Object, e As EventArgs) Handles AddCategoryButton.Click

        AddCategory.IsWarehouse = True
        Hide
        AddCategory.Opacity = 0
        WarehouseComboBox.Items.Clear
        GeneralModule.ShowOverlay(MainForm, AddCategory)

    End Sub
End Class