Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
<Serializable>
Public NotInheritable Class Provider
    Inherits List(Of Describer)
    Sub New()
        Me.Encoder = Encoding.UTF8
    End Sub
    Sub New(Encoder As Encoding)
        Me.Encoder = Encoder
    End Sub
    Public Function FromSerializedFile(Filename As String) As Provider
        If (File.Exists(Filename)) Then
            Using fs As New FileStream(Filename, FileMode.Open, FileAccess.Read)
                Dim buffer() As Byte = New Byte(Convert.ToInt32(fs.Length - 1)) {}
                fs.Read(buffer, 0, buffer.Length)
                If (buffer.BeginsWith(Constants.Signature)) Then
                    Dim checksum() As Byte = buffer.Peek(Constants.Signature.Length, 4)
                    buffer = buffer.NibbleTop(Constants.Signature.Length + checksum.Length)
                    If (checksum.SequenceEqual(buffer.ToCrc32)) Then
                        Dim obj As Object = FromByte.Convert(buffer.Decompress)
                        If (TypeOf obj Is Provider) Then
                            Me.AddRange(CType(obj, Provider))
                        End If
                        Return Me
                    End If
                End If
            End Using
        End If
        Throw New Exception("Invalid file")
    End Function
    Public Sub ToSerializedFile(Filename As String)
        Using fs As New FileStream(Filename, FileMode.Create, FileAccess.Write)
            Dim buffer() As Byte = FromObject.Convert(Me).Compress.InsertAfter(Function(arg) arg.ToCrc32(), Constants.Signature, 0)
            fs.Write(buffer, 0, buffer.Length)
        End Using
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