
Substitutions in Console.WriteLine
==================================

Output With ``+``
-----------------

An elaboration of a "Hello, World" program, could greet the user,
after obtaining the user's name.  If the user enters thje name
Kim, the program could print 

    Hello, Kim!

This is a very simple
input-process-output program (in fact with almost no "process").
Think how would you code it? 

You need to obtain a name, remember it and use it in your output.
A solution is in the next section.


.. index::
   double: WriteLine; {} for format

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
``HelloYou1.cs``:

.. literalinclude:: ../examples/HelloYou1.cs

look at a variation, ``HelloYou2.cs``, shown below.
Both programs  
look exactly the same to the user:

.. literalinclude:: ../examples/HelloYou2.cs
   
``Console.WriteLine`` actually can take parameters *after* an initial string,
but only when  the string is in the form of a *format string*,
with expression(s) in braces where substitutions are to be made,
(like in fill-in-the-blanks).  

The remaining parameters, after the initial string, 
give the values to be substituted.  To
know *which* further parameter to substitute, the parameters after the
initial string are implicitly numbered,
*starting from 0*.  
Starting with 0 is consistent with other numbering sequences in C#.
So here, where there is just one value to substitute, it gets the index 0,
and where it is substituted, the braces get 0 inside, to indicate
that parameter 0 is to be substituted.

Everything in the initial string that is *outside* the braces is just
repeated verbatim.  In particular, if the only parameter is a string 
with no braces, it is printed completely
verbatim (as we have used ``Console.WriteLine`` before).

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
    Console.WriteLine("{0} plus {1} = {2}; {0} times {1} = {3}.", x, y, x+y, x*y);
    
and see it print::

    7 plus 5 = 12; 7 times 5 = 35.
    
Note the following features:

- Parameters can be any expression, 
  and the expressions get evaluated before printing.
- Parameters to be substituted can be of any type. 
- The parameters are automatically converted to a string form, just as in the
  use of the string ``+`` operation.  
  
In fact the simple use of format strings
shown so far can be completed replaced by long expressions with ``+``,
if that is your taste.  Miles later (on page 50) discusses fancier formatting,
that *cannot* be duplicated with a simple string ``+`` operation.
We will just use the simple numbered substitutions for now, 
to get used to the idea of substitution.

A technical point: Since braces have special meaning in a format
string, there must be a special rule if you want braces to actually
be included in the final *formatted* string. The rule is to double
the braces: ``'{{'`` and ``'}}'``. The fragment ::

    int a = 2, b = 3;
    Console.WriteLine("The set is {{{0}, {1}}}.", a, b);

produces ::

    The set is {2, 3}.
    