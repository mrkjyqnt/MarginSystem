Imports Microsoft.Data.SqlClient

Module SaleValuationModule

    Async Function InsertIntoSale(StockId As Integer, QuantitySold As Integer, ItemPrice As Double, 
                                  Expenses As Double, DateSold As String, TimeSold As String) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "INSERT INTO sale VALUES(@StockId, @Quantity,
                                        @ItemPrice, @Expenses, @CopyGross, @TransactionDate, @TransactionTime)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@StockId", StockId)
                    Cmd.Parameters.AddWithValue("@Quantity", QuantitySold)
                    Cmd.Parameters.AddWithValue("@ItemPrice", ItemPrice)
                    Cmd.Parameters.AddWithValue("@Expenses", Expenses)
                    Dim CopyGross As Double = QuantitySold * ItemPrice
                    Cmd.Parameters.Add("@CopyGross", SqlDbType.Float).Value = CopyGross
                    Cmd.Parameters.AddWithValue("@TransactionDate", DateSold)
                    Cmd.Parameters.AddWithValue("@TransactionTime", TimeSold)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    If RowsAffected > 0
                        
                        ProductManagementDatabaseModule.UpdateSuccessul = True

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

                        GeneralModule.ClearSalesList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfSaleId.add(Integer.Parse(Reader("sale_id")))
                            Variables.ListOfSaleStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListOfQuantitySold.Add(Integer.Parse(Reader("quantity_sold")))
                            Variables.ListOfItemPrice.Add(Double.Parse(Reader("item_price")))
                            Variables.ListOfExpenses.Add(Double.Parse(Reader("expenses")))
                            Variables.ListOfGrossSale.Add(Double.Parse(Reader("gross_sale")))
                            Variables.ListOfNetSale.Add(Double.Parse(Reader("net_sale")))
                            Variables.ListOfSaleDate.Add(Reader("transaction_date").ToString())
                            Variables.listofSaleTime.Add(Reader("transaction_time").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function CountSum(ColumnName As String, TableName As String, MonthName As Integer, ColumnDate As String) As Task(Of Double)

        Dim Total As Double

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = $"SELECT SUM({ColumnName}) FROM {TableName} WHERE YEAR({ColumnDate}) = @Year AND MONTH({ColumnDate}) = @Month"

                Using cmd As New SqlCommand(query, Con)

                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)
                    cmd.Parameters.AddWithValue("@Month", MonthName)
                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    ' Handle potential NULL result from SUM
                    Total = If(IsDBNull(result), 0, Double.Parse(result))

                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return Total

    End Function

    Async Function CountSumByProduct(ColumnName As String, TableName As String, MonthName As Integer, ColumnDate As String, ColumnToJoin As String, ProductId As Integer) As Task(Of Double)

        Dim Total As Double

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = $"SELECT SUM({ColumnName}) FROM {TableName} WHERE YEAR({ColumnDate}) = @Year AND MONTH({ColumnDate}) = @Month AND {ColumnToJoin} IN (SELECT s.stock_id FROM stock s WHERE s.product_id = @ProductId)"

                Using cmd As New SqlCommand(query, Con)

                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)
                    cmd.Parameters.AddWithValue("@Month", MonthName)
                    cmd.Parameters.AddWithValue("@ProductId", ProductId)

                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    ' Handle potential NULL result from SUM
                    Total = If(IsDBNull(result), 0, Double.Parse(result))

                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return Total

    End Function

    Async Function CountTotalSales(StockId As Integer) As Task(Of Double)

        Dim Total As Double = 0.0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                Dim query As String = "
                    SELECT COALESCE(SUM(gross_sale), 0.0) 
                    FROM sale
                    WHERE stock_id = @StockId
                    AND MONTH(transaction_date) = @Month AND YEAR(transaction_date) = @Year
                "

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.AddWithValue("@StockId", StockId)
                    cmd.Parameters.AddWithValue("@Month", Variables.CurrentMonth)
                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)

                    Dim result As Object = Await cmd.ExecuteScalarAsync()
                    Total = Convert.ToDouble(result)
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return Total

    End Function

    Async Function CountTotalProfit(StockId As Integer) As Task(Of Double)

        Dim Total As Double = 0.0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                Dim query As String = "
                    SELECT COALESCE(SUM(net_sale), 0.0) 
                    FROM sale
                    WHERE stock_id = @StockId
                    AND MONTH(transaction_date) = @Month AND YEAR(transaction_date) = @Year
                "

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.AddWithValue("@StockId", StockId)
                    cmd.Parameters.AddWithValue("@Month", Variables.CurrentMonth)
                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)

                    Dim result As Object = Await cmd.ExecuteScalarAsync()
                    Total = Convert.ToDouble(result)
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return Total

    End Function

    Async Function CompareSaleValuation(lastMonth As String, thisMonth As String, StockId As Integer) As Task(Of String)

        Dim lastMonthValuation As Double = 0
        Dim thisMonthValuation As Double = 0
        Dim resultMessage As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' Query for last month's valuation
                Dim lastMonthQuery As String = "
                    SELECT SUM(gross_sale) 
                    FROM sale 
                    WHERE stock_id = @StockId AND DATENAME(YEAR, CONVERT(DATE, transaction_date, 107)) + '-' + 
                          RIGHT('0' + CAST(MONTH(CONVERT(DATE, transaction_date, 107)) AS VARCHAR), 2) = @LastMonth"

                Using lastMonthCmd As New SqlCommand(lastMonthQuery, Con)
                    lastMonthCmd.Parameters.AddWithValue("@LastMonth", lastMonth)
                    lastMonthCmd.Parameters.AddWithValue("@StockId", StockId)
                    Dim lastMonthResult As Object = Await lastMonthCmd.ExecuteScalarAsync()
                    lastMonthValuation = If(IsDBNull(lastMonthResult), 0, Convert.ToDouble(lastMonthResult))
                End Using

                ' Query for this month's valuation
                Dim thisMonthQuery As String = "
                    SELECT SUM(gross_sale) 
                    FROM sale 
                    WHERE stock_id = @StockId AND DATENAME(YEAR, CONVERT(DATE, transaction_date, 107)) + '-' + 
                          RIGHT('0' + CAST(MONTH(CONVERT(DATE, transaction_date, 107)) AS VARCHAR), 2) = @ThisMonth"

                Using thisMonthCmd As New SqlCommand(thisMonthQuery, Con)
                    thisMonthCmd.Parameters.AddWithValue("@ThisMonth", thisMonth)
                    thisMonthCmd.Parameters.AddWithValue("@StockId", StockId)
                    Dim thisMonthResult As Object = Await thisMonthCmd.ExecuteScalarAsync()
                    thisMonthValuation = If(IsDBNull(thisMonthResult), 0, Convert.ToDouble(thisMonthResult))
                End Using

                ' Generate the result message
                If lastMonthValuation > 0 Then
                    Dim percentageChange As Double = Math.Abs((thisMonthValuation - lastMonthValuation) / lastMonthValuation * 100)
                
                    If thisMonthValuation > lastMonthValuation Then
                        resultMessage = $"{percentageChange:F2}% higher"
                        ValuationAndReports.TotalSalesValuation = Color.FromArgb(51, 199, 90)
                    ElseIf thisMonthValuation < lastMonthValuation Then
                        resultMessage = $"{percentageChange:F2}% lower"
                        ValuationAndReports.TotalSalesValuation = Color.FromArgb(255, 59, 48)
                    Else
                        resultMessage = "No change from last month."
                        ValuationAndReports.TotalSalesValuation = Color.FromArgb(51, 199, 90)
                    End If
                Else
                    resultMessage = "100% higher"
                    ValuationAndReports.TotalSalesValuation = Color.FromArgb(51, 199, 90)
                End If

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return resultMessage

    End Function

    Async Function CompareProfitValuation(lastMonth As String, thisMonth As String, StockId As Integer) As Task(Of String)

        Dim lastMonthValuation As Double = 0
        Dim thisMonthValuation As Double = 0
        Dim resultMessage As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' Query for last month's valuation
                Dim lastMonthQuery As String = "
                    SELECT SUM(net_sale) 
                    FROM sale 
                    WHERE stock_id = @StockId AND DATENAME(YEAR, CONVERT(DATE, transaction_date, 107)) + '-' + 
                          RIGHT('0' + CAST(MONTH(CONVERT(DATE, transaction_date, 107)) AS VARCHAR), 2) = @LastMonth"

                Using lastMonthCmd As New SqlCommand(lastMonthQuery, Con)
                    lastMonthCmd.Parameters.AddWithValue("@LastMonth", lastMonth)
                    lastMonthCmd.Parameters.AddWithValue("@StockId", StockId)
                    Dim lastMonthResult As Object = Await lastMonthCmd.ExecuteScalarAsync()
                    lastMonthValuation = If(IsDBNull(lastMonthResult), 0, Convert.ToDouble(lastMonthResult))
                End Using

                ' Query for this month's valuation
                Dim thisMonthQuery As String = "
                    SELECT SUM(net_sale) 
                    FROM sale 
                    WHERE stock_id = @StockId AND DATENAME(YEAR, CONVERT(DATE, transaction_date, 107)) + '-' + 
                          RIGHT('0' + CAST(MONTH(CONVERT(DATE, transaction_date, 107)) AS VARCHAR), 2) = @ThisMonth"

                Using thisMonthCmd As New SqlCommand(thisMonthQuery, Con)
                    thisMonthCmd.Parameters.AddWithValue("@ThisMonth", thisMonth)
                    thisMonthCmd.Parameters.AddWithValue("@StockId", StockId)
                    Dim thisMonthResult As Object = Await thisMonthCmd.ExecuteScalarAsync()
                    thisMonthValuation = If(IsDBNull(thisMonthResult), 0, Convert.ToDouble(thisMonthResult))
                End Using

                ' Generate the result message
                If lastMonthValuation > 0 Then
                    Dim percentageChange As Double = Math.Abs((thisMonthValuation - lastMonthValuation) / lastMonthValuation * 100)
                
                    If thisMonthValuation > lastMonthValuation Then
                        resultMessage = $"{percentageChange:F2}% higher"
                        ValuationAndReports.TotalProfitValuation = Color.FromArgb(51, 199, 90)
                    ElseIf thisMonthValuation < lastMonthValuation Then
                        resultMessage = $"{percentageChange:F2}% lower"
                        ValuationAndReports.TotalProfitValuation = Color.FromArgb(255, 59, 48)
                    Else
                        resultMessage = "No change from last month."
                        ValuationAndReports.TotalProfitValuation = Color.FromArgb(51, 199, 90)
                    End If
                Else
                    resultMessage = "100% higher"
                    ValuationAndReports.TotalProfitValuation = Color.FromArgb(51, 199, 90)
                End If

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return resultMessage

    End Function

    Async Function GetProductsFromSale() As Task(Of List(Of Object))

        Dim Products As New List(Of Object)

        'Kuhain yung mga products na wala pa stock management.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT p.product_name FROM product p WHERE p.product_id IN (SELECT s.product_id FROM stock s WHERE s.stock_id IN (SELECT t.stock_id FROM sale t))"

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

    Async Function SearchByProductName(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query naman ng product by name. gamit 'to sa search field.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        Variables.SearchBySaleId.Clear
                        Variables.SearchBySaleStockId.Clear
                        Variables.SearchBySaleQuantity.Clear
                        Variables.SearchByGrossSale.clear

                        While Await Reader.ReadAsync

                            Variables.SearchBySaleId.add(Integer.Parse(Reader("sale_id")))
                            Variables.SearchBySaleStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.SearchBySaleQuantity.add(Reader("quantity_sold").ToString())
                            Variables.SearchByGrossSale.Add(Double.Parse(Reader("gross_sale")))
                            'Variables.SearchByStockName.Add(Reader(Await GetProductName("product_id")).ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function DoesSaleExist(ProductCode As String) As Task(Of Boolean)

        Dim Exists As Boolean = False

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT COUNT(*) " &
                                       "FROM sale t " &
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

    Async Function RetrieveSaleBy1Filter(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query ng product sa product table by 1 filter.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearSalesList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfSaleId.add(Integer.Parse(Reader("sale_id")))
                            Variables.ListOfSaleStockId.add(Integer.Parse(Reader("stock_id")))
                            Variables.ListOfQuantitySold.Add(Integer.Parse(Reader("quantity_sold")))
                            Variables.ListOfItemPrice.Add(Double.Parse(Reader("item_price")))
                            Variables.ListOfExpenses.Add(Double.Parse(Reader("expenses")))
                            Variables.ListOfGrossSale.Add(Double.Parse(Reader("gross_sale")))
                            Variables.ListOfNetSale.Add(Double.Parse(Reader("net_sale")))
                            Variables.ListOfSaleDate.Add(Reader("transaction_date").ToString())
                            Variables.listofSaleTime.Add(Reader("transaction_time").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function


End Module
