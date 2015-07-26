.. index::
   PF4
   recursion
   SP1
   history
   sorting

.. _sorting:

Sorting Algorithms
===================================

Sorting algorithms represent foundational knowledge that every computer scientist and 
IT professional should at least know at a basic level. And it turns out to be a great
way of learning about why arrays are important. 

In this section, we're going to take a look at a number of well-known sorting algorithms
with the hope of sensitizing you to the notion of *performance*--a topic that is covered
in greater detail in courses such as algorithms and data structures.

This is not intended to be a comprehensive reference at all. The idea is to learn how
these classic algorithms are coded in the teaching language for this course, C#, and to
understand the essentials of analyzing their performance, both theoretically and
experimentally. For a full theoretical treatment, we recommend the outstanding textbook
by Niklaus Wirth [WirthADP]_, who invented the Pascal language. (We have also adapted
some examples from Thomas W. Christopher's [TCSortingJava]_ animated sorting algorithms
page.

The sorts and supporting functions are all in 
:repsrc:`sorting/sorting.cs`, but we start one bit at a time: 


.. index:: exchanging array elements
   array; exchange elements
   
Exchanging Array Elements
-----------------------------

We'll begin by introducing you to a simple method, whose only purpose in life is to 
swap two data values at positions ``m`` and ``n`` in a given integer array:

.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-exchange-begin
   :end-before: chunk
   :linenos:

For example if we have an array nums, shown with indices:

.. code-block:: none

    nums: -1  8 11 22  9 -5  2 
   index:  0  1  2  3  4  5  6   

Then after ``Exchange(nums, 2, 5)`` the array would look like

.. code-block:: none

    nums: -1  8 -5 22  9 11  2 
   index:  0  1  2  3  4  5  6   

In general, swapping two values in an array is 
no different than swapping any two integers.
Suppose we have the following integers ``a`` and ``b``::

   int a, b;
   int t;

   a = 25;
   b = 35;
   t = a; 
   a = b;
   b = t;

After this code does its job, the value of ``a`` would be 35 
and the value of ``b`` would be 25.

So in the ``Exchange()`` function above, 
if we have two different array elements at positions ``m`` and ``n``,
we are basically getting each value at these positions, 
e.g. ``data[m]`` and ``data[n]`` and treating them
as if they were ``a`` and ``b`` in the above code.

You might find it helpful at this time to verify that 
the above code does what we're saying it does, and a
good way is to type it directly into the C# interpreter (csharp) 
so you can see it for yourself.

The ``Exchange()`` function is vital to all of the sorting algorithms in the following way. 
It is used whenever two items are found to be out of order. 
When this occurs, they will be *swapped*. This doesn't mean
that the item comes to its final resting place in the array. 
It just means that for the moment, the items 
have been reordered so we'll get closer to having a sorted array.

Let's now take a look at the various sorting algorithms.

.. index:: sorting; bubble sort
   algorithms; bubble sort
   array; nested loop
   bubble sort
   
Bubble Sort
-----------

The Bubble Sort algorithm works by repeatedly scanning
through the array exchanging adjacent elements that are out of order.  Watching
this work with a strategically-placed ``Console.WriteLine()`` in the outer
loop, you will see that the sorted array grows right to left. Each
sweep picks up the largest remaining element and moves to the right as
far as it can go. It is therefore not necessary to scan through the
entire array each sweep, but only to the beginning of the sorted
portion.

We define the number of *inversions* as the number of element pairs that
are out of order. They needn't be adjacent. If ``data[7] > data[16]``, 
that's an inversion. Every time an inversion is required, 
we also say that there is corresponding data *movement*. If you look at the
``Exchange()`` code, you'll observe that a swap requires three movements 
to take place, which happens very quickly on most processors but still amounts
to a significant cost. 

There can be at most :math:`N \cdot \frac{N-1}{2}` inversions in the 
array of length :math:`N`. The maximum
number of inversions occurs when the array is sorted in reverse order
and has no equal elements.

Bubble Sort exchanges only adjacent elements.  
Each such exchange removes precisely one inversion; therefore,
Bubble Sort requires :math:`O(N^2)` exchanges.


.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-bubblesort-begin
   :end-before: chunk
   :linenos:


.. index:: sorting; selection sort
   algorithms; selection sort
   nested loop
   selection sort

Selection Sort
--------------

The Selection Sort algorithm works to minimize the amount of data movement,
hence the number of ``Exchange()`` calls. 

.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-selectionsort-begin
   :end-before: chunk
   :linenos:

It's a remarkably simple algorithm to explain. As shown in the code, the
actual sorting is done by a function, ``IntArraySelectionSort()``, which 
takes an array of data as its only parameter, like Bubble sort.
The way Selection Sort works is as follows:


#. An outer loop visits each item in the array to find out whether it is the
   minimum of all the elements after it. 
   If it is not the minimum, it is going to be swapped with whatever
   item in the rest of the array is the minimum.

#. We use a helper function, 
   ``IntArrayMin()``
   to find the position of the minimum value in the rest of the array. 
   This function has a parameter, ``start`` to indicate where
   we wish to begin the search. 
   So as you can see from the loop in ``IntArraySelectionSort()``,
   when we start with position ``i``, and we compare to the later elements 
   from position ``i + 1`` to the end of the array, updating the position of the
   smallest element so far. 

An illustration to accompany the discussion:

.. code-block:: none

    data: 12  8 -5 22  9  2 
   index:  0  1  2  3  4  5    
           i     k                    

The first time through the loop, ``i`` is 0, and ``k`` gets the value 2, since data[2]
is -5, the smallest element.  Those two positions get swapped.

.. code-block:: none

    data: -5  8 12 22  9  2 
   index:  0  1  2  3  4  5    

The next 
time through the loop i is 1 and k becomes 5:

.. code-block:: none

    data: -5  8 12 22  9  2 
   index:  0  1  2  3  4  5    
              i           k                    

After the swap:

.. code-block:: none

    data: -5  2 12 22  9  8 
   index:  0  1  2  3  4  5    

and so on.  Here is the data after each of the last three swaps:

.. code-block:: none

    -5  2  8 22  9 12 

    -5  2  8  9 22 12 

    -5  2  8  9 12 22 

Consider the first call to ``IntArrayMin``.  

.. code-block:: none

    data: 12  8 -5 22  9  2 
   index:  0  1  2  3  4  5    

Initially ``minPos`` is 0.  Here are the
changes for each value of ``pos``:

.. code-block:: none

   pos=1:  8 = data[1] < data[0] = 12, so minPos becomes 1
   pos=2: -5 = data[2] < data[1] = 8, so minPos becomes 2
   pos=3: 22 = data[3] is not < data[2] = -5, so minPos still 2
   pos=4:  9 = data[4] is not < data[2] = -5, so minPos still 2
   pos=5:  2 = data[5] is not < data[2] = -5, so minPos still 2

and 2 gets returned, and we ge the swap

.. code-block:: none

    data: -5  8 12 22  9  2 
   index:  0  1  2  3  4  5    

The next call to ``IntArrayMin`` has ``start`` as 1, so ``minPos`` is initially 1,
and we compare to the elements of data at index 2, 3, 4, and 5....

We won't do the full algorithmic analysis here. Selection Sort is interesting because
it does most of its work through *comparisons*, with the same number of them no matter
how the data are ordered, exactly
:math:`N \cdot \frac{N-1}{2}`, which is 
:math:`O(N^2)` The 
number of *exchanges* is O(N). The comparisons are a non-trivial cost, 
however, and do show
in our own performance experiments with randomly-generated data. 

.. index:: Shuffle exercise
   exercise; Shuffle
   
Shuffle Exercise
~~~~~~~~~~~~~~~~~

Complete the ``Shuffle`` function and add a ``Main`` method to test it::

    /// Shuffle the elements of an array into random positions, 
    /// changing the array.  An array containing 
    /// 2, 5, 7, 7, 7, 9 *might* end up in the order 
    /// 7, 7, 2, 9, 7, 5.
    static void Shuffle(int[] a)

Use a Random and do something close to a reverse of selection sort, using 
``Exchange`` with a random position.

.. index:: sorting; insertion sort
   algorithms; insertion sort
   nested loop
   insertion sort


Insertion Sort
--------------

In the Insertion Sort algorithm, we build up a longer and longer sorted
list from the bottom of the array. We repeatedly insert the next element
into the sorted part of the array by sliding it down (using our familiar
``Exchange()`` method) to its proper position.

.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-insertionsort-begin
   :end-before: chunk
   :linenos:

Consider the earlier example array as we illustrate some of the steps.   
I use the symbol '-' for an element that we know to 
be in the sorted list at the beginning of the array, 
and '@' over the next one we are trying to insert *at* the right position.
We start with a one-element sorted list and try to position the second element:


.. code-block:: none

           -  @
    data: 12  8 -5 22  9  2 
   index:  0  1  2  3  4  5    

After each outer loop in sequence we end up with:

.. code-block:: none

           -  -  @
    data:  8 12 -5 22  9  2 
   index:  0  1  2  3  4  5    

           -  -  -  @
    data: -5  8 12 22  9  2 
   index:  0  1  2  3  4  5    

           -  -  -  -  @
    data: -5  8 12 22  9  2 
   index:  0  1  2  3  4  5    

           -  -  -  -  -  @
    data: -5  8  9 12 22  2 
   index:  0  1  2  3  4  5    

           -  -  -  -  -  -
    data: -5  2  8  9 12 22  
   index:  0  1  2  3  4  5    

Let us illustrate several times just through the inner loop, the first time,
when the 8 is moved into 
position from index ``j`` = 1, so ``i`` starts at 1.  We show the letter i
over the data at index ``i``, and show the comparison test to be done with a `>`
with a '?' over it.

.. code-block:: none

             ? i
    data: 12 > 8  -5  22   9   2   1>0 and 12>8: true, so swap, loop
   index:  0   1   2   3   4   5    

           i
    data:  8  12  -5  22   9   2   0>0 false, skip comparison of data, end loop
   index:  0   1   2   3   4   5    

Let us also illustrate at a later time through the inner loop, when the 9 is moved into 
position from index ``j`` = 4, so ``i`` starts at 4.  

.. code-block:: none

                         ? i  
    data: -5   8  12  22 > 9   2  4>0 and 22>9: true, so swap, loop
   index:  0   1   2   3   4   5    

                     ? i  
    data: -5   8  12 > 9  22   2  3>0 and 12>9: true, so swap, loop
   index:  0   1   2   3   4   5    

                 ? i  
    data: -5   8 > 9  12  22   2  2>0 and 8>9: false, end inner loop
   index:  0   1   2   3   4   5    

The 9 started at index ``j`` = 4, and now the list is sorted up through index 4.  

This will require as many exchanges as Bubble Sort,
since only one inversion is removed per exchange. So Insertion Sort also
requires :math:`O(N^2)` exchanges. On average Insertion Sort requires
only half as many comparisons as Bubble Sort, since the average distance an
element must move for random input is one-half the length of the sorted
portion. 

.. index:: sorting; Shell sort
   nested loop
   Shell sort
   algorithms; Shell sort

Shell Sort
----------

Shell Sort is basically a trick to make Insertion Sort run faster. If 
you take a quick glance at the code and look beyond the presence of
two additional *outer loops*, you'll notice that the code looks very similar.

Since Insertion Sort removes one inversion per exchange, it cannot run
faster than the number of inversions in the data, which in worst case is
:math:`O(N^2)`. Of course, it can't run faster than N, either, because
it must look at each element, whether or not the element is out of
position. We can't do any thing about the lower bound O(N), but we can
do something about the number of steps to remove inversions. 

The trick in Shell Sort is to start off swapping elements that are 
further apart.  While this may remove only one inversion sometimes,
often many more inversions are removed with intervening elements.
Shell Sort considers the subsequences of elements spaced k
elements apart. There are k such sequences starting at positions 0
through k-1 in the array. In these sorts, elements k positions apart are
exchanged, removing between 1 and 2(k-1)+1 inversions.

Swapping elements far apart is not sufficient, generally, so 
a Shell Sort will do several
passes with decreasing values of k, ending with k=1. 
The following examples experiment
with different series of values of k.

In this first example, we sort all subsequences of elements 8 apart, 
then 4, 2, and 1. Please note that these intervals are to show how the 
method works--not how the method works *best*.

.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-shellsort-begin
   :end-before: chunk
   :linenos:

.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-shellsort-naive-begin
   :end-before: chunk
   :linenos:


In general, shell sort with sequences of jump sizes that
are powers of one another doesn't 
do as well as one where most jump sizes are not multiples of others,
mixing up the data more. 
In  addition, the number of intervals must be increased as the size of the array to
be sorted increases, which explains why we allow an *arbitrary* array of intervals
to be specified. 

Without too much explanation, we show how you can choose the intervals differently
in an *improved* shell sort, where the intervals have been chosen so as not to be
multiples of one another.

Donald Knuth has suggested a couple of methods for computing the intervals:

.. math::

   h_0 = 1

   h_{k+1} = 3 h_k + 1

   t = \lfloor log_3 n \rfloor - 1

Here we are using notation for the *floor* function 
:math:`\lfloor x \rfloor` means the largest integer :math:`\le x`.

This results in a sequence 1, 4, 13, 40, 121.... You stop computing values in the 
sequence when :math:`t = log_3 n - 1`. (So for n=50,000, you should have about 9-10
intervals.)

For completeness, we note that :math:`log_3 n` must be sufficiently large (and > 2)
for this method to work. Our code ensures this by taking the *maximum* of
:math:`log_3 n` and 1.

Knuth also suggests:

.. math::

   h_0 = 1

   h_{k+1} = 2 h_k + 1

   t = \lfloor log_2 n \rfloor - 1

This results in a sequence 1, 3, 7, 15, 31....

Here is the improvement to our naive method that dynamically calculates
the intervals based on the first suggestion of Knuth:

.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-shellsort-better-begin
   :end-before: chunk
   :linenos:

Shell sort is a complex sorting algorithm to make "work well", which is why it is not
seen often in practice. It is, however, making a bit of a comeback in embedded systems.

We nevertheless think it is a very cool algorithm to have heard of as a computer science
student and think it has promise in a number of situations, especially in systems where
there are limits on available memory (e.g. embedded systems).

.. index:: sorting; Quicksort
   algorithms; Quicksort
   recursion; Quicksort
   Quicksort


Quicksort a.k.a. Partition Sort
----------------------------------

This sort is a more advanced example that uses *recursion*. We list it because it
is one of the best sorts for *random* data, having an *average* time behavior of 
:math:`O(N  \log N)`.  
Quicksort is a rather interesting case. While it has an excellent average
behavior, it has a worst case performance of :math:`O(N ^2)`.

.. later 
   
   We'll have a bit more to say about this algorithm in our discussion of recursion.

.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-quicksort-begin
   :end-before: chunk
   :linenos:

Though the initial call is to sort an entire array, this is accomplished by
dealing with sections, so the main work is done in the version with the
two extra parameters, giving the lowest and highest index considered.

It picks an arbitrary element as *pivot*, and then swaps 
elements with values above and below the pivot until the part of the array 
being processed is in three sections:  

#. elements <= pivot;
#. possibly an element equal to pivot
#. elements >= pivot.

Though sections 1 and 3 are not sorted, there are no inversions *between* any two
separate sections, so only the smaller sections 1 and 3 need to be sorted *separately*, 
and only then if they have at least two elements.  They can be sorted 
by calling the *same* function, 
but with a smaller range of indices to deal with in each case.  
These *recursive* calls stop when a part is reduced to one element.

.. index:: loop; invariant

Another optional glimpse at an advanced topic:  The outer ``while`` loop
in lines 11-20 has fairly complicated logic.  To prove it is correct
overall, you can state and prove the simpler *loop invariant* expressed
in the comments above the loop, lines 7-10.  This allows the conclusion
after the loop in comment lines 21-24.

.. index::
   Random
   seed
   regenerate random numbers
   
Random Data Generation
------------------------

Now it is time to talk about how we are going to check the performance in 
a real-world situation. We're going to start by modeling the situation when
the data are in random order.

The following code generates a random array:

.. literalinclude:: ../../source/examples/sorting/sorting.cs
   :start-after: chunk-random-begin
   :end-before: chunk
   :linenos:

There are a few things to note in this code:

#. We use the random number generator option to include a *seed*. Random numbers
   aren't truly random. The particular sequence is just determined by a seed.
   The simplest way to create a Random object uses a seed taken from the system clock.
#. In order to regenerate a particular example, we actually need the random sequence to be 
   consistent, so we know that each of the sorting algorithms is being tested
   using the same random data.  
#. Because the sorting algorithms *modify* the data that are passed to it, we 
   need to have a way of regenerating the sequence for the next test. 
   Hence we specify the same seed each time.
   (We could also copy the data, but it is kind of a waste of memory.)

This completes the discussion of the ``Sorting`` class in 
:repsrc:`sorting/sorting.cs`.

.. index:: Stopwatch
   performance - Stopwatch and TimeSpan
   timing
   
Timing
-------

Separate from the basic sorts is the idea of checking their performance.
The rest of the code is in the driver class in
:repsrc:`sorting/sorting_demo.cs`. 

We need the ability to time the various sorting algorithms. Luckily, the 
.Net framework/library gives us a
way of doing so through its ``Stopwatch`` class. This class supports methods that you
would expect if you've ever used a stopwatch (the kind found in sports):

- Reset: Resets the elapsed time to zero. We need this so we can use the same Stopwatch
  for each sorting algorithm.
- Start: Starts the stopwatch. Will keep recording time until stopped.
- Stop: Stops the stopwatch.
- ElapsedMilliseconds: Not really a method but a property (like a variable). We'll use this to
  get the total time that has elapsed between pairs of Start/Stop events in milliseconds.


So let's take a look at the ``Main()``
method's code to see how we compare the sorting algorithms. 
The ``Main()`` method should be thought of as an *experiment* that tests the performance
of each of the sorting algorithms.
As all of the tests follow the same pattern, 
we're going to look at the basic variable setup first, and then one test.

.. literalinclude:: ../../source/examples/sorting/sorting_demo.cs
   :start-after: chunk-drivervars-begin
   :end-before: chunk

The variables declared here are to set up the apparatus:

- ``arraySize``: The size of the array where we wish to test the performance. We will
  use this to create an array with ``arraySize`` random values.

- ``randomSeed``: This allows the user to vary the seed that is used to create
  the random array. We often want to do this to determine whether our performance
  results are stable when run a large number of times with different distributions.
  We won't go into too much detail here but consider it an important part of building
  good performance benchmarks.

- ``watch``: The stopwatch object we're using to do the timings of all experiments.

- ``data``:  The array to be sorted.

.. literalinclude:: ../../source/examples/sorting/sorting_demo.cs
   :start-after: chunk-driverparameters-begin
   :end-before: chunk

This code is designed so we can accept the parameters ``arraySize`` and ``randomSeed``
from the command line or by prompting the user. When programmers design benchmarks, they
often try to make it possible to run them with minimal user interaction. For the purposes
of teaching, we wanted to make it possible to run it with or without command-line parameters.


.. literalinclude:: ../../source/examples/sorting/sorting_demo.cs
   :start-after: chunk-driverapparatus-begin
   :end-before: chunk

This code fragment is one of the tests in ``Main``.  All of the tests set up 
for timing first, run the desired sorting algorithm (bubble sort in this case),
and report the timing results.  Since the timing setup and reporting is 
always done the same way, they actions are placed in helping methods:

.. literalinclude:: ../../source/examples/sorting/sorting_demo.cs
   :start-after: chunk timing
   :end-before: chunk

``TimeSetup``:

#. Creates the 'random' array of ``data``, based on ``randomSeed``.
#. Resets the ``Stopwatch`` object to zero.
#. Starts the ``Stopwatch``.

After the sort, ``TimeResult``:

#. Stops the ``Stopwatch`` and get the elapsed time (``watch.ElapsedMilliseconds``). 
   The value  
   is an integer (long) number of
   milliseconds (thousandths of a second).
#. Prints the performance results in seconds.


You can see all of the tests in :repsrc:`sorting/sorting_demo.cs`. 

Running the Code
----------------------

Here's the output of a trial run on one of our computers. The results will vary
depending on your computer's CPU, among other factors.

..  code-block:: none

    bin/Debug$ mono Sorting.exe 1000 12
    Quick Sort: 0.000
    Naive Shell Sort: 0.000
    Better Shell Sort: 0.000
    Insertion Sort: 0.001
    Selection Sort: 0.002
    Bubble Sort: 0.003
    bin/Debug$ mono Sorting.exe 1000 55
    Quick Sort: 0.000
    Naive Shell Sort: 0.000
    Better Shell Sort: 0.000
    Insertion Sort: 0.001
    Selection Sort: 0.002
    Bubble Sort: 0.003
    bin/Debug$ mono Sorting.exe 10000 2
    Quick Sort: 0.001
    Naive Shell Sort: 0.019
    Better Shell Sort: 0.002
    Insertion Sort: 0.134
    Selection Sort: 0.174
    Bubble Sort: 0.321
    bin/Debug$ mono Sorting.exe 50000 2
    Quick Sort: 0.006
    Naive Shell Sort: 0.441
    Better Shell Sort: 0.015
    Insertion Sort: 3.239
    Selection Sort: 4.172
    Bubble Sort: 8.028
    bin/Debug$ mono Sorting.exe 100000 2
    Quick Sort: 0.014
    Naive Shell Sort: 1.794
    Better Shell Sort: 0.034
    Insertion Sort: 13.158
    Selection Sort: 16.736
    Bubble Sort: 31.334

At least based on randomly-generated arrays, the performance can be summarized 
as follows:

- Bubble Sort is rather unimpressive as expected. In fact, this algorithm is never
  used in practice but is of historical interest. Like the brute-force style of
  searching, it does way too much work to come up with the right answer!

- Selection Sort and Insertion Sort are also rather unimpressive on their own. Even though 
  Selection Sort can in theory do a lot less data movement, it must make a large
  number of comparisons to find the minimum value to be moved. Again it is way too much work.
  Insertion Sort, while unimpressive, fares a bit better and turns out to be a 
  nice building block (if modified) for the Shell Sort. Varying the interval size
  drastically reduces the amount of data movement (and the distance it has to move).

- Shell Sort does rather well, especially when we pick the right intervals. 
  In practice, the intervals also need to be adjusted based on the size of the
  array, which is what we do as larger array sizes are considered. This is no trivial
  task but a great deal of work has already been done in the past to determine
  functions that generate good intervals. 

- The Quicksort is generally fastest on random data.  It is by far the
  most commonly used sorting algorithm. Yet there are signs that Shell sort
  is making a comeback in embedded systems, because it concise to code
  and is still quite fast.  See
  [WikipediaShellSort]_, where it is mentioned that
  the [uClibc]_ library makes use of Shell sort in its ``qsort()`` implementation,
  rather than implementing the library sort with the more common quicksort.

.. [WirthADP] Niklaus Wirth, Algorithms + Data Structures = Programs, Prentice Hall, 1976.

.. [WikipediaShellSort] http://en.wikipedia.org/wiki/Shellsort

.. [uClibc] http://en.wikipedia.org/wiki/UClibc

.. [TCSortingJava] http://tools-of-computing.com/tc/CS/Sorts/SortAlgorithms.htm
