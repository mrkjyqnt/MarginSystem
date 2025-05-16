Imports System.Runtime.InteropServices
Imports System.TimeZoneInfo


Public Class MainForm

    Public ManagementInfront As String = "Dashboard"
    Dim ShutdownSystem As Boolean = False

    'This is to block close control box.
    'Private Const SC_CLOSE As Integer = &HF060 ' Command to close the window
    'Private Const MF_GRAYED As Integer = &H1 ' Grayed out (disabled)
    'Private Const MF_BYCOMMAND As Integer = &H0 ' By specific command

    '<DllImport("user32.dll", SetLastError:=True)>
    'Private Shared Function GetSystemMenu(hWnd As IntPtr, bRevert As Boolean) As IntPtr
    'End Function

    '<DllImport("user32.dll", SetLastError:=True)>
    'Private Shared Function EnableMenuItem(hMenu As IntPtr, uIDEnableItem As Integer, uEnable As Integer) As Boolean
    'End Function

    'Private Sub DisableCloseButton()
    '   Dim hMenu As IntPtr = GetSystemMenu(Me.Handle, False)
    '  If hMenu <> IntPtr.Zero Then
    '     EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
    'End If
    'End Sub

    'Protected Overrides Sub OnLoad(e As EventArgs)
    '   MyBase.OnLoad(e)
    '  DisableCloseButton() ' Disable the close button when the form loads
    'End Sub

    Private Sub DashboardButton_MouseEnter(sender As Object, e As EventArgs) Handles DashboardButton.MouseEnter

        GeneralModule.ChangeFillColor(DashboardPanel, 39, 110, 241)

    End Sub

    Private Sub ProductManagementButton_MouseEnter(sender As Object, e As EventArgs) Handles ProductManagementButton.MouseEnter

        GeneralModule.ChangeFillColor(ProductManagementPanel, 39, 110, 241)

    End Sub

    Private Sub StockManagementButton_MouseEnter(sender As Object, e As EventArgs) Handles StockManagementButton.MouseEnter

        GeneralModule.ChangeFillColor(StockManagementPanel, 39, 110, 241)

    End Sub

    Private Sub InventoryManagementButton_MouseEnter(sender As Object, e As EventArgs) Handles InventoryMonitoringButton.MouseEnter

        GeneralModule.ChangeFillColor(InventoryMonitoringPanel, 39, 110, 241)

    End Sub

    Private Sub ValuationAndReportsButton_MouseEnter(sender As Object, e As EventArgs) Handles ValuationAndReportsButton.MouseEnter

        GeneralModule.ChangeFillColor(ValuationAndReportsPanel, 39, 110, 241)

    End Sub

    Private Sub DataBackupButton_MouseEnter(sender As Object, e As EventArgs) Handles DataBackupButton.MouseEnter

        GeneralModule.ChangeFillColor(DataBackupPanel, 39, 110, 241)

    End Sub

    Private Sub AccountButton_MouseEnter(sender As Object, e As EventArgs) Handles AccountButton.MouseEnter

        GeneralModule.ChangeFillColor(AccountPanel, 39, 110, 241)

    End Sub

    Private Sub DashboardButton_MouseLeave(sender As Object, e As EventArgs) Handles DashboardButton.MouseLeave

        If GeneralModule.ButtonDictionary("Dashboard") = False Then

            GeneralModule.ChangeFillColor(DashboardPanel, 229, 229, 234)

        End If

    End Sub

    Private Sub ProductManagementButton_MouseLeave(sender As Object, e As EventArgs) Handles ProductManagementButton.MouseLeave

        If GeneralModule.ButtonDictionary("Product Management") = False Then

            GeneralModule.ChangeFillColor(ProductManagementPanel, 229, 229, 234)

        End If

    End Sub

    Private Sub StockManagementButton_MouseLeave(sender As Object, e As EventArgs) Handles StockManagementButton.MouseLeave

        If GeneralModule.ButtonDictionary("Stock Management") = False Then

            GeneralModule.ChangeFillColor(StockManagementPanel, 229, 229, 234)

        End If

    End Sub

    Private Sub InventoryManagementButton_MouseLeave(sender As Object, e As EventArgs) Handles InventoryMonitoringButton.MouseLeave

        If GeneralModule.ButtonDictionary("Inventory Monitoring") = False Then

            GeneralModule.ChangeFillColor(InventoryMonitoringPanel, 229, 229, 234)

        End If

    End Sub

    Private Sub ValuationAndReportsButton_MouseLeave(sender As Object, e As EventArgs) Handles ValuationAndReportsButton.MouseLeave

        If GeneralModule.ButtonDictionary("Valuation and Reports") = False Then

            GeneralModule.ChangeFillColor(ValuationAndReportsPanel, 229, 229, 234)

        End If

    End Sub

    Private Sub DataBackupButton_MouseLeave(sender As Object, e As EventArgs) Handles DataBackupButton.MouseLeave

        If GeneralModule.ButtonDictionary("Data Backup and Recovery") = False Then

            GeneralModule.ChangeFillColor(DataBackupPanel, 229, 229, 234)

        End If

    End Sub

    Private Sub AccountButton_MouseLeave(sender As Object, e As EventArgs) Handles AccountButton.MouseLeave

        If GeneralModule.ButtonDictionary("Account") = False Then

            GeneralModule.ChangeFillColor(AccountPanel, 229, 229, 234)

        End If

    End Sub

    Private Sub DashboardButton_Click(sender As Object, e As EventArgs) Handles DashboardButton.Click

        If Not ManagementInfront = "Dashboard"

            Opacity = 0

        End If

        GeneralModule.ChooseNavigation(DashboardPanel, DashboardButton, "Hovered", "Home", GeneralModule.ButtonDictionary, "Dashboard", Dashboard, DashboardFormPanel)
        GeneralModule.ResetNavigation(ProductManagementPanel, ProductManagementButton, "Box",
                                        StockManagementPanel, StockManagementButton, "Layer",
                                        InventoryMonitoringPanel, InventoryMonitoringButton, "Monitor",
                                        ValuationAndReportsPanel, ValuationAndReportsButton, "Calculator",
                                        DataBackupPanel, DataBackupButton, "Cloud",
                                        AccountPanel, AccountButton, "Account")

        Dashboard.ActiveControl = Dashboard.FormPanel

        If Not ManagementInfront = "Dashboard"

            GeneralModule.FadeInForm(Me)

        End If

        ManagementInfront = "Dashboard"

    End Sub

    Private Sub ProductManagementButton_Click(sender As Object, e As EventArgs) Handles ProductManagementButton.Click

        If Not ManagementInfront = "Product Management"

            Opacity = 0

        End If

        GeneralModule.ChooseNavigation(ProductManagementPanel, ProductManagementButton, "Hovered", "Box", GeneralModule.ButtonDictionary, "Product Management", ProductManagement, ProductManageFormPanel)
        GeneralModule.ResetNavigation(DashboardPanel, DashboardButton, "Home",
                                        StockManagementPanel, StockManagementButton, "Layer",
                                        InventoryMonitoringPanel, InventoryMonitoringButton, "Monitor",
                                        ValuationAndReportsPanel, ValuationAndReportsButton, "Calculator",
                                        DataBackupPanel, DataBackupButton, "Cloud",
                                        AccountPanel, AccountButton, "Account")

        ProductManagement.ActiveControl = ProductManagement.FormPanel

        If Not ManagementInfront = "Product Management"

            GeneralModule.FadeInForm(Me)

        End If

        ManagementInfront = "Product Management"

    End Sub

    Private Sub StockManagementButton_Click(sender As Object, e As EventArgs) Handles StockManagementButton.Click

        If Not ManagementInfront = "Stock Management"

            Opacity = 0

        End If

        GeneralModule.ChooseNavigation(StockManagementPanel, StockManagementButton, "Hovered", "Layer", GeneralModule.ButtonDictionary, "Stock Management", StockManagement, StockManageFormPanel)
        GeneralModule.ResetNavigation(ProductManagementPanel, ProductManagementButton, "Box",
                                        DashboardPanel, DashboardButton, "Home",
                                        InventoryMonitoringPanel, InventoryMonitoringButton, "Monitor",
                                        ValuationAndReportsPanel, ValuationAndReportsButton, "Calculator",
                                        DataBackupPanel, DataBackupButton, "Cloud",
                                        AccountPanel, AccountButton, "Account")

        StockManagement.ActiveControl = StockManagement.FormPanel

        If Not ManagementInfront = "Stock Management"

            GeneralModule.FadeInForm(Me)

        End If

        ManagementInfront = "Stock Management"

    End Sub

    Private Sub InventoryMonitoringButton_Click(sender As Object, e As EventArgs) Handles InventoryMonitoringButton.Click

        If Not ManagementInfront = "Inventory Monitoring"

            Opacity = 0

        End If

        GeneralModule.ChooseNavigation(InventoryMonitoringPanel, InventoryMonitoringButton, "Hovered", "Monitor", GeneralModule.ButtonDictionary, "Inventory Monitoring", InventoryMonitoring, InventoryMonitorFormPanel)
        GeneralModule.ResetNavigation(ProductManagementPanel, ProductManagementButton, "Box",
                                        StockManagementPanel, StockManagementButton, "Layer",
                                        DashboardPanel, DashboardButton, "Home",
                                        ValuationAndReportsPanel, ValuationAndReportsButton, "Calculator",
                                        DataBackupPanel, DataBackupButton, "Cloud",
                                        AccountPanel, AccountButton, "Account")

        If Not ManagementInfront = "Inventory Monitoring"

            GeneralModule.FadeInForm(Me)

        End If

        ManagementInfront = "Inventory Monitoring"
        InventoryTransactions.ActiveControl = InventoryTransactions.FormPanel

    End Sub

    Private Sub ValuationAndReportsButton_Click(sender As Object, e As EventArgs) Handles ValuationAndReportsButton.Click

        If Not ManagementInfront = "Valuation and Reports"

            Opacity = 0

        End If

        GeneralModule.ChooseNavigation(ValuationAndReportsPanel, ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", ValuationAndReports, ValuationReportsFormPanel)
        GeneralModule.ResetNavigation(ProductManagementPanel, ProductManagementButton, "Box",
                                        StockManagementPanel, StockManagementButton, "Layer",
                                        InventoryMonitoringPanel, InventoryMonitoringButton, "Monitor",
                                        DashboardPanel, DashboardButton, "Home",
                                        DataBackupPanel, DataBackupButton, "Cloud",
                                        AccountPanel, AccountButton, "Account")

        ValuationAndReports.ActiveControl = ValuationAndReports.FormPanel

        If Not ManagementInfront = "Valuation and Reports"

            GeneralModule.FadeInForm(Me)

        End If

        ManagementInfront = "Valuation and Reports"
        Activities.ActiveControl = Activities.FormPanel
        SalesValuation.ActiveControl = SalesValuation.FormPanel
        InventoryValuation.ActiveControl = InventoryValuation.FormPanel

    End Sub

    Private Sub DataBackupButton_Click(sender As Object, e As EventArgs) Handles DataBackupButton.Click

        If Not ManagementInfront = "Data Backup and Recovery"

            Opacity = 0

        End If

        GeneralModule.ChooseNavigation(DataBackupPanel, DataBackupButton, "Hovered", "Cloud", GeneralModule.ButtonDictionary, "Data Backup and Recovery", DataBackupAndRecovery, DataBackupRecoveryFormPanel)
        GeneralModule.ResetNavigation(ProductManagementPanel, ProductManagementButton, "Box",
                                        StockManagementPanel, StockManagementButton, "Layer",
                                        InventoryMonitoringPanel, InventoryMonitoringButton, "Monitor",
                                        ValuationAndReportsPanel, ValuationAndReportsButton, "Calculator",
                                        DashboardPanel, DashboardButton, "Home",
                                        AccountPanel, AccountButton, "Account")

        DataBackupAndRecovery.ActiveControl = DataBackupAndRecovery.FormPanel

        If Not ManagementInfront = "Data Backup and Recovery"

            GeneralModule.FadeInForm(Me)

        End If

        ManagementInfront = "Data Backup and Recovery"

    End Sub

    Private Sub AccountButton_Click(sender As Object, e As EventArgs) Handles AccountButton.Click

        If Not ManagementInfront = "Account"

            Opacity = 0

        End If

        GeneralModule.ChooseNavigation(AccountPanel, AccountButton, "", "User", GeneralModule.ButtonDictionary, "Account", Account, AccountFormPanel)
        GeneralModule.ResetNavigation(ProductManagementPanel, ProductManagementButton, "Box",
                                        StockManagementPanel, StockManagementButton, "Layer",
                                        InventoryMonitoringPanel, InventoryMonitoringButton, "Monitor",
                                        ValuationAndReportsPanel, ValuationAndReportsButton, "Calculator",
                                        DataBackupPanel, DataBackupButton, "Cloud",
                                        DashboardPanel, DashboardButton, "Home")

        If Not ManagementInfront = "Account"

            GeneralModule.FadeInForm(Me)

        End If

        ManagementInfront = "Account"

    End Sub

    Private Async Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.ChooseNavigation(DashboardPanel, DashboardButton, "Hovered", "Home", GeneralModule.ButtonDictionary, "Dashboard", Dashboard, DashboardFormPanel)
        GeneralModule.ResetNavigation(ProductManagementPanel, ProductManagementButton, "Box",
                                        StockManagementPanel, StockManagementButton, "Layer",
                                        InventoryMonitoringPanel, InventoryMonitoringButton, "Monitor",
                                        ValuationAndReportsPanel, ValuationAndReportsButton, "Calculator",
                                        DataBackupPanel, DataBackupButton, "Cloud",
                                        AccountPanel, AccountButton, "Account")

        Dashboard.ActiveControl = Dashboard.FormPanel
        Account.UsernameLabel.Text = Variables.LoggedInUser
        Dim PIN As String = Await LoginDatabaseModule.GetPin(Variables.LoggedInUser)
        ProfileSettings.NameTextBox.Text = Variables.LoggedInUser
        ProfileSettings.PINTextBox.Text = PIN

        Dim ExpiredQuery As String = "SELECT stock_id FROM stock WHERE expiration_date < CAST(GETDATE() AS DATE) AND active = 1"

        Await InventoryValuationModule.RetrieveAllExpiredStock(ExpiredQuery)
        Dim Exists As Boolean

        For Each StockId In ListofExpiredStockId

            Exists = Await CheckIfExpiredAlreadyIntheValuation(StockId)

            If Not Exists

                Dim Capital As Double = Await ProductManagementDatabaseModule.GetCapital(Await StockManagementModule.GetProductIdByStockId(stockId))
                Dim CurrentStock As Integer = Await StockManagementModule.GetCurrentStock(StockId)
                Dim TotalValue = Capital * CurrentStock
                Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                Await InventoryValuationModule.InsertIntoInventoryValuation(StockId, 0, 0, TotalValue, DateAdded, TimeAdded, False)

            End If

        Next

        Dim ProductQuery As String = "SELECT * FROM product WHERE active = 1 ORDER BY product_id DESC"
        Await ProductManagementDatabaseModule.RetrieveALL(ProductQuery)
        Await ProductManagement.CreateProductUserControl()

        Dim StockQuery As String = "SELECT * FROM stock WHERE active = 1 ORDER BY stock_id DESC"
        GeneralModule.DeleteUserControls(StockManagement.FormPanel)
        Await StockManagementModule.RetrieveAll(StockQuery)
        Await StockManagement.CreateStockUserControl()

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()

        Dim InventoryTransactionQuery As String = "SELECT * FROM stock_transaction ORDER BY transaction_id DESC"
        GeneralModule.DeleteUserControls(InventoryTransactions.FormPanel)
        Await InventoryTransactionDatabaseModule.RetrieveALL(InventoryTransactionQuery)
        Await InventoryTransactions.CreateTransactionUserControl()

        Dim SalesQuery As String = "SELECT * FROM sale ORDER BY sale_id DESC"
        GeneralModule.DeleteUserControls(SalesValuation.FormPanel)
        Await SaleValuationModule.RetrieveAll(SalesQuery)
        Await SalesValuation.CreateSaleUserControl()

        Dim InventoryValuationQuery As String = "SELECT * FROM inventory_valuation ORDER BY inventory_id DESC"
        GeneralModule.DeleteUserControls(InventoryValuation.FormPanel)
        Await InventoryValuationModule.RetrieveAll(InventoryValuationQuery)
        Await InventoryValuation.CreateValuationUserControl()

        Dim BackUpQuery As String = "SELECT * FROM system_backup ORDER BY backup_id DESC"
        GeneralModule.DeleteUserControls(DataBackupAndRecovery.FormPanel)
        Await DataBackupModule.RetrieveALL(BackUpQuery)
        DataBackupAndRecovery.CreateDatabaseUserControl()

        Dim TotalSold As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Sold", Variables.CurrentMonth)
        InventoryMonitoring.SoldLabel.Text = TotalSold
        InventoryTransactions.SoldLabel.Text = TotalSold

        Dim TotalAdded As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Added", Variables.CurrentMonth)
        InventoryMonitoring.AddedLabel.Text = TotalAdded
        InventoryTransactions.AddedLabel.Text = TotalAdded

        Dim TotalRemoved As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Removed", Variables.CurrentMonth)
        InventoryMonitoring.RemovedLabel.Text = TotalRemoved
        InventoryTransactions.RemovedLabel.Text = TotalRemoved

        Dim TotalQuantitySold As Integer = Await SaleValuationModule.CountSum("quantity_sold", "sale", Variables.CurrentMonth, "transaction_date")
        SalesValuation.TotalQuantitySoldLabel.Text = TotalQuantitySold

        Dim TotalProfit As Double = Await SaleValuationModule.CountSum("net_sale", "sale", Variables.CurrentMonth, "transaction_date")
        SalesValuation.TotalProfitLabel.Text = $"₱ {TotalProfit}"

        Dim TotalSales As Double = Await SaleValuationModule.CountSum("gross_sale", "sale", Variables.CurrentMonth, "transaction_date")
        SalesValuation.TotalSalesLabel.Text = $"₱ {TotalSales}"

        Dim ListOfProduct As List(Of Object)
        ListOfProduct = Await StockManagementModule.GetProducts()
        ListOfProduct.ToString

        For each Item As String In ListOfProduct

            ValuationAndReports.ProductComboBox.Items.Add(Item)

        Next

        Dim ListOfBProductsInSale As List(Of Object)
        ListOfBProductsInSale = Await SaleValuationModule.GetProductsFromSale()
        ListOfBProductsInSale.ToString

        For each Item As String In ListOfBProductsInSale

            ValuationAndReports.ProdustSaleComboBox.Items.Add(Item)

        Next

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub QuitMenuItem_Click(sender As Object, e As EventArgs) Handles QuitMenuItem.Click

        'Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        'Dim TimeAdded = Variables.CurrrentDate.ToString("t")
        'Await ActivityDatabaseModule.InsertActivity("Close Application", String.Empty, AddedBy, "account", DateAdded, TimeAdded, $"{Variables.LoggedInUser} Close the Application")
        ShutdownSystem = True
        Application.Exit

    End Sub

    Private Async Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim Question As MsgBoxResult = MessageBox.Show("Are you sure you want to logout?", "Logging out.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If Question = MsgBoxResult.Yes

            Await LoginDatabaseModule.LoggedIn(0, Variables.LoggedInUser)
            Login.Show
            Dispose()

        ElseIf Question = MsgBoxResult.No

            'Walang ganap. Doon ka sa far away!

        End If

    End Sub

    Private Sub ShowContextMenuItem_Click(sender As Object, e As EventArgs) Handles ShowContextMenuItem.Click

        Show()
        WindowState = FormWindowState.Normal
        Activate()
        SystemNotifyIcon.Visible = False

    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Not ShutdownSystem Then

            SystemNotifyIcon.Visible = True
            Me.Hide()
            e.Cancel = True

        Else

            SystemNotifyIcon.Visible = False

        End If

    End Sub

    Private Sub SystemNotifyIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles SystemNotifyIcon.MouseClick

        If e.Button = MouseButtons.Left Then

            Show()
            WindowState = FormWindowState.Normal
            Activate()
            SystemNotifyIcon.Visible = False

        End If

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click

        Application.Restart()
        Environment.Exit(0) 

    End Sub
End Class