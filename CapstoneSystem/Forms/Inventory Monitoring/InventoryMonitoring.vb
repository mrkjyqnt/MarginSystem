Public Class InventoryMonitoring
    Private Sub RecordSaleButton_Click(sender As Object, e As EventArgs) Handles RecordSaleButton.Click

        RecordSale.ProductComboBox.Focus
        GeneralModule.ShowOverlay(MainForm, RecordSale)

    End Sub

    Private Sub InventoryTransactionButton_Click(sender As Object, e As EventArgs) Handles InventoryTransactionButton.Click, InventoryLabel2.Click, InventoryLabel1.Click, InventoryImage1.Click, InventoryImage2.Click

        MainForm.Opacity = 0
        Cursor = Cursors.WaitCursor
        MainForm.InventoryMonitorFormPanel.Controls.Clear
        GeneralModule.ChooseNavigation(MainForm.InventoryMonitoringPanel, MainForm.InventoryMonitoringButton, "Hovered", "Monitor", GeneralModule.ButtonDictionary, "Inventory Monitoring", InventoryTransactions, MainForm.InventoryMonitorFormPanel)
        InventoryTransactions.ActiveControl = InventoryTransactions.FormPanel
        GeneralModule.PanelToButton(InventoryTransactionButton, InventoryImage1, InventoryImage2, 247, "Truck", "More")
        GeneralModule.FadeInForm(MainForm)
        Cursor = Cursors.Default


    End Sub

    Private Sub InventoryTransactionButton_MouseEnter(sender As Object, e As EventArgs) Handles InventoryTransactionButton.MouseEnter, InventoryLabel2.MouseEnter, InventoryLabel1.MouseEnter, InventoryImage1.MouseEnter, InventoryImage2.MouseEnter

        GeneralModule.PanelToButton(InventoryTransactionButton, InventoryImage1, InventoryImage2, 210, "HoveredTruck", "HoveredMore")

    End Sub

    Private Sub InventoryTransactionButton_MouseLeave(sender As Object, e As EventArgs) Handles InventoryTransactionButton.MouseLeave

        GeneralModule.PanelToButton(InventoryTransactionButton, InventoryImage1, InventoryImage2, 247, "Truck", "More")

    End Sub

    Private Sub InventoryTransactionButton_MouseDown(sender As Object, e As MouseEventArgs) Handles InventoryTransactionButton.MouseDown, InventoryLabel2.MouseDown, InventoryLabel1.MouseDown, InventoryImage1.MouseDown, InventoryImage2.MouseDown

        GeneralModule.PanelToButton(InventoryTransactionButton, InventoryImage1, InventoryImage2, 147, "HoveredTruck", "HoveredMore")

    End Sub

    Private Sub InventoryMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class