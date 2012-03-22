.. _Simple-if-Statements:
    
Simple ``if`` Statements
------------------------

Compile and run this example program, ``Suitcase.cs``. 
Try it at least twice, with
inputs: 30 and then 55. As you an see, you get an extra result,
depending on the input. The main code is:

.. literalinclude:: ../examples/Suitcase.cs
   :start-after: chunk
   :end-before: chunk
   :linenos:

The lines labeled 3-5 are an ``if`` statement. It reads pretty much
like English. If it is true that the weight is greater than 50,
then print the statement about an extra charge. If it is not true
that the weight is greater than 50, then skip the part
right after the condition about  
printing the extra luggage charge. 
In any event, when
you have finished with the ``if`` statement (whether it actually does
anything or not), go on to the next statement. 
In this case that is the statement
printing "Thank you".
An ``if`` statement only breaks the  normal sequential order
*inside* the `if`` statement itself. 

The general C# syntax for a simple ``if`` statement is

    | ``if (`` *condition* ``)`` 
    |     statement  

Often you want multiple statements executed when the condition
is true.  We have used braces before.  We have not said
what they do technically, syntactically:  braces around
a group of statements technically makes a *single* 
compound statement.  So the pattern commonly written is:

    | ``if (`` *condition* ``) {`` 
    |       one or more statements  
    | ``}``

If the condition is true, then do the statement(s) in braces. If the
condition is not true, then skip the statements in braces.  The
indentation pattern is also illustrated.  Recall the compiler
does not care about the amount of whitespace, but humans do.
In general indent the statements inside a compound statement.
We will see later that there is good reason to use this format 
with braces *even* if there is just one statement inside the braces.

Another fragment as an example::

    if (balance < 0) {
        transfer = -balance; 
        // transfer enough from the backup account: 
        backupAccount = backupAccount - transfer;
        balance = balance + transfer;
    }

The assumption
in the example above is that if an account goes negative, it is
brought back to 0 by transferring money from a backup account in
several steps.

In the examples above the choice is between doing something (if the
condition is ``true``) or nothing (if the condition is ``false``).
Often there is a choice of two possibilities, only one of which
will be done, depending on the truth of a condition....

