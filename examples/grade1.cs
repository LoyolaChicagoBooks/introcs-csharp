using System;

class Grade
{                        // function chunk
   /** Return letter grade for score. */
   static char letterGrade(double score)
   {
      char letter;
      if (score >= 90) {
         letter = 'A';
      }
      else if (score >= 80) { // grade must be B, C, D or F
        letter = 'B';
      }
      else if (score >= 70) { // grade must be C, D or F
         letter = 'C';
      }
      else if (score >= 60) { // grade must D or F
         letter = 'D';
      }
      else {
         letter = 'F';
      }
      return letter;
   }
                        // end of function chunk
   static void Main()
   {
      double g = promptDouble("Enter a numerical grade: ");
      Console.WriteLine("Your letter grade is {0}.", letterGrade(g));
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
