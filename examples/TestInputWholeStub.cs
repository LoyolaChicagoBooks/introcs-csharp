using System;

class TestInputWhole  // stub for InputWhole
{

   static void Main() //testing routine
   {
      int n = InputWhole("Enter a whole niumber: ");
      Console.WriteLine("The number is {0}.", n);
   }

   static string InputLine(string prompt)
   {
      Console.Write(prompt);
      return Console.ReadLine();
   }

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

   /** Return a whole number.  Catch input
    * errors, and keep prompig the user until
    * a legal entry is made, and return
    * the corresponding int.  Trim extra whitespace. */
   static int InputWhole(string prompt)
   {
      return 0; // so stub compiles:  FIX!
   }
}


