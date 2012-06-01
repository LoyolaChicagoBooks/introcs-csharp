using System;
namespace IntroCS
{
   class Addition3  // using UIF
   {
      static string sumProblemString(int x, int y)
      {
         int sum = x + y;
         string sentence = "The sum of " + x + " and " + y + " is " + sum + ".";
         return sentence;
      }
      
      public static void Main()
      {
         Console.WriteLine(sumProblemString(2, 3));
         Console.WriteLine(sumProblemString(12345, 53579));
         Console.Write("Enter an integer: ");
         int a = UIF.PromptInt("Enter an integer: ");      //NEW
         int b = UIF.PromptInt("Enter another integer: "); //NEW
         Console.WriteLine(sumProblemString(a, b));
      }
   }
}
