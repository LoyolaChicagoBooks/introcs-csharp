.. index:: search; binary
   binary search 
   single: algorithms; binary search

.. _binarysearching:

Binary Searching 
===================================

Binary search is an improvement over linear searching that works only
if the data in the array are sorted beforehand.

Suppose we have the following array data shown under the array indices:

.. code-block:: none

   10  20  30  40  50  60  70  80  90  100 115 125 135 145 155 178 198

Binary search works by keeping track of the midpoint (mid) and the minimum (min) and 
maximum (max) index positions where the item *might be*.

If we are looking for a number, say, 115, here is a visual on how we might go about it.
We display the indices over the data being considered.
Here min and max are the smallest and largest index to still consider.
A textual explanation follows the visual:

..  code-block:: none

       0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  
      10  20  30  40  50  60  70  80  90 100 115 125 135 145 155 178 198
    min=0 max=16 mid=8
                                         100 115 125 135 145 155 178 198
    min=9 max=16 mid=12
                                         100 115 125                    
    min=9 max=11 mid=10
    Item 115 found at position 10

- We start by testing the data at position 8. 115 is greater than the value at position
  8 (100), so we assume that the value must be somewhere between positions 9 and 16.

- In the second pass, we test the data at position 12 (the midpoint between 9 and 16).
  115 is less than the value at position 12, so we assume that the value must be somewhere
  between positions 9 and 11.

- In the last pass, we test the value at position 10. The value 115 is at this position,
  so we're done.

So binary search (as its name might suggest) works by dividing the interval to be searched
during each pass in half. If you think about how it's working here with 17 items. Because
there is integer division here, the interval will not always be precisely half. it is the
floor of dividing by 2 (integer division, that is).

With the data above, you see that the algorithm determined the item within 3 steps.
To reduce to one element
to consider, it could be 4 or 5 steps.  Note that :math:`4 < log_2 17 < 5`.

Now that we've seen how the method works, here is the code that does the work:

.. literalinclude:: ../source/examples/binary_searching/binary_searching.cs
   :start-after: chunk-binarysearch-begin
   :end-before: chunk
   :linenos:

Here's a quick explanation, because it largely follows from the above explanation.

- Line 5: Initially item could be anywhere in the array, 
  so minimum is at position 0 and maximum is at position 
  N-1 (data.Length - 1).
- The loop to make repeated passes over the array begins on line 6.  
  We can only continue searching if there is some data left to consider 
  (``min <= max``).
- Line 7 does just what we expect: 
  It calculates the median position (mid).
- It is always possible that we've found the item, which is what we test on line 8,
  and return with our answer if we found it.
- Lines 10-13: If not, we continue.  If the item is greater than the value
  at this mid position, we know it is in the "upper half". 
  Otherwise, it's in the "lower half".
- Line 15: Otherwise the binary search loop terminates, and we 
  return -1 (to indicate not found). 
  The -1 value is a commonly-returned indicator of failure in search operations
  (especially on arrays, lists, and strings), 
  so we use this mostly out of respect for tradition. 
  It makes particular sense, 
  because -1 is not within the *index set* of the array (which starts
  at 0 in C# and ends at ``data.Length - 1``. 

Of course we generally would be searching in an array with multiple elements.
It is still important to check *edge cases*:  Check that the code correctly 
returns -1 if the array has length 0 (a legal length).

Similar to linear searching, we provide a main program that tests it out.  The whole code
is in :repsrc:`binary_searching/binary_searching.cs`.  It uses 
an elaboration of binary search that prints
out the steps visually, as in the introduction to this section. 
It also references previous example projects: functions from files 
:repsrc:`searching/searching.cs` and :repsrc:`sorting/sorting.cs`.

.. literalinclude:: ../source/examples/binary_searching/binary_searching.cs
   :start-after: chunk-driver-begin
   :end-before: chunk
   :linenos:

Elaborated Binary Search Exercise
----------------------------------

Even if you do not find ``item`` in a binary search, it is sometimes useful to know
where ``item`` lies in relation to the array elements.  It could be
before the first element, in between two elements, or after the last element.
Suppose ``N`` is the (positive) array length.
Instead of just returning -1 if ``item`` is not in the array, return 

* -1 if ``item < data[0]``
* ``-(k+1)`` if ``data[k-1] < item < data[k]`` 
* ``-(N+1)`` if ``data[N-1] < item``

Modify :repsrc:`binary_searching/binary_searching.cs` into 
:file:`binary_searching2.cs` so this extra information is returned
(and indicated clearly in the main testing program).
This should *not* require a change to the ``while`` loop, *nor* 
require any added loop. 