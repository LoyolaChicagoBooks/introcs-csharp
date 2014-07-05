
.. _Strings2:
   
String Special Cases
======================

.. index::
   escape code \
   \ escape code
   
There are some special cases for creating literal strings.  
For instance you might want quotes
as characters inside your string.  In this case you need special 
symbolism using a string *escape code*, starting with  ``\`` backslash.
Then the character after the backslash has a special meaning.

For instance a quote character after a backslash, ``\"``,
does not mean the end of the string.  It means a quote character
is literally used *in* the string:  ``"He said, \"Hello!\", over and over."``

We can illustrate with csharp, first with a simple string:

.. code-block:: none

    csharp> Console.WriteLine("Hello world!");
    Hello world!
    csharp> Console.WriteLine("He said, \"Hello!\", over and over.");
    He said, "Hello!", over and over.

There are many other special cases of escape code.  The main ones
you are likely to use are:

+-------------+-------------------+
| Escape code | Meaning           |
+=============+===================+
| ``\"``      | ``"`` (quote)     |
+-------------+-------------------+
| ``\\``      | ``\`` (backslash) |
+-------------+-------------------+
| ``\n``      | newline           |
+-------------+-------------------+

Hence if you really want a backslash character in a literal string, 
you need to write two of them.

The newline character indicates further text will appear on the next line down
when *printed* with the ``Console.WriteLine`` function.  

Example:

.. code-block:: none

    csharp> Console.WriteLine("Windows path: c:\\Users\\aharrin");
    Windows path: c:\Users\aharrin
    csharp> Console.WriteLine("a\nbc\n\ndef")
    a
    bc
    
    def
    
.. index::
   string; @
   @ string literal

Literal strings that are simply delimited by quotes ``"`` 
must start and end on the same line. 
There is also a notation for *\ @-quoting*, with an at-sign ``@`` before the first
quote.  In an @-quoted string, all characters are treated literally, including
all backslashes.  Also the string may go on for several lines, and all newlines
are included literally.  (The csharp program does not recognize 
multi-line @-quoted strings.)
This fragment in a program would produce the same output as the statements in
the csharp example above::

           Console.WriteLine(@"Windows path: c:\Users\aharrin");
           Console.WriteLine(@"a
    bc
    
    def");
    
The only thing this example does not show off well is the amount of
left margin indentation.
That is significant in a multiline @-quoted string.  
A whole simple program with this code is in example 
:repsrc:`at_sign_strings/at_sign_strings.cs`.
   


