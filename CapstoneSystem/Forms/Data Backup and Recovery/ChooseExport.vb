Public Class ChooseExport

    Public BackupPath As String
    Public BackUpName As String

    Private Sub ChooseExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Async Sub LocalButton_Click(sender As Object, e As EventArgs) Handles LocalButton.Click

        Await DataBackupModule.ExportBackUp(BackupPath, BackUpName)

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()
        GeneralModule.CloseOverLay(LoadingScreen)

        GeneralModule.CloseOverLay(ExportBackup)
        Close
        Dispose

    End Sub

    Private Async Sub GdriveButton_Click(sender As Object, e As EventArgs) Handles GdriveButton.Click

        Await DataBackupModule.UploadToGoogleDrive(BackupPath)

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()
        GeneralModule.CloseOverLay(LoadingScreen)

        GeneralModule.CloseOverLay(ExportBackup)
        Close
        Dispose

    End Sub

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        GeneralModule.CloseOverLay(ExportBackup)
        Close
        Dispose

    End Sub

End Class