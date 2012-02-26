.. index::
   triple:  &&; and; boolean operation

.. _Compound-Boolean-Expressions:
   
Compound Boolean Expressions
----------------------------

To be eligible to graduate from Loyola University Chicago, you must
have 120 credits *and* a GPA of at least 2.0. C# does not use the
word *and*.  Instead it uses ``&&``.  Then the statement 
translates directly into C# as a *compound condition*::

	credits >= 120 && GPA >=2.0      

This is true if both ``credits >= 120`` is true and
``GPA >= 2.0`` is
true. A short example function using this would be::

    static void checkGraduation(int credits, double GPA) 
    {
        if (credits >= 120 && GPA >=2.0) { 
            Console.WriteLine('You are eligible to graduate!') 
        }
        else { 
            Console.WriteLine('You are not eligible to graduate.') 
        }
    }

The new C# syntax for the operator ``&&``:

	*condition1* ``&&`` *condition2*

The compound condition is true if both of the component conditions
are true. It is false if at least one of the conditions is false.

Suppose we want a condition that is true if the mathematical
condition is true: low < val < high.  Unfortunately the math is not a
C# expression.  The operator ``<`` is binary.  There is a C# version::

   low < val && val < high

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
are true. It is false if at both conditions are false.

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

For other examples and different words of introduction to ``if`` statements, 
braces, and compound conditions, you might look at 
Miles, section 2.3.2.

.. _congressEx:

Congress Exercise
~~~~~~~~~~~~~~~~~
   
A person is eligible to be a US Senator who is at least 30 years
old and has been a US citizen for at least 9 years. Write a version
of a program ``Congress.cs`` to obtain age and length of
citizenship from the user and print out if a person is eligible to
be a Senator or not. A person is eligible to be a US Representative
who is at least 25 years old and has been a US citizen for at least
7 years. Elaborate your program ``Congress.cs`` so it obtains age
and length of citizenship and prints whether a person is eligible
to be a US Representative only, or is eligible for both offices, or
is eligible for neither.


..   java short circuit

     && and \|\|
     ~~~~~~~~~~~
    
     Start the example project andOr, class AndOr Consider the method:
     public static boolean and1(int x, int y, int z)
     {
     return (y/x > z) && (x != 0);
     }
     run it with the parameters below and predict the results before seeing
     the answer.
     (2, 5, 1)
     (2, 5, 4)
     (0, 2, 1)
     Note the error. Division by 0 stops execution.
     Now consider
     public static boolean and2(int x, int y, int z)
     {
     return (x != 0) && (y/x > z);
     }
     This is apparently logically equivalent. Run parameters (0, 2, 1) with
     this method.
     The different result is caused by short-circuiting. The result of
     false && anything
     is always false -- there is no need to evaluate the second operand, and
     there is an advantage to skipping it sometimes, so that is how Java (and
     many other computer languages) behave.
     Now see if you have an easier time predicting the behavior of
     public static boolean or1(int x, int y, int z)
     {
     return (y/x > z) \|\| (x == 0);
     }
     Guess the behavior of calling it with parameters
     (2, 5, 4)
     (0, 2, 1)
     Again division by 0.
     How could we avoid it? Hopefully you thought of
     public static boolean or2(int x, int y, int z)
     {
     return (x == 0) \|\| (y/x > z);
     }
     Try parameters (0, 2, 1) with this method.
     Again short-circuiting.
     true \|\| anything
     is true, and lava skips considering the second operand.
     Now guess the result with parameters (2, 7, 3) and try it.
     It will test
     2==0 \|\| 7/2 > 3
     If you did not get it right think about it.....
     All the parameters are ints. What is 7/2 ? It is 3 (dropping the
     remainder).
     Consider
     public static boolean or3(int x, double y, int z)
     {
     return (x == 0) \|\| (y/x > z);
     }
     Note the double type of y. Now try parameters (2, 7, 3) again. Watch
     out for the difference between Java integer division with '/' and the
     use you see in pure math.