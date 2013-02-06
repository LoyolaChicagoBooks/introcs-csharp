.. index:: 
   single: FIO; file I/O

.. _fio:

FIO Helper Class
=================

We have already discussed and used the ``UI`` class to aid keyboard input.
Now we are going to develop an ``FIO`` class for our libraries.  The ``FIO`` class aids
file input and output with MonoDevelop, and illustrates a number of
more generally useful ideas.

You saw in the last section how we might refer to ``numbers.txt`` in different
ways depending on the execution environment.  Our situation
is based on the particular choices made by the creators of MonoDevelop.
More generally, there are many times when a program may need a file 
that may be stored in one of several directories.

Our ``FIO`` class will address this issue, and we will set up the
parameters to work specifically with both MonoDevelop and command line
development.

We use one idea that is discussed more in the next chapter:  We need a sequence
of directory strings to look through.  At this point we have only discussed
sequences of individual characters.   The variable ``paths``  
contains a sequence of directory paths to check.  In our case we make the
sequence contain
``"."``, the current directory, ``".."``, the parent directory, and
``Path.Combine("..", "..")``, the parent's parent.  
We make ``paths`` a static variable, so
it is visible in all the functions in the class.  

Then the sequence ``paths``
can be used in the ``foreach`` loop:

.. literalinclude:: ../source/examples/fio/fio.cs
   :start-after: GetPath chunk
   :end-before:  chunk

For each directory path in ``paths``, we create a ``filePath`` as if the
file were in that directory.  We return the first path that actually exists.
We allow for the file to not be in any of the directories in ``paths``.  If
we do not find it, we return ``null`` (no object).

For convenience, we have an elaboration, using ``GetPath``,
that directly opens the file to read:

.. literalinclude:: ../source/examples/fio/fio.cs
   :start-after: OpenReader chunk
   :end-before:  chunk

We have a variation on ``GetPath`` that just return the path to the 
directory containing the file.  Here is the heading:

.. literalinclude:: ../source/examples/fio/fio.cs
   :start-after: GetLocation chunk
   :end-before:  chunk

This is useful in case you want to later write into the same directory 
that you read from.  You can get a location from ``GetLocation`` and then
write to the same directory, creating a ``StreamWriter``. Use the convenience
function:

.. literalinclude:: ../source/examples/fio/fio.cs
   :start-after: OpenWriter chunk
   :end-before:  chunk

The entire ``FIO`` class is in 
:repsrc:`fio/fio.cs`

We illustrate the use of ``FIO`` functions in example file
:repsrc:`fio_usage/fio_usage.cs`:

.. literalinclude:: ../source/examples/fio_usage/fio_usage.cs

IF you look at the fio_usage project in our examples solution, you see that
``sample.txt`` is a file in the project folder.  The program
ends up writing to a new file in the same (project) directory.  Remember that even
though the new file :file:`output.txt`
appears in the project directory, it does not appear in the
Solution pad unless you add it to the project.  You can see it in the file system, 
and open it if you like.

If you want to open a terminal/console and go to the project directory, you can compile
and run this program, and it will still work, even though the current directory
has changed.

You are encouraged to make a library project fio in *your* work solution, copying
the fio.cs file. (Follow instruction like for ui in 
:ref:`library-projects-in-monodevelop`.)  You can test your new library by also 
copying the fio_test project to your solution. 
If you do this now and stick to one work solution, then you will be ready for 
several later uses of ``FIO``.

