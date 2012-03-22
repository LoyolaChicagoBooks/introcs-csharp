.. index::
   double:  PF4; recursion
   double:  SP1; history
   double:  algorithms; arrays
   

.. _sorting:

Sorting Algorithms
===================================

Sorting algorithms represent foundational knowledge that every computer scientist and 
IT professional should at least know at a basic level. And it turns out to be a great
way of learning about why arrays are important well beyond mathematics. 

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

Exchanging Array Elements
-----------------------------

We'll begin by introducing you to a simple method, whose only purpose in life is to 
swap two data values at positions ``m`` and ``n`` in a given integer array:

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-exchange-begin
   :end-before: chunk-exchange-end
   :linenos:

In general, swapping two values in an array is no different than swapping any two integers.
Suppose we have the following integers ``a`` and ``b``::

   int a, b;
   int t;

   a = 25;
   b = 35;
   t = a; 
   a = b;
   b = t;

After this code does its job, the value of ``a`` would be 35 and the value of ``b`` would be 25.

So in the ``exchange()`` function above, 
if we have two different array elements at positions ``m`` and ``n``,
we are basically getting each value at these positions, 
e.g. ``data[m]`` and ``data[n]`` and treating them
as if they were ``a`` and ``b`` in the above code.

You might find it helpful at this time to verify that the above code does what we're saying it does, 
and a
good way is to type it directly into the C# interpreter (csharp) so you can see it for yourself.

The ``exchange()`` function is vital to all of the sorting algorithms in the following way. 
It is used whenever two items are found to be out of order. 
When this occurs, they will be *swapped*. This doesn't mean
that the item comes to its final resting place in the array. 
It just means that for the moment, the items 
have been reordered so we'll get closer to having a sorted array.

Let's now take a look at the various sorting algorithms.

.. index::
   double: sorting; bubble sort
   double: algorithms; bubble sort
   single: arrays; nested loops
   
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
``exchange()`` code, you'll observe that a swap requires three movements 
to take place, which happens very quickly on most processors but still amounts
to a significant cost. 

There can be at most :math:`N \cdot \frac{N-1}{2}` inversions in the 
array of length :math:`N`. The maximum
number of inversions occurs when the array is sorted in reverse order
and has no equal elements.

Each exchange in Bubble Sort removes precisely one inversion; therefore,
Bubble Sort requires :math:`O(N^2)` exchanges.


.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-bubblesort-begin
   :end-before: chunk-bubblesort-end
   :linenos:


.. index::
   double: sorting; selection sort
   double: algorithms; selection sort
   single: arrays; nested loops

Selection Sort
--------------

The Selection Sort algorithm works to minimize the amount of data movement,
hence the number of ``exchange()`` calls. 

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-selectionsort-begin
   :end-before: chunk-selectionsort-end
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
   we wish to begin the search. So as you can see from the loop in ``IntArraySelectionSort()``,
   when we are looking at position ``i``, we are searching for the minimum from position
   ``i + 1`` to the end of the array. 

As a concrete example, if you have an array of 10 elements, this means that
``i`` goes from 0 to 9. When we are looking at position 0, we check to find the 
position of the minimum element in 
positions 1..9. If the minimum is not already at position ``i``, we swap the minimum into
place. Then
we consider ``i=1`` and look at positions 2..9. And so on.

We won't do the full algorithmic analysis here. Selection Sort is interesting because
it does most of its work through *comparisons*, which is always the same regardless
of how the data are ordered, :math:`N \cdot \frac{N-1}{2}`, which is 
:math:`O(N^2)` The 
number of *exchanges* is O(N ). The comparisons are a non-trivial cost, however, and do show
in our own performance experiments with randomly-generated data. 


.. index::
   double: sorting; insertion sort
   double: algorithms; insertion sort
   single: arrays; nested loops
   
Insertion Sort
--------------

In the Insertion Sort algorithm, we build a sorted
list from the bottom of the array. We repeatedly insert the next element
into the sorted part of the array by sliding it down (using our familiar
``exchange()`` method) to its proper position.

This will require as many exchanges as Bubble Sort,
since only one inversion is removed per exchange. So Insertion Sort also
requires :math:`O(N^2)` exchanges. On average Insertion Sort requires
only half as many comparisons as Bubble Sort, since the average distance an
element must move for random input is one-half the length of the sorted
portion. 

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-insertionsort-begin
   :end-before: chunk-insertionsort-end
   :linenos:

.. index::
   double: sorting; Shell sort
   single: arrays; nested loops

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

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-shellsort-begin
   :end-before: chunk-shellsort-end
   :linenos:

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-shellsort-naive-begin
   :end-before: chunk-shellsort-naive-end
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

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-shellsort-better-begin
   :end-before: chunk-shellsort-better-end
   :linenos:

Shell sort is a complex sorting algorithm to make "work well", which is why it is not
seen often in practice. It is, however, making a bit of a comeback in embedded systems.

We nevertheless think it is a very cool algorithm to have heard of as a computer science
student and think it has promise in a number of situations, especially in systems where
there are limits on available memory (e.g. embedded systems).

.. index::
   double: sorting; Quicksort
   double: algorithms; Quicksort
   single: arrays; nested loops
   single: recursion


Quicksort a.k.a. Partition Sort
----------------------------------

This sort is a more advanced example that uses *recursion*. We're going to explain it 
elsewhere in our notes/book.

Quicksort is a rather interesting case. It is often perceived to be one of the
best sorting algorithms but, in practice, has a worst case performance also on the
order :math:`O(N ^2)`. When the data are randomly sorted (as in our experiments) 
it does better at :math:`O(N  \log N)`.

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-quicksort-begin
   :end-before: chunk-quicksort-end
   :linenos:

We'll have a bit more to say about this algorithm in our discussion of recursion.

.. index::
   single: Random
   double: random numbers; seeding
   double: random numbers; regeneration
   
Random Data Generation
------------------------

Now it is time to talk about how we are going to check the performance in 
a real-world situation. We're going to start by modeling the situation here
the data are in random order.

The following code generates a random array:

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-random-begin
   :end-before: chunk-random-end
   :linenos:

There are a few things to note in this code:

#. We use the random number generator option to include a *seed*. Random numbers
   aren't truly random. The particular sequence is just determined by a seed.
   The simplest way to create a Random object uses a seed taken from the system clock.

#. Because the sorting algorithms *modify* the data that are passed to it, we 
   need to have a way of regenerating the sequence. (We could also copy the 
   data, but it is kind of a waste of memory.)

#. In order to regenerate a particular example, we actually need the random sequence to be 
   consistent, so we know that each of the sorting algorithms is being tested
   using the same random data.  Hence we specify the same seed each time.


.. index::
   double: performance; Stopwatch
   double: performance; TimeSpan
   

.. index::
   single: performance
   double: timing; Stopwatch
   double: timing; Timespan
   
Timing
-------

In this code, we are actually beginning to make use of *classes* that are part of the
.Net framework/library. 

We need the ability to time the various sorting algorithms. Luckily, .Net gives us a
way of doing so through its ``Stopwatch`` class. This class supports methods that you
would expect if you've ever used a stopwatch (the kind found in sports):

- Reset: Resets the elapsed time to zero. We need this so we can use the same Stopwatch
  for each sorting algorithm.

- Start: Starts the stopwatch. Will keep recording time until stopped.

- Stop: Stops the stopwatch.

- ElapsedMilliseconds: Not really a method but a property (like a variable). We'll use this to
  get the total time that has elapsed between pairs of Start/Stop events in milliseconds.


So let's take a look at how we compare the sorting algorithms by looking at the ``Main()``
method's code. As this code is fairly lengthy, we're going to look at parts of it. The
``Main()`` method should be thought of as an *experiment* that tests the performance
of each of the sorting algorithms.

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-drivervars-begin
   :end-before: chunk-drivervars-end
   :linenos:

The variables declared here are to set up the apparatus:

- ``arraySize``: The size of the array where we wish to test the performance. We will
  use this to create an array with ``arraySize`` random values.

- ``randomSeed``: This allows the user to vary the seed that is used to create
  the random array. We often want to do this to determine whether our performance
  results are stable when run a large number of times with different distributions.
  We won't go into too much detail here but consider it an important part of building
  good performance benchmarks.

- ``watch``: The stopwatch object we're using to do the timings of all experiments.


.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-driverparameters-begin
   :end-before: chunk-driverparameters-end
   :linenos:

This code is designed so we can accept the parameters ``arraySize`` and ``randomSeed``
from the command line or by prompting the user. When programmers design benchmarks, they
often try to make it possible to run them with minimal user interaction. For the purposes
of teaching, we wanted to make it possible to run it with or without command-line parameters.


.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-driverapparatus-begin
   :end-before: chunk-driverapparatus-end
   :linenos:

This code fragment is actually replicated a few times in the actual ``Main()`` method (to
run each of the different sorting algorithms). Essentially, we do the following for each
of the sorting algorithms we want to benchmark:

#. Create the random array of data.

#. Reset the Stopwatch object to zero.

#. Start the Stopwatch.

#. Run the sorting algorithm of interest (here ``IntArrayBubbleSort()``). In the rest
   of the ``Main()`` code, we change this line to call the function for each of the
   other sorting algorithms.

#. Stop the Stopwatch and get the elapsed time (watch.Elapsed). 

#. Print the performance results.

When you get ``watch.ElapsedMilliseconds``, this gives you an integer (long) number of
milliseconds (thousandths of a second).

Getting the Code
---------------------

If you already have performed a checkout of our entire project at 
Bitbucket, you can find this code in the ``projects/Arrays/Sorting``
folder (and open the solution ``Sorting.sln`` in MonoDevelop or Visual
Studio). 

You can also view the full source code in our [SortingFolder]_.

Running the Code
----------------------

Here's the output of a trial run on one of our computers. The results will vary
depending on your computer's CPU, among other factors.

.. literalinclude:: ../projects/Arrays/Sorting/output/results.txt
   :language: text

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

- The Quicksort is generally fastest.  It is by far the
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

.. [SortingFolder] https://bitbucket.org/gkthiruvathukal/introcs-csharp/src/d82c38851f6a/projects/Arrays/Sorting/Main.cs
