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

As we will learn later in the course, development environments such as
Visual Studio (from Microsoft) and MonoDevelop (an open source
implementation similar to Visual Studio) basically shield you from the
details of understanding the workflow in detail. We think it is
important that you *learn* this workflow from day one, because many types
of software development don't always have the easiest software
development tools.  You will be able to use fancy tools later.

To be completed in the lab
~~~~~~~~~~~~~~~~~~~~~~~~~~

The following is the code for a very well-known program, *Hello,
World!*:

.. literalinclude:: ../examples/hello+nant/HelloWorld.cs
   :language: csharp
   :emphasize-lines: 9
   :linenos:
   
This program is deliberately simple, so you can type it into a text
editor (Emacs is recommended but your instructor may introduce you to
a different editor, subject to availability in the lab) quickly and become familiar with how
to create, edit, and save a program. Perform the following steps. (You
are free to deviate but may want to consider following the steps
religiously at least once to ensure you were successful.)

#.  Open the text editor. This can usually be done from your
    GUI's start menu.

#.  Create a folder anywhere you like (e.g. in Documents) and name it
    ``hello``. (This can be done through the desktop shell
    (e.g. Windows Explorer or Apple Finder.) As a general rule, we
    recommend that you start any new programming project in its own
    folder that is free of other folders/files. Clutter is a great
    enemy of those who aspire to become good programmers.

#.  When you start in Emacs, you are in what is known as *scratch*
    mode.  Typical of a sketchpad used by artists, this is where you
    can start typing right away. You can now begin typing in the text
    above. Keep in mind that the exact formatting is not important at
    this stage; however, as we progress in this course, you'll *want*
    to pay attention to how your code is formatted. (With most text editors, it is
    possible to reformat your code to make it *beautiful*. More on
    that later.)

#.  Once you have entered the text, you will want to *save* it, just
    as if you were saving a file in your word processor. (In the Emacs
    text editor, you use Control-x, Control-s. You will want to save
    the file with the name ``Hello.cs``. If you are using a graphical
    text editor (like the case) then you will usually be able to save
    from the File menu, much like you would do in a regular word
    processor. Keep in mind, however, that you will eventually want to
    learn the *keyboard shortcuts* for your editor as much development
    work in the real world happens from the command line and remote
    terminal sessions (e.g. web and embedded systems development).


#.  If all has gone well, you will now have a version of *Hello,
    World* in a file named ``Hello.cs`` in a folder named ``hello``
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
    ``Hello.cs``.  Note: Replace Dr. Thiruvathukals's login id gkt by
    your login id.  Also note for Mac/Unix examples that his machine
    is called macaroni.
    
    If you did everything right, you can do this on Windows::
    
        C:\Windows\System32> cd C:\users\gkt
        C:\Users\gkt> cd Documents\hello
        C:\Users\gkt\Documents\hello> 

    Mac/Linux::

        $ cd Documents/hello

#.  If you are on OS X or Linux, you can list the directory using the
    ``ls`` command. If the output you see here does not match, make
    sure you are in the ``hello`` folder::

        $ ls

        macaroni:hello gkt$ ls
        Hello.cs

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
		11/04/2011  08:20 PM               646 Hello.cs
		
		...

#.  If you are unable to see ``Hello.cs`` at this stage, you need to
    go back and check all previous steps. It is entirely possible you
    did not create the folder or save properly. If you think you
    completed these steps, this is a good time to ask the instructor
    or teaching assistant for help.

#.  Assuming you are able to see ``Hello.cs`` in the ``hello`` folder,
    we are now ready for *the good stuff*~~the technical term we use
    when we are about to learn something that we need to know how to
    do *for life*. We're going to compile the ``Hello.cs`` program
    into ``Hello.exe`` so we can run it. FYI, you should still be in
    the Terminal/DOS window where we just listed the directory (this
    works regardless of what OS you are using). Enter::

        gmcs Hello.cs

#.  If everything worked right, you will not see any output. If you
    spot any error messages, it means that you probably made a typo
    when copying/typing the sample code into the text editor. Go back
    to step @EditHello and check that everything is typed
    properly. (We will not be discussing all the possible errors you
    an encounter at this stage, but you might find them helpful to
    edit your program.) If your text editor is not still open, then
    you need to re-open the file, which can be done easily by using
    File ``->`` Open and browsing your folder structure to find folder
    ``hello``, then ``Hello.cs``.

#.  Now for the great moment you have been awaiting: You can *run*
    ``Hello.exe``.  Enter::

        mono Hello.exe
        
    You should see the result::
    
        Hello, World!

At this point, we have accomplished the major objective for Lab 0: to
enter, compile, and run a C# program. In the next lab, we will work on
some revisions to ``Hello.cs`` to personalize it a bit.

As this point, you should grab the instructor or teaching assistant so
they can perform a quick inspection of your work and check it off. Per
the syllabus, labs are not graded but do need to be completed to receive
credit. If you are unable to make class on a lab day, please make sure
that you complete the work and demonstrate it by the beginning of the
next lab.

For further reinforcement
~~~~~~~~~~~~~~~~~~~~~~~~~

#. Download and install the Emacs and Mono Software Development Kit on
   your home computer or laptop.

#. Make sure you can do everything that you just completed in the lab.

#. See whether you can get a head start on Lab 1.

Some Useful Resources for Learning Emacs
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

#. The GNU Emacs Tutorial, http://www.gnu.org/software/emacs/tour/

#. University of Chicago Libraries Emacs Tutorial,
   http://www2.lib.uchicago.edu/keith/tcl-course/emacs-tutorial.html

Other Useful Text Editors
~~~~~~~~~~~~~~~~~~~~~~~~~

#. Gedit, http://gedit.org, is a very nice editor that comes with most
Linux/Gnome distributions. Although it allegedely runs on Windows and OS X, we
have not had a chance to test it and cannot recommend it at this time.

#. Vim,  http://www.vim.org/docs.php, is another popular editor based
   on the famous **vi** text editor that goes back a number of
   decades. There are graphical versions for Linux, Mac, and Windows.

Unfortuntely, these are not available in the Windows labs yet (unlike
Emacs); however, students working in the Linux laboratory have access
to these editors and may wish to learn them. 

What's next in Lab 1?
~~~~~~~~~~~~~~~~~~~~~

We'll continue learning more about C#. The next lab will give you
exposure to the C# interactive mode (in Mono, the ``csharp`` command),
where we will learn to work with arithmetic and basic primitive types.
The ``csharp`` command allows you to use C# as a sort of "toy
calculator" language. It also allows you to test capabilities of the C#
*programming library*. For example, we will learn some other things you
can do with the ``Console`` interfaces, including how to prompt a user
for input.
