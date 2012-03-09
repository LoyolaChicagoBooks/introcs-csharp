.. todo::
   This is completely in draft mode now and is at best in placeholder status.
   No revisions please.

Array Example: Sorting Algorithms
===================================

Sorting algorithms represent foundational knowledge that every computer scientist and 
IT professional should at least know at a basic level. And it turns out to be a great
way of learning about why arrays are important well beyond mathematics. 

In this section, we're going to take a look at a number of well-known sorting algorithms
with the hope of sensitizing you to the notion of *performance*--a topic that is covered
in greater detail in courses suchs as algorithms and data structures.

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

So in the ``exchange()`` function above, if we have two different array elements at positions ``m`` and ``n``,
we are basically getting each value at these positions, e.g. ``data[m]`` and ``data[n]`` and treating them
as if they were ``a`` and ``b`` in the above code.

You might find it helpful at this time to verify that the above code does what we're saying it does, and a
good way is to type it directly into the C# interpreter (csharp) so you can see it for yourself.

The ``exchange()`` function is vital to all of the sorting algorithms in the following way. It is used
whenever two items are found to be out of order. When this occurs, they will be *swapped*. This doesn't mean
that the item comes to its final resting place in the array. It just means that for the moment, the items 
have been reordered so we'll get closer to having a sorted array.

Let's now take a look at the various sorting algorithms.

Bubble Sort
-----------

The Bubble Sort algorithm works by repeatedly scanning
through the array exchanging elements that are out of order.  Watching
this work with a strategically-placed ``Console.WriteLine()`` in the outer
loop, you will see that the sorted array grows right to left. Each
sweep picks up the largest remaining element and moves to the right as
far as it can go. It is therefore not necessary to scan through the
entire array each sweep, but only to the beginning of the sorted
portion.

We define the number of *inversions* as the number of elements that
are out of order. They needn't be adjacent. If element 7 is greater than
element 16, that's an inversion. Every time an inversion is required, 
we also say that there is corresponding data *movement*. If you look at the
``exchange()`` code, you'll observe that a swap requires three movements 
to take place, which happens very quickly on most processors but still amounts
to a significant cost. In systems programming, moving between the CPU and memory
is relatively expensive to operations that happen on the CPU proper. You'll
learn more about this topic in courses on systems programming and
operating systems.

There can be at most :math:`N \cdot \frac{N-1}{2}` inversions in the array. The maximum
number of inversions occurs when the array is sorted in reverse order
and has no equal elements.

Each exchange in Bubble Sort removes precisely one inversion; therefore,
Bubble Sort requires :math:`O(N^2)` exchanges.

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-bubblesort-begin
   :end-before: chunk-bubblesort-end
   :linenos:

Selection Sort
--------------

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-selectionsort-begin
   :end-before: chunk-selectionsort-end
   :linenos:


Insertion Sort
--------------

In the Insertion Sort algorithm, we build a sorted
list from the bottom of the array. We repeatedly insert the next element
into the sorted part of the array by sliding it down (using our familiar
``exchange()`` method) to its proper position.

In the worst case, this will require as many exchanges as Bubble Sort,
since only one inversion is removed per exchange. So Insertion Sort also
requires :math:`O(N^2)` exchanges. However, the average distance an
element must move for random input is one-half the length of the sorted
portion, so Insertion Sort should, in practice, be twice as fast as
Bubble Sort. (That is, it runs in 1/2 the time.)

It is worth noting that in systems programming, when an item needs to move
a shorter distance in memory, it is said to have good *locality*. So
Insertion Sort, while far from the perfect sorting algorithm, is vastly
preferable to the Bubble Sort algorithm by just about every measure.

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-insertionsort-begin
   :end-before: chunk-insertionsort-end
   :linenos:

Shell Sort
----------

Shell Sort is basically a trick to make Insertion Sort run faster. If 
you take a quick glance at the code and look beyond the presence of an
additional *outer loop*, you'll notice that the code looks very similar.

Since Insertion Sort removes one inversion per exchange, it cannot run
faster than the number of inversions in the data, which in worst case is
:math:`O(N^2)`. Of course, it can't run faster than N, either, because
it must look at each element, whether or not the element is out of
position. We can't do any thing about the lower bound O(N), but we can
do something about the number of inversions. If we can get the array in
close to sorted order, then Insertion Sort won't have many inversions to
remove.

The trick in Shell Sort is to sort the subsequences of elements spaced k
elements apart. There are k such sequences starting at positions 0
through k-1 in the array. In these sorts, elements k positions apart are
exchanged, removing between 1 and 2(k-1)+1 inversions.

Indeed, not satisfied with just one prepass, a Shell Sort may do several
passes with decreasing values of k. The following examples experiment
with different series of values of k.

Shell Sort **Shell Sort**. In this first example, we sort all
subsequences of elements 8 apart, then 4, 2, and 1. As we sort them, we
color the elements based on what subsequences they are in. It becomes
clear that this version of Shell Sort becomes a kind of merge sort where
pairs of subsequences are merged together. Comparing the performance of
this version to the two remaining, it also appears that this merging is
not a great idea. The subsequences can be quite a distance apart.


.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-shellsort-begin
   :end-before: chunk-shellsort-end
   :linenos:

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-shellsort-naive-begin
   :end-before: chunk-shellsort-naive-end
   :linenos:

Quick Sort
----------

Quick sort might be covered but also might be saved for a future class (271 or 363).

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-quicksort-begin
   :end-before: chunk-quicksort-end
   :linenos:
