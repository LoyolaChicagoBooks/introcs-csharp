.. index:: big oh
   dictionary; big oh 
   linear order
   constant order

.. _dictionary-efficiency:

Dictionary Efficiency
=======================

We could simulate the effect of a Dictionary pretty easily by keeping
a List ``keys`` and a List ``values``, in the same order.  We could
find the entry with a specified key with::

   int i = keys.IndexOf(key);
   return values[i];
   
Searching though a ``List``, however, take time proportional to the
length of the ``List`` in general, *linear order*.  Through a clever implementation
covered in data structures classes, a ``Dictionary`` uses a *hash table*
to make the average lookup time of *constant order*.  A hash table depends on the
keys being immutable.


