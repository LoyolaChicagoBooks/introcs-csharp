.. index:: files

.. _files:

File Syntax
============================ 

You already know how to use the ReadLine and WriteLine functions for Console.  
With a bit more setup you can use similar syntax for files.
Miles has a good basic introduction, page 71, section 3.6.  Read it.

A couple of comments:

Files are objects, like arrays, and use the ``new`` syntax to create a new one. 

The last piece of example code in Miles 3.6 is correct, but verbose.  
It has the condition::

    (reader.EndOfStream == false)
    
Shorter (and not suggesting you are a newbie)::

    (!reader.EndOfStream)

We are not sure why Miles first declared an input file, ``reader``,
as a ``TextReader`` rather than a ``StreamReader``.  In later discussion of
inheritance, we will see more about how one type of object can be declared as another.

Without comment he switches
in the ``EndOfStream`` testing to declaring ``reader`` as a ``StreamReader``, which
has more capacities than a ``TextReader``, in particular it has the property ``EndOfStream``.
The simpler thing would be to us a StreamReader declaration consistently.  
Also in that case you could use the more compact declaration with ``var``::

    var reader = new StreamReader("test.txt");

Things to note about reading from files:

.. index::
   double:  StreamReader; null from ReadLine
   
- Reading from a file returns the part read, of course.  Never forget the
  *side effect*:  The location in the file advances past the part just read.
  The next read does *not* return the *same* thing as last time.  It returns
  the *next* part of the file.
- Our ``while`` test conditions so far have been in a sense "backward looking":
  We have tested a variable that has already been set.  The test with ``EndOfStream`` is
  *forward looking*:  looking at what has not been processed yet.  Other than
  making sure the file is opened, there is no variable that needs to be set
  before a ``while`` loop testing for ``EndOfStream``.
- If you use ReadLine at the end of the file, the special value ``null`` (no object)
  is returned.  *This* is not an error, but if you try to apply any string methods
  to the ``null`` value returned, *then* you get an error.

.. index::
   double: file; ReadToEnd
   double: StreamReader; ReadToEnd
  
.. _ReadToEnd:

If you just want the whole file read in at once as a single (multiline) string, use the
``StreamReader`` method ``ReadToEnd``::

    var reader new StreamReader("someFile.txt");
    string wholeFile = reader.ReadToEnd();
    reader.close();
    
Example: Sum Number From Each File Line
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

We have summed the numbers from 1 to ``n``.  In that case we generated
the next number ``i`` automatically using i++.  We coud also read numbers
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

Below and in project ``Files/SumFile/SumFile.cs`` is a more elaborate, complete example,
that also skips lines that contain only whitespace.  
``Main`` takes a command line parameter containing the filename, and it gives several checks
and warning messages.  

.. literalinclude:: ../projects/Files/SumFile/SumFile.cs

A useful function used in ``Main`` for avoiding filename typo errors 
is in the System.IO namespace :: 

    bool File.Exists(string filenamePath) 

It is true if the filename exists.

See :ref:`monodevelop-run-with` for testing SumFile.cs inside MonoDevelop.  

.. index::
   double: MonoDevelop; working directory
   double: MonoDevelop; execution arguments
   double: MonoDevelop; custom execution
   
.. _monodevelop-run-with:
   
Setting the Working Directory and Command Line Arguments in MonoDevelop
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

..  warning::

    If you are using files with MonoDevelop, note that the *default* directory to start from
    when running a program, is the subdirectory :file:`bin/Debug`.  
    We will keep data files in the 
    main project directory.  To avoid needing directory path names with test data, 
    you need to make sure the working directory matches the test data location.
    
Before you run your program:

-   Select in the menu :menuselection:`Run --> Run With --> Edit Custom Modes...`.
-   This brings up the dialog window, Custom Execution Modes.  
    Click the :guilabel:`Add` button.
-   This is one way to reach the dialog window, Execution Arguments.
    The first field is Arguments.  This lets you set command line arguments to 
    pass to the ``string[] args`` parameter in ``Main``. 
    If you want to be able to change the parameters to a new value each time you run,
    click on the check-box in the bottom left corner of the window, 
    "Always show the parameters...".
-   Browse to select the working directory, like the project directory.
-   Particularly if you want to add several settings, you can change the identifying 
    name at the bottom Custom Mode Name field to something more descriptive than
    Default (Custom).

Later when running your program:

-   Select in the menu :menuselection:`Run --> Run With`, and click on the name you chose
    to describe the custom way to run your program.

You can add a text data file as a part of your project in your project directory by 
:menuselection:`File --> New --> File`, bringing up the New File dialog.
Select Misc on the left column 
and then Empty Text File in the next column, and enter the file name.

You can test all of this with the project ``Files/SumFile``.  There is a test file in the
project directory :file:`numbers.txt`.  You could make a custom run mode using the
command line parameter ``examples.txt`` and setting the working directory to the project
directory :file:`SumFile`.  You might want to copy the project to your repository. open
it in MonoDevelop, add a new data file, and use that as a command line parameter.

Example Copy to Upper Case
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Here is a simple example copying a file line by line to a new file in upper case::

         var reader = new StreamReader("Text.txt");
         var writer = new StreamWriter("UpperText.txt");
         while (!reader.EndOfStream) {
            string line = reader.ReadLine();
            writer.WriteLine(line.ToUpper());
         }
         reader.Close();
         writer.Close();

You can try this in csharp:

- First create a :file:`Text.txt`, 
- Open csharp in the same directory.
- Give the command in csharp::

    csharp> using System.IO;

- Then paste the lines above.

Outside of csharp you can look at UpperText.txt.

This example of line by line processing was intended to be simple.  
In fact this processing is
so simple, we could consider the whole file as one big string.  
We could get the same result if the entire ``while`` loop were replaced by::

    string contents = reader.ReadToEnd();
    writer.Write(contents.ToUpper());

``ReadToEnd`` does not strip off a newline, like ``ReadLine`` does,
so we do not want to add an extra newline
when writing.  We use ``Write`` instead of ``WriteLine``.
