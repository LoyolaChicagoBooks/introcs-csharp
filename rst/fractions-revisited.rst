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
   
.. literalinclude:: ../source/examples/interfaces/test_rational_sort.cs

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

   IComparable<Rational> r1 - new Rational(2,5), 
                          r2 - new Rational(1, 2);
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
