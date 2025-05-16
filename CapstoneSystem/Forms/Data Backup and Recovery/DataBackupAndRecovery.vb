Imports System.IO
Imports Microsoft.Data.SqlClient

Public Class DataBackupAndRecovery

    Private Sub DataBackupAndRecovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        HorizontalScroll.Visible = False
        If FormPanel.Controls.OfType(Of DataBackupUserControl).Any
            Label10.Hide
            Label3.show
            Label3.Text = FormPanel.Controls.OfType(Of DataBackupUserControl).Count & " Backups found"

        Else

            Label10.Show
            Label3.Hide

        End If

    End Sub

    Private Sub NewProductButton_Click(sender As Object, e As EventArgs) Handles NewProductButton.Click

        CreateBackUp.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, CreateBackup)

        If FormPanel.Controls.OfType(Of DataBackupUserControl).Any
            Label10.Hide
            Label3.show
            Label3.Text = FormPanel.Controls.OfType(Of DataBackupUserControl).Count & " Backups found"

        Else

            Label10.Show
            Label3.Hide

        End If

        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Sub BackupLabel_MouseEnter(sender As Object, e As EventArgs) Handles BackupButton.MouseEnter, BackupLabel.MouseEnter, Image1.MouseEnter, Image2.MouseEnter

        PanelToButton(BackupButton, Image1, Image2, 210, "HoveredSettings", "HoveredGenerate")

    End Sub

    Private Sub BackupLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles BackupButton.MouseDown, BackupLabel.MouseDown, Image1.MouseDown, Image2.MouseDown

        PanelToButton(BackupButton, Image1, Image2, 147, "HoveredSettings", "HoveredGenerate")

    End Sub

    Private Sub BackupLabel_Click(sender As Object, e As EventArgs) Handles BackupButton.Click, BackupLabel.Click, Image1.Click, Image2.Click

        ShowOverlay(MainForm, BackupOptions)

    End Sub

    Private Sub BackupButton_MouseLeave(sender As Object, e As EventArgs) Handles BackupButton.MouseLeave

        PanelToButton(BackupButton, Image1, Image2, 247, "Settings", "Generate")

    End Sub

    Public Sub CreateUserControl(BackUpId As Integer, BackUpName As String, DateAdded As String)

        Dim VerticalMargin As Integer = 5
        Dim ControlHeight As Integer = 100

        Dim ControlWidth As Integer = FormPanel.ClientSize.Width - 6

        'Ni ca-calculate nito yung height control hanggang bottom
        Dim MaxBottom As Integer = 0

        For Each Ctrl As Control In FormPanel.Controls
            'Exclude the SearchFlowLayoutPanel
            If Ctrl.Name <> "ResultSearchPanel" Then
                If Ctrl.Bottom > MaxBottom Then
                    MaxBottom = Ctrl.Bottom
                End If
            End If
        Next

        Dim NewYPosition As Integer = MaxBottom + VerticalMargin

        Dim NewBackUp As New DataBackupUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(3, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }

        NewBackUp.IdLabel.Text = BackUpId
        NewBackUp.BackupNameLabel.Text = BackUpName
        NewBackUp.DateLabel.Text = DateAdded

        FormPanel.Controls.Add(NewBackUp)

    End Sub

    Sub CreateDatabaseUserControl()

        'Mag produce ng user controls.

        For i As Integer = 0 To ListOfBackupId.Count - 1

            CreateUserControl(Variables.ListOfBackupId(i), Variables.ListOfBackUpName(i), Variables.ListOfDateAdded(i))

        Next

    End Sub

    Private Sub HideSearchFlowLayout

        If ResultSearchPanel.Visible

            ResultSearchPanel.Hide

        End If

    End Sub

    Private Async Sub DateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If DateComboBox.SelectedIndex > -1

            Variables.BackUpByDate = DateComboBox.SelectedItem.ToString()
            Variables.BackUpNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.BackUpFilterBy, Variables.BackUpByDate, Variables.BackUpSortBy)

            Dim Query As String = ""
            Dim TotalBackup As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.BackUpNumberOfFilters = 1 Then

                Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}'"

            ElseIf Variables.BackUpNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.BackUpSortBy) AndAlso String.IsNullOrEmpty(Variables.BackUpFilterBy) Then

                    Select Case Variables.BackUpSortBy

                        Case "A - Z"

                            Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}' ORDER BY backup_name ASC"

                        Case "Z - A"

                            Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}' ORDER BY backup_name DESC"

                        Case "New First"

                            Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}' ORDER BY backup_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}' ORDER BY backup_id ASC"

                    End Select

                End If

            End If

            Await CreateBackUps(Query, TotalBackup)

        End If

    End Sub

    Async Function CreateBackUps(Query As String, Total As Integer) As Task

        Await DataBackupModule.RetrieveAll(Query)
        Total = Variables.ListOfBackupId.Count
        CreateDatabaseUserControl
        Label3.Text = Total & " Backups found"
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Function

    Private Async Sub SortByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortByComboBox.SelectedIndexChanged

        HideSearchFlowLayout()

        If SortByComboBox.SelectedIndex > -1

            Variables.BackUpSortBy = SortByComboBox.SelectedItem.ToString()
            Variables.BackUpNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.BackUpFilterBy, Variables.BackUpByDate, Variables.BackUpSortBy)

            Dim Query As String = ""
            Dim TotalBackup As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.BackUpNumberOfFilters = 1 Then

                Select Case Variables.BackUpSortBy

                    Case "A - Z"

                        Query = $"SELECT * FROM system_backup ORDER BY backup_name ASC"

                    Case "Z - A"

                        Query = $"SELECT * FROM system_backup ORDER BY backup_name DESC"

                    Case "New First"

                        Query = $"SELECT * FROM system_backup ORDER BY backup_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM system_backup ORDER BY backup_id ASC"

                End Select

            ElseIf Variables.BackUpNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.BackUpByDate) AndAlso String.IsNullOrEmpty(Variables.BackUpFilterBy) Then

                    Select Case Variables.BackUpSortBy

                        Case "A - Z"

                            Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}' ORDER BY backup_name ASC"

                        Case "Z - A"

                            Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}' ORDER BY backup_name DESC"

                        Case "New First"

                            Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}' ORDER BY backup_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM system_backup WHERE date_added LIKE '{Variables.BackUpByDate}%' + '{Variables.CurrentYear}' ORDER BY backup_id ASC"

                    End Select

                End If

            End If

            Await CreateBackUps(Query, TotalBackup)

        End If

    End Sub

    Private Async Sub ClearAllFiltersButton_Click(sender As Object, e As EventArgs) Handles ClearAllFiltersButton.Click

        'Ireremove lahat ng filter then show all.

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        HideSearchFlowLayout()

        Variables.BackUpNumberOfFilters = 0
        Variables.BackUpFilterBy = String.Empty
        Variables.BackUpFilterBy = String.Empty
        Variables.BackUpSortBy = String.Empty

        SearchTextBox.Clear
        SortByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim BackUpQuery As String = "SELECT * FROM system_backup ORDER BY backup_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await DataBackupModule.RetrieveALL(BackUpQuery)
        CreateDatabaseUserControl()

        Dim TotalBackup As Integer = Variables.ListOfBackupId.Count
        label3.Text = TotalBackup & " Backups found"

        ' Hide loading screen
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Private Async Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged

        'Searching naman sa pangalan ng Product

        Dim Query As String
        Dim CountFlag As Integer
        Dim PanelNewHeight As Integer

        If Not String.IsNullOrEmpty(SearchTextBox.Text)

            ResultSearchPanel.Controls.Clear

            Query = " SELECT * FROM system_backup WHERE backup_name LIKE '%' + @BackUpName + '%' ORDER BY backup_id DESC"

            Await DataBackupModule.SearchByBackUpName(Query, "@BackUpName", SearchTextBox.Text)

            If Variables.SearchByBackUpId.Count > 0

                GeneralModule.CreateBackupSearchUserControl

                'Mag lo-loop sa mga search control then kukuhain yung bottom ng 5th control
                For Each Cntrl As Control In ResultSearchPanel.Controls.OfType(Of DataBackupSearchUserControl)

                    CountFlag += 1
                    PanelNewHeight = Cntrl.Bottom

                    If CountFlag = 5

                        Exit For

                    End If

                Next

                'I se-set sa panel ang bottom as height
                ResultSearchPanel.Height = PanelNewHeight + 3
                ResultSearchPanel.SetDoubleBuffered(True)
                ResultSearchPanel.Show

            Else

                HideSearchFlowLayout

            End If

        Else

            HideSearchFlowLayout

        End If

    End Sub

    Public Sub CreateSearchUserControl(BackupId As Integer, BackupName As String)

        'Creation naman ito ng product user control sa search bar.
        Dim VerticalMargin As Integer = 5
        Dim ControlHeight As Integer = 50
        Dim ControlWidth As Integer = ResultSearchPanel.ClientSize.Width - 6

        'Ni ca-calculate nito yung height control hanggang bottom
        Dim MaxBottom As Integer = 0

        For Each Ctrl As Control In ResultSearchPanel.Controls

            If Ctrl.Bottom > MaxBottom Then
                MaxBottom = Ctrl.Bottom
            End If

        Next

        Dim NewYPosition As Integer = MaxBottom + VerticalMargin

        Dim BackUpSearch As New DataBackupSearchUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(1, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }
        BackUpSearch.BackupNameLabel.Text = BackupName
        BackUpSearch.BackupIdLabel.Text = BackupId

        ResultSearchPanel.Controls.Add(BackUpSearch)

    End Sub

    Private Sub ResultSearchPanel_MouseEnter(sender As Object, e As EventArgs) Handles ResultSearchPanel.MouseEnter

        If ResultSearchPanel.Visible

            ActiveControl = ResultSearchPanel

        End If

    End Sub

    Private Sub ResultSearchPanel_MouseLeave(sender As Object, e As EventArgs) Handles ResultSearchPanel.MouseLeave

        If ResultSearchPanel.Visible

            SearchTextBox.Focus

        End If

    End Sub

    Private Async Sub ImportBackupButton_Click(sender As Object, e As EventArgs) Handles ImportBackupButton.Click

        ' Open file dialog to select the backup file
        Using openFileDialog As New OpenFileDialog

            openFileDialog.Filter = "Backup Files (*.bak)|*.bak"
            openFileDialog.Title = "Select Database Backup File"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim backupFilePath As String = openFileDialog.FileName
                Dim backupFileName As String = Path.GetFileName(backupFilePath)

                ' Validate file extension
                If Path.GetExtension(backupFilePath).ToLower() <> ".bak" Then
                    MessageBox.Show("Invalid file selected. Please choose a valid .bak file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' Validate if the file exists
                If Not File.Exists(backupFilePath) Then
                    MessageBox.Show("Selected file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim oldBackupConn As String = My.Settings.ConString
                Dim newBackupFile As String = backupFilePath
                Dim tempDbName As String = "TempBackupDB"

                Dim comparisonResult As String = Await DataBackupModule.IsCurrentDatabaseLarger(oldBackupConn, newBackupFile, tempDbName)

                MessageBox.Show(comparisonResult, "Restoration Reminder", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Dim userInput As String
                Do
                    userInput = InputBox($"Caution! Restoring backup can alter the data in the system, make sure you have a backup for the current database.{vbCrLf}{vbCrLf}Do you want to restore the backup?{vbCrLf}Enter 1 for Yes, 0 for No.", "Backup Restoration")

                    If String.IsNullOrWhiteSpace(userInput) Then
                        Exit Do
                    ElseIf userInput = "1" Then
                        RestoreBackup.Opacity = 0
                        RestoreBackup.BackUpNameDirectory = backupFilePath
                        RestoreBackup.RestoreByOuter = True
                        GeneralModule.ShowOverlay(MainForm, RestoreBackup)
                        Exit Do
                    ElseIf userInput = "0" Then
                        Exit Do
                    Else
                        MessageBox.Show("Invalid input! Please enter 0 to cancel or 1 to restore the backup.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Loop

                FormPanel.Focus
                ActiveControl = FormPanel

            End If

        End Using

    End Sub

    Private Async Sub SearchTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchTextBox.KeyDown

        Variables.BackUpNumberOfFilters = 0
        Variables.BackUpFilterBy = String.Empty
        Variables.BackUpByDate = String.Empty
        Variables.BackUpSortBy = String.Empty

        DateComboBox.SelectedIndex = -1
        SortByComboBox.SelectedIndex = -1

        Dim Query As String
        Dim TotalBackupSearched As Integer

        If e.KeyCode = Keys.Enter Then

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

            If String.IsNullOrEmpty(SearchTextBox.Text) Then

                TotalBackupSearched = FormPanel.Controls.OfType(Of DataBackupUserControl).Count
                MessageBox.Show("Put the backup name in the field", "Provide Backup Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                TotalBackupSearched = Variables.SearchByBackUpId.Count

                If TotalBackupSearched = 0 Then

                    MessageBox.Show("No related backup found.", "Backup Non-Existent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    GeneralModule.DeleteUserControls(FormPanel)

                Else

                    GeneralModule.DeleteUserControls(FormPanel)
                    ResultSearchPanel.Hide()

                    For Each Item In Variables.SearchByBackUpId

                        Query = "SELECT * FROM system_backup WHERE backup_id = @BackUpId"
                        Await DataBackupModule.RetrieveValuationBy1Filter(Query, "@BackUpId", Item)
                        CreateDatabaseUserControl()

                    Next

                End If

            End If

            SearchTextBox.Clear()
            GeneralModule.CloseOverLay(LoadingScreen)
            FormPanel.Focus
            ActiveControl = FormPanel
            Label3.Text = TotalBackupSearched & " Backups found"

        End If

    End Sub
End Class