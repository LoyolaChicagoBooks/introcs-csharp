Chapter Review Questions
=========================

#.  Which of these are Boolean expressions?  Assume the variables are of 
    type ``int``::

        true
        "false"
        x = 3
        n < 10
        count == 22
        x <= 2 || x > 10
        x == 2 || 3
        1 < y < 10
        
#.  What are the values of these expressions?  Be able to explain::

        2 < 3 && 4 < 5
        2 < 3 && 4 < 3
        2 < 3 || 4 < 5
        2 < 3 || 4 < 3
        3 < 2 || 4 < 3
        2 < 3 || 4 < 5 && 4 < 3
        
#.  Correct the last two entries in the first problem, supposing the user
    meant "x could be either 2 or 3" and then
    "y is strictly between 1 and 10".
    
#.  Add parentheses in ``2 < 3 || 4 < 5 && 4 < 3`` to get a different result. 
    
#.  Suppose you have four possible distinct situations in your algorithm, 
    each requiring a totally
    different response in your code, 
    and exactly one of the situations is sure to occur.
    Have many times must you have ``if`` followed by
    a condition?
    
#.  Suppose you have four possible distinct situations in your algorithm, 
    each requiring a totally
    different response in your code, 
    and at most one of the situations will occur, so 
    possibly nothing will happen that needs a response at all.
    Have many times must you have ``if`` followed by
    a condition?
    
#.  Assume  ``IsBig(x)`` returns a Boolean value.
    Remove the redundant part of this statement::
    
        if (IsBig(x) == true)
           x = 3;
                        
#.  Write an equivalent (and much shorter!) statement with no ``if``:: 

        if (x > 7)  
           return true;
        else
           return false; 
           
#.  Write an equivalent (and much shorter!) statement with no ``if``:: 

        if (x > 7)  
           isSmall = false;
        else
           isSmall = true; 
           
#.  Assume ``x`` and ``y`` are local ``int`` variables.  
    Code fragments are separated by a blank line below.  
    Pairs of the fragments are logically equivalent, but not necessarily with
    a directly adjacent fragment. Match the pairs.  Be sure you understand
    when different pairs would behave differently.  Caution: 
    there is some pretty awful code here, that we would *hope* you would never
    write, but you might need to correct/read!  Think of pitfalls.
    In each equivalent pair, which code fragment is more professional?  ::
    
       if (x > 7) {    //a
          x = 5;
       }
       y = 1;

       if (x > 7) {    //b
          x = 5;
          y = 1;
       }
    
       if (x > 7)      //c
          x = 5;
          y = 1;       
    
       if (x > 7) {    //d
          x = 5;
       }
       else {
          y = 1;
       }
       
       if (x > 7)      //e
          x = 5;
       else if (x <= 7) {
          y = 1;
       }
 
       if (x > 7) {    //f
          y = 1;
       }
       if (x > 7) {
          x = 5;
       }
   
#.  Same situation as the last problem, and same caution,
    except this time assume the fragments 
    appear in a function that returns an ``int``. 
    In each pair of equivalent fragments, which is your preference?  ::
    
        y = 1;         //a
        if (x > 7) {
           return x;
        }
        
        if (x > 7) {   //b
           return x;
        }
        y = 1;
        
        if (x > 7) {   //c
           return x;
        }
        else {
           y = 1;
        }
        
        if (x > 7) {   //d
           return x;
           y = 1;
        }
        
        if (x > 7) {   //e
           y = 1;
           return x;
        }
        y = 1;
        
        if (x > 7) {   //f
           return x;
        }
        
        if (x > 7);    //g
           return x;
        
        return x;      //h

#.  Same situation as the last problem, and same caution::

        if (x > 5)        //a
           if (x > 7)
               return x;
        else
           y = 1;
           
        if (x > 5)  {     //b 
           if (x > 7)
               return x;
        }
        else {
           y = 1;
        }
           
        if (x > 7)        //c
           return x;
        if (x <= 5)
           y = 1;
           
        if (x > 7)        //d
           return x;
        if (x > 5)
           y = 1;




        
        