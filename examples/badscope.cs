using System;

class BadScope
{
   static void Main()
   {
      int x = 3;
      f();
   }
   static void f()
   {
      Console.WriteLine(x); //ERROR f doesn't know about the x defined in Main
   }

}

