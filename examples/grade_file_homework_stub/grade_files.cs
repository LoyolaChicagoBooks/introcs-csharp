using System;
using System.IO;

namespace IntroCS
{
   class GradeFiles
   {
      public static void Main(string[] args)
      {
         Console.WriteLine("GradeFiles not implemented");
      }
                                                   // codeIndex chunk                                          
      // Take the first letter code for a catagory, and 
      // return the index of that category in the array categories.
      static int codeIndex(string code, string[] categories)
      {
         for (int i = 0; i < categories.Length; i++) {
            if (categories[i].StartsWith(code)) {
               return i;
            }
         }
         return -1; // compiler required: should not be reached
      }
   }                      // end codeIndex chunk
}
