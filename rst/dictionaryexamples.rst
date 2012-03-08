

Dictionary Examples
===================

.. index::
   double: example; Word Count
   double: example; List
   double: example; Set

Counting the numer of repetitions of words in a text provides a realistic
example of using a ``Dictionary``.  With each word that you find, you want to associate
a number of repetitions.  a complete program is in the  project file 
:file:`Dictionaries/CountWords/CountWords.cs`. 


The central functions are excerpted below, and they also introduce some extra 
features from the .Net libraries.

One feature is another generic type ``HashSet``, which models a mathematical set:  a collection
with no repetitions and no defined order.  We use a ``HashSet`` for the 
words to be ignored.  We use a ``HashSet`` rather than a ``List`` because
the ``Contains`` method for a ``List`` has linear order, while the ``Contains`` method for
a ``HashSet`` uses the same trick as in a ``Dictionary`` to be of constant order on average.

That lack of order for a ``HashSet`` means it cannot
be indexed, but otherwise it has mostly the same methods and constructors 
that have been discussed for a ``List``, including ``Add`` and ``Contains`` and 
a constructor taking a collection as parameter.  This constructor pattern is used twice,
to create a ``HashSet`` from an array, and later to create a ``List`` from a ``HashSet``.  
The latter is needed so the ``List`` can be sorted in alphabetical order with its 
``Sort`` method, used here for the first time.  Our table contains the words in
alphabeticaly order.

Also used for the first time are two string methods: the pretty clearly named ``ToCharArray`` and
another variation on ``Split``.  An alternative to supplying a single character to split on,
is to use a ``char`` array as parameter, and the string is split at an occurrence of any of the
characters in the array.  This allows a split on all punctuation and special symbol characters,
as well as a blank.

We separate the processing into two functions, one calculating the dictionary, and one printing
a table.  To reduce the amount of clutter in the ``Dictionary``, the function
``GetCounts`` takes a set of words to ignore as a parameter.

.. literalinclude:: ../projects/Dictionaries/CountWords/CountWords.cs
   :start-after: chunk
   :end-before: chunk

Look at the code carefully, and look at the whole program that analyses the
Gettysburg Address.