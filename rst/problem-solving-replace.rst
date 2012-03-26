.. index::
   double: string; problem solving

.. _solve-string-replace:

A Creative Problem Solution
==================================

Thus far the exercises and examples suggested have been of
a very simple form, where the idea of the steps should
have been pretty clear, and the main issue was just 
translating syntax into C#, one instruction at a time.

We still have a lot of syntax to concentrate on,
but still, early on, we wanted to get in some real thought
of problem solving.  To get very interesting you
need a number of options that might be combined in
a variety of ways.  The short list of
string methods just introduced 
is likely give us enough to think about....

Here is a basic string manipulation problem:
given a string, like,
``"It was the best of times."``,
find and replace a specified part of it by another string.
For instance replace ``"best"`` by ``"worst"``.
In this example we would get the result:
``"It was the worst of times."``.

It is very important to give concrete examples to
illustrate the idea desired.  Our human brains may be
very quick to see a solution like this in a very
concrete case, but what about making it general?

First this seems like a basic logical operation worthy 
of a function or method, so we need a heading.
(Confession:  there are methods in the class
string for replacement, but this is a good learning exercise,
so we are starting over on our own.)  Since
we cannot change the string class, we will write a
static function to generate the new string.  

For simplicity at the moment we will only change
the first occurence, and for now we will assume the
replacement makes sense.  The following heading 
(with documentation) should work:

.. literalinclude:: ../examples/StringManipStub.cs
   :start-after: }
   :end-before: {


As soon as we have the calling interface, it is good to be thinking
of the tests it should pass.  Here is a Main program written 
to test the function in different ways and display the results:

.. literalinclude:: ../examples/StringManipStub.cs
   :start-after: {
   :end-before: /**


Writing tests *first* is a good idea to focus you on what really 
needs to be accomplished, and then running tests later is a snap!

The human brain and eys are fabulous in the way they process
many things in parallel and use tools you have accumulated over
a lifetime.  In particular this substitution idea should 
seem pretty reasonable, and given any *specific concrete* example,
you are likely to be able to solve it instantly, with very little
conscious effort.  Once it becomes a programming problem, with
parameters stated in general, with just placeholder names
like ``s`` and ``target``, and given the limited set of approaches
you have in a programming language, the complexion of this
problem changes completely.  Many students guess the general problem will
be nearly as simple as the concrete exmples they do in their heads,
and then get very discouraged when the answer does not flow out of 
them.  In fact it takes practice and experience, and it is easier
to handle if you acknowledge that up front!

So let's start in with the practice, and gain some experience.  
With ``s``, ``target``, and ``replacement`` all being general, this
problem could easily be too much to contemplate at once, 
so let us replace concrete examples by generality gradually.  
The idea is to get to the end.  Rather than trying to jump a chasm, 
we can take small steps and go around.

A basic idea is to make small incremental
changes, test at each stage, and gradually see more of the tests
(that you have already written) be satisfied.  Also, if you make a 
mistake and screw up something that worked before, you can generally
focus on the small addition to see where the mistakes were. 
[#extreme]_

This also avoids you needing to keep too much in your head at once.

We do have code written already:  The test code.  Start by writing
something that will trivially satisfy the first concrete test.
The body of the function can be just::

    return "It was the worst of times";

This is a tiny, easy, silly looking step, but it does accomplish
two things:  It makes sure we can produce output
in the proper string form, and the test code runs, passing the
first test.  

Now we gradually get more complicated.  We will continue to assume
``target`` and ``replacement`` are as in the original example,
and ``target`` is in the same place in ``s``, 
but suppose we imagine each
of the other characters in ``s`` may be something different::

    "???????????best??????????"
    
Now we have to start thinking about what we have to work with.  
We have a string, and we have string methods.
Have a look at the ideas of each method (exact syntax
not important at the moment).  Clearly we are going to have to
deal with parts of strings, and the methods to deal with parts
involve indices, so let us add to our visual model::

    Index: 0123456789012345678901234
        s: ???????????best??????????

Continue in class....  The example program stub is 
:file:`StringManipStub.cs`.  In general, when given a
program with "Stub" in it, save it under a name without the "Stub",
and develop that version further.  In stubs where you need to
complete a function with a return value, you will often see
a dummy choice for the return statement, just so the stub compiles.
Where the return type is string ``"Not implemented"`` is a handy
temporary choice.

..	forclass
	
	What next?  If I do not know what is under the question marks, but I
	want to be able to use those parts, I must find a way to *refer* to them.
	How can we refer to a part of a string?  
	
	There are substring methods wiuth strings!  That is the first
	big idea.  The exact syntax comes second, but now look:
	There are two versions of the substring method given.  One
	generates a substring going all the way to the end of a string.
	that is appropriate for the part after ``best``.  Now get
	very specific....
	
	Figure indices, oo notation using "s.", put pieces together...

When you have that function version, test it.  
You will need to rename 
our incremental variations so the current version has the name
used in Main.

What might further advances toward full generality be,
in small steps?  We pinned ``best`` at a specific location.
We could remove that assumption.  The location will still be
important, but we do not know it ahead of time....

.. forclass

   size of jump here could be changed.  As i have it, the only
   real point is that the length of target need not be 4.  
   It appeared useful, though:  some students did have a hard
   time generalizing to the location of the part past the target.
   There seems to be no need to have a separate step making
   replacement general.  It is clearly adding in the middle
   of the concatenation, what ever it is.

A further advance would be a version that is complete
in all ways, except we still assume ``target`` is in ``s``,
but beyond that, do not assume what the three parameters are.

Finally we should allow ``s`` to not contain ``target``.

.. forclass

   Not sure how far along we are with if statements at this point,
   though it is important for the part of lab last-first.
   
The testing regime in Main is clear to understand and write,
but pretty primitive.  You have to look at a lot of output
every time you test.  We will come up with better testing schemes
later.

..  [#extreme]  
	We will not go far into the history of software engineering 
	practice here, but these incremental problem solving methods 
	were first widely 
	introduced as a part of *extreme programming*.
	That name gives you an idea of the newness at the time.
