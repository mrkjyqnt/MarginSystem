Imports Microsoft.Data.SqlClient

Module DashboardModule

    Async Function CountTotalValuation() As Task(Of Double)

        Dim Total As Double = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = "SELECT SUM(retail_valuation) FROM inventory_valuation"

                Using cmd As New SqlCommand(query, Con)
                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    ' Handle potential NULL result from SUM and round to 2 decimal places
                    Total = Math.Round(If(IsDBNull(result), 0, Convert.ToDouble(result)), 2)

                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Total

    End Function


    Async Function CountTotalStocks() As Task(Of Integer)

        Dim Total As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim query As String = "SELECT SUM(current_stock) FROM stock"

                Using cmd As New SqlCommand(query, Con)
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

    Async Function CompareValuation(lastMonth As String, thisMonth As String) As Task(Of String)

        Dim lastMonthValuation As Double = 0
        Dim thisMonthValuation As Double = 0
        Dim resultMessage As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' Query for last month's valuation
                Dim lastMonthQuery As String = "
                    SELECT SUM(retail_valuation)
                    FROM inventory_valuation
                    WHERE date_added >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)
                    AND date_added < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)"

                Using lastMonthCmd As New SqlCommand(lastMonthQuery, Con)
                    Dim lastMonthResult As Object = Await lastMonthCmd.ExecuteScalarAsync()
                    lastMonthValuation = If(IsDBNull(lastMonthResult), 0, Convert.ToDouble(lastMonthResult))
                End Using

                ' Query for this month's valuation
                Dim thisMonthQuery As String = "
                    SELECT SUM(retail_valuation) 
                    FROM inventory_valuation 
                    WHERE DATENAME(YEAR, CONVERT(DATE, date_added, 107)) + '-' + 
                          RIGHT('0' + CAST(MONTH(CONVERT(DATE, date_added, 107)) AS VARCHAR), 2) = @ThisMonth"

                Using thisMonthCmd As New SqlCommand(thisMonthQuery, Con)
                    thisMonthCmd.Parameters.AddWithValue("@ThisMonth", thisMonth)
                    Dim thisMonthResult As Object = Await thisMonthCmd.ExecuteScalarAsync()
                    thisMonthValuation = If(IsDBNull(thisMonthResult), 0, Convert.ToDouble(thisMonthResult))
                End Using

                ' Generate the result message
                If lastMonthValuation > 0 Then
                    Dim percentageChange As Double = Math.Abs((thisMonthValuation - lastMonthValuation) / lastMonthValuation * 100)
                
                    If thisMonthValuation > lastMonthValuation Then
                        resultMessage = $"{percentageChange:F2}% higher"
                        Dashboard.ValuationColor = Color.FromArgb(51, 199, 90)
                    ElseIf thisMonthValuation < lastMonthValuation Then
                        resultMessage = $"{percentageChange:F2}% lower"
                        Dashboard.ValuationColor = Color.FromArgb(255, 59, 48)
                    Else
                        resultMessage = "No change from last month."
                        Dashboard.ValuationColor = Color.FromArgb(51, 199, 90)
                    End If
                Else
                    resultMessage = "100% higher"
                    Dashboard.ValuationColor = Color.FromArgb(51, 199, 90)
                End If

            Catch ex As Exception
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return resultMessage

    End Function

    Function CompareInventoryValuation(lastMonth As Double, thisMonth As Double) As String

        Dim Percentage As Double

        If lastMonth > thisMonth Then
            Percentage = ((lastMonth - thisMonth) / lastMonth) * 100
            Dashboard.ValuationColor = Color.FromArgb(255, 59, 48)
            Return $"{Math.Round(Percentage, 2)}% lower"

        ElseIf thisMonth > lastMonth Then
            Dashboard.ValuationColor = Color.FromArgb(51, 199, 90)
            Percentage = ((thisMonth - lastMonth) / lastMonth) * 100
            Return $"{Math.Round(Percentage, 2)}% higher"

        Else
            Dashboard.ValuationColor = Color.FromArgb(51, 199, 90)
            Return "No change from last month."
        End If

    End Function

    Async Function CompareSale(lastMonth As String, thisMonth As String) As Task(Of String)

        Dim lastMonthValuation As Double = 0
        Dim thisMonthValuation As Double = 0
        Dim resultMessage As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' Query for last month's valuation
                Dim lastMonthQuery As String = "
                    SELECT SUM(gross_sale) 
                    FROM sale 
                    WHERE DATENAME(YEAR, CONVERT(DATE, transaction_date, 107)) + '-' + 
                          RIGHT('0' + CAST(MONTH(CONVERT(DATE, transaction_date, 107)) AS VARCHAR), 2) = @LastMonth"

                Using lastMonthCmd As New SqlCommand(lastMonthQuery, Con)
                    lastMonthCmd.Parameters.AddWithValue("@LastMonth", lastMonth)
                    Dim lastMonthResult As Object = Await lastMonthCmd.ExecuteScalarAsync()
                    lastMonthValuation = If(IsDBNull(lastMonthResult), 0, Convert.ToDouble(lastMonthResult))
                End Using

                ' Query for this month's valuation
                Dim thisMonthQuery As String = "
                    SELECT SUM(gross_sale) 
                    FROM sale 
                    WHERE DATENAME(YEAR, CONVERT(DATE, transaction_date, 107)) + '-' + 
                          RIGHT('0' + CAST(MONTH(CONVERT(DATE, transaction_date, 107)) AS VARCHAR), 2) = @ThisMonth"

                Using thisMonthCmd As New SqlCommand(thisMonthQuery, Con)
                    thisMonthCmd.Parameters.AddWithValue("@ThisMonth", thisMonth)
                    Dim thisMonthResult As Object = Await thisMonthCmd.ExecuteScalarAsync()
                    thisMonthValuation = If(IsDBNull(thisMonthResult), 0, Convert.ToDouble(thisMonthResult))
                End Using

                ' Generate the result message
                If lastMonthValuation > 0 Then
                    Dim percentageChange As Double = Math.Abs((thisMonthValuation - lastMonthValuation) / lastMonthValuation * 100)
                
                    If thisMonthValuation > lastMonthValuation Then
                        resultMessage = $"{percentageChange:F2}% higher"
                        Dashboard.ValuationColor = Color.FromArgb(51, 199, 90)
                    ElseIf thisMonthValuation < lastMonthValuation Then
                        resultMessage = $"{percentageChange:F2}% lower"
                        Dashboard.ValuationColor = Color.FromArgb(255, 59, 48)
                    Else
                        resultMessage = "No change from last month."
                        Dashboard.ValuationColor = Color.FromArgb(51, 199, 90)
                    End If
                Else
                    resultMessage = "100% higher"
                    Dashboard.ValuationColor = Color.FromArgb(51, 199, 90)
                End If

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return resultMessage

    End Function

    Async Function WeekComparison(lastWeek As String, thisWeek As String) As Task(Of String)

        Dim lastWeekValuation As Double = 0
        Dim thisWeekValuation As Double = 0
        Dim resultMessage As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' Query for last week's valuation
                Dim lastWeekQuery As String = "
                    SELECT SUM(gross_sale) 
                    FROM sale 
                    WHERE DATEPART(ISO_WEEK, transaction_date) = @LastWeek 
                    AND YEAR(transaction_date) = YEAR(GETDATE())"

                Using lastWeekCmd As New SqlCommand(lastWeekQuery, Con)
                    lastWeekCmd.Parameters.AddWithValue("@LastWeek", lastWeek)
                    Dim lastWeekResult As Object = Await lastWeekCmd.ExecuteScalarAsync()
                    lastWeekValuation = If(IsDBNull(lastWeekResult), 0, Convert.ToDouble(lastWeekResult))
                End Using

                ' Query for this week's valuation
                Dim thisWeekQuery As String = "
                    SELECT SUM(gross_sale) 
                    FROM sale 
                    WHERE DATEPART(ISO_WEEK, transaction_date) = @ThisWeek 
                    AND YEAR(transaction_date) = YEAR(GETDATE())"

                Using thisWeekCmd As New SqlCommand(thisWeekQuery, Con)
                    thisWeekCmd.Parameters.AddWithValue("@ThisWeek", thisWeek)
                    Dim thisWeekResult As Object = Await thisWeekCmd.ExecuteScalarAsync()
                    thisWeekValuation = If(IsDBNull(thisWeekResult), 0, Convert.ToDouble(thisWeekResult))
                End Using

                'MessageBox.Show($"Last Week: {lastWeekValuation}, This Week: {thisWeekValuation}")

                ' Generate the result message
                If lastWeekValuation > 0 Then
                    Dim percentageChange As Double = Math.Abs((thisWeekValuation - lastWeekValuation) / lastWeekValuation * 100)

                    If thisWeekValuation > lastWeekValuation Then
                        resultMessage = $"{percentageChange:F2}% higher"
                        Dashboard.WeekValuationColor = Color.FromArgb(51, 199, 90)
                    ElseIf thisWeekValuation < lastWeekValuation Then
                        resultMessage = $"{percentageChange:F2}% lower"
                        Dashboard.WeekValuationColor = Color.FromArgb(255, 59, 48)
                    Else
                        resultMessage = "No change from last week."
                        Dashboard.WeekValuationColor = Color.FromArgb(51, 199, 90)
                    End If
                Else
                    resultMessage = "100% higher"
                    Dashboard.WeekValuationColor = Color.FromArgb(51, 199, 90)
                End If

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return resultMessage

    End Function

    Async Function CompareTodayValuation(yesterday As String, today As String) As Task(Of String)

        Dim yesterdayValuation As Double = 0
        Dim todayValuation As Double = 0
        Dim resultMessage As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' Query for yesterday's valuation
                Dim yesterdayQuery As String = "
                    SELECT SUM(gross_sale) 
                    FROM sale 
                    WHERE CONVERT(DATE, transaction_date, 107) = @Yesterday"

                Using yesterdayCmd As New SqlCommand(yesterdayQuery, Con)
                    yesterdayCmd.Parameters.AddWithValue("@Yesterday", yesterday)
                    Dim yesterdayResult As Object = Await yesterdayCmd.ExecuteScalarAsync()
                    yesterdayValuation = If(IsDBNull(yesterdayResult), 0, Convert.ToDouble(yesterdayResult))
                End Using

                ' Query for today's valuation
                Dim todayQuery As String = "
                    SELECT SUM(gross_sale) 
                    FROM sale 
                    WHERE CONVERT(DATE, transaction_date, 107) = @Today"

                Using todayCmd As New SqlCommand(todayQuery, Con)
                    todayCmd.Parameters.AddWithValue("@Today", today)
                    Dim todayResult As Object = Await todayCmd.ExecuteScalarAsync()
                    todayValuation = If(IsDBNull(todayResult), 0, Convert.ToDouble(todayResult))
                End Using

                'MessageBox.Show($"Last Week: {yesterdayValuation}, This Week: {todayValuation}")

                ' Generate the result message
                If yesterdayValuation > 0 Then
                    Dim percentageChange As Double = Math.Abs((todayValuation - yesterdayValuation) / yesterdayValuation * 100)

                    If todayValuation > yesterdayValuation Then
                        resultMessage = $"{percentageChange:F2}% higher"
                        Dashboard.TodayValuationColor = Color.FromArgb(51, 199, 90)
                    ElseIf todayValuation < yesterdayValuation Then
                        resultMessage = $"{percentageChange:F2}% lower"
                        Dashboard.TodayValuationColor = Color.FromArgb(255, 59, 48)
                    Else
                        resultMessage = "No change from yesterday."
                        Dashboard.TodayValuationColor = Color.FromArgb(51, 199, 90)
                    End If
                Else
                    resultMessage = "100% higher"
                    Dashboard.TodayValuationColor = Color.FromArgb(51, 199, 90)
                End If

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return resultMessage

    End Function

    Async Function CountAboutToExpire() As Task(Of Integer)

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
                        AND active = 1
                "

                Using cmd As New SqlCommand(query, Con)
                    ' Execute the query to count the items about to expire and are active
                    total = Convert.ToInt32(Await cmd.ExecuteScalarAsync())
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return total

    End Function

    Async Function CountExpiredItems() As Task(Of Integer)

        Dim total As Integer = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                ' Query to count how many items have already expired
                Dim query As String = "
                    SELECT COUNT(*) 
                    FROM stock
                    WHERE 
                        expiration_date < CAST(GETDATE() AS DATE)
                        AND active = 1
                "

                Using cmd As New SqlCommand(query, Con)
                    ' Execute the query to count the expired items that are active
                    total = Convert.ToInt32(Await cmd.ExecuteScalarAsync())
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return total

    End Function

    Async Function CountExpiredItemsThisMonth() As Task(Of Integer)

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
                        AND expiration_date < GETDATE()
                "

                Using cmd As New SqlCommand(query, Con)
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



    Async Function ThisWeekTotalValuation() As Task(Of Double)

        Dim Total As Double = 0.0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' SQL query to sum valuations for the current week
                Dim query As String = "
                    SELECT SUM(gross_sale)
                    FROM sale
                    WHERE DATEPART(YEAR, transaction_date) = DATEPART(YEAR, GETDATE())
                    AND DATEPART(WEEK, transaction_date) = DATEPART(WEEK, GETDATE())
                "

                Using cmd As New SqlCommand(query, Con)
                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    ' Handle potential NULL result from SUM
                    Total = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToDouble(result), 0.0)
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return Total

    End Function

    Async Function YesterdayTodayTotalValuation() As Task(Of Double)

        Dim Total As Double

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()
            Try
                ' SQL query to sum valuations for yesterday
                Dim query As String = "SELECT SUM(gross_sale) FROM sale " & 
                                      "WHERE CONVERT(DATE, transaction_date, 107) IN (@Today)"

                Using cmd As New SqlCommand(query, Con)
                    cmd.Parameters.AddWithValue("@Today", DateTime.Now.ToString("yyyy-MM-dd"))
                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    ' Handle potential NULL result from SUM
                    Total = If(IsDBNull(result), 0, Convert.ToDouble(result))
                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return Total

    End Function

    Async Function CountLowStock() As Task(Of Integer)

        Dim Total As Integer

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim query As String = "SELECT COUNT(*) FROM stock WHERE current_stock <= 0.3 * total_stock AND active = 1"

                Using cmd As New SqlCommand(query, Con)

                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    Total = If(IsDBNull(result), 0, Convert.ToInt32(result))

                End Using

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

        Return Total

    End Function


End Module
