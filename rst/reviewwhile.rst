Chapter Review Questions
=========================

#.  While loops are a very important part of your programming tools.  
    Put in your own words:  when should you think to use a while loop?
    
#.  Loops are also among the hardest things for many students --
    with lots of things to think about.  
    There is a sequence of general process questions that you can ask yourself 
    to help you organize your work.  What are they in your words?
    Do you know them well, or have them written down in a place you
    can easily jump to?
    
#.  Compare do-while and while loops: 
    How do you think about which one to use?
    
#.  In an interactive while loop you need to continuously get data 
    from the user.  Where do you generally put the code to get more data?

#.  In general, what causes an infinite ``while`` loop?

#.  What is wrong with this statement:  When the condition in a ``while`` loop
    heading becomes false, the loop statement immediately terminates.
    
#.  A ``while`` loop will terminate when the program evaluates the
    condition in its heading and the value becomes false.  
    What is the important difference in this statement from the previous
    incorrect statement?
    
#.  When does a program evaluate the condition in a ``while`` loop heading? 
    (There are two situations.)

#.  A ``while`` loop is generally terminated when the program evaluates the
    condition in its heading and it becomes false.  
    How else can a program exit from a ``while`` loop?

#.  We generally construct a loop so its body is a compound statement,
    composed of a sequence of statements inside.  If this body is a sequence of
    simple statements, does it make sense for
    one of them to be a return statement?
    
#.  When inside a loop,
    a return statement should generally only appear as a *sub-statement*
    of what kind of statement?
    
#.  Which of these conditions is safer in general, with *arbitrary* 
    ``string`` ``s`` and 
    ``int`` ``i``?  ::

         s[i] != '#' && i >= 0 && i < s.Length
         
         i >= 0 && i < s.Length && s[i] != '#' 
         
#.  What is printed?  ::

        //          012345678901234567890
        string s = "Is coding cool?  Yes!"
        Console.WriteLine(s.Trim()); 
        string t = s.Substring(9, 8);
        Console.WriteLine(t.Replace(" ", "/")); 
        Console.WriteLine(t.Trim().Replace(" ", "/")); 
        Console.WriteLine(s.StartsWith("is"));
        Console.WriteLine(s.ToLower().StartsWith("is"));
        int i = s.IndexOf("co"), j = s.IndexOf("co", i+1),
            k = s.IndexOf("co", j+1);
        Console.WriteLine(i + " " + j + " " + k);
    
       

    
