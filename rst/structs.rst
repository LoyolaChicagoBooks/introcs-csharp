.. index::  struct

.. _struct:

Structs
##########


Making A DataType
===================

C# comes with lots of built-in datatypes, but not
everything we might want to use.
What if you want to use fractions, which determine
rational numbers?

You could always keep two integer variables, the numerator
and denominator, but conceptually the main idea is that 
of a (single) rational number.  It just happens
to have parts.  There are lots of operations on rational
numbers, and they are operations on the entire fraction.

The point is that is makes sense to think of a fraction or rational
number as *one* entity.  A way to do that is to create a ``struct``.
We will call our struct ``Rational``.

An alternate way we consider later, that has most of the same properties, 
is a ``class`` defining a new kind of object.

.. index:: 
   double: OOP; constructor

We can create a new struct with the ``new`` syntax.
We can give parameters defining the state of the new object,
most obviously, a numerator and denominator, so we can plan that ::

   Rational r = new Rational(2, 3);

would create a new Rational number 2/3.

Like with built-in types, we can have the natural operations on the
type as *methods*.  For instance we can negate Rational number or 
convert it to a double approximation, or print it, or do arithmetic.

Thinking ahead to what we would like for our Rational numbers, here is
some testing code with hopefully clear and reasonable method names:

.. literalinclude:: ../projects//Music/Rational/TestRational.cs

Like other numerical types we would like to be about to parse strings.
The helping function ShowParse makes the display neater.

One non-obvious method is CompareTo.  This one method allows
all the usual comparison operators to be used with the result.  
We will discuss it more later.

The results we would like when running this testing code::

	Parse "-12/30" to Rational: -2/5
	Parse "123" to Rational: 123
	Parse "1.125" to Rational: 9/8
	6/(-10) simplifies to -3/5
	reciprocal of -3/5 is -5/3
	-3/5 negated is 3/5
	-3/5 + 1/2 is -1/10
	-3/5 - 1/2 is -11/10
	-3/5 * 1/2 is -3/10
	(-3/5) / (1/2) is -6/5
	1/2 > -3/5 ? True
	-3/5 as a double is -0.6
	1/2 as a decimal is 0.5

One complication with fractions is that there is more than one representation
for the same number.  As in grade school we will always reduce to
lowest terms.

Struct Syntax
--------------

Much of the rest of this section will discuss how we generate 
code to make this vision happen.  Some of the parts are harder than 
others.  We start with the most basic ones.  First we need a ``struct``.

Our code is nested inside ::

    public struct Rational
    {
    
       // ... fields, constructor, code for Rational omitted
    
    }   
       
This is much like the wrapper around a class, except we have "struct" in place of "class".


.. index::
   single: OOP; field, instance variable
   single: field
   single: instance variable
   single: private

Instance Variables
~~~~~~~~~~~~~~~~~~~~~

A Rational has a numerator and a denominator.  We must remember that data.  
We declare these *in* the struct and *outside* any method declaration.  
They are *fields* of the struct.  As we will
discuss more in terms of safety and security, we add the word "private" at the beginning::

    public struct Rational
    {
       private int num;
       private int denom;
       
       // ... constructor, code for Rational omitted
    
    }   

You also see that we are lazy and abbreviate the long words numerator and denominator 
in our names.  

We have used some static variables before.  Note that the fields are *not* declared static:
Each separate Rational object gets its own data!  
Static variables get one copy for the entire class.

We need to get values into our field variables.  They describe the state of our Rational.

We have used constructors for built-in types.  Now for the first time we *create* one.

.. index::
   double: constructor; OOP

Constructors
~~~~~~~~~~~~~~~

The constructor is a slight variation on a regular method:  Its name is the same as the
kind of entity constructed (Rational here, the name of the struct), 
and it has no return type.  (Implicitly you
are creating a **Rational** in this case.)  The constructor can have parameters
like a regular method.  We will certainly
want to give values to the numerator and denominator.  We could use just ::

      public Rational(int numerator, int denominator)
      {
         num = numerator;
         denom = denominator;
      }

In order to remember state after the constructor terminates, 
we must make sure the information gets into the fields of the struct.
This is the basic operation of most constructors:  Copy desired
parameters in to initialize the state in the fields.  That important thing
to note is that ``num`` and ``denom`` are in scope inside the constructor.  
*The fields are available to the compiler anywhere inside the struct code.*

There is actually a bit more to do in this situation and many others:  
Validate the data.  The actual constructor is 

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: constructor chunk
   :end-before: chunk

The last line calls a helping method, ``normalize``, to make sure the denominator is not 0,
and to reduce the fraction to lowest terms.

The constructor, like all methods that act on a particular object, does *not*
have a ``static`` designation.  

.. index::
   double: OOP; instance method
   double: OOP; getter

Instance Methods
~~~~~~~~~~~~~~~~~~

We have chosen to make our Rationals immutable.  The ``private`` in front
of the field declarations was important to keep code outside the
struct from messing with the values.  On the other hand we do want
others to be able to inspect the numerator and denominator,
so how do we do that?  Use **public methods**. 

Since the fields are accessible anywhere *inside* the struct, and public methods
can be used from outside the class, we can simply include

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: numerator chunk
   :end-before: chunk

These methods allow one-way communication of the values out of the struct.  
Note that there is no ``static``.

Without the ``static`` a method acts on the
current object.  Such methods are called *instance methods*, in contrast to
static methods.

Note that there is no parameter for the current object explicitly passed to either of these
methods.  The current object is always passed to an instance method *implicitly*, so the
current objects fields are accessible.

Look back at the constructor and note that ``normalize`` was not called with object.method
notation.  In a constructor or instance method, another instance method can be called 
with *just* the method, not the full dot notation.  This is C# shorthand meaning that 
the method called is to act on the current object, the same object that the caller is acting on.
In particular, when ``normalize`` is called in the constructor, 
it updates the fields for the object being constructed.  This is what we want!

Another simple method returns a double approximation:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: ToDouble chunk
   :end-before: chunk

So far we have returned built-in types.  What if we wanted to generate
the reciprocal of a Rational?  That would be another Rational.
How do we do it? 
We have a constructor!  We can easily use it.  The reciprocal
swaps the numerator and denominator:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: Reciprocal chunk
   :end-before: chunk

We have used static methods before (in fact all the methods we wrote 
before this section were static methods).  They are not associated with an instance.  
They are still useful.  
For example, in analogy with the other numeric types we may want a static ``Parse`` method
to act on a string parameter and return a new Rational.

The most obvious kind of string to parse would be one like "2/3" or "-10/77", which we can 
split at the '/'.  Integers are also rational numbers, so we would like to parse "123".
Finally non-repeating decimals are rational numbers, so we would like to parse "123.45".
That last case is the trickiest.  See how our ``Parse`` method distinguishes and handles
all the cases.  It constructs integer strings for both the numerator and denominator,
and then parses the integers.  Note that the method is ``static``.  There is no Rational
when it starts, but it returns one:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: Parse chunk
   :end-before: chunk

Method Parameters of the Same Type
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

So we can deal with the current object without using dot notation.  What if we are
dealing with more than one Rational, the current one and another parameter, as in Multiply:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: Multiply chunk
   :end-before: chunk

We can mix the shorthand notation for the current object's fields and dot notation for another
named object:  ``num`` and ``denom`` refer to the fields in the current object, and
``f.num`` and ``f.denom`` refer to fields for the other ``Rational``, the parameter ``f``.

Note that I did refer to the fields of ``f``through the public methods ``GetNumerator`` and 
``GetDenominator``.  Though ``f`` is not the same *object*, it is the same *type*: Private
members of another object of the same type are accessible.  The full method is:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: Multiply chunk
   :end-before: Divide chunk

.. index::
   single:  ToString
   single:  override

ToString Override
~~~~~~~~~~~~~~~~~~~~~~

All the built-in type can be concatenated into strings with the '+' operators.  
We would like that behavior with our custom types, too.  How can the compiler
know how to handle types that were not invented when the compiler was written?

The answer is to have common features for all objects.  Any object has a ``ToString``
method.  The default version supplied by the system is not very useful for an object 
that it knows nothing about!  To define your own version, one that knows how you have defined
your type, you need to *override* the default.  To emphasize the change
in meaning, the word ``override`` must be in the heading:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: ToString chunk
   :end-before: chunk
   
A more complete discussion of ``override`` would lead us into class hierarchies and 
inheritance, which we are not emphasizing in these notes.

The whole code for Rational is in project :file:`Music/Rational`.