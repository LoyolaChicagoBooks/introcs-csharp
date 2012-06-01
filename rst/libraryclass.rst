.. index::
   double: multiple source files; library class

.. _library-classes:

Library Classes
========================

In :ref:`Returned-Function-Values`, the suggestion was made to look at 
the GlazerCalc class and split out repeated ideas into functions, leading to
a function to prompt the user and return a double value.  The same section included
the example program :file:`addition2.cs`.  In that case there were repeated prompts for 
integers.  Clearly another common situation is to prompt for a string.  We can create 
functions to do all these things and more, and embed them into a class for an
interactive program.  
A neater thing is to put them into a separate library class
that can be used directly for multiple programs.  We can create functions ``PromptLine``,
``PromptInt``, and  ``PromptDouble``, and put them in their own class, ``UIF`` 
in file :file:`uif.cs`.  We explain the namespace line after the code:

.. literalinclude:: ../examples/intro_cs_lib/uif.cs

.. index:: 
   double namespace; IntroCS

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

We will keep library classes like this one, :file:`uif.cs`, 
in directory :file:`examples/intro_cs_lib`.

Notice that the functions we want accessible in ``UIF`` 
are all marked ``public``, so that any class can use them.

We can write a modified example addition program, :file:`addition3.cs`,
as an example of using ``UIF``:

.. literalinclude:: ../examples/addition3.cs

To allow access to UIF, we have added the IntroCS namespace for the class.
To reference the static functions in the different class ``UIF``, ``UIF.``
is the start of each reference to a static function in ``UIF``.

If you run the generic nant build script from the examples directory,
it is set up to automatically allow the use of 
files in the directory :file:`examples/intro_cs_lib`, so our class ``UIF`` can
be used freely.  We will use in future examples without special note, and
you may use it too, for programs you add to the examples directory.  

Though we have not discussed all the C# syntax needed yet, there is also an 
improved class ``UI`` that may be used: It includes all the function
names in ``UIF``, and keeps your program from bombing out
if the user enters an illegal format for a number.

.. _QuotientUIEx:
	
Quotient UI Exercise
---------------------------------

Create :file:`quotientUI.cs` by modifying :file:`quotientReturn.cs` in
:ref:`QuotientStringEx` so that the program accomplishes the same
thing, but use the UIF class for all user input.
