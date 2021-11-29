Chapter Review Questions
=========================

#.  Distinguish the cases when you would want to use a list instead of an array, or 
    the other way around.

#.  What syntax is consistent between arrays and lists?  What are comparable
    features, but with different syntax?
    
#.  How is the type declaration for a generic type distinctive?

#.  Here is one way to put five particular elements into a list::

        var words = new List<string>();
        string[] temp = {"a", "an", "the", "on", "of"};
        foreach(string s in temp) {
            words.Add(s);
        }
        
    How can you do this all without a loop, and with only two statements?  
    How about with a single statement,
    assuming you do not need ``temp`` again?

#.  If we continue on from above, with the line::

        var words2 = words;
        
    Then what would be the difference in effect between these two possible next
    lines?   ::
    
        words.Clear()
        
        words = new List<string>();   
        
#.  The constructors for collections like a List are all overloaded.
    What forms are allowed in general?
    
#.  If you delete an element from the middle of a list, what happens to the
    spot where you removed the element?