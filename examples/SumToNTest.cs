using System;

class SumToNTest
{

   /** Return the sum of the numbers from 1 through n. */
   static int SumToN(int n)
   {
      int sum = 1, i = 2;
      while (i <= n) {
         sum = sum + i;
         i = i + 1;
      }
      return sum;
   }

   static void Main()
   {
      int n = InputInt("Enter the largest number in the sum: ");
      Console.WriteLine("The sum of 1 through {0} is {1}.", n, SumToN(n));
   }

   static string InputLine(string prompt)
   {
      Console.Write(prompt);
      return Console.ReadLine();
   }

   static int InputInt(string prompt)
   {
      string nStr = InputLine(prompt).Trim(); //Removes blanks at either end
      return int.Parse(nStr);
   }
}


