   
.. index::
   double: global; constant

.. _Static-Variables:

Static Variables
================

You may define *static variables* (variables defined inside the class,
but outside of any function definition). 
These variables are visible inside all of your functions. 
Instead of local scope, static variables have *class scope*.
It is good programming practice generally to avoid defining static variables and
instead to put your variables inside functions and explicitly pass
them as parameters where needed. One common exception 
will arise when we get to defining objects.  For now a
good reason for static variables is constants:
A *constant* is a name that you give a fixed data value to. 
You can then use the name of the fixed data value in
expressions anywhere in the class. 
A simple example program is ``constant.cs``:

.. literalinclude:: ../examples/constant.cs

See that ``PI`` is used in two functions without being declared locally.

By convention, names for constants are all capital letters.



