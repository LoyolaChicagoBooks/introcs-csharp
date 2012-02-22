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
You may want to jump to the final section that discusses how to
set emacs up for that.

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

As an example of how this program will ultimately work::

   Please enter the numerator? 14
   Please enter the denominator? 4
   Floating point division result = 3.5
   Integer division result = 3 remainder 2
   Result as a fraction = 3 2/4

We will later learn how to turn the 3 2/4 into a reduced
fraction. This will be achieved using a famous method known as the
*greatest common divisor* algorithm, which has a very simple
formulation that is credited to Euclid, of of the great early
mathematicians (among other things).

csharp
------

So let's get this party started by firing up the **csharp**
command. Open a terminal (Linux or OS X) or command window for the
Mono tools, which we know how to use from previous work::

    $ csharp
    Mono C# Shell, type "help;" for help

    Enter statements below.
    csharp>  

The ``csharp>`` prompt tells you that the C# interpreter has started
and is awaiting input. This allows you to create C# variables and
execute C# statements without having to write a full program. 

You can also use features of the C# programming
library (e.g. the ``Console.WriteLine`` we learned about in the
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

    csharp> int denominator = int.Parse(
    >

In this example, I accidentally hit the return/enter key after
entering the left parenthesis. For ``int.Parse(`` to work, it needs
more input to bring the statement to completion. For example, it needs
to know *what to parse* and must be a complete C# statement. The
closing parenthesis and statement terminator (semicolon) need to be
typed for this to happen.

So we can either continue entering the input::
    
    csharp> int denominator = int.Parse(
    > input);       


Or we can type semicolon (;) followed by return/enter to end the input
and try again::

    csharp> int denominator = int.Parse(
    > ;
    {interactive}(2,0): error CS1525: Unexpected symbol `;'

This will force the statement to be processed by the C# interpreter
and give an error. You can then *try again* if you like!

A particularly useful feature of the C# interpreter is the
``ShowVars()`` function. (Yes, we know you haven't fully learned
functions yet, but we're introducing some things by doing them and
will be explaining more formally later.) ``ShowVars()`` prints the
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

Now let's use the C# operators to get the quotient and the remainder::

    csharp> int quotient = numerator / denominator;
    csharp> Console.WriteLine(quotient);
    3
    csharp> int remainder = numerator % denominator;
    csharp> Console.WriteLine(remainder);
    2
    csharp> Console.WriteLine("{0} / {1} = {2} remainder {3}", numerator, denominator, quotient, remainder);
    14 / 4 = 3 remainder 2

Because we are working with integer data, we need the ability to get
the result of the division and the remainder *as integers*. As shown,
14 / 4 results in 3. That's because the remainder is not included (nor
can it be) unless we use another data type (float) that can hold the
full result of a division operation.

C# gives you the ability to get the remainder using a separate
operation known as the *modulus* operator. This operator is what we
sometimes call a *convenience* operator, because we all learned in
basic mathematics that the remainder = numerator - quotient *
denominator (here the remainder is 14 - 3 * 4 = 2).

In the above, we are also introducing the ability to take the results
of a calculation and *format* them using ``Console.WriteLine``. Here
{0}, {1}, {2}, and {3} refer to each of the variables that follow the
text that we wish to print. Each of these variables will be
substituted into the string to produce the beautifully formatted
output that is shown::

    14 / 4 = 3 remainder 2

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
    csharp> Console.WriteLine("{0} / {1} = {2} remainder {3}", numerator, denominator, quotient, remainder);
    14 / 4 = 3 remainder 2
    csharp> Console.WriteLine("{0} / {1} = {2} approximately", numerator2, denominator2, quotient2);
    14 / 4 = 3.5 approximately

So effectively we have shown everything you need to understand to
complete this lab. Your job in the remaining time is to see whether
you can use a text editor to create a program, which you can name
anything you like. We suggest calling it ``DoTheMath.cs``. To help you
get started, we provided this simple *template*. You'll probably find
it convenient to cut and paste code that you've already "tried out" (in
the C# interpreter) into your text editor::

    using System;

    namespace Comp170 {
       class DoTheMath {
          public static void main() {
	      // Prompt the user for the numerator using
              // Console.WriteLine().
       
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

.. _java-mode:

.. index::
   double: emacs; java-mode

Proper Indentation and Emacs java-mode
--------------------------------------

With this exercise, we are now entering a phase where we must start
paying a bit more attention to the basic *appearance* of our code. As
programs become larger, they also can become harder to maintain (let
alone understand) if they are not formatted according to some basic
style guidelines.

As you'll come to learn in programming, different communities have
different conventions. The folks who make another open source C# tool,
known as SharpDevelop (not used in this class but an awesome project)
have their own style guide that is particularly well written. See
http://www.icsharpcode.net/technotes/sharpdevelopcodingstyle03.pdf.

In any event, luckily for us, we have access to editors like Emacs and
Gedit (in the Linux lab anyway) that support automatic source-code
indenting. In Emacs, you can enable this support by using
*java-mode*. At the time of writing, there is actually a *csharp-mode*
but it is not yet a part of the standard Emacs distribution. For the
most part, you can get by using *java-mode*, given that C# is very
similar to Java in terms of its overall syntax. It doesn't understand
keywords like ``namespace`` but otherwise seems to work in our
testing.

When in Emacs, you can enable Java mode in your buffer for
``DoTheMath.cs`` by typing Escape-x. The minibuffer (the space you see
at the bottom of the screen where an ``M-x`` or similar prompt is
shown) will wait for you to type the name of a command. Enter
*java-mode* and you will be able to take advantage of the magical
support in Emacs for automatic formatting of your source code. Your
instructor will show you how to make effective use of it.  Two features
are worthy of immediate notice:

- The program becomes color-coded.  On of the most useful things
  is that literal strings have a different color.  
  Forgetting the final quote mark at the end of a literal string
  ia=s a common
  error that may not be associated with good error messages.
  The color coding makes it very obvious that the editor sees the
  string as being too long.
  
- Nice indentation is done with very little effort.  Pressing the
  Enter key still takes you to the beginning of the next line,
  but a single further press of the tab key 
  generally indents to exactly where the line should start.

If you are feeling a bit adventurous, you can download *csharp-mode*
from the Emacs Wiki at
http://www.emacswiki.org/emacs/CSharpMode. All you need to do is save
the Emacs Lisp file (a file with the .el suffix) anywhere in your home
folder. Then you can use Emacs to load this file (Esc-x, then type
*load-file*). You'll need to browse to the folder where you saved the
*csharp-mode* code to complete the process. Then you ca type
*csharp-mode* instead of *java-mode*.

As this is a bit of an advanced topic, this explanation will have to
suffice for now. We're hopeful that future versions of Emacs will
include *csharp-mode* by default.
