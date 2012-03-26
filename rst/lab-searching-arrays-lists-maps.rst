.. _lab-search-performance:


Lab: Performance
=================

In the sorting notes (see :ref:`sorting`) we took advantage of a few ideas
to show how to do basic 
benchmarking to compare the various approaches.

- using randomly-generated data

- making sure each algorithm is working with the same data

- making sure that we try a range of sizes to observe the effects of scaling

- using a timer with sufficiently high resolution (the ``Stopwatch`` gives 
  us measurements in milliseconds).

In this lab, you get your chance  to learn a bit more about performance
by comparing *searches*.
The art of benchmarking is
something that is easy to learn but takes a lifetime to master (to borrow
a phrase from the famous Othello board game).

Most of the algorithms we cover in introductory courses tend to be *polynomial*
in nature. That is, the execution time can be expressed as a polynomial function of the size
of the data size :math:`n`. Examples
include but are not limited to:

- :math:`O(n)` is linear time; often characterized by a single loop

- :math:`O(n^2)` is the time squared; often characterized by a nested loop

- :math:`O(log\ n)` is logarithmic (base 2) time; often characterized by a loop
  that repeatedly divides its work in half. The binary search is a well-known example.

- :math:`O(n\ log\ n)` is an example of a hybrid. Perhaps there is an outer loop that
  is linear and an inner loop that is logarithmic. 

And there are way more than these shown here. As you progress in computing, you'll
come to know and appreciate these in greater detail.

In this lab, we're going to look at a few different data structures and methods
that perform searches on them and do *empirical* analysis to get an idea of how
well each combination works. Contrasted with other labs where you had to write 
a lot of code, we're going to give you some code to do all of the needed work 
but ask you to do the actual analysis and produce a basic table.

.. george can't wait.  I do not know what tools you are expecting.
   chart (using Excel or
   other spreadsheet/analysis software like OpenOffice, Gnuplot, etc.) You can use
   anything you like to make your charts.

The Experiments
-------------------

We're going to measure the performance of data structures we have been learning
about in lectures. For this lab, we'll focus on:

- Integer arrays using :ref:`searching` and :ref:`binarysearching`

- :ref:`lists` of integers with linear searching

- :ref:`sets` of integers; checking if an item is contained in the set

In the interest of fairness, we are only going to look at the time it takes
to perform the various search operations. We're not going to count the time 
to randomly-generate the data and actually *build* the data structure. The 
reasoning is straightforward. We're interested in the search time, which is
completely independent of other aspects that may be at play. We're not at all
saying that the other aspects are unimportant but want to keep the assignment
focus on search.

The experimental apparatus that we are constructing will do the following
for each of the cases:

- create the data structure (e.g. new array, new list, new set)

- use a random seed ``seed``, initialize a random generator that will generate
  ``n`` values. 

- insert the random values into the data structure . 
  For the case of sets, which eliminate duplicates, it is
  entirely possible you will end up with a tiny fraction of a percent
  fewer than ``n`` values.

- to measure the performance of any given search method, we need to perform a 
  significant number of lookups (based on numbers in the random sequence) to
  ensure that we get an accurate idea of the *average* lookup time in practice. 
  We'll call this parameter, ``rep``.  We will spread out the values looked for 
  by checking data elements that have indices at a regular interval throughout the array.
  The separation is ``m = n/rep`` when ``rep < n``. We wrap around if ``rep > n``.
  
- We'll start a Stopwatch just before entering the loop to perform the lookups. 



Starter Project
------------------

You will probably find it convenient to start from our ``Arrays`` MonoDevelop
solution. You can find this in ``projects/Arrays``. You need this entire folder.

To make your life easier, we have put together a project within this solution,
``PerformanceLab`` that contains the code for all of the experiments you need
to run. (That's right, we're giving you the code for the experiments, 
but you're going to write
some code to run the various experiments and then run for varying sizes of ``n``.)


..  george not sure what you still want to di with this
    .. todo::
       George is still working on this part. I will put some text in to explain each
       of the experiments. It should be quick.
    
    .. todo::
       Need to give some explanation of what they need to produce at the end. I would
       like to see them produce nice looking charts for each of the experiments.


Here is the code for the first experiment, to test the performance of linear
searching on integer arrays:

.. literalinclude:: ../projects/Arrays/PerformanceLab/Main.cs
   :start-after: chunk-experiment1-begin
   :end-before: chunk-experiment1-end
   :linenos:

Let's take a quick look at how this experiment is constructed. We'll also take a
look at the other experiments but these will likely be presented in a bit 
less detail, except to highlight the differences:

- On line 3, we create a ``Stopwatch`` instance. We'll be using this to do the timing.

- On lines 4-5, we are creating the data to be searched. Because we have already
  written this code in our sorting algorithms examples, we can use the project
  by taking advantage of project references and using the ``Sorting`` class name
  to access the method ``IntArrayGenerate()`` within this class. We take advantage
  of this in the other experiments.

- Line 6 resets the stopwatch. It is not technically required; however, we tend to be
  in the habit of doing it, because we sometimes reuse the same stopwatch and want
  to make sure it is completely zeroed out. A call to ``Reset()`` ensures it is zero.

- Line 7 actually starts the stopwatch. We are starting here as opposed to before line
  3, because the random data generation has nothing to do with the actual searching of
  the array data structure.

- Line 8 converts the number of repetitions into the increment in index values for each
  time.
  
- Lines 10 through 12 are searching ``rep`` times for an item already known to
  be in the array. 

- Line 13 stops the stopwatch.

- Line 14 returns the elapsed time in milliseconds
  between the ``Start()`` and ``Stop()`` method calls,
  which reflects the actual time of the experiment.

Each of the other experiments is constructed similarly. For linear search and binary search
we use the methods created earlier.  For the lists and the set we use the built-in ``Contains`` 
method to search.  The list and set are directly initialized in their constructors from the
array data.

You need to fill in the Main method:

#. Write the code to parse command line args for the parameters rep and *any number* 
   of values for n.  For instance:
   
      mono PerformanceLab.exe 50 1000 10000 100000

   would generate the table shown below for 50 repetitions for each of the values of n, 1000,
   10000, and 100000.
   
#. Write the code to run each of the experiments for ``rep`` and a given value of ``n``.

#. Iterate through the values of ``n`` and print a table,
   something like the following, with the number of seconds calculated.
   Experiment and adjust the repetitions to get perceptable values.  
   Our choice of 50 may not be appropriate with these ``n`` values.  ::

           n   rep   linear    binary    list     set
        1000    50   ??.???    ??.???  ??.???  ??.???
       10000    50   ??.???    ??.???  ??.???  ??.???
      100000    50   ??.???    ??.???  ??.???  ??.???
  
  The table would be longer if more values of n were entered on the command line.