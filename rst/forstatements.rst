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
   
is exactly equivalent to this code simliar to part of 
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
   |    *update* 
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
terminate due to a ``return`` or ``break`` statement in the body.
See Miles, page 46, for a discussion of ``break``. 

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

The comma separated lists in a ``for`` statement heading 
are mentioned here for completeness.  Later we will find a situation
where this is actually useful.


