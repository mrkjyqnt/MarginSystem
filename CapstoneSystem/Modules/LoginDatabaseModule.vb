Imports Microsoft.Data.SqlClient

Module LoginDatabaseModule

    'check the connection if gumagana
    Async Function CheckConnection() As Task

        Using Con = Await ConnectionStringModule.OpenDatabaseConnection

            Try
                If Con.State = ConnectionState.Open Then MessageBox.Show("Connected to the database.")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try

        End Using

    End Function


    'this will get naman yung 2 users sa database
    Async Function GetUsers() As Task(of List(Of Object))

        Dim Users As New List(Of Object)

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT * FROM account"

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        While Await Reader.ReadAsync

                            Dim Userdata As Object
                            Userdata = Reader("user_name")
                            Users.Add(Userdata)

                        End While
                            
                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return Users

    End Function

    Async Function GetUserId(Username As String) As Task(of Integer)

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

    Async Function GetPin(Username As String) As Task(of String)

        Dim UserPIN As String = String.Empty

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT user_pin FROM account WHERE user_name = @user_name"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@user_name", Username)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        UserPIN = Result

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try


        End Using

        Return UserPIN

    End Function


    'for login if tama ang credentials
    Async Function LoginQuery(Username As String, Pin As String, FormClose As Form, FormShow As Form) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT COUNT(*) FROM account WHERE user_name = @user_name AND user_pin = @pin"


                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@user_name", Username)
                    Cmd.Parameters.AddWithValue("@pin", Pin)

                    Dim Count As Integer = CInt(Await Cmd.ExecuteScalarAsync)

                    If Count > 0 Then
                        
                        'Dim Result As DialogResult = RJMessageBox.Show("Login Successfully", "Welcome ", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information)
                        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
                        Await ActivityDatabaseModule.InsertActivity("Login", AddedBy, "account", DateAdded, TimeAdded, $"{Username} Logged-in to the Application")
                        MessageBox.Show("Login Successfully", "Welcome " & Username & "!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        GeneralModule.CloseOverLay(FormClose)
                        FormShow.Show
                        Variables.LoggedInUser = Username
                        Await LoginDatabaseModule.LoggedIn(1, Username)
                        Variables.Retry = 0

                    Else

                        MessageBox.Show("Wrong Pin. Try Again.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Variables.Retry += 1
                        EnterPin.PinTextBox.Clear
                        EnterPin.PinTextBox.Focus

                        If Variables.Retry = 5

                            GeneralModule.CloseOverLay(FormClose)
                            Variables.RemainingLockTime = Await LoginDatabaseModule.GetAllotedTime("first_penalty")

                        End If

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using


    End Function


    'update naman yung login status ng nakapag login na user
    Async Function LoggedIn(Status As Byte, Username As String) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "UPDATE account SET logged_in = @status WHERE user_name = @user_name"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@status", Status)
                    Cmd.Parameters.AddWithValue("@user_name", Username)

                    Dim RowsAffected As Integer = Await Cmd.ExecuteNonQueryAsync

                    If Status = 0

                        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
                        Await ActivityDatabaseModule.InsertActivity("Logout", AddedBy, "account", DateAdded, TimeAdded, $"{Username} Logged out from the Application")

                    End If

                    'If RowsAffected > 0 Then MessageBox.Show("User status updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End Using
            Catch ex As Exception

                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function


    'Para ma save yung lock time ng log-in form
    Async Function SaveLockTime(AllotedTime As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Dim Query As String = "UPDATE form_lock_timer SET alloted_time = @alloted_time WHERE time_name = @time_name"

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@alloted_time", AllotedTime)
                    Cmd.Parameters.AddWithValue("@time_name", "remaining_time")

                    Dim RowsAffected As Integer = Await Cmd.ExecuteNonQueryAsync

                    'If RowsAffected > 0 Then MessageBox.Show("Time saved successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function
    
    
    'Query yung natitrang alloted time ng lock form
    Async Function GetAllotedTime(LockName As String) As Task (Of Integer)

        Dim AllotedTime As Integer = 0

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection

            Try

                Dim Query As String = "SELECT alloted_time FROM form_lock_timer WHERE time_name = @time_name"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@time_name", LockName)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        AllotedTime = Integer.Parse(Result)

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return AllotedTime

    End Function

    
    'Check if may previous user logged-in user.
    Async Function GetPreviousUser() As Task(Of String)

        Dim PreviousUser As String = ""

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = "SELECT user_name FROM account WHERE logged_in = 1"

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        If Await Reader.ReadAsync() Then

                            PreviousUser = Reader("user_name").ToString()

                        End If

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return PreviousUser

    End Function

    Public Async Function UpdatePIN(Value As String, UserId As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try
                Dim UpdateQuery As String = "UPDATE account SET user_pin = @Value WHERE user_id = @UserId"

                Using UpdateCmd As New SqlCommand(UpdateQuery, Con)

                    UpdateCmd.Parameters.AddWithValue("@Value", Value)
                    UpdateCmd.Parameters.AddWithValue("@UserId", UserId)

                    Dim rowsAffected As Integer = Await UpdateCmd.ExecuteNonQueryAsync()

                    If rowsAffected > 0 Then

                        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                        Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                        Await ActivityDatabaseModule.InsertActivity("Change PIN", AddedBy, "account", DateAdded, TimeAdded, $"Change User PIN")

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

End Module
