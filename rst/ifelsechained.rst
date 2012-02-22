.. index:: if-else-if; if
        
.. _Multiple-Tests:

Multiple Tests and |if-else| Statements
-------------------------------------------

Often you want to distinguish between more than two distinct cases,
but conditions only have two possible results, ``true`` or ``false``,
so the only direct choice is between two options. As anyone who has
played "20 Questions" knows, you can distinguish more cases by
further questions. If there are more than two choices, a single
test may only reduce the possibilities, but further tests can
reduce the possibilities further and further. Since most any kind
of statement can be placed in the sub-statements in 
an |if-else| statement, one
choice is a further ``if`` or |if-else| statement. 
For instance consider a
function to convert a numerical grade to a letter grade, 'A', 'B',
'C', 'D' or 'F', where the cutoffs for 'A', 'B', 'C', and 'D' are
90, 80, 70, and 60 respectively. One way to write the function
would be test for one grade at a time, and resolve all the
remaining possibilities inside the next ``else`` clause. 
If we do this consistent with our indentation conventions so far::

    static char letterGrade(double score)
    {
       char letter;
       if (score >= 90) {
          letter = 'A'; 
       }
       else {   // grade must be B, C, D or F 
          if (score >= 80) { 
             letter = 'B'; 
          }
          else { // grade must be C, D or F 
             if (score >= 70) { 
                letter = 'C'; 
             }
             else {   // grade must D or F 
                if (score >= 60) {
                   letter = 'D'; 
                }
                else { 
                   letter = 'F';
                }
             }   //end else D or F
          }      // end of else C, D, or F
       }         // end of else B, C, D or F
       return letter;
    }


This repeatedly increasing indentation with an ``if`` statement in
the ``else`` clause can be annoying and distracting. Here is a preferred
alternative in this situation, that avoids all this further
indentation:  
Combine each ``else`` and following ``if`` onto the same line, 
and note that the ``if`` part after an else is just a *single*
(possibly very complicated) statement, allowing some braces to be removed:

.. literalinclude:: ../examples/Grade1.cs
   :start-after: chunk
   :end-before: chunk

A program testing the letterGrade function is in
example program ``Grade1.cs``.

See :ref:`gradeEx`.

While an |if-else| statement always chooses an alternative to execute,
a plain ``if`` statement may end up executing no sub-statement.  If
you have a more complicated embedding of |if-else| and ``if`` 
statements, you must look carefully to see how many different 
sub-statements may be chosen.  For example consider this
fragment *without* a final ``else``::

    if (weight > 120) {
        Console.WriteLine("Sorry, we can not take a suitcase that heavy.");
    }
    else if (weight > 50) { 
        Console.WriteLine("There is a $25 charge for luggage that heavy.");
    }
    
This statement only prints one of two lines if there is a
problem with the weight of the suitcase.  Nothing is printed if 
there is not a problem.

Sign Exercise
~~~~~~~~~~~~~             
   
Write a program ``Sign.cs`` to ask the user for a number. Print out
which category the number is in: ``"positive'``, ``"negative"``, or
``"zero"``.


.. _gradeEx:

Grade Exercise
~~~~~~~~~~~~~~              

Copy ``Grade1.cs`` to ``Grade2.cs`` Modify
``Grade2.cs`` so it has an equivalent version of the letterGrade
function that tests in the opposite order, first for F, then D, C,
.... Hint: How many tests do you need to do? [#grade]_

Be sure to run your new version and test with different
inputs that test all the different paths through the program.

Wages Exercise
~~~~~~~~~~~~~~              
   
Modify the ``Wages1.cs`` or the ``Wages2.cs`` example to create a
program ``Wages3.cs`` that assumes people are paid double time for
hours over 60. Hence they get paid for at most 20 hours overtime at
1.5 times the normal rate. For example, a person working 65 hours
with a regular wage of $10 per hour would work at $10 per hour for
40 hours, at 1.5 * $10 for 20 hours of overtime, and 2 * $10 for
5 hours of double time, for a total of

    10*40 + 1.5*10*20 + 2*10*5 = $800.

You may find ``Wages2.cs`` easier to adapt than ``Wages1.cs``.


.. [#grade]
   4 tests to distinguish the 5 cases, as in the previous version

