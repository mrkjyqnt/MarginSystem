Public Class GenerateReport

    Public TableName As String

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close
        Me.Dispose

    End Sub

    Private Sub GenerateReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FromYearComboBox.SelectedIndex = -1
        ToYearComboBox.SelectedIndex = -1
        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub PopulateMonthComboBox(ComboBoxName As ComboBox)

        ComboBoxName.Items.Clear()
        For month As Integer = 1 To 12
            ComboBoxName.Items.Add(New DateTime(1, month, 1).ToString("MMMM"))
        Next
        ComboBoxName.SelectedIndex = -1

    End Sub

    Private Sub PopulateDayComboBox(ComboBoxName As ComboBox, year As Integer, month As Integer)

        ComboBoxName.Items.Clear()

        Dim daysInMonth As Integer = DateTime.DaysInMonth(year, month)

        For day As Integer = 1 To daysInMonth

            ComboBoxName.Items.Add(day)

        Next

        ComboBoxName.SelectedIndex = -1

    End Sub

    Private Sub FromYearComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromYearComboBox.SelectedIndexChanged

        If FromYearComboBox.SelectedIndex > -1

            PopulateMonthComboBox(FromMonthComboBox)
            Label7.Hide

        Else

            Label7.Show

        End If

    End Sub

    Private Sub FromMonthComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromMonthComboBox.SelectedIndexChanged

        If FromYearComboBox.SelectedItem IsNot Nothing AndAlso FromMonthComboBox.SelectedIndex >= 0 Then

            Dim selectedYear As Integer = Integer.Parse(FromYearComboBox.SelectedItem.ToString())
            Dim selectedMonth As Integer = FromMonthComboBox.SelectedIndex + 1
            PopulateDayComboBox(FromDayComboBox, selectedYear, selectedMonth)

        End If

        If FromMonthComboBox.SelectedIndex > -1

            Label4.Hide

        Else

            Label4.Show

        End If

    End Sub

    Private Sub ToYearComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToYearComboBox.SelectedIndexChanged

        If ToYearComboBox.SelectedIndex > -1

            PopulateMonthComboBox(ToMonthComboBox)
            Label8.Hide

        Else

            Label8.Show

        End If

    End Sub

    Private Sub ToMonthComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToMonthComboBox.SelectedIndexChanged

        If FromYearComboBox.SelectedItem IsNot Nothing AndAlso FromMonthComboBox.SelectedIndex >= 0 Then

            Dim selectedYear As Integer = Integer.Parse(FromYearComboBox.SelectedItem.ToString())
            Dim selectedMonth As Integer = FromMonthComboBox.SelectedIndex + 1
            PopulateDayComboBox(ToDayComboBox, selectedYear, selectedMonth)

        End If

        If ToMonthComboBox.SelectedIndex > -1

            Label11.Hide

        Else

            Label11.Show

        End If

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

        FromYearComboBox.DroppedDown = True

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

        FromMonthComboBox.DroppedDown = True

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

        FromDayComboBox.DroppedDown = True

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

        ToYearComboBox.DroppedDown = True

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

        ToMonthComboBox.DroppedDown = True

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

        ToDayComboBox.DroppedDown = True

    End Sub

    Private Async Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        If FromMonthComboBox.SelectedIndex < 0 OrElse FromDayComboBox.SelectedIndex < 0 OrElse FromYearComboBox.SelectedIndex < 0 OrElse
           ToMonthComboBox.SelectedIndex < 0 OrElse ToDayComboBox.SelectedIndex < 0 OrElse ToYearComboBox.SelectedIndex < 0 Then

            MessageBox.Show("Incomplete date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Else
            Dim FromDate As String = $"{FromMonthComboBox.SelectedItem} {FromDayComboBox.SelectedItem}, {FromYearComboBox.SelectedItem}"
            Dim ToDate As String = $"{ToMonthComboBox.SelectedItem} {ToDayComboBox.SelectedItem}, {ToYearComboBox.SelectedItem}"

            Dim ReportingProjectPath As String = My.Settings.ReportingProjectPath

            Try

                Close
                Dispose
                MainForm.Enabled = False
                Dim process As Process = Process.Start(ReportingProjectPath, $"""{FromDate}"" ""{ToDate}"" ""{TableName}""")

                If process IsNot Nothing Then
                    process.WaitForExit()
                    Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
                    Dim TimeAdded = Variables.CurrrentDate.ToString("t")

                    If TableName = "product"
                        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "product", DateAdded, TimeAdded, $"Generate Report for Product Management")
                    Elseif TableName = "stock"
                        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "stock", DateAdded, TimeAdded, $"Generate Report for Stock Management")
                    Elseif TableName = "stock_transaction"
                        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "inventory transaction", DateAdded, TimeAdded, $"Generate Report for Inventory Transaction")
                    Elseif TableName = "sale"
                        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "sales", DateAdded, TimeAdded, $"Generate Report for Sales Management")
                    Elseif TableName = "inventory_valuation"
                        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "inventory valuation", DateAdded, TimeAdded, $"Generate Report for Inventory Valuations")
                    Elseif TableName = "activity"
                        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "activity", DateAdded, TimeAdded, $"Generate Report for System Activities")
                    End If

                End If

            Catch ex As Exception

                MessageBox.Show($"Error launching process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

                MainForm.Enabled = True

            End Try

        End If

    End Sub

    Private Sub ShadowButton_KeyDown(sender As Object, e As KeyEventArgs) Handles FromMonthComboBox.KeyDown, FromDayComboBox.KeyDown, FromYearComboBox.KeyDown, ToYearComboBox.KeyDown, ToDayComboBox.KeyDown, ToMonthComboBox.KeyDown, ShadowButton.KeyDown, MyBase.KeyDown

        If e.KeyCode = Keys.Escape

            ShadowButton.PerformClick

        End If

    End Sub

    Private Sub FromDayComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromDayComboBox.SelectedIndexChanged

        If FromDayComboBox.SelectedIndex > -1

            Label6.Hide

        Else

            Label6.Show

        End If

    End Sub

    Private Sub ToDayComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToDayComboBox.SelectedIndexChanged


        If ToDayComboBox.SelectedIndex > -1

            Label10.Hide

        Else

            Label10.Show

        End If

    End Sub

End Class