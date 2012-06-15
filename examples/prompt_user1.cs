using System;

class PromptUser
{

   static void Main() //testing routine
   {
      int a = InputInt("Enter an integer: ");
      int b = InputInt("Enter another integer: ");
      Console.WriteLine("The sum of {0} and {1} is {2}.", a, b, a+b);
      double x = InputDouble("Enter a real number: ");
      double y = InputDouble("Enter another real number: ");
      Console.WriteLine("The difference of {0} and {1} is {2}.", x, y, x-y);
   }
                         //utility function chunk
   /** Return a line from the keyboard
    * after displaying the prompt. */
   static string InputLine(string prompt)
   {
      Console.Write(prompt);
      return Console.ReadLine();
   }

   /** Return an integer entered from the keyboard
    * after displaying the prompt. */
   static int InputInt(string prompt)
   {
      string nStr = InputLine(prompt).Trim(); //Trim removes enclosing blanks
      return int.Parse(nStr);
   }

   /** Return a double entered from the keyboard
    * after displaying the prompt. */
   static double InputDouble(string prompt)
   {
      string nStr = InputLine(prompt).Trim(); //Trim removes enclosing blanks
      return double.Parse(nStr);
   }
}                          // past utility function chunk


