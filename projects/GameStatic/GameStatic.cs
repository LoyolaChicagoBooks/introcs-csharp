using System;

namespace IntroCS
{
   class MainProgram
   {
      private static Random r= new Random();

      public static void Main()
      {
         int big = Input.InputInt("Enter a secret number bound: ");
         Game(big);
      }

      public static void Game(int big)
      {
         int secret = r.Next(big);
         int guesses = 1;
         Console.WriteLine("Guess a number less than {0}.", big);
         int guess = Input.InputInt("Next guess: ");
         while (secret != guess) {
            if (guess < secret) {
               Console.WriteLine("Too small!");
            } else {
               Console.WriteLine("Too big!");

            }
            guess = Input.InputInt("Next guess: ");
            guesses++;
         }
         Console.WriteLine("You won on guess {0}!", guesses);
      }
   }
}
