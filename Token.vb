Imports System.Text.RegularExpressions
Public NotInheritable Class Token
    Sub New(Value As String, Type As String)
        Me.Type = Type
        Me.Value = Value
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("[{0}:{1}]", Me.Type, Me.Value)
    End Function
    Public Property Type As String
    Public Property Value As String
End Class
