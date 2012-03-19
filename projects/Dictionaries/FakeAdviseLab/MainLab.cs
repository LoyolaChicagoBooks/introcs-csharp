using System;
using System.IO;
using System.Collections.Generic;

namespace FakeConversationLab
{
   class MainClass
   {
      static Random rand = new Random();

      public static void Main(string[] args)
      {
         string fileBase = "HelpNot";
         if (args.Length > 0) {
            Console.Write("Enter Data File Base: ");
            fileBase = Console.ReadLine();
         }

         StreamReader reader = GetDataReader(fileBase+"Defaults.txt");
         string welcome = ReadParagraph(reader); // special data in
         string goodbye = ReadParagraph(reader); //    first two paragraphs
         List<string> guessList = GetParagraphs(reader); //rest is random list
         reader.Close();

         reader = GetDataReader(fileBase+"Responses.txt");
         Dictionary<string, string> responses = GetDictionary(reader);
         reader.Close();

         Console.Write(welcome);
         string prompt = "\n> ";
         Console.Write("Enter 'bye' to end our session.\n" + prompt);
         string fromUser;
         do {
            fromUser = Console.ReadLine().ToLower().Trim();
            if (fromUser != "bye") {
               string answer = Response(fromUser, guessList, responses);
               Console.Write("\n" + answer + prompt);
            }
         } while (fromUser != "bye");
         Console.Write("\n"+ goodbye);
      }


      public static string Response(string fromUser, List<string> guessList,
                                    Dictionary<string, string> responses)
      {
         char[] sep = "\t !@#$%^&*()_+{}|[]\\:\";<>?,./".ToCharArray();
         string[] words = fromUser.ToLower().Split(sep);
         foreach (string word in words) {
            if (responses.ContainsKey(word)){
               return responses[word];
            }
         }
         return guessList[rand.Next(guessList.Count)];

      }

      ///////////////////////////////////////////////////////////////////////
      // remaining function are utilities for reading from program data files
      ///////////////////////////////////////////////////////////////////////

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


      /** Return a string consisting of a sequence of nonempty lines read
       *  from reader. All the newlines at the ends of these lines are included.
       *  The function ends after reading (but not including) an empty line.
       */
      public static string ReadParagraph(StreamReader reader) {

         // REPLACE the next line with your lines of code
         return "You have not coded ReadParagraph yet!\n";
      }

      public static List<string> GetParagraphs(StreamReader reader)
      {
         List<string> all = new List<string>();

         // REPLACE the next line with your lines of code
         all.Add("You have not coded GetParagraphs yet!\n");

         return all;
      }

      public static Dictionary<string, string> GetDictionary(StreamReader reader)
      {
         Dictionary<string, string> d = new Dictionary<string, string>();

         // add your lines of code here!

         return d;
      }
   }
}
