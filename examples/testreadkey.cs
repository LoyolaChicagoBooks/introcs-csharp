using System;

class TestReadKey
{
    static void Main()
    {
      ConsoleKeyInfo ki = Console.ReadKey();
      Console.WriteLine(ki.KeyChar);
    }
}


