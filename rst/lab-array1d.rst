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

- what to do if you run out of things to do


Tasks
-----

For this lab, we recommend that you write your code in a C# source
file (.cs). You can continue to work with a text editor and the
command-line tools directly, or you can use MonoDevelop.

#. Declare an array of integers::

      int[] myArray = new int[10];
      int[] myArray = new int[] { 7, 7, 3, 5, 5, 5, 1, 2, 1, 2 };

   The first declaration creates an array but leaves it up to you to
   do the initialization with your own data. The second is creating an
   array where the elements are taken from the bracketed list of
   values. We're going to use the second line for this lab.

#. Write a function, ``IsAscendingArray(myArray)``, that tests whether
   the list of values is sorted in ascending order. This can be done
   by writing a loop that goes from 1 to ``myArray.Length - 1`` and
   compares ``myArray[i-1]`` to ``myArray[i]``. An array is in
   ascending order if ``myArray[i] <= myArray[i+1]`` for ``i`` from 1 to
   ``myArray.Length-1``.

   If you write your loop carefully, you should also be able to
   determine whether a loop that has only one value is also sorted in
   ascending. If you reach the end of the loop, you know that all of
   the items are in ascending order. So this means the if statement
   inside of the loop is being used to figure out whether the data are
   not ascending. (If any pair of items is not in order, we know that
   the entire array is not in order. So we can print "Array is not
   ascending." and be done with it!)

   The function should print "Array is ascending" or "Array is not
   ascending" or some similar informative message.

#. Now create a few more arrays and initialize them with some data
   that is and is not ascending. We're going to use this to test the
   function fully::

      // clearly sorted in ascending per our definition
      int array1[] = new int[] { 1, 2, 3, 4, 5, 6 };

      // also clearly sorted but some items remain the same
      int array2[] = new int[] { 1, 2, 3, 3, 4, 4, 5, 6, 7 };

      // not ascending
      int array3[] = new int[] { 8, 6, 7, 5, 3, 0, 9 };

      IsAscendingArray(array1); // should print "Is ascending."
      IsAscendingArray(array2); // should print "Is ascending."
      IsAscendingArray(array3); // should print "Is not ascending."

#. Now that we've gotten this working, repeat the exercise to create a 
   new function that tests whether an array is arranged in descending
   order. This will introduce you to an important skill. Sometimes you
   absolutely need to create a function that is like another one but
   is slightly different. In most cases, you can copy/paste the code
   from another function but must rename the function (to have a
   meaningful name), i.e. ``IsDescendingArray()``. In addition, you
   will need to make sure the function's code does what it's supposed
   to do. This involves changing the comparison to check whether any
   given element is *less than* the hypothetical *minimum* of the
   array.


Need more work to do? Keep working!
-----------------------------------

#. Create a new function that will print the items of an array that
   are in ascending order, starting from the beginning of the array.
   For example, if we have this array::

      int myArray[] = { 1, 2, 10, 9, 10, 3, 1 };

   And we create a function that is named
   PrintAscendingValues(myArray).

   This function will print::

      1, 2, 10


#. Create another function that prints all *runs* that are in ascending
   order. A run is defined as any part of the array that is in
   order. A run can be just a single array item.

   So if we use the same array as above, we'd get output like this::

      Run 1: 1, 2, 10
      Run 2: 9, 10
      Run 3: 3
      Run 4: 1

#. Write a function that finds the minimum value in an array of
   integers. Start by assuming the first value of the array is the
   minimum. Iterate through the remaining array positions to see if
   any given value is lower than the "trial" minimum


   As with all of our previous examples, declare some arrays to test
   whether the minimum value has been correctly computed.

#. Write a function that computes the maximum value of an array of
   integers. You can probably modify the previous code to support this
   idea.

#. Write a function that returns (an integer) of the number of items
   in the array that are even. 

#. Write a function that returns (an integer) of the number of items
   in the array that are odd.

#. Given two arrays, ``a`` and ``b``, write a function that computes
   the pairwise sum (often called the vector sum) and puts the results
   in an array ``c``.  The function is declared as follows::

      static void PairwiseAdd(a, b, c);

   To test this out, you'll need to declare and initialize the arrays
   to be added. You'll also need to declare a third array to hold the
   results. You'll need to check that the arrays all have the same
   dimensionality before proceeding.

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
      
