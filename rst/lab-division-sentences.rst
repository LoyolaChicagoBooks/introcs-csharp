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

.. highlight:: text

As an example of how this program will ultimately work::

   Please enter the numerator? 14
   Please enter the denominator? 4
   Integer division result = 3 remainder 2
   Floating point division result = 3.5
   Result as a mixed fraction = 3 2/4

For this lab the example format ``3 2/4`` is sufficient.
It would look better as ``3 1/2``, but a general 
efficient way to reduce fractions to
lowest terms is not covered until the section on the algorithm :ref:`gcd`.  
This algorithm has a very simple
formulation that is credited to Euclid, one of the great early
mathematicians (among other accomplishments).

.. index:: csharp

csharp
------

So let's get this party started by firing up the **csharp**
command. Open a terminal (Linux or OS X) or :ref:`mono-command-prompt`
window in Windows, and enter the command ``csharp``.  You should see  ::

    Mono C# Shell, type "help;" for help

    Enter statements below.
    csharp>  

The ``csharp>`` prompt tells you that the C# interpreter has started
and is awaiting input. This allows you to create C# variables and
execute C# statements without having to write a full program. 

You can also use features of the C# programming
library (e.g. the ``Console.WriteLine``  that we practiced with in the
previous lab)::

    csharp> Console.WriteLine("Please enter the numerator?");
    Please enter the numerator?
    csharp> string input = Console.ReadLine();
    25
    csharp> int numerator = int.Parse(input);
    csharp> Console.WriteLine(numerator);
    25

Before we continue with this session, please note that it is ok to
make mistakes. The C# interpreter tends to be forgiving, although
there are some cases where you might find yourself a bit
confused. Here's an example of something that could happen to you in
the course of typing a statement::

    csharp> int denominator = int.Parse(input)
          >

In this example, we accidentally hit the return/enter key before entering the
required semicolon.  The secondary prompt '>' means that you have an incomplete
statement: complete it.

So we can either continue entering the input::
    
    csharp> int denominator = int.Parse(input)
          > ;       


You might get to the semicolon, but make a syntax error, like::

    csharp> int denominator = int.Parse(;
    {interactive}(2,0): error CS1525: Unexpected symbol `;'

This reminds you that there is an error.  What you typed is ignored, and 
you can then *try again* if you like!

A particularly useful feature of the C# interpreter is the
``ShowVars()`` function.  ``ShowVars()`` prints the
list of variables and their values that have been defined in a given
session::

    csharp> ShowVars();
    int denominator = 4
    int numerator = 14
    string input = "14"
    string input2 = "4"

This just happens to be the list of variables/values that are defined
in my session. Yours may vary depending on what variables you typed,
etc.

Now let's practice using the C# operators of :ref:`Division-and-Remainders`::

    csharp> int quotient = numerator / denominator;
    csharp> Console.WriteLine(quotient);
    3
    csharp> int remainder = numerator % denominator;
    csharp> Console.WriteLine(remainder);
    2
    csharp> Console.WriteLine("{0} / {1} = {2} remainder {3}", 
          > numerator, denominator, quotient, remainder);
    14 / 4 = 3 remainder 2


In the above, we are also practicing using a :ref:`Format-Strings` 
with ``Console.WriteLine``. 

You may find this example to be helpful to print the output according
to the requirements::

    14 / 4 = 3 2/4

Now let's take a look at how we can get the results as a floating
point result. To do this, we must declare a couple of float (C#'s
basic real number type) variables to hold each of the numerator and
denominator integers. Then we will declare a variable to capture the
result of the floating point division operation. Because division is
meaningful for all numeric data types, it is exactly the same
operator. C# knows that the operator is being applied to floating
point data in this case, because we declared floating point
variables. (We will show how you can avoid declaring some of these
variables but are erring on the side of clarity.) We named each of the
floating-point variables with the number 2 in the name as C# permits
variable names that have numbers and underscores after the first
character (which must be a *letter* or an *underscore*)::

    csharp> float numerator2 = numerator;
    csharp> float denominator2 = denominator;
    csharp> float quotient2 = numerator2/denominator2;
    csharp> Console.WriteLine(quotient2);              
    3.5
    csharp> Console.WriteLine("{0} / {1} = {2} remainder {3}", 
          >                   numerator, denominator, quotient, remainder);
    14 / 4 = 3 remainder 2
    csharp> Console.WriteLine("{0} / {1} = {2} approximately", 
          >                   numerator2, denominator2, quotient2);
    14 / 4 = 3.5 approximately

.. highlight:: csharp

We have shown everything you need to understand to
complete this lab. Your job in the remaining time is to see whether
you can use a text editor to create a program, which you can name
anything you like. We suggest calling it ``do_the_math.cs``. To help you
get started, we provided this simple *template*. You'll probably find
it convenient to cut and paste code that you've already "tried out" (in
the C# interpreter) into your text editor::

    using System;

    namespace IntroCS {
       class DoTheMath {
          public static void Main() {
            // Prompt the user for the numerator using
             //   Console.WriteLine().
       
            // Convert this text into int numerator using
            // int.Parse().

            // Do the same for the denominator.

            // Calculate quotient and remainder (as integers)
            // Use Console.WriteLine() to make the results pretty as
            // above.

            // Do the same but using floating point division and not
            // doing the remainder calculation.
          }
       }
    }

When you are done editing and saving ``do_the_math.cs``, 
go to the command line and try the
script (Windows)

   run.cmd do_the_math

or Mac:

   sh run.sh do_the_math
   
If you have errors cycle through editing, saving, and running the script some more. 
