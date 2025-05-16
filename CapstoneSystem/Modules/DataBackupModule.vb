Imports Google.Apis.Drive.v3
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports System.IO
Imports System.Threading
Imports Google.Apis.Util.Store
Imports Google.Apis.Oauth2.v2
Imports Microsoft.Data.SqlClient
Imports Google.Apis.Upload

Module DataBackupModule

    Async Function GenerateBackup(BackUpName As String, BackUpFilePath As String, DateAdded As String,
                                  TimeAdded As String, AddedBy As String) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Dim Query As String = $"BACKUP DATABASE [MarginSystem] TO DISK = '{BackUpFilePath}'"
            
                Using Cmd As New SqlCommand(Query, Con)

                    Await Cmd.ExecuteNonQueryAsync()
                    Await InsertBackup(BackUpName, BackUpFilePath, DateAdded, TimeAdded, AddedBy)

                End Using

            Catch ex As Exception
                
                MessageBox.Show($"Error during backup: {ex.Message}", "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
            End Try

        End Using

    End Function

    Async Function InsertBackup(BackUpName As String, BackupDirectory As String, DateAdded As String, 
                                timeAdded As String, AddedBy As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenBackupConnection

            Try

                Dim Query As String = "INSERT INTO system_backup VALUES(@BackUpName, @BackUpDirectory, @DateAdded,
                                        @TimeAdded, @AddedBy)"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@BackUpName", BackUpName)
                    Cmd.Parameters.AddWithValue("@BackUpDirectory", BackupDirectory)
                    Cmd.Parameters.AddWithValue("@DateAdded", DateAdded)
                    Cmd.Parameters.AddWithValue("@TimeAdded", timeAdded)
                    Cmd.Parameters.AddWithValue("@AddedBy", AddedBy)

                    Dim RowsAffected As Integer = CInt(Await Cmd.ExecuteNonQueryAsync)

                    If RowsAffected > 0

                        Await ActivityDatabaseModule.InsertActivity("Generate Backup", AddedBy, "Backup and Recovery", DateAdded, TimeAdded, $"Database Backup - ({BackUpName}) Generated")
                        MessageBox.Show($"Backup successfully created!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

                        GeneralModule.ClearDatabaseBackupList()
                            While Await Reader.ReadAsync()
                            Variables.ListOfBackupId.add(Integer.Parse(Reader("backup_id")))
                            Variables.ListOfBackUpName.add(Reader("backup_name").ToString())
                            Variables.ListOfDirectory.Add(Reader("backup_directory").ToString())
                            Variables.ListOfDateAdded.Add(Reader("date_added").ToString())
                            Variables.ListOfTimeAdded.Add(Reader("time_added").ToString())
                            Variables.ListOfDatabaseAddedBy.Add(Integer.Parse(Reader("added_by")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Using
    End Function

    Public Async Sub DeleteBackupFile(BackDirectory As String, BackUpId As Integer)

        Try
            ' Validate directory path before proceeding
            If String.IsNullOrWhiteSpace(BackDirectory) Then
                MessageBox.Show("Backup directory path is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If File.Exists(BackDirectory) Then
                File.Delete(BackDirectory)
                Await DeleteBackUpRecord(BackUpId)
                MessageBox.Show("Backup deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Backup file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As UnauthorizedAccessException
            MessageBox.Show("Access denied while deleting the backup file: " & ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As IOException
            MessageBox.Show("File operation failed: " & ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the backup: " & ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Async Function DeleteBackUpRecord(BackUpId As Integer) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenBackupConnection()

            Dim Query As String = "DELETE FROM system_backup WHERE backup_id = @BackUpId"

            Using Cmd As New SqlCommand(Query, Con)
                Cmd.Parameters.Add("@BackUpId", SqlDbType.Int).Value = BackUpId

                Try
                    Dim RowsAffected As Integer = Await Cmd.ExecuteNonQueryAsync()

                    If RowsAffected > 0 Then
                        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
                        Await ActivityDatabaseModule.InsertActivity("Delete Backup", AddedBy, "Backup and Recovery", DateAdded, TimeAdded, $"Deleted Backup - ({DeleteBackup.BackUpName})")
                    Else
                        MessageBox.Show("No backup record found with the specified ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As SqlException
                    MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

    End Function

    Async Function ExportBackUp(BackDirectory As String, BackUpName As String) As Task
    
        If Not IO.File.Exists(BackDirectory) Then

            MessageBox.Show("Backup file not found. Please create a backup first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        Using saveFileDialog As New SaveFileDialog

            saveFileDialog.Title = "Export Backup File"
            saveFileDialog.Filter = "Backup Files (*.bak)|*.bak"
            saveFileDialog.FileName = $"{BackUpName}"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Try

                    GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
                    Dim exportPath As String = saveFileDialog.FileName
                    IO.File.Copy(BackDirectory, exportPath, True)
                    Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                    Dim TimeAdded = Variables.CurrrentDate.ToString("t")
                    Await ActivityDatabaseModule.InsertActivity("Export Backup", AddedBy, "Backup and Recovery", DateAdded, TimeAdded, $"Backup exported locally - ({BackUpName})")
                    MessageBox.Show($"Backup exported successfully to: {exportPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GeneralModule.CloseOverLay(LoadingScreen)

                Catch ex As Exception

                    MessageBox.Show($"Error during export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                
                End Try

            End If

        End Using

    End Function

    Async Function Restore(BackupFile As String) As Task

        Using Con As SqlConnection = Await ConnectionStringModule.OpenMasterDatabaseConnection()

            Try
                ' Terminate all connections to the Capstone database
                Dim terminateConnections As String = "
                    ALTER DATABASE [MarginSystem]
                    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;"
                Dim restoreDatabase As String = $"
                    RESTORE DATABASE [MarginSystem]
                    FROM DISK = '{BackupFile}'
                    WITH REPLACE, RECOVERY;
                    ALTER DATABASE [MarginSystem] SET MULTI_USER;"

                ' Execute termination command
                Using terminateCommand As New SqlCommand(terminateConnections, Con)
                    Await terminateCommand.ExecuteNonQueryAsync()
                End Using

                ' Execute restore command
                Using restoreCommand As New SqlCommand(restoreDatabase, Con)
                    Await restoreCommand.ExecuteNonQueryAsync()
                End Using

                Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                Dim TimeAdded = Variables.CurrrentDate.ToString("t")
                Await ActivityDatabaseModule.InsertActivity("Restore Backup", AddedBy, "Backup and Recovery", DateAdded, TimeAdded, $"Database restore. The current database is - ({BackupFile})")
                MessageBox.Show("Database restored successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

    End Function

    ' Path to your client_secret.json file
    Private Const CredentialPath As String = "C:\Users\GulaManYOW\Desktop\System\CapstoneSystem\CapstoneSystem\client_secret_704481978202-n50un08413pud3m2n27mh7e46vi96849.apps.googleusercontent.com.json"

    Private service As DriveService

    ' Function to initialize OAuth and upload a file to Google Drive
    Async Function UploadToGoogleDrive(filePath As String) As Task

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        MainForm.UseWaitCursor = True
        ChooseExport.UseWaitCursor = True
        ' Authorize the app and get user credentials
        Dim credential As UserCredential

        Using stream As New FileStream(CredentialPath, FileMode.Open, FileAccess.Read)
            ' Use FromStream instead of Load to avoid the deprecated method warning
            Dim secrets = GoogleClientSecrets.FromStream(stream).Secrets

            ' This initializes the OAuth flow and allows the user to sign in
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                {DriveService.Scope.DriveFile, "https://www.googleapis.com/auth/userinfo.email"},
                "user", CancellationToken.None, New FileDataStore("Drive.Api.Auth.Store")).Result
        End Using

        ' Check the email of the logged-in account
        Dim oauth2Service = New Google.Apis.Oauth2.v2.Oauth2Service(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = "DatabaseBackupUploader"
        })
    
        Dim userInfo = oauth2Service.Userinfo.Get().Execute()
        If userInfo.Email <> "marginbusinessemail@gmail.com" Then
            MessageBox.Show("Please log in with the correct account (marginbusinessemail@gmail.com).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Initialize the Google Drive service with the authenticated credentials
        service = New DriveService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = "DatabaseBackupUploader"
        })

        ' Create metadata for the file you want to upload
        Dim fileMetadata As New Google.Apis.Drive.v3.Data.File() With {
            .Name = Path.GetFileName(filePath) ' Use the name of the file you're uploading
        }

        ' Open the file stream for uploading
        Using fileStream As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            ' Create a request to upload the file
            Dim request = service.Files.Create(fileMetadata, fileStream, "application/octet-stream")
            request.Fields = "id" ' Specify the fields you want in the response
            Dim uploadResult = request.Upload()

            ' Check if the upload was successful
            If uploadResult.Status = UploadStatus.Completed Then
                Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                Dim TimeAdded = Variables.CurrrentDate.ToString("t")
                Await ActivityDatabaseModule.InsertActivity("Export Backup", AddedBy, "Backup and Recovery", DateAdded, TimeAdded, $"Backup exported to Google Drive - ({filePath})")
                MessageBox.Show("Backup successfully exported to Google Drive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show($"Error during upload: {uploadResult.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        GeneralModule.CloseOverLay(LoadingScreen)
        MainForm.UseWaitCursor = False
        ChooseExport.UseWaitCursor = False

    End Function

    Async Function IsCurrentDatabaseLarger(oldBackupConn As String, newBackupFile As String, tempDbName As String) As Task(Of String)

        Try
            ' Step 1: Restore the .bak file to a temporary database
            Dim restoreSuccess As Boolean = Await RestoreDatabaseFromBackup(newBackupFile, tempDbName)
            If Not restoreSuccess Then
                MessageBox.Show("Failed to restore the backup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            ' Step 2: Compare the total row count of both databases
            Dim newBackupConn As String = $"Data Source=.\SQLEXPRESS;Initial Catalog={tempDbName};Integrated Security=True;TrustServerCertificate=True"

            Dim CurrentDatabaseRows As Integer = Await GetTotalRowCount(oldBackupConn)
            Dim NewDatabaseRows As Integer = Await GetTotalRowCount(newBackupConn)

            'Step 3: Drop the temporary database after comparison
            Await DropDatabase(tempDbName)

            ' Step 4: Generate a detailed comparison message
            Dim difference As Integer = Math.Abs(CurrentDatabaseRows - NewDatabaseRows)

            If CurrentDatabaseRows > NewDatabaseRows Then
                
                Return $"The current database has more data ({CurrentDatabaseRows} rows) than this Backup which has ({NewDatabaseRows} rows).{vbCrLf}{vbCrLf}Difference: {difference} rows."
            
            ElseIf NewDatabaseRows > CurrentDatabaseRows Then

                Return $"This backup contains more data ({NewDatabaseRows} rows) than the current database ({CurrentDatabaseRows} rows).{vbCrLf}{vbCrLf}Difference: {difference} rows."
            
            Else

                Return $"Both the current database and the backup have the same amount of data ({CurrentDatabaseRows} rows)."
            
            End If

        Catch ex As Exception

            Return MessageBox.Show("Error comparing backups: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Private Async Function RestoreDatabaseFromBackup(backupFilePath As String, tempDbName As String) As Task(Of Boolean)

        Try
            Using Con As New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True")
                Await Con.OpenAsync()
                Dim restoreQuery As String = $"
                    RESTORE DATABASE [{tempDbName}]
                    FROM DISK = '{backupFilePath}'
                    WITH REPLACE, RECOVERY, MOVE 'Capstone' TO 'C:\Margins Database Backup\Test\{tempDbName}.mdf',
                    MOVE 'Capstone_Log' TO 'C:\Margins Database Backup\Test\{tempDbName}_log.ldf'
                "

                Using Cmd As New SqlCommand(restoreQuery, Con)
                    Await Cmd.ExecuteNonQueryAsync()
                End Using
            End Using

            Return True
        Catch ex As Exception

            MessageBox.Show("Error restoring database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
           
            Return False

        End Try

    End Function

    Private Async Function GetTotalRowCount(connectionString As String) As Task(Of Integer)

        Dim totalRows As Integer = 0

        Using Con As New SqlConnection(connectionString)
            Await Con.OpenAsync()

            Dim tableListQuery As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
        
            Using Cmd As New SqlCommand(tableListQuery, Con)
                Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()
                    Dim tables As New List(Of String)
                    While Await Reader.ReadAsync()
                        tables.Add(Reader.GetString(0))
                    End While

                    Reader.Close()

                    For Each table As String In tables
                        Dim rowCountQuery As String = $"SELECT COUNT(*) FROM [{table}]"
                        Using countCmd As New SqlCommand(rowCountQuery, Con)
                            Dim rowCount As Integer = Convert.ToInt32(Await countCmd.ExecuteScalarAsync())
                            totalRows += rowCount
                        End Using
                    Next
                End Using
            End Using

        End Using

        Return totalRows

    End Function

    Private Async Function DropDatabase(dbName As String) As Task

        Try
            Using Con As New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True")
                Await Con.OpenAsync()
            
                ' Force disconnect all users
                Dim forceDisconnectQuery As String = $"
                    ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    DROP DATABASE [{dbName}];"
            
                Using Cmd As New SqlCommand(forceDisconnectQuery, Con)
                    Await Cmd.ExecuteNonQueryAsync()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error dropping temporary database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Async Function SearchByBackUpName(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query naman ng product by name. gamit 'to sa search field.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenBackupConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync

                        Variables.SearchByBackUpId.Clear
                        Variables.SearchByBackUpName.Clear

                        While Await Reader.ReadAsync

                            Variables.SearchByBackUpId.add(Integer.Parse(Reader("backup_id")))
                            Variables.SearchByBackUpName.add(Reader("backup_name").ToString())

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

    Async Function RetrieveValuationBy1Filter(Query As string, ParameterName As String, ParameterValue As String) As Task

        'Query ng product sa product table by 1 filter.

        Using Con As SqlConnection = Await ConnectionStringModule.OpenBackupConnection

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue(ParameterName, ParameterValue)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        GeneralModule.ClearDatabaseBackupList()

                        While Await Reader.ReadAsync()

                            Variables.ListOfBackupId.add(Integer.Parse(Reader("backup_id")))
                            Variables.ListOfBackUpName.add(Reader("backup_name").ToString())
                            Variables.ListOfDirectory.Add(Reader("backup_directory").ToString())
                            Variables.ListOfDateAdded.Add(Reader("date_added").ToString())
                            Variables.ListOfTimeAdded.Add(Reader("time_added").ToString())
                            Variables.ListOfDatabaseAddedBy.Add(Integer.Parse(Reader("added_by")))

                        End While

                    End Using

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Function

End Module
