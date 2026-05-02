.. index:: file (StreamWriter); stream abstraction
   stream

.. _fileabstraction:

Files As Streams
============================ 

Thus far you have been able to save programs, but anything produced
during the execution of a program has been lost when the program
ends. Data has not *persisted* past the end of execution. Just as
programs live on in files, you can generate and read data files in
C# that persist after your program has finished running.

As far as C# is concerned, a file is just a string (often very
large!) stored on your file system, that you can read or write,
gradually, line by line, or all together.  

C# has the abstraction of a *stream*, 
as a sequence of characters to be processed sequentially.
A stream can either be written sequentially or read sequentially.
You have already read and written streams of 
characters to the Console.  Most of the syntax that we use for files will be very similar,
using methods ``ReadLine``, ``WriteLine``, and ``Write`` in the same way you
used them for the ``Console``.

Files can be handled very differently by different operating systems, but
C# abstracts away the differences and provides stream interfaces between
a C# program and files.
