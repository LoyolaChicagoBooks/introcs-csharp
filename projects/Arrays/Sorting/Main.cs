using System;

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
      public static void IntArraySelectionSort(int[] data) {

      }
      // chunk-selectionsort-end

      // chunk-shellsort-begin
      static void IntArrayShellSort(int[] data, int[] intervals) {
         int i, j, k, m;
         int N=data.Length;

         // The intervals for the shell sort must be sorted, ascending
         IntArrayInsertionSort(intervals)

         for (k=intervals.Length-1;k>0;k--) {
            for (m=0;m<k;m++) {
              for (j=m+k;j<N;j+=k) {
                  for (i=j;i>=k && data[i]<data[i-k];i-=k) {
                     exchange(data, i,i-k);
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

      // chunk-quicksort-begin
      public static void IntArrayQuickSort(int[] data) {

      }
      // chunk-quicksort-end

      // chunk-driver-begin
      public static void Main (string[] args)
      {
         Console.WriteLine ("Hello World!");
      }
      // chunk-driver-end
   }
}
