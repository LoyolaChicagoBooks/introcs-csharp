.. index::
   triple: interactive; loop; while

   
.. _Interactive-while-Loops:
	
Interactive ``while`` Loops
---------------------------

Next we consider a particular form of ``while`` loops, interactive ones,
involving input from the user each time through.  
We consider them now for three reasons:

- Interactive ``while`` loops have one special 'gotcha'
  worth illustrating.
- We will illustrate some general techniques for understanding and developing
  ``while`` loops.
- As a practical matter, 
  we can greatly improve the utilty input functions we have been using, and
  add some more.
  
We alredy have discussed the InputInt function.  The user can choose
any int.  Sometimes we only want an integer in a certain range.
Miles has examples that handle this by just silently changing
a bad value to one at the end of the allowed range.  
Another approach is to not accept a bad value, and get the user to explicitly
enter a value in the right range.  In theory the user could make errors
for some time, so a loop makes sense.  For instance we might have a slow
user, and there could be an exchange like the following
when you want a number from 0 to 100.  For illustration, user input is shown
in boldface:

   | Enter a score: (0 to 100) **233**
   | 233 is out of range!
   | Enter a score: (0 to 100) **101**
   | 101 is out of range!
   | Enter a score: (0 to 100) **-1**
   | -1 is out of range!
   | Enter a score: (0 to 100) **100**
   
and the value 100 would be accepted.

This is a well-defined idea.  A function makes sense.  Its heading
includes a prompt and low and high limits of the allowed range:

.. literalinclude:: ../examples/PromptUserLoop1.cs
   :start-after: chunk
   :end-before: {

There is no need to put the limits in the prompt, since the function can
create that part from the limit parameters.  For example to generate
sequence above, the call would be: 

   ``InputIntInRange("Enter a score: ", 0, 100)``

.. index::
   double: concrete example; splitting a loop

There is an issue with the common term "loop" in programming.
In normal English, a loop has no beginning and no end, like a circle.
C# loops have a sequence of statements with a definite beginning and end.

Consider the sequence above in pseudocode.  

   | Input a number with prompt (233)
   | Print error message
   | Input a number with prompt (101)
   | Print error message
   | Input a number (-1)
   | Print error message
   | Input a number with prompt (100)
   | Return 100


We can break into a repeating
pattern in two ways.  The most obvious is theofllowing, 
with three repetitions of a basic pattern, 
with the last two line not in the same pattern 
(so they would go after the loop).  :

   | Input a number with prompt (233)
   | Print error message
   |
   | Input a number with prompt (101)
   | Print error message
   |
   | Input a number (-1)
   | Print error message
   |
   | Input a number with prompt (100)
   | Return 100


Another choice, since  
you can split a loop at any point, would be the following, with the first and
last lines not in the  pattern repeating three times in the middle:

   | Input a number with prompt (233)
   |
   | Print error message
   | Input a number with prompt (101)
   |
   | Print error message
   | Input a number (-1)
   |
   | Print error message
   | Input a number with prompt (100)
   |
   | Return 100

When you consider ``while`` loops, there is a problem with the first version:
Before the first pass through the loop and at the end of the block of code
in the body of the loop, you must be *able* to run the test in the
while heading.  We will be testing the latest input from the user. 

It is the second version that has us getting new input 
*before the first* loop and at the *end of each* loop!

Now we can think more of the basic process to turn this into a C# solution:
What variables do we need?   We will call the user's response ``number``.

What is the test in the while loop heading?
The easilest thing to think of is that we are done when
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
We can use our earlier general ``IntInput`` function.  It needs a prompt.
As a first version, we can use the parameter ``prompt``::

   int number = InputInt(prompt);

That is the initialization step before the loop.

.. index::
   double: pitfall; repeat interactive input
   
If we get into the body of the loop, it means there is an error, 
and the concrete example indicates we print a warning message.
The concrete example *also* shows another step in the loop, asking
the user for input.  It is
easy to think 
"I already have the code included to read a value from the user,
so there is nothing really to do."  WRONG!  The intitialization code with
the input from the user is *before* the loop.  C# execution approaches the 
test in the ``while`` headings from *two* places: 
the initialization *and* coming back
from the bottom of the loop.  To get a *new* value to test, we must
*repeat* getting input from the user at the bottom of the loop body.  

.. index::
   double: pitfall; repeat declaration
   
You might decide to be quick 
and just copy the initialization line into the bottom of the
loop (and indent it)::

   int number = InputInt(prompt);

Luckily you will get a compiler error in that situation, avoiding
more major troubleshooting:  
The complete copy of the line copies the declaration
part as well as the assignment part, and mono sees the declaration of 
``number`` already there 
from the scope outside the while block, and complains.

Hence copy the line, *minus* the `` int`` declaration::

   number = InputInt(prompt);

When the loop condition becomes false, and you get past the loop,
you have a correct value in ``number``.  You have done all the hard work.  
Do not forget to return it at the end.  

.. literalinclude:: ../examples/PromptUserLoop1.cs
   :start-after: chunk
   :end-before: chunk

You can try this full example, ``PromptUserLoop1.cs``.  Look at it
and then try compiling and running.  If you ran it without looking
at the Main code, you might be confused about what values it would accept.

There are two approaches here:  The caller could give a more explicit
prompt.  Since the limits are given as parameters, anyway, we prefer
to have the program elaborate the prompt.  If the limits are -10 and 10,
automatically add to the prompt something like (-10 through 10).

We could use  ::
    
    Console.Write(" ({0} through {1}) ", lowLim, highLim);
    
but we need the code twice, and it is quite a mouthful.  
Thus far we have only seen the use of format strings when immediately 
printing with ``Console.Write`` (or ``WriteLine``).
Here we would like to generate a string, for *use later*.  

.. index::
   double: string; Format
   
We introduce 
the C# library function  ``string.Format``, which does just what we want:  
The parameters
have the same form as for ``Console.Write``, but the formatted string is
*returned*.

Here is a revised version, in example ``PromptUserLoop2.cs``:

.. literalinclude:: ../examples/PromptUserLoop2.cs
   :start-after: chunk
   :end-before: chunk

The only caveat with ``string.Format`` is that
there is *no* special function corresponding to ``Console.WriteLine``.
You can generate a newline with string.Format:  Remember the
escape code ``"\n"``.  Put it at the end to go on to a newline.

This time around we did the user input correctly, with the 
request for new input *repeated* at the end of the loop.
That repetition *is* easy to forget.  Before we see what happens, note:

.. index::
   double: pitfall; infinite loop
   
.. warning::

   A ``while`` loop may be written so the continuation condition is
   *always* true, and the loop *never* stops by itself.  
   This is an *infinite loop*.
   In practice, in many operating environments, particularly
   where you are geting input from the user, 
   you can abort the execution of a program in 
   an infinite loop by entering 
   :kbd:`Ctrl-C`.

In particular you get an infinite loop 
if you fail to get new input from the user at the
end of the loop.  The condition uses the bad
original choice forever.  Here is the mistaken version, 
from example  ``PromptUserLoop2Bad.cs``:

.. literalinclude:: ../examples/PromptUserLoop2Bad.cs
   :start-after: chunk
   :end-before: chunk

You can run it.  Remember :kbd:`Ctrl-C` !
There are two tests in ``Main``.  
If you give a legal answer immediately in the first test, 
it works fine (never getting into the loop body).  If you 
give a bad input in the second test, you see that you can never fix it!
Remember :kbd:`Ctrl-C` !

A more extreme abort is to close the entire console/terminal window 
running the program.

.. index::
   double: exercise; Agree
   
.. _agree-function-exercise:

Agree Function Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~

Save example ``PrompUserLoop4Stub.cs`` as ``PromptUserLoop4.cs``.

Yes-no (true/false) questions are common.
How might you write an input utility function ``Agree``? 
You can speed things
up by considering only the first letter of responses.
If it is important that the user enter correctly, you should
consider three categories of answer:  ones accepted as true, 
ones accepted as false, and ambiguous ones.  
You need to allow for 
the possibility that the user keeps
giving ambiguous answers....  


.. _interactive-sumEx:
	
Interactive Sum Exercise
~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``SumAll.cs`` that prompts the user to enter
numbers, one per line, ending with a line containing 0, and keep a
running sum of the numbers. Only print out the sum after all the
numbers are entered (at least in your *final* version).


.. index;
   double: exercise; InputWhole
   
.. _safe-whole-number-input:

Safe Whole Number Input Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Save example :file:`TestInputWholeStub.cs` as
``TestInputWhole.cs`` that tests
a function ``InputWhole``, as described below.

There is an issue with reading in numbers with the InputInt function.
If you make a typo and enter something that cannot be converted from a
string to the right kind of number, a naive program will bomb.
This is avoidable if you test the string and repeat if the string is illegal.
Places where more complicated tests for illegality are needed are
considered in :ref:`safe-input-number`.  For now we just consider
reading in whole numbers (integers greater than or equal to 0).  
Note that such
a number is written as just a sequence of digits.   
Follow the interactive model of InputIntInRange, looping until
the user enters something that is legal: in this case, all digits.

	
.. later  some after arrays, some just more work for exercises (strange func)

	Now that we have you cautious, let us try the program
	but be careful:  though we want a new *value* for ``number``,
	it can only geteasiest to think We keep on
	going if the most recent input is bad.  We print the error message only
	if the input is bad.  
	
	
	out iThe earlier examples of while loops were chosen for their
	simplicity. Obviously they could have been rewritten with range
	function calls. Now lets try a more interesting example. Suppose
	you want to let a user enter a sequence of lines of text, and want
	to remember each line in a list. This could easily be done with a
	simple repeat loop if you knew the number of lines to enter. For
	example, in ``readLines0.cs``, the user is prompted for the exact
	number of lines to be entered:
	
	.. literalinclude:: ../examples/readLines0.cs
	   :lines: 3-
	
	The user may want to enter a bunch of lines and not count them all
	ahead of time. This means the number of repetitions would not be
	known ahead of time. A ``while`` loop is appropriate here. There is
	still the question of how to test whether the user wants to
	continue. An obvious but verbose way to do this is to ask before
	every line if the user wants to continue, as shown below and in the
	example file ``readLines1.cs``. Read it and then run it:
	
	.. literalinclude:: ../examples/readLines1.cs
	   :lines: 3-
	
	See the *two* statements setting ``testAnswer``:  
	one before the ``while`` loop and one at the bottom of the loop body.
	
	.. note::
	   The data must be initialized *before* the loop, in order for the
	   first test of the while condition to work. Also the test must work
	   when you loop back from the end of the loop body. This means the
	   data for the test must also be set up a second time, *in* the loop
	   body.  It is easy to forget the second time!
	
	The ``readLines1.cs`` code works, but it may be more annoying than
	counting ahead! Two lines must be entered for every one you
	actually want! A practical alternative is to use a *sentinel*: a
	piece of data that would *not* make sense in the regular sequence,
	and which is used to indicate the *end* of the input. You could
	agree to use the line ``DONE!`` Even simpler: if you assume all the
	real lines of data will actually have some text on them, use an
	*empty* line as a sentinel. (If you think about it, the C#
	Shell uses this approach when you enter a statement with an
	indented body.) This way you only need to enter one extra (very
	simple) line, no matter how many lines of real data you have.
	
	What should the while condition be now? Since the sentinel is an
	empty line, you might think ``line == ''``, but that is the
	*termination* condition, not the *continuation* condition: You need
	the *opposite* condition. To negate a condition in C#, you may
	use ``not``, like in English,  ::
	
		not line == ''
	
	Of course in this situation there is a shorter way, ::
	
		line != ''
		
	Run the example program ``readLines2.cs``, shown below:
	
	.. literalinclude:: ../examples/readLines2.cs
	   :lines: 3-
	
	Again the data for the test in the while loop heading must be
	initialized before the first time the ``while`` statement is
	executed and the test data must *also* be made ready inside the
	loop for the test after the body has executed. Hence you see the
	statements setting the variable ``line`` both before the loop and
	at the end of the loop body. It is easy to forget the second place
	inside the loop!
	
	*After* reading the rest of this paragraph,
	comment the last line of the loop out, and run it again:
	It will never stop! The
	variable ``line`` will forever have the initial value you gave it!
	You actually can stop the program by entering :kbd:`Ctrl-C`. That means
	hold the :kbd:`Ctrl` key and press :kbd:`c`.
	
	.. note::
	   As you finish coding a ``while`` loop, it is good practice to
	   always double-check: Did I make a change to the variables, *inside*
	   the loop, that will eventually make the loop condition ``False``?
	
	The earliest ``while`` loop examples had numerical tests and the code
	to get ready for the next loop just incremented a numerical variable
	by a fixed amount.  Those were simple examples but ``while`` loops
	are much more general!  In the interactive loop we have seen a continuation
	condition with a string test, and getting ready for the next time through
	the loop involves input from the user.
	
	Some of the exercises that follow involve interactive while loops.
	Others were delayed until here just because they have a wider variety of
	continuation condition tests and ways to prepare for the next time through
	the loop.  What is *consistent* is the general steps to think of and
	questions to ask yourself.  They keep on applying!  Keep these in mind!
	
	  * the need to see whether there *is* a kind of
		repetition, even without a fixed collection of values to work through
	
	  * to think from the specific situation and figure out the
		continuation condition that makes sense for your loop
	
	  * to think what specific processing or results you want each time through
		the loop, using the *same* code
	
	  * to figure out what supporting code you need to make you ready for the
		next time through the loop:  how to make the *same* results code
		have *new* data values to process each time through, and eventually reach
		a stopping point.
		
	
	
	
	
	
