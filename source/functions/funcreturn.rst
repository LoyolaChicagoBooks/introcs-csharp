
.. index:: function; return  
   return 
   execution sequence for function

.. _Returned-Function-Values:

Returned Function Values
========================

..
	:math:`$F(x)=x^{2}$`, then it follows that
	:math:`$F(3)$` is :math:`$3^{2}=9$`, and :math:`$F(3)+F(4)$` is
	:math:`$3^{2}+4^{2}=25$`


You probably have used mathematical functions in algebra class, but
they all had calculated values associated with them. For instance
if you defined 

   F(x)=x\ :sup:`2`

then it follows that F(3) is 3\ :sup:`2` = 9, and F(3)+F(4) is
3\ :sup:`2` + 4\ :sup:`2` = 9 + 16 = 25.

Function calls in expressions get
replaced during evaluation by the value of the function.

The corresponding definition and examples in C# would be the
following, taken from example program :file:`return1.cs`. *Read*
*and run*:

.. literalinclude:: ../../source/examples/return1/return1.cs

The new C# syntax is the *return statement*, with the word
``return`` followed by an expression. Functions that return values
can be used in expressions, just like in math class. When an
expression with a function call is evaluated, the function call is
effectively replaced temporarily by its returned value. Inside the
C# function, the value to be returned is given by the
expression in the ``return`` statement.

Since the function returns data, and all data in C# is typed, 
there must be a type given for the value returned.  Note that the 
function heading does not start with ``static void``.  
In place of ``void`` is ``int``.  The ``void`` in earlier function headings
meant nothing was returned.  The ``int`` here means that a value *is*
returned and its type is ``int``.

After the function ``F``
finishes executing from inside ::

	Console.WriteLine(F(3));

it is as if the statement temporarily became ::

	Console.WriteLine(9);

and similarly when executing ::

	Console.WriteLine(F(3) + F(4)); 

the interpreter first evaluates F(3) and effectively replaces the
call by the returned result, 9, as if the statement temporarily
became ::

	Console.WriteLine(9 + F(4));


and then the interpreter evaluates F(4) and effectively replaces
the call by the returned result, 16, as if the statement
temporarily became ::

	Console.WriteLine(9 + 16);

resulting finally in 25 being calculated and printed.

C# functions can return any type of data, not just numbers, and
there can be any number of statements executed before the return
statement. Read, follow, and run the example program
:file:`return2.cs`:

.. literalinclude:: ../../source/examples/return2/return2.cs
   :linenos:

Many have a hard time following the flow of execution with functions.
Even more is involved when there are return values.  
Make sure you completely follow the details of the execution:

#. Lines 12: Start at Main

#. Line 14: call the function, remembering where to return

#. Line 5: pass the parameters: ``firstName = "Benjamin"``;
   ``lastName = "Franklin"``

#. Line 7: Assign the variable ``separator`` the value ``", "``

#. Line 8: Assign the variable ``result`` the value of 
   ``lastName + separator + firstName`` which is  
   ``"Franklin" + ", " + "Benjamin"``, which evaluates to
   ``"Franklin, Benjamin"``

#. Line 9: Return ``"Franklin, Benjamin"``

#. Line 14: Use the value returned from the function call so the line
   effectively becomes  ``Console.WriteLine("Franklin, Benjamin");``, 
   so print it.

#. Line 15: call the function with the new actual parameters,
   remembering where to return

#. Line 5: pass the parameters: ``firstName = "Andrew"``;
   ``lastName = "Harrington"``

#. Lines 7-9: ... calculate and return ``"Harrington, Andrew"``

#. Line 15: Use the value returned by the function and print
   ``"Harrington, Andrew"``

Compare :repsrc:`return2/return2.cs` and :repsrc:`addition1/addition1.cs`, 
from the previous
section. Both use functions. Both print, but where the printing *is
done* differs. The function ``SumProblem`` prints directly inside
the function and returns nothing. On the other hand
``LastFirst`` does not print anything but returns a string. The
caller gets to decide what to do with the returned string, and above it is
printed in ``Main``.

.. index:: example; addition2.cs
   addition2.cs example
   
In general functions should do a single thing.
You can easily combine a sequence of functions, and you have more
flexibility in the combinations
if each does just one unified thing.  The function
SumProblem in :repsrc:`addition1/addition1.cs` does two thing:  
It creates a sentence,
and prints it.  If that is all you have, you are out of luck if you want
to do something different with the sentence string.  A better approach is
to have a function that just creates the sentence, and returns it for
whatever further use you want.  After returning that value,
printing is one possibility, done in
:repsrc:`addition2/addition2.cs`:

.. literalinclude:: ../../source/examples/addition2/addition2.cs

This example constructs the sentence using the string ``+`` operator.
Generating a string with substitutions using a format string 
in ``Console.Write`` is neater, but 
we are forced to directly print the string,
and not remember it for later arbitrary use.  

.. index:: string; Format
   Format method for string

.. _string-format:
   
It is common to want to construct and immediately print a string,
so having ``Console.Write`` is definitely handy when we want it.,
However it is an example of combining two separate steps!  Sometimes
(like here) we just want to have the resulting string, and do something else
with it.  We introduce 
the C# library function  ``string.Format``, which does just what we want:  
The parameters
have the same form as for ``Console.Write``, but the formatted string is
*returned*.

Here is a revised version of the function ``SumProblemString``, 
from example :repsrc:`addition2a/addition2a.cs`:

.. literalinclude:: ../../source/examples/addition2a/addition2a.cs
   :start-after: chunk
   :end-before: chunk
   :dedent: 3

The only caveat with ``string.Format`` is that
there is *no* special function corresponding to ``Console.WriteLine``,
with an automatic terminating newline.
You can generate a newline with string.Format:  Remember the
escape code ``"\n"``.  Put it at the end to go on to a new line.


**In class recommendation**:  Improve example :repsrc:`painting/painting.cs`
with a function used for repeated similar operations.  
Copy it to a file :file:`painting_input.cs` in your
own project and modify it.

.. _InterviewStringEx:
	
Interview String Return Exercise/Example
------------------------------------------

Write a program by that accomplishes the same thing as
:ref:`InterviewProblem`, but introduce a function 
``InterviewSentence`` that takes name
and time strings as parameters and returns the interview sentence string.
For practice use ``string.Format`` in the function.  
With this setup you can manage input from the user and output to the
screen entirely in ``Main``, while using ``InterviewSentence`` to generate
the sentence that you want to *later* print. 

(Here we are having you work on getting used to 
function syntax while keeping the
body of your new function very simple.  Combining that with longer, more
realistic function bodies is coming!)

If you want a further example on this idea of returning 
something first and then using the result, 
or if you want to compare your work to ours,
see our solution, :repsrc:`interview2/interview2.cs`.
	
.. _QuotientStringEx:
	
Quotient String Return Exercise
---------------------------------

Create :file:`quotient_return.cs` by modifying :file:`quotient_prob.cs` in
:ref:`QuotientFunctionEx` so that the program accomplishes the same
thing, but everywhere: 

* Change the QuotientProblem function into one
  called ``QuotientString`` that merely *returns* the string rather
  than printing the string directly. 
* Have ``Main`` print
  the result of each call to the ``QuotientString`` function.

Use ``string.Format`` to create the sentence that you return.