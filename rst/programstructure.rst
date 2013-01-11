
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