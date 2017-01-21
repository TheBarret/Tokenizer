# Tokenizer

The tokenizer is a library that can transform a sentence into meaning full and pre-defined tokens

How to define the tokenizer instance
```Visual Basic
Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromString("{rules}"))
Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromFile("{filename}")
```

Tokenizer will only tokenize that what is defined, the rest will be skipped

Example config that defines words, quotes and numbers
```
# neg/pos numbers with or without exponent

define 	decimal		"[-+]?\d*\.\d+([eE][-+]?\d+)?";
define 	integer		"[-+]?\d*([eE]?\d+)";

# word or quoted words

define 	quotedword	"\".*?\"|\'.*?\'";
define 	word		"\w+";

```
