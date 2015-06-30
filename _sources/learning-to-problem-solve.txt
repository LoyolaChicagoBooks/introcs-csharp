.. index::
   single: problem solving; strategy

.. _learn-solve:

Learning to Solve Problems
==================================

This section might have been placed earlier, 
but from reading all the way to here, 
you should realize that you will have a *lot* of data and concepts to deal with.

The manner in which you deal with all the data and ideas is very important 
for effective learning.
It might be rather different than what you needed if you were in a situation 
where *rote* recall is the main important thing.

Different learning styles mean different things are useful to different people.
Consider what is mentioned here and try out some approaches.

The idea of this course is *not* to regurgitate the book, but to learn to solve problems
(generally involving producing a computer program).  
In this highly connected and wired world
you have access to all sorts of data.  The data is not an end in itself, the question is
*doing* the right things with the tools out there to solve a new creative problem.

In this course there is a lot of data tied into syntax and library function names and ....  
It can seem overwhelming.  It need not be. Take a breath.  

First basic language syntax:  When learning any new language, there is a lot to take in.  
We introduce C# in chunks.  For a while there will always be the new current topic coming.  
You do NOT need to memorize *everything* immediately!  

- Some things that you use rarely, you may never memorize, like,
  "What is the exact maximum magnitude of a ``double``?"  
  At *some* point that might be useful.
  Can you find it?  It happens to be in :ref:`numeric-type-limits`.  
  It is also in online .Net documentation
  that you can Google or bookmark.
  
- Some things you will use all the time, but of course they start off as new and maybe strange.
  Knowing where to go to check is still useful but not sufficient. For much-used material
  that you do not find yourself absorbing immediately, 
  consider writing down a summary of the current topic.  
  Both thinking of a summary and writing help reinforce things and get you to remember faster.  
  Also, if you have the current things of interest summarized in one place, they are easy to look
  up! 
- If you need some syntax to solve a simple early problem, 
  first try to remember the syntax, then check.  With frequently
  used material and with this sort of repetition, 
  most everyone will remember most everything shortly.  If there are a few things
  that just do not stick, keep them in your list.  Then go on to new material.  The list of
  what you need to check on will keep changing as you get more experience and get to more topics.
  If you keep some of the old lists, you will be amazed how much stuff that you sweated over,
  is later ho-hum or automatic.
  
- In the earliest exercises
  the general steps that you need should be pretty apparent, 
  and you can just concentrate on
  translating simple ideas into C# syntax
  (mostly from the material most recently introduced).
  In this case the focus is mostly on syntax.

Memorizing syntax is not going to directly get you to solve real problems.  In any domain:
programming, construction, organizing political action, ..., you need to analyze the problem
and figure out a sequence of steps, knowing what *powers and resources you have*.  
  
For example with political action:
if you know demonstrations are possible in front of City Hall, you can make a high-level
plan to have one, but then you have to attend to details:  Do you need city permission?  
Who do you call? ... You do not have to have all that in your head when coming up with the
idea of the demonstration, but you better know how to find the information allowing you
to follow through to make it happen.

With programming, syntax details are like the details above: not the first thing to think of,
and maybe not things that you have memorized.  What *is* important to break down a problem
and plan a solution, is to know the basic *capacities* you have in programming.  As you get 
into larger projects and have more experience, "basic capacities" will be bigger and bigger ideas.  
For now, as beginners, based on the sections of the book so far, 
it is important to know:

- You can get information from a user and return information via keyboard and screen.
- You can remember and recall and use information using variables.
- You can deal directly with various kinds of data: numbers and strings at this point.
- There are basic operations you can do with the data (arithmetic, concatenating string,
  converting between data types).
- At a slightly higher level, you might already have the idea of basic recurring patterns,
  like solving a straightforward problem with **input-processing-output**.
- You will see shortly that you have more tools:  decision, repetition, more built-in
  ways to deal with data (like more string operations shortly), creating your own data types....

At slightly more detailed level, *after* thinking of overall plans:

- There are multiple kinds of number types.  What is appropriate for your use?
- There are various ways of formatting and presenting data to output. What shall you use?

*Finally*, you actually need to translate specific instructions into C# (or whatever language).  
Of course if you remember the syntax, then this level of step is pretty automatic.  
Even if you do *not* remember, you have something very specific to look up!  If you are 
keeping track of your sources of detailed information, this is hopefully only one further
step.

Contrast this last-step translation with the earlier creative organizational process:
If you do not have *in your head* an idea of the basic tools available, 
how are you going to plan?
How are you going to even know how to start looking something up?

So far basic ideas for planning a solution has been discussed, and you can see that you do not
need to think of everything at once or have everything equally prominent in your brain.

Also, when you are coding, you do not need to to have all the details of syntax in your head,
even for the *one* instruction that you are dealing with at the moment.  You want to have
the main idea, and you want to get it written down, but once it is written down, you can make
multiple passes, examining and modifying what you have.  For example, Dr. Harrington does a lot of
Python programming, where semicolons are not needed.  He can get the main ideas down 
in C# without the required
semicolons.  He *could* wait for the compiler to stop him on every one that is missed, 
and maybe have the compiler misinterpret further parts, and give bogus error messages.  
*More effective* is having
a list of things to concentrate on in later rounds of manual checking.  
For example, checking for semicolons: Scan the statements; 
look at the ends; add semicolons where missing.  You can go through a large program very 
quickly and efficiently doing this and have one less thing to obsess about when first writing.

This list of things-to-check-separately should come from experience.  
Keep track of the errors you make.  Some people even keep an error log.
What errors keep occurring?
Make entries in things-to-check-separately,
so you will make scans checking for the specific things that you frequently slip up on.

This things-to-check-separately list, too, will evolve.  Revise it occasionally.  
If Dr. Harrington does enough
concentrated C#, *maybe* he will find that entering semicolons becomes automatic, 
and he can take the separate round of semicolon checking off his list....

What to do *after* you finish an exercise is important, too.  The natural thing psychologically,
particularly if you had a struggle, is to think, "Whew, outta here!!!!"

On something that came automatically or flowed smoothly, that is not a big deal - 
you will probably get it just as fast the next time. If you had a hard time and only eventually
got to success, you may be doing yourself a disservice with "Whew, outta here!!!"

We have already mentioned how not everything is equally important, and some things are more
important to keep in your head than others.  The same idea applies to all the steps in solving
a possibly long problem.  Some parts were easy; some were hard; there may have been many steps.
If all of that goes into your brain in one continuous stream of stuff that you 
remember at the same level, then you are going to leave important nuggets mixed in
with an awful lot of unimportant 
and basically useless information, and have it all fade into oblivion, or be next to 
impossible to cycle through looking for the nuggets.  
Why do the problem anyway if you are just going to bury important information further
down in your brain?

What is important?  The most obvious thing you will need at a higher level of recall is what
*just messed you up*, what you missed until doing this problem:  After finishing the
actual problem, *actively* follow up and ask yourself:

- What did I get in the end that I was missing initially? What was the connection I made?
- Does this example fit in to some larger idea/abstraction/generalization in a way that
  I did not see before?
- How am I going to look at this so I can make a similar connection
  in a similar (or maybe only partly similar) problem?
- Is there a kernel here that I can think of as a new tool in my bag of tricks?
  
Your answers to these questions are the most important things to take away from your
recent hard work.  
The extra consideration puts them more in
the "priority" part of your brain, so you can really learn from your effort.  When you need 
the important ideas 
next, you do not need to play through all the details of 
the stuff you did to solve the exact earlier problem.

Keep coming back to this section and check up on your process:  It is really important.
