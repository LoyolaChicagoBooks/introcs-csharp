Chapter Review Questions
=========================

#.  After writing everything you want to a file through a ``StreamWriter``, 
    what do you still need to remember to do?
    
#.  If you want to create a file path in an operating system independent way for 
    file f.txt in directory d2, which is a subdirectory of d1, which is a 
    subdirectory of the current directory, how would you do it?
    
#.  Windows uses ``\`` as a path separator.  If you want to write a literal
    directly for a Windows path, what issue is there in C#?
    
#.  In a file path, how do you refer to the parent directory of the 
    current directory, without using the actual name of the parent directory?
    
#.  If you are reading from a ``StreamReader`` ``inFile``, what is logically
    wrong with the following::
    
        if (inFile.ReadLine().Contains("!")) {
           Console.WriteLine(inFile.ReadLine() + "\n contains the symbol !"
        }  
