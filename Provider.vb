Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
<Serializable>
Public NotInheritable Class Provider
    Inherits List(Of Describer)
    Private Signature() As Byte = New Byte(1) {&HFF, &HAF}
    Private Pattern As String = "^\bdefine\b\s+(?<name>[a-z0-9_.]*?)\s+(?<pattern>"".*?""?)\;"
    Public Function FromSerializedFile(Filename As String) As Provider
        Dim provider As Provider = Nothing
        If (New HeaderCreator.Reader().IntegrityCheck(Of Provider)(Filename, Me.Signature, provider)) Then
            Me.AddRange(provider)
        End If
        Return Me
    End Function
    Public Function ToSerializedFile(Filename As String) As Boolean
        Return New HeaderCreator.Writer().Build(Me, Me.Signature, Filename)
    End Function
    Public Function FromFile(Filename As String) As Provider
        If (File.Exists(Filename)) Then
            Return Me.FromStream(New FileStream(Filename, FileMode.Open, FileAccess.Read))
        End If
        Return Me
    End Function
    Public Function FromStream(stream As Stream) As Provider
        Dim buffer() As Byte = New Byte(Convert.ToInt32(stream.Length)) {}
        stream.Read(buffer, 0, buffer.Length)
        Return Me.FromString(Encoding.UTF8.GetString(buffer))
    End Function
    Public Function FromString(str As String) As Provider
        Dim rx As New Regex(Me.Pattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        For Each m As Match In rx.Matches(str)
            If (m.Success) Then
                Me.Add(New Describer(m.Groups("name").Value, m.Groups("pattern").Value))
            End If
        Next
        Return Me
    End Function
End Class