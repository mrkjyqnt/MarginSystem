Public Class InventoryValuationInfo

    Public ShowExpirationPanel As Boolean = True

    Private Sub InventoryValuationInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not ShowExpirationPanel

            Size = New Size(596, 465)
            Guna2Separator1.Size = New Size(548, 17)
            ValuationPanel.Show
            ExpirationPanel.Hide

        Else

            Size = New Size(573, 411)
            Guna2Separator1.Size = New Size(528, 17)
            ExpirationPanel.Show
            ValuationPanel.Hide

        End If

        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Me.Close
        Me.Dispose

    End Sub

    Private Sub ShadowButton_Click(sender As Object, e As EventArgs) Handles ShadowButton.Click

        Me.Close
        Me.Dispose

    End Sub
End Class