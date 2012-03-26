using System;
using System.IO;
using System.Collections.Generic;

namespace Books
{
   public class FileUtil
   {
      /** Open fileName and return the stream.
       * MonoDevelop kludge looks up two directories in preference to the
       * current directory.
       * Provides a message if cannot find fileName, and exits program. */
      public static StreamReader GetDataReader(string fileName)
      {
         // MonoDevelop kludge!!!!
         string pathAboveDebug = Path.Combine("..", Path.Combine("..", fileName));
         if (File.Exists(pathAboveDebug)) {
            fileName = pathAboveDebug;
         }
         else if (!File.Exists(fileName)) {
            Console.WriteLine("Cannot find file: {0}", fileName);
            Environment.Exit(1);
         }
         return new StreamReader(fileName);
      }

  }
}