using System;

namespace Arrays
{
   public class BinarySearching
   {

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

      // chunk-binarysearch-printing-begin
      public static void IntArrayPrint(int[] data, int min, int max) {
         for (int i=0; i < data.Length; i++) {
            if (i >= min && i <= max) {
               string number = data[i] + "";
               for (int j=number.Length; j < 5; j++)
                  number = number + " ";
               Console.Write(number);
            } else
               Console.Write("     ");
         }
         Console.WriteLine();
      }

      public static int IntArrayBinarySearchPrinted(int[] data, int item) {
         int min = 0;
         int N=data.Length;
         int max= N-1;
         IntArrayPrint(data, min, max);
         do {
            int mid = (min+max) / 2;
            Console.WriteLine("min={0} max={1} mid={2}", min, max, mid);
            if (item > data[mid])
               min = mid + 1;
            else
               max = mid - 1;
            IntArrayPrint(data, min, max);
            if (data[mid] == item)
               return mid;
            //if (min > max)
            //   break;
         } while(min <= max);
         return -1;
      }
      // chunk-binarysearch-printing-end


      // chunk-driver-begin
      public static void Main (string[] args)
      {
         Console.WriteLine ("Please enter some integers, separated by spaces:");
         string input = Console.ReadLine();
         string[] integers = input.Split(' ');
         int[] data = new int[integers.Length];
         for (int i=0; i < data.Length; i++)
            data[i] = int.Parse(integers[i]);
   
         Sorting.IntArrayShellSortBetter(data);
         while (true) {
            Console.WriteLine("Please enter a number you want to find (blank line to end):");
            input = Console.ReadLine();
            if (input.Length == 0)
               break;
            int searchItem = int.Parse(input);
            int foundPos = IntArrayBinarySearchPrinted(data, searchItem);
            if (foundPos < 0)
               Console.WriteLine("Item {0} not found", searchItem);
            else
               Console.WriteLine("Item {0} found at position {1}", searchItem, foundPos);
         }
      }
   }
}
