Imports System.Text.RegularExpressions

Public NotInheritable Class Parser
    Inherits List(Of Token)
    Sub New(provider As Provider)
        Me.Provider = provider
    End Sub
    Public Function Tokenize(str As String) As List(Of Token)
        If (Me.Provider IsNot Nothing AndAlso Me.Provider.Any) Then

            Dim len As Integer = 0, index As Integer = 0
            Dim result As Match = Nothing, name As String = String.Empty

            Do While (index < str.Length)
                result = Nothing
                For Each describer In Me.Provider
                    Dim m As Match = New Regex(describer.Pattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline).Match(str, index)
                    If m.Success AndAlso (m.Index - index) = 0 Then
                        result = m
                        name = describer.Name
                        len = result.Length
                        Exit For
                    End If
                Next

                If (result Is Nothing) Then
                    index += 1
                Else
                    Me.Add(New Token(str.Substring(index, len), name))
                    index += len
                End If

            Loop
        End If
        Return Me
    End Function
    Public Property Provider As Provider
End Class
