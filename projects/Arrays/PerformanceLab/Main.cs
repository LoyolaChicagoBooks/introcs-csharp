using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Arrays
{
	public class PerformanceLab
	{
		// chunk-experiment1-begin
		public static TimeSpan ExperimentIntArrayLinearSearch (int n, int m, int seed)
		{
			Stopwatch watch = new Stopwatch ();
			int[] data = new int[n];
			Sorting.IntArrayGenerate (data, seed);
			watch.Reset ();			
			watch.Start ();
			// perform the m lookups
			for (int i=0; i < data.Length; i += m) {
				var datum = Searching.IntArrayLinearSearch (data, data [i]);
			}
			watch.Stop ();
			return watch.Elapsed;
		}
		// chunk-experiment1-end
		
		public static TimeSpan ExperimentIntArrayBinarySearch (int n, int m, int seed)
		{
			Stopwatch watch = new Stopwatch ();
			int[] data = new int[n];
			Sorting.IntArrayGenerate (data, seed);
			/* Use our existing work on sorting to generate sorted array for testing */
			Sorting.IntArrayQuickSort (data);
			watch.Reset ();			
			watch.Start ();
			// perform the m lookups
			for (int i=0; i < data.Length; i += m) {
				var datum = Searching.IntArrayBinarySearch (data, data [i]);
			}
			watch.Start ();
			watch.Stop ();
			return watch.Elapsed;
		}
				
		public static TimeSpan ExperimentListSearch (int n, int m, int seed)
		{
			Stopwatch watch = new Stopwatch ();
			int[] data = new int[n];
			Sorting.IntArrayGenerate (data, seed);
			List<int> dataAsList = new List<int> (data);
			watch.Reset ();			
			watch.Start ();
			for (int i=0; i < data.Length; i += m) {
				var datum = dataAsList [data [i]];
			}
			watch.Stop ();
			return watch.Elapsed;
		}

		public static TimeSpan ExperimentDictionarySearch (int n, int m, int seed)
		{
			Stopwatch watch = new Stopwatch ();
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int[] data = new int[n];
			Random r = new Random(randomSeed);
         	for (int i=0; i < n; i++) {
				do {
					var randomValue = r.Next ();
				} while (dictionary.ContainsKey(randomValue));
				dictionary[randomValue] = randomValue;
				data[i] = randomValue;
			}			
			watch.Reset ();			
			watch.Start ();
			for (int i=0; i < data.Length; i += m) {
				var datum = dictionary [data [i]];
			}
			watch.Stop ();
			return watch.Elapsed;
		}
		
		// chunk-printelapsedtime-begin
		public static void PrintElapsedTime (string description, TimeSpan ts)
		{
			// student will customize this output to produce/calculate seconds
			// so all timings can be procecessed, say, with Excel or another spreadsheet
			// program
			
			string elapsedTime = String.Format ("{0:00}:{1:00}:{2:00}.{3:00}",
            	ts.Hours, ts.Minutes, ts.Seconds,
            	ts.Milliseconds / 10);
			Console.WriteLine ("{0} {1}", description, elapsedTime);
		}
		// chunk-printelapsedtime-end
		
		public static void Main (string[] args)
		{
			// student will write the code to parse args for the parameters
			
			// student will write the code to run each of the experiments
			
			// student will write the code to output the times and format the TimeSpan output
			// for external processing
		}
	}
}
