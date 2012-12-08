.. index::
   double: multiple source files; library class

.. _library-classes:

Library Classes
========================

.. index::
   library; UIF
   
In :ref:`Returned-Function-Values`, the suggestion was made to look at 
the Painter class and split out repeated ideas into functions, leading to
a function to prompt the user and return a double value.  The same section included
the example program :repsrc:`addition2/addition2.cs`.  In that case there were repeated prompts for 
integers.  Clearly another common situation is to prompt for a string.  We can create 
functions to do all these things and more, and embed them into a class for an
interactive program.  
A neater thing is to put them as a class in a separate library
that can be used directly for multiple programs.  We can create functions ``PromptLine``,
``PromptInt``, and  ``PromptDouble``, and put them in their own class, ``UIF`` 
in project ui's file :repsrc:`uif.cs <ui/uif.cs>`.  
We explain the namespace line after the code:

.. literalinclude:: ../source/examples/ui/uif.cs

.. index:: 
   double: namespace; IntroCS

We have been ``using System;`` in every program.  ``System`` is a *namespace* that 
collects a particular group of class names, making them available to the program,
and distinguishing any classes in a different namespace that might have the 
same class names.  

Once we start writing and using multiple classes at once, it is a good idea for us to 
specify our own namespace.  We will consistently use ``IntroCS`` in our multi-file
examples in these notes.  

Specifying a namespace makes it possible for all other classes in the 
same namespace to reference *public* parts of the current class, and vice-versa.

The code included in a namespace is enclosed in braces, so the general syntax is 

   | ``namespace`` *name* 
   | ``{``
   |     class definition(s)...
   | ``}``   

We will keep user interface library classes like this one, :repsrc:`uif.cs <ui/uif.cs>`, 
in a project ui.

Notice that the functions we want accessible in ``UIF`` 
are all marked ``public``, so that any class can use them.

We can write a modified example addition program, :repsrc:`addition3/addition3.cs`,
as an example of using ``UIF``:

.. literalinclude:: ../source/examples/addition3/addition3.cs

To allow access to UIF, we have added the IntroCS namespace for the class.
To reference the static functions in the different class ``UIF``, we put ``UIF.``
(with the dot) at the start of each reference to a static function in 
the class ``UIF``.

.. warning::

   If you use a file from a library project, be sure that the current project includes 
   a *reference* to the file. If you expand the references in the MonoDevelop 
   project addition3, you should see the project ui.  
   
Though we have not discussed all the C# syntax needed yet, there is also an 
improved class ``UI`` in the ui project that we discuss later.
It includes all the function
names in ``UIF``, and keeps your program from bombing out
if the user enters an illegal format for a number.

Library Projects in MonoDevelop
----------------------------------------

Try adding a reference yourself.  Follow these instructions:

#.  In your own MonoDevelop solution, start to add a project, but *instead* of leaving
    Console Project selected in the dialog window, select **Library Project**.
    
#.  Then add the project name ui, and continue like when starting previous projects.
    
#.  Copy in the files from
    our ui project, :repsrc:`uif.cs <ui/uif.cs>` and :repsrc:`ui.cs <ui/ui.cs>`.
    Now you have your library project.

#.  Create another regular Console project in your *same* solution, addition3, and copy in
    our :repsrc:`addition3/addition3.cs`, so that is the only file.
    
#.  In the Solutions pod, in your addition3 project,
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

You only need to add a library project once, but every further project that needs it,
must have a reference to the library project added.  You might try another for yourself
with the next exercise!

.. _QuotientUIEx:
	
Quotient UI Exercise
---------------------------------

Create :file:`quotient_u_i.cs` by modifying :file:`quotient_return.cs` in
:ref:`QuotientStringEx` so that the program accomplishes the same
thing, but use the UIF class for all user input.
