using System;

namespace Sorting
{

   class MainClass
   {
      /* This method swaps two items in the array during sorting. As we neeed to do this in multiple
       * sort methods, a function has been created for it.
       */

      static void exchange(int[] data, int m, int n) {
         int temporary;

         temporary = data[m];
         data[m] = data[n];
         data[n] = temporary;
      }

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

      public static void IntArrayInsertionSort(int[] data) {
         int i,j;
         int N=data.Length;

         for (j=1;j<N;j++) {
            for (i=j; i>0 && data[i] < data[i-1]; i--) {
               exchange(data, i,i-1);
            }
         }
      }

      /* Shell sort with intervals 8, 4, 2, 1 */

      static void IntArrayShellSort(int[] data) {
         int i, j, k, m;
         int N=data.Length;

         for (k=8;k>0;k/=2) {
            for (m=0;m<k;m++) {
              for (j=m+k;j<N;j+=k) {
                  for (i=j;i>=k && data[i]<data[i-k];i-=k) {
                     exchange(data, i,i-k);
                  }
               }
            }
         }
      }

      public static void Main (string[] args)
      {
         Console.WriteLine ("Hello World!");
      }
   }
}
