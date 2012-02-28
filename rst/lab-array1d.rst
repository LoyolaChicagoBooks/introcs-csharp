.. _lab-arrays1d:

.. index::
   single: labs; arrays

Lab: Arrays
==================================

Overview
--------

In this lab, we'll learn how to work with arrays. Arrays are
fundamental to computer science, especially when it comes to
formulating various *algorithms*. We've already learned a bit about
arrays through the ``string`` data type. In many ways, a character
string reveals the secrets of arrays:

- each element of a string is a common type (char)

- we can use indexing to find any given character, e.g. ``s[i]`` gives
  us the character at position ``i``.

- we know that the string has a finite length, e.g. ``s.Length``.

So you've already learned the *concept*. But what if we want to have
arrays that can hold different kinds of data, for example, integer or
floating point data? That's why we need this lab.

Goals
-----

In this lab, we're going to learn:

- how to create arrays that hold numerical data.

- how to populate an array with data

- how to use the tools of loops and decisions to do something interesting with the data

- how to print the data


Tasks
-----

Start from the stub in the projects, :file:`Labs/Array1D/ArrayLab.cs`.
It si set up as a MonoDevelop Project, though you may use a different editor
and use command line tools if you like.  Complete the body of a function
for each main part, and call each function in ``Main`` several times with
actual parameters chosen to test it well.  To label your illustrations, make
liberal use of the first function, PrintNums, to display and label inputs 
and outputs.  Where several tests are appropriate for the same function, 
you might want to write a separate testing function that prints 
and labels inputs, passes the data on to the function being tested,
and prints results.

Recall that you can declare an array in two ways::

      int[] myArray1 = new int[10];
      int[] myArray2 = { 7, 7, 3, 5, 5, 5, 1, 2, 1, 2 };

The first declaration creates an array initialized to
all zeroes. The second creates an
array where the elements are taken from the bracketed list of
values. We're going to use the second line for this lab.

#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: PrintInts chunk
      :end-before: ReadInts chunk

   This will be handy for labellng later tests.  Note that you end
   on the same line, but a later label can start with ``\n`` 
   to advance to the next line.

#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: ReadInts chunk
      :end-before: Minimum chunk

   This will allow user tests.  The earlier input utility functions
   are included at the end of the class.

#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: Minimum chunk
      :end-before: CountEven chunk

#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: CountEven chunk
      :end-before: PairwiseAdd chunk

#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: PairwiseAdd chunk
      :end-before: NewPairwiseAdd chunk

   To test this out, you'll need to declare and initialize the arrays
   to be added. You'll *also* need to declare a third array to hold the
   results. Make sure that the arrays all have the same
   dimensionality before proceeding.
   
#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: NewPairwiseAdd chunk
      :end-before: IsAscending chunk
      
   See how this is different from the previous part!

#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: IsAscending chunk
      :end-before: PrintAscendingValues chunk

   This has some pitfalls.  You will need more tests that the ones 
   in the documentation!  You can code this with
   a "short-circuit" loop.  What do you need to find to be
   immediately sure you know the answer?
   
#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: PrintAscendingValues chunk
      :end-before: PrintRuns chunk


#. Complete and test the function with documentation and heading:

   .. literalinclude:: ../projects/Labs/Arrays1D/ArrayLab.cs
      :start-after: PrintRuns chunk
      :end-before: PrintRuns chunk

#. Given two arrays, ``a`` and ``b`` that represent vectors. Write a
   function that computes the vector dot product of these two
   floating point arrays. The vector dot product (in mathematics) is defined as the 
   sum of ``a[i] * b[i]`` (for all i). Here's an example of how it
   should work::

      double[] a = new double[] { 1.0, 2.0, 3.0 };
      double[] b = new double[] { 4.0, 2.0, -1.0 };

      double dotProduct = VectorDotProduct(a, b);
      Console.WriteLine("The dot product is {0}", dotProduct);

      // Should print 1.0 * 4.0 + 2.0 * 2.0 + 3.0 * -1.0 = 5.0
      
   From here on, create your own headings.
      
#. Suppose we have loaded an array with the digits of an integer,
   where the highest power is kept in position 0, next highest in
   position 1, and so on. The ones position is always at position
   array.Length - 1::


      int[] digits = { 1, 9, 6, 7 };


   Without showing you the code, here is how you would convert a
   number from its digits to an integer::

      num = 0
      num = 10 * 0 + 1 = 1
      num = 10 * 10 + 9 = 19
      num = 10 * 19 + 6 = 196
      num = 10 * 196 + 7 = 1967
      done!

   Write a function that converts the array of digits representing
   a base 10 number to its ``int`` value 
   (or for really long integers, you are encouraged to use
   a ``long`` data type). Note that we only allow single digit
   numbers to be placed
   in the array, so negative numbers are not addressed.

#. Suppose that we not only have the digits but also the *base* that
   in which the number is represented. (The base can be at most
   10 if it uses only digits for place value.)
   Write a function (or revise the
   previous solution) to return the int or long represented.
   For example if {1, 0, 0, 1, 1} represents a base 2 number,
   19 is returned.

