.. _lab-search-performance:


Lab: Performance
=================

In :ref:`sorting` we took advantage of a few ideas
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
in nature. That is, the execution time can be bounded by a polynomial function 
of the data size :math:`n`. A more accurate measure may also include 
a logarithm.  Examples
include but are not limited to:

- :math:`O(1)` is constant time, 
  characterized by a calculation with a limited number of steps.
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
but ask you to write the code to 
do the actual analysis and produce a basic table.

The Experiments
-------------------

We're going to measure the performance of data structures we have been learning
about (and *will* learn about, for lists and sets). For this lab, we'll focus on:

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
  The separation is ``m = n/rep`` when ``rep < n``. The separation is 1, and
  we wrap around at the end of the array if ``rep > n``. 
- We'll start a Stopwatch just before entering the loop to perform the lookups. 


Starter Project
------------------

To make your life easier, we have put together a project 
that refers to all the code for all of the experiments you need
to run. (That's right, we're giving you the code for the *experiments*, 
but you're going to write
some code to run the various experiments and then run for varying sizes of ``n``.)
The stub file is :repsrc:`performance_lab_stub/performance_lab.cs`.

Recreate example project performance_lab_stub in your solution as performance_lab,
so you have your own copy to modify.  You can either 

* copy into the
  lab project the files :repsrc:`sorting/sorting.cs`,  
  :repsrc:`searching/searching.cs`, and 
  :repsrc:`binary_searching/binary_searching.cs`.  *If* you copy them into the lab 
  project, *rename* the unused ``Main`` method from :file:`binary_searching.cs`  
  to something else (since Xamarin Studio allows only one ``Main`` method in a
  project).
* An alternative is to recreate their whole projects, 
  and *reference* them from the lab project.

Here is the code for the first experiment, to test the performance of linear
searching on integer arrays:

.. literalinclude:: ../../examples/introcs/performance_lab_stub/performance_lab.cs
   :start-after: chunk-experiment1-begin
   :end-before: chunk-experiment1-end
   :linenos:
   :dedent: 6

Let's take a quick look at how this experiment is constructed. We'll also take a
look at the other experiments but these will likely be presented in a bit 
less detail, except to highlight the differences:

- On line 3, we create a ``Stopwatch`` instance. We'll be using this to do the timing.
- On lines 4-5, we are creating the data to be searched. Because we have already
  written this code in our sorting algorithms examples, we can refer to the
  Sorting class code in :file:`sorting.cs`, as long as you made the lab project 
  able to reference it.  We use the ``Sorting`` class name
  to access the method ``IntArrayGenerate()`` within this class. We also take advantage
  of this in the other experiments.
- Line 6 converts the number of repetitions into the increment in index values for each
  time.
- Line 7 resets the stopwatch. It is not technically required; however, we tend to be
  in the habit of doing it, because we sometimes reuse the same stopwatch and want
  to make sure it is completely zeroed out. A call to ``Reset()`` ensures it is zero.
- Line 8 actually starts the stopwatch. We are starting here as opposed to before line
  4, because the random data generation has nothing to do with the actual searching of
  the array data structure.
- Lines 10 through 12 are searching ``rep`` times for an item already known to
  be in the array. 
- Line 13 stops the stopwatch.
- Line 14 returns the elapsed time in *milliseconds*
  between the ``Start()`` and ``Stop()`` method calls,
  which reflects the actual time of the experiment.

Each of the other experiments is constructed similarly. 
For linear search and binary search
we use the methods created earlier.  
For the lists and the set we use the built-in ``Contains`` 
method to search.  
The list and set are directly initialized in their constructors from the
array data.  (More on that in later chapters.)

You need to fill in the ``Main`` method.
The stub already has code to generate a random value for the ``seed`` for 
any run of the program.  *Read* through to the end of the lab before 
starting to code.  A step-by-step sequence is suggested at the end.

*  Your code must parse command line ``args`` for the parameters ``rep`` 
   and *any number* 
   of values for ``n``.  For instance:
   
      mono PerformanceLab.exe 50000 1000 10000 100000

   would generate the table shown below for 50000 repetitions 
   for each of the values of ``n``: 1000,
   10000, and 100000.
   
*  In the end you will want to run each experiment 
   for ``rep`` repetitions and iterate through each different value of ``n``.

*  Present the result data in a nice printed right-justified table for
   all values of n,
   with a title including the number of repetitions.  Print
   something like the following, with the number of seconds calculated.

   .. code-block:: none
   
     Times in seconds with 50000 repetitions
            n    linear      list  binary     set
         1000  ????.???  ????.???  ??.???  ??.???
        10000  ????.???  ????.???  ??.???  ??.???
       100000  ????.???  ????.???  ??.???  ??.???
  
   The table would be longer if more values of n were entered on the command line.
   Note that the experiments return times in milliseconds, (1/1000 of a second)
   while the table should print times in *seconds*.
  
*  Your final aim is to 
   show your TA or instructor the results of 
   a run with a table with at least three lines of data and with n 
   being successive powers of 10, and *non-zero entries everywhere*.  *Read on*
   for the major catch!  
   
   You will need to 
   *experiment* and adjust the repetitions and ``n`` choices.  
   In order to *get all perceptible values* (nonzero), you will need a 
   very large number of repetitions to work for the fastest searches.
   Our choice of 50000 in the example is not appropriate with these ``n`` values.  
   The catch is that without further tweaking, you will only get nonzero
   values for all the fastest searches if the slower ones take 
   *ridiculously long*.
   
   Because the range of speeds is so enormous, make an accommodation with the 
   slow linear versions:  If ``rep >= 100`` and ``(long)n*rep >= 100000000``, 
   then, for the linear and list columns *only*, time with ``rep2 = rep/100`` 
   instead of ``rep``, 
   and then compensate by multiplying the resulting time by ``(double)rep/rep2`` 
   to produce the final table value.
   (This multiplier is not necessarily just 100, since the integer division creating
   ``rep2`` may not be exact.)           
   
Before making the modification for large numbers, be sure to test with 
small enough values (though some results will be 0).
Once again, you are encouraged to develop this is steps, for example:

#. Make sure you can parse the command line parameters.  In a testing version
   write code to print out ``rep``, 
   and *separate* code to print out all ``n`` values, for any number
   of ``n`` values.
#. Print out one *linear* test for ``rep`` and one value of ``n``.
#. Print out the results for all tests for ``rep`` and one value of ``n``.
   Keep ``rep*n`` small enough so the linear searches do not take too much time.
#. Do all values of ``n``.
#. Make the printing be formatted as in the sample table.
#. Add the modification for large ``rep*n``.
#. Experiment and get a table to show off!
