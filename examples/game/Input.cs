using System;
namespace IntroCS
{  
   /**
    *  Console input functions with prompts and safe type conversion. */
   public class Input 
   {
      /** Return a line from the keyboard in response to prompt. */
      public static string InputLine(string prompt)
      {
        Console.Write(prompt);
        return Console.ReadLine();
      }

      /** True when s consists of only 1 or more digits. */
      public static bool IsDigits(string s)
      {
         foreach( char ch in s) {
            if (ch <'0' || ch > '9') {
               return false;
            }
			}
         return (s.Length > 0);
      }

      /** True if s is the string form of an int. */
      public static bool IsIntString(string s)
      {
         if (s.StartsWith("-")) {
            s = s.Substring(1);
         }
         return IsDigits(s);
      }

      /** Return true if s represents a decimal string. */
      public static bool IsDecimalString(string s)
      {
         if (s.StartsWith("-")) {
            s = s.Substring(1);
         }
         int i = s.IndexOf(".");
         if (i >= 0) {
            s = s.Substring(0,i) + s.Substring(i+1);
         }
         return IsDigits(s);
      }
           
      /** Prompt the user to enter an integer until the response is legal.
          Return the result as in int. */
      public static int InputInt(string prompt)
      {
         string nStr = InputLine(prompt).Trim();
         while (!IsIntString(nStr)) {
            Console.WriteLine("Bad int format!  Try again.");
            nStr = InputLine(prompt).Trim();
         }
         return int.Parse(nStr);
      }
                                                 
      /** Prompt the user to enter a decimal value until the response is legal.
           Return the result as a double. */
      public static double InputDouble(string prompt)
      {
         string nStr = InputLine(prompt).Trim();
         while (!IsDecimalString(nStr)) {
            Console.WriteLine("Bad decimal format!  Try again.");
            nStr = InputLine(prompt).Trim();
         }
         return double.Parse(nStr);
      }
                                                 
      /** Continue to obtain a value from the user's keyboard until it is
        * in the range [lowLim, highLim].  Then return the value in range.*/
      public static int InputIntInRange(string prompt, int lowLim, int highLim)
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
           
      /** Prompt the user with a question;
           return true of false based on the keyboard response.  */
      public static Boolean Agree(string question)
      {
         string meanYes = "ytYT", meanNo = "nfNF",
                validResponses = meanYes + meanNo;
         string answer = InputLine(question);
         while (answer.Length == 0 ||
                !validResponses.Contains(""+answer[0])) {
            Console.WriteLine("Enter y or n!");
            answer = InputLine(question);
         }
         return meanYes.Contains(""+answer[0]);
      }
   }
}
