Chapter Review Questions
=========================

#.  What is printed by this fragment?  ::

        string s = "question";
        Console.WriteLine(s.Length);
        Console.WriteLine(s[2]);
        Console.WriteLine(s.Substring(2, 3));
        Console.WriteLine(s.Substring(3));
        Console.WriteLine(s.IndexOf("ti"));
        Console.WriteLine(s.IndexOf("to"));
        int j = s.IndexOf("u"), k = s.IndexOf("o");
        Console.WriteLine("{0} {1} {2}", j, k, s.Substring(j, k-j));

#.  What is printed by this fragment?  ::

        string s = "Word";
        s.ToUpper();
        Console.WriteLine(s);

#.  What is printed by this fragment?   ::

        string a = "hi", b = a.ToUpper();
        Console.WriteLine(a+b);

#.  Are strings mutable or immutable: which?

#.  What is the distinction syntactically between the use of a
    method and a property?
    
#.  Suppose we have a string ``s``.
    Is this expression legal, or what should it be?  ::
    
        s.Length()
    
        
