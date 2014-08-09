.. index:: statement; do while
   do while 
   while vs. do while
   
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
With the triangle problem, three pieces for data need to be entered, 
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
        }
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

It only sets the data to be tested *once*.  
(The trade-off is that the condition is tested *twice*.)

.. index:: exercise; loan table
   decimal; loan table exercise

.. _loan_table_exercise:

Loan Table Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Loans are common with a specified interest rate and with a fixed periodic 
payment.  Interest is charged at a fixed rate on the amount left in the loan 
after the last periodic payment (or start of the loan for the first payment).

For example, if an initial $100 loan is made with 10% interest per pay
period, and a regular $20 payment each pay period:
At the time of the first payment interest of $100*.10 = $10 is accrued,
so the total owed is $110.  Right after the payment of $20, 
$110 - $20 = $90 remains.  That $90 gains interest of $90*.10 = $9 up to the
next payment, when $90 + $9 = $99 is owed.  After the regular payment of
$20, $99 - $20 = $79 is left, and so on.  When a payment of at most $20 brings
the amount owed to 0, the loan is done.
 
We can make a table showing 

* Payment number (starting from 1)
* The principal amount after the previous payment (or the beginning of the loan
  for the first payment) 
* The interest on that principal up until the next periodic payment
* The payment made as a result.  

Continuing the example above, the whole table
would look like:

.. code-block:: none

    Number Principal   Interest    Payment
         1    100.00      10.00      20.00
         2     90.00       9.00      20.00
         3     79.00       7.90      20.00
         4     66.90       6.69      20.00
         5     53.59       5.36      20.00
         6     38.95       3.90      20.00
         7     22.85       2.29      20.00
         8      5.14       0.51       5.65

In the final line, the principal plus interest equal the payment, finishing
off the loan.
     
Similarly, with a $1000.00 starting loan, 5% interest per pay period, and
$196 payments due, we would get

.. code-block:: none
      
    Number Principal   Interest    Payment
         1   1000.00      50.00     196.00
         2    854.00      42.70     196.00
         3    700.70      35.04     196.00
         4    539.74      26.99     196.00
         5    370.73      18.54     196.00
         6    193.27       9.66     196.00
         7      6.93       0.35       7.28

If a $46 payment were specified, the principal would not decrease from the
initial amount, and the loan would never be paid off.

There are a couple of wrinkles here:  ``double`` values do not hold decimal
values exactly.  The ``decimal`` type does hold decimal numbers exactly 
(and in an enormous range, see :ref:`numeric-type-limits`) and
hence are beter for monetary calculations.  Decimal literals end with m, like
``34.56m`` for *exactly* 34.56.    

Though decimals are exact, money only has two decimal places.  We make the 
assumption that interest will always be calculated as current 
principal*rate, rounded
to two decimal places:  ``Math.Round(principal*rate, 2)``.

Write :file:`loan_calc.cs``, completing ``LoanTable`` and write a 
``Main`` testing program::

    /// Print a loan table, showing payment number, principal at the 
    /// beginning of the payment period, interest over the period, and
    /// payment at the end of the period.
    /// The principal is the initial amount of the loan.
    /// The rate is fraction representing the rate of interest per PAYMENT.
    /// The periodic regular payment is also specified.
    /// If the payment is insufficient, merely print "payment too low".    
    public static void LoanTable(decimal principal, decimal rate, 
                                 decimal payment)

Note that the ``rate``, too, is a ``decimal``, 
even though it does not represent money.
That is important, because arithmetic with a ``decimal`` and a ``double`` is
forbidden:  A ``double`` would have to be explicitly cast to a ``decimal``.
Insisting on ``decimal`` parameter simplifies the function code.

This exercise is much more sophisticated than the :ref:`savings_exercise`,
so it is placed in this section, much later in the chapter.  Use what
ever form of loop makes the most sense to you.
