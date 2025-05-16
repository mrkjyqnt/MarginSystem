Imports System.ComponentModel
Imports System.IO
Imports System.Net.Http.Headers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports Guna.UI2.WinForms

Public Class ProductManagement

    Private hoveredIndex As Integer = -1
    Dim Clicked As Integer = 0

    Private Sub GenerateReportButton_MouseEnter(sender As Object, e As EventArgs) Handles GenerateReportButton.MouseEnter, Label5.MouseEnter, GenerateReportImage1.MouseEnter, GenerateReportImage2.MouseEnter

        GeneralModule.PanelToButton(GenerateReportButton, GenerateReportImage1, GenerateReportImage2, 210, "HoveredStars", "HoveredGenerate")

    End Sub

    Private Sub GenerateReportButton_MouseLeave(sender As Object, e As EventArgs) Handles GenerateReportButton.MouseLeave

        GeneralModule.PanelToButton(GenerateReportButton, GenerateReportImage1, GenerateReportImage2, 247, "Stars", "Generate")

    End Sub

    Private Sub Label5_MouseDown(sender As Object, e As MouseEventArgs) Handles GenerateReportButton.MouseDown, Label5.MouseDown, GenerateReportImage1.MouseDown, GenerateReportImage2.MouseDown

        GeneralModule.PanelToButton(GenerateReportButton, GenerateReportImage1, GenerateReportImage2, 147, "HoveredStars", "HoveredGenerate")

    End Sub

    Private Sub NewProductButton_Click(sender As Object, e As EventArgs) Handles NewProductButton.Click

        'Add new product.
        HideSearchFlowLayout
        GeneralModule.ShowOverlay(MainForm, AddNewProduct)
        FormPanel.Focus
        ActiveControl = FormPanel

        'If wala pang products, show a message.
        If FormPanel.Controls.OfType(Of ProductUserControl).Any

            Label4.Hide
            Label3.show
            Label3.Text = FormPanel.Controls.OfType(Of ProductUserControl).Count & " Products found"

        Else

            Label4.Show
            Label3.Hide

        End If

        'If wala pang products, show a message.
        If Activities.FormPanel.Controls.OfType(Of ActivityValuationUserControl).Any

            Activities.Label3.Hide
            Activities.Label13.show
            Activities.Label13.Text = FormPanel.Controls.OfType(Of ActivityValuationUserControl).Count & " Products found"

        Else

            Activities.Label3.Show
            Activities.Label13.Hide

        End If

    End Sub

    Private Async Sub Label5_Click(sender As Object, e As EventArgs) Handles GenerateReportButton.Click, Label5.Click, GenerateReportImage1.Click, GenerateReportImage2.Click

        GenerateReport.Opacity = 0
        HideSearchFlowLayout
        GenerateReport.TableName = "product"
        GeneralModule.ShowOverlay(MainForm, GenerateReport)

        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "product", DateAdded, TimeAdded, $"Generate Report for Product Management")
        
        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()

        GeneralModule.PanelToButton(GenerateReportButton, GenerateReportImage1, GenerateReportImage2, 247, "Stars", "Generate")
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Sub ProductManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FormPanel.HorizontalScroll.Enabled = False

        'Count how many products there are.
        If FormPanel.Controls.OfType(Of ProductUserControl).Any

            Label4.Hide
            Label3.show
            Label3.Text = FormPanel.Controls.OfType(Of ProductUserControl).Count & " Products found"

        Else

            Label4.Show
            Label3.Hide

        End If

    End Sub

    Private Sub ScanBarcodeButton_Click(sender As Object, e As EventArgs) Handles ScanBarcodeButton.Click

        Barcode.Opacity = 0
        HideSearchFlowLayout
        Barcode.BarcodeImage.Hide
        Barcode.label2.Show
        Barcode.label3.Hide
        Barcode.Label1.Text = "Scan Barcode"
        Barcode.ProductCodeTextBox.Focus
        GeneralModule.ShowOverlay(MainForm, Barcode)
        Barcode.Dispose
        ActiveControl = FormPanel
        FormPanel.Focus

    End Sub

    'MainForm.ProductManageFormPanel.Controls.Clear
    'GeneralModule.ChooseNavigation(MainForm.ProductManagementPanel, MainForm.ProductManagementButton, "Hovered", "Box", GeneralModule.ButtonDictionary, "Product Management", ViewMoreFormProductManagement, MainForm.ProductManageFormPanel)

    Public Sub CreateUserControl(ProductId As Integer, ProductCode As String, ProductName As String, ProductImage As Byte(),
                             Category As String, Price As Integer)

        'Creation ng Product User Control

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

        Dim NewProduct As New ProductUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(3, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }

        'Assigning ng values ng products sa user control/
        NewProduct.ProductNameLabel.Text = ProductName

        If ProductImage IsNot Nothing Then
            Using ms As New IO.MemoryStream(productImage)
                NewProduct.PlaceholderImage.Image = Image.FromStream(ms)
            End Using
        End If

        NewProduct.CategoryProductCodeLabel.Text = Category.ToString & " | " & ProductCode.ToString
        NewProduct.ItemPriceLabel.Text = "₱ " & Price.ToString
        NewProduct.ProductIdLabel.Text = ProductId.ToString
        NewProduct.ProductCategoryLabel.Text = Category.ToString
        NewProduct.SendToBack

        FormPanel.Controls.Add(NewProduct)

    End Sub

    Async Function CreateProductUserControl() As Task

        'Mag produce ng user controls.

        For i As Integer = 0 To ListOfProductId.Count - 1

            CreateUserControl(Variables.ListOfProductId(i), Variables.ListOfProductBarcodeSequence(i), Variables.ListOfProductName(i), Variables.ListOfProductImage(i), Await ProductManagementDatabaseModule.GetCategory(ListOfProductCategory(i)), Variables.ListOfProductRetailPrice(i))

        Next

    End Function

    Public Sub CreateSearchUserControl(ProductId As Integer, ProductName As String, ProductImage As Byte())

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

        Dim ProductSearch As New SearchUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(1, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }

        ProductSearch.ProductNameLabel.Text = ProductName

        If ProductImage IsNot Nothing Then
            Using ms As New IO.MemoryStream(productImage)
                ProductSearch.PlaceholderImage.Image = Image.FromStream(ms)
            End Using
        End If

        ProductSearch.ProductNameLabel.text = ProductName.ToString
        ProductSearch.ProductIdLabel.Text = "Product # " & ProductId.ToString
        ProductSearch.IdLabel.Text = ProductId

        ResultSearchPanel.Controls.Add(ProductSearch)

    End Sub

    Private Async Sub FilterByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterByComboBox.SelectedIndexChanged

        HideSearchFlowLayout


        If FilterByComboBox.SelectedIndex > -1

            FilterNameComboBox.Items.Clear
            Variables.FilterBy = FilterByComboBox.SelectedItem
            Dim FilterBy As List(Of Object)

            If Variables.FilterBy = "Category"

                Label6.Text = Variables.FilterBy
                Label6.Left = FilterNameComboBox.Left - Label6.Width
                FilterBy = Await ProductManagementDatabaseModule.GetCategoryList
                FilterBy.ToString

                For each Item As String In FilterBy

                    FilterNameComboBox.Items.Add(Item)

                Next

            ElseIf Variables.FilterBy = "Supplier"

                Label6.Text = Variables.FilterBy
                Label6.Left = FilterNameComboBox.Left - Label6.Width
                FilterBy = Await ProductManagementDatabaseModule.GetSupplierList
                FilterBy.ToString

                For each Item As String In FilterBy

                    FilterNameComboBox.Items.Add(Item)

                Next

            End If

            'Mag iiba yung location ang FilterByCombo Box depende kung may laman or wala yung variable.
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
                Label24.Top = 108

            End If

        End If

        ActiveControl = FormPanel

    End Sub

    Private Async Sub FilterNameComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterNameComboBox.SelectedIndexChanged

        HideSearchFlowLayout

        'For searching naman ng by filter.

        If FilterNameComboBox.SelectedIndex > -1

            Variables.FilterByWhat = FilterNameComboBox.SelectedItem.ToString()
            Variables.NumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.FilterBy, Variables.ByDate,
                                                                            Variables.SortBy)

            Dim Query As String
            Dim ParameterValue As Integer
            Dim TotalProductsSearched As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)
            If Variables.FilterBy = "Category"

                If Variables.NumberOfFilters = 1

                    'Label1.Text = Variables.NumberOfFilters
                    Query = "SELECT * FROM product WHERE category_id = @CategoryId And active = 1"
                    ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                    Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                    TotalProductsSearched = Variables.ListOfProductId.Count

                ElseIf Variables.NumberOfFilters = 2

                    'Label1.Text = Variables.NumberOfFilters
                    If Not String.IsNullOrEmpty(Variables.SortBy) And String.IsNullOrEmpty(Variables.ByDate)

                        If Variables.SortBy = "A - Z"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId And active = 1 ORDER BY product_name ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId And active = 1 ORDER BY product_name DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "New First"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId And active = 1 ORDER BY product_id DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Old First"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId And active = 1 ORDER BY product_id ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    ElseIf Not String.IsNullOrEmpty(Variables.ByDate) And String.IsNullOrEmpty(Variables.SortBy)

                        If Variables.ByDate = "Custom"

                        Else

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId And date_added Like @SelectedMonth + '%' AND active = 1"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count


                        End If

                    End If

                Else

                    'Label1.Text = Variables.NumberOfFilters
                    If Variables.SortBy = "A - Z"

                        Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name ASC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "Z - A"

                        Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name DESC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "New First"

                        Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id DESC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "Old First"

                        Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id ASC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    End If

                End If

            ElseIf Variables.FilterBy = "Supplier"

                If Variables.NumberOfFilters = 1

                    Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1"
                    ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                    Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                    TotalProductsSearched = Variables.ListOfProductId.Count

                ElseIf Variables.NumberOfFilters = 2

                    If Not String.IsNullOrEmpty(Variables.SortBy) And String.IsNullOrEmpty(Variables.ByDate)

                        If Variables.SortBy = "A - Z"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1 ORDER BY product_name ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1 ORDER BY product_name DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "New First"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1 ORDER BY product_id DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Old First"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1 ORDER BY product_id ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    ElseIf Not String.IsNullOrEmpty(Variables.ByDate) And String.IsNullOrEmpty(Variables.SortBy)

                        If Variables.ByDate = "Custom"

                        Else

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count


                        End If

                    End If

                Else

                    If Variables.SortBy = "A - Z"

                        Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name ASC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "Z- A"

                        Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name DESC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "New First"

                        Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id DESC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "Old First"

                        Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id ASC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    End If

                End If

            End If

            Label3.Text = TotalProductsSearched & " Products found"
            Await CreateProductUserControl
            GeneralModule.CloseOverLay(LoadingScreen)
            ActiveControl = FormPanel

        End If

    End Sub

    Private Async Sub SortByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortByComboBox.SelectedIndexChanged

        'Search naman by Sorting.

        HideSearchFlowLayout

        If SortByComboBox.SelectedIndex > -1

            Variables.SortBy = SortByComboBox.SelectedItem.ToString
            Variables.NumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.FilterBy, Variables.ByDate,
                                                                            Variables.SortBy)

            Dim Query As String
            Dim ParameterValue As Integer
            Dim TotalProductsSearched As Integer
            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)
            If Variables.NumberOfFilters = 1

                If Variables.SortBy = "A - Z"

                    Query = "SELECT * FROM product WHERE active = 1 ORDER BY product_name ASC"
                    Await ProductManagementDatabaseModule.RetrieveAll(Query)
                    TotalProductsSearched = Variables.ListOfProductId.Count

                ElseIf Variables.SortBy = "Z - A"

                    Query = "SELECT * FROM product WHERE active = 1 ORDER BY product_name DESC"
                    Await ProductManagementDatabaseModule.RetrieveAll(Query)
                    TotalProductsSearched = Variables.ListOfProductId.Count

                ElseIf Variables.SortBy = "New First"

                    Query = "SELECT * FROM product WHERE active = 1 ORDER BY product_id DESC"
                    Await ProductManagementDatabaseModule.RetrieveAll(Query)
                    TotalProductsSearched = Variables.ListOfProductId.Count

                ElseIf Variables.SortBy = "Old First"

                    Query = "SELECT * FROM product WHERE active = 1 ORDER BY product_id ASC"
                    Await ProductManagementDatabaseModule.RetrieveAll(Query)
                    TotalProductsSearched = Variables.ListOfProductId.Count
                End If

            ElseIf Variables.NumberOfFilters = 2

                If Not String.IsNullOrEmpty(Variables.FilterBy) And String.IsNullOrEmpty(Variables.ByDate)

                    If Variables.FilterBy = "Category"

                        If Variables.SortBy = "A - Z"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND active = 1 ORDER BY product_name ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND active = 1 ORDER BY product_name DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "New First"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND active = 1 ORDER BY product_id DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Old First"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND active = 1 ORDER BY product_id ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@CategoryId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    ElseIf Variables.FilterBy = "Supplier"

                        If Variables.SortBy = "A - Z"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1 ORDER BY product_name ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1 ORDER BY product_name DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "New First"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1 ORDER BY product_id DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Old First"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND active = 1 ORDER BY product_id ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SupplierId", ParameterValue)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    End If

                ElseIf Not String.IsNullOrEmpty(Variables.ByDate) And String.IsNullOrEmpty(Variables.FilterBy)

                    If Variables.ByDate = "Custom"

                    Else

                        If Variables.SortBy = "A - Z"

                            Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name ASC"
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(query, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name DESC"
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(query, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "New First"

                            Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id DESC"
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(query, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Old First"

                            Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id ASC"
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(query, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    End If

                End If

            Else

                If Variables.FilterBy = "Category"

                    If Variables.SortBy = "A - Z"

                        Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name ASC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "Z - A"

                        Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name Desc"
                        ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "New First"

                        Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id DESC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "Old First"

                        Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id ASC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    End If

                Elseif Variables.FilterBy = "Supplier"

                    If Variables.SortBy = "A - Z"

                        Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name ASC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "Z - A"

                        Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name Desc"
                        ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "New First"

                        Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id DESC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    ElseIf Variables.SortBy = "Old First"

                        Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id ASC"
                        ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                        Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                        TotalProductsSearched = Variables.ListOfProductId.Count

                    End If

                End If

            End If

            Label3.Text = TotalProductsSearched & " Products found"

            Await CreateProductUserControl
            GeneralModule.CloseOverLay(LoadingScreen)
            ActiveControl = FormPanel

        End If

    End Sub

    Private Async Sub DateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateComboBox.SelectedIndexChanged

        'Searching by date.

        HideSearchFlowLayout

        If DateComboBox.SelectedIndex > -1

            Variables.ByDate = DateComboBox.SelectedItem.ToString
            Variables.NumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.FilterBy, Variables.ByDate,
                                                                            Variables.SortBy)

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            Dim Query As String
            Dim TotalProductsSearched As Integer
            Dim ParameterValue As Integer

            If Variables.NumberOfFilters = 1

                If Variables.ByDate <> "Custom" Then

                    Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1"
                    Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@SelectedMonth", Variables.ByDate)
                    TotalProductsSearched = Variables.ListOfProductId.Count

                End If

            ElseIf Variables.NumberOfFilters = 2

                If Variables.ByDate = "Custom"


                Else

                    If Not String.IsNullOrEmpty(Variables.FilterBy) And String.IsNullOrEmpty(Variables.SortBy)

                        If Variables.FilterBy = "Category"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.FilterBy = "Supplier"

                            Query = "SELECT * FROM product WHERE supplier_id = @Supplier_Id AND date_added LIKE @SelectedMonth + '%' AND active = 1"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@Supplier_Id", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    ElseIf Not String.IsNullOrEmpty(Variables.SortBy) And String.IsNullOrEmpty(Variables.FilterBy)

                        If Variables.SortBy = "A - Z"

                            Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name ASC"
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(query, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name DESC"
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(query, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "New First"

                            Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id DESC"
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(query, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Old First"

                            Query = "SELECT * FROM product WHERE date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id ASC"
                            Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(query, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    End If

                End If

            Else

                If Variables.ByDate = "Custom"

                Else

                    If Variables.FilterBy = "Category"

                        If Variables.SortBy = "A - Z"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "New First"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Old First"

                            Query = "SELECT * FROM product WHERE category_id = @CategoryId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetCategoryId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@CategoryId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    ElseIf Variables.FilterBy = "Supplier"

                        If Variables.SortBy = "A - Z"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Z - A"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_name DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "New First"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id DESC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        ElseIf Variables.SortBy = "Old First"

                            Query = "SELECT * FROM product WHERE supplier_id = @SupplierId AND date_added LIKE @SelectedMonth + '%' AND active = 1 ORDER BY product_id ASC"
                            ParameterValue = Await ProductManagementDatabaseModule.GetSupplierId(Variables.FilterByWhat)
                            Await ProductManagementDatabaseModule.RetrieveProductBy2Filter(Query, "@SupplierId", ParameterValue, "@SelectedMonth", Variables.ByDate)
                            TotalProductsSearched = Variables.ListOfProductId.Count

                        End If

                    End If

                End If

            End If

            Label3.Text = TotalProductsSearched & " Products found"
            Await CreateProductUserControl
            GeneralModule.CloseOverLay(LoadingScreen)
            ActiveControl = FormPanel

        End If

    End Sub

    Private Async Sub ClearAllFiltersButton_Click(sender As Object, e As EventArgs) Handles ClearAllFiltersButton.Click

        'Ireremove lahat ng filter then show all.

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        HideSearchFlowLayout
        Dim TotalProductsSearched As Integer

        Variables.NumberOfFilters = 0
        Variables.FilterBy = String.Empty
        Variables.FilterByWhat = String.Empty
        Variables.ByDate = String.Empty
        Variables.SortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        FilterByComboBox.SelectedIndex = -1
        FilterNameComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim Query As String = "SELECT * FROM product WHERE active = 1 ORDER BY product_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await ProductManagementDatabaseModule.RetrieveALL(Query)
        Await CreateProductUserControl()
        TotalProductsSearched = Variables.ListOfProductId.Count

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

        Label3.Text = TotalProductsSearched & " Products found"
        GeneralModule.CloseOverLay(LoadingScreen)

        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub


    Private Async Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged

        'Searching naman sa pangalan ng Product

        Dim Query As String
        'Dim TotalProductsSearched As Integer = FormPanel.Controls.OfType(Of ProductUserControl).Count
        Dim CountFlag As Integer
        Dim PanelNewHeight As Integer

        If Not String.IsNullOrEmpty(SearchTextBox.Text)

            ResultSearchPanel.Controls.Clear

            'Query = "
             '       SELECT p.*, s.* 
            '       FROM product p 
             '       LEFT JOIN stock s ON p.product_id = s.product_id 
             '       WHERE p.product_name LIKE '%' + @ProductName + '%'"

            Query = "SELECT * FROM product WHERE product_name LIKE '%' + @ProductName + '%' AND active = 1 ORDER BY product_id DESC"
            
            Await ProductManagementDatabaseModule.SearchByProductName(Query, "@ProductName", SearchTextBox.Text)
            
            If Variables.SearchByProductId.Count > 0
                
                GeneralModule.CreateProductSearchUserControl
                'Mag lo-loop sa mga search control then kukuhain yung bottom ng 5th control
                    
                
                For Each Cntrl As Control In ResultSearchPanel.Controls.OfType(Of SearchUserControl)
                    
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

        'Label3.Text = TotalProductsSearched & " Products Found"

    End Sub

    Private Sub PanelSearch_Click(sender As Object, e As EventArgs) Handles PanelSearch.Click, FormPanel.Click, MyBase.Click

        HideSearchFlowLayout

    End Sub

    Private Sub HideSearchFlowLayout

        If ResultSearchPanel.Visible

            ResultSearchPanel.Hide

        End If

    End Sub

    Private Async Sub SearchTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchTextBox.KeyDown

        'Same lang sa SearchTextBox_TextChanged pero dito lalabas lahat ng result sa PanelForm

        Dim Query As String
        Dim TotalProductsSearched As Integer
        Dim ProductExist As Boolean = Await ProductManagementDatabaseModule.IsProductCodeExists(SearchTextBox.Text)

        If e.KeyCode = Keys.Enter Then

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

            If ProductExist

                Dim ProductName As String = Await StockManagementModule.GetProductName(Await ProductManagementDatabaseModule.GetProductIdByBarcode(SearchTextBox.Text))
                Query = "SELECT * FROM product WHERE product_name = @ProductName AND active = 1 ORDER BY product_id DESC"
                Await ProductManagementDatabaseModule.SearchByProductName(Query, "@ProductName", ProductName)

            End If

            If String.IsNullOrEmpty(SearchTextBox.Text) Then

                TotalProductsSearched = FormPanel.Controls.OfType(Of ProductUserControl).Count
                MessageBox.Show("Put the product name in the field", "Provide Product Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                TotalProductsSearched = Variables.SearchByProductId.Count

                If TotalProductsSearched = 0 Then

                    MessageBox.Show("No related products found.", "Product Non-Existent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    GeneralModule.DeleteUserControls(FormPanel)

                Else

                    GeneralModule.DeleteUserControls(FormPanel)
                    ResultSearchPanel.Hide()

                    For Each Item In Variables.SearchByProductId

                        Query = "SELECT * FROM product WHERE product_id = @ProductId AND active = 1"
                        Await ProductManagementDatabaseModule.RetrieveProductBy1Filter(Query, "@ProductId", Item)
                        Await CreateProductUserControl()

                    Next

                End If

            End If

            SearchTextBox.Clear()
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel
            Label3.Text = TotalProductsSearched & " Products Found"

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