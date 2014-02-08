.. index:: value type
   reference object
   struct
   

.. _structs-and-classes:

Classes And Structs
======================

C# has an alternate syntax to a class: a *struct*. 
Everything we have said so far about classes such an ``Rational`` applies to
structs also!  In fact you could change ``class`` into ``struct`` in the heading for
Rational, and it would become a ``struct``, with no further code changes in any of the
code we have written! ::

	public struct Rational
	{
	   // ...
	}

So why the distinction?  We have mentioned that new objects created in a class are 
accessed indirectly via a reference, as with an array.  As a general category,
they are called *reference objects*.  We distinguished the types ``int`` and 
``double`` and ``bool``, where the actual value of the data is stored in the space 
for a variable of the type.  They are *value types*.  A struct is also a value
type.  In practice this is efficient for small objects of a fixed size.  
We made Rational a class because
you have already seen the class construct with
``static`` entries, and classes are more generally useful.  
In fact being a ``struct`` would be a good choice for Rational, 
since it only contains two integers.  Its size is no more than one ``double``.

The behavior of a Rational is the same either way, because it is immutable.  If we
allowed mutating methods, then a class version and a struct version would not behave
the same way, due to the fact the reference types can have aliases, 
and value types cannot.

There are some more complicated situations where there are further distinctions between
classes and structs, but we shall not concern ourselves 
with those fine advanced points in this book.