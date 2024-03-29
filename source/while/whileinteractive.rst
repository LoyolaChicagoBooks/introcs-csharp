.. index:: interactive while loop
   single: loop; while
   while; interactive
   
.. _Interactive-while-Loops:
	
Interactive ``while`` Loops
---------------------------

Next we consider a particular form of ``while`` loops:  Interactive while loops
involve input from the user each time through the loop.  
We consider them now for three reasons:

- Interactive ``while`` loops have one special 'gotcha'
  worth illustrating.
- We will illustrate some general techniques for understanding and developing
  ``while`` loops.
- As a practical matter, 
  we can greatly improve the utility input functions we have been using, and
  add some more.
  
We already have discussed the PromptInt function.  The user can choose
any int.  Sometimes we only want an integer in a certain range.
One approach is to not accept a bad value, but make the user repeat
trying until explicitly
entering a value in the right range.  In theory the user could make errors
for some time, so a loop makes sense.  For instance we might have a slow
user, and there could be an exchange like the following
when you want a number from 0 to 100.  For illustration, user input is shown
in boldface:

   | Enter a score: (0 through 100) **233**
   | 233 is out of range!
   | Enter a score: (0 through 100) **101**
   | 101 is out of range!
   | Enter a score: (0 through 100) **-1**
   | -1 is out of range!
   | Enter a score: (0 through 100) **100**
   
and the value 100 would be accepted.

This is a well-defined idea.  A function makes sense.  Its heading
includes a prompt and low and high limits of the allowed range:

.. literalinclude:: ../../examples/introcs/input_in_range1/input_in_range1.cs
   :start-after: chunk
   :end-before: {
   :dedent: 6

For example to generate
sequence above, the call would be:: 

   PromptIntInRange("Enter a score: (0 through 100) ", 0, 100)

.. index:: concrete example; splitting a loop
   loop; splitting concrete example
   splitting a loop concrete example

There is an issue with the common term "loop" in programming.
In normal English, a loop has no beginning and no end, like a circle.
C# loops have a sequence of statements with a definite beginning and end.

Consider the sequence above in pseudocode.  

..  code-block:: none

    Input a number with prompt (233)
    Print error message
    Input a number with prompt (101)
    Print error message
    Input a number (-1)
    Print error message
    Input a number with prompt (100)
    Return 100

We can break this into a repeating
pattern in two ways.  The most obvious is the following, 
with three repetitions of a basic pattern, 
with the last two line not in the same pattern 
(so they would go after the loop).  :

..  code-block:: none

    Input a number with prompt (233)
    Print error message
   
    Input a number with prompt (101)
    Print error message
   
    Input a number (-1)
    Print error message
   
    Input a number with prompt (100)
    Return 100

Another choice, since  
you can split a loop at any point, would be the following, with the first and
last lines not in the  pattern that repeats three times in the middle:

..  code-block:: none

    Input a number with prompt (233)
   
    Print error message
    Input a number with prompt (101)
   
    Print error message
    Input a number (-1)
   
    Print error message
    Input a number with prompt (100)
   
    Return 100

When you consider ``while`` loops, there is a problem with the first version:
Before the first pass through the loop and at the end of the block of code
in the body of the loop, you must be *able* to run the test in the
while heading.  We will be testing the latest input from the user. 

It is the second version that has us getting new input 
*before the first* loop *and* at the *end of each* loop!

Now we can think more of the basic process to turn this into a C# solution:
What variables do we need?   We will call the user's response ``number``.

What is the test in the while loop heading?
The easiest thing to think of is that we are done when
we get something correct.  That, however, is a *termination* condition.
We need to reverse it to get the *continuation condition*, that the answer is
out of range.  There are two ways to be out of range::

    number < lowLim
    number > highLim

How do we combine them?  Either one rules out a correct answer,
so ``number`` is out of range
if too high OR too low.  Remember the C# symbolism for "or": ``||``::

    while (number < lowLim || number > highLim) {
    
Following the sequence in the concrete example we had above, 
we can see how to put things
together.   
We need to get input from the user *before* first beginning 
the ``while`` loop, so we immediately have something to test
in the ``while`` heading's condition.

Do not reinvent the wheel!  
We can use our earlier general ``PromptInt`` function.  It needs a prompt.
As a first version, we can use the parameter ``prompt``::

   int number = PromptInt(prompt);

That is the initialization step before the loop.

.. index:: pitfall; repeat interactive input
   interactive while loop; repeat interactive input
   
*If* we get into the body of the loop, it means there is an error, 
and the concrete example indicates we print a warning message.
The concrete example *also* shows another step in the loop, asking
the user for input.  It is
easy to think 

   "I already have the code included to read a value from the user,
   so there is nothing really to do."  
   
WRONG!  The initialization code with
the input from the user is *before* the loop.  C# execution approaches the 
test in the ``while`` headings from *two* places at different times: 
the initialization *and* coming back
from the bottom of the loop.  To get a *new* value to test, we must
*repeat* getting input from the user at the *bottom of the loop body*.  

.. index:: compiler error; declaration repeat
   declaration repeat error
   type; declaration repeat error
   
You might decide to be quick 
and just copy the initialization line into the bottom of the
loop (and indent it)::

   int number = PromptInt(prompt);

Luckily you will get a compiler error in that situation, avoiding
more major troubleshooting:  
The *complete* copy of the line copies the *declaration*
part as well as the assignment part, and the compiler sees the declaration of 
``number`` already there 
from the scope outside the while block, and complains.

Hence copy the line, *without* the ``int`` declaration::

   number = PromptInt(prompt);

When the loop condition becomes false, and you get past the loop,
you have a correct value in ``number``.  You have done all the hard work.  
Do not forget to return it at the end.  

.. literalinclude:: ../../examples/introcs/input_in_range1/input_in_range1.cs
   :start-after: chunk
   :end-before: chunk
   :dedent: 6

You can try this full example, :repsrc:`input_in_range1/input_in_range1.cs`.  
Look at it and then try compiling and running.  

Look at the Main code.
It is redundant - the limits are written both in the prompt and in the
parameters.  We can do better.  In general we endeavor to supply data only
once, and let the program use it in several places if it needs to.  
Since the limits are given as parameters, anyway, we prefer
to have the program elaborate the prompt automatically.  
If the limits are -10 and 10,
automatically add to the prompt something like (-10 through 10).

We could use  ::
    
    Console.Write(" ({0} through {1}) ", lowLim, highLim);
    
but we need the code twice, producing the same string each time.
If you recall the  
:ref:`string.Format function <string-format>`, then we can just create
the string once, and use it twice.  
Here is a revised version, in example 
:repsrc:`input_in_range2/input_in_range2.cs`, 
without redundancy in the prompts in ``Main``:

.. literalinclude:: ../../examples/introcs/input_in_range2/input_in_range2.cs
   :start-after: chunk
   :end-before: chunk
   :dedent: 6


This time around we did the user input correctly, with the 
request for new input *repeated* at the end of the loop.
That repetition *is* easy to forget.  Before we see what happens
when you forget, note:

.. index:: pitfall; infinite loop
   infinite loop
   
.. warning::

   A ``while`` loop may be written so the continuation condition is
   *always* true, and the loop *never* stops by itself.  
   This is an *infinite loop*.
   In practice, in many operating environments, particularly
   where you are getting input from the user, 
   you can abort the execution of a program in 
   an infinite loop by entering 
   :kbd:`Ctrl-C`.

In particular you get an infinite loop 
if you fail to get new input from the user at the
end of the loop.  The condition uses the bad
original choice forever.  Here is the loop in the mistaken version, 
from example  :repsrc:`input_in_range2_bad/input_in_range2_bad.cs`:

.. literalinclude:: ../../examples/introcs/input_in_range2_bad/input_in_range2_bad.cs
   :start-after: chunk
   :end-before: chunk
   :dedent: 9


You can run the program.  Remember :kbd:`Ctrl-C` !
There are two tests in ``Main``.  
If you give a legal answer immediately in the first test, 
it works fine (never getting into the loop body).  If you 
give a bad input in the second test, you see that you can never fix it!
Remember :kbd:`Ctrl-C` !

A more extreme abort is to close the entire console/terminal window 
running the program.

.. index:: exercise; Agree
   Agree exercise
   
.. _agree-function-exercise:

Agree Function Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~

Save example :repsrc:`test_agree_stub/test_agree.cs` 
in a project of your own.

Yes-no (true/false) questions are common.
How might you write an input utility function ``Agree``? 
You can speed things
up by considering only the first letter of responses.
Assume that it is important that the user makes a clear response:
Then you should
consider three categories of answer:  ones accepted as true, 
ones accepted as false, and ambiguous ones.  
You need to allow for 
the possibility that the user keeps
giving ambiguous answers for some time....  


.. _interactive-sumEx:
	
Interactive Sum Exercise
~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``sum_all.cs`` that prompts the user to enter
numbers, one per line, ending with a line containing 0, and keep a
running sum of the numbers. Only print out the sum after all the
numbers are entered (at least in your *final* version).


.. index:: exercise; InputWhole
   InputWhole exercise
   
.. _safe-whole-number-input:

Safe Whole Number Input Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Save example :repsrc:`test_input_whole_stub/test_input_whole.cs` as
a project of your own.  The code should test
a function ``PromptWhole``, as described below.

There is an issue with reading in numbers with the PromptInt function.
If you make a typo and enter something that cannot be converted from a
string to the right kind of number, a naive program will bomb.
This is avoidable if you test the string and repeat the input 
if the string is illegal.
Places where more complicated tests for illegality are needed are
considered in :ref:`safe-input-number` and 
:ref:`safest-input-int`.  For now we just consider
reading in whole numbers (integers greater than or equal to 0).  
Note that such
a number is written as just a sequence of digits.   
Follow the interactive model of PromptIntInRange, looping until
the user enters something that is legal: in this case, all digits.

The stub code already includes the earlier function ``IsDigits``.

