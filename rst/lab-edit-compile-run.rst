.. index:: MonoDevelop
   labs; MonoDevelop


.. _lab-edit-compile-run:

Lab Exercise: Editing, Compiling, and Running with MonoDevelop
================================================================

This first lab is aimed at taking you through the end-to-end process of
writing and running a basic computer program with the MonoDevelop
environment. As with all things in
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

These steps can all be done with different tools.  Many find it simpler to have
an integrated tool, like MonoDevelop, that does them all in the same place,
and automates the steps that do not need human interaction!  

If you are doing this on your own
machine, make sure you have Mono and MonoDevelop installed as in
:ref:`development-tools`.

Other tools are available, like
the development environment 
Visual Studio (from Microsoft, only for Windows).

Understanding the lower level tools that accomplish each step is important, but we defer
a discussion to get you going with monoDevelop.


Goals
-----

Our primary goal to create a C# Solution that you can use to do all of
the remaining homework assignments and labs this semester. If you
wish, you can create as many solutions as you like, but C# allows you
to create a single solution and add (at any time) projects to it. This
will provide by far the best experience for you in the course, where
you can keep adding onto previous efforts without having to start over
each time.

Steps
-----

We start by creating a *solution* with a project in it.  The images are from
a Mac.  Windows versions should be similar.

#.  Open MonoDevelop, in the appropriate way for an application in your
    operating system.  It should be in the Start menu for Windows.
    Using Spotlight is quick on a Mac.

#.  You get a Welcome screen.  Toward the upper left corner is a link for 
    New Solution.  Click on it.  Alternately you can follow the path through the menus
    Go File -> New -> Solution.  
   
    ..  image:: images/lab-edit/newSolution.png
     	:alt: MonoDevelop Start Image
     	:align: center

#. You get a dialog window to fill out:

   - Select C# in left hand side panel
   - Select Console Project in right hand side panel
   - In the bottom field, "Solution name", 
     enter any name you like:  We recommend **work**.
   - Leave the Location field above it as is or change it if you like.
   - Above that, Enter **hello** for the name (of the project).
   - Make sure *Create directory for solution* is checked in the bottom right.
   - Press the Forward button.
   
   ..   image:: images/lab-edit/consoleProjectDialog.png
     	:alt: MonoDevelop Dialog Image
     	:align: center
   
#. At the Project Features form (no image here), just press ok.  
   We are not using the feature mentioned in that dialog.  
   
   You now have created a solution in MonoDevelop, with one project
   inside it. Later we can add further *projects* to this *solution*. 

#. Look at the MonoDevelop window that appears.  It should have two main sub-windows or 
   "Pads" as MonoDevelop calls them.  A narrow one on the left is the Solution pad,
   containing a hierarchical view of the solution.  You should see your solution name
   at the top and hello under that.  Folders have a little triangle shown to their 
   left.  You can click on the triangle.  A triangle pointing down, 
   means the inside of the folder is displayed.  A triangle pointing to the right
   means the contents are not being displayed. Listed under hello is the automatically
   generated sample code file Main.cs.  
   It should also appear in the edit window to the right.
   
   ..   image:: images/lab-edit/Main.png
     	:alt: MonoDevelop Main.cs Image
     	:align: center
   
#. You can open a context sensitive popup window 
   on most entries in the Solution pad.  With a two button mouse you right click on
   a particular item.  In this case use the project hello.  On a one-button Mac you will
   need to hold the Control key and click.  We may use the short term *right-click* in the
   future, though it may not directly apply to a Mac, where you may interpret it as
   Control-click.
   
#. Bring up the context menu on the hello project in the Solution pad.
   Select Run Item.  

   ..   image:: images/lab-edit/runMainMenu.png
     	:alt: MonoDevelop Run Main.cs Image
     	:align: center
   
    
#.  Here MonoDevelop combines several steps: saving the file,
    compiling it, and starting running it, if compilation succeeded.
    With the canned file, it should succeed!  You see a Console window
    something like
    
    ..  image:: images/lab-edit/pressKey.png
     	:alt: MonoDevelop Press Key to close Image
     	:align: center
   
    You have a chance to see the output of this simple program.
    Follow the instructions and press the Enter key.
    
#.  On Windows, that kills the window.  **On a Mac, only, there is one more step:**

    ..  image:: images/lab-edit/processComplete.png
     	:alt: MonoDevelop Process Complete Image
     	:align: center
   
    You have to actively close the Mac terminal window, either by clicking the
    red window closing button, or using the keyboard, with Command-W.

#.  Initially, for immediate practice running a program, this automatically generated
    file, ``Main.cs``, is convenient.  Hereafter it is an annoyance.  
    The file name is always the same, and not useful, 
    and you would need to redo the whole
    code for your own program.  A general approach is to *delete* this
    file and put in a file of your own.   
    
    Open the context sensitive menu for the file Main.cs, and select
    Remove.
    
    ..  image:: images/lab-edit/menuRemoveMain.png
     	:alt: MonoDevelop Remove Main.cs Image
     	:align: center
   
    You get another popup.  The image below shows the way it first appears, 
    *with the wrong button chosen*.  **Choose the left button, Delete**.  
    Otherwise the file is left in the hello
    folder, but it is not listed as being in the project.
      
    ..  image:: images/lab-edit/sureRemove.png
     	:alt: MonoDevelop Delete Main.cs Image
     	:align: center
   

#. To get in code that you want, there are several approaches.  The one we take
   now is to start from a completely
   new empty file:  Pop up the context sensitive menu for the hello project.
   Select the submenu Add...  and  then New File....  

   ..   image:: images/lab-edit/addNewFileMenu.png
     	:alt: MonoDevelop Add new file Image
     	:align: center
   

#. In the popup New File Dialog Window, click on Empty File.  Enter the name hello.cs.
   Click the New button.
   
   ..   image:: images/lab-edit/makeEmptyFileDialog.png
     	:alt: MonoDevelop Add empty file Image
     	:align: center
   
#. This should add hello.cs to the hello project and open an editing window for hello.cs.
   The file should have no text.
   
   ..   image:: images/lab-edit/editEmptyHello.png
     	:alt: MonoDevelop edit empty file Image
     	:align: center
   
   
   Much like in most word processors type in (or paste) 
   the following code.  This is actually an equivalent
   *Hello, World!* program to the automatically generated one,
   but it is a bit shorter.  
   It only introduces the syntax we actually need at the beginning,
   and will be discussing more shortly:
    
   ..  literalinclude:: ../source/examples/hello/hello.cs
       :language: csharp
       :linenos:
   
   This program is deliberately simple, so you can type it into a text
   editor quickly and become familiar with how
   to create, edit, and save a program. 
            
   ..   image:: images/lab-edit/pasteHello.png
     	:alt: MonoDevelop Edited new file Image
     	:align: center
   
#.  You can run the project just as before.  You should ge the same result, unless
    you made a typing error.  In that case look, fix it, and try again.
    
#.  Now try a bit of editing.  Look at the program to see where output came
    from.  Change what is printed and run it, but don't eliminate the console
    window.

#.  Now grab the instructor or teaching assistant so
    they can perform a quick inspection of your work and check it off
    (including the varied message printed).
    
Labs need to be completed to receive
credit. If you are unable to make class on a lab day, please make sure
that you complete the work and demonstrate it by the beginning of the
next lab.

At this point, you have accomplished the major objective for this
introductory lab: to create a MonoDevelop project, and
enter, compile, and run a C# program. 

For further reinforcement
~~~~~~~~~~~~~~~~~~~~~~~~~

#. Can you make a new program variant print out two *separate* lines?
   
#. Download and install Mono Software Development Kit and MonoDevelop on
   your home computer or laptop.  
   
#. You can now add further projects.  To add a new project in your solution,
   *right* click on the solution name in the solution pad, select Add,
   and in the submenu select New project.
   
   You see a window much like when creating a solution, except there is no
   line for a solution name.  Complete the remaining parts in the same
   way, giving a new name for the project.
