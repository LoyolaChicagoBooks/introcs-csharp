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

#.  To show off the transition, first run the ``addition1`` example project
    from inside Xamarin Studio.
#.  Open a terminal on a Mac or a Mono Command Prompt console in Windows.
#.  Following the 
    :ref:`commandline`,
    change the current directory to the addition1 example project directory.
#.  Enter the command to list the directory (``dir`` in Windows; ``ls`` on a Mac).
#.  You should see ``addition1.cs`` but 
    *not* see ``addition1.exe``.  The file ``addition1.exe`` is the compiled program
    that Xamarin Studio creates for this project, however, 
    with the default configuration that we kept
    for this project, this file ends up two directories down in :file:`bin/Debug`.

.. index:: mcs
   command line; compile with mcs
   compile on command line   

Let us now create ``addition1.exe`` in the main project directory 
without using Xamarin Studio.   
Continue with the same terminal/console window:

#.  Try the command

    .. code-block:: none
       
        mono addition1.exe
        
    You should get an error message, because ``addition1.exe`` is not in the current
    directory.
#.  Enter the command
 
    .. code-block:: none
       
        mcs addition1.cs
        
    This is the Mono system compiler, building from the source code.
#.  Print a listing of the directory.  You should now see
    ``addition1.exe``, created by the compiler.
#.  Try the command again:

    .. code-block:: none
       
        mono addition1.exe
    
    Note that no new terminal window popped up and later disappeared - 
    output appears in and stays in the current terminal window.
#.  Windows only:  On Windows, Xamarin Studio creates a regular Windows executable file.
    For consistency you can use the command above, but you no longer need Mono.
    You can just enter the command ``addition1.exe`` or the shorter ``addition1``.
        
Now try a program that had multiple files.  The project version addition3
uses the library class UIF.  Continue with the same terminal/console window:

#.  Enter the commands:

    .. code-block:: none
       
       cd ../addition3
       mcs addition3.cs
       
    to get to the addiiton3 project foilder, and attempt to compile its program.
    You should get an error about missing the UIF class. The mcs program
    does not know about the information Xamarin Studio keeps in its references.
#.  Extend the command to also give the location of the library file:

    .. code-block:: none
       
       mcs addition3.cs ../ui/uif.cs
       
    That should work, now referring to both needed files.
#.  Enter the command

    .. code-block:: none
       
       mono addition3.exe

#.  Now let us try a project where we read a file.  Enter command

    .. code-block:: none
       
       cd ../sum_file

#.  List the contents of this directory. (``dir`` on Windows; ``ls`` on a mac).
#.  If you have run the sum_file.cs program before, you should see
    :file:`sum_file.exe` listed, 
    since the Xamarin options for this project were set to place the output in this
    main project directory.  Erase :file:`sum_file.exe` with 
    ``erase sum_file.exe`` on Windows or ``rm sum_file.exe`` on a Mac.
    You can list the directory again to check that you did it.
#.  Now enter the command    

    .. code-block:: none

       mcs sum_file.cs

#.  List the directory again - :file:`sum_file.exe` has been created again.
#.  Now enter the command    

    .. code-block:: none

       mono sum_file.exe

    As the program runs, remember the file 
    ``numbers.txt`` is in the same folder. To use it,
    just enter the simple file name, ``numbers.txt``.

#.  For a little more command-line experience enter
    ``type numbers.txt`` on Windows, or ``cat numbers.txt`` on a Mac.
    You should see that the the numbers in the file 
    do add to the program's result: 16.
   
By default mcs and mono read from and write to the current directory of the 
terminal/console.  
This is unlike the Xamarin Studio default, where the current directory for execution
is not the project directory.
Under the hood, Xamarin Studio uses mcs also, with a bunch of further options
in the parameters, changing the execution directory and also arranging
for better debugging information when you get a runtime error.

.. index:: NAnt build tool

Xamarin Studio keeps track of all of the parts of your projects, and recompiles only
as needed.  There are
also many command-line tools that manage multi-file projects neatly, remembering
the parts, and compiling only as necessary.
One example is NAnt, which comes with Mono.
