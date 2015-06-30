.. index:: labs; loops

.. _lab-loops:
   
Lab: Loops
==========

Goals for this lab:

- Practice with loops.  You are encouraged to use a ``for`` loop where appropriate.
- Use nested loops where appropriate.

Copy example :repsrc:`loop_lab_stub/loop_lab.cs` to a new project of yours, 
and fill in function bodies for each part below: 

.. index:: PrintReps

#.  Complete  

    .. literalinclude:: ../source/examples/loop_lab_stub/loop_lab.cs
       :start-after: PrintReps chunk
       :end-before: body

    Hint:  How would you do something like the example
    ``PrintReps("Ok", 9)`` or with a higher count by hand?  
    Probably count under your breath as you write:
    
    .. code-block:: none

        1 2 3 4 5 6 7 8 9
       OkOkOkOkOkOkOkOkOk
    
    This is a counting loop.
    
    .. index:: StringOfReps
    
#.  Complete  

    .. literalinclude:: ../source/examples/loop_lab_stub/loop_lab.cs
       :start-after: StringOfReps chunk
       :end-before: body

    Note the distinction from the previous part:  Here the function prints nothing.
    Its work is *returned* as a single string.  You have to build up the final
    string.
    
    .. index:: Factorial
    
#.  Complete ``Factorial``, in a format much like SumToN in example 
    :repsrc:`sum_to_n_test/sum_to_n_test.cs`:  
    
    .. literalinclude:: ../source/examples/loop_lab_stub/loop_lab.cs
       :start-after: Factorial chunk
       :end-before: body
    
    It is useful to think of the sequence of steps to calculate a 
    concrete example of a factorial, say 6!:
    
    .. code-block:: none

       Start with 1
       2 *1 = 2
       3*2 = 6
       4 * 6 = 24
       5*24 = 120
       6*120 = 720

    **ALSO** find the largest value of ``n`` for which the function works.
    (You might want to add a bit of code further testing Factorial,
    to make this easier.)  Caution:  although a negative result from the 
    product of two positive numbers is clearly wrong, only half of the
    allowed values are negative, so the first wrong answer could equally well
    be positive.
    
#.  Modify the function to return a ``long``.  
    Then what is the largest value of ``n`` for which the function works?
    
    *Remember the values from this part and the previous part*
    *to tell the TA's checking out your work.*

    .. index:: PrintRectangle
      
#.  Complete the method

    .. literalinclude:: ../source/examples/loop_lab_stub/loop_lab.cs
       :start-after: PrintRectangle chunk
       :end-before: body
    
    Here are further examples::
        
        PrintRectangle(5, 1, ' ', 'B');
        PrintRectangle(0, 2, '-', '+');
    
    would print
    
    .. code-block:: none

       BBBBBBB
       B     B
       BBBBBBB
       ++
       ++
       ++
       ++
    
    Suggestion:  You are always encouraged to build up to a complicated solution 
    incrementally.
    You might start by just creating the inner rectangle, without the border.

#.  **40% Extra Credit** Complete the method below.  

    .. literalinclude:: ../source/examples/loop_lab_stub/loop_lab.cs
       :start-after: PrintTableBorders chunk
       :end-before: body
    
    Here is further example::
        
        PrintTableBorders(2, 1, 6, 3);
    
    would print (with actual vertical bars)
    
    .. code-block:: none

       +------+------+
       |      |      |
       |      |      |
       |      |      |
       +------+------+
    
    You can do this with lots of nested loops, 
    or much more simply you can use ``StringOfReps``, possibly six times
    in several assignment statements, 
    and print a single string.  Think of larger and larger building blocks.
   
    The source of this book is plain text where some of the tables are laid out
    in a format similar to the output of this function.  The Emacs editor 
    has a mode that maintains
    a fancier related setup on the screen, on the fly,
    as content is added inside the cells!
   