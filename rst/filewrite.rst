.. index::
   double: file; write
   double: StreamWriter; WriteLine
   double: StreamWriter; class
   single: file; close
   
.. _filewrite:

Writing Files
==============
   
*Open a console window for our examples folder.*
First note that there is no file named sample.txt. 

Then compile and run the example program ``first_file.cs``, shown below:

.. literalinclude:: ../examples/first_file.cs

Nothing shows on the screen when you run the program:
it is just writing to a file.

Look at the code.  Note the extra namespace being used at the top.  You will
always need to be using ``System.IO`` when working with files.
 
The first line of ``Main`` creates a ``StreamWriter`` object assigned to the
variable  ``reader``.  A ``StreamWriter`` 
links C# to your
computer's file system for writing, not reading. 
Files are objects, like a Random, and use the ``new`` syntax to create a new one. 
The parameter in the constructor
gives the name of the file to connect to the program, ``sample.txt``. 

..  warning::
    If the file already existed,  the old contents are
    *destroyed* silently by creating a ``StreamWriter``.

If you do not use
any operating system directory separators in the name (``'\'`` or ``'/'``,
depending on your operating system), then the file will lie in the
current directory. :ref:`file-and-directory-paths` discusses 
the use of directory separators.

The second and third lines of ``Main`` write the specified strings to lines in the file.
Note that the ``StreamWriter`` object ``reader``, not ``Console``, 
comes before the dot and method.

The last line of ``Main`` is important for cleaning up. Until this line, this
C# program controls the file, and nothing may be actually
written to the file yet:  Since initiating a file operation
is thousands of times
slower than memory operations, C# *buffers* data, saving small
amounts and writing a larger chunk all at once.

..  warning::
    The call to the ``Close`` method
    is essential for C# to make sure everything is really
    written, and to relinquish control of the file for use by
    other programs.

It is a common bug
to write a program where you have the code to add all the data you
want to a file, but the program does not end up creating a file.
Usually this means you forgot to close the file!

Switch focus and look at the examples
directory. You should now see a file ``sample.txt``. You can open
it in :ref:`jEdit` (or your favorite text processor) and see its contents, or
jut print it to your console window.

As you can use a :ref:`Format-Strings` with 
``Console`` methods ``Write`` and ``WriteLine``, 
you can also use a format string with a ``StreamWriter``, 
and embed fields by using braces in 
the format string.
