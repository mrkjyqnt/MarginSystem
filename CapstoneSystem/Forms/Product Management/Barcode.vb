Imports MessagingToolkit.Barcode

Public Class Barcode

    Public ProductCodeText As String = String.Empty

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click

        If ProductInfo.Clicked Then

            Hide

        Else

            Close
            Dispose
            RecordSale.Close
            RecordSale.Dispose

        End If

    End Sub

    Private Sub Barcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not String.IsNullOrEmpty(ProductCodeText) Then

            Dim barcodeFormat As BarcodeFormat

            Select Case ProductCodeText.Length
                Case 8
                    barcodeFormat = BarcodeFormat.EAN8
                Case 12
                    barcodeFormat = BarcodeFormat.UPCA
                Case 13
                    barcodeFormat = BarcodeFormat.EAN13
                Case Else
                    MessageBox.Show("Product Code must be 8, 12, or 13 digits long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
            End Select

            Dim Generator As New BarcodeEncoder With {
                .BackColor = Color.Transparent
            }

            Label3.Text = ProductCodeText
            Label3.Left = (Label3.Parent.Width - Label3.Width) \ 2

            Try
                BarcodeImage.Image = New Bitmap(Generator.Encode(barcodeFormat, ProductCodeText))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Async Sub QuantityTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ProductCodeTextBox.KeyDown

        If e.KeyCode = Keys.Enter


            Dim ProductCode As String = ProductCodeTextBox.Text

            If Await ProductManagementDatabaseModule.IsProductCodeExists(ProductCode)

                Hide
                RecordSale.Opacity = 0
                RecordSale.ProductCode = ProductCode
                GeneralModule.ShowOverlay(MainForm, RecordSale)
                ProductCodeTextBox.Clear
                ProductCodeTextBox.Focus

            Else

                MessageBox.Show("The product is currently not available. Product can either be disabled or non-existent.", "Invalid Product", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GeneralModule.CloseOverLay(Me)
                Exit Sub

            End If

        End If

        If e.KeyCode = Keys.Escape

            CloseButton.PerformClick

        End If

    End Sub

    Private Sub ProductCodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles ProductCodeTextBox.TextChanged

    End Sub

    Private Sub Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape

            CloseButton.PerformClick

        End If

    End Sub

End Class