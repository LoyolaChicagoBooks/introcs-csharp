.. index:: file (StreamWriter); write and close
   double: StreamWriter; WriteLine
   class; StreamWriter
   close file
   
.. _filewrite:

Writing Files
==============

Thus far we have only used the Console class for input and output, 
so we have neither read nor written data from/to files.

By default Xamarin Studio places data files in a place that makes sense for advanced
projects, but not for our usage.  Thus far it has not mattered, and we
have left the default directory structure alone.  Now, however, it matters, 
and will be a lot simpler if we make a small change to the setup of all our projets using
data files. This will also simplify command-line usage when we get to it.

Try the following:

#.  In Xamarin Studio go to the example project :repsrc:`first_file`.  Double click 
    on the project line in the Solution pad to open the Options dialog.  
    (If this does not work for some
    reason you can also open the drop-down project menu and select Options.)

#.  In the left column of the dialog under Build, the last entry should be Output.  Click on it.
    The output path entry should end with:

    .. code-block:: none

       examples/first_file

    This is *not* the way Xamarin sets it up by default.  
    Originally Output Path ended with:

    .. code-block:: none

       examples/first_file/bin/$(Configuration)

    This version has the extra ``/bin/$(Configuration)``.  

..  note::
    When you create a new project to
    use data files, make sure the  ``/bin/$(Configuration)`` is *removed*
    from the end of this Output Path field.

Now let us examine the files here.  

#.  In the dropdown menu for the :repsrc:`first_file` project, select 
    "Open Containing Folder" on Windows
    or "Reveal in Finder" on a Mac.  In any event the selection opens the project folder
    in the operating system, showing all the files, not just the ones you see listed in 
    Xamarin in the project. 

#.  Look at the folder. You should *not* see a file :file:`sample.txt`.   Keep the folder handy.

#.  Now build (not run yet ) the first_file project.  

#.  Look at the operating system folder again.  You should now see build products,
    :file:`first_file.exe`, the executable file, and :file:`first_file.exe.mdb`, 
    extra debugging information if there are errors in execution.

#.  Now run the program.  This program does *not* produce output to the screen,
    so just close the execution window.

#.  The program did do something:  Look at the operating system folder again. 
    Now you *should* see a file :file:`sample.txt`. 
    This is a file created by the program you ran.  

Here is the program:

.. literalinclude:: ../../examples/introcs/first_file/first_file.cs

.. index:: . ; part of namespace
   System.IO namespace

Look at the code.  Note the extra namespace being used at the top.  You will
always need to be using ``System.IO`` when working with files.  Here is a slightly
different use of a dot, ``.``, to indicate a *subsidiary* namespace.
 
The first line of ``Main`` creates a ``StreamWriter`` object assigned to the
variable  ``writer``.  A ``StreamWriter`` 
links C# to your
computer's file system for writing, not reading. 
Files are objects, like a Random, and use the ``new`` syntax to create a new one. 
The parameter in the constructor
gives the name of the file to connect to the program, ``sample.txt`` - the same
as the file name we saw created by the program. 

..  warning::
    If the file already existed,  the old contents are
    *destroyed* silently by creating a ``StreamWriter``.

If you do not use
any operating system directory separators in the name (``'\'`` or ``'/'``,
depending on your operating system), then the file will lie in the
*current directory*, discussed more shortly.  The Xamarin Studio default is for this
current directory to be the bin/Debug subdirectory.  Our change to the output path
converts it so the *current directory* is the main project folder.

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

If you were to run the program from the command line instead of from Xamarin Studio, 
the file would appear in the current directory.

.. index:: StreamWriter; format string
   StreamWriter; Write
   
Just as you can use a :ref:`Format-Strings` with 
functions ``Write`` and ``WriteLine`` of the ``Console`` class, 
you can also use a format string with the corresponding methods of a 
``StreamWriter``, and embed fields by using braces in 
the format string.
