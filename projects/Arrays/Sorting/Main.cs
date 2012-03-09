using System;
using System.Diagnostics;


namespace Sorting
{

   class MainClass
   {
      /* This method swaps two items in the array during sorting. As we neeed to do this in multiple
       * sort methods, a function has been created for it.
       */

      // chunk-exchange-begin
      static void exchange(int[] data, int m, int n) {
         int temporary;

         temporary = data[m];
         data[m] = data[n];
         data[n] = temporary;
      }
      // chunk-exchange-end

      // chunk-bubblesort-begin
      public static void IntArrayBubbleSort(int[] data) {
         int i,j;
         int N= data.Length;

         for (j=N-1;j>0;j--) {
            for (i=0;i<j;i++) {
               if (data[i] > data[i+1])
                  exchange(data, i,i+1);
            }
         }
      }
      // chunk-bubblesort-end

      // chunk-insertionsort-begin
      public static void IntArrayInsertionSort(int[] data) {
         int i,j;
         int N=data.Length;

         for (j=1;j<N;j++) {
            for (i=j; i>0 && data[i] < data[i-1]; i--) {
               exchange(data, i,i-1);
            }
         }
      }
      // chunk-insertionsort-end

      // chunk-selectionsort-begin
      public static int IntArrayMin(int[] data, int start) {
         int minPos = start; 
         for (int pos=start+1; pos < data.Length; pos++)
            if (data[pos] < data[minPos])
               minPos = pos;
         return minPos; 
      }

      public static void IntArraySelectionSort(int[] data) {
         int i;
         int N = data.Length;

         for (i=0; i < N-1; i++) {
            int k = IntArrayMin(data, i);
            if (i != k)
               exchange(data, i, k);
         }
      }
      // chunk-selectionsort-end

      // chunk-shellsort-begin
      static void IntArrayShellSort(int[] data, int[] intervals) {
         int i, j, k, m;
         int N=data.Length;

         // The intervals for the shell sort must be sorted, ascending

         for (k=intervals.Length-1;k>=0;k--) {
            int interval = intervals[k];
            Console.WriteLine("Interval {0}", interval);
            for (m=0;m<interval;m++) {
              for (j=m+interval;j<N;j+=interval) {
                  for (i=j;i>=interval && data[i]<data[i-interval];i-=interval) {
                     exchange(data, i,i-interval);
                  }
               }
            }
         }
      }
      // chunk-shellsort-end


      // chunk-shellsort-naive-begin
      static void IntArrayShellSortNaive(int[] data) {
         int[] intervals = { 1, 2, 4, 8 };
         IntArrayShellSort(data, intervals);
      }
      // chunk-shellsort-naive-end

      // chunk-shellsort-better-begin
      static void IntArrayShellSortBetter(int[] data) {
         if (data.Length < 10000) {

            int[] intervals = { 1, 3, 5, 7 };
            IntArrayShellSort(data, intervals);
         } else {
            int[] intervals = { 1, 3, 5, 7, data.Length / 7, data.Length / 5 };
            IntArrayShellSort(data, intervals);
         }
      }
      // chunk-shellsort-better-end

      // chunk-quicksort-begin
      public static void IntArrayQuickSort(int[] data, int l, int r, int depth) {
         int i, j;
         int x;
 
         i = l;
         j = r;

         //Console.WriteLine("l={0} r={1} stackdepth={2}", l, r, depth);
         x = data[(l+r) / 2]; /* find pivot item */
         while (true) {
            while (data[i] < x)
               i++;
            while (x < data[j])
               j--;
            if (i <= j) {
               exchange(data, i, j);
               i++;
               j--;
            }
            if (i > j)
               break;
         }
         if (l < j)
            IntArrayQuickSort(data, l, j, depth+1);
         if (i < r)
            IntArrayQuickSort(data, i, r, depth+1);
      }

      public static void IntArrayQuickSort(int[] data) {
         IntArrayQuickSort(data, 0, data.Length-1, 0);
      }
      // chunk-quicksort-end

      /*
       * This program is designed to run from the command line.
       * args[0] array size, integer. If no argument is specified,
       * user will be prompted.
       */


      // chunk-random-begin

      public static void IntArrayGenerate(int[] data, int randomSeed) {
         Random r = new Random(randomSeed);
         for (int i=0; i < data.Length; i++)
            data[i] = r.Next();
      }

      // chunk-random-end

      // chunk-printtime-begin
      public static void PrintElapsedTime(string description, TimeSpan ts) {
         string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
         Console.WriteLine("{0} {1}", description, elapsedTime);
      }
      // chunk-printtime-end

      // chunk-sortcheck-begin
      public static void SortCheckHeuristic(int[] data) {
         if (data.Length == 0)
            return;
         int sum = data[0];
         bool isSorted = true;
         for (int i=1; i < data.Length; i++) {
            if (data[i-1] > data[i])
               isSorted = false;
            sum += data[i];
         }
         if (isSorted)
            Console.WriteLine("Array is sorted");
         else
            Console.WriteLine("Array is not sorted");
         Console.WriteLine("Checksum = {0}", sum);
      }
            
      // chunk-sortcheck-end


      // chunk-driver-begin
      public static void Main (string[] args)
      {
         // chunk-drivervars-begin
         int arraySize;
         int randomSeed;
         Stopwatch watch = new Stopwatch();
         TimeSpan elapsedTime;
         // chunk-drivervars-end

         // chunk-driverparameters-begin
         if (args.Length < 2) {
            Console.WriteLine("Please enter desired array size: ");
            arraySize = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter an initial random seed value: ");
            randomSeed = int.Parse(Console.ReadLine());
         } else {
            arraySize = int.Parse(args[0]);
            randomSeed = int.Parse(args[1]);
         }
         // chunk-driverparameters-end

         int[] data = new int[arraySize];

         // chunk-driverapparatus-begin
         IntArrayGenerate(data, randomSeed);
         watch.Reset();
         watch.Start();
         IntArrayBubbleSort(data);  // the other experiments call a different method
         SortCheckHeuristic(data);
         watch.Stop();
         elapsedTime = watch.Elapsed;
         PrintElapsedTime("Bubble Sort", elapsedTime);
         // chunk-driverapparatus-end

         IntArrayGenerate(data, randomSeed);
         watch.Reset();
         watch.Start();
         IntArraySelectionSort(data);
         SortCheckHeuristic(data);
         watch.Stop();
         elapsedTime = watch.Elapsed;
         PrintElapsedTime("Selection Sort", elapsedTime);
         
         IntArrayGenerate(data, randomSeed);
         watch.Reset();
         watch.Start();
         IntArrayInsertionSort(data);
         SortCheckHeuristic(data);
         watch.Stop();
         elapsedTime = watch.Elapsed;
         PrintElapsedTime("Insertion Sort", elapsedTime);

         IntArrayGenerate(data, randomSeed);
         watch.Reset();
         watch.Start();
         IntArrayShellSortNaive(data);
         SortCheckHeuristic(data);
         watch.Stop();
         elapsedTime = watch.Elapsed;
         PrintElapsedTime("Naive Shell Sort", elapsedTime);

         IntArrayGenerate(data, randomSeed);
         watch.Reset();
         watch.Start();
         IntArrayShellSortBetter(data);
         SortCheckHeuristic(data);
         watch.Stop();
         elapsedTime = watch.Elapsed;
         PrintElapsedTime("Better Shell Sort", elapsedTime);

         IntArrayGenerate(data, randomSeed);
         watch.Reset();
         watch.Start();
         IntArrayQuickSort(data);
         SortCheckHeuristic(data);
         watch.Stop();
         elapsedTime = watch.Elapsed;
         PrintElapsedTime("Quick Sort", elapsedTime);

      }
      // chunk-driver-end
   }
}
