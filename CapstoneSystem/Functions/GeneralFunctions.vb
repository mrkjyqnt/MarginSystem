Module GeneralFunctions
    
    Function CheckSearchFilters(Parameter1 As String, Parameter2 As String,
                                Parameter3 As String) As Integer

        Dim Search As Integer

        If (Not String.IsNullOrEmpty(Parameter1) And String.IsNullOrEmpty(Parameter2) And
                String.IsNullOrEmpty(Parameter3)) Or (Not String.IsNullOrEmpty(Parameter2) And 
                String.IsNullOrEmpty(Parameter1) And String.IsNullOrEmpty(Parameter3)) Or 
                (Not String.IsNullOrEmpty(Parameter3) And String.IsNullOrEmpty(Parameter1) And 
                String.IsNullOrEmpty(Parameter2)) 

            Search = 1

        ElseIf (Not String.IsNullOrEmpty(Parameter1) And Not String.IsNullOrEmpty(Parameter2) And
                String.IsNullOrEmpty(Parameter3)) Or (Not String.IsNullOrEmpty(Parameter1) And 
                Not String.IsNullOrEmpty(Parameter3) And String.IsNullOrEmpty(Parameter2)) Or 
                (Not String.IsNullOrEmpty(Parameter3) And Not String.IsNullOrEmpty(Parameter2) And 
                String.IsNullOrEmpty(Parameter1)) 

            Search = 2

        ElseIf Not String.IsNullOrEmpty(Parameter1) And Not String.IsNullOrEmpty(Parameter2) And
                Not String.IsNullOrEmpty(Parameter3)

            Search = 3

        End If 

        Return Search

    End Function

End Module
