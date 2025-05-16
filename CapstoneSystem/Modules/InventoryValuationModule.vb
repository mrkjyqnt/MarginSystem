Imports Microsoft.Data.SqlClient
Module InventoryValuationModule

    Async Function InsertIntoInventoryValuation(StockId As Integer,  RetailValuation As Double, WholeSaleValuation As Double, 
                                                ExpirationValuation As Double, DateAdded As String, TimeAdded As String, Added As Boolean) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "INSERT INTO inventory_valuation VALUES(@StockId, @RetailValuation, @WholeSaleValuation, 
                                        @ExpirationValuation, @DateAdded, @TimeAdded, @Added)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)
                    Cmd.Parameters.AddWithValue("@RetailValuation", RetailValuation)
                    Cmd.Parameters.AddWithValue("@WholeSaleValuation", WholeSaleValuation)
                    Cmd.Parameters.AddWithValue("@ExpirationValuation", ExpirationValuation)
                    Cmd.Parameters.AddWithValue("@DateAdded", DateAdded)
                    Cmd.Parameters.AddWithValue("@TimeAdded", TimeAdded)
                    Cmd.Parameters.AddWithValue("@Added", Added)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    If RowsAffected > 0
                        
                        If Added

                            MessageBox.Show($"New ({Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))}) batch added", "Successful transactions.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrieveAll(Query As String) As Task

        'Query lahat ng info sa stock transaction table sa database.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearInventoryValuationList()

                        While Await Reader.ReadAsync()

                            Variables.ListofInventoryValuationId.add(Integer.Parse(Reader("inventory_id")))
                            Variables.ListofInventoryValuationStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListofInventoryValuationRetail.Add(Double.Parse(Reader("retail_valuation")))
                            Variables.ListofInventoryValuationWholesale.Add(Double.Parse(Reader("wholesale_valuation")))
                            Variables.ListofInventoryValuationExpiration.Add(Double.Parse(Reader("expiration_valuation")))
                            Variables.ListofInventoryValuationDateAdded.Add(Reader("date_added").ToString)
                            Variables.ListofInventoryValuationTimeAdded.Add(Reader("time_added").ToString)
                            Variables.ListofInventoryValuationAdded.Add(Boolean.Parse(Reader("added")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrieveAllExpiredStock(Query As String) As Task

        'Query lahat ng info sa stock transaction table sa database.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearExpiredStocks()

                        While Await Reader.ReadAsync()

                            Variables.ListofExpiredStockId.add(Integer.Parse(Reader("stock_id")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function CountQuantityExpiredItems() As Task(Of Double)

        Dim total As Integer = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                ' Query to count how many items have already expired
                Dim query As String = "
                    SELECT SUM(current_stock) 
                    FROM stock
                    WHERE 
                        expiration_date < CAST(GETDATE() AS DATE)
                        AND active = 1
                "

                Using cmd As New SqlCommand(query, Con)
                    Dim result = Await cmd.ExecuteScalarAsync()
                
                    total = If(IsDBNull(result), 0, Convert.ToInt32(result))
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return total

    End Function

    Async Function CountQuantityExpiredItemsByProductId(ProductId As Integer) As Task(Of Double)

        Dim total As Integer = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                ' Query to count how many items have already expired
                Dim query As String = "
                    SELECT SUM(current_stock) 
                    FROM stock
                    WHERE 
                        expiration_date < CAST(GETDATE() AS DATE)
                        AND active = 1 AND product_id = @ProductId
                "

                Using cmd As New SqlCommand(query, Con)

                    Cmd.Parameters.AddWithValue("@ProductId", ProductId)
                    Dim result = Await cmd.ExecuteScalarAsync()
                
                    total = If(IsDBNull(result), 0, Convert.ToInt32(result))
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return total

    End Function

    Async Function CheckIfExpiredAlreadyIntheValuation(StockId As Integer) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = "SELECT COUNT(*) FROM inventory_valuation WHERE stock_id = @StockID AND added = 0"

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.Add("@StockID", SqlDbType.Int).Value = StockId

                    Dim count As Integer = Convert.ToInt32(Await cmd.ExecuteScalarAsync())

                    Exists = (count > 0)
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return Exists

    End Function

    Async Function TotalLoss() As Task(Of Double)

        'Count Total Loss

        Dim total As Double = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = "
                    SELECT SUM(p.capital * s.current_stock) AS TotalValue
                    FROM stock s, product p
                    WHERE 
                        s.product_id = p.product_id
                        AND s.expiration_date < CAST(GETDATE() AS DATE)
                        AND s.active = 1
                "

                Using cmd As New SqlCommand(query, Con)
                    Dim result = Await cmd.ExecuteScalarAsync()
                
                    total = If(result IsNot DBNull.Value, Convert.ToDouble(result), 0.0)
                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
           
            End Try

        End Using

        Return total

    End Function

    Async Function TotalLossThisMonth(MonthNumber As Integer) As Task(Of Double)

        'Count Total Loss

        Dim total As Double = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = "
                    SELECT SUM(p.capital * s.current_stock) AS TotalValue
                    FROM stock s
                    INNER JOIN product p ON s.product_id = p.product_id
                    WHERE 
                        s.active = 1
                        AND YEAR(s.expiration_date) = @Year 
                        AND MONTH(s.expiration_date) = @Month
                "

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)
                    cmd.Parameters.AddWithValue("@Month", MonthNumber)
                    Dim result = Await cmd.ExecuteScalarAsync()

                    total = If(result IsNot DBNull.Value, Convert.ToDouble(result), 0.0)
                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return total

    End Function


    Async Function TotalLossPerProduct(ProductId As Integer) As Task(Of Double)

        'Count total loss based on the specified ProductId

        Dim total As Double = 0.0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = "
                    SELECT SUM(p.capital * s.current_stock) AS TotalValue
                    FROM stock s, product p
                    WHERE 
                        s.product_id = p.product_id
                        AND s.expiration_date < CAST(GETDATE() AS DATE)
                        AND s.active = 1
                        AND s.product_id = @ProductId
                "

                Using cmd As New SqlCommand(query, Con)

                    cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    total = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToDouble(result), 0.0)

                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return total

    End Function

    Async Function SearchByProductName(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query naman ng product by name. gamit 'to sa search field.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        Variables.SearchByValuationId.Clear
                        Variables.SearchByValuationStockId.Clear
                        Variables.SearchByRetailValuation.Clear
                        Variables.SearchByExpirationValuation.Clear

                        While Await Reader.ReadAsync

                            Variables.SearchByValuationId.add(Integer.Parse(Reader("inventory_id")))
                            Variables.SearchByValuationStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.SearchByRetailValuation.add(Reader("retail_valuation").ToString())
                            Variables.SearchByExpirationValuation.Add(Reader("expiration_valuation").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function SumExpiredItemsThisMonth(MonthNumber As Integer) As Task(Of Integer)

        Dim total As Integer = 0

        Try
            Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
                ' Query to count expired items for the given month and year
                Dim query As String = "
                    SELECT SUM(current_stock) 
                    FROM stock
                    WHERE 
                        MONTH(expiration_date) = @Month 
                        AND YEAR(expiration_date) = @Year
                        AND active = 1
                        AND expiration_date < GETDATE()
                "

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthNumber
                    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = Variables.CurrentYear

                    Dim result = Await cmd.ExecuteScalarAsync()
                    total = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToInt32(result), 0)
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return total

    End Function

    Async Function DoesValuationExist(ProductCode As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT COUNT(*) " &
                                       "FROM inventory_valuation t " &
                                       "WHERE t.stock_id IN (" &
                                       "SELECT s.stock_id FROM stock s " &
                                       "WHERE s.batch_code LIKE @ProductCode)"

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

    Async Function RetrieveValuationBy1Filter(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query ng product sa product table by 1 filter.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearInventoryValuationList()

                        While Await Reader.ReadAsync()

                            Variables.ListofInventoryValuationId.add(Integer.Parse(Reader("inventory_id")))
                            Variables.ListofInventoryValuationStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListofInventoryValuationRetail.Add(Double.Parse(Reader("retail_valuation")))
                            Variables.ListofInventoryValuationWholesale.Add(Double.Parse(Reader("wholesale_valuation")))
                            Variables.ListofInventoryValuationExpiration.Add(Double.Parse(Reader("expiration_valuation")))
                            Variables.ListofInventoryValuationDateAdded.Add(Reader("date_added").ToString)
                            Variables.ListofInventoryValuationTimeAdded.Add(Reader("time_added").ToString)
                            Variables.ListofInventoryValuationAdded.Add(Boolean.Parse(Reader("added")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

End Module
