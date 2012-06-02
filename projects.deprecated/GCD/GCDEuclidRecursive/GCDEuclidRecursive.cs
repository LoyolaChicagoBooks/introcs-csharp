using System;

namespace GCDEuclidRecursive
{
   class MainClass
   {
      // chunk-gcd-begin
      public static int GreatestCommonDivisor (int a, int b)
      {
         if (b == 0) {
            Console.WriteLine ("gcd({0}, {1}) = {0}", a, b);
            return a;
         } else {
            Console.WriteLine (
            "gcd({0}, {1}) = gcd({1}, {0} mod {1} = gcd({1}, {2})",
             a, b, a % b);
            return GreatestCommonDivisor (b, a % b);
         }
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
