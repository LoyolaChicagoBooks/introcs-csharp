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

Without coment he switches
in the ``EndOfStream`` testing to declaring ``reader`` as a ``StreamReader``, which
has more capacities than a ``TextReader``, in particular it has the property ``EndOfStream``.
The simpler thing would be to us a StreamReader declaration consistently.  
Also in that case you could use the more compact declaration with ``var``::

    var reader = new StreamReader("test.txt");
    
.. index::
   double: MonoDevelop; working directory
   double: MonoDevelop; execution arguments
   double: MonoDevelop; custom execution
   
.. _mondevelop-run-with:
   
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

    
    