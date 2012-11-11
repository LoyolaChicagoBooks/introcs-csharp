.. index::
   single: labs; division sentences

.. _lab-division:

Lab: Division Sentences
=======================

Overview
--------

In this lab, we're going to begin to look at what makes computers *do
their thing* so to speak. 

It is rather insightful to look at how Wikipedia summarizes the
computer:

    A computer is a programmable machine designed to sequentially and
    automatically carry out a sequence of arithmetic or logical
    operations. The particular sequence of operations can be changed
    readily, allowing the computer to solve more than one kind of
    problem.

In other words, a computer is a calculator--and much
more. Furthermore, the definition of a computer goes on to include
access to storage and peripherals, such as consoles (graphical displays),
printers, and the network. We already got a glimpse of this access
when we explored ``Console.WriteLine`` in the first lab exercise.

So in this lab, we're going to explore the use of C# as a
calculator. We're going to begin by looking at the **csharp** command
as opposed to the compiler (**gmcs** that we used in the first
lab). Then we will take what we've learned in this session and use it
to write a full program.

This is a large enough program that it may be useful to have the
editor be knowledgeable about C# syntax and formatting conventions.
If you are using jEdit, see the :ref:`jedit` appendix for an overview and
particularly to set it up neatly for C#.

Also look at the appendix :ref:`nant`, through the section on Convenience Scripts.
When you go to the command line, this should save you some typing 
for compiling and running.

Requirements
------------

We want to develop a program that can do the following:

- Prompt the user for input of two integers, which we will call
  *numerator* and *denominator*. For clarity, we are only looking at
  integers, because this assignment is about rational numbers. A
  rational number can always be expressed as a quotient of two integers.

- Calculate the floating point division result (e.g. 10/4 = 2.5).

- Calculate the quotient and the remainder (e.g. 10/4 = 2 with a
  remainder of 2 = 2 2/4).

Your final program should work as in this sample run, and use the same format:

.. code-block:: none

   Please enter the numerator? 14
   Please enter the denominator? 4
   Integer division result = 3 with a remainder 2
   Floating point division result = 3.5
   Result as a mixed fraction = 3 2/4

For this lab the example format ``3 2/4`` is sufficient.
It would look better as ``3 1/2``, but a general 
efficient way to reduce fractions to
lowest terms is not covered until the section on the algorithm :ref:`gcd`.  

So let's get this party started by firing up the **csharp**
command, as introduced in :ref:`csharp` and continued later with
:ref:`more csharp <more-csharp>`.  We can illustrate some of the ideas
for this lab:

.. code-block:: none

    csharp> Console.WriteLine("Please enter the numerator?");
    Please enter the numerator?
    csharp> string input = Console.ReadLine();
    25
    csharp> int numerator = int.Parse(input);
    csharp> Console.WriteLine(numerator);
    25

Now let's practice using the C# operators of :ref:`Division-and-Remainders`::

    csharp> int quotient = numerator / denominator;
    csharp> Console.WriteLine(quotient);
    3
    csharp> int remainder = numerator % denominator;
    csharp> Console.WriteLine(remainder);
    2
    csharp> Console.WriteLine("{0} / {1} = {2} with a remainder {3}", 
          > numerator, denominator, quotient, remainder);
    14 / 4 = 3 with a remainder 2


In the above, we are also practicing using a :ref:`Format-Strings` 
with ``Console.WriteLine``. 

You may find this example to be helpful to print the output according
to the final lab requirements::

    14 / 4 = 3 2/4

Now let's take a look at how we can get the results as a real number, not
necessarily an integer. Here is a variation on the approach in :ref:`cast`.
We do this by declaring a couple of ``double``  
variables to hold each of the numerator and
denominator integers. Then we will declare a variable to capture the
result of the floating point division operation.  We named each of the
floating-point variables with the number 2 in the name as C# permits
variable names that have numbers and underscores after the first
character (which must be a *letter* or an *underscore*):

.. code-block:: none

    csharp> double numerator2 = numerator;
    csharp> double denominator2 = denominator;
    csharp> double quotient2 = numerator2/denominator2;
    csharp> Console.WriteLine(quotient2);              
    3.5
    csharp> Console.WriteLine("{0} / {1} = {2} remainder {3}", 
          >                   numerator, denominator, quotient, remainder);
    14 / 4 = 3 remainder 2
    csharp> Console.WriteLine("{0} / {1} = {2} approximately", 
          >                   numerator2, denominator2, quotient2);
    14 / 4 = 3.5 approximately

We have shown everything you need to understand to
complete this lab. To help you
get started, we provided this simple *stub* in the example file
:file:`do_the_math_stub.cs`.  Save the stub as 
:file:`do_the_math.cs` and complete it:

.. literalinclude:: ../examples/do_the_math_stub.cs

When you are done editing and saving :file:`do_the_math.cs`, 
in :ref:`work-folder` or in the examples folder we provided,
you need to test it.
In Windows start with the Mono command line, go to the program's folder, and try the
script 

   run.cmd do_the_math

or go to the program's folder in a Mac terminal and run:

   sh run.sh do_the_math
   
If you have errors cycle through editing, saving, and running the script some more. 
