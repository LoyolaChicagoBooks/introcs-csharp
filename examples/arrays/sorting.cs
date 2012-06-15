using System;
using System.Diagnostics;

namespace IntroCS
{
   public class Sorting
   {
      // sort methods, a function has been created for it.
      // chunk-exchange-begin
      public static void exchange (int[] data, int m, int n)
      {
         int temporary;

         temporary = data [m];
         data [m] = data [n];
         data [n] = temporary;
      }
      // chunk-exchange-end

      // chunk-bubblesort-begin
      public static void IntArrayBubbleSort (int[] data)
      {
         int i, j;
         int N = data.Length;

         for (j=N-1; j>0; j--) {
            for (i=0; i<j; i++) {
               if (data [i] > data [i + 1])
                  exchange (data, i, i + 1);
            }
         }
      }
      // chunk-bubblesort-end

      // chunk-insertionsort-begin
      public static void IntArrayInsertionSort (int[] data)
      {
         int i, j;
         int N = data.Length;

         for (j=1; j<N; j++) {
            for (i=j; i>0 && data[i] < data[i-1]; i--) {
               exchange (data, i, i - 1);
            }
         }
      }
      // chunk-insertionsort-end

      // chunk-selectionsort-begin
      public static int IntArrayMin (int[] data, int start)
      {
         int minPos = start; 
         for (int pos=start+1; pos < data.Length; pos++)
            if (data [pos] < data [minPos])
               minPos = pos;
         return minPos; 
      }

      public static void IntArraySelectionSort (int[] data)
      {
         int i;
         int N = data.Length;

         for (i=0; i < N-1; i++) {
            int k = IntArrayMin (data, i);
            if (i != k)
               exchange (data, i, k);
         }
      }
      // chunk-selectionsort-end

      // chunk-shellsort-begin
      public static void IntArrayShellSort (int[] data, int[] intervals)
      {
         int i, j, k, m;
         int N = data.Length;

         // The intervals for the shell sort must be sorted, ascending

         for (k=intervals.Length-1; k>=0; k--) {
            int interval = intervals [k];
            for (m=0; m<interval; m++) {
               for (j=m+interval; j<N; j+=interval) {
                  for (i=j; i>=interval && data[i]<data[i-interval]; i-=interval) {
                     exchange (data, i, i - interval);
                  }
               }
            }
         }
      }
      // chunk-shellsort-end


      // chunk-shellsort-naive-begin
      public static void IntArrayShellSortNaive (int[] data)
      {
         int[] intervals = { 1, 2, 4, 8 };
         IntArrayShellSort (data, intervals);
      }
      // chunk-shellsort-naive-end

      // chunk-shellsort-better-begin
    
      static int[] GenerateIntervals (int n)
      {
         if (n < 2) {  // no sorting will be needed
            return new int[0];
         }
         int t = Math.Max (1, (int)Math.Log (n, 3) - 1);
         int[] intervals = new int[t];       
         intervals [0] = 1;
         for (int i=1; i < t; i++)
            intervals [i] = 3 * intervals [i - 1] + 1;
         return intervals;
      }

      public static void IntArrayShellSortBetter (int[] data)
      {
         int[] intervals = GenerateIntervals (data.Length);
         IntArrayShellSort (data, intervals);
      }

      // chunk-shellsort-better-end

      // chunk-quicksort-begin
      public static void IntArrayQuickSort (int[] data, int l, int r)
      {
         int i, j;
         int x;
 
         i = l;
         j = r;

         x = data [(l + r) / 2]; /* find pivot item */
         while (true) {
            while (data[i] < x)
               i++;
            while (x < data[j])
               j--;
            if (i <= j) {
               exchange (data, i, j);
               i++;
               j--;
            }
            if (i > j)
               break;
         }
         if (l < j)
            IntArrayQuickSort (data, l, j);
         if (i < r)
            IntArrayQuickSort (data, i, r);
      }

      public static void IntArrayQuickSort (int[] data)
      {
         IntArrayQuickSort (data, 0, data.Length - 1);
      }
      // chunk-quicksort-end

      /*
       * This program is designed to run from the command line.
       * args[0] array size, integer. If no argument is specified,
       * user will be prompted.
       */


      // chunk-random-begin
      public static void IntArrayGenerate (int[] data, int randomSeed)
      {
         Random r = new Random (randomSeed);
         for (int i=0; i < data.Length; i++)
            data [i] = r.Next ();
      }

      // chunk-random-end
                                                 
      // chunk-driver-begin
      public static void Main (string[] args)
      {
         // chunk-drivervars-begin
         int arraySize;
         int randomSeed;
         Stopwatch watch = new Stopwatch ();
         double elapsedTime;  // time in second, accurate to about millseconds
         // chunk-drivervars-end

         // chunk-driverparameters-begin
         if (args.Length < 2) {
            arraySize = Input.InputInt("Please enter desired array size: ");
            randomSeed = Input.InputInt(
               "Please enter an initial random seed value: ");
         } else {
            arraySize = int.Parse (args [0]);
            randomSeed = int.Parse (args [1]);
         }
         // chunk-driverparameters-end

         int[] data = new int[arraySize];

         IntArrayGenerate (data, randomSeed);
         watch.Reset ();
         watch.Start ();
         IntArrayQuickSort (data);
         watch.Stop ();
         elapsedTime = watch.ElapsedMilliseconds/1000.0;
         Console.WriteLine ("Quick Sort: {0:F3}", elapsedTime);

         IntArrayGenerate (data, randomSeed);
         watch.Reset ();
         watch.Start ();
         IntArrayShellSortNaive (data);
         watch.Stop ();
         elapsedTime = watch.ElapsedMilliseconds/1000.0;
         Console.WriteLine ("Naive Shell Sort: {0:F3}", elapsedTime);

         IntArrayGenerate (data, randomSeed);
         watch.Reset ();
         watch.Start ();
         IntArrayShellSortBetter (data);
         watch.Stop ();
         elapsedTime = watch.ElapsedMilliseconds/1000.0;
         Console.WriteLine ("Better Shell Sort: {0:F3}", elapsedTime);

         IntArrayGenerate (data, randomSeed);
         watch.Reset ();
         watch.Start ();
         IntArrayInsertionSort (data);
         watch.Stop ();
         elapsedTime = watch.ElapsedMilliseconds/1000.0;
         Console.WriteLine ("Insertion Sort: {0:F3}", elapsedTime);

         IntArrayGenerate (data, randomSeed);
         watch.Reset ();
         watch.Start ();
         IntArraySelectionSort (data);
         watch.Stop ();
         elapsedTime = watch.ElapsedMilliseconds/1000.0;
         Console.WriteLine ("Selection Sort: {0:F3}", elapsedTime);
         
         // chunk-driverapparatus-begin
         IntArrayGenerate (data, randomSeed);
         watch.Reset ();
         watch.Start ();
         IntArrayBubbleSort (data);  // the other experiments call a different method
         watch.Stop ();
         elapsedTime = watch.ElapsedMilliseconds/1000.0;
         Console.WriteLine ("Bubble Sort: {0:F3}", elapsedTime);
         // chunk-driverapparatus-end

       }
      // chunk-driver-end
   }
}
