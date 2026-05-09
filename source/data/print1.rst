
.. index:: 
   double: Console; WriteLine
   

.. _write-to-console:
   
Writing to the Console
======================
   
In a scratch program, you can print the result of an expression with
``Console.WriteLine``. This works for testing syntax and doing calculator-style
calculations. In a regular C# program run from a file like in
:ref:`sample-program`, 
you must explicitly give instructions to print to a 
console or terminal window.

This printing is accomplished through a function with a long name: ``Console.WriteLine``.
As in math, you can pass a function a value to work on by placing it in
parentheses after the name of the function.  Unlike in high school algebra classes,
in C# we have many types of data to supply other than numbers.  The simplest
way to use the ``Console.WriteLine`` function is to give it a string.   
We can demonstrate the statement and the line it prints:

.. index:: . ; class static member

.. code-block:: csharp

    Console.WriteLine("Hello, world!");

Output:

.. code-block:: none

    Hello, world!

What is printed to the screen does *not* have the quotes which we needed to
define the literal string ``"Hello, world!"`` inside the program.

``Console`` is a C# class maintained by the system that
interacts with the terminal or console window where text output 
appears for the program.  A function defined in that class is ``WriteLine``.
To refer to a function like ``WriteLine`` in a different class, you must indicate
the location of the function with the "dot" notation shown:
class name, then ``.``, then the function.  This  
gives the more elaborate name needed in the program.

The string that gets printed can be the result of evaluating an expression, 
for instance concatenating:


.. code-block:: csharp

    int total = 5;
    Console.WriteLine("All together: " + total);

Output:

.. code-block:: none

    All together: 5

More elaborate use of ``WriteLine`` is discussed in :ref:`Format-Strings`.

.. index:: Console; Write

The ``Console.WriteLine`` function automatically makes the printing
position advance to the next line, as when you press the Enter or Return key.
A variant, ``Console.Write``, prints the parameter exactly, and nothing else.
These differences are easiest to see in a complete program.

Printing is better shown in a real program.
