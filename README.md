# Tokenizer

The tokenizer is a library that can transform a sentence into meaning full and pre-defined tokens

How to define the tokenizer instance

```
Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromString("{rules}"))
Dim provider As Tokenizer.Provider = New Tokenizer.Provider().FromFile("{filename}")
```

Tokenizer will only tokenize that what is defined, the rest will be skipped

Example config that defines words, quotes and numbers

