.. index:: file (StreamWriter); read and close
   StreamReader; ReadLine
   close file

.. _fileread:

Reading Files
=============

In Xamarin Studio, go to project :repsrc:`print_first_file`.  Note that we have added a copy of 
:file:`sample.txt` as a project file, so it is an existing file in the project folder.  
You can open it and see that it is a copy of the file created in the last section.

It will be true of most all the programs for this chapter, but you might check that we have
modified the project Output Path to refer to the project folder, 
in this case with the path ending
``examples/print_first_file``.  This means :file:`sample.txt` will be in the
current directory when the program runs.

.. old
    Right click on the project in the Solution pad, and select "Open Containing Folder"
    or "Reveal in Finder". 
   
Run the example program
:repsrc:`print_first_file/print_first_file.cs`, shown below:

.. literalinclude:: ../../source/examples/print_first_file/print_first_file.cs

Now you have read a file and used it in a program.

In the first line of ``Main`` the operating system file (``sample.txt``) is
associated again with a C# variable name (``reader``),
this time for reading as a ``StreamReader`` object. 
A ``StreamReader`` can only open an existing file, so
``sample.txt`` must already exist.  

Again we have parallel names to those used with ``Console``,
but in this case the ``ReadLine`` method returns the next line from the file.
Here the string from the file line is assigned to 
the variable ``line``. Each call the ReadLine reads the
next line of the file.

Using the ``Close`` method is
generally optional with files being read. There is nothing to lose
if a program ends without closing a file that was being read. [#readclose]_

.. index:: StreamReader; EndOfStream
   EndOfStream 

.. _endofstream:
   
Reading to End of Stream
-------------------------

In ``first_file.cs``, we explicitly coded reading two lines.  You will often
want to process each line in a file, without knowing the total number of
lines at the time when you were programming.  
This means that files provide us with our
second kind of a sequence:  the sequence of lines in the file!
To process all of them will require a loop and a new test to make sure that you
have not yet come to the end of the file's stream: You can use the ``EndOfStream``
property. It has the wrong sense (true at the end of the file), so we negate it,
testing for ``!reader.EndOfStream`` to *continue* reading. 
The example program ``print_file_lines.cs`` 
reads and prints the contents of a file specified by the 
user, one line at a time:

.. literalinclude:: ../../source/examples/print_file_lines/print_file_lines.cs
    
.. index:: var
   type; var

``var``
   For conciseness (and variety) we declared ``reader`` 
   using the more compact syntax with ``var``::
   
      var reader = new StreamReader(userFileName);
   
   You can use ``var`` in place of a declared type to shorten your code 
   with a couple of restrictions:
   
   - Use an initializer, from which the type of the variable can be inferred.
   - Declare a local variable inside a method body or in a loop heading.
   - Declare only a single variable in the statement.
   
   We could have used this syntax long ago, but as the type names become longer, 
   it is more useful!

You can run this program. You need an existing file to read.  An obvious file is
the source file itself:  :file:`print_file_lines.cs`.

Things to note about reading from files:

.. index:: StreamReader; null from ReadLine
   ReadLine; null with StreamReader 
   
- Reading from a file returns the part read, of course.  Never forget the
  *side effect*:  The location in the file advances past the part just read.
  The next read does *not* return the *same* thing as last time.  It returns
  the *next* part of the file.
- Our ``while`` test conditions so far have been in a sense "backward looking":
  We have tested a variable that has *already been set*.  
  The test with ``EndOfStream`` is
  *forward looking*:  looking at what has not been processed yet.  Other than
  making sure the file is opened, there is no variable that needs to be set
  before a ``while`` loop testing for ``EndOfStream``.
- If you use ReadLine at the end of the file, the special value ``null`` (no object)
  is returned.  *This* is not an error, but if you try to apply any string methods
  to the ``null`` value returned, *then* you get an error!

.. index::
   file (StreamWriter); ReadToEnd
   StreamReader; ReadToEnd
   ReadToEnd
  
.. _ReadToEnd:

Though ``print_file_lines.cs`` was a nice simple illustration of a loop reading
lines, it was very verbose considering the final effect of the program,
just to print the whole file.  
You can read the entire remaining contents of a file
as a single (multiline) string, using the
``StreamReader`` method ``ReadToEnd``.  In place of the reading and printing
loop we could have just had::

    string wholeFile = reader.ReadToEnd();
    Console.Write(wholeFile);
    
``ReadToEnd`` does not strip off a newline, unlike ``ReadLine``,
so we do not want to add an extra newline
when writing.  We use the ``Write`` method instead of ``WriteLine``.

.. index:: example; sum_files.cs
   sum_files.cs example
       
Example: Sum Numbers in File
-------------------------------

We have summed the numbers from 1 to ``n``.  In that case we generated
the next number ``i`` automatically using ``i++``.  We could also read numbers
from a file containing one number per line (plus possible white space)::

      static int CalcSum(string filename)
      {
         int sum = 0;
         var reader = new StreamReader(filename);
         while (!reader.EndOfStream) {
            string sVal = reader.ReadLine().Trim();
            sum += int.Parse(sVal);
         }
         reader.Close();
         return sum;
      }

.. index:: File class; Exists
   Exists - File class method

Below and in :repsrc:`sum_file/sum_file.cs` is a more elaborate, complete example,
that also exits gracefully if you give a bad file name.
If you give a good file name, it skips lines that contain only whitespace.  

.. literalinclude:: ../../source/examples/sum_file/sum_file.cs

A useful function used in ``Main`` for avoiding filename typo errors 
is ``File.Exists`` in the ``System.IO`` namespace :: 

    bool File.Exists(string filenamePath) 

It is true if the named files exists in the operating system's file structure.  

You should see the files :repsrc:`sum_file/numbers.txt` and
:repsrc:`sum_file/numbers2.txt` in the Xamarin Studio project.  You can test
with them.  It is important to test all paths through the program: also do
put in a bad name and see that the program exits gracefully, as intended.

For files in the current folder, you can just use the plain file name.  
For other folders see :ref:`path-strings`.

.. bin/debug
    It is in the right form for the program.  If you run the program and enter the
    response:

    .. code-block:: none

       numbers.txt

    you should be told that the file does not exist.  Recall that the executable
    created by Xamarin Studio is two directories down through :file:`bin` 
    to :file:`Debug`.  This is the default 
    *current directory* when Xamarin Studio runs the program.
    You can refer to
    a file that is not in the current directory.  
    A full description is in the next section, but briefly, what we need now:
    The symbol for the parent directory is ``..``.  
    The hierarchy of folders and files are separated by
    ``\`` in Windows and ``/`` on a Mac,  so you can test the program successfully
    if you use the file name:
    ``..\..\numbers.txt`` in Windows and ``../../numbers.txt`` on a Mac.  On a Mac, running 
    the program looks like:

    .. code-block:: none

       Enter the name of a file of integers: ../../numbers.txt
       The sum is 16
    
.. bin/Debug
    In :ref:`fio` we will discuss a more flexible way of finding files to open, 
    that works well in Xamarin Studio and many other situations.
 
.. index:: exercise; safe sum
   safe sum exercise 
   
.. _safe_sum_file_ex:

Safe Sum File Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~

a.  Copy :file:`sum_file.cs` to a file :file:`safe_sum_file.cs` in a new project of yours. 
    *Be sure to modify the Output path option to just refer to the project folder!* 
    Modify the program: Write
    a new function with the heading below.  Use it in ``Main``, in place of the ``if`` 
    statement that checks (only once) for a legal file::         
   
      // Prompt the user to enter a file name to open for reading.
      // Repeat until the name of an existing file is given.
      // Open and return the file.
      public static StreamReader PromptFile(string prompt)

b.  A user who completely forgot the file name could be stuck in an infinite loop!
    Elaborate the function and program, so that an empty line entered means
    "give up", and ``null`` (no object) should be returned.  The main program needs to
    test for this and quit gracefully in that case.
    
Example Copy to Upper Case
--------------------------

Here is a simple fragment from example file :repsrc:`copy_upper/copy_upper.cs`.
It copies a file line by line to a new file in upper case:

.. literalinclude:: ../../source/examples/copy_upper/copy_upper.cs
   :start-after: chunk
   :end-before:  chunk
   :dedent: 9

You may test this in the Xamarin Studio example project copy_upper:  

#.  Expand the copy_upper project in the Solution pad.  The project
    includes the input file.  You may not see it at first.  You need to expand the folder
    for :file:`bin` and then :file:`Debug`.  You see :file:`text.txt`.  
#.  To see
    what else is in the project directory, 
    select
    "Open Containing Folder" or "Open in Finder" on a Mac.  
    You should see project file :file:`text.txt` but not :file:`upper_text.txt`.
    Leave that operating system file folder open.  
#.  Go back to Xamarin Studio and run the project.  Now look at the
    operating system folder again.  You should see :file:`upper_text.txt`.
    You can open it and see that it holds an upper case version of the contents
    of :file:`text.txt`.

This is another case where the ``ReadToEnd`` function could have eliminated the loop. 
[#finalNewline]_  ::

    string contents = reader.ReadToEnd();
    writer.Write(contents.ToUpper());


.. [#readclose]
   If, for some reason, you want to reread this same file while the
   same program is running, you need to close it and reopen it.

.. [#finalNewline]
   Besides the speed and efficiency of this second approach, 
   there is also a technical improvement:  There may or may not be
   a newline at the end of the very last line of the file.  The ``ReadLine``
   method works either way, but does not let you know the difference.  
   In the line-by-line version, there is always a newline after the
   final line written with ``WriteLine``.  
   The ``ReadToEnd`` version will have newlines exactly matching the input.

