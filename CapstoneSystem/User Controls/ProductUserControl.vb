Imports System.Xml

Public Class ProductUserControl

    Dim ClickElipse As Integer = 0
    Private Sub ItemInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ItemPriceLabel.Left = ElipseLabel.Left - (ItemPriceLabel.Width + 10)

    End Sub

    Private Sub ItemPriceLabel_MouseEnter(sender As Object, e As EventArgs) Handles ItemPriceLabel.MouseEnter, CategoryProductCodeLabel.MouseEnter, ProductNameLabel.MouseEnter, PlaceholderImage.MouseEnter, MyBase.MouseEnter

        GeneralModule.UserControlToButton(Me, 210)

    End Sub

    Private Sub ProductUserControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave

        GeneralModule.UserControlToButton(Me, 247)

    End Sub

    Private Sub ItemPriceLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles ItemPriceLabel.MouseDown, CategoryProductCodeLabel.MouseDown, ProductNameLabel.MouseDown, PlaceholderImage.MouseDown, MyBase.MouseDown

        GeneralModule.UserControlToButton(Me, 147)

    End Sub

    Private Async Sub ItemPriceLabel_Click(sender As Object, e As EventArgs) Handles ItemPriceLabel.Click, CategoryProductCodeLabel.Click, ProductNameLabel.Click, PlaceholderImage.Click, MyBase.Click

        ProductInfo.Opacity = 0
        Dim productIndex As Integer = Variables.ListOfProductId.IndexOf(Integer.Parse(ProductIdLabel.Text))

        If productIndex >= 0 Then
            
            If Variables.ListOfProductImage(productIndex) IsNot Nothing Then
                Using ms As New IO.MemoryStream(Variables.ListOfProductImage(productIndex))
                    ProductImage.ProductImagePictureBox.Image = Image.FromStream(ms)
                End Using
            End If

            ProductInfo.ProductNameTextBox.Text = Variables.ListOfProductName(productIndex)
            ProductInfo.CategoryTextBox.Text = Await ProductManagementDatabaseModule.GetCategory(Variables.ListOfProductCategory(productIndex))
            ProductInfo.SupplierTextBox.Text = Await ProductManagementDatabaseModule.GetSupplier(Variables.ListOfProductSupplier(productIndex))
            ProductInfo.CapitalTextBox.Text = "₱ " & Variables.ListOfProductCapital(productIndex)
            ProductInfo.WholesaleTextBox.Text = "₱ " & Variables.ListOfProductWholeSalePrice(productIndex)
            ProductInfo.RetailTextBox.Text = "₱ " & Variables.ListOfProductRetailPrice(productIndex)
            ProductInfo.MinStockTextBox.Text = Variables.ListOfProductMinStock(productIndex) & " Stocks"
            ProductInfo.MaxStockTextBox.Text = Variables.ListOfProductMaxStock(productIndex) & " Stocks"
            ProductInfo.DateAddedTextBox.Text = Variables.ListOfProductDateAdded(productIndex)
            ProductInfo.TimeAddedTextBox.Text = Variables.ListOfProductTimeAdded(productIndex)
            ProductInfo.AddedByTextBox.Text = Await ProductManagementDatabaseModule.GetAddedBy(Variables.ListOfProductAddedBy(productIndex))
            
            ProductInfo.BarcodeText = Variables.ListOfProductBarcodeSequence(productIndex)
            GeneralModule.ShowOverlay(MainForm, ProductInfo)
            GeneralModule.UserControlToButton(Me, 247)
        Else
            MessageBox.Show("Product ID not found in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ElipseLabel_Click(sender As Object, e As EventArgs) Handles ElipseLabel.Click

        ClickElipse += 1
        Dim ContextLocation = ElipseLabel.PointToScreen(New Point(0, ElipseLabel.Height + 1))

        If ClickElipse Mod 2 = 1 Then ElipseContextMenu.Show(ContextLocation) Else ElipseContextMenu.Hide
        GeneralModule.UserControlToButton(Me, 247)

    End Sub

    Private Sub ElipseLabel_MouseLeave(sender As Object, e As EventArgs) Handles ElipseLabel.MouseLeave

        ElipseLabel.Font = New Font("Inter", 12)

    End Sub

    Private Sub ElipseLabel_MouseEnter(sender As Object, e As EventArgs) Handles ElipseLabel.MouseEnter

        ElipseLabel.Font = New Font("Inter Black", 12)
        GeneralModule.UserControlToButton(Me, 210)

    End Sub

    Private Async Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click

        UpdateProduct.Opacity = 0

        Dim isValidInput As Boolean = False
        Dim userInput As String

        Do
            userInput = InputBox("Enter the number you want to update." & vbCrLf &
                                 "1. Product Name" & vbCrLf &
                                 "2. Category" & vbCrLf & "3. Product Code" & vbCrLf & "4. Description" &
                                 vbCrLf & "5. Capital" & vbCrLf & "6. Wholesale Price" & vbCrLf &
                                 "7. Retail Price" & vbCrLf & "8. Minimum Stock Level" & vbCrLf &
                                 "9. Maximum Stock Level" & vbCrLf & "10. Supplier", "Updating Product")

            If String.IsNullOrEmpty(userInput) Then
                MessageBox.Show("No input provided. Exiting...", "Input Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If IsNumeric(userInput) AndAlso Integer.TryParse(userInput, Nothing) Then
                Dim inputNumber As Integer = Integer.Parse(userInput)

                If inputNumber >= 1 AndAlso inputNumber <= 11 Then
                    isValidInput = True
                ElseIf inputNumber > 11 Then
                    MessageBox.Show("The number entered is greater than 11. Exiting...", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Else
                MessageBox.Show("Please enter a valid numeric value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Loop Until isValidInput

        Dim productIndex As Integer = Variables.ListOfProductId.IndexOf(Integer.Parse(ProductIdLabel.Text))

        Dim comboBoxItem as New List(Of Object)

        If userInput = 2 OrElse userInput = 10

            UpdateProduct.newComboBoxGroupBox.show
            UpdateProduct.newGroupBox.Hide

        Else

            UpdateProduct.newGroupBox.show
            UpdateProduct.newComboBoxGroupBox.Hide

        End If

        If userInput = 2

            UpdateProduct.Label3.text = "Choose New Category"
            UpdateProduct.LABEL8.text = "Confirm Category"
            comboBoxItem = Await ProductManagementDatabaseModule.GetCategoryList
            comboBoxItem.ToString

        End If

        If userInput = 10

            UpdateProduct.Label3.text = "Choose New Supplier"
            UpdateProduct.LABEL8.text = "Confirm Supplier"
            comboBoxItem = Await ProductManagementDatabaseModule.GetSupplierList
            comboBoxItem.ToString

        End If

        For each Item As String In comboBoxItem

            UpdateProduct.NewComboBox.Items.Add(Item)

        Next

        For each Item As String In comboBoxItem

            UpdateProduct.confirmComboBox.Items.Add(Item)

        Next

        If userInput = 1

            UpdateProduct.Label5.Text = "Product Name"
            UpdateProduct.InfoTextBox.Text = Variables.ListOfProductName(productIndex)
            UpdateProduct.tableName = "product_name"

        ElseIf userInput = 2

            UpdateProduct.Label5.Text = "Category"
            UpdateProduct.InfoTextBox.Text = Await ProductManagementDatabaseModule.GetCategory(Variables.ListOfProductCategory(productIndex))
            UpdateProduct.tableName = "category_id"

        ElseIf userInput = 3

            UpdateProduct.Label5.Text = "Product Code"
            UpdateProduct.InfoTextBox.Text = Variables.ListOfProductBarcodeSequence(productIndex)
            UpdateProduct.tableName = "barcode_sequence"

        ElseIf userInput = 4

            UpdateProduct.Label5.Text = "Description"
            UpdateProduct.InfoTextBox.Text = Variables.ListOfProductDescription(productIndex)
            UpdateProduct.tableName = "description"

        ElseIf userInput = 5

            UpdateProduct.Label5.Text = "Capital"
            UpdateProduct.InfoTextBox.Text = Variables.ListOfProductCapital(productIndex)
            UpdateProduct.tableName = "capital"

        ElseIf userInput = 6

            UpdateProduct.Label5.Text = "Whole Sale"
            UpdateProduct.InfoTextBox.Text = Variables.ListOfProductWholeSalePrice(productIndex)
            UpdateProduct.tableName = "wholesale_price"

        ElseIf userInput = 7

            UpdateProduct.Label5.Text = "Retail Price"
            UpdateProduct.InfoTextBox.Text = Variables.ListOfProductRetailPrice(productIndex)
            UpdateProduct.tableName = "retail_selling_price"

        ElseIf userInput = 8

            UpdateProduct.Label5.Text = "Min Stock Level"
            UpdateProduct.InfoTextBox.Text = Variables.ListOfProductMinStock(productIndex)
            UpdateProduct.tableName = "min_stock_level"

        ElseIf userInput = 9

            UpdateProduct.Label5.Text = "Max Stock Level"
            UpdateProduct.InfoTextBox.Text = Variables.ListOfProductMaxStock(productIndex)
            UpdateProduct.tableName = "max_stock_level"

        ElseIf userInput = 10

            UpdateProduct.Label5.Text = "Supplier"
            UpdateProduct.InfoTextBox.Text = Await ProductManagementDatabaseModule.GetSupplier(Variables.ListOfProductSupplier(productIndex))
            UpdateProduct.tableName = "supplier_id"

        End If

        UpdateProduct.ProductIdLabel.Text = ProductIdLabel.Text
        GeneralModule.ShowOverlay(MainForm, UpdateProduct)

    End Sub

    Private Sub RestockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestockToolStripMenuItem.Click

        StockEntry.Opacity = 0
        StockEntry.ProductNameStockEntry = ProductNameLabel.Text
        StockEntry.ProductComboBox.SelectedItem = ProductName
        GeneralModule.ShowOverlay(MainForm, StockEntry)

        If StockManagement.FormPanel.Controls.OfType(Of StockUserControl).Any

            StockManagement.Label4.Hide
            StockManagement.Label3.show
            StockManagement.Label3.Text = StockManagement.FormPanel.Controls.OfType(Of StockUserControl).Count & " stock found"

        Else

            StockManagement.Label4.Show
            StockManagement.Label3.Hide

        End If

        If InventoryTransactions.FormPanel.Controls.OfType(Of InventoryTransactionUserControl).Any

            InventoryTransactions.Label1.Hide
            InventoryTransactions.Label3.show
            InventoryTransactions.Label3.Text = InventoryTransactions.FormPanel.Controls.OfType(Of InventoryTransactionUserControl).Count & " Transaction found"

        Else

            InventoryTransactions.Label1.Show
            InventoryTransactions.Label3.Hide

        End If

        ProductManagement.FormPanel.Focus
        ProductManagement.ActiveControl = ProductManagement.FormPanel

    End Sub

    Private Async Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem.Click

        Dim IsInStock As Boolean = Await ProductManagementDatabaseModule.CheckProductStock(ProductIdLabel.Text)

        If IsInStock

            MessageBox.Show("Can not perform this action: Existing batch for this product found!", "Action Prohibited", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        
        Else

            Dim Ans As MsgBoxResult = MessageBox.Show("Are you sure to disable this product?", "Verifying Changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If Ans = MsgBoxResult.Ok
                
                GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
                Await ProductManagementDatabaseModule.UpdateProductStatus(ProductIdLabel.Text)

                Dim ActivityQuery As String = "SELECT * FROM activity ORDER BY activity_id DESC"
                GeneralModule.DeleteUserControls(Activities.FormPanel)
                Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
                Await Activities.CreateActivityUserControl()

                GeneralModule.CloseOverLay(LoadingScreen)
                'TotalActivity = Variables.ListOfActivityId.Count

            ElseIf Ans = MsgBoxResult.Cancel

                Exit Sub

            End If

        End If

    End Sub

End Class
