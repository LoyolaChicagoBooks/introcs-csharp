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
on a standard keyboard. 
(If you are looking at the following table in the html version,
you need to be online and may need an up-to-date browser 
to see these mathematical symbols be displayed correctly,
as well as the mathematical expressions later in the text.  The pdf version
of the book automatically shows all the right math symbolism online or offline.
 
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
   :end-before: {
   :dedent: 6

The problem clearly indicates two cases: when no more than 40
hours are worked or when more than 40 hours are worked. In case
more than 40 hours are worked, it is convenient to introduce a
variable overtimeHours. You are encouraged to think about a
solution before going on and examining mine.

You can try running the complete example program, :repsrc:`wages1/wages1.cs`, 
also shown below.  

.. literalinclude:: ../source/examples/wages1/wages1.cs
   :linenos:
  
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
   :dedent: 9

In the format string are ``{1:F2}`` and ``{2:F2}``:  Inside 
the braces, after the parameter index, you see a new part,
``:F2``.  
The part after the colon gives additional formatting information.
In this case: Display with the decimal point  
fixed (hence the **F**) so  **2** places beyond the decimal
point are shown.  Also the result is *rounded*.  
This is appropriate for money with dollars and cents.  
You can replace the 2 to display
a different number of digits after the decimal point.
More formatting syntax is introduced in :ref:`tables`. 

Because |if-else| statements alter the flow or execution, and altering this flow
causes lots of problems for many students, this is a good place to
play computer to illustrate clearly what is happening.  We will just 
concentrate on a call to ``CalcWeeklyWages``, where the |if-else|
statement is.

Recall that to play computer,
we keep track of the state of variables while following execution carefully,
statement by statement.  
The big point here is that this order of execution is *not* textual order!
If we are just following a call to ``CalcWeeklyWages``, we start at
line 9, and we will assume for example that it is called with
``totalHour`` as 50 and ``hourlyWage`` as 14.00: 

====  ==========  ========  =======================================
Line  totalWages  overtime  Comment
====  ==========  ========  =======================================
9     \-          \-        Assume passed totalHours=50; hourlyWage=14
12                          50 <= 40: false; SKIP if clause
16                10        50-40=10 at start of else clause
17    770                   14*40 + (1.5*14)*10 = 770
19                          return 770 to caller
====  ==========  ========  =======================================

We *skipped* the executable line 13 in the if-true clause.

Instead suppose the function is called with 
``totalHour`` as 30 and ``hourlyWage`` as 14.00:

====  ==========  ========  =======================================
Line  totalWages  overtime  Comment
====  ==========  ========  =======================================
9     \-          \-        Assume passed totalHours=30; hourlyWage=14
12                          30 <= 40: true; continue straight
13    420                   14*30 = 420; SKIP else clause
19                          return 420 to caller
====  ==========  ========  =======================================

We skipped the executable lines 16-17 
in the if-false clause after ``else``.

Below is an equivalent alternative version of 
``CalcWeeklyWages``, used in :repsrc:`wages2/wages2.cs`. It uses just one
general calculation formula and sets the parameters for the formula
in the ``if`` statement. There are generally a number of ways you might
solve the same problem!

.. literalinclude:: ../source/examples/wages2/wages2.cs
   :start-after: Include
   :end-before: chunk
   :linenos:
   :dedent: 6

Wages Play Computer Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

We played computer on the original version of ``CalcWeeklyWages``.  Now
follow the second version above, from :repsrc:`wages2/wages2.cs`.  Try it
with the same two sets of formal parameter values.  

====  ============  ========  ===============================================
Line  regularHours  overtime  Comment
====  ============  ========  ===============================================
1     \-            \-        Assume passed totalHours=50; hourlyWage=14
\ 
\ 
\ 
\ 
====  ============  ========  ===============================================

====  ============  ========  ===============================================
Line  regularHours  overtime  Comment
====  ============  ========  ===============================================
1     \-            \-        Assume passed totalHours=30; hourlyWage=14
\ 
\ 
\ 
\ 
====  ============  ========  ===============================================


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
of a ``double``, and remember the power of 10 notation with ``E``
for ``double`` literals. See :ref:`type-double` and the section on limits 
after it.)
   

