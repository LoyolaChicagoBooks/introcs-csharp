using System;

class Constant
{
   static double PI = 3.14159265358979; // constant, value not reset

   static double circleArea(double radius)
   {
      return PI*radius*radius;
   }

   static double circumference(double radius)
   {
      return 2*PI*radius;
   }

   static void Main()
   {
      Console.WriteLine("circle area with radius 5: " + circleArea(5));
      Console.WriteLine("circumference with radius 5:" + circumference(5));
   }
}

