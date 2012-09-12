.. index::
   double: statement; do while
   
.. _do-while:

Do-While Loops
_________________

Suppose you want the user to enter three integers for sides of a 
right triangle.  If they do not make a right triangle, say so
and make the user try again.

One way to look at the while statement rubric is:

.. code-block:: none

    set data for condition
    while (condition) {
       accomplish something
       set data for condition
    }
    
As we have pointed out before this involves setting data in two places.
With the triangle problem, three pieces fo data need to be entered, 
and the condition to test is fairly simple.   (In any case the condition 
could be calculated in a function.)

A |do-while| loop will help here.  It tests the condition at the end of the
loop, so there is no need to gather data before the loop::

    int a, b, c;
    do {
        Console.WriteLine("Think of integer sides for a right triangle.");
        a = UI.PromptInt("Enter integer leg: ");
        b = UI.PromptInt("Enter another integer leg: ");
        c = UI.PromptInt("Enter integer hypotenuse: ");
        if (a*a + b*b != c*c) {
            Console.WriteLine("Not a right triangle: Try again!");
    } while (a*a + b*b != c*c);
    
The general form of a |do-while| statement is

    | ``do {``
    |    statement(s)
    | ``} while (`` *continuationCondition* ``);``
    
Here the block of statement(s) is *always* executed at least once, but it continues
to be executed in a loop only so long as the condition tested 
after the loop body is true.

.. note::

   A |do-while| loop is the *one* place where you *do* want a semicolon
   right after a condition, unlike the places mentioned in
   :ref:`dangerous-semicolon`.  At least if you omit it here you
   are likely to get a compiler error rather than a difficult logical
   bug.


A |do-while| loop, like the example above, 
can accomplish exactly the same thing as the ``while``
loop rubric at the beginning of this section.  It has the general form:

.. code-block:: none

    do {
       set data for condition
       if (condition) {
           accomplish something
       }
    } while (condition);

It only sets the data to be tested once.  
(The tradeoff is that the condition is tested twice.)
