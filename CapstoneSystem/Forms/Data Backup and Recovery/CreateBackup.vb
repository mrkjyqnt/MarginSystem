Imports System.DirectoryServices
Imports System.IO

Public Class CreateBackup

    Dim PIN As String

    Public BackUpName As String
    Private PinTextBoxClick As Integer = 0


    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close
        Me.Dispose

    End Sub

    Private Async Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        PIN = PinTextBox.Text
        BackUpName = BackUpNameTextBox.Text

        Dim Passcode As String = Await LoginDatabaseModule.GetPin(Variables.LoggedInUser)

        If String.IsNullOrEmpty(BackUpName)

            MessageBox.Show("Provide a Backup Name", "Invalid Backup File Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BackUpNameTextBox.Focus
            Exit Sub

        End If

        If String.IsNullOrEmpty(PIN)

            MessageBox.Show("Provide your PIN", "Security Identification", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PinTextBox.Focus
            Exit Sub

        End If

        If PIN <> Passcode

            MessageBox.Show("Incorrect PIN", "Invalid Identification Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PinTextBox.Clear
            PinTextBox.Focus
            Exit Sub

        End If

        Dim directoryPath As String = "C:\Margins Database Backup\"
        Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
        Dim backupFileName As String = $"{BackUpName}_{timestamp}.bak"
        Dim backupFilePath As String = Path.Combine(directoryPath, backupFileName)

        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        Await DataBackupModule.GenerateBackup(backupFileName, backupFilePath, DateAdded, TimeAdded, Variables.AddedBy)

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()

        Dim BackUpQuery As String = "SELECT * FROM system_backup ORDER BY backup_id DESC"
        GeneralModule.DeleteUserControls(DataBackupAndRecovery.FormPanel)
        Await DataBackupModule.RetrieveALL(BackUpQuery)
        DataBackupAndRecovery.CreateDatabaseUserControl()
        GeneralModule.CloseOverLay(LoadingScreen)

        Close
        Dispose

    End Sub

    Private Sub CreateBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub PinTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PinTextBox.KeyDown, BackUpNameTextBox.KeyDown

        If e.KeyCode = Keys.Enter

            ConfirmButton.PerformClick

        End If

    End Sub

    Private Sub PinTextBox_TextChanged(sender As Object, e As EventArgs) Handles PinTextBox.TextChanged

    End Sub

    Private Sub PinTextBox_IconRightClick(sender As Object, e As EventArgs) Handles PinTextBox.IconRightClick

        PinTextBoxClick += 1

        If PinTextBoxClick Mod 2 = 1 Then

            'Show password real value
            PinTextBox.IconRight = My.Resources.Show
            PinTextBox.UseSystemPasswordChar = False
            PinTextBox.PasswordChar = ""


        Else

            'I-hide yung real password.
            PinTextBox.IconRight = My.Resources.Hide
            PinTextBox.UseSystemPasswordChar = True
            PinTextBox.PasswordChar = "●"

        End If

    End Sub
End Class