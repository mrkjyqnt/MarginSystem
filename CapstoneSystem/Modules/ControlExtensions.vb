Module ControlExtensions

    'Para ma double buffered yung forms.
    'This method adds double buffering to any control
    <Runtime.CompilerServices.Extension()>
    Public Sub SetDoubleBuffered(control As Control, value As Boolean)

        ' Set the control's DoubleBuffered property via reflection
        Dim propertyInfo = control.GetType().GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        If propertyInfo Is Nothing Then
            Return
        End If

        propertyInfo.SetValue(control, value)


    End Sub

End Module
