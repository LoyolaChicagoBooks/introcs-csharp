.. index:: list


.. _listsyntax:

List Syntax
===============

Arrays are fine if you know ahead of time how long your sequence of items is.
Then you create your array with that length, and you are all set.

If you want a variable sized container, you are likely to want a ``List``.  
As with arrays, you might want a collection of any particular type. 
Unfortunately, you cannot use the simple notation of arrays to specify
the type of element in a ``List``.  Array syntax is
*built into* the language.  Lists are handled in the *library* of types
provided by C# from the .Net framework.  There are all sorts of
situations where you might want a general idea to have a version for each of
many kinds of objects.  There is *not* a new syntax for *each* one.

.. index:: generics
   < > for generics

Generics
-----------

Instead .Net 4.0 introduced one new form of syntax that can apply to all sorts of
classes, *generics*.

The type for a list of strings is ::

    List<string>
    
The type for an ``int`` list is ::

    List<int>

In general the new generic syntax allows a type (or several, comma separated) in angle
brackets after a class name.  Lists are an example that depends on just
one included type.  We will see more shortly.

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
   single: List; Contains
   
List Constructors and Methods
-------------------------------

We can play with some ``List`` methods in csharp.  
Note that csharp informally displays the
value of a ``List`` with a list of elements inside braces.  
This is *not* a legal
way to assign values to lists.   

The blocks below are all from one csharp session, 
with our comments breaking up the sequence.

With the no-parameter constructor, the ``List`` is empty to start:

..  code-block:: none

	csharp> List<string> words = new List<string>();
	csharp> words;
	{  }
	csharp> words.Count;
	0
	
You can add elements, and keep count with the ``Count`` property 
as the size changes:

..  code-block:: none

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
	
.. index::  list; index [ ]
   single: [ ]; list index
   
You can reference and change elements by index, like with arrays:

..  code-block:: none

	csharp> words[0];
	"up"
	csharp> words[2];
	"over"
	csharp> words[2] = "in";
	csharp> words;
	{ "up", "down", "in" }	
	
You can use ``foreach`` like with arrays or other sequences:

..  code-block:: none
	
	csharp> foreach (string s in words) {      
		  >    Console.WriteLine(s.ToUpper()); 
		  > }
	UP
	DOWN
	ON

.. index:: List; Console.WriteLine useless
	
Note:  Unfortunately C# is not user-friendly if 
you try to use ``Console.WriteLine`` to print a ``List`` *object*:

..  code-block:: none

    csharp> Console.WriteLine(words)
    System.Collections.Generic.List`1[System.Int32]

Next compare ``Remove``, which finds the first matching element and removes it,
and ``RemoveAt``, which removes the element at a specified index.
``Remove`` returns whether the List has been changed:

..  code-block:: none

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
so the index decreases for the elements after the removed one:

..  code-block:: none

	csharp> words[2];
	"on"
	csharp> words.Count;
	3
	
You can check for membership in a ``List`` with ``Contains``:

..  code-block:: none

	csharp> words.Contains("in");
	true
	csharp> words.Contains("into");
	false

You can also remove all elements at once:

..  code-block:: none

	csharp> words.Clear();
	csharp> words.Count;
	0

.. index::
   single: List; constructor with sequence
   
Here is a List containing ``int`` elements.
Though more verbose than for an array, you can initialize a ``List``
with another collection, including an anonymous array,
specified with an explicit sequence in braces:

..  code-block:: none

	csharp> List<int> nums = new List<int>(new[]{5, 3, 7, 4});
	csharp> nums;
	{ 5, 3, 7, 4 }

We have been using the explicit declaration syntax, but generic types tend to get long,
so ``var`` is handy with them::

   var stuff = new List<string>();

When initializing a generic object, you still need to remember both the angle braces 
around the type *and* the parentheses for the parameter list after that.    

.. index:: side effect

An aside on the ``Remove`` method:  It both causes a side effect, 
changing the list,
*and* it returns a value.  If a function returns a value, 
we typically use the function call as an 
expression in a larger statement.  This is not necessary, as described in
:ref:`not-using-ret-val`.  In that section we discussed the *mistake* of not
using return values.  The ``Remove`` method illustrates that this is 
not always a mistake:  If you just want the side effect, trying to remove an element,
whether or not it is in the list, then there is no need to check for the return value.
This complete C# statement is fine::

  someList.Remove(element);

You should generally think carefully before *defining* a function 
that both has a side effect 
and a return value.  Most functions that return a value do not have a side effect.  
If you see a function used in the normal way as an expression, it is easy to forget that
it was *also* producing some side effect.
  
.. index:: example; ReadLines
   ReadLines example
   List; ReadLines example

Interactive List Example
-------------------------

Lists are handy when you do not know how much data there will be.  
A simple example would be reading in lines from the user interactively::

    /// Return a List of lines entered by the user in response
    /// to the prompt.  Lines in the List will be nonempty, since an
    /// empty line terminates the input. 
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
    
    