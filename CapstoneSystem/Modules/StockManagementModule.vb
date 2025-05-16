Imports Microsoft.Data.SqlClient

Module StockManagementModule

    Async Function GetProducts() As Task(Of List(Of Object))

        Dim Products As New List(Of Object)

        'Kuhain yung mga products na wala pa stock management.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT product_name FROM product WHERE active = 1"

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        While Await Reader.ReadAsync

                            Products.Add(Reader("product_name").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Products

    End Function

    Async Function GetWarehouses() As Task(Of List(Of Object))

        Dim Warehouses As New List(Of Object)

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT * FROM warehouse"

                Using Cmd As New SqlCommand(Query, Con)

                    Using Read As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        While Await Read.ReadAsync

                            Dim Warehouse As Object
                            Warehouse = Read("warehouse_name")
                            Warehouses.Add(Warehouse)

                        End While


                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Warehouses

    End Function

    Async Function GetProductId(ProductName As String) As Task(Of Integer)

        Dim ProductId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT product_id FROM product WHERE product_name = @ProductName"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductName", ProductName)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        ProductId = Integer.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return ProductId

    End Function

    Async Function GetWarehouseId(WarehouseName As String) As Task(of Integer)

        Dim WarehouseId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT warehouse_id FROM warehouse WHERE warehouse_name = @WarehouseName"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@WarehouseName", WarehouseName)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing Then WarehouseId = Integer.Parse(Result)

                End Using 

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return WarehouseId

    End Function

    Async Function InsertStock(ProductId As Integer, Batch As String, Expiration As String, CurrentStock As Integer,
                          WarehouseId As Integer, DateAdded As String, TimeAdded As String, AdddedBy As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "INSERT INTO stock VALUES(@ProductId, @Batch, @Expiration, @TotalStocks, @CurrentStock,
                                        @Warehouse, @AddedDate, @TimeAdded, @Status)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)
                    Cmd.Parameters.AddWithValue("@Batch", Batch)
                    Cmd.Parameters.AddWithValue("@Expiration", Expiration)
                    Cmd.Parameters.AddWithValue("@TotalStocks", CurrentStock)
                    Cmd.Parameters.AddWithValue("@CurrentStock", CurrentStock)
                    Cmd.Parameters.AddWithValue("@Warehouse", WarehouseId)
                    Cmd.Parameters.AddWithValue("@AddedDate", DateAdded)
                    Cmd.Parameters.AddWithValue("@TimeAdded", TimeAdded)
                    Cmd.Parameters.AddWithValue("@Status", 1)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    If RowsAffected > 0

                        Await InventoryTransactionDatabaseModule.InsertIntoTransaction(Await InventoryTransactionDatabaseModule.GetStockId(), "Added", CurrentStock, DateAdded, TimeAdded, AdddedBy, ProductId)

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

                        GeneralModule.ClearStockList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListOfStockProductId.add(Integer.Parse(Reader("product_id")))
                            Variables.ListOfBatchCode.Add(Reader("batch_code").ToString())
                            Variables.ListOfExpiration.Add(Reader("expiration_date").ToString())
                            Variables.ListOfCurrentStock.Add(Integer.Parse(Reader("current_stock")))
                            Variables.ListOfWarehouse.Add(Integer.Parse(Reader("warehouse_id")))
                            Variables.ListOfStockDateAdded.Add(Reader("date_added").ToString())
                            Variables.ListOfStockTimeAdded.Add(Reader("time_added").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function


    Async Function GetProductName(ProductId As Integer) As Task(Of String)

        Dim ProductName As String = String.Empty

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT product_name FROM product WHERE product_id = @ProductId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        ProductName = Result.ToString

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return ProductName

    End Function

    Async Function GetProductImage(ProductId As Integer) As Task(Of Byte())

        Dim ProductImage As Byte() = Nothing

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT product_image FROM product WHERE product_id = @ProductId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot DBNull.Value AndAlso Result IsNot Nothing Then

                        ProductImage = DirectCast(Result, Byte())

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return ProductImage

    End Function

    Async Function GetWarehouse(WarehouseId As Integer) As Task(Of String)

        Dim WarehouseName As String = String.Empty

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT warehouse_name FROM warehouse WHERE warehouse_id = @WarehouseId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@WarehouseId", WarehouseId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        WarehouseName = Result.ToString

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return WarehouseName

    End Function

    Async Function SearchByProductName(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query naman ng product by name. gamit 'to sa search field.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        Variables.SearchByStockId.Clear
                        Variables.SearchByStockProductId.Clear
                        Variables.SearchBatchCode.Clear
                        Variables.SearchCurrentStock.clear

                        While Await Reader.ReadAsync

                            Variables.SearchByStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.SearchByStockProductId.add(Integer.Parse(Reader("product_id")))
                            Variables.SearchBatchCode.add(Reader("batch_code").ToString())
                            Variables.SearchCurrentStock.Add(Integer.Parse(Reader("current_stock")))
                            'Variables.SearchByStockName.Add(Reader(Await GetProductName("product_id")).ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function GetCurrentStock(StockId As Integer) As Task(Of Integer)

        Dim CurrentStock As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT current_stock FROM stock WHERE stock_id = @StockId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        CurrentStock = Integer.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return CurrentStock

    End Function

    Async Function GetTotalStock(StockId As Integer) As Task(Of Integer)

        Dim CurrentStock As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT total_stock FROM stock WHERE stock_id = @StockId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        CurrentStock = Integer.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return CurrentStock

    End Function

    Async Function GetCurrentStockProductId(ProductId As Integer) As Task(Of Integer)

        Dim CurrentStock As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT SUM(current_stock) FROM stock WHERE product_id = @ProductId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        CurrentStock = Integer.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return CurrentStock

    End Function

    Async Function GetExpiration(StockId As Integer) As Task(Of String)

        Dim Expiration As String = String.Empty

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT expiration_date FROM stock WHERE stock_id = @StockId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        Expiration = Result.ToString

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Expiration

    End Function

    Async Function GetWarehouseFromStock(StockId As Integer) As Task(Of String)

        Dim WarehouseId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT warehouse_id FROM stock WHERE stock_id = @StockId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        WarehouseId = Result.ToString

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return WarehouseId

    End Function

    Async Function GetBarcode(ProductId As Integer) As Task(Of String)

        Dim BarcodeSequence As String = String.Empty

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT barcode_sequence FROM product WHERE product_id = @ProductId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        BarcodeSequence = Result.ToString

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return BarcodeSequence

    End Function

    Async Function GetBatchFromStock(StockId As Integer) As Task(Of String)

        Dim StockBatch As String = String.Empty

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT batch_code FROM stock WHERE stock_id = @StockId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        StockBatch = Result.ToString

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return StockBatch

    End Function

    Async Function RetrieveStockBy1Filter(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query ng product sa product table by 1 filter.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearStockList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListOfStockProductId.add(Integer.Parse(Reader("product_id")))
                            Variables.ListOfBatchCode.Add(Reader("batch_code").ToString())
                            Variables.ListOfExpiration.Add(Reader("expiration_date").ToString())
                            Variables.ListOfCurrentStock.add(Integer.Parse(Reader("current_stock")))
                            Variables.ListOfWarehouse.add(Integer.Parse(Reader("warehouse_id")))
                            Variables.ListOfStockDateAdded.add(Reader("date_added").ToString())
                            Variables.ListOfStockTimeAdded.add(Reader("time_added").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrievePStockBy2Filter(Query As String, ParameterName As String, ParameterValue As Integer,
                                 Parameter2Name As String, Parameter2Value As String) As Task

        'Query ng product sa table gamit yung 2 filter.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)
                    Cmd.Parameters.AddWithValue(Parameter2Name, Parameter2Value)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        GeneralModule.ClearStockList()

                        While Await Reader.ReadAsync

                            Variables.ListOfStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListOfStockProductId.add(Integer.Parse(Reader("product_id")))
                            Variables.ListOfBatchCode.Add(Reader("batch_code").ToString())
                            Variables.ListOfExpiration.Add(Reader("expiration_date").ToString())
                            Variables.ListOfCurrentStock.add(Integer.Parse(Reader("current_stock")))
                            Variables.ListOfWarehouse.add(Integer.Parse(Reader("warehouse_id")))
                            Variables.ListOfStockDateAdded.add(Reader("date_added").ToString())
                            Variables.ListOfStockTimeAdded.add(Reader("time_added").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function


    Async Function GetNextBatchNumber(ProductCode As String) As Task(Of Integer)

        Dim NextBatchNumber As Integer = 1 ' Default to 1 if no batches are found.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' Query to extract the numeric part after "BTCH" and find the maximum value.
                Dim Query As String = "
                    SELECT MAX(CAST(SUBSTRING(batch_code, CHARINDEX('BTCH', batch_code) + 4, LEN(batch_code) - CHARINDEX('BTCH', batch_code) - 3) AS INT))
                    FROM stock
                    WHERE batch_code LIKE @ProductCode + '%'
                "

                Using Cmd As New SqlCommand(Query, Con)
                    Cmd.Parameters.AddWithValue("@ProductCode", ProductCode)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot DBNull.Value AndAlso Result IsNot Nothing Then
                        NextBatchNumber = Convert.ToInt32(Result) + 1 ' Increment the highest batch number.
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return NextBatchNumber

    End Function


    Async Function GetProductsFromStock() As Task(Of List(Of Object))

        Dim Products As New List(Of Object)

        'Kuhain yung mga products na wala pa stock management.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT p.product_name FROM product p WHERE p.product_id IN (SELECT s.product_id FROM stock s WHERE s.active = 1)"

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        While Await Reader.ReadAsync

                            Products.Add(Reader("product_name").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Products

    End Function

    Async Function GetProductIdByStockId(StockId As Integer) As Task(Of Integer)

        Dim ProductId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT product_id FROM stock WHERE stock_id = @StockId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        ProductId = Integer.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return ProductId

    End Function

    Async Function GetBatches(ProductId As Integer) As Task(Of List(Of Object))

        Dim Batches As New List(Of Object)

        'Kuhain yung mga products na wala pa stock management.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT * FROM stock WHERE product_id = @ProductId AND active = 1"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        While Await Reader.ReadAsync

                            Batches.Add(Reader("batch_code").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Batches

    End Function

    Async Function GetStockIdByBatchcode(BatchCode As String) As Task(Of String)

        Dim StockId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT stock_id FROM stock WHERE batch_code = @BatchCode"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@BatchCode", BatchCode)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        StockId = Integer.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return StockId

    End Function

    Async Function GetStockIdByProductID(ProductId As Integer) As Task(Of Integer)

        Dim StockId As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT stock_id FROM stock WHERE product_id = @ProductId"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim Result = Await Cmd.ExecuteScalarAsync()

                    If Result IsNot Nothing

                        StockId = Integer.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return StockId

    End Function

    Async Function DoesStockExist(ProductCode As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT COUNT(*) FROM stock WHERE batch_code LIKE @ProductCode AND active = 1"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = $"%{ProductCode}%"

                    Dim Count As Integer = Convert.ToInt32(Await Cmd.ExecuteScalarAsync())
                    Exists = Count > 0

                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return Exists

    End Function

    Async Function IsStockAboutToExpire(StockId As Integer) As Task(Of Boolean)

        Dim isAboutToExpire As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim query As String = "
                    SELECT CASE 
                        WHEN COUNT(*) > 0 THEN 1 
                        ELSE 0 
                    END
                    FROM stock
                    WHERE 
                        stock_id = @StockId
                        AND expiration_date BETWEEN CAST(GETDATE() AS DATE) 
                        AND CAST(DATEADD(WEEK, 1, GETDATE()) AS DATE)
                        AND active = 1
                "

                Using cmd As New SqlCommand(query, Con)

                    cmd.Parameters.AddWithValue("@StockId", StockId)
                    ' Execute the query to check if the product is about to expire
                    isAboutToExpire = Convert.ToBoolean(Await cmd.ExecuteScalarAsync())
                
                End Using

            Catch ex As Exception
                
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return isAboutToExpire

    End Function

    Async Function IsStockExpired(StockId As Integer) As Task(Of Boolean)

        Dim isExpired As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim query As String = "
                    SELECT CASE 
                        WHEN COUNT(*) > 0 THEN 1 
                        ELSE 0 
                    END
                    FROM stock
                    WHERE 
                        stock_id = @StockId
                        AND expiration_date < CAST(GETDATE() AS DATE)
                        AND active = 1
                "

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.AddWithValue("@StockId", StockId)
                    ' Execute the query to check if the product has expired
                    isExpired = Convert.ToBoolean(Await cmd.ExecuteScalarAsync())
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return isExpired

    End Function

    Public Async Function UpdateStockInfo(TableName As String, Value As String, StockId As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim UpdateQuery As String = $"UPDATE stock SET {TableName} = @Value WHERE stock_id = @StockId"

                Using UpdateCmd As New SqlCommand(UpdateQuery, Con)
                    UpdateCmd.Parameters.AddWithValue("@Value", Value)
                    UpdateCmd.Parameters.AddWithValue("@StockId", StockId)

                    Dim rowsAffected As Integer = Await UpdateCmd.ExecuteNonQueryAsync()

                    If rowsAffected > 0 Then

                        Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
                        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
                        Dim ProductName As String = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))

                        If TableName = "expiration_date"

                            Await ActivityDatabaseModule.InsertActivity("Changes", AddedBy, "stock", DateAdded, TimeAdded, $"Update ({ProductName}) - Expiration Date Change to {Value}")

                        ElseIf TableName = "current_stock"

                            Await ActivityDatabaseModule.InsertActivity("Changes", AddedBy, "stock", DateAdded, TimeAdded, $"Update ({ProductName}) - Change batch quantity to {Value}")

                        ElseIf TableName = "warehouse_id"

                            Dim WarehouseName As String = Await StockManagementModule.GetWarehouse(Value)
                            Await ActivityDatabaseModule.InsertActivity("Changes", AddedBy, "stock", DateAdded, TimeAdded, $"Update ({ProductName}) - Change batch warehouse to {WarehouseName}")
        
                        End If
                        
                        UpdateStock.ShadowButton.PerformClick()
                        ChooseUpdate.ShadowButton.PerformClick()
                        StockManagement.ClearAllFiltersButton.PerformClick()

                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

    End Function

    Public Async Function DeleteStock(StockId As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim DeleteQuery As String = "DELETE FROM stock WHERE stock_id = @StockId"

                Using DeleteCmd As New SqlCommand(DeleteQuery, Con)
                    DeleteCmd.Parameters.AddWithValue("@StockId", StockId)

                    Dim rowsAffected As Integer = Await DeleteCmd.ExecuteNonQueryAsync()

                    If rowsAffected > 0 Then

                        Dim AddedBy As Integer = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
                        Dim DateDeleted As String = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                        Dim TimeDeleted As String = Variables.CurrrentDate.ToString("t")
                        Dim ProductName As String = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))
                        Dim BatchName As String = Await StockManagementModule.GetBatchFromStock(StockId)

                        Await ActivityDatabaseModule.InsertActivity("Delete Stock", AddedBy, "stock", DateDeleted, TimeDeleted, $"Deleted a batch ({BatchName}) of product {ProductName}")

                        StockManagement.ClearAllFiltersButton.PerformClick()
                    Else
                        MessageBox.Show("No stock entry found with the specified ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

    End Function


End Module
