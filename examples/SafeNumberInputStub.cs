using System;

class SafeNumberInput  //version with fault tolerance
{

   static void Main() //testing routine
   {
      string maybeNum = InputLine("Enter a number, maybe: ");
      Console.WriteLine("{0}: Is it a legal int? {1}.  A double? {2}",
             maybeNum, IsIntString(maybeNum), IsDecimalString(maybeNum));
      int n = InputIntInRange("Enter a score: ", 0, 100);
      Console.WriteLine("Your score is {0}.", n);
      double x = InputDouble("Enter a decimal number: ");
      Console.WriteLine("Your number is {0}.", x);
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

   static string InputLine(string prompt)
   {
      Console.Write(prompt);
      return Console.ReadLine();
   }

   /** Return true when s is a legal int string,
    * and return false otherwise. */
   static Boolean IsIntString(string s)
   {
      return false;  // so stub compiles; COMPLETE
   }

   /** Return an int entered by the user.  Catch input
    * errors, and keep promping the user until
    * a legal entry is made, and return
    * the corresponding int.  Trim extra whitespace. */
   static int InputInt(string prompt)  //FIX so loops until legal
   {
      string nStr = InputLine(prompt).Trim(); //Removes blanks at either end
      return int.Parse(nStr);
   }

   /** Return true when s is a legal decimal string,
    * and return false otherwise. */
   static Boolean IsDecimalString(string s)
   {
      return false;  // so stub compiles; COMPLETE
   }

   /** Return a double entered by the user.  Catch input
    * errors, and keep promping the user until
    * a legal decimal entry is made, and return
    * the corresponding double.  Trim extra whitespace. */
   static double InputDouble(string prompt)  //FIX so loops until legal
   {
      string nStr = InputLine(prompt).Trim(); //Removes blanks at either end
      return double.Parse(nStr);
   }

   /** Continue to obtain a value from the user until it is in the
    * range [lowLim, highLim].  Then return the value in range.
    * Use the specified prompt, adding a reminder of the allowed range. */
   static int InputIntInRange(string prompt, int lowLim, int highLim)
   {
      string longPrompt = string.Format("{0} ({1} through {2}) ",
                                        prompt, lowLim, highLim);
      int number = InputInt(longPrompt);
      while (number < lowLim || number > highLim) {
         Console.WriteLine("{0} is out of range!", number);
         number = InputInt(longPrompt);
      }
      return number;
   }
}


