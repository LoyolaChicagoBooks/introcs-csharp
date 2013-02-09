
.. _searching:

Linear Searching 
===================================

In this section, we'll take a look at how to search for a value in an
array.  Although a fairly straightforward topic, it is one that comes
up repeatedly in programming.

These examples make use of arrays and loops, not to mention functions
(for putting it all together). 

.. index::
   search; linear
   double: algorithms; linear search

Linear Search
------------------

By far, one of the most common searches you will see in typical
programs. It also happens to be one of the more *misused* searches,
which is another reason we want you to know about it.

Here is the code from example :repsrc:`searching/searching.cs` 
to perform a linear search for an integer in an 
array:

.. literalinclude:: ../source/examples/searching/searching.cs
   :start-after: chunk-linearsearch-begin
   :end-before: chunk-linearsearch-end
   :linenos:

Here's what it does:

- In lines 2-3 we set up a loop to go from 0 to N-1. We often use N
  to indicate the size of the array (and it's much easier to type
  than ``data.Length``.

- In line 4, we see whether we found a match for the item we are searching.
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

.. literalinclude:: ../source/examples/searching/searching.cs
   :start-after: chunk-linearsearchfrom-begin
   :end-before: chunk-linearsearchfrom-end
   :linenos:

The following code shows how to use the linear search: 

.. literalinclude:: ../source/examples/searching/searching.cs
   :start-after: chunk-driver-begin
   :end-before: chunk
   :linenos:

In this example, we ask the user to enter an array of data by entering
the values space separated on a line. .  To convert to an int array we
use the function ``IntsFromString`` discussed in :ref:`split`.

To allow easy termination of the testing loop, we do not use ``PromptInt``
for ``searchItem``, because any
``int`` could be the search target.  By using ``PromptLine``, we can allow an empty
string as the response, and we test for that to terminate the loop.

The rest is mostly self-explanatory.

