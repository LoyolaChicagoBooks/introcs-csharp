.. _string-indexing:

.. index::
   double: string; index

String Indexing
==================================

Strings are composed of characters, but be careful of the different
kinds of quotes, single for individual characters, double for strings
of 0 or more characters:
'u' (single quotes) is a char type literal, while "u" is a string
literal, referencing a string object. While "you" is a legal string
literal, 'you' generates a compiler error (too many characters - only
one allowed).

Many of the operations on strings depend upon counting positions of characters
in the string. In C#, positions are counted *starting at 0*, not 1.
The indices of the characters in the string "coding" are labeled:

+-------------+-----+-----+-----+-----+-----+-----+
| Index       | 0   | 1   | 2   | 3   | 4   | 5   |
+-------------+-----+-----+-----+-----+-----+-----+
| Character   | c   | o   | d   | i   | n   | g   |
+-------------+-----+-----+-----+-----+-----+-----+

The position of a character in a string is usually referred to as the
character's *index*. Note that because the indices start at 0, not 1,
the index of the last character is one less that the length of the
string. This is a common source of errors. Watch out.

You can easily create an expression that refers 
to an individual character inside a string.  Use
square braces around the index of the character::

   csharp> string s = "coding";
   csharp> s[2];
   'd'
   csharp> s[0];
   'c'
   csharp> s[5];
   'g'
   csharp> string greeting = "Bonjour";
   csharp> greeting[1];
   'o'
   
Note from the single quotes that the result is a ``char`` in each case.
