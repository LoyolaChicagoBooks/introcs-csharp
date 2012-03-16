.. index:: list


.. _listsyntax:

List Syntax
===============

Arrays are fine if you know ahead of time how long your sequence of items is.
Then you create your array with that length, and you are all set.

If you want a variable sized container, you are likely to want a ``List``.  
As with arrays, you might want a collection of any type. 
Unfortunately, you cannot use the simple notation of arrays to specify
the type of element in a ``List``.  Arrays are *built into* the language, and they have
their own special syntax.  Lists are handled in the *library* of types
provided by C# from the .Net framework.  There are all sorts of
situations where you might want a general idea to have a version for each of
many kinds of objects.  There is *not* a new syntax for *each* one.

.. index:: generics

Generics
-----------

Instead .Net 4.0 introduced one new form of syntax that can apply to all sorts of
classes, *generics*.

The type for a list of strings is ::

    List<string>
    
The type for an ``int`` list is ::

    List<int>

In general the new generic syntax allows a type (or several in a list) in angle
brackets after a class name.  Lists are an example.  We will see more shortly.

There is a namespace for the generics for collections, including List:
System.Collections.Generic.

We will use several generic library classes, though we will not write the definitions of 
new generic classes ourselves.


.. index::
   single: List; constructor
   single: List; Count
   single: List; Add
   single: List; Remove
   single: List; RemoveAt
   
List Constructors and Methods
-------------------------------

We can play with some ``List`` methods in csharp.  
Note that csharp informally displays the
value of a ``List`` with a list of elements inside braces.  This is *not* a legal
way to assign values to lists.  Nor is it the *unhelpful* way
C# would print out a string representation of a ``List`` with ``Console.WriteLine``.
The blocks below are all from one csharp session, 
with our comments breaking up the sequence.

With the no-parameter constructor, the ``List`` is empty to start::

	csharp> List<string> words = new List<string>();
	csharp> words;
	{  }
	csharp> words.Count;
	0
	
You can add elements, and keep count with the ``Count`` property 
as the size changes::

	csharp> words.Add("up");
	csharp> words;
	{ "up" }
	csharp> words.Add("down");
	csharp> words;             
	{ "up", "down" }
	csharp> words.Add("over"); 
	csharp> words;             
	{ "up", "down", "over" }
	csharp> words.Count;
	3

You can reference and change elements by index, like with arrays::

	csharp> words[0];
	"up"
	csharp> words[2];
	"over"
	csharp> words[2] = "in";
	csharp> words;
	{ "up", "down", "in" }	
	
You can use ``foreach`` like with arrays or other sequences::
	
	csharp> foreach (string s in words) {      
		  >    Console.WriteLine(s.ToUpper()); 
		  > }
	UP
	DOWN
	ON
	
Compare ``Remove``, which finds the first matching element and removes it,
and ``RemoveAt``, which removes the element at a specified index.
``Remove`` returns whether the List has been changed::

	csharp> words.Remove("down");  
	true
	csharp> words;
	{ "up", "in" }
	csharp> words.Remove("around"); // no change
	false
	csharp> words.Add("out");
	csharp> words.Add("on");
	csharp> words;
	{ "up", "in", "out", "on" }
	csharp> words.RemoveAt(2); // "out" is at index 2
	csharp> words;
	{ "up", "in", "on" }
	
Removing does not leave a "hole" in the ``List``:  The list closes up,
so the index decreases for the elements after the removed one::

	csharp> words[2];
	"on"
	csharp> words.Count;
	3
	
You can also remove all elements at once::

	csharp> words.Clear();
	csharp> words.Count;
	0

.. index::
   single: List; constructor with sequence
   
Here is a List containing ``int`` elements.
Though more verbose than for an array, you can initialize a ``List``
with another collection, including an anonymous array,
specified with an explicit list in braces::

	csharp> List<int> nums = new List<int>(new int[]{5, 3, 7, 4});
	csharp> nums;
	{ 5, 3, 7, 4 }

.. index::
   double: example; ReadLines
   double: example; List

Interactive List Example
-------------------------

Lists are handy when you do not know how much data there will be.  
A simple example would be reading in lines from the user interactively::

    /** Return a List of lines entered by the user in response
      * to the prompt.  Lines in the List will be nonempty, since an
      * empty line terminates the input. */
    List<string> ReadLines(string prompt) 
    {
       List<string> lines = new List<string>();
       Console.WriteLine(prompt);
       Console.WriteLine("An empty line terminates input.");
       string line = Console.ReadLine();
       while (line.Length > 0) {
          lines.Add(line);
          line = Console.ReadLine();
       }
       return lines;
    }
    
    