
Strings, Part I
===============

Enough with numbers for a while. Strings of characters are another
important type in C#.

.. index::
   string; "

A string in C# is a sequence of characters. For C# to
recognize a literal sequence of characters, like ``hello``, as a string, it
must be enclosed in quotes ``"`` to delimit the string.  Special cases
are considered later in :ref:`strings2`.


.. index::
   double: string; concatenation
   double; string; +

.. _String-Concatenation:
   
String Concatenation
--------------------
   
We can operate on numbers with arithmetic operators, including ``+``.
Because everything in C# is typed, C# can give a special meaning to
operators depending on the types involved.  This means ``+`` can have
a special meaning with a string. Look at the example
in csharp:

.. code-block:: none

    csharp> "very " + "hot";
    "very hot"

The plus operation with strings means *concatenate* the strings: join them
together end to end.

C# is even a bit smarter.  If you use a ``+`` with a string, presumable you
are looking to produce a string, so even if the second operand to the ``+`` is
*not* a string, it is automatically converted to a string representation before
concatenating:

.. code-block:: none

    csharp> x = 3;
    csharp> string result;
    csharp> result = "We get " + x;
    csharp> result;
    "We get 3"

You can chain concatenations.  We could make a full sentence adding a period:

.. code-block:: none

    csharp> "We get " + x + ".";
    "We get 3."
    
