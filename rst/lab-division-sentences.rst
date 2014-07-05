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

We have discussed all the syntax and concepts needed in recent sections
on :ref:`arithmetic`, :ref:`Variables-and-Assignment`,
:ref:`io`, and :ref:`cast`.  Also you can make things easier for yourself using
:ref:`substitution-in-writeline` to format output.

Before writing your final program, you might like to review some of 
the parts, testing in the :ref:`csharp` program, so you get immediate feedback
for the calculations.

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

Your final program should work as in this sample run, and use the same 
labeled format:

.. code-block:: none

   Please enter the numerator? 14
   Please enter the denominator? 4
   Integer division result = 3 with a remainder 2
   Floating point division result = 3.5
   The result as a mixed fraction is 3 2/4.

For this lab the example format ``3 2/4`` is sufficient.
It would look better as ``3 1/2``, but a general 
efficient way to reduce fractions to
lowest terms is not covered until the section on the algorithm :ref:`gcd`.  

To do the part requiring a decimal quotient you are going to need to have a 
``double`` value, though your original data was of type ``int``.
You could use the approach in :ref:`cast`, with an explicit cast.
Another approach mentioned in that section was to do the cast implicitly
in a ``double`` declaration with initialization from an ``int``.  If we
already had ``int`` variables, ``numerator`` and 
``denominator``, that were previously assigned their values, 
we could use::

    double numeratorDouble = numerator; // implicit cast
    double quotientDouble = numeratorDouble/denominator;
    ...

Remember: at least one operand in a quotient must be ``double`` 
to get a ``double`` result.
    
To help you
get started with your program code, 
we provided this simple *stub* in the example file
:repsrc:`do_the_math_stub/do_the_math.cs`. 
You are encouraged to copy this into your own project as reviewed 
after the lab in :ref:`xamarinstudio-reminders`.

.. index:: comment
   single: /* ... */ comment
   single: */ end /* comment
   single: // comment

The body of ``Main`` presently contains only *comments*, skipped by the compiler.  
We illustrate two forms (being inconsistent for your information only):

* ``//`` to the end of the *same* line
* ``/*`` to ``*/`` through any number of lines.

Save the stub in a project of
your own and replace the comments with your code to complete it:

.. literalinclude:: ../source/examples/do_the_math_stub/do_the_math.cs
     
Be sure to run it and test it thoroughly. Show your output to a TA.

.. index:: Xamarin Studio; empty project - no console error
   Xamarin Studio; file not in project error 

.. _xamarinstudio-reminders:

Xamarin Studio Reminders and Fixes 
-------------------------------------

Be careful to open your Xamarin Studio solution and add a new **C# Console project** to
it, and add your new file directly into the project (through the Solution pad).  
There are two main places to
mess up here.  We emphasize them and mention fixes if you make the easy mistakes:
   
#.  It is easy to select Empty Project instead of C# and Console Project.  If you
    do that, a correct program will compile successfully, but it will run 
    in limbo, with no console attached to it, and all ``Console.ReadLine()`` calls
    return ``null``, which is likely to make the program have a run-time error.
    One way to fix it:
    
    - If you discovered this while running your program, there is no good access to 
      the running process.  (You lack a console!)
      In this case you need to close your solution, ending the running process,
      and open the solution again.
         
    - Double click on the project in the Solution Pad 
      (if that does anything, or right-click it and select Options).  
      An elaborate Project Options dialog window appears.
      
    - In the left pane under Run, select General.  
      In the right pane, two check boxes should appear.  Make sure you have the first
      checked: Run on external console.  That should check the second one
      automatically.  Close the window and you should be set. 
      
      Be careful, it is possible to uncomment the second checkbox, 
      which makes your execution console close instantly at the end
      of your program, so you miss any last thing printed.  Recheck if
      necessary.
      
#.  Another common error is to proceed like with most text processors, 
    and open the top File menu,  
    and choose to open and edit a new file for your program.  
    *You cannot** *run* **this program from Xamarin Studio.**  
    The file you edit must show in the solution pad in Xamarain Studio, as
    a source file in your project.  If you have a separate project set up, 
    but without this file or any other showing in the Solutions pad, an attempt to
    run the project with say no ``Main`` method (in fact no program at all). 
    The fix:
    
    - You will shortly need to navigate in an operating system open file dialog to where 
      you put the file created from the File menu.  If you do not
      remember where that was, a good trick is to click in the edit window of the file
      and then go to the File menu and select Save As.  The dialog should
      show where the file currently is.  Cancel the dialog.   
    
    - Right click on the project in the Solution pad, and choose Add and then 
      Add Files....  Browse to where the file is and select it; click Open.
      Unless you have some
      reason to keep a copy in the original place, select Move, and Ok.
      Now the orphaned file is moved into your project.  You should see it list 
      under the project in the Solution pad. 
      You can proceed to edit and run it.
      
#.  If you lose the display of the Solution pad somehow, you can go to the View menu, 
    select Pads, and then select Solution.    
    