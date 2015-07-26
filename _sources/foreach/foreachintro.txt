
.. _foreach-syntax:

``foreach`` Syntax 
=====================

.. index:: statement; foreach
   foreach; syntax 
   
These sections on ``foreach`` loops and the later :ref:`For-Loops`
introduce new looping statements. 
Neither is absolutely necessary:  
You could do all the same things with ``while`` loops,
but there are many situations where ``foreach`` loops and ``for`` loops 
are more convenient and easier to read.  

A ``foreach`` statement
only works with an object that holds a sequence or collection.
We will see many more kinds of sequences later.  For now we can illustrate
with a string, which is a sequence of characters.

We have already processed strings a character at a time, with ``while`` loops.
We took advantage of the fact that strings could be indexed.  Our ``while``
loops directly controlled the sequence of indices. Then we could
look up the character at each index of a given string ``s``::

	int i = 0;
	while (i < s.Length) {
	   use value of s[i]...
	   i++;
	}

Examples have been in :ref:`While-Sequence`, like

.. literalinclude:: ../../source/examples/char_loop1/char_loop1.cs
   :start-after: chunk
   :end-before: chunk
 
In this example we really only care about the characters, not the indices.
Managing the indices is just a way to get at the 
underlying sequence of characters.

A conceptually simpler view is just::

   for each character in s
       use the value of the character
       
To *use* "the character" in C#, we must be able to refer to it.
We might name the current character ``ch``.
The following is a variant of ``OneCharPerLine`` with a ``foreach`` 
loop::

    static void OneCharPerLine(string s) 
    {
       foreach (char ch in s) {
           Console.WriteLine(ch);
       }
    }

That is all you need! The ``foreach`` heading feeds us one
character from ``s`` each time through, using the name ``ch`` 
to refer to it.  
Of course any new variable name must be declared in C#, so ``ch``
is preceded in the heading by its type, ``char``.
Then we can use ``ch`` inside the body of the loop.  
Advancing to the next element in the sequence is automatic in the next 
time through the loop.  No ``i++`` to remember; 
no possibility of an infinite loop!

The general syntax of a ``foreach`` loop is

    | ``foreach (`` **type itemName** ``in`` *sequence* ``) {``
    |      statement(s) using **itemName**
    | ``}``

Here is a version of IsDigits::

    static Boolean IsDigits(string s) 
    {
       foreach (char ch in s) {
           if (ch < '0' || ch > '9') {
              return false;
           }
       }
       return (s.Length > 0);
    }

See the advantages of ``foreach`` in these examples:

- They are more concise than the indexing versions.
- They keep the emphasis on the characters, not the secondary indices.
- The ``foreach`` heading emphasizes that a particular sequence is being 
  processed.

.. warning::  
   
   *If* you have explicit need to refer to the indices of the items in the sequence,
   then a ``foreach`` statement does not work.  
   
Of course you can refer to the indices of items in  sequence with a flexible 
``while`` loop, or see :ref:`For-Loops`, coming soon....
