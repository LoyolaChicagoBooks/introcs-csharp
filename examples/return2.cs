using System;

class Return2
{
   static string lastFirst(string firstName, string lastName)
   {
      string separator = ", ";
      string result = lastName + separator + firstName;
      return result;
   }

    static void Main()
    {
        Console.WriteLine(lastFirst("Benjamin", "Franklin"));
        Console.WriteLine(lastFirst("Andrew", "Harrington"));
    }
}
