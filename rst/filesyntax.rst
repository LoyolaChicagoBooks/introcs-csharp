.. index:: files

.. _files:

File Syntax
============================ 

You already know how to use the ReadLine and WriteLine functions for Console.  
With a bit more setup you can use similar syntax for files.
Miles has a good basic introduction, page 71, section 3.6.  Read it.

Files are objects, like arrays, and use the ``new`` syntax to create a new one. 

The last piece of example code in Miles 3.6 is correct, but verbose.  
It has the condition::

    (reader.EndOfStream == false)
    
Shorter (and not suggesting you are a newbie)::

    (!reader.EndOfStream)
