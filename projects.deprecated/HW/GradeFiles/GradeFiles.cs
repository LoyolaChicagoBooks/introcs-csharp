using System;
using System.IO;

namespace GradeFiles
{
   class GradeFiles
   {
      public static void Main(string[] args)
      {
         // test setup!  Remove this code in the final version.
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

      /** Return a line from the keyboard
       * after displaying the prompt. */
      static string InputLine(string prompt)
      {
         Console.Write(prompt);
         return Console.ReadLine();
      }
   }
}
