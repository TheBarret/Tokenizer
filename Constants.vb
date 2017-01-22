Public Class Constants
    Public Shared Signature As Byte() = New Byte(1) {&HAF, &HAB}
    Public Shared DESCRIBER_LINE As String = "^\bdefine\b\s+(?<name>[a-z0-9_.]*?)\s+(?<pattern>"".*?""?)\;"
End Class