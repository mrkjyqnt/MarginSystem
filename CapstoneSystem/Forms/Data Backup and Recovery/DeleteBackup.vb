Imports System.Net.Mail

Public Class DeleteBackup

    Dim PIN As String

    Public BackDirectory As String
    Public BackupId As Integer
    Public BackUpName As String

    Private PinTextBoxClick As Integer = 0
    Private recentCode As Integer

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close
        Me.Dispose

    End Sub

    Private Sub DeleteBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Async Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        PIN = PinTextBox.Text
        Dim Passcode As String = Await LoginDatabaseModule.GetPin(Variables.LoggedInUser)

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

        Dim enteredCode As Integer

        If Integer.TryParse(CodeTextBox.Text, enteredCode) Then
            If enteredCode = recentCode Then
                DataBackupModule.DeleteBackupFile(BackDirectory, BackupId)
            Else
                MessageBox.Show("Incorrect code. Please try again.")
                CodeTextBox.Clear
                Exit Sub
            End If
        Else
            MessageBox.Show("Please enter a valid numeric code.")
            Exit Sub
        End If

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()

        Dim BackUpQuery As String = "SELECT * FROM system_backup ORDER BY backup_id DESC"
        GeneralModule.DeleteUserControls(DataBackupAndRecovery.FormPanel)
        Await DataBackupModule.RetrieveALL(BackUpQuery)
        DataBackupAndRecovery.CreateDatabaseUserControl()
        GeneralModule.CloseOverLay(LoadingScreen)

        If DataBackupAndRecovery.FormPanel.Controls.OfType(Of DataBackupUserControl).Any
            DataBackupAndRecovery.Label10.Hide
            DataBackupAndRecovery.Label3.show
            DataBackupAndRecovery.Label3.Text = DataBackupAndRecovery.FormPanel.Controls.OfType(Of DataBackupUserControl).Count & " Backups found"

        Else

            DataBackupAndRecovery.Label10.Show
            DataBackupAndRecovery.Label3.Hide

        End If

        Close
        Dispose

        Application.Restart()
        Environment.Exit(0) 

    End Sub

    Private Sub PinTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PinTextBox.KeyDown

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

    Private Sub SendEmail(recipient As String, code As Integer)
        Try
            Dim mail As New MailMessage() With {
                .From = New MailAddress("06.stewei@gmail.com"),
                .Subject = "Personal Identification Number for Deletion of Backup",
                .Body = "Your request code is: " & code
            }
            mail.To.Add(recipient)

            Dim SmtpServer As New SmtpClient("smtp-relay.brevo.com") With {
                .Port = 587,
                .Credentials = New System.Net.NetworkCredential("Username", "Password"),
                .EnableSsl = True
            }

            SmtpServer.Send(mail)
            MessageBox.Show("Code sent successfully to your email.")

            ' Store the recent code
            recentCode = code

        Catch ex As Exception
            MessageBox.Show("Error sending email: " & ex.Message)
        End Try

    End Sub

    Private Sub GetCodeButton_Click(sender As Object, e As EventArgs) Handles GetCodeButton.Click

        LoadingScreen.Show
        Enabled = False
        Dim recipient As String = EmailTextBox.Text
        Dim generatedCode As Integer = New Random().Next(100000, 999999)

        If Not String.IsNullOrEmpty(recipient) Then
            SendEmail(recipient, generatedCode)
        Else
            MessageBox.Show("Please enter a valid email address.")
        End If
        Enabled = True
        LoadingScreen.Close
        LoadingScreen.Dispose

    End Sub
End Class