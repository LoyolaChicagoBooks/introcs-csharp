Chapter Review Questions
=========================

#.  Most of C# arithmetic is just like normal math.  The exceptions are
    most important:  What are they?
    
#.  What are the consequences of numerical value types each being stored in
    a fixed amount of memory space?
    
#.  What is the order of operations if several of the same level,
    are chained together like ``x + y + z``?  
    This can matter in C# (including in a question below).
    
#.  Which of these individual 
    two-line fragments could fit into a legal C# program?  
    Explain::
    
       w = 3;
       w = 4;
       
       x = 3;
       x = x+1;
       
       y = 3;
       y = "hello";
       
       z = 3.5
       z = 3;
       
       q = 3;
       q + 1 = q;
       
#.  For the legal pairs above, what could the type of the variable have been
    declared?  You can check them in csharp, giving the declaration first.

#.  What are the final values of ``x`` and ``y``  after this fragment? ::

        int x = 3
        int y = x + 2;
        x = x + y;
        y = x + y;
        
    Test in csharp after you have decided.
    
#.  Which of these expressions are legal in C#?  
    Think of the results.
    Explain.  ::

        "a" + "b"
        "a" + 'b'
        "a" + 2
        2 + "a"
        "a" + 2 * 3;
        "a" + 2 + 3        
        2 + 3 + "a"
        2 + 3 * "a"
        
    Think first; try in csharp; reconsider if necessary.

#.  Write a single ``WriteLine`` statement that would produce output
    on two separate lines, not one.  Accomplish the same thing a second time 
    with fundamentally
    different syntax.
    
#.  What is printed?  ::

        Console.WriteLine("{1} {0} {2} {1} {0}", 'B', 2, "or not");
    
#.  Which of these casts is necessary, and which could be left out
    (and be legal and mean the same thing)? Before testing, 
    think what the values of the variables will be
    for the first two or three::

        int x= (int)5.8;
        double y = (double)6;
        char c = (char)('a' + 1)
        int z = (int)'a' + 1;
        
      

     
    

     