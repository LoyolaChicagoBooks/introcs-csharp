.. index:: 
   FIO file I/O
   library; FIO

.. _fio:

FIO Helper Class
=================

This is an **optional** section.  It was much more important before we realized how 
easily we much
simplified file manipulating projects by changing the Output Path setting.

Still there are a variety of situations where a program may want to access 
resources in the file system, without know ahead of time exactly which folder contains
the file resource.  The ``FIO`` library class that we display here illustrates how
a program can search for the directory in which a file resides, given a list
of folder options.  This section also illustrates use of methods from the ``Path`` and
``File`` classes.

In this case we are specifically thinking of two possible uses of 
program source files:  When executing, the project folder may
be the current directory or, in the default setup for Xamarain, the current directory
may be two folders down in :file:`bin/Debug`.

We use one idea that is discussed more in the next chapter:  We need a sequence
of directory strings to look through.  At this point we have only discussed
sequences of individual characters.   The variable ``paths``  
contains a sequence of directory paths to check.  
(More on the syntax comes up shortly in :ref:`array`.) 
In our case we make the
sequence contain
``"."``, the current directory, ``".."``, the parent directory, and
``Path.Combine("..", "..")``, the parent's parent.  
We make ``paths`` a static variable, so
it is visible in all the functions in the class.  

Then the sequence ``paths``
can be used in the ``foreach`` loop:

.. literalinclude:: ../../source/examples/fio/fio.cs
   :start-after: GetPath chunk
   :end-before:  chunk
   :dedent: 6

For each directory path in ``paths``, we create a ``filePath`` as if the
file were in that directory.  We return the first path that actually exists.
We allow for the file to not be in any of the directories in ``paths``.  If
we do not find it, we return ``null`` (no object).

For convenience, we have an elaboration, using ``GetPath``,
that directly opens the file to read:

.. literalinclude:: ../../source/examples/fio/fio.cs
   :start-after: OpenReader chunk
   :end-before:  chunk
   :dedent: 6

We have a variation on ``GetPath`` that just return the path to the 
directory containing the file.  Here is the heading:

.. literalinclude:: ../../source/examples/fio/fio.cs
   :start-after: GetLocation chunk
   :end-before:  chunk
   :dedent: 6


This is useful in case you want to later write into the same directory 
that you read from.  You can get a location from ``GetLocation`` and then
write to the same directory, creating a ``StreamWriter``. 
You can use the convenience function:

.. literalinclude:: ../../source/examples/fio/fio.cs
   :start-after: OpenWriter chunk
   :end-before:  chunk
   :dedent: 6

The entire ``FIO`` class is in 
:repsrc:`fio/fio.cs`

We illustrate the use of ``FIO`` functions in example file
:repsrc:`fio_usage/fio_usage.cs`:

.. literalinclude:: ../../source/examples/fio_usage/fio_usage.cs

If you look at the fio_usage project in our examples solution, you see that
``sample.txt`` is a file in the project folder.  The program
ends up writing to a new file in the same (project) directory.  Remember that even
though the new file :file:`output.txt`
appears in the project directory, it does not appear in the
Solution pad unless you add it to the project.  You can see it in the file system, 
and open it if you like.

This project was created with the default set up:  Output path 
two folders down.  If you change to Output path to the main project folder, 
it should still work.  If you open a terminal/console and go to the project directory, you can compile
and run this program, and it will also work.  
