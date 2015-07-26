

.. index:: function; definition

.. _A-First-Function:

A First Function Definition
==============================

If you know it is the birthday of a friend, Emily, you might tell
those gathered with you to sing "Happy Birthday to Emily".

We can make C# display the song. *Read*, and run if you like,
the example program :repsrc:`birthday1/birthday1.cs`:

.. literalinclude:: ../../source/examples/birthday1/birthday1.cs

Here the song is just a part of the ``Main`` method that is in 
every program.  

Note that we are using a function already provided to us, 
``Console.WriteLine``.  We can use it over and over, wherever we like.
We can alter its behavior by including a different parameter.
Now we look further at writing and using your own functions.

If we 
want this song to be just part of a larger program, and be able to refer
to it repeatedly and easily, we might like
to package it separately.
You would probably not repeat the whole song to let others know
what to sing. You would give a request to sing via a descriptive
name like "Happy Birthday to Emily".

In C# we can also give a name like ``HappyBirthdayEmily``, and
associate the name with whole song by using a new
*function definition*, also called a *method*. We will see many variations 
on method definitions.  Later we will see definitions that are
attached to a particular object.
For now the simpler cases do not involve creating a type of object, 
but there is an extra word, ``static``, 
needed to distinguish a function definition 
*not* attached to  on object.    
We will also shortly look at functions more like 
the functions from math class, that produce or *return* a value.  In 
this simple case we will not deal with returning a value.  
This also requires a special word in the heading:  ``void``.  A ``void``
function will just be a shorthand name for something to do, a procedure
to follow, in this case
printing out the Happy Birthday song for Emily.  (Note that 
the ``Main`` method for a program is also ``static void``.  
This *does* your whole program and is not attached to an object.)

*Read* for now:

.. literalinclude:: ../../source/examples/birthday2/birthday2.cs
   :linenos:
       
There are several parts of the syntax for a function definition to
notice:

Line 5: The *heading* starts with ``static void``, the name of the function,
and then parentheses.  

A more general syntax for functions that just *do*
something is

    | ``static void`` **FunctionName**\ ``()``
    | ``{``
    |    statements in the function body...
    | ``}``
       
Recall the conventions in :ref:`Syntax-Template-Typography`.

Lines 6-11: The remaining lines form the function *body*.  They are enclosed
in braces.  By convention the lines inside the braces are indented by a
consistent amount. Three spaces is a common indentation.

The whole definition does just that: *defines* the meaning of the
name ``HappyBirthdayEmily``, but it does not do anything else yet -
for example, the definition itself does not yet make anything be
printed. This is our first example of altering the order of
execution of statements from the normal sequential order. This is
important: the statements in the function *definition* are *not*
executed as C# first passes over the lines.  
The only part of a program that is automatically executed is ``Main``.
Hence ``Main`` better refer to the newly defined function....

Look at the first statement inside Main, line 15::

    HappyBirthdayEmily();

Note that the ``static void`` of the function definition is missing,
but we still have the function name and parentheses. 
When ``Main`` is running, C# goes back and looks up
the definition, and only then, executes the code inside the
function definition. The term for this action is a *function call*
or function *invocation*.  In this simple situation the format is

    *FunctionName*\ ``()``

While the convention for variable identifiers is to start with a lowercase
letter, the convention for function names is to start with a capital letter.
Hence ``HappyBirthdayEmily``, not ``happyBirthdayEmily``.

Can you predict what the program will do?  Note the two function calls
to ``HappyBirthdayEmily``.  To see, load and run :repsrc:`birthday2/birthday2.cs`. 

.. index:: function; execution sequence
   execution sequence; function
   
The *execution* sequence for the program is different from the 
*textual* sequence.  Execution always starts in Main:

#. Line 13: Main is where execution starts, and initially proceeds
   sequentially.

#. Line 15: the function is called while this location is
   remembered.

#. Lines 5-11: Jump!  The code of the function is executed for the first
   time, printing out the song.

#. End of line 15: Back from the function call; continue on.

#. Line 16:  Just to mix things up, print out a "Hip, hip, hooray".

#. Line 17: the function is called again while this location is
   remembered.

#. Lines 5-11: The function is executed again, printing out the song
   again.

#. End of line 17: Back from the function call, but at this point
   there is nothing more in ``Main``, and execution stops.

Functions alter execution order in several ways: by statements not
being executed as the definition is first read, and then when the
function is called during execution, jumping to the function code,
and back at the the end of the function execution.

Understanding the jumping around in the code with function calls is
crucial.  Be sure you follow the sequence detailed above.  In particular,
be sure to distinguish function **definition** from function **call**.

If it also happens to be Andre's birthday, we might define a
function ``HappyBirthdayAndre``, too. Think how to do that before
going on ....
