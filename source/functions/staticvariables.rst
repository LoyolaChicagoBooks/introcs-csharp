   
.. index:: constant
   global constant
   scope; class
   class; scope

.. _Static-Variables:

Static Variables
================

You may define *static variables* (variables defined 
with the word ``static`` inside the class,
but *outside* of any function definition). 
These variables are visible inside all of your functions in the class. 
Instead of local scope, static variables have *class scope*.
It is good programming practice generally to avoid defining static variables and
instead to put your variables inside functions and explicitly pass
them as parameters where needed. There are exceptions.  For now a
good reason for using static variables is constants:
A *constant* is a name that you give a fixed data value to. 
If you have a static definition of a constant,
then you can then use the name of the fixed data value in
expressions in any function in the class. 
A simple example program is :repsrc:`constant/constant.cs`:

.. literalinclude:: ../../source/examples/constant/constant.cs

See that ``PI`` is used in two functions without being declared locally.

By convention, names for constants are all capital letters
(and underscores joining multiple words).
