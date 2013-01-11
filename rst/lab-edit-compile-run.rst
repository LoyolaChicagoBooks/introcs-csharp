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
   executable program to keep things simple.)  The default is to have
   an executable program created with compilation, automatically.

#. Run your program. Even for the most seasoned developers, your
   program may not work entirely right the first time, so you may end
   up repeating these steps (debugging).

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

.. literalinclude:: ../source/examples/hello_world/hello_world.cs
   :language: csharp
   :emphasize-lines: 9
   :linenos:
   
This program is deliberately simple, so you can type it into a text
editor quickly and become familiar with how
to create, edit, and save a program. Perform the following steps. (You
are free to deviate but may want to consider following the steps
religiously at least once to ensure you were successful.)

#.  Open MonoDevelop.   FILL THIS IN!

    ...
    
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
    the project .......

    You should see the result::
    
        Hello, World!

    At this point, we have accomplished the major objective for this
    introductory lab: to
    enter, compile, and run a C# program. 

#.  Now try a bit of editing.  Look at the program to see where output came
    from.  Change what is printed, save the revised program,
    compile it and run it.

    Now grab the instructor or teaching assistant so
    they can perform a quick inspection of your work and check it off
    (including the varied message printed).
    Labs need to be completed to receive
    credit. If you are unable to make class on a lab day, please make sure
    that you complete the work and demonstrate it by the beginning of the
    next lab.

For further reinforcement
~~~~~~~~~~~~~~~~~~~~~~~~~

#. Download and install Mono Software Development Kit and MonoDevelop on
   your home computer or laptop.  

#. Can you make a new program variant print out two separate lines?
