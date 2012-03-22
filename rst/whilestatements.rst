.. index::
   double:  while; statement

.. _While-Statements:


While-Statements
============================ 

We have seen that the sequential flow of a program 
can be altered with function calls
and decisions.  The last important pattern is *repetition* or *loops*.
There are several varieties.  The simplest place to start is with
``while`` loops.

A C#
``while`` loop behaves quite similarly to common English usage. If
I say

    While your tea is too hot, add a chip of ice.

Presumably you would test your tea. If it were too hot, you would
add a little ice. If you test again and it is still too hot, you
would add ice again. *As long as* you tested and found it was true
that your tea was too hot, you would go back and add more ice.
C# has a similar syntax:

    | ``while (`` *condition* ``)`` 
    |   statement 

As with an ``if`` statement we will generally assume a compound statement, 
after the condition, so the syntax will actually be:

    | ``while (`` *condition* ``) {`` 
    |    statement(s)
    | ``}``

Setting up the English example in a similar format would be:

    | while  ( *your tea is too hot* ) { 
    |     add a chip of ice 
    | }

To make things concrete and numerical, suppose the following: The
tea starts at 115 degrees Fahrenheit. You want it at 112 degrees. A
chip of ice turns out to lower the temperature one degree each
time. You test the temperature each time, and also print out the
temperature before reducing the temperature. In C# you could
write and run the code below, saved in example program Cool.cs:

.. literalinclude:: ../examples/Cool.cs
   :start-after: chunk
   :end-before: chunk
   :linenos:

I added a final line after the ``while`` loop to remind you that
execution follows sequentially after a loop completes.

It is extremely important to totally understand how the flow of
execution works with loops.  One way to follow it
closely is to make a table with a line for each instruction
executed, keeping track of all the variables.  We call this
*playing computer*.

Each row shows the line number of the start of the next instruction
executed, and the values of all the variables *after* the instruction
is executed.  The important thing to see with loops is that the same
line can be executed over and over, but with different variable
values.  We leave a column for the line number, each variable
that is involved (particularly any that change) and a place for
comments about what is happening.  The comment line can be used any time
it is helpful.  If should be used in particular when something
is printed and when something is returned, since neither of these
important actions appear int he variable list.

If you play computer and follow the path of execution, you could
generate the following table. Remember, that each time you reach
the end of the block after the ``while`` heading,
execution returns to the ``while`` heading for another test:

====  ===========  =======
Line  temperature  Comment
====  ===========  =======
1     115
2                  115 > 112 is true, do loop
3                  prints 115
4     114          115 - 1 is 114, loop back
2                  114 > 112 is true, do loop
3                  prints 114
4     113          114 - 1 is 113, loop back
2                  113 > 112 is true, do loop
3                  prints 113
4     112          113 - 1 is 112, loop back
2                  112 > 112 is false, skip loop
6                  prints that the tea is cool
====  ===========  =======

Each time the end of the loop body block is reached, execution
returns to the ``while`` loop heading for another test. When the
test is finally false, execution jumps past the indented body of
the ``while`` loop to the next sequential statement.

.. index::
   double: while; rubric
   
The biggest trick with a loop is to make the same code do the next
thing you want each time through.  That generally involves 
the use of variables that are modified for each successive time through
the loop.  

    | initialization
    | ``while (`` *continuationCondition* ``) {`` 
    |     do main action to be repeated 
    |     prepare variables for the next time through the loop
    | ``}``
    
The simple first example follows this pattern directly.  Note
that the variables needed for the test of the condition must be
set up *both* in the initialization *and* inside the loop
(often at the very end).  Without a change inside the loop, the loop would
run forever!

It is a big deal for beginning students, how to manage all this in general.
We will see a number of common patterns in lots of practice.  We will use
the term *successive modification loop* for loops following this pattern.

Test yourself: Follow the code.  Figure out what is printed.
If it helps, get detailed and play computer:

.. literalinclude:: ../examples/TestWhile1.cs
   :start-after: chunk
   :end-before: chunk
   :linenos:

Check yourself by running the example program ``TestWhile1.cs``.

.. note::
   In C#, ``while`` is not used *quite* like in English. In
   English you could mean to stop *as soon as* the condition you want
   to test becomes false. In C# the test is *only* made when
   execution for the loop starts (or starts again), 
   *not* in the middle of the loop.

*Predict* what will happen with this slight variation on the
previous example, switching the order in the loop body. Follow it
carefully, one step at a time.

.. literalinclude:: ../examples/TestWhile2.cs
   :start-after: chunk
   :end-before: chunk
   :linenos:

Check yourself by running the example program ``TestWhile2.cs``.

The sequence order is important. The variable ``i`` is increased before
it is printed, so the first number printed is 6. Another common
error is to assume that 10 will *not* be printed, since 10 is
*past* 9, but the test that may stop the loop is *not* made in the
middle of the loop. Once the body of the loop is started, it
continues to the end, even when ``i`` becomes 10.
 
====  ==  ======= 
Line   i  Comment
====  ==  ======= 
1      4
2         4 < 9 is true, do loop
3      6  4+2=6
4         print 6
2         6 < 9 is true, do loop
3      8  6+2= 8
4         print 8
2         8 < 9 is true, do loop
3     10  8+2=10  *No test here*
4         print 10 
2         10 < 9 is false, skip loop
====  ==  ======= 

**Problem**:  Write a program with a ``while`` loop to print:

    | 10
    | 9
    | 8
    | 7
    | 6
    | 5
    | 4
    | 3
    | 2
    | 1
    | Blastoff!

**Analysis**:  
We have seen that we can produce a regular sequence of numbers in a loop.
The "Blastoff!" part does not fit the pattern, so it must be a *separate*
part after the loop.  We need a name for the number that decreases.  It can
be ``time``.  Remember the general rubric for a ``while`` loop:

    | initialization
    | ``while (`` *continuationCondition* ``) {`` 
    |     do main action to be repeated 
    |     prepare variables for the next time through the loop
    | ``}``

You can consider each part separately.  Where to start is partly a 
matter of taste.

The main thing to do is print the time over and over.
The initial value of the time is 10.  We are going to want to keep printing 
until the time is down to 1, so we *continue* while the time is at least 1,
meaning the continuationCondition can be ``time >= 1``, 
or we could use ``time > 0``.

Finally we need to get ready to print a different time in 
the next pass through the loop.
Since each successive time is one less than the previous one, the
preparation for the next value of time is:  ``time = time - 1``.

Putting that all together, and remembering the one thing we noted 
to do after the loop,
we get ``Blastoff.cs``:

.. literalinclude:: ../examples/Blastoff.cs

Look back and see how we fit the general rubric.  
There are a bunch of things to think about with a while loop, so
going one step at a time, thinking of the rubric and the specific
needs of the current problem, helps.

There are many different (and more exciting) patterns of change coming
for loops, 
but the simple examples so far get us started.

.. index::
   double: while; questions
   
Looking ahead to more complicated and interesting problems,
here is a more complete list of questions to ask yourself when
designing a function with a ``while`` loop:

-  What variables do I need?
-  What needs to be initialized and how? This certainly includes any
   variable tested in the condition.
-  What is the condition that will allow the loop to continue?
-  What is the code that should only be executed once? What action do I want to
   repeat? Where does the repetition come in the overall sequence of
   operations?
-  How do I write the action so I can modify it for the next time
   through the loop?
-  What code is needed to do modifications to make the same code work
   the next time through the loop?
-  Have I thought of variables needed in the middle and declared them;
   do other things need initialization?
-  Will the continuation condition eventually fail?
-  Separate thing to be done once before the repetition (code before the
   loop) from repetitive actions (in loop) from actions not repeated but
   done after the loop (code after the loop). Missing this distinction
   is a *common error*!

.. _SumToN:

.. rubric:: Sum To ``n``

Let us write a function to sum the numbers from 1 to ``n``::

    /** Return the sum of the numbers from 1 through n. */
    static int SumToN(int n) 
    {
       ...
    }

For instance SumToN(5) calculates 1 + 2 + 3 + 4 + 5 and returns 15.
We know how to generate a sequence of integers, but this is a place
that a programmer gets tripped up by the speed of the human mind.  
You are likely
so quick at this that you just see it all at once, with the answer.

.. index:: concrete example

In fact, you and the computer need to do this in steps.  To help see, let
us take a concrete example like the one above for SumToN(5), and write out a 
detailed sequence of steps like::

    3 = 1 + 2
    6 = 3 + 3 
    10 = 6 + 4
    15 = 10 + 5
    
You could put this in code directly for a specific sum, but if n is general,
we need a loop, and hence we must see a pattern in code that we can repeat.

Each of the second terms in the additions is a successive integer, 
that we can generate.  Starting in the second line, the first number
in each addition
is the sum from the previous line.  Of course the next integer and the next
partial sum change from step to step, so in order to use the same code over and
over we will need changeable variables, with names.  We can make the partial
sum be ``sum`` and we can call the next integer ``i``.  Each addition can be
in the form::

    sum + i

We need to remember that result, the new sum.  you might first think to introduce
such a name::

    newSum = sum + i;
    
This will work.  We can go through the ``while`` loop rubric:
    
The variables are ``sum``, ``newSum`` and ``i``.
    
To evaluate 

    newSum = sum + i;

the first time in the loop, we need *initial* values for sum and i.
Our concrete example leads the way::

   int sum = 1, i = 2;
   
We need a ``while`` loop heading with a continuation condition.  How
long do we want to add the next ``i``?  That is for all the value up to and
including n::

   while (i <= n) {

There is one more important piece - making sure the same code 

    newSum = sum + i;
    
works for the *next* time through the loop.  We have dealt before with
the idea of the next number in sequence::

   i = i + 1;
   
What about ``sum``?  What was the ``newSum`` on one line becomes the old or
just plain ``sum`` on the next line, so we can make an assignment::

   sum = newSum:
   
All together we calculate the sum with::

   int sum = 1, i = 2;
   while (i <= n) {
      int newSum = sum + i;
      i = i + 1;
      sum = newSum:
   }
   
This exactly follows our general rubric, with preparation for the next time
through the loop at the end of the loop.  
We can condense it in this case: Since ``newSum`` is only used
once, we can do away with it, and directly change the value of sum::

   int sum = 1, i = 2;
   while (i <= n) {
      sum = sum + i;
      i = i + 1;
   }

Finally this was supposed to fit in a function.  The ultimate purpose
was to *return* the sum, which is the final value of the
variable ``sum``, so the whole function is::

  /** Return the sum of the numbers from 1 through n. */
  static int SumToN(int n) 
  {
     int sum = 1, i = 2;
     while (i <= n) {
        sum = sum + i;
        i = i + 1;
     }
     return sum;
  }

.. index::
   double: testing; edge case
   double: testing; range testing
   double: edge case; range testing
   
The comment before the function definition does not give a clear idea of the 
range of possible values for n.  How small makes sense for the comment?
What actually works in the function?  The smallest expression 
starting with 1 would just be 1: (n = 1).  Does that work in the function?
You were probably not thinking of that when developing the function!
Now look back now at this *edge case*.  You can play computer on the code
or directly test it.  In this case the initialization of ``sum`` is 1,
and the body of the loop *never* runs (2 <= 1 is false).  The function
execution jumps right to the return statement, and
does return 1, and everything is fine.

Now about large n....

.. index::
   double: big oh; order of n
   
With loops we can make programs run for a long time.
The time taken becomes an issue.  In this case we go though the loop
n-1 times, so the total time is approximately proportional to n.
We write that the time is O(n), spoken "oh of n", or "big oh of n" or
"order of n".

.. index::
   double: pitfall; limit on number size
   
Computers are pretty fast, so you can try the testing program 
``SumToNTest.cs``
and it will go by so fast, that you will hardly notice.  Try these specific
numbers in tests: 5, 6, 1000, 10000, 98765.  All look OK?  Now try 66000.
On many systems you will get quite a surprise!  
This is the first place we have to deal with the limited 
size of the ``int`` type.
On many systems the limit is a bit over 2 billion.  
You can check out the size of ``int.MaxValue`` in csharp.
The answer for 66000,
and *also* 98765, is bigger than the upper limit.  
Luckily the obviously wrong negative answer
for 66000 pops out at you.  Did you guess before you saw the answer for
66000, that there was an issue for 
98765?  It is a good thing that no safety component in a big bridge was being 
calculated!  It is a big deal that the system fails *silently* 
in such situations.  *Think* how large the data may be that you deal with!

Now look at, compile, and run ``SumToNLong.cs``.  The sum is
a ``long`` integer here. Check out in csharp how big
a ``long`` can be (``long.MaxValue``).  This version of the program
works for 100000 and for 98765.  We can get correct
answers for things that will take perceptible time.  Try working up to 
1 billion (1000000000, nine 0's).  It takes a while: O(n) can be slow!

.. index::
   double: Gauss; sum through n
   
By hand it is a lot slower, unless you totally change the algorithm:
There is a classic story about how a calculation like this
was done in gradeschool (n=100) by the famous
mathematician Gauss. His teacher was trying to keep him busy.
Gauss discovered the general, exact, mathematical formula:  
    
    1 + 2 + 3 + ... + n = n(n+1)/2.  
    
That is the number of terms (n), times the average term (n+1)/2.

.. index::
   double: big oh; constant order
   
Our loop was instructive, but not the fastest approach.  The simple exact
formula takes about the same time for any n.  
(That is as long as the result fits in
a standard type of computer integer!)  
This is basically constant time.  In discussing
how the speed relates to the size of n, we say it is O(1). 
The point is here that 1 is a constant.  The time is of *constant order*.

.. index::
   double: pitfall; division
   
We can write a ridiculously short
function following Gauss's model.  Here I introduce the variable average,
as in the motivation for Gauss's answer:

.. literalinclude:: ../examples/SumToNLongBad.cs
   :start-after: chunk
   :end-before: chunk

Compile and test the example program containing it: ``SumToNLongBad.cs``.

Test it with 5, and then try 6. ???

"Ridiculously short" does not imply correct!  The problem goes back
to the fact that Gauss was in *math class* and you are doing 
Computer Science.  Think of a subtle difference that might come in here:
Though (n+1)/2 is fine as math, recall the division operator does not
always give correct answers in C#.  You get an integer answer from the
integer (or long) operands.  Of course the exact mathematical final answer
is an integer when *adding* integers, but splitting it according to
Gausss's motivation can put a mathematical non-integer in the middle.

The C# fix: The final answer is clearly an integer, so if we do the division
last, when we know the answer will be an integer, things should be better::

   return n*(n+1)/2;

.. index::
   double: pitfall; cast
   
Here is a shot at the whole function:

.. literalinclude:: ../examples/SumToNLongBad2.cs
   :start-after: chunk
   :end-before: chunk

Compile and test the example program containing it: ``SumToNLongBad2.cs``.

Test it with 5, and then try 6. Ok so far, but go on to long integer range:
try 66000 that messed us up before.  ??? You get an answer that is not
a multiple of 1000: not what we got before!  What other issues do we have
between math and C#?

Further analysis:  To make sure the function always worked, it made sense
to leave the parameter ``n`` an ``int``.  The function would not work
with ``n`` as the largest ``long``.  The result can still be big enough
to only fit in a ``long``, so the return value is a ``long``.  All
this is reasonable but the C# result is still wrong!  Look deeper.
While the result of ``n*(n+1)/2`` is *assigned* to a ``long`` variable,
the *calculation* ``n*(n+1)/2`` is done with ``int``\ s not mathematical
integers.  By the same general type rule that led to the (n+1)/2 error 
earlier, these operations on ``int``\ s produce an ``int`` result, even
when wrong.

We need to force the *calculation* to produce a ``long``. 
In the correct looping version ``sum`` was a ``long``, and that
forced all the later arithmentic to be with longs.  Here are two variations
that work::
    
    long nLong = n;
    return nLong*(nLong+1)/2;
    
or we can avoid a new variable name by doing a cast to ``long``, convering
the first (left) operand to ``long``, so all the later left-to-right
operations are forced to be ``long``::

    return (long)n*(n+1)/2;
    
You can try example ``SumToNLongQuick.cs`` to finally get a result that
is dependably fast and correct.

Important lessons from this humble summation problem:

- *Working* and being *efficient* are two different things in general.  

- *Math* operations and C# operations are not always the same. 
  Knowing this in theory is not the same as remembering it in practice.


