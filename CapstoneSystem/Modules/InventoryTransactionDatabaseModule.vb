Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports Microsoft.Data.SqlClient

Module InventoryTransactionDatabaseModule

    Async Function InsertIntoTransaction(StockId As Integer, TransactionType As String, Quantity As Integer,
                                         TransactionDate As String,TransactionTime As String, ActionBy As String,
                                         ProductId As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "INSERT INTO stock_transaction VALUES(@StockId, @TransactionType, @Quantity,
                                        @TransactionDate, @TransactionTime, @ActionBy)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)
                    Cmd.Parameters.AddWithValue("@TransactionType", TransactionType)
                    Cmd.Parameters.AddWithValue("@Quantity", Quantity)
                    Cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate)
                    Cmd.Parameters.AddWithValue("@TransactionTime", TransactionTime)
                    Cmd.Parameters.AddWithValue("@ActionBy", ActionBy)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    If RowsAffected > 0

                        If TransactionType = "Added"

                            Await InventoryValuationModule.InsertIntoInventoryValuation(StockId, Quantity * Await ProductManagementDatabaseModule.GetRetail(ProductId), Quantity * Await ProductManagementDatabaseModule.GetWholeSale(ProductId), 0, TransactionDate, TransactionTime, True)

                        ElseIf TransactionType = "Sold"

                            Await SaleValuationModule.InsertIntoSale(StockId, Quantity, RecordSale.ItemPrice, (Await ProductManagementDatabaseModule.GetCapital(ProductId) * Quantity), TransactionDate, TransactionTime)

                        End If

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function GetStockId() As Task(Of Integer)

        Dim Total As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT TOP 1 stock_id FROM stock ORDER BY stock_id DESC"

                Using Cmd As New SqlCommand(Query, Con)
                    
                    Total = CInt(Await Cmd.ExecuteScalarAsync())

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Total

    End Function

    Async Function RetrieveAll(Query As String) As Task

        'Query lahat ng info sa stock transaction table sa database.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearInventoryTransactionList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfTransactionId.add(Integer.Parse(Reader("transaction_id")))
                            Variables.ListOfTransactionStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListOfTransactionName.Add(Reader("transaction_type").ToString())
                            Variables.ListOfTransactionQuantity.Add(Integer.Parse(Reader("quantity")))
                            Variables.ListOfTransactionDate.Add(Reader("transaction_date").ToString())
                            Variables.ListOfTransactionTime.Add(Reader("transaction_time").ToString())
                            Variables.ListOfTransactionActionBy.Add(Integer.Parse(Reader("action_by")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function GetProductCode(StockId As Integer) As Task(Of String)

        Dim ProductCode As String = String.Empty

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT barcode_sequence FROM product WHERE product_id IN(SELECT product_id FROM stock WHERE stock_id = @StockId)"
                
                Using Cmd As New SqlCommand(Query, Con)
                    
                    Cmd.Parameters.AddWithValue("@StockId", StockId)
                    
                    Dim Result = Await Cmd.ExecuteScalarAsync()
                    
                    If Result IsNot Nothing
                        
                        ProductCode = Result.ToString
                    
                    End If
                
                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return ProductCode

    End Function

    Async Function CheckIfDataExist(TableName As String, ColumnName As String,
                                    Parameter As String, Value As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = $"SELECT COUNT(1) FROM {TableName} WHERE {ColumnName} = @{Parameter}"

                Using cmd As New SqlCommand(query, Con)

                    cmd.Parameters.AddWithValue($"@{Parameter}", Value)

                    Dim result As Integer = Convert.ToInt32(Await cmd.ExecuteScalarAsync())

                    'If result is greater than 0, which product exists
                    Exists = (result > 0)

                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return Exists

    End Function

    Async Function CountValue(TableName As String, ColumnName As String, ParameterValue As String, MonthName As Integer) As Task(Of Integer)

        Dim Total As Integer = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim query As String = $"SELECT SUM(quantity) FROM {TableName} WHERE {ColumnName} = @Value AND YEAR(transaction_date) = @Year AND MONTH(transaction_date) = @Month"

                Using cmd As New SqlCommand(query, Con)

                    cmd.Parameters.AddWithValue("@Value", ParameterValue)
                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)
                    cmd.Parameters.AddWithValue("@Month", MonthName)

                    If Con.State <> ConnectionState.Open Then

                        Await Con.OpenAsync()

                    End If

                    Dim result As Object = Await cmd.ExecuteScalarAsync()
                    Total = If(IsDBNull(result), 0, Convert.ToInt32(result))

                End Using

            Catch ex As SqlException

                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return Total

    End Function

    Async Function CountValueByProductCode(TableName As String, ColumnName As String, ParameterValue As String, StockId As Integer) As Task(Of Integer)

        Dim Total As Integer = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim query As String = $"SELECT SUM(quantity) FROM {TableName} WHERE {ColumnName} = @Value AND stock_id = @StockId AND MONTH(transaction_date) = @Month AND YEAR(transaction_date) = @Year"

                Using cmd As New SqlCommand(query, Con)

                    cmd.Parameters.AddWithValue("@Value", ParameterValue)
                    cmd.Parameters.AddWithValue("@StockId", StockId)
                    cmd.Parameters.AddWithValue("@Month", Variables.CurrentMonth)
                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)

                    If Con.State <> ConnectionState.Open Then

                        Await Con.OpenAsync()

                    End If

                    Dim result As Object = Await cmd.ExecuteScalarAsync()
                    Total = If(IsDBNull(result), 0, Convert.ToInt32(result))

                End Using

            Catch ex As SqlException

                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return Total

    End Function

    Async Function CountExpiredItemsThisMonthProductCode(ProductCode As String) As Task(Of Integer)

        Dim total As Integer = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' Query to count items expiring this month
                Dim query As String = "
                    SELECT COUNT(*) 
                    FROM stock
                    WHERE 
                        MONTH(expiration_date) = @Month 
                        AND YEAR(expiration_date) = @Year
                        AND active = 1
                        AND expiration_date < GETDATE() AND batch_code LIKE @BatchCode
                "

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.AddWithValue("@BatchCode", $"%{ProductCode}%")
                    cmd.Parameters.AddWithValue("@Month", Variables.CurrentMonth)
                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)

                    total = Convert.ToInt32(Await cmd.ExecuteScalarAsync())
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return total

    End Function

    Async Function CountAboutToExpireByProductCode(ProductCode As String) As Task(Of Integer)

        Dim total As Integer = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                ' Query to count how many items are about to expire in the next week and are active
                Dim query As String = "
                    SELECT COUNT(*) 
                    FROM stock
                    WHERE 
                        -- Get the month and year of expiration_date
                        DATENAME(MONTH, CAST(expiration_date AS DATETIME)) + ' ' + 
                        DATENAME(DAY, CAST(expiration_date AS DATETIME)) + ', ' + 
                        DATENAME(YEAR, CAST(expiration_date AS DATETIME)) BETWEEN 
                        CAST(GETDATE() AS DATE) AND 
                        CAST(DATEADD(WEEK, 1, GETDATE()) AS DATE)
                        AND active = 1 AND batch_code LIKE @BatchCode
                "

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.AddWithValue("@BatchCode", $"%{ProductCode}%")
                    ' Execute the query to count the items about to expire and are active
                    total = Convert.ToInt32(Await cmd.ExecuteScalarAsync())
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return total

    End Function

    Async Function CountLowStock(ProductCode As String) As Task(Of Integer)

        Dim Total As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim query As String = "SELECT COUNT(*) FROM stock WHERE current_stock <= 0.3 * total_stock AND active = 1 AND batch_code LIKE @BatchCode"

                Using cmd As New SqlCommand(query, Con)

                    cmd.Parameters.AddWithValue("@BatchCode", $"%{ProductCode}%")
                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    Total = If(IsDBNull(result), 0, Convert.ToInt32(result))

                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return Total

    End Function

    Async Function SearchByTransactionName(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query naman ng product by name. gamit 'to sa search field.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        Variables.SearchTransactionId.Clear
                        Variables.SearchTransactionStockId.Clear
                        Variables.SearchTransactionType.Clear

                        While Await Reader.ReadAsync

                            Variables.SearchTransactionId.add(Integer.Parse(Reader("transaction_id")))
                            Variables.SearchTransactionStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.SearchTransactionType.add(Reader("transaction_type").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrieveTransactionBy1Filter(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query ng product sa product table by 1 filter.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearInventoryTransactionList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfTransactionId.add(Integer.Parse(Reader("transaction_id")))
                            Variables.ListOfTransactionStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListOfTransactionName.Add(Reader("transaction_type").ToString())
                            Variables.ListOfTransactionQuantity.Add(Integer.Parse(Reader("quantity")))
                            Variables.ListOfTransactionDate.Add(Reader("transaction_date").ToString())
                            Variables.ListOfTransactionTime.Add(Reader("transaction_time").ToString())
                            Variables.ListOfTransactionActionBy.Add(Integer.Parse(Reader("action_by")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function DoesTransactionExist(ProductCode As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT COUNT(*) " &
                                       "FROM stock_transaction t " &
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

End Module
