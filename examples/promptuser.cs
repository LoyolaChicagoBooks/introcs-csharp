using System;

namespace Comp170 {
   class GetInput {
      /* snip-ReadInteger-begin */
      public int ReadInteger(string message) {
         string input;
         Console.WriteLine(message);
         input = Console.ReadLine();
         return int.Parse(input);
      }
      /* snip-ReadInteger-end */
      /* snip-ReadDouble-begin */
      public double ReadDouble(string message) {
         string input;
         Console.WriteLine(message);
         input = Console.ReadLine();
         return double.Parse(input);
      }
      /* snip-ReadDouble-end */
   }
}

