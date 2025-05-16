Public Class ProductImage
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click

        Hide

    End Sub

    Private Sub ProductImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

    End Sub
End Class