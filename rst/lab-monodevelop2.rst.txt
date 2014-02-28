
.. _lab-monodevelop:

.. index::
   single: labs; MonoDevelop

Lab: Using MonoDevelop
======================


Rationale for this Lab
----------------------

We will later discuss the low level tools for compiling and running a program. 
An *Integrated Development Environment (IDE)* makes that easier.  
We start by introducing the free IDE, MonoDevelop.  Later, when you are more
experienced we will discuss basic commands in a console for building and running.


Goals
-----

Our primary goal to create a C# Solution that you can use to do all of
the remaining homework assignments and labs this semester. If you
wish, you can create as many solutions as you like, but C# allows you
to create a single solution and add (at any time) projects to it. This
will provide by far the best experience for you in the course, where
you can keep adding onto previous efforts without having to start over
each time.

..  use ?
    (As we'll see in this lab, you'll also have a way of making
    *use* of previous work, which is an incredibly powerful concept in
    software engineering that many CS courses and real-world software
    projects depend upon.)


Steps
-----

We start by creating a *solution* with a project in it.


!!! The images are presently out of date.

#. Create a new solution using the following steps:

   - Go File -> New -> Solution

     .. image:: images/lab-monodevelop/FileNewSolution.png
        :height: 400 px
     	:alt: MonoDevelop Image
     	:align: center

   - Select C# in left hand side panel
   - Select Console Project in right hand side panel
   - In the bottom field, "Solution name", 
     enter any name you like:  We recommend **work**.
   - Leave the Location field above it as is or change it if you like.
   - Above that, Enter **hello** for the name (of the project).
   - Make sure *Create directory for solution* is checked in the bottom right.
   - Press the Forward button.
   - At the Project Features form, just press ok.
   - You now have created a solution in MonoDevelop. We can now add further *projects*
     to this *solution*. 

#. Look at the MonoDevelop window that appears.  It should have two main sub-windows or 
   "Pads" as MonoDevelop calls them.  A narrow one on the left is the Solution pad,
   containing a hierarchical view of the solution.  You should see your solution name
   at the top and hello under that.  Folders have a little triangle shown to their 
   left.  You can click on the triangle.  A triangle pointing down, 
   means the inside of the folder is displayed.  A triangle pointing to the right
   means the contents are not being displayed.
   
   A larger file editing pad is to the right, for the file MonoDevelop created,
   main.cs.  If it does not appear, double click on main.cs in the solution pad.  
   you will notice that the starter MonoDevelop
   gives you is a traditional first program, printing "Hello, World!". 
   In the current versions of mono, a new C#
   console project always creates a minimal, functioning program so
   you can test MonoDevelop and Mono for their ability to build a
   working project. 
   
#. Now you can actually *run* the program defined by this project:

   - *Right* click on the hello folder in the solution pad.
   - Select *Build Hello* or *Rebuild Hello*.
   - If the build was successful, which it will be, you will see
     *Build successful.* in the status line.
   - Right click on hello again.
   - Select *Run Item*.
   - If all goes well, you will see a *console* pop up with
     the output from your program.

     .. image:: images/lab-monodevelop/HelloRunOutput.png
        :height: 400 px
     	:alt: MonoDevelop Image
     	:align: center

     Note that what you see here may vary, depending on whether you
     use OS X, Windows, or another platform (Linux).
     
#. The program is a bit generic.  We have the convention of naming
   source file in a one-file project like the project name:
   Right click on main.cs in the solution pad, and select rename.  
   Enter hello (keeping the .cs).
   
   Also rename the class to match in the edit pad.  
   Classes get capitalized:  make ``Hello`` replace ``MainClass``.
   
   This program still has features that were not in :repsrc:`painting/painting.cs`.
   MonoDevelop generates something more general than we need.
   You should see the parameter for the Main function:
   ``string[] args``.  We do not need it 
   (and will not explain the meaning yet for many chapters) so you
   can delete it if you like.
   
   There is also a namespace block.  We will discuss those later, too.
   The ``namespace hello`` and the matching braces, ``{`` on the next line,
   and ``}`` at the end, could also be eliminated for simplicity.
   
   If you make the changes, the program should still run....
    
   
#. You can now add further projects.  To add a new project in your solution,
   *right* click on the solution name in the solution pad, select Add,
   and in the submenu select New project.
   
   You see a window much like when creating a solution, except there is no
   line for a solution name.  Complete the remaining parts in the same
   way, giving a new name for the project, like lab1.


TODO:  redo images, viewing pads, copying files from the examples....
   
..  old - how use?

    #. Create a project for the traditional "Hello, World!" program:
    
       - Place the mouse over the Solution *folder* in the Solution pane
         (on the left hand side).
       - Right click, select Add -> Add New Project
    
         .. image:: images/lab-monodevelop/AddHelloProject.png
            :height: 400 px
            :alt: MonoDevelop Image
            :align: center
    
       - Select C# in the left panel and Console Project in the right
         panel. Enter Hello in the Name field.
       - Press the Forward button.
       - At the Project Features form, just press ok.
       - You'll now see the Hello folder. Click on Hello (beneath the
         Solution) in the left panel and you'll see ``main.cs``. If you
         double click on main.cs, you will notice that the starter MonoDevelop
         gives you is a traditional first program, printing "Hello, World!". 
         In the current versions of mono, a new C#
         console project always creates a minimal, functioning program so
         you can test MonoDevelop and Mono for their ability to build a
         working project.
    
         .. image:: images/lab-monodevelop/BrowseHelloProject.png
            :height: 400 px
            :alt: MonoDevelop Image
            :align: center
    
    #. Now you can actually *run* the program defined by this project:
    
       - Right click on Hello.
       - Select *Build Hello* or *Rebuild Hello*.
       - If the build was successful, which it will be, you will see
         *Build successful.* in the status line.
       - Right click on Hello.
       - Select *Run Item*.
       - If all goes well, you will see the familiar *console* pop up with
         the output from your program.
    
         .. image:: images/lab-monodevelop/HelloRunOutput.png
            :height: 400 px
            :alt: MonoDevelop Image
            :align: center
    
         Note that what you see here may vary, depending on whether you
         use OS X, Windows, or another platform (Linux).
    
    #. Create one or more projects for each of your labs/homework
       assignments. For this last part you will add a project, which can
       make use of code that you wrote in a previous lab or assignment:
    
       - Add a project as we did in step 1.
       - Name your project appropriately. For example, if you want to take
         the first homework assignment and move it to MonoDevelop, you
         could name it Homework1. You could also name it GradeCalc or
         something similar.
       - You don't need to retype the code that you've already created,
         compiled, and run. Instead, you can just open it up in the text
         editor and copy/paste it into the ``main.cs`` file for your new
         project. (You'll first want to delete the "Hello, World!" code
         that MonoDevelop creates *every time* you add a new C# project.
       - You should now have *two* projects: Hello and Homework1 (or
         GradeCalc).
       - Build and Run the program to see whether it works.
    
    
    #. Create a library project for the Input Utilities.
    
       In many of our examples, we have made use of a User Input class like ``UI``. 
    
       - On the solution you have created for your overall project, right
         click and select Add -> Add New Project.
       - Select C# and Library/C#.
       - Enter ``UI`` as the project name and press Forward as
         many times as required to complete the process.
       - You now have a new library project.
       - Remove class named ``my_class.cs``. 
       - Add the class ``UI``
       - As in the previous part, let's check whether our entire solution
         *builds* properly. From the Build menu, select Build All. If you
         encounter any errors, you'll have to correct them.
    
    #. Create a console project that makes use of ``UI`` by
       adding a reference to the Input Utilities library (created in the
       previous step).
    
       Now that we have a library project, we can create another project
       that uses this library. That is, much like when we say ``using
       System`` we now have a way of making use of our own *stuff*. That
       is, we can say ``using InputUtils`` and then call our *input*
       functions.
    
       - Much like we did for the initial ``Hello`` project, we are going
         create a new project called ``InputTesting``. To make sure you
         know how to do this, you must do the ``Add New Project`` like we
         did earlier.
       - Once you have the new project, you need to *reference* the
         library. 
       - In the Solution pane (explorer), you will see a folder named
         References underneath InputTesting. Right click to Edit
         References.
       - If all has gone according to plan, you should see ``UI``
         as an "assembly" (.Net's fancy name for a compiled
         library). Check the checkbox next to UI so we can use it
         in our new project.
    
       - Now click on ``my_class.cs`` in the ``InputTesting`` project and
         do the following:
    
         - Change the namespace to ``IntroCS``.
         - Create a Main() method to prompt the user for any desired input
           (integer, string, etc.) We are just testing whether we can see
           the functions that we referenced in ``UI``.
    
       - As before, you should be able to Build -> Build All and then run
         this simple program. You might want to use a
         ``Console.WriteLine`` to write the variable ``i`` to the
         console. 
    
    So that's it! At this point, you will have a solution with three
    projects. Incidentally, everything we have shown here does also work
    in Microsoft Visual Studio. You may find that the instructions vary
    slightly. Because our course places great emphasis on learning
    computer science on the platform of your choice, we're only doing this
    in Mono and MonoDevelop (for now).
    
    So the next time you have a lab or homework assignment, you can start
    by adding a new project to this existing solution. This will allow
    you to build on ideas we have explored previously. As you become more
    *seasoned* as an introductory computer science student, you will find
    yourself saying, "I think I have done something like this before." If
    properly packaged into a library, you can make use of the code again
    and again in your work, which can be a real time saver!
    