.. _substitution-in-writeline:

Substitutions in Console.WriteLine
==================================

Output With ``+``
-----------------

An elaboration of a "Hello, World" program, could greet the user,
after obtaining the user's name.  If the user enters the name
Elliot, the program could print 

    Hello, Elliot!

This is a very simple
input-process-output program (in fact with almost no "process").
Think how would you code it. 

You need to obtain a name, remember it and use it in your output.
A solution is in the next section.


.. index::
   WriteLine; { } for format
   single: { } ; Format 

.. _Format-Strings:

String Format Operation
-----------------------

A common convention is fill-in-the blanks. For instance,

    Hello, _____!

and you can fill in the name of the person greeted, and combine
given text with a chosen insertion. C# has a similar
construction, better called fill-in-the-braces,
that can be used with ``Console.WriteLine``.

Instead of inserting user input with the ``+`` operation as in 
:repsrc:`hello_you1/hello_you1.cs`:

.. literalinclude:: ../../source/examples/hello_you1/hello_you1.cs

look at a variation, :repsrc:`hello_you2/hello_you2.cs`, shown below.
Both programs  
look exactly the same to the user:

.. literalinclude:: ../../source/examples/hello_you2/hello_you2.cs

All the new syntax is in the line::

   Console.WriteLine ("Hello, {0}!", name);

``Console.WriteLine`` actually can take parameters *after* an initial string,
but only when  the string is in the form of a *format string*,
with expression(s) in braces where substitutions are to be made,
(like in fill-in-the-blanks). Here the format string is ``"Hello, {0}!"``. 

The remaining parameters, after the initial string, 
give the values to be substituted.  To
know *which* further parameter to substitute, the parameters after the
initial string are implicitly numbered,
*starting from 0*.  
Starting with 0 is consistent with other numbering sequences in C#.
So here, where there is just one value to substitute (``name``), it gets the index 0,
and where it is substituted, the braces get 0 inside, to indicate
that parameter with index 0 is to be substituted.

Everything in the initial string that is *outside* the braces is just
*repeated verbatim*.  In particular, if the only parameter is a string 
with no braces, it is printed completely
verbatim (reducing to the situations where we have used ``Console.WriteLine`` before).

A more elaborate silly examples that you could test in csharp would be::

    string first = "Peter";
    string last = "Piper";
    string what = "pick";
    Console.WriteLine("{0} {1}, {0} {1}, {2}.", first, last, what);
    
It would print::

    Peter Piper, Peter Piper, pick.
    
where parameter 0 is ``first`` (value ``"Peter"``), 
parameter 1 is ``last`` ( value ``"Piper"``), and
parameter 2 is ``what`` (value ``"pick"``).  

Make sure you see why the given output is exactly what is printed.

Or try in csharp::

    int x = 7;
    int y = 5;
    Console.WriteLine("{0} plus {1} is {2}; {0} times {1} is {3}.", x, y, x+y, x*y);
    
and see it print:

.. code-block:: none

    7 plus 5 is 12; 7 times 5 is 35.
    
Note the following features of the parameters after the first string:

- These parameters can be any expression, 
  and the expressions get evaluated before printing.
- These parameters to be substituted can be of any type. 
- These parameters are automatically converted to a string form, just as in the
  use of the string ``+`` operation.  
  
In fact the simple use of format strings
shown so far can be completed replaced by long expressions with ``+``,
if that is your taste.  We later discusses fancier formatting in :ref:`tables`,
that *cannot* be duplicated with a simple string ``+`` operation.
We will use the simple numbered substitutions for now just  
to get used to the idea of substitution.

.. index:: format; literal {}
    
A technical point: Since braces have special meaning in a format
string, there must be a special rule if you want braces to actually
be included in the final *formatted* string. The rule is to double
the braces: ``"{{"`` and ``"}}"``. The fragment ::

    int a = 2, b = 3;
    Console.WriteLine("The set is {{{0}, {1}}}.", a, b);

produces

.. code-block:: none

    The set is {2, 3}.

Format Reading Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~

What is printed?  ::

        Console.WriteLine("{0}{1}{1}{2}", "Mi", "ssi", "ppi");
        
Check yourself.
   
.. _QuotientFormat:

Exercise for Format
~~~~~~~~~~~~~~~~~~~~~~~

Write a program, ``quotient_format.cs``, that behaves like
:ref:`QuotientProblem`, but generate the sentence using 
``Console.WriteLine`` with a format string and no ``+`` operator.


Madlib Exercise 
~~~~~~~~~~~~~~~~~~~~~~~

Write a program, ``my_mad_lib.cs``, that prompts the user for
words that fit specified gramatical patterns ( a noun, a verb, a color,
a city....) and plug them into a multiline format string so they fit
grammatically, and
print the usually silly result.  
If you are not used to mad libs, try running (not 
looking at the source code) the example project mad_lib, and then try it 
again with different data.
If this exercise seems like too big of a challenge yet,
see our example source code, 
:repsrc:`mad_lib/mad_lib.cs`, and then *start over* on your own.


.. index:: method; overloading
   overloading; methods

.. _overloading:

Overloading
-------------

The ``WriteLine`` function can take parameters in different ways:

- It can take a single parameter of an type (and print its string representation).
- It can take a string parameter followed by any number of parameters used to 
  substitute into the initial format string.
- It can take no parameters, and just advance to the next line (not used yet in
  this book).
  
Though each of these uses has the same name, ``Console.WriteLine``, 
they are technically all different functions:  A function is not just recognized
by its name, but by its *signature*, 
which includes the name **and** the number and types of parameters.
The technical term for using the same name with different signatures for different
functions is *overloading* the function (or method).

This only makes practical sense for a group of closely related functions, where the
use of the same name is more helpful than confusing.
