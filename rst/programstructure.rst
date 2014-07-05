
.. index::  program structure

.. _program-structure:

C# Program Structure
=====================

We discuss the most basic syntax satisfied by all C# programs, which are plain text files,
with names ending in ``.cs``.  There will be additions
later, but any program you can run will include:

    | ``using System;`` 
    |
    | ``class`` **ClassName** 
    | ``{``
    |    ``static void Main()``
    |    ``{``
    |          program statements go here....
    |
    |    ``}``
    | ``}``

By convention class names are capitalized.

You can see that both the example program :repsrc:`painting/painting.cs` and the lab program
:repsrc:`hello/hello.cs` follow this pattern.  The discussion of these parts through 
line 6 in
:ref:`sample-program` are about all we have to say at this point.  For now this
is the boilerplate code.  We will make additions as necessary.  We choose not to
clutter up the basic setup with features that we are not about to use and discuss. 

Here is a silly little test illustrating the difference between ``Console.WriteLine``
and ``Console.Write``, in example :repsrc:`write_test/write_test.cs`:

.. literalinclude:: ../source/examples/write_test/write_test.cs

When run, the program prints:

.. code-block:: none

    hellotherehello
    Another line
    Starting yet another line
    
Do you see how the output shows the differences between ``WriteLine`` and ``Write``?
If we added another printing statement, where would the beginning of 
the output appear:
after the final ``e`` or under the ``S`` of Starting?

.. index:: Xamarin Studio; indentation options setting
   indentation options in Xamarin Studio
   tabs changed to spaces

.. _indentation_help:

Indentation Help
-----------------------

Using conventional indentation helps understand a program and find errors, 
like unmatched braces. When you press return in a C# source file 
(i.e. a file with name ending in ``.cs``), Xamarin Studio makes a guess at the proper
indentation of the next line.  The exact reaction can be set in the *options*.
The simplest approach is to set these options *once* for all new files 
in a solution, like your work solution:

#. Access the context menu for the whole solution (not one project).
#. Select Options.
   
   .. image:: images/select_options.png
      :width: 332.25 pt
   
#. In the popup Solution Options Window, you will see "Code Formatting" 
   in the left column.  If you do not see "C# source code" and then "Text file"
   right underneath it
   click on "Code Formatting" to expand the hierarchy.
  
   .. image:: images/set_indent.png 
      :width: 351.75 pt
   
#. Click on Text file, and then the right side should show options.  
   Adjust them to look like the picture: tab and indent widths 3, 
   first and last check boxes *checked* 
   (Convert tabs to spaces. Remove trailing spaces),
   and have the middle check box (Allow tabs after non-tabs) *unchecked*.
#. Click OK.

Tabs vs. spaces is not a significant issue inside a consistent environment,
like Xamarin Studio, but if there are tab characters in a file, 
they can be expanded different amounts by different display programs.  
Then particularly if you mix tab characters and spaces you can get 
something very strange.
If only spaces are used, there is no ambiguity in different displays.

The 3 vs. 4 spaces is not a big deal, but 3 appears to be large enough to see 
easily, and makes lines with nested indentation have more room.

.. index:: compiler error; explanation link

Compiler Error Help
-----------------------

There are an enormous number of possible *syntactic* errors in your source code
that the compiler
can detect.  

.. index:: editor error annotations
   syntax error annotations in editor
   Xamarin Studio; editor error annotations
   
**Errors shown** *while* **editing**:  If you use an editor like Xamarin Studio, 
some of these errors are even checked while you type and are
noted while you are editing.  They may be indicated with a 
red squiggly underline, and possibly a red comment at the right.  Sometimes
the squiggle is just because you are in the middle of something, but if it
is still there after you complete a whole statement, there may well
be an issue to look at.  Sometimes fixing the issue makes the annotation
go away, but sometimes your program may really be fixed, 
and the error annotation
does not go away until you formally compile/build the whole program.
This annoying ambiguity leads some people to turn off error annotations,
and just let
the system note errors after a complete compile cycle.

After compiling and getting an error, sometimes reading the error description 
carefully  will help you 
understand the problem.  Sometimes the error is very cryptic.   In those cases
it might help to look at the C# .NET error documentation,

   http://msdn.microsoft.com/en-us/library/ms228296.aspx.

Each compiler error you make has a number shown in its description. 
Many of these error numbers are shown in the left column
of the linked page.  You can click to get a more complete explanation and 
examples.

Another important way to learn about the error messages is to leverage your
experience:  After 
you have eventually found how to fix your error, *take the extra time* to
use your new knowledge,
look back at the original error message,
and see if the error description text makes more sense.  
That should help next time,
(and there usually is a next time). Even when the error description still 
makes no particular sense, you may well get into the same situation again,
with the same error number.  Then 
remembering the issue you found in a previous time could help.

Debugging can eat up an enormous amount of time, 
so it is really worth your effort to understand the errors that you tend to make
and the errors' relation to the error messages that you get.

.. warning::
   It is certainly helpful that the compiler finds *syntactic* errors for you,
   but be sure to remember that compiling does *not* mean the program
   will "work" and correctly do what you desire.  Test your compiled program
   thoroughly to reduce the chance of *logical* errors remaining, that
   cause *run-time* errors, or just the wrong results.
 