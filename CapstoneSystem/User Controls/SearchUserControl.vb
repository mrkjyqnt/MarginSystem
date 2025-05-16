Public Class SearchUserControl
    Private Sub ProductIdLabel_MouseEnter(sender As Object, e As EventArgs) Handles ProductIdLabel.MouseEnter, ProductNameLabel.MouseEnter, PlaceholderImage.MouseEnter, Guna2Panel1.MouseEnter

        ProductManagement.ActiveControl = ProductManagement.ResultSearchPanel

    End Sub

    Private Async Sub SearchUserControl_Click(sender As Object, e As EventArgs) Handles ProductIdLabel.Click, ProductNameLabel.Click, PlaceholderImage.Click, Guna2Panel1.Click, MyBase.Click

        ProductInfo.Opacity = 0
        Dim ProductId As Integer = Integer.Parse(IdLabel.Text)
        Dim Query As String = "SELECT * FROM product WHERE product_id = @ProductID AND active = 1"
        Await ProductManagementDatabaseModule.RetrieveSearchProduct(Query, ProductId)
        GeneralModule.ShowOverlay(MainForm, ProductInfo)
        ProductManagement.FormPanel.Focus()
        ProductManagement.ActiveControl = ProductManagement.ResultSearchPanel

    End Sub

End Class
