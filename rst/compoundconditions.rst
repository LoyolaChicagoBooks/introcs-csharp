.. index::
   single: &&; boolean operation AND
   and &&
   boolean operation; && AND

.. _Compound-Boolean-Expressions:
   
Compound Boolean Expressions
----------------------------

To be eligible to graduate from Loyola University Chicago, you must
have 120 credits *and* a GPA of at least 2.0. C# does not use the
word *and*.  Instead it uses ``&&`` (inherited from the C language).  
Then the requirement 
translates directly into C# as a *compound condition*::

	credits >= 120 && GPA >=2.0      

This is true if both ``credits >= 120`` is true and
``GPA >= 2.0`` is
true. A short example function using this would be::

    static void checkGraduation(int credits, double GPA) 
    {
        if (credits >= 120 && GPA >=2.0) { 
            Console.WriteLine("You are eligible to graduate!"); 
        }
        else { 
            Console.WriteLine("You are not eligible to graduate."); 
        }
    }

The new C# syntax for the operator ``&&``:

	*condition1* ``&&`` *condition2*

The compound condition is true if both of the component conditions
are true. It is false if at least one of the conditions is false.

Suppose we want a C# condition that is true in the same situations as the mathematical
expression: low < val < high.  Unfortunately the math is not a
C# expression.  The C# operator ``<`` is binary.  In C# the statement above is
equivalent to 

    (low < val) < high

comparing a Boolean result to high, and causing a compiler error.
There is a C# version.  Be sure to use this pattern::

   low < val && val < high

.. index::
   single: ||; boolean operation OR
   or ||
   boolean operation; || OR

Now suppose we want the opposite condition:  that val is *not* 
strictly between low and high.
There are several approaches.  
One is that ``val`` would be less than or equal to low 
*or* greater than or equal to ``high``.  C# translate *or* into ``||``,
so a C# expression would be:

    val <= low || val >= high
    
The new C# syntax for the operator ``||``:

	*condition1* ``||`` *condition2*

The compound condition is true if at least one of the component conditions
are true. It is false if both conditions are false.

.. index::
   single: ! boolean operation NOT
   not !
   boolean operation; ! NOT

Another logical way to express the opposite of the condition low < val < high
is that it is *not* the case
that low < val && val << high.  C# translates *not* as ``!``.  Another way
to state the condition would be ::

    !(low < val && val < high)

The parentheses are needed because the ``!`` 
operator has higher precedence than
``<``.

A way to remember this strange *not* operator is to think of the use of ``!``
in the not-equal operator: ``!=``   

The new C# syntax for the operator ``!``:

	``!`` *condition* 

This whole expression is true when *condition* is false, 
and false when *condition* is true.

Because of the precedence of ``!``, you are often going to write:

	``!(`` *condition* ``)`` 

Remember when such a condition is used in an ``if`` statement, *outer*
parentheses are also needed:

	``if (!(`` *condition* ``)) {`` 
	
We now have a lot of operators!  Most of those in appendix :ref:`precedence`
have now been considered. There 
you can see that ``!`` has the high precedence of unary arithmetic operators.
The operators ``&&`` and ``||`` are almost at the bottom of the operators 
considered in this book, just above the assignment operators, and below the
relational operators, with ``&&`` above ``||``.  
You are encourages to use parentheses to make sure.
	
**Compound Overkill**:  Look back to the code converting a score to a letter grade
in :ref:`Multiple-Tests`.
The condition before assigning the B grade could have been::

    (score >= 80 && score < 90)
    
That would have totally nailed the condition, but it is overly verbose in the
``if`` .. ``else if`` ... code where it appeared:  
Since you only get to consider a B as a grade if the grade was *not* already
set to A, the second part of the compound condition above is redundant.  

There are a couple more wrinkles with compound Boolean expressions introduced 
later in :ref:`short-circuit`.

.. _congressEx:

Congress Exercise
~~~~~~~~~~~~~~~~~
   
A person is eligible to be a US Senator who is at least 30 years
old and has been a US citizen for at least 9 years. Write a version
of a program ``congress.cs`` to obtain age and length of
citizenship from the user and print out if a person is eligible to
be a Senator or not. A person is eligible to be a US Representative
who is at least 25 years old and has been a US citizen for at least
7 years. Elaborate your program ``congress.cs`` so it obtains age
and length of citizenship and prints whether a person is eligible
to be a US Representative only, or is eligible for both offices, or
is eligible for neither.

This exercise could be done by making an exhaustive treatment of all 
possible combinations of age and citizenship.  Try to avoid that.  
(Note the paragraph just before this exercise.)  

Caution:  be sure to do exhaustive testing.  It is easy to write code
that is correct for *some* inputs, but not all.

.. index:: implication operator

Implication Exercise
~~~~~~~~~~~~~~~~~~~~~~~

We have introduced C# Boolean operators for AND, OR, and NOT. 
There are other Boolean operators important in logic, 
that are not directly given as a C# operator.  
One example is "implies", also expressed
in a logical if-then statement:  If I am expecting rain, then I am carrying an
umbrella.  Otherwise put:  "I am expecting rain" *implies* 
"I am carrying an umbrella". The first part is a Boolean expression called the
*hypothesis*, and the second part is called the *conclusion*.  In general, when
A and B are Boolean expressions, "A implies B" is also a Boolean expression.  

Just as the truth of a compound Boolean expression like "A and B" depends on the
truth value of the two parts, so with *implies*:
If you are using good logic, and you start with a true assertion, 
you should only be able to conclude something else true, so it is true that 
"true implies true".  If you start with garbage you can use that false statement
in a logical argument and end up with something either false or true:
"false implies false" and "false implies true" are both true. The only thing
that should not work is to start with something true and conclude 
something false.  If that were the case, logical arguments would be useless,
so "true implies false" is false.  There is no C# operator for "implies", but
you can check all four cases of Boolean values for A and B to see that 
"A implies B" is true exactly when "not A or B" is true.  We can 
express this in C# as ``!A || B``.  

So here is a silly little exercise illustrating both implication and using
the C# Boolean operators:  Ask the user whether "I am expecting rain" is true.
(We have the UI function Agree.)  Then check with the user whether 
"I am carrying an umbrella."  Then conclude and print out 
whether the implication "If I am expecting rain, then I am carrying an
umbrella." is true or not in this situation.

