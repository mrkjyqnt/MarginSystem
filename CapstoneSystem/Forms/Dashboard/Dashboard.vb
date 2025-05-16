Imports System.Globalization

Public Class Dashboard

    Public ValuationColor As Color
    Public WeekValuationColor As Color
    Public TodayValuationColor As Color

    Private Sub NewProductButton_Click(sender As Object, e As EventArgs) Handles NewProductButton.Click

        GeneralModule.ShowOverlay(MainForm, AddNewProduct)
        Focus
        ActiveControl = FormPanel

    End Sub

    Private Sub StockEntryButton_Click(sender As Object, e As EventArgs) Handles StockEntryButton.Click

        StockEntry.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, StockEntry)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Sub RecordSaleButton_Click(sender As Object, e As EventArgs) Handles RecordSaleButton.Click

        RecordSale.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, RecordSale)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Async Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Total Inventory Valuation
        Dim totalValuation As Double = Await DashboardModule.CountTotalValuation
        TotalValueLabel.Text = $"₱ {totalValuation}"
        
        'This month inventory valuation
        Dim InventoryValuationThisMonth As Double = Await SaleValuationModule.CountSum("retail_valuation", "inventory_valuation", Variables.CurrentMonth, "date_added")
        InventoryValuation.TotalValueLabel.Text = $"₱ {InventoryValuationThisMonth}"

        'Inventory valuation comparison (this month and last month)
        Dim lastMonth As String = DateTime.Now.AddMonths(-1).ToString("yyyy-MM")
        Dim thisMonth As String = DateTime.Now.ToString("yyyy-MM")
        Dim message As String = Await DashboardModule.CompareValuation(lastMonth, thisMonth)
        If message = "No change from last month." Then Label9.hide Else Label9.Show
        ValuationPercentLabel.ForeColor = ValuationColor
        ValuationPercentLabel.Text = message
        Label9.Left = ValuationPercentLabel.Right

        'Total Stocks
        Dim totalStocks As Integer = Await DashboardModule.CountTotalStocks
        TotalStockLabel.Text = totalStocks

        'Count Low Stock batches
        Dim lowStock As Integer = Await DashboardModule.CountLowStock
        LowStockLabel.Text = lowStock
        InventoryMonitoring.LowStockLabel.Text = lowStock
        InventoryTransactions.LowStockLabel.Text = lowStock

        'Count batches about to expire
        Dim aboutToExpire As Integer = Await DashboardModule.CountAboutToExpire
        AboutToExpireLabel.Text = aboutToExpire
        InventoryMonitoring.AboutToExpireLabel.Text = aboutToExpire
        InventoryTransactions.AboutToExpireLabel.Text = aboutToExpire

        'Count all expired batches
        Dim expired As Integer = Await DashboardModule.CountExpiredItems
        ExpiredLabel.Text = expired

        'Compare today and yesterday sale valuation
        Dim TodayValuation As Double = Await DashboardModule.YesterdayTodayTotalValuation
        TodayLabel.Text = $"₱ {TodayValuation}"
        Dim yesterday As String = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
        Dim today As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim todaycomparison As String = Await DashboardModule.CompareTodayValuation(yesterday, today)
        HigherThanLastYesterdayLabel.ForeColor = TodayValuationColor
        HigherThanLastYesterdayLabel.Text = todaycomparison
        Label18.Left = HigherThanLastYesterdayLabel.Right

        'Compare this week and last week sale valuation
        Dim ThisWeekValuation As Double = Await DashboardModule.ThisWeekTotalValuation
        ThisWeekLabel.Text = $"₱ {ThisWeekValuation}"
        Dim lastWeek As String = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(-7), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString()
        Dim thisWeek As String = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString()
        Dim weekcomparison As String = Await DashboardModule.WeekComparison(lastWeek, thisWeek)
        If weekcomparison = "No change from last week." Then Label23.hide Else Label23.Show
        LowerThanLastWeekLabel.ForeColor = WeekValuationColor
        LowerThanLastWeekLabel.Text = weekcomparison
        Label23.Left = LowerThanLastWeekLabel.Right

        'Compare this month and last month sale valuation
        Dim ThisMonthSale As Double = Await SaleValuationModule.CountSum("gross_sale", "sale", Variables.CurrentMonth, "transaction_date")
        ThisMonthLabel.Text = $"₱ {ThisMonthSale}"
        Dim message1 As String = Await DashboardModule.CompareSale(lastMonth, thisMonth)
        If message1 = "No change from last month." Then label28.hide Else label28.Show
        ValuationPercentLabel2.ForeColor = ValuationColor
        ValuationPercentLabel2.Text = message1
        Label28.Left = ValuationPercentLabel2.Right


        Dim expiredThisMonth As Integer = Await DashboardModule.CountExpiredItemsThisMonth
        InventoryMonitoring.ExpiredLabel.Text = expiredThisMonth
        InventoryTransactions.ExpiredLabel.Text = expiredThisMonth

        Dim SumTotalLoss As Double = Await InventoryValuationModule.TotalLoss
        InventoryValuation.TotalLossLabel.Text = $"₱ {SumTotalLoss}"

        Dim SumTotalQuantityExpired As Integer = Await InventoryValuationModule.CountQuantityExpiredItems
        InventoryValuation.TotalQuantityExpiredLabel.Text = SumTotalQuantityExpired

    End Sub

End Class