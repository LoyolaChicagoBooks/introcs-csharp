using System;
namespace IntroCS
{
   class InputInRange  //version with range added to prompt
   {
      
      public static void Main() //testing routine
      {
         Console.WriteLine(Agree("Do you understand? "));
      }
      
      // Prompt the user with a question; Return true of false.
      // Allow certain starting characters for true and
      // others for false, and repeat until the response
      // is in one of these groups.
      static Boolean Agree(string question)
      {
         //initial prompt
         string response = UIF.PromptLine(question).ToLower() + ' ';
         while(response[0] != 'y' &&  response[0] != 'n') {
            Console.WriteLine("Enter y or n!");
            response = UIF.PromptLine(question).ToLower() + ' ';
         }
         return response[0] == 'y';  // so stub compiles
      }
   }                                          
}

