
.. index::
   triple: homework; input-output; decisions

.. _homework-grade-calculation:

Homework: Grade Calculation
===========================

You are going to be 
putting together your first programming assignment where
you will be taking the various concepts we have learned
thus far in lecture and lab and to put together your first
meaningful program on your own.

This program will incorporate the following elements:

- Prompt a user for input.
- Perform some rudimentary calculations.
- Make some decisions.
- Produce output.

As we've mentioned in the early lectures, our focus is going
to be on learning how to write computer programs that start
with a Main() function and perhaps use other functions as
needed to *get a particular job done*. Eventually, we will
be incorporating more and more advanced elements, such as
classes and objects. For now, we would like you to organize
your program according to the guidelines set forth here.

Program Summary
---------------

We're going to begin with an *executive summary* of what the
first homework assignment will actually accomplish. We want
to train your brain early about the importance of not only
understanding what you are doing but also the great 
importance of being able to explain your ideas to others. 

Our first program is based on a common task that every
course professor/instructor needs to do: make grades. In 
any given course, there is a *grading scale* and a set of
*categories*.

Details
-------

This is based on the idea of Dr. Thiruvathukal's own 
legendary course syllabus.
We're going to start
by assuming that there is a fixed set of categories.
As an example we assume Dr. Thiruvathukal's categories.

In the example below we work out for
Dr. Thiruvathukal's weights in each category,
though your program should prompt
the user for these integer percentages:

- exams - 40% (integer weight is 40)
- labs - 15% (weight 15)
- homework - 15% (weight 15)
- project - 20% (weight 20)
- participation - 10% (weight 10)

Your program will prompt the user for each the weights
for each of the categories. These weights will be entered
as integers, which must add up to 100. 

If the weights do not add up to 100, print a message and 
end the program. You can use an ``if-else`` construction
here.  An alternative is an ``if`` statement to test for a bad sum.
In the block of statements that go with the ``if`` statement,
you can put not only the message to the user, but also a 
statement::

    return;

Recall that a function ends when a return statement is reached.
You may not have heard that this can also be used
with a ``void`` function.  In a ``void`` function 
there is no return value in the ``return`` statement.

Assuming the weights add to 100, then we will use
these weights as *floating point* numbers to compute your
grade. We will be using ``double``, which gives you the
best precision when it comes to floating-point arithmetic.

We'll talk in class about why we want the weights to be
integers. Because floating-point mathematics is not 100%
precise, it is important that we have an accurate way
to know that the weights *really add up* to 100. The only
way to be assured of this is to use *integers*. We will
actually use floating-point calculations to compute the
grade, because we have a certain tolerance for errors at
this stage. (This is a fairly advanced topic that is 
covered extensively in courses like COMP 264/Systems 
Programming and even more advanced courses like Numerical
Analysis, Comp 308.)


We are going to pretend
that we already know our score (as a percentage) for each
one of these categories, so it will be fairly simple to
compute the grade. 

For each category, you will define a weight (int) and a
score (double). Then you will sum up the weight * score and
divide by 100.0 (to get a double-precision floating-point
result).

This is best illustrated by example.

George is a student in COMP 170. He has the following
averages for each category to date:

- exams: 50%
- labs: 100%
- homework: 100%
- project: 100%
- participation: 5%

The following session with the ``csharp`` interpreter shows
the how you would declare all of the needed variables and
the calculation to be performed::

    csharp> int exam_weight = 40;
    csharp> int lab_weight = 15;
    csharp> int hw_weight = 15;
    csharp> int project_weight = 20;
    csharp> int participation_weight = 10;

    csharp> double exam_grade = 50.0;
    csharp> double lab_grade = 100;
    csharp> double homework_grade = 100;
    csharp> double project_grade = 100;
    csharp> double participation_grade = 5;  

    csharp> ShowVars();
    int exam_weight = 40
    double lab_weight = 15
    int hw_weight = 15
    int project_weight = 20
    int participation_weight = 10
    double exam_grade = 50
    double homework_grade = 100
    double lab_grade = 100
    double project_grade = 100
    double participation_grade = 5

This is intended only to be as an example though. Your 
program must ask the user to enter each of these variables.

Here is an example of how to prompt for an exam weight and
grade::

    csharp> Console.WriteLine("Enter the weight for exams: ");
    Enter the weight for exams: 
    csharp> string input = Console.ReadLine();
    csharp> int exam_weight = int.Parse(input);
    csharp> Console.WriteLine("You entered {0} for exams.", exam_weight);
    You entered 40 for exams.

The code is similar for entering the exam grade. Where you
see the ``int`` type, you'll want to use ``double``. We are
going to leave this part to your imagination.

Once we have all of the weights and scores entered, we
can calculate the grade as follows.  This is a long
expression: It is continued on multiple lines.  Recall all
the ``>`` sybols are csharp prompts, not part of the
expression::

    csharp> double grade = (exam_weight * exam_grade +  
          > homework_weight* homework_grade + 
          > lab_weight * lab_grade + project_weight * project_grade + 
          > participation_weight * participation_grade) / 100.0; 


Then you can display the grade as a percentage::

    csharp> Console.WriteLine("Your grade is {0}%", grade);
    Your grade is 70.5%

Now for the fun part. We will use ``if`` statements to 
print the letter grade. You will actually need to use
multiple ``if`` statements to test the conditions. A way
of thinking of how you would write the logic for determining
your grade is similar to how you tend to think of the *best*
grade you can *hope for* in any given class. (We know that
we used to do this as students.)

Here is the thought process:

- If my grade is 93 (93.0) or higher, I'm getting an A.
- If my grade is 90 or higher (but less than 93), I
  am getting an A-.
- If my grade is 87 or higher (but less than 90), I 
  am getting a B+.
- And so on...
- Finally, if I am less than 60, I am unlikely to pass.

We'll come to see how *logic* plays a major role in 
computer science--sometimes even more of a role than
other mathematical aspects. In this particular program, 
however, we see a bit of the best of both worlds. We're
doing *arithmetic* calculations to *compute* the grade.
But we are using *logic* to determine the grade in the
cold reality that we all know and love: the bottom-line
grade.

This assignment is listed in the data chapter, 
because you can do most all of it with tools
learned so far.  Add the parts with ``if`` statements
when you have been introduced to ``if`` statements.
(Initially be sure to use data that makes the 
weights actually add up to 100.)

You should be able to write the program more concisely
and readably if you use functions developed
in class for the prompting and user input.

Usage
-----

Here is sample output from two runs of the program. 
The only data entered by the user are
show in **boldface** for illustration here.

One successful run with the data used above:

    | Enter weights for each part as an integer 
    | percentage of the final grade:
    | Exams: **40**
    | Labs: **15**
    | Homework: **15**
    | Project: **20**
    | Participation: **10**
    |
    | Enter decimal numbers for the averages in each part:
    | Exams: **50**
    | Labs: **100**
    | Homework: **100**
    | Project: **100**
    | Participation: **5**
    |
    | Your grade is 70.5%
    | Your letter grade is C-.

A run with bad weights:

    | Enter weights for each part as an integer 
    | percentage of the final grade:
    | Exams: **30**
    | Labs: **10**
    | Homework: **10**
    | Project: **10**
    | Participation: **10**
    |
    | Your weights add to 70, not 100.
    | This grading program is ending. 

