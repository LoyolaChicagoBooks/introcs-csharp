using System;

class Clothes
{
   static void Main()
   {                               // main chunk
      Console.Write ( "What is the temperature? ");
      double temperature = double.Parse(Console.ReadLine());
      if (temperature > 70) {
           Console.WriteLine("Wear shorts.");
      }
      else {
          Console.WriteLine("Wear long pants.");
      }
      Console.WriteLine("Get some exercise outside.");
   }                               // past main chunk
}
