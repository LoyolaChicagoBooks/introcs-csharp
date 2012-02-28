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
   a collection of input files (that is, it will not be reading most of the 
   data from
   the Console.  

#. The program needs a class abbreviation from the user.  If there
   is a command line argument, use it.  Make sure your code can 
   read a command-line argument using the special form of
   ``Main(string[] args)``.  If there is not command line argument,
   prompt the user for it.
   The abbreviation should not include spaces.
   An example would be Comp170.  All data files will include the class
   abbreviation as part of their name.  We will use Comp170 in the examples,
   but it could be something else.

#. There are two master files. One is "Categories" + the course abbreviation
   + ".txt".  For example, CategoriesComp170.txt.
   
   It will contain three lines.
   The first line is a comma separated list of category names like
   
       Exam,Lab,Homework,Project,Class participation
       
   There may be extra spaces after the commas.  
   Categories will be chosen so that each one starts with a different letter.
   
   The second line contains the integer weights for each category, like
   
       40, 15, 15, 20, 10
       
   They do *not* need to add to 100.  If the sum is called totWeights,
   get the final grade by summing for each category::
   
      (category weight)(category grade)/totWeights
   
   The third line will contain the number of grades in each category, like
   
       2, 5, 3, 1, 2
       
   The second master file will be "Students" + the course abbreviation + ".txt".
   For example :file:`StudentsComp170.txt`.
   It will contain a list of student information
   records. Each record (one per input line) will have the following
   structure:

      Student ID, Last Name, First Name

   For example::

      P34323243,Thiruvathukal,George
      P87483743, Harrington, Andrew

 
#. There will be a secondary file for each student, 
   named after the student id and the course abbreviation and ".dat". 
   For example,
   George's scores will be kept in a file named
   ``P34323243Comp170.dat``. Andy's scores are in
   ``P87483743Comp170.dat``. Each record (one per input line will have the
   following structure:

      Category letter, Item, Points Earned

   where:

   - category letter is the first letter of the category.  With the categories
     given in the example above, they would be E, L, H, P, and C.
   - item is a number within that category (0, 1, 2, ...)
   - points earned is a real number
   - the lines are in no special order.
   
   For example::
   
     L,1,100
     H,1,85.5
     H,2,70
     E,1,72.5
     H,3,70
     P,1,100

#. The program will process the data from each student file and
   calculate the average within each category and weighted average 
   and letter grade for
   each student, using code derived from the previous
   assignment. 

#. The final report file is named with the course abbreviation 
   + "Summary.txt".  Example: Comp170Summary.txt.
   This file must have a line for each student showing the student's last name, first name,
   weighted average rounded to one decimal place, and letter grade.  
   For example::
   
     Thiruvathukal, George 99.5 A
     Harrington, Andrew 91.2 A-
   
#. In the course repository, there is a stub for the
   homework in subdirectory :file:`projects/HW/GradeFiles`.
   Pull the latest version of the repository and copy the homework files to 
   your solution area (hopefully in your own repostitory).  There is test data for
   class abbreviations Comp170 and Comp150 in the project directory.   
   There are also solution files for the 
   summaries.  Their names end in ``Solution.txt`` to distinguish them from the
   summary files you should generate in tests.
   
   While your program should certainly work for course abbreviations Comp170 and Comp150,
   it should also work in general for any data files your refer to
   in the defined formats.
   
   The stub of GradeFiles.cs has a Main function that just prints out the
   current working directory.  That should help you check if you have the 
   "Run With" parameters for MonoDevelop,
   setting the working directory to be the main 
   project directory, ``GradeFiles``, 
   not the default :file:`bin/Debug` subdirectory. 
   See :ref:`monodevelop-run-with`.
   
Hints
-----

#. You'll be able to learn how to use files by reading 
   :ref:`files` and the Miles section 6.3 on Files. Be sure to read
   :ref:`monodevelop-run-with`.
   We'll also have a lab exercise for learning to
   work with file I/O. You're still going to need ReadLine() and
   WriteLine() in this assignment, the only difference is that we'll
   be making use of File classes to get the input from a file instead
   of the Console. The parameter syntax will be the same.

#. For each file line you'll want to use the string ``Split`` method, 
   and then the ``Trim`` 
   method on each part to
   remove surrounding spaces. Then 
   use indexing to get the field of interest. (More below.)

#. You'll need an *outer loop* to read the records from the master name
   file. You'll need an *inner loop* (or a loop inside of a function)
   to read the records for each student.

#. When processing the records from a student file, you should process
   each one separately and not assumed they are grouped in any
   particular order. 

   This means, specifically, that your program simply reads a record,
   decides what category it is in, and updates the running total for
   that category. Once the entire file has been read, you can compute
   the average for each category based on the *number of items* that
   *should* be in that category, which may be more than the number
   of records in the file for items turned in.

#. There is no need to *keep* a score
   after you've read it and immediately used it.
   *Do* use an array, however, for the running total
   for each category. 

#. In order to deal with a varying number of categories and different 
   possible first letter codes, youi will need to split the category
   name line into an array, say 
       
       string[] categories;
       
   To know where to store data for each category, you can use this
   function after you read in a code, to determine the proper index.
   It is already in the stub code::
   
      static int codeIndex(string code, string[] categories)
      {
         for (int i = 0; i < categories.Length; i++) {
            if (categories[i].StartsWith(code)) {
               return i;
            }
         }
         return -1;
      }
       
   You may assume the data is good and the -1 is never returned, 
   but the compiler needs this line.
   
#. You cannot have one fixed formula to calculate the final weighted grade,
   because you do not know the number of categories when writing the code. 
   You will have to accumulate parts in a loop.
   
Grading Rubric (25 points)
---------------------------

#. Get the abbreviation from the command line if it is there. [2]
#. Otherwise get the abbreviation from prompting the user. [1]
#. Read the Categories file and parse lines. [2]
#. Deal with each student. [3]
#. Calculate the cumulative grades in each category, reading
   a student's file once, using arrays. [5]
#. Calculate the overall grade and letter grade. [3]
#. Generate summary entries. [3]
#. Use functions where there would otherwise be two several-line blocks of code
   differing only in the name of the data evaluated and the name of the
   result generated. [2]
#. Use good style:  formatting, naming conventions, 
   meaningful names other than for simple array indices, lack of redundant code. [4]
   
Optional Extra Credit Opportunities!  You may choose to do 
any combination that does not include both of the last two options about missing work.

#. Format the summary file in nice columns.  Include the grades for each category,
   rounded to one decimal place.  Include a heading line.    
   For example the summary for the repository example Comp150 could start::
   
       Name: Last, First           Avg Gr     E     H     P
       Hopper, Grace             100.0 A  100.0 100.0 100.0

   You may assume the last-first name field fits in 25 columns.
   Copy the first three column headings from above.
   The column headings for the categories can just be their one letter code.
   Names and letter grades should be left-justified (padded on the right, by 
   using a negative field width). [2]
#. Change the scheme for calculating letter grade to use a function that calculates
   the proper grade, where the only ``if`` statement is one simple one
   inside a loop.  The ``if`` statement will have a return statement in its body, 
   and no ``else``.  The loop will need to use
   corresponding arrays of data for grade cutoffs and grade names. [3]
#. For any student who has missed passing in all the required items, 
   generate extra data on missing work in the summary, at the right end of the
   line for the student.  Add this to 
   whichever version of the earlier parts you use.
   Include an addendum starting with "Missing: "
   only if there are not enough grades in one or more
   categories.  For each category where
   one or more grades is missing, including a count of the number of grades missing followed
   by the category letter.  An example using the example categories is::

      Doe, John 68.5 D+ Missing: 2 L 1 H
      Smith, Chris 83.2 B M issing: 1 L
      Star, Anna 91.2 A-
      
   meaning Doe has 2 labs missing and 1 homework missing.  Smith is missing one lab.  Star
   has done all assigned work, since nothing is added. [3]
#. This is a much harder alternate version for handling missing work:  
   Unlike the previous format, do not count and print the number of missing 
   entries in each category in a form like "2 L ".
   Replace such an entry with a list of *each* item
   missing, in order, as in "L:1, 4 ", meaning labs 1 and 4 were missing.  
   Assume that the expected item numbers for a category 
   run from 1 through the number of grades in the category.
   You may assume no item number for the same category appears twice.
   For example, with the sample data files given in the repository for
   Comp170, the summary line for John Doe would be::
       
       Doe, John 78.9 C+ Missing: L: 1, 4 H: 3
       
   The most straightforward way to do this requires something 
   like a 2-dimensional array. 
   We may get to 2-dimensional arrays in time for the due date, 
   or you may need to read ahead if you want to use this approach. [5]
