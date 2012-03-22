using System;

class Wages
{        //heading chunk
   /** Return the total weekly wages for a worker working totalHours,
    with a given regular hourlyWage.  Include overtime for hours over 40.
   */
   static double CalcWeeklyWages(double totalHours, double hourlyWage)
   {     //body chunk
      double totalWages;
      if (totalHours <= 40) {
         totalWages = hourlyWage*totalHours;
      }
      else {
         double overtime = totalHours - 40;
         totalWages = hourlyWage*40 + (1.5*hourlyWage)*overtime;
      }
      return totalWages;
   }
                               //
   static void Main()
   {
      double hours = promptDouble("Enter hours worked: ");
      double wage = promptDouble("Enter dollars paid per hour: ");
      double total = CalcWeeklyWages(hours, wage);  //before chunk2
      Console.WriteLine(
         "Wages for {0} hours at ${1:F2} per hour are ${2:F2}.",
         hours, wage, total);
   }                                                //after chunk2

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
