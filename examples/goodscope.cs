using System;

class BadScope
{
   static void Main()
   {
      int x = 3;
      f(x);
   }
   static void f(int x)
   {
      Console.WriteLine(x);
   }

}

