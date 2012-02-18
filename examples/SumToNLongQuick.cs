using System;

class SumToNTest  // finally quick and correct
{
                              // good chunk
   /** Return the sum of the numbers from 1 through n. */
   static long SumToN(int n)
   {
      return (long)n*(n+1)/2;
   }
                              // end good chunk
   static void Main()
   {
      int n = InputInt("Enter the largest number in the sum: ");
      Console.WriteLine("The sum of 1 through {0} is {1}.", n, SumToN(n));
   }

   // standard utility functions hereafter
   
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


