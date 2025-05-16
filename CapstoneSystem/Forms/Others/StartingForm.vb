Imports System.Threading

Public Class StartingForm

    Dim TimerCount As Integer = 0
    Private Shared appMutex As Mutex


    Private Sub StartingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim isNewInstance As Boolean
        appMutex = New Mutex(True, "MyUniqueAppName", isNewInstance) ' Replace "MyUniqueAppName" with a unique string for your app.

        If Not isNewInstance Then
            ' Application is already running
            MessageBox.Show("The application is already running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BringToForeground() ' Bring the already running instance to the front
            Me.Close() ' Close the current instance
        Else
            ' Start the application normally
            GeneralModule.FadeInForm(Me)
            LoadingTimer.Start()
        End If

    End Sub

    Private Sub BringToForeground()
        ' Bring the already running instance to the foreground
        Dim currentProcess = Process.GetCurrentProcess()
        For Each p As Process In Process.GetProcessesByName(currentProcess.ProcessName)
            If p.Id <> currentProcess.Id Then
                ' Show the main window of the running instance
                ShowWindow(p.MainWindowHandle, SW_RESTORE)
                SetForegroundWindow(p.MainWindowHandle)
                Exit For
            End If
        Next
    End Sub

    <Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(hWnd As IntPtr) As Boolean
    End Function

    <Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function ShowWindow(hWnd As IntPtr, nCmdShow As Integer) As Boolean
    End Function

    Private Const SW_RESTORE As Integer = 9

    Private Async Sub LoadingTimer_Tick(sender As Object, e As EventArgs) Handles LoadingTimer.Tick

        TimerCount += 1

        If TimerCount < 6

            Return
        
        End if

        LoadingTimer.Stop()
        TimerCount = 0
        
        'I che-check if may nakalogin na previous user.
        Variables.LoggedInUser = Await LoginDatabaseModule.GetPreviousUser()
        Variables.AddedBy = Await ProductManagementDatabaseModule.GetUserId(Variables.LoggedInUser)
        
        Me.Hide()
        
        'If meron then mag lo-login agad at pupunta sa MainForm.
        If Not String.IsNullOrEmpty(Variables.LoggedInUser) Then
            
            'Dim DateAdded = Variables.CurrrentDate.ToString("MMMM d, yyyy")
            'Dim TimeAdded = Variables.CurrrentDate.ToString("t")
            'Await ActivityDatabaseModule.InsertActivity("Startup", String.Empty, AddedBy, "account", DateAdded, TimeAdded, $"Start the Application")
            MainForm.Opacity = 0
            MainForm.Show
            Dashboard.ActiveControl = Dashboard.FormPanel
        
        Else

            ''pag walang previously logged-in users, then mag lo-login.
            Login.Opacity = 0
            Login.Show
        
        End If

    End Sub

End Class
