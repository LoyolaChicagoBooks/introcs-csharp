.. _io:

Combining Input and Output
==========================

.. _read-from-console:
   
Reading from the Keyboard
--------------------------

If you want users to type something at the keyboard, you should let them know first!
The jargon for this is to give them a *prompt*:  Instructions written to the screen,
something like ::

    Console.Write("Enter your name: ");
    
Then the user should respond.
What the user types is automatically shown (*echoed*)
in the terminal or console window.  For a program to 
read what is typed, another function in the ``Console`` class is used:
``Console.ReadLine``.

Here the data for the function comes from a line typed at the keyboard by the user,
so there is no need for a parameter between
the parentheses: ``Console.ReadLine()``.  
The resulting sequence of characters,
typed before the user presses the Enter (Return) key
form the string *value* of the function.
Syntactically in C#, 
when a function with a value is used, it is an *expression* in the
program, and the 
expression evaluation is the value produced by the function.  
An with any function producing a value,
the value is *lost* unless it is immediately used.  
Often this is done by immediately assigning the value to a variable like in ::

    string name;
    name = Console.ReadLine();

or in the shorter ::

    string name = Console.ReadLine();

Fine points:  Notice that in most operating systems you can edit and correct your line
before pressing the Return key.  This is handy, 
but it means that the Return key *must* always be pressed to signal the end.  
Hence a whole line must be read, and there is *no* function ``Console.Read()``.  
     

.. index::
   string; convert to int
   string; convert to double
   double: Parse; int
   double: Parse; double
   
.. _Numbers-and-Digit-Strings:

Numbers and Strings of Digits
-----------------------------

You may well want to have the user supply you with numbers.
There is a complication.  Suppose you want to get numbers and add them.
What happens with this code, in :file:`bad_sum.cs`?

.. literalinclude:: ../source/examples/bad_sum/bad_sum.cs

Here is a sample run:

.. code-block:: none

    Enter an integer: 23
    Enter another integer: 9
    They add up to 239

C# has a type for everything and 
``Console.ReadLine()`` gives you a string.  
Adding strings with ``+`` is not the same as adding numbers!

We must explicitly convert the strings to the proper kind of number.
There are functions to do that:  ``int.Parse`` takes a string parameter
that should be the characters in an ``int``, like "123" or "-25", and 
produces the corresponding ``int`` value, like 123 or -25.
In :file:`good_sum.cs`, we changed the names to emphasize the type
conversions:

.. literalinclude:: ../source/examples/good_sum/good_sum.cs

Notice that the values calculated by ``int.Parse`` for the strings
``xString`` and ``yString`` are immediately remembered in 
assignment statements.  Be careful of the distinction here.
The ``int.Parse`` function does not magically *change*
the variable ``xString`` into an ``int``:  the string ``xString`` is unchanged, 
but the corresponding ``int`` value is calculated, 
and gets assigned to an ``int`` variable, ``x``.  


Note that this would not work if the string represents the wrong kind of number,
but there is an alternative:

.. code-block:: none

    csharp> string s = "34.5";
    csharp> int.Parse(s);
    System.FormatException: Input string was not in the correct format ....
    csharp> double.Parse(s);
    34.5

We omitted the long tail of the error message.  
There is no decimal point in an ``int``.
You see the fix with the corresponding function returning a double.

.. index:: run scripts

Writing and Running Programs
-----------------------------

The language discussions apply no matter what environment you work in.
If you want to go through the learning curve, you could use Visual C# in Windows or 
MonoDevelop on multiple platforms.  Our suggested initial approach is detailed in 
appendices.

Here is an overview of where to look:

- For writing or modifying your own plain text program files we have an appendix
  on one good option, :ref:`jedit`.

- Once you have a program saved, you need to compile and run it.  
  We discuss methods using a terminal or console window.  The basics of getting
  to the right directory were discussed in the first lab, and are elaborated 
  in the appendix with a :ref:`commandline`.
  
- To compile and run, particularly on simple
  single-file programs, you could follow the underlying procedure of the first lab,
  though that is a bit tedious and fails without more explanation in more complicated
  cases.  Instead we suggest seeing the appendix section on :ref:`build-scripts`, in 
  particular going over the use of the **run** scripts.  They make compiling and running
  our example programs a simple 1-step process.  Our organization is to put all the
  single file programs directly in the examples folder, and put each project
  that needs several special files in its own sub-folder.  There are run scripts
  for all these places.
  
- You can store your own work mixed in with ours, as long as you use different names for
  your versions of files, as explained further in the section on run scripts.  
  Many students prefer to have their own work separate, 
  and the appendix section  :ref:`work-folder` shows how to set up your work so you 
  have access to files of ours that you will use, and still be able to still use 
  the convenient run scripts.

.. _AdditionProblem:

Exercise for Addition
~~~~~~~~~~~~~~~~~~~~~~

Write a version, :file:`add3.cs`, that
prompts the user for three numbers, *not necessarily integers*, 
and lists all three, and their sum, in
similar format to :file:`good_sum.cs`.

.. _QuotientProblem:

Exercise for Quotients
~~~~~~~~~~~~~~~~~~~~~~~

Write a program, ``quotient.cs``, that
prompts the user for two integers, and then prints them out in a
sentence with an integer division problem like ::

   The quotient of 14 and 3 is 4 with a remainder of 2

Review :ref:`Division-and-Remainders` if you forget the integer
division or remainder operator.

