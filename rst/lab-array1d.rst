.. _lab-arrays1d:

.. index::
   single: labs; arrays

Lab: Arrays
==================================

Overview
--------

In this lab, we'll learn how to work with arrays. Arrays are fundamental to computer science, especially when it comes to formulating various *algorithms*. We've already learned a bit about arrays through the ``string`` data type. In many ways, a character string reveals the secrets of arrays:

- each element of a string is a common type (char)
- we can use indexing to find any given character, e.g. ``s[i]`` gives us the character at position ``i``.
- we know that the string has a finite length, e.g. ``s.Length``.

So you've already learned the *concept*. But what if we want to have arrays that can hold different
kinds of data, for example, integer or floating point data? That's why we need this lab.

Goals
-----

In this lab, we're going to learn:

- how to create arrays that hold numerical data.

- how to populate an array with data

- how to use the tools of loops and decisions to do something interesting with the data

- how to print the data

- etc.


Tasks
-----

For this lab, we recommend that you write your code in a C# source file (.cs). You can continue to 
work with a text editor and the command-line tools directly, or you can use MonoDevelop.

#. Declare an array of integers::

      int[] myArray = new int[10];
      int[] myArray = new int[] { 7, 7, 3, 5, 5, 5, 1, 2, 1, 2 };

   The first declaration creates an array but leaves it up to you to do the initialization with
   your own data. The second is creating an array where the elements are taken from the bracketed
   list of values. We're going to use the second line for this lab.

#. Write a function, ``IsArrayAscending(myArray)``, that tests whether
   the list of values is increasing. This can be done by writing a
   loop that goes from 0 to the length of the array,
   ``myArray.Length`` and checks each value, ``myArray[i]`` for
   whether it is greater than the maximum value found thus far.  Hint:
   Declare a variable ``max`` that is assumed to be the first element
   of the array, ``myArray[0]`` and use a ``do ... while`` loop.

   The function should print "Array is ascending" or "Array is not
   ascending" or some similar informative message.

#. What we have done in the previus step is to determine whether an
   array is *sorted* in ascending order or not. A sorted array (in
   ascending order) is where all consecutive elements are either the
   same or increasing e.g. ``myArray[i] <= myArray[i+1]``. Descending
   order can be determined by using ``>=`` instead of ``<=``.
   
#. Call the function::

      IsArrayAscending(myArray);

#. Now create a few more arrays and initialize them with some data
   that is and is not ascending. We're going to use this to test the
   function fully::

      // clearly sorted in ascending per our definition
      int array1[] = new int[] { 1, 2, 3, 4, 5, 6 };

      // also clearly sorted but some items remain the same
      int array2[] = new int[] { 1, 2, 3, 3, 4, 4, 5, 6, 7 };

      // not ascending
      int array3[] = new int[] { 8, 6, 7, 5, 3, 0, 9 };

      IsArrayAscending(array1);
      IsArrayAscending(array2);
      IsArrayAscending(array3);

#. Now that we've gotten this working, repeat the exercise to create a 
   new function that tests whether an array is arranged in descending
   order. This will introduce you to an important skill. Sometimes you
   absolutely need to create a function that is like another one but
   is slightly different. In most cases, you can copy/paste the code
   from another function but must rename the function (to have a
   meaningful name), i.e. ``IsArrayDescending()``. In addition, you
   will need to make sure the function's code does what it's supposed
   to do. This involves changing the comparsion to check whether any
   given element is *less than* the hypothetical *minimum* of the
   array.



If you finish early
--------------------

#. Create a new function that will print the items of an array that
   are in ascending order, starting from the beginning of the array.
   For example, if we have this array::

      int myArray[] = { 1, 2, 10, 9, 10, 3, 1 };

   And we create a function that is named
   PrintAscendingValues(myArray).

   This function will print::

      1, 2, 10


#. Create another function that prints all *runs* that are in ascendin
   order. A run is defined as any part of the array that is in
   order. A run can be just a single array item.

   So if we use the same array as above, we'd get output like this::

      Run 1: 1, 2, 10
      Run 2: 9, 10
      Run 3: 3
      Run 4: 1


  

   
