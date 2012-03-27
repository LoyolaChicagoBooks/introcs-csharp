Fractions Revisited
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
We can do that.  The CompareTo method
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
  
None of the other mehtods for Rationals make any difference for
sorting:  Just this one method is needed.  Of course the
comparison of strings or doubles are done with 
totalluy idfferent implementations, but they have methods
with the same name, CompareTo, and with the same abstract
meaning.  Still C# is strongly typed and we are talking about
totally different types.

An *interface* allows us to group diverse classes under one
interface type.  An interface just focuses on the commonality of behavior
in one or more methods among the different classes.  In this case we are only concerned 
with one method, CompareTo.  We want it to be able to compare to another
object of the same type.  

C# defines an interface ``IComparable<T>``.  A type T can satisfy this interface if
if has a public instance method with signature::

	   public int CompareTo(T other);

There is one more step before we can use a library method to sort:  Although this is the
name that C# requires to be able to satisfy the ``Icomparable<T>`` interface, it does not
automatically assume that is your intention.  You must explicitly say you want your class
to be considered to satisfy this interface.  For instance for Rational, we need to change
the class heading to::

   public class Rational : IComparable<Rational>

In general one or more interface names can be listed after the class name and a  colon,
and before the opening brace of the class body.  This particular interface is defined in
System.Collections.Generic, so we ned to be using that namespace.

Project :file:`Interfaces/Rational` has the modified Rational and a :file:`Main.cs`
to test this with a list of Rationals.  This program:
   
.. literalinclude:: ../projects/Interfaces/Rational/Main.cs

which prints:

   | 11/3 2/5 2/3 1/3 
   | 1/3 2/5 2/3 11/3 
