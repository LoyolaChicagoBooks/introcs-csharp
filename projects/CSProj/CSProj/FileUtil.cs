using System;
using System.IO;
namespace CSProject
{
   
   /**
    * File utilities for reading from a text file.
    */
   public class FileUtil
   {
      /** Open fileName and return the stream.
       * MonoDevelop kludge looks up two directories if need be.
       * Provides a message if cannot find fileName, and returns null. */
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

      /**
        * Read a long line and return it wrapped into lines.
        */    
      public static string lineWrap(StreamReader reader)
      {
         return wordWrap(reader.ReadLine(), 79);
      }

      private static char[] noChar = {};

      /** Split s at any number of whitespace characters.
       *  No empty strings are inserted. */
      public static string[] SplitWhite(string s)
      {   // such a mouthfull!
         return s.Split(noChar, StringSplitOptions.RemoveEmptyEntries);
      }
      /**
        * Add line breaks to s so it wraps within a specified
        * number of columns. */
      public static string wordWrap(string s, int columns)
      {
         string wrapped = "";
         s = s.Trim();
         while (s.Length > columns) {
            int i = s.LastIndexOf(" ", columns);
            if (i == -1) {
               i = columns;
            }
            wrapped += s.Substring(0, i).Trim();
            s = s.Substring(i).Trim();
            if (s.Length > 0) {
               wrapped += "\n";
            }
         }
         wrapped += s;
         return wrapped;
      }
       
      /**
        * Read a paragraph from reader
        * consisting of one or more nonempty lines terminated by an empty
        * line, and return a single string, preserving the newlines.
        * The reader stops reading after the first empty line or the
        * end of the file.
        * Return the whole paragraph, with the newlines after each line,
        *   ending with the newline after the last nonempty line.
        */
      public static string readParagraph(StreamReader reader)
      {
         string para = "";
         string line;
         do {
            line = reader.ReadLine();  // drops newline
         } while (line.Trim().Length == 0);
         while (!string.IsNullOrEmpty(line)) {
            para += line + "\n";  // add back newline
            line = reader.ReadLine();
         }
         return para;
      }
   }
}
