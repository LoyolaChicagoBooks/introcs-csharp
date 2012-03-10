Algorithms using While
======================

.. index::
   double:  %; binary operation
   double:  %; remainder
   double:  remainder; binary operation
   double:  PF4; recursion
   double:  SP1; history
   double:  history; Euclid

.. _gcd:

Greatest Common Divisor
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
where we start at 1 and end at min(a, b)? Why the minimum? 
Well, we know that none of the values after the minimum can divide both a and b
(in integer division) because either a / b = 0 or b / a = 0, if a != b.

You can verify this by picking any two different values of a and b. 
For example 810/729 > 0 and 729/810 = 0.

Without further ado, let's take a look at a basic version of GCD:

.. literalinclude:: ../projects/GCD/GCDBasic/GCDBasic.cs
   :start-after: chunk-gcd-begin
   :end-before: chunk-gcd-end
   :linenos:

This code works as follows:

- We begin by finding ``Math.Min(a, b)``. 
  This is how to compute the minimum of any two
  values in C#. Technically, we don't need to use the minimum of a and b, 
  but there is no
  point in doing any more work than necessary. 
  We'll use the variable ``i`` as the loop index
  and the variable ``gcd`` will hold the currently known value of the GCD.

- The line ``i = gcd = 1`` means we'll start i at 1 
  and assume that the GCD is one until
  we find a higher value that also divides a and b.

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

- The line ``i = i + 1`` is our way of going to the next value of ``i`` 
  to be tested as the new GCD.

- When this loop terminates, the greatest common divisor has been found. 

So this gives you a relatively straightforward way of calculating the 
greatest common divisor. While simple, it is not necessarily the most 
efficient way of determining the GCD? If you think about what is going on, 
this loop could run a significant number of times. 
For example, if you were calculating the GCD two very large numbers, say,
one billion (1,000,000,000) and two billion (2,000,000,000) 
it is painfully evident that you would consider a large number of values 
(a billion, in fact) before obtaining
the candidate GCD, which we know is 1,000,000,000.

GCD Subtraction Method
----------------------

The subtraction method (also attributable to Euclid) to compute the
Greatest Common Divisor works as follows:

- Based on the *mathematical* definition in the previous section, the
  greatest common divisor algorithm *works best* when we already have
  ``a`` and ``b`` in the *right order*.

- The *right order* means that :math:`a > b`. As we noted earlier, the
  cleverness of the *mathematical* definition is that ``a`` and ``b``
  are swapped as the first step to ensure that :math:`a > b`, after
  which we can repeatedly divide to get the GCD.

- Division, of course, is a form of repetetive subtraction, so the way
  to divide by ``b`` is to repeatedly subtract it (from a) until ``a``
  is no longer greater than ``b``.

- The subtraction method basically makes no attempt to put ``a`` and
  ``b`` in the right order. Instead, we just write similar loops to
  allow for the possibility of either order.

- A simple check must be performed to ensure that the approach of
  repeated subtraction actually resulted in the GCD. This will happen
  if ``a`` and ``b`` bump into one another, thereby meaning that we
  have computed the GCD.

.. literalinclude:: ../projects/GCD/GCDSubtractionMethod/GCDSubtractionMethod.cs
   :start-after: chunk-gcd-begin
   :end-before: chunk-gcd-end
   :linenos:


A look at the source code more or less follows the above explanation.

Let's start by looking at the inner loop at line 5, ``while (a >
b)``. In this loop, we are repeatedly subtracting ``b`` from ``a``,
which we know we can do, because ``a`` started out as being larger
than ``b``.  At the end of loop, we know one of two things:

    #. ``a`` divides ``b`` perfectly, meaning there is no remainder.
    #. ``a`` doesn't divide ``b`` perfectly, meaning there is a
       remainder.
    #. This loop, therefore is computing :math:`a \bmod b` (or in C#
       terms ``a % b``.

The loop on line 9 is similar to the loop in line 5. For the same
reasons as we already explained, this loop therefore is computing
:math:`b \bmod a`. 

So the question is: Why the outer loop? As it turns out, the simple
explanation is that we need to make sure that ``a`` and ``b`` are the
same. Per the definition, we need to ensure that ``a`` is the result
of :math:``gcd(a, 0)``. So extra passes may be required to cause
*convergence*.

As an exercise to the reader, you may want to consider adding some
``Console.WriteLine()`` statements to print the values of ``a`` and
``b`` within each loop, and after both loops have executed. It will
allow yout see in visual terms how this method does its work.



Preview: Recursive GCD
----------------------

As it turns out, we can transform the earlier definition of greatest
common divisor (as formulated by Euclid) directly into C# using a
technique known as *recursion*, where a function calls *itself*
inside its definition. We don't expect you to master this
technique immediately but do feel that it is important you at least
*hear* about it and see its tremendous power:

.. literalinclude:: ../projects/GCD/GCDEuclidRecursive/GCDEuclidRecursive.cs
   :start-after: chunk-gcd-begin
   :end-before: chunk-gcd-end
   :linenos:

- Recalling our earlier definition, the case :math:`gcd(a, 0) = a` is
  handled by lines 3-6.

- And the case :math:`gcd(a, b) = gcd(b, a \bmod b)` is handled by
  line 11.

- Lines 4 and 8-10 exist to show you all of the *steps* that Euclid's
  algorithm takes to compute the greatest common divisor.

The mathematical definition of gcd *refers to itself* in its own definition.  
The recursive version of the ``gcd`` function *refers to itself*
by *calling* itself.  Though this seems circular, you can see
from the examples that it works very well.  The important point is that
the calls to the same function are not completely the same:
*Successive* calls have *smaller* second numbers, and the second
number eventually reaches 0, and in that case 
there is a direct final answer.
