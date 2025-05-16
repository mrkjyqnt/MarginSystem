Public Class Login

    Dim TimerCount As Integer = 0

    Private Async Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Kukunin yung dalawang name ng users sa database.
        Dim Users as List(Of Object)
        Users = Await LoginDatabaseModule.GetUsers()
        Users.ToString

        'Conditions if meron or walang query na Usernames.
        If Users.Count = 0

            MessageBox.Show("No data found. Contact the customer service.", "No Users", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            User1Button.Text = Users(0)
            User2Button.Text = Users(1)

        End If

        'Kukunin yung remaining locktime na natira nung previous close ng Login Form.
        Variables.RemainingLockTime = Await LoginDatabaseModule.GetAllotedTime("remaining_time")

        'If may remaining locktime.
        If Variables.RemainingLockTime > 0

            LockPanel.Show
            UsersPanel.Hide

            TimeLabel.Show
            TimeLabel.Text = Variables.NewLockTime
            LockTimer.Start

        Else

            LockTimer.stop

        End If
        GeneralModule.FadeInForm(Me)

    End Sub

    Private Sub User1Button_Click(sender As Object, e As EventArgs) Handles User1Button.Click

        EnterPin.Opacity = 0
        '1st User.
        Variables.LoggedInUser = User1Button.Text
        GeneralModule.ShowOverlay(Me, EnterPin)

        'lock the form if the user did 5 tries.
        If Variables.Retry = 5

            LockPanel.Show
            UsersPanel.Hide
            LockTimer.start
            Variables.Retry = 0

        End If

        'Hide the 1st Form.
        If MainForm.Visible = True

            Me.Hide

        ElseIf MainForm.Visible = False

            me.Show

        End If

        Focus()
        ActiveControl = FillPanel

    End Sub

    Private Sub User2Button_Click(sender As Object, e As EventArgs) Handles User2Button.Click

        EnterPin.Opacity = 0
        '2nd User.
        Variables.LoggedInUser = User2Button.Text
        GeneralModule.ShowOverlay(Me, EnterPin)

        'lock the form if the user did 5 tries.
        If Variables.Retry = 5

            LockPanel.Show
            UsersPanel.Hide
            LockTimer.start

        End If

        'Hide the 1st Form.
        If MainForm.Visible = True

            me.Hide

        ElseIf MainForm.Visible = False

            me.Show

        End If

    End Sub

    Private Sub Login_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        'If login form is moved, 'pag niresize babalik lagi sa gitna.
        If Me.WindowState = FormWindowState.Normal

            Me.CenterToScreen

        End If

    End Sub

    Private Async Sub LockTimer_Tick(sender As Object, e As EventArgs) Handles LockTimer.Tick

        'Timer count for form lock
        TimerCount += 1
        Variables.NewLockTime = Variables.RemainingLockTime - TimerCount

        If TimerCount < Variables.RemainingLockTime

            'Lock yung login form.
            LockPanel.Show
            UsersPanel.Hide

            TimeLabel.Show
            TimeLabel.Text = Variables.NewLockTime

        Else

            'If Tapos na yung timer, re-enable ulit yung login form.
            LockTimer.Stop()

            LockPanel.Hide
            UsersPanel.Show

            TimeLabel.Hide

            TimerCount = 0
            Variables.Retry = 0
            Await LoginDatabaseModule.SaveLockTime(0)

        End If

    End Sub

    Private Async Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        'I-update yung remaining lock time if na close yung form ng hindi natapos yung timer.
        Await LoginDatabaseModule.SaveLockTime(Variables.NewLockTime)
        Application.Exit

    End Sub

End Class