Public Class SaleInfo
    Private Sub SaleInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close
        Me.Dispose

    End Sub
End Class