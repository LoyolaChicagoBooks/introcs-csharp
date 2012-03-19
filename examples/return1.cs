using System;

class Return1
{
   static int f(int x)
   {
       return x*x;
   }

   static void Main()
   {
      Console.WriteLine(f(3));
      Console.WriteLine(f(3) + f(4));
   }
}

