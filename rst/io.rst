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
typed before the user presses the Enter (Return) key,
form the string *value* of the function.
Syntactically in C#, 
when a function with a value is used, it is an *expression* in the
program, and the 
expression evaluation is the value produced by the function. 
This is the same as in normal use of functions in math.

With any function producing a value,
the value is *lost* unless it is *immediately* used.  
Often this is done by immediately assigning the value to a variable like in ::

    string name;
    name = Console.ReadLine();

or in the shorter ::

    string name = Console.ReadLine();

.. index:: Console; ReadKey
   ReadKey
   
Fine point:  Notice that in most operating systems you can edit and correct your line
before pressing the Return key.  This is handy, 
but it means that the Return key *must* always be pressed to signal the end
of the response.  
Hence a whole line must be read, and there is *no* function ``Console.Read()``.  
Just for completeness we mention that you can read a raw single keystroke immediately
(no editing beforehand).  If you want to explore that later, see  
:repsrc:`test_readkey/test_readkey.cs`. 
     

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
What happens with this code, in :repsrc:`bad_sum/bad_sum.cs`?

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
In :repsrc:`good_sum/good_sum.cs`, we changed the names to emphasize the type
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
You see the fix with the corresponding function that returns a double.

Example Projects and the Source Repository 
--------------------------------------------

We have started to refer to whole programs that we have written.  You will
want to have your own copies to test and modify for related work.

All of our examples are set up in a Xamarin Studio solution in our 
`zip file that you can download <https://bitbucket.org/loyolachicagocs_books/introcs-csharp-examples/get/default.zip>`_.

Unzip default.zip in a place you control.  The ``examples`` subdirectory is
a Xamarin Studio solution.  

There are various way to access our files.  

#. One way is to look at individual files from your download
   under our examples directory.  
#. If you open the examples solution in Xamarin Studio, 
   you can select files from the Solutions pad.
#. In the notes we refer to individual code file names that are hyperlinked.
   They link to the *latest version* in our online source repository.
   You get a display of color-coded web page with numbered lines.  If you
   want to adapt a chunk, you can select it, and copy.
   If you want to copy all of a large file, your editing shortcuts
   for Select All do *not* work:  You get a bunch of extra html.
   An alternative is to click the **Raw** button in the web page 
   to the left above the source code.
   That brings up a plain text page with just the code.  
   You can either download it or select all of it, and you
   *only* get the code.

We have one main convention in naming our projects:  Most projects are
examples of full, functional programs to run.  Others are intended to be
copied by you as *stubs* for your solutions, for you to elaborate.  
These project folders all end with
"_stub", like ``string_manip_stub``.  Even the stubs can be compiled 
immediately, though they may not accomplish anything.

.. _our-md-projects:

Running our Xamarin Studio Examples Solution
-----------------------------------------------

If you are just starting Xamarin Studio, and you have *not* run our solution before:

#.  On the Welcome screen select the button Open Solution or File.
#.  You get anopen-file dialog.  Navigate to our example solution.
    (It must be unzipped already!)
#.  Select :file:`examples/examples.sln`.

The next time you come to the Welcome screen, our examples should be listed in the
Recent Projects, and you can click to open it directly.

Copying and Modifying Our Example Xamarin Studio Projects
----------------------------------------------------------------

We strongly encourage you not to modify our examples in place, if you want
to keep the changes, because we will make additions and modifications to default.zip,
and the easiest thing to do is to unzip the new version on top of the old version,
clobbering any changes that you made to files.

If you do want to alter our code, we suggest you copy it to a project in your
solution ("work", discussed before).

#. Open your solution.
#. Create a new project, maybe with the same name as the one we had.  If it was a
   "_stub" project, remove the "_stub" from your project's name.
#. In the Solution Pad open the menu on the new project, select, Add, and then in the
   further submenu, select Add Files....
#. This brings up an operating system open-file dialog.  Switch folders into our
   example projects.  Select the files you want to copy.
#. A further dialog window pops up, with the choice **Copy** selected.
   Click to approve copy (as opposed to move or link).  
#. Now the desired files should appear in your project.  
   If you intended to copy everything for a project, test by running the project.
   Even our stub projects should compile, though a stub project may not do anything
   when you run it until you add your own code to it.  To make successful incremental
   additions, it is always good to start from something the compiles!

.. _AdditionProblem:

Exercise for Addition
~~~~~~~~~~~~~~~~~~~~~~

Write a version, :file:`add3.cs`, that
prompts the user for three numbers, *not necessarily integers*, 
and lists all three, and their sum, in
similar format to :repsrc:`good_sum/good_sum.cs`.

.. _QuotientProblem:

Exercise for Quotients
~~~~~~~~~~~~~~~~~~~~~~~

Write a program, ``quotient.cs``, that
prompts the user for two integers, and then prints them out in a
sentence with an integer division problem like ::

   The quotient of 14 and 3 is 4 with a remainder of 2

Review :ref:`Division-and-Remainders` if you forget the integer
division or remainder operator.
