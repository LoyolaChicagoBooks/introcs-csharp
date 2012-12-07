.. _lab-monodevelop:

.. index::
   single: labs; MonoDevelop

Lab: Using MonoDevelop
======================


Rationale for this Lab
----------------------

Now that we have developed basic fluency in editing, compiling, and
running programs, we are now going to start using something called the
*integrated development environment* (the IDE). Professional software
developers generally prefer the IDE, because the IDE does for software
development what a word processor does for writing. That said, a word
processor won't make you a better writer but will help you to avoid
some of the pitfalls that plague writers: spelling, grammar, and
style, among other formatting features. When it comes to programming,
you've already learned that working at the command line can be an
exercise in frustration. You will often make basic syntax errors or
forget to do something "grammatically" like declaring a variable or
not using a particular feature of the language properly. It can be
tricky to fix errors, especially when the error output scrolls beyond
the visible terminal area. While there are ways to work around these
issues, the use of an IDE is far more efficient and allows us to
maintain our collective sanity.

So the IDE is here to help you, and it is now time to start using it
for our labs, homework, and (eventually) your project. You might
wonder why we don't teach it from the beginning. The rationale is
simple. You need to know the basics of how a program is put together
and run. It is part of learning to think like a computer scientist and
software developer. Furthermore, we want to be able to assume that you
know at least one of the *basics*: executable programs and how to run
them. When we compile a Mono program, we get an output file named
*Name*.exe, where this *Name* can be anything, say,
``HelloWorld.exe``. When we use the IDE, MonoDevelop, we'll still be
getting this executable and be able to run it either within our
outside of MonoDevelop.

Goals
-----

In this lab, we're going to set the table for the rest of the
course. So please do whatever you can to complete each part. It is
entirely possible we will spend two lab periods working on this lab.

Our primary goal to create a C# Solution that you can use to do all of
the remaining homework assignments and labs this semester. If you
wish, you can create as many solutions as you like, but C# allows you
to create a single solution and add (at any time) projects to it. This
will provide by far the best experience for you in the course, where
you can keep adding onto previous efforts without having to start over
each time. (As we'll see in this lab, you'll also have a way of making
*use* of previous work, which is an incredibly powerful concept in
software engineering that many CS courses and real-world software
projects depend upon.)

We're going to create a solution that will contain (at least) three different
projects:

#. A project that contains our familiar Hello, World example. This
   will be used to make sure that everyone can create something that 
   works, much like we did in the first lab.

#. A project that contains the user input functions of ``UIF`` that we have been
   using in various examples.

#. A project that makes use of the *input* functions. This project 
   can contain whatever code you like, including your homework 
   assignment. This project will use something called a *reference* 
   to make use of the *input* library.


Steps
-----

So let's begin. We'll start by creating a *solution* and add projects
to it one at a time.

#. Create a new blank solution using the following steps:

   - Go File -> New -> Solution

     .. image:: images/lab-monodevelop/FileNewSolution.png
        :height: 400 px
     	:alt: MonoDevelop Image
     	:align: center

   - Select C# in left hand side panel
   - Select Empty Project in right hand side panel
   - Leave the Location field as is.
   - Enter any solution name you like (we recommend Last name, First name,
     followed by 170, e.g. ThiruvathukalGeorge170) in the Name field.
   - For the Solution name
   - Make sure *Create directory for solution* is checked.
   - Press the Forward button.
   - At the Project Features form, just press ok.
   - You now have created your first empty solution in MonoDevelop. We can now add *projects*
     to this *solution*. Because your project is empty, it won't
     actually do anything until we add some *projects* to it.

#. Create a project for the familiar "Hello, World!" program:

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
     double click on main.cs, you will notice the familiar "Hello,
     World!" program. In the current versions of mono, a new C#
     console project always creates a minimal, functioning program so
     you can test MonoDevelop and Mono for their ability to build a
     working project.

     .. image:: images/lab-monodevelop/BrowseHelloProject.png
        :height: 400 px
     	:alt: MonoDevelop Image
     	:align: center


   Now you can actually *run* the program defined by this project:

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
x