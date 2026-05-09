.. index:: arithmetic

.. _arithmetic:
   
Arithmetic
==================

We start with the integers and integer arithmetic, not because
arithmetic is exciting, but because the symbolism should be mostly
familiar. Of course arithmetic is important in many cases, but
C# is often used to manipulate text and other
sorts of data.


.. index:: dotnet command
   csharp; legacy Mono shell

.. _csharp:

Testing Small Expressions with dotnet
-------------------------------------

Older versions of these notes used Mono's ``csharp`` interactive shell for
quick experiments.  Modern .NET installations do not include that shell.
For current work, use a small console project as a scratch program and run it
with ``dotnet``.

Create a scratch project once:

.. code-block:: none

    mkdir csharp-scratch
    cd csharp-scratch
    dotnet new console --use-program-main

Open ``Program.cs`` in Visual Studio Code, ``vim``, ``emacs``, or another text
editor.  Put test statements inside ``Main``:

.. code-block:: csharp

    using System;

    class Program
    {
       static void Main()
       {
          Console.WriteLine(2 + 3);
       }
    }

Run the program:

.. code-block:: none

    dotnet run

The output is:

.. code-block:: none

    5

For later quick tests, replace or add statements inside ``Main`` and run
``dotnet run`` again.

.. index::
   single: operator; + with numbers
   single: +; with numbers

Play along with the examples here by putting each expression inside
``Console.WriteLine``:

.. code-block:: csharp

    Console.WriteLine(2 + 3);

This evaluates the expression ``2 + 3`` and prints the result.

.. index::
   operator; -
   single: -; subtraction

Subtraction works as you would expect.  
Blanks are optional around symbols: 

.. code-block:: none
 
    7

For the binary arithmetic operators, add spaces to make the expression
easier for humans to read.

C# itself is not line-oriented.  A long expression can be split across lines
when the syntax is incomplete:

.. code-block:: csharp
 
    Console.WriteLine(10
       - 3);

.. index::
   operator; *
   single: * multiplication

In math class you could enter something like 4(10) for multiplication:

.. code-block:: csharp
 
    Console.WriteLine(4(10));

Unfortunately, error messages are not always easy to follow.  
The compiler cannot reliably guess what a programmer intended.

The issue here is that the multiplication operator must be *explicit* in
C#.  Recall that an asterisk is used as a multiplication operator:

.. code-block:: csharp
 
    Console.WriteLine(4 * 10);

.. index::
   single:  ( ); grouping
   grouping ( )
   single: -; negation
     
Put each of the following expressions inside ``Console.WriteLine``, and think
what they will produce before you run the program:

.. code-block:: none
 
    2*5 
    2 + 3 * 4 

If you expected the last answer to be 20, think again: C# uses
the normal *precedence* of arithmetic operations: Multiplications
divisions, and negations are done before addition and subtraction, unless
there are parentheses forcing the order: 

.. code-block:: csharp
 
    Console.WriteLine(-(2+3)*4);

A sequence of operations with equal precedence also works like in math: 
left to right in most cases, like for combinations of addition and subtraction:

.. code-block:: csharp
 
    Console.WriteLine(10 - 3 + 2);

.. index:: 
   single: remainder %
   single: % remainder
   single: operator; /, %
   division
   single: / ; division
   single: . ; double literal
   double
   int
   type; int
   type; double

.. _Division-and-Remainders:
   
Division and Remainders
--------------------------------

   
We started with the almost direct translations from math.  Division is
more complicated.  Try these statements in your scratch program:

.. code-block:: csharp

    Console.WriteLine(5.0/2.0);
    Console.WriteLine(14.0/4.0);

So far so good.  Now consider:

.. code-block:: csharp

    Console.WriteLine(14/4);

What?  Some explanation is in order.  All data has a *type* in C#.
When you write an explicit number
without a decimal point, like 2, 17, or -237,
it is interpreted as the type of an integer, called ``int`` for short.

When you include a decimal point, the type is ``double``, representing a more
general real number.  This is true even if the value of the number is an
integer like 5.0: the type is still ``double``.

Addition, subtraction, and multiplication work as you would expect for
``double`` values, too:

.. code-block:: csharp

    Console.WriteLine(0.5 * (2.0 + 4.5));

If one or both
of the operands to ``/`` is a ``double``, the result is a ``double``, 
close to the actual quotient.  
We say close,
because C# stores 
values with only a limited precision, so in fact results are
only approximate in general.  For example:

.. code-block:: csharp

    Console.WriteLine(1.0/3);

Small errors are also possible with the ``double`` type 
and the other arithmetic operations.  See :ref:`type-double`.

.. note::
   
   In C#, the result of the / operator depends on the
   *type* of the operands, not on the *mathematical value* of the operands.
 
Division with ``int`` data is handled completely differently.  

If you think about it, you learned several ways to do division.
Eventually you learned how to do division resulting in a decimal.
In the earliest grades, however, you would say

    "14 divided by 4 is 3 with a remainder of 2." 

Note the quotient is an integer 3, that matches the C# evaluation of 14/4,
so having a way to generate an integer quotient is not actually too strange.
The problem here is that the answer from grade school is in *two* parts, 
the integer quotient 3 and the remainder 2.  

C# has a *separate* operation symbol to generate the remainder part.  
There is no standard
single-character operator for this in regular math, 
so C# grabs an unused symbol: 
``%`` is the remainder operator.  
(This is the same as in many other computer languages.)

Try in your scratch program:

.. code-block:: csharp

    Console.WriteLine(14 / 4);
    Console.WriteLine(14 % 4);
    
You see that with the combination of the ``/`` operator and the ``%`` operator,
you get both the quotient and the remainder from our grade school division.

Now predict and then try each of these expressions:

.. code-block:: none

    23/5 
    23%5
    20%5 
    6/8
    6%8
    6.0/8

Finding remainders will prove more useful than you might think in
the future!  Remember the strange ``%`` operator.

.. note::
   The precedence of ``%`` is the same as ``/`` and ``*``, and hence
   higher than addition and subtraction, ``+`` and ``-``. 

There are some more details about numeric types in :ref:`value-types`.

.. index:: expression

We have been testing arithmetic expressions, with the word 
*expression* used pretty much like with normal math.  More generally in C#
an *expression* is any syntax that evaluates to a single value of some type.  
We will introduce many more types and operations that can be used in expressions. 

Divisible by 17 Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~

What is a simple expression that lets you see if an int x is divisible by 17?   

Mixed Arithmetic Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~

*Think* of the result of one of these at a time; write your prediction, 
and *then* test, and write the correct answer afterward if you were wrong.
Then go on to the next.... 
For the ones you got wrong, can you explain the result after seeing it? ::

    2 * 5 + 3
    2 + 5 * 3
    1.5 * 3
    7.0/2.0
    7.0/2
    7/2.0
    4.0 * 3 / 8
    4 * 3 / 8
    6 * (2.0/3)
    6 * (2/3)
    3 + 10 % 6
    10 % 6 + 3
