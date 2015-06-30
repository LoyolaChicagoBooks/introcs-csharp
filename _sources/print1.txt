
.. index:: 
   double: Console; WriteLine
   

.. _write-to-console:
   
Writing to the Console
======================
   
In interactive use of csharp, you can type an
expression and immediately see the result of its evaluation. This
is fine to test out syntax and maybe do simple calculator
calculations. In a regular C# program run from a file like in
:ref:`sample-program`, 
you must explicitly give instructions to print to a 
console or terminal window.  This will be a window like you see
when running csharp.  

This printing is accomplished through a function with a long name: ``Console.WriteLine``.
Like with math, you can pass a function a value to work on, by placing it in
parentheses after the name of the function.  Unlike in high school algebra classes,
in C# we have many types of data to supply other than numbers.  The simplest
way to use the ``Console.WriteLine`` function is to give it a string.   
We can demonstrate in csharp.  The response is just the line that would
be printed in a regular program:

.. index:: . ; class static member

.. code-block:: none

    csharp> Console.WriteLine("Hello, world!");
    Hello, world!

What is printed to the screen does *not* have the quotes which we needed to
define the literal string ``"Hello, world!"`` inside the program.

``Console`` is a C# class maintained by the system, that
interacts with the terminal or console window where text output 
appears for the program.  A function defined in that class is ``WriteLine``.
To refer to a function like ``WriteLine`` in a different class, you must indicate
the location of the function with the "dot" notation shown:
class name, then ``.``, then the function.  This  
gives the more elaborate name needed in the program.

The string that gets printed can be the result of evaluating an expression, 
for instance concatenating:


.. code-block:: none

    csharp> int total = 5;
    csharp> Console.WriteLine("All together: " + total);
    All together: 5

More elaborate use of ``WriteLine`` is discussed in :ref:`Format-Strings`.

.. index:: Console; Write

The ``Console.WriteLine`` function automatically makes the printing
position advance to the next line, as when you press the Enter or Return key.
A variant, ``Console.Write``, prints the parameter exactly, and nothing else.
The statement-at-a-time approach in csharp is not good for illustrating the 
differences.

Printing is better shown off in a real program....
