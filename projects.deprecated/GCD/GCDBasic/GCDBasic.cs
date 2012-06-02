using System;

namespace GCDBasic
{
   class MainClass
   {
      // chunk-gcd-begin
      public static int GreatestCommonDivisor (int a, int b)
      {
         int n = Math.Min (a, b);
         int gcd, i;

         i = gcd = 1;
         while (i <= n) {
            if (a % i == 0 && b % i == 0)
               gcd = i;
            i = i + 1;
         }
         return gcd;
      }
      // chunk-gcd-end


      static string InputLine (string prompt)
      {
         Console.Write (prompt);
         return Console.ReadLine ();
      }

      static int InputInt (string prompt)
      {
         string nStr = InputLine (prompt).Trim ();
         return int.Parse (nStr);
      }

      static void Main ()
      {
         int a = InputInt ("Enter an integer: ");
         int b = InputInt ("Enter another integer: ");
         Console.WriteLine ("The final result is: gcd({0}, {1}) = {2}",
                        a, b, GreatestCommonDivisor (a, b));
      }
   }
}
