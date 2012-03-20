using System;
using System.IO;
using System.Collections.Generic;

namespace FakeAdviseLab
{
   class MainClass
   {
      static Random rand = new Random();

      public static void Main()
      {
         // set up data reading with utilities in class FileUtil
         StreamReader reader = FileUtil.GetDataReader("HelpNotDefaults.txt");
         // special data in first two paragraphs
         string welcome = FileUtil.ReadParagraph(reader);
         string goodbye = FileUtil.ReadParagraph(reader);
         List<string> guessList =
                   FileUtil.GetParagraphs(reader); //rest is random list
         reader.Close();

         reader = FileUtil.GetDataReader("HelpNotResponses.txt");
         Dictionary<string, string> responses =
                                        FileUtil.GetDictionary(reader);
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

      /** Take input fromUser and use guessList and responses to
       *  determine and return a string response. */
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
   }
}
