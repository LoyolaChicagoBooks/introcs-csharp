using System;

class SumToNTest
{

   /** Return the sum of the numbers from 1 through n. */
   static long SumToN(int n)  //CHANGED:  returns long
   {
      long sum = 1, i = 2;    //CHANGED:  sum is long
      while (i <= n) {
         sum = sum + i;
         i = i + 1;
//         if (sum < 0) return -i;
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


