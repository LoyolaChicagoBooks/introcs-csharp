.. index:: library; UI
   UI library class
   
.. _UI:

User Input: UI
_________________

With the exercises in the last section, we have all we need for a much improved
User Input library class.  This will be the class ``UI``.  
We have the original ``PromptLine``, improved ``PromptInt``,
``PromptDouble``, ``PromptIntInRange``, ``PromptDoubleInRange``, ``Agree``,
and assorted supporting functions.  
The only changes to individual methods were to make
sure that the static methods are public.

Henceforth we will be using ``UI`` in place of ``UIF``.  In fact all the places ``UIF``
was used before could be replaced by ``UI``:  
It includes all the functionality of ``UIF``.

You can look at the code all together in :repsrc:`ui/ui.cs`.

There are even fancier ways of arranging for legal numeric input.  
We have only been reading whole lines, but it is possible to read
individual characters with ``Console.ReadKey``,  
without a newline being entered yet.  A much more extensive advanced
subject is the special regular expression language for 
describing arbitrary patterns in strings using the ``Regex`` class.  
Though we will not discuss the details, another slick replacement for UI 
using these features is in the example class :repsrc:`uifnt/UIFNT.cs`. 