.. index::
   double: library; UI
   
.. _UI:

User Input: UI
_________________

With the exercises in the last section, we have all we need for a much improved
User Input library class.  This will be the class ``UI``.  
We have the original ``PromptLine``, improved ``PromptInt``,
``PromptDouble``, ``PromptIntInRange``, ``PromptDoubleInRange``, ``Agree``,
and assorted supporting functions.  The only changes to individual methods were to make
sure that the static methods are public.

Henceforth we will be using ``UI`` in place of ``UIF``.  In fact all the places ``UIF``
was used before could be replaced by ``UI``:  
It includes all the functionality of ``UIF``.

You can look at the code all together in :file:`examples/intro_cs_lib/ui.cs`.

The functions are still not perfect:  
It is possible to blow things up by entering too long an integer.
Though that could be addressed with our present technology, 
it probably makes sense to wait for an introduction
of Exception handling syntax to really make things bulletproof.
Meanwhile you have good examples of interactive loops and string manipulation.