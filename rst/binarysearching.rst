.. _binarysearching:

Binary Searching 
===================================

Binary search is an improvement over linear searching that works only
if the data in the array are sorted beforehand.

Suppose we have the following array data, showing indices underneath::

   10   20   30   40   50   60   70   80   90   100  115  125  135  145  155  178  198
    0    1    2    3    4    5    6    7    8     9   10   11   12   13   14   15   16

If we are looking for a number, say, 115, here is a visual on how we might go about it::

   10   20   30   40   50   60   70   80   90   100  115  125  135  146  155  178  198  
   min=0 max=16 mid=8: 90 < 115
                                                100  115  125  135  146  155  178  198  
   min=9 max=16 mid=12: 135 > 115
                                                100  115  125                           
   min=9 max=11 mid=10: found 115


Binary search works by keeping track of the midpoint (mid) and the minimum (min) and 
maximum (max) positions where the item *might be*.

Let's see how we migth search for the value 115.

- We start by testing the data at position 8. 115 is greater than the value at position
  8 (100), so we assume that the value must be somewhere between positions 9 and 16.

- In the second pass, we test the data at position 12 (the midpoint between 9 and 16).
  115 is less than the value at position 12, so we assume that the value must be somewhere
  between positions 9 and 11.

- In the last pass, we test the value at position 10. The value 115 is at this position,
  so we're done.

So binary search (as its name might suggest) works by dividing the interval to be searched
during each pass in half. If you think about how it's working here with 16 items. Because
there is integer division here, the interval will not always be precisely half. it is the
floor of dividing by 2 (integer division, that is).

You can see that the above determined the item within 3 steps. At most it would be 4 steps,
which is :math:`log_2 16 = 4`.


.. index::
   double: search; binary
   double: algorithms; binary search

Binary Search
------------------

Now that we've seen how the method works, here is the code that does the work:

.. literalinclude:: ../projects/Arrays/BinarySearching/Main.cs
   :start-after: chunk-binarysearch-begin
   :end-before: chunk-binarysearch-end
   :linenos:

Here's a quick explanation, because it largely follows from the above explanation.

- Line 3-5. We assume that the minimum is at position 0 and maximum is at position 
  N-1 (data.Length - 1). This assumption is only valid if the data are sorted.

- The loop to make repeated passes over the array begins on line 6. We use a bottom-tested
  while loop, because we know that we need to enter this loop--no matter what--at least once
  to determine whether the item is in the middle or not. If you think about any given array
  there is always a chance you could "guess right" the first time, simply by having picked
  the median value.

- Line 7 does just what we expect. It calculates the median position (mid) and then proceeds
  to test whether the value is present at this position. If it is greater than the value
  at this position, we know it is in the "upper half". Otherwise, it's in the lower half.
  It is also possible that we've found the item, which is what we test on line 12.

- The binary search terminates if in the course of searching for the item, ``min`` *bumps into*
  ``max``. 

- The binary search either returns the *position* where we found the item, or it returns -1 (to 
  indicate not found). The -1 value is a commonly-returned function in most search operations
  (especially on lists and strings), so we use this mostly out of respect for tradition. 
  It makes particular sense, becuase -1 is not within the *index set* of the array (which starts
  at 0 in C# and ends at ``data.Length - 1``. 

Similar to linear searching, we provide a main program that tests it out. Because the
code is so similar, we will leave the study thereof to you, the reader.

.. literalinclude:: ../projects/Arrays/BinarySearching/Main.cs
   :start-after: chunk-driver-begin
   :end-before: chunk-driver-end
   :linenos:

