using System;
using System.IO;

namespace GradeFiles
{
   class GradeFiles
   {
      public static void Main(string[] args)
      {
         // Test your setup!  Remove this code in the final version.  Make
         //   sure you are starting off in the same folder as the data files!
         Console.WriteLine(Directory.GetCurrentDirectory());
      }

      /** Use the code for the beginning of a catagory,
        * and find and return the index of that category.*/
      static int codeIndex(string code, string[] categories)
      {
         for (int i = 0; i < categories.Length; i++) {
            if (categories[i].StartsWith(code)) {
               return i;
            }
         }
         return -1;
      }
   }
}
