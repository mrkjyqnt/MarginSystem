Public Class Activities
    Private Async Sub BackLabel_Click(sender As Object, e As EventArgs) Handles BackLabel.Click

        Cursor = Cursors.WaitCursor
        MainForm.Opacity = 0

        Variables.TransactionNumberOfFilters = 0
        Variables.TransactionFilterBy = String.Empty
        Variables.TransactionByDate = String.Empty
        Variables.TransactionSortBy = String.Empty

        SortByComboBox.SelectedIndex = -1
        FilterByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await CreateActivityUserControl()

        ' Update the UI
        Dim TotalActivitySearched As Integer = Variables.ListOfActivityId.Count
        Label3.Text = TotalActivitySearched & " Activities found"

        MainForm.ValuationReportsFormPanel.Controls.Clear
        GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", ValuationAndReports, MainForm.ValuationReportsFormPanel)
        ValuationAndReports.ActiveControl = ValuationAndReports.FormPanel
        GeneralModule.FadeInForm(MainForm)
        Cursor = Cursors.Default

    End Sub

    Private Sub BackLabel_MouseEnter(sender As Object, e As EventArgs) Handles BackLabel.MouseEnter

        BackLabel.Font = New Font("Inter Black", 20)
        Label2.Location = New point(394, 0)

    End Sub

    Private Sub BackLabel_MouseLeave(sender As Object, e As EventArgs) Handles BackLabel.MouseLeave

        BackLabel.Font = New Font("Inter Semibold", 20)
        Label2.Location = New point(377, 0)

    End Sub

    Private Sub Activities_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If FormPanel.Controls.OfType(Of ActivityValuationUserControl).Any

            Label3.Hide
            Label13.show
            Label13.Text = FormPanel.Controls.OfType(Of ActivityValuationUserControl).Count & " Activities found"

        Else

            Label3.Show
            Label13.Hide

        End If

    End Sub

    'Private Sub ViewMoreButton_Click(sender As Object, e As EventArgs) Handles ViewMoreButton.Click

    'MainForm.ValuationReportsFormPanel.Controls.Clear
    'GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", ViewMoreForm, MainForm.ValuationReportsFormPanel)

    'ViewMoreForm.BackLabel2.Text = ">  Activities"
    'ViewMoreForm.Label1.Location = New Point(586, 0)
    'ViewMoreForm.SearchByLabel.text = "Search Activity"
    'ViewMoreForm.FoundLabel.text = "10 Activities found"

    'End Sub

    Private Async Sub NewProductButton_Click(sender As Object, e As EventArgs) Handles NewProductButton.Click

        GenerateReport.Opacity = 0
        'HideSearchFlowLayout
        GenerateReport.TableName = "activity"
        GeneralModule.ShowOverlay(MainForm, GenerateReport)

        Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
        Dim TimeAdded = Variables.CurrrentDate.ToString("t")
        Await ActivityDatabaseModule.InsertActivity("Generate Report", AddedBy, "activity", DateAdded, TimeAdded, $"Generate Report for Activities")

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await CreateActivityUserControl()

        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub

    Public Sub CreateUserControl(ActivityId As Integer, ActivityName As String,
                             Management As String, DateAdded As String)

        'Creation ng Stock User Control

        Dim VerticalMargin As Integer = 5
        Dim ControlHeight As Integer = 100

        Dim ControlWidth As Integer = FormPanel.ClientSize.Width - 6

        'Ni ca-calculate nito yung height control hanggang bottom
        Dim MaxBottom As Integer = 0

        For Each Ctrl As Control In FormPanel.Controls
            'Exclude the SearchFlowLayoutPanel
            If Ctrl.Name <> "ResultSearchPanel" Then
                If Ctrl.Bottom > MaxBottom Then
                    MaxBottom = Ctrl.Bottom
                End If
            End If
        Next

        Dim NewYPosition As Integer = MaxBottom + VerticalMargin

        Dim NewActivity As New ActivityValuationUserControl With {
            .Size = New Size(ControlWidth, ControlHeight),
            .Location = New Point(3, NewYPosition),
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        }

        'Assigning ng values ng products sa user control/
        NewActivity.ActivityNameLabel.Text = ActivityName
        NewActivity.ActtivityIdLabel.Text = ActivityId
        NewActivity.DateManagementLabel.Text = $"{DateAdded} | {StrConv(Management, VbStrConv.ProperCase)} Management"

        FormPanel.Controls.Add(NewActivity)

    End Sub

    Async Function CreateActivityUserControl() As Task

        'Mag produce ng user controls.

        For i As Integer = 0 To ListOfActivityId.Count - 1

            CreateUserControl(Variables.ListOfActivityId(i), Variables.ListOfActivityName(i),
                              Await GeneralModule.GetColumn("management", "activities", "activity_id", Variables.ListOfActivityId(i)), Variables.ListOfActivityDate(i))

        Next

    End Function

    Async Function CreateActivity(Query As String, Total As Integer) As Task

        Await ActivityDatabaseModule.RetrieveAll(Query)
        Total = Variables.ListOfActivityId.Count
        Await CreateActivityUserControl
        Label13.Text = Total & " Activities found"
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Function


    Private Async Sub DateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateComboBox.SelectedIndexChanged

        If DateComboBox.SelectedIndex > -1

            Variables.ActivityByDate = DateComboBox.SelectedItem.ToString()
            Variables.ActivityNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.ActivityFilterBy, Variables.ActivityByDate, Variables.ActivitySortBy)

            Dim Query As String = ""
            Dim TotalActivity As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.ActivityNumberOfFilters = 1 Then

                Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}'"

            ElseIf Variables.ActivityNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.ActivitySortBy) AndAlso String.IsNullOrEmpty(Variables.ActivityFilterBy) Then

                    Select Case Variables.ActivitySortBy

                        Case "A - Z"

                            Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' ORDER BY action_name ASC, activity_id DESC"

                        Case "Z - A"

                            Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' ORDER BY action_name DESC, activity_id DESC"

                        Case "New First"

                            Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' ORDER BY activity_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' ORDER BY activity_id ASC"

                    End Select

                ElseIf Not String.IsNullOrEmpty(Variables.ActivityFilterBy) AndAlso String.IsNullOrEmpty(Variables.ActivitySortBy) Then

                    Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}'"

                End If

            Else

                Select Case Variables.ActivitySortBy

                    Case "A - Z"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name ASC, activity_id DESC"

                    Case "Z - A"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name DESC, activity_id DESC"

                    Case "New First"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id ASC"

                End Select

            End If

            Await CreateActivity(Query, TotalActivity)

        End If

    End Sub

    Private Async Sub SortByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SortByComboBox.SelectedIndexChanged

        If SortByComboBox.SelectedIndex > -1

            Variables.ActivitySortBy = SortByComboBox.SelectedItem.ToString()
            Variables.ActivityNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.ActivityFilterBy, Variables.ActivityByDate, Variables.ActivitySortBy)

            Dim Query As String = ""
            Dim TotalActivity As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.ActivityNumberOfFilters = 1 Then

                Select Case Variables.ActivitySortBy

                    Case "A - Z"

                        Query = $"SELECT * FROM activities ORDER BY action_name ASC, activity_id DESC"

                    Case "Z - A"

                        Query = $"SELECT * FROM activities ORDER BY action_name DESC, activity_id DESC"

                    Case "New First"

                        Query = $"SELECT * FROM activities ORDER BY activity_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM activities ORDER BY activity_id ASC"

                End Select

            ElseIf Variables.ActivityNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.ActivityByDate) AndAlso String.IsNullOrEmpty(Variables.ActivityFilterBy) Then

                    Select Case Variables.ActivitySortBy

                        Case "A - Z"

                            Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' ORDER BY action_name ASC, activity_id DESC"

                        Case "Z - A"

                            Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' ORDER BY action_name DESC, activity_id DESC"

                        Case "New First"

                            Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' ORDER BY activity_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' ORDER BY activity_id ASC"

                    End Select

                ElseIf Not String.IsNullOrEmpty(Variables.ActivityFilterBy) AndAlso String.IsNullOrEmpty(Variables.ActivityByDate) Then

                    Select Case Variables.ActivitySortBy

                        Case "A - Z"

                            Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name ASC, activity_id DESC"

                        Case "Z - A"

                            Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name DESC, activity_id DESC"

                        Case "New First"

                            Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id ASC"

                    End Select

                End If

            Else

                Select Case Variables.ActivitySortBy

                    Case "A - Z"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name ASC, activity_id DESC"

                    Case "Z - A"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name DESC, activity_id DESC"

                    Case "New First"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id ASC"

                End Select

            End If

            Await CreateActivity(Query, TotalActivity)

        End If

    End Sub

    Private Async Sub FilterByComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterByComboBox.SelectedIndexChanged

        If FilterByComboBox.SelectedIndex > -1

            Variables.ActivityFilterBy = FilterByComboBox.SelectedItem.ToString()
            Variables.ActivityNumberOfFilters = GeneralFunctions.CheckSearchFilters(Variables.ActivityFilterBy, Variables.ActivityByDate, Variables.ActivitySortBy)

            Dim Query As String = ""
            Dim TotalActivity As Integer

            GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)
            GeneralModule.DeleteUserControls(FormPanel)

            If Variables.ActivityNumberOfFilters = 1 Then

                Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}'"

            ElseIf Variables.ActivityNumberOfFilters = 2 Then

                If Not String.IsNullOrEmpty(Variables.ActivitySortBy) AndAlso String.IsNullOrEmpty(Variables.ActivityByDate) Then

                    Select Case Variables.ActivitySortBy

                        Case "A - Z"

                            Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name ASC, activity_id DESC"

                        Case "Z - A"

                            Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name DESC, activity_id DESC"

                        Case "New First"

                            Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id DESC"

                        Case "Old First"

                            Query = $"SELECT * FROM activities WHERE action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id ASC"

                    End Select

                ElseIf Not String.IsNullOrEmpty(Variables.ActivityByDate) AndAlso String.IsNullOrEmpty(Variables.ActivitySortBy) Then

                    Query = $"SELECT * FROM activities WHERE activity_date LIKE '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}'"

                End If

            Else

                Select Case Variables.ActivitySortBy

                    Case "A - Z"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name ASC, activity_id DESC"

                    Case "Z - A"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY action_name DESC, activity_id DESC"

                    Case "New First"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id DESC"

                    Case "Old First"

                        Query = $"SELECT * FROM activities WHERE activity_date Like '{Variables.ActivityByDate}%' + '{Variables.CurrentYear}' AND action_name = '{Variables.ActivityFilterBy}' ORDER BY activity_id ASC"

                End Select

            End If

            Await CreateActivity(Query, TotalActivity)

        End If

    End Sub

    Private Async Sub ClearAllFiltersButton_Click(sender As Object, e As EventArgs) Handles ClearAllFiltersButton.Click

        'Ireremove lahat ng filter then show all.

        GeneralModule.ShowOverlayForm(LoadingScreen, MainForm)

        Variables.TransactionNumberOfFilters = 0
        Variables.TransactionFilterBy = String.Empty
        Variables.TransactionByDate = String.Empty
        Variables.TransactionSortBy = String.Empty

        SortByComboBox.SelectedIndex = -1
        FilterByComboBox.SelectedIndex = -1
        DateComboBox.SelectedIndex = -1

        Dim ActivityQuery As String = "SELECT * FROM activities ORDER BY activity_id DESC"
        GeneralModule.DeleteUserControls(FormPanel)
        Await ActivityDatabaseModule.RetrieveALL(ActivityQuery)
        Await CreateActivityUserControl()

        ' Update the UI
        Dim TotalActivitySearched As Integer = Variables.ListOfActivityId.Count
        Label13.Text = TotalActivitySearched & " Activities found"

        ' Hide loading screen
        GeneralModule.CloseOverLay(LoadingScreen)
        FormPanel.Focus
        ActiveControl = FormPanel

    End Sub
End Class