.. _string-indexing:

.. index:: string; index [ ]
   single: [ ]; string index

String Indexing
==================================

Strings are composed of characters.  In literals be careful of the different
kinds of quotes: single for individual characters for type ``char`` and double for strings
of 0 or more characters.  For example,
``'u'`` (single quotes) is a char type literal, while ``"u"`` is a string
literal, referencing a string object. While ``"you"`` is a legal string
literal, ``'you'`` generates a compiler error 
(too many characters for a char literal).

Many of the operations on strings depend upon referring to the 
positions of characters in the string.  
A position is given by a numerical *index* number. 
In C#, positions are counted *starting at 0*, not 1.
The indices of the characters in the string "coding" are labeled:

+-------------+-----+-----+-----+-----+-----+-----+
| Index       | 0   | 1   | 2   | 3   | 4   | 5   |
+-------------+-----+-----+-----+-----+-----+-----+
| Character   | c   | o   | d   | i   | n   | g   |
+-------------+-----+-----+-----+-----+-----+-----+

There are 6 characters in ``"coding"``, while the last index is 5.

.. warning::
   
   Because the indices start at 0, not 1,
   the index of the last character is one less that the length of the
   string. This is a common source of errors!

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

.. index:: subscript

C# does not allow the typography for normal mathematical subscripts, 
like :math:`s_2`.
There is a correspondence with index notation, so ``s[2]`` is
sometimes spoken as "s sub 2".  The indices are sometimes referred to as 
*subscripts*.

In this introduction, we have used literal integers for the subscripts. 
The most common situation in practice is to have a variable or a more 
complicated expression as the
subscript.  An expression inside square braces is always 
evaluated to find the resulting index:: 

   csharp> string s = "coding";
   csharp> int n = 3;
   csharp> s[n-1];
   'd'

When we get to loops, we will find this is useful.

Indexing Exercise
--------------------

What is printed by this fragment?  ::

        string str = "fragment";
        int k = 3;
        Console.WriteLine(str[1]);
        Console.WriteLine(str[k]);
        Console.WriteLine(str[2*k - 2]);

Write an expression that would give you the n in ``str``, above.

Play with csharp:  declare other strings and ``int`` variables, and make up
string indexing expressions for which you predict the value and then test.