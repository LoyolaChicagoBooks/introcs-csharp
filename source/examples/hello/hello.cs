using System;

namespace hello
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			dividezero();
		}

		public static void dividezero() {
			int zero = 0;
			Console.WriteLine ("5 / 0 = ", 5/ zero );
		}
	}
}
