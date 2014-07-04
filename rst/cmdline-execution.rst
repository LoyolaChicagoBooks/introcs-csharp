.. index:: command line; execution
   execution on command line 

.. _cmdline-execution:

Command Line Execution
========================


C# shields you from the differences
between operating systems 
with its ``File``, ``Path``, and ``Directory`` classes.

If you leave Xamarin Studio and go to the command line as described in
:ref:`commandline`, then you are exposed to the differences
between the operating systems.  *Look over that section.*

Thus far we have let Xamarin Studio hide what actually is happening when
you execute a program.  The natural environment for the text-based programs
that we are writing is the command line.  
We need to get outside of Xamarin Studio.

#.  To show off the transition, first build or run the ``addition1`` example project
    from inside Xamarin Studio.
#.  Open a terminal on a Mac or a Mono Command Prompt console in Windows.
#.  Following the 
    :ref:`commandline`,
    change the current directory to the addition1 example project directory.
#.  Then change to the subdirectory ``bin`` and then the subdirectory ``Debug``.
#.  Enter the command to list the directory (``dir`` in Windows; ``ls`` on a Mac).
#.  You should see ``addition1.exe``.  This is the compiled program
    created by Xamarin Studio.  Enter the command 

    .. code-block:: none
       
        mono addition1.exe
    
    This should run your program.  Note that when you complete it, the window does not
    disappear!  You keep that history.  Keep this terminal/console window open
    until the end of the chapter.  
#.  Windows only:  On Windows, Xamarin Studio creates a regular Windows executable file.
    For consistency you can use the command above, but you no longer need Mono.
    You can just enter the command ``addition1.exe`` or the shorter ``addition1``.

.. index:: mcs
   command line; compile
   compile on command line

.. _gmcs:

MCS: Compiling 
---------------
   
Continue with the same terminal/console window.
Let us now consider creating an executable program for ``addition1.cs``,
directly, without using Xamarin Studio:

#.  Enter the command ``cd ..`` and then *repeat*: ``cd ..``, 
    to go up to the project directory.
#.  Print a listing of the directory. 
    You should see
    ``addition1.cs`` but not ``addition1.exe``.
#.  Try the command

    .. code-block:: none
       
        mono addition1.exe
        
    You should get an error message, because ``addition1.exe`` is not in the current
    directory.
#.  Enter the command
 
    .. code-block:: none
       
        mcs addition1.cs
        
    This is the Mono system compiler, building from the source code.
#.  Print a listing of the directory.  You should see
    now ``addition1.exe``, created by the compiler.
#.  Try the command again:

    .. code-block:: none
       
        mono addition1.exe
        
Now try a program that had multiple files.  The project version addition3
uses the library class UIF.  Continue with the same terminal/console window:

#.  Enter the commands:

    .. code-block:: none
       
       cd ../addition3
       mcs addition3.cs
       
    You should get an error about missing the UIF class. The mcs program
    does not know about the information Xamarin Studio keeps in its references.
#.  Extend the command:

    .. code-block:: none
       
       mcs addition3.cs ../ui/uif.cs
       
    That should work, now referring to both needed files.
#.  Enter the command

    .. code-block:: none
       
        mono addition3.exe

#. Now let us try a project where we read a file.  Enter commands

    .. code-block:: none
       
       cd ../sum_file
       mcs sum_file.cs
       mono sum_file.exe
       
   We ran this program earlier through Xamarin Studio.  Recall that that
   entering the file name ``numbers.txt`` failed, and to refer to the right 
   place for the ``numbers.txt`` file, we needed to use ``..\..\numbers.txt``
   or ``../../numbers.txt``.  This time *just enter* ``numbers.txt``.  The
   program should work, giving the answer 16.
   
By default mcs and mono read from and write to the current directory of the 
terminal/console.  In the situation above, ``sum_file.cs`` and ``numbers.txt``
were in the project directory, which is the current directory. 
Then sum_file.exe was written to and run from
the same directory.

This is unlike the Xamarin Studio default, where the current directory for execution
is not the project directory.

Under the hood, Xamarin Studio uses mcs also, with a bunch of further options
in the parameters, changing the execution directory and also arranging
for better debugging information when you get a runtime error.

.. index:: NAnt build tool

Xamarin Studio keeps track of all of the parts of your projects, and recompiles only
as needed.  There are
also command-line tools that manage multi-file projects neatly, remembering
the parts, and compiling only as necessary.
One example is NAnt, which comes with Mono.
