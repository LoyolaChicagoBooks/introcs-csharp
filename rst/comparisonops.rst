.. index:: 
   boolean expression
   comparison < > <= >= == !=
   single: < less than 
   single: <= less than or equal 
   single: > greater than 
   single: >= greater than or equal
   single: == equality test
   single: != inequality test
   
.. _More-Conditional-Expressions:
    
More Conditional Expressions
----------------------------

All the usual arithmetic comparisons may be made in C#, but many do not
use standard mathematical symbolism, mostly for lack of proper keys
on a standard keyboard. (If you are looking at the following table in the html version,
you may need an up-to-date browser to see the mathematical symbols correctly,
and also the mathematical expressions later in the text.)
 
=====================  ==============   ==============
Meaning                Math Symbol      C# Symbols
=====================  ==============   ==============
Less than              :math:`<`        ``<`` 
Greater than           :math:`>`        ``>``
Less than or equal     :math:`\leq`     ``<=``
Greater than or equal  :math:`\geq`     ``>=``
Equals                 :math:`=`        ``==``
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

Tests for equality do not make an assignment. Tests for equality can have an 
arbitrary expression on the left, not just a variable. 

All these tests work for numbers,
and characters.  Strings can also be compared, most often for
equality (==) or inequality (!=), though they also have a defined order,
so you can use ``<``, for instance.

Predict the results and try each line in csharp::

    int x = 5; 
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
    string s = "Hello";
    string t = "HELLO";
    s == t;  
    s.ToUpper() == t;

An equality check does not make an assignment. Strings equality tests are case
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

.. literalinclude:: ../source/examples/wages1/wages1.cs
   :start-after: chunk
   :end-before: chunk

The problem clearly indicates two cases: when no more than 40
hours are worked or when more than 40 hours are worked. In case
more than 40 hours are worked, it is convenient to introduce a
variable overtimeHours. You are encouraged to think about a
solution before going on and examining mine.

You can try running my complete example program, :repsrc:`wages1/wages1.cs`, 
also shown below.  

.. literalinclude:: ../source/examples/wages1/wages1.cs
  
.. index::
   format; digits shown in string
   precision; format with {:F#} 
   digits formatted in string
   single: :; string precision formatting
   
This program also introduces new notation for 
displaying decimal numbers:  

.. literalinclude:: ../source/examples/wages1/wages1.cs
   :start-after: chunk2
   :end-before: chunk2

In the format string are ``{1:F2}`` and ``{2:F2}``:  Inside 
the braces, after the parameter index, you see a new part,
``:F2``.  
The part after the colon gives additional formatting information.
In this case display with the decimal point  
fixed (hence the **F**) so  **2** places beyond the decimal
point are shown.  Also the result is *rounded*.  
This is appropriate for money with dollars and cents.  
You can replace the 2 to display
a different number of digits after the decimal point.
More formatting syntax is introduced in :ref:`tables`. 

Below is an equivalent alternative version of the body of
``CalcWeeklyWages``, used in :repsrc:`wages2/wages2.cs`. It uses just one
general calculation formula and sets the parameters for the formula
in the ``if`` statement. There are generally a number of ways you might
solve the same problem!

.. literalinclude:: ../source/examples/wages2/wages2.cs
   :start-after: chunk
   :end-before: chunk


.. _graduateEx:
   
Graduate Exercise
~~~~~~~~~~~~~~~~~
   
Write a program, ``graduate.cs``, that prompts students for how
many credits they have. Print whether of not they have enough
credits for graduation. (At Loyola University Chicago 120 credits
are needed for graduation.)

Roundoff Exercise
~~~~~~~~~~~~~~~~~

In csharp declare and initialize  non-zero ``double`` variables
``x`` and ``y``.  Experiment so, according to C# (and csharp):  ``x+y == x``.
In other words, while ``y`` is not 0, adding it to  ``x`` does not
change ``x``.  (Hints:  Note the approximate number of digits of accuracy
of a ``double``, and remember the power of 10 notation with ``E``.)
   

