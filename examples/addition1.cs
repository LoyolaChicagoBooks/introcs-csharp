using System;

class Addition1
{
   static void sumProblem(int x, int y)
   {
      int sum = x + y;
      string sentence = "The sum of " + x + " and " + y + " is " + sum + ".";
      Console.WriteLine(sentence);
   }

   static void Main()
   {
      sumProblem(2, 3);
      sumProblem(12345, 53579);
      Console.Write("Enter an integer: ");
      int a = int.Parse(Console.ReadLine());
      Console.Write("Enter another integer: ");
      int b = int.Parse(Console.ReadLine());
      sumProblem(a, b);
   }
}
