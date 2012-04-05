.. _string-char:

.. index::
   double: function; scope
   double: function; not use return value
   double: scope; not use return value

Not using Return Values
==================================

Some functions are void, and get used as a whole instruction in your code:  
They go off and do something, leaving some lasting side effect; 
come back, and are ready to go on to the next task.

Some functions return a value, and get used as an expression in a larger statement.
The statement uses the value returned.  Usually the only effect of such a function is in the
value returned.

Usually there is this division:  

#. Void; do something as whole instruction, with a side effect in the larger system
#. Return a value to use in a larger statement

It is legal to *both* accomplish something with a side effect in the system,
like add to a set, leaving it changed, *and* return a value.

An example is the method ``Add`` for :ref:`sets`: 

  It can modify the set - 
  a change that lives on after the method terminates,
  
*and*

  it returns a boolean value, so ``someSet.Add(element)`` can be used
  in a larger statement.
  
There is a purpose to the return value in this situation:  Adding to a set
may or may not change the set, since sets ignore duplicates.  The method returns 
true if the set was changed.

You may or may not find that returned information useful.  You might use it,
as in this trivial example::

    if (someSet.Add(element)) {
        Console.WriteLine("Set changed!");
    }
    
or if you do not care about the returned value you can *ignore* it, and use
the method call as a *whole* statement, as you would use a void method::

    someSet.Add(element);

The system does not complain if a return value is ignored and essentially thrown away.

You should generally think carefully before writing a function that both has a side effect 
and a return value.  Most functions that return a value do not have a side effect.  
If you see a function used in the normal way as an expression, it is easy to forget that
it was *also* producing some side effect.

Another common error is to forget to assign a return value to a variable when that is what
you actually want for the logic of your program.   For example with this definition::

    static int CalcResult(int param)
    {
       int result;
       // ....
       result = ....;
       return result;
    }
    
you might  try to use it in this bad code::

    CalcResult(x);
    Console.WriteLine(result);
    
You went to the trouble to calculate ``result`` in the function.  Why not just use it?

The reason is the *scope* rules for functions:  The local variable ``result`` 
disappears when the function returns.  It has no meaning later in the calling function.  

Any of the following alternatives are OK::

    int result = CalcResult(x);  //remember it!
    Console.WriteLine(result);
   
    //OR
    
    int value = CalcResult(x);  // no need for names to match
    Console.WriteLine(value);  
   
    //OR
    
    Console.WriteLine(CalcResult(x));  
    
The last version works as long as you do not need the 
returned value in a second place, later.