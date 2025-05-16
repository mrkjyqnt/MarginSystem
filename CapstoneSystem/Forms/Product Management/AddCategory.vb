Public Class AddCategory

    Public IsCategory As Boolean = False
    Public IsWarehouse As Boolean = False

    Private Async Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        If IsCategory And Not IsWarehouse

            Dim ListOfCategories as List(Of Object)
            ListOfCategories = Await ProductManagementDatabaseModule.GetCategoryList
            ListOfCategories.ToString

            For each Item As String In ListOfCategories

                AddNewProduct.CategoryComboBox.Items.Add(Item)

            Next

            Hide
            AddNewProduct.Show

        ElseIf Not IsCategory And Not IsWarehouse

            Dim ListofSuppliers as List(Of Object)
            ListofSuppliers = Await ProductManagementDatabaseModule.GetSupplierList
            ListofSuppliers.ToString

            For each item As String In ListofSuppliers

                AddNewProduct.SupplierComboBox.Items.Add(item)

            Next

            Hide
            AddNewProduct.Show

        ElseIf IsWarehouse And Not IsCategory

            Dim ListOfWarehouse As List(Of Object)
            ListOfWarehouse = Await StockManagementModule.GetWarehouses()
            ListOfWarehouse.ToString

            For Each Item As String In ListOfWarehouse

                StockEntry.WarehouseComboBox.Items.Add(Item)


            Next

            Hide
            StockEntry.Show

        End If

    End Sub

    Private Async Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click

        If IsCategory And Not IsWarehouse

            Dim Exist As Boolean = Await ProductManagementDatabaseModule.IscategoryExists(CategoryTextBox.Text)

            If Exist

                MessageBox.Show("Category is already available", "Invalid Category", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CategoryTextBox.Clear
                CategoryTextBox.Focus
                Exit Sub

            Else

                Await ProductManagementDatabaseModule.InsertCategory(CategoryTextBox.Text)
                CategoryTextBox.Clear
                CategoryTextBox.Focus

            End If

        ElseIf Not IsCategory And Not IsWarehouse

            Dim SupplierExist As Boolean = Await ProductManagementDatabaseModule.IsSupplierExists(CategoryTextBox.Text)

            If SupplierExist

                MessageBox.Show("Supplier is already available", "Invalid Supplier Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CategoryTextBox.Clear
                CategoryTextBox.Focus
                Exit Sub

            Else

                Await ProductManagementDatabaseModule.InsertSupplier(CategoryTextBox.Text)
                CategoryTextBox.Clear
                CategoryTextBox.Focus

            End If

        End IF

        If IsWarehouse And Not IsCategory

            Dim Exist As Boolean = Await ProductManagementDatabaseModule.IsWarehouseExists(CategoryTextBox.Text)

            If Exist

                MessageBox.Show("Warehouse is already available", "Invalid Category", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CategoryTextBox.Clear
                CategoryTextBox.Focus
                Exit Sub

            Else

                Await ProductManagementDatabaseModule.InsertWarehouse(CategoryTextBox.Text)
                CategoryTextBox.Clear
                CategoryTextBox.Focus

            End If

        End If

    End Sub

    Private Sub AddCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IsCategory

            Label1.Text = "New Category"
            Label8.Text = "Category"
            CategoryTextBox.PlaceholderText = "Category Name"

        Else

            Label1.Text = "New Supplier"
            Label8.Text = "Supplier"
            CategoryTextBox.PlaceholderText = "Supplier Name"

        End If

        If IsWarehouse

            Label1.Text = "New Warehouse"
            Label8.Text = "Warehouse"
            CategoryTextBox.PlaceholderText = "Warehouse Name"

        End If

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub CategoryTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles CategoryTextBox.KeyDown

        If e.KeyCode = Keys.Enter

            NextButton.PerformClick

        End If

    End Sub
End Class