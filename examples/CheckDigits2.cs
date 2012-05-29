using System;

class CheckDigits  // IsDigits with return shortcut; test
{

   static void Main() //testing routine
   {
      string s = InputLine("Enter a line: ");
      Console.WriteLine("Only digits in {0} ?: ", IsDigits(s));
   }

   static string InputLine(string prompt)
   {
      Console.Write(prompt);
      return Console.ReadLine();
   }
                                            // new chunk
   /** Return true if s contains one or more digits
    * and nothing else. Otherwise return false. */
   static Boolean IsDigits(string s)
   {
      int i = 0;
      while (i < s.Length) {
         if (s[i] < '0' || s[i] > '9') {
            return false;
         }
         i++;
      }
      return (s.Length > 0);
   }
}                                           // past new chunk


