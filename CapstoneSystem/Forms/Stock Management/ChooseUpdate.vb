Public Class ChooseUpdate

    Public StockId As Integer

    Private Async Sub ExpirationButton_Click(sender As Object, e As EventArgs) Handles ExpirationButton.Click

        Hide
        UpdateStock.Opacity = 0
        UpdateStock.WhatToUpdate = "Expiration"
        UpdateStock.StockId = StockId
        UpdateStock.OldTextBox.Text = Await GeneralModule.GetColumn("expiration_date", "stock", "stock_id", StockId)
        GeneralModule.FadeInForm(UpdateStock)
        GeneralModule.ShowOverlay(MainForm, UpdateStock)

    End Sub

    Private Async Sub StockButton_Click(sender As Object, e As EventArgs) Handles StockButton.Click

        Hide
        UpdateStock.Opacity = 0
        UpdateStock.WhatToUpdate = "Stock"
        UpdateStock.StockId = StockId
        UpdateStock.OldTextBox.Text = Await GeneralModule.GetColumn("current_stock", "stock", "stock_id", StockId)
        GeneralModule.FadeInForm(UpdateStock)
        GeneralModule.ShowOverlay(MainForm, UpdateStock)

    End Sub

    Private Async Sub WarehouseButton_Click(sender As Object, e As EventArgs) Handles WarehouseButton.Click

        Hide
        UpdateStock.Opacity = 0
        UpdateStock.WhatToUpdate = "Warehouse"
        UpdateStock.StockId = StockId
        UpdateStock.OldTextBox.Text = Await StockManagementModule.GetWarehouse(Await GeneralModule.GetColumn("warehouse_id", "stock", "stock_id", StockId))
        GeneralModule.FadeInForm(UpdateStock)
        GeneralModule.ShowOverlay(MainForm, UpdateStock)

    End Sub

    Private Sub ChooseUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Async Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(Activities.FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await Activities.CreateActivityUserControl()
        GeneralModule.CloseOverLay(Me)
        UpdateStock.Close
        UpdateStock.Dispose

    End Sub
End Class