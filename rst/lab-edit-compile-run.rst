.. _lab-edit-compile-run:

Lab Exercise: Editing, Compiling, and Running
---------------------------------------------

Summary
~~~~~~~

This first lab is aimed at taking you through the end-to-end process of
writing and running a basic computer program. As with all things in
life, we will learn in this lab that becoming a programmer requires you
to learn a number of other things along the way.

In software development/engineering parlance, we typically describe a
scenario as a *workflow*, which can be thought of as a series of steps
that are possibly repeated. The workflow of programming can loosely be
defined as follows:

#. Use a text editor to write your source code (human readable).

#. Compile your code using the Software Development Kit (SDK) into
   object code.

#. Link your object code to create an executable. (There are other
   kinds of results to produce, but we will start with the idea of an
   executable program to keep things simple.)  The default is to nave
   an executable program created with compilation, automatically.

#. Run your program. Even for the most seasoned developers, your
   program may not work entirely right the first time, so you may end
   up repeating these steps (debugging).

Later in the course we will use some scripts 
(prewritten collections of commands)
to reduce repetitive typing.
These basically shield you from the
details of understanding the workflow in detail. We think it is
important that you *learn* this workflow from day one, because many types
of software development don't always have the easiest software
development tools.  You will be able to use fancy tools later.

Other tools are available, like
the development environments 
Visual Studio (from Microsoft) and MonoDevelop (an open source
implementation similar to Visual Studio).
These environments are optimized for more complex projects 
than found in this introductory course, so we will avoid the initial learning curve 
needed for such environments. 


To be completed in the lab
~~~~~~~~~~~~~~~~~~~~~~~~~~

The following is the code for a very well-known program, *Hello,
World!*:

.. literalinclude:: ../examples/hello_world.cs
   :language: csharp
   :emphasize-lines: 9
   :linenos:
   
This program is deliberately simple, so you can type it into a text
editor quickly and become familiar with how
to create, edit, and save a program. Perform the following steps. (You
are free to deviate but may want to consider following the steps
religiously at least once to ensure you were successful.)

#.  Open the text editor. This can usually be done from your
    GUI's start menu.  For example :ref:`jEdit` is available in the labs
    and free for `download.
    For this lab you only need to use generic editor features, but
    a further introduction and download instructions are
    in the :ref:`jedit` appendix.

#.  Create a folder anywhere you like (e.g. in Documents) and name it
    ``hello``. (This can be done through the desktop shell
    (e.g. Windows Explorer or Apple Finder.) As a general rule, we
    recommend that you start any new programming project in its own
    folder that is free of other folders/files. Clutter is a great
    enemy of those who aspire to become good programmers.

#.  Enter in the text of the program above, either typing or cutting and pasting.
    Keep in mind that the exact formatting is not important at
    this stage; however, as we progress in this course, you'll *want*
    to pay attention to how your code is formatted. (With most text editors, it is
    possible to reformat your code to make it *beautiful*. More on
    that later.)

#.  Once you have entered the text, you will want to *save* it, just
    as if you were saving a file in your word processor.  
    You will want to save
    the file with the name ``hello.cs``. If you are using a graphical
    text editor, then you will usually be able to save
    from the File menu, much like you would do in a regular word
    processor. Keep in mind, however, that you will eventually want to
    learn the *keyboard shortcuts* for your editor as much development
    work in the real world happens from the command line and remote
    terminal sessions (e.g. web and embedded systems development).


#.  If all has gone well, you will now have a version of *Hello,
    World* in a file named ``hello.cs`` in a folder named ``hello``
    (located in ``Documents``).

#.  Now we are going to learn how to compile this program. For this,
    you will need to open a shell. On Linux and OS X, the shell is
    opened by launching Terminal. On Windows, open a Mono Command
    Prompt, as discussed above (or use one you left open).  Again to
    find it:

    -  OS X: Applications -> Terminal (double click it)
    -  Linux: Applications -> Terminal
    -  Windows: Start Menu, search for Mono Command Line

#.  Now you need to learn how to "move around" using the shell. The
    command shell basically awaits user input and does whatever it is
    told (and does nothing otherwise). You'll begin by using the "cd"
    command to change your working directory to where you saved
    ``hello.cs``.  Note: Replace Dr. Thiruvathukal's login id gkt by
    your login id.  Also note for Mac/Unix examples that his machine
    is called macaroni.
    
    If you did everything right, you can do this on Windows:
    
        | C:\Windows\\System32> cd C:\\Users\\gkt
        | C:\\Users\\gkt> cd Documents\\hello
        | C:\\Users\\gkt\\Documents\\hello> 

    Mac/Linux::

        $ cd Documents/hello

#.  If you are on OS X or Linux, you can list the directory using the
    ``ls`` command. If the output you see here does not match, make
    sure you are in the ``hello`` folder::

        $ ls

        macaroni:hello gkt$ ls
        hello.cs

        $ pwd
        /Users/gkt/Documents/hello

#.  If you're on Windows, can list the contents of the directory using
    ``dir``::

        C:\Users\gkt\Documents\hello>dir
		 Volume in drive C has no label.
		 Volume Serial Number is 2C13-C918
		
		 Directory of C:\Users\anh\Documents\hello
		
		01/16/2012  06:07 PM    <DIR>          .
		01/16/2012  06:07 PM    <DIR>          ..
		11/04/2011  08:20 PM               646 hello.cs
		
		...

#.  If you are unable to see ``hello.cs`` at this stage, you need to
    go back and check all previous steps. It is entirely possible you
    did not create the folder or save properly. If you think you
    completed these steps, this is a good time to ask the instructor
    or teaching assistant for help.

#.  Assuming you are able to see ``hello.cs`` in the ``hello`` folder,
    we are now ready for *the good stuff*~~the technical term we use
    when we are about to learn something that we need to know how to
    do *for life*. We're going to compile the ``hello.cs`` program
    into ``hello.exe`` so we can run it. FYI, you should still be in
    the Terminal/DOS window where we just listed the directory (this
    works regardless of what OS you are using). Enter::

        gmcs hello.cs
    
    This compiles and links your source code to produce an executable program.
    
#.  If everything worked right, you will not see any output. If you
    spot any error messages, it means that you probably made a typo
    when copying/typing the sample code into the text editor. Go back
    to step @EditHello and check that everything is typed
    properly. (We will not be discussing all the possible errors you
    an encounter at this stage, but you might find them helpful to
    edit your program.) If your text editor is not still open, then
    you need to re-open the file, which can be done easily by using
    File ``->`` Open and browsing your folder structure to find folder
    ``hello``, then ``hello.cs``.

#.  Now for the great moment you have been awaiting: You can *run*
    ``Hello.exe``.  Enter::

        mono Hello.exe
        
    You should see the result::
    
        Hello, World!

    At this point, we have accomplished the major objective for this
    introductory lab: to
    enter, compile, and run a C# program. 

#.  Now try a bit of editing.  Look at the program to see where output came
    from.  Change what is printed, save the revised program,
    compile it and run it.

    Now grab the instructor or teaching assistant so
    they can perform a quick inspection of your work and check it off.
    Labs need to be completed to receive
    credit. If you are unable to make class on a lab day, please make sure
    that you complete the work and demonstrate it by the beginning of the
    next lab.

For further reinforcement
~~~~~~~~~~~~~~~~~~~~~~~~~

#. Download and install Mono Software Development Kit on
   your home computer or laptop.  :ref:`jedit`, which knows about C#
   conventions automatically, is a handy editor, with instructions
   for download in the appendix.

#. Make sure you can do everything that you just completed in the lab.

#. Can you make a new program variant print out two separate lines?

#. Go beyond the minimal tools introductions in the lab and see appendices 
   :ref:`commandline` and :ref:`jedit`.

#. See whether you can get a head start on :ref:`lab-division`.


..  comment  now written, so can look there!

    What's in the next lab?
    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    
    In :ref:`lab-division`
    we'll continue learning more about C#. The next lab will give you
    exposure to the C# interactive mode (in Mono, the ``csharp`` command),
    where we will learn to work with arithmetic and basic primitive types.
    The ``csharp`` command allows you to use C# as a sort of "toy
    calculator" language. It also allows you to test capabilities of the C#
    *programming library*. For example, we will learn some other things you
    can do with the ``Console`` interfaces, including how to prompt a user
    for input.
