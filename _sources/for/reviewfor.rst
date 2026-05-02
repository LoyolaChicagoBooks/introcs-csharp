Chapter Review Questions
=========================

#.  When might you prefer a ``for`` loop in place of a ``while`` loop?
    What do you gain?
    
#.  When might you prefer a ``while`` loop or a ``foreach`` instead of 
    a ``for`` loop?
    
#.  When you have nested ``for`` loops, and you reach the bottom of the *body* of the
    *inner* loop, where does execution go next?

#.  May you legally omit the initialization part of a ``for`` loop?

#.  What happens when you omit the condition in a ``for`` loop?

#.  In the heading of a ``for`` loop, how do you initialize or update
    several variables?
    
#.  Rewrite ::
   
        num /= 2;
        
    equivalently without the operand ``/=``.
    
#.  Rewrite ::

       bigName = bigName - 10;
       
    with a statement that only includes ``bigName`` once.
    
#.  Distinguish the effects of these two statements::

       x-=2;
       
       x=-2;
       
#.  What is printed?  ::

        Console.WriteLine("12345678");
        for( int p = 1; p < 6; p++) {
            string formatStr = "{0:F" + p + "}";
            Console.WriteLine(formatStr, 1.2345678);
        }
        
#.  What is printed?  (Just ",4" has been inserted.) ::

        Console.WriteLine("12345678");
        for( int p = 1; p < 6; p++) {
            string formatStr = "{0,4:F" + p + "}";
            Console.WriteLine(formatStr, 1.2345678);
        }
        
#.  What is printed?  ::

        Console.WriteLine("123456");
        for( int w = 6; w >= -6; w -= 4) {
            string formatStr = "{0," + w + "}|";
            Console.WriteLine(formatStr, "here");
        }
        
