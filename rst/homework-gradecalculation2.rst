
.. index::
   triple: homework; input-output; decisions
   triple: homework; input-output; loops
   
.. _homework-grade-calculation2:

Homework: Grade Calculation from Individual Scores
==================================================

In the previous assignment, we calculated grades based on a *memorized* 
overall grade within each of the categories below, as in this example:

- exams - 40% (integer weight is 40)
- labs - 15% (weight 15)
- homework - 15% (weight 15)
- project - 20% (weight 20)
- participation - 10% (weight 10)

In this assignment, we are going to change the specification slightly
to make the program a bit smarter. Instead of someone having to remember
what their average grade was for each category, we will prompt the user for
the number of items within each category (e.g. number of exams, number
of labs, etc.), have the user enter individual grades, and have the program
calculate the average for the category.

As usual, we will begin by specifying *requirements*. Whenever required,
we will explain how you would approach the solution to the requirement
in C#.  User responses are shown **bold faced**.

Functional Requirements
-----------------------

#. Instead of bombing out if the weights don't add up to 100, use a 
   ``do { ... } while`` loop (see Miles p. 43-44) to prompt the user again
   for all of the weights until they do add up to 100. The ``do { ... } while``
   loop is the right choice here, because you can test all of the weights
   at the end of the loop, after each time they have been entered 
   in the loop.

#. Add code to prompt the user for the number of items in each category:

      Please enter the number of exams: **3**

#. Instead of prompting the user for an overall average 
   exam grade, use a loop  to 
   read one grade at a time. The grades will be added together (on the fly)
   to give the grade for that category. For example, after you have asked
   for the number of exams, you'd prompt the user to enter each exam 
   grade and have the program compute the sum. 
   To make sure everyone understands what should
   be happening, you should also print a *running total* of the grade 
   category you're calculating:

     | Please enter the grade for exam 1: **100**
     | Total exam points: 100
     |
     | Please enter the grade for exam 2: **90**
     | Total exam points: 190
     |
     | Please enter the grade for exam 3: **80**
     | Total exam points: 270
     |
     | Calculated average exam grade = 90.0

   Write a function, ``FindAverage``, 
   to do this, and that can be reused for each
   category.  (Since it works for each category, the category
   *name* will need to be a parameter to ``FindAverage``.)

#. Once you have read in the data for each of the items within a category,
   you'll basically be able to *reuse* the code that you developed in the
   previous assignment to compute the weighted average and print the
   final letter grade.

Style Requirements
------------------

#. For this assignment, you are expected to start using functions for all
   aspects of the assignment. For example, it can become tedious in a hurry
   to write code to prompt for each of exams, labs, homeworks, etc. when 
   a single function (with parameter named *category*) could be used to
   avoid repeating yourself. (And per the Hints section, you will also
   want to write your function to take advantage of our *input* 
   functions.

#. Also beginning with this assignment, it is expected that your work 
   will be presented neatly. That is, we expect the following:

   - proper indentation that makes your program more readable by other
     humans. Use all spaces, not tabs to indent.  You never know what
     default tabs your grader will have set up.

   - proper naming of classes and functions. In C#, the convention is to
     begin a name with a capital letter. You can have multiple words in a
     name, but these should be capitalized using a method known as 
     CamelCase [CamelCase]_. We also recommend this same naming convention
     for variables but with a lowercase first letter. 
     For variables, we are also
     ok with the use of underscores. For example, in homework 1 we used
     names like `exam_grade`. If you use CamelCase, you can name this
     variable `examGrade`. 

   - If you have any questions about the neatness or appearance of your 
     code, please talk to the instructor or teaching assistant.

   - This guide from CIS 193 at [UPennCSharp]_ 
     provides a nice set of conventions
     to follow. We include this here so you know that other faculty at 
     other universities also consider neatness/apperance to be important.

Hints
-----

This assignment will be the first one where you need to start using 
functions. Otherwise, you'll find yourself getting tired within minutes
of starting your work.`

You need to have two functions to prompt the user to input 
integer and double
data. We're going to give you the code for these here and in 
example ``PromptUser1.cs``.  Your job is to
copy them into your program and make use of them in your solution.  The
first function is
a supporting function to return a string in response to a prompt.
These versions are sufficient for the assignment, 
though you are *welcomed* to replace these
with more *robust* versions that get developed in class later:

.. literalinclude:: ../examples/PromptUser1.cs
   :start-after: chunk
   :end-before: chunk
   
.. [CamelCase] http://en.wikipedia.org/wiki/CamelCase

.. [UPennCSharp] http://www.cis.upenn.edu/~cis193/csstyle.html


Grading Rubric
--------------

.. warning::

   As a general rule, we expect programs to be complete, 
   compile correctly, run, and be
   thoroughly tested. We are able to grade an incomplete program 
   but will only give at most 10/25
   for effort. Instead of submitting something incomplete,
   you are encouraged to complete your program and 
   submit it per the late policy.  Start early and get help!

25 point assignment broken down as follows:

- Loop until weights add to 100: 5

- Average any number of grades in a category: 5

- One function that is reused and works for the average in each category: 5

- Previous program features still work: 5

- Style: 5


Logs and Partners
-------------------

You may work with a partner, following good pair-programming practice,
sharing responsibility for all parts.

Only one of a pair needs to submit the actual programming assignment.
However *both* students, *independently*, should write and
include a log in their
Homework submission.  Students working alone should also submit a log, 
with fewer parts.

Each individual's log should indicate each of the following clearly:

- Your name and who your partner is (if you have one)
- Your approximate total number of hours working on the homework
- Some comment about how it went - what was hard ...
- An assessment of your contribution (if you have a partner) 
- An assessment of your partner's contribution (if you have a partner).  

Just omit the parts about a partner if you do not have one.

.. note::
   Name the log file with the exact file name: 
   "log.txt" and make it a plain text file.  
   You can create it in a program editor or in a fancy document editor.
   If you use a fancy document editor, be sure to save it an a plain text file,
   usually indicated by the ".txt" suffix.


