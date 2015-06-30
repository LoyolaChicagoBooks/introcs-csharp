.. index::
   type; value
   value type


.. _value-types:

Value Types and Conversions
===========================

.. index::
   int; value range
   type; int
   overflow


.. _type-int:

Type int
--------

A variable is
associated with a space in memory.  This space has a fixed size associated with the type 
of data.
The ``int`` and ``double`` types are examples of *value types*, 
which means that this memory space holds an encoding of the complete data for the
value of the variable.  The fixed space means that an ``int`` cannot be a totally 
arbitrary integer of an enormous size.  In fact an ``int`` variable can only hold
an integer in a specific range.  See :ref:`data-representation` for the 
general format of the underlying encoding in bits.

An ``int`` is held in a memory space of 32 bits, so it can have at
most :math:`2^{32}` values, and the encoding is chosen so about half are positive and 
half are negative: An ``int`` has maximum value :math:`2^{31} - 1 = 2147483647` and
a minimum value of :math:`-2^{31} = -2147483648`.  The extreme values are also 
named constants in C#, ``int.MaxValue`` and ``int.MinValue``.

In particular this means ``int`` arithmetic does not always work.  What is worse,
it fails *silently*:

.. code-block:: none

    csharp> int i = int.MaxValue;
    csharp> i;
    2147483647
    csharp> i + 5;
    -2147483644

Add two positive numbers and get a negative number!  Getting such a wrong
answer is called *overflow*.
Be very careful if you are
going to be using big numbers!  Note: with addition, 
overflow will give the wrong sign, 
but the sign may not give such a clue 
if another operation overflows, like multiplication.

.. index:: type; long
   long type
   short type
   byte type

.. _type-long:
   
Type long
---------

Most everyday uses of integers fit in this range of an ``int``, 
and many modern computers are designed
to operate on an ``int`` very efficiently, but sometimes you need a
larger range.  Type `long` uses twice as much space.

The same kind of silent overflow errors happen with ``long`` arithmetic, but only
with much larger numbers.

When we get to :ref:`array`, you will see that a program may store
an enormous number of integers, and then the total space may be an 
issue.  If some numbers fit in a ``long``, but not an ``int``, 
``long`` must be used, taking us twice the space of an array of ``int``
elements.  If all the integers have even more limited ranges, 
they might be stored in the smaller space of a ``short``  
or a ``byte``.  
We will not further discuss or use types ``short`` or ``byte`` in this book.  
Here we will only use the integral types ``int`` and ``long``.

.. index:: type; double
   double type
   precision
   float type
   type; float

.. _type-double:
   
Type double
------------

A ``double`` is also a value type, stored in a fixed sized space.  There are
even more issues with ``double`` storage than with an ``int``:  Not only do you need
to worry about the total magnitude of the number, you also need to choose
a *precision*:  There are an infinite number of real values, just between 0 and 1.
Clearly we cannot encode for all of them!  As a result a ``double`` has a limited
number of digits of accuracy.  There is also an older type ``float`` that takes up
half of the space of a ``double``, and has a smaller range and less accuracy.  This at
least gives a reason for the name ``double``:  double the storage space of a ``float``.

To avoid a ridiculously large number of
trailing 0's, a big double literal can be 
expressed using a variant of scientific notation:

   ``1.79769313486232E+308`` means :math:`1.7976931348623157(10^{308})`

C# does not have the typography for raised exponents.  Instead 
literal values can use the E to mean
"times 10 to the power", and the E is followed by and exponent integer
that can be positive or negative.  
The whole double literal may not contain any embedded blanks.  Internally
these numbers are stored with powers of 2, not 10:  See 
:ref:`data-representation`.

Arithmetic with the ``double`` type does not overflow silently as with 
the integral types.  
We show behavior that could be important if you do scientific computing
with enormous numbers:  There are values for Infinity and Not a Number,
abbreviated NaN.  See them used in csharp: 

.. code-block:: none

    csharp> double x = double.MaxValue;
    csharp> x;
    1.79769313486232E+308
    csharp> double y = 10 * x;
    csharp> y;
    Infinity
    csharp> y  + 1000;
    Infinity
    csharp> y  - 1000;
    Infinity
    csharp> 1000/y;
    0
    csharp> double z = 10 - y;
    csharp> z;
    -Infinity
    csharp> double sum = y + z;
    csharp> sum;
    NaN
    csharp> sum/1000;
    NaN

Once a result gets too big, it gets listed as infinity.
As you can see,
there is some arithmetic allowed with a finite number and infinity! 
Still some operations are not legal.
Once a result turns into ``NaN``, no arithmetic operations change
further results away from ``NaN``, 
so there is a lasting record of a big error!

Note that Infinity, -Infinity and NaN are just representations when displayed
as strings.  The numerical constants are 
``Double.PositiveInfinity``, ``Double.NegativeInfinity``, and ``Double.NaN``.

..  warning::

    There is no such neat system for showing off small inaccuracies in ``double``
    arithmetic accumulating 
    due to limited precision.  These inaccuracies *still* happen silently.

.. index::  numeric type range
   range of numeric types
   byte type
   short type
   type; byte and short
   
.. _numeric-type-limits:

Numeric Types and  Limits
--------------------------

The listing below shows how the storage size in bits translates into the limits
for various numerical types.  We will not discuss or use ``short``,
``byte`` or ``float`` further.

long
   64 bits; range -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
   
int
   32 bits; range -2,147,483,648 to 2,147,483,647

short
   16 bits; range -32,768 to 32,767
   
byte
    8 bits; range 0 to 255 (no negative values)

double
   64 bits; maximum magnitude: :math:`1.7976931348623157(10^{308})`; 
   about 15 digits of accuracy
   
float
   32 bits; maximum magnitude: :math:`3.402823(10^{38})`; about 7 digits of accuracy

decimal     
   128 bits; maximum value: 79228162514264337593543950335; 
   28 digits of accuracy;  can exactly represents decimal values
   for financial operations; briefly discussed in *optional*
   :ref:`Decimal Type <decimal-type>`.

char
   See :ref:`char as integer <integer-char>`.
   
.. index:: cast

.. _cast:

Casting 
---------

While the mathematical ideas of 42 and 42.0 are the same, C# has specific types.
There are various places where numerical types get converted automatically by C# 
or explicitly by the programmer.  
A major issue is whether the new type can accurately represent the original value.

Going from ``int`` to ``double`` has no issue:  Any ``int`` can be exactly
represented as a ``double``.  Code like the following is fine:

.. code-block:: none

    csharp> int i = 33;
    csharp> double d = i;
    csharp> double x;
    csharp> x = 11;
    csharp> double z = i + 2.5;
    csharp> ShowVars(); 
    int i = 33
    double d = 33
    double x = 11
    double z = 35.5

The ``double`` variable ``d`` is initialized with the value of an ``int`` variable.
The ``double`` variable ``x`` is assigned a value using an ``int`` literal.
The ``double`` variable ``z`` is initialized with the value of a sum involving
both an ``int`` variable and a ``double`` literal.  As we have discussed before in 
:ref:`arithmetic`, the ``int`` is converted to a ``double`` before the addition
operation is done.

The other direction for conversion is more problematic:

.. code-block:: none

    csharp> double d= 2.7;
    csharp> int i;
    csharp> i = d;
    {interactive}(1,4): error CS0266: Cannot implicitly convert type 'double' to 'int'. 
    An explicit conversion exists (are you missing a cast?)

The ``int`` ``i`` cannot accurately hold the value 2.7.  
Since the compiler does this checking, looking only at types, not values, this even
fails if the the ``double`` happens to have an integer value:
    
.. code-block:: none

    csharp> double d = 2.0;
    csharp> int i = d;
    {interactive}(1,4): error CS0266: Cannot implicitly convert type 'double' to 'int'. 
    An explicit conversion exists (are you missing a cast?)

.. index:: truncate in cast
    
If you really want to possibly lose precision and convert a ``double`` to 
an ``int`` result, you *can* do it, but you must be explicit, using a *cast*
as the csharp error messages suggest. 

.. code-block:: none

    csharp> double d= 2.7;
    csharp> int i;
    csharp> i = (int)d;
    csharp> i;
    2
    
The desired result type name in parentheses ``(int)`` is a *cast*, telling the compiler
you really intend the conversion.  Look what is lost!  The cast does not
*round* to the nearest integer, it *truncates* toward 0, dropping the fractional
part, .7 here.

.. index:: Round function

Rounding is possible, but if you really want the ``int`` type, it takes two steps,
because the function ``Math.Round`` does round to a mathematical integer, but leaves
the type as ``double``!  To round ``d`` to an ``int`` result we could use:

.. code-block:: none

    csharp> i = (int)Math.Round(d); 
    csharp> i;
    3

You can also use an explicit cast from int to double.  This is generally not needed,
because of the automatic conversions, but there is one place where it is 
important:  if you want ``double`` division but have ``int`` parts.  Here is a 
quick artificial test:

.. code-block:: none

    csharp> int sum = 14;
    csharp> int n = 4;
    csharp> double avg = sum/n;
    csharp> avg;  
    3
    
Oops, integer division.  Instead, continue with:

.. code-block:: none

    csharp> avg = (double)sum/n;
    csharp> avg;
    3.5

We get the right decimal answer.  

This is a bit more subtle than it may appear:  
The cast to double, ``(double)``
is an operation in C# and so it has a *precedence* like all operations.  Casting
happens to have precedence higher than any arithmetic operation, so the expression is 
equivalent to::

    avg = ((double)sum)/n;

On the other hand, if we switch the order the other way with parentheses around the
division:

.. code-block:: none

    csharp> avg = (double)(sum/n);
    csharp> avg;
    3

then working *one* step at a time, ``(sum/n)`` is *integer* division, 
with result 3.  It is the 3 that is then cast to a double (too late)!

See the appendix :ref:`precedence`, listing all C# operations discussed in this book. 


.. index:: type; char
   char
   
.. _type-char:

Type char
----------

The type for an individual character is ``char``.  A ``char`` literal value is
a *single* character enclosed in *single* quotes, like ``'a'`` or ``'$'``.  
The literal for a
single quote character itself and the literal for a newline use 
*escape codes*, like in :ref:`Strings2`:  
The literals are ``'\''`` and ``'\n'`` respectively.

Be careful to distinguish a ``char`` literal like ``'A'`` 
from a string literal ``"A"``.

.. index:: Unicode

.. _integer-char:

**Char as integer**:  Though the ``char`` type has character literals 
and prints as a character,
internally a ``char`` is a *type of integer*, stored in 16 bits,
with the correspondence
between numeric codes and characters given by the *Unicode* standard.  
Unicode allows special symbol characters and alphabets of many languages.  
We will stick to the standard American keyboard for these characters.

Besides different alphabets, Unicode also has characters for all sorts of 
symbols: emoticons, chess pieces, advanced math....  See 
http://www.unicode.org/charts.  All the symbols can be represented as escape 
codes in C#, starting with ``\u`` followed by 4 hexadecimal digits.  For example
``\u262F`` produces a yin-yang symbol.

We mention the ``char`` type being numeric mostly because of errors 
that you can make that would otherwise be hard to figure out.  This code does
not concatenate the ``char`` symbols:

.. code-block:: none

    csharp> Console.WriteLine('A' + '-');
    110

What?  
We mentioned that modern computers are set up to easily work with the ``int``
type.  In arithmetic with *smaller* integral types the operands are first
automatically converted to type ``int``.  
An ``int`` sum is an ``int``, and that is
what is printed.  

You can look at the numeric values inside a ``char`` with a cast!

.. code-block:: none

    csharp> (int)'A';
    65
    csharp> (int)'-';
    45
 
So the earlier 110 is correct:  65 + 45 = 110.

For completeness: 
It is also possible to cast from small ``int`` back to ``char``.  
This may be useful for dealing with the alphabet
in sequence (or simple classical cryptographic codes):

.. code-block:: none

    csharp> 'A' + 1;       
    66
    csharp> (char)('A' + 1);
    'B'

The capital letter one place after A is B.

.. index::  type; Boolean or bool
   Boolean or bool

.. _type-boolean:

Type Boolean or bool
---------------------

There is one more very important value type, that we introduce here
for completeness, though we will not use it until
:ref:`If-Statements`.
Logical conditions are either true or false.  The type with just these
two values is *Boolean*, or *bool* for short.  The
type is named after George Boole, who invented what we now call
*Boolean algebra*.  Though it seemed like a useless mathematical curiosity 
when Boole invented it, a century later Boolean algebra turned out to be
at the heart of the implementation of computer hardware.

.. note::
   The Boolean literals are ``true`` and ``false``, with *no* quotes
   around them.  
   
With quotes they would be of type string, not Boolean!

Overflow to Positive Exercise
-------------------------------

We gave an example above in :ref:`type-int`,
adding two positive ``int`` values and 
clearly having an error, since the result was negative.  Declare
and initialize two positive ``int`` variables ``x`` and ``y``.  Experiment
with the initializations so

i.  Their product is too big to fit in an ``int`` AND
ii. The wrong overflow result for ``x*y`` is *positive*, not negative.


