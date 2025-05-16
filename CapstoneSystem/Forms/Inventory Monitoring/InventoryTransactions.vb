Imports System.Security.AccessControl

Public Class InventoryTransactions
    Private Async Sub BackLabel_Click(sender As Object, e As EventArgs) Handles BackLabel.Click

        MainForm.Opacity = 0
        Cursor = Cursors.WaitCursor
        
        HideSearchFlowLayout()

        Variables.TransactionNumberOfFilters = 0
        Variables.TransactionFilterBy = String.Empty
        Variables.TransactionByDate = String.Empty
        Variables.TransactionSortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        FilterByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim InventoryTransactionQuery As String = "SELECT * FROM stock_transaction ORDER BY transaction_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await InventoryTransactionDatabaseModule.RetrieveAll(InventoryTransactionQuery)
        Await CreateTransactionUserControl()

        Dim TotalSold As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Sold", Variables.CurrentMonth)
        SoldLabel.Text = TotalSold

        Dim TotalAdded As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Added", Variables.CurrentMonth)
        AddedLabel.Text = TotalAdded

        Dim TotalRemoved As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Removed", Variables.CurrentMonth)
        RemovedLabel.Text = TotalRemoved

        ' Update the UI
        Dim TotalTransactionSearched As Integer = Variables.ListOfTransactionId.Count
        Label3.Text = TotalTransactionSearched & " Transaction found"

        MainForm.InventoryMonitorFormPanel.Controls.Clear
        GeneralModule.ChooseNavigation(MainForm.InventoryMonitoringPanel, MainForm.InventoryMonitoringButton, "Hovered", "Monitor", GeneralModule.ButtonDictionary, "Inventory Monitoring", InventoryMonitoring, MainForm.InventoryMonitorFormPanel)
        GeneralModule.FadeInForm(MainForm)
        Cursor = Cursors.Default

    End Sub

    Private Sub BackLabel_MouseEnter(sender As Object, e As EventArgs) Handles BackLabel.MouseEnter

        BackLabel.Font = New Font("Inter Black", 20)
        Label2.Location = New point(376, 0)

    End Sub

    Private Sub BackLabel_MouseLeave(sender As Object, e As EventArgs) Handles BackLabel.MouseLeave

        BackLabel.Font = New Font("Inter Semibold", 20)
        Label2.Location = New point(362, 0)

    End Sub

    Private Sub InventoryTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If FormPanel.Controls.OfType(Of InventoryTransactionUserControl).Any

            Label1.Hide
            Label3.show
            Label3.Text = FormPanel.Controls.OfType(Of InventoryTransactionUserControl).Count & " Transaction found"

        Else

            Label1.Show
            Label3.Hide

        End If

    End Sub

    Private Async Sub GenerateReport_Click(sender As Object, e As EventArgs) Handles GenerateReportButton.Click

        GenerateReport.Opacity = 0
        HideSearchFlowLayout
        GenerateReport.TableName = "stock_transaction"
        GeneralModule.ShowOverlay(MainForm, GenerateReport)

        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "inventory transaction", DateAdded, TimeAdded, $"Generate Report for Inventory Transactions")

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()

        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Sub CreateUserControl(TransactionId As Integer, StockId As Integer, Quantity As Integer, StockName As String,
                             DateAdded As String, TransactionType As String, ProductImage As Byte())

        'Creation ng Stock User Control

        Dim VerticalMargin As Integer = 5
        Dim ControlHeight As Integer = 100

        Dim ControlWidth As Integer = FormPanel.ClientSize.Width - 6

        'Ni ca-calculate nito yung height control hanggang bottom
        Dim MaxBottom As Integer = 0

        For Each Ctrl As Control In FormPanel.Controls
            'Exclude the SearchFlowLayoutPanel
            If Ctrl.Name <> "ResultSearchPanel" Then
                If Ctrl.Bottom > MaxBottom Then
                    MaxBottom = Ctrl.Bottom
                End If
            End If
        Next

        Dim NewYPosition As Integer = MaxBottom + VerticalMargin

        Dim NewTransaction As New InventoryTransactionUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(3, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }

        If ProductImage IsNot Nothing Then
            Using ms As New IO.MemoryStream(ProductImage)
                NewTransaction.PlaceholderImage.Image = Image.FromStream(ms)
            End Using
        End If

        'Assigning ng values ng products sa user control/
        NewTransaction.TransactionIdLabel.Text = TransactionId
        NewTransaction.StockIdLabel.Text = StockId
        NewTransaction.StockNameLabel.Text = StockName
        NewTransaction.QuantityDateLabel.Text = $"{Quantity} | {DateAdded}"
        NewTransaction.TransactionTypeLabel.Text = TransactionType

        FormPanel.Controls.Add(NewTransaction)

    End Sub

    Async Function CreateTransactionUserControl() As Task

        'Mag produce ng user controls.

        For i As Integer = 0 To ListOfTransactionId.Count - 1

            CreateUserControl(Variables.ListOfTransactionId(i), Variables.ListOfTransactionStockId(i), Variables.ListOfTransactionQuantity(i),
                                Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(Variables.ListOfTransactionStockId(i))),
                                Variables.ListOfTransactionDate(i), Variables.ListOfTransactionName(i), Await StockManagementModule.GetProductImage(Await StockManagementModule.GetProductIdByStockId(Variables.ListOfTransactionStockId(i))))

        Next

    End Function

    Private Sub HideSearchFlowLayout

        If ResultSearchPanel.Visible

            ResultSearchPanel.Hide

        End If

    End Sub

    Public Sub CreateSearchUserControl(TransactionId As Integer, StockId As Integer, TransactionType As String)

        'Creation naman ito ng product user control sa search bar.
        Dim VerticalMargin As Integer = 5
        Dim ControlHeight As Integer = 50
        Dim ControlWidth As Integer = ResultSearchPanel.ClientSize.Width - 6

        'Ni ca-calculate nito yung height control hanggang bottom
        Dim MaxBottom As Integer = 0

        For Each Ctrl As Control In ResultSearchPanel.Controls

            If Ctrl.Bottom > MaxBottom Then
                MaxBottom = Ctrl.Bottom
            End If

        Next

        Dim NewYPosition As Integer = MaxBottom + VerticalMargin

        Dim TransactionSearch As New InventoryTransactionSearchUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(1, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }
        TransactionSearch.TypeLabel.Text = TransactionType
        TransactionSearch.TransactionIdLabel.Text = TransactionId
        TransactionSearch.StockIdLabel.Text = StockId

        ResultSearchPanel.Controls.Add(TransactionSearch)

    End Sub

    Private Async Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged

        ' Searching based on the product name
        Dim Query As String
        Dim TotalTransactionSearched As Integer = ResultSearchPanel.Controls.OfType(Of InventoryTransactionSearchUserControl).Count
        Dim CountFlag As Integer = 0
        Dim PanelNewHeight As Integer = 0

        If Not String.IsNullOrEmpty(SearchTextBox.Text) Then

            ResultSearchPanel.Controls.Clear()

            Query = "SELECT t.* " &
                    "FROM stock_transaction t " &
                    "WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN " &
                    "(SELECT p.product_id FROM product p WHERE p.product_name LIKE '%' + @ProductName + '%')) ORDER BY transaction_id DESC"

            Await InventoryTransactionDatabaseModule.SearchByTransactionName(Query, "@ProductName", SearchTextBox.Text)

            If Variables.SearchTransactionId.Count > 0 Then

                GeneralModule.CreateStockTransactionSearchUserControl()

                For Each Cntrl As Control In ResultSearchPanel.Controls.OfType(Of InventoryTransactionSearchUserControl)()
                    CountFlag += 1
                    PanelNewHeight = Cntrl.Bottom

                    If CountFlag = 5 Then
                        Exit For
                    End If
                Next

                ResultSearchPanel.Height = PanelNewHeight + 3
                ResultSearchPanel.SetDoubleBuffered(True)
                ResultSearchPanel.Show()

            Else
                HideSearchFlowLayout()
            End If

        Else
            HideSearchFlowLayout()
        End If

        'Label3.Text = TotalTransactionSearched & " transaction Found"

    End Sub

    Private Async Sub SearchTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchTextBox.KeyDown

        'Same lang sa SearchTextBox_TextChanged pero dito lalabas lahat ng result sa PanelForm

        Variables.TransactionNumberOfFilters = 0
        Variables.TransactionFilterBy = String.Empty
        Variables.TransactionByDate = String.Empty
        Variables.TransactionSortBy = String.Empty
        
        SortByComboBox.SelectedIndex = -1
        FilterByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim Query As String
        Dim TotalTransactionsSearched As Integer
        Dim TransactionExist As Boolean = Await InventoryTransactionDatabaseModule.DoesTransactionExist(SearchTextBox.Text)

        If e.KeyCode = Keys.Enter Then

            If TransactionExist

                Dim ProductName As String = Await StockManagementModule.GetProductName(Await ProductManagementDatabaseModule.GetProductIdByBarcode(SearchTextBox.Text))
                Dim ProductId As Integer = Await StockManagementModule.GetProductId(ProductName)
                Dim StockId As Integer = Await StockManagementModule.GetStockIdByProductID(ProductId)
                
                Query = "SELECT t.* " &
                    "FROM stock_transaction t " &
                    "WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN " &
                    "(SELECT p.product_id FROM product p WHERE p.product_name LIKE '%' + @ProductName + '%')) ORDER BY transaction_id DESC"

                Await InventoryTransactionDatabaseModule.SearchByTransactionName(Query, "@ProductName", ProductName)

                Dim TotalSold As Integer = Await InventoryTransactionDatabaseModule.CountValueByProductCode("stock_transaction", "transaction_type", "Sold", StockId)
                SoldLabel.Text = TotalSold
            
                Dim TotalAdded As Integer = Await InventoryTransactionDatabaseModule.CountValueByProductCode("stock_transaction", "transaction_type", "Added", StockId)
                AddedLabel.Text = TotalAdded
            
                Dim TotalRemoved As Integer = Await InventoryTransactionDatabaseModule.CountValueByProductCode("stock_transaction", "transaction_type", "Removed", StockId)
                RemovedLabel.Text = TotalRemoved

                Dim TotalExpired As Integer = Await InventoryTransactionDatabaseModule.CountExpiredItemsThisMonthProductCode(SearchTextBox.Text)
                ExpiredLabel.Text = TotalExpired

                Dim TotalAboutToExpire As Integer = Await InventoryTransactionDatabaseModule.CountAboutToExpireByProductCode(SearchTextBox.Text)
                AboutToExpireLabel.Text = TotalAboutToExpire

                Dim TotalLowStock As Integer = Await InventoryTransactionDatabaseModule.CountLowStock(SearchTextBox.Text)
                LowStockLabel.Text = TotalLowStock

            End If

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

            If String.IsNullOrEmpty(SearchTextBox.Text) Then

                TotalTransactionsSearched = FormPanel.Controls.OfType(Of InventoryTransactionUserControl).Count
                MessageBox.Show("Put the product name in the field", "Provide Product Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                TotalTransactionsSearched = Variables.SearchTransactionId.Count

                If TotalTransactionsSearched = 0 Then

                    MessageBox.Show("No related transactions found.", "Transaction Non-Existent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    GeneralModule.DeleteUserControls(FormPanel)
                    SoldLabel.Text = 0
                    AddedLabel.Text = 0
                    RemovedLabel.Text = 0
                    LowStockLabel.Text = 0
                    AboutToExpireLabel.Text = 0
                    ExpiredLabel.Text = 0

                Else

                    GeneralModule.DeleteUserControls(FormPanel)
                    ResultSearchPanel.Hide()

                    For Each Item In Variables.SearchTransactionId

                        Query = "SELECT * FROM stock_transaction WHERE transaction_id = @TransactionId"
                        Await InventoryTransactionDatabaseModule.RetrieveTransactionBy1Filter(Query, "@TransactionId", Item)
                        Await CreateTransactionUserControl()

                    Next

                End If

            End If

            SearchTextBox.Clear()
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel
            Label3.Text = TotalTransactionsSearched & " Transactions found"

        End If

    End Sub

    Private Async Sub ClearAllFiltersButton_Click(sender As Object, e As EventArgs) Handles ClearAllFiltersButton.Click

        'Ireremove lahat ng filter then show all.

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        HideSearchFlowLayout()

        Variables.TransactionNumberOfFilters = 0
        Variables.TransactionFilterBy = String.Empty
        Variables.TransactionByDate = String.Empty
        Variables.TransactionSortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        FilterByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim InventoryTransactionQuery As String = "SELECT * FROM stock_transaction ORDER BY transaction_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await InventoryTransactionDatabaseModule.RetrieveAll(InventoryTransactionQuery)
        Await CreateTransactionUserControl()

        ' Update the UI
        Dim TotalTransactionSearched As Integer = Variables.ListOfTransactionId.Count
        Label3.Text = TotalTransactionSearched & " Transaction found"

        Dim TotalSold As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Sold", Variables.CurrentMonth)
        SoldLabel.Text = TotalSold

        Dim TotalAdded As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Added", Variables.CurrentMonth)
        AddedLabel.Text = TotalAdded

        Dim TotalRemoved As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Removed", Variables.CurrentMonth)
        RemovedLabel.Text = TotalRemoved

        ' Hide loading screen
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Async Sub FilterByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterByComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If FilterByComboBox.SelectedIndex > -1

            Variables.TransactionFilterBy = FilterByComboBox.SelectedItem.ToString()
            Variables.TransactionNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.TransactionFilterBy, Variables.TransactionByDate, Variables.TransactionSortBy)

            Dim Query As String = ""
            Dim TotalTransactionSearched As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.TransactionNumberOfFilters = 1 Then

                Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}'"

            ElseIf Variables.TransactionNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.TransactionSortBy) AndAlso String.IsNullOrEmpty(Variables.TransactionByDate) Then

                    Select Case Variables.TransactionSortBy

                        Case "A - Z"

                            Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                        Case "Z - A"

                            Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                        Case "New First"

                            Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' ORDER BY transaction_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' ORDER BY transaction_id ASC"

                    End Select

                ElseIf Not String.IsNullOrEmpty(Variables.TransactionByDate) AndAlso String.IsNullOrEmpty(Variables.TransactionSortBy) Then

                    If Variables.TransactionByDate <> "Custom"

                        Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%'"

                    End If

                End If

            Else

                Select Case Variables.TransactionSortBy

                    Case "A - Z"

                        Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                    Case "Z - A"

                        Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                    Case "New First"

                        Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' ORDER BY transaction_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' ORDER BY transaction_id ASC"

                End Select

            End If

            Await CreateSearch(Query, TotalTransactionSearched)

        End If

    End Sub

    Private Async Sub SortByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortByComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If SortByComboBox.SelectedIndex > -1

            Variables.TransactionSortBy = SortByComboBox.SelectedItem.ToString()
            Variables.TransactionNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.TransactionFilterBy, Variables.TransactionByDate, Variables.TransactionSortBy)

            Dim Query As String = ""
            Dim TotalTransactionSearched As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.TransactionNumberOfFilters = 1 Then

                Select Case Variables.TransactionSortBy

                    Case "A - Z"

                        Query = $"SELECT t.* FROM stock_transaction t WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                    Case "Z - A"

                        Query = $"SELECT t.* FROM stock_transaction t WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                    Case "New First"

                        Query = $"SELECT * FROM stock_transaction ORDER BY transaction_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM stock_transaction ORDER BY transaction_id ASC"

                End Select

            ElseIf Variables.TransactionNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.TransactionFilterBy) AndAlso String.IsNullOrEmpty(Variables.TransactionByDate) Then

                    Select Case Variables.TransactionSortBy

                        Case "A - Z"

                            Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                        Case "Z - A"

                            Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                        Case "New First"

                            Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' ORDER BY transaction_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' ORDER BY transaction_id ASC"

                    End Select

                ElseIf Not String.IsNullOrEmpty(Variables.TransactionByDate) AndAlso String.IsNullOrEmpty(Variables.TransactionFilterBy) Then

                    If Variables.TransactionByDate <> "Custom"

                        Select Case Variables.TransactionSortBy

                            Case "A - Z"

                                Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_date LIKE '{Variables.TransactionByDate}%' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                            Case "Z - A"

                                Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_date LIKE '{Variables.TransactionByDate}%' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                            Case "New First"

                                Query = $"SELECT * FROM stock_transaction WHERE transaction_date LIKE '{Variables.TransactionByDate}%' ORDER BY transaction_id DESC"

                            Case "Old First"

                                Query = $"SELECT * FROM stock_transaction WHERE transaction_date LIKE '{Variables.TransactionByDate}%' ORDER BY transaction_id ASC"

                        End Select

                    End If

                End If

            Else

                Select Case Variables.TransactionSortBy

                    Case "A - Z"

                        Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                    Case "Z - A"

                        Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                    Case "New First"

                        Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' ORDER BY transaction_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' ORDER BY transaction_id ASC"

                End Select

            End If

            Await CreateSearch(Query, TotalTransactionSearched)

        End If

    End Sub

    Private Async Sub DateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If DateComboBox.SelectedIndex > -1

            Variables.TransactionByDate = DateComboBox.SelectedItem.ToString()
            Variables.TransactionNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.TransactionFilterBy, Variables.TransactionByDate, Variables.TransactionSortBy)

            Dim Query As String = ""
            Dim TotalTransactionSearched As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.TransactionNumberOfFilters = 1 Then

                Query = $"SELECT * FROM stock_transaction WHERE transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}'"

            ElseIf Variables.TransactionNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.TransactionSortBy) AndAlso String.IsNullOrEmpty(Variables.TransactionFilterBy) Then

                    Select Case Variables.TransactionSortBy

                        Case "A - Z"

                            Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                        Case "Z - A"

                            Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                        Case "New First"

                            Query = $"SELECT * FROM stock_transaction WHERE transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}' ORDER BY transaction_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM stock_transaction WHERE transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}' ORDER BY transaction_id ASC"

                    End Select

                ElseIf Not String.IsNullOrEmpty(Variables.TransactionFilterBy) AndAlso String.IsNullOrEmpty(Variables.TransactionSortBy) Then

                    Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}'"

                End If

            Else

                Select Case Variables.TransactionSortBy

                    Case "A - Z"

                        Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                    Case "Z - A"

                        Query = $"SELECT t.* FROM stock_transaction t WHERE t.transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                    Case "New First"

                        Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}' ORDER BY transaction_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM stock_transaction WHERE transaction_type = '{Variables.TransactionFilterBy}' AND transaction_date LIKE '{Variables.TransactionByDate}%' + '{Variables.CurrentYear}' ORDER BY transaction_id ASC"

                End Select

            End If

            Await CreateSearch(Query, TotalTransactionSearched)

        End If

        If Not String.IsNullOrEmpty(Variables.TransactionByDate)

            Dim MonthNumber As Integer = GeneralModule.GetMonthNumberFromMonthName(Variables.TransactionByDate)
            
            Dim TotalSold As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Sold", MonthNumber)
            SoldLabel.Text = TotalSold
            
            Dim TotalAdded As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Added", MonthNumber)
            AddedLabel.Text = TotalAdded
            
            Dim TotalRemoved As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Removed", MonthNumber)
            RemovedLabel.Text = TotalRemoved
        
        Else
            
            Dim TotalSold As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Sold", Variables.CurrentMonth)
            SoldLabel.Text = TotalSold

            Dim TotalAdded As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Added", Variables.CurrentMonth)
            AddedLabel.Text = TotalAdded

            Dim TotalRemoved As Integer = Await InventoryTransactionDatabaseModule.CountValue("stock_transaction", "transaction_type", "Removed", Variables.CurrentMonth)
            RemovedLabel.Text = TotalRemoved
        
        End If

    End Sub

    Async Function CreateSearch(Query As String, Total As Integer) As Task

        Await InventoryTransactionDatabaseModule.RetrieveAll(Query)
        Total = Variables.ListOfTransactionId.Count
        Await CreateTransactionUserControl
        Label3.Text = Total & " Transactions found"
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Function

    Private Sub ResultSearchPanel_MouseEnter(sender As Object, e As EventArgs) Handles ResultSearchPanel.MouseEnter

        If ResultSearchPanel.Visible

            ActiveControl = ResultSearchPanel

        End If

    End Sub

    Private Sub ResultSearchPanel_MouseLeave(sender As Object, e As EventArgs) Handles ResultSearchPanel.MouseLeave

        If ResultSearchPanel.Visible

            SearchTextBox.Focus

        End If

    End Sub

    Private Sub PanelSearch_Click(sender As Object, e As EventArgs) Handles PanelSearch.Click, FormPanel.Click, MyBase.Click

        HideSearchFlowLayout

    End Sub
End Class