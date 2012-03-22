using System;

class CharLoop
{

   static void Main() //testing routine
   {
      string s = InputLine("Enter a line: ");
      OneCharPerLine(s);
   }

   static string InputLine(string prompt)
   {
      Console.Write(prompt);
      return Console.ReadLine();
   }
                                            // new chunk
   /** Print the characters of s, one per line. */
   static void OneCharPerLine(string s)
   {
      int i = 0;
      while (i < s.length) {
         Console.WriteLine(s[i]);
         i++;
      }
   }
}                                           // past new chunk


