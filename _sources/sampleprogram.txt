
.. index:: introduction

.. _sample-program:
    
A Sample C# Program
======================================

As a start let us consider a ridiculously simple problem and a program to solve it.
Suppose you paint the walls of rooms in one color and the ceiling in another, and
you want to calculate the size of the areas to cover with paint.  
For simplicity ignore doors.
What data do you need to start with?  Clearly the dimensions of the room.
Suppose we consider modern houses where the height of the room is predictably 8 feet, 
so the new starting data is just the length and width of the room.

You need to

#. Obtain the length and width from the user.
#. Calculate the wall area and ceiling area.
#. Let the user know the results.

This is a very simple programming pattern:  data in, calculate results, 
output results.  In this case the calculations in the middle are very easy.

In the examples that you should have downloaded is a first simple program,
:repsrc:`painting/painting.cs`.

Here is what it looks like when it runs, with the user typing the 20.5 and the 10:

.. code-block:: none

    Calculation of Room Paint Requirements
    Enter room length: 20.5
    Enter room width: 10
    The wall area is 488 square feet.
    The ceiling area is 205 square feet.
    
This is not very exciting, but it is a simple place to start seeing
basic program features.  We will refer back to this sample run while
discussing the program.
Here is the text of the program:

.. literalinclude:: ../source/examples/painting/painting.cs
   :linenos:

This section gives an overview of a working
program, even if all the explanations do not make total sense yet.  
This is a first introduction of concepts and syntax that gets fully explained
in further sections.

Do not worry if you not totally understand the
explanations! Try to get the gist now and the details later. 

The different colors are used in modern program editors to
emphasize the different uses of the parts of the program.
    
We give a line by line explanation:

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 1

The C# environment supplies an enormous number of parts that you can
reference.  
Nobody is familiar with all of them.  
If you had to make sure you always used names that did not conflict with other
names supplied, you would be in trouble.  To avoid this C# has *namespaces*.  The 
same name can be used in different namespaces without conflict.  The central
standard namespace is ``System``.  We will always include this first line,
``using System;``.

Lines 2, 10, 18, and 21 are blank.  
This is merely for the human reader to separate sections visually.  The computer
ignores them.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 3-4

A basic unit in C# is a *class*.  Our code sits inside a class.  Each class
has a *heading* with ``class`` followed by a name.  
This class is ``Painting``.  After the heading comes
a *body* delimited by braces.  The opening brace ``{`` in line 4, is matched
by the closing brace ``}`` on the last line of the program.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 5-6

A class is broken up with chunks called *functions* or *methods*.  Each has
a *heading*.  C# allows the currently popular programming paradigm called 
*object-oriented programming*, where classes generally 
describe new kinds of objects.  
This is useful in complicated situations, 
but we start more simply with the older *procedural* programming.  
Unfortunately for now,
the more common situation is with objects, so a function that does *not*
involve such new objects must be marked specially as ``static``.

Functions can be like in math, where they produce a function value
for later use.  In C# they can
also just *do* something (like write to the screen), and not produce a value
for later use in the program.  
To show that
no function value is produced, the word ``void`` is used.

Every program must start running somewhere.  In C# that is at a function with
name ``Main``.  So our program starts running here.  
This syntax for this function needs to start just like here, with 
``static void Main``.

Even though this is not a mathematical function producing a value, a function in
C# must be followed by parentheses ``( )``.

After the function heading comes a *body*.  Like with a class, a function body
is delimited by braces.  The opening brace here is matched by the closing 
brace on the second to last line of the program.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 7
   
A program works with data of many different possible types.  One type
is ``double``.  A ``double`` can hold an approximate numerical value, 
including a possible fractional part.

To refer to data in a program we use names called *variables*.  
This line says that
``width``, ``length``, ``wallArea``, and ``ceilingArea`` are all 
the names for variables that can hold a ``double`` value.  We will assign
values to these variables later.

This line is a *declaration* statement.
Most statements in C#, like this one, end with ``;`` - a semicolon.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 8

This is another declaration.  This time the type of the variables is
``string``, which means a sequence of characters, like a line you
might type at the keyboard.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 9

Here is another declaration for a ``double``, looking slightly different.
In this case we follow a convention, using all capital letters, to
suggest that the value of ``HEIGHT`` will be constant (unchanging), 
and we assign its value at the same time with ``= 8``.  This naming of
constants is not
strictly necessary, but it makes the program's intention easier to follow.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 11

``Console`` refers to the terminal or console window where text output 
appears for the program.  One of the things you can do with the Console
is ``WriteLine``, to write a line.  The period between ``Console`` and
``WriteLine`` indicates ``WriteLine`` is a named part of the ``Console``.
This ``WriteLine`` is a function.  Like in math, it can have
a parameter in parentheses.  While you are used to a parameter for a
function in math being a number, functions in C# are much more general.
A function can be defined with any type of parameters.  
Here the parameter is a string, 
``"Calculation of Room Paint Requirements"``,
delimited by the quotes at either end.  Notice that the contents
of this string appear at the start of the screen output 
displayed for this program.  The program did **write** this **line**.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 12

This statement is similar to the last one, except that it uses ``Write``
rather than ``WriteLine``.  The ``WriteLine`` function wrote a whole line -
see that the output next *after* the ``WriteLine`` statement
started on the next line.
Here ``Write`` does not advance the printing position to the next line
after it.

This statement serves as a *prompt*: letting the user know that information is being 
requested (a room length).

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 13

Here is where the program takes in the information requested from the user.
Its action is actually right to left:  ``Console.ReadLine`` is another
function available with the ``Console``, that reads a line typed in by the
user on the keyboard.  Here in the sample run, 
on the same line as the prompt string 
(because of the previous ``Write``, not ``WriteLine``),
the user types
``20.5`` and the Enter or Return key.

In the sample run, 
the value produced by the ``Console.ReadLine`` function is these four 
characters ``20.5``.

Recall that ``lengthString`` was declared as a variable to hold a string.
The  ``=`` indicates an *assignment statement*.
It is an *assignment* of the value on the right of the equal sign 
to be the current value of the variable on the left
of the equal sign.  In the sample run, this would mean that the variable
``lengthString`` would end up holding the value ``"20.5"``.  Though these
characters happen  to look like a number, 
any sequence of characters can be typed.
The ``Console.ReadLine()`` function produces this sequence of characters
as a *string* type.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 14

Of course we want to interpret the user's input as a number in order to do
our arithmetic.  This line makes the conversion between the types.

It is another assignment statement (with the ``=``).  We are assigning to 
the variable ``length``, which we declared as a ``double``.  
The value assigned comes from the 
expression on the right of the ``=``, ``double.Parse(lengthString)``.
The function ``double.Parse``, is just the one we want, it takes a string parameter
``lengthString`` containing the string from the user input, 
and the value produced is the corresponding ``double`` number.  In
the sample run that assigns to ``length`` the value 20.5.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 15-17

These lines are analogous to the previous three lines:  
give a prompt for the user;
get the user response; convert it to a ``double``, and assign to a variable 
(``width`` in this case).  In the sample run the variable ``width`` is assigned
the value 10.

.. index:: comment
   // comment

At this point we have all the data we need from the user.  The next part is
the brief calculations of results:

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 19-20

At the end of the first line is a *comment*.  It starts with ``//`` and ends
at the end of the same line.  It is ignored by the compiler.  It is there for humans,
hopefully to add something that helps understanding of the program.
  
We have two assignment statements.  The values to assign are given by arithmetic
expressions on the right side of the equal signs.  It looks pretty much like
regular math, except in math class you may be used to only having one letter names
for variables, unlike ``length``, ``width``, and ``HEIGHT``.

The tradeoff for allowing multiple character names is that multiplication must 
have an explicit operation symbol.  
The symbol used for multiplication in C# is ``*`` an asterisk.  The ``+``
and parentheses serve their normal mathematical purpose.  In the sample run,
the value of ``2 * (length + width) * HEIGHT`` is 

.. code-block:: none

   2 * (20.5 + 10) * 8
   
which simplifies to 488.

With the sample run, ``ceilingArea`` would get the value 20.5 * 10, or 205.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 22-23

This is a single statement.  Line endings act just like a space in C#.
The statement ends with the semicolon on the second line.

Again ``Console.WriteLine`` will print something to the computer console.  This 
time the string printed is more complicated:  It starts off with
the literal string ``"The wall area is "``, but then we want to print out
the calculated result.  The ``+ wallArea`` allows that.  The ``+`` sign
after the string is not a mathematical operator here.  Coming after a string,
it has a special string meaning:  It converts the next part
``wallArea`` to be a string.  In the sample run that would be converting the
``double`` value 488 to be the string ``"488"``.  The plus sign then "adds" the strings 
in a manner appropriate for strings, *concatenating* them.  That means joining
them together, end to end.  

The ``+ " square feet."`` then tacks on the last part to the string.  
In the sample output you see what is printed:

.. code-block:: none

     The wall area is 488 square feet.

sandwiching the value taken from the variable ``wallArea`` between
two literal string, given in quotes.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 24-25
 
This statement behave like the previous one, except with different
quoted strings and the value of a different variable.  See the sample output.

.. literalinclude:: ../source/examples/painting/painting.cs
   :lines: 26-27
 
Finally we have the matching closing braces marking the end of the body of the
``Main`` function and the end of the body of the ``Painting`` class.

Of course the display would look different if the user entered different data.
Here is what is displayed when the user enters length 15 and width 6.5:

..  code-block:: none

    Calculation of Room Paint Requirements
    Enter room length: 15 
    Enter room width: 6.5
    The wall area is 344 square feet.
    The ceiling area is 97.5 square feet.

.. index:: whitespace

The blank space in the program was there to aid human understanding.  
In a C# program *whitespace* is any consecutive combination of spaces, 
newlines, and tabs.  C# treats any amount of whitespace
just the same as a single space, except inside quoted strings,
where every character is important.  

Also the compiler does not require whitespace around special symbols
like ``{};().=*+,``.  Hence  
the :repsrc:`painting/painting.cs` program above would be just as well translated 
by the compiler if it were written as:

.. code-block:: none

    using System;class Painting{static void Main(){double width,length
    ,wallArea,ceilingArea;string widthString,lengthString;double HEIGHT 
    =8;Console.WriteLine("Calculation of Room Paint Requirements");Console.
    Write("Enter room length: ");lengthString=Console.ReadLine();length= 
    double.Parse(lengthString);Console.Write("Enter room width: ");
    widthString=Console.ReadLine();width=double.Parse(widthString);wallArea 
    =2*(length+width)*HEIGHT;ceilingArea=length*width;Console.WriteLine(
            "The wall area is "                  +                 wallArea
    +" square feet.");Console.WriteLine
          ("The ceiling area is "
                   +ceilingArea+
    " square feet.");}}

Since human understanding is very important, we will emphasize good 
whitespace conventions, and expect you to use them.

Next we give you an even simpler program to run in the lab.  After
that we return to how you can get the painting program to run on your computer.
