.. todo::
   This is completely in draft mode now and is at best in placeholder status.
   No revisions please.

.. _searching:

Linear Searching 
===================================

In this section, we'll take a look at how to search for a value in an
array.  Although a fairly straightforward topic, it is one that comes
up repeatedly in programming.

These examples make use of arrays and loops, not to mention functions
(for putting it all together). You'll also begin to see greater use of
the ``return`` statement and *return values* (the results of
functions).

.. index::
   double: search; linear
   double: algorithms; linear search

Linear Search
------------------

By far, one of the most common searches you will see in typical
programs. It also happens to be one of the more *misused* searches,
which is another reason we want you to know about it.

Here is the code to perform a linear search for an integer in an 
array:

.. literalinclude:: ../projects/Arrays/Searching/Main.cs
   :start-after: chunk-linearsearch-begin
   :end-before: chunk-linearsearch-end
   :linenos:

Here's what it does:

- In lines 2-3 we set up a loop to go from 0 to N..1. We often use N
  to indicate the size of the array (and it's much easier to type
  than ``data.Length``.

- In line 4, we are checking whether ``data[i] == item``. What this is
  telling us is whether we found a match for the item we are searching.
  If we find the match, we immediately leave the loop by returning the
  position where it was found.

- It is worth noting here that the array, ``data``, may or my not
  be in sorted order. So our search reports the first location where
  we found the value. It is entirely possible that the more than
  one position in the array contains the matching value. If you 
  wanted to find the next one, you could modify the ``IntArrayLinearSearch()``
  method to have a third parameter, ``start``, that allows us
  to continue searching from where we left off. It might look
  something like the following:

.. literalinclude:: ../projects/Arrays/Searching/Main.cs
   :start-after: chunk-linearsearchfrom-begin
   :end-before: chunk-linearsearchfrom-end
   :linenos:

The following code shows how to use the linear search: 

.. literalinclude:: ../projects/Arrays/Searching/Main.cs
   :start-after: chunk-driver-begin
   :end-before: chunk-driver-end
   :linenos:

In this example, we ask the user to enter an array of data by entering
the values one at a time. As we've learned before, Console.ReadLine() gives
us a string, which we can then split using the ``Split()`` method. (It is
important that the items in this array are only separated by a single 
space character as ``Split()`` is not flexible to handle extra spaces.

Once we have gotten the input text split into an array of string (string[]),
we set up a simple loop (on lines 7-8) to convert each item in the string
array into an integer.

The rest is mostly self-explanatory.
