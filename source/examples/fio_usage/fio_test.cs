using System;
using System.IO;

namespace IntroCS
{
   class FIOTests
   {
      public static void Main(string[] args)
      {
         string sample = "sample.dat";
         string output = "output.dat";
         Console.WriteLine(FIO.GetLocation(sample));
         Console.WriteLine(FIO.GetPath(sample));
         StreamReader reader1 = FIO.OpenReader(sample);
         if (reader1 != null) {
            Console.WriteLine("first reader test passed");
            reader1.Close();
         }

         StreamReader reader2 = FIO.OpenReader(FIO.GetLocation(sample), sample);
         if (reader2 != null) {
            Console.WriteLine("second reader test passed");
            reader2.Close();
         }

         StreamWriter writer1 = FIO.OpenWriter(FIO.GetLocation(sample), output);
         writer1.Close();
         Console.WriteLine("writer test passed; file written at {0}", FIO.GetPath(output));
      }
   }
}
