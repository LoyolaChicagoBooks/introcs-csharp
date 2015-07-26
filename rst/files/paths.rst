.. index:: path

.. _path-strings:

Path Strings
====================

When a program is running, there is alway a *current working directory*.  
When you run a project through Xamarin Studio, by default the current directory is the directory
two levels below the project directory.
   
Files in the current working directory can to referred to by their simple names,
e.g., *sample.txt*.  

Referring to files not in the current directory is more complicated.  
You should be aware from using the Windows Explorer or the Finder that
files and  directories are located in a hierarchy of directories in the
file system.  On a Mac, the file system is unified in 
one hierarchy. On Windows, each drive has its own hierarchy.

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

Paths starting from the root of a file system, with ``\`` or ``/`` are called
*absolute paths*.
Since there is always a current directory, it makes sense to allow a path to be *relative*
to the current directory.  In that case do *not* start with the slash that would
indicate the root directory.  For example, if the current directory is
your home directory, you likely have a subdirectory :file:`Downloads`, and the 
:file:`Downloads`
directory might contain :file:`examples.zip`.  From the home directory, this file could
be referred to as :file:`Downloads\\examples.zip` or  :file:`Downloads/examples.zip` on a Mac.

Relative to a Xamarin Studio project directory, the current directory for execution
of the program is :file:`bin\\Debug` or  :file:`bin/Debug` on a Mac.

Referring to files in the current directory just by their plain file name is
actually an example of using relative paths.

With relative paths, you sometimes want to move up the directory hierarchy:  ``..``
(two periods) refers to the directory one level up the chain.  

Next imagine reversing the relative path from a Xamarin Studio project directory to the
current directory for execution:  If the current directory is the execution 
directory, then ``..`` refers to directory :file:`bin`, and then
``..\..`` or ``../..`` refers to the project directory.  Further, if the 
project directory contains the file :file:`numbers.txt`, then it could be referred to
relative to the execution directory as 
:file:`..\\..\\numbers.txt` or :file:`../../numbers.txt`.

Occasionally you need to
refer explicitly to the current directory:  It is referred to as "." (a single
period).

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
``Path.Combine("..", "..", "numbers.txt")`` will return a string with characters
``..\..\numbers.txt`` or ``../../numbers.txt``.  

Even if you know you are going to be on Windows, file paths are a problem because
``\`` is the string escape character.  To enter the Windows path above explicitly
you would need to have ``"..\\..\\numbers.txt"``, or the raw string prefix,
``@`` can come to the rescue:  ``@"..\..\numbers.txt"``.

You can look at the ``Path`` class in the MSDN documentation 
for many other operations with path strings.

Path strings are used by the :ref:`directory-class` and by the :ref:`file-class`.

