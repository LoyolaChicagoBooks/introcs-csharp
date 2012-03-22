.. index::
   double: value object; reference object
   double: value object; struct
   

.. _classes-and-structs:

Classes And Structs
======================


Everything we have said so far about structs such an ``Rational`` applies to
classes also!  In fact you could change ``struct`` into ``class`` in the heading for
Rational, and it would become a class! ::

	public class Rational
	{
	   // ...
	}

So why the distinction?  We have mentioned that new objects created in a class are 
accessed indirectly via a reference, as with an array.  As a general category,
they are called *reference objects*.  We distinguished the types ``int`` and 
``double`` and ``bool``, where the actual value of the data is stored in the space 
for a variable of the type.  They are *value objects*.  A struct is also a value
object.  In practice this is efficient for small objects.  We made a good choice to make
Rational a struct, since it only contains two integers.  Its size is no more than one double.

The behavior of a Rational is the same either way, because it is immutable.  If we
allowed mutating methods, then a struct version and a class version would not behave
the same way.

There are some more complicated situations where structs cannot be used.
Also structs have 
some specialized features not available to class objects, but we shall not concern ourselves 
with those fine points in these notes.