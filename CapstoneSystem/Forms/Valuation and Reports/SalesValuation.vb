Imports System.Transactions
Imports Microsoft.Identity.Client

Public Class SalesValuation
    Private Async Sub BackLabel_Click(sender As Object, e As EventArgs) Handles BackLabel.Click

        Cursor = Cursors.WaitCursor
        MainForm.Opacity = 0
        
        HideSearchFlowLayout()

        Variables.SaleNumberOfFilters = 0
        Variables.SaleFilterBy = String.Empty
        Variables.SaleByDate = String.Empty
        Variables.SaleSortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim SalesQuery As String = "SELECT * FROM sale ORDER BY sale_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await SaleValuationModule.RetrieveAll(SalesQuery)
        Await CreateSaleUserControl()

        Dim TotalSale As Integer = Variables.ListOfSaleId.Count
        Label3.Text = TotalSale & " Sales found"

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

    'Private Sub ViewMoreButton_Click(sender As Object, e As EventArgs) Handles ViewMoreButton.Click

    'MainForm.ValuationReportsFormPanel.Controls.Clear
    'GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", ViewMoreForm, MainForm.ValuationReportsFormPanel)

    'ViewMoreForm.BackLabel2.Text = ">  Sales Valuation"
    'ViewMoreForm.Label1.Location = New Point(683, 0)
    'ViewMoreForm.SearchByLabel.text = "Search Sales"
    'ViewMoreForm.FoundLabel.text = "10 sales transaction found"

    'End Sub

    Private Async Sub GenerateReportButton_Click(sender As Object, e As EventArgs) Handles GenerateReportButton.Click

        GenerateReport.Opacity = 0
        'HideSearchFlowLayout
        GenerateReport.TableName = "sale"
        GeneralModule.ShowOverlay(MainForm, GenerateReport)

        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "sales", DateAdded, TimeAdded, $"Generate Report for Sales Valuation")

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()

        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Sub SalesValuation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If FormPanel.Controls.OfType(Of SalesValuationUserControl).Any

            Label1.Hide
            Label3.show
            Label3.Text = FormPanel.Controls.OfType(Of SalesValuationUserControl).Count & " Sales found"

        Else

            Label1.Show
            Label3.Hide

        End If

    End Sub

    Public Sub CreateUserControl(SaleId As Integer, StockId As Integer, ProductName As String, ProductImage As Byte(),
                             DateSold As String, Quantity As Integer, SaleAmount As String)

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

        Dim NewSale As New SalesValuationUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(3, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }

        'Assigning ng values ng products sa user control/
        NewSale.SaleNameLabel.Text = ProductName

        If ProductImage IsNot Nothing Then
            Using ms As New IO.MemoryStream(ProductImage)
                NewSale.PlaceholderImage.Image = Image.FromStream(ms)
            End Using
        End If

        NewSale.NoDateLabel.Text = Quantity.ToString & " | " & DateSold.ToString
        NewSale.SaleIdLabel.Text = SaleId.ToString
        NewSale.StockIdLabel.Text = StockId.ToString
        NewSale.TotalSaleLabel.Text = "₱ " & SaleAmount.ToString

        FormPanel.Controls.Add(NewSale)

    End Sub

    Async Function CreateSaleUserControl() As Task

        'Mag produce ng user controls.

        For i As Integer = 0 To ListOfSaleId.Count - 1

            CreateUserControl(Variables.ListOfSaleId(i), Variables.ListOfSaleStockId(i), Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(Variables.ListOfSaleStockId(i))),
                                Await StockManagementModule.GetProductImage(Await StockManagementModule.GetProductIdByStockId(Variables.ListOfSaleStockId(i))),
                                Variables.ListOfSaleDate(i), Variables.ListOfQuantitySold(i), Variables.ListOfNetSale(i))

        Next

    End Function

    Private Sub HideSearchFlowLayout

        If ResultSearchPanel.Visible

            ResultSearchPanel.Hide

        End If

    End Sub

    Private Async Sub ClearAllFiltersButton_Click(sender As Object, e As EventArgs) Handles ClearAllFiltersButton.Click

        'Ireremove lahat ng filter then show all.

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        HideSearchFlowLayout()

        Variables.SaleNumberOfFilters = 0
        Variables.SaleFilterBy = String.Empty
        Variables.SaleByDate = String.Empty
        Variables.SaleSortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim SalesQuery As String = "SELECT * FROM sale ORDER BY sale_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await SaleValuationModule.RetrieveAll(SalesQuery)
        Await CreateSaleUserControl()

        Dim TotalSale As Integer = Variables.ListOfSaleId.Count
        Label3.Text = TotalSale & " Sales found"

        ' Hide loading screen
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Async Sub DateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If DateComboBox.SelectedIndex > -1

            Variables.SaleByDate = DateComboBox.SelectedItem.ToString()
            Variables.SaleNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.SaleFilterBy, Variables.SaleByDate, Variables.SaleSortBy)

            Dim Query As String = ""
            Dim TotalSale As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.SaleNumberOfFilters = 1 Then

                Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}'"

            ElseIf Variables.SaleNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.SaleSortBy) AndAlso String.IsNullOrEmpty(Variables.SaleFilterBy) Then

                    Select Case Variables.SaleSortBy

                        Case "A - Z"

                            Query = $"SELECT t.* FROM sale t WHERE t.transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                        Case "Z - A"

                            Query = $"SELECT t.* FROM sale t WHERE t.transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                        Case "New First"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY sale_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY sale_id ASC"

                        Case "Least Sold"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY quantity_sold ASC"

                        Case "Most Sold"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY quantity_sold DESC"

                        Case "High Item Price"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY item_price DESC"

                        Case "Low Item Price"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY item_price ASC"

                        Case "Higest Sale"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY gross_sale DESC"

                        Case "Lowest Sale"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY gross_sale ASC"

                        Case "Highest Profite"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY net_sale DESC"

                        Case "Lowest Profit"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY net_sale ASC"

                    End Select

                End If

            End If

            Await CreateSearch(Query, TotalSale)

        End If

        If Not String.IsNullOrEmpty(Variables.SaleByDate)

            Dim MonthNumber As Integer = GeneralModule.GetMonthNumberFromMonthName(Variables.SaleByDate)
            
            Dim TotalQuantitySold As Integer = Await SaleValuationModule.CountSum("quantity_sold", "sale", MonthNumber, "transaction_date")
            TotalQuantitySoldLabel.Text = TotalQuantitySold

            Dim TotalProfit As Double = Await SaleValuationModule.CountSum("net_sale", "sale", MonthNumber, "transaction_date")
            TotalProfitLabel.Text = $"₱ {TotalProfit}"

            Dim TotalSales As Double = Await SaleValuationModule.CountSum("gross_sale", "sale", MonthNumber, "transaction_date")
            TotalSalesLabel.Text = $"₱ {TotalSales}"
        
        Else
            
            Dim TotalQuantitySold As Integer = Await SaleValuationModule.CountSum("quantity_sold", "sale", Variables.CurrentMonth, "transaction_date")
            TotalQuantitySoldLabel.Text = TotalQuantitySold

            Dim TotalProfit As Double = Await SaleValuationModule.CountSum("net_sale", "sale", Variables.CurrentMonth, "transaction_date")
            TotalProfitLabel.Text = $"₱ {TotalProfit}"

            Dim TotalSales As Double = Await SaleValuationModule.CountSum("gross_sale", "sale", Variables.CurrentMonth, "transaction_date")
            TotalSalesLabel.Text = $"₱ {TotalSales}"
        
        End If

    End Sub

    Async Function CreateSearch(Query As String, Total As Integer) As Task

        Await SaleValuationModule.RetrieveAll(Query)
        Total = Variables.ListOfSaleId.Count
        Await CreateSaleUserControl
        Label3.Text = Total & " Sales found"
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Function

    Private Async Sub SortByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortByComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If SortByComboBox.SelectedIndex > -1

            Variables.SaleSortBy = SortByComboBox.SelectedItem.ToString()
            Variables.SaleNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.SaleFilterBy, Variables.SaleByDate, Variables.SaleSortBy)

            Dim Query As String = ""
            Dim TotalSale As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.SaleNumberOfFilters = 1 Then

                Select Case Variables.SaleSortBy

                    Case "A - Z"

                        Query = "SELECT t.* FROM sale t WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                    Case "Z - A"

                        Query = "SELECT t.* FROM sale t WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                    Case "New First"

                        Query = "SELECT * FROM sale ORDER BY sale_id DESC"

                    Case "Old First"

                        Query = "SELECT * FROM sale ORDER BY sale_id ASC"

                    Case "Least Sold"

                        Query = "SELECT * FROM sale ORDER BY quantity_sold ASC"

                    Case "Most Sold"

                        Query = "SELECT * FROM sale ORDER BY quantity_sold DESC"

                    Case "High Item Price"

                        Query = "SELECT * FROM sale ORDER BY item_price DESC"

                    Case "Low Item Price"

                        Query = "SELECT * FROM sale ORDER BY item_price ASC"

                    Case "Higest Sale"

                        Query = "SELECT * FROM sale ORDER BY gross_sale DESC"

                    Case "Lowest Sale"

                        Query = "SELECT * FROM sale ORDER BY gross_sale ASC"

                    Case "Highest Profit"

                        Query = "SELECT * FROM sale ORDER BY net_sale DESC"

                    Case "Lowest Profit"

                        Query = "SELECT * FROM sale ORDER BY net_sale ASC"

                End Select

            ElseIf Variables.SaleNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.SaleByDate) AndAlso String.IsNullOrEmpty(Variables.SaleFilterBy) Then

                    Select Case Variables.SaleSortBy

                        Case "A - Z"

                            Query = $"SELECT t.* FROM sale t WHERE t.transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) ASC"

                        Case "Z - A"

                            Query = $"SELECT t.* FROM sale t WHERE t.transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' AND t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN (SELECT p.product_id FROM product p)) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = (SELECT s.product_id FROM stock s WHERE s.stock_id = t.stock_id)) DESC"

                        Case "New First"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY sale_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY sale_id ASC"

                        Case "Least Sold"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY quantity_sold ASC"

                        Case "Most Sold"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY quantity_sold DESC"

                        Case "High Item Price"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY item_price DESC"

                        Case "Low Item Price"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY item_price ASC"

                        Case "Higest Sale"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY gross_sale DESC"

                        Case "Lowest Sale"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY gross_sale ASC"

                        Case "Highest Profit"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY net_sale DESC"

                        Case "Lowest Profit"

                            Query = $"SELECT * FROM sale WHERE transaction_date LIKE '{Variables.SaleByDate}%' + '{Variables.CurrentYear}' ORDER BY net_sale ASC"

                    End Select

                End If

            End If

            Await CreateSearch(Query, TotalSale)

        End If

    End Sub

    Public Sub CreateSearchUserControl(SaleId As Integer, StockId As Integer, Quantity As Integer, GrossSale As Double)

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

        Dim SaleSearch As New SaleSearchUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(1, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }
        SaleSearch.QuantityLabel.Text = Quantity
        SaleSearch.GrossSaleLabel.Text = $"+ ₱ {GrossSale.ToString}"

        SaleSearch.SaleIdLabel.Text = SaleId
        SaleSearch.StockIdLabel.Text = StockId

        ResultSearchPanel.Controls.Add(SaleSearch)

    End Sub

    Private Async Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged

        'Searching naman sa pangalan ng Product

        Dim Query As String
        Dim TotalSaleSearched As Integer = FormPanel.Controls.OfType(Of SaleSearchUserControl).Count
        Dim CountFlag As Integer
        Dim PanelNewHeight As Integer

        If Not String.IsNullOrEmpty(SearchTextBox.Text)

            ResultSearchPanel.Controls.Clear

            Query = " SELECT s.* FROM sale s WHERE s.stock_id IN (SELECT t.stock_id FROM stock t WHERE t.product_id IN (SELECT p.product_id FROM product p WHERE p.product_name LIKE '%' + @ProductName + '%'))"

            Await SaleValuationModule.SearchByProductName(Query, "@ProductName", SearchTextBox.Text)

            If Variables.SearchBySaleId.Count > 0

                GeneralModule.CreateSaleSearchUserControl

                'Mag lo-loop sa mga search control then kukuhain yung bottom ng 5th control
                For Each Cntrl As Control In ResultSearchPanel.Controls.OfType(Of SaleSearchUserControl)

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

        Variables.SaleNumberOfFilters = 0
        Variables.SaleFilterBy = String.Empty
        Variables.SaleByDate = String.Empty
        Variables.SaleSortBy = String.Empty
        
        DateComboBox.SelectedIndex = -1
        SortByComboBox.SelectedIndex = -1

        'Same lang sa SearchTextBox_TextChanged pero dito lalabas lahat ng result sa PanelForm

        Dim Query As String
        Dim TotalSaleSearched As Integer
        Dim SaleExist As Boolean = Await SaleValuationModule.DoesSaleExist(SearchTextBox.Text)

        If e.KeyCode = Keys.Enter Then

            If SaleExist

                Dim ProductName As String = Await StockManagementModule.GetProductName(Await ProductManagementDatabaseModule.GetProductIdByBarcode(SearchTextBox.Text))
                Dim ProductId As Integer = Await ProductManagementDatabaseModule.GetProductIdByBarcode(SearchTextBox.Text)
                Query = "SELECT t.* " &
                    "FROM sale t " &
                    "WHERE t.stock_id IN (SELECT s.stock_id FROM stock s WHERE s.product_id IN " &
                    "(SELECT p.product_id FROM product p WHERE p.product_name LIKE '%' + @ProductName + '%')) ORDER BY sale_id DESC"

                Await SaleValuationModule.SearchByProductName(Query, "@ProductName", ProductName)

                Dim TotalSales As Integer = Await SaleValuationModule.CountSumByProduct("l.gross_sale", "sale l", Variables.CurrentMonth, "l.transaction_date", "l.stock_id", ProductId)
                TotalSalesLabel.Text = $"₱ {TotalSales}"

                Dim TotalProfit As Integer = Await SaleValuationModule.CountSumByProduct("l.net_sale", "sale l", Variables.CurrentMonth, "l.transaction_date", "l.stock_id", ProductId)
                TotalProfitLabel.Text = $"₱ {TotalProfit}"

                Dim TotalQuantitySold As Integer = Await SaleValuationModule.CountSumByProduct("l.quantity_sold", "sale l", Variables.CurrentMonth, "l.transaction_date", "l.stock_id", ProductId)
                TotalQuantitySoldLabel.Text = TotalQuantitySold

            End If

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

            If String.IsNullOrEmpty(SearchTextBox.Text) Then

                TotalSaleSearched = FormPanel.Controls.OfType(Of SalesValuationUserControl).Count
                MessageBox.Show("Put the product name in the field", "Provide Product Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                TotalSaleSearched = Variables.SearchBySaleId.Count

                If TotalSaleSearched = 0 Then

                    MessageBox.Show("No related sale found.", "Sale Non-Existent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    GeneralModule.DeleteUserControls(FormPanel)
                    TotalSalesLabel.Text = 0
                    TotalProfitLabel.Text = 0
                    TotalQuantitySoldLabel.Text = 0

                Else

                    GeneralModule.DeleteUserControls(FormPanel)
                    ResultSearchPanel.Hide()

                    For Each Item In Variables.SearchBySaleId

                        Query = "SELECT * FROM sale WHERE sale_id = @SaleId"
                        Await SaleValuationModule.RetrieveSaleBy1Filter(Query, "@SaleId", Item)
                        Await CreateSaleUserControl()

                    Next

                End If

            End If

            SearchTextBox.Clear()
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel
            Label3.Text = TotalSaleSearched & " Sales found"

        End If

    End Sub

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
End Class