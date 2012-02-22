using System;

class CheckDigits  // test IsDigits (long way)
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
      Boolean allDigitsSoFar = (s.Length > 0);
      int i = 0;
      while (i < s.Length) {
         if (s[i] < '0' || s[i] > '9') {
            allDigitsSoFar = false;
         }
         i++;
      }
      return allDigitsSoFar;
   }
}                                           // past new chunk


