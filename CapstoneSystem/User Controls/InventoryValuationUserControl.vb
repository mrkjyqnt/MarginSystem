Imports System.Reflection.Metadata.Ecma335

Public Class InventoryValuationUserControl
    Private Sub InventoryValuationUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If InventoryValuationLabel.Text.Substring(0, 1) = "+"

            InventoryValuationLabel.ForeColor = Color.FromArgb(55, 199, 90)

        ElseIf InventoryValuationLabel.Text.Substring(0, 1) = "-"

            InventoryValuationLabel.ForeColor = Color.FromArgb(255, 59, 48)

        End If

        InventoryValuationLabel.Left = ElipseLabel.Left - InventoryValuationLabel.Width - 5

    End Sub

    Private Sub InventoryValuationLabel_MouseEnter(sender As Object, e As EventArgs) Handles InventoryValuationLabel.MouseEnter, NoDateLabel.MouseEnter, ValuationNameLabel.MouseEnter, PlaceholderImage.MouseEnter, MyBase.MouseEnter

        GeneralModule.UserControlToButton(Me, 210)

    End Sub

    Private Async Sub InventoryValuationLabel_Click(sender As Object, e As EventArgs) Handles InventoryValuationLabel.Click, NoDateLabel.Click, ValuationNameLabel.Click, PlaceholderImage.Click, MyBase.Click

        Dim ValuationId As Integer = Integer.Parse(InventoryIdLabel.Text)
        Dim StockId As Integer = Integer.Parse(StockIdLabel.Text)
        Dim TableName As String = "inventory_valuation"
        Dim Parameter As String = "inventory_id"

        InventoryValuationInfo.Opacity = 0

        Dim Symbol As Char = InventoryValuationLabel.Text(0)
        
        
        If Symbol = "-"
            
            InventoryValuationInfo.ShowExpirationPanel = True
            InventoryValuationInfo.ProductNameTextBox.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))
            InventoryValuationInfo.BatchCodeTextBox.Text = Await StockManagementModule.GetBatchFromStock(StockId)
            InventoryValuationInfo.QuantityTextBox.Text = Await GeneralModule.GetColumn("current_stock", "stock", "stock_id", StockId)
            InventoryValuationInfo.ValuationValueTextBox.Text = $"- ₱ {Await GeneralModule.GetColumn("expiration_valuation", TableName, Parameter, ValuationId)}"
            InventoryValuationInfo.ExpirationTextBox.Text = Await GeneralModule.GetColumn("expiration_date", "stock", "stock_id", StockId)
        
        ElseIf Symbol = "+"
            
            InventoryValuationInfo.ShowExpirationPanel = False
            InventoryValuationInfo.ProductNameTextBox1.Text = Await StockManagementModule.GetProductName(Await StockManagementModule.GetProductIdByStockId(StockId))
            InventoryValuationInfo.BatchCodeTextBox1.Text = Await StockManagementModule.GetBatchFromStock(StockId)
            InventoryValuationInfo.QuantityTextBox1.Text = Await GeneralModule.GetColumn("total_stock", "stock", "stock_id", StockId)
            InventoryValuationInfo.RetailValuationTextBox.Text = $"+ ₱ {Await GeneralModule.GetColumn("retail_valuation", TableName, Parameter, ValuationId)}"
            InventoryValuationInfo.WholesaleValuationTextBox.Text = $"+ ₱ {Await GeneralModule.GetColumn("wholesale_valuation", TableName, Parameter, ValuationId)}"
            InventoryValuationInfo.DateTextBox.Text = Await GeneralModule.GetColumn("date_added", TableName, Parameter, ValuationId)
            InventoryValuationInfo.TimeTextBox.Text = Await GeneralModule.GetColumn("time_added", TableName, Parameter, ValuationId)
        
        End If

        GeneralModule.ShowOverlay(MainForm, InventoryValuationInfo)
        GeneralModule.UserControlToButton(Me, 247)
        InventoryValuation.FormPanel.Focus
        InventoryValuation.ActiveControl = InventoryValuation.FormPanel

    End Sub

    Private Sub InventoryValuationLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles InventoryValuationLabel.MouseDown, NoDateLabel.MouseDown, ValuationNameLabel.MouseDown, PlaceholderImage.MouseDown, MyBase.MouseDown

        GeneralModule.UserControlToButton(Me, 147)

    End Sub

    Private Sub InventoryValuationUserControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave

        GeneralModule.UserControlToButton(Me, 247)

    End Sub

End Class
