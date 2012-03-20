using System;

namespace Music
{
   public class TestRational
   {
      public static void Main()
      {
         ShowParse("-12/30");
         ShowParse("123");
         ShowParse("1.125");
         Rational f = new Rational(6, -10);
         Console.WriteLine("6/(-10) simplifies to {0}", f);
         Console.WriteLine("reciprocal of {0} is {1}", f, f.Reciprocal());
         Console.WriteLine("{0} negated is {1}", f, f.Negate());
         Rational h = new Rational(1,2);
         Console.WriteLine("{0} + {1} is {2}", f, h, f.Add(h));
         Console.WriteLine("{0} - {1} is {2}", f, h, f.Subtract(h));
         Console.WriteLine("{0} * {1} is {2}", f, h, f.Multiply(h));
         Console.WriteLine("({0}) / ({1}) is {2}", f, h, f.Divide(h));
         Console.WriteLine("{0} > {1} ? {2}", h, f, (h.CompareTo(f) > 0));
         Console.WriteLine("{0} as a double is {1}", f, f.ToDouble());
         Console.WriteLine("{0} as a decimal is {1}", h, h.ToDecimal());
      }

      static void ShowParse(string s)
      {
         Console.WriteLine("Parse \"{0}\" to Rational: {1}",
                           s, Rational.Parse(s));
      }
   }
}