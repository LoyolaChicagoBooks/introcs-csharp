.. index::  string; method
   
.. _more-string-methods:
	
More String Methods
---------------------------

Before we do more elaborate things with strings, some more string methods
will be helpful.  Be sure you are familiar with the earlier discussion of 
strings in 
:ref:`basic-string-ops`.

Play with the new string methods in csharp!

This variation of ``IndexOf`` has a second parameter:

.. index:: string; IndexOf
   IndexOf string method
   
``int IndexOf(string target, int start)``   
    Returns the index of the beginning of the first occurrence of the string 
    ``target`` 
    in **this** string object, starting at index ``start`` or after. 
    Returns -1 if ``target`` is not found. Example:: 
    
        csharp> string state = "Mississippi"; 
        csharp> print("01234567890\n"+state) // to see indices
        01234567890
        Mississippi
        csharp> state.IndexOf("is", 0); // same as state.IndexOf("is");
        1                     
        csharp> state.IndexOf("is", 2);
        4                     
        csharp> state.IndexOf("is", 5);
        -1                     
        csharp> state.IndexOf("i", 5);
        7                     

.. index:: string; Trim
   Trim string method
   
``string Trim()``   
    Returns a string formed from **this** string object, but
    with leading and trailing whitespace removed. Example:: 
    
        csharp> string s = "\n  123    ";
        csharp> "#" + s + "#";
        #
          123   #
        csharp> "#" + s.Trim() + "#";
        #123#

.. index:: string; Replace
   Replace string method
   
   
``string Replace(string target, string replacement)``
    Returns a string formed from **this** string by replacing
    all occurrences of the substring ``target`` by ``replacement``.  
    Example::
    
        csharp> string s = "This is it!";
        csharp> s.Replace(" ", "/");
        "This/is/it!"      
        csharp> s.Replace("is", "at");
        "That at it!"      
        csharp> "oooooh".Replace("oo", "ah");
        "ahahoh"      

.. index:: string; StartsWith
   StartsWith string method
   
``bool StartsWith(string prefix)`` 
    Returns ``true`` if  **this** string object starts 
    with string ``prefix``, and ``false`` otherwise.
    Example::

        csharp> "-123".StartsWith("-");
        true
        csharp> "downstairs".StartsWith("down");
        true                   
        csharp> "1 - 2 - 3".StartsWith("-");
        false   

.. index:: string; EndsWith
   EndsWith string method
   
``bool EndsWith(string suffix)`` 
    Returns ``true`` if  **this** string object ends 
    with string ``suffix``, and ``false`` otherwise.
    Example::

        csharp> "-123".EndsWith("-");
        false
        csharp> "downstairs".EndsWith("airs");
        true                   
        csharp> "downstairs".EndsWith("air");
        false                   


.. index:: exercise; CountRep
   CountRep exercise 

.. _countrep:

Count Repetitions in a String Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program :file:`test_count_rep.cs`, with a Main testing method,
that tests a function with the following heading::

  // Return the number of separate repetitions of target in s.
  static int CountRep(string s, string target)

For example here is what ``CountRep( "Mississippi", target)`` 
would return with various values for ``target``:
  
      | ``"i"``: 4
      | ``"is"``: 2
      | ``"sss"``: 0

Assume each repetition is completely separate, so
``CountRep("Wheee!", "ee")`` returns 1.  The last
two e's do not count, since the middle e is already
used in the match of the first two e's.

      
.. index:: exercise; safe PromptInt and PromptDouble
   safe PromptInt and PromptDouble exercises
   
.. _safe-input-number:

Safer PromptInt and PromptDouble Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Save the example :repsrc:`safe_number_input_stub/safe_number_input.cs` 
in a project of your own.

The idea is to write safe versions of the utility functions
PromptInt and PromptDouble (which can then be used in further
places like PromptIntInRange).  

Be sure you are familiar with :ref:`safe-whole-number-input`,
and the development of its ``InputWhole`` function.

A legal whole number string consists entirely of digits.  We have
already written example ``IsDigits`` to identify a string for a
whole number.

The  improvements to PromptInt and PromptDouble are 
very similar and straightforward *if* you have developed the two main
Boolean support functions,
``IsIntString`` and ``IsDecimalString`` respectively.  

A complicating issue with integer and decimal strings 
is that they may include parts other than
digits.  An integer may start with a minus sign.  A
decimal number can also contain a decimal point in an appropriate 
place.  The suggestion is to confirm that these other characters appear in
legal places, remove them, and see that what is left is digits. 
The recently introduced string methods should help....

Using the ideas above, 
develop the functions in order and test after each one:
write ``IsIntString``, revise ``PromptInt``, 
write ``IsDecimalString``, and revise ``PromptDouble``.

Be sure to test carefully.  Not only confirm that all
appropriate strings return ``true``:
Also be sure to test that you return ``false"`` 
for *all* sorts of bad strings.  

There is still one issue with ``IsIntString`` not considered yet:  see
the next exercise for the final improvement.

Hopefully
you learned something from writing the earlier PromptWhole.
Probably it is not worth keeping in our utility library
any longer, since we have 
the more general and safe PromptInt, and we can
restrict to many ranges with PromptIntInRange.

We will arrange for these functions to be a library class later.
For now just develop and test them in this one class. 

.. _safest-input-int:

Safest PromptInt Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

With the suggestions so far the in the previous exercise,
``IsIntString`` will catch a strange stray character, and be
sure that the string for an *integer* is entered, but an ``int`` is
not an arbitrary integer:  it has limited range, between
``int.MinValue`` =  -2147483648 and ``int.MaxValue`` = 2147483647.

Revise the ``IsIntString`` function of the previous
exercise so that it checks that the result is in range, too, allowing
the PromptInt function to be totally reliable.

There is a problem:  your current version of IsIntString is likely
to accept a string like ``"9876543210"``, and you cannot convert it to an 
``int`` to do the comparison to see that it is in fact 
too large for an ``int``!  Catch 22?

There is an alternate approach involving comparing strings, not numbers.  

There is a string instance method::

    public int CompareTo(string t)
    
It does roughly lexicographical string comparisons, so  ::

    s.CompareTo(t) <= 0
    
is true when s "comes before" t or is equal to t.  This works with 
alphabetizing letter strings:  "at" comes before "ate" which comes before
"attention" which comes before "eat".  It also works with digit strings
*of the same length* 
to give the same relationship as the corresponding numbers::

    "123456890".CompareTo("2147483647") <= 0

is true, and ::

    "9876543210".CompareTo("2147483647") <= 0

is false.  

This idea can be leveraged into a completely reliable version of IsIntString.
(With this approach you could also create an IsLongString very similarly,
but we skip it since it teaches you nothing new.)

The idea of a ``CompareTo`` method is much more general 
and is used much later in :ref:`rationals-revisited`.
