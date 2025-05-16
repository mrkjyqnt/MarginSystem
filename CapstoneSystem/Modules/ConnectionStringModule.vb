Imports Microsoft.Data.SqlClient

Module ConnectionStringModule

    Async Function OpenDatabaseConnection() As Task(Of SqlConnection)

        Dim Con As New SqlConnection(My.Settings.ConString)
        If Con.State = ConnectionState.Open Then Con.Close
        Await Con.OpenAsync()
        Return Con

    End Function

    Async Function OpenMasterDatabaseConnection() As Task(Of SqlConnection)

        Dim Con As New SqlConnection(My.Settings.MasterDatabaseConString)
        If Con.State = ConnectionState.Open Then Con.Close
        Await Con.OpenAsync()
        Return Con

    End Function

    Async Function OpenBackupConnection() As Task(Of SqlConnection)

        Dim Con As New SqlConnection(My.Settings.DatabaseConString)
        If Con.State = ConnectionState.Open Then Con.Close
        Await Con.OpenAsync()
        Return Con

    End Function

End Module
