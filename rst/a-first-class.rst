.. index::  
   double: class; Rational
   
.. _class:

A First Class Example: Rational
================================

Making A DataType
--------------------

C# comes with lots of built-in datatypes, but not
everything we might want to use.
What if you want to use fractions, which determine
rational numbers?

You could always keep two integer variables, the numerator
and denominator, but conceptually the main idea is that 
of a (single) rational number.  It just happens
to have parts.  There are lots of operations on rational
numbers, and they are operations on the entire fraction, as a unit.

The point is that is makes sense to think of a fraction or rational
number as *one* entity.  A way to do that is to create a ``class``.
We will call our class ``Rational``.

An alternate way we consider later, that has most of the same properties, 
is a ``class`` defining a new kind of object.

.. index:: 
   double: OOP; constructor

We can create a new class with the ``new`` syntax.
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
*lowest terms*.

Class Syntax
--------------

Much of the rest of this section will discuss how we generate 
code to make this vision happen.  Some of the parts are harder than 
others.  We start with the most basic ones.  First we need a ``class``.

Our code is nested inside ::

    public class Rational
    {
    
       // ... fields, constructor, code for Rational omitted
    
    }   
       
This is the same wrapper we have used for our Main programs!  Before everything was
labeled ``static``.  Now we see what happens with the ``static`` keyword omitted....

.. index::
   single: OOP; field, instance variable
   double: field; private
   double: instance variable; private

Instance Variables
----------------------

A Rational has a numerator and a denominator.  We must remember that data. 
Each individual Rational that we use will have its own numerator and denominator.

We have used some static variables before in classes, with the keyword ``static``, 
where there is just one copy for the whole class.  If we omit the ``static`` we get
an *instance variable*, that is the particular data for an *individual* Rational
number.

We declare these *in* the class and *outside* any method declaration.  
They are *fields* of the class.  As we will
discuss more in terms of safety and security, we add the word "private" at the beginning::

    public class Rational
    {
       private int num;
       private int denom;
       
       // ... constructor, code for Rational omitted
    
    }   

You also see that we are lazy and abbreviate the long words numerator and denominator 
in our names.  

It is important to distinguish *instance* variables of a class and *local* variables.
While a local variable is only accessible inside the one method where it was declared,
the class fields  ``num`` and ``denom`` are in scope *anywhere inside the class code*,
as long as the object exists.

We need to get values into our field variables.  They describe the state of our Rational.

We have *used* constructors for built-in types.  Now for the first time we *create* one.

.. index::
   double: constructor; OOP

Constructors
----------------

The constructor is a slight variation on a regular method:  Its name is the same as the
kind of object constructed, the class name (Rational here), 
and it has *no return type* (and *no* ``static``).  Implicitly you
are creating the kind of object named, a **Rational** in this case.
The constructor can have parameters like a regular method.  We will certainly
want to give values to the numerator and denominator.  We could use just ::

      public Rational(int numerator, int denominator)
      {
         num = numerator;
         denom = denominator;
      }

While the local variables in the formal parameters disappear after the constructor terminates,
we want the data to live on as the state of the object.
In order to remember state after the constructor terminates, 
we must make sure the information gets into the instance variables of the class.
This is the basic operation of most constructors:  Copy desired
parameters in to initialize the state in the fields.  

Note that we are not using full object notation with an object reference and a
dot, as we have when referring to a field in a different (so far always built-in)
class, like ``arrayObject.Length``.  

C# allows a shorthand notation inside a constructor or instance method 
(discussed below):
The instance variable names used without an object reference and dot refer to the 
*current* instance.  In this case it is the instance being created with the constructor.

There is actually a bit more to do in the constructor than we showed:  
Validate the data.  The actual constructor is 

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: constructor chunk
   :end-before: chunk

The last line calls a helping method, ``normalize``, to make sure the denominator is not 0,
and to reduce the fraction to lowest terms.

Like with the instance variable there is not the full object notation: object.method.
Again C# is allowing a shorthand:  With the explicit object reference missing, the 
assumption is that the method be applied to the current object, the one just being
intialized in this constructor.

.. index::
   double: OOP; instance method
   double: OOP; private helping function

Instance Methods
--------------------

Look at the heading for ``normalize``:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: normalize chunk
   :end-before: chunk

You see that there is *no* static, so the method is 
attached to the current instance implicitly.
Since the method only deals with the instance variables, no further
parameters need to be given explicitly.

(It is also declared ``private`` - it is a helping method used only, privately,
inside the class.)

The method uses the :ref:`gcd` function, discussed in the ``while`` loop section,
to reduce the Rational to lowest terms.

.. index::
   double: OOP; getter

Getters
--------

We have chosen to make our Rationals immutable.  The ``private`` in front
of the field declarations was important to keep code outside the
class from messing with the values.  On the other hand we do want
others to be able to inspect the numerator and denominator,
so how do we do that?  

Use **public methods**. 

Since the fields are accessible anywhere *inside* the class, and public methods
can be used from outside the class, we can simply code

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: numerator chunk
   :end-before: chunk

These methods allow one-way communication of the values out of the class.  

Note again that there is no ``static``.  The field value for the *current*
Rational is returned.

Another simple method returns a ``double`` approximation:

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
and then parses the integers.  Note that the method *is* ``static``.  There is no Rational
being referred to when it starts, but in this case the method returns one:


.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: Parse chunk
   :end-before: chunk

Method Parameters of the Same Type
-------------------------------------

We can deal with the current object without using dot notation.  What if we are
dealing with more than one Rational, the current one and another parameter, as in Multiply:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: Multiply chunk
   :end-before: chunk

We can mix the shorthand notation for the current object's fields and dot notation for another
named object:  ``num`` and ``denom`` refer to the fields in the *current* object, and
``f.num`` and ``f.denom`` refer to fields for the other ``Rational``, the parameter ``f``.

Note that I did not refer to the fields of ``f``through the public methods ``GetNumerator`` and 
``GetDenominator``.  Though ``f`` is not the same *object*, it is the same *type*: 
*Private members of another object of the same type are accessible.*  The full method is:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: Multiply chunk
   :end-before: Divide chunk

There are a number of other arithmetic methods in the source code for Rational
that return a new Rational result of the arithmetic operation.  They *do* review 
your knowledge of arithmetic! They do not add further C# syntax.

.. index::
   single:  ToString
   single:  override


ToString Override
---------------------

All the built-in type can be concatenated into strings with the '+' operators.  
We would like that behavior with our custom types, too.  How can the compiler
know how to handle types that were *not invented* when the compiler was written?

The answer is to have common features commmon to all objects.  Any object has a ``ToString``
method.  The default version supplied by the system is not very useful for an object 
that it knows nothing about!  To define your own version, one that knows how you have defined
your type, and to have that version used *in place of* the default,
you need to *override* the default.  To emphasize the change
in meaning, the word ``override`` must be in the heading:

.. literalinclude:: ../projects//Music/Rational/Rational.cs
   :start-after: ToString chunk
   :end-before: chunk
   
A more complete discussion of ``override`` would lead us into class hierarchies and 
inheritance, which we are not emphasizing in these notes.

The whole code for Rational is in project :file:`Music/Rational`.