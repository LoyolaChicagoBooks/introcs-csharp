.. todo::
   This is completely in draft mode now and is at best in placeholder status.
   No revisions please.

Array Example: Sorting Algorithms
===================================

In the various sort methods, we will use this method to keep the code more concise, since it is
needed for all of the sorting methods covered here (and beyond).

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-exchange-begin
   :end-before: chunk-exchange-end
   :linenos:


Bubble Sort
-----------

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

.. literalinclude:: ../projects/Arrays/Sorting/Main.cs
   :start-after: chunk-insertionsort-begin
   :end-before: chunk-insertionsort-end
   :linenos:

Shell Sort
----------

This general version of shell sort allows you to specify the intervals. This array of intervals
must be in sorted order to have any hope of yielding good performance and must include the 
number 1 to ensure the array ends up sorted.

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
