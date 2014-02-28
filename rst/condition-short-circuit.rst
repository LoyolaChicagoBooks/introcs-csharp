.. index::
   single: short-circuit && and ||
   single: ||; short-circuit
   single: &&; short-circuit
   
.. _short-circuit:

Short-Circuiting && and \|\|
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Follow along with the following silly, but illustrative csharp sequence::

	csharp> int x = 5, y = 2, z = 1;
	csharp> y/x > z && x != 0;
	false
	csharp> x = 2; y = 5;
	csharp> y/x > z && x != 0;
	true

The compound condition includes ``x != 0``,
so what happens if we change x to 0 and 
try the condition again.  Will you get ``false``? ::

	csharp> x = 0;
	csharp> y/x > z && x != 0; 
	System.DivideByZeroException: Division by zero
	...

No, one of the parts involves dividing by zero, and you see the result.
What if we swap the two conditions to get the *logically equivalent*  ::

	csharp> x != 0 && y/x > z;
	false

Something is going on here besides pure mathematical logic.  
Remember the final version in :ref:`IsDigits <IsDigits>`.  We did not
need to continue processing when we knew the final answer
already.  The ``&&`` and ``||`` operators work the same way,
evaluating from left to right.  If ``x != 0`` is ``false``,
then ``x != 0 && y/x > z`` starts off being evaluated like
``false && ??``.  We do no need the second part evaluated to
know the overall result is ``false``, so C# 
*does not evaluate further*.  This behavior has
acquired the jargon *short-circuiting*.  Many computer languages share
this feature.

It also applies to ``||``.  In what situation do you know 
what the final result is after evaluating
the first condition?  In this case you know:: 

    true || ??

evaluates to true.  Continuing with the same csharp sequence above
(where x is 0, y is 5, and z is 1)::

	csharp> x == 0 || y/x > z;
	true

The division by 0 in the second condition *never happens*. 
It is short-circuited.

For completeness, try the other order::

    csharp> y/x > z || x == 0;          
    System.DivideByZeroException: Division by zero
    ...

This idea is useful in the ``Agree`` function, where you
want to deal with the first character in the user's answer.

In situations where you want to 
test conditionThatWillBombWithBadData, you want to avoid
causing an Exception.  
When there is good data, you want the result to actually 
come from conditionThatWillBombWithBadData.  There are two cases,
however, depending on what result
you want if the data for this condition *is bad*, so you cannot evaluate it:  

- If you want the result to be ``false`` with bad data for the dangerous
  condition, use

    falseConditionIfDataBad ``&&`` conditionThatWillBombWithBadData

- If you want the result to be ``true`` with bad data for
  the dangerous condition, use

    trueConditionIfDataBad ``||`` conditionThatWillBombWithBadData

   