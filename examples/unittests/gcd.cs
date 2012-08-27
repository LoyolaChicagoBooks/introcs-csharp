using System;
using NUnit.Framework;

namespace IntroCS
{
   [TestFixture()]
   public class gcd_UnitTests
   {
      [Test()]
      public void ZeroTest()
      {
         Assert.AreEqual(Euclid.GCDEuclid(5, 0),  5);
      }

      [Test()]
      public void BasicTest()
      {
         Assert.AreEqual(Euclid.GCDEuclid(10, 5), 5);
         Assert.AreEqual(Euclid.GCDEuclid(5, 10), 5);
      }
   }
}

