using System;
using System.Collections.Generic;

namespace IntroCS
{
   /** Use IComparable<Rational> interface to sort Rationals. */
   class MainClass
   {
      public static void Main(string[] args)
      {
         List<Rational> nums = new List<Rational>();
         nums.Add(new Rational(11, 3));
         nums.Add(new Rational(2, 5));
         nums.Add(new Rational(2, 3));
         nums.Add(new Rational(1, 3));
         PrintList(nums);
         nums.Sort();
         PrintList(nums);
      }

      public static void PrintList(List<Rational> list)
      {
         foreach (Rational r in list)
         {
            Console.Write(r + " ");
         }
         Console.WriteLine();
      }
   }
}
