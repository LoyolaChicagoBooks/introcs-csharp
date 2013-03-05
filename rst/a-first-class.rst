.. index::  
   double: class; Rational
   
.. _class:

A First Example of Class Instances: Rational 
============================================

Making a Datatype
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

It makes sense to think of a fraction or rational
number as *one* entity.  A way to do that is to create a ``class``. 
We will call our class ``Rational``.  This way we can have a single
variable refer to a ``Rational`` object.

There is an alternate construction, that has most of the same properties, 
in :ref:`structs-and-classes`.

We have already considered built-in types with internal state, like Lists:   
Each List can contain different data, and the internal data can be changed.
 
The idea of creating a new type of object opens new ground for managing data.  
Thus far we have stored data as local variables, and we have called functions,
with two ways to get information in and out of functions:

#. In through parameters and out through returned data.
#. Directly via the user: in through the keyboard and out to the screen.

We have stored and passed around built-in types of object using this model.  

Now we have alternatives for storing and accessing data in the methods within
a new class we write.  
Now we have the idea of an object that has *internal* state
(like a rational number with a numerator and a denominator).  We shall see that
this state is *not* 
stored in local variables and does *not* need to be passed through parameters for 
methods *within* the class.  
Pay careful attention as we introduce this new location for data and the new ways
of interacting with it.

This is quite a shift.
*Do not take it lightly.*  

.. index:: 
   double: OOP; constructor

We can create a new object with the ``new`` syntax.
We can give parameters defining the initial state of the new object.  
In our example these are fairly obvious,
a numerator and denominator, so we can plan that ::

   Rational r = new Rational(2, 3);

would create a new Rational number for the mathematical expression, 2/3.

Like with built-in types, we can have the natural operations on the
type as *methods*.  For instance we can negate Rational number or 
convert it to a double approximation, or print it, or do arithmetic.

Thinking ahead to what we would like for our Rational numbers, here is
some testing code, with hopefully clear and reasonable method names:

.. literalinclude:: ../source/examples/test_rational/test_rational.cs

Like other numerical types we would like to be able to parse strings.
The helping function, ``ShowParse``, in our testing code makes the display neater.

One non-obvious method is ``CompareTo``.  This one method allows
all the usual comparison operators to be used with the result.  
We will discuss it more in :ref:`rationals-revisited`.

The results we would like when running this testing code:

..  code-block:: none

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
	Parse "-12/30" to Rational: -2/5
	Parse "123" to Rational: 123
	Parse "1.125" to Rational: 9/8

One complication with fractions is that there is more than one representation
for the same number.  As in grade school we will always reduce to
*lowest terms*.

We are using the same object oriented notation that we have for many other classes:
*Calls to instance methods are always attached to a specific object.*
So far that has always been
the object of

   *object*\ ``.``\ *method*\ ``(``  ... ``)``
   
So far we have been thinking and illustrating how we would like objects in this
Rational class to look like and behave from the *outside*.  We could be
describing another library class.  Now, for the first time, we start to delve inside,
to the code and concepts needed to make this happen:

Some of the parts are harder than 
others.  We start with the most basic ones.  First we need a ``class``.

Class Syntax
--------------

Our code is nested inside ::

    public class Rational
    {
    
       // ... fields, constructor, code for Rational omitted
    
    }   
       
This is the same sort of wrapper we have used for our Main programs!  
*Before*, everything inside was
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
number.  This is our new place to store data:

We declare these *in* the class and *outside* any method declaration.  

They are *fields* of the class.  As we will
discuss more in terms of safety and security, we add the word "private" at the beginning::

    public class Rational
    {
       private int num;
       private int denom;
       
       // ... constructor, code for Rational omitted
    
    }   

You also see that we are lazy in this example,
and abbreviate the long words numerator and denominator 
in our names.  

It is important to distinguish *instance* variables of a class and *local* variables.
A local variable is only accessible inside the one method where it was declared,
and is destroyed at the end of the method.  
However the class fields  ``num`` and ``denom`` are remembered by C# 
as long as the object is in use.  This is a totally new situation.  We repeat:

.. note::
   *Instance* variable have a completely different lifetime and scope from *local* variables.
   An object and its instance variables, persist from the time a new object is created
   with ``new`` for as long
   as it remains referenced in the program.
   
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
want to give a state to our new object.
That means giving values to its numerator and denominator.  Recall we are want to
store this state in instance variables ``num`` and ``denom``.  We could just use ::

      public Rational(int numerator, int denominator)
      {
         num = numerator;
         denom = denominator;
      }

While the local variables in the formal parameters disappear after the constructor terminates,
we want the data to live on as the state of the object.
In order to remember state after the constructor terminates, 
we must *make sure the information gets into the instance variables* for the object.
This is the basic operation of most constructors:  Copy desired
parameters in to initialize the state in the fields.  That is all our simple
code above does.

Note that with ``num`` and ``denom`` we are *not* using 
full object notation with an object reference and a
dot, as we have when referring to a field in a different (so far always built-in)
class, like ``arrayObject.Length``.  The constructor is creating an object,
and the notation for the instance variables is understood to be giving values to
the Rational object being constructed.
C# allows this shorthand notation inside a constructor and also inside an instance method 
(discussed below).

There is actually a bit more to do in the constructor than we showed:  
Validate the data.  The actual constructor is 

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
   :start-after: constructor chunk
   :end-before: chunk

The last line calls an instance method, ``normalize``, 
to make sure the denominator is not 0,
and to reduce the fraction to lowest terms.

Like with the instance variables, with ``normalize()`` 
there is not the full object notation: object.method().
Again C# is allowing a shorthand:  With the explicit object reference missing, the 
assumption is that the method be applied to the current object: In this case that is 
the one just being initialized in this constructor.

.. index::
   double: OOP; instance method
   double: OOP; private helping function

.. _instance-methods:

Instance Methods
--------------------

Look at the heading for ``normalize``:

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
   :start-after: normalize chunk
   :end-before: chunk

You see that there is *no* static in the method heading, so the method is 
attached to the current instance implicitly.  
It can only be called when there *is* a current instance (discussed below).
Since the method only deals with the instance variables, no further
parameters need to be given explicitly.

(It is also declared ``private``: It is a helping method only used privately,
from *inside* the class.)

The method uses the :ref:`gcd-remainder-loop` function
to reduce the Rational to lowest terms.

The instance variable names and method names 
used without an object reference and dot refer to the 
*current* instance.  Whenever a constructor or non-static method in the class is called,
there is *always* a current object:

#.  In a constructor, referring to the object being created.
#.  When some instance method ``methodName`` is called with explicit dot notation, 
    ``someObject.methodName()``, 
    then it is acting on the current object ``someObject``.
#.  When a constructor or instance method (no ``static``) inside the class is called,
    there must *already* be a current object.  
    If that constructor or instance method calls a
    further instance method inside the same class, without using dot notation, 
    then the further method has the *same* current object.

Again:  When a constructor or method refers to or sets an instance variable, without
starting with "someObject.", it is referring to the *current object*, also referred to as
*this* object.  

.. warning::
   These are the only places where there is a current object. 
   Inside a ``static`` method there
   is *no* current object.  A common compiler error is to try to have a static method call
   an instance method without dot notation for a specific object.  The shorthand notation
   without an explicit object reference and dot cannot be used, because there is no
   current object to insert implicitly::
   
	   public void AnInstanceMethod() 
	   {
		 ...
	   }
	   
	   public static void AStaticMethod()  // no current object
	   {
		  AnInstanceMethod();  // Compiler error caused
	   }
	
   On the other hand, there is no issue when
   an instance method calls a static method.  (The instance variables are just 
   inaccessible inside the static method.)
   
.. index::
   double: this; instance method
   double this; OOP

The current object is *implicit* inside a constructor or instance method definition,
but it can be referred to *explicitly*.  It is called ``this``.  
In a constructor or instance method, ``this`` is automatically a legal
local variable to reference.  
You usually do not need to 
use it explicitly, but you could.   For example the current ``Rational`` object's
``num`` field could be referred to as either ``this.num`` or the shorter plain ``num``.
We will see in later sections that there are places
where there is reason for an object to refer to itself explicitly, 
and use ``this`` as the object's name.

 
.. index::
   double: OOP; getter

.. _getters:

Getters
--------

In instance methods, where instance variables are accessible, 
you have an extra way of getting 
data in and out of the method:  Reading or setting instance variables.  
The simplest methods do nothing but that....

We have chosen to make our Rationals immutable.  The ``private`` in front
of the field declarations was important to keep code outside the
class from messing with the values.  On the other hand we do want
others to be able to *inspect* the numerator and denominator,
so how do we do that?  

Use **public methods**. 

Since the fields are accessible anywhere *inside* the class's instance methods, 
and public methods can be used from outside the class, we can simply code

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
   :start-after: numerator chunk
   :end-before: chunk

These methods allow one-way communication of the numerator and denominator 
values out of the object.
These are examples
of a simple category of methods:  A *getter* simply returns the value of a part
of the object's state, without changing the object at all.  

Note again that there is no ``static`` in the method heading.  
The field value for the *current* Rational is returned.

Another simple method returns a ``double`` approximation:

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
   :start-after: ToDouble chunk
   :end-before: chunk

So far we have returned built-in types.  What if we wanted to generate
the reciprocal of a Rational?  That would be another Rational.
How do we do it? 
We have a constructor!  We can easily use it.  The reciprocal
swaps the numerator and denominator:

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
   :start-after: Reciprocal chunk
   :end-before: chunk

We have used static methods before (in fact all the methods we wrote 
before this section were static methods).  They are not associated with an instance.  
They are still useful.  
For example, in analogy with the other numeric types we may want a static ``Parse`` method
to act on a string parameter and return a new Rational.

The most obvious kind of string to parse would be one like "2/3" or "-10/77", which we can 
split at the '/'.  Integers are also rational numbers, so we would like to parse "123".
Finally decimal strings can be converted to rational numbers, 
so we would like to parse "123.45".
That last case is the trickiest.  See how our ``Parse`` method below distinguishes and handles
all the cases.  It constructs integer strings for both the numerator and denominator,
and then parses the integers.  Note that the method *is* ``static``.  There is no Rational
being referred to when it starts, but in this case the method returns one:

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
   :start-after: Parse chunk
   :end-before: chunk

Method Parameters of the Same Type
-------------------------------------

We can deal with the current object without using dot notation.  What if we are
dealing with more than one Rational, the current one *and* another one, 
like the parameter in Multiply:

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
   :start-after: Multiply chunk
   :end-before: chunk

We can mix the shorthand notation for the current object's fields 
and dot notation for another
*named* object:  ``num`` and ``denom`` refer to the fields in the *current* object, and
``f.num`` and ``f.denom`` refer to fields for the other ``Rational``, the parameter ``f``.

Note that we do not refer to the fields of ``f`` through the public methods 
``GetNumerator`` and 
``GetDenominator``.  Though ``f`` is not the same *object*, it is the same *type*: 

.. note::
   Private members of another object of the *same* type are accessible from method 
   definitions in the class.  
   
The full ``Multiply`` method is:

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
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

All the built-in types can be concatenated into strings with the '+' operators.  
We would like that behavior with our custom types, too.  How can the compiler
know how to handle types that were *not invented* when the compiler was written?

The answer is to have common features among all objects.  Any object has a ``ToString``
method.  The default version supplied by the system is not very useful for an object 
that it knows nothing about!  You need to define your own version, 
one that knows how you have defined
your type with its own specific instance variables. 
You need to have that version used *in place of* the default:
You need to *override* the default.  To emphasize the change
in meaning, the word ``override`` *must* be in the heading:

.. literalinclude:: ../source/examples/rational_nunit/rational.cs
   :start-after: ToString chunk
   :end-before: chunk

For any kind of new object that you create and want to be able to implicitly convert to
a string, you need a ``ToString`` method with the exact same heading 
as the ``ToString`` for a Rational.    

A more complete discussion of ``override`` would lead us into class hierarchies and 
inheritance, which we are not emphasizing in this book.

The whole code for Rational is in :repsrc:`rational_nunit/rational.cs`.

Pictorial Playing Computer
---------------------------

Let us start pictorially playing computer on :file:`test_rational.cs`, 
as a review of much of the previous sections  We explicitly show a local variable
``this`` to identify the current object in an instance method or constructor.  

The first line of ``Main``, ::

   Rational f = new Rational(6, -10);
   
creates a new Rational, so it calls the constructor.  At the very beginning of the
constructor, a prototype ``Rational`` is already created as the current object,
so immediately, there is a ``this``.  
The parameters 6, and -10 are passed, initializing the explicit local
variables ``numerator`` and ``denominator``.  
The figure illustrates the memory state at the beginning of the constructor call:

.. image:: images/callConstructor.png

Note the immediate value assigned to the numeric instance variables is zero:  This is 
as discussed in :ref:`default-fields`.  
Of course we do not want to keep those default values:
The constructor finds the value of the local variable ``numerator``, and needs to 
assign the value 6 to a variable ``num``.  The compiler has looked 
first for a local variable ``num``, and found none. 
Then it looked *second* for an instance variable in the object pointed to
by ``this``.  It found ``num`` there.  Now it copies the 6 into that location.  
Similarly for ``denominator`` and ``denom``:

.. image:: images/callConstructorCopied.png

Then the constructor calls ``normalize``.  Since normalize is also an instance method,
a reference to ``this`` is passed implicitly.  While illustrating the memory state 
for more than one active method, we separate each one with a horizontal segment.

.. image:: images/callNormalize.png

Later ``normalize`` calls ``gcd``.  Since ``gcd`` is static, note that the local 
variables for ``gcd`` do *not* contain a reference to ``this``.

.. image:: images/callGCD.png

At the end of ``gcd`` the ``int`` 2 is returned and initializes 
``n`` in the calling method ``normalize``.
Then normalize modifies the instance variable pointed to by ``this``, and finishes.

.. image:: images/finishNormalize.png

That is the same object ``this`` in the constructor.  
Just before the constructor completes we have:

.. image:: images/finishConstructor.png

Then in ``Main`` the constructor's ``this`` is the reference to the new object 
initializing ``f``.

.. image:: images/setF.png

Consider the next line of ``Main``::

   Console.WriteLine("6/(-10) simplifies to {0}", f);
          
We omit the internals of the WriteLine call, except to note that it must convert
the reference ``f`` to a string.  As with any object,
it does this by calling the ``ToString`` method for ``f``,
so the implicit ``this`` in the call to ``ToString`` refers to the same object as ``f``:

.. image:: images/callToString.png

``ToString`` returns "-3/5", and it gets printed as part of the line generated
by ``WriteLine``....  

We skip the similar details through two more ``WriteLine`` statements and the 
initialization of ``h``::

    Rational h = new Rational(1,2);

The ``WriteLine``
statement after that needs to evaluate ``f.Add(h)``, generating a call to ``Add``.
The next figure shows the two local variables in ``Main``, ``f`` and ``h``, each
pointing to a ``Rational`` object.  The image shows the situation in the call to ``Add``.  
In the local variables for the method ``Add`` 
see what the implicit ``this`` refers to, and what the 
(local to ``Add``) variable ``f`` refer to.  As the figure shows, 
this use of a local variable
``f`` is independent of the ``f`` in ``Main``:

.. image:: images/callAdd.png

Since the return statement in ``Add`` creates a new object, 
the figure shows  a call to the
constructor from inside ``Add``.  We do not go through the details of another
constructor call, but
``this`` in The constructor ends up pointing to the Rational shown.

The ``this`` of the constructor ends up as the reference returned by ``Add``:

.. image:: images/endAdd.png

which gets sent to the WriteLine statement and gets printed as in the earlier code.

Make sure you see how the pictures reinforce these important ideas:

*  Keeping track of the ``this`` with 
   constructors and instance methods (but not static methods).
*  The aliasing of ``Rational`` objects used as parameters explicitly or 
   implicitly (``this``).
   
We have played computer before in procedural programming, 
following individually explicitly named
variables.  This has allowed us to follow loops clearly after the code is
written.  The pictorial version with multiple object references and method calls
is also useful for checking on code that is written.  

When first *writing* code, a picture of the setup
of the references in your data is also helpful.  
New object-oriented programmers often have a hard time referring to the
data they want to work with. 
If you have a picture of the data relationships
you can point with a finger to a part that you want to use.
For example 
in the call to ``Add``, one piece of data you need for your arithmetic is
the ``num`` field in ``f``.  Then you must be carful to note
that *only local variables can be referenced directly*
(including the implicit ``this``).   If you want to refer to data that is not a local
variable, you must follow the reference path arrow that leads *from a local variable* to
an instance field that you want to reference. 

.. image:: images/pathToNum.png

Then use the proper object-oriented notation to refer to the path.  
In the example, it takes one step,
from local variable ``f`` to its field ``num``, referred to as ``f.num``.
Similarly the current object's ``num`` is connected through ``this``, but C# shorthand
allows ``this.`` to be omitted.  And so on, for ``f.denom`` and ``denom``.

Visually following such paths will be even more important later, when we construct
more complex types of objects, and you need to follow
a path through *several* references in sequence.

.. _local-variables-hiding-instance-variables:

Local Variables Hiding Instance Variables
------------------------------------------

A common error is for students to try to declare the instance variables twice,
once in the regular instance variable declarations, and then again in a 
constructor, like::

      public Rational(int numerator, int denominator)
      {
         int num = numerator;       // LOGICAL ERROR!
         int denom = denominator;   // LOGICAL ERROR!
      }

This is deadly.  it is worse than redeclaring a local variable, which at least will 
trigger a compiler error.

.. index:: warning; redeclaring instance variables

..  warning::

    Instance variable *only* get declared outside of all
    functions and constructors.  Same-name 
    local variable declarations hide the
    instance variables, but *compile just fine*.  The local variables disappear
    after the constructor ends, leaving the instance variables 
    *without* your desired initialization. Instead the hidden instance variables 
    just get the default initialization, 0 for a number.
