    
If-statement Pitfalls
------------------------

.. index::
   triple: pitfall; semicolon after condition; if statement

.. _dangerous-semicolon:

Dangerous Semicolon
~~~~~~~~~~~~~~~~~~~~~~~~~~

Regular statements must end with a semicolon.
It turns out that the semicolon is all you need to have a legal statement::

    ;
    
We will see places that it is useful, but
meanwhile it can cause errors: Although you may be hard pressed to
remember to put semicolons at the end of all your statements, and may
get compulsive in response about adding them at the end of statement
lines, be careful NOT to put one at the end of a method heading or 
an if condition::

    if ( x < 0); // WRONG PROBABLY!
        Console.WriteLine(x);

Remember indentation and newlines are only significant for humans. The
two lines above are equivalent to::

    if ( x < 0)
       ; // Do nothing as statement when the condition is true
    Console.WriteLine(x); // past if statement - do it always

(Whenever you do need an empty statement, you are encouraged to put the
semicolon all by itself on a line, as above.)

This code is deadly, since it compiles and is almost surely 
*not* what you mean.

If you always put an open brace at the end of the line of a condition, 
you are less likely to make this error.

The corresponding error at the end of a method heading will at least 
generate a compiler error, though it may appear crypic::

    static void badSemicolon(int x);
    {
        x = x = 2;
        // ...

.. index::
   triple: pitfall; dangling else; if-else

Match Wrong ``if`` With ``else``
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The fact that the else part of an if statement is optional can cause
problems if you do not consistently put the substatements for the true
and false choices inside braces. Even if you do
this consistently, you may well need to read code that does not place
braces around single statements. If C# understood indentation as
in the recommended formatting style (or as required in Python), 
the following would be OK::

    if (x > 0)
       if (y > 0)
          Console.WriteLine("positive x and y");
    else
       Console.WriteLine("x not positive, untested y");

Unfortunately placing the ``else`` under the first ``if`` is not enough to make
them go together (remember the C# compiler ignores whitespace). The
following is equivalent to the compiler, with the else apparently going
with the second if::

    if (x > 0)
       if (y > 0)
          Console.WriteLine("positive x and y");
       else
          Console.WriteLine("x not positive, untested y");

The compiler is consistent with the latter visual pattern: an ``else`` goes
with the most *recent* ``if`` that could still take an ``else``. 
Hence if ``x`` is 3
and ``y`` is -2, the ``else`` part is executed and statement printed is
incorrect: the else clause is only executed when ``x`` is positive and 
``y`` (is
tested and) is not positive. If you put braces everywhere to reinforce
your indentation, as we suggest, or if you only add the following
one set of braces around the inner if statement::

    if (x > 0) {
       if (y > 0)
          Console.WriteLine("positive x and y");
    }
    else
       Console.WriteLine("x not positive, untested y");

then the braces enclosing the inner ``if`` statement make it impossible for
the inner  ``if`` to continue on to an optional ``else`` part. 
The ``else`` must go
with the first ``if``. Now when the ``else`` part is reached, the statement
printed will be true: ``x`` is not positive, and the test of ``y`` is skipped.
   

.. index::
   triple: pitfall; need braces; if statement

Missing Braces
~~~~~~~~~~~~~~~~~~~~~~~~~~

Another place you can fool yourself with nice indenting style is
something like this.  Suppose I start with a perfectly reasonable ::

    if (x > 0)
        Console.WriteLine("x is: positive");

I may decide to avoid the braces, since there *is* just one statement
that I want as the if-true part, but if I later decide 
that I want this on two lines
and change it to ::

    if (x > 0)
        Console.WriteLine("x is:");
        Console.WriteLine("  positive");

I am not going to get the behavior I want.  
The positive part will *always* be printed.

If I had first taken a bit more effort originally to write ::

    if (x > 0) {
        Console.WriteLine("x is: positive");
    }
    
then I could have split successfully into  ::

    if (x > 0) {
        Console.WriteLine("x is:");
        Console.WriteLine("  positive");
    }

This way I do not have to keep worrying when I revise:
Have I switched to multiple lines after the ``if``
and need to introduce braces?

All three of the pitfalls mentioned in this section are fixed or 
minimized by consistent
use of braces in the sub-statements of ``if`` statements.