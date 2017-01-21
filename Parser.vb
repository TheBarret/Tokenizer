Imports System.Text.RegularExpressions

Public NotInheritable Class Parser
    Inherits List(Of Token)
    Sub New(provider As Provider)
        Me.Provider = provider
    End Sub
    Public Function Tokenize(str As String) As List(Of Token)
        If (Me.Provider IsNot Nothing AndAlso Me.Provider.Any) Then

            Dim result As Match = Nothing, skip As Boolean = False
            Dim name As String = String.Empty, len As Integer = 0, index As Integer = 0

            Do While (index < str.Length)
                result = Nothing
                For Each describer In Me.Provider
                    Dim m As Match = New Regex(describer.Pattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline).Match(str, index)
                    If m.Success AndAlso (m.Index - index) = 0 Then
                        result = m
                        skip = describer.Skip
                        name = describer.Name
                        len = result.Length
                        Exit For
                    End If
                Next

                If (result Is Nothing) Then
                    index += 1
                Else
                    If (Not skip) Then
                        Me.Add(New Token(str.Substring(index, len), name))
                    End If
                    index += len
                End If

            Loop
        End If
        Return Me
    End Function
    Public Property Provider As Provider
End Class
