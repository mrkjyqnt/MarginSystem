Imports Microsoft.VisualBasic.Devices
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports System.Diagnostics

Public Class AddNewProduct

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        'Close shown forms.

        If Not String.IsNullOrEmpty(CategoryComboBox.Text) OrElse Not String.IsNullOrEmpty(ProductNameTextBox.Text) OrElse
                Not String.IsNullOrEmpty(ProductCodeTextBox.Text) OrElse Not String.IsNullOrEmpty(DescriptionTextBox.Text) OrElse
                Not String.IsNullOrEmpty(CapitalTextBox.Text) OrElse Not String.IsNullOrEmpty(WholesalePriceTextBox.Text) OrElse
                Not String.IsNullOrEmpty(RetailPriceTextBox.Text) OrElse Not String.IsNullOrEmpty(MinStockTextBox.Text) OrElse
                Not String.IsNullOrEmpty(MaxStockTextBox.Text) OrElse Not String.IsNullOrEmpty(SupplierComboBox.Text)

            Dim Ans As MsgBoxResult = MessageBox.Show("Are you sure?", "Incomplete Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

            If Ans = MsgBoxResult.Ok

                GeneralModule.CloseOverLay(Me)
                GeneralModule.ClearProductData
                Exit Sub

            Else

                Return

            End If

        Else

            AddCategory.Close
            AddCategory.Dispose
            GeneralModule.CloseOverLay(Me)
            GeneralModule.ClearProductData

        End If

    End Sub

    Private Async Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click

        Variables.ProductName = ProductNameTextBox.Text.ToString
        Variables.ProductCode = ProductCodeTextBox.Text.ToString

        Variables.ProductDescription = DescriptionTextBox.Text.ToString

        Variables.Capital = CapitalTextBox.Text.ToString
        Variables.WholeSalePrice = WholesalePriceTextBox.Text.ToString
        Variables.RetailPrice = RetailPriceTextBox.Text.ToString
        Variables.MinStock = MinStockTextBox.Text.ToString
        Variables.MaxStock = MaxStockTextBox.Text.ToString

        If String.IsNullOrEmpty(Variables.Capital) OrElse String.IsNullOrEmpty(Variables.WholeSalePrice) OrElse
                String.IsNullOrEmpty(Variables.RetailPrice) OrElse String.IsNullOrEmpty(Variables.MinStock) OrElse
                String.IsNullOrEmpty(Variables.MaxStock) OrElse String.IsNullOrEmpty(Variables.ProductName) OrElse
                String.IsNullOrEmpty(Variables.ProductCode)

            MessageBox.Show("Fill in the important fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If Variables.ProductImage Is Nothing

            Using Ms As New MemoryStream
                ProductImageTextBox.Text = Variables.ImagePlaceholder.ToString
                Variables.ImagePlaceholder.Save(Ms, System.Drawing.Imaging.ImageFormat.png)
                Variables.ProductImage = Ms.ToArray

            End Using

        End If

        If Not String.IsNullOrEmpty(CategoryComboBox.Text)

            Dim Exists As Boolean = Await ProductManagementDatabaseModule.IscategoryExists(CategoryComboBox.Text)

            If Exists

                CategoryComboBox.SelectedIndex = CategoryComboBox.Items.IndexOf(CategoryComboBox.Text)

            Else

                MessageBox.Show("Invalid product category", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If

        Else

            CategoryComboBox.SelectedIndex = 0

        End If

        If Not String.IsNullOrEmpty(SupplierComboBox.Text)

            Dim Exists As Boolean = Await ProductManagementDatabaseModule.IsSupplierExists(SupplierComboBox.Text)

            If Exists

                SupplierComboBox.SelectedIndex = SupplierComboBox.Items.IndexOf(SupplierComboBox.Text)

            Else

                MessageBox.Show("Invalid product supplier", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If

        Else

            SupplierComboBox.SelectedIndex = 0

        End If


        If String.IsNullOrEmpty(DescriptionTextBox.Text)

            DescriptionTextBox.Text = "No Available Description"

        End If

        Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")

        If Await ProductManagementDatabaseModule.IsProductCodeExists(Variables.ProductCode)

            MessageBox.Show("Product is already inserted in the system" & vbCrLf & "Provide a unique product code", "Invalid Product", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If Not IsNumeric(Variables.Capital) Or Not Double.TryParse(Variables.Capital, Nothing) Then
            MessageBox.Show("The value of capital must be a valid value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(Variables.WholeSalePrice) Or Not Double.TryParse(Variables.WholeSalePrice, Nothing) Then
            MessageBox.Show("The value of wholesale price must be a valid value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(Variables.RetailPrice) Or Not Double.TryParse(Variables.RetailPrice, Nothing) Then
            MessageBox.Show("The value of retail price must be a valid value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(Variables.MinStock) Then
            MessageBox.Show("The value of minimun stock level must be a valid value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(Variables.MaxStock) Then
            MessageBox.Show("The value of maximum stock level must be a valid value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not String.IsNullOrEmpty(Variables.MinStock)

            If Integer.Parse(Variables.MinStock) <= 0

                MessageBox.Show("Minimum stock level cannot be lower than or equal to 0", "Invalid Product", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            If Not String.IsNullOrEmpty(Variables.MaxStock) And Integer.Parse(Variables.MinStock) >= Integer.Parse(Variables.MaxStock)

                MessageBox.Show("Minimum stock level cannot be higher or equal to maximum stock level", "Invalid Product", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

        End If

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

        Await ProductManagementDatabaseModule.InsertProduct(Variables.ProductName, Variables.ProductImage,
                                        Variables.ProductCategory, Variables.ProductCode, Variables.ProductDescription,
                                        Variables.Capital, Variables.WholeSalePrice, Variables.RetailPrice, Variables.MinStock,
                                        Variables.MaxStock, Variables.Supplier, DateAdded, TimeAdded,
                                        Variables.AddedBy)

        Dim ProductQuery As String = "SELECT * FROM product WHERE active = 1 ORDER BY product_id DESC"
        GeneralModule.DeleteUserControls(ProductManagement.FormPanel)
        Await ProductManagementDatabaseModule.RetrieveALL(ProductQuery)
        Await ProductManagement.CreateProductUserControl()
        'TotalProductsSearched = Variables.ListOfProductId.Count

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()
        'TotalActivity = Variables.ListOfActivityId.Count

        'Count how many products there are.
        If ProductManagement.FormPanel.Controls.OfType(Of ProductUserControl).Any

            ProductManagement.Label4.Hide
            ProductManagement.Label3.show
            ProductManagement.Label3.Text = ProductManagement.FormPanel.Controls.OfType(Of ProductUserControl).Count & " Products found"

        Else

            ProductManagement.Label4.Show
            ProductManagement.Label3.Hide

        End If

        ValuationAndReports.ProductComboBox.Items.Clear

        Dim ListOfProduct As List(Of Object)
        ListOfProduct = Await StockManagementModule.GetProducts()
        ListOfProduct.ToString

        For each Item As String In ListOfProduct

            ValuationAndReports.ProductComboBox.Items.Add(Item)

        Next

        GeneralModule.ClearProductData
        GeneralModule.CloseOverLay(Me)
        GeneralModule.CloseOverLay(LoadingScreen)

    End Sub

    Private Sub ProductImageTextBox_IconLeftClick(sender As Object, e As EventArgs) Handles ProductImageTextBox.IconLeftClick

        Dim OpenFileDialog As New OpenFileDialog With {
            .Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif",
            .Title = "Select a Product Image"
            }

        If OpenFileDialog.ShowDialog = DialogResult.OK

            Dim SelectedFilePath As String = OpenFileDialog.FileName
            Dim SelectedFileName As String = Path.GetFileName(SelectedFilePath)
            Dim FileExtension As String = Path.GetExtension(SelectedFilePath).ToLower

            Dim ValidateExtenstions As String() = {".png", ".jpg", ".jpeg", ".bmp", ".gif"}
            If ValidateExtenstions.Contains(FileExtension)

                Variables.ProductImageName = SelectedFileName
                ProductImageTextBox.Text = Variables.ProductImageName
                Variables.ProductImage = File.ReadAllBytes(SelectedFilePath)

            Else

                MessageBox.Show("Invalid File Path. Please select a valid image file" & vbCrLf & "(PNG, JPEG, BMP, GIF).", "Invalid File",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        End If

    End Sub

    Private Async Sub AddNewProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Opacity = 0
        Dim ListOfCategories as List(Of Object)
        ListOfCategories = Await ProductManagementDatabaseModule.GetCategoryList
        ListOfCategories.ToString

        For each Item As String In ListOfCategories

            CategoryComboBox.Items.Add(Item)
        Next

        Dim ListofSuppliers as List(Of Object)
        ListofSuppliers = Await ProductManagementDatabaseModule.GetSupplierList
        ListofSuppliers.ToString

        For each item As String In ListofSuppliers

            SupplierComboBox.Items.Add(item)

        Next

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Async Sub CategoryComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CategoryComboBox.SelectedIndexChanged

        Variables.ProductCategory = Await ProductManagementDatabaseModule.GetCategoryId(CategoryComboBox.SelectedItem)

    End Sub

    Private Sub CategoryComboBox_TextChanged(sender As Object, e As EventArgs) Handles CategoryComboBox.TextChanged

        If String.IsNullOrEmpty(CategoryComboBox.Text) Then

            Label2.Show

        Else

            Label2.Hide

        End If

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

        CategoryComboBox.Focus

    End Sub

    Private Sub CapitalTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CapitalTextBox.KeyPress

        GeneralModule.CheckDemicalNumber(e, CapitalTextBox)

    End Sub

    Private Sub WholesalePriceTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles WholesalePriceTextBox.KeyPress

        GeneralModule.CheckDemicalNumber(e, WholesalePriceTextBox)

    End Sub

    Private Sub RetailPriceTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RetailPriceTextBox.KeyPress

        GeneralModule.CheckDemicalNumber(e, RetailPriceTextBox)

    End Sub

    Private Sub MinStockTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MinStockTextBox.KeyPress

        GeneralModule.CheckDemicalNumber(e, MinStockTextBox)

    End Sub

    Private Sub MaxStockTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MaxStockTextBox.KeyPress

        GeneralModule.CheckDemicalNumber(e, MaxStockTextBox)

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

        SupplierComboBox.Focus

    End Sub

    Private Async Sub SupplierComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SupplierComboBox.SelectedIndexChanged

        Variables.Supplier = Await ProductManagementDatabaseModule.GetSupplierId(SupplierComboBox.SelectedItem)

    End Sub

    Private Sub SupplierComboBox_TextChanged(sender As Object, e As EventArgs) Handles SupplierComboBox.TextChanged

        If String.IsNullOrEmpty(SupplierComboBox.Text) Then

            Label18.Show

        Else

            Label18.Hide

        End If

    End Sub

    Private Sub ProductCodeTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ProductCodeTextBox.KeyDown

        If e.KeyCode = Keys.Enter

            If ProductCodeTextBox.Text = CodeCopy.text
                CodeCopy.Text = ""
            End If
            CodeCopy.Text = ProductCodeTextBox.Text

            CodeCopy.PerformClick

        End If

    End Sub

    Private Sub CodeCopy_TextChanged(sender As Object, e As EventArgs) Handles CodeCopy.TextChanged

        If Not String.IsNullOrEmpty(CodeCopy.Text)

            ProductCodeTextBox.Clear

        End If

    End Sub

    Private Sub CodeCopy_Click(sender As Object, e As EventArgs) Handles CodeCopy.Click

        ProductCodeTextBox.text = CodeCopy.Text
        ProductCodeTextBox.Focus

    End Sub

    Private Sub MaxStockTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles DescriptionTextBox.KeyDown, ProductNameTextBox.KeyDown, CategoryComboBox.KeyDown, MaxStockTextBox.KeyDown, MinStockTextBox.KeyDown, SupplierComboBox.KeyDown, RetailPriceTextBox.KeyDown, WholesalePriceTextBox.KeyDown, CapitalTextBox.KeyDown

        If e.KeyCode = Keys.Enter

            NextButton.PerformClick

        End If

        If e.KeyCode = Keys.Escape

            ShadowButton.PerformClick

        End If

    End Sub

    Private Sub DescriptionTextBox_TextChanged(sender As Object, e As EventArgs) Handles DescriptionTextBox.TextChanged

        Variables.ProductDescription = DescriptionTextBox.Text

    End Sub

    Private Sub AddCategoryButton_Click(sender As Object, e As EventArgs) Handles AddCategoryButton.Click

        AddCategory.IsCategory = True
        Hide
        AddCategory.Opacity = 0
        CategoryComboBox.Items.Clear
        GeneralModule.ShowOverlay(MainForm, AddCategory)

    End Sub

    Private Sub AddSupplierButton_Click(sender As Object, e As EventArgs) Handles AddSupplierButton.Click

        AddCategory.IsCategory = False
        Hide
        AddCategory.Opacity = 0
        SupplierComboBox.Items.Clear
        GeneralModule.ShowOverlay(MainForm, AddCategory)

    End Sub

End Class