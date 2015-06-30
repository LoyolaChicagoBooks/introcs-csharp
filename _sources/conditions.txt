.. _Simple-Conditions:

Conditions I
============================ 

Thus far, within a given function, instructions have been executed
sequentially, in the same order as written.  Of course that is often
appropriate!  On the other hands if you are planning your instruction
sequence,
you can get to a place where you say, "Hm, that depends....", and
a choice must be made.  The simplest choices are two-way: do one
thing if a condition is true, and another (possibly nothing) if the
condition is not true.

More syntax for conditions will be introduced later,
but for now consider simple arithmetic comparisons that directly
translate from math into C#. First start csharp an enter::

    int x = 11; 

Now think of which of these expressions below are true and which false, 
and then enter each one into your csharp session to test::

    2 < 5
    3 > 7
    x > 10 
    2*x < x 

You see the C# values, either ``true`` or ``false`` (with no
quotes!). These are the only possible *Boolean* values (named after
19th century mathematician George Boole). You can also use the
abbreviation for the type ``bool``.  It is the type of the
results of true-false conditions or tests.

The simplest place to use conditions is in a decision made with an 
``if`` statement. 

We will consider :ref:`More-Conditional-Expressions` later, but this is a 
quick start with the easiest ones.
