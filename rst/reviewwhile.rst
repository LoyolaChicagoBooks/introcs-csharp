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
        int i = s.IndexOf("co"), j = s.IndexOf("co", i+1);
        Console.WriteLine(i + " " + j);
    
       

    
