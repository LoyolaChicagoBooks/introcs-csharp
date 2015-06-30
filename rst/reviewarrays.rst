Chapter Review Questions
=========================

#.  When do you want to use an array rather than just 
    a bunch of individually named variables?

#.  Before writing a program, must you know the exact size of an array that
    you are going to create?
    
#.  Before creating a new array in a program, 
    must the program be able to calculate the proper size for the array?
    
#.  After you have created the array, can you change the size of the original
    array object?
    
#.  If I have the declaration  ::

        int[] vals = new int[5];
        
    a.  What is stored directly in the memory position for variable ``vals``?
    b.  Does ``vals[3]`` then have a clear value?  If so, what?
    c.  Can I later make ``vals`` refer to an array of a different size?

#.  Comment on the comparison between these two snippets::

        char[] a = {'n', 'o', 'w'};
        a[0] = 'c';
        
        string s = "now";
        s[0] = 'c';

#.  If I want to read or modify the first 100 elements of a 999 element
    array, would I use a
    ``foreach`` loop or a ``for`` loop? Explain.
            
#.  If I want to modify all the elements of an array, would I use a
    ``foreach`` loop or a ``for`` loop? Explain.

#.  If I want to read all the elements of an array, but not change the array,
    and I do not care about the exact position in the array of any member,
    would I use a ``foreach`` loop or a ``for`` loop? 
    
#.  Is this legal?  ::

        int[] a= {1, 2, 3, 4};
        //...
        a = new int[7]; 
          
#.  The definition of a program's ``Main`` method may optionally
    include a parameter.  What is the type?  How is it used?
    
#.  What is an alias?  Why is understanding aliases important with arrays?

#.  If I have a function declared  ::

        static void f(int num)
        //...
        
    and I call it from my ``Main`` function ::
    
        int v = 7;
        f(v);
        Console.WriteLine(v);
        
    Could ``f`` change the value of the variable ``v``, so 1 is printed
    in ``Main``?
    If so, write a one-line body for ``f`` that does it.
    
#.  If I have a function declared  ::

        static void f(int[] nums)
        //...
        
    and I call it from my ``Main`` function ::
    
        int[] v = {7, 8, 9};
        f(v);
        Console.WriteLine(v[0]);
        
    Could ``f`` change the value of the variable ``v[0]``, so 1 is printed
    in ``Main``?
    If so, write a one-line body for ``f`` that does it.
    
#.  What is printed by this snippet? ::

       int[] a = {1, 2, 3};
       int[] b = {4, 5, 6};
       b[0] = 7; 
       a[1] = 8; 
       b[2] = 9;
       Console.WriteLine("" + a[0] + a[1] + a[2]);

#.  What is printed by this snippet? (Only the second line is changed.)  ::

       int[] a = {1, 2, 3};
       int[] b = a;
       b[0] = 7; 
       a[1] = 8;  
       b[2] = 9;
       Console.WriteLine("" + a[0] + a[1] + a[2]);

#.  If my only use for variable ``temp`` is to set up this call to ``f``::

       int[] temp = {1, 2, 3};
       f(temp);
       
    how could I rewrite it with an anonymous array?
    
#.  After this line, what is the value of ``a[2]``?  ::
    
        bool[] a = new bool[5];

#.  This will cause a runtime error.  Why? ::
    
        string[] a = new string[5];
        foreach(string s in a) {
           Console.WriteLine(s.Length);
        }
      
#.   If you get a data sequence from a ``Random`` object, 
     is it really random?
     
#.   Explain the significance of a *seed* for a ``Random`` object.

#.   Suppose I create an object ``table`` of type ``double[,]``,
     and I think of the first index as referring to a row and the second
     index as referring to a column.
        
     a.  Must each row be the same length? 
     b.  Does each row have a type ``double[]`` ? 

#.   (Optional) Suppose I create an object ``table`` of type ``double[][]``,
     and I think of the first index as referring to a row and the second
     index as referring to a column.
        
     a.  Must each each row be the same length? 
     b.  Does each row have a type ``double[]`` ? 
