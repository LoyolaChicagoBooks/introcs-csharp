using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Arrays
{
   public class PerformanceLab
   {
      // chunk-experiment1-begin
      public static long ExperimentIntArrayLinearSearch (int n, int rep, int seed)
      {
         Stopwatch watch = new Stopwatch ();
         int[] data = new int[n];
         Sorting.IntArrayGenerate (data, seed);
         watch.Reset ();       
         watch.Start ();
         int m = Math.Max(1, n/rep);
         // perform the rep lookups
         for (int k=0, i=0; k < rep; k++, i=(i+m)%n) {
            Searching.IntArrayLinearSearch (data, data [i]);
         }
         watch.Stop ();
         return watch.ElapsedMilliseconds;
      }
      // chunk-experiment1-end
    
      public static long ExperimentIntArrayBinarySearch (int n, int rep, int seed)
      {
         Stopwatch watch = new Stopwatch ();
         int[] data = new int[n];
         Sorting.IntArrayGenerate (data, seed);
         /* Use our existing work on sorting to generate sorted array for testing */
         Sorting.IntArrayQuickSort (data);
         watch.Reset ();       
         watch.Start ();
         int m = Math.Max(1, n/rep);
         // perform the rep lookups
         for (int k=0, i=0; k < rep; k++, i=(i+m)%n) {
            BinarySearching.IntArrayBinarySearch (data, data [i]);
         }
         watch.Start ();
         watch.Stop ();
         return watch.ElapsedMilliseconds;
      }
          
      public static long ExperimentListSearch (int n, int rep, int seed)
      {
         Stopwatch watch = new Stopwatch ();
         int[] data = new int[n];
         Sorting.IntArrayGenerate (data, seed);
         List<int> dataAsList = new List<int> (data);
         watch.Reset ();       
         watch.Start ();
         int m = Math.Max(1, n/rep);
         // perform the rep lookups
         for (int k=0, i=0; k < rep; k++, i=(i+m)%n) {
            dataAsList.Contains(data [i]);
         }
         watch.Stop ();
         return watch.ElapsedMilliseconds;
      }

      public static long ExperimentSetSearch (int n, int rep, int seed)
      {
         var watch = new Stopwatch ();
         var data = new int[n];
         Sorting.IntArrayGenerate (data, seed);         
         var myset = new HashSet<int> (data);
         watch.Reset ();       
         watch.Start ();
         int m = Math.Max(1, n/rep);
         // perform the rep lookups
         for (int k=0, i=0; k < rep; k++, i=(i+m)%n) {
            myset.Contains(data [i]);
         }
         watch.Stop ();
         return watch.ElapsedMilliseconds;
      }
    
      public static void Main (string[] args)
      {
         // Write the code to parse args for the parameters
         // rep n1 n2 n3 ...
       
         // Write the code to run each of the experiments for rep and
         // a value of n
       
         // Generate a comparative table for all values fo n specified.
      }
      
      /** Return a line from the keyboard in response to prompt. */
      public static string InputLine(string prompt)
      {
        Console.Write(prompt);
        return Console.ReadLine();
      }
  
      // Input functions follow...
      
      /** True when s consists of only 1 or more digits. */
      public static bool IsDigits(string s)
      {
         foreach( char ch in s) {
            if (ch <'0' || ch > '9') {
               return false;
            }
       }
         return (s.Length > 0);
      }

      /** True if s is the string form of an int. */
      public static bool IsIntString(string s)
      {
         if (s.StartsWith("-")) {
            s = s.Substring(1);
         }
         return IsDigits(s);
      }

      /** Prompt the user to enter an integer until the response is legal.
          Return the result as in int. */
      public static int InputInt(string prompt)
      {
         string nStr = InputLine(prompt).Trim();
         while (!IsIntString(nStr)) {
            Console.WriteLine("Bad int format!  Try again.");
            nStr = InputLine(prompt).Trim();
         }
         return int.Parse(nStr);
      }
                                                 

   }
}
