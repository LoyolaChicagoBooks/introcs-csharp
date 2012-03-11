.. todo::
   This is completely in draft mode now and is at best in placeholder status.
   No revisions please.

.. _searching:

Array Example: Searching 
===================================

In this section, we'll take a look at how to search for a value in an array.
Although a fairly straightforward topic, it is one that comes up repeatedly
in programming.

These examples make use of arrays and loops, not to mention functions (for putting
it all together). You'll also begin to see greater use of the ``return`` statement
and *return values* (the results of functions).

.. index::
   double: search; linear
   double: algorithms; linear search

Linear Search
------------------

By far, one of the most common searches you will see in typical programs. It also
happens to be one of the more *misused* searches, which is another reason we
want you to know about it.

For this

.. literalinclude:: ../projects/Arrays/Searching/Main.cs
   :start-after: chunk-linearsearch-begin
   :end-before: chunk-linearsearch-end
   :linenos:

.. index::
   double: search; binary
   double: algorithms; binary search

Binary Search
--------------

.. literalinclude:: ../projects/Arrays/Searching/Main.cs
   :start-after: chunk-binarysearch-begin
   :end-before: chunk-binarysearch-end
   :linenos:


Putting it Together
--------------------

.. literalinclude:: ../projects/Arrays/Searching/Main.cs
   :start-after: chunk-driver-begin
   :end-before: chunk-driver-end
   :linenos:
