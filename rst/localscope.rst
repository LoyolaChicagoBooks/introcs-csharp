
.. index::
   double: local; scope

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

The context for ``x`` is the function ``F``, not ``Main``.
We will fix this error below. 

If you do want local data from one function to go to another,
define the called function so it includes parameters! Read and
compare and try the program :repsrc:`good_scope/good_scope.cs`:

.. literalinclude:: ../source/examples/good_scope/good_scope.cs

With parameter passing, the parameter name ``x`` in the function
``F`` does not need to match the name of the actual parameter in
the calling function ``Main``. The definition of ``F`` could just as well have been::

   static void F(int whatever)
   {
      Console.WriteLine(whatever);
   }
