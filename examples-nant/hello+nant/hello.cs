using System;

class hello
{
    static void Main (string[] args)
    {   
        string name = "";
        if (args.Length > 0)
            name = ", " + args [0];
        Console.WriteLine ("Hello{0}!", name);
    }

}


