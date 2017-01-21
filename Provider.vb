Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Public NotInheritable Class Provider
    Inherits List(Of Describer)
    Sub New()
        Me.Encoder = Encoding.UTF8
    End Sub
    Sub New(Encoder As Encoding)
        Me.Encoder = Encoder
    End Sub
    Public Function FromFile(Filename As String) As Provider
        If (File.Exists(Filename)) Then
            Return Me.FromStream(New FileStream(Filename, FileMode.Open, FileAccess.Read))
        End If
        Return Me
    End Function
    Public Function FromStream(stream As Stream) As Provider
        Dim buffer() As Byte = New Byte(Convert.ToInt32(stream.Length)) {}
        stream.Read(buffer, 0, buffer.Length)
        Return Me.FromString(Me.Encoder.GetString(buffer))
    End Function
    Public Function FromString(str As String) As Provider
        Dim rx As New Regex(Constants.DESCRIBER_LINE, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        For Each m As Match In rx.Matches(str)
            If (m.Success) Then
                Me.Add(New Describer(m.Groups("name").Value, m.Groups("pattern").Value))
            End If
        Next
        Return Me
    End Function
    Public Property Encoder As Encoding
End Class