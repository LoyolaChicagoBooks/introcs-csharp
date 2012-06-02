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

      // chunk-linearsearchfrom-begin
      public static int IntArrayLinearSearch(int[] data, int item, int start) {
         int N=data.Length;
         if (start < 0)
            return -1;
         for (int i=start; i < N; i++)
            if (data[i] == item)
               return i;
         return -1;
      }
      // chunk-linearsearchfrom-end

      // chunk-driver-begin
      public static void Main (string[] args)
      {
         Console.WriteLine ("Please enter some integers, separated by spaces:");
         string input = Console.ReadLine();
         string[] integers = input.Split(' ');
         for (int i=0; i < integers.Length; i++)
            Console.WriteLine("i={0} integers[i]={1}", i, integers[i]);
         int[] data = new int[integers.Length];
         for (int i=0; i < data.Length; i++)
            data[i] = int.Parse(integers[i]);

         for (int i=0; i < data.Length; i++)
            Console.WriteLine("i={0} data[i]={1}", i, data[i]);

         while (true) {
            Console.WriteLine("Please enter a number you want to find (blank line to end):");
            input = Console.ReadLine();
            if (input.Length == 0)
               break;
            int searchItem = int.Parse(input);
            Console.WriteLine("Please enter a position to start searching from (0 for beginning): ");
            input = Console.ReadLine();
            int searchPos = int.Parse(input);
            int foundPos = IntArrayLinearSearch(data, searchItem, searchPos);
            if (foundPos < 0)
               Console.WriteLine("Item {0} not found", searchItem);
            else
               Console.WriteLine("Item {0} found at position {1}", searchItem, foundPos);
         }
      }
   }
}
