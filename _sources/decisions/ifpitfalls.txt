    
If-statement Pitfalls
------------------------

.. index::
   semicolon after condition pitfall
   double: pitfall; if

.. _dangerous-semicolon:

Dangerous Semicolon
~~~~~~~~~~~~~~~~~~~~~~~~~~

Regular statements must end with a semicolon.
It turns out that the semicolon is all you need to have a legal statement::

    ;
    
We will see places that it is useful, but
meanwhile it can cause errors: You may be hard pressed to
remember to put semicolons at the end of all your statements, and in response you may
get compulsive about adding them at the end of statement
lines.  Be careful NOT to put one at the end of a method heading or 
an ``if`` condition::

    if ( x < 0); // WRONG PROBABLY!
        Console.WriteLine(x);

This code is deadly, since it compiles and is almost surely 
*not* what you mean.

Remember indentation and newlines are only significant for humans. The
two lines above are equivalent to::

    if ( x < 0)
       ;  // Do nothing as statement when the condition is true
    Console.WriteLine(x); // past if statement - do it always

(Whenever you do need an empty statement, you are encouraged to put the
semicolon all by itself on a line, as above.)

If you always put an open brace *directly* after the condition in an ``if`` statement, 
you will not make this error::

    if ( x < 0) {
        Console.WriteLine(x);
    }

Then even if you were to add a semicolon::

    if ( x < 0) { ;
        Console.WriteLine(x);
    }

it would be a waste of a keystroke, but it would just be the first (empty) statement 
inside the block, and the writing would still follow:
The extra semicolon would have no effect.

The corresponding error at the end of a method heading will at least 
generate a compiler error, though it may appear cryptic::

    static void badSemicolon(int x);
    {
        x = x + 2;
        // ...

This is another easy one to make and *miss* - just one innocent semicolon.

.. index:: pitfall; dangling else;
   dangling else pitfall 
   if-else; pitfall
   
.. _match_wrong_if:

Match Wrong ``if`` With ``else``
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

If you do not consistently put the substatements for the true
and false choices inside braces, you can run into problems from
the fact that the else part of an if statement is *optional*. 
Even if you use braces consistently, 
you may well need to read code that does not place
braces around single statements. If C# understood indentation as
in the recommended formatting style (or as required in Python), 
the following would be OK::

    if (x > 0)
       if (y > 0)
          Console.WriteLine("positive x and y");
    else
       Console.WriteLine("x not positive, untested y");

Unfortunately placing the ``else`` under the first ``if`` is not enough to make
them go together (remember the C# compiler ignores extra whitespace). The
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
and ``y`` is -2, the ``else`` part is executed and the statement printed is
incorrect: in this code 
the else clause is only executed when ``x`` is positive and 
``y`` (*is*
tested and) is not positive. 

If you put braces everywhere to reinforce
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
printed will be true: ``x`` is not positive, and the test of ``y`` was skipped.
   

.. index::
   pitfall; need braces for if
   if; need braces
   braces needed with if

.. _missing-braces:

Missing Braces
~~~~~~~~~~~~~~~~~~~~~~~~~~

Another place you can fool yourself with nice indenting style is
something like this.  Suppose we start with a perfectly reasonable ::

    if (x > 0)
        Console.WriteLine("x is: positive");

We may decide to avoid the braces, since there *is* just one statement
that we want as the if-true part, but if we later decide 
that we want this on two lines
and change it to ::

    if (x > 0)
        Console.WriteLine("x is:");
        Console.WriteLine("  positive");

We are not going to get the behavior we want.  
The word "positive" will *always* be printed.

If we had first taken a bit more effort originally to write ::

    if (x > 0) {
        Console.WriteLine("x is: positive");
    }
    
then we could have split successfully into  ::

    if (x > 0) {
        Console.WriteLine("x is:");
        Console.WriteLine("  positive");
    }

This way we do not have to keep worrying about this question when we revise:
"Have I switched to multiple lines after the ``if``
and need to introduce braces?"

The last two of the pitfalls mentioned in this section are fixed by consistent
use of braces in the sub-statements of ``if`` statements.  They fix the ``;`` 
after if-condition problem only if the open brace comes right after
the condition, but you still get a nasty error if you put in a semicolon 
between the condition and opening brace.
