using System;

class Addition2
{
   static string sumProblemString(int x, int y)
   {
      int sum = x + y;
      string sentence = "The sum of " + x + " and " + y + " is " + sum + ".";
      return sentence;
   }

   static void Main()
   {
      Console.WriteLine(sumProblemString(2, 3));
      Console.WriteLine(sumProblemString(12345, 53579));
      Console.Write("Enter an integer: ");
      int a = int.Parse(Console.ReadLine());
      Console.Write("Enter another integer: ");
      int b = int.Parse(Console.ReadLine());
      Console.WriteLine(sumProblemString(a, b));
   }
}

