Public Class ExportBackup

    Dim PIN As String
    Public BackupPath As String
    Public BackUpName As String

    Private PinTextBoxClick As Integer = 0

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close
        Me.Dispose

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

        Hide
        ChooseExport.BackupPath = BackupPath
        ChooseExport.BackUpName = BackUpName
        ChooseExport.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, ChooseExport)

    End Sub

    Private Sub ExportBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

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
End Class