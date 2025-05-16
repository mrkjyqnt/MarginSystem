Public Class InventoryTransactionInfo
    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close
        Me.Dispose

    End Sub

    Private Sub InventoryTransactionInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If TypeTextBox.Text = "Added"

            TypeTextBox.ForeColor = Color.FromArgb(51, 199, 90)

        ElseIf TypeTextBox.Text = "Removed"

            TypeTextBox.ForeColor = Color.FromArgb(255, 59, 48)

        ElseIf TypeTextBox.Text = "Sold"

            TypeTextBox.ForeColor = Color.FromArgb(39, 110, 241)

        End If

        GeneralModule.FadeInForm(Me)

    End Sub
End Class