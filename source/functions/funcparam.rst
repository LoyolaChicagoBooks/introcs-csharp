
.. index:: function; parameter
   parameter

.. _Function-Parameters:

Function Parameters
==============================

As a young child, you probably heard Happy Birthday sung to a
couple of people, and then you could sing to a new person, say
Maria, without needing to hear the whole special version with
Maria's name in it word for word. You had the power of
*abstraction*. With examples like the versions for Emily and Andre,
you could figure out what change to make it so the song could be
sung to Maria!

Unfortunately, C# is not that smart. It needs explicit rules.
If you needed to explain *explicitly* to someone how Happy Birthday
worked in general, rather than just by example, you might say
something like this:

First you have to be *given* a person's name. Then you sing the
song with the person's name inserted at the end of the third line.

C# works something like that, but with its own syntax. The term
"person's name" serves as a stand-in for the actual data that
will be used, "Emily", "Andre", or "Maria". This is just like
the association with a variable name in C#. "person's name"
is not a legal C# identifier, so we will use just ``person`` as
this stand-in.  It will be a variable in the program, 
so it needs a type in C#.  The names are strings, 
so the type of ``person`` is ``string``.

In between the parentheses of the function definition heading, we insert the variable
name ``person``, preceded  by its type, ``string``.
Then in the body of the definition
of the function, ``person`` is used in place of the real data for any
specific person's name. Read and then run example program
:repsrc:`birthday4/birthday4.cs`:

.. literalinclude:: ../../source/examples/birthday4/birthday4.cs
   :linenos:

In the definition heading for ``HappyBirthday``, ``person`` is
referred to as a *parameter*, or a *formal parameter*. This
variable name is a *placeholder* for the real name of the person
being sung to.  In the definition we give instructions for singing
Happy Birthday *without* knowing the exact name of the person who might be sung to.

``Main`` now has two calls to the same function, 
but between the parentheses, where there was the **placeholder** ``person`` 
in the definition, now we have the **actual people** being sung to.
The value between the parentheses here in the function call
is referred to as an *argument* or *actual parameter* of the
function call. The argument supplies the actual data to be used in
the function execution. When the call is made, C# does this by
associating the **formal** parameter name ``person`` with the **actual**
parameter data, as in an assignment statement. In the first call,
this actual data is ``"Emily"``. We say the actual parameter value
is *passed* to the function for execution.

The execution in greater detail:

#. Lines 13: Execution starts in Main.  

#. Line 15: Call to ``HappyBirthday``, with actual parameter
   ``"Emily"``.

#. Line 5: ``"Emily"`` is passed to the function, so
   ``person = "Emily"``.

#. Lines 7-10: The song is printed, with ``"Emily"`` used as the
   value of ``person`` in line 9: printing ::
       
       Happy Birthday, dear Emily.

#. End of line 15 after returning from the function call

#. Line 16: Call to ``HappyBirthday``, this time with actual
   parameter ``"Andre"``

#. Line 5: ``"Andre"`` is passed to the function, so
   ``person = "Andre"``.

#. Lines 7-10: The song is printed, with ``"Andre"`` used as the
   value of ``person`` in line 9: printing ::
       
       Happy Birthday, dear Andre.

#. End of line 16 after returning from the function call, 
   and the program is over.

The beauty of this system is that the same function definition can
be used for a call with a different actual parameter variable, and
then have a different effect. The value of the variable person is
used in the third line of ``HappyBirthday``, to put in whatever
actual parameter value was given.

.. index:: abstraction

This is the power of *abstraction*. It is one application of the
most important principal in programming. Rather than have a number
of separately coded parts with only slight variations, see where it
is appropriate to combine them using a function whose parameters
refer to the parts that are different in different situations. Then
the code is written to be simultaneously appropriate for the
separate specific situations, with the substitutions of the right
parameter values.

.. note::

    Be sure you completely understand :repsrc:`birthday4/birthday4.cs`
    and the sequence of execution!  It illustrates extremely
    important ideas that many people miss the first time!  It is
    essential to understand the difference between

    1. *Defining* a function (lines 5-11)
       with the heading including *formal* parameter name and type,
       where the code is merely instructions to be remembered,
       not acted on immediately.

    2. *Calling* a function with an *actual* parameter value to be
       substituted for the formal parameter, 
       (with *no* type included!) and have the function
       code actually *run* when the instruction containing the call
       is run.  Also note that the function can be
       called multiple times with different expressions as the
       actual parameter (line 15 and again in line 16).

We can combine function parameters with user input, and have the
program be able to print Happy Birthday for anyone. Check out the
``Main`` method and run :repsrc:`birthday_who/birthday_who.cs`:

.. literalinclude:: ../../source/examples/birthday_who/birthday_who.cs
   :linenos:

This last version illustrates several important ideas:

#. There are more than one way to get information into a function:
   
   #. Have a value passed in through a parameter (from line 18 to line 5).

   #. Prompt the user, and obtain data from the keyboard (lines 16-17).

#. It is a good idea to separate the *internal* processing of data
   from the *external* input from the user by the use of distinct
   functions. Here the user interaction is in ``Main``, and the data
   is manipulated in ``HappyBirthday``.

#. In the first examples of actual parameters, we used literal
   values. In general an actual parameter can be an expression. The
   expression is evaluated before it is passed in the function call.
   One of the simplest expressions is a plain variable name, which is
   evaluated by replacing it with its associated value. 
   Note this important situation in the example:  
   We have the
   value of ``userName`` in ``Main`` becoming the value of ``person``
   in ``HappyBirthday``.  We used different names to illustrate the
   important fact:  
   
   ..  note::
       Only the *value* of the actual parameter is passed, not any
       variable name, so there is *no need* to have a match between a variable name 
       used in
       an actual parameter and the formal parameter name.

.. comment get this idea in somewhere else?

	.. index::
	   traceback; error in execution
	
	Now that we have nested function calls, it is worth looking further
	at tracebacks from execution errors.  If we add a line to ``Main`` in
	:repsrc:`birthday4/birthday4.cs`::
		
		HappyBirthday(2)
	
	as in example file :repsrc:`birthday_bad/birthday_bad.cs`, and then run it, you get
	something close to:
	
	  | Traceback (most recent call last):
	  | TypeError: Can't convert 'int' object to str implicitly
	
	Your file folder is probably different than /hands-on/examples.
	The last three lines are most important, giving the line number
	where the error was detected, the text of the line in question,
	and a description of what problem was found.  Often that is all
	you need to look at, but this example illustrates that
	the *genesis* of the problem may be far away from the line
	where the error was *detected*.  
	Going further up the traceback, you find the sequence of function
	calls that led to the line where the error was detected.
	You can see that in ``main`` we call ``HappyBirthday``
	with the bad parameter, 2.

.. _BirthdayFunctionEx:

Birthday Function Exercise
---------------------------

Make your own further change to :repsrc:`birthday4/birthday4.cs` and save it in your
own project as 
``birthday_many.cs``: Add a function call
(but *not* another function *definition*), so Maria gets a verse, in
addition to Emily and Andre. Also print a blank line between
verses. (There are two ways to handle the blank lines: 
You may *either* do this by adding a print line to the
function definition, *or* by adding a print line between all calls to
the function.  Recall that if you give Console.WriteLine an empty
parameter list, it just goes to the next line.)
