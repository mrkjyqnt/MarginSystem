Imports Newtonsoft.Json.Linq

Public Class UpdateStock

    Public WhatToUpdate As String
    Public StockId As Integer

    Private Async Sub UpdateStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If WhatToUpdate = "Expiration"

            Label1.Text = "Update Expiration Date"
            ExpirationDateTime.Show

            NewTextBox.Hide
            Label9.Hide
            WarehouseComboBox.Hide

        ElseIf WhatToUpdate = "Stock"

            Label1.Text = "Update Stock Quantity"
            NewTextBox.Show

            ExpirationDateTime.Hide
            Label9.Hide
            WarehouseComboBox.Hide

        ElseIf WhatToUpdate = "Warehouse"

            Label1.Text = "Update Warehouse"
            WarehouseComboBox.Show
            Label9.Show

            Dim ListOfWarehouse As List(Of Object)
            ListOfWarehouse = Await StockManagementModule.GetWarehouses()
            ListOfWarehouse.ToString

            For Each Item As String In ListOfWarehouse

                WarehouseComboBox.Items.Add(Item)


            Next

            ExpirationDateTime.Hide
            NewTextBox.Hide

        End If


    End Sub

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Hide
        ChooseUpdate.Opacity = 0
        GeneralModule.FadeInForm(ChooseUpdate)
        GeneralModule.ShowOverlay(MainForm, ChooseUpdate)
        WhatToUpdate = String.Empty

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

        WarehouseComboBox.DroppedDown = True

    End Sub

    Private Async Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        If WhatToUpdate = "Expiration"

            Dim NewExpiration As String = ExpirationDateTime.Value.ToString("MMMM d, yyyy").ToString
            Await StockManagementModule.UpdateStockInfo("expiration_date", NewExpiration, StockId)

        ElseIf WhatToUpdate = "Stock"

            Dim StockValue As String = NewTextBox.Text

            If Not IsNumeric(StockValue) Then
                MessageBox.Show("The value of stock must be a valid value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                NewTextBox.Clear
                Exit Sub
            End If

            Await StockManagementModule.UpdateStockInfo("current_stock", StockValue, StockId)

        ElseIf WhatToUpdate = "Warehouse"

            If WarehouseComboBox.SelectedIndex < 0
                MessageBox.Show("Select a valid warehouse.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim Warehouse As String = WarehouseComboBox.SelectedItem.ToString
            Dim WarehouseId As Integer = Await StockManagementModule.GetWarehouseId(Warehouse)
            Await StockManagementModule.UpdateStockInfo("warehouse_id", WarehouseId, StockId)

        End If

    End Sub

    Private Sub NewTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NewTextBox.KeyPress

        GeneralModule.CheckNumericNumber(e, NewTextBox)

    End Sub

    Private Sub WarehouseComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WarehouseComboBox.SelectedIndexChanged

    End Sub
End Class