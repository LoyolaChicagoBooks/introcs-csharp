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
``frac1*frac2``.  C#, like C++, but unlike Java, allows this
giving of a new meaning to operators, in a process called 
*operator overloading*.  The C# syntax is illustrated in the 
variant of the Rational class in 
:repsrc:`rational_ops_stub/rational.cs`.  This is extended in the
next section on user-defined casts.

.. literalinclude:: ../source/examples/rational_ops_stub/rational.cs
   :start-after: operator chunk
   :end-before: chunk

To overload an operator requires a special method heading.  It
must be ``public static``, and show the
desired return type, and in place of a usual name is something like
``operator *`` or ``operator -``, including the symbol being overloaded.
Binary operations like multiplication require two operands. (In general
at least one of them must be of the type of the class being defined.). 

(We could have directly defined variants with the first or second parameter 
being an ``int`` or a ``double``, but we avoid that need by later overloading
some implicit cast operations, as discussed below.)  The method then
computes and returns the named return type in the normal fashion.

The heading format is

    ``public static`` *returnType* ``operator`` *opSymbol* ``(`` *parameters* ``)`` 

The ``-`` symbol is special, since it can be used either as a unary operator for
negation, or as a binary operator for subtraction.  Since we included only 
one parameter, we were defining the unary version.  The class is a stub,
and the exercise below invites you to add further operator overloads, for
subtraction and some others.

The operator does not need to produce a result of the same type.  We
included ``==`` and ``!=`` as examples (returning a Boolean).  (These methods
do cause compiler warnings, but not errors, 
since we have not add further more advanced
overloads of Equals and HashCode methods, that are ideally in sync with 
the meaning of ``==``.  You should see a discussion of these methods in a 
data structures course, like Loyola's Comp 271.)

.. index:: precedence; with operator overloading

**Precedence**:  Note that the overloaded method definitions for operators include
nothing about :ref:`precedence`. That is because the precedence of each operator
is always the same as defined with built-in types.  Unary ``-`` has higher
precedence that ``*`` ....

The example testing class also uses the casting of next section:

.. index:: operator; casts in user class
   casts in user-defined classes
   
.. casts_in_user_classes:

Casts in User-Defined Classes
-------------------------------
  
We have discussed casts before.  We know that an ``int`` can also be represented
implicitly as a ``double`` with an integer value, 
so an expression like 3.2 * 2 is processed by the compiler, converting the
2 to ``double`` 2.0, to do the ``double`` multiplication.  
The same idea makes sense with an
``int`` and a Rational.  A Rational ``f`` times an int ``n``
should give the same result as with a cast:  ``f * (Rational)n``.  This
cast and others are defined in:

.. literalinclude:: ../source/examples/rational_ops_stub/rational.cs
   :start-after: implicit cast chunk
   :end-before: chunk
 
Again it is
the heading that takes a special form, starting with
``public static implicit operator`` followed by the type being cast to, 
like Rational, while the parameter is the starting type, like ``int``.  
This is not like a regular method with its return type and method name.
Here it looks something like a constructor with its type in place of a method
name, but a constructor would not have ``static implicit operator``!

The ``implicit`` means that an explicit cast ``(Rational)`` 
is not needed in an expression
where the strong typing of C# would not allow an ``int`` but would allow
a Rational. 

Now consider an expression with double ``d`` and a Rational ``f`` like 
``d * f``.
Multiplication is not defined directly between an double and a Rational.  Since
doubles are only approximations, it would not be safe to implicitly convert 
a double to a Rational, but it does make sense to approximate a Rational 
by a double before the multiplication with a ``double``, 
so we also have the method to cast a Rational (as parameter)
to a ``double`` (in the place of a function name), starting with heading ::

  public static implicit operator double(Rational f)

The general format of such an implicit cast in a user-defined class is:

    ``public static implicit operator`` *resultType* ``(`` *sourceType* *paramName* ``)``

One of the two types should be the type of the containing class.
    
Finally, you need to be very careful where you allow implicit casts, to
make sure you are not being overly general, and maybe allowing  
trouble in a form that may be very hard to debug: 
It is harder to trace implicit actions than explicit actions.
You are
*safe*, but more *verbose*, if you only allow *explicit* casts, as we have already 
seen required from ``double`` to ``int``.  To force the cast to only be used
explicitly, replace ``implicit`` by ``explicit`` in the cast method heading.  
Though we have not used the
``decimal`` type much, we use it for contrast to illustrate an explicit cast
from Rational to decimal:

.. literalinclude:: ../source/examples/rational_ops_stub/rational.cs
   :start-after: explicit cast chunk
   :end-before: chunk

The use of all the operator overloads and casts is tested in example
:repsrc:`rational_ops_stub/test_ops.cs`.  Look at it and run it.
Note where overloaded operators are used and where implicit and explicit casts
to or from a Rational are used.

Operator Overloading Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The classes discussed above from example project 
:repsrc:`rational_ops_stub` are incomplete.  Add the
overloaded binary operators  /, +, -, <, >, <= and >= to the Rational class,
and extend the TestOps class to test them.