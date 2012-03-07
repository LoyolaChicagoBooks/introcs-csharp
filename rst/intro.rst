Introduction to the Notes
============================

These notes are designed for Comp 170.  They are closely tied to the
excellent C# introduction in Rob Miles' free online 
`C# Yellow Book <http://www.robmiles.com/c-yellow-book/Rob%20Miles%20CSharp%20Yellow%20Book%202011.pdf>`_.

These notes will follow mostly the same order, adding some extra explanations, examples, 
and challenges, and introduce the Mono open source implementation of C#.

The content here will be interspersed with comments about where to look at parts of Miles book,
with clarifications of the book and comments about what is not important for a 
beginner in the book.

Computer programs are designed to run on a computer and solve problems.  
Though the initial problems will be tiny and often silly, they will serve as learning tools
to prepare for substantive problems.



.. comment 

	Nothing used from here on:
	
	Here is some code::
	
		using System;
	
		public class hello
		{
				public static void Main (string[] args)
				{	
						string name = "";
						if (args.Length > 0)
								name = ", " + args [0];
						Console.WriteLine ("Hello{0}!", name);
				}
	
		}
	
	Same except some lines numbered?
	
	..  code-block:: csharp
		:linenos:
		
		using System;
	
		public class hello
		{
				public static void Main (string[] args)
				{	
						string name = "";
						if (args.Length > 0)
								name = ", " + args [0];
						Console.WriteLine ("Hello{0}!", name);
				}
	
		}
	
	From a file, with some emphasis?:
	
	..  literalinclude:: ../examples/hello.cs
		:emphasize-lines: 7-10
		:linenos:
	
	And now....
	
