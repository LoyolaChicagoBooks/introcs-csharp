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
   
   For **extra credit** include an addendum starting with "Missing: ",
   only if there are not enough grades in all
   categories.  For each category where
   one or more grades is missing, including a count of the number of grades missing followed
   by the category letter.  An example is using the example categories is::

      Doe, John 68.5 D+ Missing: 2 L 1 H
      Smith, Chris 83.2 B Missing: 1 L
      Star, Anna 91.2 A-
      
   meaning Doe has 2 labs missing and 1 homework missing.  Smith is missing one lab.  Star
   has done all assigned work.

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
   See :ref:`mondevelop-run-with`.
   
Hints
-----

#. You'll be able to learn how to use files by reading 
   :ref:`files` and the Miles section 6.3 on Files. Be sure to read
   :ref:`mondevelop-run-with`.
   We'll also have a lab exercise for learning to
   work with file I/O. You're still going to need ReadLine() and
   WriteLine() in this assignment, the only difference is that we'll
   be making use of File classes to get the input from a file instead
   of the Console. The parameter syntax will be the same.

#. You'll want to use the string Split method, and Trim to
   remove surrounding spaces. Then 
   use indexing to get the field of interest, 

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
   We will need to use an array, however, 
   for the running total
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
       
   You may assume the data is good and the -1 is never returned.
   
#. You cannot have one fixed formula to calculate the final weighted grade,
   because you do not know the number of categories when writing the code. 
   You will have to accumulate parts in a loop.
   
Grading Rubric
---------------

Coming....