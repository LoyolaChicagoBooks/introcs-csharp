.. index:: function; consumer and writer
   consumer of functions
   writer of functions

.. _Two-Roles:

Two Roles: Writer and Consumer of Functions
=============================================

The remainder of this section covers finer
points about functions that you might skip on a first reading.

We are only doing tiny examples so far to get the basic idea of
functions. In much larger programs, functions are useful to manage
complexity, splitting things up into logically related, modest
sized pieces. Programmers are both writers of functions and
consumers of the other functions called inside their functions. It
is useful to keep those two roles separate:

The user of an already written function needs to know:

#. the name of the function

#. the order and meaning of parameters

#. what is returned or produced by the function

*How* this is accomplished is not relevant at this point. For
instance, you use the work of the C# development team, calling
functions that are built into the language. You need know the three
facts about the functions you call. You do not need to know exactly
*how* the function accomplishes its purpose.

On the other hand when you *write* a function you need to figure
out exactly how to accomplish your goal, name relevant variables,
and write your code, which brings us to the next section.

The jargon for these parts are the *interface* (for the consumer)
and the *implementation* (for the programmer, who must be sure
to satisfy the public interface).