Public Class EnterPin

    Private PinTextBoxClick As Integer = 0

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close()

    End Sub

    Private Async Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        'Query for the Login ng user.
        MainForm.Opacity = 0
        Await LoginDatabaseModule.LoginQuery(Variables.LoggedInUser, PinTextBox.text, Me, MainForm)

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

    Private Sub PinTextBox_MouseEnter(sender As Object, e As EventArgs) Handles PinTextBox.MouseEnter

        PinTextBox.BorderThickness = 2

    End Sub

    Private Sub PinTextBox_MouseLeave(sender As Object, e As EventArgs) Handles PinTextBox.MouseLeave

        PinTextBox.BorderThickness = 1

    End Sub

    Private Sub EnterPin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        UsernameLabel.Text = Variables.LoggedInUser
        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub PinTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PinTextBox.KeyDown

        If e.KeyValue = Keys.Enter

            ConfirmButton.PerformClick

        End If

    End Sub

    Private Sub PinTextBox_TextChanged(sender As Object, e As EventArgs) Handles PinTextBox.TextChanged

        'Wag delete.

        'If PinTextBox.Text.Length = 4

            'Await LoginDatabaseModule.LoginQuery(Variables.LoggedInUser, PinTextBox.text, Me, MainForm)

        'End If

    End Sub

End Class