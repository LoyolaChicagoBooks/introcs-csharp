using System;

namespace Arrays
{
   public class Searching
   {

      // chunk-linearsearch-begin
      public static int IntArrayLinearSearch(int[] data, int item) {
         int N=data.Length;
         for (int i=0; i < N; i++)
            if (data[i] == item)
               return i;
         return -1;
      }
      // chunk-linearsearch-end

      // chunk-binarysearch-begin
      public static int IntArrayBinarySearch(int[] data, int item) {

         int min = 0;
         int N=data.Length;
         int max= N-1;
         do {
            int mid = (min+max) / 2;
            if (item > data[mid])
               min = mid + 1;
            else
               max = mid - 1;
            if (data[mid] == item)
               return mid;
            //if (min > max)
            //   break;
         } while(min <= max);
         return -1;
      }
      // chunk-binarysearch-end

      // chunk-driver-begin
      public static void Main (string[] args)
      {
         Console.WriteLine ("Hello World!");
      }
      // chunk-driver-end

   }
}
