
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
