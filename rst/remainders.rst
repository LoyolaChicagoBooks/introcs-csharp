.. index:: 
   double: division; remainder 

.. _Division-and-Remainders:
   
Division and Remainders
=========================

Try in the csharp shell.  Be sure to include the decimal points::

    5.0/2.0; 
    14.0/4.0; 

On the other hand, try in csharp::

	14/4;
	
you get something that looks strange:  Just and addition, subtraction, and multiplication
of ``int``\ s produces and ``int``, so, too with division.

In C#, the result of the / operator depends on the
type of the operands, not on the mathematical value of the operands.

If you think about it, you learned several ways to do division.
Eventually you learned how to do division resulting in a decimal.
In the earliest grades you would say

    "14 divided by 4 is 3 with a remainder of 2". 

Note the the quotient is an integer 3, that matches the C# evaluation of 14/4,
so having a way to generate an integer quotient is not actually too strange.
The problem here is
that the answer from grade school is in two parts, the integer quotient 3 and the
remainder 2.  

C# has separate operation to generate the remainder part.  There is no standard
single operator character operator in regular math, so C# grabs an unused symbol 
(the same ias in many other computer languages): % is the remainder operator.

Try in the csharp shell::

    14%4;
    
You see you do get the remainder from our grade school division.

Now predict and then try each in the csharp shell::

    23/5; 
    23%5; 
    20%5; 
    6/8; 
    6%8; 
    6.0/8;

The / operator can be confusing, depending on the type, not the mathematical value.
Note that if at least one operand is double, the result was be.

Finding remainders will prove more useful than you might think in
the future!


.. _QuotientProblem:

Exercise for Quotients
------------------------

Write a program, ``quotient.cs``, that
prompts the user for two integers, and then prints them out in a
sentence with an integer division problem like ::

   The quotient of 14 and 3 is 4 with a remainder of 2
