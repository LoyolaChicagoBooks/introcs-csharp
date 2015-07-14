Lab: File Data and Collections
===================================

Goals for this lab:
----------------------

-  Read a text file.
-  Work with loops.
-  Work with a Dictionary and a List.
-  Retrieve a random entry.

Overview
~~~~~~~~~~

Copy project :repsrc:`dict_lab_stub` to your own project.

This lab provides a replacement file 
:repsrc:`fake_help.cs <dict_lab_stub/fake_help.cs>` for an improved
project.  The project still needs some additions in a helper class.

Before we get there, open the comparison program
:repsrc:`fake_help_verbose/fake_help_verbose.cs` and
look at the methods ``GetParagraphs()`` and ``GetDictionary()``.
All the strings for the responses are pre-coded for you there, but if
you were writing your own methods, it would be a pain. There is all the
repetitious code to make multiline strings and then to add to the
List and Dictionary. This lab will provide simple versatile methods to
fill a ``List<string>`` or a ``Dictionary<string, string>``: You only need
you to write the string data itself into a text file, with the only
overhead being a few extra newlines. Minor further adaptations could
save time later in a project, too.

Look in your copy of 
:repsrc:`fake_help.cs <dict_lab_stub/fake_help.cs>`.  
It creates the ``List`` ``guessList`` and the
``Dictionary`` ``responses`` using more general functions that you need to fill in. 
The stubs for these new versions are put in 
the class ``FileUtil`` for easy reuse.  ``Main`` calls these functions 
and chooses the files to read.
The results will look the same as the original program to the user, 
but the second version will be easier 
for a programmer to read and generalize:  It will be easier in other situations 
where you want lots of canned data 
in your program (like in a game you might write soon).

The stub should run as is
(mostly saying things are not implemented).
Test out your work at every stage!

You will need to complete very short versions of functions
``GetParagraphs`` and ``GetDictionary`` that have been moved to
:repsrc:`file_util.cs <dict_lab_stub/file_util.cs>`
and now
take a ``StreamReader`` as parameter.
The files that they read will contain the basic data.  
You can look in the lab project at the first data file:
:repsrc:`help_not_defaults.txt <dict_lab_stub/help_not_defaults.txt>`, 
and the beginning is shown below:  

.. literalinclude:: ../source/examples/dict_lab_stub/help_not_defaults.txt
   :language: none
   :lines: 1-15

You can see that it includes the data for the welcome
and goodbye strings followed by all the data to go in the ``List`` of random answers.

One complication is that many of these strings take up several lines, in what we call
a *paragraph*.  We follow a standard convention for putting paragraphs into plain text: 
Put a blank line after a paragraph to mark its end.  As you can see, that is how 
:repsrc:`help_not_defaults.txt <dict_lab_stub/help_not_defaults.txt>` is set up. 

Steps
-----------------

All of the additions you need to make are in bodies of function 
definitions in the class ``FileUtil``.  Look back to ``Main`` in ``FakeAdvise`` to
see how the functions from ``FileUtil`` are actually used:  The 
``StreamReader`` is set up to read from the right file.  The the ``FileUtil`` functions
``ReadParagraph``, ``GetParagraphs``, and ``GetDictionary`` are used to provide
the text data needed. 

ReadParagraph
~~~~~~~~~~~~~~

The first method to complete in 
:repsrc:`file_util.cs <dict_lab_stub/file_util.cs>`
is useful by itself and later for use in the 
``GetParagraphs`` and ``GetDictionary`` that you will complete.  See the stub:

.. literalinclude:: ../source/examples/dict_lab_stub/file_util.cs
   :start-after: ReadParagraph chunk
   :end-before: chunk

The first call to ``ReadParagraph``, using the file illustrated above, should
return the following (showing the escape codes for the newlines)::

    "Welcome to We-Give-Answers!\nWhat do you have to say?\n"

and then the reader should be set to read the goodbye paragraph
(the next time ``ReadParagraph`` is called).

To code, you can read lines one at a time, and append them to the part of the
paragraph read so far. There is one thing to watch out for: The
``ReadLine`` function *throws away* the following newline (``"\n"``) in the input. You
need to preserve it, so be sure to explicitly add a newline, back onto
your paragraph string after each nonempty line is added. The returned
paragraph should end with a single newline. 

Throw away the empty line
in the input after the paragraph. Make sure you stop after reading
the empty line.  It is very important that you advance the reader
to the right place, to be ready to read the next paragraph. 

Be careful of a pitfall with files:  You can only read a given chunk once:  
If you read again, with the exact same syntax,
you get the *next* line of the file.  The ``ReadLine`` method
has the *side effect* of advancing the reading position in the file.

**Testing**: This first short ``ReadParagraph`` function should actually be most of 
the code that you write for the lab!  The program is set up so you can immediately
run the program and test ``ReadParagraph``:  It is called to read in the welcome string
and the goodbye string for the program, so if those come correctly to the screen, you
can advance to the next two parts.  

GetParagraphs
~~~~~~~~~~~~~~~~

Since you have ``ReadParagraph`` at your disposal, you now only need to
insert a *few remaining lines of code* to complete the next method
``GetParagraphs``, that reads to the end of the file, and likely
processes more than one paragraph.  

.. literalinclude:: ../source/examples/dict_lab_stub/file_util.cs
   :start-after: GetParagraphs chunk
   :end-before: chunk

Look again at 
:repsrc:`help_not_defaults.txt <dict_lab_stub/help_not_defaults.txt>`, 
to see how the data is set up.

This lab requires very few lines of code. Be sure to read the examples
and instructions carefully (several times). A lot of ideas get packed
into the few lines!

**Testing**: After writing ``GetParagraphs``, the random
responses in the lab project program should work as the user enters lines in the program.

GetDictionary
~~~~~~~~~~~~~~~

The last stub to complete in :repsrc:`file_util.cs <dict_lab_stub/file_util.cs>` 
is ``GetDictionary``.  Its
stub also takes a ``StreamReader`` as parameter.  In 
``Main`` this function is called to read from
:repsrc:`help_not_responses.txt <dict_lab_stub/help_not_responses.txt>`.  
Here are the first few lines:

.. literalinclude:: ../source/examples/dict_lab_stub/help_not_responses.txt
   :language: none
   :lines: 1-15

Here is the stub of the function to complete, reading such data:

.. literalinclude:: ../source/examples/dict_lab_stub/file_util.cs
   :start-after: GetDictionary chunk
   :end-before: chunk
   :dedent: 6

**Testing**: 
When you complete this function, the program should behave 
just like the earlier
verbose version with the hard-coded data, using a dictionary value
if it finds the right key, 
or choosing a random response if there is no key match.

Be careful to distinguish the data file 
:repsrc:`help_not_responses.txt <dict_lab_stub/help_not_responses.txt>` 
from
:repsrc:`help_not_responses2.txt <dict_lab_stub/help_not_responses2.txt>`, 
used in the extra credit option.

This should also be an extremely short amount of coding!  
Think of following through the data file, and get the corresponding 
sequence of instructions to handle the data in the exact same sequence. 

Show the program output to a TA (after the extra credit if you like).

Extra credit 
~~~~~~~~~~~~~~~~~~~~~~
    
#.  (20%) Modify ReadParagragh so it *also* works if the paragraph ends 
    at the end of the file, with no blank line after it, or if the line after
    the paragraph only has whitespace characters.  Both changes are good to
    bullet-proof the code, since
    the added or removed whitespace is hard to see in print.
    
#.  (20%) The crude word classification scheme would recognize "crash", but not
    "crashed" or "crashes".  You could make whole file entries
    for each key variation, repeating the value paragraph.  
    A concise approach is to use a data file
    like :repsrc:`help_not_responses2.txt <dict_lab_stub/help_not_responses2.txt>`.  
    Here are the first few lines:

    .. literalinclude:: ../source/examples/dict_lab_stub/help_not_responses2.txt
       :language: none
       :lines: 1-15
       :dedent: 12

    The line that used to have one key now may have several blank-separated keys.

    Here is how the documentation for ``GetDictionary`` should be changed:

    .. literalinclude:: ../source/examples/dict_lab_stub/file_util.cs
       :start-after: Extra credit documentation
       :end-before: }

    Modify the lab project to use this file effectively:  Find
    "help_not_responses.txt" on line 22 in ``Main``.  Change it to
    "help_not_responses2.txt" (inserting '2'), so ``Main`` reads it.

    In your test of the program, be sure to use several of the keys that apply to the
    same response, and show to your TA.
