
Module Program

    Sub Main()

        Console.Title = "Tokenizer Demo"

        'Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromString("define word ""\w+"";"))
        'Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromFile(".\defines.cfg")
        Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromSerializedFile(".\defines.bin")

        'provider.ToSerializedFile(".\defines.bin")


        Dim parser As New Tokenizer.Parser(provider)


        Dim crlf As String = ControlChars.CrLf

        Console.WriteLine(String.Format("Input: Hello, 'World!'{0}", crlf))

        Console.WriteLine(String.Format("Output: {0}{1}", String.Join(" ", parser.Tokenize("Hello, 'World!'")), crlf))

        parser.Clear()

        Console.WriteLine(String.Format("Input:1 -2 3.14 4e5{0}", crlf))

        Console.WriteLine(String.Format("Output: {0}{1}", String.Join(" ", parser.Tokenize("1 -2 3.14 4e5")), crlf))

        Console.Read()

    End Sub

End Module
