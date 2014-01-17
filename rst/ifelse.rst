
.. index:: if-else

.. _if-else-Statements:
    
|if-else| Statements
----------------------------

Run the example program, :repsrc:`clothes/clothes.cs`. Try it at least twice, with
inputs 50 and then 80. As you can see, you get different results,
depending on the input. The main code of :repsrc:`clothes/clothes.cs` is:

.. literalinclude:: ../source/examples/clothes/clothes.cs
   :start-after: chunk
   :end-before: chunk
   :linenos:

The lines labeled 2-7 are an |if-else| statement. Again it is
close to English, though you might say "otherwise" instead of
"else" (but else is shorter!). There are two indented statements
in braces:
One, like in the simple ``if`` statement, comes right after the
``if`` condition and is executed when the condition  is true. 
In the |if-else| form this is followed by an
``else`` (lined up under the ``if`` by convention), 
followed by another indented statement enclosed in braces that is only
executed when the original condition is *false*. In an |if-else|
statement exactly one of two possible parts in braces is executed.

A final line is also shown that is not indented, about getting exercise.
The `if` and `else` clauses each only embed a single (possibly compound) statement
as option, so the last statement is not part of the |if-else|
statement.  Instead it is a part of the normal sequential
flow of statements.  It is *always* executed after the
|if-else| statement, no matter what happens inside the
|if-else| statement.  Again:  inside the |if-else| there is a
choice made, but the whole |if-else| construction is a single
larger statement, which exists in the normal sequential flow.
The compiler does not require the indentation of the if-true-statement
and the if-false-statement, but it is a standard style convention. 

The general C# |if-else| syntax is

    | ``if (`` *condition* ``) {``   
    |    statement(s) for if-true  
    | ``}``
    | ``else {``
    |    statement(s) for if-false 
    | ``}``


The statements chosen based on the condition 
can be any kind of statement.  This is the suggested form, but
as with the plain ``if`` statement, the if-true compound statement or 
the if-false compound statement can be replace by a single statement
without braces, except in one otherwise ambiguous situation later,
:ref:`match_wrong_if`.

.. _compound-statement-scope:

.. index::
   double: scope; compound statement
   { }; scope
   
Scope With Compound Statements
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The section :ref:`Local-Scope` referred to function  bodies,
which happen to be enclosed in braces, making the function body a *compound statement*.
In fact variables declared inside *any* compound statement have their scope restricted
in inside that compound statement.

As a result the following code makes no sense::

    static int BadBlockScope(int x) 
    {
       if ( x < 100) {
          int val = x + 2;
       }
       else {
          int val = x - 2:
       }
       return val;
    }

The |if-else| statement is legal, but useless, 
because whichever compound statement gets executed,
``val`` ceases being defined after the
closing brace of its compound statement, 
so the ``val`` in the return statement has
not been declared or given a value.  The code
would generate a compiler error. 
 
If we want ``val`` be used inside the braces and 
to make sense past the end of the compound statement,
it cannot be declared inside the braces. Instead it must be
declared before the compound statements that are parts of the 
|if-else| statement.   A local variable in a function declared before a nested compound 
statement is still visible (in scope) *inside*  that compound statement.
The following would work:

.. literalinclude:: ../source/examples/ok_if_scope/ok_if_scope.cs
   :start-after: chunk
   :end-before: chunk

There is even more subtlety here than meets the eye:
An |if-else| statement can generally be rewritten as two simple
if statements (though it is less efficient and less clear).
The two ``if`` statements would use opposite conditions, as in this variation:

.. index:: compiler error; uninitialized local variable

.. literalinclude:: ../source/examples/ok_if_scope/ok_if_scope.cs
   :start-after: past chunk
   :end-before: chunk
   :linenos:


Notie that in this variation we added an 
initialization for ``val`` to be 0, though the 
value of the initialization is never used:  ``val`` is
guaranteed to be assigned a value in one of the ``if`` statements
before its value is used in the return statement.

Open Xamarin Studio with the examples solution, and open 
:repsrc:`ok_if_scope/`ok_if_scope.cs` in the edit window.  
The last function, ``OkScope2``, 
is the one shown above.  Now *remove* the logically
unnecessary ``= 0`` initialization for ``val`` so the line is just ``int val;``.  
As the comment says, an error should
appear (at least after you try to compile the program).
The error will say that there is an uninitialized local variable!  Why?

For safety 
the C# compiler has some basic analysis to check that every local
variable gets given a value before its value is used.  In the ``OkScope`` function
there is no *one*
place where ``val`` gets an initial value, but the compiler is smart enough to see
that one of the branches of any if-else statement is always taken, 
and ``val`` gets a value in each, so there is
no problem. 

The compiler analysis is not complete:  It does not actually evaluate any
expressions.  This is good enough to catch many initialization errors that coders make, 
but it
is not sufficient in general: We can see this from the altered ``OkScope2``.

The original code shows the fix:  Give a dummy initialization that is never used
in execution, but keeps the compiler happy.

Although this extra initialization is annoying, the extra step is rarely needed. 
Meanwhile it is very easy to forget to give a value to a local variable before use!  
Having
the error caught quickly by the compiler is very handy, offsetting the extra work
when the compiler gives this error unnecessarily.

