.. index::
   double: file; read
   double: StreamReader; ReadLine
   double: StreamReader; class
   single: file; close

.. _fileread:

Reading Files
=============
   
Run the example program
``print_first_file.cs``, shown below:

.. literalinclude:: ../source/examples/print_first_file/print_first_file.cs

Now you have come full circle: what one C# program has written
into the file ``sample.txt``, another has read and displayed.

In the first line the operating system file (``sample.txt``) is
associated again with a C# variable name (``reader``),
this time for reading as a ``StreamReader`` object. 
A ``StreamReader`` can only open an existing file, so
``sample.txt``, must already exist.  

Again we have parallel names to those used with ``Console``,
but in this case the ``ReadLine`` method returns the next line from the file.
Here the string from the file line is assigned to 
the variable ``line``. Each call the ReadLine reads the
next line of the file.

Using the ``Close`` method is
generally optional with files being read. There is nothing to lose
if a program ends without closing a file that was being read. [#readclose]_

.. index::
   double: StreamReader; EndOfStream

.. _endofstream:
   
Reading to End of Stream
-------------------------

In ``first_file.cs``, we explicitly coded reading two lines.  You will often
want to process each line in a file, without knowing the total number of
lines ahead of time.  This will require a loop and a new test to make sure that you
have not yet come to the end of the file's stream.  You can use the ``EndOfStream``
property. It has the wrong sense (true at the end of the file), so we negate it,
testing for ``!reader.EndOfStream`` in the example program ``print_file_lines.cs``.
This little program reads and prints the contents of a file specified by the 
user, one line at a time:

.. literalinclude:: ../source/examples/print_file_lines/print_file_lines.cs
    
.. index:: 
   double: var; type

``var``
   For conciseness (and variety) we declared ``reader`` 
   using the more compact syntax with ``var``::
   
      var reader = new StreamReader(userFileName);
   
   You can use ``var`` in place of a declared type to shorten your code 
   with a couple of restrictions:
   
   - Use an initializer, from which the type of the variable can be inferred.
   - Declare a local variable inside a method or in a loop heading.
   - Declare a single variable in the statement.
   
   You could have used this syntax long ago, but as the type names become longer, 
   it is more useful!

Things to note about reading from files:

.. index::
   double:  StreamReader; null from ReadLine
   
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
   double: file; ReadToEnd
   double: StreamReader; ReadToEnd
  
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
    
``ReadToEnd`` does not strip off a newline, like ``ReadLine`` does,
so we do not want to add an extra newline
when writing.  We use the ``Write`` method instead of ``WriteLine``.

.. index::
   double: example; sum_files.cs
       
Example: Sum Numbers in File
-------------------------------

We have summed the numbers from 1 to ``n``.  In that case we generated
the next number ``i`` automatically using i++.  We could also read numbers
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

Below and in project ``files/sum_file.cs`` is a more elaborate, complete example,
that also skips lines that contain only whitespace.  

.. literalinclude:: ../source/examples/files/sum_file.cs

A useful function used in ``Main`` for avoiding filename typo errors 
is in the ``System.IO`` namespace is :: 

    bool File.Exists(string filenamePath) 

It is true if the named files exists in the file system.

.. index::
   double: example; copy file to upper case
   

Safe Sum File Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~

Copy :file:`sum_file.cs` to :file:`safe_sum_file.cs`.  Modify the program: Write
a new function with the heading below.  Use it in ``Main``, in place of the ``if`` 
statement that checks (only once) for a legal file::         

    // Prompt the user to enter a file name to open for reading.
    // Repeat until the name of an existing file is given.
    // Open and return the file.
    public static StreamReader PromptFile(string prompt)

Example Copy to Upper Case
--------------------------

Here is a simple fragment copying a file line by line to a new file in upper case::

         var reader = new StreamReader("text.txt");
         var writer = new StreamWriter("upper_text.txt");
         while (!reader.EndOfStream) {
            string line = reader.ReadLine();
            writer.WriteLine(line.ToUpper());
         }
         reader.Close();
         writer.Close();

You can try this in csharp:

- First create a :file:`text.txt`, 
- Open csharp in the same directory.
- Give the command in csharp::

    csharp> using System.IO;

- Then paste the lines above.

Outside of csharp you can look at upper_text.txt.

This is another case where ``ReadToEnd`` could have eliminated the loop. 
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

