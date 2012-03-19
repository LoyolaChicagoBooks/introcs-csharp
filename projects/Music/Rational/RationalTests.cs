using System;
using NUnit.Framework;

namespace Music
{
   // Rational Unit Tests...Note: will be used for the unit testing lecture (GKT).

   [TestFixture()]
	public class RationalTests
   {
      [Test()]
      public void GetStructTests()
      {
         Rational r = Rational.GetRational(3, 5);
         Assert.IsTrue(r.Numerator == 3);
         Assert.IsTrue(r.Denominator == 5);
         r = Rational.GetRational(125);
         Assert.IsTrue(r.Numerator == 125);
         Assert.IsTrue(r.Denominator == 1);
      }

      [Test()]
      public void ParseTest()
      {
         Rational r, expecting;
         r = Rational.Parse("-12/30");

         expecting = Rational.GetRational(-12, 30);
         Assert.IsTrue(r.CompareTo(expecting) == 0);
         r = Rational.Parse("123");
         expecting = Rational.GetRational(123);
         Assert.IsTrue(r.CompareTo(expecting) == 0);
         r = Rational.Parse("1.125");
         expecting = Rational.GetRational(9, 8);
         Assert.IsTrue(r.CompareTo(expecting) == 0);
      }

      [Test()]
      public void BasicArithmeticTests() {
         Rational r, r1, r2, expecting;
         r1 = Rational.GetRational(47, 64);
         r2 = Rational.GetRational(-11, 64);

         r = r1.Add(r2);

         expecting = Rational.GetRational(36, 64);
         Assert.IsTrue(r.CompareTo(expecting) == 0);

         r = r1.Subtract(r2);
         expecting = Rational.GetRational(58, 64);
         Assert.IsTrue(r.CompareTo(expecting) == 0);

         r = r1.Multiply(r2);
         expecting = Rational.GetRational(47 * -11, 64 * 64);
         Assert.IsTrue(r.CompareTo(expecting) == 0);
         r = r1.Divide(r2);

         expecting = Rational.GetRational(47, -11);
         Assert.IsTrue(r.CompareTo(expecting) == 0);

         r = r1.Reciprocal();
         expecting = Rational.GetRational(64, 47);
         Assert.IsTrue(r.CompareTo(expecting) == 0);

         r = r1.Negate();
         expecting = Rational.GetRational(-47, 64);
         Assert.IsTrue(r.CompareTo(expecting) == 0);
      }

      [Test()]
      public void BasicComparisonTests() {
         Rational r1 = Rational.GetRational(-3, 6);
         Rational r2 = Rational.GetRational(2, 4);
         Rational r3 = Rational.GetRational(1, 2);
         Assert.IsTrue(r1.CompareTo(r2) < 0);
         Assert.IsTrue(r2.CompareTo(r1) > 0);
         Assert.IsTrue(r2.CompareTo(r3) == 0);
      }

      [Test()]
      public void ConversionTests() {
         Rational r1 = Rational.GetRational(3, 6);
         Rational r2 = Rational.GetRational(-3, 6);

         Assert.IsTrue(r1.ToDecimal() == 0.5m);
         Assert.IsTrue(r2.ToDecimal() == -0.5m);
         Assert.IsTrue(r1.ToDouble() == 0.5);
         Assert.IsTrue(r2.ToDouble() == -0.5);
         Assert.IsTrue(r1.ToString().Equals("1/2"));
      }
   }
}

