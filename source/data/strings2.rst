
.. _Strings2:
   
String Special Cases
======================

.. index::
   escape code \
   single: \ ; character escape code
   character escape code \
   
There are some special cases for creating literal strings.  
For instance, you might want quotes
as characters inside your string.  In this case you need special 
symbolism using a character *escape code*, starting with  ``\`` backslash.
Then the character after the backslash has a special meaning.

For instance a quote character after a backslash, ``\"``,
does not mean the end of a string literal.  It means a quote character
is literally used *in* the string:  ``"He said, \"Hello!\", over and over."``

We can illustrate with a scratch program, first with a simple string:

.. code-block:: csharp

    Console.WriteLine("Hello world!");
    Console.WriteLine("He said, \"Hello!\", over and over.");

Output:

.. code-block:: none

    Hello world!
    He said, "Hello!", over and over.

There are many other escape codes.  The main ones
you are likely to use are:

+-------------+---------------------------------------+
| Escape code | Meaning                               |
+=============+=======================================+
| ``\"``      | ``"`` (quote)                         |
+-------------+---------------------------------------+
| ``\'``      | ``'`` ( single quote in char literal) |
+-------------+---------------------------------------+
| ``\\``      | ``\`` (backslash)                     |
+-------------+---------------------------------------+
| ``\n``      | newline                               |
+-------------+---------------------------------------+

Hence if you really want a backslash character in a literal, 
you need to write two of them.

The newline character indicates further text will appear on the next line down
when *printed* with the ``Console.WriteLine`` function.  

Example:

.. code-block:: csharp

    Console.WriteLine("Windows path: c:\\Users\\aharrin");
    Console.WriteLine("a\nbc\n\ndef")

Output:

.. code-block:: none

    Windows path: c:\Users\aharrin
    a
    bc
    
    def
    
.. index::
   string; @
   @ string literal
   verbatim string with @

Literal strings that are simply delimited by quotes ``"`` 
must start and end on the same line. 
There is also a notation for *\ @-quoting*, with an at-sign ``@`` before the first
quote.  In an @-quoted string, all characters are treated verbatim, including
all backslashes.  Also the string may go on for several lines, and all newlines
are included literally.
This fragment in a program would produce the same output as the statements in
the example above::

           Console.WriteLine(@"Windows path: c:\Users\aharrin");
           Console.WriteLine(@"a
    bc
    
    def");
    
The only thing this example does not show well is the amount of
left margin indentation.
That is significant in a multiline @-quoted string.  
A complete short program with this code is in example 
:repsrc:`at_sign_strings/at_sign_strings.cs`.

.. index:: string; verbatim display
  
Caution:  A printed string does not include the original escape-code spelling.
The output shows the actual characters in the string:

.. code-block:: csharp

    Console.WriteLine("Windows path: c:\\Users\\aharrin");
    Console.WriteLine("a\nbc\n\ndef");

Output:

.. code-block:: none

    Windows path: c:\Users\aharrin
    a
    bc
    
    def

Multiline String Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~

a.  Write a statement that initializes a string ``s`` with a **single**
    string literal that, when printed, shows something on one line then three 
    empty lines, and then a final line with text.
b.  Declare the same string with a different string literal expression, that
    produces the same string.  (Just one of your literals should start
    with ``@``.)
