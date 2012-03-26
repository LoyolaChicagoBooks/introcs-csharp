.. index:: boolean expression; condition; comparison
   
.. _More-Conditional-Expressions:
    
More Conditional Expressions
----------------------------

All the usual arithmetic comparisons may be made, but many do not
use standard mathematical symbolism, mostly for lack of proper keys
on a standard keyboard.
 
=====================  ==============   ==============
Meaning                Math Symbol      C# Symbols
=====================  ==============   ==============
Less than              :math:`<`        ``<`` 
Greater than           :math:`>`        ``>``
Less than or equal     :math:`\leq`     ``<=``
Greater than or equal  :math:`\geq`     ``>=``
Equals                 =                ``==``
Not equal              :math:`\neq`     ``!=``
=====================  ==============   ============== 

There should not be space between the two-symbol C#
substitutes.

Notice that the obvious choice for *equals*, a single equal sign,
is *not* used to check for equality. An annoying second equal sign
is required. This is because the single equal sign is already used
for *assignment* in C#, so it is not available for tests.

.. warning::
   It is a common error to use only one equal sign when you mean to *test*
   for equality, and not make an assignment!

Tests for equality do not make an assignment, and they do not
require a variable on the left. 

All these tests work for numbers,
and characters.  Strings can be tested for
equality or inequality (!=). 

Predict the results and try each line in csharp::

    x = 5; 
    x; 
    x == 5; 
    x == 6; 
    x; 
    x != 6; 
    x = 6; 
    6 == x; 
    6 != x; 
    "hi" == "h" + "i"; 
    "HI" != "hi";  

An equality check does not make an assignment. Strings are case
sensitive. 

**Try this**: Following up on the discussion of the *inexactness* of float
arithmetic, confirm that C#
does not consider .1 + .2 to be equal to .3: Write a simple
condition into csharp to test.

.. rubric:: Pay with Overtime Example 

Given a person's work
hours for the week and regular hourly wage, calculate the total pay
for the week, taking into account overtime. Hours worked over 40
are overtime, paid at 1.5 times the normal rate. This is a natural
place for a function enclosing the calculation.

*Read* the setup for the function:

.. literalinclude:: ../examples/Wages1.cs
   :start-after: chunk
   :end-before: chunk

The problem clearly indicates two cases: when no more than 40
hours are worked or when more than 40 hours are worked. In case
more than 40 hours are worked, it is convenient to introduce a
variable overtimeHours. You are encouraged to think about a
solution before going on and examining mine.

You can try running my complete example program, :file:`Wages1.cs`, 
also
shown below. The program uses the keyboard input functions
developed in class.  

.. literalinclude:: ../examples/Wages1.cs
   
This program also introduces new notation for 
displaying decimal numbers:  

.. literalinclude:: ../examples/Wages1.cs
   :start-after: chunk2
   :end-before: chunk2

Inside the format string you see ``{1:F2}`` and ``{2:F2}``:  inside 
the braces, after the parameter index, you see a new part,
``:F2``.  
The part after the colon gives optional formatting information.
In this case display with the decimal point  
**f**\ ixed so  **2** places beyond the decimal
point are shown.  Also the result is *rounded*.  
This is appropriate for money with dollars and cents.  
Replace the 2 to display
a different number of digits after the decimal point.
More formatting instructions will be discussed later. 

Below is an equivalent alternative version of the body of
``CalcWeeklyWages``, used in ``Wages2.cs``. It uses just one
general calculation formula and sets the parameters for the formula
in the ``if`` statement. There are generally a number of ways you might
solve the same problem!

.. literalinclude:: ../examples/Wages2.cs
   :start-after: chunk
   :end-before: chunk


.. _graduateEx:
   
Graduate Exercise
~~~~~~~~~~~~~~~~~
   
Write a program, ``Graduate.cs``, that prompts students for how
many credits they have. Print whether of not they have enough
credits for graduation. (At Loyola University Chicago 120 credits
are needed for graduation.)
