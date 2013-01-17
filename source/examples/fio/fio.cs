using System;
using System.IO;

namespace IntroCS
{
   public class FIO
   {
      private static string[] path = { ".", "..", Path.Combine("..", "..") };

      /// Return a directory conaining the filename, if it exists. 
      /// Otherwise return null.
      public static string GetLocation(string filename)
      {
         foreach (string dir in path) {
            string filePath = Path.Combine(dir, filename);
            if (File.Exists(filePath))
               return dir;
         }
         return null;
      }

      /// Find a directory containing the filename
      /// and return the full path, if it exists. 
      /// Otherwise return null.
      public static string GetPath(string filename)
      {
         foreach (string dir in path) {
            string filePath = Path.Combine(dir, filename);
            if (File.Exists(filePath))
               return filePath;
         }
         return null;
      }

      /// Join the location directory and filename;
      /// open and return a StreamReader to the file. 
      public static StreamReader OpenReader(string location, string filename) {
         string filePath = Path.Combine(location, filename);
         Console.WriteLine("attempting to open {0}", filePath);
         return new StreamReader(filePath);
      }

      /// Find a directory containing filename,
      /// and open a StreamReader to the file.
      public static StreamReader OpenReader(string filename) {
         string fileLocation = GetPath(filename);
         if (fileLocation == null)
            return null;
         else
            return new StreamReader( fileLocation);
      }

      /// Join the location directory and filenameF;
      /// open and return a StreamWriter to the file. 
      public static StreamWriter OpenWriter(string location, string filename) {
         string filePath = Path.Combine(location, filename);
         return new StreamWriter(filePath);
      }

   }
}

