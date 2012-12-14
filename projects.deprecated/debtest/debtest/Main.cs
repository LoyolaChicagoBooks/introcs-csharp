using System;

namespace debtest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Calling f");
            int z = F(5);
            Console.WriteLine(z);
        }

        static int F(int x)
        {
            int y = x;
            return y/(y-x);
        }
    }
}
