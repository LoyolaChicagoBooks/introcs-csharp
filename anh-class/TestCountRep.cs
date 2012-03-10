using System;

class PromptUser  //version with range added to prompt
{

   static void Main() //testing routine
   {
//    int n = InputIntInRange("Enter a score: ", 0, 100);
//    Console.WriteLine("Your score is {0}.", n);
//    Console.WriteLine("Try another test.");
//    n = InputIntInRange("Enter a number: ", -10, 10);
//    Console.WriteLine("Your number is {0}.", n);
      Console.WriteLine(Agree("Do you understand? "));
   }

   static string InputLine(string prompt)
   {
      Console.Write(prompt);
      return Console.ReadLine();
   }

   static int InputInt(string prompt)
   {
      string nStr = InputLine(prompt).Trim(); //Removes blanks at either end
      return int.Parse(nStr);
   }
                                             // new chunk
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
   
   /** Return the number of occuurences of target in s.  */
   static int CountRep(string s, string target)
   {
      if (target.Length == 0) {
         return 0;
      }
      int i = s.IndexOf(target), count = 0;
      while (i >= 0) { 
         count++;
         i = s.IndexOf(target, i + target.Length);
      }
      return count;
}                                           // past new chunk


