using System;
using System.IO;

namespace Files
{
   class SumFile
   {
      public static void Main(string[] args)
      {
         if (args.Length == 0){
            Console.WriteLine(
               "Expect on command line: a file name for a file of integers!");

         }
         else if (File.Exists(args[0])) {
            Console.WriteLine("The sum is {0}", CalcSum(args[0]));
         }
         else {
            Console.WriteLine("Bad file name {0}", args[0]);
         }
      }

      /** Read the named file and
       * print the sum of an int from each line
       * that is not just white space. */
      static int CalcSum(string filename)
      {
         int sum = 0;
         var reader = new StreamReader(filename);
         while (!reader.EndOfStream) {
            string sVal = reader.ReadLine().Trim();
            if (sVal.Length > 0) {
               sum += int.Parse(sVal);
            }
         }
         reader.Close();
         return sum;
      }
   }
}
