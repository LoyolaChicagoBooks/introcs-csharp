.. index:: Visual Studio Code
   labs; Visual Studio Code
   dotnet command

.. _lab-edit-compile-run-code:

Lab: Editing, Compiling, and Running with Visual Studio Code
============================================================

This lab shows how to create, edit, compile, and run a small C# console
program using Visual Studio Code and the .NET command-line tools.  This is the
recommended graphical editor workflow for current versions of this course.

Prerequisites
-------------

Install these tools before starting:

- The .NET SDK, which provides the ``dotnet`` command.
- Visual Studio Code.
- The Microsoft C# Dev Kit extension for Visual Studio Code.

Microsoft's current setup guides are:

- `.NET command-line interface documentation <https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet>`_
- `Getting Started with C# in VS Code <https://code.visualstudio.com/docs/csharp/get-started>`_

Check that the .NET SDK is available by opening a terminal and entering:

.. code-block:: none

   dotnet --version

You should see a version number.  If you get a "command not found" message,
install the .NET SDK or fix your terminal path before continuing.

Create a Project
----------------

Choose a folder where you want to keep your course work.  In a terminal, move
to that folder and create a new console project:

.. code-block:: none

   mkdir hello-code
   cd hello-code
   dotnet new console --use-program-main

The ``--use-program-main`` option keeps the generated program close to the
style used in this book: an explicit class with a ``Main`` method.  Without
that option, current .NET templates use a shorter style called top-level
statements, which is useful later but less helpful while learning the basic
structure of C# programs.

Open the Project in Visual Studio Code
--------------------------------------

From the same terminal, open the project folder:

.. code-block:: none

   code .

If the ``code`` command is not available, open Visual Studio Code manually and
use File -> Open Folder... to open the ``hello-code`` folder.

In Visual Studio Code, open ``Program.cs``.  Replace its contents with:

.. code-block:: csharp

   using System;

   class Hello
   {
      static void Main()
      {
         Console.WriteLine("Hello, world!");
      }
   }

Save the file.  A quick way to save is Command-S on macOS or Ctrl-S on Windows
and Linux.

Build the Program
-----------------

Open the integrated terminal in Visual Studio Code with Terminal -> New
Terminal.  Make sure the terminal is still in the project folder, where the
``.csproj`` file is located.

Build the project:

.. code-block:: none

   dotnet build

If the build succeeds, you should see a message ending with something like:

.. code-block:: none

   Build succeeded.

If the build fails, read the first compiler error carefully.  Check for common
typing mistakes: missing semicolons, mismatched braces, misspelled names, or
quotes that do not match.

Run the Program
---------------

Run the project:

.. code-block:: none

   dotnet run

You should see:

.. code-block:: none

   Hello, world!

Try changing the string inside ``Console.WriteLine``.  Save, then run again:

.. code-block:: none

   dotnet run

For small programs, ``dotnet run`` is the command you will use most often.  It
builds the project if necessary and then runs it.

What Files Were Created?
------------------------

The project folder contains files and folders created by the .NET tools:

- ``Program.cs`` contains your C# source code.
- The ``.csproj`` file describes the project to the .NET build tools.
- ``bin`` and ``obj`` contain generated build output.

You normally edit ``Program.cs`` and other ``.cs`` files.  You normally do not
edit files in ``bin`` or ``obj``.

Exercise
--------

Modify the program so that it prints two separate lines.  Build and run it.
Then intentionally remove one semicolon, build again, and read the compiler
error.  Put the semicolon back and verify that the program runs.
