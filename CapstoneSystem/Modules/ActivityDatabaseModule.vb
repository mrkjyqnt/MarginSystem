Imports Microsoft.Data.SqlClient


Module ActivityDatabaseModule

    Async Function InsertActivity(ActionName As String, ActionBy As Integer, Management As String,
                      ActivityDate As String, ActivityTime As String, Detail As String) As Task

        
        'Insert yung info ng activity sa database.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenBackupConnection

            Try

                Dim Query As String = "INSERT INTO activities VALUES(@ActionName, @ActionBy,
                                        @Management, @ActivityDate, @ActivityTime, @Detail)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@ActionName", ActionName)
                    Cmd.Parameters.AddWithValue("@ActionBy", ActionBy)
                    Cmd.Parameters.AddWithValue("@Management", Management)
                    Cmd.Parameters.AddWithValue("@ActivityDate", ActivityDate)
                    Cmd.Parameters.AddWithValue("@ActivityTime", ActivityTime)
                    Cmd.Parameters.AddWithValue("@Detail", Detail)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    If RowsAffected > 0

                        If Management = "category"

                            MessageBox.Show("New Category Added!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf Management = "supplier"

                            MessageBox.Show("New Supplier Added!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf Management = "warehouse"

                            MessageBox.Show("New Warehouse Added!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                
                        ElseIf ActionName = "Add"

                            MessageBox.Show("New Product Added!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf ActionName = "Disable"

                            MessageBox.Show("Product disabled!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf ActionName = "Update"

                            MessageBox.Show("Product Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf ActionName = "Changes"

                            MessageBox.Show("Stock Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf ActionName = "Change PIN"

                            MessageBox.Show("Your Personal Identification Number is changed.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrieveAll(Query As String) As Task

        'Query lahat ng info sa activity table sa database.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenBackupConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearActivityList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfActivityId.add(Integer.Parse(Reader("activity_id")))
                            Variables.ListOfActivityName.add(Reader("action_name").ToString())
                            Variables.ListOfActionBy.Add(Integer.Parse(Reader("action_by")))
                            Variables.ListOfManagement.Add(Reader("management").ToString())
                            Variables.ListOfActivityDate.Add(Reader("activity_date").ToString())
                            Variables.ListOfActivityTime.Add(Reader("activity_time").ToString())
                            Variables.listofActivityDetails.Add(Reader("details").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function GetProductName(ProductIdentifier As String, Management As String) As Task(Of String)

        Dim ProductName As String = String.Empty

        Using Con As SqlConnection = Await ConnectionStringModule.OpenBackupConnection()

            Try

                Dim Query As String

                If Management = "product"

                    Query = "SELECT product_name FROM product WHERE barcode_sequence = @BarcodeSequence"

                    Using Cmd As New SqlCommand(Query, Con)

                        Cmd.Parameters.AddWithValue("@BarcodeSequence", ProductIdentifier)

                        Dim Result = Await Cmd.ExecuteScalarAsync()

                        If Result IsNot Nothing

                            ProductName = Result.ToString

                        End If

                    End Using

                ElseIf Management = "stock"

                    Query = "SELECT p.product_name FROM product p WHERE p.barcode_sequence IN (SELECT s.stock_id FROM stock s WHERE s.batch_code LIKE @BatchCode)"

                    Using Cmd As New SqlCommand(Query, Con)

                        Cmd.Parameters.AddWithValue("@BatchCode", "%" & ProductIdentifier & "%")

                        Dim Result = Await Cmd.ExecuteScalarAsync()

                        If Result IsNot Nothing

                            ProductName = Result.ToString

                        End If

                    End Using

                End If

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return ProductName

    End Function



End Module
