Public Class ActivityValuationUserControl
    Private Sub CategoryIdLabel_MouseEnter(sender As Object, e As EventArgs) Handles DateManagementLabel.MouseEnter, ActivityNameLabel.MouseEnter, MyBase.MouseEnter

        GeneralModule.UserControlToButton(Me, 210)
        DateManagementLabel.ForeColor = Color.Black

    End Sub

    Private Sub ActivityValuationUserControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave

        GeneralModule.UserControlToButton(Me, 247)
        DateManagementLabel.ForeColor = Color.FromArgb(199, 199, 204)

    End Sub

    Private Sub ActivityValuationUserControl_MouseDown(sender As Object, e As MouseEventArgs) Handles DateManagementLabel.MouseDown, ActivityNameLabel.MouseDown, MyBase.MouseDown

        GeneralModule.UserControlToButton(Me, 147)

    End Sub

    Private Async Sub ActivityValuationUserControl_Click(sender As Object, e As EventArgs) Handles DateManagementLabel.Click, ActivityNameLabel.Click, MyBase.Click

        ActivityInfo.Opacity = 0
        Dim ActivityIndex As Integer = Variables.ListOfActivityId.IndexOf(Integer.Parse(ActtivityIdLabel.Text))

        If ActivityIndex >= 0 Then

            ActivityInfo.ActionTextBox.Text = Variables.ListOfActivityName(ActivityIndex)
            ActivityInfo.ActionByTextBox.Text = Await ProductManagementDatabaseModule.GetAddedBy(Variables.ListOfActionBy(ActivityIndex))
            ActivityInfo.CategoryTextBox.Text = $"{StrConv(Variables.ListOfManagement(ActivityIndex), VbStrConv.ProperCase)} Management"
            ActivityInfo.DateTextBox.Text = Variables.ListOfActivityDate(ActivityIndex)
            ActivityInfo.TimeTextBox.Text = Variables.ListOfActivityTime(ActivityIndex)
            ActivityInfo.DetailsTextBox.Text = Variables.listofActivityDetails(ActivityIndex)

            GeneralModule.ShowOverlay(MainForm, ActivityInfo)
            GeneralModule.UserControlToButton(Me, 247)
            Activities.FormPanel.Focus
            Activities.ActiveControl = Activities.FormPanel

        Else

            MessageBox.Show("Activity not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Sub ActivityValuationUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
