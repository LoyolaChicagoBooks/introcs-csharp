.. _defining_operators:

Defining Operators (Optional)
==============================

.. index:: operator; overload in user class
   overloading operators
   
.. _overloading_operators:

Operator Overloading
----------------------------------------------------

The Rational class is a fine example of a useful utility class.
Still, to an experience user it has a striking deficiency:
A Rational is a *number* and we are used to doing arithmetic with 
standard operators.  We would like to replace the mouthful
``frac1.Multiply(frac2)`` by our common symbolism for multiplication,
``frac1*frac2``.  This can be coded in C#, using *operator overloading* to 
give new meanings to the operator ``*``.  The C# syntax is illustrated in the 
variant of the Rational class in 
:repsrc:`rational_ops_stub/rational.cs`.  This class also contains code
discussed in the
next section, :ref:`casts_in_user_classes`.  
Here are operator overload declarations for ``*`` and others:

.. literalinclude:: ../source/examples/rational_ops_stub/rational.cs
   :start-after: operator chunk
   :end-before: chunk

All operator overload headings have the special form

    ``public static`` *returnType* ``operator`` opSymbol ``(`` *parameters* ``)`` 

Here opSymbol can be any arithmetic or comparison operator, or
some other operators that we have not discussed.  So something like
``operator *`` or ``operator -`` replaces the method name.
Binary operations like multiplication require two operands, and hence the
method has two parameters. 
The method 
computes and returns the named return type in the normal fashion. 
In general
at least one of the parameters must be of the type of the class being defined.
  
(We could have directly defined four further overloads of ``*``, 
with the first or second parameter 
being an ``int`` or a ``double``, but we will avoid that by also adding methods 
to provide implicit :ref:`casts_in_user_classes`.)  

The ``-`` symbol is special, since it can be used either as a unary operator for
negation, or as a binary operator for subtraction.  Since we include only 
one parameter above, we are defining the unary version.  

The operator does not need to produce a result of the same type.  We
included ``==`` and ``!=`` as examples (returning a ``Boolean``).  

(These methods
do not cause compiler errors, but warnings are generated:  
We have not added further more advanced
overrides of Equals and HashCode methods, that are ideally in sync with 
the meaning of ``==``.  You should see a discussion of these methods in a 
data structures course, like Loyola's Comp 271.)

The class is a stub,
and :ref:`overloading-operator-exercise` 
invites you to add further operator overloads.

.. index:: precedence; with operator overloading
   operator overloading; precedence unchanged

**Precedence**:  Note that the operator overloading method definitions include
nothing about :ref:`precedence`. That is because the precedence of operators
is fixed across the whole language. Unary ``-`` has higher
precedence than ``*`` ... no matter what the types involved.

An example testing class also uses the new casting syntax of next section:

.. index:: operator; casts in user class
   casts in user-defined classes
   implicit casts in user-defined classes
   
.. _casts_in_user_classes:

Casts in User-Defined Classes
-------------------------------
  
We have discussed casts before.  We know that an ``int`` can also be represented
as a ``double`` with an integer value, and the cast from ``int`` to ``double`` 
is done implicitly
when needed:  An expression like ``3.2 * 2`` is processed by the compiler, 
*implicitly* casting the
2 to ``double`` 2.0, and then doing a ``double`` multiplication.  
The same idea makes sense with an
``int`` ``n`` and a Rational ``f``.  We only defined the operator overload ``*``
for two Rationals, so in our code so far, ``f * n`` does not make sense.
Mathematically an integer is rational, so mathematically, it should make sense.  
We bridge this difference by defining an implicit cast of an ``int`` to a Rational,
so  the compiler will take ``f * n`` and see the need to implicitly cast
``n`` to a Rational.  The definition below will also allow explicit casts 
if you choose, like ``f * (Rational) n``:

.. literalinclude:: ../source/examples/rational_ops_stub/rational.cs
   :start-after: implicit cast chunk
   :end-before: chunk
 
Again it is
the heading that takes a special form, starting with
``public static implicit operator`` followed by the type being cast to, 
like Rational, while the parameter is the starting type, like ``int``.  
This is not like a regular method with its return type and method name.
Here it looks something like a constructor with a type in place of a method
name, but a constructor would not start with ``static implicit operator``!

Now consider a ``double`` ``d`` and a Rational ``f``.
We would like to allow an expression like 
``d * f``.
Again, the operator overload for ``*`` does not allow this directly, so consider
implicit casts:  Since
a ``double`` is only an approximation, in general, 
it would not be wise to implicitly convert 
a ``double`` to a Rational, but it does make sense to approximate a Rational 
by a ``double`` before use with a ``double``:

.. literalinclude:: ../source/examples/rational_ops_stub/rational.cs
   :start-after: to double chunk
   :end-before: chunk
 
The general format of such an implicit cast in a user-defined class is:

    ``public static implicit operator`` *resultType* ``(`` *sourceType* *paramName* ``)``

One of the two types should be the type of the containing class.  
We have illustrated both combinations.
    
Finally, you need to be *very careful where you declare implicit casts*, to
make sure you are not being overly general, and maybe allowing  
trouble in a form that may be very hard to debug: 
It is much harder to foresee and trace implicit actions than explicit actions.
You are
*safe*, but more *verbose*, if you *only allow explicit* casts.  For example,
we have already seen these required for a cast from ``double`` to ``int``.  
To only allow an explicit cast with your type, 
replace ``implicit`` by ``explicit`` in the cast method heading.  

.. index:: decimal type
   type; decimal
   explicit casts in user-defined classes

.. _decimal-type:
   
.. literalinclude:: ../source/examples/rational_ops_stub/rational.cs
   :start-after: explicit cast chunk
   :end-before: chunk

**The decimal type**:  Though we have not used the
``decimal`` type before, we use it here for contrast to illustrate a cast
from Rational to ``decimal`` that can only be used explicitly, as in
``(decimal) f``:
  
Example
:repsrc:`rational_ops_stub/test_ops.cs` tests all of the operator overloads 
and casts shown for a Rational.  Look at the source code and run it.
Note where overloaded operators are used and where implicit and explicit casts
to or from a Rational are used.  

The example also illustrates a special feature
of the ``decimal`` type.  While a ``double`` is encoded with a power of 2, so
0.1 is *not* stored accurately, a ``decimal`` is encoded with a power of 10, so
exact decimal values with up to 28 digits can be stored and manipulated.
(This is important for *monetary calculations*, so a ``decimal`` literal 
has **m** for money appended, like  ``5.99m``, representing the mathematical
quantity 5.99 *exactly*.) 

.. index:: exercise; overloading operators
   overloading operators; exercise      
   
.. _overloading-operator-exercise:

Operator Overloading Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The classes discussed above from example project 
:repsrc:`rational_ops_stub` 
are incomplete.  Add the
overloaded binary operators  /, +, -, <, >, <= and >= to the Rational class,
and extend the TestOps class to test them.