Public Class ValuationAndReports

    Dim ProductId As Integer

    Public TotalSalesValuation As Color
    Public TotalProfitValuation As Color

    Private Sub SalesLabel2_MouseEnter(sender As Object, e As EventArgs) Handles SalesButton.MouseEnter, SalesLabel2.MouseEnter, SalesLabel1.MouseEnter, SaleImage1.MouseEnter, SaleImage2.MouseEnter

        GeneralModule.PanelToButton(SalesButton, SaleImage1, SaleImage2, 210, "HoveredWallet", "HoveredMore")

    End Sub

    Private Sub SalesButton_MouseLeave(sender As Object, e As EventArgs) Handles SalesButton.MouseLeave

        GeneralModule.PanelToButton(SalesButton, SaleImage1, SaleImage2, 247, "Wallet", "More")

    End Sub

    Private Sub SalesLabel2_MouseDown(sender As Object, e As MouseEventArgs) Handles SalesButton.MouseDown, SalesLabel2.MouseDown, SalesLabel1.MouseDown, SaleImage1.MouseDown, SaleImage2.MouseDown

        GeneralModule.PanelToButton(SalesButton, SaleImage1, SaleImage2, 147, "HoveredWallet", "HoveredMore")

    End Sub

    Private Sub InventoryButton_MouseEnter(sender As Object, e As EventArgs) Handles InventoryButton.MouseEnter, InventoryLabel2.MouseEnter, InventoryLabel1.MouseEnter, InventoryImage1.MouseEnter, InventoryImage2.MouseEnter

        GeneralModule.PanelToButton(InventoryButton, InventoryImage1, InventoryImage2, 210, "HoveredBigBox", "HoveredMore")

    End Sub

    Private Sub InventoryButton_MouseLeave(sender As Object, e As EventArgs) Handles InventoryButton.MouseLeave

        GeneralModule.PanelToButton(InventoryButton, InventoryImage1, InventoryImage2, 247, "BigBox", "More")

    End Sub

    Private Sub InventoryButton_MouseDown(sender As Object, e As MouseEventArgs) Handles InventoryButton.MouseDown, InventoryLabel2.MouseDown, InventoryLabel1.MouseDown, InventoryImage1.MouseDown, InventoryImage2.MouseDown

        GeneralModule.PanelToButton(InventoryButton, InventoryImage1, InventoryImage2, 147, "HoveredBigBox", "HoveredMore")

    End Sub

    Private Sub ActivitiesLabel2_MouseEnter(sender As Object, e As EventArgs) Handles ActivitiesButton.MouseEnter, ActivitiesLabel2.MouseEnter, ActivitiesLabel1.MouseEnter, ActivitiesImage1.MouseEnter, ActivitiesImage2.MouseEnter

        GeneralModule.PanelToButton(ActivitiesButton, ActivitiesImage1, ActivitiesImage2, 210, "HoveredClock", "HoveredMore")

    End Sub

    Private Sub ActivitiesButton_MouseLeave(sender As Object, e As EventArgs) Handles ActivitiesButton.MouseLeave

        GeneralModule.PanelToButton(ActivitiesButton, ActivitiesImage1, ActivitiesImage2, 247, "Clock", "More")

    End Sub

    Private Sub ActivitiesLabel2_MouseDown(sender As Object, e As MouseEventArgs) Handles ActivitiesButton.MouseDown, ActivitiesLabel2.MouseDown, ActivitiesLabel1.MouseDown, ActivitiesImage1.MouseDown, ActivitiesImage2.MouseDown

        GeneralModule.PanelToButton(ActivitiesButton, ActivitiesImage1, ActivitiesImage2, 147, "HoveredClock", "HoveredMore")

    End Sub

    Private Sub SalesLabel2_Click(sender As Object, e As EventArgs) Handles SalesButton.Click, SalesLabel2.Click, SalesLabel1.Click, SaleImage1.Click, SaleImage2.Click

        Cursor = Cursors.WaitCursor
        MainForm.Opacity = 0
        MainForm.ValuationReportsFormPanel.Controls.Clear
        GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", SalesValuation, MainForm.ValuationReportsFormPanel)
        SalesValuation.ActiveControl = SalesValuation.FormPanel
        GeneralModule.PanelToButton(SalesButton, SaleImage1, SaleImage2, 247, "Wallet", "More")
        GeneralModule.FadeInForm(MainForm)
        Cursor = Cursors.Default

    End Sub

    Private Sub InventoryLabel2_Click(sender As Object, e As EventArgs) Handles InventoryButton.Click, InventoryLabel2.Click, InventoryLabel1.Click, InventoryImage1.Click, InventoryImage2.Click

        Cursor = Cursors.WaitCursor
        MainForm.Opacity = 0
        MainForm.ValuationReportsFormPanel.Controls.Clear
        GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", InventoryValuation, MainForm.ValuationReportsFormPanel)
        InventoryValuation.ActiveControl = InventoryValuation.FormPanel
        GeneralModule.PanelToButton(InventoryButton, InventoryImage1, InventoryImage2, 247, "BigBox", "More")
        GeneralModule.FadeInForm(MainForm)
        Cursor = Cursors.Default

    End Sub

    Private Sub ActivitiesLabel2_Click(sender As Object, e As EventArgs) Handles ActivitiesButton.Click, ActivitiesLabel2.Click, ActivitiesLabel1.Click, ActivitiesImage1.Click, ActivitiesImage2.Click

        Cursor = Cursors.WaitCursor
        MainForm.Opacity = 0
        MainForm.ValuationReportsFormPanel.Controls.Clear
        GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", Activities, MainForm.ValuationReportsFormPanel)
        Activities.ActiveControl = Activities.FormPanel
        GeneralModule.PanelToButton(ActivitiesButton, ActivitiesImage1, ActivitiesImage2, 247, "Clock", "More")
        GeneralModule.FadeInForm(MainForm)
        Cursor = Cursors.Default

    End Sub

    Private Async Sub ProductComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProductComboBox.SelectedIndexChanged

        If ProductComboBox.SelectedIndex <> -1

            ProductId = Await StockManagementModule.GetProductId(ProductComboBox.SelectedItem.ToString)
            Dim Total As Double = Await ValuationAndReportsModule.CountProductTotalValuation(ProductId)
            TotalInventoryValueLabel.Text = $"₱ {Total}"

            Dim TotalLoss As Double = Await InventoryValuationModule.TotalLossPerProduct(ProductId)
            TotalLossLabel.Text = $"₱ {TotalLoss}"

        End If

    End Sub

    Private Async Sub MonthComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProdustSaleComboBox.SelectedIndexChanged


        If ProdustSaleComboBox.SelectedIndex <> -1

            Dim ProductName As String = ProdustSaleComboBox.SelectedItem.ToString
            Dim ProductId As Integer = Await StockManagementModule.GetProductId(ProductName)
            Dim StockId As Integer = Await StockManagementModule.GetStockIdByProductID(ProductId)

            HigherThanLastMonthSalesLabel.Show
            Label20.Show
            HigherThanLastMonthProfitLabel.Show
            Label18.Show

            Dim TotalSales As Double = Await SaleValuationModule.CountTotalSales(StockId)
            TotalSalesLabel.Text = $"₱ {TotalSales}"

            Dim TotalProfit As Double = Await SaleValuationModule.CountTotalProfit(StockId)
            TotalProfitLabel.Text = $"₱ {TotalProfit}"

            Dim lastMonth As String = DateTime.Now.AddMonths(-1).ToString("yyyy-MM")
            Dim thisMonth As String = DateTime.Now.ToString("MM")

            Dim SaleMessage As String = Await SaleValuationModule.CompareSaleValuation(lastMonth, thisMonth, StockId)

            If SaleMessage = "No change from last month." Then Label20.hide Else Label20.Show

            HigherThanLastMonthSalesLabel.ForeColor = TotalSalesValuation
            HigherThanLastMonthSalesLabel.Text = SaleMessage
            Label20.Left = HigherThanLastMonthSalesLabel.Right

            Dim ProfitMessage As String = Await SaleValuationModule.CompareProfitValuation(lastMonth, thisMonth, StockId)

            If ProfitMessage = "No change from last month." Then Label18.hide Else Label18.Show

            HigherThanLastMonthProfitLabel.ForeColor = TotalSalesValuation
            HigherThanLastMonthProfitLabel.Text = ProfitMessage
            Label18.Left = HigherThanLastMonthProfitLabel.Right

        End If

    End Sub

    Private Sub ValuationAndReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class