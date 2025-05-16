Public Class ProfileSettings

    Private PinTextBoxClick As Integer = 0

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close
        Me.Dispose

    End Sub

    Private Async Sub ProfileSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim PIN As String = Await LoginDatabaseModule.GetPin(Variables.LoggedInUser)
        NameTextBox.Text = Variables.LoggedInUser
        PINTextBox.Text = PIN
        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub CurrentPINTextBox_IconRightClick(sender As Object, e As EventArgs) Handles PINTextBox.IconRightClick

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