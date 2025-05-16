Public Class StockManagement
    Private Sub StockManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FormPanel.HorizontalScroll.Enabled = False

        If FormPanel.Controls.OfType(Of StockUserControl).Any

            Label4.Hide
            Label3.show
            Label3.Text = FormPanel.Controls.OfType(Of StockUserControl).Count & " Batches found"

        Else

            Label4.Show
            Label3.Hide

        End If

    End Sub

    Private Sub GenerateReportButton_MouseEnter(sender As Object, e As EventArgs) Handles GenerateReportButton.MouseEnter, Label5.MouseEnter, GenerateReportImage1.MouseEnter, GenerateReportImage2.MouseEnter

        GeneralModule.PanelToButton(GenerateReportButton, GenerateReportImage1, GenerateReportImage2, 210, "HoveredStars", "HoveredGenerate")

    End Sub

    Private Sub GenerateReportButton_MouseLeave(sender As Object, e As EventArgs) Handles GenerateReportButton.MouseLeave

        GeneralModule.PanelToButton(GenerateReportButton, GenerateReportImage1, GenerateReportImage2, 247, "Stars", "Generate")

    End Sub

    Private Sub Label5_MouseDown(sender As Object, e As MouseEventArgs) Handles GenerateReportButton.MouseDown, Label5.MouseDown, GenerateReportImage1.MouseDown, GenerateReportImage2.MouseDown

        GeneralModule.PanelToButton(GenerateReportButton, GenerateReportImage1, GenerateReportImage2, 147, "HoveredStars", "HoveredGenerate")

    End Sub

    Private Async Sub GenerateReportButton_Click(sender As Object, e As EventArgs) Handles GenerateReportButton.Click, Label5.Click, GenerateReportImage1.Click, GenerateReportImage2.Click

        GenerateReport.Opacity = 0
        HideSearchFlowLayout
        GenerateReport.TableName = "stock"
        GeneralModule.ShowOverlay(MainForm, GenerateReport)

        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "stock", DateAdded, TimeAdded, $"Generate Report for Stock Management")

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()

        GeneralModule.PanelToButton(GenerateReportButton, GenerateReportImage1, GenerateReportImage2, 247, "Stars", "Generate")
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    'MainForm.StockManageFormPanel.Controls.Clear
    'GeneralModule.ChooseNavigation(MainForm.StockManagementPanel, MainForm.StockManagementButton, "Hovered", "Layer", GeneralModule.ButtonDictionary, "Stock Management", ViewMoreStockManagement, MainForm.StockManageFormPanel)


    Private Sub NewProductButton_Click(sender As Object, e As EventArgs) Handles NewStockButton.Click

        StockEntry.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, StockEntry)
        FormPanel.Focus
        ActiveControl = FormPanel

        If FormPanel.Controls.OfType(Of StockUserControl).Any

            Label4.Hide
            Label3.show
            Label3.Text = FormPanel.Controls.OfType(Of StockUserControl).Count & " stock found"

        Else

            Label4.Show
            Label3.Hide

        End If

        If InventoryTransactions.FormPanel.Controls.OfType(Of InventoryTransactionUserControl).Any

            InventoryTransactions.Label1.Hide
            InventoryTransactions.Label3.show
            InventoryTransactions.Label3.Text = InventoryTransactions.FormPanel.Controls.OfType(Of InventoryTransactionUserControl).Count & " Transaction found"

        Else

            InventoryTransactions.Label1.Show
            InventoryTransactions.Label3.Hide

        End If

    End Sub

    Public Sub CreateUserControl(StockId As Integer, ProductName As String, ProductImage As Byte(),
                             Warehouse As String, CurrentStock As Integer, BatchName As String, ProductId As Integer)

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

        Dim NewStock As New StockUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(3, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }

        'Assigning ng values ng products sa user control/
        NewStock.StockNameLabel.Text = ProductName

        If ProductImage IsNot Nothing Then
            Using ms As New IO.MemoryStream(ProductImage)
                NewStock.PlaceholderImage.Image = Image.FromStream(ms)
            End Using
        End If

        NewStock.WarehouseBatchLabel.Text = Warehouse.ToString & " | " & BatchName.ToString
        NewStock.StockLabel.Text = CurrentStock.ToString
        NewStock.StockIdLabel.Text = StockId.ToString
        NewStock.ProductIdLabel.Text = ProductId.ToString

        FormPanel.Controls.Add(NewStock)

    End Sub

    Async Function CreateStockUserControl() As Task

        'Mag produce ng user controls.

        For i As Integer = 0 To ListOfStockId.Count - 1

            CreateUserControl(Variables.ListOfStockId(i),
                              Await StockManagementModule.GetProductName(Variables.ListOfStockProductId(i)),
                              Await StockManagementModule.GetProductImage(Variables.ListOfStockProductId(i)),
                              Await StockManagementModule.GetWarehouse(Variables.ListOfWarehouse(i)),
                              Variables.ListOfCurrentStock(i), Variables.ListOfBatchCode(i), Variables.ListOfStockProductId(i))

        Next

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

    Private Sub HideSearchFlowLayout

        If ResultSearchPanel.Visible

            ResultSearchPanel.Hide

        End If

    End Sub

    Private Async Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged

        'Searching naman sa pangalan ng Product

        Dim Query As String
        Dim TotalStocksSearched As Integer = FormPanel.Controls.OfType(Of StockUserControl).Count
        Dim CountFlag As Integer
        Dim PanelNewHeight As Integer

        If Not String.IsNullOrEmpty(SearchTextBox.Text)

            ResultSearchPanel.Controls.Clear

            Query = " SELECT s.* FROM stock s WHERE s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p WHERE p.product_name LIKE '%' + @ProductName + '%') ORDER BY s.stock_id DESC"

            Await StockManagementModule.SearchByProductName(Query, "@ProductName", SearchTextBox.Text)

            If Variables.SearchByStockId.Count > 0

                GeneralModule.CreateStockSearchUserControl

                'Mag lo-loop sa mga search control then kukuhain yung bottom ng 5th control
                For Each Cntrl As Control In ResultSearchPanel.Controls.OfType(Of StockSearchUserControl)

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

        'Label3.Text = TotalStocksSearched & " stocks Found"

    End Sub

    Private Sub PanelSearch_Click(sender As Object, e As EventArgs) Handles PanelSearch.Click, FormPanel.Click, MyBase.Click

        HideSearchFlowLayout

    End Sub

    Public Sub CreateSearchUserControl(StockId As Integer, ProductId As Integer, BatchName As String, Stock As Integer)

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

        Dim StockSearch As New StockSearchUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(1, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }
        StockSearch.BatchLabel.Text = BatchName.ToString & " - " & Stock.ToString & " stocks"
        StockSearch.ProductIdLabel.Text = ProductId
        StockSearch.StockId.Text = StockId

        ResultSearchPanel.Controls.Add(StockSearch)

    End Sub

    Private Async Sub DateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateComboBox.SelectedIndexChanged

        'Searching by date.

        HideSearchFlowLayout

        If DateComboBox.SelectedIndex > -1

            Variables.StockByDate = DateComboBox.SelectedItem.ToString
            Variables.StockNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.StockFilterBy, Variables.StockByDate,
                                                                            Variables.StockSortBy)
            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            Dim Query As String
            Dim TotalStocksSearched As Integer
            Dim ParameterValue As Integer

            If Variables.StockNumberOfFilters = 1

                If Variables.StockByDate <> "Custom" Then

                    Query = "SELECT * FROM stock WHERE date_added LIKE @SelectedMonth + '%' AND active = 1"
                    Await StockManagementModule.RetrieveStockBy1Filter(Query, "@SelectedMonth", Variables.StockByDate)
                    TotalStocksSearched = Variables.ListOfStockId.Count

                End If

            ElseIf Variables.StockNumberOfFilters = 2

                If Variables.StockByDate = "Custom"

                Else

                    If Not String.IsNullOrEmpty(Variables.StockFilterBy) And String.IsNullOrEmpty(Variables.StockSortBy)

                        If Variables.StockFilterBy = "Batches"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND date_added LIKE @SelectedMonth + '%' AND active = 1"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockFilterBy = "Warehouse"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND date_added LIKE @SelectedMonth + '%' AND active = 1"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    ElseIf Not String.IsNullOrEmpty(Variables.StockSortBy) And String.IsNullOrEmpty(Variables.StockFilterBy)

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.date_added LIKE @SelectedMonth + '%' AND active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) ASC"
                            Await StockManagementModule.RetrieveStockBy1Filter(query, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.date_added LIKE @SelectedMonth + '%' AND active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) DESC"
                            Await StockManagementModule.RetrieveStockBy1Filter(query, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY stock_id DESC"
                            Await StockManagementModule.RetrieveStockBy1Filter(query, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY stock_id ASC"
                            Await StockManagementModule.RetrieveStockBy1Filter(query, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    End If

                End If

            Else

                If Variables.StockByDate = "Custom"

                Else

                    If Variables.StockFilterBy = "Batches"

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p ) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) ASC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p ) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) DESC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id DESC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id ASC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    ElseIf Variables.StockFilterBy = "Warehouse"

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @WarehouseId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p ) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) ASC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @WarehouseId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p ) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) DESC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id DESC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id ASC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    End If

                End If

            End If

            Label3.Text = TotalStocksSearched & " Batches found"
            Await CreateStockUserControl
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel

        End If

    End Sub

    Private Async Sub SortByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortByComboBox.SelectedIndexChanged

        'Search naman by Sorting.

        HideSearchFlowLayout


        If SortByComboBox.SelectedIndex > -1

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)
            Variables.StockSortBy = SortByComboBox.SelectedItem.ToString
            Variables.StockNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.StockFilterBy, Variables.StockByDate,
                                                                            Variables.StockSortBy)

            Dim Query As String
            Dim ParameterValue As Integer
            Dim TotalStocksSearched As Integer

            If Variables.StockNumberOfFilters = 1

                If Variables.StockSortBy = "A - Z"

                    Query = "SELECT s.* FROM stock s WHERE s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) ASC"
                    Await StockManagementModule.RetrieveAll(Query)
                    TotalStocksSearched = Variables.ListOfStockId.Count

                ElseIf Variables.StockSortBy = "Z - A"

                    Query = "SELECT s.* FROM stock s WHERE s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) DESC"
                    Await StockManagementModule.RetrieveAll(Query)
                    TotalStocksSearched = Variables.ListOfStockId.Count

                ElseIf Variables.StockSortBy = "New First"

                    Query = "SELECT * FROM stock WHERE active = 1 ORDER BY stock_id DESC"
                    Await StockManagementModule.RetrieveAll(Query)
                    TotalStocksSearched = Variables.ListOfStockId.Count

                ElseIf Variables.StockSortBy = "Old First"

                    Query = "SELECT * FROM stock WHERE active = 1 ORDER BY stock_id ASC"
                    Await StockManagementModule.RetrieveAll(Query)
                    TotalStocksSearched = Variables.ListOfStockId.Count

                End If

            ElseIf Variables.StockNumberOfFilters = 2

                If Not String.IsNullOrEmpty(Variables.StockFilterBy) And String.IsNullOrEmpty(Variables.StockByDate)

                    If Variables.StockFilterBy = "Batches"

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) ASC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) DESC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 ORDER BY stock_id DESC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 ORDER BY stock_id ASC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    ElseIf Variables.StockFilterBy = "Warehouse"

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @Warehouse AND s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) ASC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@Warehouse", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @Warehouse AND s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) DESC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@Warehouse", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @Warehouse AND active = 1 ORDER BY stock_id DESC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@Warehouse", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @Warehouse AND active = 1 ORDER BY stock_id ASC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@Warehouse", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    End If

                ElseIf Not String.IsNullOrEmpty(Variables.StockByDate) And String.IsNullOrEmpty(Variables.StockFilterBy)

                    If Variables.StockByDate = "Custom"

                    Else

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.date_added LIKE @SelectedMonth + '%' AND s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) ASC"
                            Await StockManagementModule.RetrieveStockBy1Filter(query, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.date_added LIKE @SelectedMonth + '%' AND s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id) DESC"
                            Await StockManagementModule.RetrieveStockBy1Filter(query, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY stock_id DESC"
                            Await StockManagementModule.RetrieveStockBy1Filter(query, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY stock_id ASC"
                            Await StockManagementModule.RetrieveStockBy1Filter(query, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    End If

                End If

            Else

                If Variables.StockByDate = "Custom"

                Else

                    If Variables.StockFilterBy = "Batches"

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE s.product_id = p.product_id) ASC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE s.product_id = p.product_id) DESC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id DESC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id ASC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    ElseIf Variables.StockFilterBy = "Warehouse"

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @WarehouseId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE s.product_id = p.product_id) ASC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @WarehouseId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE s.product_id = p.product_id) DESC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id DESC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id ASC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    End If

                End If

            End If

            Label3.Text = TotalStocksSearched & " Batches found"
            Await CreateStockUserControl
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel

        End If

    End Sub

    Private Async Sub FilterByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterByComboBox.SelectedIndexChanged

        HideSearchFlowLayout

        If FilterByComboBox.SelectedIndex > -1

            FilterNameComboBox.Items.Clear
            Variables.StockFilterBy = FilterByComboBox.SelectedItem
            Dim FilterBy As List(Of Object)

            If Variables.StockFilterBy = "Batches"

                Label6.Text = Variables.StockFilterBy
                Label6.Left = FilterNameComboBox.Left - Label6.Width
                FilterBy = Await StockManagementModule.GetProductsFromStock
                FilterBy.ToString

                For each Item As String In FilterBy

                    FilterNameComboBox.Items.Add(Item)

                Next

            ElseIf Variables.StockFilterBy = "Warehouse"

                Label6.Text = Variables.StockFilterBy
                Label6.Left = FilterNameComboBox.Left - Label6.Width
                FilterBy = Await StockManagementModule.GetWarehouses
                FilterBy.ToString

                For each Item As String In FilterBy

                    FilterNameComboBox.Items.Add(Item)

                Next

            End If

            'Mag iiba yung location ang FilterByCombo Box depende kung may laman or wala yung variable.
            If Not String.IsNullOrEmpty(Variables.StockFilterBy)

                Label6.Show
                FilterNameComboBox.Show

                FilterByComboBox.Top = 44
                FilterByComboBox.Left = label28.left - FilterByComboBox.Width - 5
                Label24.Top = 55
                Label24.Left = FilterByComboBox.Left - Label24.Width - 4

                FilterNameComboBox.Top = 96
                FilterNameComboBox.Left = Label26.Left - FilterNameComboBox.Width - 4
                Label6.Top = 108
                Label6.Left = FilterNameComboBox.Left - Label6.Width - 4

            Else

                Label6.Hide
                FilterNameComboBox.Hide

                FilterByComboBox.Top = 96
                Label24.Top = 108

            End If

        End If

        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Async Sub FilterNameComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterNameComboBox.SelectedIndexChanged

        HideSearchFlowLayout

        'For searching naman ng by filter.

        If FilterNameComboBox.SelectedIndex > -1

            Variables.StockFilterByWhat = FilterNameComboBox.SelectedItem.ToString()
            Variables.StockNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.StockFilterBy, Variables.StockByDate,
                                                                            Variables.StockSortBy)

            Dim Query As String
            Dim ParameterValue As Integer
            Dim TotalStocksSearched As Integer
            
            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.StockFilterBy = "Batches"

                If Variables.StockNumberOfFilters = 1

                    Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1"
                    ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                    Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                    TotalStocksSearched = Variables.ListOfStockId.Count

                ElseIf Variables.StockNumberOfFilters = 2

                    If Not String.IsNullOrEmpty(Variables.StockSortBy) And String.IsNullOrEmpty(Variables.StockByDate)

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id AND s.active = 1) ASC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE p.product_id = s.product_id AND s.active = 1) DESC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 ORDER BY stock_id DESC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 ORDER BY stock_id ASC"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@ProductId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    ElseIf Not String.IsNullOrEmpty(Variables.StockByDate) And String.IsNullOrEmpty(Variables.StockSortBy)

                        If Variables.StockByDate = "Custom"

                        Else

                            Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 AND date_added LIKE @SelectedMonth + '%'"
                            ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    End If

                Else

                    If Variables.StockSortBy = "A - Z"

                        Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE s.product_id = p.product_id) ASC"
                        ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                        Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                        TotalStocksSearched = Variables.ListOfStockId.Count

                    ElseIf Variables.StockSortBy = "Z - A"

                        Query = "SELECT s.* FROM stock s WHERE s.product_id = @ProductId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE s.product_id = p.product_id) DESC"
                        ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                        Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                        TotalStocksSearched = Variables.ListOfStockId.Count

                    ElseIf Variables.StockSortBy = "New First"

                        Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id DESC"
                        ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                        Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                        TotalStocksSearched = Variables.ListOfStockId.Count

                    ElseIf Variables.StockSortBy = "Old First"

                        Query = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id ASC"
                        ParameterValue = Await StockManagementModule.GetProductId(Variables.StockFilterByWhat)
                        Await StockManagementModule.RetrievePStockBy2Filter(Query, "@ProductId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                        TotalStocksSearched = Variables.ListOfStockId.Count

                    End If

                End If

            ElseIf Variables.StockFilterBy = "Warehouse"

                If Variables.StockNumberOfFilters = 1

                    Query = "SELECT * FROM stock WHERE warehouse_id = @Warehouse AND active = 1"
                    ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                    Await StockManagementModule.RetrieveStockBy1Filter(Query, "@Warehouse", ParameterValue)
                    TotalStocksSearched = Variables.ListOfStockId.Count

                ElseIf Variables.StockNumberOfFilters = 2

                    If Not String.IsNullOrEmpty(Variables.StockSortBy) And String.IsNullOrEmpty(Variables.StockByDate)

                        If Variables.StockSortBy = "A - Z"

                            Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @WarehouseId AND s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name WHERE s.product_id = p.product_id) ASC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@WarehouseId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Z - A"

                            Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @WarehouseId AND s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name WHERE s.product_id = p.product_id) DESC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@WarehouseId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "New First"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 ORDER BY stock_id DESC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@WarehouseId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        ElseIf Variables.StockSortBy = "Old First"

                            Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 ORDER BY stock_id ASC"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrieveStockBy1Filter(Query, "@WarehouseId", ParameterValue)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    ElseIf Not String.IsNullOrEmpty(Variables.StockByDate) And String.IsNullOrEmpty(Variables.StockSortBy)

                        If Variables.StockByDate = "Custom"

                        Else

                            Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 AND date_added LIKE @SelectedMonth + '%'"
                            ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                            Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                            TotalStocksSearched = Variables.ListOfStockId.Count

                        End If

                    End If

                Else

                    If Variables.StockSortBy = "A - Z"

                        Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @WarehouseId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE s.product_id = p.product_id) ASC"
                        ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                        Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                        TotalStocksSearched = Variables.ListOfStockId.Count

                    ElseIf Variables.StockSortBy = "Z - A"

                        Query = "SELECT s.* FROM stock s WHERE s.warehouse_id = @WarehouseId AND s.active = 1 AND s.date_added LIKE @SelectedMonth + '%' AND s.product_id IN (SELECT p.product_id FROM product p) ORDER BY (SELECT p.product_name FROM product p WHERE s.product_id = p.product_id) DESC"
                        ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                        Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                        TotalStocksSearched = Variables.ListOfStockId.Count

                    ElseIf Variables.StockSortBy = "New First"

                        Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id DESC"
                        ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                        Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                        TotalStocksSearched = Variables.ListOfStockId.Count

                    ElseIf Variables.StockSortBy = "Old First"

                        Query = "SELECT * FROM stock WHERE warehouse_id = @WarehouseId AND active = 1 AND date_added LIKE @SelectedMonth + '%' ORDER BY stock_id ASC"
                        ParameterValue = Await StockManagementModule.GetWarehouseId(Variables.StockFilterByWhat)
                        Await StockManagementModule.RetrievePStockBy2Filter(Query, "@WarehouseId", ParameterValue, "@SelectedMonth", Variables.StockByDate)
                        TotalStocksSearched = Variables.ListOfStockId.Count

                    End If

                End If

            End If

            Label3.Text = TotalStocksSearched & " Batches found"
            Await CreateStockUserControl
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel

        End If

    End Sub

    Private Async Sub SearchTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchTextBox.KeyDown

        'Same lang sa SearchTextBox_TextChanged pero dito lalabas lahat ng result sa PanelForm

        Dim Query As String
        Dim TotalStocksSearched As Integer
        Dim StockExist As Boolean = Await StockManagementModule.DoesStockExist(SearchTextBox.Text)

        If e.KeyCode = Keys.Enter Then

            If StockExist

                Dim ProductName As String = Await StockManagementModule.GetProductName(Await ProductManagementDatabaseModule.GetProductIdByBarcode(SearchTextBox.Text))
                Query = " SELECT s.* FROM stock s WHERE s.active = 1 AND s.product_id IN (SELECT p.product_id FROM product p WHERE p.product_name LIKE '%' + @ProductName + '%') ORDER BY s.stock_id DESC"
                Await StockManagementModule.SearchByProductName(Query, "@ProductName", ProductName)

            End If

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

            If String.IsNullOrEmpty(SearchTextBox.Text) Then

                TotalStocksSearched = FormPanel.Controls.OfType(Of StockSearchUserControl).Count
                MessageBox.Show("Put the product name in the field", "Provide Product Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                TotalStocksSearched = Variables.SearchByStockId.Count

                If TotalStocksSearched = 0 Then

                    MessageBox.Show("No related batch found.", "Product Non-Existent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    GeneralModule.DeleteUserControls(FormPanel)

                Else

                    GeneralModule.DeleteUserControls(FormPanel)
                    ResultSearchPanel.Hide()

                    For Each Item In Variables.SearchByStockId

                        Query = "SELECT * FROM stock WHERE stock_id = @StockId AND active = 1"
                        Await StockManagementModule.RetrieveStockBy1Filter(Query, "@StockId", Item)
                        Await CreateStockUserControl()

                    Next

                End If

            End If

            SearchTextBox.Clear()
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel
            Label3.Text = TotalStocksSearched & " Batches found"

        End If

    End Sub

    Private Async Sub ClearAllFiltersButton_Click(sender As Object, e As EventArgs) Handles ClearAllFiltersButton.Click

        'Ireremove lahat ng filter then show all.

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        HideSearchFlowLayout()

        Variables.StockNumberOfFilters = 0
        Variables.StockFilterBy = String.Empty
        Variables.StockFilterByWhat = String.Empty
        Variables.StockByDate = String.Empty
        Variables.StockSortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        FilterByComboBox.SelectedIndex = -1
        FilterNameComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim StockQuery As String = "SELECT * FROM stock WHERE active = 1 ORDER BY stock_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await StockManagementModule.RetrieveAll(StockQuery)
        Await CreateStockUserControl()

        If Not String.IsNullOrEmpty(Variables.FilterBy)

            Label6.Show
            FilterNameComboBox.Show

            FilterByComboBox.Top = 44
            FilterByComboBox.Left = label28.left - FilterByComboBox.Width - 5
            Label24.Top = 55
            Label24.Left = FilterByComboBox.Left - Label24.Width - 4

            FilterNameComboBox.Top = 96
            FilterNameComboBox.Left = Label26.Left - FilterNameComboBox.Width - 4
            Label6.Top = 108
            Label6.Left = FilterNameComboBox.Left - Label6.Width - 4

        Else

            Label6.Hide
            FilterNameComboBox.Hide

            FilterByComboBox.Top = 96
            FilterByComboBox.Left = Label26.Left - FilterByComboBox.Width - 4
            Label24.Top = 108
            Label24.Left = FilterByComboBox.Left - Label24.Width - 4

        End If

        ' Update the UI
        Dim TotalStocksSearched As Integer = Variables.ListOfStockId.Count
        Label3.Text = TotalStocksSearched & " Batches found"

        ' Hide loading screen
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

End Class