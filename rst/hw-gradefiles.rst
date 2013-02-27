.. index:: 
   double: homework; grade files

.. _hw-gradefiles:

Homework: Grade File 
===================== 

Copy project files in :repsrc:`grade_file_homework_stub` to
your own project.  Then you should have copies of the 
source file :repsrc:`grade_files.cs <grade_file_homework_stub/grade_files.cs>` 
for you to *complete* for this homework.  
The folder also contains sample data files
including the examples discussed below.
   
In this assignment, we're going to begin taking steps to help you
achieve greater *independence* when it comes to programming. This
means (among other things) that you will be given what is commonly
known as a specification. In software development--and in the business
world in general, it is customary to capture a set of 
*business requirements* in what is commonly known as a 
*requirements specification* document. While what you read here will be much more
concise, we want you to become familiar with requirements-driven
thinking, without which many real-world software projects fail.

After presenting the set of requirements, we will give you some hints
for how to *implement* the requirements. These hints may or may not
prove completely helpful to you, and you are also invited to come up
with your own solutions. As we inch closer to the semester project,
you're going to want to use your imagination to create a good solution
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
*summary report* file with a line for each student.

Although we could do all of what we're describing here with a
*spreadsheet*, the point is to show how we can use C# to read in a
simplified form of comma-separated data, process it, and do some
general-purpose calculations on the data.

Using C#
--------

We'll be making use of a number of C# features (some old, some new) in
this homework:

- decisions, loops, strings, and functions 
- files
- arrays


Requirements
------------


#. Unlike in previous assignments, this program must accept data from
   a collection of input files (that is, it will not be reading most of the 
   data from the class ``Console``).  

#. The program needs a course abbreviation from the user.  If there
   is a command line argument, use it as the course abbreviation.  
   Make sure your code can 
   read a command-line argument using the special form of
   ``Main(string[] args)`` already in the stub 
   :repsrc:`grade_files.cs <grade_file_homework_stub/grade_files.cs>`.  
   If the user does not provide at command line argument,
   prompt the user for it once the program starts.
   The abbreviation should not include spaces.
   An example would be comp170.  All data files will include the course
   abbreviation as part of their name.  We will use comp170 in the examples below,
   but it could be something else.  The folder also contains sample data files
   for a course abbreviation comp150.
   
   Note that these data files are not in the MonoDevelop execution directory, but
   in the project directory, so the :ref:`fio` is useful to provide
   flexibility in reading the data files.

#. There are two master files for any course. 
   One is "categories\_" + the course abbreviation
   + ".txt".  For example, ``categories_comp170.txt`` is a sample data file
   provided and used below.
   
   It will contain three lines.
   The first line is a comma separated list of category names like

   .. literalinclude:: ../source/examples/grade_file_homework_stub/categories_comp170.txt
      :language: text
      :lines: 1
       
   There may be extra spaces after the commas.  
   Categories will be chosen so that *each one starts with a different letter*.
   
   The second line contains the integer weights for each category, like
   
   .. literalinclude:: ../source/examples/grade_file_homework_stub/categories_comp170.txt
      :language: text
      :lines: 2
       
   They do *not* need to add to 100.  If the sum is called totWeights,
   get the final grade by summing for each category::
   
      (category weight)(category grade)/totWeights
   
   The third line will contain the number of grades in each category, like
   
   .. literalinclude:: ../source/examples/grade_file_homework_stub/categories_comp170.txt
      :language: text
      :lines: 3
       
   The second master file will be "students\_" + the course abbreviation + ".txt".
   For example :file:`students_comp170.txt`.
   It will contain a list of student information
   records. Each record (one per input line) will have the following
   structure:

      Student ID, Last Name, First Name

   For example, the sample data file :file:`students_comp170.txt` starts:
   
   .. literalinclude:: ../source/examples/grade_file_homework_stub/students_comp170.txt
      :language: text
      :lines: 1-2

 
#. There will be a secondary file for each student, 
   named after the student id and the course abbreviation and ".data". 
   For example,
   John's scores would be kept in a file named
   ``P12345678comp170.data``. Maria's scores would be in
   ``P00000001comp170.data``. Each record (one per file line will have the
   following structure:

      Category letter, Item, Points Earned

   where:

   - category letter is the first letter of the category.  With the categories
     given in the example above, they would be E, L, H, P, and C.
   - item is a number within that category (1, 2, 3, ...) - 
     only used in part of the extra credit.
   - points earned is a real number
   - the lines are in no special order.
   
   Sample data file ``P12345678comp170.data`` starts:
   
   .. literalinclude:: ../source/examples/grade_file_homework_stub/P12345678comp170.data
      :language: text
      :lines: 1-6

#. The program will process the data from each student file and
   calculate the average within each category, and then the weighted overall average. 
   Also display the letter grade for
   each student, using code derived from the previous
   assignment. 

#. Your program writes the final report file.  
   It is named with the course abbreviation 
   + "_summary.txt".  Example: "comp170_summary.txt".
   This file must have a line for each student showing the 
   student's last name, first name,
   weighted average rounded to one decimal place, and letter grade.  
   File ``comp170_summary.txt`` would start with lines:

   .. code-block:: none
   
        Doe, John 78.9 C+
        Hernandez, Maria 88.2 B+
    
   Write this file to the same directory where you found the input data.  Again
   the :ref:`fio` is useful.
   
#. The rest of the test data for 
   course abbreviations comp170 and all the data for comp150 in the homework directory.   
   There are also sample solution files for the 
   summaries (including some extra credit additions at the ends of lines).  
   Their names end in ``_solution.txt`` to distinguish them from the
   summary files *you* should generate in tests.
   
   While your program should certainly work for course abbreviations comp170 and comp150,
   it should also work in general for any data files your refer to
   in the defined formats and place in the same folder.
      
Hints
-----

#. Read  
   :ref:`files`.
   You're still going to need ReadLine() and
   WriteLine() in this assignment, the only difference is that we'll
   get the input from a file instead
   of the Console. The parameter syntax will be the same. 

#. For each file line you'll want to use the :ref:`Split`, 
   and then the ``Trim``
   method from :ref:`more-string-methods` on each part to
   remove surrounding spaces. Then 
   use indexing to get the field of interest. (More below.)

#. You'll need an *outer loop* to read the records from the master name
   file. You'll need an *inner loop* (or a loop inside of a function)
   to read the records for each student.

#. When processing the records from a student file, you should process
   each one separately and not assumed they are grouped in any
   particular order. 

   This means, specifically, that your program simply reads a record,
   decides what category it is in, and updates the *running total* for
   that category. Once the entire file has been read, you can compute
   the average for each category based on the *number of items* that
   *should* be in that category, which may be more than the number
   of records in the file for items turned in.

#. There is no need to *keep* a score
   after you've read it and immediately used it.
   *Do* use an array, however, for the running total
   for each category. 

#. In order to deal with a varying number of categories and different 
   possible first letter codes, you will need to split the category
   name line into an array, say  ::
       
       string[] categories;
       
   To know where to update data for each category, you can use this
   function after you read in a code, to determine the proper index.
   It is already in the stub of the solution file 
   :repsrc:`grade_files.cs <grade_file_homework_stub/grade_files.cs>`:

   .. literalinclude:: ../source/examples/grade_file_homework_stub/grade_files.cs
      :start-after: chunk
      :end-before: chunk

   You may assume the data is good and the -1 is never returned, 
   but the compiler requires this last line.
   
#. You cannot have one fixed formula to calculate the final weighted grade,
   because you do not know the number of categories when writing the code. 
   You will have to accumulate parts in a loop.
   
#. Test thoroughly!  Be sure to test with and without command line parameter and
   with multiple data sets.

Grading Rubric (25 points)
---------------------------

#. Get the abbreviation from the command line if it is there. **[2]**
#. Otherwise get the abbreviation from prompting the user. **[1]**
#. Read the categories file and parse lines. **[2]**
#. Deal with each student. **[3]**
#. Calculate the cumulative grades in each category, reading
   a student's file once, using arrays. **[5]**
#. Calculate the overall grade and letter grade. **[3]**
#. Generate summary entries. **[3]**
#. Use functions where there would otherwise be two several-line blocks of code
   differing only in the name of the data evaluated and the name of the
   result generated. **[2]**
#. Use good style:  formatting, naming conventions, 
   meaningful names other than for simple array indices, lack of redundant code. **[4]**
   
**Optional Extra Credit Opportunities!**  You may choose to do 
any combination that does not include both of the last two options about missing work.

#. Format the summary file in nice columns.  Include the grades for each category,
   rounded to one decimal place.  Include a heading line.    
   For example the summary for the repository example Comp150 could start:
   
   ..  code-block:: none
   
       Name: Last, First           Avg Gr     E     H     P
       Hopper, Grace             100.0 A  100.0 100.0 100.0

   You may assume the last-first name field fits in 25 columns.
   Copy the first three column headings from above.
   The column headings for the categories can just be their one letter code.
   Names and letter grades should be left-justified (padded on the right, by 
   using a *negative* field width).  
   See :ref:`Left Justification <left-justification>`. **[2]**
#. Change the scheme for calculating letter grades to use a function that calculates
   the proper grade, where the only ``if`` statement is one simple one
   inside a *loop*.  The ``if`` statement will have a ``return`` statement in its body, 
   and no ``else``.  The loop will need to use
   corresponding arrays of data for grade cutoffs and grade names. **[3]**
#. For any student who has missed passing in all the required items, 
   generate extra data on missing work in the summary, at the right end of the
   line for the student.  Add this to 
   whichever version of the earlier parts you use.
   Include an addendum starting with "Missing: "
   only if there are not enough grades in one or more
   categories.  For each category where
   one or more grades is missing, including a count of the number of grades missing followed
   by the category letter.  An example using the example categories is:

   .. code-block:: none
   
      Doe, John 68.5 D+ Missing: 2 L 1 H
      Smith, Chris 83.2 B Missing: 1 L
      Star, Anna 91.2 A-
      
   meaning Doe has 2 labs missing and 1 homework missing.  Smith is missing one lab.  Star
   has done all assigned work, since nothing is added. The solution files display this
   extra credit addition on the ends of lines.  **[3]**
#. This is a much harder alternate version for handling missing work:  
   Unlike the previous format, do not count and print the number of missing 
   entries in each category in a form like "2 L ".
   Replace such an entry with a list of *each* item
   missing, in order, as in "L:1, 4 ", meaning labs 1 and 4 were missing.  
   Assume that the expected item numbers for a category 
   run from 1 through the number of grades in the category.
   You may assume no item number for the same category appears twice.
   For example, with the sample data files given in the repository for
   comp170, the summary line for John Doe would be:

   ..  code-block:: none
          
       Doe, John 78.9 C+ Missing: L: 1, 4 H: 3
       
   The most straightforward way to do this requires something 
   like an array of arrays, array of lists or array of sets. 
   You may need to read ahead if you want to use one of these approaches. **[5]**
