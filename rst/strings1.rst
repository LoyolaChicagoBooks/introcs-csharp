
Strings, Part I
===============

Enough with numbers for a while. Strings of characters are another
important type in C#.

.. index:: string
   single: "..." for string literal

A string in C# is a sequence of characters. For C# to
recognize a literal sequence of characters, like ``hello``, as a string, it
must be enclosed in quotes ``"`` to delimit the string: ``"hello"``.  
Special cases are considered later in :ref:`strings2`.


.. index:: string; concatenation with +
   concatenation
   single: +; string concatenation
   operator; + string concatenation

.. _String-Concatenation:
   
String Concatenation
--------------------
   
Because everything in C# is typed, C# can give a special meaning to
operators depending on the types involved,
as we saw with ``/``.
We can operate on numbers with arithmetic operators, including ``+``.
With strings ``+`` has a completely different meaning. Look at the example
in csharp:

.. code-block:: none

    csharp> "never" + "ending";
    "neverending"

The plus operation with strings means *concatenate* the strings: join them
together end to end.

C# is even a bit smarter.  If you use a ``+`` with a string, presumable you
are looking to produce a string, so even if the second operand to the ``+`` is
*not* a string, it is automatically converted to a string representation before
concatenating:

.. code-block:: none

    csharp> int x = 42;
    csharp> string result;
    csharp> result = "We get " + x;
    csharp> result;
    "We get 42"

You can chain concatenations.  We could make a full sentence adding a period:

.. code-block:: none

    csharp> "We get " + x + ".";
    "We get 42."

Note to Python programmers:  Unfortunately there is no ``*`` 
multiplication operator for strings in C#.
 
Four Copies Exercise
~~~~~~~~~~~~~~~~~~~~~~
In csharp declare and initialize a string variable.  Write an expression that
evaluates to four copies of the string, so it works no matter what value you
gave your string.

..  dump, like Conrad said
    Thirty-two Copies Exercise
    ~~~~~~~~~~~~~~~~~~~~~~~~~~~
    This is an extension of the previous exercise, except with 32 copies,
    but do not do it with one long
    expression.  Include some extra short *assignment statements* in the middle, 
    to shorten the overall 
    writing.  Hint:  32 was chosen since you can reach it by repeated *doubling*.
    To repeatedly double, you must save the result after each intermediate doubling.

Sum String Exercise
~~~~~~~~~~~~~~~~~~~~~~

In csharp declare and initialize two int's, x and y.  Then enter an expression whose
value is "x + y is 56", except that 56 is replaced by the sum of x and y, and is not
a literal, but calculated from the actual values of variables x and y (which do not
need to add up to 56 specifically).

This has a trick to it.

Ints and Strings Added
~~~~~~~~~~~~~~~~~~~~~~

In csharp enter  ::

   int x = 2;
   int y = 3;
   
*Think* what the csharp response 
is to each of these then write one predicted response at a time, 
*then* test it,
and put the right answer beside your answer if you were wrong::

   x + "??" + y;
   x + y + "??";
   (x * y + "??"); 
   "??" + x * y;
   "??" + x + y;
   x + "??" * y;
   
Can you explain the ones you got wrong, after looking at the actual answer?
Precedence and operation order is important.
