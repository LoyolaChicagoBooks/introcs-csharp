.. index::  string; methods
   
.. _more-string-methods:
	
More String Methods
---------------------------

Before we do more elaborate things with strings, some more string methods
will be helpful.  Be sure you are familiar with the earlier discussion of 
strings in 
:ref:`basic-string-ops`.

Play with the new string methods in csharp!

This variation of ``IndexOf`` has a second parameter:

.. index::
   double: string; IndexOf
   
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

.. index::
   double: string; Trim
   
``string Trim()``   
    Returns a string formed from **this** string object, but
    with leading and trailing whitespace removed. Example:: 
    
        csharp> string s = "\n  123    ";
        csharp> "#" + s + "#";
        #
          123   #
        csharp> "#" + s.Trim() + "#";
        #123#

.. index::
   double: string; Replace
   
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

.. index::
   double: string; StartsWith
   
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

.. index::
   double: string; EndsWith
   
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


.. index::
   double: exercise; CountRep

.. _countrep:

Count Repetitions in a String
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Write a program :file:`TestCountRep.cs`, with a Main testing method,
that tests a function with the following heading::

   /**Return the number of separate repetitions of target
    * in s. */
  static int CountRep(string s, string target)

For example here is what ``CountRep( "Mississippi", target)`` 
would return with various values for ``target``:
  
      | ``"i"``: 4
      | ``"is"``: 2
      | ``"sss"``: 0

Assume each repetition is completely separate, so
``CountRep("Wheee!", "ee")`` returns 1.  The last
two e's do not count, since the middle e is already
used int he match of the first two e's.

      
.. index::
   double: exercise; safe InputInt
   double: exercise; safe InputDouble
   
.. _safe-input-number:

Safe InputInt and InputDouble Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Save the example ``SafeNumberInputStub.cs`` as ``SafeNumberInput.cs``.

The idea is to write safe versions of the utility functions
InputInt and InputDouble (which can then be used in further
places like InputIntInRange).  

Be sure you are familiar with :ref:`safe-whole-number-input`,
and the development of its ``InputWhole`` function.

A legal whole number string consists entirely of digits.  We have
already written example ``IsDigits`` to identify a string for a
whole number.

The  improvements to InputInt and InputDouble are 
very similar and straightforward *if* you have developed the two main
Boolean support functions,
``IsIntString`` and``IsDecimalString`` respectively.  

The issue with integer and decimal strings 
is that they may include parts other than
digits.  An integer may start with a minus sign.  A
decimal number can also contain a decimal point in an appropriate 
place.  The suggestion is to confirm that these other characters appear in
legal places, remove them, and see that what is left is digits. 
The recently introduced string methods should help....

Develop the functions in order and test after each one:
write ``IsIntString``, revise ``InputInt``, 
write ``IsDecimalString``, and revise ``InputDouble``.

Be sure to test carefully.  Not only confirm that all
appropriate strings return ``true``:
Also be sure to test that you return ``false"`` 
for *all* sorts of bad strings.  

Hopefully
you learned something from writing the earlier InputWhole.
Probably it is not worth keeping in our utility library
any longer, since we have 
the more general and safe InputInt, and we can
restrict to many ranges with InputIntInRange.  
