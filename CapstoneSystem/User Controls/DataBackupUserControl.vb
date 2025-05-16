Public Class DataBackupUserControl
    Private Sub DeleteButton_MouseEnter(sender As Object, e As EventArgs) Handles DateLabel.MouseEnter, BackupNameLabel.MouseEnter, PlaceholderImage.MouseEnter, DeleteButton.MouseEnter, ExportButton.MouseEnter, RestoreButton.MouseEnter, MyBase.MouseEnter

        GeneralModule.UserControlToButton(Me, 210)

    End Sub

    Private Sub DataBackupUserControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave

        GeneralModule.UserControlToButton(Me, 247)

    End Sub

    Private Sub DataBackupUserControl_MouseDown(sender As Object, e As MouseEventArgs) Handles DateLabel.MouseDown, BackupNameLabel.MouseDown, PlaceholderImage.MouseDown, MyBase.MouseDown

        GeneralModule.UserControlToButton(Me, 147)

    End Sub

    Private Sub DataBackupUserControl_Click(sender As Object, e As EventArgs) Handles DateLabel.Click, BackupNameLabel.Click, PlaceholderImage.Click, MyBase.Click

    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click

        Dim BackupId As Integer = Integer.Parse(IdLabel.Text)
        Dim BackupIndex As Integer = Variables.ListOfBackupId.IndexOf(Integer.Parse(BackupId))

        DeleteBackup.BackDirectory = Variables.ListOfDirectory(BackupIndex)
        DeleteBackup.BackupId = BackupId
        DeleteBackup.BackUpName = BackupNameLabel.Text

        DeleteBackup.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, DeleteBackup)
        GeneralModule.UserControlToButton(Me, 247)
        DataBackupAndRecovery.FormPanel.Focus
        DataBackupAndRecovery.ActiveControl = DataBackupAndRecovery.FormPanel

    End Sub

    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click

        ExportBackup.Opacity = 0
        Dim BackupIndex As Integer = Variables.ListOfBackupId.IndexOf(Integer.Parse(IdLabel.Text))
        ExportBackup.BackupPath = Variables.ListOfDirectory(BackupIndex)
        ExportBackup.BackUpName = Variables.ListOfBackUpName(BackupIndex)
        GeneralModule.ShowOverlay(MainForm, ExportBackup)
        GeneralModule.UserControlToButton(Me, 247)
        DataBackupAndRecovery.FormPanel.Focus
        DataBackupAndRecovery.ActiveControl = DataBackupAndRecovery.FormPanel

    End Sub

    Private Async Sub RestoreButton_Click(sender As Object, e As EventArgs) Handles RestoreButton.Click

        RestoreBackup.Opacity = 0

        Dim BackupIdIndex As Integer = Variables.ListOfBackupId.IndexOf(Integer.Parse(IdLabel.Text))

        Dim oldBackupConn As String = My.Settings.ConString
        Dim newBackupFile As String = Variables.ListOfDirectory(BackupIdIndex)
        Dim tempDbName As String = "TempBackupDB"

        Dim comparisonResult As String = Await DataBackupModule.IsCurrentDatabaseLarger(oldBackupConn, newBackupFile, tempDbName)

        MessageBox.Show(comparisonResult, "Restoration Reminder", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Dim userInput As String
        Do
            userInput = InputBox($"Caution! Restoring backup can alter the data in the system, make sure you have a backup for the current database.{vbCrLf}{vbCrLf}Do you want to restore the backup?{vbCrLf}Enter 1 for Yes, 0 for No.", "Backup Restoration")

            If String.IsNullOrWhiteSpace(userInput) Then
                Exit Do
            ElseIf userInput = "1" Then
                RestoreBackup.BackupIdIndex = BackupIdIndex
                GeneralModule.ShowOverlay(MainForm, RestoreBackup)
                GeneralModule.UserControlToButton(Me, 247)
                Exit Do
            ElseIf userInput = "0" Then
                Exit Do
            Else
                MessageBox.Show("Invalid input! Please enter 0 to cancel or 1 to restore the backup.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Loop

        DataBackupAndRecovery.FormPanel.Focus
        DataBackupAndRecovery.ActiveControl = DataBackupAndRecovery.FormPanel

    End Sub
End Class
