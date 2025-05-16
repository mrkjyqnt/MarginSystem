Public Class Account
    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles ProfileSettingsButton.Click, ProfileSettingsImage2.Click, ProductNameLabel1.Click, ProfileSettingsImage1.Click

        ProfileSettings.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, ProfileSettings)

    End Sub

    Private Sub Account_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2PictureBox3_Click(sender As Object, e As EventArgs) Handles ModifyPinButton.Click, ModifyPinImage2.Click, Label5.Click, ModifyPinImage1.Click

        ModifyPin.Opacity = 0
        GeneralModule.ShowOverlay(MainForm, ModifyPin)

    End Sub

    Private Sub ProfileSettingsButton_MouseEnter(sender As Object, e As EventArgs) Handles ProfileSettingsButton.MouseEnter, ProfileSettingsImage2.MouseEnter, ProductNameLabel1.MouseEnter, ProfileSettingsImage1.MouseEnter

        GeneralModule.PanelToButton(ProfileSettingsButton, ProfileSettingsImage1, ProfileSettingsImage2, 210, "HoveredSettings", "HoveredGenerate")

    End Sub

    Private Sub ProfileSettingsButton_MouseLeave(sender As Object, e As EventArgs) Handles ProfileSettingsButton.MouseLeave

        GeneralModule.PanelToButton(ProfileSettingsButton, ProfileSettingsImage1, ProfileSettingsImage2, 247, "Settings", "Generate")

    End Sub

    Private Sub ProfileSettingsButton_MouseDown(sender As Object, e As MouseEventArgs) Handles ProfileSettingsButton.MouseDown, ProfileSettingsImage2.MouseDown, ProductNameLabel1.MouseDown, ProfileSettingsImage1.MouseDown

        GeneralModule.PanelToButton(ProfileSettingsButton, ProfileSettingsImage1, ProfileSettingsImage2, 147, "HoveredSettings", "HoveredGenerate")

    End Sub

    Private Sub ModifyPinImage2_MouseEnter(sender As Object, e As EventArgs) Handles ModifyPinButton.MouseEnter, ModifyPinImage2.MouseEnter, Label5.MouseEnter, ModifyPinImage1.MouseEnter

        GeneralModule.PanelToButton(ModifyPinButton, ModifyPinImage1, ModifyPinImage2, 210, "HoveredKey", "HoveredGenerate")

    End Sub

    Private Sub ModifyPinButton_MouseLeave(sender As Object, e As EventArgs) Handles ModifyPinButton.MouseLeave

        GeneralModule.PanelToButton(ModifyPinButton, ModifyPinImage1, ModifyPinImage2, 247, "Key", "Generate")

    End Sub

    Private Sub ModifyPinImage2_MouseDown(sender As Object, e As MouseEventArgs) Handles ModifyPinButton.MouseDown, ModifyPinImage2.MouseDown, Label5.MouseDown, ModifyPinImage1.MouseDown

        GeneralModule.PanelToButton(ModifyPinButton, ModifyPinImage1, ModifyPinImage2, 147, "HoveredKey", "HoveredGenerate")

    End Sub

    Private Async Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click

        Dim Question As MsgBoxResult = MessageBox.Show("Are you sure you want to logout?", "Logging out.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If Question = MsgBoxResult.Yes

            Await LoginDatabaseModule.LoggedIn(0, Variables.LoggedInUser)
            Login.Show
            MainForm.Dispose

        ElseIf Question = MsgBoxResult.No

            'Walang ganap. Doon ka sa far away!

        End If


    End Sub
End Class