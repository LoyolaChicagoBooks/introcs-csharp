using System;
using NUnit.Framework;

namespace Music
{
   [TestFixture()]
	public class NoteTests
   {
      [Test()]
      public void TestConstructor()
      {
         Note n = new Note(0, 0, new Rational(1, 4));
         Rational r = n.GetDuration();
         Assert.IsTrue(r.CompareTo(new Rational(1, 4)) == 0);
      }
   }

   [TestFixture()]
   public class MeasureTests
   {
      [Test()]
      public void TestAdditionOfNotes()
      {
         // Create a measure in 3/4 time.
         Measure m = new Measure(new Rational(3, 4));
         Note q = new Note(0, 0, new Rational(1, 4));
         bool ok;
         ok = m.AddNote(q);
         Assert.IsTrue(ok);
         Assert.IsTrue( m.Length().CompareTo(new Rational(1, 4)) == 0 );

         ok = m.AddNote(q);
         Assert.IsTrue(ok);
         Assert.IsTrue( m.Length().CompareTo(new Rational(2, 4)) == 0 );

         ok = m.AddNote(q);
         Assert.IsTrue(ok);
         Assert.IsTrue( m.Length().CompareTo(new Rational(3, 4)) == 0 );

         // This last addition should *not* be ok and should not change the length from 3/4 to anything else.
         ok = m.AddNote(q);
         Assert.IsFalse(ok);
         Assert.IsTrue( m.Length().CompareTo(new Rational(3, 4)) == 0 );
      }
   }

   [TestFixture()]
   public class ScaleTests
   {
      [Test()]
      public void TestScaleGeneration() {
         Scale cscale = new Scale("C", Scale.ScaleTypes.Major);
         int[] cintervals = { 0, 2, 4, 5, 7, 9, 11, 0 };
         for (int i=0; i < 8; i++)
            Assert.AreEqual(cscale.GetTone(i), cintervals[i]);

         Scale dscale = new Scale("D", Scale.ScaleTypes.Major);
         int[] dintervals = { 2, 4, 6, 7, 9, 11, 1, 2 };
         dscale.Output();
         for (int i=0; i < 8; i++) {
            Console.WriteLine("i={0} actual={1} expected={2}", i, dscale.GetTone(i), dintervals[i]);
            Assert.AreEqual(dscale.GetTone(i), dintervals[i]);
         }
      }
   }
}

