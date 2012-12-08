.. index::
   single: operator; + (with numbers)
   single: +; arithmetic
   double: operator; -
   double: operator; *
   double:  ( ); grouping

.. _arithmetic:
   
Arithmetic
==================

We start with the integers and integer arithmetic, not because
arithmetic is exciting, but because the symbolism should be mostly
familiar. Of course arithmetic is important in many cases, but
C# is often used to manipulate text and other
sorts of data.


.. index:: csharp

.. _csharp:

Csharp
---------

Of course we could write programs to demonstrate arithmetic,
but there is a fair amount of overhead with a full program.
For just testing little bits, there is another alternative:
The Mono system comes with a program *csharp*.  Let us
try it out.

Open a terminal (Linux or OS X) or :ref:`mono-command-prompt`
window in Windows, and enter the command ``csharp``.  You should see  :

.. code-block:: none

    Mono C# Shell, type "help;" for help

    Enter statements below.
    csharp>  

The ``csharp>`` prompt tells you that the C# interpreter has started
and is awaiting input. This allows you to create C# variables and
execute C# statements without having to write a full program! 

You can enter whole statements, ending with a semicolon.  Unlike 
with a program you can just enter an expression (but followed by a semicolon)
and the expression gets evaluated and printed on a line of its own.  
We can test out arithmetic, for example.

Play along with the examples here, entering what comes after the prompt:

.. code-block:: none
 
    csharp> 2 + 3;
    5

The csharp program just has a read, evaluate, and print loop: the acronym is 
*repl*.

The csharp program is not line-oriented.  The semicolon indicates that
you are finished with an entry.  You can easily forget it.  
If your statement is incomplete you get another ``>`` prompt (with no
"csharp"), until you complete your entry with a ``;`` (semicolon).

.. code-block:: none
 
    csharp> 10-3
          > ;
    7

Subtraction works as you would expect.  

Blanks are optional around symbols: 

.. code-block:: none
 
    csharp> 10 - 3;
    7

For the arithmetic operators, you are encouraged to add blanks to make the expression
more easily readable by humans.

In math class you could enter something like 4(10) for multiplication:

.. code-block:: none
 
    csharp> 4(10);
    {interactive}(1,2): error CS0119: Expression denotes a 'value', 
    where a 'method group' was expected

Unfortunately the error messages are not always easy to follow:  it is hard to guess the
intention of the user making a mistake.

The issue here is that the multiplication operator must be *explicit* in
C#.  Recall that an asterisk is used as a multiplication operator:

.. code-block:: none
 
    csharp> 4 * 10;
    40
    
Enter each of the following expressions into csharp, and think what they
will produce (and then check):    

.. code-block:: none
 
    2*5; 
    2 + 3 * 4; 

If you expected the last answer to be 20, think again: C# uses
the normal *precedence* of arithmetic operations: Multiplications
and divisions are done before addition and subtraction, unless
there are parentheses forcing the order: 

.. code-block:: none
 
    csharp> (2+3)*4; 
    20 

A sequence of operations with equal precedence also work like in math: left to right.

.. code-block:: none
 
    csharp> 10 - 3 + 2; 
    9 

.. index:: 
   double: division; remainder 
   single: operator; /
   double: operator; %
   double: %; remainder 
   double: division; /
   single: . ; double literal
   double
   int
   type; int
   type; double

.. _Division-and-Remainders:
   
Division and Remainders
--------------------------------

   
We started with the almost direct translations from math.  Division is
more complicated.  We continue in the csharp program:

.. code-block:: none

    csharp> 5.0/2.0;
    2.5
    csharp> 14.0/4.0;
    3.5

So far so good.  Now consider:

.. code-block:: none

    csharp> 14/4;
    3

What?  Some explanation is in order.  All data has a *type* in C#.
When you write an explicit number
without a decimal point, like 2, 17, or -237,
it is interpreted as the type of an integer, called ``int`` for short.

When you include a decimal point, the type is ``double``, representing a more
general real number.  This is true even if the value of the number is an
integer like 5.0: the type is still ``double``.

Addition, subtraction, and multiplication work as you would expect for
``double`` values, too:

.. code-block:: none

    csharp> 0.5 * (2.0 + 4.5);
    3.25


.. note::
   
   In C#, the result of the / operator depends on the
   *type* of the operands, not on the *mathematical value* of the operands.

If one or both
of the operands to ``/`` is a ``double``, the result is a ``double``, 
close to the actual quotient.  
We say close,
because C# stores 
values with only a limited precision, so in fact results are
only approximate in general.  For example:

.. code-block:: none

    csharp> 1.0/3;
    0.333333333333333

Small errors are also possible with the ``double`` type 
and the other arithmetic operations.  See :ref:`type-double`.
 
Division with ``int`` data is handled completely differently.  

If you think about it, you learned several ways to do division.
Eventually you learned how to do division resulting in a decimal.
In the earliest grades, however, you would say

    "14 divided by 4 is 3 with a remainder of 2." 

Note the the quotient is an integer 3, that matches the C# evaluation of 14/4,
so having a way to generate an integer quotient is not actually too strange.
The problem here is
that the answer from grade school is in *two* parts, the integer quotient 3 and the
remainder 2.  

C# has a *separate* operation symbol to generate the remainder part.  There is no standard
single operator character operator for this in regular math, 
so C# grabs an unused symbol: 
``%`` is the remainder operator.  
(This is the same as in many other computer languages.)

Try in the csharp shell:

.. code-block:: none

    csharp> 14 / 4;
    3
    csharp> 14 % 4;
    2
    
You see that with the combination of the ``/`` operator and the ``%`` operator,
you get both the quotient and the remainder from our grade school division.

Now predict and then try each of these expression in csharp:

.. code-block:: none

    23/5; 
    23%5; 
    20%5; 
    6/8; 
    6%8; 
    6.0/8;

Finding remainders will prove more useful than you might think in
the future!  Remember the strange ``%`` operator.

When you are done with csharp, you can enter the special statement

    quit;

After we discuss variables and statements there is 
:ref:`more about csharp <more-csharp>`.
    
.. note::
   The precedence of ``%`` is the same as ``/`` and ``*``, and hence
   higher than addition and subtraction, ``+`` and ``-``. 

There are some more details about numeric types in :ref:`value-types`.
    