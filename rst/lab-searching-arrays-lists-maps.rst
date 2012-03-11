.. _lab-search-performance:


Performance
===============

In this lab, we're going to learn a bit about performance. In our lecture on 
Sorting Algorithms (see :ref:`sorting`), we have shown how to do basic 
benchmarking to compare the various approaches. The art of benchmarking is
something that is easy to learn but takes a lifetime to master (to borrow
a phrase from the famous Othello board game).

In this lecture, we took advantage of a few ideas:

- using randomly-generated data

- making sure each algorithm is working with the same data

- making sure that we try a range of sizes to observe the effects of scaling

- using a timer with sufficiently high resolution (the ``Stopwatch`` gives 
  us measurements via a ``TimeSpan`` instance.


Most of the algorithms we cover in introductory courses tend to be *polynomial*
in nature. That is, the time can be expressed as a polynomial function. Examples
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
but ask you to do the actual analysis and produce a basic chart (using Excel or
other spreadsheet/analysis software like OpenOffice, Gnuplot, etc.) You can use
anything you like to make your charts.

The Experiments
-------------------

We're going to measure the performance of data structures we have been learning
about in lectures. For this lab, we'll focus on:

- integer arrays using linear and binary searching

- Dictionaries with integer keys using lookups by integer key

- Lists of integer with linear searching

In the interest of fairness, we are only going to look at the time it takes
to perform the various search operations. We're not going to count the time 
to randomly-generate the data and actually *build* the data structure. The 
reasoning is straightforward. We're interested in the search time, which is
completely independent of other aspects that may be at play. We're not at all
saying that the other aspects are unimportant but want to keep the assignment
focus on search.

The experimental apparatus that we are constructing will do the following
for each of the cases:

- create the data structure (e.g. new array, new list, new dictionary)

- use a random seed ``seed``, initialize a random generator that will generate
  ``n`` *distinct* values. 

- insert the random values into the data structure until the structure contains
  ``n`` values. For the case of dictionaries, which eliminate duplicates, it is
  entirely possible you will have to generate more than ``n`` values until the
  structure is filled with ``n`` actual values.

- to measure the performance of any given search method, we need to perform a 
  significant number of lookups (based on numbers in the random sequence) to
  ensure that we get an accurate idea of the *average* lookup time in practice. 
  We'll call this parameter, ``m``, which will pick one of every ``m`` values
  in the random sequence to test whether it's in the data structure. (We're only
  going to look up values that we know are in the data structure.)

- We'll start a Stopwatch just before entering the loop to perform the lookups. 



Starter Project
------------------

You will probably find it convenient to start from our ``Arrays`` MonoDevelop
solution. You can find this in ``projects/Arrays``. You need this entire folder.

To make your life easier, we have put together a project within this solution,
``PerformanceLab`` that contains the code for all of the experiments you need
to run. (That's right, we're giving you the code, but you're going to write
some code to run the various experiments and then run for varying sizes of ``n``.)


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

- Line 7 actually starts the stopwatch. WE are starting here as opposed to before line
  3, because the random data generation has nothing to do with the actual searching of
  the array data structure.

- Lines 8 through 10 are searching every ``m`` values for an item already known to
  be in the array. 

- Line 12 stops the stopwatch.

- Line 13 returns the elapsed time between the ``Start()`` and ``Stop()`` method calls,
  which reflects the actual time of the experiment.


Each of the other experiments is constructed similarly. We will explain each of these,
focusing on the obvious differences.

.. todo::
   George to finish this Sunday, I hope.

