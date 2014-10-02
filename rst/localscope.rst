
.. index:: local variables' scope
   scope; local

.. _Local-Scope:

Local Scope
============

For the logic of writing functions, it is important that the writer
of a function knows the names of variables inside the function. On
the other hand, if you are only using a function, maybe written by
someone unknown to you, you should not care what names are given to
values used internally in the implementation of the function you
are calling. C# enforces this idea with *local scope* rules:
Variable names initialized and used inside one function are
*invisible* to other functions. Such variables are called *local*
variables. For example, an elaboration of the earlier program
:repsrc:`return2/return2.cs` might have its ``lastFirst`` function with its local
variable ``separator``, but it might also have another function
that defines a ``separator`` variable, maybe with a different value
like ``"\n"``. They would not conflict. They would be 
independent. This avoids lots of errors!

For example, the following code in the example program
:repsrc:`bad_scope/bad_scope.cs` causes a compilation error. 
Read it and try to run it, and see:

.. literalinclude:: ../source/examples/bad_scope/bad_scope.cs

The compilation error that Mono gives is pretty clear:

    The name 'x' does not exist in the current context.

The the error occurs in the function ``F``.  The *context* there just includes 
the local variables already declared in ``F``.  And ``x`` is declared in  
``Main``, not in ``F``, so it *does not exist* inside ``F``.
We will fix this error below. 

If you do want local data from one function to go to another,
define the called function so it includes parameters! Read and
compare and try the program :repsrc:`good_scope/good_scope.cs`:

.. literalinclude:: ../source/examples/good_scope/good_scope.cs

With parameter passing, the parameter name ``x`` in the function
``F`` does not need to match the name of the actual parameter in
the calling function ``Main``. (Just the ``int`` value is passed.) 
The definition of ``F`` could just as well have been::

   static void F(int whatever)
   {
      Console.WriteLine(whatever);
   }
   
.. warning::
   It is a very common error to declare a variable in one function
   and try to use it by name in a different function.  If you get
   an error about a variable not existing, look to see where it was
   declared (or if you remembered to declare it at all)!

In general the *scope* of a variable is
the places in the program where its value can be referenced and used.  
The scope of a local variable is just inside
the function where it is declared.  