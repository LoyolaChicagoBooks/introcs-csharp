.. index:: 
   double: homework; grade files

.. _hw-gradefiles:

Grade File Homework
============================ 

In this assignment, we're going to begin taking steps to help you
achieve greater *independence* when it comes to programming. This
means (among other things) that you will be given what is commonly
known as a specification. In software development--and in the business
world in general, it is customary to capture a set of *business
requirements* in what is commonly known as a *requirements
specification* document. While what you read here will be much more
concise, we want you to become familar with requirements-driven
thinking, without which many real-world software projects fail.

After presenting the set of requirements, we will give you some hints
for how to *implement* the requirements. These hints may or may not
prove compltely helful to you, and you are also invited to come up
with your own solutions. As we inch closer to the semester project,
you're going to want touse your imagination to create a good solution
to a problem.


Brief Problem Statement
-----------------------

The previous two homework assignments represent a great simplification
of the real-world process of grading. The notion that grade
information must be entered manually is rather tedious, not to mention
error prone. In the real world, grade information would be kept in a
file (a spreadsheet is common), from which various calculations and
summary reports could be generated.

In this assignment, the problem we are trying to solve is to take all
of the *raw* grade data from one or more student files and prepare a
*grade report* for each student, along with a *summary report* for the
entire class.

Although we could do all of what we're decribing here with a
*spreadsheet*, the point is to show how we can use C# to read in a
simplified form of comma-separated data, process it, and do some
general-purpose calculations on the data.

Using C#
--------

We'll be making use of a number of C# features (some old, some new) in
this homework:

- decisions, loops, strings, and functions (basically all of our notes, chapters 1-5)
- files
- arrays


Requirements
------------

#. Unlike in previous assignments, this program must accept data from
   a collection of input files (that is, it will not be reading from
   the Console.

#. The master file will contain a list of student information
   records. Each record (one per input line) will have the following
   structure::

      Student ID, Last Name, First Name, Middle Initial

   So for example::

      P34323243343,Thiruvathukal,George,K.
      P87483743843,Harrington,Andrew,N.

 
#. The collecton of ssecondary files will contain one or more records
   corresponding to the *scores* for a particular student.  The
   secondary files are named after the student id. For example,
   George's scores will be kept in a file named
   ``P34323243343.dat``. Andy's scores are in
   ``P87483743843.dat``. Each record (one per input line will have the
   following structure::

      Category, Item, Points Possible, Points Earned

   where:

   - category is a single letter *code* for homework (H), labs (L), exams (E), class participation (C), and projects (P)
   - item is a number within that category (0, 1, 2, ...)
   - points possible can be any value but must be greater than zero to be meaningful
   - points earned can be any value but must be less than points possible

#. The program may either prompt the user for the input filename or
   accept it as a command-line argument using the special form of
   ``Main(string[] args)``.

#. The program will process the data from each student file and
   calculate the average within each category and weighted average for
   each student, using the code that was developed in the previous
   assignment. You can either prompt the user for the weights (as done
   in the previous program) or optionally read the weights from an
   additional file, ``weights.dat``.

#. The final report must show the student's last name, first name,
   middle initial, averages for each of the categories, weighted
   average, and letter grade.


Hints
-----

#. You'll be able to learn how to use files by reading the Miles
   chapter on Files. We'll also have a lab exercise for learning to
   work with file I/O. You're still going to need ReadLine() and
   WriteLine() in this assignment, the only difference is that we'll
   be making use of File classes to get the input from a file instead
   of the Console. The actual syntax will be roughly equivalent.

#. You'll want to write a function, ``string[] SplitInput(string
   input)`` that returns all of the files as an array of strings.
   This will make it easy to:

   - check that the correct number of fields is present in an input record
   - use indexing to get the field of interest

#. You'll need an *outer loop* to read the records from the master
   file. You'll need an *inner loop* (or a loop inside of a function)
   to read the records for each student.

#. When processing the records from a student file, you should process
   each one separately and not assumed they are grouped in any
   particular order. For example, you could have data like this::

     Q,0,100,80
     H,0,85,75
     H,2,70,30
     Q,1,100,72.5
     H,1,70,70
     Q,2,100,100
     ...
     etc.

   This means, specifically, that your program simply reads a record,
   decides what category it is in, and updates the running total for
   that category. Once the entire file has been read, you can compute
   the average for each category based on the *number of items* you
   actually read in that category.

#. For now, you can assume that there is no need to *keep* a score
   after you've read it. We will need to use an array, however, to
   keep track of each of the names we have read in, the running total
   for each category, and ultimately the averags within each
   category. In this program, we will assume that there is a maximum
   number of students allowed by our program.  Later, when working
   with classes/objects, we'll learn how to expand this to support any
   number of students.


