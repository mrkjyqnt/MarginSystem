Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client.Cache

Module ProductManagementDatabaseModule

    Async Function GetCategoryId(Category As String) As Task(Of Integer)

        'kuhain yung Category Id depende kung anong category pinili nila.

        Dim CategoryId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT category_id FROM category WHERE category_name = @CategoryName"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@CategoryName", Category)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        CategoryId = Result

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try


        End Using

        Return CategoryId

    End Function

    Async Function GetSupplierId(Supplier As String) As Task(of Integer)

        'kuhain yung Supplier Id depende kung sinomng Supplier pinili nila sa combo box.
        'Paulit-ulit nalang?!

        Dim SupplierId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT supplier_id FROM supplier WHERE supplier_name = @supplier_name"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@supplier_name", Supplier)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        SupplierId = Result

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return SupplierId

    End Function

    Async Function GetSupplierList() As Task(of List(Of Object))

        'Ito naman para ma display yung listahan ng Suppliers na nasa database.

        Dim Suppliers As new List(Of Object)

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT * FROM supplier"

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        While Await Reader.ReadAsync

                            Dim SupplierData As Object
                            SupplierData = Reader("supplier_name")
                            Suppliers.Add(SupplierData)

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Suppliers

    End Function

    Async Function GetCategoryList() As Task (Of List(Of Object))

        'Ito yung kukuhain is Category List parehas lang sa Suppliers.

        Dim Categories As New List(Of Object)

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT * FROM category"
                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader  = Await Cmd.ExecuteReaderAsync

                        While Await Reader.ReadAsync

                            Dim CategoriesData As Object
                            CategoriesData = Reader("category_name")
                            Categories.Add(CategoriesData)

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Categories

    End Function

    Async Function GetUserId(Username As String) As Task(of Integer)

        'Kukuhain yung Id ng user.

        Dim UserId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT user_id FROM account WHERE user_name = @user_name"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@user_name", Username)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        UserId = Result

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try


        End Using

        Return UserId

    End Function

    Async Function GetCategory(CategoryId As Integer) As Task(Of String)

        'Para madisplay yung Equivalent na category name depende sa category id. Basahin mo nalang 'wag tanga

        Dim CategoryName As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT category_name FROM category WHERE category_id = @CategoryId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@CategoryId", CategoryId)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        CategoryName  = Result

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return CategoryName

    End Function

    Async Function GetAddedBy(UserId As Integer) As Task(Of String)

        'Parehas lang sa Get Category pero dito user

        Dim AddedBy As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT user_name FROM account WHERE user_id = @UserId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@UserId", UserId)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        AddedBy  = Result

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return AddedBy

    End Function

    Async Function GetSupplier(SupplierId As Integer) As Task(Of String)

        'Ito naman sa supplier.

        Dim SupplierName As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT supplier_name FROM supplier WHERE supplier_id = @SupplierId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@SupplierId", SupplierId)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        SupplierName  = Result

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return SupplierName

    End Function

    Async Function InsertProduct(ProductName As String, ProductImage As Byte(), ProductCategory As Integer,
                  BarcodeSequence As String, Description As String, Capital As Double,
                  WholeSalePrice As Double, RetailSellingPrice As Double, MinStock As Integer, 
                  MaxStock As Integer, Supplier As Integer, DateAdded As String,
                  TimeAdded As String, AddedBy As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim CheckQuery As String = "SELECT COUNT(1) FROM product WHERE barcode_sequence = @BarcodeSequence"

                Using CheckCmd As New SqlCommand(CheckQuery, Con)

                    CheckCmd.Parameters.AddWithValue("@BarcodeSequence", BarcodeSequence)

                    Dim Exists As Integer = CInt(Await CheckCmd.ExecuteScalarAsync())

                    If Exists > 0 Then

                        MessageBox.Show($"The product with barcode '{BarcodeSequence}' already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Function
                    
                    End If

                End Using

                Dim Query As String = "INSERT INTO product VALUES(@ProductName, @ProductImage, @Category,
                                        @BarcodeSequence, @Description, @Capital, @WholeSalePrice, @RetailSellingPrice,
                                        @MinStockLevel, @MaxStockLevel, @Supplier, @DateAdded, @TimeAdded, @AddedBy, @Active)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductName", ProductName)
                    Cmd.Parameters.AddWithValue("@ProductImage", ProductImage)
                    Cmd.Parameters.AddWithValue("@Category", ProductCategory)
                    Cmd.Parameters.AddWithValue("@BarcodeSequence", BarcodeSequence)
                    Cmd.Parameters.AddWithValue("@Description", Description)
                    Cmd.Parameters.AddWithValue("@Capital", Double.Parse(Capital))
                    Cmd.Parameters.AddWithValue("@WholeSalePrice", Double.Parse(WholeSalePrice))
                    Cmd.Parameters.AddWithValue("@RetailSellingPrice", Double.Parse(RetailSellingPrice))
                    Cmd.Parameters.AddWithValue("@MinStockLevel", Integer.Parse(MinStock))
                    Cmd.Parameters.AddWithValue("@MaxStockLevel", Integer.Parse(MaxStock))
                    Cmd.Parameters.AddWithValue("@Supplier", Supplier)
                    Cmd.Parameters.AddWithValue("@DateAdded", DateAdded)
                    Cmd.Parameters.AddWithValue("@TimeAdded", TimeAdded)
                    Cmd.Parameters.AddWithValue("@AddedBy", AddedBy)
                    Cmd.Parameters.AddWithValue("@Active", 1)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    If RowsAffected > 0 Then
                        
                        Await ActivityDatabaseModule.InsertActivity("Add", AddedBy, "product", DateAdded, TimeAdded, $"Add a Product ({BarcodeSequence}) - {ProductName}")
                    
                    End If

                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

    End Function

    Async Function InsertCategory(CategoryName As String) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "INSERT INTO category VALUES(@CategoryName)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@CategoryName", CategoryName)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
                    Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                    Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                    If RowsAffected > 0 Then
                        
                        Await ActivityDatabaseModule.InsertActivity("Add", AddedBy, "category", DateAdded, TimeAdded, $"Add a Category ({CategoryName})")
                    
                    End If

                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

    End Function

    Async Function InsertSupplier(SupplierName As String) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "INSERT INTO supplier VALUES(@SupplierName)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@SupplierName", SupplierName)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
                    Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                    Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                    If RowsAffected > 0 Then
                        
                        Await ActivityDatabaseModule.InsertActivity("Add", AddedBy, "supplier", DateAdded, TimeAdded, $"Add a new Supplier ({SupplierName})")
                    
                    End If

                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

    End Function

    Async Function InsertWarehouse(WarehouseName As String) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "INSERT INTO warehouse VALUES(@WarehouseName)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@WarehouseName", WarehouseName)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
                    Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                    Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                    If RowsAffected > 0 Then
                        
                        Await ActivityDatabaseModule.InsertActivity("Add", AddedBy, "warehouse", DateAdded, TimeAdded, $"Add a new Warehouse ({WarehouseName})")
                    
                    End If

                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

    End Function

    Async Function RetrieveAll(Query As String) As Task

        'Query lahat ng info sa product table sa database.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearProductList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfProductId.add(Integer.Parse(Reader("product_id")))
                            Variables.ListOfProductName.Add(Reader("product_name").ToString())
                            Variables.ListOfProductImage.Add(CType(Reader("product_image"), Byte()))
                            Variables.ListOfProductCategory.Add(Integer.Parse(Reader("category_id")))
                            Variables.ListOfProductBarcodeSequence.Add(Reader("barcode_sequence").ToString())
                            Variables.ListOfProductDescription.Add(Reader("description").ToString())
                            Variables.ListOfProductCapital.Add(Double.Parse(Reader("capital")))
                            Variables.ListOfProductWholeSalePrice.Add(Double.Parse(Reader("wholesale_price")))
                            Variables.ListOfProductRetailPrice.Add(Double.Parse(Reader("retail_selling_price")))
                            Variables.ListOfProductMinStock.Add(Integer.Parse(Reader("min_stock_level")))
                            Variables.ListOfProductMaxStock.Add(Integer.Parse(Reader("max_stock_level")))
                            Variables.ListOfProductSupplier.Add(Integer.Parse(Reader("supplier_id")))
                            Variables.ListOfProductDateAdded.Add(Reader("date_added").ToString())
                            Variables.ListOfProductTimeAdded.Add(Reader("time_added").ToString())
                            Variables.ListOfProductAddedBy.Add(Integer.Parse(Reader("added_by")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrieveProductBy1Filter(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query ng product sa product table by 1 filter.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearProductList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfProductId.add(Integer.Parse(Reader("product_id")))
                            Variables.ListOfProductName.Add(Reader("product_name").ToString())
                            Variables.ListOfProductImage.Add(CType(Reader("product_image"), Byte()))
                            Variables.ListOfProductCategory.Add(Integer.Parse(Reader("category_id")))
                            Variables.ListOfProductBarcodeSequence.Add(Reader("barcode_sequence").ToString())
                            Variables.ListOfProductDescription.Add(Reader("description").ToString())
                            Variables.ListOfProductCapital.Add(Double.Parse(Reader("capital")))
                            Variables.ListOfProductWholeSalePrice.Add(Double.Parse(Reader("wholesale_price")))
                            Variables.ListOfProductRetailPrice.Add(Double.Parse(Reader("retail_selling_price")))
                            Variables.ListOfProductMinStock.Add(Integer.Parse(Reader("min_stock_level")))
                            Variables.ListOfProductMaxStock.Add(Integer.Parse(Reader("max_stock_level")))
                            Variables.ListOfProductSupplier.Add(Integer.Parse(Reader("supplier_id")))
                            Variables.ListOfProductDateAdded.Add(Reader("date_added").ToString())
                            Variables.ListOfProductTimeAdded.Add(Reader("time_added").ToString())
                            Variables.ListOfProductAddedBy.Add(Integer.Parse(Reader("added_by")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrieveProductBy2Filter(Query As String, ParameterName As String, ParameterValue As Integer,
                                 Parameter2Name As String, Parameter2Value As String) As Task

        'Query ng product sa table gamit yung 2 filter.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)
                    Cmd.Parameters.AddWithValue(Parameter2Name, Parameter2Value)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        GeneralModule.ClearProductList()

                        While Await Reader.ReadAsync

                            Variables.ListOfProductId.add(Integer.Parse(Reader("product_id")))
                            Variables.ListOfProductName.Add(Reader("product_name").ToString())
                            Variables.ListOfProductImage.Add(CType(Reader("product_image"), Byte()))
                            Variables.ListOfProductCategory.Add(Integer.Parse(Reader("category_id")))
                            Variables.ListOfProductBarcodeSequence.Add(Reader("barcode_sequence").ToString())
                            Variables.ListOfProductDescription.Add(Reader("description").ToString())
                            Variables.ListOfProductCapital.Add(Double.Parse(Reader("capital")))
                            Variables.ListOfProductWholeSalePrice.Add(Double.Parse(Reader("wholesale_price")))
                            Variables.ListOfProductRetailPrice.Add(Double.Parse(Reader("retail_selling_price")))
                            Variables.ListOfProductMinStock.Add(Integer.Parse(Reader("min_stock_level")))
                            Variables.ListOfProductMaxStock.Add(Integer.Parse(Reader("max_stock_level")))
                            Variables.ListOfProductSupplier.Add(Integer.Parse(Reader("supplier_id")))
                            Variables.ListOfProductDateAdded.Add(Reader("date_added").ToString())
                            Variables.ListOfProductTimeAdded.Add(Reader("time_added").ToString())
                            Variables.ListOfProductAddedBy.Add(Integer.Parse(Reader("added_by")))

                        End While


                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function SearchByProductName(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query naman ng product by name. gamit 'to sa search field.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        Variables.SearchByProductId.Clear
                        Variables.SearchByProductName.Clear
                        Variables.SearchByProductImage.Clear

                        While Await Reader.ReadAsync

                            Variables.SearchByProductId.add(Integer.Parse(Reader("product_id")))
                            Variables.SearchByProductName.Add(Reader("product_name").ToString())
                            Variables.SearchByProductImage.Add(CType(Reader("product_image"), Byte()))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrieveSearchProduct(Query As String, ProductId As Integer) As Task

        'Unlike sa malaking user control dito nag que-query sa product table
        'since may instance na wala sa variable na nag e store ng lahat ng products for malaking user control.
        'yung other details ng product na na-i search.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductID", ProductId)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        While Await Reader.ReadAsync()

                            Dim ImageData As Byte() = If(Reader("product_image"), Nothing)

                            If imageData IsNot Nothing Then
                                Using ms As New IO.MemoryStream(ImageData)
                                    ProductImage.ProductImagePictureBox.Image = Image.FromStream(ms)
                                End Using
                            End If

                            ProductInfo.ProductNameTextBox.Text = Reader("product_name").ToString()
                            ProductInfo.CategoryTextBox.Text = Await ProductManagementDatabaseModule.GetCategory(Reader("category_id").ToString)
                            ProductInfo.SupplierTextBox.Text = Await ProductManagementDatabaseModule.GetSupplier(Reader("supplier_id").ToString)
                            ProductInfo.CapitalTextBox.Text = "₱ " & Reader("capital").ToString()
                            ProductInfo.WholesaleTextBox.Text = "₱ " & Reader("wholesale_price").ToString()
                            ProductInfo.RetailTextBox.Text = "₱ " & Reader("retail_selling_price").ToString()
                            ProductInfo.MinStockTextBox.Text = Reader("min_stock_level").ToString() & " Stocks"
                            ProductInfo.MaxStockTextBox.Text = Reader("max_stock_level").ToString() & " Stocks"
                            ProductInfo.AddedByTextBox.Text = Await ProductManagementDatabaseModule.GetAddedBy(Reader("added_by").ToString())

                            ProductInfo.BarcodeText = Reader("barcode_sequence").ToString()

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function IsProductCodeExists(ProductCode As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT COUNT(*) FROM product WHERE barcode_sequence = @ProductCode AND active = 1"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductCode", ProductCode)

                    Dim Count As Integer = CInt(Await Cmd.ExecuteScalarAsync())
                    Exists = Count > 0

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Exists

    End Function

    Async Function IscategoryExists(CategoryName As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT COUNT(*) FROM category WHERE category_name = @CategoryName"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@CategoryName", CategoryName)

                    Dim Count As Integer = CInt(Await Cmd.ExecuteScalarAsync())
                    Exists = Count > 0

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Exists

    End Function

    Async Function IsWarehouseExists(WarehouseName As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT COUNT(*) FROM warehouse WHERE warehouse_name = @WarehouseName"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@WarehouseName", WarehouseName)

                    Dim Count As Integer = CInt(Await Cmd.ExecuteScalarAsync())
                    Exists = Count > 0

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Exists

    End Function

    Async Function IsSupplierExists(SupplierName As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT COUNT(*) FROM supplier WHERE supplier_name = @SupplierName"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@SupplierName", SupplierName)

                    Dim Count As Integer = CInt(Await Cmd.ExecuteScalarAsync())
                    Exists = Count > 0

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Exists

    End Function

    Public UpdateSuccessul As Boolean = False
    Public QuantitySold As Integer

    Async Function UpdateAndRemoveStock(ProductId As Integer, TotalSales As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT batch_code, current_stock FROM stock WHERE product_id = @ProductId AND active = 1 ORDER BY stock_id"

                Dim StockList As New List(Of Tuple(Of String, Integer)) ' To hold batch_code and current_stock
                Dim TotalStock As Integer = 0 ' To calculate total available stock

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        While Await Reader.ReadAsync()

                            Dim BatchCode As String = Reader("batch_code").ToString()
                            Dim CurrentStock As Integer = Convert.ToInt32(Reader("current_stock"))
                            StockList.Add(New Tuple(Of String, Integer)(BatchCode, CurrentStock))
                            TotalStock += CurrentStock

                        End While

                    End Using

                End Using

                If TotalSales > TotalStock Then

                    UpdateSuccessul = False
                    MessageBox.Show(
                        $"You only have {TotalStock} stocks available for this product." & vbCrLf & "Please provide a valid sale quantity.",
                        "Insufficient Stocks",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    )
                    Exit Function

                End If

                For Each Stock In StockList

                    If TotalSales <= 0 Then Exit For

                    Dim BatchCode As String = Stock.Item1
                    Dim CurrentStock As Integer = Stock.Item2

                    ' Calculate how much stock to deduct from this batch
                    Dim DeductedStock As Integer = Math.Min(CurrentStock, TotalSales)
                    Dim NewStock As Integer = CurrentStock - DeductedStock
                    TotalSales -= DeductedStock ' Reduce TotalSales by the deducted stock

                    ' Update the stock for this batch
                    Dim UpdateQuery As String = "UPDATE stock SET current_stock = @NewStock, active = CASE WHEN @NewStock = 0 THEN 0 ELSE active END WHERE batch_code = @BatchCode"
            
                    Using UpdateCmd As New SqlCommand(UpdateQuery, Con)

                        UpdateCmd.Parameters.AddWithValue("@NewStock", NewStock)
                        UpdateCmd.Parameters.AddWithValue("@BatchCode", BatchCode)
                        Await UpdateCmd.ExecuteNonQueryAsync()

                    End Using

                    ' Insert a transaction record for this batch
                    Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                    Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                    Await InventoryTransactionDatabaseModule.InsertIntoTransaction(
                        Await StockManagementModule.GetStockIdByBatchcode(BatchCode), 
                        "Sold", 
                        DeductedStock, 
                        DateAdded, 
                        TimeAdded, 
                        Variables.AddedBy, 
                        Await StockManagementModule.GetProductIdByStockId(Await StockManagementModule.GetStockIdByBatchcode(BatchCode))
                    )

                Next

            Catch ex As Exception

                UpdateSuccessul = False
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    
            End Try

        End Using

    End Function

    Async Function UpdateSold(BatchCode As String, AvailableStock As Integer, SaleCount As Integer) As Task

        Dim NewStock As Integer = AvailableStock - SaleCount

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim UpdateQuery As String = "UPDATE stock SET current_stock = @NewStock, active = CASE WHEN @NewStock = 0 THEN 0 ELSE active END WHERE batch_code = @BatchCode"
            
                Using UpdateCmd As New SqlCommand(UpdateQuery, Con)

                    UpdateCmd.Parameters.AddWithValue("@NewStock", NewStock)
                    UpdateCmd.Parameters.AddWithValue("@BatchCode", BatchCode)

                    Await UpdateCmd.ExecuteNonQueryAsync()

                End Using

                Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                Await InventoryTransactionDatabaseModule.InsertIntoTransaction(
                    Await StockManagementModule.GetStockIdByBatchcode(BatchCode), 
                    "Sold", 
                    SaleCount, 
                    DateAdded, 
                    TimeAdded, 
                    Variables.AddedBy, 
                    Await StockManagementModule.GetProductIdByStockId(Await StockManagementModule.GetStockIdByBatchcode(BatchCode))
                )

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function GetRetail(ProductId As Integer) As Task(Of Double)

        Dim RetailPrice As Double

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT retail_selling_price FROM product WHERE product_id = @ProductId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        RetailPrice = Double.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return RetailPrice

    End Function

    Async Function GetCapital(ProductId As Integer) As Task(Of Double)

        Dim Capital As Double

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT capital FROM product WHERE product_id = @ProductId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        Capital = Double.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Capital

    End Function

    Async Function GetWholeSale(ProductId As Integer) As Task(Of Double)

        Dim WholesalePrice As Double

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT wholesale_price FROM product WHERE product_id = @ProductId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        WholesalePrice = Double.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return WholesalePrice

    End Function

    Public Async Function CheckProductStock(ProductId As Integer) As Task(Of Boolean)

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim CheckStockQuery As String = "SELECT COUNT(1) FROM stock WHERE product_id = @ProductId AND active = 1"
        
                Using CheckStockCmd As New SqlCommand(CheckStockQuery, Con)
            
                    CheckStockCmd.Parameters.AddWithValue("@ProductId", ProductId)
            
                    Dim result As Integer = Convert.ToInt32(Await CheckStockCmd.ExecuteScalarAsync())
        
                    Return result > 0
        
                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End Try

        End Using

    End Function

    Public Async Function UpdateProductStatus(ProductId As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim UpdateQuery As String = "UPDATE product SET active = 0 WHERE product_id = @ProductId"
            
                Using UpdateCmd As New SqlCommand(UpdateQuery, Con)
                
                    UpdateCmd.Parameters.AddWithValue("@ProductId", ProductId)
                
                    Dim rowsAffected As Integer = Await UpdateCmd.ExecuteNonQueryAsync()
            
                    If rowsAffected > 0 Then

                        Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
                        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                        Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                        Await ActivityDatabaseModule.InsertActivity("Disable", Variables.AddedBy, "product", DateAdded, TimeAdded, $"Disabled a Product {Await StockManagementModule.GetBarcode(ProductId)} Name - {Await StockManagementModule.GetProductName(ProductId)}")
                        ProductManagement.ClearAllFiltersButton.PerformClick

                    End If
            
                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Throw New ApplicationException("An error occurred while updating the product info.", ex)

            End Try

        End Using

    End Function

    Public Async Function UpdateProductInfo(TableName As String, Value As String, ProductId As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim UpdateQuery As String = $"UPDATE product SET {TableName} = @Value WHERE product_id = @ProductId"

                Using UpdateCmd As New SqlCommand(UpdateQuery, Con)
                    UpdateCmd.Parameters.AddWithValue("@Value", Value)
                    UpdateCmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim rowsAffected As Integer = Await UpdateCmd.ExecuteNonQueryAsync()

                    If rowsAffected > 0 Then

                        Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
                        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
                        Dim BarcodeSequence = Await StockManagementModule.GetBarcode(ProductId)
                        Dim ProductName As String = Await StockManagementModule.GetProductName(ProductId)

                        Await ActivityDatabaseModule.InsertActivity("Changes", AddedBy, "product", DateAdded, TimeAdded, $"Update ({BarcodeSequence}) - {ProductName}")
                        UpdateProduct.ShadowButton.PerformClick()
                        ProductManagement.ClearAllFiltersButton.PerformClick()

                        Dim ActivityQuery As String = "SELECT * FROM activity ORDER BY activity_id DESC"
                        GeneralModule.DeleteUserControls(Activities.FormPanel)
                        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
                        Await Activities.CreateActivityUserControl()

                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

    End Function

    Async Function GetProductIdByBarcode(Barcode As String) As Task(Of Integer)

        'kuhain yung Category Id depende kung anong category pinili nila.

        Dim ProductId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT product_id FROM product WHERE barcode_sequence = @BarcodeSequence"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@BarcodeSequence", Barcode)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        ProductId = Result

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try


        End Using

        Return ProductId

    End Function

End Module
