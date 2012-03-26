.. _Multiple-Function-Definitions:

Multiple Function Definitions
==============================

Here is example program ``birthday3.cs`` where we add a function
``happyBirthdayAndre``, and call them both. Guess what happens, and
then load and try it:

.. literalinclude:: ../examples/birthday3.cs

Again, definitions are remembered and execution starts in ``Main``.  
The order in which the function definitions are given does not matter
to C#.  It is a human choice.  For variety I show ``Main`` first.  This 
means a human reading in order gets an overview of what is happening 
by looking at Main, but does not know the details until reading the 
definitions of the birthday functions.

Detailed order of execution:

#. Line 5: Start on ``Main``

#. Line 7. This location is remembered as execution jumps to
   ``happyBirthdayEmily``

#. Lines 11-17 are executed and Emily is sung to.

#. Return to the end of Line 7: Back from ``happyBirthdayEmily``
   function call

#. Line 8: Now ``happyBirthdayAndre`` is called as this location is
   remembered.

#. Lines 19-25: Sing to Andre

#. Return to the end of line 8: Back from ``happyBirthdayAndre``
   function call, done with ``Main``; 
   at the end of the program


The calls to the birthday functions
*happen* to be in the same order as their definitions, but that is
arbitrary. If the two lines of the body of ``Main`` were swapped, 
the order of
operations would change. 

Functions that you write can also call other functions you write.
In this case Main calls each of the birthday functions.

Poem Function Exercise
-------------------------

Write a program, :file:`poem.cs`, that defines a function that
prints a *short* poem or song verse. Give a meaningful name to the
function. Have the program call the function three times,
so the poem or verse is repeated three times.

	
