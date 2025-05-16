Public Class ProductInfo

    Public BarcodeText As String = String.Empty
    Public Clicked As Boolean = False

    Private Sub ProductInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        GeneralModule.CloseOverLay(Barcode)
        GeneralModule.CloseOverLay(Me)

    End Sub

    Private Sub BarcodeImage_Click(sender As Object, e As EventArgs) Handles BarcodeImage.Click

        Hide
        Barcode.Opacity = 0

        Barcode.ProductCodeText = BarcodeText
        Barcode.BarcodeImage.Show
        Barcode.label2.Hide
        Barcode.Label3.Show
        Barcode.Label1.Text = "Product Barcode"
        Barcode.ProductCodeTextBox.Hide
        Clicked = True
        GeneralModule.ShowOverlay(MainForm, Barcode)
        Show

    End Sub

    Private Sub ImageButton_Click(sender As Object, e As EventArgs) Handles ImageButton.Click

        Hide
        ProductImage.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, ProductImage)
        Show

    End Sub
End Class