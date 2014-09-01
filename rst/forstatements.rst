.. index:: statement; for

For-Statement Syntax
============================ 

We now introduce the last kind of loop syntax: ``for`` loops.

A ``for`` loop is an example of *syntactic sugar*:  syntax that can simplify
things for the programmer, but can be immediately translated into an
equivalent syntax by the compiler.  For example::

    for (i = 2; i <= n; i++) {
       sum = sum + i;
    }
   
is exactly equivalent to this code similar to part of 
:ref:`SumToN <SumToN>`::

    i= 2;
    while (i <= n) {
       sum = sum + i;
       i++;
    }

More generally:

   | ``for (`` *initialization* ``;`` *condition* ; *update* ``)`` {
   |    statement(s)
   | ``}``
   
translates to

   | *initialization* ``;`` 
   | ``while (`` *condition* ``)`` {
   |    statement(s)
   |    *update* ``;``
   | ``}``

In the example above, *initialization* is ``i=2``, *condition* is ``i <= n``,
and *update* is ``i++``.

Why bother with this rearrangement?  It is a matter of taste,
but the heading::

    for (i = 2; i <= n; i++) {
    
puts all the information about the variable controlling the loop
into one place at the top, which may help quickly visualize the overall
sequence in the loop.  If you use this format, and get used to the
three parts you are less likely to forget the ``i++`` 
than when it comes tacked on to the end of a while loop body, after all 
the specific things you were trying to accomplish.  

Although the ``for`` loop syntax is very general, 
a strongly recommended convention
is to only use a ``for`` statement when all the control of variables 
determining loop repetition are in the heading.  

For example if a ``for``
loop uses ``i`` in the heading, ``i`` can have a value assigned or 
reassigned in the heading, but should *not* have its value modified
anywhere inside the loop body.  
If you want more complicated behavior, use a ``while`` loop.

A ``for`` loop can also include variable declaration in the initialization,
as in::

    for (int i = 2; i <= n; i++) {
       sum = sum + i;
    }
   
This is close, but not quite equivalent to::

    int i = 2;
    while (i <= n) {
       sum = sum + i;
       i++;
    }

Variables declared in a ``for`` loop heading are local to the 
``for`` loop heading and body.  The variable ``i`` declared before
the ``while`` statement above is still defined after the ``while`` loop.

The two semicolons are always needed in the ``for`` heading, but any of the
parts they normally separate may be omitted.  
If the condition part is omitted, the condition is 
interpreted as always true, leading to an infinite loop, that can only
terminate due to a ``return`` or :ref:`break statement <break-continue>` in the body.  

.. index:: execution sequence; for loop

Note the different parts of the heading used at different times (consistent 
with the positions in the corresponding while loop):

* When starting the whole statement, the initialization is done, and then
  the test.
* After finishing the body and returning to the heading, the update operations
  are done, followed by the test. 

**Other variations**

As in a regular local variable declaration, 
there may be several variables of the
same type initialized at the beginning of a ``for`` loop heading, 
separated by commas.  Also, at the end of the ``for`` loop heading, the
update portion may include more than one expression, separated by commas.  
For example::

      for (int i = 0, j = 10; i < j; i = i+2, j++) {
         Console.WriteLine("{0} {1}", i, j);
      }

Guess what this does, and then paste it into csharp to check.

The comma separated lists in a ``for`` statement heading 
are mentioned here for completeness.  Later we will find a situation
where this is actually useful.

.. index::
   statement; break
   statement; continue
   break statement
   continue statement
   
.. _break-continue:

Break and Continue
------------------------------------------

This section concerns special *break* and *continue* statements 
that can *only* occur inside a loop (any kind:  
``while``, ``for`` or ``foreach``).  
The syntax is convenient in various circumstances, but not necessary.  You are free
to use it, but for this course it is an *optional extra*:

You can already stop a loop in the middle with an ``if`` statement 
that leads to a choice with a ``return`` statement.
Of course that forces you to completely leave the current function.  If you only want to
break out of the *innermost current loop*, but *not* out of the whole function, use
a break statement:

  ``break;`` 
  
in place of return.  Execution continues after the end of the whole innermost
currently running loop statement.  
The ``break`` and ``continue`` statements only 
make practical sense inside of an ``if`` statement that is inside the loop.

Examples, assuming  ``target`` already has a string value and ``a`` is an array of
strings::

    bool found = false;
    for (int i = 0; i < a.Length; i++) {
       if (a[i] == target) {
          found = true;
          break;
       }
    }
    if (found) {
       Console.WriteLine("Target found at index " + i);
    } else {
       Console.WriteLine("Target not found");
    } 

When an element is reached that matches ``target``, 
execution goes on *past the loop* with ``if (found)`` ....

An alternate implementation with a compound condition in the heading and no ``break`` is::

    bool found = false;
    for (int i = 0; i < a.Length && !found; i++) {
       if (a[i] == target) {
          found = true;
       }
    }
    if (found) {
       Console.WriteLine("Target found at index " + i);
    } else {
       Console.WriteLine("Target not found");
    } 

With a ``foreach`` loop, which has no explicit continuation condition, 
the ``break`` would be more clearly useful.
Here is a variant if you do not care about the specific location of the target::

    bool found = false;
    foreach (string s in a) {
       if (s == target) {
          found = true;
          break;
       }
    }
    if (found) {
       Console.WriteLine("Target found");
    } else {
       Console.WriteLine("Target not found");
    } 

Using ``break`` statements is a matter of taste.  There is some advantage in reading
and following a loop that has only one exit criteria, 
which is easily visible in the heading.  On the other hand, in many situations,
using a break statement makes the code much less verbose, and hence easier to follow.
If you *are* reading through the loop, it may be clearer to have an immediate action
where it is certain that the loop should terminate. 

All the modifiers about *innermost* loop are important 
in a situation like the following::

    for (....) {
       for (....) {
          ...
          if (...) {
            ...
            break;
          }
          ...
       }
    } 

The break statement is in the inner loop.  If it is reached, the inner loop ends,
but the inner loop is just a single statement inside the outer loop, 
and the outer loop continues.  
If the outer loop continuation condition remains true,
the inner loop will be executed again, 
and the break may or may not be reached that time, so the inner loop may or may
not terminate normally....

For completeness we mention the much less used ``continue`` statement:

  ``continue;``  

It does not break out of the whole loop: 
It just 
skips the rest of the *body* of the innermost current loop, *this time* through the loop.  
In the simplest situations a ``continue`` statement just avoids an extra ``else`` clause. 
It can considerable shorten code if the test is inside of complicated, deeply nested 
``if`` statements.
