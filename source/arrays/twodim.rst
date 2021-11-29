
.. _multi-dimensional-arrays:

Multi-dimensional Arrays
========================================

.. index:: array; two dimensional
   two dimensional array

Rectangular Arrays (Two Dimensional)
--------------------------------------

You should be familiar with one dimensional arrays. The data in arrays
may be any type. While a one dimensional array
works for a sequence of data, 
we need something more for a two dimensional table,
where data values vary over both row and column.  

If we have a table of integers, for instance with three
rows and four columns::

    2 4  7 55
    3 1  8 10    
    6 0 49 12

We could declare an array variable of the right size as ::

    int[,] table = new int[3, 4];

Multiple indices are separated by commas inside the square brackets.
In declaring an array type, no indices are included so the ``[,]`` 
indicates a two dimensional array.  Where the ``new`` object is being created,
the values inside the square brackets give each dimension.

In general the notation for a two dimensional array declaration is:

    **type** ``[, ]`` **variableName** 
    
and to create a new array with default values:

    new **type** ``[`` *intExpression1*\ ``,`` *intExpression2* ``]`` 
    
where the expressions evaluate to integers for the dimensions.

To assign the 8 in the table above, consider that it is in the second
row in normal counting, but we start array indices at 0, so there are
rows 0, 1, and 2, and the 8 has row index 1. 
Again starting with index 0 for columns, the 8 is at index
2. We can assign a value to that position with ::

   table[1, 2] = 8;

In fact a two dimensional array just needs two indices that could mean 
anything.  For instance, it was just the standard convention, 
calling the left index the row.  They could have been switched everywhere, and
assume the notation ``table[column, row]``::
 
    int[,] table = new int[4, 3];
    table[2, 1] = 8;

but we will *stick with* the original ``[row, column]`` model. 

Data indexed by more than two integer indices can be stored in a higher
dimension array, with more indices between the square braces.  We
will only consider two dimensional arrays in the examples here.

A shorthand for initializing all the data in the table, 
analogous to initializing one dimensional arrays is:: 

    int[, ] table = { {2, 4,  7, 55}, 
                      {3, 1,  8, 10}, 
                      {6, 0, 49, 12} };

All rows must be the same length when using this notation.   

Often two dimensional arrays, like one dimensional  arrays, are processed
in loops. Multiple dimension arrays are often processed in nested loops.
We could print out this table using columns 5 spaces wide with the code:

.. literalinclude:: ../../source/examples/print_table/print_table.cs
   :start-after: };
   :end-before: chunk

If we wanted to make a more general function out of that code,
we have a problem:  the number of rows and columns were literal values
that we knew.  We need something more general.  For one dimensional
arrays we had the Length property, but now there are more than one
lengths!  

The following csharp sequence illustrates the syntax needed::

    csharp> int[, ] table = { {2, 4,  7, 55}, 
          >                   {3, 1,  8, 10}, 
          >                   {6, 0, 49, 12} };
    csharp> table.Length;
    12
    csharp> table.GetLength(0);
    3
    csharp> table.GetLength(1);
    4
    csharp> foreach (int n in table) {
          >    Console.WriteLine(n);
          > }
    2
    4
    7
    55
    3
    1
    8
    10
    6
    0
    49
    12

Note:

- The meaning for the Length property,
  is now the *total* number of elements, (3)(4) = 12.
- The separate method ``GetLength`` is needed to find the number of rows and columns.
  The entries in the list of array indices in the multi-dimensional array notation
  are themselves indexed to provide the ``GetLength`` method parameter for each dimension.
  In this case index 0 gives the row length (left index of the array notation),
  and 1 gives the column length (right index of the array notation).
- The ``foreach`` statement behavior is consistent with the ``Length`` property, giving *all*
  the elements, row by row.  More generally, the rightmost indices vary most rapidly
  as the ``foreach`` statement iterates through all elements.

Just replacing 3 and 4 by ``table.GetLength(0)`` and ``table.GetLength(1)`` in the
table printing code would make it general.

A more elaborate table might include row and column sums::

       2   4   7  55 |  68
       3   1   8  10 |  22
       6   0  49  12 |  67
     ---------------------
      11   5  64  77 | 157


For example, the following function from example file 
:repsrc:`print_table/print_table.cs`,
prints out a table of integers 
neatly, including row and column sums.  It illustrates
a number of things.  It shows the interplay between
one and two dimensional arrays, since the row and column sums are
just one dimensional arrays.

Now that we are using arrays, 
we can easily look at the same collection of data repeatedly.
It is possible to look at the data one time to just see its maximum
width, and then go through again and print data using a column
width that is just large enough for the longest numbers.
When looking through the data for string lengths, the row and column
structure is not important, so the code illustrates ``foreach`` loops
to chug through all the data.  We use the earlier trick in
:ref:`modular_mult_table`, creating a custom format string to make columns
the right width.

The code refers once to the earlier ``StringOfReps`` in :ref:`lab-loops` 
for the row of dashes setting off the column sums:

.. literalinclude:: ../../source/examples/print_table/print_table.cs
   :start-after: chunk
   :end-before: chunk


.. index:: exercise; row and column numbering
   row and column numbering exercise

.. _row-col-number-exercise:

Row and Column Numbering Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a function that sets the values in a given
rectangular array to 10 \* (row index +1) + column index + 1, with the
normal row and column indices, starting from 0. For example
an array with two rows
and five columns would end up with values below. Your method should set
the values in the array, not print them out::

     11 12 13 14 15
     21 22 23 24 25 

If there are no more than 9 rows or columns, this display gives row and
column numbers neatly for the normal human counting system, starting from 1.

.. index:: exercise; varying column width
   varying column width exercise

.. _varying-width-columns-exercise:

Varying Column Width Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Copy the project file :repsrc:`print_table/print_table.cs` to a file
:file:`print_varying_width_table.cs` in a projet of yours. 
Edit it so that *each* column
is only as wide as it needs to be: the width for the widest entry in
that column.  
The earlier data would now print as::

      2 4  7 55 |  68
      3 1  8 10 |  22
      6 0 49 12 |  67
     ----------------
     11 5 64 77 | 157

Calculate each of these widths *only once*.
Hint: Create an array of widths and an array of format strings.


.. index::
   single: array; of arrays 
   single: array; two-dimensional, ragged 

Advanced topic: Array of Arrays
---------------------------------

Since you can have an array of any type, it is also possible to have an
*array of arrays*.  


You could create a table with shape like the initial example 
in :ref:`multi-dimensional-arrays`  ::

   int[][] table2 = new array[3][4];
   
and refer to an element still by row and column index:::

   table2[1][2] = 4;
   
The notational difference so far is just that each index in enclosed in
separate square brackets, with no commas.

This takes somewhat more memory and is longer to
access than the multidimensional arrays that we have been talking about
with the comma-separated notation.  For most uses, when you want to
refer to a rectangular table of data, like above,
this new version has little to
offer.   

There are a couple of reasons why you might want this format.

First you may have functions that operate on one dimensional arrays,
and individual rows of ``table2`` are one dimensional arrays:
``table2[1]`` has type ``int[]``.  On the other hand, with the
earlier ``table`` with type  ``int[,]``, references to part of
the array must always include a comma, so ``tabel[1]`` would
not refer to a row, but would be a syntax error.

Also in an array of arrays, since each row is an independent array, 
their lengths can *vary*.  
Here is code to make a doubly indexed "triangular" collection 
(of 0 values).
Each row must be separately created as a new array::

   int[][] tri = new int[4][]; //create four null int[] elements
   for (int i = 0; i < tri.Length; i++) { // Length 4 (rows)
      tri[i] = new int[i+1];  // each row has a different length
   }
   
With ``tri`` constructed as above:

- ``tri[3, 3]`` would given a compiler error: no changing ``[][]`` to ``[, ]``.
- ``tri[3][3]`` would refer to an element.
- ``tri[1][3]`` would given a run-time out-of-bounds error.
  since ``tri[1]`` is an array of length 2.
