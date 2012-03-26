.. index::
   triple:  while; index; sequence

.. _While-Sequence:


While-Statements with Sequences
================================= 

We will process many sequences or collections.  At this point
the only collection we have discussed is a string - a sequence of
characters that we can index.

.. _OneCharPerLine:

.. index::
   double:  example; OneCharPerLine
   
Consider the following silly function description and heading as a start:

.. literalinclude:: ../examples/CharLoop1.cs
   :start-after: chunk
   :end-before: {
 
``OneCharPerLine("bug")`` would print:

  | b
  | u
  | g

We are accessing one character at a time.  We can do that with
the indexing notation.  Thinking concretely about the example above,
we are looking to print, ``s[0]``, ``s[1]``, ``s[2]``.
This requires a loop.  
For now our only option is a ``while`` loop.  We can follow 
our basic rubric, one step at a time:
The index is changing in a simple repetitive sequence.  
We can call the
index ``i``.  Its initial value is clearly 0. 
That is our initialization.  We need a ``while`` loop continuation 
condition.
For the 3-character string example, the last index above is 2.
In general we want *all* the characters.  Recall the index of the last 
character is the length - 1, or with our parameter``s``, ``s.length - 1``
The ``while`` loop condition needs to allow indices through 
``s.length - 1``.  We could write a condition with ``<=`` or more
concisely::

    while (i < s.length) {

In the bode of the loop, the main thing is to print the next character,
and the next character is ``s[i]``::

    Console.WriteLine(s[i]);
    
We also need to remember the part to get ready for the next time 
through the loop.  We have dealt with regular sequence of values
before.  We change ``i`` with::

    i = i+1;
    
This change is so common, there is a simpler syntax::

    i++;
    
This increases the value of the numeric variable i by 1.
(The reverse is ``i--;``)

So all together:

.. literalinclude:: ../examples/CharLoop1.cs
   :start-after: chunk
   :end-before: chunk
 
You can test this with example :file:`CharLoop1.cs``.

This is a very common pattern.  
We could do anything we want with each individual character, 
no just print it.

..  later maybe
	.. rubric:: Print Backwards
	
	Here is a variation, print backward on one line:
	There are a few changes:
	
	- You do not want to go on to the next line, so use ``Write``, 
	  not ``WriteLine``.
	- It is still a regular sequence of character indices, but
	  everything needs to be reworked.

.. index::
   double: string; PrintVowels
   
.. _PrintVowels:
   
.. rubric:: PrintVowels

Let us get more complicated.  Consider the function described:

.. literalinclude:: ../examples/Vowels.cs
   :start-after: chunk
   :end-before: {

For instance PrintVowels("hello") would print:

    | e
    | o

We have seen that we can go through the whole string and do the same
thing each time through the loop, use ``s[i]`` in some specific way.

This new description seems like a problem.  We do *not* appear to want to do
the same thing each time:  We only want to print *some* of the 
characters.  Again your eyes and mind are so fast, you likely miss what you
need to do when go through ``PrintVowels`` by hand.  Your
eyes let you just grab the vowels easily, but think, what is actually
happening?  You are checking each character to see if it is a vowel,
and printing it if it is:  You are doing the same thing each time -
*testing* **if** the character is a vowel.  The pseudocode is   ::

    if (s[i] is a vowel) {
       print s[i]
    }

We do want to do this each time through the loop.  We *can* use 
a ``while`` statement.

Next problem:  convert the pseudocode "s[i] is a vowel" to C#.

There are multiple approaches.  The one you get by following your
nose is just to consider all the cases where it is true::

   s[i] == 'a'
   s[i] == 'e'
   s[i] == 'i'
   s[i] == 'o'
   s[i] == 'u'

How do you combine them into a condition?  
The letter can be a *or* e *or* i *or* o *or* u.  We get the code:

.. literalinclude:: ../examples/Vowels.cs
   :start-after: chunk
   :end-before: chunk

That has a long condition!  Here is a nice trick to shorten that:
We want to check if a character is in a group of letters.  We have
already seen the string method IndexOf.  Recall we can use it to see if
a character is in or not in a string.  We can use ``"aeiou".IndexOf(s[i])``.
We do not care where ``s[i]`` comes in the string of vowels.  
All we care is that ``"aeiou".IndexOf(s[i]) >= 0``.

.. index::
   double: string; Contains
   
This is still a bit of a mouthful.  Often it is just important if a
character or string is *contained* in another string, not where it appears,
so it is easier to
use the string method ``Contains``.  Though IndexOf takes either a string
or a character as parameter, ``Contains`` only takes a string.  There is a 
nice quick idiom to convert anything to a string:  use ``""+``. 
The condition could be ``"aeiou".Contains(""+s[i])``.  
This adds
the string version of ``s[i]`` to the empty string.

The function is still not as general as it might be:
Only lowercase vowels are listed.  We could do something with
``ToLower``, or just use the condition: ``"aeiouAEIOU".Contains(""+s[i])``

This variation is in example ``Vowels2.cs``.

.. literalinclude:: ../examples/Vowels2.cs
   :start-after: chunk
   :end-before: chunk


.. index::
   double example; IsDigits
   
.. _IsDigits:

.. rubric:: IsDigits

Consider a variation, determining if *all* the characters
in a string are vowels.  We could work on that, but it is 
nit very useful.  Instead let us consider if all the 
characters are digits.  This is a true-false question, so function
to determine this would return a Boolean result:

There are several ways to check if a character is a digit.  We could use the
``Contains`` idiom from above, but here is another option:
The codes for digits are sequential,
and since characters are technically a kind of integer, we can 
compare:  ``s[i]`` is a digit if it is in the range from ``'0'``
to ``'9'``, so the condition can be written::

    '0' <= s[i] && s[i] <= '9'
    
Similarly  the condition ``s[i]`` is not a digit, can be written 
negating the condition above or using the sam ideas as when we 
considered out of range values::

    s[i] < '0' || s[i] > '9'
    
If you think of going through by hand and checking, 
you would check through the 
characters sequentially and if you find a non-digit,
you would want to remember that the string is not only digits.

One way to do this is have a variable holding an answer so far::

     bool allDigitsSoFar = true;
     
Of course initially, you have not found any non-digits, so it starts off true.  
As you go through
the string, you want to make sure that answer is changed to ``false`` 
if a non-digit is encountered::

     if ('0' > s[i] || s[i] > '9') {
         allDigitsSoFar = false;
     }

When we get all the way through the string, the answer so far is the
final answer to be returned::

   /** Return true if s contains one or more digits
    * and nothing else. Otherwise return false. */
   static bool IsDigits(string s)
   {
      bool allDigitsSoFar = true;
      int i = 0;
      while (i < s.Length) {
         if (s[i] < '0' || s[i] > '9') {
            allDigitsSoFar = false;
         }
         i++;
      }
      return allDigitsSoFar;
   }

Remember something to always consider:  edge cases.
In the description it says it is true for a string of *one or more* digits.

Check examples of length 1 and 0.  
Length 1 is fine, but it fails for the empty string,
since the loop is skipped and the initial answer, ``true`` is returned.

There are many ways to fix this.  We will know right up front that the answer
is false if the length is 0, and we could immediately set
``allDigitsSoFar`` to false.  We would need to change the initialization 
so it checks the length and chooses the right value for ``allDigitsSoFar``,
true or false, appropriate.  since we are selecting between two values,
an ``if`` statement should occur to you::

  bool allDigitsSoFar;
  if (s.Length > 0) {
      allDigitsSoFar = true;
  }
  else {
      allDigitsSoFar = false;
  }
      
If we substitute this initialization for ``allDigitsSoFar``, 
the code will satisfy the edge case, and the code will always 
work. 

Examine the ``if`` statement more closely:

    | if the condition is  ``true``, ``allDigitsSoFar`` is ``true``; 
    | if the condition is ``false``, ``allDigitsSoFar`` is ``false``; 

See the symmetry: the value assigned to ``allDigitsSoFar`` is always
the *value of the condition*.

A *much* more concise and still equivalent initialization is just::

    bool allDigitsSoFar = (s.Length > 0); 
    
In more generality this 
conciseness comes from the fact that it is a *Boolean* value that
you are trying to set, based on a *Boolean* condition:  You do not
need to do that with an ``if`` statement!  You just need an 
assignment statement!  If you use an ``if`` statement in such a situation,
you mark yourself as a novice.

It could even be slightly more concise:  The precedence of assignment is
very low, lower than the comparison ``>``, 
so the parentheses could be omitted.  We think the
code is easier to read with the parentheses left in, as written above,
and below.

The whole function would be:

.. literalinclude:: ../examples/CheckDigits1.cs
   :start-after: chunk
   :end-before: chunk

You can try this code in example :file:`CheckDigits1.cs`.

.. index::  return; from inside loop
   
We are not done.  This code is still inefficient.  If an early
character in a long string is not a digit, we already know the 
final answer, but this code goes through and still checks all the
other characters in the string!  People checking by hand 
would stop as soon as they found a
non-digit.  We can do that in several ways with C#, too.  
Since this is a function, and we would know the final answer
where we find a non-digit, 
the simplest thing is to use the fact that a return statement
*immediately terminates* the function (even if in a loop).

Instead of setting a variable to ``false`` to *later* be returned,
we can return right away, using the loop::

      while (i < s.Length) {
         if (s[i] < '0' || s[i] > '9') {
            return false;
         }
         i++;
      }

What if the loop terminates normally (no return from inside)?  
That means no
non-digit was found, so if there are any characters at all,
they are all digits. There are 
*one or more* digits as long as the string length is *positive*.
Again we do not need an ``if`` statement for a check.  Look in the full
code for the function:

.. literalinclude:: ../examples/CheckDigits2.cs
   :start-after: chunk
   :end-before: chunk

The full code with a ``Main`` testing program is in 
example :file:`CheckDigits2.cs`.

Returning put of a loop 
is a good pattern to remember for when you are searching for something, 
and you know the final answer for your function as soon as you find it.
