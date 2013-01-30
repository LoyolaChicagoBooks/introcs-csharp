.. index::
   double:  PF4; recursion
   double:  SP1; history
   double:  history; Euclid
   double:  algorithms; greatest common divisor

.. _gcd:

Greatest Common Divisor
=========================

Euclid's Algorithm
-----------------------

The greatest common divisor of two non-zero integers is a great
example to illustrate the power of loops. Everyone learns about the
*concept* of a greatest common divisor when faced with a fraction that
is not in *reduced* form.

Consider the fraction :math:`\frac{2}{4}`, which is the same as
:math:`\frac{1}{2}`. This fraction can be reduced, because the
numerator and denominator both have greatest common factor of 2. That
is, :math:`\frac{2}{4} = \frac{1 \cdot 2}{2 \cdot 2}`. So the factor of 2 can
be canceled from both the numerator and the denominator.

Euclid (the mathematician from classic times and author of *Elements*)
is credited with having come up with a clever algorithm for how to
compute the greatest common divisor efficiently. It is written as
follows, where :math:`a \bmod b` means ``a % b`` in C#.

.. math::

   gcd(a, b) = gcd(b, a \bmod b)

   gcd(a, 0) = a


It is common in mathematics to list functions as one or more
*cases*. The way you read this is as follows:

- In general, the greatest common divisor of ``a`` and ``b`` is the
  same as computing the greatest common divisor of ``b`` and the
  remainder of ``a`` divided by ``b``. 

- In the case where ``b`` is zero, the result is ``a``. This makes
  sense because ``a`` divides itself and 0.

To gain some appreciation of how the definition *always* allows you to
compute the greatest common divisor, it is worthwhile to try it out
for a couple of numbers where you *know* the greatest common
divisor. For example, we already know that the greatest common divisor
of 10 and 15 is 5. Let's use Euclid's method to verify this:

- :math:`gcd(10, 15) = gcd(15, 10 \bmod 15) = gcd(15, 10)`

- :math:`gcd(15, 10) = gcd(10, 15 \bmod 10) = gcd(10, 5)`

- :math:`gcd(10, 5) = gcd(5, 10 \bmod 5) = gcd(5, 0)`

- :math:`gcd(5, 0) = 5`


Notice that in the example above, the first number (10) was smaller than 
the second (15), and the first transformation just swapped the numbers,
so the larger number was first.  Thereafter the first number is always
larger.

In other words, Euclid's method is smart enough to work for 10 and 15
and 15 and 10. And it must. After all, the greatest common divisor of
these two numbers is always 5 as the order doesn't matter.

GCD "Brute Force" Method
------------------------

Now that we've gotten the preliminaries out of the way and have a basic 
mathematical explanation for how
to calculate the greatest common divisor, 
we'll take a look at how to translate this into code using the
machinery of while loops that you've recently learned.

The way GCD is formulated above is, indeed, the most clever way to 
calculate the greatest common divisor.
Yet the way we learn about the greatest common divisor in elementary 
school (at least at first) is to 
learn how to factor the numbers a and b, often in a brute force way. 
So for example, when calculating the 
greatest common divisor of 10 and 15, we can immediately see it, 
because we know that both of these 
numbers are divisible by 5 (e.g. 5 * 2 = 10 and 5 * 3 = 15). 
So the greatest common divisor is 5.

But if we had something more tricky to do like 810 and 729, 
we might have to think a bit more.

Before we learn to find the factors of numbers, 
we will often just "try" numbers until we get the 
greatest common divisor. This sort of trial process can take place in a loop, 
where we start at 1 and end at min(a, b). Why the minimum? 
We know that none of the values after the minimum can divide both a and b
(in integer division),
because no larger number can divide a smaller positive number. The smaller 
number would be the (non-zero) remainder.

Now take a look at a basic version of GCD:

.. literalinclude:: ../source/examples/g_c_d_basic/g_c_d_basic.cs
   :start-after: chunk-gcd-begin
   :end-before: chunk-gcd-end
   :linenos:

This code works as follows:

- We begin by finding ``Math.Min(a, b)``. 
  This is how to compute the minimum of any two
  values in C#. Technically, we don't need to use the minimum of a and b, 
  but there is no
  point in doing any more work than necessary. 
- We'll use the variable ``i`` as the loop index, starting at 1.
- The variable ``gcd`` will hold the largest currently known common divisor.
  We start with 1, which divides any integer, and we will
  look for a higher value that also divides a and b.
- The line ``while (i <= n)`` is used to indicate that we are 
  iterating the values of
  ``i`` until the minimum of ``a`` and ``b`` (computed earlier) is reached.
- The line ``if (a % i == 0 && b % i == 0)`` 
  is used to check whether we have found a
  new value that replaces our previous *candidate* for the GCD. 
  A value can only be
  a candidate for the GCD if it divides a and b without a remainder. 
  The modulus 
  operator ``%`` is our way of determining whether there is a 
  remainder from the
  division operation ``a / i`` or ``b / i``. 
- The line ``i++`` is our way of going to the next value of ``i`` 
  to be tested as the new GCD.
- When this loop terminates, the greatest common divisor has been found. 

So this gives you a relatively straightforward way of calculating the 
greatest common divisor. While simple, it is not necessarily the most 
efficient way of determining the GCD. If you think about what is going on, 
this loop could run a significant number of times. 
For example, if you were calculating the GCD two very large numbers, say,
one billion (1,000,000,000) and two billion (2,000,000,000) 
it is painfully evident that you would consider a large number of values 
(a billion, in fact) before obtaining
the candidate GCD, which we know is 1,000,000,000.

Brute-Force GCD Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~

The code above goes though all integers 2 through ``min(a, b)``.  That is
not generally necessary when the GCD is greater than 1, 
even with a brute-force mindset.   Write a
``g_c_d_basic_faster.cs`` to do this with a slightly different
``GreatestCommonDivisor`` function.

GCD Subtraction Method
----------------------

The subtraction method (also attributable to Euclid) to compute the
Greatest Common Divisor works as follows:

- Based on the *mathematical* definition in the previous section, the
  greatest common divisor algorithm saves a step when we already have
  ``a`` and ``b`` in the *right order*.

- The *right order* means that :math:`a > b`. As we noted earlier, the
  cleverness of the *mathematical* definition is that ``a`` and ``b``
  are swapped as the first step to ensure that :math:`a > b`, after
  which we can repeatedly divide to get the GCD.

- Division, of course, is a form of repetitive subtraction, so the way
  to divide by ``b`` is to repeatedly subtract it (from a) until ``a``
  is no longer greater than ``b``.  

- The subtraction method basically makes no attempt to put ``a`` and
  ``b`` in the right order. Instead, we just write similar loops to
  allow for the possibility of either order.

- A simple check must be performed to ensure that the approach of
  repeated subtraction actually resulted in the GCD. This will happen
  if ``a`` and ``b`` bump into one another, thereby meaning that we
  have computed the GCD.

.. literalinclude:: ../source/examples/g_c_d_subtraction_method/g_c_d_subtraction_method.cs
   :start-after: chunk-gcd-begin
   :end-before: chunk-gcd-end
   :linenos:

A look at the source code more or less follows the above explanation.

Let's start by looking at the inner loop at line 5, ``while (a >
b)``. In this loop, we are repeatedly subtracting ``b`` from ``a``,
which we know we can do, because ``a`` started out as being larger
than ``b``.  At the end of loop ``a`` is reduced to either

#. ``b``, in which case ``b`` exactly divided the earlier ``a``,
   and ``b`` is the GCD, or 
#. a number less than ``b``, namely 
   :math:`a \bmod b` (or in C# terms ``a % b``), and the process continues....

The loop on line 9 is similar to the loop in line 5. For the same
reasons as we already explained, ``b`` ends up equal to ``a``,
which is the GCD, or ``b`` ends up as 
:math:`b \bmod a`. 

As discussed above, if ``a`` and ``b`` end up as the same number,
that is the GCD.  On the other hand, 
the first GCD algorithm example showed how remainders may need to be to
be calculated over and over.  The outer loop in this version keeps this up
until ``a`` and ``b`` are reduced to equal
values.  At this point the inner loops would make no further changes, 
and the common value is the GCD.

As an exercise to the reader, you may want to consider adding some
``Console.WriteLine()`` statements to print the values of ``a`` and
``b`` within each loop, and after both loops have executed. It will
allow you to see in visual terms how this method does its work.

.. index::  greatest common divisor; iterative

.. _gcd-remainder-loop:

GCD Remainder Loop
--------------------

There are several ways to code the shorter Euclidean algorithm at the beginning of this
GCD section.  It is a repetitive pattern, 
and a loop can be used.  There are two parameters, ``a`` and ``b``, to the gcd, 
and they can be successively changed, suggesting a loop.  What is the continuation
condition?  You stop when ``b`` is 0, so you continue while ``b != 0``.
The parameters ``a`` and ``b`` need to be replaced by ``b`` and ``a % b``.
One extra variable needs to be introduced to make this double change work.  The simplest
is to introduce a variable ``r`` for the remainder.  Check and see for yourself that you
need an extra variable like ``r``.
This code is from :repsrc:`g_c_d_remainder_loop/g_c_d_remainder_loop.cs`:

.. literalinclude:: ../source/examples/g_c_d_remainder_loop/g_c_d_remainder_loop.cs
   :start-after: gcd chunk
   :end-before: gcd end chunk

.. index::  
   double:  recursion; greatest common divisor

.. _gcd-recursive:


Preview: Recursive GCD
----------------------

The first statement of Euclid's algorithm said (in C#) when  ::
    
    gcd(a, b) = gcd(b, a % b)

It is saying the result of the function with one set of parameters is equal to
calling the function with another set of parameters.  If we put this into a
C# function definition, ti would mean the instructions for the function say 
to *call itself*.  This is a broadly useful technique called *recursion*, 
where a function calls *itself* inside its definition. 
We don't expect you to master this
technique immediately but do feel that it is important you at least
*hear* about it and see its tremendous power:

.. literalinclude:: ../source/examples/g_c_d_euclid_recursive/g_c_d_euclid_recursive.cs
   :start-after: chunk-gcd-begin
   :end-before: chunk-gcd-end
   :linenos:

- Recalling our earlier definition, the case :math:`gcd(a, 0) = a` is
  handled by lines 3-5.

- And the case :math:`gcd(a, b) = gcd(b, a \bmod b)` is handled by
  line 10.

- Lines 4 and 7-9 exist to show you all of the *steps* that Euclid's
  algorithm takes to compute the greatest common divisor.

The recursive version of the ``gcd`` function *refers to itself*
by *calling* itself.  Though this seems circular, you can see
from the examples that it works very well.  The important point is that
the calls to the same function are not completely the same:
*Successive* calls have *smaller* second numbers, and the second
number eventually reaches 0, and in that case 
there is a direct final answer.  Hence the function is not really circular.

This recursive version is a much more direct translation of the original mathematical
algorithm than the looping version.

The general idea of recursion is for a
function to call itself with *simpler* parameters, until a simple enough place
is reached, where the answer cam be directly calculated.
