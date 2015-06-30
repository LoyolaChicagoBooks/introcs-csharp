.. index:: if-else-if
        
.. _Multiple-Tests:

Multiple Tests and |if-else| Statements
-------------------------------------------

Often you want to distinguish between more than two distinct cases,
but conditions only have two possible results, ``true`` or ``false``,
so the only direct choice is between two options. As anyone who has
played "20 Questions" knows, you can distinguish more cases with
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
would be to test for one grade at a time, and resolve all the
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
and note that the ``if`` part after each else is just a *single*
(possibly very complicated) statement.  This allows the elimination of
some of the braces:

.. literalinclude:: ../source/examples/grade1/grade1.cs
   :start-after: chunk
   :end-before: chunk

A program testing the letterGrade function is in
example program :repsrc:`grade1/grade1.cs`.

See :ref:`gradeEx`.

As in a basic |if-else| statement, in the general format,

   | ``if (`` *condition1* ``) {``
   |      statement-block-run-if-condition1-is-true;       
   | ``}``  
   | ``else if (`` *condition2* ``) {``
   |      statement-block-run-if-condition2-is-the-first-true;       
   | ``}``  
   | ``else if (`` *condition3* ``) {``
   |      statement-block-run-if-condition3-is-the-first-true;       
   | ``}`` 
   | // ...
   | ``else {    //`` *no condition!* 
   |      statement-block-run-if-no condition-is-true;       
   | ``}`` 
    
*exactly one* of the statement blocks gets executed:
If some condition is true,
the first block following a true condition is executed.
If no condition is true,
the ``else`` block is executed.

Here is a variation. Consider this
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

If the final ``else`` clause is omitted from the general ``if`` ... ``else if`` ...
pattern above, at most one block after a condition
is executed:  That is the block after the first true condition.  
If all the conditions are false, none of the statement blocks 
will be executed.

It is also possible to embed |if-else| statements inside other ``if`` or
|if-else| statements in more complicated patterns.

Sign Exercise
~~~~~~~~~~~~~             
   
Write a program ``sign.cs`` to ask the user for a number. Print out
which category the number is in: ``"positive"``, ``"negative"``, or
``"zero"``.


.. _gradeEx:

Grade Exercise
~~~~~~~~~~~~~~              

Copy :repsrc:`grade1/grade1.cs` to ``grade2.cs`` in your own project.
Modify
``grade2.cs`` so it has an equivalent version of the letterGrade
function that tests in the opposite order, first for F, then D, C,
.... Hint: How many tests do you need to do? [#grade]_

Be sure to run your new version and test with different
inputs that test all the different paths through the program.

Be careful for edge cases:  Test the grades on the "edge" of a 
change in the result.

Wages Exercise
~~~~~~~~~~~~~~              
   
Modify the :repsrc:`wages1/wages1.cs` or the :repsrc:`wages2/wages2.cs` 
example to create a
program ``wages3.cs`` that assumes people are paid double time for
hours over 60. Hence they get paid for at most 20 hours overtime at
1.5 times the normal rate. For example, a person working 65 hours
with a regular wage of $10 per hour would work at $10 per hour for
40 hours, at 1.5 * $10 for 20 hours of overtime, and 2 * $10 for
5 hours of double time, for a total of

    10*40 + 1.5*10*20 + 2*10*5 = $800.

You may find :repsrc:`wages2/wages2.cs` easier to adapt than 
:repsrc:`wages1/wages1.cs`.

Caution:  Be sure to thoroughly test your *final* program version.  It is
easy to add new features that work by themselves, but break a part
that worked before! In particular in a program with decisions, make sure you
test with enough different data to check all lines of your program.

.. [#grade]
   4 tests to distinguish the 5 cases, as in the previous version

