Imports System.Text.RegularExpressions
Public NotInheritable Class Describer
    Sub New(Name As String, Pattern As String)
        Me.Name = Name
        Me.Pattern = Pattern.Substring(1, Pattern.Length - 2)
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("{0}: {1}", Me.Name, Me.Pattern)
    End Function
    Public Property Name As String
    Public Property Pattern As String
End Class
