.. index:: IComparable Interface
   interface; IComparable
   
.. _rationals-revisited:

Rationals Revisited
=====================

C# has a built-in method to sort a List.  ``List`` is a
generic type, however, so how does C# know how to do 
comparisons for all different types?  Is this
specially programmed in for built-in types, or
can it be extended to user-defined types?

In fact it can be extended to user defined types,
such as our Rational.
To sort objects, you only need to be able to do one
thing: indicate which object comes before another.
We can do that.  The ``CompareTo`` method
already does that.  If Rational r1 is less than
Rational r2, then  ::

    r1.CompareTo(r2) < 0
    
The single CompareTo method is very versatile:  Just by varying
the comparison with 0, you vary the corresponding 
comparison of Rationals:

| ``r1.CompareTo(r2) < 0`` means r1 < r2
| ``r1.CompareTo(r2) <= 0`` means r1 <= r2
| ``r1.CompareTo(r2) > 0`` means r1  > r2
| ``r1.CompareTo(r2) >= 0`` means r1 >= r2
| ``r1.CompareTo(r2) == 0`` means r1 is equal to r2
| ``r1.CompareTo(r2) != 0`` means r1 is not equal to r2
  
None of the other methods for Rationals make any difference for
sorting:  Just this one method is needed.  Of course the
comparison of strings or doubles are done with 
totally different implementations, but they have methods
with the same name, ``CompareTo``, and with the same abstract
meaning.  Still C# is strongly typed and we are talking about
totally different types.

An *interface* allows us to group diverse classes under one
interface type.  An interface just focuses on the commonality of behavior
in one or more methods among the different classes.  
Interface types, like classes can also be generic.
For sorting we are only concerned 
with one method, ``CompareTo``.  We want it to be able to compare to another
object of the same type.  

C# defines a generic interface ``IComparable<T>``.  A type T can satisfy this interface if
if has a public instance method with signature::

	   public int CompareTo(T other);

.. index:: :; in class heading

There is one more step before we can use a library method to sort:  
Although the signature shown above for ``CompareTo`` is the
one that C# requires to be able to satisfy the ``Icomparable<T>`` interface, 
it does not
automatically assume that this is your *intention*.  
You must explicitly say that you *want* your class
to be considered to satisfy this interface.  
For instance for Rational, we need to change
the class heading to::

   public class Rational : IComparable<Rational>

In general one or more interface names can be listed 
after the class name and a colon,
and before the opening brace of the class body.  
This particular interface is defined in
System.Collections.Generic, so we need to be using that namespace.

The project :repsrc:`interfaces` 
has the modified :repsrc:`rational.cs <interfaces/rational.cs>` 
and :repsrc:`test_rational_sort.cs <interfaces/test_rational_sort.cs>`
to test this with a list of Rationals:
   
.. literalinclude:: ../../examples/introcs/interfaces/test_rational_sort.cs

which prints:

..  code-block:: none

    Before sorting: 1/2 11/3 -1/10 2/5 2/3 1/3 
    After sorting:  -1/10 1/3 2/5 1/2 2/3 11/3 


.. index:: interface; hides actual underlying type

Interfaces are very handy for dealing with the *common* abstract behavior of
different objects and different underlying class, but if an object is 
declared to be of interface type the compiler no longer sees the attributes
that are *not* common to the interface.  A silly example, legal as far
as it goes::

   IComparable<Rational> r1 = new Rational(2,5), 
                         r2 = new Rational(1, 2);
   Console.WriteLine(r1.CompareTo(r2) > 0); // prints false

The declarations are legal because a Rational does have interface type
``IComparable<Rational>``.  The use of ``CompareTo`` is legal 
because that is the one method that this interface type guarantees.

However, if we add this extra line::

   Console.WriteLine(r1.Multiply(r2)); // compiler error!  
    
Even though r1 and r2 are actually Rational underneath, where the
Multiply method is legal, their declaration as only their interface type
*hides* this extra functionality from the compiler. [#actualType]_

..  [#actualType]

    It is possible to deal with the actual underlying class type, but this gets 
    more complicated.  It is better discussed in a course that more fully
    explores *inheritance*. 

.. index:: interface; syntax examples

.. _interface-syntax-examples:

Interface Syntax Examples
--------------------------

In the previous section we showed a realistic application of an existing
interface.  It was in a fairly sophisticated class with a lot of other things
included.  Now you can look at examples that are designed to highlight syntax 
for interfaces without distractions.  They are very simple and artificial.

There is a comment at the bottom of each file explaining the new
features introduced.  Like all our other examples, they compile and
run as given.  After running an example, see if the notes
include instructions to delete or comment out parts or
uncomment lines.  If so, follow instructions and try to compile again.  
Check that the change causes a compiler error.  

Look through and process these examples in order:

:repsrc:`interface_syntax1/interface_demo1.cs`,
:repsrc:`interface_syntax2/interface_demo2.cs`,
:repsrc:`interface_syntax3/interface_demo3.cs`,
:repsrc:`interface_syntax4/interface_demo4.cs`,
:repsrc:`interface_syntax5/interface_demo5.cs`,
:repsrc:`interface_syntax6/interface_demo6.cs`,
:repsrc:`interface_syntax7/interface_demo7.cs`,
:repsrc:`interface_syntax8/interface_demo8.cs`


After looking at those simple bare examples illustrating the syntax, 
go on to the next section :ref:`csproject-revisited`,
where a useful, more sophisticated user-defined interface
is introduced....

Example Class Sorting - Worked Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

In :ref:`more-getters-and-setters` we introduced example
:repsrc:`example_class/example_class.cs`.

Elaborate the code for the ``Example`` class, adding
a ``CompareTo`` method. 
The rules for comparison are:

#.  An object
    with a larger ``n`` value is considered larger.
#.  If the ``n`` 
    values are the same, then the object with the larger ``d`` 
    value is considered larger.  
#.  If they completely match, then they are equal, of course.

Modify the ``Main`` driver to merely test sorting:
create and sort a list of ``Example``
elements.  Show the before and after sequence in the list.

You can compare your solution to ours:
:repsrc:`example_class2/example_class2.cs`.    

