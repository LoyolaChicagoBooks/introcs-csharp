.. index:: 
   single: arrays; one dimensional

.. _one-dim-arrays:

One Dimensional Arrays
============================ 

A string is an immutable sequence of characters.  Arrays provide more general sequences, 
with the same indexing notation, but with free choice of the type of the items in the
sequence, and the ability to change the elements in the sequence.

For example, if we want the type for an array with ``int`` elements, it is ``int[]``.
In general for any element type, the type for an array of the element type is

    **type**\ ``[]``

so ::

   int[] a;

declares ``a`` to refer to an array containing ``int`` elements.  You do *not*
know how many elements will be allowed in this array from this declaration.  
We must give further information to create the corresponding array object.  
All object can be created using the ``new`` syntax.  An array must get a definite
length, which can be a literal integer of any integer expression.  For example ::

   int[] a;
   a = new int[4];
   
or combined with the declaration, ::

   int[] a = new int[4];

creates an array that holds 4 integers.  The elements of the array must get initial values.
Numerical arrays get initialized to all 0's with this syntax.

For a variety of reasons, including bookkeeping by the compiler, the actual data for
an array is *not* stored directly in the memory location allocated by the declaration.
The array could have any number of items, and hence the memory requirements are not known
at compile time.  Like all other object (as opposed to primitive) types,
what is actually stored at the memory location declared for ``a`` is a *reference* to the
actual place where the data for the array is stored.  
In actual compiler implementation this reference is an address in memory.
In diagrams we will illustrate object references with an arrow *pointing* to the actual 
location for the object's data.  For example after ``a`` is initialized:

.. image:: images/newArray1.png
   :alt: new array
   :align: center

The small box beside ``a`` is meant to indicate the memory space allocated when ``a`` is
declared.  As you can see that space does not actually contain the array, but only a 
*reference* to the array, pointing to the actual sequence of data for the array.
To make it easy to refer to the elements in the diagram, we also label the indices 
associated with each element, though they are not actual a part of what is stored in memory.

The general syntax to create a new array is

   ``new`` **type**\ ``[`` *length* ``]``
   
After the type, there are square brackets enclosing an expression for the length
of the array - this length is unchangeable after creation.


The elements inside an array can to referenced with the same index notation used
earlier for strings. :: 

    a[2]
    
refers to the element at index 2 (third element because of 0 based indexing).

Unlike with strings, this element can not only be read, but also be assigned to::

    a[0] = 7;
    a[1] = 5;
    a[2] = 9;
    a[3] = 6;

These four assignment statements 
would replace the original 0 values for each element in the array.

This is a verbose way to specify all array values. An array with the
same final data could be created with the single declaration::

   int[] b = {7, 5, 9, 6};

.. image:: images/newArray2.png
   :alt: new array initialized with braces
   :align: center

The list in braces ONLY is allowed as an initialization of a variable
in a declaration, not in a later assignment statement.  
Technically it is an initializer, not an array literal.

Individual array elements can *both* be used in expressions, and be assigned to. 
Continuing with the
earlier example code::

    a[2] = 4*a[1] - a[3];

``a[2]`` now equals 4\*5 - 6 = 14.

Arrays, like strings, have a ``Length`` property::

    Console.WriteLine(b.Length); // prints 4

Just as we saw that using a variable for an index was useful with
strings, array elements are almost always referred to with an index
variable in practice.  A very common pattern is to deal with each element in sequence,
and the syntax is the same as for a string.  Print all elements of array ``b``::

    for (int i= 0; i < b.Length, i++) { 
       Console.WriteLine(b[i]); 
    }
    
You could also use ``while`` syntax.  The foreach syntax would be::

   foreach( int x : b) {
      Console.WriteLine(x);
   }

The int type for ``x`` matches the element type or the array ``b``.

The shorter ``foreach`` syntax is not as general as the ``for`` syntax.  
For example, to print only the first 3 elements of b::

   for(int i= 0; i < 3; i++) {
      Console.WriteLine(b[i]);
   }

but the ``foreach`` syntax would not work, since it must process *all* elements.

Also use the ``for`` syntax to assign new values to the array elements, 
rather than just use the values in expressions::

   for(int i= 0; i < b.Length; i++) {
      b[i] = 5*i;
   }
   
Now the array ``b`` of our earlier examples (of length 4) would contain 0, 5,
10, and 15.

.. index::
   double:  command line; parameters
   double:  Main; parameters

.. _command-line-param:

.. rubric:: Parameters to Main

The Main function may take an array of strings as parameter, as in example 
:file:`PrintParam.cs`:

.. literalinclude:: ../examples/PrintParam.cs
   :start-after: chunk
   :end-before: chunk

By convention, the parameter name is args.  

Compile and run the program from the command line.
Run it again with some things at the end of the line like::

     mono PrintParam.exe hi there 123

This should print for you::

    There are 3 command line parameters.
    hi
    there
    123

See what quoted strings do.  Run the command::

     mono PrintParam.exe "hi there" 123

This should print for you::

    There are 2 command line parameters.
    hi there
    123
    
The quotes are important in many places.  For instance the **message** in the 
``hg commit -m message`` command must be one parameter.  
That generally requires quotes, unless you are given to one-word descriptions.

Adder Command Line Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``Adder.cs`` calculates and prints the sum of command line parameters, so ::

    mono Adder.exe 2 5 22
    
would print 29.


..  later
    example `arraysFor <../examples/arraysForfiles.zip>`_, finish in class
    In loops example, Notebook class, add print notes backwards,
     interactive input loop, sentinels
     Finish `Scanner <JDK15Library.html#Scanner>`_ in the 1.5 lib web page
     Fill out stubs in the example utility class
    `UI <../examples/UIfiles.zip>`_.
     `Assignment 3 <../hw/hw3.html>`_
     loops project examples
     sumToN
     bitsNeeded
     See JDK library: String format method
     final loops project example
     loan table
     work in class stub of example
    `loopsArrays <../examples/loopsArraysfiles.zip>`_
     Loops are the hardest topic for many people. For more practice, there
    are many options:
    
    -  My extra loop and array exercises, with solutions, in the examples
       `arrayLoopProblems.html <../examples/arrayLoopProblems.html>`_,
       `arrayLoopSolutions.txt <../examples/arrayLoopSolutions.txt>`_,
       moreLoopArrayProblems
       (`.doc <../examples/moreLoopArrayProblems.doc>`_ or
       `.pdf <../examples/moreLoopArrayProblems.pdf>`_) with solutions
    -  Independent reviews of looping in
       `Codingbat.com <http://codingbat.com>`_: `While and for
       loops <http://javabat.com/doc/loop.html>`_ `Arrays and
       loops <http://javabat.com/doc/array.html>`_, plus extensive
       interactive problem sections of graded difficulty: String2, Array1,
       Array2, String3, and the extra challenging Array3
    
