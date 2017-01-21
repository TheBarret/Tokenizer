# Tokenizer

The tokenizer is a library that can transform a sentence into meaning full and pre-defined tokens


![example](https://i.imgur.com/dqzEIsq.png)

Declaring and setting up the tokenizer instance
``` VB.NET
Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromString("{rules}"))
- or -
Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromFile("{filename}")
- or -
Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromStream({stream})

Dim parser As New Tokenizer.Parser(provider)

parser.tokenize({input})
```

The result is returned as 'List(Of Tokenizer.Token)'

- Example Config

A config that defines words, quotes and numbers for the provider that will instruct the parser what to recognize
```
# neg/pos numbers with or without exponent

define 	decimal		"[-+]?\d*\.\d+([eE][-+]?\d+)?";
define 	integer		"[-+]?\d*([eE]?\d+)";

# word or quoted words

define 	quotedword	"\".*?\"|\'.*?\'";
define 	word		"\w+";
```


- Format:

```
Define {name} {"regex pattern"};
```


- Remarks

The tokenizer will skip any symbol that is not defined.
