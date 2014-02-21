.. index:: 
   single: array; one dimensional

.. _one-dim-arrays:

One Dimensional Arrays
============================ 

.. index::
   array; [ ] declaration
   
Basic Syntax
---------------

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
A new object can be created using the ``new`` syntax.  An array must get a definite
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
   :width: 437.25 pt

The small box beside ``a`` is meant to indicate the memory space allocated when ``a`` is
declared.  As you can see that space does not actually contain the array, but only a 
*reference* to the array, pointing to the actual sequence of data for the array.
To make it easy to refer to the elements in the diagram, we also label the indices 
associated with each element, though they are not actual a part of what is stored in memory.

The general syntax to create a  new array is

   ``new`` **type**\ ``[`` *length* ``]``
   
After the type, there are square brackets enclosing an expression for the length
of the array - this length is unchangeable after creation.

.. index::
   single: [ ]; array indexing
   array; indexing [ ]

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
   :width: 433.5 pt

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
    
You could also use ``while`` syntax.  The ``foreach`` syntax would be::

   foreach( int x in b) {
      Console.WriteLine(x);
   }

The int type for ``x`` matches the element type of the array ``b``.

The shorter ``foreach`` syntax is not as general as the ``for`` syntax.  
For example, to print only the first *3* elements of b::

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
10, and 15.  There is no analog of *changing* the value of ``b[i]`` with a
``foreach`` loop.  We can only *use the value* of sequence elements.

We have had the array indices so far be given by a single symbol, 
which is the most common case in practice, but in fact what appears
inside the square braces can be any ``int`` *expression*.
Like parentheses, square brackets *delimit*
the inside expression, which gets evaluated first, before the array value is
looked up.  Consider this csharp sequence:

..  code-block:: none

    csharp> int[] a = {5, 9, 15, -4};
    csharp> int i = 2;
    csharp> a[i];
    15

This should be clear.  Now think first, what should ``a[i+1]`` be?

...

..  code-block:: none

    csharp> a[i+1];
    -4

In steps:  ``a[i+1]`` is ``a[2+1]`` is ``a[3]`` is -4. Be careful,
``a[i+1]`` is *NOT* ``a[i] + 1`` (which would be 16). 

.. index::
   command line; parameter
   parameter; command line to Main
   Main; parameters

.. _command-line-param:

Parameters to Main
---------------------

The ``Main`` function may take an array of strings as parameter, as in example 
:repsrc:`print_param/print_param.cs`:

.. literalinclude:: ../source/examples/print_param/print_param.cs
   :start-after: chunk
   :end-before: chunk

By convention, the formal parameter for ``Main`` is called ``args``, 
short for arguments.  

Compile and run the program from the command line.
Run it again with some things at the end of the line like:

..   code-block:: none

     mono print_param.exe hi there 123

This should print for you:

..  code-block:: none

    There are 3 command line parameters.
    hi
    there
    123

See what quoted strings do.  Use command line parameters (with the quotes)  
``"hi there" 123``.
This should print for you::

    There are 2 command line parameters.
    hi there
    123

.. index::
   Xamarin Studio; command line parameters
   command line; parameters in Xamarin Studio

You can simulate command line parameters inside Xamarin Studio:

#.  Open the local popup menu for the project you are using.
#.  Select Run With > 
#.  In the submenu select Custom Parameters.
#.  That brings up a dialog where you can enter the
    desired command line parameters.
#.  Optionally you can remember this setup by clicking on
    box in front of "Save this configuration as a custom execution mode".
    If you check it, you get a place to enter a Custom Mode Name.
#.  End up clicking the Execute button.
#.  If you set a Custom Mode, later when you get to the submenu after
    "Run With >", you will see your custom mode name to select!

Try it!
        
.. index:: string; Split
   Split method for strings
   
.. _Split:

String Method Split
---------------------

A string method producing an array:

``string[] Split(char`` **separator** ``)``   
    Returns an array of substrings from *this* string.  They are the pieces left
    after chopping out the separator character from the string. 
    A piece may be the empty string. 
    Example: 

    ..  code-block:: none
    
		csharp> var fruitString = "apple pear banana";
		csharp> string[] fruit = fruitString.Split(' ');
		csharp> fruit;
		{ "apple", "pear", "banana" }
		csharp> fruit[1];
		"pear"
		csharp> var s = "  extra   spaces ";
		csharp> s.Split(' ');
		{ "", "", "extra", "", "", "spaces", "" }
		
Note: The response with the list in braces is a purely *csharp* convention for displaying
sequences for the user.  There is no corresponding string displayed by C# Write commands.
Also see that the string is split at *each* ``separator``, 
even if that produces empty strings.

.. index:: IntsFromString

Split is useful for parsing a line with several parts.  You might get a group of 
integers on a line of text, for instance from::

         string input = UI.PromptLine(
            "Please enter some integers, separated by single spaces: ");

To extract the numbers, you want to the separate the entries in the string
with ``Split``, *and* you probably want further processing: 
If you want them as integers, not strings, you must convert each one separately.  

It is useful to put this idea in a function.
See the type returned.  It is an array ``int[]`` for the int results:

.. literalinclude:: ../source/examples/searching/searching.cs
   :start-after: IntsFromString chunk
   :end-before: chunk

In a call to ``IntsFromString("2 5 22")``,  ``integers`` would be 
an array containing strings "2", "5", and "22".  
We need the conversions to ``int`` to go in a new array that we call ``data``.
We must set its length, which will clearly be the same as for ``integers``,
``integers.Length``.
To assign elements into ``data`` we need a loop providing indices,
like the ``for`` loop provided.  Then for each index, we parse a
string in ``integers`` into an ``int``, 
and place the ``int`` in the corresponding location in ``data``.  We need to return
``data`` at the end to make it accessible to the caller.

Remember some patterns illustrated here,
*that you will use over and over*:

* You can return any type, including an array type.
* If you want to return a new array, you must first create an array of the proper 
  length before you can make assignments to individual elements.
* The use of the same index variable in more than one array is a standard way to have 
  related entries in corresponding positions of the arrays.
  
We will use this function for testing in :ref:`searching`.

.. index:: exercise; GetToken
   GetToken exercise
   
GetTokens Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Complete this function::

   ///Return an array with the string split at blanks
   /// into positive length tokens.
   /// Example:  GetTokens("  extra  spaces ") returns an
   /// array containing {"extra", "spaces"} 
   public static string[] GetTokens(string s)
   
Hint: It is harder now to get the right length for your new array:
After splitting at ``' '``, you can count the non-empty strings in the result.
Then create your new array and copy only non-empty strings.
Handling the indices for the new array also gets more complicated.
     
.. index:: alias

.. _alias:

References and Aliases
-------------------------

Object variables, like arrays, are references, and this has important implications for
assignment.

With a primitive type like an ``int``, an assignment copies the data:

.. image:: images/intCopy.png
   :alt: copying an int
   :align: center
   :width: 132.75 pt

In the diagram, the contents of the memory box labeled ``b`` is copied to the
memory box labeled ``d``. The value of ``d`` starts off equal to the value of ``b``, 
but can later be changed independently.

Contrast an assignment with arrays.  The value that is copied is the *reference*,
not the array data itself, so both end up pointing at the *same*  actual array:

.. image:: images/arrayAlias.png
   :alt: copying an array reference
   :align: center
   :width: 433.5 pt
   
Hereafter, array assignments like::

   b[2] = -10;
   d[1] = 55;
   
would both change the *same* array.  Now ``b`` and ``d`` are essentially
names for the same thing (the actual array).  The technical term matches English:
The names are *aliases*.

This may seem like a pretty silly discussion.   Why bother to give two different 
names to the same object?  Isn't one enough?  In fact it is very important
in function/method calls.  An array reference can be passed as an actual value, 
and it is the array *reference* that is copied to the formal parameter, so
the formal parameter name is an **alias** for the actual parameter name.

.. note::
   If an array passed as a parameter to a method has elements changed in the
   method, then the change affects the actual parameter array.
   The change *remains* in the actual parameter array *after* the method has terminated.

.. index:: example; Scale
   Scale example
   array; parameter

For example, consider the following function::

   // Modify a by multiplying all elements by multiplier. 
   static void Scale(int[] a, int multiplier)
   {
      for (int i = 0; i < a.Length; i++) {
         a[i] *= multiplier;  // or:  a[i] = a[i] * multiplier
      }
   }
   
The fragment::

   int[] nums = {2, 4, 1};
   Scale(nums, 5);
   
would *change* nums, so it ends up containing elements 10, 20, and 5.

.. index::
   single: array; anonymous initialization

.. _Anonymous-Array-initialization:

Anonymous Array Initialization
--------------------------------

Sometimes you only want to use an array with specific values 
as a parameter to a function.  You could write something like ::

    int[] temp = {3, 1, 7};
    SomeFunc(temp);

but if ``temp`` is never going to be referenced again, you can 
do this without using a name::

    SomeFunc(new int[] {3, 1, 7});

Like with the use of ``var``, the compiler can infer the type of the array, and the
last example could be shortened to  ::

    SomeFunc(new[] {3, 1, 7});

It is essential to include the ``new int[]`` or ``new[]``, not just the ``{3, 1, 7}``.


Such an approach could also be used if you want to return a fixed
length array, where you have values for each parts, as in::
    
    int minVal = ...
    int maxVal = ...
    
    return new[] {minVal, maxVal};
    
.. index:: OOP; default value
   default value in instance 

.. _default-fields:
   
Default Initializations
-------------------------

You should have notice that when the first example array of integers was created,   
it was filled with zeros.  It is a safety feature of C# that the internal fields 
of objects always get a specific value, not random data.  Here are the defaults:

   | primitive numeric types: zero
   | boolean: false
   | all object types:  null

.. warning::

   An array with elements of object type, like ``string[]``,  
   without a specific initializer, 
   gets initialized to  all ``null`` values.  The creation is totally
   legal, but if you try to use the created value, like  ::
   
       string[] words = new string[10];
       Console.WriteLine(words[0].Length);  // run time error here 
    
   The error is because ``null`` is not an object - it does not have a ``Length``
   property.  If, for example, 
   you want an array of empty strings you would need a loop::
    
       for (int i = 0; i < words.length; i++) {
          words[i] = "";
       }
        
.. index:: exercise; command line adder
   command line adder exercise
   Main; parameter exercise
   parameter; for Main exercise

.. _command-line-adder-exercise:
   
Command Line Adder Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``adder.cs`` that calculates and prints the sum of 
command line parameters, so if you make the command line parameters
in Xamarin Studio be 

..  code-block:: none

    2 5 22

then the program prints 29.

Do try running from the command line:  If you compiled with
Xamarin Studio, that means going down to the bin/Debug directory.
Recall Xamarin Studio for Windows produces a Windows executable,
not a Mono file, so you can run
    
..  code-block:: none

    adder 2 5 22
    
while on a Mac you need to run with mono:

..  code-block:: none

    mono adder.exe 2 5 22
    
.. index:: exercise; TrimAll for arrays
   TrimAll exercise

.. _trim-all-exercise:
   
Trim All Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``trimmer.cs`` that includes and tests a 
function with heading::

   // Trim all elements of a and replace them in the array.
   //  Example: If a contains {" is  ", " it", "trimmed?   "}
   //  then after the function call the array contains
   //  {"is", "it", "trimmed?"}.   
   static void TrimAll(string[] a) 
   
   
.. index:: exercise; Dups
   Dups exercise for arrays

.. _Dups-exercise:
   
Count Duplicates Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``count_dups.cs`` that includes and tests a 
function with heading::

	// Return the number of duplicate pairs in an array a.  
	// Example: for elements 2, 5, 1, 5, 2, 5 
	// the return value would be 4 (one pair of 2's three pairs of 5's. 
	public static int dups(int[] a)


.. index:: exercise; Mirror
   Mirror exercise for arrays

.. _Mirror-exercise:
   
Mirror Array Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``make_mirror.cs`` that includes and tests a 
function with heading::

	// Create a new array with the elements of a in the opposite order.
	// {"aA", "bB", "cC"} produces a new array {"cC", "bB", "aA"}
	public static string[] Mirror(string[] a)


.. index:: exercise; Reverse for arrays
   Reverse exercise for arrays

.. _Reverse-exercise:
   
Reverse Array Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``reverse_array.cs`` that includes and tests a 
function with heading::


	// Reverse the order of array elements.
	// {"aA", "bB", "cC"} -> {"cC", "bB", "aA"}
	public static void Reverse(string[] a)

   
.. index:: exercise; Histogram
   Histogram exercise

.. _Histogram-exercise:
   
Histogram Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program ``make_histogram.cs`` that includes and tests a 
function with heading::

    // Return a histogram array counting repetitions of values
    // start through end in array a.  The count for value start+i
    // is at index i of the returned array, starting at i == 0.  
    // For example:
    // Histogram(new int[]{2, 0, 3, 5, 3, 5}, 2, 5) counts how
    // many times the numbers 2 through 5, inclusive, occur in
    // the original array, and returns a new array containing
    // {1, 2, 0, 2}, that is, 1 2, 2 3's, 0 4's, and 2 5's. The
    // count of 2's appears as the first (0th) element of the
    // returned array, the count of 3's as the second, etc.
    // Similarly, Histogram(new int[]{2, 0, 3, 5, 3, 5}, -1, 1)
    // returns the new array {0, 1, 0}, 
    // that is, 0 -1's, 1 0, and 0 1's.
    public static int[] Histogram(int[] a, int start, int end)

This problem clearly requires you to loop through all the elements of 
array ``a``.  You should *not* need any further nested loop.

.. _Histogram-interval-exercise:
   
Histogram Interval Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

This is a slight elaboration of the previous problem, where
you count entries in intervals, not just of width 1. 

Write a program ``make_histogram2.cs`` that includes and tests a 
function with heading::

    // Return a histogram array counting repetitions of values
    // in array a in the n half-open intervals [start, start + width),
    // [start+width, start+2*width), ... [
    // [start + (n-1)*width, start + n*width) .  The counts for 
    // each of the n intervals, in order, goes in the returned array 
    // of length n.  For example
    // Histogram(new[]{89, 69, 100, 83, 99, 81}, 60, 10, 5)  
    // would return an array containing counts 1, 0, 3, 1, 1,
    // for 1 in sixties, 0 in seventies, 3 in eighties, 1 in nineties,
    // and 1 in range 100 through 109.
    public static int[] HistogramIntervals(int[] a, int start, 
                                           int width, int n)

The previous exercise version ``Histogram(a, start, end)`` 
would return the same
result as ``HistogramIntervals(a, start, 1, end-start+1)``.

Again, the only loop needed should be to process each element of ``a``.

..  later
    example `arraysFor <../examples/arraysForfiles.zip>`_, finish in class
    
     loops project examples
     bitsNeeded
     final loops project example
     loan table
     work in class stub of example
    `loopsArrays <../examples/loopsArraysfiles.zip>`_
     Loops are the hardest topic for many people. For more practice, there
    are many options:
    
    -  My extra loop and array exercises, with solutions, in the examples
       `arrayLoopProblems.html <../examples/arrayLoopProblems.html>`_,
       `array_loop_solutions.txt <../examples/array_loop_solutions.txt>`_,
       moreLoopArrayProblems
       (`.doc <../examples/moreLoopArrayProblems.doc>`_ or
       `.pdf <../examples/moreLoopArrayProblems.pdf>`_) with solutions
    -  Independent reviews of looping in
       `Codingbat.com <http://codingbat.com>`_: `While and for
       loops <http://javabat.com/doc/loop.html>`_ `Arrays and
       loops <http://javabat.com/doc/array.html>`_, plus extensive
       interactive problem sections of graded difficulty: String2, Array1,
       Array2, String3, and the extra challenging Array3
    
