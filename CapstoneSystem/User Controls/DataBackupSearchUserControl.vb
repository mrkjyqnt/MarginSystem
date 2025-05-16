Public Class DataBackupSearchUserControl
    Private Sub BackupNameLabel_MouseEnter(sender As Object, e As EventArgs) Handles Guna2Panel1.MouseEnter, BackupIdLabel.MouseEnter, BackupNameLabel.MouseEnter

        DataBackupAndRecovery.ActiveControl = DataBackupAndRecovery.ResultSearchPanel

    End Sub
End Class
