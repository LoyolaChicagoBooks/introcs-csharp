using System;

namespace GCDSubtractionMethod
{
   class MainClass
   {
      // chunk-gcd-begin
      public static int GreatestCommonDivisor (int a, int b)
      {
         int c;
         while (a != b) {
            while (a > b) {
               c = a - b;
               a = c;
            }
            while (b > a) {
               c = b - a;
               b = c;
            }
         }
         return a;
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
