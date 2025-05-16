Imports Microsoft.Data.SqlClient

Module ValuationAndReportsModule

    Async Function CountProductTotalValuation(ProductId As Integer) As Task(Of Double)

        Dim Total As Double = 0.0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim query As String = "
                    SELECT SUM(i.retail_valuation) 
                    FROM inventory_valuation i
                    WHERE i.stock_id IN (
                        SELECT s.stock_id 
                        FROM stock s
                        WHERE s.product_id = @ProductId
                        AND MONTH(i.date_added) = @Month AND YEAR(i.date_added) = @Year
                    )
                "

                Using cmd As New SqlCommand(query, Con)
                    ' Add parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@ProductId", ProductId)
                    cmd.Parameters.AddWithValue("@Month", Variables.CurrentMonth)
                    cmd.Parameters.AddWithValue("@Year", Variables.CurrentYear)
                    Dim result As Object = Await cmd.ExecuteScalarAsync()

                    ' Handle potential NULL result from SUM
                    Total = If(IsDBNull(result), 0.0, Convert.ToDouble(result))

                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return Total

    End Function


End Module
