using System;

class Birthday4
{
    static void happyBirthday(string person)
    {   
        Console.WriteLine ("Happy Birthday to you!");
        Console.WriteLine ("Happy Birthday to you!");
        Console.WriteLine ("Happy Birthday, dear " + person + ".");
        Console.WriteLine ("Happy Birthday to you!");
    }
    
    static void Main()
    {   
        happyBirthday("Emily");
        happyBirthday("Andre");
    }

}
