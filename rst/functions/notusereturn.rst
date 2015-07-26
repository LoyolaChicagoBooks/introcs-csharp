.. index:: function; not use return value
   return; value not used 
   
.. _not-using-ret-val:

Not using Return Values
==================================

Some functions return a value, and get used as an expression 
in a larger calling statement.
The calling statement uses the value returned.  
Usually the only effect of such a value-returning function is from the
value returned.

Some functions are ``void``, and get used as a whole instruction in your code:  
Without returning a value, the only way to be useful is to do something that 
leaves some lasting *side effect*:  
make some change to the system that persists after
the termination of the function and its local variables disappear.  
The only such effect that we have seen so 
far is to print something that remains on the console screen.  
Later we will talk about other persistent changes 
to values in objects, locations in files, ....

Usually there is this division in the behavior of functions, 
returning a value or not:  

#. ``void``: do something as a whole instruction, 
   with a side effect in the larger system.
#. Return a value to use in a larger calling statement


It is legal to do *both*: accomplish something with a side effect 
in the system, *and*
return a value.  Sometimes you care about both, 
and sometimes you use the function only for its side effect.  
We will see examples of that later, like in :ref:`sets`.

This later advanced use will mean that the compiler needs to 
*permit* the programmer to ignore a 
returned value, and use a function returning a value as a whole statement. 

..  warning:: 
    This means that the compiler cannot catch a common logical error: 
    forgetting to immediately use a returned value that your program logic
    really needs.   

For example with this definition::

    static int CalcResult(int param)
    {
       int result;
       // ....
       result = ....;
       return result;
    }
    
you might try to use ``CalcResult`` in this bad code, intending to use the ``result``
from CalcResult::

    static void BadUseResult(int x)
    {
       int result = 0;
       CalcResult(x);
       Console.WriteLine(result);
    }
    
In fact you would always print 0, ignoring the ``result`` 
calculated in ``CalcResult``.
The reason is the :ref:`Local-Scope` rules:  The local variable name ``result`` 
disappears when the ``CalcResult`` function returns.  
It is not used in the calling function, ``BadUseResult``, and the 
separately declared ``result`` of ``BadUseResult``
retains its original 0 value.   

Here we set up the worst situation: where there is a logical error, 
but not an error shown by the compiler.  More commonly a student leaves out
the ``int result = 0;`` line, incorrectly relying on the declaration of ``result``
in ``CalcResult``.  At least in that situation a compiler error brings attention
to the problem: 
The last line would try to use the variable ``result`` 
without it being declared.

You can use the result from ``CalcResult``, like with any other
value-returning function, with either  ::

    int value = CalcResult(x);  //store the returned value in an assignment!
    Console.WriteLine(value);   //  and then use the remembered value

or  ::
    
    Console.WriteLine(CalcResult(x)); // immediately use the returned value 
       
This second version works as long as you do *not* need the 
returned value later, in another place, since you do not remember it past that
one statement!
