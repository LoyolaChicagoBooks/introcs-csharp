using System;
using System.IO;

namespace hwgradefiles
{
   class GradeFiles
   {
      public static void Main(string[] args)
      {
         // test setup!
         Console.WriteLine(Directory.GetCurrentDirectory());
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
