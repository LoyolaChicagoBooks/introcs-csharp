``foreach`` Examples
=====================

.. index::    char; underlying numeric code

.. _codeofstringchar:

In :ref:`IsDigits <IsDigits>` we use the underlying int Unicode value
of the characters in comparisons.  
When printing, you cannot see this code directly,
since the ``char`` type prints as *characters*!
To see the underlying code value for a character, ch,
it can be cast to an int:  ``(int)ch``

We can easily write a loop to print the unicode value of each character in a
string, ``s``.  We do not need indices here, so a ``foreach`` loop is
appropriate::

   foreach (char ch in s) {
       Console.WriteLine("Unicode for {0} is {1}.", ch, (int)ch);
   }
   
Try this in csharp.

We will have many more examples after we introduce more kinds of sequences.
   




