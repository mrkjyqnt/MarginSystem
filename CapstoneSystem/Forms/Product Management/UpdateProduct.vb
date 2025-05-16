Imports System.Reflection

Public Class UpdateProduct

    Public tableName As String = String.Empty

    Private Sub UpdateProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        NewComboBox.Items.Clear
        confirmComboBox.Items.Clear
        Me.Close
        Me.Dispose

    End Sub

    Private Async Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click

        Dim NumericValue As Integer
        Dim StringValue As String

        If tableName = "category_id" OrElse tableName = "supplier_id" Then

            If NewComboBox.SelectedIndex = -1 AndAlso confirmComboBox.SelectedIndex = -1 Then
                MessageBox.Show("No selected fields.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If NewComboBox.SelectedIndex = confirmComboBox.SelectedIndex Then
                MessageBox.Show("Selected fields are the same.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        Else

            If String.IsNullOrEmpty(NewTextBox.Text) AndAlso String.IsNullOrEmpty(ConfirmTextBox.Text) Then
                MessageBox.Show("No inserted data.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If NewTextBox.Text <> ConfirmTextBox.Text Then
                MessageBox.Show("Information inaccurate.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                StringValue = ConfirmTextBox.Text
                Await ProductManagementDatabaseModule.UpdateProductInfo(tableName, StringValue, ProductIdLabel.Text)
            End If

        End If

        If tableName = "category_id" Then
            NumericValue = Await ProductManagementDatabaseModule.GetCategoryId(confirmComboBox.SelectedItem.ToString())
            Await ProductManagementDatabaseModule.UpdateProductInfo(tableName, NumericValue.ToString(), ProductIdLabel.Text)
        End If

        If tableName = "supplier_id" Then
            NumericValue = Await ProductManagementDatabaseModule.GetSupplierId(confirmComboBox.SelectedItem.ToString())
            Await ProductManagementDatabaseModule.UpdateProductInfo(tableName, NumericValue.ToString(), ProductIdLabel.Text)
        End If

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

        NewComboBox.DroppedDown = True

    End Sub

    Private Sub NewComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NewComboBox.SelectedIndexChanged

        If NewComboBox.SelectedIndex > -1

            Label3.Hide

        End If

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

        confirmComboBox.DroppedDown = True

    End Sub

    Private Sub confirmComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles confirmComboBox.SelectedIndexChanged

        If confirmComboBox.SelectedIndex > -1

            Label8.Hide

        End If

    End Sub

End Class