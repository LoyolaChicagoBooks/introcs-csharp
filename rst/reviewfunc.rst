Chapter Review Questions
=========================

#.  Write the function definition heading for a static function called
    ``Q1`` which
    has two ``int`` parameters, ``x`` and ``y``, and returns a ``double``.
    
#.  The function above must have what kind of a statement in its body?

#.  Each of these lines has a call to the function above, ``Q1``.  Which
    are legal?  Explain::

        double d = Q1(2, 5);
        
        int x = Q1(2, 5);
        
        double y = Q1(2) + 5.5;
        
        Console.WriteLine(Q1("2", "5"));

        Console.WriteLine(Q1(2.5, 5.5));

#.  Write the function definition heading for a static function called
    ``Q4`` which
    has one ``string`` parameter, ``s``, and returns nothing.
    
#.  Which of these lines with a call to the function above, ``Q4``,
    is legal?  Explain::

        Q4("hi");
        
        string t = Q4("hi");
        
        Console.WriteLine(Q4("hi"));

        Q4("hi" + "ho");

        Q4("hi", "ho");

        Q4(2);

#.  Can you have more than one function/method in the same 
    class definition with the same name?
    
#.  What is a function/method signature?  
    Can you have more than one function/method declared in the same 
    class definition with the same signature?
    
#.  In each part, 
    is this a legal program?  If so, what is printed?  If not, why not?
    
    Each version uses the same code, except for different versions of 
    ``Main``.  Here is the common code with the body of ``Main`` omitted::

            using System;
            class Local1
            {
               static int Q(int a)
               {
                  int x = 3;
                  x = x + a;
                  return x;
               }
               
               static void Main()
               {
                  // see each version
               }
            }   

    a.  Insert::
    
               static void Main()
               {
                  Q(5);
                  Console.WriteLine(x);
               }
        
    b.  Insert instead::

               static void Main()
               {
                  int x= 1;
                  Q(5);
                  Console.WriteLine(x);
               }

    c.  Insert instead::
        
               static void Main()
               {                 
                  int x = 1, y = 2;
                  y = Q(5);
                  Console.WriteLine(x + " " + y);
               }
                  