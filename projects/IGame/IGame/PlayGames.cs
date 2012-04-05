using System;
using System.Collections.Generic;
namespace IntroCS
{
   /**
    * Starting point for Lab 8.
    */
   public class PlayGames
   {
      private static Random rand = new Random();

      static IGame PopRandom(List<IGame> g)
      {
         int n = g.Count;
         int i = rand.Next(n);
         IGame ret = g[i];
         g[i] = g[n-1];
         g.RemoveAt(n-1);
         return ret;
      }

      public static void Main()
      {
         List<IGame> games = new List<IGame>(); // Note Game as a type
         games.Add(new AdditionGame(rand, 100));
         // write at least 2 more different types of Game classes
         // and add a new one of each type to games:
         // ...
           
           
         int totScore = 0;
         while (games.Count > 0 && Input.Agree("Want a game? ")) {
            IGame g = PopRandom(games);
            totScore += g.Play();  // use numerical result from the game
         }
         Console.WriteLine("Thanks for Playing!");
         Console.WriteLine("Your total score is " + totScore);
      }
   }
}