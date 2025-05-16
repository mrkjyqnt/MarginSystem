Public Class InventoryValuation
    Private Async Sub BackLabel_Click(sender As Object, e As EventArgs) Handles BackLabel.Click

        Cursor = Cursors.WaitCursor
        MainForm.Opacity = 0

        HideSearchFlowLayout()

        Variables.ValuationNumberOfFilters = 0
        Variables.ValuationFilterBy = String.Empty
        Variables.ValuationByDate = String.Empty
        Variables.ValuationSortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim InventoryValuationQuery As String = "SELECT * FROM inventory_valuation ORDER BY inventory_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await InventoryValuationModule.RetrieveAll(InventoryValuationQuery)
        Await CreateValuationUserControl()


        Dim TotalValuation As Integer = Variables.ListofInventoryValuationId.Count
        Label13.Text = TotalValuation & " Valuations found"

        MainForm.ValuationReportsFormPanel.Controls.Clear
        GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", ValuationAndReports, MainForm.ValuationReportsFormPanel)
        ValuationAndReports.ActiveControl = ValuationAndReports.FormPanel
        GeneralModule.FadeInForm(MainForm)
        Cursor = Cursors.Default

    End Sub

    Private Sub BackLabel_MouseEnter(sender As Object, e As EventArgs) Handles BackLabel.MouseEnter

        BackLabel.Font = New Font("Inter Black", 20)
        Label2.Location = New point(394, 0)

    End Sub

    Private Sub BackLabel_MouseLeave(sender As Object, e As EventArgs) Handles BackLabel.MouseLeave

        BackLabel.Font = New Font("Inter Semibold", 20)
        Label2.Location = New point(377, 0)

    End Sub

    Private Sub InventoryValuation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If FormPanel.Controls.OfType(Of InventoryValuationUserControl).Any

            Label10.Hide
            Label13.show
            Label13.Text = FormPanel.Controls.OfType(Of InventoryValuationUserControl).Count & " Inventory Valuation found"

        Else

            Label10.Show
            Label13.Hide

        End If

    End Sub

    'Private Sub ViewMoreButton_Click(sender As Object, e As EventArgs) Handles ViewMoreButton.Click

    'MainForm.ValuationReportsFormPanel.Controls.Clear
    'GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", ViewMoreForm, MainForm.ValuationReportsFormPanel)

    'ViewMoreForm.BackLabel2.Text = ">  Inventory Valuation"
    'ViewMoreForm.Label1.Location = New Point(748, 0)
    'ViewMoreForm.SearchByLabel.text = "Search Inventory"
    'ViewMoreForm.FoundLabel.text = "10 Inventory transacntion found"

    'End Sub

    Private Async Sub NewProductButton_Click(sender As Object, e As EventArgs) Handles NewProductButton.Click

        GenerateReport.Opacity = 0
        'HideSearchFlowLayout
        GenerateReport.TableName = "inventory_valuation"
        GeneralModule.ShowOverlay(MainForm, GenerateReport)

        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "inventory valuation", DateAdded, TimeAdded, $"Generate Report for Inventory Valuations")

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()

        FormPanel.Focus
        ActiveControl = FormPanel


    End Sub

    Public Sub CreateUserControl(InventoryId As Integer, StockId As Integer, ProductName As String, ProductImage As Byte(),
                             Quantity As Integer, DateSold As String, RetailValuation As Double, Added As Boolean)

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

        Dim NewValuation As New InventoryValuationUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(3, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }

        'Assigning ng values ng products sa user control/
        NewValuation.ValuationNameLabel.Text = ProductName

        If ProductImage IsNot Nothing Then
            Using ms As New IO.MemoryStream(ProductImage)
                NewValuation.PlaceholderImage.Image = Image.FromStream(ms)
            End Using
        End If

        NewValuation.NoDateLabel.Text = Quantity.ToString & " | " & DateSold.ToString
        NewValuation.InventoryIdLabel.Text = InventoryId.ToString
        NewValuation.StockIdLabel.Text = StockId.ToString

        If Added
            NewValuation.InventoryValuationLabel.Text = "+ " & RetailValuation.ToString
        Else
            NewValuation.InventoryValuationLabel.Text = "- " & RetailValuation.ToString
        End If

        FormPanel.Controls.Add(NewValuation)

    End Sub

    Async Function CreateValuationUserControl() As Task

        ' Mag produce ng user controls.
        For i As Integer = 0 To Variables.ListofInventoryValuationId.Count - 1

            Dim stockId = Variables.ListofInventoryValuationStockId(i)
            Dim productId = Await StockManagementModule.GetProductIdByStockId(stockId)
            Dim productName = Await StockManagementModule.GetProductName(productId)
            Dim productImage = Await StockManagementModule.GetProductImage(productId)
            Dim totalStock = Await StockManagementModule.GetTotalStock(stockId)
            Dim remainingStock = Await StockManagementModule.GetCurrentStock(stockId)
            Dim dateAdded = Variables.ListofInventoryValuationDateAdded(i)
            Dim addedStock = Variables.ListofInventoryValuationAdded(i)
            Dim retailPrice = Variables.ListofInventoryValuationRetail(i)
            Dim expiration = Variables.ListofInventoryValuationExpiration(i)

            If expiration > 0 Then
                CreateUserControl(Variables.ListofInventoryValuationId(i), stockId, productName, productImage, remainingStock, dateAdded, expiration, addedStock)
            Else
                CreateUserControl(Variables.ListofInventoryValuationId(i), stockId, productName, productImage, totalStock, dateAdded, retailPrice, addedStock)
            End If

        Next

    End Function


    Private Sub HideSearchFlowLayout

        If ResultSearchPanel.Visible

            ResultSearchPanel.Hide

        End If

    End Sub

    Async Function CreateValuation(Query As String, Total As Integer) As Task

        Await InventoryValuationModule.RetrieveAll(Query)
        Total = Variables.ListofInventoryValuationId.Count
        Await CreateValuationUserControl
        Label13.Text = Total & " Valuations found"
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Function

    Private Async Sub DateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If DateComboBox.SelectedIndex > -1

            Variables.ValuationByDate = DateComboBox.SelectedItem.ToString()
            Variables.ValuationNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.ValuationFilterBy, Variables.ValuationByDate, Variables.ValuationSortBy)

            Dim Query As String = ""
            Dim TotalValuation As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.ValuationNumberOfFilters = 1 Then

                Query = $"SELECT * FROM inventory_valuation WHERE date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}'"

            ElseIf Variables.ValuationNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.ValuationSortBy) AndAlso String.IsNullOrEmpty(Variables.ValuationFilterBy) Then

                    Select Case Variables.ValuationSortBy

                        Case "A - Z"

                            Query = $"SELECT t.* FROM inventory_valuation t WHERE t.date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                        Case "Z - A"

                            Query = $"SELECT t.* FROM inventory_valuation t WHERE t.date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                        Case "New First"

                            Query = $"SELECT * FROM inventory_valuation WHERE date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}' ORDER BY inventory_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM inventory_valuation WHERE date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}' ORDER BY inventory_id ASC"

                    End Select

                End If

            End If

            Await CreateValuation(Query, TotalValuation)

        End If

        If Not String.IsNullOrEmpty(Variables.ValuationByDate)

            Dim MonthNumber As Integer = GeneralModule.GetMonthNumberFromMonthName(Variables.ValuationByDate)

            Dim TotalInventoryValueThisMonth As Double = Await SaleValuationModule.CountSum("retail_valuation", "inventory_valuation", MonthNumber, "date_added")
            TotalValueLabel.Text = $"₱ {TotalInventoryValueThisMonth}"

            Dim TotalLoss As Double = Await InventoryValuationModule.TotalLossThisMonth(MonthNumber)
            TotalLossLabel.Text = $"₱ {TotalLoss}"

            Dim TotalQuantityExpired As Integer = Await InventoryValuationModule.SumExpiredItemsThisMonth(MonthNumber)
            TotalQuantityExpiredLabel.Text = TotalQuantityExpired

        Else

            Dim InventoryValuationThisMonth As Double = Await SaleValuationModule.CountSum("retail_valuation", "inventory_valuation", Variables.CurrentMonth, "date_added")
            TotalValueLabel.Text = $"₱ {InventoryValuationThisMonth}"

            Dim SumTotalLoss As Double = Await InventoryValuationModule.TotalLoss
            TotalLossLabel.Text = $"₱ {SumTotalLoss}"

            Dim SumTotalQuantityExpired As Integer = Await InventoryValuationModule.CountQuantityExpiredItems
            TotalQuantityExpiredLabel.Text = SumTotalQuantityExpired

        End If

    End Sub

    Private Async Sub SortByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortByComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If SortByComboBox.SelectedIndex > -1

            Variables.ValuationSortBy = SortByComboBox.SelectedItem.ToString()
            Variables.ValuationNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.ValuationFilterBy, Variables.ValuationByDate, Variables.ValuationSortBy)

            Dim Query As String = ""
            Dim TotalValuation As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.ValuationNumberOfFilters = 1 Then

                Select Case Variables.ValuationSortBy

                    Case "A - Z"

                        Query = "SELECT t.* FROM inventory_valuation t WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                    Case "Z - A"

                        Query = "SELECT t.* FROM inventory_valuation t WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                    Case "New First"

                        Query = "SELECT * FROM inventory_valuation ORDER BY inventory_id DESC"

                    Case "Old First"

                        Query = "SELECT * FROM inventory_valuation ORDER BY inventory_id ASC"

                End Select

            ElseIf Variables.ValuationNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.ValuationByDate) AndAlso String.IsNullOrEmpty(Variables.ValuationFilterBy) Then

                    Select Case Variables.ValuationSortBy

                        Case "A - Z"

                            Query = $"SELECT t.* FROM inventory_valuation t WHERE t.date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                        Case "Z - A"

                            Query = $"SELECT t.* FROM inventory_valuation t WHERE t.date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                        Case "New First"

                            Query = $"SELECT * FROM inventory_valuation WHERE date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}' ORDER BY inventory_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM inventory_valuation WHERE date_added LIKE '{Variables.ValuationByDate}%' + '{Variables.CurrentYear}' ORDER BY inventory_id ASC"

                    End Select

                End If

            End If

            Await CreateValuation(Query, TotalValuation)

        End If

    End Sub

    Private Async Sub ClearAllFiltersButton_Click(sender As Object, e As EventArgs) Handles ClearAllFiltersButton.Click

        'Ireremove lahat ng filter then show all.

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        HideSearchFlowLayout()

        Variables.ValuationNumberOfFilters = 0
        Variables.ValuationFilterBy = String.Empty
        Variables.ValuationByDate = String.Empty
        Variables.ValuationSortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim InventoryValuationQuery As String = "SELECT * FROM inventory_valuation ORDER BY inventory_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await InventoryValuationModule.RetrieveAll(InventoryValuationQuery)
        Await CreateValuationUserControl()

        Dim InventoryValuationThisMonth As Double = Await SaleValuationModule.CountSum("retail_valuation", "inventory_valuation", Variables.CurrentMonth, "date_added")
        TotalValueLabel.Text = $"₱ {InventoryValuationThisMonth}"

        Dim SumTotalLoss As Double = Await InventoryValuationModule.TotalLoss
        TotalLossLabel.Text = $"₱ {SumTotalLoss}"

        Dim SumTotalQuantityExpired As Integer = Await InventoryValuationModule.CountQuantityExpiredItems
        TotalQuantityExpiredLabel.Text = SumTotalQuantityExpired

        Dim TotalValuation As Integer = Variables.ListofInventoryValuationId.Count
        Label13.Text = TotalValuation & " Valuations found"

        ' Hide loading screen
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Public Sub CreateSearchUserControl(ValuationId As Integer, StockId As Integer, RetailValuation As Double, Expired As Boolean)

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

        Dim ValuationSearch As New InventoryValuationSearchControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(1, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }
        ValuationSearch.ValuationIdLabel.Text = ValuationId
        ValuationSearch.StockIdLabel.Text = StockId

        If Expired
            ValuationSearch.RetailValuationLabel.Text = $"- ₱ {RetailValuation}"
            Valuationsearch.RetailValuationLabel.ForeColor = Color.FromArgb(255, 59, 48)
        Else
            ValuationSearch.RetailValuationLabel.Text = $"+ ₱ {RetailValuation}"
        End If

        ResultSearchPanel.Controls.Add(ValuationSearch)

    End Sub

    Private Async Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged

        'Searching naman sa pangalan ng Product

        Dim Query As String
        Dim TotalValuationSearched As Integer = FormPanel.Controls.OfType(Of InventoryValuationSearchControl).Count
        Dim CountFlag As Integer
        Dim PanelNewHeight As Integer

        If Not String.IsNullOrEmpty(SearchTextBox.Text)

            ResultSearchPanel.Controls.Clear

            Query = " SELECT s.* FROM inventory_valuation s WHERE s.stock_id IN (SELECT t.stock_id FROM stock t WHERE t.product_id IN (SELECT p.product_id FROM product p WHERE p.product_name LIKE '%' + @ProductName + '%')) ORDER BY inventory_id DESC"

            Await InventoryValuationModule.SearchByProductName(Query, "@ProductName", SearchTextBox.Text)

            If Variables.SearchByValuationId.Count > 0

                GeneralModule.CreateValuationSearchUserControl

                'Mag lo-loop sa mga search control then kukuhain yung bottom ng 5th control
                For Each Cntrl As Control In ResultSearchPanel.Controls.OfType(Of InventoryValuationSearchControl)

                    CountFlag += 1
                    PanelNewHeight = Cntrl.Bottom

                    If CountFlag = 5

                        Exit For

                    End If

                Next

                'I se-set sa panel ang bottom as height
                ResultSearchPanel.Height = PanelNewHeight + 3
                ResultSearchPanel.SetDoubleBuffered(True)
                ResultSearchPanel.Show

            Else

                HideSearchFlowLayout

            End If

        Else

            HideSearchFlowLayout

        End If

        'Label3.Text = TotalSaleSearched & " Sales Found"

    End Sub

    Private Async Sub SearchTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchTextBox.KeyDown

        Variables.ValuationNumberOfFilters = 0
        Variables.ValuationFilterBy = String.Empty
        Variables.ValuationByDate = String.Empty
        Variables.ValuationSortBy = String.Empty

        DateComboBox.SelectedIndex = -1
        SortByComboBox.SelectedIndex = -1

        'Same lang sa SearchTextBox_TextChanged pero dito lalabas lahat ng result sa PanelForm

        Dim Query As String
        Dim TotalValuationSearched As Integer
        Dim ValuationExist As Boolean = Await InventoryValuationModule.DoesValuationExist(SearchTextBox.Text)

        If e.KeyCode = Keys.Enter Then

            If ValuationExist

                Dim ProductName As String = Await StockManagementModule.GetProductName(Await ProductManagementDatabaseModule.GetProductIdByBarcode(SearchTextBox.Text))
                Dim ProductId As Integer = Await ProductManagementDatabaseModule.GetProductIdByBarcode(SearchTextBox.Text)
                Query = "SELECT t.* " &
                    "FROM inventory_valuation t " &
                    "WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN " &
                    "(SELECT p.product_id FROM product p WHERE p.product_name LIKE '%' + @ProductName + '%')) ORDER BY inventory_id DESC"

                Await InventoryValuationModule.SearchByProductName(Query, "@ProductName", ProductName)

                Dim TotalValue As Integer = Await SaleValuationModule.CountSumByProduct("l.retail_valuation", "inventory_valuation l", Variables.CurrentMonth, "l.date_added", "l.stock_id", ProductId)
                TotalValueLabel.Text = $"₱ {TotalValue}"

                Dim TotalLoss As Integer = Await SaleValuationModule.CountSumByProduct("l.expiration_valuation", "inventory_valuation l", Variables.CurrentMonth, "l.date_added", "l.stock_id", ProductId)
                TotalLossLabel.Text = $"₱ {TotalLoss}"

                Dim SumTotalQuantityExpired As Integer = Await InventoryValuationModule.CountQuantityExpiredItemsByProductId(ProductId)
                TotalQuantityExpiredLabel.Text = SumTotalQuantityExpired

            End If

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

            If String.IsNullOrEmpty(SearchTextBox.Text) Then

                TotalValuationSearched = FormPanel.Controls.OfType(Of InventoryValuationUserControl).Count
                MessageBox.Show("Put the product name in the field", "Provide Product Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                TotalValuationSearched = Variables.SearchByValuationId.Count

                If TotalValuationSearched = 0 Then

                    MessageBox.Show("No related valuation found.", "Valuation Non-Existent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    GeneralModule.DeleteUserControls(FormPanel)
                    TotalValueLabel.Text = 0
                    TotalLossLabel.Text = 0
                    TotalQuantityExpiredLabel.Text = 0

                Else

                    GeneralModule.DeleteUserControls(FormPanel)
                    ResultSearchPanel.Hide()

                    For Each Item In Variables.SearchByValuationId

                        Query = "SELECT * FROM inventory_valuation WHERE inventory_id = @ValuationId"
                        Await InventoryValuationModule.RetrieveValuationBy1Filter(Query, "@ValuationId", Item)
                        Await CreateValuationUserControl()

                    Next

                End If

            End If

            SearchTextBox.Clear()
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel
            Label13.Text = TotalValuationSearched & " Valuations found"

        End If

    End Sub

    Private Sub ResultSearchPanel_MouseLeave(sender As Object, e As EventArgs) Handles ResultSearchPanel.MouseLeave

        If ResultSearchPanel.Visible

            SearchTextBox.Focus

        End If

    End Sub

    Private Sub ResultSearchPanel_MouseEnter(sender As Object, e As EventArgs) Handles ResultSearchPanel.MouseEnter

        If ResultSearchPanel.Visible

            ActiveControl = ResultSearchPanel

        End If

    End Sub

    Private Sub PanelSearch_Click(sender As Object, e As EventArgs) Handles PanelSearch.Click

        HideSearchFlowLayout

    End Sub
End Class