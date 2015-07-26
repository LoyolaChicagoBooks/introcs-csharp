.. index:: function; parameter
   parameter 

.. _more-func-param:

Multiple Function Parameters
================================

A function can have more than one parameter in a parameter list.  The 
list entries are
separated by commas. Each formal parameter name is preceded by its type.
The example program :repsrc:`addition1/addition1.cs` 
uses 
a function, ``SumProblem``,  with two parameters
to make it easy to display many sum problems. Read and
follow the code, and then run:

.. literalinclude:: ../../source/examples/addition1/addition1.cs

.. index:: parameter; actual and formal
   actual parameter 
   formal parameter 

The actual parameters in the function call are evaluated left to
right, and then these values are associated with the formal
parameter names in the function definition, also left to right. For
example a function call with actual parameters,
``F(actual1, actual2, actual3)``, calling a function ``F`` with
definition heading::

	static void F(int formal1, int formal2, int formal3)

acts approximately as if the first lines executed inside the called
function ``F`` were ::

	formal1 = actual1; 
	formal2 = actual2; 
	formal3 = actual3;

Functions provide extremely important functionality to programs,
allowing tasks to be defined once and performed repeatedly with
different data. It is essential to see the difference between the
**formal** parameters used to describe what is done inside the function
definition (like x and y in the definition of SumProblem) and the
**actual** parameters (like 2 and 3 or 12345 and 53579)
which *substitute* for the formal parameters when the function is
actually executed. ``Main`` uses three different sets
of actual parameters in the three calls to SumProblem.

.. warning::

   It is easy to confuse the heading in a function *definition* and a *call*
   to actually execute that function.  Be careful.  In particular,
   do *not* list the types of parameters
   in a call's *actual* parameter list.  The actual parameters are expressions 
   involving terms that are *already defined*, not just being declared. 

.. _QuotientFunctionEx:

Quotient Function Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~

Modify :file:`quotient_format.cs` from
:ref:`QuotientFormat` and save it
as ``quotient_prob.cs``.
You should create a function ``QuotientProblem`` with ``int``
parameters.  Like in the earlier versions, it should print a full
sentence with inputs, integer quotient, and remainder.
``Main``
should test the ``QuotientProblem`` function
on several sets of literal values, and also test the function with
input from the user.


