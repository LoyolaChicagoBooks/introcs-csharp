.. index::
   double: function; parameter

Multiple Function Parameters
================================

A function can have more than one parameter in a parameter list
separated by commas. Each formal parameter name is preceded by its type.
For example the example program :file:`addition1.cs` 
uses 
a function to make it easy to display many sum problems. Read and
follow the code, and then run:

.. literalinclude:: ../examples/addition1.cs

.. index::
   double: parameter; actual
   double: parameter; formal

The actual parameters in the function call are evaluated left to
right, and then these values are associated with the formal
parameter names in the function definition, also left to right. For
example a function call with actual parameters,
``f(actual1, actual2, actual3)``, calling a function ``f`` with
definition heading::

	static void f(int formal1, int formal2, int formal3)

acts approximately as if the first lines executed inside the called
function ``f`` were ::

	formal1 = actual1; 
	formal2 = actual2; 
	formal3 = actual3;

Functions provide extremely important functionality to programs,
allowing tasks to be defined once and performed repeatedly with
different data. It is essential to see the difference between the
**formal** parameters used to describe what is done inside the function
definition (like x and y in the definition of sumProblem) and the
**actual** parameters (like 2 and 3 or 12345 and 53579)
which *substitute* for the formal parameters when the function is
actually executed. ``Main`` uses three different sets
of actual parameters in the three calls to sumProblem.

.. _QuotientFunctionEx:

Quotient Function Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~

Modify :file:`quotient.cs`from
:ref:`QuotientProblem` and save it
as ``quotientProb.cs``.
You should create a function ``quotientProblem`` with int
parameters.  Like in the earlier versions, it should print a full
sentence with inputs, quotient, and remainder.
``Main``
should test the ``quotientProblem`` function
on several sets of literal values, and also test the function with
input from the user.
