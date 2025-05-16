Imports System.Net.Mail

Public Class ModifyPin

    Private recentCode As Integer

    Private Sub SendEmail(recipient As String, code As Integer)
        Try
            Dim mail As New MailMessage() With {
                .From = New MailAddress("06.stewei@gmail.com"),
                .Subject = "Personal Identification Number Change Request",
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

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Close
        Dispose

    End Sub

    Private Sub ModifyPin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Size = New Size(505, 311)
        GeneralModule.FadeInForm(Me)

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

    Private Async Sub SaveButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        Dim enteredCode As Integer

        If Integer.TryParse(CodeTextBox.Text, enteredCode) Then
            If enteredCode = recentCode Then
                MessageBox.Show("Verification successful!", "Change PIN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CurrentPINTextBox.Text = Await LoginDatabaseModule.GetPin(Variables.LoggedInUser)
                PanelEmail.Hide
                Size = New Size(408, 296)
                PanelChangePin.Show
            Else
                MessageBox.Show("Incorrect code. Please try again.")
                CodeTextBox.Clear
            End If
        Else
            MessageBox.Show("Please enter a valid numeric code.")
        End If

    End Sub

    Private Sub ShadowButton1_Click(sender As Object, e As EventArgs) Handles ShadowButton1.Click

        Close
        Dispose

    End Sub

    Private Async Sub SaveButton_Click_1(sender As Object, e As EventArgs) Handles SaveButton.Click

        Dim NewPin As String = NewPINTextBox.Text
        Dim Repeat As String = NewPINTextBox1.Text

        If String.IsNullOrEmpty(NewPin)

            MessageBox.Show("Provide a new PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If String.IsNullOrEmpty(Repeat)

            MessageBox.Show("Repeat your new PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If NewPin.Length <> Repeat.Length

            MessageBox.Show("PIN's are not the same length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If NewPin <> Repeat

            MessageBox.Show("PIN's are not the same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If NewPin.Length > 4 OrElse NewPin.Length > 4

            MessageBox.Show("Only 4 Digit PIN is allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        Dim UserId As Integer = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
        Await LoginDatabaseModule.UpdatePIN(NewPin, UserId)
        GeneralModule.CloseOverLay(LoadingScreen)
        Close
        Dispose

    End Sub

    Private Sub NewPINTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NewPINTextBox.KeyPress

        GeneralModule.CheckNumericNumber(e, NewPINTextBox)

    End Sub

    Private Sub NewPINTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NewPINTextBox1.KeyPress

        GeneralModule.CheckNumericNumber(e, NewPINTextBox1)

    End Sub

End Class