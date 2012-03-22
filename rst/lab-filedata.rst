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

The idea of this lab is to replace project file 
:file:`projects/Dictionaries/FakeAdviseVerbose/MainVerbose.cs` with an improved
project. 

Open the original :file:`projects/Dictionaries/FakeAdviseVerbose/MainVerbose.cs` and
look at the methods ``GetParagraphs()`` and ``GetDictionary()``.
All the strings for the responses are pre-coded for you there, but if
you were writing your own it would be a pain. There is all the
repetitious code to make multiline strings and then to add to the
List and Dictionary. This lab will provide simple versatile methods to
fill a ``List<string>`` or a ``Dictionary<string, string>`` which only need
you to write the string data itself into a text file, with the only
overhead being a few extra newlines. Minor further adaptations could
save time later in your game project, too.

In the revised lab project with Main class 
:file:`projects/Dictionaries/FakeAdviseLab/MainLab.cs`,
the List and Dictionary filling code is made more general and moved
to the class FileUtil for easy reuse.  The main program chooses the files to read.
The results will look the same as the original program to the user, 
but the second version will be easier 
for a programmer to read and generalize to other situations 
where you want lots of canned data 
in your program (like in a game you might write soon).

You will need to complete very short versions of functions
``GetParagraphs`` and ``GetDictionary`` that have been moved to
:file:`projects/Dictionaries/FakeAdviseLab/FileUtil.cs` and now
take a StreamReader as parameter.
The files that they read will contain the basic data.  
You can look in the lab project at the first data file:
:file:`HelpNotDefaults.txt`, and the beginning is shown below:  

.. literalinclude:: ../projects/Dictionaries/FakeAdviseLab/HelpNotDefaults.txt
   :language: none
   :lines: 1-15

You can see that it includes the data for the welcome
and goodbye strings followed by all the data to go in the ``List`` of random answers.

One complication is that many of these strings take up several lines, in what we call
a paragraph.  We follow a standard convention for putting paragraphs into plain text: 
Put a blank line after a paragraph to mark its end.  As you can see, that is how 
:file:`HelpNotDefaults.txt` is set up. 

Steps
-----------------

All of the additions you need to make are in the class ``FileUtil``.

The class already has one completed method, ``GetDataReader``, 
that is a kludge to make opening files work either if the file is in the 
main project folder or two folders below with the exe file 
(so no need for special run configurations).  This function is used
in the Main program to read the two data files.

ReadParagraph
~~~~~~~~~~~~~~

The first method is useful by itself and later for use in the new
``GetParagraphs`` and ``GetDictionary``.  A stub is in :file:`FileUtil.cs`:

.. literalinclude:: ../projects/Dictionaries/FakeAdviseLab/FileUtil.cs
   :start-after: ReadParagraph chunk
   :end-before: chunk

The first call to ``ReadParagraph``, using the file illustrated above, should
return the following (showing and emphasizing the escape codes for the newlines)::

    "Welcome to We-Give-Answers!\nWhat do you have to say?\n"

and then the reader should be set to read the goodbye paragraph
(the next time ``ReadParagraph`` is called).

To code, you can read lines one at a time, and append them to the part of the
paragraph read so far. There is one thing to watch out for: The
ReadLine method *throws away* the following newline in the input. You
need to preserve it, so be sure to explicitly add a newline, ``"\n"``, back onto
your paragraph string after each nonempty line is added. The returned
paragraph should end with a single newline. Throw away the empty line
in the input after the paragraph. Make sure you stop after reading
the empty line.  Making sure you advance the reader
to the right place is very important.  

Be careful of a pitfall with files:  You can only read a given chunk once:  
If you read again you get the *next* part.

Fill in ``ReadParagraph`` first - this short function should actually be most of 
the code that you write for the lab!  The program is set up so you can immediately
run the program and test ``ReadParagraph``:  It is called to read in the welcome string
and the goodbye string for the program, so if those come correctly to the screen, you
can advance to the next two parts.  

GetParagraphs
~~~~~~~~~~~~~~~~

Since you have ReadParagraph at your disposal, you now only need to
insert a few remaining lines of code to complete the next method
``GetParagraphs``, that reads to the end of the file, and likely
processes more than one paragraph.  

.. literalinclude:: ../projects/Dictionaries/FakeAdviseLab/FileUtil.cs
   :start-after: GetParagraphs chunk
   :end-before: chunk

Look again at :file:`HelpNotDefaults.txt` to see how the data is set up.

This lab requires very few lines of code. Be sure to read the examples
and instructions carefully (several times). A lot of ideas get packed
into the few lines!

As a test after writing ``GetParagraphs``, the random
responses in the lab project program should work as enter lines in the program.

GetDictionary
~~~~~~~~~~~~~~~

The last stub to complete in :file:`FileUtil.cs`` is GetDictionary.  Its
stub is also modified to take a StreamReader as parameter.  In the
Main program this function is called to read from
:file:`HelpNotResponses.txt`.  Here are the first few lines:

.. literalinclude:: ../projects/Dictionaries/FakeAdviseLab/HelpNotResponses.txt
   :language: none
   :lines: 1-15

Here is the stub of the function to complete, reading such data:

.. literalinclude:: ../projects/Dictionaries/FakeAdviseLab/FileUtil.cs
   :start-after: GetDictionary chunk
   :end-before: chunk

When you complete this function, the program should behave like the earlier
verbose version with the hard-coded data.

Be careful to distinguish the data file :file:`HelpNotResponses.txt` from
:file:`HelpNotResponses2.txt`, used in the extra credit.

This should also be an extremely short amount of coding!  
Think of following through the data file, and get the corresponding 
sequence of instructions to handle the data in the exact same sequence. 

Show the program output to a TA (after the extra credit if you like).

Extra credit (1 point)
~~~~~~~~~~~~~~~~~~~~~~

The crude word classification scheme would recognize "crash", but not
"crashed" or "crashes".  You could make whole file entries
for each key variation, repeating the value paragraph.  
A concise approach is to use a data file
like :file:`HelpNotResponses2.txt`.  Here are the first few lines:

.. literalinclude:: ../projects/Dictionaries/FakeAdviseLab/HelpNotResponses2.txt
   :language: none
   :lines: 1-15

The line that used to have one key now may have several blank-separated keys.

Here is how the documentation for GetDictionary should be changed:

.. literalinclude:: ../projects/Dictionaries/FakeAdviseLab/FileUtil.cs
   :start-after: Extra credit documentation
   :end-before: }

Modify the lab project to use this file effectively:  Rename
"HelpNotResponses.txt" to "OneKeyResponses.txt" and then rename
"HelpNotResponses2.txt" to "HelpNotResponses.txt", so the Main program reads it.

In your test of the program, be sure to use several of the keys that apply to the
same response, and show to your TA.