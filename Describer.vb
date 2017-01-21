Imports System.Text.RegularExpressions
Public NotInheritable Class Describer
    Sub New(Name As String, Pattern As String, Optional Skip As Boolean = False)
        Me.Name = Name
        Me.Skip = Skip
        Me.Pattern = Pattern.Substring(1, Pattern.Length - 2)
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("{0}: {1}", If(Me.Skip, "Skip", "Define"), Me.Name)
    End Function
    Public Property Skip As Boolean
    Public Property Name As String
    Public Property Pattern As String
End Class
