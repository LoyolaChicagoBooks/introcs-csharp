using System;

namespace Music
{
   /*
    * Class for fractions (rational numbers),
    * including basic arithmetic operations.
    */
   public struct Rational
   {
      private int num, denom; // invariant: denom > 0, fraction is reduced to lowest terms

      /* With structs, it does not make sense to have constructors as you can only call them on dynamically
       * allocated instances. So we provide two static methods to get a "value" instance of Rational:
       * GetRational(int numerator, int denominator) and GetRational(int number)
       *
       * The best way to work with Rational structs, however, is as follows:
       *    Rational r;
       *    r.Numerator = 3
       *    r.Denominator = 6
       *
       * If you do not set the denominator (which starts at 0), it will be normalized the first time
       * property Numerator is set.
       *
       * After this, the Rational will have the value 1/2, thanks to the existing normalize() function.
       * These methods are provided to approximate the convenience of a constructor.
       *
       * All situations where we previously had "new" have been replaced by one of these two methods
       * to ensure no wasteful dynamic allocation takes place.
       */

      public int Numerator {
         get {
            return num;
         }
         set {
            num = value;
            normalize();
         }
      }

      public int Denominator {
         get {
            return denom;
         }
         set {
            denom = value;
            normalize();
         }
      }

      public static Rational GetRational(int numerator, int denominator)
      {
         Rational r;
         r.num = numerator;
         r.denom = denominator;
         r.normalize();
         return r;
      }

      public static Rational GetRational(int numerator)
      {
         Rational r;
         r.num = numerator;
         r.denom = 1;
         r.normalize();
         return r;
      }

      /** Parse a string of an integer, fraction (with /) or decimal (with .)
       *  and return the corresponding Rational. */
      public static Rational Parse(string s)
      {
         s = s.Trim();
         string[] parts = {s, "1"};
         if (s.Contains("/")) {
            parts = s.Split('/');
         } else if (s.Contains(".")) {
               parts = s.Split('.');
               string zeros = "";
               foreach (char dig in parts[1]) {
                  zeros += "0";
               }
               parts[0] += parts[1];
               parts[1] = "1" + zeros;
            }

         Rational result;
         result.num = int.Parse(parts[0].Trim());
         result.denom = int.Parse(parts[1].Trim());
         result.normalize();
         return result;
      }



      /**
       * Return a string of the fraction in lowest terms,
       * omitting the denominator if it is 1.
       */
      public override string ToString()
      {
         if (denom != 1)
            return string.Format("{0}/{1}", num, denom);
         return "" + num;
      }
   
      /** Return a double approximation to the fraction. */
      public double ToDouble()
      {
         return ((double)num) / denom;
      }
   
      /** Return a decimal approximation to the fraction. */
      public decimal ToDecimal()
      {
         return ((decimal)num) / denom;
      }
   
      /** Return a new Rational which is this Rational negated.*/
      public Rational Negate()
      {
         return GetRational(-num, denom);
      }
   
      /** Return a new Rational which is the reciprocal of this Rational.*/
      public Rational Reciprocal()
      {
         return GetRational(denom, num);
      }
   
      /** Return a new Rational which is the product of this Rational and f. */
      public Rational Multiply(Rational f)
      {
         return GetRational(num * f.num, denom * f.denom);
      }
   
      /** Return a new Rational which is the quotient of this Rational and f. */
      public Rational Divide(Rational f)
      {
         return GetRational(num * f.denom, denom * f.num);
      }
   
      /** Return a new Rational which is the sum of this Rational and f. */
      public Rational Add(Rational f)
      {
         return GetRational(num * f.denom + denom * f.num, denom * f.denom);
      }

      /** Return a new Rational which is the difference of this Rational and f.*/
      public Rational Subtract(Rational f)
      {
         return GetRational(num * f.denom - denom * f.num, denom * f.denom);
      }
   
      /**
       * Return a number that is positive, zero or negative, respectively, if
       *   the value of this Rational is bigger than f,
       *   the values of this Rational and f are equal or
       *   the value of this Rational is smaller than f.
       */
      public int CompareTo(Rational f)
      {
         return num * f.denom - denom * f.num;
      }
   
      /* Return the positive greatest common divisor of parameters a and b.*/
      private static int gcd(int a, int b)
      {  // assume not both a, b are 0
         if (a == 0)
            return Math.Abs(b);
         while (b != 0) {  // Euclid's algorithm
            int remainder = a % b;
            a = b;
            b = remainder;
         }
         return Math.Abs(a);
      }
   
      /* Force the invarient: in lowest terms with a positive denominator.*/
      private void normalize()
      {
         if (denom == 0) { // We really should force an Exception, but we won't.
            Console.WriteLine("Zero denominator changed to 1!");
            denom = 1;
         }
         int n = gcd(num, denom);
         num /= n;         // lowest
         denom /= n;       //    terms
         if (denom < 0) {  // make denom positive
            denom = -denom;
            num = -num;
         }
      }
   }
}
