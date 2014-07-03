.. index:: Xamarin Studio
   labs; Xamarin Studio


.. _lab-edit-compile-run:

Lab: Editing, Compiling, and Running with Xamarin Studio
===========================================================================

This first lab is aimed at taking you through the end-to-end process of
writing and running a basic computer program with the Xamarin Studio
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
an integrated tool, like Xamarin Studio, that does them all in the same place,
and automates the steps that do not need human interaction!  

If you are doing this on your own
machine, make sure you have Mono and Xamarin Studio installed as in
:ref:`development-tools`.

Other tools are available, like
the development environment 
Visual Studio (from Microsoft, only for Windows).

Understanding the lower level tools that accomplish each step is important, 
but we defer
a discussion to get you going with Xamarin Studio.

Goals
-----

Our primary goal to create and understand an Xamarin Studio setup
that you can use to do all of
the remaining homework assignments and labs for this course. 


.. index: Xamarin Studio; solution
   Xamarin Studio; project
   
.. _steps:

Steps
-----

Xamarin Studio files and interactions 
are organized hierarchically.  At a low level are
individual C# source code files.  One, or possibly more, are used for a
particular *project*.  Multiple projects are gathered together under a single
*solution*.  Xamarin Studio deals with one solution at a time, though you can
separately create multiple solutions.  The simplest thing is to create
a *single solution for this course*, 
and put each of the projects that you create in that one solution.   
You can keep adding onto previous efforts without having to start over
with a new solution each time.

We start by creating a *solution* with a *project* in it.  The images are from
a Mac.  Windows versions should be similar.

#.  Open Xamarin Studio, in the appropriate way for an application in your
    operating system.  It should be in the Start menu for Windows.
    Using Spotlight is quick on a Mac.

#.  You get a Welcome screen.  Toward the upper left corner is a link for 
    New Solution.  Click on it.  Alternately you can follow the path through the menus:
    File -> New -> Solution.  
   
    ..  image:: images/lab-edit/newSolution.png
     	:alt: Xamarin Studio Start Image
     	:align: center
        :width: 227.25 pt

#. You get a dialog window to fill out.  Follow the order below.  
   Later parts may not be visible until you do the previous parts:

   - Select C# in left hand side panel
   - Select Console Project in the middle panel
   - In the bottom field, "Solution name" (*not* the top Name field),
     enter any name you like:  We recommend **work**, which will make
     sense for all your work for the course.
   - Leave the Location field above it as is or change it if you like.
   - Above that, Enter **hello** in the Name field, for the name of the project.
   - Make sure *Create directory for solution* is checked in the bottom right.
   - Press the OK button.
   
   ..   image:: images/lab-edit/consoleProjectDialog.png
     	:alt: Xamarin Studio Dialog Image
     	:align: center
        :width: 489.3 pt
   
   You now have created a solution in Xamarin Studio, with one project
   inside it. Later we can add further *projects* to *this solution*. 

#. Look at the Xamarin Studio window that appears.  It should have two main sub-windows or 
   "Pads" as Xamarin Studio calls them.  A narrow one on the left is the Solution Pad,
   containing a hierarchical view of the solution.  You should see your solution name
   at the top and the hello project under that.  
   Folders have a little triangle shown to their 
   left.  You can click on the triangle.  A triangle pointing down 
   means the inside of the folder is displayed.  A triangle pointing to the right
   means the contents are not being displayed. Listed under hello are References and
   Properties, that we will ignore for now.  Below them is the line for the automatically
   generated sample code file Program.cs.  
   The file should also appear in the Edit Pad to the right.
   
   ..   image:: images/lab-edit/Program.png
     	:alt: Xamarin Studio Program.cs Image
     	:align: center
        :width: 485.25 pt
   
#. Program.cs should be selected in the Solution Pad, as shown above.  
   Change the selection by clicking on hello. 
   At the right end of the
   highlighted hello entry you should see an icon with a small gear and a triangle.
   Click on it to get the context sensitive popup window.   
   When selected, most entries in the Solution Pad should show this icon,
   allowing you to open its context sensitive menu. 
   
#. Bring up the context menu on the hello project in the Solution Pad.
   Select Run Item.  

   ..   image:: images/lab-edit/runMainMenu.png
     	:alt: Xamarin Studio Run Program.cs Image
     	:align: center
        :width: 389.25 pt
   
    
#.  Here Xamarin Studio combines several steps: saving the file,
    compiling it into an executable program, 
    and starting running it if compilation succeeded.
    With the canned file it should succeed!  You see a Console window
    something like
    
    ..  image:: images/lab-edit/pressKey.png
     	:alt: Xamarin Studio Press Key to close Image
     	:align: center
        :width: 283.5 pt
   
    You have a chance to see the output of this simple program.
    Follow the instructions and press the space or Enter key.
    
#.  On Windows, that kills the window.  **On a Mac, only, there is one more step:**

    ..  image:: images/lab-edit/processComplete.png
     	:alt: Xamarin Studio Process Complete Image
     	:align: center
        :width: 198.75 pt
   
    You have to actively close the Mac terminal window, either by clicking the
    red window closing button, or using the keyboard, with Command-W.

#.  Initially, for immediate practice running a program, this automatically generated
    file, ``Program.cs``, is convenient.  Hereafter it is an annoyance.  
    The file name is always the same, and not useful, 
    and you would need to redo the whole
    code for your own program.  A general approach is to *delete* this
    file and put in a file of your own:
    
    -   Make sure Program.cs is selected in the Solution Pad.
        You save a step by closing the Edit Pad for Program.cs,
        clicking on the X in the Program.cs tab at the top of the Edit Pad.      

    -   In the Solution Pad open the context sensitive menu for Program.cs, and select
        Remove.
    
        ..  image:: images/lab-edit/menuRemoveMain.png
            :alt: Xamarin Studio Remove Program.cs Image
            :align: center
            :width: 326.25 pt
   
    -   You get another popup.  When it appears the right button is selected,
        *but you do not want that selection*, Remove From Project. 
        The image below shows the proper button, the
        *left* button*, **Delete**, being chosen.  
        Otherwise the file is left in the hello
        folder, but it is just not listed as being in the project.
      
        ..  image:: images/lab-edit/sureRemove.png
            :alt: Xamarin Studio Delete Program.cs Image
            :align: center   
            :width: 436.5 pt
            
    -   If you forgot to close the Edit Pad tab containing Program.cs earlier, you can still
        do it, just say not to save changes to the file when asked. 

#. To get in code that you want, there are several approaches.  The one we take
   now is to start from a completely
   new empty file:  Pop up the context sensitive menu for the hello project.
   Select the submenu Add...  and  then New File....  

   ..   image:: images/lab-edit/addNewFileMenu.png
     	:alt: Xamarin Studio Add new file Image
     	:align: center
        :width: 468.75 pt

#. In the popup New File Dialog Window, click on Empty File (not Empty *Class*).  
   Enter the name hello.cs.
   Click the New button.
   
   ..   image:: images/lab-edit/makeEmptyFileDialog.png
     	:alt: Xamarin Studio Add empty file Image
     	:align: center
        :width: 427.5 pt
   
#. This should add hello.cs to the hello project and open an editing window for hello.cs.
   The file should have no text.
   
   ..   image:: images/lab-edit/editEmptyHello.png
     	:alt: Xamarin Studio edit empty file Image
     	:align: center
        :width: 272.25 pt
   
   
   Much like in most word processors type in (or paste) 
   the following code.  This is actually an equivalent
   *Hello, World!* program to the automatically generated one,
   but it is a bit shorter.  
   It only introduces the syntax we actually *need* at the beginning,
   and will be discussing more shortly:
    
   ..  literalinclude:: ../source/examples/hello/hello.cs
       :language: csharp
       :linenos:
   
   This program is deliberately simple, so you can type it into the text
   editor quickly and become familiar with how
   to create, edit, and save a program. 
            
   ..   image:: images/lab-edit/pasteHello.png
     	:alt: Xamarin Studio Edited new file Image
     	:align: center
        :width: 274.5 pt
   
#.  You can run the project just as before.  You should ge the same result, unless
    you made a typing error.  In that case look, fix it, and try again.
    
#.  Now try a bit of editing:  Look at the program to see where output came
    from.  Change what is printed and run it, but don't eliminate the console
    window (so you can show it off).

#.  Now grab the instructor or teaching assistant so
    they can perform a quick inspection of your work and check it off
    (including the varied message printed).
    
Labs need to be completed to receive
credit. If you are unable to make class on a lab day, please make sure
that you complete the work and demonstrate it by the beginning of the
next lab.

At this point, you have accomplished the major objective for this
introductory lab: to create a Xamarin Studio project, and
enter, compile, and run a C# program. 

For further reinforcement
~~~~~~~~~~~~~~~~~~~~~~~~~

#. Can you make a new program variant print out two *separate* lines?
   
#. Download and install Mono Software Development Kit and Xamarin Studio on
   your home computer or laptop.  
   
#. You can now add further projects to your *current* solution.  
   To add a new project in your solution, in the Solution Pad open the context
   sensitive menu for the whole solution (top line), select Add,
   and in the submenu select New project.
   
   You see a window much like when creating a solution, except there is no
   line for a solution name.  Complete the remaining parts in the same
   way, giving a new name for the project.
