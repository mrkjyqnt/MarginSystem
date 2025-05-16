Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports Guna.UI2.WinForms.Suite
Imports Microsoft.Data.SqlClient
Module GeneralModule

    Sub ShowOverlayForm(FormToShow As Form, SizeOfOverlay As Form)

        'Display form na hindi nag rerequire na naka-showdialog and overlay.
        'Since hindi gumagana ang asynchronous operation 'pag naka show dialog ang form.
        Overlay.Show()
        Overlay.Size = SizeOfOverlay.ClientSize
        Overlay.Location = SizeOfOverlay.PointToScreen(New Point(0, 0))
        FormToShow.Show
        FormToShow.TopMost = True
        SizeOfOverlay.Enabled = False

    End Sub

    Sub CloseOverLay(FormToHide As Form)

        'I close yung form and overlay.
        Overlay.Close()
        Overlay.Dispose()
        FormToHide.Close()
        FormToHide.Dispose()
        MainForm.Enabled = True
End Sub

    Public Sub ShowOverlay(FormSize As form, FormShowDiaglog As form)

        'Show overlay and form that requires show dialog lalo na yung hindi nag re-require ng async operations.
        Overlay.Show()
        Overlay.Size = FormSize.ClientSize
        Overlay.Location = FormSize.PointToScreen(New Point(0, 0))
        AddHandler FormShowDiaglog.FormClosed, Sub()
Overlay.Close()
                                           End Sub
        FormShowDiaglog.ShowDialog()

    End Sub

    Public Sub ChangeFillColor(PanelName As Guna.UI2.WinForms.Guna2Panel, Red As Integer, Green As Integer, Blue As Integer)

        PanelName.FillColor = Color.FromArgb(Red, Green, Blue)

    End Sub

    'Act as flag. Para ma keep track kung anong button sa managements ang na click.
    Public ButtonDictionary As New Dictionary(Of String, Boolean) From {
        {"Dashboard", False},
        {"Product Management", False},
        {"Stock Management", False},
        {"Inventory Monitoring", False},
        {"Valuation and Reports", False},
        {"Data Backup and Recovery", False},
        {"Account", False}
    }


    Public Sub ChooseNavigation(PanelName As Guna.UI2.WinForms.Guna2Panel, ButtonName As Guna.UI2.WinForms.Guna2Button, NewPicture As String, Picture As String,
ButtonDict As Dictionary(Of String, Boolean), KeyName As string, FormName As Form, PanelForm As Guna.UI2.WinForms.Guna2Panel)

'Paras sa animation ng panel ng managements para mag mukhang button at para ma insert yung form sa panel.

        InsertForm(PanelForm, FormName)
        PanelName.FillColor = Color.FromArgb(39, 110, 241)
        ButtonName.FillColor = Color.White

        Dim ResourceName As String = NewPicture & Picture
        Dim ImageResource As Image = CType(My.Resources.ResourceManager.GetObject(ResourceName), Image)
        ButtonName.Image = ImageResource
        
        for each Key As String In ButtonDict.Keys.ToList()
If Key = KeyName Then

                ButtonDict(Key) = True

            Else

            ButtonDict(Key) = False
            End If
        Next
End Sub
    
    Public Sub InsertForm(ByVal PanelName As Panel, ByVal FormName As Form)

'I-insert yung form sa loob ng panel.
        PanelName.BringToFront()
        FormName.TopLevel = False
        PanelName.Controls.Add(FormName)
        FormName.Dock = DockStyle.Fill
        FormName.Show()

    End Sub

    Function GetMonthNumberFromMonthName(MontName As String) As Integer

        Try
            Return DateTime.ParseExact(MontName, "MMMM", Globalization.CultureInfo.InvariantCulture).Month
        Catch ex As FormatException
            MessageBox.Show($"Invalid month name: {Variables.TransactionByDate}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try

    End Function

    Public Sub ResetNavigation(Panel1 As Guna.UI2.WinForms.Guna2Panel, Button1 As Guna.UI2.WinForms.Guna2Button, ButtonImage1 As String,
                            Panel2 As Guna.UI2.WinForms.Guna2Panel, Button2 As Guna.UI2.WinForms.Guna2Button, ButtonImage2 As String,
                            Panel3 As Guna.UI2.WinForms.Guna2Panel, Button3 As Guna.UI2.WinForms.Guna2Button, ButtonImage3 As String,
                            Panel4 As Guna.UI2.WinForms.Guna2Panel, Button4 As Guna.UI2.WinForms.Guna2Button, ButtonImage4 As String,
                            Panel5 As Guna.UI2.WinForms.Guna2Panel, Button5 As Guna.UI2.WinForms.Guna2Button, ButtonImage5 As String,
                            Panel6 As Guna.UI2.WinForms.Guna2Panel, Button6 As Guna.UI2.WinForms.Guna2Button, ButtonImage6 As String)

        'Ireset yung panel sa main form as normal.

        Panel1.FillColor = Color.Transparent
        Button1.FillColor = Color.FromArgb(229, 229, 234)
        Button1.Image = CType(My.Resources.ResourceManager.GetObject(ButtonImage1), Image)

        Panel2.FillColor = Color.Transparent
        Button2.FillColor = Color.FromArgb(229, 229, 234)
        Button2.Image = CType(My.Resources.ResourceManager.GetObject(ButtonImage2), Image)

        Panel3.FillColor = Color.Transparent
        Button3.FillColor = Color.FromArgb(229, 229, 234)
        Button3.Image = CType(My.Resources.ResourceManager.GetObject(ButtonImage3), Image)

        Panel4.FillColor = Color.Transparent
        Button4.FillColor = Color.FromArgb(229, 229, 234)
        Button4.Image = CType(My.Resources.ResourceManager.GetObject(ButtonImage4), Image)

        Panel5.FillColor = Color.Transparent
        Button5.FillColor = Color.FromArgb(229, 229, 234)
        Button5.Image = CType(My.Resources.ResourceManager.GetObject(ButtonImage5), Image)

        Panel6.FillColor = Color.Transparent
        Button6.FillColor = Color.FromArgb(229, 229, 234)
        Button6.Image = CType(My.Resources.ResourceManager.GetObject(ButtonImage6), Image)

    End Sub

    Public Sub PanelToButton(ButtonName As Guna.UI2.WinForms.Guna2Panel,
                             Image1 As Guna.UI2.WinForms.Guna2PictureBox,
                             Image2 As Guna.UI2.WinForms.Guna2PictureBox,
                             RGB As Integer,
                             ImageName1 As String,
                             ImageName2 As String)

        'To make panels as button, para mag mukhang button.

        ButtonName.FillColor = Color.FromArgb(RGB, RGB, RGB)

        Image1.Image = CType(My.Resources.ResourceManager.GetObject(ImageName1), Image)
        Image2.Image = CType(My.Resources.ResourceManager.GetObject(ImageName2), Image)

    End Sub

    Public Sub UserControlToButton(UserControlName As UserControl,
                             RGB As Integer)

        'Ito naman for user controls para mag mukhang fbutton
        UserControlName.BackColor = Color.FromArgb(RGB, RGB, RGB)

    End Sub

    Sub CheckDemicalNumber(ByVal e As KeyPressEventArgs, ByVal TextBoxName As Guna.UI2.WinForms.Guna2TextBox)

        'Para ma handle yung numeric and decimal values. then disregard yung alphabet and other special characters.
        'maliban sa tuldok.

        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso Not Char.IsControl(e.KeyChar)

            e.Handled = True

        End If

        If e.KeyChar = "." AndAlso TextBoxName.Text.Contains("."c)

            e.Handled = True

        End If

    End Sub

    Sub CheckNumericNumber(ByVal e As KeyPressEventArgs, ByVal TextBoxName As Guna.UI2.WinForms.Guna2TextBox)

        'Para ma handle yung numeric values. then disregard yung alphabet and other special characters.

        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar)

            e.Handled = True

        End If

    End Sub

    Sub CreateProductSearchUserControl

        'For search naman para mag create ng user control.

        For i As Integer = 0 To Variables.SearchByProductId.Count - 1
            
                ProductManagement.CreateSearchUserControl(Variables.SearchByProductId(i), Variables.SearchByProductName(i),
        Variables.SearchByProductImage(i))
        Next

    End Sub

    Sub CreateStockSearchUserControl

        'For search naman para mag create ng user control.

        For i As Integer = 0 To Variables.SearchByStockId.Count - 1
            
                StockManagement.CreateSearchUserControl(Variables.SearchByStockId(i), Variables.SearchByStockProductId(i), Variables.SearchBatchCode(i), Variables.SearchCurrentStock(i))
        Next

    End Sub
    Sub CreateStockTransactionSearchUserControl

        'For search naman para mag create ng user control.

        For i As Integer = 0 To Variables.SearchTransactionId.Count - 1
            
                InventoryTransactions.CreateSearchUserControl(Variables.SearchTransactionId(i), Variables.SearchTransactionStockId(i), Variables.SearchTransactionType(i))
            
        Next

    End Sub

    Sub CreateSaleSearchUserControl

        'For search naman para mag create ng user control.

        For i As Integer = 0 To Variables.SearchBySaleId.Count - 1
            
                SalesValuation.CreateSearchUserControl(Variables.SearchBySaleId(i), Variables.SearchBySaleStockId(i), Variables.SearchBySaleQuantity(i),
                                                        Variables.SearchByGrossSale(i))
            
        Next

    End Sub

    Sub CreateValuationSearchUserControl

        'For search naman para mag create ng user control.

        For i As Integer = 0 To Variables.SearchByValuationId.Count - 1

            Dim ValuationId As Integer = Variables.SearchByValuationId(i)
            Dim ValuationStockId As Integer = Variables.SearchByValuationStockId(i)
            Dim RetailValue As Double = Variables.SearchByValuationStockId(i)

            Dim ExpirationValue As Double = Variables.SearchByExpirationValuation(i)
            
            If ExpirationValue > 0 Then
                
                InventoryValuation.CreateSearchUserControl(ValuationId, ValuationStockId, ExpirationValue, True)
            
            Else
                
                InventoryValuation.CreateSearchUserControl(ValuationId, ValuationStockId, RetailValue, False)
            
            End If
            
        Next

    End Sub

    Sub CreateBackupSearchUserControl

        'For search naman para mag create ng user control.

        For i As Integer = 0 To Variables.SearchByBackUpId.Count - 1
            
                DataBackupAndRecovery.CreateSearchUserControl(Variables.SearchByBackUpId(i), Variables.SearchByBackUpName(i))
            
        Next

    End Sub

    Sub ClearProductList

        'I clear yung elements ng list ng mga info ng products.

        Variables.ListOfProductId.Clear
        Variables.ListOfProductName.Clear
        Variables.ListOfProductImage.Clear
        Variables.ListOfProductCategory.Clear
        Variables.ListOfProductBarcodeSequence.Clear
        Variables.ListOfProductDescription.Clear
        Variables.ListOfProductCapital.Clear
        Variables.ListOfProductWholeSalePrice.Clear
        Variables.ListOfProductRetailPrice.Clear
        Variables.ListOfProductMinStock.Clear
        Variables.ListOfProductMaxStock.Clear
        Variables.ListOfProductSupplier.Clear
        Variables.ListOfProductDateAdded.Clear
        Variables.ListOfProductTimeAdded.Clear
        Variables.ListOfProductAddedBy.Clear

    End Sub

    Sub ClearProductData

        'Para ma clear yung variables after mag add ng info.
        Variables.ProductImage = Nothing
        Variables.ProductImageName = String.Empty
        Variables.ProductCategory = Nothing
        Variables.ProductName = String.Empty
        Variables.ProductCode = String.Empty
        Variables.ProductDescription = String.Empty
        Variables.Capital = String.Empty
        Variables.WholeSalePrice = String.Empty
        Variables.RetailPrice = String.Empty
        Variables.MinStock = String.Empty
        Variables.MaxStock = String.Empty
        Variables.Supplier = Nothing
        Variables.AddedBy = 0

    End Sub

    Sub ClearStockData

        'Para ma clear yung variables after mag add ng info.
        Variables.StockProductId = Nothing
        Variables.StockBatch = String.Empty
        Variables.StockExpiration = Nothing
        Variables.CurrentStock = Nothing
        Variables.StockWarehouseId = Nothing

    End Sub

    Public Sub DeleteUserControls(PanelName As Panel)

        'Burahin yung mga user controls.

        Dim ControlsToRemove As New List(Of Control)

        For Each Ctrl As Control In PanelName.Controls
            'Check if the control is a UserControl
            If TypeOf Ctrl Is UserControl Then
                ControlsToRemove.Add(Ctrl)
            End If
        Next

        For Each Ctrl As Control In ControlsToRemove
            PanelName.Controls.Remove(Ctrl)
            Ctrl.Dispose()
        Next

    End Sub

    Sub FadeInForm(FormName As Form)

        'Smooth fade effect
        Dim OpacityTimer As New Timer With {
            .Interval = 20
        }

        AddHandler OpacityTimer.Tick, Sub()
                                          'If form is disposed then stop the timer.
                                          If FormName.IsDisposed OrElse FormName.Disposing Then
                                              OpacityTimer.Stop()
                                              OpacityTimer.Dispose()
                                              Return
                                          End If

                                          If FormName.Opacity < 1 Then
                                              FormName.Opacity += 0.05
                                          Else
                                              OpacityTimer.Stop()
                                              OpacityTimer.Dispose()
                                          End If
                                      End Sub
        OpacityTimer.Start()

    End Sub

    Sub ClearStockList

        'I clear yung elements ng list ng mga info ng products.
        Variables.ListOfStockId.Clear
        Variables.ListOfStockProductId.Clear
        Variables.ListOfBatchCode.Clear
        Variables.ListOfExpiration.Clear
        Variables.ListOfCurrentStock.Clear
        Variables.ListOfWarehouse.Clear
        Variables.ListOfStockDateAdded.Clear
        Variables.ListOfStockTimeAdded.Clear

    End Sub

    Sub ClearActivityList

        'I clear yung elements ng list ng mga info ng products.

        Variables.ListOfActivityId.Clear
        Variables.ListOfActivityName.Clear
        Variables.ListOfActionBy.Clear
        Variables.ListOfManagement.Clear
        Variables.ListOfActivityDate.Clear
        Variables.ListOfActivityTime.Clear
        Variables.listofActivityDetails.Clear

    End Sub

    Sub ClearInventoryTransactionList

        'I clear yung elements ng list ng mga info ng products.

        Variables.ListOfTransactionId.Clear
        Variables.ListOfTransactionStockId.Clear
        Variables.ListOfTransactionName.Clear
        Variables.ListOfTransactionQuantity.Clear
        Variables.ListOfTransactionDate.Clear
        Variables.ListOfTransactionTime.Clear
        Variables.ListOfTransactionActionBy.Clear

    End Sub

    Sub ClearSalesList

        'I clear yung elements ng list ng mga info ng products.

        Variables.ListOfSaleId.Clear
        Variables.ListOfSaleStockId.Clear
        Variables.ListOfQuantitySold.Clear
        Variables.ListOfItemPrice.Clear
        Variables.ListOfExpenses.Clear
        Variables.ListOfGrossSale.Clear
        Variables.ListOfNetSale.Clear
        Variables.ListOfSaleDate.Clear
        Variables.listofSaleTime.Clear

    End Sub

    Sub ClearInventoryValuationList

        'I clear yung elements ng list ng mga info ng products.

        Variables.ListofInventoryValuationId.Clear
        Variables.ListofInventoryValuationStockId.Clear
        Variables.ListofInventoryValuationRetail.Clear
        Variables.ListofInventoryValuationWholesale.Clear
        Variables.ListofInventoryValuationExpiration.Clear
        Variables.ListofInventoryValuationDateAdded.Clear
        Variables.ListofInventoryValuationTimeAdded.Clear
        Variables.ListofInventoryValuationAdded.Clear

    End Sub

    Sub ClearExpiredStocks

        'I clear yung elements ng list ng mga info ng products.

        Variables.ListofExpiredStockId.Clear

    End Sub

    Sub ClearDatabaseBackupList

        Variables.ListOfBackupId.Clear
        Variables.ListOfBackUpName.Clear
        Variables.ListOfDirectory.Clear
        Variables.ListOfDateAdded.Clear
        Variables.ListOfTimeAdded.Clear
        Variables.ListOfDatabaseAddedBy.Clear

    End Sub

    Async Function GetColumn(ColumnName As String, TableName As String, Parameter As String, Value As String) As Task(Of String)

        Dim ReturnValue As String = String.Empty

        Dim Con As SqlConnection

        If TableName = "activities" Or TableName = "system_backup"

            Con = Await ConnectionStringModule.OpenBackupConnection

        Else

            Con = Await ConnectionStringModule.OpenDatabaseConnection

        End If

        Using Con

            Try

                Dim Query As String = $"SELECT {ColumnName} FROM {TableName} WHERE {Parameter} = @Value"

                Using Cmd As New SqlCommand(Query, Con)

                    Cmd.Parameters.AddWithValue("@Value", Value)

                    Dim Result = Await Cmd.ExecuteScalarAsync

                    If Result IsNot Nothing

                        ReturnValue = Result.ToString

                    End If

                End Using

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

        Return ReturnValue

    End Function


    Async Function GetList(Query As String, TableName As String) As Task(Of List(Of Object))

        Dim Products As New List(Of Object)

        Using Con As SqlConnection = Await ConnectionStringModule.OpenDatabaseConnection()

            Try

                Using Cmd As New SqlCommand(Query, Con)

                    Using Reader As SqlDataReader = Await Cmd.ExecuteReaderAsync()

                        While Await Reader.ReadAsync()
                            Products.Add(Reader(TableName).ToString())
                        End While

                    End Using

                End Using

            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

        Return Products

    End Function

End Module
