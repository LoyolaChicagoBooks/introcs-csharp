.. index:: file (StreamWriter); write and close
   double: StreamWriter; WriteLine
   class; StreamWriter
   close file
   
.. _filewrite:

Writing Files
==============

Try the following:

#.  In Xamarin Studio build, *not* run, the project :repsrc:`first_file`.  Build is
    the first selection in the local popup menu for first_file in the Solution pad. 
    Recall to get the local popup menu
    
    * go to the Solution pad
    * right click on the project (Mac control-click)

#.  Next open an operating system directory window for the project.
    With Xamarin Studio open, a quick way to do that is to go to the same popup window,
    and this time select "Open Containing Folder".

#.  Besides the project files from the Solutions pad, in the directory window
    you should also see a folder
    :file:`bin`.  Change to that folder and then to its sub-folder :file:`Debug`.
    This is where the build step put its result :file:`first_file.exe` and debug
    information :file:`first_file.exe.mdb`.  You should see no other file.
    Leave this window open.

#.  Now, back in Xamarin Studio, run the project.  Depending on your operating system,
    you may or may not see a Console Window pop up.  If you do see one, you
    should not see any evidence of program results.  If you got a window, close it.

#.  Look at the directory window again.  You should see a file :file:`sample.txt`.
    This is a file created by the program you ran.

Here is the program:

.. literalinclude:: ../../source/examples/first_file/first_file.cs

.. index:: . ; part of namespace

Look at the code.  Note the extra namespace being used at the top.  You will
always need to be using ``System.IO`` when working with files.  Here is a slightly
different use of a dot, ``.``, to indicate a subsidiary namespace.
 
The first line of ``Main`` creates a ``StreamWriter`` object assigned to the
variable  ``writer``.  A ``StreamWriter`` 
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
*current directory*, discussed more shortly.  The Xamarin Studio default is for this
current directory to be this Debug directory.  This will be inconvenient
in many circumstances, and later in the chapter we will see how to minimize the
issue.

The second and third lines of ``Main`` write the specified strings to lines in the file.
Note that the ``StreamWriter`` object ``writer``, not ``Console``, 
comes before the dot and ``WriteLine``.  
This is yet another variation on the use of a dot, ``.``:  between an object and
a function tied to this object.  In this situation the function tied to an object
is more specifically called a *method*, in object-oriented terminology.  All the
uses of a dot (except for a numerical literal value) share a common idea, indicating
a named part or attribute of a larger thing.

The last line of ``Main`` is important for cleaning up. Until this line, this
C# program controls the file, and nothing may be actually
written to the operating system file yet:  Since initiating a file operation
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

As discussed above, Xamarin Studio places ``sample.txt`` in the 
:file:`Debug` sub-subfolder, a hard-to-guess place in the file system, 
that is *not* shown in the Solution pad, so do not look for it there!  
As you should have checked above, you *can* see it in an operating system file
window.  Do drill down to the Debug folder if you have not already; 
open the ``sample.txt`` file with your favorite text processor. 
It should contain just what was written!  

If you were to run the program from the command line instead of from Xamarin Studio, 
the file would appear in the current directory.

.. index:: StreamWriter; format string
   StreamWriter; Write
   
Just as you can use a :ref:`Format-Strings` with 
functions ``Write`` and ``WriteLine`` of the ``Console`` class, 
you can also use a format string with the corresponding methods of a 
``StreamWriter``, and embed fields by using braces in 
the format string.
