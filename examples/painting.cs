using System; 

class Painting  // A simple first example
{
   static void Main()
   {
      double HEIGHT = 8;
      double width, length, wallArea, ceilingArea;
      string widthString, lengthString;
      
      Console.WriteLine ( "Calculation of Room Paint Requirements");
      Console.Write ( "Enter room length: ");
      lengthString = Console.ReadLine();
      length = double.Parse(lengthString);
      Console.Write( "Enter room width: ");
      widthString = Console.ReadLine();
      width = double.Parse(widthString);
      
      wallArea = 2 * (length + width) * HEIGHT;
      ceilingArea = length * width;
      
      Console.WriteLine("The wall area is " +
                          wallArea + " square feet.") ;
      Console.WriteLine("The ceiling area is " +
                          ceilingArea + " square feet.") ;
   }
}
