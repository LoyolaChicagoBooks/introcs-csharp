.. index:: labs; loops

.. _lab-loops:
   
Lab: Loops
==========

Goals for this lab:

- Practice with loops.  You are encouraged to use a ``for`` loop where appropriate.
- Use nested loops where appropriate.

The lab stub was added to the examples on 9/21/12.  You can download and unzip 
a *new* copy of the 
`course example file <http://introcs.cs.luc.edu/book/download/comp170code.zip>`_.
Alternately, you can directly download the example
`loop_lab_stub.cs <https://bitbucket.org/gkthiruvathukal/introcs-csharp/raw/default/examples/loop_lab_stub.cs>`_.
Then copy example :file:`loop_lab_stub.cs` to :file:`loop_lab.cs`, 
and fill in function bodies in :file:`loop_lab.cs` for each part below: 

.. index:: PrintReps

#.  Complete  

    .. literalinclude:: ../examples/loop_lab_stub.cs
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

    .. literalinclude:: ../examples/loop_lab_stub.cs
       :start-after: StringOfReps chunk
       :end-before: body

    Note the distinction from the previous part:  Here the function prints nothing.
    Its work is *returned* as a single string.  You have to build up the final
    string.
    
    .. index:: Factorial
    
#.  Complete ``Factorial``, in a format much like SumToN in example ``sum_to_n.cs``:  
    
    .. literalinclude:: ../examples/loop_lab_stub.cs
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
    to make this easier.)
    
#.  Modify the function to return a ``long``.  
    Then what is the largest value of ``n`` for which the function works?
    
    *Remember the values from this part and the last part
    to tell the TA's checking out your work.*

    .. index:: loop; nested
       PrintRectangle
      
#.  Complete the method

    .. literalinclude:: ../examples/loop_lab_stub.cs
       :start-after: PrintRectangle chunk
       :end-before: body
    
    Here are further examples::
        
        printRectangle(5, 1, ' ', 'B');
        printRectangle(0, 2, '-', '+');
    
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
    