using System;

class Suitcase
{
   static void Main()
   {                                        //main chunk
      Console.Write ( "How many pounds does your suitcase weigh? ");
      double weight = double.Parse(Console.ReadLine());
      if (weight > 50) {
           Console.WriteLine("There is a $25 charge for luggage that heavy.");
      }
      Console.WriteLine("Thank you for your business.");
   }                                       // past main chunk
}
