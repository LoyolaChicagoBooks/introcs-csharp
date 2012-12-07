using System;
using System.IO;

namespace IntroCS
{
   public class FIO
   {
      private static string[] path = { ".", "..", Path.Combine("..", "..") };

      public static string GetLocation(string filename)
      {
         foreach (string dir in path) {
            string filePath = Path.Combine(dir, filename);
            if (File.Exists(filePath))
               return dir;
         }
         return null;
      }

      public static string GetPath(string filename)
      {
         foreach (string dir in path) {
            string filePath = Path.Combine(dir, filename);
            if (File.Exists(filePath))
               return filePath;
         }
         return null;
      }

      public static StreamReader OpenReader(string location, string filename) {
         string filePath = Path.Combine(location, filename);
         Console.WriteLine("attempting to open {0}", filePath);
         return new StreamReader(filePath);
      }

      // This version will search the path to find the file for the user.
      public static StreamReader OpenReader(string filename) {
         string fileLocation = GetPath(filename);
         if (fileLocation == null)
            return null;
         else
            return new StreamReader( fileLocation);
      }

      public static StreamWriter OpenWriter(string location, string filename) {
         string filePath = Path.Combine(location, filename);
         return new StreamWriter(filePath);
      }

   }
}

