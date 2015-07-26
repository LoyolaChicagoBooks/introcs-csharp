.. index:: library class
   multiple source files using library class

.. _library-classes:

Library Classes
========================

.. index::
   library; UIF
   
In :ref:`Returned-Function-Values`, the suggestion was made to look at 
the Painter class and split out repeated ideas into functions, leading to
a function to prompt the user and return a double value.  
The same section included
the example program :repsrc:`addition2/addition2.cs`.  
In that case there were repeated prompts for 
integers.  Clearly another common situation is to prompt for a string.  
We can create 
functions to do all these things and more, and embed them into a class 
specially written for a new
interactive program.  

A neater thing is to put them as a class in a separate library
that can be used directly for multiple programs.  We can create functions 
``PromptLine``,
``PromptInt``, and  ``PromptDouble``, and put them in their own class, ``UIF`` 
(for User Input First version)
in project ui's file :repsrc:`uif.cs <ui/uif.cs>`.  
We explain the namespace line after the code:

.. literalinclude:: ../../source/examples/ui/uif.cs

.. index:: namespace
   IntroCS namespace 

We have been ``using System`` in every program.  ``System`` is a *namespace* that 
collects a particular group of class names, making them available to the program,
and distinguishes them form any classes in a different namespace that might have the 
same class names.  

Once we start writing and using multiple classes at once, it is a good idea for us to 
specify our own namespace.  We will consistently use ``IntroCS`` in our multi-file
examples in this book.  

.. index:: public

Specifying a namespace makes it possible for all other classes in the 
same namespace to reference *public* parts of the current class, and vice-versa.

Public classes and functions start their heading with ``public``.

The code included in a namespace is enclosed in braces, so the general syntax is 

   | ``namespace`` *name* 
   | ``{``
   |     class definition(s)...
   | ``}``   

We will keep user input library classes like this one, :repsrc:`uif.cs <ui/uif.cs>`, 
in a project ui.

Notice that the functions we want accessible in ``UIF`` 
are all marked ``public``, so that any class can use them.

We can write a modified example addition program, :repsrc:`addition3/addition3.cs`,
as an example of using ``UIF``:

.. literalinclude:: ../../source/examples/addition3/addition3.cs

To allow access to UIF, we have added the IntroCS namespace for the class.
To reference the static functions in the different class ``UIF``, we put ``UIF.``
(with the dot) at the start of each reference to a static function in 
the class ``UIF``.

.. warning::

   In Xamarin Studio, if you use a file from a library project (without
   just copying the present version of that file into the current project), 
   be sure that the current project includes 
   a *reference* to the library project. 
   If you expand the references in the Xamarin Studio 
   project addition3, by clicking on the References line in the solution pad, 
   you should see the project ui.  

Shortly you will see the optional section for making your own 
:ref:`library-projects-in-xamarinstudio`.   

Though we have not discussed all the C# syntax needed yet, there is also an 
improved class ``UI`` in the ui project that we discuss later.
It includes all the function
names in ``UIF``, and keeps your program from bombing out
if the user enters an illegal format for a number.

.. index:: documentation of functions
   function; documentation ///
   single: /// documentation
   
.. _function-documentation:

Function Documentation
----------------------

In keeping with :ref:`Two-Roles`, in future you will be a *consumer* of the library
classes.  It is particularly important to document library classes with the 
interface information users will need.  
Documentation could be written in a separate document, but much developer history has
shown that such documentation does not tend to either get written in the first place,
or not updated well to stay consistent with updates in the code.  
Inconsistent documentation is useless.  Documentation is much more
likely to be seen and maintained by the implementers if it sits right with the
code, like our comments before the class and function headings.

You will note that instead of the usual line comment syntax ``//``, we have added
an extra ``/``, making ``///``.  That will also start a comment.  (The third ``/`` 
is technically just a part of the comment.)  There is a special reason for the 
notation:  Though it is convenient for the *implementer* of code to have the documentation
right with the code, a *user* of the functions only needs the interface information
found in good documentation.  The ``///`` lines before heading are specially recognized
by *separate* automatic documentation generating programs.  

There are many documentation
generating programs and conventions.  
For now we will just use plain text in the ``///`` lines.
This is recognized by the Xamarin Studio system. If you open our ``examples`` solution,
in Xamarin Studio, and edit window for
:repsrc:`addition3/addition3.cs`,
you can place your mouse over ``UIF`` and a popup window shows the ``UIF`` class heading
documentation.  

If you move the mouse over ``PromptInt``, you should see the popup label showing 
the function signature and the function documentation.  
If you change the two ``///`` lines
in ``uif.cs`` above the ``PromptInt`` heading to start with just ``//``. 
you should no longer be able to see the documentation part of the popup for 
``PromptInt`` in the ``addition3.cs`` edit window. (Be sure to change back to ``///``.)

There are more elaborate documentation conventions that can be used for
Xamarin Studio and other documentation generation programs, not discussed here.  

This documentation also works inside a single program file.  If you have a long 
program with lots of functions defined, this can also be helpful when calling
one of your own functions.  You can avoid jumping
around to be reminded of the signature and use of your functions.

.. _library-projects-in-xamarinstudio:

Library Projects in Xamarin Studio (Optional)
------------------------------------------------

Xamarin Studio has a multi-step process for 
creating a library project and for separately
referencing it in other projects.  The *advantage* of this approach is when you
want to change the implementation but not the interface to library functions, 
you just do it once, in the library project.  
Other projects reference that project.

Some students find the Xamarin Studion overhead of setting up and referencing 
library projects onerous.
As a  practical matter with files that you want to reuse but are not likely to change, 
you can just copy the source file into the new project, and avoid the 
Xamarin Studio library setup overhead.  
Many of our already created example projects use a library version
of UIF and several other utility files.  You can do the same with your solutions, 
following the instructions below, or you can just copy in the needed utility
files for each project.

Hence the rest of the section here is *optional*:

Try adding a reference yourself.  Follow these instructions:

#.  In your own Xamarin Studio solution, start to add a project, 
    but *instead* of leaving
    Console Project selected in the dialog window, select **Library Project**.
    
#.  Then add the project name ui, and continue like when starting 
    previous projects.
    
#.  Copy in the ``.cs`` files from
    our ui project, :repsrc:`uif.cs <ui/uif.cs>` and :repsrc:`ui.cs <ui/ui.cs>`.
    Now you have your library project.

#.  Create another regular Console project, addition3, in your *same* solution, 
    and copy in our :repsrc:`addition3/addition3.cs`, so that is the only file.
    
    .. warning::
       Xamarin Studio remembers the last kind of project you created.
       That is fine when you are creating a sequence of Console projects.
       However, if you have just explicitly chosen to create a library 
       project, the default for your next project will also be library,
       and really mess up your next Console project.  Fix such an error
       after the fact as in the first 
       entry in :ref:`xamarinstudio-reminders`. 
    
#.  In the Solutions pad, in your addition3 project,
    click on the References entry just inside the project.
    You should see that the project is automatically set up to reference System.
    
#.  Open the local menu for the References, and select Edit References.

#.  Click the Projects tab in the window that pops up.  This limits the length 
    of the list that you search.
    
#.  Possibly after scrolling down, find the recently made ui project and
    check the box beside it.
    
#.  Click OK in the bottom right corner of the window.
    Now look at the References again.  You should see ui listed!
    
#.  Run your addition3 project.

You only need to add a library project once, 
but every further project that needs it,
must have a *reference* to the library project added.  
You might try another for yourself
with the next exercise!  

Again this approach allows you to change the implementation of
your library class in just one copy in one project, 
which can be referenced from many places.  
If you copy the file into different projects, and then decide the code 
needs to be updated, you are stuck *finding* and editing *all* the copies!
Not good.  Our library files uif.cs, ui.cs, and later fio.cs, 
should not be moving targets, so copying should not cause a problem.  This
may simplify your life, but the tradeoff is not getting used to using
library references, which are useful in the larger scheme of things.


.. _QuotientUIEx:
	
Quotient UI Exercise
---------------------------------

Create :file:`quotient_u_i.cs` by modifying :file:`quotient_return.cs` in
:ref:`QuotientStringEx` so that the program accomplishes the same
thing, but use the UIF class for all user input.
