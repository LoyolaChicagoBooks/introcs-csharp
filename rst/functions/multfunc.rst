.. _Multiple-Function-Definitions:

Multiple Function Definitions
==============================

Here is example program :repsrc:`birthday3/birthday3.cs` where we add a function
``HappyBirthdayAndre``, and call them both. Guess what happens, and
then load and try it:

.. literalinclude:: ../../source/examples/birthday3/birthday3.cs

Again, definitions are remembered and execution starts in ``Main``.  
The order in which the function definitions are given does not matter
to C#.  It is a human choice.  For variety I show ``Main`` first.  This 
means a human reading in order gets an overview of what is happening 
by looking at Main, but does not know the details until reading the 
definitions of the birthday functions.

Detailed order of execution:

#. Line 5: Start on ``Main``

#. Line 7. This location is remembered as execution jumps to
   ``HappyBirthdayEmily``

#. Lines 11-17 are executed and Emily is sung to.

#. Return to the end of Line 7: Back from ``HappyBirthdayEmily``
   function call

#. Line 8: Now ``HappyBirthdayAndre`` is called as this location is
   remembered.

#. Lines 19-25: Sing to Andre

#. Return to the end of line 8: Back from ``HappyBirthdayAndre``
   function call, done with ``Main``; 
   at the end of the program


The calls to the birthday functions
*happen* to be in the same order as their definitions, but that is
arbitrary. If the two lines of the body of ``Main`` were swapped, 
the order of
operations would change, but if the order of the whole function 
definitions were changed,
it would make no difference in execution.

Functions that you write can also call other functions you write.
In this case Main calls each of the birthday functions.

.. index:: compiler error; bad place for heading syntax
   single: { } ; matching
   function; compiler error with heading
    
.. warning::
   A common compiler error is caused by failing to match the braces
   that wrap a function body.  A new function heading can only
   exist outside all other function declarations and inside a class.
   If you have too few or extra ``'}'`` you are likely to find
   a perfectly fine looking function heading with an error,
   for instance, about not
   allowing ``static`` here....  
   Check your earlier lack or excess of braces!

.. index::
   single: ( ) ; matching
   single: [ ] ; matching
   Xamarin Studio; delimiter matching
   
Xamarin Studio, like other modern code editors, can show you
matching delimiters.  If you place your cursor immediately after a delimiter
{ } ( ) [ ], the matching one should become highlighted.

Poem Function Exercise
-------------------------

Write a program, :file:`poem.cs`, that defines a function that
prints a *short* poem or song verse. Give a meaningful name to the
function. Have the program call the function three times,
so the poem or verse is repeated three times.

	
