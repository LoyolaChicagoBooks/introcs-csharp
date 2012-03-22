using System;

class Wages  //with alternate version of calcWeeklyWages
{
   /** Return the total weekly wages for a worker working totalHours,
    with a given regular hourlyWage.  Include overtime for hours over 40.
   */
   static double CalcWeeklyWages(double totalHours, double hourlyWage)
   {                       // start chunk
      double regularHours, overtime;
      if (totalHours <= 40) {
         regularHours = totalHours;
         overtime = 0;
      }
      else {
         regularHours = 40;
         overtime = totalHours - 40;
      }
      return hourlyWage*regularHours + (1.5*hourlyWage)*overtime;
   }                       // end chunk

   static void Main()  // rest same as in Wages1.cs
   {
      double hours = promptDouble("Enter hours worked: ");
      double wage = promptDouble("Enter dollars paid per hour: ");
      double total = CalcWeeklyWages(hours, wage);
      Console.WriteLine(
         "Wages for {0} hours at ${1:F2} per hour are ${2:F2}.",
         hours, wage, total);
   }

   /** Prompt user and return a line read from the keyboard.*/
   static string promptLine(string prompt)
   {
      Console.Write(prompt);
      return Console.ReadLine();
   }

   /** Prompt user and return a double read from the keyboard.*/
   static double promptDouble(string prompt)
   {
      return double.Parse(promptLine(prompt)); //assumes legal format for now
   }
}
