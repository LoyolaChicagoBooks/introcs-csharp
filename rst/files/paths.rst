.. index:: path

.. _path-strings:

Path Strings
====================

When a program is running, there is alway a *current working directory*.  
Files in the current working directory can to referred to by their simple names,
e.g., *sample.txt*, so with our conventions, project files can be referred to by their simple names.  

Referring to files not in the current directory is more complicated.  
You should be aware from using the Windows Explorer or the Finder that
files and  directories are located in a hierarchy of directories in the
file system.  On a Mac, the file system is unified in 
one hierarchy. On Windows, each drive has its own hierarchy.

.. index:: / ; path separator
   single: \ ; path separator

Files are generally referred to by a chain of directories before
the final name of the file desired.  A *path string* is used
to represent such a sequence of names.  Elements of the directory chain are separated
by operating system specific punctuation:  In Windows the separator is backslash, \\,
and on a Mac it is (forward) slash, /.  For example on a Mac the path 

.. code-block:: none
    
   /Users/anh 
   
starts with a /, meaning the *root* or top directory in the hierarchy, and Users is
a subdirectory, and anh is a subdirectory of Users (in this case the home directory
for the user with login anh).  
It is similar with Windows, except there may be a drive in the beginning,
and the separator is a \\, so

.. code-block:: none
   
   C:\Windows\System32

is on C: drive; Windows is a subdirectory of the root directory \\, and System32 is
a subdirectory of Windows.  
Each drive in Windows has a separate file hierarchy underneath it.

.. index:: path; absolute

Paths starting from the root of a file system, with ``\`` or ``/`` are called
*absolute paths*.
Since there is always a current directory, it makes sense to allow a path to be *relative*
to the current directory.  In that case do *not* start with the slash that would
indicate the root directory.  For example, if the current directory is
your home directory, you likely have a subdirectory :file:`Downloads`, and the 
:file:`Downloads`
directory might contain :file:`examples.zip`.  From the home directory, this file could
be referred to as :file:`Downloads\\examples.zip` or  :file:`Downloads/examples.zip` on a Mac.

When you run a project through Xamarin Studio with the default setup, the current directory is the directory
two levels below the project directory, in a folder created by the system,
:file:`bin\\Debug` or  :file:`bin/Debug` on a Mac.
We choose to modify and simplify this in our projects working with files, so the Output Folder 
is just the project folder.

Referring to files in the current directory just by their plain file name is
actually an example of using relative paths.

.. index:: .. parent folder

With relative paths, you sometimes want to move up the directory hierarchy:  ``..``
(two periods) refers to the directory one level up the chain.  

For example, suppose you solve :ref:`safe_sum_file_ex` by puting your new project
safe_sum_file in the *same* solution as the original sum_file.  That means the parent folder
for both projects is the solution folder.  If you want to run your new :file:`safe_sum_file.cs`
program (assuming you made the Output Path be the project folder) 
and want tp open the :file:`numbers.txt`
file in the sum_file project, then, when prompted in the program, you would refer to the
file to read as :file:`..\\sum_file\\numbers.txt` in Windows or 
:file:`../sum_file/numbers.txt` on a Mac.  Follow this one step at a time:  
Starting from the :file:`safe_sum_file` project folder, where the program is running,
go up one folder (:file:`..`) to the solution folder, then down into the :file:`sum_file` project folder,
and refer to the :file:`numbers.txt` file in that folder.  

.. index:: . ; current folder

Occasionally you need to
refer explicitly to the current directory:  It is referred to as :file:`.`. (a single
period).

.. index:: Path class

Paths in C#
--------------

The differing versions of paths for Windows and a Mac are a pain to deal with. Luckily C#
abstracts away the differences.  It has a ``Path`` class in the ``System.IO`` 
namespace that provides many handy functions for dealing with paths in 
an operating system independent way:

For one thing, C# knows the path separator character for your operating system,
``Path.DirectorySeparatorChar``.
   
More useful is the function ``Path.Combine``, which takes any number of string parameters
for sequential parts of a path, and creates a single string appropriate for the
current operating system.  For example,
``Path.Combine("bin", "Debug")`` will return ``"bin\Debug"`` or ``"bin/debug"``
as appropriate.
``Path.Combine("..", "sum_file", "numbers.txt")`` will return a string with characters
``..\sum_file\numbers.txt`` or ``../sum_file/numbers.txt``.  

Even if you know you are going to be on Windows, file paths are a problem because
``\`` is the string escape character.  To enter the Windows path above explicitly
you would need to have ``"..\\sum_file\\numbers.txt"``, or the raw string prefix,
``@`` can come to the rescue:  ``@"..\sum_file\numbers.txt"``.

You can look at the ``Path`` class in the MSDN documentation 
for many other operations with path strings.

Path strings are used by the :ref:`directory-class` and by the :ref:`file-class`.

Path String Exercise
~~~~~~~~~~~~~~~~~~~~~~

In the path string illustration above to open :file:`numbers.txt`,
we assumed for simplicity that the sum_file and safe_sum_file 
projects were in the same Xamarin solution.
Imagine the following alternate assumptions, more like the way 
we suggested you actually set up your projects:

* You have your own solution including the 
  safe_sum_file project.
* Your solution's folder and the examples solution folder are both 
  subfolder of the
  same parent folder.
* You are running the safe_sum_file.cs program from your safe_sum_file project folder.
* You want the user to reference the :file:`numbers.txt` in the sum_file project inside 
  our examples project.

What path string would you enter to be able to open that file?

File Line Removal Exercise
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Complete the function described below, and make a Main program and
sample file to test it.  Modify the Xamarin defaults so the Output Path
is the project folder.  ::

    /// Take all lines from reader that do not start with startToRemove
    /// and copy them to writer.
    static void FileLineRemoval(StreamReader reader, StreamWriter writer
                                char startToRemove)
    
For example, in Unix/Mac scripts lines starting with ``'#'`` are
comment lines.  Making ``startToRemove`` be ``'#'`` would write only non-comment lines
to the writer.
